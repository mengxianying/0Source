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
    public partial class UcUdetailsSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Method.BindText(txtTitle, "txt", true);
                Method.BindDdlOrRadio(rblsearch, "lei", true);
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder();

            bu.Append(Method.BindText(txtTitle, "txt", false));
            bu.Append(Method.BindDdlOrRadio(rblsearch, "lei", false));
            Response.Redirect("UserDetails_Manage.aspx?" + bu.ToString(), true);

        }
    }
}