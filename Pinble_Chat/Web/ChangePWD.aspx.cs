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

namespace Pbzx.Web
{
    public partial class ChangePWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                return;
            }

            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
            }            


            string oldPwd = Input.MD5(Input.FilterAll(this.txtOldPWD.Text));
            bool isRight = ((int)DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Method.Get_UserName + "' and UserPassword='" + oldPwd + "'")) > 0 ? true : false ;
            if (!isRight)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("旧密码输入错误!"));
                return;
            }
            else
            {
               int  result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserPassword='" + Input.MD5(this.txtNewPWD.Text) + "' where UserName='"+Method.Get_UserName+"' ");
               if (result > 0)
               {
                   Response.Write("<script>alert('密码更新成功！\\r\\n新密码将在下次登录时候起效');</script>");
                   return;
               }
               else
               {
                   ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("密码更新失败!\\r\\n请与管理员联系"));
                   return;            
               }
            }


        }

    }
}
