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

namespace Pbzx.Web.Contorls
{
    public partial class Head_Chat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  Pbzx.Common.LoginSort login = new Pbzx.Common.LoginSort();
                //  if (login["manager_user"])
                //  {
                //      this.btnLoginShow.Visible = false;
                //      this.btnLoginOut.Visible = true;
                //  }
                //  else
                //  {
                //      this.btnLoginShow.Visible = true;
                //      this.btnLoginOut.Visible = false;
                //  }
                //this.WindowLogin.ShowOnLoad = false;            
            }

        }


        protected void btnLoginOut_Click(object sender, EventArgs e)
        {
            //Pbzx.BLL.PinbleLogin.UserOut();
            //Response.Redirect(Request.Url.PathAndQuery);           
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ÏÔÊ¾µÇÂ¼´°Ìå
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLoginShow_Click(object sender, EventArgs e)
        {
            //this.WindowLogin.Show(this);
        }

    }
}