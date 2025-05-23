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
using System.Text.RegularExpressions;

namespace Pbzx.Web.Contorls
{
    public partial class UcAddOrder : System.Web.UI.UserControl
    {

        public HiddenField _hdPortPrice
        {
            get
            {
                return hdPortPrice;
            }
            set
            {
                this.hdPortPrice = value;
            }
        }

        protected string[] myChange = new string[3];
        private string divHead = "<div class='Order_list_qie1bg'>";//style='width:100%; height:100% 
        private string divHead1 = "<div class='Order_list_qie2bg'>";
        private string divfoot = "</div>";

        private bool _disPortType = false ;
        /// <summary>
        /// 是否显示protType
        /// </summary>
        public bool DisPortType
        {
            get
            {
                return _disPortType;
            }
            set { _disPortType = value; }
        }

        public event CommandEventHandler AddOrders_Command;
        public event EventHandler ModifyOrdersClick;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //<asp:ObjectDataSource ID="objectDSPayType" runat="server" SelectMethod="GetAllList"
                //TypeName="Pbzx.BLL.PBnet_PayType"></asp:ObjectDataSource>
                Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
                DataSet dsShoppingCart = shoppingCartBll.SelectShoppingCartByCartGuid(Method.GetCartGuid());

                bool hasRJG = false;
                decimal SumBookPrice = 0.0M;
                decimal SumPrice = 0.0M;
                hdPortPrice.Value = "0";
                foreach (DataRow row in dsShoppingCart.Tables[0].Rows)
                {
                    string regType = row["RegType"].ToString();
                    string[] strRegType = regType.Split(new char[] { '|' });
                    decimal price = 0;
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
                        if (strRegType[0] == "7")
                        {
                            hasRJG = true;
                            hdPortPrice.Value = "20";
                        }
                    }
                    SumBookPrice += price;
                }
                decimal dcJianRJG = SumBookPrice;
                if(hasRJG)
                {
                    dcJianRJG = SumBookPrice - WebInit.webBaseConfig.SoftdogPrice;
                }
                StringBuilder sb = new StringBuilder();
                if (WebFunc.IsDaili())
                {
                    decimal jjrZK = WebFunc.GetCurrentPricePercent();
                    sb.Append("<div style='font-size:12px;'>您是代理用户<br/>用户名：" + Method.Get_UserName + "<br/>代理折扣：" + Convert.ToInt32(jjrZK * 100) + "%<br/><br/>软件金额：");
                    sb.Append(dcJianRJG.ToString("0.00") + "元*" + Convert.ToInt32(jjrZK * 100) + "%&nbsp;");
                    SumPrice += dcJianRJG * jjrZK;
                }
                else
                {
                    sb.Append("<font style='font-size:12px;'>软件金额：");
                    sb.Append(dcJianRJG.ToString("0.00") + "元&nbsp;");
                    SumPrice += dcJianRJG;
                }
                if(hasRJG)
                {
                    sb.Append("+&nbsp;软件狗价格：" + WebInit.webBaseConfig.SoftdogPrice.ToString("0.00")+"元&nbsp;");
                    SumPrice += WebInit.webBaseConfig.SoftdogPrice;
                    sb.Append("+&nbsp;快递费：20.00元&nbsp;");
                    SumPrice += 20;
                }
                sb.Append("</div>");
                this.lblJSXX.Text = sb.ToString();
                this.lblYFJE.Text = " <font style='font-size:14px; font-weight:bold; color:Red;'>应付总额：<font style='font-size:14px; font-weight:bold; color:Red;'>"+SumPrice.ToString("0.00")+"</font> 元 </font>";
                ViewState["payType"] = "1";
                //this.lblPayType.Text = "备注：即时到帐，支持绝大多数银行借记卡及信用卡，准确快捷，推荐您使用此支付方式！ &nbsp; &nbsp;<a href='/Payment.htm' target='_blank'>查看银行及限额</a>";
            }
        }

        

        

        #region 收货人信息
        public TextBox _txtReceiverName
        {
            get { return txtReceiverName; }
            set { txtReceiverName = value; }
        }

        public TextBox _txtReceiverAddress
        {
            get { return txtReceiverAddress; }
            set { txtReceiverAddress = value; }
        }


        public TextBox _txtReceiverPostalCode
        {
            get { return txtReceiverPostalCode; }
            set { txtReceiverPostalCode = value; }
        }

        public TextBox _txtReceiverPhone
        {
            get { return txtReceiverPhone; }
            set { txtReceiverPhone = value; }
        }

         public TextBox _txtReceiverEmail
        {
            get { return txtReceiverEmail; }
            set { txtReceiverEmail = value; }
        }
        #endregion

        #region 收货方式
        public Panel _rblPortType
        {
            get { return tbPortType; }
            set { tbPortType = value; }
        }
        #endregion



        #region 费用信息
        //public Label _lblTotalBookPrice
        //{
        //    get { return lblTotalBookPrice; }
        //    set { lblTotalBookPrice = value; }
        //}

        //public Label _lblPortPrice
        //{
        //    get { return lblPortPrice; }
        //    set { lblPortPrice = value; }
        //}

        //public Label _lblSumPrice
        //{
        //    get { return lblSumPrice; }
        //    set { lblSumPrice = value; }
        //}

        //public Label _lblHasPayedPrice
        //{
        //    get { return lblHasPayedPrice; }
        //    set { lblHasPayedPrice = value; }
        //}

        //public Label _lblHasNotPayedPrice
        //{
        //    get { return lblHasNotPayedPrice; }
        //    set { lblHasNotPayedPrice = value; }
        //}

        public RadioButton _rblBalancePay
        {
            get { return rblBalancePay; }
            set { rblBalancePay = value; }
        }
        #endregion

        #region 按钮
        public Button _btnAddOrders
        {
            get { return btnAddOrders; }
            set { btnAddOrders = value; }
        }

        public Button _btnModifyOrders
        {
            get { return btnModifyOrders; }
            set { btnModifyOrders = value; }
        }
        #endregion



        #region 提示
        public Label _lblMsg
        {
            get { return lblMsg; }
            set { lblMsg = value; }
        }
        #endregion

        #region 总价格
        public Label _lblSumPrice
        {
            get { return lblSumPrice; }
            set { lblSumPrice = value; }
        }
        #endregion

        #region 余额
        public Label _lblCurrentMoney
        {
            get { return lblCurrentMoney; }
            set { lblCurrentMoney = value; }
        }
        #endregion

        #region 警告
        public Label _lblAlert
        {
            get { return lblAlert; }
            set { lblAlert = value; }
        }
        #endregion



        #region 警告
        public Image _imgCZ
        {
            get { return imgCZ; }
            set { imgCZ = value; }
        }

        #endregion


        #region 按钮触发事件
        protected void btnModifyOrders_Click(object sender, EventArgs e)
        {
            ModifyOrdersClick(this, e);
        }
        #endregion


        protected void btnAddOrders_Command(object sender, CommandEventArgs e)
        {
            int strReceiverNameLength = Method.GetStrLen(this.txtReceiverName.Text.Trim());
            int strReceiverAddressLength = Method.GetStrLen(this.txtReceiverAddress.Text.Trim());
            String mobile = this.txtReceiverPhone.Text.Trim();

            if(strReceiverNameLength < 4)
            {
                Page.RegisterStartupScript("", "<script>alert('姓名不能小于两个汉字！');</script>");
                return;
            }

            if (strReceiverAddressLength < 4)
            {
                Page.RegisterStartupScript("", "<script>alert('详细地址不能小于两个汉字！');</script>");
                return;
            }

            if (!Regex.IsMatch(mobile, @"^1[3-9]\d{9}$"))
            {
                Page.RegisterStartupScript("", "<script>alert('对不起，该手机号码不正确！');</script>");
                return;
            }

            if (pnlYEZF.Visible == true &&  this.imgCZ.Visible && this.lblAlert.Visible && !string.IsNullOrEmpty(this.lblAlert.Text))
            {
                //Page.RegisterStartupScript(WebFunc.GetGuid(),"" + JS.myAlert1("", "您的余额不足，请先充值！", 400, "1", "", "", false, false) + "");
                Page.RegisterStartupScript("", "<script>alert('您的余额不足，请先充值！');</script>");
                return;
            }
            string value = ViewState["payType"].ToString();
            //if (this.rblPayType.Visible)
            //{
            //   value = this.rblPayType.SelectedValue;
            //}
            //else
            //{
            //   value = "20";
            //}
            AddOrders_Command(sender, new CommandEventArgs(e.CommandName, value));
        }

        protected void rblOnline_CheckedChanged(object sender, EventArgs e)
        {
            if(rblOnline.Checked)
            {
                ViewState["payType"] = "1";
                pnlYEZF.Visible = false;
            }
        }

        protected void rblBank_CheckedChanged(object sender, EventArgs e)
        {
            if (rblBank.Checked)
            {
                ViewState["payType"] = "2";
                pnlYEZF.Visible = false;
            }
        }

        protected void rblBalancePay_CheckedChanged(object sender, EventArgs e)
        {
            if (rblBalancePay.Checked)
            {
                pnlYEZF.Visible = true;
                if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
                {
                    this.rblBalancePay.Enabled = false;
                    ScriptManager.RegisterStartupScript(this.UpFKFS, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert("", "只有高级用户才能使用此项功能，您现在就去申请为高级用户吗？", 600, "1", "top.location='UserRealInfo.aspx';", "", false, false) + "", false);
                    return;
                }
                if (this.imgCZ.Visible && this.lblAlert.Visible && !string.IsNullOrEmpty(this.lblAlert.Text))
                {
                    this.rblBalancePay.Enabled = false;
                    Page.RegisterStartupScript("", "<script>alert('您的余额不足，请先充值！');</script>");
                    return;
                }
                this.rblBalancePay.Enabled = true;
                ViewState["payType"] = "20";
            }
            else
            {
                pnlYEZF.Visible = false;
            }
        }


    }
}