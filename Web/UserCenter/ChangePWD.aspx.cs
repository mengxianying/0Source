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
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "验证码已经失效！", 350, "1", "", "", false, false) + "");
                return;
            }

            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                strErrMsg += "验证码输入错误！<br/>";
            }
            string pwd = this.txtNewPWD.Text;
            string rePwd = this.txtConfirmPWD.Text;
            

            if (string.IsNullOrEmpty(pwd))
            {
                strErrMsg += "密码不能为空！<br/>";
            }
            if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            {
                strErrMsg += "密码必须是6-16位的字母和数字！<br/>";
            }
            if (Input.IsInteger(pwd, true) || Input.IsAllLetter(pwd) || pwd.Contains("12345"))
            {
                strErrMsg += "密码过于简单，密码必须是字母和数字的组合！<br/>";
            }
            if (pwd != rePwd)
            {
                strErrMsg += "两次密码输入不一致！<br/>";
            }
            if(!string.IsNullOrEmpty(strErrMsg))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "您提交的信息有以下错误：<br/><br/>"+strErrMsg+"<br/>请您修改后重新提交！", 350, "1", "", "", false, false) + "");
                return;
            }

            string oldPwd = Input.MD5(Input.FilterHTML(this.txtOldPWD.Text));
            bool isRight = ((int)DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Method.Get_UserName + "' and UserPassword='" + oldPwd + "'")) > 0 ? true : false;
            if (!isRight)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "旧密码输入错误！", 350, "1", "", "", false, false) + "");
                return;
            }
            else
            {
                int result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserPassword='" + Input.MD5(this.txtNewPWD.Text) + "' where UserName='" + Method.Get_UserName + "' ");
                DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(this.txtNewPWD.Text) + "' where UserName='" + Method.Get_UserName + "' ");
                if (result > 0)
                {
                   // Pbzx.BLL.PinbleLogin.UserOut();
                   // Response.Write("<script>alert('密码更新成功！<br/>请您重新登录！');</script>");
                    this.txtCode.Text = "";
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "密码更新成功！新密码将在下次登录时生效！", 350, "1", "location.href='userManage.aspx'", "", false, false) + "");                   
                    //top.location.href='/login.aspx';
                    Method.record_user_log(Method.Get_UserName, "", "修改密码", "密码相关");
                    return;                   
                }
                else
                {
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "密码更新失败！<br/>请与管理员联系！", 350, "1", "location.href='userManage.aspx'", "", false, false) + "");
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
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "密保答案输入不正确！", 400, "1", "", "", false, false) + "");
            }
            else
            {
                this.pnlYanZ.Visible = false;
                this.pnlXiuG.Visible = true;
            }
        }

    }
}
