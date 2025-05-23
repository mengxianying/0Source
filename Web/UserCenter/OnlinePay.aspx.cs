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
    public partial class OnlinePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
                {
                    Response.Write(JS.Alert("对不起！该订单已取消或者已失效！"));
                    return;
                }
                ViewState["Type"] = WebFunc.GetOrderType(Input.FilterAll(Request["OrderID"]));
                DataTable dt1 = WebFunc.GetDsOrder(Input.FilterAll(Request["OrderID"]));
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    DataRow row = dt1.Rows[0];
                    if (row["UserName"].ToString() != Method.Get_UserName)
                    {
                        Response.Write("<script type='text/javascript'>alert('您无权限查看！');location.href='User_Center.aspx';</script>");
                        return;
                    }
                    else
                    {
                        this.lblOrderID.Text = row["OrderID"].ToString();
                        decimal totalPrice = 0.00M;
                        if (dt1.TableName == "PBnet_Charge")
                        {
                            totalPrice = Convert.ToDecimal(row["PayMoney"]) - Convert.ToDecimal(row["HasPayedPrice"]);
                        }
                        else if (dt1.TableName == "PBnet_Orders" || dt1.TableName == "PBnet_Orders_Delegates")
                        {
                            totalPrice = Convert.ToDecimal(row["TotalProductPrice"]) + Convert.ToDecimal(row["PortPrice"]) - Convert.ToDecimal(row["HasPayedPrice"]);
                        }

                        
                        this.lblMoneyPay.Text = totalPrice.ToString("0.00");
                    }
                }
            }
        }

        protected void imgYunWang_Click(object sender, ImageClickEventArgs e)
        {
            if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
            {
                Response.Write(JS.Alert("对不起！该订单已取消或者已失效！"));
                return;
            }
            Response.Redirect("/YunWangCncard/SendOrder.aspx?OrderID=" + Input.FilterAll(Request["OrderID"]),true);
        }

        protected void ibtnChinaBank_Click(object sender, ImageClickEventArgs e)
        {
            if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
            {
                Response.Write(JS.Alert("对不起！该订单已取消或者已失效！"));
                return;
            }
            Response.Redirect("/jdPay/PayStartForm1.aspx?OrderID=" + Input.FilterAll(Request["OrderID"]), true);
        }

        //protected void ibtn99Bill_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
        //    {
        //        Response.Write(JS.Alert("对不起！该订单已取消或者已失效！"));
        //        return;
        //    }
        //    Response.Redirect("/99bill/Send.aspx?OrderID=" + Input.FilterAll(Request["OrderID"]), true);
        //}

        protected void ibtnAlipay_Click(object sender, ImageClickEventArgs e)
        {
            if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
            {
                Response.Write(JS.Alert("对不起！该订单已取消或者已失效！"));
                return;
            }
            Response.Redirect("/Alipay/Default.aspx?OrderID=" + Input.FilterAll(Request["OrderID"]), true);
        }
       
    }
}
