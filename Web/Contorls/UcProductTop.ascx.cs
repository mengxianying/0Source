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
    public partial class UcProductTop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindTop();      
            }
        }
        private void BindTop()
        {
            DataSet dsProduct = DbHelperSQL.Query("select top 4 * from PBnet_Product where  " + Method.product + " and pb_OnTop=1 ");
            this.dlProductTop.DataSource = dsProduct;
            this.dlProductTop.DataBind();
            //dlProductTop
        }
    }
}