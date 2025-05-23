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
    public partial class UserTradeInfo : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
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
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
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
            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                bu.Append(" and UserName like'%" + Input.FilterAll(Request["UserName"]) + "%'");
            }
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
            object objZHYE = DbHelperSQL.GetSingle(" select sum(CurrentMoney) from PBnet_UserTable");
            if (objZHYE == null)
            {
                objZHYE = 0;
            }
            this.lblUserTotal.Text = Math.Round(Convert.ToDecimal(objZHYE), 2) + "Ԫ";

            Pbzx.BLL.PBnet_UserTradeInfo mBLL = new Pbzx.BLL.PBnet_UserTradeInfo();

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

            DataTable lsResult = mBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                object objSR = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  (TradeType/100)>=3 and (TradeType/100)<=4  ");
                object objZC = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  (TradeType/100)>=7 and  (TradeType/100)<=8 ");
                decimal sr = 0;
                if (objSR != null)
                {
                    sr = Math.Round(Convert.ToDecimal(objSR.ToString()), 2);
                    this.lblSR.Text = sr + "Ԫ";
                }
                else
                {
                    this.lblSR.Text = "0.00Ԫ";
                }
                decimal zc = 0;
                if (objZC != null)
                {
                    zc = Math.Round(Convert.ToDecimal(objZC.ToString()), 2);
                    this.lblZC.Text = zc + "Ԫ";
                }
                else
                {
                    this.lblZC.Text = "0.00Ԫ";
                }


                this.lblMLR.Text = Math.Round(sr - zc,2) + "Ԫ";
              
                object objSJSR = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  (TradeType/100)<=2   ");

                object objSJZC = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  (TradeType/100)>=5 and (TradeType/100)<=6  ");
                if(objSJSR == null)
                {
                    objSJSR = 0;
                }
                if (objSJZC == null)
                {
                    objSJZC = 0;
                }
                lblSJSR.Text = Math.Round(Convert.ToDecimal(objSJSR.ToString()), 2) + "Ԫ";
                lblSJZC.Text = Math.Round(Convert.ToDecimal(objSJZC.ToString()), 2) + "Ԫ";
                this.lblSJLR.Text = (Math.Round(Convert.ToDecimal(objSJSR.ToString()), 2) - Math.Round(Convert.ToDecimal(objSJZC.ToString()), 2)) + "Ԫ";


                lblSR2.Text = lblSR.Text;
                lblZC2.Text = lblZC.Text;
                object objLoginFD = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  TradeType=512 ");

                object objJJR = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  TradeType=511 ");
                if (objLoginFD == null)
                {
                    objLoginFD = 0;
                }
                if (objJJR == null)
                {
                    objJJR = 0;
                }                
                lblLoginFD.Text = Math.Round(Convert.ToDecimal(objLoginFD), 2) + "Ԫ";
                lblJJR.Text = Math.Round(Convert.ToDecimal(objJJR), 2) + "Ԫ";

                object objYEZF = DbHelperSQL.GetSingle(" select sum(TradeMoney) from PBnet_UserTradeInfo where " + Searchstr + " and  (TradeType/10 % 10) >= 7 and (TradeType/10 % 10)<=8 and (TradeType/100)<5 ");
                if (objYEZF == null)
                {
                    objYEZF = 0;
                }

                lblYEZF.Text = Math.Round(Convert.ToDecimal(objYEZF), 2) + "Ԫ";

                lblTJYE.Text = Math.Round(sr - zc + Convert.ToDecimal(objLoginFD) + Convert.ToDecimal(objJJR) - Convert.ToDecimal(objYEZF), 2) + "Ԫ";
                // string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());
                //this.lblTotal.Text = "�ܼƽ�" + strTotalTemp.Split(new char[] { '&' })[1] + "Ԫ&nbsp;�ܼ�:" + strTotalTemp.Split(new char[] { '&' })[0] + "����¼";
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
                string href = "<a href='UserTradeInfoDetail.aspx?ID=" + e.Row.Cells[1].Text + "' target='_blank' >";
                e.Row.Cells[1].Text = href+"("+ (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString()+ ")</a>";
            }
        }


        /// <summary>
        /// �õ��û�״̬
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="payMoney"></param>
        /// <returns></returns>
        public string GetUserState(string userName, decimal payMoney)
        {
            Pbzx.BLL.PBnet_UserTable realUserBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable realUserModel = realUserBll.GetModelName(userName);
            if (realUserModel.State != 2)
            {
                return Method.GetRealUserSateByState(realUserModel.State);
            }
            return "";
        }


     
        /// <summary>
        /// �õ���ǰ״̬
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string GetState(object state, object IsPay)
        {

            string strSta = state.ToString();
            string result = "";
            switch (strSta)
            {
                case "0":
                    if (IsPay.ToString() == "0")
                    {
                        return "δ����";
                    }
                    else
                    {
                        return "<span style='color:blue;' >�Ѹ���ȴ����</span>";
                    }
                case "1":
                    return "<span style='color:green;' >��ͨ��</span>";

                case "2":
                    return "<span  style='color:red;' >���δͨ��</span>";

            }
            return result;
        }
        protected string GetUserIDByUserName(object uName)
        {
            if (uName == null)
            {
                return "";
            }
            else
            {
                object objResult = DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + uName.ToString() + "'  ");
                if(objResult == null)
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
