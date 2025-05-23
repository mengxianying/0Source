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
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {
                    XmlNode xml_root = root.SelectNodes("pz")[0];
                    //�õ�����ID
                    count = xml_root.SelectSingleNode("@count").Value;;
                }
                lab_num.Text = "<font color='blue'>�������Խ��� " + count +" ��ȡ������Ĳ�����</font>";
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("�û���Ϊ�գ�"));
                return;
            }
                        XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            XmlNode hahaTime = root.SelectNodes("pz")[0];

            string hours = hahaTime.SelectSingleNode("@Hours").Value;
            string proxyIP = null;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("proxy")[0];
               
                //�õ�����ID
                proxyIP = haha.SelectSingleNode("@proxyIP").Value;
            }
            if (proxyIP != null)
            {
                if (proxyIP == "1")
                { 
                    //�ж��Ƿ�ʹ�ô���IP
                    if (Input.GetViaIP() != "")
                    {
                        Method.record_user_log(this.txtUserName.Text.Trim(), Input.GetViaIP(), "����IPȡ������", "�������");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("��֧�ִ���IPȡ�����룡"));
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
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("ȡ���������̫�࣬���" + hours + "Сʱ��ִ�в�����"));
            //    return;
            //}
            string Name = Input.FilterAll(this.txtUserName.Text.Trim());
            object objUclass = DbHelperSQLBBS.GetSingle("select top 1 UserClass from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
            string strClass = "";
            if (objUclass != null)
            {
                strClass = objUclass.ToString();
                if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
                {
                    Session["CheckCode1"] = "false";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "ȡ����̳����-��������<br/>���û�����ǹ���Ա�����ǰ�����ֻ��ͨ����ϵ����Ա������롣 ", 400, "1", "history.go(-1)", "", false, false));
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "err", Pbzx.Common.JS.Alert("�û��������ڻ��߱�����."));
            }
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "ϵͳ��æ�� ", 400, "1", "history.go(-1)", "", false, false));
            //    return;
            //}
        }
        /// <summary>
        /// ѭ���ж�
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
                        //   Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "��Ǹ��û���ṩ�˷��񣡣� ", 400, "1", "location='http://www.pinble.com'", "http://www.pinble.com", false, false));
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('��Ǹ��û���ṩ�˷���');location='http://www.pinble.com';</script>");
                        if (objuser != null)
                        {
                            Method.record_user_log(Name.ToString(), Name.ToString(), "������" + msg + "�һ�", "�������");
                        }
                        else
                        {
                            Method.record_user_log("�ο�", "", "������" + msg + "�һ�", "�������");
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

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //���������ܵĵ�ַ
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
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
                //�ж����ε�IP 192.168.1.123
                //�籾��IP��127.
                //��ֹIP 127.0.0.2 ������Ҫͨ����֤
                //�����ó������أ�127.0.0. ����Ҫ���������е�127.0.0.��ͷ��IP
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
                //�ж�ʡ��
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address, "ʡ��", objUclass, Name))
                {
                    return true;
                }

                //�ҳ����ĵ�һ���һ�����ʱ��
                object objtime = DbHelperSQLBBS.GetSingle("select top 1 GetPSTime from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                if (objtime != null)
                {
                    int number = -1;
                    //ת����һ��ʱ��
                    DateTime datetimeZH = Convert.ToDateTime(objtime);
                    //�õ���ǰʱ��
                    DateTime datetimeXZ = DateTime.Now;

                    //�õ�ʱ����
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
                    //�Ѿ������޶�ʱ��,ÿ���һ����������0
                    if (number == 0)
                    {
                        DbHelperSQLBBS.ExecuteSql("update Dv_User set GetPSCount=0 where UserName='" + Name + "'");
                    }
                }
                else
                {
                    DbHelperSQLBBS.ExecuteSql("update Dv_User set GetPSCount=0 where UserName='" + Name + "'");
                }

                //�ҳ���NСʱ���һ�����Ĵ���
                object objcount = DbHelperSQLBBS.GetSingle("select top 1 GetPSCount from Dv_User where UserName='" + Name + "' and " + Method.DV_User);
                if (objcount != null)
                {
                    //�ж����һ�����Ĵ���
                    if (Convert.ToInt32(objcount) >= Convert.ToUInt32(count))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "ȡ����̳����-�һش���Ƶ��<br/>��" + hours + "Сʱ֮���������һأ��� ", 400, "1", "history.go(-1)", "", false, false));
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
        /// �鿴�޶�����
        /// </summary>
        /// <returns></returns>
        private bool limitNum()
        { 
            string count="";
            string hours="";
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
                hours = xml_root.SelectSingleNode("@Hours").Value;
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
                DataSet dsN = DbHelperSQL.Query("select * from PBnet_retrieveinfo where Rip="+"'"+ ip +"'");
                if (dsN != null && dsN.Tables[0].Rows.Count > 0)
                {
                    
                    //��Ϊ��
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
                                //ɾ����������
                                if (DbHelperSQL.ExecuteSql("delete from PBnet_retrieveinfo where Rip=" + "'" + ip + "'") > 0)
                                {
                                    //��ӵ����ݿ�
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
                                    Method.record_user_log(txtUserName.Text.ToString(), "IP��" + ip, "�һ�����Ƶ��", "�������");
                                }
                                else
                                {
                                    //��¼��־
                                    Method.record_user_log(txtUserName.Text.ToString(), "", "�һ�����Ƶ��", "�������");
                                }
                                return false;
                            }
                        }

                    }
                    else
                    { 
                        //�������ƴ���
                        //��ӵ����ݿ�
                        if (DbHelperSQL.ExecuteSql("insert into PBnet_retrieveinfo(RName,Rip,RTime) values('" + txtUserName.Text.ToString() + "','" + ip + "','" + DateTime.Now + "')") > 0)
                        {
                            return true;
                        }
                    }

                }
                else
                { 
                    //û������
                    //��ӵ����ݿ�
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
