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

namespace Pbzx.Web.PB_Manage
{
    public partial class Cut_value : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            decimal mo = 0;
            if (!decimal.TryParse(this.txtPayMoney.Text, out mo))
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('您输入得扣款金额不正确')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('您输入得扣款金额不正确')", true);
                return;
            }
            


            Pbzx.BLL.PBnet_UserTable utBLL = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable ut = utBLL.GetModelName(Input.FilterAll(this.txtUname.Text));
            if (mo > ut.CurrentMoney)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('错误！扣款金额大于用户余额。')", true);
                return;
            }
            ut.CurrentMoney -= mo;
            bool result = utBLL.Update(ut);
            /////////////////写入交易信息表//////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.Account_UserName = "";
            tradeModel.AccountNumber = "";
            tradeModel.BankName = "";
            tradeModel.CurrentMoney = 0;

            Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(Input.FilterAll(this.txtUname.Text));
            if (userRealModel != null)
            {
                tradeModel.Account_UserName = userRealModel.RealName;
                tradeModel.AccountNumber = userRealModel.AccountNumber;
                tradeModel.BankName = userRealModel.BankName;
                tradeModel.CurrentMoney = userRealModel.CurrentMoney;
            }
            tradeModel.ForeignKey_id = "";
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
             string strBZ = DateTime.Now + "后台管理员给用户[" + this.txtUname.Text + "]扣除余额" + Math.Round(mo, 2) + "元";
            if (!string.IsNullOrEmpty(txtDetails.Text))
            {
                strBZ += "；备注信息：" + this.txtDetails.Text;
            }
            tradeModel.Remark = strBZ;            
            tradeModel.TradeMoney = Math.Round(mo, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = this.txtUname.Text;
            tradeModel.TradeType = 773;
            tradeBll.Add(tradeModel);
            /////////////////写入交易信息表//////////////////////////////////////////////

            if (result)
            {
                Response.Write("<script language='javascript'>alert('扣款成功！');window.returnValue ='1';self.close();</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('扣款失败！');window.returnValue ='0';self.close();</script>");
            }
        }
    }
}
