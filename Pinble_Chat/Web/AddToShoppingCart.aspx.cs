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
    public partial class AddToShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int productID = 0;

            if (!int.TryParse(Input.FilterAll(Request["productID"]), out productID))
                return;

            InsertShoppingCart(productID);
        }

        #region 加入购物车
        private void InsertShoppingCart(int productID)
        {
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            Pbzx.Model.PBnet_Product productModel  = productBLL.GetModel(productID);
            string danjPrice = productModel.pb_DemoUrl;
            string zongsPrice = productModel.pb_RegUrl;

            if(productModel.pb_TypeName =="出票系统")
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示", "出票系统暂不支持网上购买，如有需要请与拼搏在线客服联系！<br/>", 400, "1", "history.go(-1);", "", false, false) + "");
                return ; 
            }
            if (productModel.pb_TypeName == "专业版")
            {
                if (!CheckIsFree(danjPrice) && !CheckIsFree(zongsPrice))
                {
                    return;
                }
            }
            else
            {
                if (!CheckIsFree(danjPrice) && !CheckIsFree(zongsPrice))
                {
                    return;
                }
            }
           
            string cartGuid = Method.GetCartGuid();
            Pbzx.Model.PBnet_ShoppingCart shoppingCart = new Pbzx.Model.PBnet_ShoppingCart();
            shoppingCart.ProductID = productID;
            shoppingCart.CartGuid = cartGuid;
            shoppingCart.Quatity = 1;
            shoppingCart.RegType = "";

            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.InsertShoppingCart(shoppingCart);

            Response.Redirect("~/ShowShoppingCart.aspx");
        }
        #endregion
        private bool CheckIsFree(string strPrice)
        {
            int index1 = strPrice.IndexOf("元");
            if (index1 < 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "此软件免费，无需购买！", 400, "1", "history.go(-1);", "", false, false) + "");
                return false;
            }
            string intPrice = strPrice.Remove(index1);
            decimal p = 0;
            if (decimal.TryParse(intPrice, out p))
            {
                if(p == 0)
                {
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "此软件免费，无需购买！", 400, "1", "history.go(-1);", "", false, false) + "");                    
                    return false; 
                }
            }
            else
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "此软件免费，无需购买！", 400, "1", "history.go(-1);", "", false, false) + "");

                return false; 
            }

            return true;
        }
    }
}
