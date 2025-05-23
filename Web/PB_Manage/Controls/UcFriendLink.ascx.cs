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
    public partial class UcFriendLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Method.BindText(txtSiteName, "IntSiteName", true);

              Method.BindDdlOrRadio(ddlLinkType, "IntLinkType", true);
              Method.BindDdlOrRadio(ddlIsGood, "IsGood", true);
              Method.BindDdlOrRadio(ddlPass, "BitIsOK", true);
            }
        }

        private string _reUrl = "FriendLink_Manage.aspx";

        public string ReUrl
        {
            get { return _reUrl; }
            set { _reUrl = value; }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindText(txtSiteName, "IntSiteName", false));
            bu1.Append(Method.BindDdlOrRadio(ddlIsGood, "IsGood", false));
            bu1.Append(Method.BindDdlOrRadio(ddlLinkType, "IntLinkType", false));
            bu1.Append(Method.BindDdlOrRadio(ddlPass, "BitIsOK", false));
            Response.Redirect(ReUrl+"?" + bu1.ToString());
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(ReUrl);
        }

       
    }
}