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

namespace Pbzx.Web.PB_Manage
{
    public partial class NewsType_Sort : System.Web.UI.Page
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
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            ObjDCProduct.SelectParameters[0].DefaultValue = Searchstr;
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["IntSiteName"]))
            {
                bu1.Append(" and IntSiteName like '%" + Input.FilterAll(Request["IntSiteName"].Trim()) + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["IntLinkType"]))
            {
                bu1.Append(" and IntLinkType='" + Request["IntLinkType"] + "' ");
            }


            if (!string.IsNullOrEmpty(Request["BitIsOK"]))
            {
                bu1.Append(" and BitIsOK='" + Request["BitIsOK"] + "' ");
            }
            return bu1.ToString();
        }


        protected void lbtnUpdateNews_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("新闻资讯");
        }
    }
}
