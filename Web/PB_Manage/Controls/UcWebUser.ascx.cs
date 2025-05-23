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
using System.Text;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcWebUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtUserName, "strUserName", true);
                Method.BindText(txtUserEmail, "strUserEmail", true);
                Method.BindText(txtUserMobile, "strUserMobile", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
                Method.BindChickBox(this.ckbox, "islike", true);
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");

            bu1.Append(Method.BindText(txtUserName, "strUserName", false));
            bu1.Append(Method.BindText(txtUserEmail, "strUserEmail", false));
            bu1.Append(Method.BindText(txtUserMobile, "strUserMobile", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            bu1.Append(Method.BindChickBox(ckbox,"islike",false));
            Response.Redirect("WebUser.aspx?" + bu1.ToString());
        }
        public string Islike()
        {
            if (this.ckbox.Checked)
            {
                return "1";
            }
            else
            {

                return "0";
            }

        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebUser.aspx");
        }
    }
}