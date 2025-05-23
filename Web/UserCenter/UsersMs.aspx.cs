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

namespace Pbzx.Web.UserCenter
{
    public partial class UsersMs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //消息逻辑方法
                MsgInit();


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
                //    lblTitle.Text = "废信箱";
                //}
                //else
                //{
                //    ViewState["delMsg"] = "0";
                lblTitle.Text = "收信箱";
                //}
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }
        /// <summary>
        /// 消息方法Shovy
        /// 2011-11-17
        /// </summary>
        private static void MsgInit()
        {
            ///////////////////////////////////////////////////////////////////////判断未读消息
            object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' ");
            if (objMsgCount.ToString() == "0")
            {
                DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMsg='0||0||null' where UserName='" + Method.Get_UserName + "'");
            }
            else
            {
                //否则先读出消息，改对应条数
                Object obj = DbHelperSQLBBS.GetSingle("select UserMsg from Dv_User where UserName = '" + Method.Get_UserName + "' ");
                if (obj != null)
                {
                    //否则找到ID
                    Object obj1 = DbHelperSQLBBS.GetSingle("select top 1 id from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' order by id desc  ");
                    Object obj2 = DbHelperSQLBBS.GetSingle("select top 1 sender  from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' order by id desc");
                    string Msgtitle = objMsgCount + "||" + obj1 + "||" + obj2;
                    DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMsg='" + Msgtitle + "' where UserName='" + Method.Get_UserName + "'");

                }
            }
            //////////////////////////////////////////////////////////////////////////////////
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 19;
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
            //    bu.Append(" and ((sender = '" + Method.Get_UserName + "' and delS = 1) or (incept = '" + Method.Get_UserName + "' and delR = 1)) and not delS = 2 ");
            //}
            //else
            //{
            bu.Append(" and  issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "'");
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
            DataTable lsResult = Pbzx.SQLServerDAL.Basic.BbsGetRecordFromPagesDs("Dv_Message", "*", order, "id", 19, AspNetPager1.CurrentPageIndex, true, 3, Searchstr, out myCount);
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
            string sql = "update Dv_Message set delR=1  WHERE id IN(" + str + ")";
            int del = DbHelperSQLBBS.ExecuteSql(sql);
            if (del > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "删除成功！共删除了" + del + "条消息。删除的消息将置于您的废信箱内", 400, "1", "", "", false, false) + "");   //location.reload();             
            }
            //消息逻辑方法
            MsgInit();

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btnQK_Click(object sender, EventArgs e)
        {
            string sql = "update Dv_Message set delR=1  WHERE  issend = 1 and delR =0 and incept = '" + Method.Get_UserName + "' ";
            int del = DbHelperSQLBBS.ExecuteSql(sql);
            if (del > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "清空成功！共删除了" + del + "条消息。删除的消息将置于您的废信箱内", 400, "1", "", "", false, false) + "");   //location.reload();             
            }

            //消息逻辑方法
            MsgInit();
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

    }
}
