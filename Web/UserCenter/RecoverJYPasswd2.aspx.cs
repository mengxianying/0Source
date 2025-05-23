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
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class RecoverJYPasswd2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Pbzx.BLL.PBnet_UserProtectPwd MyBll = new Pbzx.BLL.PBnet_UserProtectPwd();
                this.lblAsk.Text = MyBll.GetModelName(Method.Get_UserName).SecurityQuestion;
                if (Request["Type"] == "email")
                {
                    this.ask.Visible = false;
                    this.email.Visible = true;
                }
                else if (Request["Type"] == "ask")
                {
                    this.ask.Visible = true;
                    this.email.Visible = false;
                }
                else
                {
                    this.ask.Visible = false;
                    this.email.Visible = false;
                }

            }
        }
        protected void inbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            string Name = Method.Get_UserName;
            string Email = Input.FilterAll(this.txtEmail.Text);
            this.lblEmails.Text = Input.FilterAll(this.txtEmail.Text);
            string Subject = "您的交易密码";
            Pbzx.BLL.PBnet_UserProtectPwd MyBll = new Pbzx.BLL.PBnet_UserProtectPwd();
            if (MyBll.ExistsEmail(Name, Email))
            {
                string strPwd = Method.CreateVerifyCode(8);
                int result = DbHelperSQL.ExecuteSql("update PBnet_UserTable set TradePwd='" + Input.MD5(strPwd) + "' where UserName='" + Name + "'");

                if (result > 0)
                {
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("请重新输入."));
                }

                string content = "您的新交易密码：" + strPwd + "";
                content += "<br />";
                content += "请您<a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx'>点击此处</a>重新设置您的交易密码，还有其它问题请直接与我们客服联系!";
                try
                {
                    //远程邮件发送开关
                    string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                    if (jmailString == null || jmailString != "true")
                    {
                        //Email email = new Email(Email, Subject, content);
                        //email.Send("拼搏在线交易密码找回");
                    }
                    else
                    {
                        //远程调用
                        Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                        wb.GetEmail(Email, Subject, content);
                    }
                    Pbzx.Common.ErrorLog.WriteLogMeng("密码找回邮件发送", "用户：" + Name + " 邮件发送成功", true, true);
                }
                catch (Exception ex)
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("密码找回邮件发送", ex.ToString(), true, true);

                }
                // SendMsg(content, Email);                
                this.email2.Visible = false;
                this.email3.Visible = true;

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("您输入的邮箱地址不对,请重新输入."));
            }
        }
        protected void imbtAsk_Click(object sender, ImageClickEventArgs e)
        {
            string Name = Method.Get_UserName;
            string Question = this.lblAsk.Text;
            string Answer = Input.MD5(Input.FilterAll(this.txtAnswer.Text));


            Pbzx.BLL.PBnet_UserProtectPwd MyBll = new Pbzx.BLL.PBnet_UserProtectPwd();
            if (MyBll.ExistsAsk(Name, Question, Answer))
            {

                Response.Redirect("MakeJYPwd.aspx?tag=ask");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("您的问题或答案存在错误,请重新输入."));
            }
        }

        protected void imbtEmail2_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/"));
        }
    }
}
