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
    public partial class UcAD : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.Common.Method.BindAdChanl(this.ddlChannel);
                
                Pbzx.Common.Method.BindAdClass(this.ddlADType);
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
             
                Method.BindDdlOrRadio(this.ddlChannel, "Channel", true);
                Method.BindDdlOrRadio(this.ddlADType, "ADType", true);

                Method.BindText(txtSiteName, "strSiteName", true);
                Method.BindText(txtSiteUrl, "strSiteUrl", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindDdlOrRadio(this.ddlChannel, "Channel", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlADType, "ADType", false));

             bu1.Append(Method.BindText(txtSiteName, "strSiteName", false));
             bu1.Append(Method.BindText(txtSiteUrl, "strSiteUrl", false));
             bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
             bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
             bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

             Response.Redirect("Ad_Manage.aspx?" + bu1.ToString());

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ad_Manage.aspx");
            
        }
    }
}