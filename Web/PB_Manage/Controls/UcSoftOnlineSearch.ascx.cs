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
    public partial class UcSoftOnlineSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                BindList();

                #region ���޸�(2010-01-05)
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

                Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType",true);

                if (!string.IsNullOrEmpty(Request["softwareType"]))
                {
                    Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
                    softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
                }

                if (!string.IsNullOrEmpty(Request["installType"]))
                {
                    this.ddlInstallType.SelectedValue = Request["installType"];
                }
                Method.BindText(txtHDSN, "strHDSN", true);
                if (!string.IsNullOrEmpty(Request["yuan"]))
                {
                    this.chkYuan.Checked = true;    
                }                
                Method.BindText(txtAct_RN, "strRN", true);
                Method.BindDdlOrRadio(this.ddlAct_RegType, "regType", true);
                Method.BindDdlOrRadio(this.rblCheckHDSN, "checkHDSN", true);
                Method.BindText(txtVersion, "strVersion", true);
                Method.BindDdlOrRadio(this.ddlOSVersion, "oSVersion", true);
                Method.BindText(txtIP, "strIP", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);                
            }
        }
             
        private void BindList()
        {
            Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
            softwareBLL.BindSoftwareType(this.ddlSoftwareType);
            ddlSoftwareType.Attributes.Add("onChange", "SoftwareTypeChange('" + ddlSoftwareType.ClientID + "','" + ddlInstallType.ClientID + "',this.value);");

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder("");
            #region ���޸�(2010-01-05)
            bu.Append(Method.BindDdlOrRadio(this.ddlSoftwareType, "SoftwareName", false));
            //bu.Append(Method.BindDdlOrRadio(this.ddlInstallType, "InstallName", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlInstallType, "InstallName", false));
            #endregion
            bu.Append(Method.BindText(txtHDSN, "strHDSN", false));  
            if(this.chkYuan.Checked )
            {
                bu.Append("&yuan=yes");
            }
            bu.Append(Method.BindText(txtAct_RN, "strRN", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlAct_RegType, "regType", false));
            bu.Append(Method.BindDdlOrRadio(this.rblCheckHDSN, "checkHDSN", false));
            bu.Append(Method.BindText(txtVersion, "strVersion", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlOSVersion, "oSVersion", false));
            bu.Append(Method.BindText(txtIP, "strIP", false));
            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("SoftOnline_Manage.aspx?"+bu.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftOnline_Manage.aspx");
        }

        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
            softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
        }
    }
}