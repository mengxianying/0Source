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
    public partial class softdog_Manager : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "SellTime";
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

                if (!string.IsNullOrEmpty(Request["Time"]))
                {
                    if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                    {

                        bu1.Append(" and SellTime between '" + Convert.ToDateTime(Request["strCreateTime1"]).ToShortDateString()+" 0:00:00" + "' and '" +  Convert.ToDateTime(Request["strCreateTime2"]).ToShortDateString()+" 23:59:59" + "'  ");

                    }
                }

                //if (!string.IsNullOrEmpty(Request["Agent"]))
                //{
                //    bu1.Append(" and AgentName='" + Request["Agent"] + "' ");
                //}
                if (!string.IsNullOrEmpty(Request["PayType"]))
                {
                    bu1.Append(" and PayType='" + Request["PayType"] + "'");
                }

                if (!string.IsNullOrEmpty(Request["Status"]))
                {
                    bu1.Append(" and Status='" + Request["Status"] + "' ");
                }
                if (!string.IsNullOrEmpty(Request["strSN"]))
                {
                    bu1.Append(" and SN like'%" + Request["strSN"] + "%' ");
                }
                if (!string.IsNullOrEmpty(Request["strOldSN"]))
                {
                    bu1.Append(" and OldSN='" + Request["strOldSN"] + "'");
                }

                if (!string.IsNullOrEmpty(Request["strSeller"]))
                {
                    bu1.Append(" and Seller='" + Request["strSeller"] + "' ");
                }
                if (!string.IsNullOrEmpty(Request["strRemarks"]))
                {
                    bu1.Append(" and Remarks like '%" + Request["strRemarks"] + "%'");
                }            
            

            return bu1.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);    
        }
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.SoftDogInfo backBLL = new Pbzx.BLL.SoftDogInfo();
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
                string strTotalTemp = backBLL.GetTotalMoney(bu.ToString());
                this.lblTotal.Text = "总金额：" + strTotalTemp.Split(new char[] { '&' })[1] + "元&nbsp;总计:" + strTotalTemp.Split(new char[] { '&' })[0] + "条";
                this.litContent.Text = "";
            }

        }
        public static string GetStatus(object objnum)
        {
            string status = "";
            int Snum = int.Parse(objnum.ToString());
            switch (Snum)
            {
             case 0:
                    status="未出售";
                    break;
                case 1:
                    status="<font color='#009900'>已出售</font>";
                    break;
                case 10:
                    status="<font color='red'>禁止</font>";
                    break;
                default:
                    status = "";
                    break;
               }
               return status;
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='softdog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
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
    }
}
