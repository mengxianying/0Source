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
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Text.RegularExpressions;

namespace Pbzx.Web.UserCenter
{
    public partial class ChangePWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object objMBWT = DbHelperSQLBBS.GetSingle(" select UserQuesion from Dv_User where UserName='"+Method.Get_UserName+"' ");

                if (objMBWT != null && objMBWT.ToString() != "")
                {
                    this.lblMBWT.Text = objMBWT.ToString();
                }
                else
                {
                    this.pnlYanZ.Visible = false;
                    this.pnlXiuG.Visible = true;
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (Session["ValidateCode"] == null)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "��֤���Ѿ�ʧЧ��", 350, "1", "", "", false, false) + "");
                return;
            }

            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                strErrMsg += "��֤���������<br/>";
            }
            string pwd = this.txtNewPWD.Text;
            string rePwd = this.txtConfirmPWD.Text;
            

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
            if (pwd != rePwd)
            {
                strErrMsg += "�����������벻һ�£�<br/>";
            }
            if(!string.IsNullOrEmpty(strErrMsg))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "���ύ����Ϣ�����´���<br/><br/>"+strErrMsg+"<br/>�����޸ĺ������ύ��", 350, "1", "", "", false, false) + "");
                return;
            }

            string oldPwd = Input.MD5(Input.FilterHTML(this.txtOldPWD.Text));
            bool isRight = ((int)DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Method.Get_UserName + "' and UserPassword='" + oldPwd + "'")) > 0 ? true : false;
            if (!isRight)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "�������������", 350, "1", "", "", false, false) + "");
                return;
            }
            else
            {
                int result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserPassword='" + Input.MD5(this.txtNewPWD.Text) + "' where UserName='" + Method.Get_UserName + "' ");
                DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(this.txtNewPWD.Text) + "' where UserName='" + Method.Get_UserName + "' ");
                if (result > 0)
                {
                   // Pbzx.BLL.PinbleLogin.UserOut();
                   // Response.Write("<script>alert('������³ɹ���<br/>�������µ�¼��');</script>");
                    this.txtCode.Text = "";
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("��ʾ��", "������³ɹ��������뽫���´ε�¼ʱ��Ч��", 350, "1", "location.href='userManage.aspx'", "", false, false) + "");                   
                    //top.location.href='/login.aspx';
                    Method.record_user_log(Method.Get_UserName, "", "�޸�����", "�������");
                    return;                   
                }
                else
                {
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "�������ʧ�ܣ�<br/>�������Ա��ϵ��", 350, "1", "location.href='userManage.aspx'", "", false, false) + "");
                    return;
                }
            }
        }

        protected void btnKSYZ_Click(object sender, EventArgs e)
        {
            string answer = Input.MD5(this.txtMBDA.Text);

            int count =  Convert.ToInt32(DbHelperSQLBBS.GetSingle(" select count(UserName)  from Dv_User where UserName='" + Method.Get_UserName + "' and UserQuesion='" + this.lblMBWT.Text + "' and UserAnswer='" + answer + "' "));
            if (count < 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "�ܱ������벻��ȷ��", 400, "1", "", "", false, false) + "");
            }
            else
            {
                this.pnlYanZ.Visible = false;
                this.pnlXiuG.Visible = true;
            }
        }

    }
}
