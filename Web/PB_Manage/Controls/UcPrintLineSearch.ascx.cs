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
    public partial class UcPrintLineSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtSN, "strSN", true);
                Method.BindText(txtUsername, "strUsername", true);
                Method.BindDdlOrRadio(this.ddlUseType, "useType", true);
                Method.BindDdlOrRadio(this.ddlPayStatus, "payStatus", true);                           

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder("");
            bu.Append(Method.BindText(txtSN, "strSN", false));
            bu.Append(Method.BindText(txtUsername, "strUsername", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlUseType, "useType", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlPayStatus, "payStatus", false));                     

            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("CL_PrintLine_Manage.aspx?" + bu.ToString());
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("CL_PrintLine_Manage.aspx");
        }
    }
}