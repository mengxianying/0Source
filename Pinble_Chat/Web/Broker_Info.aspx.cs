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
                Response.Write("<script>alert('����û�е�¼��\\r\\n�����ȵ�¼��Ȼ�������룡');history.back(1);</script>");
                return;
            }
            else
            {
                Server.Transfer("Broker_Agrt.aspx");
            }
        }
    }
}
