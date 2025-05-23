using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace JMailText
{
    public class Email
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
            catch (Exception ex)
            {
            
                throw ex;
            }
        }
    }
}