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
    public partial class UcSoftdogsearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
              //  BindList();
                
          //      Method.BindDdlOrRadio(this.ddlAgent, "Agent", true);
                Method.BindDdlOrRadio(this.ddlPayType, "PayType", true);
                Method.BindDdlOrRadio(this.ddlStatus, "Status", true);
                if (!string.IsNullOrEmpty(Request["Time"]))
                {
                    this.chkTime.Checked = true;
                }
                Method.BindText(txtSN, "strSN", true);
                Method.BindText(txtOldSN, "strOldSN", true);
                Method.BindText(txtSeller, "strSeller", true);
                Method.BindText(txtRemarks, "strRemarks", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);


            }
        }
        //private void BindList()
        //{
        //    Pbzx.BLL.AgentInfo agenBLL = new Pbzx.BLL.AgentInfo();
        //    agenBLL.BindAgentName(this.ddlAgent);
        //}
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");




          // bu1.Append(Method.BindDdlOrRadio(this.ddlAgent, "ddlAgent", false));
           bu1.Append(Method.BindDdlOrRadio(this.ddlPayType, "PayType",false));
           bu1.Append(Method.BindDdlOrRadio(this.ddlStatus, "Status", false));
            if (this.chkTime.Checked)
            {
               bu1.Append("&time=1");
               bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
               bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            }
           bu1.Append(Method.BindText(txtSN, "strSN", false));
           bu1.Append(Method.BindText(txtOldSN, "strOldSN", false));
           bu1.Append(Method.BindText(txtSeller, "strSeller",false));
           bu1.Append(Method.BindText(txtRemarks, "strRemarks",false));


           Response.Redirect("softdog_Manager.aspx?" + bu1.ToString());
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("softdog_Manager.aspx");
        }
    }
}