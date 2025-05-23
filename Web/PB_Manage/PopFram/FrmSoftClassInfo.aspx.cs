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

namespace Pbzx.Web.PB_Manage.PopFram
{
    public partial class FrmSoftClassInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Request["SoftwareType"]
            if (!string.IsNullOrEmpty(Request["SoftwareType"]))
            {
                BindData();
            }
        }
        protected void BindData()
        { 
            StringBuilder sb = new StringBuilder();
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            if (string.IsNullOrEmpty(Request["SoftwareType"]))
            {
                Response.End();
            }
            string strInstall = softBLL.GetInstallTypes(Request["SoftwareType"]);
            if (string.IsNullOrEmpty(strInstall))
            {
              //  JS.Alert("ÔÝÎÞÊý¾Ý");
            }
            else
            {
               
                StringBuilder sbls = new StringBuilder();
                string[] strSZ = strInstall.Split(new char[] { ','});

                foreach(string strT in strSZ)
                {
                        string[] valueTemp = strT.Split(new char[] { '&'});
                        this.cblClass.Items.Add(new ListItem(valueTemp[0], valueTemp[1]));                       
                }
               
            }
            
        }
    }
}


















































































//for (int i = 0; i < len; i++)
//{
//    if (len == 0)
//    {
//        sb.Append("<td></td>");
//        break;
//    }
//    if (i > 0 && i % col == 0)
//    {
//        sb.Append("</tr><tr>");
//    }
//    sb.Append("<td>");
//    sb.Append("<asp:CheckBox ID='ck"+i+"' runat='server' /> ");
//    sb.Append("</td>");
//}