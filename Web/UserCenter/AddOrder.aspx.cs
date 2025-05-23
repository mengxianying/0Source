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
using Common;
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class AddOrder : System.Web.UI.Page
    {
        

        private decimal _totalOrderPrice = 0;

        public decimal TotalOrderPrice
        {
            get { return _totalOrderPrice; }
            set { _totalOrderPrice = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            ViewState["Type"] = "0";
            if (!IsPostBack)
            {

                //判断当前用户是否是代理用户(2010-03-04)start     
              
                if (WebFunc.IsDaili())
                {                                      
                    this.txtBrokerName.Text = "";
                    this.tbJingJiRen.Visible = false;
                }
                else
                {             
                    this.tbJingJiRen.Visible = true;
                    string brokerResult = WebFunc.CheckBroker(Method.Get_UserName);
                    if (brokerResult == "true")
                    {
                        spJingJR.Visible = true;
                        this.chbIsJingJR.Checked = true;
                        this.txtBrokerName.Text = Method.Get_UserName;
                    }
                }
                //判断当前用户是否是代理用户(2010-03-04)end
                if(!string.IsNullOrEmpty(Request["type"]))
                {
                    if(Request["type"] == "1")
                    {
                        ViewState["Type"] = "1";
                    }
                }
                InvokeAddOrder1();
            }
        }       
        private void InvokeAddOrder1()
        {
            string cartGuid = Method.GetCartGuid();
            //if (ViewState["Type"].ToString() == "0")
            //{
            //    cartGuid = Method.GetCartGuid();
            //}
            //else if (ViewState["Type"].ToString() == "1")
            //{
            //    cartGuid = Method.GetDelegateCartGuid();
            //}  
                            
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            DataSet dsShoppingCart = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);

            decimal SumPrice = Method.CalShoppingCartPrice(dsShoppingCart,true);


            //判断当前用户是否是代理用户(2010-03-04)end

            AddOrder1._lblSumPrice.Text = string.Format("{0:C2}", SumPrice);

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
                AddOrder1._lblCurrentMoney.Text = string.Format("{0:C2}",uRealInfo.CurrentMoney);
                if (SumPrice > (uRealInfo.CurrentMoney - uRealInfo.FrozenMoney))
                {
                    AddOrder1._lblAlert.Visible = true;
                    AddOrder1._imgCZ.Visible = true;
                    AddOrder1._lblAlert.Text = "您的可用余额不足，请先充值再进行支付。";
                    AddOrder1._rblBalancePay.Enabled = false;
                }
                else
                {
                    AddOrder1._lblAlert.Visible = false;
                    AddOrder1._imgCZ.Visible = false;
                    AddOrder1._lblAlert.Text = "";
                    AddOrder1._rblBalancePay.Enabled = true;
                }
            }
            else
            {
               // Method.GetCurrentUser();
            }
            TotalOrderPrice = SumPrice;
        }

        protected void AddOrders_Command(object sender, CommandEventArgs e)
        {             
            string strBrokerName = Input.FilterAll(this.txtBrokerName.Text);
            //string brokerResult = WebFunc.CheckBroker(strBrokerName);
            //if (!string.IsNullOrEmpty(brokerResult) && brokerResult != "true")
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), WebFunc.GetGuid(), JS.Alert(brokerResult));
            //    return;
            //}
                Pbzx.Model.PBnet_UserTable uRealInfo = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();


                Pbzx.Model.PBnet_Orders orders = new Pbzx.Model.PBnet_Orders();
                string brokerResult = WebFunc.CheckBroker(strBrokerName);

                if (!string.IsNullOrEmpty(brokerResult) && brokerResult != "true")
                {
                    //Page.ClientScript.RegisterStartupScript(GetType(), WebFunc.GetGuid(), JS.Alert(brokerResult));
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", brokerResult, 400, "1", "", "", false, false) + "");
                    //ScriptManager.RegisterStartupScript(this.upBroker, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", brokerResult, 400, "1", "", "", false, false) + "", false);
                    return;
                }
                else if (!string.IsNullOrEmpty(brokerResult) && brokerResult == "true" && chbIsJingJR.Checked)
                {
                    orders.BrokerName = strBrokerName;
                }
                else
                {
                    orders.BrokerName = "";
                }
                orders.TotalProductPrice = TotalOrderPrice;
                LoginSort login = new LoginSort();
                //判断当前用户是否是代理用户(2010-03-04)start
                if (WebFunc.IsDaili())
                {
                    orders.OrderClass = 1;
                }
                else
                {
                    orders.OrderClass = 0;
                }
               
                orders.UserID = int.Parse(Method.Get_UserID);//
                orders.UserName = Method.Get_UserName;
                //收货人信息
                orders.ReceiverName = Input.FilterHTML(AddOrder1._txtReceiverName.Text);
                orders.ReceiverAddress = Input.FilterHTML(AddOrder1._txtReceiverAddress.Text);
                orders.ReceiverPhone = Input.FilterHTML(AddOrder1._txtReceiverPhone.Text);
                orders.ReceiverEmail = Input.FilterHTML(AddOrder1._txtReceiverEmail.Text);
                orders.ReceiverPostalCode = Input.FilterHTML(AddOrder1._txtReceiverPostalCode.Text);

                Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
                Pbzx.Model.PBnet_PayType payModel = payTypeBll.GetModel(int.Parse(e.CommandArgument.ToString()));

                //付款方式
                orders.PayTypeID = payModel.PayTypeID;
                orders.PayTypeName = payModel.PayTypeName;

                orders.Type = payModel.PayValue;                
                //收货方式

                
                if (AddOrder1._hdPortPrice.Value == "20")
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
                DataSet shoppingCartList = shoppingCartBll.SelectShoppingCartByCartGuid(Method.GetCartGuid());
                Pbzx.BLL.PBnet_Orders ordersBll = new Pbzx.BLL.PBnet_Orders();
               
                if (orders.PayTypeName == "余额支付")
                { 
                    decimal totalBookPrice = Method.CalShoppingCartPrice(shoppingCartList, false); 
                    if (totalBookPrice > (uRealInfo.CurrentMoney - uRealInfo.FrozenMoney))
                    {
                        Response.Write("<script>alert('您的余额不足，订单提交失败！');history.go(-1);</script>");
                        Response.End();
                        return;
                    }
                }
                orders.UserIP = Request.UserHostAddress;
                string orderID = ordersBll.InsertOrders(orders, shoppingCartList);

                if (string.IsNullOrEmpty(orderID))
                {
                    AddOrder1._lblMsg.Text = "生成订单失败！请核实后输入！";
                }
                else
                {
                    if (!string.IsNullOrEmpty(orders.ReceiverEmail))
                    {
                        //发送订单邮件
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
        protected void txtBrokerName_TextChanged(object sender, EventArgs e)
        {
            string strBrokerName = Input.FilterAll(this.txtBrokerName.Text);
            string brokerResult = WebFunc.CheckBroker(strBrokerName);
            if (!string.IsNullOrEmpty(brokerResult) && brokerResult != "true")
            {
                ScriptManager.RegisterStartupScript(this.upBroker, this.GetType(), WebFunc.GetGuid(), JS.Alert(brokerResult),false);
                //ScriptManager.RegisterStartupScript(this.upBroker, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", brokerResult, 350, "1", "", "", false, false) + "", false);
               // ScriptManager.RegisterStartupScript(this.upBroker, this.GetType(), "err", JS.Alert(), false);
            }
        }

        protected void chbIsJingJR_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsJingJR.Checked)
            {
                this.spJingJR.Visible = true;
            }
            else
            {
                this.txtBrokerName.Text = "";
                this.spJingJR.Visible = false;
            }
        }
    }
}
