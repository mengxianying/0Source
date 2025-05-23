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
    public partial class BankTransferCZ : System.Web.UI.Page
    {
        protected string c_order = "";
        protected decimal c_orderamount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["Type"] = "0";
            if (!string.IsNullOrEmpty(Request["OrderID"]))
            {
                ViewState["Type"] = WebFunc.GetOrderType(Input.FilterAll(Request["OrderID"]));                
                DataTable dtOrder =  WebFunc.GetDsOrder(Request["OrderID"]);
                DataRow row = null;
                if (dtOrder != null)
                {
                    row = dtOrder.Rows[0];
                    if (row["UserName"].ToString() != Method.Get_UserName)
                    {
                        Response.Write("<script type='text/javascript'>alert('您无权限查看！');location.href='User_Center.aspx';</script>");
                        return;
                    }
                    c_order = row["OrderID"].ToString();
                    if (!WebFunc.CheckOrderIsValidate(c_order))
                    {
                        Response.Write("<script>alert('对不起！该订单已取消或者已失效！');history.go(-1);</script>");
                        return;
                    }
                    c_orderamount = Convert.ToDecimal(row["PayMoney"]) - Convert.ToDecimal(row["HasPayedPrice"]);
                    this.lblMoney.Text = String.Format("{0:C2}", c_orderamount + Convert.ToDecimal(Method.Number(1)) / 10);

                    int PayTypeID = Convert.ToInt32(row["PayTypeID"]);
                    Pbzx.BLL.PBnet_PayType paytypeBll = new Pbzx.BLL.PBnet_PayType();
                    string paytypeName = paytypeBll.GetModel(PayTypeID).PayTypeName;
                }
                else
                {
                    Response.Write("<script>alert('对不起！订单错误！');location.href='User_Center.aspx';</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('对不起！订单错误！');location.href='User_Center.aspx';</script>");
                return;
            }
        }

        //protected void img_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("User_Center.aspx?myUrl=Money_Log.aspx");
        //}
    }
}
