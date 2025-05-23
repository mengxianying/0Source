using System;
using System.Collections.Generic;
using System.Text;

namespace  Pbzx.Common
{
    public  class Email
    {
        private string toEmail;
        private string subject;
        private string body;

        public Email(string toEmail, string subject, string body)
        {
            this.toEmail = toEmail;
            this.subject = subject;
            this.body = body;
        }

        public void Send(string FromName)
        {
            try
            {
                SmtpServer smtpServer = EmailHelper.GetDefaultSmtpServer();
                EmailHelper emailHelper = new EmailHelper(smtpServer);
                JmailHelper help = new JmailHelper();
                EmailMsg emailMsg = new EmailMsg();

                emailMsg.FromEmail = smtpServer.FromEmail;
                emailMsg.FromName = smtpServer.FromName;
                emailMsg.ToEmail = toEmail;
                emailMsg.ToName = "";
                emailMsg.Subject = subject;
                emailMsg.Body = body;
                emailMsg.IsBodyHtml = true;
                emailMsg.BodyEncoding = Encoding.UTF8;
                JmailHelper.SendMailByJmail(emailMsg);
                //emailHelper.SendEmail(emailMsg);
            }
            catch(Exception ex)
            {                
                Pbzx.Common.ErrorLog.WriteLogMeng("邮件异常", "邮件发送异常消息：" + ex.Message + "\r\n堆栈信息：" + ex.StackTrace+"\r\n",true,true);
                throw ex;
            }
        }
    }
}
