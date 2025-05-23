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

namespace Pbzx.Web.PB_Manage
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // Session["ValidateCode"] = "";
               //Response.Redirect("AdminLogin.aspx");
            }
        }
       Pbzx.BLL.PBnet_tpman bllTpman = new Pbzx.BLL.PBnet_tpman();

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string UID = this.txtUname.Text.Trim();
            string PWD = this.txtUpwd.Text.Trim();
              string vCode = this.txtCode.Text.Trim();
            if (UID == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "uiderr", JS.Alert("�û�������Ϊ��!"));
                return;
            }
            if (PWD == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "pwderr", JS.Alert("�û����벻��Ϊ��!"));
                return;
            }
            if (vCode == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("��֤�벻��Ϊ��!"));
                return;
            }
            Pbzx.BLL.PBnet_tpman AdminBLL = new Pbzx.BLL.PBnet_tpman();

            if (Session["ValidateCode"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("��֤���Ѿ�ʧЧ!"));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString().ToUpper())
            {
                AdminBLL.WriteWebLog(UID, Session["ValidateCode"].ToString(), vCode);
                ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("��֤���������!"));
                return;
            }
            if (InitLoginIP())
            {
                 // �ж��û��Ƿ������¼
                if (!adminLogion(UID))
                {
                    if (AdminBLL.ValidateLogin(UID, PWD))
                    {
                        Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(UID);
                        Pbzx.BLL.PBnet_Group GroupBLL = new Pbzx.BLL.PBnet_Group();

                        //object objAuthority = GroupBLL.GetAuthorityByName(MyAdmin.UserGroup);
                        //if (objAuthority != null)
                        //{
                        //AdminBasic.UserAuthority = AdminBasic.DeCodeModule(objAuthority);
                        Session["htUserPower"] = AdminBasic.GetUserPowers(MyAdmin.Setting);
                        AdminBLL.UpdateInfo(MyAdmin);
                        if (HttpContext.Current.Request.Cookies["AdminManager"] == null)
                        {
                            HttpCookie cookie = new HttpCookie("AdminManager");
                            cookie.Value = Input.Encrypt(MyAdmin.Master_Name);
                            //cookie.Domain = ".pinble2.com";
                            //cookie.Path = "/";
                            HttpContext.Current.Response.AppendCookie(cookie);
                        }
                        Response.Redirect("Default.aspx", true);
                        //}
                        //else
                        //{
                        //    ClientScript.RegisterStartupScript(this.GetType(), "grouperr", JS.Alert("���û��������κ��û���!"));
                        //    return;
                        //}
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "loginerr", JS.Alert("��¼ʧ�ܣ�\\r\\n�û����������������Ѿ�������"));
                        return;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "loginerr", JS.Alert("��¼ʧ�ܣ�\\r\\n�û��������¼"));
                    return;
                }
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "loginerr", JS.Alert("��¼ʧ�ܣ�\\r\\n�û��������¼"));
                return;
            }
            


            //if (Request.Cookies["CheckCode"] == null)
            //{
            //    Label1.Text = "";
            //    Label1.Visible = true;
            //    return;
            //}

            //if (String.Compare(Request.Cookies["CheckCode"].Value, txtCode.Text.ToString().Trim(), true) != 0)
            //{
            //    Label1.Text = "<font color=red>�Բ�����֤�����</font>";
            //    Label1.Visible = true;
            //    return;
            //}
            //else
            //{
            //    if (!bllTpman.CheckUser(this.txtUname.Text, this.txtUpwd.Text))
            //    {
            //        Label1.Text = "<font color=red>�Բ��������û������������</font>";
            //        Label1.Visible = true;
            //        return;
            //    }
            //    else
            //    {
            //        Response.Redirect("", true);
            //    }
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtUname.Text = "";
            this.txtCode.Text = "";
        }
        private bool InitLoginIP()
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("adminloginIP")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                ////���������ܵĵ�ַ
                //if (ips == "")
                //{
                //    ips = "000.000.000";
                //}
                //if (address == "")
                //{
                //    address = "0";
                //}

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
                if (ips != "")
                {
                    if (NewMethod(ips, ip))
                    {
                        //Method.record_user_log(username, "", "�����θ�IPλ�õ�¼", "��¼���");
                        //Response.Redirect("/PB_Manage/AdminLogin.aspx");
                        
                        return false;
                    }
                    
                }
                if (address != "")
                {
                    //�ж�ʡ��
                    string s_temp = Method.S_getIPaddress(ip);
                    if (NewMethod(s_temp, address))
                    {
                        //Method.record_user_log(username, "", "�����θõ�ַλ�õ�¼", "��¼���");
                        //Response.Redirect("/PB_Manage/AdminLogin.aspx");

                        return false;
                    }
                }
                
            }
            return true;
        }

        /// <summary>
        /// ѭ���ж�
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool NewMethod(string s_temp, string sfs)
        {
            sfs = sfs.Replace("|\r\n", "|");
            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// �û��Ƿ������¼ ��ip���ƣ�
        /// </summary>
        /// <param name="userName">����Ա��</param>
        /// <returns></returns>
        private bool adminLogion(string userName)
        {
            Pbzx.BLL.PBnet_tpman get_tpman = new Pbzx.BLL.PBnet_tpman();
            DataSet ds = get_tpman.GetList("Master_Name="+"'"+ userName +"'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string ips = ds.Tables[0].Rows[0]["ipLimit"].ToString().Trim();

                string address = ds.Tables[0].Rows[0]["regionLimit"].ToString().Trim();
                if (ips == "" && address == "")
                {
                    return false;
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
                if (ips != "")
                {
                    if (accord(ips, ip))
                    {
                        return false;
                    }

                }
                if (address != "")
                {
                    //�ж�ʡ��
                    string s_temp = Method.S_getIPaddress(ip);
                    if (accord(s_temp, address))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ѭ���ж�
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool accord(string s_temp, string sfs)
        {
            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
