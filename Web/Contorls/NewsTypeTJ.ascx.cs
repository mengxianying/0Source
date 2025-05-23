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
    public partial class NewsTypeTJ : System.Web.UI.UserControl
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

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _intTypeLevel = "";

        public string IntTypeLevel
        {
            get { return _intTypeLevel.Trim(); }
            set { _intTypeLevel = value; }
        }



        private void BindData()
        {
            Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            if (!string.IsNullOrEmpty(IntTypeLevel))
            {
                this.DataList1.DataSource = DbHelperSQL.Query("select  top " + WebInit.pageConfig.NewsTypeCount + "  * from PBnet_NewsType where IntTypeLevel=" + IntTypeLevel + " and BitIsAuditing=1 order by IntSortID  ");


                this.DataList1.DataBind();
            }
            else
            {
                this.DataList1.DataSource = DbHelperSQL.Query("select  top " + WebInit.pageConfig.NewsTypeCount + "  * from PBnet_NewsType where BitIsAuditing=1 order by IntSortID  ");
                //top " + WebInit.pageConfig.NewsTypeCount + " 
                this.DataList1.DataBind();
            }

        }
    }
}