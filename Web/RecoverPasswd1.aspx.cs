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
using System.Text;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Xml;

namespace Pbzx.Web
{
    public partial class RecoverPasswd1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    count = xml_root.SelectSingleNode("@count").Value;;
                }
                lab_num.Text = "<font color='blue'>【您可以进行 " + count +" 次取回密码的操作】</font>";
                LoginSort loginS = new LoginSort();
                if (loginS["manager_user"])
                {
                    this.txtUserName.Text = Method.Get_UserName;
                }
            }

            try
            {

                if (XMLMessage())
                {
                    return;
                }
            }
            catch
            {
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //try
            //{
            if (this.txtUserName.Text.Trim() == "" || this.txtUserName.Text.Trim().Length == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("用户名为空！"));
                return;
            }
                        XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            XmlNode hahaTime = root.SelectNodes("pz")[0];

            string hours = hahaTime.SelectSingleNode("@Hours").Value;
            string proxyIP = null;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("proxy")[0];
               
                //得到他的ID
                proxyIP = haha.SelectSingleNode("@proxyIP").Value;
            }
            if (proxyIP != null)
            {
                if (proxyIP == "1")
                { 
                    //判断是否使用代理IP
                    if (Input.GetViaIP() != "")
                    {
                        Method.record_user_log(this.txtUserName.Text.Trim(), Input.GetViaIP(), "代理IP取回密码", "密码相关");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("不支持代理IP取回密码！"));
                        return;
                    }
                }
                
            }
            if (XMLMessage())
            {
                return;
            }
            //if (!limitNum())
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("取回密码次数太多，请过" + hours + "小时再执行操作！"));
            //    return;
            //}
            string Name = Input.FilterAll(this.txtUserName.Text.Trim());
            object objUclass = DbHelperSQLBBS.GetSingle("select top 1 UserClass from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
            string strClass = "";
            if (objUclass != null)
            {
                strClass = objUclass.ToString();
                if (strClass == "管理员" || strClass == "超级版主" || strClass == "版主" || strClass == "聊管")
                {
                    Session["CheckCode1"] = "false";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "取回论坛密码-发生错误<br/>此用户身份是管理员或者是版主，只能通过联系管理员获得密码。 ", 400, "1", "history.go(-1)", "", false, false));
                    return;
                }
                else
                {
                    Session["CheckCode1"] = "true";
                    Server.Transfer("RecoverPasswd2.aspx?name=" + Input.Encrypt(Name.ToString()));
                }
            }
            else
            {
                Session["CheckCode1"] = "false";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("用户名不存在或者被锁定."));
            }
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "系统繁忙！ ", 400, "1", "history.go(-1)", "", false, false));
            //    return;
            //}
        }
        /// <summary>
        /// 循环判断
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool NewMethod(string s_temp, string sfs, string msg, object objuser, string Name)
        {
            sfs = sfs.Replace("|\r\n", "|");
            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        //   Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "抱歉！没有提供此服务！！ ", 400, "1", "location='http://www.pinble.com'", "http://www.pinble.com", false, false));
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('抱歉！没有提供此服务！');location='http://www.pinble.com';</script>");
                        if (objuser != null)
                        {
                            Method.record_user_log(Name.ToString(), Name.ToString(), "已屏蔽" + msg + "找回", "密码相关");
                        }
                        else
                        {
                            Method.record_user_log("游客", "", "已屏蔽" + msg + "找回", "密码相关");
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        public bool XMLMessage()
        {
            //try
            //{

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

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //给它不可能的地址
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
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
                //判断屏蔽的IP 192.168.1.123
                //如本机IP：127.
                //禁止IP 127.0.0.2 本机就要通过验证
                //但设置成这样呢！127.0.0. 这样要求屏蔽所有的127.0.0.开头的IP
                string Name = Input.FilterAll(this.txtUserName.Text.Trim());
                object objUclass = null;
                if (Name.Length > 0)
                {
                    objUclass = DbHelperSQLBBS.GetSingle("select top 1 UserClass from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                }
                //if (NewMethod(ip, ips, "IP", objUclass, Name))
                //{
                //    return true;
                //}
                //判断省份
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address, "省份", objUclass, Name))
                {
                    return true;
                }

                //找出他的第一次找回密码时间
                object objtime = DbHelperSQLBBS.GetSingle("select top 1 GetPSTime from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                if (objtime != null)
                {
                    int number = -1;
                    //转换第一次时间
                    DateTime datetimeZH = Convert.ToDateTime(objtime);
                    //得到当前时间
                    DateTime datetimeXZ = DateTime.Now;

                    //得到时间间隔
                    TimeSpan da = datetimeZH.AddHours(Convert.ToUInt32(hours)).Subtract(datetimeXZ);

                    if (da.Days <= 0)
                    {
                        if (da.Hours < 0)
                        {
                            number = 0;
                        }
                        else if (da.Hours == 0)
                        {
                            if (da.Minutes <= 0)
                            {
                                number = 0;
                            }
                        }
                    }
                    else
                    {
                        number = 1;
                    }
                    //已经超出限定时间,每天找回密码次数清0
                    if (number == 0)
                    {
                        DbHelperSQLBBS.ExecuteSql("update Dv_User set GetPSCount=0 where UserName='" + Name + "'");
                    }
                }
                else
                {
                    DbHelperSQLBBS.ExecuteSql("update Dv_User set GetPSCount=0 where UserName='" + Name + "'");
                }

                //找出他N小时内找回密码的次数
                object objcount = DbHelperSQLBBS.GetSingle("select top 1 GetPSCount from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                if (objcount != null)
                {
                    //判断他找回密码的次数
                    if (Convert.ToInt32(objcount) >= Convert.ToUInt32(count))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "取回论坛密码-找回次数频繁<br/>请" + hours + "小时之后再申请找回！。 ", 400, "1", "history.go(-1)", "", false, false));
                        return true;
                    }
                }
            }
            return false;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //return true;
        }
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
        /// 查看限定次数
        /// </summary>
        /// <returns></returns>
        private bool limitNum()
        { 
            string count="";
            string hours="";
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
                hours = xml_root.SelectSingleNode("@Hours").Value;
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
                DataSet dsN = DbHelperSQL.Query("select * from PBnet_retrieveinfo where Rip="+"'"+ ip +"'");
                if (dsN != null && dsN.Tables[0].Rows.Count > 0)
                {
                    
                    //不为空
                    if (dsN.Tables[0].Rows.Count >= Convert.ToInt32(count) && count!="")
                    {

                        DataSet dst = DbHelperSQL.Query("select Max(RTime) from PBnet_retrieveinfo where Rip=" + "'" + ip + "'");
                        if (hours != "")
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
                            if (hourtime >= Convert.ToInt32(hours))
                            {
                                //删除过期数据
                                if (DbHelperSQL.ExecuteSql("delete from PBnet_retrieveinfo where Rip=" + "'" + ip + "'") > 0)
                                {
                                    //添加到数据库
                                    if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + txtUserName.Text.ToString() + "','" + ip + "','" + DateTime.Now + "')") > 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                if (Input.GetViaIP() != "")
                                {
                                    Method.record_user_log(txtUserName.Text.ToString(), "IP：" + ip, "找回密码频繁", "密码相关");
                                }
                                else
                                {
                                    //记录日志
                                    Method.record_user_log(txtUserName.Text.ToString(), "", "找回密码频繁", "密码相关");
                                }
                                return false;
                            }
                        }

                    }
                    else
                    { 
                        //不够限制次数
                        //添加到数据库
                        if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + txtUserName.Text.ToString() + "','" + ip + "','" + DateTime.Now + "')") > 0)
                        {
                            return true;
                        }
                    }

                }
                else
                { 
                    //没有数据
                    //添加到数据库
                    if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + txtUserName.Text.ToString() + "','" + ip + "','" + DateTime.Now + "')") > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
