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

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcLog_kuais : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                if(!string.IsNullOrEmpty(Request["strKuais"]))
                {
                    this.ddlKuai.SelectedValue = Request["strKuais"];
                }
            }
        }

        protected void ddlKuai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("US_log.aspx?strKuais=" + this.ddlKuai.SelectedValue.ToString());

        }

        
    }
}