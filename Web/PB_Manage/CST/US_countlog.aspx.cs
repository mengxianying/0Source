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
    public partial class US_countlog : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "StartTime";
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

            if (!string.IsNullOrEmpty(Request["strRun"]))
            {
                bu1.Append(" and  datediff(s,StartTime,EndTime)= '" + Request["strRun"].Trim() + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strDays"]))
            {
                bu1.Append(" and Days='" + Request["strDays"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strResult"]))
            {
                bu1.Append(" and Result='" + Request["strResult"] + "'");
            }

            if (!string.IsNullOrEmpty(Request["strErrorInfo"]))
            {
                bu1.Append(" and ErrorInfo='" + Request["strErrorInfo"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strFlag"]))
            {
                bu1.Append(" and Flag='" + Request["strFlag"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strStatTableName"]))
            {
                bu1.Append(" and StatTableName='" + Request["strStatTableName"] + "' ");
            }

            //if (!string.IsNullOrEmpty(Request["dateType"]))
            //{
            //    if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
            //    {
            //        if (Request["dateType"] == "1")
            //        {
            //            bu1.Append(" and StartTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
            //        }
            //        //else if (Request["dateType"] == "2")
            //        //{
            //        //    bu1.Append(" and EndTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
            //        //}
            //        //else if (Request["dateType"] == "3")
            //        //{
            //        //    bu1.Append(" and EndDate between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
            //        //}
            //    }
           // }

            return bu1.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CN_StatLog logBLL = new Pbzx.BLL.CN_StatLog();
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

            DataTable lsResult = logBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
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

     //返回时间差结果
        public static string GetRun(object obj1, object obj2)
        {
            DateTime dt1 = DateTime.Parse(obj1.ToString());
            DateTime dt2 = DateTime.Parse(obj2.ToString());
            TimeSpan ts = dt1 - dt2;
            return ts.Seconds.ToString();
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }


    }
}
