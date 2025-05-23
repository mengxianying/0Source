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

namespace Pbzx.Web.PB_Manage
{
    public partial class Broker_TradeInfo : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!Page.IsPostBack)
                {
                    this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
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
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_broker_TradeInfo MyBLL = new Pbzx.BLL.PBnet_broker_TradeInfo();
          //  Pbzx.Model.PBnet_UserTradeInfo MyModel = new Pbzx.Model.PBnet_UserTradeInfo();
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

            DataTable IsResult = MyBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);

            if (IsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
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
        
        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["strBrokerName"]))
            {
                bu1.Append(" and BrokerName like '%" + Request["strBrokerName"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strCustomerName"]))
            {
                bu1.Append(" and CustomerName like '%" + Request["strCustomerName"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strrate"]))
            {
                bu1.Append(" and BrokerIncome='" + Request["strrate"] + "' ");
            }
            //if (!string.IsNullOrEmpty(Request["installType"]))
            //{
            //    bu1.Append(" and InstallType='" + Request["installType"] + "'");
            //}

            if (!string.IsNullOrEmpty(Request["strOrderID"]))
            {
                bu1.Append(" and OrderID like '%" + Request["strOrderID"].Trim() + "%' ");
            }
                        
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {

                    bu1.Append(" and CreateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");

                }
            }
            return bu1.ToString();
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return result[0] + "(" + result[1]+")";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
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

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Broker_TradeInfo_Edit.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
