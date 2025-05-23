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
    public partial class BalancePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["OrderID"]))
                {
                    string orderID = Input.FilterAll(Request["OrderID"]);
                    this.lblOrderID.Text = orderID;
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
                            tbZF.Visible = false;
                            Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "您无权限查看！", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                            return;
                        }
                    }
                    //else if (type == "1")
                    //{
                    //    ds = new Pbzx.BLL.PBnet_Orders_Delegates().SelectOrdersByOrderID(orderID);
                    //    row = ds.Tables[0].Rows[0];
                    //    if (row["UserName"].ToString() != Method.Get_UserName)
                    //    {
                    //        tbZF.Visible = false;
                    //        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "您无权限查看！", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                    //        return;
                    //    }
                    //}
                    bool isSuccess = row["TipName"].ToString().Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.已付款));
                    if (isSuccess)
                    {
                        this.dvSuccess.Visible = true;
                        this.dvFail.Visible = false;
                    }
                    else
                    {
                        this.dvFail.Visible = true;
                        this.dvSuccess.Visible = false;
                    }
                }

            }
        }        
    }
}
