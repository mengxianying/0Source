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

namespace Pinble_Ask.Contorls
{
    public partial class UcAskHead : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                          
              //  dvLogin.Attributes.Add("onclick", "window.top.location.href='http://www.pinble2.com/login.aspx?ReturnURL=" + Server.UrlEncode("http://Ask.pinble2.com" + HttpContext.Current.Request.Url.PathAndQuery) + "';");
                //dvReg.Attributes.Add("onclick", "window.top.location.href='http://www.pinble2.com/Register.aspx?ReturnURL=" + Server.UrlEncode("http://Ask.pinble2.com" + HttpContext.Current.Request.Url.PathAndQuery) + "';");
            }
        }
    }
}