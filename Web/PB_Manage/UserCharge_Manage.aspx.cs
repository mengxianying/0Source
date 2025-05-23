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
    public partial class UserCharge_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "OrderDate";
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
            //�ֹ����������Զ�����
            if (!string.IsNullOrEmpty(Request["OnlineType"]) && Request["OnlineType"] != "-1")
            {
                bu.Append(" and OnlineType='" + Request["OnlineType"] + "' ");
            }
            else if (string.IsNullOrEmpty(Request["OnlineType"]))
            {
                bu.Append(" and OnlineType='1' ");
            }
            //�û���
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {
                bu.Append(" and UserName like '%" + Input.Filter(Request["strUsername"].Trim()) + "%' ");
            }

            //��ʵ����
            if (!string.IsNullOrEmpty(Request["strRealName"]))
            {
                bu.Append(" and RealName like '%" + Input.Filter(Request["strRealName"].Trim()) + "%' ");
            }

            //��ֵ��ʽ
            if (!string.IsNullOrEmpty(Request["payType"]))
            {
                bu.Append(" and PayTypeID='" + Input.Filter(Request["payType"].Trim()) + "' ");
            }

            //���
            if (!string.IsNullOrEmpty(Request["strOrderID"]))
            {
                bu.Append(" and OrderID ='" + Input.Filter(Request["strOrderID"].Trim()) + "' ");
            }

            //״̬
            if (!string.IsNullOrEmpty(Request["state"]))
            {
                if (Request["state"] == "-1")
                {
                }
                else
                {
                    if (Input.Filter(Request["state"].Trim()) == "3")
                    {
                        bu.Append(" and state='0' and IsPay='2' and iscancel=0 ");
                    }
                    else if (Request["state"] == "0")
                    {
                        bu.Append(" and state='0' and IsPay='0' and iscancel=0 ");

                    }
                    else if (Request["state"] == "1")
                    {
                        bu.Append(" and state='1' and iscancel=0 ");
                    }
                    else if (Request["state"] == "2")
                    {
                        bu.Append(" and state='2' and iscancel=0 ");
                    }
                }
            }
            else
            {
                bu.Append(" and state='0' and IsPay='2' and iscancel=0 ");
            }

            if (!string.IsNullOrEmpty(Request["strdate"]))
            {
                bu.Append(" and OrderDate between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
            }


            return bu.ToString();

        }

        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_Charge mBLL = new Pbzx.BLL.PBnet_Charge();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and type='0' ");
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
                string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());
                string totalPrice = strTotalTemp.Split(new char[] { '&' })[1];
                if (!string.IsNullOrEmpty(totalPrice))
                {
                    totalPrice = Convert.ToString(Math.Round(Convert.ToDecimal(totalPrice), 2));
                }
                else
                {
                    totalPrice = "0";
                }
                this.lblTotal.Text = "����" + totalPrice + "Ԫ������" + strTotalTemp.Split(new char[] { '&' })[0] + "��";
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
                //<a href='ChargeDetails.aspx?ID=<%#Eval("Id") %>'>
                string href = "<a href='ChargeDetails.aspx?ID=" + e.Row.Cells[1].Text + "'>";
                //string strState = MyGridView.DataKeys[e.Row.RowIndex].Values["State"].ToString();               
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
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

        private string getCLUrl(object payTypeID)
        {
            Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
            Pbzx.Model.PBnet_PayType payTypeModel = payTypeBll.GetModel(Convert.ToInt32(payTypeID));
            return "<span style='color:blue;' ><a href='" + payTypeModel.LinkUrl + "' target='_blank' style='cursor:pointer' >��֤����</a></span>";
        }

        protected string GetZY(object type, object state, object PayTypeName, object PayMoney)
        {
            string result = "";
            //result += PayTypeName;

            if (type.ToString() == "0")
            {
                result += "��ֵ";
            }
            else
            {
                if (state.ToString() == "2")
                {
                    result += "<span color='red'>ȡ��" + PayMoney + "Ԫ<span>";
                }
                else
                {
                    result += "ȡ��" + PayMoney + "Ԫ";
                }
            }
            return result;
        }

        /// <summary>
        /// ��ֵ�ɹ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnEdite_Command(object sender, CommandEventArgs e)
        {
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = chargeBLL.GetModel(Convert.ToInt32(e.CommandArgument));
            model.State = 1;
            model.Result = "��ֵ�ɹ���";
            model.IsPay = 1;
            chargeBLL.Update(model);
            if (ViewState["order"] == null)
            {
                ViewState["order"] = "OrderDate";
            }
            if (ViewState["isDesc"] == null)
            {
                ViewState["isDesc"] = true;
            }

            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(model.UserName);
            userModel.LastTrade_time = DateTime.Now;
            userModel.CurrentMoney += model.PayMoney;
            userBll.Update(userModel);
            ////////////////д�뽻�׼�¼��////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.UserName = model.UserName;
            tradeModel.TradeMoney = model.PayMoney;
            tradeModel.TradeTime = model.OrderDate;
            tradeModel.BankName = model.PayTypeName;
            tradeModel.AccountNumber = userModel.AccountNumber;
            tradeModel.Account_UserName = userModel.RealName;
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
            tradeModel.CurrentMoney = userModel.CurrentMoney;
            tradeModel.ForeignKey_id = model.Id.ToString();
            tradeModel.Remark = DateTime.Now + "����Ա" + WebFunc.GetCurrentAdmin() + "���û�(" + userModel.UserName + ")��ֵ" + Convert.ToDecimal(model.PayMoney);
            tradeModel.TradeType = 1;
            tradeBll.Add(tradeModel);
            ////////////////д�뽻�׼�¼��////////////////////////////////////////////

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void lbtnCancel_Command(object sender, CommandEventArgs e)
        {
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = chargeBLL.GetModel(Convert.ToInt32(e.CommandArgument));
            model.State = 2;
            chargeBLL.Update(model);
            if (ViewState["order"] == null)
            {
                ViewState["order"] = "OrderDate";
            }
            if (ViewState["isDesc"] == null)
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// �õ���ǰ״̬
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string GetState(object state, object IsPay, object isCancel)
        {
            if (isCancel != null && (Convert.ToInt32(isCancel) == 1))
            {
                return "�û�ȡ��";
            }
            else if (isCancel != null && (Convert.ToInt32(isCancel) == 2))
            {
                return "ϵͳȡ��";
            }
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
            return DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + uName.ToString() + "'  ").ToString();
        }
        /// <summary>
        /// ����״̬�ж��Ƿ��ѳ���
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string Statusprice(object state, object lastprice, object price)
        {
            if (lastprice.ToString() == "")
            {
                return "";
            }
            if (price.ToString() == "")
            {
                return "";
            }
            string strSta = state.ToString();
            if (strSta == "1")
            {
                if (Convert.ToDouble(lastprice) == Convert.ToDouble(price))
                {
                    return lastprice.ToString() + "Ԫ";
                }
                else if (Convert.ToDouble(lastprice) > Convert.ToDouble(price))
                {
                    return "<span style='color:green;' >" + lastprice.ToString() + "Ԫ</span>";
                }
                else
                {
                    return "<span style='color:gray;' >" + lastprice.ToString() + "Ԫ</span>";
                }



            }
            return "";

        }


    }
}
