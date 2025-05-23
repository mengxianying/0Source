using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Collections.Generic;

namespace Pbzx.Web
{
    public partial class Soft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PageConfig pageConfig = WebInit.pageConfig;

                SoftTitle1.Count = Convert.ToInt32(pageConfig.Softxzlie);
                SoftTitle1.TilteLength = Convert.ToInt32(pageConfig.Softxzlength);
                labzong.InnerText = pageConfig.Softxzlie;


                SoftTitle2.Count = Convert.ToInt32(pageConfig.Softlie);
                SoftTitle2.TilteLength = Convert.ToInt32(pageConfig.Softlength);


                SoftTitle3.Count = Convert.ToInt32(pageConfig.SoftMlie);
                SoftTitle3.TilteLength = Convert.ToInt32(pageConfig.SoftMlength);
                labyue.InnerText = pageConfig.SoftMlie;
                BindTop();
                BindData();
                if (Request.QueryString["vef"] != null)
                {
                    this.N1.Visible = false;
                    this.N2.Visible = true;
                }
                else
                {
                    this.N2.Visible = false;
                    this.N1.Visible = true;
                }
            }
        }


        private void BindData()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                bu.Append(" and pb_ClassID ='" + Input.FilterAll(Input.Decrypt(Request["id"])) + "' ");
                Pbzx.BLL.PBnet_SoftClass softClassBll = new Pbzx.BLL.PBnet_SoftClass();
                Pbzx.Model.PBnet_SoftClass softClassModel = softClassBll.GetModel(Convert.ToInt32(Input.FilterAll(Input.Decrypt(Request["id"]))));
                this.Title = softClassModel.NvarClassName + "_软件商城_拼搏在线彩神通软件";
            }
            if (!string.IsNullOrEmpty(Request["TypeID"]))
            {
                bu.Append(" and pb_TypeName ='" + Input.FilterAll(Input.Decrypt(Request["TypeID"])) + "' ");

                this.Title = Input.FilterAll(Input.Decrypt(Request["TypeID"])) + "软件_软件商城_拼搏在线彩神通软件";

            }
            bu.Append(this.AddParameter());
            bu.Append(" and " + Method.product);
            string Searchstr = bu.ToString();
            //  string order = "pb_UpdateTime desc ";
            string order = "countid asc ";
            int mycount = 0;

            DataTable IsResult = MyBLL.GuestGetBySearch(Searchstr, "*", order, 10, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.Repeater1.DataSource = IsResult;
            this.Repeater1.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            //AspNetPager1.CustomInfoHTML += "本页共计<font color=\"red\"><b>" + Repeater1.Items.Count + "</b></font>条记录&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["strType"]))
            {
                if (!string.IsNullOrEmpty(Request["strKey"]))
                {
                    if (Request["strType"] == "0")
                    {
                        bu1.Append(" and pb_SoftName like '%" + Input.FilterAll(Request["strKey"]) + "%'");
                    }
                    else if (Request["strType"] == "1")
                    {
                        bu1.Append(" and pb_SoftIntro like '%" + Input.FilterAll(Request["strKey"]) + "%'");
                    }
                }
            }

            return bu1.ToString();
        }


        public static string GetBuyPic(object strStr, object intnum, object pb_TypeName, object pb_freeshow)
        {
            string Pic = "";
            int intId = int.Parse(intnum.ToString());

            if ((bool)pb_freeshow)
            {
                return Pic;
            }

            if (pb_TypeName.ToString() == "免费版" || pb_TypeName.ToString() == "珍藏版")
            {
                Pic = "";
            }
            else
            {
                if (pb_TypeName.ToString() == "出票系统")
                {
                    Pic = "<img alt='购买' src='/Images/Web/mybuy.gif'  align='middle' style='cursor:pointer' onclick=\"$('#dialog1').attr('title','提示'); $('#dialog1').html('<p style=padding:20px >出票系统暂不支持网上购买，如有需要请与拼搏在线客服联系！</p>'); $('#dialog1').dialog({autoOpen: false,modal: true,width: 450, buttons: {'确定':function() {$(this).dialog('close');$('#dialog1').dialog('destroy'); } } });$('#dialog1').dialog('open');\"  border='0' >";
                }
                else
                {
                    Pic = "<a href='addtoshoppingcart.aspx?productID=" + intId + "'><img alt='购买' src='/Images/Web/mybuy.gif'  align='middle'  border='0'></a>";
                }


            }
            return Pic.ToString();
        }

        public static string GetPrice(object strNian, object strTao, object pb_freeshow)
        {
            string Price = "";
            if ((bool)pb_freeshow)
            {
                return "";
            }
            if ((strNian != null && strNian.ToString() != "") || (strTao != null && strTao.ToString() != ""))
            {
                Price = "";
                if (strNian.ToString() == "免费" || strNian.ToString() == "" || strNian.ToString().StartsWith("0元") || strNian.ToString() == "0")
                {
                }
                else
                {
                    Price += "<span class='S_zi3'>" + strNian.ToString() + "</span>&nbsp;";
                }

                if (strTao.ToString() != "")
                {
                    if (strTao.ToString() == "免费")
                    {
                        Price = "<span class='S_zi3'>免费</span>";
                    }
                    else
                    {
                        if (strTao.ToString() == "免费" || strTao.ToString() == "" || strTao.ToString().StartsWith("0元") || strTao.ToString() == "0")
                        {
                        }
                        else
                        {
                            Price += "<span class='S_zi3'>" + strTao.ToString() + "</span>";
                        }
                    }
                }
            }

            return Price.ToString();
        }
        public static string GetType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 1:
                    type = "免费版";
                    break;
                case 2:
                    type = "共享版";
                    break;
                case 3:
                    type = "试用版";
                    break;
                case 4:
                    type = "演示版";
                    break;
                case 5:
                    type = "注册版";
                    break;
                case 6:
                    type = "破解版";
                    break;
                case 7:
                    type = "零售版";
                    break;
                case 8:
                    type = "OEM版";
                    break;

                default:
                    type = "错误类型";
                    break;
            }
            return type;
        }

        public static string GetDownLoad(object strUrl1, object strUrl2, object intnum)
        {
            string DownLoad = "";
            string[] down1SZ = WebFunc.GetDownInfo("1", "1");
            string[] down2SZ = WebFunc.GetDownInfo("1", "2");
            string[] down3SZ = WebFunc.GetDownInfo("1", "3");
            string[] down4SZ = WebFunc.GetDownInfo("1", "4");
            if (down1SZ[2] == "0" && down2SZ[2] == "0" && down3SZ[2] == "0" && down4SZ[2] == "0")
            {
                return "";
            }
            else
            {
                int intID = int.Parse(intnum.ToString());
                if (strUrl1.ToString() != "" || strUrl2.ToString() != "")
                {
                    DownLoad += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                    DownLoad += "<tr>";
                    DownLoad += "<td width='27%' align='right'>下载地址：</td>";

                    List<string> lsResult = WebFunc.GetTop2DownLoadName();

                    if (strUrl1.ToString() != "")
                    {
                        if (lsResult.Count > 0)
                        {
                            DownLoad += "<td width='10%'><img src='/images/Web/download1.gif' width='12' height='12' alt='' />&nbsp;</td>";

//                            DownLoad += "<td width='22%' align='left'><a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + intID + "&reUrl=1&time=" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "'>" + lsResult[0] + "</a></td>";
                            DownLoad += "<td width='22%' align='left'><a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + intID + "&reUrl=1" + "'>" + lsResult[0] + "</a></td>";
                            DownLoad += "<td width='4%'></td>";
                        }
                    }
                    if (strUrl2.ToString() != "")
                    {
                        string name = "";
                        if (lsResult.Count > 1)
                        {
                            name = lsResult[1];
                        }
                        else
                        {
                            name = lsResult[0];
                        }
                        DownLoad += "<td width='10%'><img src='/images/Web/download1.gif' width='12' height='12' alt='' />&nbsp;</td>";
                        DownLoad += " <td width='35%' align='left'><a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "ProductDownload.aspx?id=" + intID + "&reUrl=2" + "'>" + name + "</a></td>";
                    }
                    DownLoad += "</tr></table>";
                }
            }




            return DownLoad.ToString();
        }
        private void BindTop()
        {
            DataSet dsProduct = DbHelperSQL.Query("select top 4 * from PBnet_Product where  " + Method.product + " and pb_OnTop=1 order by pb_UpdateTime desc ");
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                this.tuijian.Visible = true;
            }
            this.dlProductTop.DataSource = dsProduct;
            this.dlProductTop.DataBind();
            //dlProductTop
        }
        public static string GetMoney(object strTypeName)
        {
            string softMoney = "";
            if (strTypeName.ToString() != "")
            {
                Pbzx.BLL.PBnet_ProductPrice PriceBll = new Pbzx.BLL.PBnet_ProductPrice();
                string[] prices = PriceBll.GetModelTime(strTypeName.ToString());
                if (prices != null)
                {
                    softMoney = prices[0] + "&nbsp;" + prices[1] + "&nbsp;" + prices[2] + "&nbsp;" + prices[3].Substring(0, prices[3].Length - 3) + "&nbsp;";
                }
                else
                {
                    softMoney = "";
                }


            }
            return softMoney;
        }
    }
}