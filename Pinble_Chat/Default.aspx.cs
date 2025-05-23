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
using System.Net;
using System.IO;
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Xml;

namespace Pinble_Chat
{
    public partial class _Default : System.Web.UI.Page
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
            if (Method.Get_UserName.ToString() != "0")
            {
                Page.RegisterStartupScript("cue", "<script>cue('" + Method.Get_UserName.ToString() + "')</script>");
            }
            if (!IsPostBack)
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
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' ");
                    if (Convert.ToInt32(objMsgCount) > 0)
                    {
                        this.lblMessage.Text = "<a href='" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx?myUrl=/UsersMs.aspx' title='�Ķ�����Ϣ' target='_blank'>������ (<font color='red'>" + objMsgCount.ToString() + "</font>)</a>";
                    }
                    else
                    {
                        this.lblMessage.Text = "<a href='" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx?myUrl=/UsersMs.aspx' title='�Ķ�����Ϣ' target='_blank'>������ (0)</a>";
                    }
                    this.hasLogin.Visible = true;

                }
                BindChat();
                CheckIsLogin();
            }

        }
        private void CheckIsLogin()
        {
            LoginSort login = new LoginSort();
            if (login["manager_user"])
            {
                string bbsName = Method.Get_UserName;
                //string chatName = "";
                ///�ж��û��Ƿ������Ĳ��ҵ�һ�ε�¼������û��ǵ�һ�ε�¼����ʾͬ�����������û���
                if (!DbHelperSQLMeChat.Exists("select  count(*) from UserInfo where UserName='" + Method.Get_UserName + "'"))
                {
                    ClientScript.RegisterStartupScript(GetType(), "winOpen", "<script type='text/javascript'> $(document).ready(function(){show('Synchronous',document.getElementById('address'),'�Ĳ���ͬ��',500,400)});</script>");//document.getElementById('Synchronous'),{width:'650px',height:'487px'} 
                    return;
                    //{alert('�����Ĳ������û���\\r\\n�����û���Ϊ:" + Session["manager_user"].ToString() + "\\r\\n��������Ϊ:" + Session["RealPWD"].ToString() + "\\r\\n���μ�!');window.location.reload();}        $.blockUI({message: $('#Synchronous'), css: {width:'480px',height:'360px'} });
                    //
                }

            }
        }
        private void BindChat()
        {
            string chatName = this.lblUName.Text;
            DataSet ds = DbHelperSQLMeChat.Query("select top 1 Alias,Grade,Age,LogoutTime from UserInfo where UserName='" + chatName + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //this.lblAlias.Text = ds.Tables[0].Rows[0]["Alias"].ToString();
                if (ds.Tables[0].Rows[0]["Grade"] != null)
                {
                    this.lblGrade.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
                    this.lblAge.Text = GetGrade(ds.Tables[0].Rows[0]["Grade"].ToString());
                }
            }
            DataSet dsBBS = DbHelperSQLBBS.Query("select top 1 LastLogin from Dv_User where UserName='" + chatName + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (dsBBS.Tables.Count > 0 && dsBBS.Tables[0].Rows.Count > 0)
                {
                    this.lblLogoutTime.Text = dsBBS.Tables[0].Rows[0]["LastLogin"].ToString();
                }

            }

        }
        public static string GetGrade(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "��ҵ����";
                    break;
                case 1:
                    type = "�±�";
                    break;
                case 2:
                    type = "רҵ��ʿ";
                    break;
                case 3:
                    type = "��ξ";
                    break;
                case 4:
                    type = "��ξ";
                    break;
                case 5:
                    type = "��ξ";
                    break;
                case 6:
                    type = "��У";
                    break;
                case 7:
                    type = "��У";
                    break;
                case 8:
                    type = "��У";
                    break;
                case 9:
                    type = "��У";
                    break;
                case 10:
                    type = "�ٽ�";
                    break;
                case 11:
                    type = "�н�";
                    break;
                case 12:
                    type = "�Ͻ�";
                    break;
                case 13:
                    type = "�����Ͻ�";
                    break;
                default:
                    type = "δ֪";
                    break;
            }
            return type;
        }

        private void InitLoginIP(string username)
        {
            string tempLJ = HttpRuntime.AppDomainAppPath.Substring(0, HttpRuntime.AppDomainAppPath.Length - 1);
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
            XmlElement xe1 = (XmlElement)node1;
            string barWJJ = xe1.Attributes["value"].Value;

            string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

            XmlDocument XmlDoc;
            XmlNodeList NodeList;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");

            //�õ����ڵ�
            XmlElement root = XmlDoc.DocumentElement;
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

            InitLoginIP(UID);

            if (UID == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "uiderr", JS.Alert("�û�������Ϊ��!"));
                return;
            }
            if (PWD == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "pwderr", JS.Alert("�û����벻��Ϊ��!"));
                return;
            }
            if (vCode == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("��֤�벻��Ϊ��!"));
                return;
            }
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("��֤���Ѿ�ʧЧ!"));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("��֤���������!"));
                return;
            }
            Pbzx.BLL.PinbleLogin login = new Pbzx.BLL.PinbleLogin();
            string cbState = this.chbState.Checked ? "3" : "0";
            string loginResult = login.CheckLoginChat(UID, PWD, cbState);
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
        protected void ibtnLoginOut_Click(object sender, ImageClickEventArgs e)
        {
            Pbzx.BLL.PinbleLogin.UserOut();
            Response.Redirect(Request.Url.PathAndQuery);
        }

        //protected void btnTB_Click(object sender, EventArgs e)
        //{
        //    //��̨������֤
        //    string strErrMsg = "";
        //    if (this.txtBbsName.Text.Trim() == "")
        //    {
        //        strErrMsg += "��̳�û�������Ϊ��.\\r\\n";
        //    }
        //    if (this.txtBbsPWD.Text.Trim() == "")
        //    {
        //        strErrMsg += "��̳�����벻��Ϊ��.\\r\\n";
        //    }
        //    if (this.txtLcsName.Text.Trim() == "")
        //    {
        //        strErrMsg += "�Ĳ����û�������Ϊ��.\\r\\n";
        //    }
        //    if (this.txtLcsPWD.Text.Trim() == "")
        //    {
        //        strErrMsg += "�Ĳ������벻��Ϊ��.\\r\\n";
        //    }
        //    if (strErrMsg != "")
        //    {
        //        strErrMsg = "���ύ���Ĳ���ͬ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
        //        ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));                
        //        return;
        //    }
        //    else
        //    {
        //        #region �ж���̳�û����������Ƿ���ȷ
        //        //�����ı��� ��ֹע�빥��
        //        string bbsName = Input.FilterAll(this.txtBbsName.Text);
        //        string bbsPWD = Input.FilterAll(this.txtBbsPWD.Text);
        //        DataSet ds = DbHelperSQLBBS.Query("select top 1 * from Dv_User where UserName='" + bbsName + "'");
        //        if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("��̳�û��������벻��ȷ!�޷�ͬ����"));                    
        //            return;
        //        }
        //        DataRow rowData = ds.Tables[0].Rows[0];
        //        if (rowData["UserPassword"].ToString() != Input.MD5(bbsPWD))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("��̳�û��������벻��ȷ!�޷�ͬ����"));                    
        //            return;
        //        }
        //        #endregion

        //        #region �ж��Ĳ��� �û����������Ƿ���ȷ
        //        string chatName = Input.FilterAll(this.txtLcsName.Text);
        //        string chatPWD = Input.FilterAll(this.txtLcsPWD.Text);
        //        DataSet dsChat = DbHelperSQLMeChat.Query("select top 1 * from UserInfo where UserName='" + chatName + "'");
        //        if (!(dsChat.Tables.Count > 0 && dsChat.Tables[0].Rows.Count > 0))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("�Ĳ����û��������벻��ȷ!�޷�ͬ����"));
        //            return;
        //        }
        //        DataRow rowDataChat = dsChat.Tables[0].Rows[0];
        //        string tempChatPWD = rowDataChat["Password"].ToString();
        //        if (tempChatPWD.Length == 16 && !Method.IsContainsNum(tempChatPWD))
        //        {
        //            if (tempChatPWD != Input.MD5(chatPWD))
        //            {
        //                Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("�Ĳ����û��������벻��ȷ!�޷�ͬ����"));                        
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (tempChatPWD != chatPWD)
        //            {
        //                Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("�Ĳ����û��������벻��ȷ!�޷�ͬ����"));                        
        //                return;
        //            }
        //        }
        //        #endregion


        //        ///�����û�ԭ�Ĳ��Ҽ�¼��¼�����±�
        //        int copy = DbHelperSQLMeChat.ExecuteSql("select * into userInfo from userInfo2 where userInfo2.userName='" + chatName + "'");
        //        ///�����û��Ĳ����û�������Ϊ��̳�û���ʵ��ͬ��
        //        int update = DbHelperSQLMeChat.ExecuteSql("update userInfo2 set userName='" + bbsName + "'");
        //        if (copy > 0 && update > 0)
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>alert('ͬ���ɹ���\\r\\n�����û���Ϊ�� " + bbsName + "\\r\\n��������Ϊ�� " + bbsPWD + "\\r\\n�����μǣ�');$.unblockUI();</script> ");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>alert('ͬ��ʧ�ܣ�\\r\\n������վ����Ա��ϵ��');$.unblockUI();</script> ");
        //        }
        //        //�رմ˴��ڲ�ˢ�¸�����            
        //    }            
        //}

        //protected void btnNew_Click(object sender, EventArgs e)
        //{
        //    string bbsName = Input.FilterAll(this.txtBbsName.Text);
        //    string bbsPWD = Input.FilterAll(this.txtBbsPWD.Text);
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>alert('�����Ĳ������û���\\r\\n�����û���Ϊ�� " + bbsName + "\\r\\n��������Ϊ�� " + bbsPWD + "\\r\\n�����μǣ�');$.unblockUI();</script> ");
        //}
    }
}
