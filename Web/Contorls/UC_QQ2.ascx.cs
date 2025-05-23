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

namespace Pbzx.Web.Contorls
{
    public partial class UC_QQ2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindQQ();
            }
        }
        private void BindQQ()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1");
            sb.Append(" and BitIsAuditing=1");
            sb.Append(" and IntDisplayPosition=0");
            Pbzx.BLL.PBnet_QQ QqBll = new Pbzx.BLL.PBnet_QQ();
            this.dtQq.DataSource = QqBll.GetList(sb.ToString());
            this.dtQq.DataBind();
        }
    }
}