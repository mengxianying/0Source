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

namespace Pbzx.Web.PB_Manage
{
    public partial class Admin_ChangePWD : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                return;
            }

            if (this.txtTry.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
            }
            if (this.txtNewPWD1.Text.Length < 6)
            {

            }
            string oldPwd = Pbzx.Common.Input.MD5(Input.FilterAll(this.txtold.Text), false);
            string newPwd = Pbzx.Common.Input.MD5(Input.FilterAll(this.txtNewPWD1.Text), false);
            string Name = WebFunc.GetCurrentAdmin();

            bool isRight = ((int)DbHelperSQL.GetSingle("select count(1) from PBnet_tpman where Master_Name='" + Name + "' and Master_Password='" + oldPwd + "'")) > 0 ? true : false;
            if (!isRight)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("旧密码输入错误!"));
                return;
            }
            else
            {
                int result = DbHelperSQL.ExecuteSql("update PBnet_tpman set Master_Password='" + newPwd + "' where Master_Name='" + Name + "' ");
                if (result > 0)
                {
                    Session.Abandon();
                    Response.Write("<script>alert('密码更新成功！\\r\\n请您重新登录');top.location.href='/PB_Manage/AdminLogin.aspx'</script>");
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
