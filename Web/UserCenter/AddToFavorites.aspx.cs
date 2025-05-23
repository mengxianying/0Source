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

namespace Pbzx.Web
{
    public partial class AddToFavorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int productID = 0;
            if (int.TryParse(Request["productID"], out productID))
            {
                InsertFavorites(productID);
            }
        }

        private void InsertFavorites(int productID)
        {

            Pbzx.Model.PBnet_Favorites favorites = new Pbzx.Model.PBnet_Favorites();
            favorites.ProductID = productID;
            favorites.UserID = int.Parse(Method.Get_UserID);
            favorites.UserName = Method.Get_UserName;
            favorites.TableName = "PBnet_Product";
            favorites.DateAdded = DateTime.Now;
            int result =  new Pbzx.BLL.PBnet_FavoritesBll().InsertFavorites(favorites);
            if (result > 0)
            {
                Response.Write("<script type='text/javascript'>alert('收藏成功！');top.location='/UserCenter/User_Center.aspx?myUrl=Favorites.aspx';</script>");
                //Page.RegisterStartupScript(WebFunc.GetGuid(), "<script type='text/javascript'>alert('收藏成功！');top.location='/UserCenter/Favorites.aspx';</script>");
                //Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "收藏成功！", 400, "2", "top.location='/UserCenter/Favorites.aspx';", "", false, false) + "");
                //Response.Write(JS.Alert("", ""));
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('该产品已经在您的收藏夹中！');top.location='/UserCenter/User_Center.aspx?myUrl=Favorites.aspx';</script>");
                //Page.RegisterStartupScript(WebFunc.GetGuid(), "<script type='text/javascript'>alert('该产品已经在您的收藏夹中！');top.location='/UserCenter/Favorites.aspx';</script>");
                //Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "该产品已经在您的收藏夹中！", 400, "2","top.location='/UserCenter/Favorites.aspx';","", false, false) + "");
            }            
        }
    }
}
