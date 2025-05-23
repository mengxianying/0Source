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
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class AspLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string IsLogin = Input.FilterAll(Request["IsLogin"]);
                if (!string.IsNullOrEmpty(IsLogin) && Convert.ToBoolean(IsLogin))
                {

                    string uName = Input.FilterAll(Request["uName"]);
                    string uPWD = Input.Decrypt(Input.FilterAll(Request["pwd"]));
                    string state = Input.FilterAll("uTime");
                    if (!string.IsNullOrEmpty(uName) && !string.IsNullOrEmpty(uPWD) && !string.IsNullOrEmpty(state))
                    {
                        Response.Write("<FORM name='bbsSubmit' METHOD=POST ACTION='login.asp?action=chk' >");
                        Response.Write("<input type='hidden' name='username' value='" + uName + "'  />");
                        Response.Write("<input type='hidden' name='password' value='" + uPWD + "'  />");
                        Response.Write("<input type='hidden' name='CookieDate' value='" + state + "'  />");
                        Response.Write("</form>");
                        Response.Write("<script>");
                        Response.Write("document.bbsSubmit.submit()");
                        Response.Write("</script>");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(IsLogin) && !Convert.ToBoolean(IsLogin))
                    {
                        Server.Execute("http://bbs1.pinble.com/logout.asp");
                    }
                }
            }
        }
    }
}
