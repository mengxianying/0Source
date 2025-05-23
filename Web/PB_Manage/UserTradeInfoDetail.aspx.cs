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

namespace Pbzx.Web.PB_Manage
{
    public partial class UserTradeInfoDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_UserTradeInfo userTBll = new Pbzx.BLL.PBnet_UserTradeInfo();
                int id = 0;
                if(int.TryParse(Request["id"],out id))
                {
                    Pbzx.Model.PBnet_UserTradeInfo userTModel = userTBll.GetModel(id);
                    this.lblBbsName.Text = userTModel.UserName;

                    if (userTModel.TradeMoney != null)
                    {
                        this.lblTradeMoney.Text = Math.Round((decimal)userTModel.TradeMoney, 2) + "Ԫ";
                    }
                    else
                    {
                        this.lblTradeMoney.Text = "0.00Ԫ";
                    }
                    this.lblTradeTime.Text = userTModel.TradeTime.ToString();
                    this.lblTradeType.Text = Pbzx.Web.WebFunc.GetTradeType(userTModel.TradeType);
                    this.lblBankName.Text = userTModel.BankName;
                    this.lblAccount_UserName.Text = userTModel.Account_UserName;
                    this.lblAccountNumber.Text = userTModel.AccountNumber;
                    if (userTModel.CurrentMoney != null)
                    {
                        this.lblCurrentMoney.Text = Math.Round((decimal)userTModel.CurrentMoney, 2) + "Ԫ";
                    }
                    else
                    {
                        this.lblCurrentMoney.Text = "0.00Ԫ";
                    }
                    this.lblOperateManager.Text = userTModel.OperateManager;
                    this.txtRemark.Text = userTModel.Remark;
                }

               
            }
        }
    }
}
