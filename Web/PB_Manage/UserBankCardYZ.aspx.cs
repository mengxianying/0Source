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
    public partial class UserBankCardYZ : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Input.FilterAll(Request["uid"]);
                int myid = 0;
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out myid))
                {
                    Response.Write("<script language='javascript'>alert('充值失败1！');window.returnValue ='2';window.close()</script>");
                    return;
                }
                Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable userModel = userBll.GetModel(myid);
                lblAccountNumber.Text = userModel.AccountNumber;
                this.lblAccountNumberCode.Text = userModel.AccountNumberCode;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string id = Input.FilterAll(Request["uid"]);
            int myid = 0;
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out myid))
            {
                Response.Write("<script language='javascript'>alert('充值失败2！');window.returnValue ='2';window.close()</script>");
                return;
            }
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModel(myid);
            userModel.AccountNumberState = 4;
            userBll.Update(userModel);
            lblAccountNumber.Text = userModel.AccountNumber;
            this.lblAccountNumberCode.Text = userModel.AccountNumberCode;
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();

            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.UserName = userModel.UserName;
            tradeModel.TradeMoney = Convert.ToDecimal(userModel.AccountNumberCode);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.BankName = userModel.BankName;
            tradeModel.AccountNumber = userModel.AccountNumber;
            tradeModel.Account_UserName = userModel.RealName;
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
            tradeModel.CurrentMoney = userModel.CurrentMoney - userModel.FrozenMoney;
            tradeModel.ForeignKey_id = "0";
            tradeModel.Remark = DateTime.Now + "，后台处理用户(" + userModel.UserName + ")的银行卡验证，拼搏在线彩神通软件给他汇入：" + Convert.ToDecimal(userModel.AccountNumberCode);
            userModel.LastTrade_time = DateTime.Now;
            string result = Pbzx.Common.Method.GetEmailContent(("/Template/Email_Success.aspx?uid=" + userModel.Id + "&type=AccountNumberStateYZ&DH=" + this.txtDH.Text));
            try
            {
                //远程邮件发送开关
                string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                if (jmailString == null || jmailString != "true")
                {
                    //Email email = new Email(userModel.Email, "拼搏在线彩神通软件银行卡验证（系统自动发送，请勿回复）", result);
                    //email.Send("拼搏在线彩神通软件");
                }
                else
                {
                    //远程调用
                    Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                    wb.GetEmail(userModel.Email, "拼搏在线彩神通软件银行卡验证（系统自动发送，请勿回复", result);
                }
                Pbzx.Common.ErrorLog.WriteLogMeng("充值邮件发送", "用户：" + userModel.UserName + " 邮件发送成功", true, true);
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("充值邮件发送", ex.ToString(), true, true);

            }
            Response.Write("<script language='javascript'>alert('充值成功！');window.returnValue ='1';window.close()</script>");
        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alert('充值失败3！');window.returnValue ='2';window.close()</script>");
        }
    }
}
