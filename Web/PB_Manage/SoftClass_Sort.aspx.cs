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

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftClass_Sort : System.Web.UI.Page
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
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            ObjDCProduct.SelectParameters[0].DefaultValue = Searchstr;
            //Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            //this.ReorderList1.DataSource = productBLL.GetProductListSort(Searchstr);
            //this.ReorderList1.DataBind();   

        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        protected string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //软件名称
            if (!string.IsNullOrEmpty(Request["NvarClassName"]))
            {
                bu.Append(" and NvarClassName like '%" + Request["NvarClassName"].Trim() + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["IntSetting"]))
            {
                bu.Append(" and IntSetting='" + Request["IntSetting"] + "' ");
            }
            else
            {
                bu.Append(" and IntSetting='0' ");
            }

            if (!string.IsNullOrEmpty(Request["BitIsElite"]))
            {
                bu.Append(" and BitIsElite='" + Request["BitIsElite"] + "' ");
            }

            return bu.ToString();

        }

    }
}
