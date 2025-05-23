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

namespace Pbzx.Web.UserCenter.Contorls
{
    public partial class UcDelegate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                //°ó¶¨¶©µ¥×´Ì¬
                Method.BindOrderState(ref this.ddlTipName);
                if (!string.IsNullOrEmpty(Request["strOrderID"]))
                {
                    this.txtOrderID.Text = Input.FilterAll(Request["strOrderID"]);
                }
                Method.BindText(txtOrderID, "strOrderID", true);
                Method.BindText(txtReceiverName, "strReceiverName", true);
                Method.BindDdlOrRadio(ddlTipName, "strTipName", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");


            bu1.Append(Method.BindText(txtOrderID, "strOrderID",false));
            bu1.Append(Method.BindText(txtReceiverName, "strReceiverName", false));
            bu1.Append(Method.BindDdlOrRadio(ddlTipName, "strTipName", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            //Response.Redirect("Delegate.aspx?" + bu1.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Delegate.aspx");
        }
    }
}