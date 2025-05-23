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
using System.Xml;
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class UpdateApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userIP = Request.UserHostAddress;
            string serverIP = ConfigurationManager.AppSettings["ServerIP"];
            if (serverIP == "" || serverIP.Contains(userIP))
            {
                if (!string.IsNullOrEmpty(Request["cpName"]))
                {
                    Application.Lock();
                    Application[Request["cpName"]] = "false";
                    Application.UnLock();

                    Response.Write("执行IP：" + userIP + "   更新成功！");
                }
            }
        }
    }
}
