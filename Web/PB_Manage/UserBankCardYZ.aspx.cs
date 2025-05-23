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
                    Response.Write("<script language='javascript'>alert('��ֵʧ��1��');window.returnValue ='2';window.close()</script>");
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
                Response.Write("<script language='javascript'>alert('��ֵʧ��2��');window.returnValue ='2';window.close()</script>");
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
            tradeModel.Remark = DateTime.Now + "����̨�����û�(" + userModel.UserName + ")�����п���֤��ƴ�����߲���ͨ����������룺" + Convert.ToDecimal(userModel.AccountNumberCode);
            userModel.LastTrade_time = DateTime.Now;
            string result = Pbzx.Common.Method.GetEmailContent(("/Template/Email_Success.aspx?uid=" + userModel.Id + "&type=AccountNumberStateYZ&DH=" + this.txtDH.Text));
            try
            {
                //Զ���ʼ����Ϳ���
                string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                if (jmailString == null || jmailString != "true")
                {
                    //Email email = new Email(userModel.Email, "ƴ�����߲���ͨ������п���֤��ϵͳ�Զ����ͣ�����ظ���", result);
                    //email.Send("ƴ�����߲���ͨ���");
                }
                else
                {
                    //Զ�̵���
                    Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                    wb.GetEmail(userModel.Email, "ƴ�����߲���ͨ������п���֤��ϵͳ�Զ����ͣ�����ظ�", result);
                }
                Pbzx.Common.ErrorLog.WriteLogMeng("��ֵ�ʼ�����", "�û���" + userModel.UserName + " �ʼ����ͳɹ�", true, true);
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("��ֵ�ʼ�����", ex.ToString(), true, true);

            }
            Response.Write("<script language='javascript'>alert('��ֵ�ɹ���');window.returnValue ='1';window.close()</script>");
        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alert('��ֵʧ��3��');window.returnValue ='2';window.close()</script>");
        }
    }
}
