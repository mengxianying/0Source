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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class Cut_valueSXF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ///����������
                DataSet dsBank = DbHelperSQL.Query("select PayTypeName,PayTypeID from PBnet_PayType where PayValue='1' and FTypeID<>'0'  ");
                ddlBankName.DataSource = dsBank;
                ddlBankName.DataTextField = "PayTypeName";
                ddlBankName.DataValueField = "PayTypeID";
                ddlBankName.DataBind();
                ddlBankName.Items.Insert(0, new ListItem("��ѡ��", ""));
                ddlBankName.Items[0].Selected = true;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            decimal mo = 0;
            if (!decimal.TryParse(this.txtTradeMoney.Text, out mo))
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ÿۿ����ȷ')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ó�ֵ����ȷ')", true);
                return;
            }

            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.Account_UserName = "";
            tradeModel.AccountNumber = "";
            if (this.ddlBankName.SelectedValue != "")
            {
                tradeModel.BankName = this.ddlBankName.SelectedItem.Text;
            }
            tradeModel.CurrentMoney = 0;
            
            tradeModel.ForeignKey_id = this.txtOrderID.Text;
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();

            string strBZ =  DateTime.Now + "����̨����Ա������[" + this.txtOrderID.Text + "]��д���������" + Math.Round(mo, 2) + "Ԫ";

            if (!string.IsNullOrEmpty(this.txtDetails.Text))
            {
                strBZ += "����ע��Ϣ��"+this.txtDetails.Text;
            }
            tradeModel.Remark = strBZ;                       
            tradeModel.TradeMoney = Math.Round(mo, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = "";
            tradeModel.TradeType = 501;
            tradeModel.UserName = "";
            bool result = tradeBll.Add(tradeModel);
            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
            if (result)
            {
                Response.Write("<script language='javascript'>alert('�����ɹ���');window.returnValue ='1';self.close();</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('����ʧ�ܣ�');window.returnValue ='0';self.close();</script>");
            }
        }
    }
}
