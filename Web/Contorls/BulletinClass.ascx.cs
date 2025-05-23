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
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.Web.Contorls
{
    public partial class BulletinClass : System.Web.UI.UserControl
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
            this.DataList1.DataSource = DbHelperSQL.Query("select top " + WebInit.pageConfig.BulletinTypeCount + " * from PBnet_BulletinType where IntTypeLevel=2 and BitIsAuditing=1 order by IntSortID  ");
            this.DataList1.DataBind();
        }
    }
}