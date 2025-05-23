//====================================================================
//      Copyright(C) 2008-2009 meng
//      All rights reserved
//      
//      filename :ClassLibrary.Helper.EmailHelper_2
//      description:
//
//      created by mengxianying at 09/18/2009 12:45:22
//=====================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;



namespace Pbzx.Common
{
    public class EmailHelper
    {
        private SmtpClient  smtpClient;

        public EmailHelper(SmtpServer smtpServer)
        {

            SmtpClient smtp = new SmtpClient(smtpServer.ServerAddress,smtpServer.Port);
            smtp.Credentials = new NetworkCredential(smtpServer.UserName, smtpServer.UserPwd);
            smtp.EnableSsl = smtpServer.EnableSsl;
            smtpClient = smtp;
        }

        public void SendEmail(EmailMsg emailMsg)
        {
            MailMessage mailMsg = new MailMessage();

            //�ʼ���ַ
            mailMsg.From = new MailAddress(emailMsg.FromEmail, emailMsg.FromName);
            mailMsg.To.Add(new MailAddress(emailMsg.ToEmail, emailMsg.ToName));

            //�ʼ�ʵ��
            mailMsg.Subject = emailMsg.Subject;
            mailMsg.Body = emailMsg.Body;
            mailMsg.BodyEncoding = emailMsg.BodyEncoding;
            mailMsg.IsBodyHtml = emailMsg.IsBodyHtml;

            smtpClient.Send(mailMsg);
        }

        /// <summary>
        /// ��ȡĬ�ϵ�Smtp���������ã���xml/Pinble.config�ļ������ã�
        /// </summary>
        public  static SmtpServer GetDefaultSmtpServer()
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
