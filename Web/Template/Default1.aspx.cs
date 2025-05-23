using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Text;
using Common;
using System.Collections.Generic;
using Pbzx.Common;
using System.Xml;

namespace Pbzx.Web.Template
{
    public partial class Default : System.Web.UI.Page
    {
        public DateTime EndTime = DateTime.Now.Date;

        private int rowCount = 0;
        public string centerAD1 = "";
        public string rightAD1 = "";
        public string leftAD1 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Input.Encrypt("遨游版"));
            if (!IsPostBack)
            {
               
                //广告部分
                Pbzx.BLL.SaveAdPlaceType saveBll = new Pbzx.BLL.SaveAdPlaceType();
                List<Pbzx.Model.ObjAdPlace> ls = saveBll.GetAllList();

                Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\AdTypeConfig.xml");
                XmlNode root = xml.GetXmlRoot();
                XmlNode tempNodeG = root.SelectSingleNode("/root/child_0"); 

                if (tempNodeG.Attributes["IsOpen"].Value == "1")
                {
                    this.divGold.Visible = true;
                }
                else
                {
                    this.divGold.Visible = false;
                }

                XmlNode tempNodeT = root.SelectSingleNode("/root/child_1");
                if (tempNodeT.Attributes["IsOpen"].Value == "1")
                {
                    this.divText.Visible = true;
                }
                else
                {
                    this.divText.Visible = false;
                }


                Pbzx.BLL.PBnet_News newsBll = new Pbzx.BLL.PBnet_News();
                DataTable dt = newsBll.GetAllList().Tables[0];
                string href = "";
                string nvarTitle = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    href = dt.Rows[0]["SavePath"].ToString();
                    nvarTitle = dt.Rows[0]["NvarTitle"].ToString();
                }

                HotNewsOne = "<a href='" + href + "' target='_blank'>" + nvarTitle + "</a>";

                BindDataZY();

