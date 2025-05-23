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
    public partial class AdvancedUserManage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "CreatTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
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
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
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

            if (!string.IsNullOrEmpty(Request["Money"]))
            {
                if (Request["Money"] == "0")
                {
                    bu.Append(" and CurrentMoney>0 ");
                }
                else if (Request["Money"] == "1")
                {
                    bu.Append(" and FrozenMoney>0 ");
                }             
            }

            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                bu.Append(" and UserName like '%" + Input.FilterAll(Request["UserName"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["RealName"]))
            {
                bu.Append(" and RealName like '%" + Input.FilterAll(Request["RealName"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["UserEmail"]))
            {
                bu.Append(" and Email like '%" + Input.FilterAll(Request["UserEmail"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["AccountNumber"]))
            {
                bu.Append(" and AccountNumber='" + Input.FilterAll(Request["AccountNumber"]) + "' ");
            }

            if (!string.IsNullOrEmpty(Request["BankName"]))
            {
                bu.Append(" and BankName like '%" + Input.FilterAll(Request["BankName"]) + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["State"]))
            {
                bu.Append(" and State='" + Input.FilterAll(Request["State"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and CreatTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and LastTrade_time between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu.ToString();
        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["order"].ToString() != e.SortExpression.ToString())
            {
                ViewState["isDesc"] = true;
            }
            else
            {
                if ((bool)ViewState["isDesc"])
                {
                    ViewState["isDesc"] = false;
                }
                else
                {
                    ViewState["isDesc"] = true;
                }
            }
            ViewState["order"] = e.SortExpression.ToString();
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_UserTable userTableBll = new Pbzx.BLL.PBnet_UserTable();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
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
            DataTable lsResult = userTableBll.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
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

                object objTotalPrice = DbHelperSQL.GetSingle(" select sum(CurrentMoney) from PBnet_UserTable where " + Searchstr);
                if (objTotalPrice == null)
                {
                    objTotalPrice = 0;
                }
                this.lblCurrentMoney.Text = Math.Round(Convert.ToDecimal(objTotalPrice), 2) + "元";

                object objPostPrice = DbHelperSQL.GetSingle(" select sum(FrozenMoney) from PBnet_UserTable where " + Searchstr);
                if (objPostPrice == null)
                {
                    objPostPrice = 0;
                }
                this.lblFrozenMoney.Text = Math.Round(Convert.ToDecimal(objPostPrice), 2) + "元";
            }
        }

        //protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        //{
        //    int id = int.Parse(e.CommandArgument.ToString());
        //    Pbzx.BLL.CstMessage cstMSGBLL = new Pbzx.BLL.CstMessage();

        //    cstMSGBLL.ChangeAudit(id, "MsgSend");
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}
        //protected void btn_add_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("SoftMessage_Editor.aspx");
        //}

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='WebUser_Editor.aspx?ID=" + GetUserIDByUserName(e.Row.Cells[1].Text) + "'  target='_blank' >";
                e.Row.Cells[0].Text = href +"(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
        /// <summary>
        /// 根据用户名得到用户ID
        /// </summary>
        /// <param name="uName"></param>
        /// <returns></returns>
        protected string GetUserIDByUserName(object uName)
        {
            if (uName == null)
            {
                return "";
            }
            else
            {
                object objResult = DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + uName.ToString() + "'  ");
                if (objResult == null)
                {
                    return "";
                }
                else
                {
                    return objResult.ToString();
                }
            }
        }
    }
}
