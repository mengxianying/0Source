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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string aa = "ÄãºÃ°¡£¡";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // this.Label1.Text = "   <ul> <li class='zhong2'>9</li>  <li class='zhong2'>1</li> <li class='zhong2'>3</li> </ul>";
                //Response.Write(HttpContext.Current.Request.Url.PathAndQuery);

            }
        }

    }
}
