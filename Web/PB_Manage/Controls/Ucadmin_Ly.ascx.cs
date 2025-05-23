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
    public partial class Ucadmin_Ly : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_LyType typeBll = new Pbzx.BLL.PBnet_LyType();
                this.ddlSort.DataSource = typeBll.GetList(" IsAuditing=1 order by OrderID ");
                this.ddlSort.DataTextField = "TypeName";
                this.ddlSort.DataValueField = "ID";
                this.ddlSort.DataBind();
                this.ddlSort.Items.Insert(0, new ListItem("È«²¿", ""));

                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtLy_Email, "strLy_Email", true);
                Method.BindText(txtLyContent, "strLyContent", true);
                Method.BindDdlOrRadio(this.ddlState, "State", true);
                Method.BindDdlOrRadio(this.ddlSort, "Sort", true);

                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();        
             bu1.Append(Method.BindText(txtLy_Email, "strLy_Email", false));
             bu1.Append(Method.BindText(txtLyContent, "strLyContent", false));
             bu1.Append(Method.BindDdlOrRadio(this.ddlState, "State", false));
             bu1.Append(Method.BindDdlOrRadio(this.ddlSort, "Sort", false));

             bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append( Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));
            Response.Redirect("admin_Ly.aspx?" + bu1.ToString());
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_Ly.aspx");
        }
    }
}