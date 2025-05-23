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
                ///绑定银行名称
                DataSet dsBank = DbHelperSQL.Query("select PayTypeName,PayTypeID from PBnet_PayType where PayValue='1' and FTypeID<>'0'  ");
                ddlBankName.DataSource = dsBank;
                ddlBankName.DataTextField = "PayTypeName";
                ddlBankName.DataValueField = "PayTypeID";
                ddlBankName.DataBind();
                ddlBankName.Items.Insert(0, new ListItem("请选择", ""));
                ddlBankName.Items[0].Selected = true;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            decimal mo = 0;
            if (!decimal.TryParse(this.txtTradeMoney.Text, out mo))
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('您输入得扣款金额不正确')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('您输入得充值金额不正确')", true);
                return;
            }

            /////////////////写入交易信息表//////////////////////////////////////////////
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

            string strBZ =  DateTime.Now + "；后台管理员处理订单[" + this.txtOrderID.Text + "]填写汇款手续费" + Math.Round(mo, 2) + "元";

            if (!string.IsNullOrEmpty(this.txtDetails.Text))
            {
                strBZ += "；备注信息："+this.txtDetails.Text;
            }
            tradeModel.Remark = strBZ;                       
            tradeModel.TradeMoney = Math.Round(mo, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = "";
            tradeModel.TradeType = 501;
            tradeModel.UserName = "";
            bool result = tradeBll.Add(tradeModel);
            /////////////////写入交易信息表//////////////////////////////////////////////
            if (result)
            {
                Response.Write("<script language='javascript'>alert('操作成功！');window.returnValue ='1';self.close();</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('操作失败！');window.returnValue ='0';self.close();</script>");
            }
        }
    }
}
