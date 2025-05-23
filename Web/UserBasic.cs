using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pbzx.Web
{
    public partial class UserBasic : System.Web.UI.Page
    {
        public UserBasic()
        {
            Pbzx.BLL.ChangeDB defaultdb = new Pbzx.BLL.ChangeDB();
            this.Load += new EventHandler(this.Basic_Load);
        }

        private void Basic_Load(object sender, System.EventArgs e)
        {
            //¼ì²éÊÇ·ñÒÑµÇÂ¼.
            IsLogin(); // .Admin.IsLogin();
            //DeCodeModule(EnCodeModule());
            // IsAuthority(1);

        }

        /// <summary>
        /// ÅÐ¶ÏÊÇ·ñµÇÂ¼
        /// </summary>
        public static void IsLogin()
        {
            //if (HttpContext.Current.Session["manager_user"] == null || HttpContext.Current.Session["RealPWD"] == null || HttpContext.Current.Session["user_RealInfo"] == null || HttpContext.Current.Session["user_Broker"] == null)
            //{
            //    //if (System.Web.HttpContext.Current.Request.Cookies["cookieBiz"] == null)
            //    //{
            //    HttpContext.Current.Response.Write("<script>alert('ÇëÄúÖØÐÂµÇÂ¼£¡');window.top.location.href='/login.aspx?ReturnURL=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.CurrentExecutionFilePath) + "';</script>");
            //    //}
            //    HttpContext.Current.Response.End();
            //    return;
            //}
        }


    }
}
