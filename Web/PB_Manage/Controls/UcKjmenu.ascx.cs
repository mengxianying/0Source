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
using System.Collections.Generic;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcKjmenu : System.Web.UI.UserControl
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
            Pbzx.BLL.PBnet_LotteryMenu LotteryMenuBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            // List<Pbzx.Model.PBnet_LotteryMenu> ls = LotteryMenuBLL.GetLisBySql("select IntId,NvarName,NvarClass 1=1  group by NvarClass order by min(IntId)");
            DataTable dt = LotteryMenuBLL.GetLisBySql("select NvarClass from PBnet_LotteryMenu where 1=1  group by NvarClass order by min(IntId)");
            this.rptCpBigSort.DataSource = dt;
            this.rptCpBigSort.DataBind();
        }

        protected void rptCpBigSort_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //ÄÚ²ãdatalist°ó¶¨
                DataList dlCp2 = (DataList)e.Item.FindControl("dlCpSort");
                //((DataList)(((DataList)sender).NamingContainer)).Item.FindControl(""); 
                string strClass = ((Label)e.Item.FindControl("lblClass")).Text;
                Pbzx.BLL.PBnet_LotteryMenu LotteryMenuBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                List<Pbzx.Model.PBnet_LotteryMenu> ls = LotteryMenuBLL.DataTableToList(LotteryMenuBLL.GetList(" NvarClass='" + strClass + "'").Tables[0]);
                dlCp2.DataSource = ls;
                dlCp2.DataBind();
            }

        }
    }
}