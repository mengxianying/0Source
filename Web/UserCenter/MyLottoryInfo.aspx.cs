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

namespace Pbzx.Web.UserCenter
{
    public partial class MyLottoryInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "TradeTime";
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
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ��<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["strType"]))
            {
                bu.Append(" and TradeType ='" + Input.FilterAll(Request["strType"]) + "'");
            }


            if (!string.IsNullOrEmpty(Request["dateType"]))
            {

                bu.Append(" and TradeTime between '" + Input.FilterAll(Request["strCreateTime1"].Trim()) + "' and '" + DateTime.Parse(Input.FilterAll(Request["strCreateTime2"])).AddDays(1).ToShortDateString() + "'  ");

            }
            return bu.ToString();

        }

        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_UserTradeInfo mBLL = new Pbzx.BLL.PBnet_UserTradeInfo();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and UserName='" + Method.Get_UserName + "' ");
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

            DataTable lsResult = mBLL.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                object objSR = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + bu.ToString() + " and  (TradeType/10)%10<5 ");
                object objZC = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + bu.ToString() + " and (TradeType/10)%10>=7  and (TradeType/10)%10<=8 ");
                if(objSR != null)
                {
                    this.lblSR.Text = Math.Round(Convert.ToDecimal(objSR.ToString()),2) + "Ԫ";               
                }
                else
                {
                    this.lblSR.Text =  "0.00Ԫ";
                }
                if (objZC != null)
                {
                    this.lblZC.Text = Math.Round(Convert.ToDecimal(objZC.ToString()),2) + "Ԫ";
                }
                else
                {
                    this.lblZC.Text = "0.00Ԫ";
                }
               
                object objZFJE = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + bu.ToString() + " and  (TradeType/10)%10>=5  and  (TradeType/10)%10<=6 ");
                if(objZFJE == null)
                {
                    objZFJE = 0;
                }
                lblZFJE.Text = Math.Round(Convert.ToDecimal(objZFJE.ToString()), 2) + "Ԫ";

                // string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());
                //this.lblTotal.Text = "�ܼƽ�" + strTotalTemp.Split(new char[] { '&' })[1] + "Ԫ&nbsp;�ܼ�:" + strTotalTemp.Split(new char[] { '&' })[0] + "����¼";
                this.litContent.Text = "";
            }
            Pbzx.Model.PBnet_UserTable utReal = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            this.lblKYYE.Text = Math.Round((decimal)utReal.CurrentMoney - (decimal)utReal.FrozenMoney, 2)+"Ԫ";
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
                // string href = "<a href='/SoftRegisterLog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                // e.Row.Cells[0].Text = href + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString();//+ "</a>";
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }

      
    }
}
