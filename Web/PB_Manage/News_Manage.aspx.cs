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

namespace Pbzx.Web.PB_Manage
{
    public partial class News_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request["CID"] != null)
                //{
                //    labAction.Text = new Pbzx.BLL.PBnet_NewsType().GetModel(Convert.ToInt32(Request["CID"])).VarTypeName;
                //}
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            //  bu.Append(" and IntSetting=0 ");
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "BitIsTop desc,datdateandtime desc ";
            int myCount = 0;
            
            DataTable lsResult = newsBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            //AspNetPager1.CurrentPageIndex = page;
           
        }



        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            BindData();
        }

        protected string GetTypeNameByID(object obj)
        {
            string result = "";
            Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            if (obj != null && obj.ToString() != "")
            {
                Pbzx.Model.PBnet_NewsType typeModel = newsTypeBLL.GetModel(int.Parse(obj.ToString()));
                if (typeModel != null)
                {
                    result = typeModel.VarTypeName;
                }
            }
            return result;
        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["IntChannelID"]))
            {
                bu.Append(" and IntChannelID =" + Request["IntChannelID"] + " ");
            }
            if (!string.IsNullOrEmpty(Request["IntShowType"]))
            {
                bu.Append(" and IntShowType =" + Request["IntShowType"] + " ");
            }
            if (!string.IsNullOrEmpty(Request["regedit"]))
            {
                bu.Append(" and DatDateAndTime between dateAdd(day," + this.Request["regedit"].ToString() + ",getdate()) and getdate()  ");
            }

            if (!string.IsNullOrEmpty(Request["NvarTitle"]))
            {
                bu.Append(" and NvarTitle like '%" + Request["NvarTitle"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["ShowIndex"]))
            {
                bu.Append(" and ShowIndex=" + Request["ShowIndex"]);
            }
            if (!string.IsNullOrEmpty(Request["BitIsPass"]))
            {
                bu.Append(" and BitIsPass=" + Request["BitIsPass"]);
            }
            return bu.ToString();

        }

      protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("必须保证至少有一条记录");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["NvarTitle"].ToString();
            Pbzx.BLL.PBnet_News bll = new Pbzx.BLL.PBnet_News();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除新闻[" + nvarname + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("删除新闻[" + nvarname + "]成功！"));
                //JS.Alert("删除新闻[" + nvarname + "]成功！");
            }
            BindData();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("News_Editor.aspx?ID=[*]");
        }


        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsPass",true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("推荐", "推荐新闻[" + str + "]");
                //ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("共推荐了" + del + "条记录."));


            }
            BindData();   
        }

        

 
        protected void btnSC_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchDel(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除新闻[" + str + "]");
                 JS.Alert("共删除了" + del + "条记录.");
            }
            BindData();
        }





        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='News_Editor.aspx?ID=" + e.Row.Cells[1].Text + "' >";
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected void btnNoFB_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsPass",false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设置不发布", "设置不发布新闻[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("共设置不发布" + del + "条记录."));
            }
            BindData();
        }


        protected string GetTitle(object title,object isStatic,object savePath)
        {           
            string strTitle = StrFormat.CutStringByNum(title, 18*2);
            string result = "";
            if (bool.Parse(isStatic.ToString()))
            {
                result = "<a title='" + title.ToString() + "' href='" + savePath.ToString() + "' target='_blank'>" + strTitle + "</a>";
            }
            else
            {
                result = "<span title='"+title.ToString()+"'>"+strTitle+"</span>";
            }
            return result;
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            WebFunc.RefPagesByPageName("新闻详细页模板");
            int newsID = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
            Pbzx.Model.PBnet_News myNews = newsBLL.GetModel(newsID);
            newsBLL.ArticleUpdate(myNews);            
            BindData();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("新闻详细页模板");
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            newstBLL.CreateContentFileByTemplate(str);          
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("生成", "生成新闻[" + str + "]");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("生成新闻[" + str + "]"));            
            BindData();
            RefNewsPage();
           
        }

        protected void btnAllCreate_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("新闻详细页模板");
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            newstBLL.CreateAllArticleFile();
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("生成", "全部新闻生成");
            // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("共生成了" + del + "条记录."));
            BindData();
            RefNewsPage();       
        }

        protected void lblCreateIndex_Click(object sender, EventArgs e)
        {
            RefNewsPage();
            //btnAllCreate_Click(sender, e);
            //Response.Redirect(Request.Url.PathAndQuery);
        }

        protected void lbtnIsTop_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_News.ChangeAudit(id, "ShowInSoft");
            BindData();
        }

        protected void lbtnShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_News.ChangeAudit(id, "ShowIndex");
            BindData();
        }

        protected void lbtnIsPass_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_News.ChangeAudit(id, "BitIsPass");
            BindData();
        }

        /// <summary>
        /// 刷新首页和新闻资讯首页
        /// </summary>
        private void RefNewsPage()
        {
            WebFunc.RefPagesByPageName("首页");
            WebFunc.RefPagesByPageName("新闻资讯");
            WebFunc.RefPagesByPageName("软件内嵌页面");
        }
        public static string GetIsTop(object objIsTop)
        {
            string strIsTop = "";
            if (objIsTop.ToString() != null && objIsTop.ToString() != "")
            {
                int intIsTop = int.Parse(objIsTop.ToString());
                switch (intIsTop)
                {
                    case 2:
                        strIsTop = "<font color=red>首固</font>";
                        break;
                    case 1:
                        strIsTop = "<font color= blue>次固</font>";
                        break;
                    case 0:
                        strIsTop = "<font color=#000000>不固</font>";
                        break;
                    default:
                        strIsTop = "<font color=red>未知</font>";
                        break;
                }
            }
            else {

                return null;
            }
            return strIsTop;
        }

        protected void btnShouG_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdateTop(str, "BitIsTop", 2);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设置首固", "设置首固[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("共设置首固" + del + "条记录."));
            }
            BindData();
        }

        protected void btnCiG_Click(object sender, EventArgs e)
        {
   
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdateTop(str, "BitIsTop", 1);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设置次固", "设置次固[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("共设置次固" + del + "条记录."));
            }
            BindData();
        }

        protected void btnBuG_Click(object sender, EventArgs e)
        {
     
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdateTop(str, "BitIsTop", 0);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设置不固", "设置不固[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("共设置不固" + del + "条记录."));
            }
            BindData();
        }

        protected void btnSChtml_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchDelHtml(str);

            BindData();
            if (del >= 0)
            {
                //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除公告[" + str + "]");
                //Response.Write(JS.Alert("共删除了" + del + "个公告文件."));
                //this.RegisterStartupScript("SCHtml", JS.Alert("共删除了" + del + "个公告文件."));
                ClientScript.RegisterStartupScript(GetType(), "SCHtmlXW", JS.Alert("共删除了" + del + "个新闻文件."));
            }
        }
    }
}
