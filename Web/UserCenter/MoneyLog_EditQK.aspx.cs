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
    public partial class MoneyLog_EditQK : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string orderID = Input.FilterAll(Request["OrderID"]);

                if (!string.IsNullOrEmpty(orderID))
                {

                    Pbzx.BLL.PBnet_Charge MyBll = new Pbzx.BLL.PBnet_Charge();
                    Pbzx.Model.PBnet_Charge MyModel = MyBll.GetModelByOrderId(orderID);
                    if (MyModel.UserName != Method.Get_UserName)
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "您没有权限查看该订单！", 500, "1", "window.close();", "", false, false));
                        return;
                    }

                    if (MyModel.IsCancel ==1 || MyModel.IsCancel ==2)
                    {
                        tbFinish.Visible = false;
                        this.tbCancel.Visible = true;
                    }
                    else if (MyModel.State == 1)
                    {
                        tbFinish.Visible = true;
                        this.tbCancel.Visible = false;
                    }
                    else
                    {
                        tbFinish.Visible = false;
                        tbCancel.Visible = false;
                    }

                    lblOrderID.Text = MyModel.OrderID;
                    lblState.Text = MyBll.GetState(MyModel.State,MyModel.IsCancel);                    
                    if (MyModel.IsCancel ==1)
                    {
                        lblState.Text = "用户取消";
                    }
                    else if (MyModel.IsCancel == 2)
                    {
                        lblState.Text = "系统取消";
                    }
                    lblOrderDate.Text = MyModel.OrderDate.ToString();
                    lblRealName.Text = MyModel.RealName;
                    lblPayMoney.Text = string.Format("{0:C2}",Convert.ToDecimal(MyModel.PayMoney));                    
                    lblPayNum.Text = MyModel.PayNum;
                    //lblUpdateStaticDate.Text = MyModel.UpdateStaticDate.ToString();
                    lblResult.Text = MyModel.Result;
                    if(string.IsNullOrEmpty(MyModel.Result))
                    {
                        this.lblResult.Text = "等待处理";
                    }
                    if (MyModel.IsCancel == 1)
                    {
                        lblResult.Text = "订单已经被用户取消";
                    }
                    else if (MyModel.IsCancel == 2)
                    {
                        lblResult.Text = "订单已经被系统自动取消";
                    }
                }
            }

        }


        protected void ibtnHasPay_Click(object sender, ImageClickEventArgs e)
        {
            string orderID = Input.FilterAll(Request["OrderID"]);
            Pbzx.BLL.PBnet_Charge MyBll = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge MyModel = MyBll.GetModelByOrderId(orderID);          
            if (MyModel.IsPay == 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", "您的取款申请已提交过，无需重复提交！<br/>请耐心等待客服审核！", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                return;
            }
            MyModel.IsPay = 1;
            if (MyBll.Update(MyModel))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "您的汇款确认已提交，请等待客服审核！", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                return;
            }
            else
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "提交失败！请与拼搏在线彩神通软件客服联系！", 500, "1", "", "", false, false));
            }
        }

    }
}
