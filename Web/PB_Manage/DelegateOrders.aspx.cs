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
    public partial class DelegateOrders : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "UpdateStaticDate";
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

            if (!string.IsNullOrEmpty(Request["IsPay"]))
            {
                string str = Request["IsPay"];
                if (str == "1")
                {
                    bu.Append(" and (IsPay='1' or IsPay='2') ");
                }
                else
                {
                    bu.Append(" and  IsPay='3' ");
                }
            }
            if (!string.IsNullOrEmpty(Request["Error"]))
            {
                bu.Append(" and OrderID in (select OrderID from PBnet_OrderDetail where State=2 ) ");
            }

            if (!string.IsNullOrEmpty(Request["Type"]) && Request["Type"] != "-1")
            {
                bu.Append(" and Type='" + Request["Type"] + "' ");
            }
            else if (string.IsNullOrEmpty(Request["Type"]))
            {
                //bu.Append(" and Type='1' ");
            }

            if (!string.IsNullOrEmpty(Request["tipID"]) && Request["tipID"] != "-1")
            {
                bu.Append(" and TipID='" + Request["tipID"].Trim() + "' ");
            }
            else if (string.IsNullOrEmpty(Request["tipID"]))
            {
            }

            if (!string.IsNullOrEmpty(Request["payType"]))
            {
                bu.Append(" and PayTypeID='" + Request["payType"].Trim() + "' ");
            }

            if (!string.IsNullOrEmpty(Request["IsCancal"]) && Request["IsCancal"] != "-1")
            {
                if (Request["IsCancal"] == "0")
                {
                    bu.Append(" and IsCancel='0' ");
                }
                else
                {
                    bu.Append(" and (IsCancel='1' or IsCancel='2') ");
                }
            }
            else if (string.IsNullOrEmpty(Request["IsCancal"]))
            {
                bu.Append(" and IsCancel='0' ");
            }

            if (!string.IsNullOrEmpty(Request["strOrderID"]))
            {
                bu.Append(" and OrderID like '%" + Request["strOrderID"].Trim() + "%' ");
            }

            //根据用户名和客户名参数拼接条件
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {
                bu.Append(" and ReceiverName like '%" + Request["strUsername"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strBbsName"]))
            {
                bu.Append(" and UserName like '%" + Request["strBbsName"].Trim() + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and OrderDate between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and UpdateStaticDate between '" + Request["strCreateTime1"] + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                }
            }
            return bu.ToString();

        }

        private void BindData(string column, bool isDesc)
        {
            
            Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and  OrderClass=1 ");
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

            DataTable lsResult = orderBll.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.lblTotal.Text = "";
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                string strTotalTemp = orderBll.GetTotalMoney(bu.ToString());
                string totalPrice = strTotalTemp.Split(new char[] { '&' })[1];
                if (!string.IsNullOrEmpty(totalPrice))
                {
                    totalPrice = Convert.ToString(Math.Round(Convert.ToDecimal(totalPrice), 2));
                }
                else
                {
                    totalPrice = "0";  
                }

                object objTotalPrice = DbHelperSQL.GetSingle(" select sum(TotalProductPrice) from PBnet_Orders where " + Searchstr);
                if (objTotalPrice == null)
                {
                    objTotalPrice = 0;
                }
                this.lblTotalPrice.Text = Math.Round(Convert.ToDecimal(objTotalPrice), 2) + "元";

                object objPostPrice = DbHelperSQL.GetSingle(" select sum(PortPrice) from PBnet_Orders where " + Searchstr);
                if (objPostPrice == null)
                {
                    objPostPrice = 0;
                }
                this.lblPostPrice.Text = Math.Round(Convert.ToDecimal(objPostPrice), 2) + "元";

                object objHasPay = DbHelperSQL.GetSingle(" select sum(HasPayedPrice) from PBnet_Orders where " + Searchstr);
                if (objHasPay == null)
                {
                    objHasPay = 0;
                }
                this.lblHasPay.Text = Math.Round(Convert.ToDecimal(objHasPay), 2) + "元";
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

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "  <a href='OrderDetails.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank' >";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
