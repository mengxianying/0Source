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

namespace Pbzx.Web
{
    public partial class zhengce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.AgentAgree AgentBll = new Pbzx.BLL.AgentAgree();
                Pbzx.Model.AgentAgree AgentModel = AgentBll.GetModelName("经销政策");

                lbltitle.Text = AgentModel.Title;
                lblContent.Text = AgentModel.Content;

            }
        }
    }
}
