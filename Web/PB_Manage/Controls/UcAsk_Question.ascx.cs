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
    public partial class UcAsk_Question : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Pbzx.BLL.PBnet_ask_Type TypeBll = new Pbzx.BLL.PBnet_ask_Type();
                TypeBll.BindClass(this.ddlTypeName, 0);

                ListItem item = new ListItem("����", "");
                ddlTypeName.Items.Insert(0, item);

                Method.BindText(txtTitle, "strTitle", true);
                Method.BindText(txtAsker, "strAsker", true);
                //Method.BindText(txtAnswerer, "strAnswerer", true);
                Method.BindDdlOrRadio(this.ddlTypeName, "TypeName", true);
                Method.BindDdlOrRadio(this.ddlState, "State", true);

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);

                Method.BindDdlOrRadio(this.dropsh, "Auditing", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);            
           }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindDdlOrRadio(this.ddlTypeName, "TypeName", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlState, "State", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            bu1.Append(Method.BindText(txtTitle, "strTitle", false));
            bu1.Append(Method.BindText(txtAsker, "strAsker", false));
            //bu1.Append(Method.BindText(txtAnswerer, "strAnswerer", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));

            bu1.Append(Method.BindDdlOrRadio(this.dropsh, "Auditing", false));


            Response.Redirect("Ask_Question.aspx?" + bu1.ToString());
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ask_Question.aspx");
        }
    }
}