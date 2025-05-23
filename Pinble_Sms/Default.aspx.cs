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
using Pbzx.BLL;

namespace Pinble_Sms
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Note_WriteBack wbk = new Note_WriteBack();
            Response.Write(wbk.GetList().Tables[0].Rows.Count);
        }
    }
}
