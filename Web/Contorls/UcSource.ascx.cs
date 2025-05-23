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

namespace Pbzx.Web.Contorls
{
    public partial class UcSource : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Method.BindText(txtKey, "strKey", true);
                Method.BindDdlOrRadio(this.ddltype, "strType", true);
            }
        }

        protected void btn_soft_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindText(txtKey, "strKey", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddltype, "strType", false));

            Response.Redirect("Source.aspx?" + bu1.ToString());
        }
    }
}