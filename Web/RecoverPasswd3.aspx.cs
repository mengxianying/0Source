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
                    //远程邮件发送开关
                    string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                    if (jmailString == null || jmailString != "true")
                    {
                        Response.Write("<script>alert('抱歉，邮箱找回密码正在维护中，无法通过邮箱找回密码！');history.go(-1);</script>");
                        return;
                    }

                    object objQuestion = DbHelperSQLBBS.GetSingle(" select top 1 UserEmail from Dv_User where UserName='" + Input.Decrypt(Input.FilterAll(Request["name"])) + "' and UserEmail IS NOT NULL and len(UserEmail)>0   ");
                    if (objQuestion == null)
                    {
                        Response.Write("<script>alert('抱歉，您没有设置Email，无法通过邮箱找回密码！');history.go(-1);</script>");
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
                        Response.Write("<script>alert('抱歉，您没有设置密码保护问题，或者密保答案为空，无法通过密码保护问题找回密码！');history.go(-1);</script>");
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

                //查询用户的Email地址
                string Name = Input.Decrypt(Input.FilterAll(Request["name"]));
                DataSet ds_name = DbHelperSQLBBS.Query("select UserEmail from Dv_User where UserName="+"'"+ Name +"'");
                if (ds_name != null && ds_name.Tables[0].Rows.Count > 0)
                {
                    if (ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].Length < 2)
                    {
                        lab_Email.Text = "系统提示：您的密保邮箱为 <font color='blue'>" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].ToString() + "****@" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[1].ToString() + "</font>";
                    }
                    else
                    {
                        lab_Email.Text = "系统提示：您的密保邮箱为 <font color='blue'>" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].Substring(0, ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[0].Length / 2).ToString() + "****@" + ds_name.Tables[0].Rows[0]["UserEmail"].ToString().Split('@')[1].ToString() + "</font>";
                    }
                }
                else
                {
                    lab_Email.Text = "您没有设置密保邮箱";
                }
            }
        }

        protected void inbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            //用密码保护邮箱取回

            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
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
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("取回密码次数太多，请过" + _HorsTime + "小时再执行操作！"));
                //    return;
                //}
                if (PDXML(Name))
                {
                    return;
                }

                UpdateCount(Name);
                string Email = this.txtEmail.Text.Trim();
                this.lblEmails.Text = this.txtEmail.Text.Trim();
                string Subject = "拼搏在线彩神通软件密码找回（系统自动发送，请勿回复）";

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
                    Method.record_user_log(Name, "Email：" + Email + "找回密码", "密码找回成功", "密码相关");
                    Session["CheckCode1"] = null;
                    //if (result > 0)
                    //{
                    //}
                    //else
                    //{
                    //    Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("请重新输入."));
                    //}
                    string content = "您的新密码：" + strPwd + "";
                    content += "<br />";
                    content += "请您<a href='" + Pbzx.Common.WebInit.webBaseConfig.WebUrl + "login.aspx'>点击此处</a>登录后，到用户中心重新设置您的密码，还有其它问题请直接与我们客服联系!";
                    try
                    {
                        //远程邮件发送开关
                        string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                        if (jmailString == null || jmailString != "true")
                        {
                            Response.Write("<script>alert('抱歉，邮箱找回密码正在维护中，无法通过邮箱找回密码！');history.go(-1);</script>");
                            return;
                            //Email email = new Email(Email, Subject, content);
                            //email.Send("拼搏在线彩神通软件");
                        }
                        else
                        {
                            //远程调用
                            Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                            wb.GetEmail(Email, Subject, content);
                        }
                        Pbzx.Common.ErrorLog.WriteLogMeng("密码找回邮件发送", "用户：" + Name + " 邮件发送成功", true, true);
                    }
                    catch (Exception ex)
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("密码找回邮件发送", ex.ToString(), true, true);

                    }
                    // SendMsg(content, Email);                
                    this.email2.Visible = false;
                    this.email3.Visible = true;
                }
                else
                {
                    Method.record_user_log(Name, "Email：" + Email + "邮箱验证未通过。", "密码找回失败", "密码相关");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("您输入的邮箱地址不对,请重新输入."));
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "系统繁忙！。 ", 400, "1", "location='/';", "", false, false));
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
        //        m_message.Subject = "拼搏在线密码找回";
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
        //        text = "<span style='color:green; font-size:15px; font-weight:bolder;'>信息已经提交到我们邮箱，服务人员会尽快与您联系！^_^</span>";
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "<span style='color:Red; font-size:15px; font-weight:bolder;'>对不起！信息提交发生错误！请与我们客服联系！</span>" + ex.ToString();
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
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("取回密码次数太多，请过" + _HorsTime + "小时再执行操作！"));
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
                    Method.record_user_log(Name, "问题：" + Question + " 答案：" + Answer, "密码答案正确", "密码相关");
                    Session["CheckCode3"] = "true";
                    Server.Transfer("OnMakePwd.aspx?name=" + Request["name"]);
                }
                else
                {
                    Method.record_user_log(Name, "问题：" + Question + " 答案：" + Answer, "密码找回失败", "密码相关");
                    Session["CheckCode3"] = "false";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("您的问题或答案存在错误,请重新输入."));
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "系统繁忙！。 ", 400, "1", "location='/';", "", false, false));
                return;
            }
        }

        private bool PDXML(string Name)
        {
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("pz")[0];
                //得到他的ID
                string count = haha.SelectSingleNode("@count").Value;
                string hours = haha.SelectSingleNode("@Hours").Value;


                //找出他24小时内找回密码的次数
                object objcount = DbHelperSQLBBS.GetSingle("select top 1 GetPSCount from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                if (objcount != null)
                {
                    if (Convert.ToInt32(objcount) >= Convert.ToUInt32(count))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "取回论坛密码-找回次数频繁<br/>请" + hours + "小时之后再申请找回！。 ", 400, "1", "location='/';", "", false, false));
                        Method.record_user_log(Name, Name, "找回次数频繁", "密码相关");
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
        #region 方法
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
        /// 取回密码限定
        /// </summary>
        /// <returns></returns>
        private bool limitNum()
        {
            string Name = Input.Decrypt(Input.FilterAll(Request["name"]));
            string count = "";
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode xml_root = root.SelectNodes("pz")[0];
                //得到他的ID
                count = xml_root.SelectSingleNode("@count").Value;
                _HorsTime = xml_root.SelectSingleNode("@Hours").Value;
            }
            //获取IP地址
            //判断IP
            string ip = "";
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
            {
                // 得到真实的客户端地址
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
            }
            else//如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP 
            {
                //得到服务端的地址 
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }
            if (ip != "")
            {
                DataSet dsN = DbHelperSQL.Query("select * from PBnet_retrieveinfo where Rip=" + "'" + ip + "'");
                if (dsN != null && dsN.Tables[0].Rows.Count > 0)
                {

                    //不为空
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
                                //删除过期数据
                                if (DbHelperSQL.ExecuteSql("delete from PBnet_retrieveinfo where Rip=" + "'" + ip + "'") > 0)
                                {
                                    //添加到数据库
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
                                    Method.record_user_log(Name, "IP：" + ip, "找回密码频繁", "密码相关");
                                }
                                else
                                {
                                    //记录日志
                                    Method.record_user_log(Name, "", "找回密码频繁", "密码相关");
                                }
                                return false;
                            }
                        }

                    }
                    else
                    {
                        //不够限制次数
                        //添加到数据库
                        if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + Name + "','" + ip + "','" + DateTime.Now + "')") > 0)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    //没有数据
                    //添加到数据库
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
