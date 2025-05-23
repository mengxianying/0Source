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

namespace Pbzx.Web.Contorls
{
    public partial class AboutMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClass();
            }
        }
        private void BindClass()
        {
            Pbzx.BLL.PBnet_About AboutBll = new Pbzx.BLL.PBnet_About();
            dlUsMenu.DataSource = AboutBll.GetList(" UsState=1 order by UsOrder asc"); 
            dlUsMenu.DataBind();
        }
        public static string GetLinkTitle(object strTilte, object strUrl, object intnum)
        {
          
            if (strUrl.ToString() != null && strUrl.ToString() != "")
            {
                return "<a href='" + strUrl.ToString() + "'  target='_self' class='Amenu'>" + strTilte + "</a>";
            }
            else
            {
                return "<a href='" + intnum + "'  target='_self' class='Amenu'>" + strTilte + "</a>";

            }
        }
    }
}