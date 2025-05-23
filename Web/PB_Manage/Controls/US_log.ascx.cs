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
using Pbzx.Common;
namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class US_log : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
            this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
            BindList();

            Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType", true);
            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
                softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
            }

            if (!string.IsNullOrEmpty(Request["installType"]))
            {
                this.ddlInstallType.SelectedValue = Request["installType"];
            }
            //Method.BindText(txtHDSN, "strHDSN", true);
            this.chkYuan.Checked = false;
            Method.BindText(txtVersion, "strVersion", true);
            Method.BindText(txtIP, "strIP", true);
            Method.BindText(txtName, "strName", true);
            Method.BindText(txtCreateTime1, "strCreateTime1", true);
            Method.BindText(txtCreateTime2, "strCreateTime2", true);
            Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
        }
        private void BindList()
        {
            Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
            softwareBLL.BindSoftwareType(this.ddlSoftwareType);            
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType", false));

            bu1.Append(Method.BindDdlOrRadio(this.ddlInstallType, "installType", false));

            bu1.Append(Method.BindText(txtHDSN, "strHDSN", false));
            if (!string.IsNullOrEmpty(this.txtHDSN.Text))
            {
                StringBuilder aa = this.chkYuan.Checked ? bu1.Append(Method.BindText(txtHDSN, "strHDSN", false)) : bu1.Append("&strHDSN=" + this.txtHDSN.Text + "+1");
            }
            bu1.Append(Method.BindText(txtVersion, "strVersion", false));
            bu1.Append(Method.BindText(txtIP, "strIP", false));
            bu1.Append(Method.BindText(txtName, "strName", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("US_online.aspx?" + bu1.ToString());
        }

        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
            softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
        }
    }
}