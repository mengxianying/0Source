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
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcAsk_Reply : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtReplyer, "Replyer", true);
                Method.BindText(txtContent, "Content", true);
               // Method.BindDdlOrRadio(this.ddlIsBest, "IsBest", true);  

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);  

            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");
            bu1.Append(Method.BindText(txtReplyer, "Replyer",false));
            bu1.Append(Method.BindText(txtContent, "Content", false));
          //  bu1.Append(Method.BindDdlOrRadio(this.ddlIsBest, "IsBest", false));

            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("Ask_Reply.aspx?" + bu1.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ask_Reply.aspx");
        }
    }
}