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
using System.Text;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcLottery : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["name"]))
                {
                    this.txtName.Text = Request["name"];
                }
                if (!string.IsNullOrEmpty(Request["NvarClass"]))
                {
                    this.ddlType.SelectedValue = Request["NvarClass"];
                }
                if (!string.IsNullOrEmpty(Request["isShow"]))
                {
                    this.rblIsShow.SelectedValue = Request["isShow"];
                }
                if (!string.IsNullOrEmpty(Request["state"]))
                {
                    this.rblState.SelectedValue = Request["state"];
                }
            }
        }
        //Controls/cpdataconfig/GPX5config.aspx
        //Controls/cpdataconfig/TC481config.aspx
        ///Controls/cpdataconfig/SSCconfig.aspx
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();
            bu1.Append("1=1");
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                bu1.Append("&name=" + this.txtName.Text);
            }
            if (this.ddlType.SelectedValue != "")
            {
                bu1.Append("&NvarClass=" + this.ddlType.SelectedValue);
            }
            if (this.rblIsShow.SelectedValue != "")
            {
                bu1.Append("&isShow=" + this.rblIsShow.SelectedValue.Trim());
            }
            if (this.rblState.SelectedValue != "")
            {
                bu1.Append("&state=" + this.rblState.SelectedValue.Trim());
            }

            Response.Redirect("KJCpSort_Manage.aspx?" + bu1.ToString(), true);
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();
            bu1.Append("1=1");
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                bu1.Append("&name=" + this.txtName.Text);
            }
            if (this.ddlType.SelectedValue != "")
            {
                bu1.Append("&NvarClass=" + this.ddlType.SelectedValue);
            }
            if (this.rblIsShow.SelectedValue != "")
            {
                bu1.Append("&isShow=" + this.rblIsShow.SelectedValue.Trim());
            }
            if (this.rblState.SelectedValue != "")
            {
                bu1.Append("&state=" + this.rblState.SelectedValue.Trim());
            }

            Response.Redirect("KJCpSort_Manage.aspx?" + bu1.ToString(), true);
        }

        protected void btnCanl_Click(object sender, EventArgs e)
        {
            Response.Redirect("KJCpSort_Manage.aspx");
        }
    }
}