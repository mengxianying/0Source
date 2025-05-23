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

namespace Pbzx.Web
{
    public partial class RecoverPasswd2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["name"] == null)
                {
                    Response.Redirect("RecoverPasswd1.aspx");
                }
                if (Session["CheckCode1"] != null && Session["CheckCode1"].ToString() == "true")
                {
                }
                else
                {
                    Response.Redirect("~/PageNoFound.htm");
                }
            }
        }

        protected void imbtAsk_Click(object sender, ImageClickEventArgs e)
        {
           Server.Transfer("RecoverPasswd3.aspx?Type=ask&name=" + Request["name"]);
        }

        protected void imbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("RecoverPasswd3.aspx?Type=email&name=" + Request["name"]);
        }
    }
}
