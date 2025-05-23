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
    public partial class Bbs_Userpost : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "DateAndTime";
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

            if (!string.IsNullOrEmpty(Request["ParentID"]))
            {
                bu1.Append(" and  ParentID= '" + Input.FilterAll(Request["ParentID"].Trim()) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["BoardID"]))
            {
                bu1.Append(" and BoardID='" +  Input.FilterAll(Request["BoardID"]) + "' ");
            }
            if (!string.IsNullOrEmpty(Request["Username"]))
            {
                bu1.Append(" and Username like '%" + Input.FilterAll(Request["Username"]) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["isbest"]))
            {
                bu1.Append(" and isbest='" +  Input.FilterAll(Request["isbest"]) + "' ");
            }

            if (!string.IsNullOrEmpty(Request["locktopic"]))
            {
                string locktopic = Input.FilterAll(Request["locktopic"]);
                if (locktopic == "0" || locktopic == "1")
                {
                    bu1.Append(" and locktopic='" + locktopic + "' ");
                }
                else
                {
                    bu1.Append(" and locktopic<>0 and  locktopic<>1 ");
                }
              
            }
            if (!string.IsNullOrEmpty(Request["AnnounceID"]))
            {
                bu1.Append(" and AnnounceID='" + Input.FilterAll(Request["AnnounceID"]) + "' ");
            }

            if (!string.IsNullOrEmpty(Request["PostTable"]))
            {
                bu1.Append(" and PostTable='" + Input.FilterAll(Request["PostTable"]) + "' ");
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
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = column;
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            int myCount = 0;
            
            DataTable lsResult = Pbzx.SQLServerDAL.Basic.BbsGetRecordFromPagesDs("CN_TempBbs", "ID,ParentID,BoardID,Username,isbest,locktopic,AnnounceID,PostTable,DateAndTime", order, "ID", Pbzx.Common.WebInit.webBaseConfig.WebPageNum, AspNetPager1.CurrentPageIndex,true, 3, Searchstr, out myCount);
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
                if(objBoard != null)
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
