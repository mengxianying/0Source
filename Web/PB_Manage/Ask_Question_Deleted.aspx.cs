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
using Pbzx.Common;
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_Question_Deleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "AskTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }
        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_ask_Question MyBll = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder sb = new StringBuilder();

            sb.Append(" 1=1");
            sb.Append(" and Deleted =1 ");
            string Searchstr = sb.ToString();
            string order = column;
            int myCount = 0;
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            DataTable lsResult = MyBll.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
        }
        public static string GetState(object nState)
        {
            string state = "";
            int intst = int.Parse(nState.ToString());
            switch (intst)
            {
                case 0:
                    state = "<font color='#FF6600'>待解决</font>";
                    break;
                case 1:
                    state = "<font color='#0066FF'>已解决</font>";
                    break;
                case 2:
                    state = "<font color='#006600'>已关闭</font>";
                    break;
                default:
                    state = "未知";
                    break;
            }
            return state;
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
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { }
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {

            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            int id = int.Parse(e.CommandArgument.ToString());
            produtBLL.Delete(id);


            // Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除问题[" + produtBLL.GetModel(id).Title + "].");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("删除成功！."));

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "Deleted", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("还原", "还原问题[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共还原了" + del + "条问题记录.", "Ask_Question_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void lbtnPb_Elite_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_ask_Question.ChangeAudit(id, "Deleted");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void btnGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.ExecuteBySql("update  PBnet_Product set Deleted=0   WHERE Deleted=1 ");
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("还原", "还原所有问题[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共还原了" + del + "条问题记录.", "Ask_Question_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);

        }

        protected void btnTJ_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchDel(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("彻底删除", "彻底删除问题[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共彻底删除了" + del + "条问题记录.", "Ask_Question_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }



        protected void btnNotIndex_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.ExecuteBySql("DELETE FROM PBnet_ask_Question WHERE Deleted=1 ");
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("彻底删除", "彻底删除问题[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共彻底删除了" + del + "条问题记录.", "Ask_Question_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Ask_Question_Edit.aspx?id=" + e.Row.Cells[1].Text + "'>";
                e.Row.Cells[1].Text = e.Row.Cells[0].Text + href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
