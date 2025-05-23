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
    public partial class Broker_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void ibtnApply1_Click(object sender, ImageClickEventArgs e)
        {
            if (Pbzx.Common.Method.Get_UserName == "0")
            {
                Response.Write("<script>alert('您还没有登录！\\r\\n请您先登录，然后再申请！');history.back(1);</script>");
                return;
            }
            else
            {
                Server.Transfer("Broker_Agrt.aspx");
            }
        }
    }
}
