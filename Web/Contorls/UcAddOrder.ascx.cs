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
        /// �Ƿ���ʾprotType
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
                    sb.Append("<div style='font-size:12px;'>���Ǵ����û�<br/>�û�����" + Method.Get_UserName + "<br/>�����ۿۣ�" + Convert.ToInt32(jjrZK * 100) + "%<br/><br/>�����");
                    sb.Append(dcJianRJG.ToString("0.00") + "Ԫ*" + Convert.ToInt32(jjrZK * 100) + "%&nbsp;");
                    SumPrice += dcJianRJG * jjrZK;
                }
                else
                {
                    sb.Append("<font style='font-size:12px;'>�����");
                    sb.Append(dcJianRJG.ToString("0.00") + "Ԫ&nbsp;");
                    SumPrice += dcJianRJG;
                }
                if(hasRJG)
                {
                    sb.Append("+&nbsp;������۸�" + WebInit.webBaseConfig.SoftdogPrice.ToString("0.00")+"Ԫ&nbsp;");
                    SumPrice += WebInit.webBaseConfig.SoftdogPrice;
                    sb.Append("+&nbsp;��ݷѣ�20.00Ԫ&nbsp;");
                    SumPrice += 20;
                }
                sb.Append("</div>");
                this.lblJSXX.Text = sb.ToString();
                this.lblYFJE.Text = " <font style='font-size:14px; font-weight:bold; color:Red;'>Ӧ���ܶ<font style='font-size:14px; font-weight:bold; color:Red;'>"+SumPrice.ToString("0.00")+"</font> Ԫ </font>";
                ViewState["payType"] = "1";
                //this.lblPayType.Text = "��ע����ʱ���ʣ�֧�־���������н�ǿ������ÿ���׼ȷ��ݣ��Ƽ���ʹ�ô�֧����ʽ�� &nbsp; &nbsp;<a href='/Payment.htm' target='_blank'>�鿴���м��޶�</a>";
            }
        }

        

        

        #region �ջ�����Ϣ
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

        #region �ջ���ʽ
        public Panel _rblPortType
        {
            get { return tbPortType; }
            set { tbPortType = value; }
        }
        #endregion



        #region ������Ϣ
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

        #region ��ť
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



        #region ��ʾ
        public Label _lblMsg
        {
            get { return lblMsg; }
            set { lblMsg = value; }
        }
        #endregion

        #region �ܼ۸�
        public Label _lblSumPrice
        {
            get { return lblSumPrice; }
            set { lblSumPrice = value; }
        }
        #endregion

        #region ���
        public Label _lblCurrentMoney
        {
            get { return lblCurrentMoney; }
            set { lblCurrentMoney = value; }
        }
        #endregion

        #region ����
        public Label _lblAlert
        {
            get { return lblAlert; }
            set { lblAlert = value; }
        }
        #endregion



        #region ����
        public Image _imgCZ
        {
            get { return imgCZ; }
            set { imgCZ = value; }
        }

        #endregion


        #region ��ť�����¼�
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
                Page.RegisterStartupScript("", "<script>alert('��������С���������֣�');</script>");
                return;
            }

            if (strReceiverAddressLength < 4)
            {
                Page.RegisterStartupScript("", "<script>alert('��ϸ��ַ����С���������֣�');</script>");
                return;
            }

            if (!Regex.IsMatch(mobile, @"^1[3-9]\d{9}$"))
            {
                Page.RegisterStartupScript("", "<script>alert('�Բ��𣬸��ֻ����벻��ȷ��');</script>");
                return;
            }

            if (pnlYEZF.Visible == true &&  this.imgCZ.Visible && this.lblAlert.Visible && !string.IsNullOrEmpty(this.lblAlert.Text))
            {
                //Page.RegisterStartupScript(WebFunc.GetGuid(),"" + JS.myAlert1("", "�������㣬���ȳ�ֵ��", 400, "1", "", "", false, false) + "");
                Page.RegisterStartupScript("", "<script>alert('�������㣬���ȳ�ֵ��');</script>");
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
                    ScriptManager.RegisterStartupScript(this.UpFKFS, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert("", "ֻ�и߼��û�����ʹ�ô���ܣ������ھ�ȥ����Ϊ�߼��û���", 600, "1", "top.location='UserRealInfo.aspx';", "", false, false) + "", false);
                    return;
                }
                if (this.imgCZ.Visible && this.lblAlert.Visible && !string.IsNullOrEmpty(this.lblAlert.Text))
                {
                    this.rblBalancePay.Enabled = false;
                    Page.RegisterStartupScript("", "<script>alert('�������㣬���ȳ�ֵ��');</script>");
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