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
using System.Text;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcDelegateOrderSearch : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                BindList();

                Pbzx.BLL.PBnet_PayType PlayBll = new Pbzx.BLL.PBnet_PayType();
                PlayBll.BindPlayType(ddlPayType);
                if (!string.IsNullOrEmpty(Request["Error"]))
                {
                    this.chbError.Checked = true;
                }
                else
                {
                    this.chbError.Checked = false;
                }
                Method.BindDdlOrRadio(this.rblIsPay, "IsPay", true);
                Method.BindDdlOrRadio(this.rblOrderType, "Type", true);
                Method.BindText(this.txtOrderID, "strOrderID", true);
                Method.BindText(this.txtBbsName, "strBbsName", true);
                Method.BindText(txtUsername, "strUsername", true);
                Method.BindDdlOrRadio(this.ddlPayType, "payType", true);
                Method.BindDdlOrRadio(this.rblIsCancal, "IsCancal", true);
                Method.BindDdlOrRadio(this.rblOrderState, "tipID", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        private void BindList()
        {
            //绑定订单状态
            //Method.BindOrderStaticTip(ddlTipName);
            //this.ddlTipName.Items.Insert(0, new ListItem("所有", ""));
            //this.ddlTipName.Items[0].Selected = true;
            ////绑定付款方式
            //Pbzx.BLL.PBnet_PayType payTypeBll = new Pbzx.BLL.PBnet_PayType();
            //this.ddlPayType.DataSource = payTypeBll.GetList(" 1=1 order by OrderID");
            //this.ddlPayType.DataTextField = "PayTypeName";
            //this.ddlPayType.DataValueField = "PayTypeID";
            //this.ddlPayType.DataBind();
            //this.ddlPayType.Items.Insert(0, new ListItem("所有",""));
            //this.ddlPayType.Items[0].Selected = true;
            ////绑定软件版本类别
            //Pbzx.Common.Method.BindProductVersionByEnum(ref this.ddlSoftVersion);
            //this.ddlSoftVersion.Items.Insert(0, new ListItem("所有", ""));
            //this.ddlSoftVersion.Items[0].Selected = true;            
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder("");
            if (this.chbError.Checked)
            {
                bu.Append("&Error=1");
            }
            bu.Append(Method.BindDdlOrRadio(this.rblIsPay, "IsPay", false));
            bu.Append(Method.BindDdlOrRadio(this.rblOrderType, "Type", false));
            bu.Append(Method.BindText(this.txtOrderID, "strOrderID", false));
            bu.Append(Method.BindText(txtUsername, "strUsername", false));
            bu.Append(Method.BindText(this.txtBbsName, "strBbsName", false));
            bu.Append(Method.BindDdlOrRadio(this.rblIsCancal, "IsCancal", false));
            bu.Append(Method.BindDdlOrRadio(this.rblOrderState, "tipID", false));

            bu.Append(Method.BindDdlOrRadio(this.ddlPayType, "payType", false));

            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            Response.Redirect("DelegateOrders.aspx?" + bu.ToString());
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("DelegateOrders.aspx");
        }
    }
}