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
    public partial class ViewClass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private int _titleLength;

        public int TitleLength
        {

            get { return _titleLength; }
            set { _titleLength = value; }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_SoftClass MyBLL = new Pbzx.BLL.PBnet_SoftClass();
            this.DataList1.DataSource = MyBLL.GetList(" IntSetting=1 ");
            this.DataList1.DataBind();
        }
    }
}