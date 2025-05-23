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
            string Subject = "���Ľ�������";
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
                    Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("����������."));
                }

                string content = "�����½������룺" + strPwd + "";
                content += "<br />";
                content += "����<a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx'>����˴�</a>�����������Ľ������룬��������������ֱ�������ǿͷ���ϵ!";
                try
                {
                    //Զ���ʼ����Ϳ���
                    string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                    if (jmailString == null || jmailString != "true")
                    {
                        //Email email = new Email(Email, Subject, content);
                        //email.Send("ƴ�����߽��������һ�");
                    }
                    else
                    {
                        //Զ�̵���
                        Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                        wb.GetEmail(Email, Subject, content);
                    }
                    Pbzx.Common.ErrorLog.WriteLogMeng("�����һ��ʼ�����", "�û���" + Name + " �ʼ����ͳɹ�", true, true);
                }
                catch (Exception ex)
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("�����һ��ʼ�����", ex.ToString(), true, true);

                }
                // SendMsg(content, Email);                
                this.email2.Visible = false;
                this.email3.Visible = true;

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("������������ַ����,����������."));
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("���������𰸴��ڴ���,����������."));
            }
        }

        protected void imbtEmail2_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/"));
        }
    }
}
