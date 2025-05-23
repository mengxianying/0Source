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
using System.Xml;
using System.Net.Mail;
using System.Text;
using System.Net;
//using System.Web.Mail;

namespace Pbzx.Web
{
    /// <summary>
    /// 邮件发送测试页面（独立）
    /// </summary>
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["content"]))
            {
                Response.Write(SendMsg(Request["content"]));
            }
        }

        protected string SendMsg(string strContent)
        {
            string text = "--";
            try
            {
                //string host = "smtp.qq.com";
                //string strport = "25";
                //int port = int.Parse(strport);
                //string userName = "296386021@qq.com";
                //string password = "ymx315193";

                XmlDocument xmlDoc = new XmlDocument();
                string path = Server.MapPath("~/Web.Config");
                xmlDoc.Load(path);
                //  xmlDoc.selectNodes("/configuration/system.web/sessionState");
                XmlNode xn = xmlDoc.SelectSingleNode("/configuration/system.net/mailSettings/smtp/network");
                XmlElement xe = (XmlElement)xn;
                string host = xe.Attributes["host"].Value;
                string strport = xe.Attributes["port"].Value;
                int port = int.Parse(strport);
                string userName = xe.Attributes["userName"].Value;
                string password = xe.Attributes["password"].Value;


                MailMessage m_message = new MailMessage();

                m_message.From = new MailAddress(userName);
                m_message.To.Add(new MailAddress("296386021@qq.com"));
                m_message.Subject = "拼搏在线密码找回";
                StringBuilder sb = new StringBuilder("");
                sb.Append(strContent);
                m_message.IsBodyHtml = true;
                m_message.SubjectEncoding = Encoding.GetEncoding("gb2312");//Encoding.GetEncoding("gb2312");
                m_message.BodyEncoding = Encoding.GetEncoding("gb2312");

                m_message.Body = sb.ToString();
                SmtpClient client = new SmtpClient(host, port);

                client.Credentials = new NetworkCredential(userName, password);
                client.EnableSsl = false;
                client.Send(m_message);
                text = "<span style='color:green; font-size:15px; font-weight:bolder;'>信息已经提交到我们邮箱，服务人员会尽快与您联系！^_^</span>";
            }
            catch (Exception ex)
            {
                text = "<span style='color:Red; font-size:15px; font-weight:bolder;'>对不起！信息提交发生错误！请与我们客服联系！</span>" + ex.ToString();
            }
            return text;
        }
    }
}
