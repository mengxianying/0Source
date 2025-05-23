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
    public partial class NewClass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            Pbzx.BLL.PBnet_BulletinType MyBLL = new Pbzx.BLL.PBnet_BulletinType();
            this.RptClass.DataSource = MyBLL.GetAllList();
            this.RptClass.DataBind();
        }
    }
}