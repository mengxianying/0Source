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

namespace Pbzx.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Error += new EventHandler(MyPageErrorHandler);
        }

        public void MyPageErrorHandler(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Response.Write("an   error   occurer:" + ex.Message);
            if (ex.InnerException != null)
                Response.Write("WebForm1.aspx");
             Server.ClearError();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string aa = null;
            Response.Write(aa.Length);
        }   
    }
}
