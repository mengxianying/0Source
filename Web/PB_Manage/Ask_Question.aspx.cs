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

namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_Question : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
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
            sb.Append(" and Deleted =0 ");
            sb.Append(this.AddParameter());
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

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question QuestionBLL = new Pbzx.BLL.PBnet_ask_Question();
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.Model.PBnet_ask_Question QuestionModel = QuestionBLL.GetModel(id);
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除问题[" + QuestionModel.Title + "].");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("删除成功！."));
            QuestionModel.Deleted = true;
            QuestionBLL.Update(QuestionModel);
            WebFunc.DelQuestion(QuestionModel.Asker);
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
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
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["strTitle"]))
            {
                bu.Append(" and Title like '%" + Request["strTitle"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strAsker"]))
            {
                bu.Append(" and Asker like '%" + Request["strAsker"].Trim() + "%' ");
            }
            //if (!string.IsNullOrEmpty(Request["strAnswerer"]))
            //{
            //    bu.Append(" and Answerer like '%" + Request["strAnswerer"].Trim() + "%' ");
            //}
            if (!string.IsNullOrEmpty(Request["TypeName"]))
            {
                //  string strType = Request["TypeName"].Trim().Replace("-|", "");                
                bu.Append(" and TypeID in( SELECT id FROM dbo.PBnet_ask_Type WHERE (Id = " + Request["TypeName"].Trim() + ") OR (FTypeID = " + Request["TypeName"].Trim() + "))  ");

            }
            if (!string.IsNullOrEmpty(Request["State"]))
            {
                bu.Append(" and State like '%" + Request["State"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["Auditing"]))
            {
                if (Request["Auditing"] != "2")
                {
                    bu.Append(" and  Auditing='" + Request["Auditing"]+"'");
                }
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and AskTime between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and OverTime between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                }
            }

            return bu.ToString();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Ask_Question_Edit.aspx?Id=" + e.Row.Cells[1].Text + "' target='_blank'>";
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
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
        public static string GetState(object nState)
        {
            string state = "";
            int intst = int.Parse(nState.ToString());
            switch (intst)
            {
                case 0:
                    state = "<font color='#FF6600'>待解</font>";
                    break;
                case 1:
                    state = "<font color='#0066FF'>已解</font>";
                    break;
                case 2:
                    state = "<font color='#006600'>已关</font>";
                    break;
                default:
                    state = "未知";
                    break;
            }
            return state;
        }
        //protected void lbtnIsHot_Command(object sender, CommandEventArgs e)
        //{
        //    int id = int.Parse(e.CommandArgument.ToString());
        //    Pbzx.BLL.PBnet_ask_Question.ChangeAudit(id, "BitIsHot");
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}
        protected void lbtnIsCommend_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_ask_Question AskBll = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question AskModel = AskBll.GetModel(id);
            if (AskModel.IsCommend == false)
            {
                WebFunc.JingHuaUpdate(AskModel.Id);
            }
            Pbzx.BLL.PBnet_ask_Question.ChangeAudit(id, "IsCommend");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("推荐", "推荐[" + AskModel.Title + "]");

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question QuestionBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = QuestionBLL.BatchUpdate(str, "Deleted", true);
            WebFunc.BatchDelQuestion(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除回复[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "Ask_Reply.aspx"));
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
            WebFunc.UpJInFen(str);
            int del = produtBLL.BatchUpdate(str, "IsCommend", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("推荐", "推荐[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设置推荐了" + del + "条记录.", "Ask_Question.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }



        protected void btnNottuij_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "IsCommend", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("取消推荐", "取消推荐[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共取消推荐了" + del + "条记录.", "Ask_Question.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void lbtsh_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_ask_Question AskBll = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question AskModel = AskBll.GetModel(id);
            if (AskModel.Auditing == true)
            {
                AskModel.Auditing = false;
            }
            else
            {
                AskModel.Auditing = true;
            }

            AskBll.Update(AskModel);

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btntuij0_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str.ToString(), "Auditing", true);
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btntuij1_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str.ToString(), "Auditing", false);
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// 生成拼搏吧的 静态问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbtn_geng_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            bll.CreatHtmlByChannelID(51, false);
            Response.Write("<script>location='Ask_Question.aspx';</script>");
        }


        //protected void btnjing_Click(object sender, EventArgs e)
        //{
        //    Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
        //    string str = Request.Form["sel"];
        //    if (str == null)
        //    {
        //        return;
        //    }
        //    int del = produtBLL.BatchUpdate(str, "BitIsHot", true);
        //    if (del > 0)
        //    {
        //        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("精华", "精华[" + str + "]");
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设置精华了" + del + "条记录.", "Ask_Question.aspx"));
        //    }
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}



        //protected void btnNotjing_Click(object sender, EventArgs e)
        //{
        //    Pbzx.BLL.PBnet_ask_Question produtBLL = new Pbzx.BLL.PBnet_ask_Question();
        //    string str = Request.Form["sel"];
        //    if (str == null)
        //    {
        //        return;
        //    }
        //    int del = produtBLL.BatchUpdate(str, "BitIsHot", false);
        //    if (del > 0)
        //    {
        //        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("取消精华", "取消精华[" + str + "]");
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共取消精华了" + del + "条记录.", "Ask_Question.aspx"));
        //    }
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        // }

    }
}
