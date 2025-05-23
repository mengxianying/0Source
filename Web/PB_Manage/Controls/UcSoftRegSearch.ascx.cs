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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcSoftRegSearch : System.Web.UI.UserControl
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


                Method.BindText(txtHDSN, "strHDSN", true);
                if (!string.IsNullOrEmpty(Request["yuan"]))
                {
                    this.chkYuan.Checked = true;
                }
                Method.BindText(txtAct_RN, "strRN", true);
                Method.BindText(txtOldSN,"strOldSN",true);
                Method.BindText(txtOrgSN, "strOrgSN", true);
                Method.BindText(txtUserName, "strUserName", true);
                Method.BindText(txtBBsID, "strBBsID", true);
                Method.BindDdlOrRadio(this.ddlTimeType, "timeType", true);
                Method.BindDdlOrRadio(this.ddlRegisterType, "registerType", true);

                Method.BindDdlOrRadio(this.ddlUseType, "useType", true);
                Method.BindDdlOrRadio(this.ddlPayType, "payType", true);

                Method.BindText(txtPayDetails, "strPayDetails", true);
                Method.BindText(txtRemarks, "strRemarks", true);
                Method.BindText(txtUserAddress, "strUserAddress", true);

                Method.BindDdlOrRadio(this.ddlRegType, "regType", true);
                Method.BindDdlOrRadio(this.ddlTStatus, "tStatus", true);

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        private void BindList()
        {
            Pbzx.BLL.AgentInfo agentInfoBLL = new Pbzx.BLL.AgentInfo();
            agentInfoBLL.BindAgentName(this.ddlRegisterType);
            Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
            softwareBLL.BindSoftwareType(this.ddlSoftwareType);



        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder("");
            #region ÃÏÐÞ¸Ä(2010-01-05)
            bu.Append(Method.BindDdlOrRadio(this.ddlSoftwareType, "SoftwareName", false));
            //bu.Append(Method.BindDdlOrRadio(this.ddlInstallType, "InstallName", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlInstallType, "InstallName", false));
            #endregion



            bu.Append(Method.BindText(txtHDSN, "strHDSN", false));
            if (this.chkYuan.Checked)
            {
                bu.Append("&yuan=yes");
            }
            bu.Append(Method.BindText(txtAct_RN, "strRN", false));
            bu.Append(Method.BindText(txtOldSN, "strOldSN", false));
            bu.Append(Method.BindText(txtOrgSN, "strOrgSN", false));
            bu.Append(Method.BindText(txtUserName, "strUserName", false));
            bu.Append(Method.BindText(txtBBsID, "strBBsID", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlTimeType, "timeType", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlRegisterType, "registerType", false));

            bu.Append(Method.BindDdlOrRadio(this.ddlUseType, "useType", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlPayType, "payType", false));

            bu.Append(Method.BindDdlOrRadio(this.ddlRegType, "regType", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlTStatus, "tStatus", false));

            bu.Append(Method.BindText(txtPayDetails, "strPayDetails", false));
            bu.Append(Method.BindText(txtRemarks, "strRemarks", false));
            bu.Append(Method.BindText(txtUserAddress, "strUserAddress", false));

            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("SoftReg_Manager.aspx?" + bu.ToString());
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftReg_Manager.aspx");
        }

        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
            softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);

        }
    }
}