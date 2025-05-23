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
using System.Xml;
using System.Net.Mail;
using System.Text;
using System.Net;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace Pbzx.Web
{
    public partial class RecoverPasswd3 : System.Web.UI.Page
    {
        public static string _HorsTime = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                if (Session["CheckCode1"] != null && Session["CheckCode1"].ToString() == "true")
                {
                }
                else
                {
                    Response.Redirect("~/PageNoFound.htm");
                }

                if (Request["Type"] == "email")
                {
                    //Զ���ʼ����Ϳ���
                    string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                    if (jmailString == null || jmailString != "true")
                    {
                        Response.Write("<script>alert('��Ǹ�������һ���������ά���У��޷�ͨ�������һ����룡');history.go(-1);</script>");
                        return;
                    }

                    object objQuestion = DbHelperSQLBBS.GetSingle(" select top 1 UserEmail from Dv_User where UserName='" + Input.Decrypt(Input.FilterAll(Request["name"])) + "' and UserEmail IS NOT NULL and len(UserEmail)>0   ");
                    if (objQuestion == null)
                    {
                        Response.Write("<script>alert('��Ǹ����û������Email���޷�ͨ�������һ����룡');history.go(-1);</script>");
                        return;
                    }

                    this.ask.Visible = false;
                    this.email.Visible = true;
                }
                else if (Request["Type"] == "ask")
                {
                    object objQuestion = DbHelperSQLBBS.GetSingle(" select top 1 UserQuesion from Dv_User where UserName='" + Input.Decrypt(Input.FilterAll(Request["name"])) + "' and UserQuesion IS NOT NULL and len(UserQuesion)>0 and UserAnswer IS NOT NULL and len(UserAnswer)>0  ");
                    if (objQuestion == null)
                    {
                        Response.Write("<script>alert('��Ǹ����û���������뱣�����⣬�����ܱ���Ϊ�գ��޷�ͨ�����뱣�������һ����룡');history.go(-1);</script>");
                        return;
                    }
                    this.lblQuestion.Text = objQuestion.ToString();
                    this.ask.Visible = true;
                    this.email.Visible = false;
                }
                else
                {
                    this.ask.Visible = false;
                    this.email.Visible = false;
                }

                //��ѯ�û���Email��ַ
                string Name = Input.Decrypt(Input.FilterAll(Request["name"]));
                DataSet ds_name = DbHelperSQLBBS.Query("select UserEmail from Dv_User where UserName="+"'"+ Name +"'");
                if (ds_name != null && ds_name.Tables[0].Rows.Count > 0)
                {
                    if (ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].Length < 2)
                    {
                        lab_Email.Text = "ϵͳ��ʾ�������ܱ�����Ϊ <font color='blue'>" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].ToString() + "****@" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[1].ToString() + "</font>";
                    }
                    else
                    {
                        lab_Email.Text = "ϵͳ��ʾ�������ܱ�����Ϊ <font color='blue'>" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].Substring(0, ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].Length / 2).ToString() + "****@" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[1].ToString() + "</font>";
                    }
                }
                else
                {
                    lab_Email.Text = "��û�������ܱ�����";
                }
            }
        }

        protected void inbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            //�����뱣������ȡ��

            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode xml_root = root.SelectNodes("pz")[0];
                _HorsTime = xml_root.SelectSingleNode("@Hours").Value;
            }
            try
            {
                string Name = Input.Decrypt(Input.FilterAll(Request["name"]));

                //if (!limitNum())
                //{
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("ȡ���������̫�࣬���" + _HorsTime + "Сʱ��ִ�в�����"));
                //    return;
                //}
                if (PDXML(Name))
                {
                    return;
                }

                UpdateCount(Name);
                string Email = this.txtEmail.Text.Trim();
                this.lblEmails.Text = this.txtEmail.Text.Trim();
                string Subject = "ƴ�����߲���ͨ��������һأ�ϵͳ�Զ����ͣ�����ظ���";

                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select count(UserName) from Dv_User ");
                strSql.Append(" where  UserName=@UserName and UserEmail=@UserEmail  ");
                SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,50)};
                parameters[0].Value = Name;
                parameters[1].Value = Email;
                Pbzx.Model.PBnet_Charge model = new Pbzx.Model.PBnet_Charge();
                int countDvUser = Convert.ToInt32(DbHelperSQLBBS.GetSingle(strSql.ToString(), parameters));

                if (countDvUser > 0)
                {
                    string strPwd = Method.CreateVerifyCode(8);

                    int result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserPassword='" + Input.MD5(strPwd) + "' where UserName='" + Name + "'");
                    DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(strPwd) + "' where UserName='" + Name + "' ");
                    Method.record_user_log(Name, "Email��" + Email + "�һ�����", "�����һسɹ�", "�������");
                    Session["CheckCode1"] = null;
                    //if (result > 0)
                    //{
                    //}
                    //else
                    //{
                    //    Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("����������."));
                    //}
                    string content = "���������룺" + strPwd + "";
                    content += "<br />";
                    content += "����<a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "login.aspx'>����˴�</a>��¼�󣬵��û��������������������룬��������������ֱ�������ǿͷ���ϵ!";
                    try
                    {
                        //Զ���ʼ����Ϳ���
                        string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                        if (jmailString == null || jmailString != "true")
                        {
                            Response.Write("<script>alert('��Ǹ�������һ���������ά���У��޷�ͨ�������һ����룡');history.go(-1);</script>");
                            return;
                            //Email email = new Email(Email, Subject, content);
                            //email.Send("ƴ�����߲���ͨ���");
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
                    Method.record_user_log(Name, "Email��" + Email + "������֤δͨ����", "�����һ�ʧ��", "�������");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("������������ַ����,����������."));
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "ϵͳ��æ���� ", 400, "1", "location='/';", "", false, false));
                return;
            }
        }

        private void UpdateCount(string Name)
        {

            DbHelperSQLBBS.ExecuteSql("update Dv_User set GetPSCount=GetPSCount+1,GetPSTime='" + DateTime.Now.ToString() + "' where UserName='" + Name + "'");
        }

        //protected string SendMsg(string strContent,string address)
        //{
        //    string text = "--";
        //    try
        //    {
        //        //string host = "smtp.qq.com";
        //        //string strport = "25";
        //        //int port = int.Parse(strport);
        //        //string userName = "296386021@qq.com";

        //        XmlDocument xmlDoc = new XmlDocument();
        //        string path = Server.MapPath("~/Web.Config");
        //        xmlDoc.Load(path);
        //        //  xmlDoc.selectNodes("/configuration/system.web/sessionState");
        //        XmlNode xn = xmlDoc.SelectSingleNode("/configuration/system.net/mailSettings/smtp/network");
        //        XmlElement xe = (XmlElement)xn;
        //        string host = xe.Attributes["host"].Value;
        //        string strport = xe.Attributes["port"].Value;
        //        int port = int.Parse(strport);
        //        string userName = xe.Attributes["userName"].Value;
        //        string password = xe.Attributes["password"].Value;


        //        MailMessage m_message = new MailMessage();

        //        m_message.From = new MailAddress(userName);
        //        m_message.To.Add(new MailAddress(address));
        //        m_message.Subject = "ƴ�����������һ�";
        //        StringBuilder sb = new StringBuilder("");
        //        sb.Append(strContent);
        //        m_message.IsBodyHtml = true;
        //        m_message.SubjectEncoding = Encoding.GetEncoding("gb2312");//Encoding.GetEncoding("gb2312");
        //        m_message.BodyEncoding = Encoding.GetEncoding("gb2312");

        //        m_message.Body = sb.ToString();
        //        SmtpClient client = new SmtpClient(host, port);

        //        client.Credentials = new NetworkCredential(userName, password);
        //        client.EnableSsl = false;
        //        client.Send(m_message);
        //        text = "<span style='color:green; font-size:15px; font-weight:bolder;'>��Ϣ�Ѿ��ύ���������䣬������Ա�ᾡ��������ϵ��^_^</span>";
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "<span style='color:Red; font-size:15px; font-weight:bolder;'>�Բ�����Ϣ�ύ���������������ǿͷ���ϵ��</span>" + ex.ToString();
        //    }
        //    return text;
        //}

        protected void imbtAsk_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string Name = Input.Decrypt(Input.FilterAll(Request["name"]));

                if (!limitNum())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("ȡ���������̫�࣬���" + _HorsTime + "Сʱ��ִ�в�����"));
                    return;
                }
                if (PDXML(Name))
                {
                    return;
                }

                UpdateCount(Name);
                string Question = this.lblQuestion.Text;
                string Answer = Input.FilterAll(this.txtAnswer.Text);
                string strAnswer = DbHelperSQLBBS.GetSingle(" select top 1 UserAnswer from Dv_User where UserName='" + Name + "' ").ToString();
                if (Input.MD5(Answer) == strAnswer)
                {
                    Method.record_user_log(Name, "���⣺" + Question + " �𰸣�" + Answer, "�������ȷ", "�������");
                    Session["CheckCode3"] = "true";
                    Server.Transfer("OnMakePwd.aspx?name=" + Request["name"]);
                }
                else
                {
                    Method.record_user_log(Name, "���⣺" + Question + " �𰸣�" + Answer, "�����һ�ʧ��", "�������");
                    Session["CheckCode3"] = "false";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("���������𰸴��ڴ���,����������."));
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "ϵͳ��æ���� ", 400, "1", "location='/';", "", false, false));
                return;
            }
        }

        private bool PDXML(string Name)
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("pz")[0];
                //�õ�����ID
                string count = haha.SelectSingleNode("@count").Value;
                string hours = haha.SelectSingleNode("@Hours").Value;


                //�ҳ���24Сʱ���һ�����Ĵ���
                object objcount = DbHelperSQLBBS.GetSingle("select top 1 GetPSCount from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                if (objcount != null)
                {
                    if (Convert.ToInt32(objcount) >= Convert.ToUInt32(count))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "ȡ����̳����-�һش���Ƶ��<br/>��" + hours + "Сʱ֮���������һأ��� ", 400, "1", "location='/';", "", false, false));
                        Method.record_user_log(Name, Name, "�һش���Ƶ��", "�������");
                        return true;
                    }
                }
            }

            return false;
        }

        protected void imbtEmail2_Click(object sender, ImageClickEventArgs e)
        {
            // this.Response.Write("<script language=javascript>window.close();</script>"); 
            ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/"));

        }
        #region ����
        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString() + ","
                                + ts.Hours.ToString() + ","
                                + ts.Minutes.ToString() + ","
                                + ts.Seconds.ToString() + ",";
            }
            catch
            {

            }
            return dateDiff;

        }
        /// <summary>
        /// ȡ�������޶�
        /// </summary>
        /// <returns></returns>
        private bool limitNum()
        {
            string Name = Input.Decrypt(Input.FilterAll(Request["name"]));
            string count = "";
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode xml_root = root.SelectNodes("pz")[0];
                //�õ�����ID
                count = xml_root.SelectSingleNode("@count").Value;
                _HorsTime = xml_root.SelectSingleNode("@Hours").Value;
            }
            //��ȡIP��ַ
            //�ж�IP
            string ip = "";
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // �������� using proxy 
            {
                // �õ���ʵ�Ŀͻ��˵�ַ
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
            }
            else//���û��ʹ�ô�����������ߵò����ͻ��˵�ip  not using proxy or can't get the Client IP 
            {
                //�õ�����˵ĵ�ַ 
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }
            if (ip != "")
            {
                DataSet dsN = DbHelperSQL.Query("select * from PBnet_retrieveinfo where Rip=" + "'" + ip + "'");
                if (dsN != null && dsN.Tables[0].Rows.Count > 0)
                {

                    //��Ϊ��
                    if (dsN.Tables[0].Rows.Count >= Convert.ToInt32(count) && count != "")
                    {

                        DataSet dst = DbHelperSQL.Query("select Max(RTime) from PBnet_retrieveinfo where Rip=" + "'" + ip + "'");
                        if (_HorsTime != "")
                        {
                            string diffTime = DateDiff(DateTime.Now, Convert.ToDateTime(dst.Tables[0].Rows[0][0]));
                            int hourDay = 0;
                            int hourtime = 0;
                            if (Convert.ToInt32(diffTime.Split(',')[0]) > 0)
                            {
                                hourDay = Convert.ToInt32(diffTime.Split(',')[0]) * 24;
                            }
                            if (Convert.ToInt32(diffTime.Split(',')[1]) > 0)
                            {
                                hourtime = Convert.ToInt32(diffTime.Split(',')[1]) + hourDay;
                            }
                            else
                            {
                                hourtime = hourDay;
                            }
                            if (hourtime >= Convert.ToInt32(_HorsTime))
                            {
                                //ɾ����������
                                if (DbHelperSQL.ExecuteSql("delete from PBnet_retrieveinfo where Rip=" + "'" + ip + "'") > 0)
                                {
                                    //��ӵ����ݿ�
                                    if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + Name + "','" + ip + "','" + DateTime.Now + "')") > 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                if (Input.GetViaIP() != "")
                                {
                                    Method.record_user_log(Name, "IP��" + ip, "�һ�����Ƶ��", "�������");
                                }
                                else
                                {
                                    //��¼��־
                                    Method.record_user_log(Name, "", "�һ�����Ƶ��", "�������");
                                }
                                return false;
                            }
                        }

                    }
                    else
                    {
                        //�������ƴ���
                        //��ӵ����ݿ�
                        if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + Name + "','" + ip + "','" + DateTime.Now + "')") > 0)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    //û������
                    //��ӵ����ݿ�
                    if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + Name + "','" + ip + "','" + DateTime.Now + "')") > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