                BindDataDS();
                BindDataBZ();
                BindDataMF();
                BindDataAY();
                //绑定影音教程
                BindDataVideo();
                BindLinkPic();
                BindLinkText();
                BindGold();
                BindLetter();
                BindBroker();
                BindBulletin();
                BindNews();
                BindShool();
                BindSoft();
            }

        }

        /// <summary>
        /// 绑定最新更新
        /// </summary>
        private void BindSoft()
        {

            Pbzx.BLL.PBnet_Product ProductBll = new Pbzx.BLL.PBnet_Product();

           

            string tempSql = "select * from(select * from(SELECT TOP " + WebInit.pageConfig.IndexNewUpdateProduct + " pb_SoftID, pb_SoftName, pb_SoftVersion, pb_DownloadUrl1, pb_updatetime, 1 AS myType FROM PBnet_Product where " + Method.product + " and pb_indexshow=1  ORDER BY 5 DESC) t1 ";
            tempSql += " union ";
            tempSql += "select * from(SELECT TOP " + WebInit.pageConfig.IndexNewUpdateSoft + " PBnet_SoftID,  pbnet_SoftName, pbnet_SoftVersion, pb_DownloadUrl1, pb_updatetime, 2 AS myType FROM PBnet_soft where " + Method.soft + " and pb_indexshow=1  ORDER BY 5 DESC) t2) t order by t.pb_updatetime desc";


            DataSet dsProduct = DbHelperSQL.Query(tempSql);
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='95%' border='0' cellpadding='0' cellspacing='1'  bgcolor='#D8D8D8'>");
            sb.Append("<tr><td width='80%' bgcolor='#F4F4F4' align='left'>");
            sb.Append(" <strong>&nbsp;名称</strong>");
            sb.Append("</td><td width='20%' align='center' bgcolor='#F4F4F4'>");
            sb.Append("<strong>版本</strong>");
            sb.Append("</td></tr>");

            for (int i = 0; i < dsProduct.Tables[0].Rows.Count; i++)
            {
                DataRow tempRow = dsProduct.Tables[0].Rows[i];
                sb.Append("<tr><td bgcolor='#FFFFFF' align='left'>");
                if (tempRow["myType"].ToString() == "1")
                {
                    sb.Append("·<a href='Soft_explain.aspx?ID=" + Input.Encrypt(tempRow["pb_SoftID"].ToString()) + "' target='_blank' title='" + tempRow["pb_SoftName"].ToString() + "' >" + StrFormat.CutStringByNum(tempRow["pb_SoftName"], 13 * 2) + "</a>");
                }
                else
                {
                    sb.Append("·<a href='Source_explain.aspx?ID=" + Input.Encrypt(tempRow["pb_SoftID"].ToString()) + "' target='_blank' title='" + tempRow["pb_SoftName"].ToString() + "' >" + StrFormat.CutStringByNum(tempRow["pb_SoftName"], 13 * 2) + "</a>");
                }
                sb.Append("</td>");
                sb.Append("<td  align='center' bgcolor='#FFFFFF'  title='" + tempRow["pb_SoftVersion"].ToString() + "'>");
                sb.Append("" + tempRow["pb_SoftVersion"].ToString() + "");
                sb.Append("</td></tr>");
            }
            sb.Append("</table>");
            this.soft.InnerHtml = sb.ToString();
        }

        private void BindBroker()
        {
            Pbzx.BLL.PBnet_broker_content ContentBll = new Pbzx.BLL.PBnet_broker_content();

            dthaoc.DataSource = ContentBll.GetList("Btype='经纪人好处'and IsAuditing=1 order by IntSortID asc ");
            dthaoc.DataBind();
        }
        private void BindLetter()
        {

            Pbzx.BLL.PBnet_AdvPlace adBll = new Pbzx.BLL.PBnet_AdvPlace();
            this.dlletter.DataSource = adBll.GetList("ChannelID='" + (int)EadChanl.首页 + "' and PlaceType='首页头部文字广告区'");
            this.dlletter.DataBind();
        }
        public string Getletter(object num)
        {
            string letter = "";
            Pbzx.BLL.PBnet_Adv AdBll = new Pbzx.BLL.PBnet_Adv();
            List<Pbzx.Model.PBnet_Adv> ls = AdBll.GetModelList(" PlaceName='" + num.ToString() + "' ");
            if (ls.Count > 0)
            {
                Pbzx.Model.PBnet_Adv AdModel = ls[0];
                if (AdModel.pb_SiteName != "" && (AdModel.pb_ENDTime > DateTime.Now.Date) && AdModel.pb_IsSelected)
                {
                    letter += "<a href='" + AdModel.pb_SiteUrl + "' title='" + AdModel.pb_SiteUrl + "' target='_blank'>";
                    letter += "<font color='#0C0C0C'>" + AdModel.pb_SiteName + "</font>";
                    letter += "</a>";
                }
                else
                {
                    letter += "<a href='ADserve.htm' title='http://www.pinble.com' target='_blank'>";
                    letter += "<font color='#888888'>黄金广告位</font>";
                    letter += "</a>";
                }
            }
            else
            {
                letter += "<a href='ADserve.htm' title='http://www.pinble.com' target='_blank'>";
                letter += "<font color='#888888'>黄金广告位</font>";
                letter += "</a>";
            }
            return letter.ToString();
        }

        /// <summary>
        /// 绑定图片广告（金牌广告位）
        /// </summary>
        private void BindGold()
        {
            Pbzx.BLL.PBnet_AdvPlace adBll = new Pbzx.BLL.PBnet_AdvPlace();
            this.dlGold.DataSource = adBll.GetList(" ChannelID='" + (int)EadChanl.首页 + "' and PlaceType='首页头部图片广告区' ");
            this.dlGold.DataBind();
        }


        public string GetAdPic(object num)
        {
            string gold = "";
            Pbzx.BLL.PBnet_Adv AdBll = new Pbzx.BLL.PBnet_Adv();
            List<Pbzx.Model.PBnet_Adv> ls = AdBll.GetModelList(" PlaceName='" + num.ToString() + "' ");
            if (ls.Count > 0)
            {
                Pbzx.Model.PBnet_Adv AdModel = ls[0];
                if (AdModel.pb_ImgUrl != "" && (AdModel.pb_ENDTime > DateTime.Now.Date) && AdModel.pb_IsSelected)
                {
                    if (AdModel.pb_IsFlash)
                    {
                        gold += "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "'>";
                        gold += "<param name='movie' value='" + AdModel.pb_ImgUrl + "' />";
                        gold += "<param name='quality' value='high' />";
                        gold += " <param name='wmode' value='transparent' />";
                        gold += "<embed src='" + AdModel.pb_ImgUrl + "'  width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>";
                        gold += "</object>";

                    }
                    else
                    {
                        gold += "<a href='" + AdModel.pb_SiteUrl + "' title='" + AdModel.pb_SiteName + "' target='_blank'>";
                        gold += "<img border='0' src='" + AdModel.pb_ImgUrl + "' width='" + AdModel.pb_ImgWidth + "' height='" + AdModel.pb_ImgHeight + "'>";
                        gold += "</a>";
                    }
                }
                else
                {
                    gold += "<a href='ADserve.htm' title='拼搏在线' target='_blank'>";
                    gold += " <img src='../Images/AD/Gold.gif' width='245' height='36'>";
                    gold += "</a>";
                }
            }
            else
            {
                gold += "<a href='ADserve.htm' title='拼搏在线' target='_blank'>";
                gold += " <img src='../Images/AD/Gold.gif' width='245' height='36'>";
                gold += "</a>";
            }
            return gold.ToString();
        }
        private string _hotNewsOne;

        public string HotNewsOne
        {
            get { return _hotNewsOne; }
            set { _hotNewsOne = value; }
        }

        private void BindDataZY()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            DataTable dsZY = MyBLL.GetListTitleCount(18, "pb_TypeName='专业版'and " + Method.IndexProduct + " ");

            DataTable dtGS = MyBLL.GetListTitleCount(18, "(pb_TypeName='出票系统') and " + Method.IndexProduct + " ");
            for (int i = 0; i < dtGS.Rows.Count; i++)
            {
                DataRow myRow = dsZY.NewRow();
                myRow.ItemArray = dtGS.Rows[i].ItemArray;
                dsZY.Rows.Add(myRow);
            }
            this.zhuanye.DataSource = dsZY;
            this.zhuanye.DataBind();
            rowCount = zhuanye.Rows.Count;
        }
        private void BindDataDS()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            this.dansha.DataSource = MyBLL.GetListTitleCount(18, "pb_TypeName='胆杀版' and " + Method.IndexProduct + " ");
            this.dansha.DataBind();
        }
        private void BindDataBZ()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            this.biaozhun.DataSource = MyBLL.GetListTitleCount(18, "pb_TypeName='标准版' and " + Method.IndexProduct + "  ");
            this.biaozhun.DataBind();
        }
        private void BindDataMF()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            this.mianfei.DataSource = MyBLL.GetListTitleCount(18, "pb_TypeName='免费版' and " + Method.IndexProduct + "  ");
            this.mianfei.DataBind();
        }
        private void BindDataAY()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            this.aoyou.DataSource = MyBLL.GetListTitleCount(18, "pb_TypeName='遨游版' and " + Method.IndexProduct + "  ");
            this.aoyou.DataBind();
        }
        //private void BindBlog()
        //{
        //    this.Repeater2.DataSource = DbHelperSQLBlog.Query("SELECT TOP 8 * from oblog_user where user_isbest=1 order by lastlogintime  desc");
        //    this.Repeater2.DataBind();
        //}

        //资源下载
        private void BindDataVideo()
        {
            Pbzx.BLL.PBnet_Soft MyBLL = new Pbzx.BLL.PBnet_Soft();
            //this.rptVideo.DataSource = MyBLL.GetListTitleCount(4, "pb_DemoUrl='彩神通软件使用教程'");
            //this.rptVideo.DataBind();
            //this.rptVideo1.DataSource = MyBLL.GetListTitleCount(8, "pb_DemoUrl='彩神通技巧讲座' and  " + Method.IndexYYJC + " ");
            this.rptVideo1.DataSource = MyBLL.GetListTitleCount(int.Parse(WebInit.pageConfig.IndexSoft), " " + Method.IndexYYJC + " ");
            this.rptVideo1.DataBind();
        }


        protected void dansha_DataBound(object sender, EventArgs e)
        {
            if (dansha.Rows.Count < rowCount)
            {
                if (dansha.Controls.Count > 0)
                {
                    Control table = dansha.Controls[0];
                    if (table != null)
                    {
                        for (int i = 0; i < rowCount - dansha.Rows.Count; i++)
                        {
                            int rowIndex = dansha.Rows.Count + i + 1;
                            GridViewRow row = new GridViewRow(rowIndex, -1, DataControlRowType.Separator, DataControlRowState.Normal);
                            row.CssClass = "GridView_Row";
                            for (int j = 0; j < dansha.Columns.Count; j++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = "&nbsp;";
                                row.Controls.Add(cell);
                            }
                            table.Controls.AddAt(rowIndex, row);
                        }
                    }
                }
            }
        }

        protected void biaozhun_DataBound(object sender, EventArgs e)
        {
            if (biaozhun.Rows.Count < rowCount)
            {
                if (biaozhun.Controls.Count > 0)
                {
                    Control table = biaozhun.Controls[0];
                    if (table != null)
                    {
                        for (int i = 0; i < rowCount - biaozhun.Rows.Count; i++)
                        {
                            int rowIndex = biaozhun.Rows.Count + i + 1;
                            GridViewRow row = new GridViewRow(rowIndex, -1, DataControlRowType.Separator, DataControlRowState.Normal);
                            row.CssClass = "GridView_Row";
                            for (int j = 0; j < biaozhun.Columns.Count; j++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = "&nbsp;";
                                row.Controls.Add(cell);
                            }
                            table.Controls.AddAt(rowIndex, row);
                        }
                    }
                }
            }
        }

        protected void mianfei_DataBound(object sender, EventArgs e)
        {
            if (mianfei.Rows.Count < rowCount)
            {
                if (mianfei.Controls.Count > 0)
                {
                    Control table = mianfei.Controls[0];
                    if (table != null)
                    {
                        for (int i = 0; i < rowCount - mianfei.Rows.Count; i++)
                        {
                            int rowIndex = mianfei.Rows.Count + i + 1;
                            GridViewRow row = new GridViewRow(rowIndex, -1, DataControlRowType.Separator, DataControlRowState.Normal);
                            row.CssClass = "GridView_Row";
                            for (int j = 0; j < mianfei.Columns.Count; j++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = "&nbsp;";
                                row.Controls.Add(cell);
                            }
                            table.Controls.AddAt(rowIndex, row);
                        }
                    }
                }
            }
        }

        protected void aoyou_DataBound(object sender, EventArgs e)
        {
            if (aoyou.Rows.Count < rowCount)
            {
                if (aoyou.Controls.Count > 0)
                {
                    Control table = aoyou.Controls[0];
                    if (table != null)
                    {
                        for (int i = 0; i < rowCount - aoyou.Rows.Count; i++)
                        {
                            int rowIndex = aoyou.Rows.Count + i + 1;
                            GridViewRow row = new GridViewRow(rowIndex, -1, DataControlRowType.Separator, DataControlRowState.Normal);
                            row.CssClass = "GridView_Row";
                            for (int j = 0; j < aoyou.Columns.Count; j++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = "&nbsp;";
                                row.Controls.Add(cell);
                            }
                            table.Controls.AddAt(rowIndex, row);
                        }
                    }
                }
            }
        }

        private void BindLinkPic()
        {
            Pbzx.BLL.PBnet_Links PicBll = new Pbzx.BLL.PBnet_Links();
            this.RptPic.DataSource = PicBll.GetList("BitIsOK=1 and IntLinkType=0  and BitIsGood =1 order by SortOrder desc");
            this.RptPic.DataBind();
        }
        private void BindLinkText()
        {
            Pbzx.BLL.PBnet_Links PicBll = new Pbzx.BLL.PBnet_Links();
            this.RptText.DataSource = PicBll.GetList(" BitIsOK=1 and IntLinkType=1 and BitIsGood =1 order by SortOrder asc");
            this.RptText.DataBind();
        }
        private void BindNews()
        {

            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();

            DataSet ds = DbHelperSQL.Query("select top " + Convert.ToInt32(Convert.ToInt32(WebInit.pageConfig.IndexNewsCount) + 4) + " * from PBnet_News where 1=1 " + Method.Where_News + Method.IndexNews + " ");

            List<Pbzx.Model.PBnet_News> lsNews = newsBLL.DataTableToList(ds.Tables[0]);
            if (lsNews.Count > 0)
            {
                this.lblNewsTop.Text = "<a href='" + lsNews[0].SavePath + "' target='_blank' title='" + lsNews[0].NvarTitle + "' >" + StrFormat.CutStringByNum(lsNews[0].NvarTitle, 48) + "</a>";

                lsNews.RemoveAt(0);
                if (lsNews.Count > 2)
                {
                    dlNewsTop3.DataSource = lsNews.GetRange(0, 3);
                    dlNewsTop3.DataBind();
                    lsNews.RemoveRange(0, 3);
                }
                dlNewsTopList.DataSource = lsNews;
                dlNewsTopList.DataBind();

            }


        }
        /// <summary>
        /// 根据链接类型代码得到链接类型名
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        public static string GetShortTitle(object objlong, object objshort, object intnum)
        {
            int intLong = int.Parse(intnum.ToString());
            if (objshort.ToString() != null && objshort.ToString() != "")
            {
                return StrFormat.CutStringByNum(objshort.ToString(), intLong);
            }
            else
            {
                return StrFormat.CutStringByNum(objlong.ToString(), intLong);
            }
        }
        /// <summary>
        /// 根据链接类型代码得到链接类型名
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        public static string GetShortIsTop(object objlong, object objshort, object objIsTop)
        {
            if (objshort.ToString() != null && objshort.ToString() != "")
            {
                if (Convert.ToBoolean(objIsTop) == true)
                {
                    return "<font color='red'>" + StrFormat.CutStringByNum(objshort.ToString(), 21 * 2) + "</font>";
                }
                else
                {
                    return StrFormat.CutStringByNum(objshort.ToString(), 21 * 2);

                }

            }
            else
            {
                if (Convert.ToBoolean(objIsTop) == true)
                {
                    return "<font color='red'>" + StrFormat.CutStringByNum(objlong.ToString(), 21 * 2) + "</font>";
                }
                else
                {
                    return StrFormat.CutStringByNum(objlong.ToString(), 21 * 2);
                }
            }
        }
        private void BindBulletin()
        {
            Pbzx.BLL.PBnet_Bulletin BulletinBLL = new Pbzx.BLL.PBnet_Bulletin();

            dtBulletin.DataSource = BulletinBLL.GetTitleListByCount(" 1=1 " + Method.Where_News + Method.IndexNews, int.Parse(WebInit.pageConfig.IndexBulletinCount));
            dtBulletin.DataBind();
        }
        private void BindShool()
        {
            Pbzx.BLL.PBnet_School SchoolBLL = new Pbzx.BLL.PBnet_School();
            dtShool.DataSource = SchoolBLL.GetTitleListByCount(" 1=1" + Method.Where_News + Method.IndexNews, int.Parse(WebInit.pageConfig.IndexSchool));
            dtShool.DataBind();
        }
    }
}
