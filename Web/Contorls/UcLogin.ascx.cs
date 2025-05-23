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
using Maticsoft.DBUtility;
using System.Xml;

namespace Pbzx.Web.Contorls
{
    public partial class UcLogin : System.Web.UI.UserControl
    {


        private string _inUrl = "";
        /// <summary>
        /// ��תĿ��Url
        /// </summary>
        public string InUrl
        {
            get { return _inUrl; }
            set { _inUrl = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginSort login = new LoginSort();
                ///�ж��û��Ƿ��½״̬
                if (!login["manager_user"])
                {
                    this.hasLogin.Visible = false;
                    this.Login.Visible = true;
                }
                else
                {
                    this.Login.Visible = false;
                    this.lblUName.Text = Method.Get_UserName;
                    this.hasLogin.Visible = true;
                }

            }
        }
        private void InitLoginIP(string username)
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("userlogin")[0];

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
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log(username, "", "�����θ�IPλ�õ�¼", "��¼���");
                    Response.Redirect("http://www.pinble.com");
                }
                //�ж�ʡ��
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log(username, "", "�����θõ�ַλ�õ�¼", "��¼���");
                    Response.Redirect("http://www.pinble.com");
                }
            }
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

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            #region ���������Ϣ��¼
            string UID = this.txtName.Text.Trim();
            string PWD = this.txtPWD.Text.Trim();
            string vCode = this.txtCode.Text.Trim();

            //��¼����λ���ж�
            InitLoginIP(UID);

            if (UID == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "�û�������Ϊ�գ�", 350, "1", "", "", false, false));

                return;
            }
            if (PWD == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "�û����벻��Ϊ�գ�", 350, "1", "", "", false, false));

                return;
            }
            if (vCode == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "��֤�벻��Ϊ�գ�", 350, "1", "", "", false, false));

                return;
            }
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "��֤���Ѿ�ʧЧ��", 350, "1", "", "", false, false));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "��֤���������", 350, "1", "", "", false, false));
                return;
            }
            Pbzx.BLL.PinbleLogin login = new Pbzx.BLL.PinbleLogin();
            string loginResult = login.CheckLogin(UID, PWD, "0");
            if (string.IsNullOrEmpty(loginResult))
            {

                if (Request["ReturnUrl"] != null)
                {
                    Response.Write("<script>window.top.location.href='" + Server.UrlDecode(Request["ReturnUrl"]) + "';</script>");
                    Response.End();
                }
                //������ת
                if (string.IsNullOrEmpty(InUrl))
                {
                    Response.Redirect(Request.Url.PathAndQuery);
                }
                else
                {
                    Response.Write("<script>window.top.location.href='" + this.InUrl + "';</script>");
                    Response.End();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "loginResult", JS.Alert("" + loginResult + ""));
                return;
            }
            #endregion

        }
    }
}