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
    public partial class UcMoney_Log : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtCreateTime1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
              
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.ddlType, "strType", true);
                Method.BindDdlOrRadio(this.ddlState, "strState", true);
                Method.BindDdlOrRadio(this.rblDate, "dateType", true);
                Method.BindDdlOrRadio(this.rblIsCancel, "IsCancel", true);
            }
        }
        protected void btnLook_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder("");                    
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlType, "strType", false));
            bu1.Append(Method.BindDdlOrRadio(this.ddlState, "strState", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDate, "dateType", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblIsCancel, "IsCancel", false));
            Response.Redirect("Money_Log.aspx?" + bu1.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Money_Log.aspx");
        }
    }
}