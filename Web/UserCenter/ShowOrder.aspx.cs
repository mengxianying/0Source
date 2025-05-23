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
    public partial class ShowOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                string orderID = Input.FilterAll(Request["OrderID"]);
                string toEmail = Input.FilterAll(Request["ToEmail"]);
                ViewState["Type"] = "0";
                ViewState["Type"] = WebFunc.GetOrderType(orderID);
                if (!string.IsNullOrEmpty(orderID))
                {
                    DataRow Order = null;
                    if( ViewState["Type"].ToString() == "0")
                    {
                        Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                        Order = orderBll.SelectOrdersByOrderID(orderID).Tables[0].Rows[0];

                        if (Order["TipName"].ToString().Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.已付款)))
                        {
                            this.btnPay.Visible = false;
                        }
                        else
                        {
                            this.btnPay.Visible = true;
                        }
                    }
                    else if (ViewState["Type"].ToString() == "1")
                    {
                        Pbzx.BLL.PBnet_Orders_Delegates orderBll = new Pbzx.BLL.PBnet_Orders_Delegates();
                        Order = orderBll.SelectOrdersByOrderID(orderID).Tables[0].Rows[0];
                        DataSet dsOrderStatic = orderBll.SelectOrderStaticByOrderID(orderID);
                        if (Order["TipName"].ToString().Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.已付款)))
                        {
                            this.btnPay.Visible = false;
                        }
                        else
                        {
                            this.btnPay.Visible = true;
                        }
                    }
                        
                    if (Order["UserName"].ToString() != Method.Get_UserName)
                    {
                        Response.Write("<script type='text/javascript'>alert('您无权限操作该笔交易!');location.href='User_Center.aspx';</script>");
                        return;
                    }
                    if (ViewState["Type"].ToString() == "0")
                    {
                        //经纪人
                        if (string.IsNullOrEmpty(Order["BrokerName"].ToString()))
                        {
                            this.tbBroker.Visible = false;
                        }
                        else
                        {
                            this.tbBroker.Visible = true;
                            lblBroker.Text = Order["BrokerName"].ToString();
                        }
                    }
                    //邮费
                    if (Order["PortTypeID"].ToString() == "0")
                    {
                        this.OrderInfo1.DisPortType = false;
                    }
                    else
                    {
                        this.OrderInfo1.DisPortType = true;
                    }
                    if (toEmail.Length > 0)
                    {
                        lblToEmailMsg.Text += toEmail;
                        lblToEmailMsg.Visible = true;
                    }
                    else
                    {
                        lblToEmailMsg.Visible = false;
                    }


                    OrderDetail1.BindOrderDetail(orderID);

                    OrderInfo1.BindOrderInfo(orderID);

                 //   PageHelper.SetSession(SessionName.HasNotPayedPrice, OrderInfo1.HasNotPayedPrice);
                }
            }
        }

        //付款
        protected void btnPay_Click(object sender, EventArgs e)
        {
            string orderID = Input.FilterAll(Request["OrderID"]);
            DataRow Order = null;
            if (ViewState["Type"].ToString() == "0")
            {
                Order = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(orderID).Tables[0].Rows[0];
            }
            else if (ViewState["Type"].ToString() == "1")
            {
                Order = new Pbzx.BLL.PBnet_Orders_Delegates().SelectOrdersByOrderID(orderID).Tables[0].Rows[0];
            }
            Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
            Pbzx.Model.PBnet_PayType payTypeModel = payTypeBll.GetModel(Convert.ToInt32(Order["PayTypeID"]));
            if (!string.IsNullOrEmpty(payTypeModel.SelectAddress))
            {
                Response.Redirect(payTypeModel.SelectAddress + "?type=" + ViewState["Type"].ToString() + "&OrderID=" + Input.FilterAll(Request["OrderID"]));           
            }          
        }
    }
}
