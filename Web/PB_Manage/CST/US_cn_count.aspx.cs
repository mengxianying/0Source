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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class US_cn_count : System.Web.UI.Page
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


            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                bu1.Append(" and UserName like '%" + Input.FilterAll(Request["UserName"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["BoardID"]))
            {
                bu1.Append(" and BoardID='" + Input.FilterAll(Request["BoardID"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["NormalTopicCount"]))
            {
                bu1.Append(" and NormalTopicCount='" + Input.FilterAll(Request["NormalTopicCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["BestTopicCount"]))
            {
                bu1.Append(" and BestTopicCount='" + Input.FilterAll(Request["BestTopicCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["NormalAnnounceCount"]))
            {
                bu1.Append(" and NormalAnnounceCount='" + Input.FilterAll(Request["NormalAnnounceCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["BestAnnounceCount"]))
            {
                bu1.Append(" and BestAnnounceCount='" + Input.FilterAll(Request["BestAnnounceCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["DelTopicCount"]))
            {
                bu1.Append(" and DelTopicCount='" + Input.FilterAll(Request["DelTopicCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["DelAnnounceCount"]))
            {
                bu1.Append(" and DelAnnounceCount='" + Input.FilterAll(Request["DelAnnounceCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["TotalTopicCount"]))
            {
                bu1.Append(" and TotalTopicCount='" + Input.FilterAll(Request["TotalTopicCount"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["TotalAnnounceCount"]))
            {
                bu1.Append(" and TotalAnnounceCount='" + Input.FilterAll(Request["TotalAnnounceCount"]) + "' ");
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
            string sql = "Select ConfigValue From CN_Config Where ConfigName = 'CurBbsStatTable'";
            string tableName = DbHelperSQL1.GetSingle(sql).ToString();

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

            DataTable lsResult = Pbzx.SQLServerDAL.Basic.CstGetRecordFromPagesDs(tableName, "ID,Username,BoardID,NormalTopicCount,BestTopicCount,NormalAnnounceCount,BestAnnounceCount,DelTopicCount,DelAnnounceCount,TotalTopicCount,TotalAnnounceCount", order, "ID", Pbzx.Common.WebInit.webBaseConfig.WebPageNum, AspNetPager1.CurrentPageIndex, true, 3, Searchstr, out myCount);
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

        public string BoardNameByID(object BoardID)
        {
            if (BoardID != null)
            {
                object objBoard = DbHelperSQLBBS.GetSingle("select top 1 BoardType  from  [Dv_Board]  where BoardID=" + BoardID + " ");
                if (objBoard != null)
                {
                    return objBoard.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}
