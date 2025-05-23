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

namespace Pbzx.Web.UserCenter.Contorls
{
    public partial class UcGroupSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Method.BindText(txtQQ_GroupID, "GroupID", true);
                Method.BindText(this.txtQQ_GroupName, "GroupName", true);
                Method.BindDdlOrRadio(this.rblQQ_GroupType, "GroupType", true);
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();
            bu1.Append(Method.BindText(txtQQ_GroupID, "GroupID", false));
            bu1.Append(Method.BindText(txtQQ_GroupName, "GroupName", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblQQ_GroupType, "GroupType", false));
            Response.Redirect("QQ_GroupManager.aspx?" + bu1.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("QQ_GroupManager.aspx");
        }
    }
}