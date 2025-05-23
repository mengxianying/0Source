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
using System.Text.RegularExpressions;

namespace Pbzx.Web
{
    public partial class OnMakePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CheckCode3"] != null && Session["CheckCode3"].ToString() == "true")
                {
                }
                else
                {
                    Response.Redirect("~/PageNoFound.htm");
                }

                if (Request["name"] != null)
                {
                    this.txtUserName.Text = Input.Decrypt(Input.FilterAll(Request["name"])); 
                }
                else
                {
                    Response.Redirect("RecoverPasswd1.aspx");
                }
            }
        }

        protected void inbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            string userName = Input.FilterAll(this.txtUserName.Text);
            string pwd = Input.FilterAll(this.txtUserPassword.Text);
            string vCode = this.txtCode.Text.Trim();
            string strErrMsg = "";
            if (vCode == "")
            {
                strErrMsg += "��֤�벻��Ϊ�գ�<br/>";
            }
            if (Session["ValidateCode"] == null)
            {
                strErrMsg += "��֤���Ѿ�ʧЧ��<br/>";
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                strErrMsg += "��֤���������<br/>";
            }

            if (string.IsNullOrEmpty(pwd))
            {
                strErrMsg += "���벻��Ϊ�գ�<br/>";
            }
            if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            {
                strErrMsg += "���������6-16λ����ĸ�����֣�<br/>";
            }
            if (Input.IsInteger(pwd, true) || Input.IsAllLetter(pwd) || pwd.Contains("12345"))
            {
                strErrMsg += "������ڼ򵥣������������ĸ�����ֵ���ϣ�<br/>";
            }

            if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
            }
            else
            {
                strErrMsg += "�û��������ڣ����޷��޸ģ�������ע�ᣡ<br/>";
            }
            if(!string.IsNullOrEmpty(strErrMsg))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "���ύ����Ϣ�����´���<br/><br/>" + strErrMsg + "<br/>�����޸ĺ������ύ��", 400, "1", "", "", false, false) + "");
                return;
            }

            int result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserPassword='"+Input.MD5(pwd)+"' where UserName='" + userName + "'");
            //int chat = DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(pwd) + "' where UserName='" + userName + "'");
            DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(pwd) + "' where UserName='" + userName + "' ");
            if (result > 0 )
            {
                Session["CheckCode3"] = null;
                Method.record_user_log(userName, "ͨ���ܱ������һ�����", "�����һسɹ�", "�������");
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("��ʾ��", "��ϲ���������޸ĳɹ���", 400, "1", "document.location='/'", "", false, false) + "");        
            }
            else
            {
                Method.record_user_log(userName, "ͨ���ܱ������һ�����", "�һ�����ʧ��", "�������");
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "�Բ��������޸�ʧ�ܣ�", 400, "1", "document.location='/'", "", false, false) + "");     
            }
           
        }
    }
}
