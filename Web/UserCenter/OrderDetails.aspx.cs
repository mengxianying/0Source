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

namespace Pbzx.Web.UserCenter
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string orderID = Input.FilterAll(Request["ID"]);
                if (!string.IsNullOrEmpty(orderID))
                {
                  //  string orderID = Input.FilterAll(Request["ID"]);
                    Pbzx.BLL.PBnet_Orders_Delegates MyBll = new Pbzx.BLL.PBnet_Orders_Delegates();
                    Pbzx.Model.PBnet_Orders_Delegates MyModel = MyBll.GetModel(orderID);
                    if (MyModel.UserName == Method.Get_UserName)
                    {
                        OrderDetail1.BindOrderDetail(orderID);
                        OrderInfo1.BindOrderInfo(orderID);
                    }                
                }
            }
        }
    }
}
