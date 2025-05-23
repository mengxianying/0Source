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

namespace Pbzx.Web.Contorls
{
    public partial class OtherSoft2 : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            this.DataList1.DataSource = MyBLL.GetSoftPic(4);
            this.DataList1.DataBind();
        }

    }
}