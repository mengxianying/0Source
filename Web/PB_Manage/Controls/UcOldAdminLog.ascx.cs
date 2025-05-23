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
    public partial class UcOldAdminLog : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtlog_username, "log_username", true);
                Method.BindText(txtlog_Ip, "log_Ip", true);
                Method.BindText(txtlog_state, "log_state", true);

                Method.BindText(txtlog_stepinto, "log_stepinto", true);

                Method.BindText(txtlog_password, "log_password", true);

                Method.BindText(txtlog_urlname, "log_urlname", true);


                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");

            bu1.Append(Method.BindText(txtlog_username, "log_username", false));
            bu1.Append(Method.BindText(txtlog_Ip, "log_Ip", false));
            bu1.Append(Method.BindText(txtlog_state, "log_state", false));

            bu1.Append(Method.BindText(txtlog_stepinto, "log_stepinto", false));

            bu1.Append(Method.BindText(txtlog_password, "log_password", false));

            bu1.Append(Method.BindText(txtlog_urlname, "log_urlname", false));



            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));

            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            Response.Redirect("Old_pb_adminloginlog.aspx?" + bu1.ToString());
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Old_pb_adminloginlog.aspx");
        }
    }
}