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

namespace Pbzx.Web.PB_Manage
{
    public partial class Transit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //传值到帮助平台
                if (Request["PageState"].ToString() == "help")
                {
                    //取出cookie中保存的值
                    string url = System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
                    Response.Redirect("http://192.168.1.121:8013/pinbleHelp/HelpList.aspx?urlAddress=" + url);
                }
                //传到彩票超市
                if (Request["PageState"].ToString() == "Market")
                {
                    //取出cookie中保存的值
                    string url = System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
                }
                //传到合买代购平台
                if (Request["PageState"].ToString() == "Chipped")
                { 
                   //和买代购的平台的地址
                }
            }
        }
    }
}
