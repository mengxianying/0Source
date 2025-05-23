using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jmail;

namespace JMailText
{
    public class JmailHelper
    {
        /**/
        /// <summary>
        /// 利用Jmail发送邮件
        /// </summary>
        public static bool SendMailByJmail(EmailMsg emailMsg)
        {
            /**/
            ///建立发邮件类
            jmail.MessageClass oJmailMessage = new jmail.MessageClass();

            /**/
            /// 字符集
            oJmailMessage.Charset = "GB2312";

            /**/
            ///附件的编码格式
            oJmailMessage.Encoding = "BASE64";
            oJmailMessage.ContentType = "text/html";

            /**/
            ///是否将信头编码成iso-8859-1字符集
            oJmailMessage.ISOEncodeHeaders = false;

            /**/
            /// 优先级
            oJmailMessage.Priority = Convert.ToByte(1);

            /**/
            ///发送人邮件地址
            oJmailMessage.From = emailMsg.FromEmail;

            /**/
            ///发送人姓名
            oJmailMessage.FromName = emailMsg.FromName;

            /**/
            /// 邮件主题
            oJmailMessage.Subject = emailMsg.Subject;

            /**/
            ///身份验证的用户名
            oJmailMessage.MailServerUserName = UIConfig.SmtpUserName;

            /**/
            ///用户密码
            oJmailMessage.MailServerPassWord = UIConfig.SmtpUserPwd;

            /**/
            ///添加一个收件人，抄送人和密送人的添加和该方法是一样的，只是分别使用AddRecipientCC和RecipientBCC两个属性
            ///要是需要添加多个收件人，则重复下面的语句即可。添加多个抄送和密送人的方法一样
            // oJmailMessage.AddRecipient(txtReciver.Text.Trim(),"","");
            //if("" != upFile.PostedFile.FileName)
            //{
            //    string attpath = upFile.PostedFile.FileName;
            //    oJmailMessage.AddAttachment(@attpath,true,attpath.Substring(attpath.LastIndexOf(".")+1,3));//添加附件
            //}

            /**/
            ///邮件内容
            oJmailMessage.Body = emailMsg.Body;

            oJmailMessage.AddRecipient(emailMsg.ToEmail, "", "");
            bool result = false;
            try
            {
                result = oJmailMessage.Send(UIConfig.SmtpServerAddress, false);
            }
            catch (Exception ex)
            {
            //    Pbzx.Common.ErrorLog.WriteLogMeng("邮件异常1", "邮件发送异常1：" + ex.Message + "\r\n堆栈1：" + ex.StackTrace + "\r\n", true, true);
                throw ex;
            }
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}