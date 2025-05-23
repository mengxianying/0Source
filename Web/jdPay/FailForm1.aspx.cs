using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jdPay
{
    public partial class FailForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessForm1 sf = Context.Handler as SuccessForm1;
            this.spanId.InnerHtml=sf.errorMsg;
        }
    }
}