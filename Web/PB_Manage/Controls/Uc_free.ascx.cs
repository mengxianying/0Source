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
    public partial class Uc_free : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                BindList();

                #region ÃÏÐÞ¸Ä(2010-01-05)
                Method.BindDdlOrRadio(this.ddlSoftwareType, "SoftwareName", true);
                if (!string.IsNullOrEmpty(Request["SoftwareName"]))
                {
                    Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
                    softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
                }
                if (!string.IsNullOrEmpty(Request["InstallName"]))
                {
                    this.ddlInstallType.SelectedValue = Request["InstallName"];
                }
                #endregion

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
                Method.BindDdlOrRadio(this.ddlStatus, "Status", true);
                Method.BindText(txtHDSN, "strHDSN", true);
                if (!string.IsNullOrEmpty(Request["yuan"]))
                {
                    this.chkYuan.Checked = true;
                }
                Method.BindText(txtDiskCVol, "strDiskCVol", true);
                Method.BindText(txtUseCount, "strUseCount", true);
                Method.BindText(txtLastIp, "strLastLoginIP", true);
                Method.BindText(txtLastID, "strLastLoginID", true);
                Method.BindText(txtServiceID, "strServiceID", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
             
            }
        }
        private void BindList()
        {
            Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
            softwareBLL.BindSoftwareType(this.ddlSoftwareType);
            //ddlSoftwareType.Attributes.Add("onChange", "SoftwareTypeChange('" + ddlSoftwareType.ClientID + "','" + ddlInstallType.ClientID + "',this.value);");

        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");

            #region ÃÏÐÞ¸Ä(2010-01-05)
            bu1.Append(Method.BindDdlOrRadio(this.ddlSoftwareType, "SoftwareName", false));
            //bu.Append(Method.BindDdlOrRadio(this.ddlInstallType, "InstallName", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlInstallType, "InstallName", false));
            #endregion

            bu1.Append(Method.BindDdlOrRadio(this.ddlStatus, "Status", false));
          //  Method.BindText(txtHDSN, "strHDSN", true);
            bu1.Append(Method.BindText(txtHDSN, "strHDSN", false));
            if (this.chkYuan.Checked)
            {
                bu1.Append("&yuan=yes");
            }
            bu1.Append(Method.BindText(txtDiskCVol, "strDiskCVol", false));
            bu1.Append(Method.BindText(txtUseCount, "strUseCount", false));
            bu1.Append(Method.BindText(txtLastIp, "strLastLoginIP", false));
            bu1.Append(Method.BindText(txtLastID, "strLastLoginID", false));
            bu1.Append(Method.BindText(txtServiceID, "strServiceID", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            Response.Redirect("US_free.aspx?" + bu1.ToString());
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("US_free.aspx");
        }

        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
            softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
        }
    }
}