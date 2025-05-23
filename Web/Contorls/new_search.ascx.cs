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
    public partial class new_search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["strTitle"]))
                {
                    this.txtTitle.Text = Input.Decrypt(Request["strTitle"]);
                }
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            string parTitle = Input.FilterAll(this.txtTitle.Text);
            string result = Input.Encrypt(parTitle);
            Response.Redirect("Bulletin_list.aspx?" + "strTitle=" + result);
        }
    }
}