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
    public partial class UcSoftClass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Method.BindText(this.txtNvarClassName, "NvarClassName", true);

                if (string.IsNullOrEmpty(Request["IntSetting"]))
                {
                    this.rblIntSetting.Items[0].Selected = true;
                }
                else
                {
                    Method.BindDdlOrRadio(rblIntSetting, "IntSetting", true);
                }
                Method.BindDdlOrRadio(this.rblBitIsElite, "BitIsElite", true);
            }
        }

        private string _reUrl = "SoftClass_Sort.aspx";

        public string ReUrl
        {
            get { return _reUrl; }
            set { _reUrl = value; }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindText(this.txtNvarClassName, "NvarClassName", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblBitIsElite, "BitIsElite", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblIntSetting, "IntSetting", false));
            Response.Redirect(ReUrl + "?" + bu1.ToString());
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(ReUrl);
        }

        protected void rblLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindText(txtNvarClassName, "NvarClassName", false));
            bu1.Append(Method.BindDdlOrRadio(rblBitIsElite, "BitIsElite", false));
            bu1.Append(Method.BindDdlOrRadio(rblIntSetting, "IntSetting", false));
            Response.Redirect(ReUrl + "?" + bu1.ToString());
        }
    }
}