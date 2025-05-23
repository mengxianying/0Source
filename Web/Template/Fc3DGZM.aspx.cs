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
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.Web.Template
{
    public partial class Fc3DGZM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.Expires = 0;
            if (!Page.IsPostBack)
            {
                //       BindZiMenu();
            }
        }

        public string Fmt(object obj)
        {
            if (obj != null)
            {
                if (obj.ToString().Contains("*"))
                {
                    return "<td bgcolor='#C1FFE4'>" + obj.ToString() + "</td>";
                }

            }
            return "<td bgcolor='#FFFFFF'>" + obj.ToString() + "</td>";
        }
    }
}
