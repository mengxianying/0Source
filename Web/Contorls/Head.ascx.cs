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
    public partial class Head : System.Web.UI.UserControl
    {
        Pbzx.BLL.PBnet_platfrom_icon get_plf = new BLL.PBnet_platfrom_icon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
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
                Binddata_navigation();
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


        /// <summary>
        /// 显示登录窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLoginShow_Click(object sender, EventArgs e)
        {
            //this.WindowLogin.Show(this);
        }
        /// <summary>
        /// 绑定数据
        /// </summary>

        public void Binddata_navigation()
        {

            DataSet ds = get_plf.GetList(8, "P_state=0", " P_Sort asc");
            //data_navigation.DataSource = ds;
            //data_navigation.DataBind();
            data_nav.DataSource = ds;
            data_nav.DataBind();
        }
    }
}