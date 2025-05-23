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
    public partial class UsersMsSend : AdminBasic
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
                if (Request["isSend"] == "1")
                {
                    ViewState["isSend"] = "1";
                    lblTitle.Text = "已发送消息";
                    btnSC.Text = "删除已发送消息";
                    this.btnQK.Text = "清空已发送消息";
                    btnSC.Width = 120;
                    btnQK.Width = 120;
                }
                else
                {
                    ViewState["isSend"] = "0";
                    lblTitle.Text = "草稿箱";
                    btnSC.Text = "删除草稿箱";
                    this.btnQK.Text = "清空草稿箱";
                    btnSC.Width = 100;
                    btnQK.Width = 100;
                }
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
            if (ViewState["isSend"].ToString() == "1")
            {
                bu.Append(" and sender = '拼搏在线' and issend = 1 and delS = 0 ");
            }
            else
            {
                bu.Append(" and sender = '拼搏在线' and issend = 0 and delS = 0 ");
            }
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
            string sql = "update Dv_Message set delS=1  WHERE id IN(" + str + ")";
            int del = DbHelperSQLBBS.ExecuteSql(sql);
            if (del > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "删除成功！共删除了" + del + "条消息。删除的消息将置于您的废信箱内", 400, "1", "", "", false, false) + "");   //location.reload();             
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btnQK_Click(object sender, EventArgs e)
        {
            string sql = "update Dv_Message set delS=1  WHERE  issend =" + ViewState["isSend"].ToString() + " and  delS=0 and sender= '拼搏在线' ";
            int del = DbHelperSQLBBS.ExecuteSql(sql);
            if (del > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "清空成功！共删除了" + del + "条消息。删除的消息将置于您的废信箱内", 400, "1", "", "", false, false) + "");   //location.reload();             
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        protected string FormartTitleA(object id, object title)
        {
            string action = "";
            if (ViewState["isSend"].ToString() == "0")
            {
                action = "edit";
            }
            else if (ViewState["isSend"].ToString() == "1")
            {
                action = "outread";
            }
            return "<a title=\"阅读短消息\" href=\"#\" onclick=\"window.open('MsgDetail.aspx?id=" + id + "&action=" + action + "','','height=500, width=600, top='+(screen.height-500)/2+',left='+(screen.width-800)/2+', toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');\"> " + Pbzx.Common.StrFormat.CutStringByNum(title, 50 * 2) + "</a>";
        }
    }
}
