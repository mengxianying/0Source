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
    public partial class UcAdvancedUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                this.ddlBankName.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
                ddlBankName.DataBind();
                this.ddlBankName.Items.Insert(0, new ListItem("È«²¿",""));
                this.ddlBankName.Items[0].Selected = true;

                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtUserName, "UserName", true);
                Method.BindText(txtRealName, "RealName", true);
                Method.BindText(txtUserEmail, "UserEmail", true);
                Method.BindText(txtAccountNumber, "AccountNumber", true);
                Method.BindDdlOrRadio(this.ddlBankName, "BankName", true);
                Method.BindDdlOrRadio(this.rblState, "State", true);
                Method.BindDdlOrRadio(this.rblMoney, "Money", true);
                

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");

            bu1.Append(Method.BindText(txtUserName, "UserName", false));
            bu1.Append(Method.BindText(txtRealName, "RealName", false));
            bu1.Append(Method.BindText(txtUserEmail, "UserEmail", false));
            bu1.Append(Method.BindText(txtAccountNumber, "AccountNumber", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlBankName, "BankName", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblState, "State", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblMoney, "Money", false));


            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("AdvancedUserManage.aspx?" + bu1.ToString());
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvancedUserManage.aspx");
        }
    }
}