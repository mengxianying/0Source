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

namespace Pbzx.Web
{
    public partial class RecoverJYPasswd1 : System.Web.UI.Page
    {
        public string strName = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              
                                           
            }
        }

        protected void imbtAsk_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("RecoverJYPasswd2.aspx?Type=ask");
        }

        protected void imbtEmail_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("RecoverJYPasswd2.aspx?Type=email");
        }
    }
}
