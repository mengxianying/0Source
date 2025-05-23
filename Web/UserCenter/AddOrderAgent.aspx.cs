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

namespace Pbzx.Web.UserCenter
{
    public partial class AddOrderAgent : System.Web.UI.Page
    {
        bool disPlayPort = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["Type"] = "0";
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["type"]))
                {
                    if (Request["type"] == "1")
                    {
                        ViewState["Type"] = "1";
                    }
                }
                InvokeAddOrder1();
            }
        }
        private void InvokeAddOrder1()
        {
            string cartGuid = "";
            cartGuid = Method.GetDelegateCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            DataSet dsShoppingCart = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);

            decimal SumPrice = 0;
            foreach (DataRow row in dsShoppingCart.Tables[0].Rows)
            {
                string regType = row["RegType"].ToString();
                string[] strRegType = regType.Split(new char[] { '|' });
                decimal price = 0;
                if (strRegType[0] == "7")
                {
                    disPlayPort = true;
                }
                if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                {
                    string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        price = decimal.Parse(strRegType[1]);
                    }
                }
                int quatity = Convert.ToInt32(row["Quatity"]);
                SumPrice += quatity * price;
            }
            AddOrder1._lblSumPrice.Text = string.Format("{0:C2}", SumPrice);

            AddOrder1.DisPortType = disPlayPort;
            AddOrder1._btnModifyOrders.Enabled = false;
            AddOrder1._btnModifyOrders.Visible = false;
            Pbzx.Model.PBnet_UserTable uRealInfo = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            if (uRealInfo != null)
            {
                AddOrder1._txtReceiverName.Text = uRealInfo.RealName;
                AddOrder1._txtReceiverAddress.Text = uRealInfo.Address;
                AddOrder1._txtReceiverPostalCode.Text = uRealInfo.PostCode;
                AddOrder1._txtReceiverPhone.Text = uRealInfo.Telphone;
                AddOrder1._txtReceiverEmail.Text = uRealInfo.Email;
                AddOrder1._lblCurrentMoney.Text = string.Format("{0:C2}", uRealInfo.CurrentMoney);
                if (SumPrice > (uRealInfo.CurrentMoney - uRealInfo.FrozenMoney))
                {
                    AddOrder1._lblAlert.Visible = true;
                    AddOrder1._imgCZ.Visible = true;
                    AddOrder1._lblAlert.Text = "您的帐户余额不足，请先充值再进行支付。";
                }
                else
                {
                    AddOrder1._lblAlert.Visible = false;
                    AddOrder1._imgCZ.Visible = false;
                    AddOrder1._lblAlert.Text = "";
                }
            }
            else
            {
                // Method.GetCurrentUser();
            }
        }
        protected void AddOrders_Command(object sender, CommandEventArgs e)
        {
            Pbzx.Model.PBnet_UserTable uRealInfo = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            Pbzx.Model.PBnet_Orders_Delegates orders = new Pbzx.Model.PBnet_Orders_Delegates();

            orders.UserID = int.Parse(Method.Get_UserID);//
            orders.UserName = Method.Get_UserName;
            //收货人信息
            orders.ReceiverName = Input.FilterAll(AddOrder1._txtReceiverName.Text);
            orders.ReceiverAddress = Input.FilterAll(AddOrder1._txtReceiverAddress.Text);
            orders.ReceiverPhone = Input.FilterAll(AddOrder1._txtReceiverPhone.Text);
            orders.ReceiverEmail = Input.FilterAll(AddOrder1._txtReceiverEmail.Text);
            orders.ReceiverPostalCode = Input.FilterAll(AddOrder1._txtReceiverPostalCode.Text);

            Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
            Pbzx.Model.PBnet_PayType payModel = payTypeBll.GetModel(int.Parse(e.CommandArgument.ToString()));

            //付款方式
            orders.PayTypeID = payModel.PayTypeID;
            orders.PayTypeName = payModel.PayTypeName;
            orders.Type = payModel.PayValue;

            //收货方式
            if (AddOrder1.DisPortType)
            {
                orders.PortTypeID = 2;
                orders.PortTypeName = "快递";
            }
            else
            {
                orders.PortTypeID = 0;
                orders.PortTypeName = "";
            }
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            DataSet shoppingCartList = shoppingCartBll.SelectShoppingCartByCartGuid(Method.GetDelegateCartGuid());

            Pbzx.BLL.PBnet_Orders_Delegates ordersBll = new Pbzx.BLL.PBnet_Orders_Delegates();
            string orderID = ordersBll.InsertOrders(orders, shoppingCartList);

            if (string.IsNullOrEmpty(orderID))
            {
                AddOrder1._lblMsg.Text = "生成订单失败！请检查输入并重试。";
            }
            else
            {
                //发送订单邮件
                if (!string.IsNullOrEmpty(orders.ReceiverEmail))
                {
                    string toEmail = orders.ReceiverEmail;
                    EmailOrder emailOrder = new EmailOrder(toEmail, orderID, "0", "1");
                    emailOrder.SendEmail();
                }
                if (orders.PayTypeID == 1)
                {
                    Response.Redirect("OnlinePay.aspx?OrderID=" + orderID);
                }
                else if (orders.PayTypeID == 2)
                {
                    Response.Redirect("BankTransfer.aspx?OrderID=" + orderID);
                }
                else if (orders.PayTypeID == 20)
                {
                    // Page.RegisterStartupScript("提示", " if(confirm('您确定要使用余额支付吗？')){location.href='/UserCenter/BalancePay.aspx?OrderID=" + orderID + "';}");
                    Response.Redirect("BalancePayQueRen.aspx?OrderID=" + orderID);
                }
            }
          }
        
    }
}
