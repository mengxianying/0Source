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
    public partial class OrderDetails_EditeRG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["OrderDetailID"]))
                {
                    Pbzx.BLL.PBnet_OrderDetail orderDetail = new Pbzx.BLL.PBnet_OrderDetail();
                    Pbzx.Model.PBnet_OrderDetail orderDetailModel = orderDetail.GetModel(long.Parse(Request["OrderDetailID"]));
                    Pbzx.BLL.PBnet_Product productBll = new Pbzx.BLL.PBnet_Product();
                    Pbzx.Model.PBnet_Product productModel = productBll.GetModel((int)orderDetailModel.ProductID);
                    this.lblProductName.Text = productModel.pb_SoftName;
                    this.lblRegType.Text = Pbzx.Web.WebFunc.CheckRegTye(orderDetailModel.RegType, productModel.pb_TypeName, productModel.pb_DemoUrl, productModel.pb_RegUrl);

                    string regType =orderDetailModel.RegType;
                    string[] strRegType = regType.Split(new char[] { '|' });
                    decimal price = 0;
                    if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                    {
                        string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                        if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                        {
                            price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                        }
                        else
                        {
                            price = decimal.Parse(strRegType[1]);
                        }
                    }             
                    int quatity = 1;
                    decimal totalBookPrice = Convert.ToDecimal(quatity * price);
                    this.lblPrice.Text = totalBookPrice.ToString("0.00") + "元";
                    txtSerial.Text = orderDetailModel.Serial;
                    rblState.SelectedValue = orderDetailModel.State.ToString();
                }
            }
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Serial = Input.FilterAll(this.txtSerial.Text);
            string state = rblState.SelectedValue;
            if (!string.IsNullOrEmpty(Request["OrderDetailID"]))
            {
                Pbzx.BLL.PBnet_OrderDetail orderDetail = new Pbzx.BLL.PBnet_OrderDetail();
                Pbzx.Model.PBnet_OrderDetail orderDetailModel = orderDetail.GetModel(long.Parse(Request["OrderDetailID"]));
                orderDetailModel.Serial = Serial;
                orderDetailModel.State = int.Parse(state);
                orderDetail.Update(orderDetailModel);
                if (state == "1")
                {
                    Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                    Pbzx.Model.PBnet_Orders orderModel = orderBll.GetModel(orderDetailModel.OrderID);
                    orderModel.IsPay = 3;
                    orderBll.Update(orderModel);         
                }
            }
            Response.Write("<script language='javascript'>alert('修改成功！');window.returnValue ='yes';window.close()</script>");
        }
    }
}
