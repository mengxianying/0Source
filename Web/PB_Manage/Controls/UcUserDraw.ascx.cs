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
    public partial class UcUserDraw : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtUname, "strUsername", true);
                Method.BindText(txtRealName, "strRealName", true);
                Method.BindDdlOrRadio(rbldate, "strdate", true);
                Method.BindText(txtBankInfo, "strBankInfo", true);
                Method.BindText(txtOrderID, "strOrderID", true);


                if (string.IsNullOrEmpty(Request["state"]))
                {
                    this.ddlState.SelectedValue = "0";
                }
                else
                {
                    Method.BindDdlOrRadio(this.ddlState, "state", true);
                }

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);

                this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
                this.rblBankList.DataBind();
                this.rblBankList.Items.Insert(0, new ListItem("所有银行", ""));
                this.rblBankList.Items[0].Selected = true;
             

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDraw_Manage.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu = new StringBuilder("");

            bu.Append(Method.BindText(txtUname, "strUsername", false));
            bu.Append(Method.BindText(txtRealName, "strRealName", false));
            bu.Append(Method.BindDdlOrRadio(this.rblBankList, "strBankName", false));
            bu.Append(Method.BindDdlOrRadio(this.txtBankInfo, "strBankInfo", false));

            bu.Append(Method.BindText(txtOrderID, "strOrderID", false));

            bu.Append(Method.BindDdlOrRadio(rbldate, "strdate", false));

            bu.Append(Method.BindDdlOrRadio(this.ddlState, "state", false));

            bu.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));

            Response.Redirect("UserDraw_Manage.aspx?" + bu.ToString());
        }
    }
}