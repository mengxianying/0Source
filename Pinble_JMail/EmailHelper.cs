using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace JMailText
{
    public class EmailHelper
    {
        private SmtpClient smtpClient;

        public EmailHelper(SmtpServer smtpServer)
        {

            SmtpClient smtp = new SmtpClient(smtpServer.ServerAddress, smtpServer.Port);
            smtp.Credentials = new NetworkCredential(smtpServer.UserName, smtpServer.UserPwd);
            smtp.EnableSsl = smtpServer.EnableSsl;
            smtpClient = smtp;
        }

        public void SendEmail(EmailMsg emailMsg)
        {
            MailMessage mailMsg = new MailMessage();

            //邮件地址
            mailMsg.From = new MailAddress(emailMsg.FromEmail, emailMsg.FromName);
            mailMsg.To.Add(new MailAddress(emailMsg.ToEmail, emailMsg.ToName));

            //邮件实体
            mailMsg.Subject = emailMsg.Subject;
            mailMsg.Body = emailMsg.Body;
            mailMsg.BodyEncoding = emailMsg.BodyEncoding;
            mailMsg.IsBodyHtml = emailMsg.IsBodyHtml;

            smtpClient.Send(mailMsg);
        }

        /// <summary>
        /// 获取默认的Smtp服务器配置（在xml/Pinble.config文件中设置）
        /// </summary>
        public static SmtpServer GetDefaultSmtpServer()
        {
            SmtpServer smtpServer = new SmtpServer();
            UIConfig cof = new UIConfig();
            smtpServer.EnableSsl = UIConfig.SmtpEnableSsl;
            smtpServer.FromEmail = UIConfig.SmtpFromEmail;
            smtpServer.FromName = UIConfig.SmtpFromName;
            smtpServer.Port = UIConfig.SmtpPort;
            smtpServer.ServerAddress = UIConfig.SmtpServerAddress;
            smtpServer.UserName = UIConfig.SmtpUserName;
            smtpServer.UserPwd = UIConfig.SmtpUserPwd;

            return smtpServer;
        }
    }
}