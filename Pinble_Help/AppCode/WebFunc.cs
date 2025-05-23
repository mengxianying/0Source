using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Pbzx.Help
{
    public class WebFunc
    {
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="url">登录的用户名</param>
        public static void validation(string url)
        {
            string userName = Input.Decrypt(url);


            Pbzx.BLL.PBnet_tpman AdminBLL = new Pbzx.BLL.PBnet_tpman();
            Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(userName);

            AdminBLL.UpdateInfo(MyAdmin);
            if (HttpContext.Current.Request.Cookies["AdminManager"] == null)
            {
                HttpCookie cookie = new HttpCookie("AdminManager");
                
                cookie.Value = Input.Encrypt(MyAdmin.Master_Name);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            HttpCookie aCookie = HttpContext.Current.Request.Cookies["AdminManager"];
            //检查是否已登录.
            Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
        }
    }
}
