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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class UsersMsDel : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ////////////////////////////////////////////////////////////////////////
                string strMonth = ConfigurationManager.AppSettings["MessageCancelMonth"];
                int month = 0;
                int.TryParse(strMonth, out month);
                if (month == 0)
                {
                    lblDel.Text = "。";
                }
                else
                {
                    lblDel.Text = "，系统将会自动删除" + month + "个月之前的消息。";
                }
                /////////////////////////////////////////////////////////////////////////

                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "sendtime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                //if (Request["delMsg"] == "1")
                //{
                //    ViewState["delMsg"] = "1";
                lblTitle.Text = "废信箱";
                //}
                //else
                //{
                //    ViewState["delMsg"] = "0";
                //    lblTitle.Text = "收信箱";
                //}
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
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
            AspNetPager1.CustomInfoHTML += "本页共<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            //if (ViewState["delMsg"].ToString() == "1")
            //{
            bu.Append(" and ((sender = '拼搏在线' and delS = 1) or (incept = '拼搏在线' and delR = 1)) and not delS = 2 ");
            //}
            //else
            //{
            //    bu.Append(" and  issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "'");
            //}
            return bu.ToString();
        }

        private void BindData(string column, bool isDesc)
        {
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "flag asc,id desc";
            int myCount = 0;

            //if (isDesc)
            //{
            //    order += " desc ";
            //}
            //else
            //{
            //    order += " asc ";
            //}
            DataTable lsResult = Pbzx.SQLServerDAL.Basic.BbsGetRecordFromPagesDs("Dv_Message", "*", order, "id", WebInit.webBaseConfig.WebPageNum, AspNetPager1.CurrentPageIndex, true, 3, Searchstr, out myCount);
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                //this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                //this.litContent.Text = "";
            }
        }

        //protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    ViewState["order"] = e.SortExpression.ToString();
        //    if ((bool)ViewState["isDesc"])
        //    {
        //        ViewState["isDesc"] = false;
        //    }
        //    else
        //    {
        //        ViewState["isDesc"] = true;
        //    }
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}

        protected void btnSC_Click(object sender, EventArgs e)
        {
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            //用户能完全删除收到信息和逻辑删除所发送信息，逻辑删除所发送信息设置入口字段DelS参数为2
            //收信人回收站： incept=收信人 DelR=1
            //发件人回收站： sender=收信人 DelS=2

            string sql = "DelETE FROM Dv_Message WHERE incept='拼搏在线' And DelR=1 and id IN(" + str + ")";
            string sql1 = "UPDATE Dv_Message Set DelS=2 WHERE sender='拼搏在线' And DelS=1 and id IN(" + str + ")";
            int del = DbHelperSQLBBS.ExecuteSql(sql);
            int del1 = DbHelperSQLBBS.ExecuteSql(sql1);
            if (del > 0 && del1 > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "删除成功！共删除了" + (del + del1) + "条消息。删除的消息将不可恢复", 400, "1", "", "", false, false) + "");   //location.reload();             
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btnQK_Click(object sender, EventArgs e)
        {
            //用户能完全删除收到信息和逻辑删除所发送信息，逻辑删除所发送信息设置入口字段DelS参数为2
            //收信人回收站： incept=收信人 DelR=1
            //发件人回收站： sender=收信人 DelS=2
            string sql = "DelETE FROM Dv_Message WHERE incept='拼搏在线' And DelR=1 ";
            string sql1 = "UPDATE Dv_Message Set DelS=2 WHERE sender='拼搏在线' And DelS=1 ";
            int del = DbHelperSQLBBS.ExecuteSql(sql);
            int del1 = DbHelperSQLBBS.ExecuteSql(sql1);
            if (del > 0 && del1 > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "删除成功！共删除了" + (del + del1) + "条消息。删除的消息将不可恢复", 400, "1", "", "", false, false) + "");   //location.reload();             
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);

        }


        protected string FormartTitleA(object id, object title, object sender, object incept)
        {
            string action = "";
            if ("拼搏在线" == incept.ToString().ToLower())
            {
                action = "read";
            }
            else if ("拼搏在线" == sender.ToString().ToLower())
            {
                action = "myRead";
            }
            return "<a title=\"阅读短消息\" href=\"#\" onclick=\"window.open('MsgDetail.aspx?id=" + id + "&action=" + action + "','','height=500, width=600, top='+(screen.height-500)/2+',left='+(screen.width-800)/2+', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');\"> " + Pbzx.Common.StrFormat.CutStringByNum(title, 50 * 2) + "</a>";
        }
    }
}
