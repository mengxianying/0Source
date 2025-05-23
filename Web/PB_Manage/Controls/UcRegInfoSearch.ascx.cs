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
    public partial class UcRegInfoSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                BindList();

                Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType", true);


                Method.BindText(txtUsername, "strUsername", true);

                Method.BindDdlOrRadio(this.ddlPayStatus, "payStatus", true);
                Method.BindDdlOrRadio(this.ddlPayType, "payType", true);
                Method.BindDdlOrRadio(this.ddlRegisterType, "registerType", true);

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        private void BindList()
        {
            Pbzx.BLL.AgentInfo agentInfoBLL = new Pbzx.BLL.AgentInfo();
            agentInfoBLL.BindAgentName(this.ddlRegisterType);
           // Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
           // softwareBLL.BindSoftwareType(this.ddlSoftwareType);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu= new StringBuilder("");
            bu.Append(Method.BindDdlOrRadio(this.ddlSoftwareType, "softwareType", false));

            bu.Append(Method.BindText(txtUsername, "strUsername", false));

            bu.Append(Method.BindDdlOrRadio(this.ddlPayStatus, "payStatus", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlPayType, "payType", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlRegisterType, "registerType", false));

            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("CL_RegInfo_Manage.aspx?" + bu.ToString());
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("CL_RegInfo_Manage.aspx");
        }
    }
}