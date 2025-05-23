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
    public partial class BankTransfer : System.Web.UI.Page
    {
        protected string c_order = "";
        protected decimal c_orderamount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {      
            if (!string.IsNullOrEmpty(Request["OrderID"]))
            {
                DataSet  ds = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(Input.FilterAll(Request["OrderID"]));
                DataRow row = null;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {                    
                    row = ds.Tables[0].Rows[0];
                    if (row["UserName"].ToString() != Method.Get_UserName)
                    {
                        tbZF.Visible = false;
                        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "您无权限查看！", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                        return;
                    }
                    c_order = row["OrderID"].ToString();
                    if (!WebFunc.CheckOrderIsValidate(c_order))
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                        this.tbZF.Visible = false;
                    }

                    c_orderamount = Convert.ToDecimal(row["HasNotPayedPrice"]);
                    this.lblMoney.Text = String.Format("{0:C2}",c_orderamount + Convert.ToDecimal(Method.Number(1))/10) ;

                    int PayTypeID = Convert.ToInt32(row["PayTypeID"]);
                    Pbzx.BLL.PBnet_PayType paytypeBll = new Pbzx.BLL.PBnet_PayType();
                    string paytypeName = paytypeBll.GetModel(PayTypeID).PayTypeName;                
                }
                else
                {
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "对不起！订单错误！", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                    this.tbZF.Visible = false;

                    return;
                }
            }
            else
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "对不起！订单错误！", 400, "1", "top.location='/UserCenter/User_Center.aspx';", "", false, false) + "");
                this.tbZF.Visible = false;

                return;        
            }
        }


        //protected void img_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (ViewState["Type"].ToString() == "0")
        //    {
        //        //Response.Redirect("detailsorder.aspx?OrderID=" + Input.FilterAll(Request["OrderID"]),true);
        //        Response.Redirect("User_Center.aspx?myUrl=OrderList.aspx");
        //    }
        //    else if (ViewState["Type"].ToString() == "1")
        //    {
        //        Response.Redirect("User_Center.aspx?myUrl=Delegate.aspx");
        //    }           
        //}

    }
}
