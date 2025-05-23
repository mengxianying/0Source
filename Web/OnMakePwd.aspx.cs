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
                strErrMsg += "验证码不能为空！<br/>";
            }
            if (Session["ValidateCode"] == null)
            {
                strErrMsg += "验证码已经失效！<br/>";
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                strErrMsg += "验证码输入错误！<br/>";
            }

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

            if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
            }
            else
            {
                strErrMsg += "用户名不存在，您无法修改，请重新注册！<br/>";
            }
            if(!string.IsNullOrEmpty(strErrMsg))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "您提交的信息有以下错误：<br/><br/>" + strErrMsg + "<br/>请您修改后重新提交！", 400, "1", "", "", false, false) + "");
                return;
            }

            int result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserPassword='"+Input.MD5(pwd)+"' where UserName='" + userName + "'");
            //int chat = DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(pwd) + "' where UserName='" + userName + "'");
            DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + Input.MD5(pwd) + "' where UserName='" + userName + "' ");
            if (result > 0 )
            {
                Session["CheckCode3"] = null;
                Method.record_user_log(userName, "通过密保问题找回密码", "密码找回成功", "密码相关");
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "恭喜您，密码修改成功！", 400, "1", "document.location='/'", "", false, false) + "");        
            }
            else
            {
                Method.record_user_log(userName, "通过密保问题找回密码", "找回密码失败", "密码相关");
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "对不起，密码修改失败！", 400, "1", "document.location='/'", "", false, false) + "");     
            }
           
        }
    }
}
