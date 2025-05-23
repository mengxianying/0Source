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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class US_softpost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "ID";
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

            //if (!string.IsNullOrEmpty(Request["strRun"]))
            //{
            //    bu1.Append(" and BlackValue='" + Request["strRun"] + "' ");
            //}
            //if (!string.IsNullOrEmpty(Request["strDays"]))
            //{
            //    bu1.Append(" and Days='" + Request["strDays"] + "' ");
            //}
            //if (!string.IsNullOrEmpty(Request["strResult"]))
            //{
            //    bu1.Append(" and Result='" + Request["strResult"] + "'");
            //}

            //if (!string.IsNullOrEmpty(Request["strErrorInfo"]))
            //{
            //    bu1.Append(" and ErrorInfo='" + Request["strErrorInfo"] + "' ");
            //}
            //if (!string.IsNullOrEmpty(Request["strFlag"]))
            //{
            //    bu1.Append(" and Flag='" + Request["strFlag"] + "' ");
            //}
            //if (!string.IsNullOrEmpty(Request["dateType"]))
            //{
            //    if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
            //    {
            //        if (Request["dateType"] == "1")
            //        {
            //            bu1.Append(" and CreateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
            //        }
            //        else if (Request["dateType"] == "")
            //        {
            //            bu1.Append(" and FirstLoginTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
            //        }
            //    }
            //}
            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                bu1.Append(" and SoftwareType='" + Request["softwareType"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["installType"]))
            {
                bu1.Append(" and InstallType='" + Request["installType"] + "'");
            }

            return bu1.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CN_Software softBLL = new Pbzx.BLL.CN_Software();
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


            DataTable lsResult = softBLL.GuestGetBySearch(Searchstr, "*", "", Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 1, AspNetPager1.CurrentPageIndex, out myCount);

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


        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();

            string[] result = softBLL.Chksettype(num, st);
            return "<a href='US_softpost.aspx?SoftwareType=" + num.ToString() + "&InstallType=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";
        }

        public static string GetStatus(object status)
        {
            string type = "";
            int intType = int.Parse(status.ToString());
            switch (intType)
            {
                case 0:
                    type = "<font color=blue>投入使用</font>";
                    break;
                case 1:
                    type = "<font color=#0000FF>等待使用</font>";
                    break;
                case 2:
                    type = "<font color=#0000FF>禁用</font>";
                    break;
               
                default:
                    type = "未知";
                    break;
            }
            return type;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("US_softpost_Editor.aspx");
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='US_softpost_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
