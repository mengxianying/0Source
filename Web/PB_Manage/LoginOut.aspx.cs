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

namespace Pbzx.Web.PB_Manage
{
    public partial class LoginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpContext.Current.Request.Cookies["AdminManager"].Expires = DateTime.Now.AddMinutes(-1);
            //Response.Write("<script>alert('退出成功！');window.top.location.href='/PB_Manage/AdminLogin.aspx'</script>");
            //return;

            HttpCookie cookieUClass = HttpContext.Current.Request.Cookies["AdminManager"];
            if (cookieUClass != null)
            {
                cookieUClass.Expires = DateTime.Today.AddDays(-10);
                HttpContext.Current.Response.Cookies.Add(cookieUClass);
            }
            Response.Write("<script>alert('退出成功！');window.top.location.href='/PB_Manage/AdminLogin.aspx'</script>");
            return;

        }
    }
}
