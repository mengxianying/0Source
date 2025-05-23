using System;
using System.Collections.Generic;
using System.Text;
using jmail;

namespace Pbzx.Common
{
    public class JmailHelper
    {
        /**//// <summary>
        /// ����Jmail�����ʼ�
        /// </summary>
        public static bool SendMailByJmail(EmailMsg emailMsg)
        {
            /**////�������ʼ���
           jmail.MessageClass oJmailMessage = new jmail.MessageClass();
            
            /**//// �ַ���
            oJmailMessage.Charset = "GB2312";
            
            /**////�����ı����ʽ
            oJmailMessage.Encoding = "BASE64";
            oJmailMessage.ContentType = "text/html";

            /**////�Ƿ���ͷ�����iso-8859-1�ַ���
            oJmailMessage.ISOEncodeHeaders = false;

            /**//// ���ȼ�
            oJmailMessage.Priority = Convert.ToByte(1);
            
            /**////�������ʼ���ַ
            oJmailMessage.From = emailMsg.FromEmail;
            
            /**////����������
            oJmailMessage.FromName = emailMsg.FromName; 

            /**//// �ʼ�����
            oJmailMessage.Subject = emailMsg.Subject;

            /**////�����֤���û���
            oJmailMessage.MailServerUserName = UIConfig.SmtpUserName;

            /**////�û�����
            oJmailMessage.MailServerPassWord = UIConfig.SmtpUserPwd;

            /**////���һ���ռ��ˣ������˺������˵���Ӻ͸÷�����һ���ģ�ֻ�Ƿֱ�ʹ��AddRecipientCC��RecipientBCC��������
            ///Ҫ����Ҫ��Ӷ���ռ��ˣ����ظ��������伴�ɡ���Ӷ�����ͺ������˵ķ���һ��
           // oJmailMessage.AddRecipient(txtReciver.Text.Trim(),"","");
            //if("" != upFile.PostedFile.FileName)
            //{
            //    string attpath = upFile.PostedFile.FileName;
            //    oJmailMessage.AddAttachment(@attpath,true,attpath.Substring(attpath.LastIndexOf(".")+1,3));//��Ӹ���
            //}

            /**////�ʼ�����
            oJmailMessage.Body = emailMsg.Body;

            oJmailMessage.AddRecipient(emailMsg.ToEmail, "", "");
            bool result = false;
            try
            {
                 result = oJmailMessage.Send(UIConfig.SmtpServerAddress, false);
            }
            catch(Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("�ʼ��쳣1", "�ʼ������쳣1��" + ex.Message + "\r\n��ջ1��" + ex.StackTrace + "\r\n",true,true);
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
        ///// ����Jmail�����ʼ�
        ///// </summary>
        //private void ReciveByJmail()
        //{    
        //    /**////�������ʼ�����
        //    jmail.POP3Class popMail = new POP3Class();
            
        //   /**////�����ʼ���Ϣ�ӿ�
        //    jmail.Message mailMessage; 

        //    /**////�����������ӿ�
        //    jmail.Attachments atts;

        //    /**////���������ӿ�
        //    jmail.Attachment att;

        //    try
        //    {
        //        popMail.Connect(TxtPopUser.Text.Trim(),TxtPopPwd.Text.Trim(),TxtPopServer.Text.Trim(),Convert.ToInt32(TxtPopPort.Text.Trim()));
                
        //       /**////����յ��ʼ�
        //       if(0 < popMail.Count)                                                                          
        //        {    
        //           /**////����ȡ�����ʼ���������ȡ��ÿ���ʼ�
        //           for(int i=1;i <= popMail.Count;i++)                                                       
        //            {
        //               /**////ȡ��һ���ʼ���Ϣ
        //               mailMessage = popMail.Messages[i];                                                        

        //               /**////ȡ�ø��ʼ��ĸ�������
        //               atts = mailMessage.Attachments; 
                       
        //               /**////�����ʼ��ı��뷽ʽ                          
        //               mailMessage.Charset = "GB2312"; 
                       
        //                /**////�����ʼ��ĸ������뷽ʽ                         
        //                mailMessage.Encoding = "Base64"; 
                        
        //               /**////�Ƿ���ͷ�����iso-8859-1�ַ���                        
        //                mailMessage.ISOEncodeHeaders = false; 
                       
        //                /**////�ʼ������ȼ�                     
        //               txtpriority.Text = mailMessage.Priority.ToString(); 
                        
        //               /**////�ʼ��ķ����˵������ַ                      
        //                txtSendMail.Text = mailMessage.From; 
                       
        //               /**////�ʼ��ķ�����                     
        //                txtSender.Text = mailMessage.FromName; 
                        
        //              /**////�ʼ�����                   
        //               txtSubject.Text = mailMessage.Subject; 
                       
        //               /**////�ʼ�����                   
        //                txtBody.Text = mailMessage.Body; 
                        
        //               /**////�ʼ���С                        
        //              txtSize.Text = mailMessage.Size.ToString();                                                          
                        
        //               for(int j=0;j<atts.Count;j++)
        //               {
        //                   /**////ȡ�ø���
        //                   att = atts[j];  
                            
        //                   /**////��������                              
        //                   string attname = att.Name;                                                            
                           
        //                   /**////�ϴ���������
        //                   att.SaveToFile("e:\\attFile\\"+attname);                                             
                           
        //               }
                       
        //           }
        //            panMailInfo.Visible = true;
        //            att = null;
        //            atts = null;
        //        }
        //       else
        //        {
        //           Response.Write("û�����ʼ�!");
        //       }

        //        popMail.DeleteMessages();
        //       popMail.Disconnect();
        //        popMail = null;
        //    }
        //    catch
        //    {
        //        Response.Write("Warning!�����ʼ��������������Ƿ���ȷ��");
        //    }
        //   }

    }
}
