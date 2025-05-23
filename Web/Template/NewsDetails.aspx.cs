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

namespace Pbzx.Web.Template
{
    public partial class NewsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                News_Hot1.Count = int.Parse(WebInit.pageConfig.NewsNewUpdateCount);
                News_Hot2.Count = int.Parse(WebInit.pageConfig.NewsNewHotCount);
            }
        }
    }
}
