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
    public partial class ModifyOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ViewState["Type"] = "0";
                if (!string.IsNullOrEmpty(Request["type"]))
                {
                    if (Request["type"] == "1")
                    {
                        ViewState["Type"] = "1";
                    }
                }
                AddOrder1._btnAddOrders.Enabled = false;
                AddOrder1._btnAddOrders.Visible = false;
                string orderID = Input.FilterAll(Request["OrderID"]);
                if (!string.IsNullOrEmpty(orderID))
                {
                    //OrderDetail1.BindOrderDetail(orderID);
                   // BindOrderInfo(orderID);
                }
            }
        }

        //private void BindOrderInfo(string orderID)
        //{ 
        //    DataSet ds  = null;
        //    if (ViewState["Type"].ToString() == "0")
        //    {
        //        Pbzx.BLL.PBnet_Orders orderBLL = new Pbzx.BLL.PBnet_Orders();
        //        ds = orderBLL.SelectOrdersByOrderID(orderID);
        //    }
        //    else if (ViewState["Type"].ToString() == "1")
        //    {
        //        Pbzx.BLL.PBnet_Orders_Delegates orderBLL = new Pbzx.BLL.PBnet_Orders_Delegates();
        //        ds = orderBLL.SelectOrdersByOrderID(orderID);
        //    }                  
        //    if (ds == null && ds.Tables[0].Rows.Count == 0)
        //        return;

        //    DataRow dr = ds.Tables[0].Rows[0];

        //    AddOrder1._txtReceiverName.Text = dr["ReceiverName"].ToString();
        //    AddOrder1._txtReceiverAddress.Text = dr["ReceiverAddress"].ToString();
        //    AddOrder1._txtReceiverPhone.Text = dr["ReceiverPhone"].ToString();
        //    AddOrder1._txtReceiverPostalCode.Text = dr["ReceiverPostalCode"].ToString();
        //    if (dr["PortTypeID"].ToString() != "0")
        //    {
        //        AddOrder1._rblPortType.Visible = true;
        //    }
        //    else
        //    {
        //        AddOrder1._rblPortType.Visible = false;
        //    }
        //    AddOrder1._rblPayType.SelectedValue = dr["PayTypeID"].ToString();
        //    AddOrder1._txtReceiverEmail.Text = dr["ReceiverEmail"].ToString();
        //}

        //protected void ModifyOrdersClick(object sender, EventArgs e)
        //{
        //    //User userLogined = UserState.GetUserLogined();
            
        //    Pbzx.Model.PBnet_UserTable userLogined = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
        //    string orderID = Input.FilterAll(Request["OrderID"]);
        //    if (string.IsNullOrEmpty(orderID))
        //        return;

        //    if (ViewState["Type"].ToString() == "0")
        //    {
        //        Pbzx.Model.PBnet_Orders orders = new Pbzx.Model.PBnet_Orders();
        //        orders.UserID = int.Parse(Method.Get_UserID);
        //        orders.UserName = Method.Get_UserName;
        //        orders.OrderID = orderID;
        //        orders.ReceiverName = AddOrder1._txtReceiverName.Text;
        //        orders.ReceiverPostalCode = AddOrder1._txtReceiverPostalCode.Text;
        //        orders.ReceiverPhone = AddOrder1._txtReceiverPhone.Text;
        //        orders.ReceiverAddress = AddOrder1._txtReceiverAddress.Text;
        //        orders.ReceiverEmail = AddOrder1._txtReceiverEmail.Text;

        //        if (AddOrder1._rblPortType.Visible)
        //        {
        //            orders.PortTypeID = 2;
        //            orders.PortTypeName = "¿ìµÝ";
        //        }
        //        else
        //        {
        //            orders.PortTypeID = 0;
        //            orders.PortTypeName = "";
        //        }
        //        orders.PayTypeID = Convert.ToInt32(AddOrder1._rblPayType.SelectedValue);
        //        Pbzx.BLL.PBnet_Orders ordersBll = new Pbzx.BLL.PBnet_Orders();
        //        int result = ordersBll.UpdateOrders(orders);

        //        if (result > 0)
        //        {
        //            Response.Redirect("ShowOrder.aspx?OrderId=" + orderID);
        //        }
        //        else
        //        {
        //            AddOrder1._lblMsg.Text = "ÐÞ¸ÄÊ§°Ü£¡";
        //        }
        //    }
        //    else if (ViewState["Type"].ToString() == "1")
        //    {
        //        Pbzx.Model.PBnet_Orders_Delegates orders = new Pbzx.Model.PBnet_Orders_Delegates();
        //        orders.UserID = int.Parse(Method.Get_UserID);
        //        orders.UserName = Method.Get_UserName;
        //        orders.OrderID = orderID;
        //        orders.ReceiverName = AddOrder1._txtReceiverName.Text;
        //        orders.ReceiverPostalCode = AddOrder1._txtReceiverPostalCode.Text;
        //        orders.ReceiverPhone = AddOrder1._txtReceiverPhone.Text;
        //        orders.ReceiverAddress = AddOrder1._txtReceiverAddress.Text;
        //        orders.ReceiverEmail = AddOrder1._txtReceiverEmail.Text;

        //        if (AddOrder1._rblPortType.Visible)
        //        {
        //            orders.PortTypeID = 2;
        //            orders.PortTypeName = "¿ìµÝ";
        //        }
        //        else
        //        {
        //            orders.PortTypeID = 0;
        //            orders.PortTypeName = "";
        //        }
        //        orders.PayTypeID = Convert.ToInt32(AddOrder1._rblPayType.SelectedValue);
        //        Pbzx.BLL.PBnet_Orders_Delegates ordersBll = new Pbzx.BLL.PBnet_Orders_Delegates();
        //        int result = ordersBll.UpdateOrders(orders);

        //        if (result > 0)
        //        {
        //            Response.Redirect("ShowOrder.aspx?type=1&OrderId=" + orderID);
        //        }
        //        else
        //        {
        //            AddOrder1._lblMsg.Text = "ÐÞ¸ÄÊ§°Ü£¡";
        //        }            
        //    }


        //}
    }
}
