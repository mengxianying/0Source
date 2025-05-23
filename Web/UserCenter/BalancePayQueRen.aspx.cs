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
    public partial class BalancePayQueRen : System.Web.UI.Page
    {
        protected string c_order;
        protected decimal c_orderamount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["OrderID"]))
                {
                   
                    if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "2", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                        this.tbZF.Visible = false;
                        this.ibtnBalancePay.Enabled = false;
                        return;
                    }
                    string orderID = Input.FilterAll(Request["OrderID"]);
                    lblOrderID.Text = orderID;
                    string type = "0";
                    type = WebFunc.GetOrderType(orderID);
                    DataSet ds = null;
                    DataRow row = null;
                    Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                    Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(Method.Get_UserName);
                    if (type == "0")
                    {
                        ds = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(orderID);
                        row = ds.Tables[0].Rows[0];
                        if (row["UserName"].ToString() != Method.Get_UserName)
                        {
                            Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "您无权限查看！", 400, "2", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                            this.tbZF.Visible = false;
                            return;
                        }
                        if (userModel.CurrentMoney-userModel.FrozenMoney < Convert.ToDecimal(row["HasNotPayedPrice"]))
                        {
                            Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert("", "您的余额不足，无法余额支付！请先充值，您确定要去充值吗?", 400, "2", "location.href='User_Deposit.aspx';", "", false, false) + "");
                            this.tbZF.Visible = false;
                            this.ibtnBalancePay.Enabled = false;
                            return;
                        }
                        lblOrderMoney.Text ="<font color='red'>"+  Convert.ToDecimal(row["HasNotPayedPrice"]).ToString("0.00")+"</font>" + "元";
                    }
                    else if (type == "1")
                    {
                        //ds = new Pbzx.BLL.PBnet_Orders_Delegates().SelectOrdersByOrderID(orderID);
                        //row = ds.Tables[0].Rows[0];
                        //if (row["UserName"].ToString() != Method.Get_UserName)
                        //{
                        //    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "您无权限查看！", 400, "2", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                        //    this.tbZF.Visible = false;
                        //    return;
                        //}
                        //if (userModel.CurrentMoney < Convert.ToDecimal(row["HasNotPayedPrice"]))
                        //{
                        //    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert("", "您的余额不足，无法余额支付！请先充值，您确定要去充值吗?", 400, "2", "location.href='User_Deposit.aspx';", "", false, false) + "");
                        //    this.tbZF.Visible = false;
                        //    this.ibtnBalancePay.Enabled = false;
                        //    return;
                        //}
                        //lblOrderMoney.Text = Convert.ToDecimal(row["HasNotPayedPrice"]).ToString("0.00") + "元";
                    }
                }
            }
           
        }

        protected void ibtnBalancePay_Click(object sender, ImageClickEventArgs e)
        {
            if (!WebFunc.CheckOrderIsValidate(Input.FilterAll(Request["OrderID"])))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "2", "location.href='/UserCenter/User_Center.aspx';", "", false, false) + "");
                this.ibtnBalancePay.Enabled = false;
                return;
            }
            string orderID = Input.FilterAll(Request["OrderID"]);
            DataSet ds = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(orderID);
            DataRow row = ds.Tables[0].Rows[0];
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(row["UserName"].ToString());
            if (userModel.CurrentMoney - userModel.FrozenMoney < Convert.ToDecimal(row["HasNotPayedPrice"]))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert("", "您的余额不足，无法余额支付！请先充值，您确定要去充值吗?", 400, "2", "location.href='User_Deposit.aspx';", "", false, false) + "");
                this.tbZF.Visible = false;
                this.ibtnBalancePay.Enabled = false;
                return;
            }
            WebFunc.FrozenUserMoney(row["UserName"].ToString(), Math.Round(Convert.ToDecimal(row["HasNotPayedPrice"]),2));
            bool isSuccess = WebFunc.UpdateOrder(orderID, true, row["HasNotPayedPrice"].ToString(), "order@pinble.com", "（自动）", 20, "余额支付");
            if (isSuccess)
            {
                Response.Redirect("BalancePay.aspx?OrderID=" + orderID);
            }
            else
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "支付失败，请与拼搏在线彩神通软件客服联系！", 400, "2", "location.href='/UserCenter/User_Center.aspx';", "", false, false) + "");
                return;
            }
        }
    }
}
