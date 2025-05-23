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
    public partial class MakeJYPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request["tag"]))
                {
                    return;
                }              
                this.lblUserName.Text = Method.Get_UserName;
             }
        }
        protected void inbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            string pwd = this.txtUserPassword.Text;
            string vCode = this.txtCode.Text.Trim();
            if (vCode == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码不能为空!"));
                return;
            }
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
            }
            if (DbHelperSQL.Exists("select * from PBnet_UserTable where UserName='" + Method.Get_UserName + "'"))
            {
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("用户名不存在，您无法修改，请重新注册!"));
                return;
            }
            int result = DbHelperSQL.ExecuteSql("update PBnet_UserTable set TradePwd='" + Input.MD5(pwd) + "' where UserName='" + Method.Get_UserName + "'");           
            if (result > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("恭喜您，密码修改成功!"));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/"));
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "tiao", JS.Alert("对不起，密码修改失败!"));
            }

        }

    }
}
