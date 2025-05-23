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
    public partial class UcBroker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                BindGrade();
                BindRate();
                Method.BindText(txtBrokerName, "strBrokerName", true);
                Method.BindDdlOrRadio(ddlState, "strState", true);
                Method.BindDdlOrRadio(ddlgrade, "strgrade", true);
                Method.BindDdlOrRadio(ddlrate, "strrate", true);

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }
        private void BindGrade()
        {
            Pbzx.BLL.PBnet_broker_Config CfBLL = new Pbzx.BLL.PBnet_broker_Config();
            CfBLL.BindGrade(this.ddlgrade);
            ListItem item = new ListItem("所有", "");
            ddlgrade.Items.Insert(0, item);
        }
        private void BindRate()
        {
            Pbzx.BLL.PBnet_broker_Config CfBLL = new Pbzx.BLL.PBnet_broker_Config();
            CfBLL.BindRate(this.ddlrate);
            ListItem item = new ListItem("所有", "");
            ddlrate.Items.Insert(0, item);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");


            bu1.Append(Method.BindText(txtBrokerName, "strBrokerName", false));
          　bu1.Append(Method.BindDdlOrRadio(ddlState, "strState", false));
          　bu1.Append(Method.BindDdlOrRadio(ddlgrade, "strgrade", false));
           bu1.Append(Method.BindDdlOrRadio(ddlrate, "strrate", false));


           bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
           bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));

           bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            Response.Redirect("Broker.aspx?" + bu1.ToString());
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Broker.aspx");
        }
    }
}