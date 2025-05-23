using System;
using System.Collections.Generic;
using System.Text;
using jmail;

namespace Pbzx.Common
{
    public class JmailHelper
    {
        /**//// <summary>
        /// 利用Jmail发送邮件
        /// </summary>
        public static bool SendMailByJmail(EmailMsg emailMsg)
        {
            /**////建立发邮件类
           jmail.MessageClass oJmailMessage = new jmail.MessageClass();
            
            /**//// 字符集
            oJmailMessage.Charset = "GB2312";
            
            /**////附件的编码格式
            oJmailMessage.Encoding = "BASE64";
            oJmailMessage.ContentType = "text/html";

            /**////是否将信头编码成iso-8859-1字符集
            oJmailMessage.ISOEncodeHeaders = false;

            /**//// 优先级
            oJmailMessage.Priority = Convert.ToByte(1);
            
            /**////发送人邮件地址
            oJmailMessage.From = emailMsg.FromEmail;
            
            /**////发送人姓名
            oJmailMessage.FromName = emailMsg.FromName; 

            /**//// 邮件主题
            oJmailMessage.Subject = emailMsg.Subject;

            /**////身份验证的用户名
            oJmailMessage.MailServerUserName = UIConfig.SmtpUserName;

            /**////用户密码
            oJmailMessage.MailServerPassWord = UIConfig.SmtpUserPwd;

            /**////添加一个收件人，抄送人和密送人的添加和该方法是一样的，只是分别使用AddRecipientCC和RecipientBCC两个属性
            ///要是需要添加多个收件人，则重复下面的语句即可。添加多个抄送和密送人的方法一样
           // oJmailMessage.AddRecipient(txtReciver.Text.Trim(),"","");
            //if("" != upFile.PostedFile.FileName)
            //{
            //    string attpath = upFile.PostedFile.FileName;
            //    oJmailMessage.AddAttachment(@attpath,true,attpath.Substring(attpath.LastIndexOf(".")+1,3));//添加附件
            //}

            /**////邮件内容
            oJmailMessage.Body = emailMsg.Body;

            oJmailMessage.AddRecipient(emailMsg.ToEmail, "", "");
            bool result = false;
            try
            {
                 result = oJmailMessage.Send(UIConfig.SmtpServerAddress, false);
            }
            catch(Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("邮件异常1", "邮件发送异常1：" + ex.Message + "\r\n堆栈1：" + ex.StackTrace + "\r\n",true,true);
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

        ///**//// <summary>
        ///// 利用Jmail接收邮件
        ///// </summary>
        //private void ReciveByJmail()
        //{    
        //    /**////建立收邮件对象
        //    jmail.POP3Class popMail = new POP3Class();
            
        //   /**////建立邮件信息接口
        //    jmail.Message mailMessage; 

        //    /**////建立附件集接口
        //    jmail.Attachments atts;

        //    /**////建立附件接口
        //    jmail.Attachment att;

        //    try
        //    {
        //        popMail.Connect(TxtPopUser.Text.Trim(),TxtPopPwd.Text.Trim(),TxtPopServer.Text.Trim(),Convert.ToInt32(TxtPopPort.Text.Trim()));
                
        //       /**////如果收到邮件
        //       if(0 < popMail.Count)                                                                          
        //        {    
        //           /**////根据取到的邮件数量依次取得每封邮件
        //           for(int i=1;i <= popMail.Count;i++)                                                       
        //            {
        //               /**////取得一条邮件信息
        //               mailMessage = popMail.Messages[i];                                                        

        //               /**////取得该邮件的附件集合
        //               atts = mailMessage.Attachments; 
                       
        //               /**////设置邮件的编码方式                          
        //               mailMessage.Charset = "GB2312"; 
                       
        //                /**////设置邮件的附件编码方式                         
        //                mailMessage.Encoding = "Base64"; 
                        
        //               /**////是否将信头编码成iso-8859-1字符集                        
        //                mailMessage.ISOEncodeHeaders = false; 
                       
        //                /**////邮件的优先级                     
        //               txtpriority.Text = mailMessage.Priority.ToString(); 
                        
        //               /**////邮件的发送人的信箱地址                      
        //                txtSendMail.Text = mailMessage.From; 
                       
        //               /**////邮件的发送人                     
        //                txtSender.Text = mailMessage.FromName; 
                        
        //              /**////邮件主题                   
        //               txtSubject.Text = mailMessage.Subject; 
                       
        //               /**////邮件内容                   
        //                txtBody.Text = mailMessage.Body; 
                        
        //               /**////邮件大小                        
        //              txtSize.Text = mailMessage.Size.ToString();                                                          
                        
        //               for(int j=0;j<atts.Count;j++)
        //               {
        //                   /**////取得附件
        //                   att = atts[j];  
                            
        //                   /**////附件名称                              
        //                   string attname = att.Name;                                                            
                           
        //                   /**////上传到服务器
        //                   att.SaveToFile("e:\\attFile\\"+attname);                                             
                           
        //               }
                       
        //           }
        //            panMailInfo.Visible = true;
        //            att = null;
        //            atts = null;
        //        }
        //       else
        //        {
        //           Response.Write("没有新邮件!");
        //       }

        //        popMail.DeleteMessages();
        //       popMail.Disconnect();
        //        popMail = null;
        //    }
        //    catch
        //    {
        //        Response.Write("Warning!请检查邮件服务器的设置是否正确！");
        //    }
        //   }

    }
}
