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

namespace Pbzx.Web.Contorls
{
    public partial class UcLyBookDisp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_LyType typeBll = new Pbzx.BLL.PBnet_LyType();
                this.ddlType.DataSource = typeBll.GetList(" IsAuditing=1 order by OrderID ");
                this.ddlType.DataTextField = "TypeName";
                this.ddlType.DataValueField = "ID";
                this.ddlType.DataBind();
                this.ddlType.Items.Insert(0, new ListItem("È«²¿", ""));

                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindDdlOrRadio(this.ddlState, "strState", true);
                Method.BindDdlOrRadio(this.ddlType, "strType", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }

        protected void btsearch_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");

            bu1.Append(Method.BindDdlOrRadio(this.ddlState, "strState", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlType, "strType", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));           


            Response.Redirect("LyBookDisp.aspx?" + bu1.ToString());
          
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("LyBookDisp.aspx");
        }
    }
}