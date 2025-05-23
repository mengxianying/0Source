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
                Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ��쳣", "�ʼ������쳣��Ϣ��" + ex.Message + "\r\n��ջ��Ϣ��" + ex.StackTrace+"\r\n",true,true);
                throw ex;
            }
        }
    }
}
