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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class US_black : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "CreateTime";
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
            AspNetPager1.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["strBlackValue"]))
            {
                bu1.Append(" and BlackValue='" + Request["strBlackValue"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["BlackFlag"]))
            {
                bu1.Append(" and BlackFlag='" + Request["BlackFlag"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["Status"]))
            {
                bu1.Append(" and Status='" + Request["Status"] + "'");
            }

            if (!string.IsNullOrEmpty(Request["strDetails"]))
            {
                bu1.Append(" and Details like '%" + Request["strDetails"] + "%'");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {

                    bu1.Append(" and CreateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
                   
                }
            }
            
            return bu1.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CN_Black backBLL = new Pbzx.BLL.CN_Black();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
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

            DataTable lsResult = backBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
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
        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

    //改变 
        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.CN_Black cN_BlackBLL = new Pbzx.BLL.CN_Black();
            cN_BlackBLL.ChangeAudit(id, "Status");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        protected string GetFlag(object objnum)
        {
            string Flag = "";
            int intnum = int.Parse(objnum.ToString());
            switch (intnum)
            {
                case 1:
                    Flag = "原始认证码";
                    break;
                case 2:
                    Flag = "认证码";
                    break;
                case 3:
                    Flag = "用户名";
                    break;
                case 4:
                    Flag = "IP地址";
                    break;
                default:
                    Flag = "未知";
                    break;
            }
            return Flag;
        }
        protected string GetStatus(object objnum)
        {
            string Status = "";
            int intnum = int.Parse(objnum.ToString());
            switch (intnum)
            {
                case 1:
                    Status = "<font color='#006600'>启用</font>";
                    break;
                case 0:
                    Status = "<font color='#666666'>解除</font>";
                    break;
                default:
                    Status = "";
                    break;
            }
            return Status;
        }

        protected void btnhei_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bacl_Editor.aspx");
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Bacl_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
