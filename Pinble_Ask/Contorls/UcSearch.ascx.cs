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

namespace Pinble_Ask.Contorls
{
    public partial class UcSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearchAnswer_Click(object sender, EventArgs e)
        {
            if (this.txtKey.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "answerSearchError", "alert('请输入搜索的答案！')", true);
                // Response.End();
                return;
            }
            Response.Redirect("SearchList.aspx?searchKey=" + Input.Encrypt(Input.FilterHTML(this.txtKey.Text)));
        }

        protected void btnTW_Click(object sender, EventArgs e)
        {
            if (this.txtKey.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "TWError", "alert('请输入提问标题！')", true);
                // Response.End();
                return;
            }
            Response.Redirect("Ask.aspx?title=" + Input.Encrypt(Input.FilterAll(this.txtKey.Text)));
        }
    }
}