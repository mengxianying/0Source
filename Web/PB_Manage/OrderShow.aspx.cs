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

namespace Pbzx.Web.PB_Manage
{
    public partial class OrderShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderID = Input.FilterAll(Request["ID"]);
               
                if (!string.IsNullOrEmpty(orderID))
                {
                    ViewState["Type"] = WebFunc.GetOrderType(orderID);
                    if (ViewState["Type"].ToString() == "1")
                    {
                        Pbzx.BLL.PBnet_Orders_Delegates orderBll = new Pbzx.BLL.PBnet_Orders_Delegates();
                        Pbzx.Model.PBnet_Orders_Delegates orderModel = orderBll.GetModel(orderID);
                        if (orderModel == null)
                        {
                            Response.Write("<script type='text/javascript'>alert('订单号错误!');location.href='User_Center.aspx';</script>");
                            return;
                        }
                            this.lblHasPayedPrice.Text = string.Format("{0:f}", orderModel.HasPayedPrice) + "元";
                            this.lblOrderDate.Text = orderModel.OrderDate.ToString();
                            this.lblOrderID.Text = orderModel.OrderID;
                            this.lblPayTypeName.Text = orderModel.PayTypeName;
                            this.lblPortPrice.Text = orderModel.PortPrice.ToString();
                            this.lblReceiverAddress.Text = orderModel.ReceiverAddress;
                            this.lblReceiverEmail.Text = orderModel.ReceiverEmail;
                            this.lblReceiverName.Text = orderModel.ReceiverName;
                            this.lblReceiverPhone.Text = orderModel.ReceiverPhone;
                            this.lblPortPrice.Text = orderModel.ReceiverPostalCode;
                            this.lblTotalProductPrice.Text = string.Format("{0:f}", orderModel.TotalProductPrice) + "元";
                            this.lblUpdateStaticDate.Text = orderModel.UpdateStaticDate.ToString();
                            this.lblUserName.Text = orderModel.UserName;
                            this.lblTipName.Text = orderModel.TipName;
                            this.lblProductPrice.Text = string.Format("{0:f}", orderModel.TotalProductPrice) + "元";
                            this.lblPort.Text = string.Format("{0:f}", orderModel.PortPrice) + "元";
                            this.lblTotal.Text = string.Format("{0:f}", orderModel.TotalProductPrice + orderModel.PortPrice) + "元";
                            this.lblHasPay.Text = this.lblHasPayedPrice.Text;
                            this.lblNoPay.Text = string.Format("{0:f}", orderModel.TotalProductPrice + orderModel.PortPrice - orderModel.HasPayedPrice) + "元";
                    }
                    else if (ViewState["Type"].ToString() == "0")
                    {
                        Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                        Pbzx.Model.PBnet_Orders orderModel = orderBll.GetModel(orderID);
                        if (orderModel == null)
                        {
                            Response.Write("<script type='text/javascript'>alert('订单号错误!');location.href='User_Center.aspx';</script>");
                            return;
                        }
                            this.lblHasPayedPrice.Text = string.Format("{0:f}", orderModel.HasPayedPrice) + "元";
                            this.lblOrderDate.Text = orderModel.OrderDate.ToString();
                            this.lblOrderID.Text = orderModel.OrderID;
                            this.lblPayTypeName.Text = orderModel.PayTypeName;
                            this.lblPortPrice.Text = orderModel.PortPrice.ToString();
                            this.lblReceiverAddress.Text = orderModel.ReceiverAddress;
                            this.lblReceiverEmail.Text = orderModel.ReceiverEmail;
                            this.lblReceiverName.Text = orderModel.ReceiverName;
                            this.lblReceiverPhone.Text = orderModel.ReceiverPhone;
                            this.lblPortPrice.Text = orderModel.ReceiverPostalCode;
                            this.lblTotalProductPrice.Text = string.Format("{0:f}", orderModel.TotalProductPrice) + "元";
                            this.lblUpdateStaticDate.Text = orderModel.UpdateStaticDate.ToString();
                            this.lblUserName.Text = orderModel.UserName;
                            this.lblTipName.Text = orderModel.TipName;
                            this.lblProductPrice.Text = string.Format("{0:f}", orderModel.TotalProductPrice) + "元";
                            this.lblPort.Text = string.Format("{0:f}", orderModel.PortPrice) + "元";
                            this.lblTotal.Text = string.Format("{0:f}", orderModel.TotalProductPrice + orderModel.PortPrice) + "元";
                            this.lblHasPay.Text = this.lblHasPayedPrice.Text;
                            this.lblNoPay.Text = string.Format("{0:f}", orderModel.TotalProductPrice + orderModel.PortPrice - orderModel.HasPayedPrice) + "元";
                    }

                }
            }
        }
    }
}
