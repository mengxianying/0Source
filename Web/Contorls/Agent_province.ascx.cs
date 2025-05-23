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
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web.Contorls
{
    public partial class Agent_province : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.AgentInfo MyBLL = new Pbzx.BLL.AgentInfo();
                if (!String.IsNullOrEmpty(Request["province"]))
                {
                    Method.BindProvince(this.ddlprovince, Input.Decrypt(Input.FilterAll(Request["province"])));
                }
                else
                {
                    Method.BindProvince(this.ddlprovince, "");                    
                }
            }
        }

        protected void ddlprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder("");
            string strprovince=this.ddlprovince.SelectedValue;                       
            string result = Input.Encrypt(strprovince);

            Response.Redirect("/Agent.aspx?province=" + result);
        }
    }
}