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
    public partial class Reg1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Request.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); 
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); 
                Response.CacheControl = "no-cache";
                Response.Expires = 0;
                //¥¶¿Ì¡ƒ≤  “
                if (Request["name_pwd"] != null)
                {
                    Response.Clear();
                    LoginSort login = new LoginSort();
                    if (!login["manager_user"] || Method.Get_UserPwd == "0")
                    {
                        Response.Write("var NamePWD='';");
                        //Response.End();
                        //Response.Redirect("/Login.aspx");
                    }
                    else
                    {
                        Response.Write("var NamePWD='" + Server.UrlEncode(Method.Get_UserName.ToLower() + "|" + Method.Get_UserPwd) + "';");
                    }
                    Response.End();
                }
            }
        }
    }
}
