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
using Pbzx.Common;
using System.Text;
using Pbzx.SQLServerDAL;

namespace Pbzx.Web.UserCenter
{
    public partial class Favorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
              
                Favorites1.BindFavorites(int.Parse(Method.Get_UserID));
            }
        }

        protected void Favorites_RowDeleting(object sender, EventArgs e)
        {
            int returnValue = new Pbzx.BLL.PBnet_FavoritesBll().DeleteFavoritesByID(Favorites1.FavoritesID);
            Favorites1.BindFavorites(int.Parse(Method.Get_UserID));
        }
        private void BindData()
        {
          //  Pbzx.SQLServerDAL.PBnet_Product MyDal = new Pbzx.SQLServerDAL.PBnet_Product(); 

            Pbzx.BLL.PBnet_Product MyBLL = new Pbzx.BLL.PBnet_Product();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");

            bu.Append(" and  pb_Elite=1 and " + Method.product + " ");
            this.dtcommend.DataSource = MyBLL.GetList(8, bu.ToString(), "countid");
            this.dtcommend.DataBind();          
        }

        protected void btnAddProduct_Command(object sender, CommandEventArgs e)
        {
            int productID = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("AddToFavorites.aspx?productID="+productID);
        }
    }
}
