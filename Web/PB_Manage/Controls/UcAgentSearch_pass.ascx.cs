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
    public partial class UcAgentSearch_pass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProvince();
                Method.BindText(txtUserName, "UserName", true);
                Method.BindText(txtName, "Name", true);
                Method.BindDdlOrRadio(this.ddlProvince, "province", true);
                Method.BindDdlOrRadio(this.ddlSate, "strSate", true);

            }
        }

        private void BindProvince()
        {
            Pbzx.BLL.AgentInfo agentBLL = new Pbzx.BLL.AgentInfo();
            DataTable dt1 = agentBLL.GetLisBySql("select distinct Province from AgentInfo");
            foreach (DataRow row in dt1.Rows)
            {
                this.ddlProvince.Items.Add(new ListItem(row["Province"].ToString(), row["Province"].ToString()));
            }

        }

        protected void btnO_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder();
            bu.Append(Method.BindText(txtUserName, "UserName", false));
            bu.Append(Method.BindText(txtName, "Name", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlProvince, "province", false));
            bu.Append(Method.BindDdlOrRadio(this.ddlSate, "strSate", false));
            Response.Redirect("AgentPass_Manage.aspx?" + bu.ToString(), true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgentPass_Manage.aspx");
        }
    }
}