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
    public partial class hetong : System.Web.UI.Page
    {
        public string strDown = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.AgentAgree AgentBll = new Pbzx.BLL.AgentAgree();
                Pbzx.Model.AgentAgree AgentModel = AgentBll.GetModelName("协议合同");

                lbltitle.Text = AgentModel.Title;
                lblContent.Text = AgentModel.Content;
                strDown = AgentModel.AgreeUrl;

            }
        }
    }
}
