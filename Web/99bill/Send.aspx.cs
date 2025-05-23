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

namespace Pbzx.Web._99bill
{
    public partial class Send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write(Request.Url.Query);
        }

        protected void ibtnRMB_Click(object sender, ImageClickEventArgs e)
        {


            String RMB_Button = ConfigurationManager.AppSettings["RMB_Button"];
            if (RMB_Button != null && RMB_Button.Trim() == "on")
            {
                Response.Redirect("RMB1/send.aspx" + Request.Url.Query);
            }
            else
            {
                Response.Redirect("RMB/send.aspx" + Request.Url.Query);
            }

        }

        protected void ibtnSZX_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SZX/send.aspx" + Request.Url.Query);
        }
    }
}
