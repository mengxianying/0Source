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
using System.IO;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class Create3DGZM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            Response.Expires = 0;  
            string htmlPath = HttpRuntime.AppDomainAppPath + "\\pb_cst.htm";
            if (!File.Exists(htmlPath))
            {
                DirectoryFile.CreateFile(htmlPath);
            }
            Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
        }
    }
}
