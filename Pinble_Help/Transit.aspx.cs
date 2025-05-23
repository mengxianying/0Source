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

namespace Pinble_Help
{
    public partial class Transit : System.Web.UI.Page
    {
        Pbzx.BLL.Help_Contrast get_con = new Pbzx.BLL.Help_Contrast();
        Pbzx.BLL.Help_HelpName get_help = new Pbzx.BLL.Help_HelpName();
        Pbzx.BLL.CstSoftware get_software = new Pbzx.BLL.CstSoftware();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    string id = Request["id"].ToString();
                    DataSet dsContrast = get_con.GetList("Ct_software=" + "'" + id + "'");
                    if (dsContrast != null && dsContrast.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsSoftware = get_software.GetList("CstID=" + Convert.ToInt32(id));
                        if (dsContrast != null && dsContrast.Tables[0].Rows.Count > 0)
                        {
                            DataSet dsHelp = get_help.GetList("Hn_ID=" + Convert.ToInt32(dsContrast.Tables[0].Rows[0]["Ct_TreeNum"]) + " and Hn_Open=1");
                            string url = "Help.htm?id=" + dsContrast.Tables[0].Rows[0]["Ct_TreeNum"].ToString() + "&name=" + dsSoftware.Tables[0].Rows[0]["CstName"].ToString() + "&helpName=" + dsHelp.Tables[0].Rows[0]["Hn_name"].ToString();

                            Response.Write("<script>window.location.href='" + url + "'</script>");

                        }
                        else
                        {

                            return;
                        }
                    }
                    else
                    {
                        Response.Write("<script>window.location.href='http://help.pinble.com'</script>");
                        Response.End();
                    }           
                }                
            }
                
        }
    }
}
