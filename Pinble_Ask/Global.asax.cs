using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pinble_Ask
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (!Request.Url.PathAndQuery.Contains("NoRight.htm"))
            {
                string userIP = Request.UserHostAddress;
                //Response.Write(userIP);
                //return;

                string[] lockIpSZ = DbHelperSQLBBS.GetSingle("select top 1 Forum_LockIP from Dv_Setup").ToString().Split(new char[] { '|' });
                for (int i = 0; i < lockIpSZ.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lockIpSZ[i]))
                    {
                        if (lockIpSZ[i].Substring(lockIpSZ[i].Length - 1, 1) == "*")
                        {
                            if (userIP !="::1" && userIP.Substring(0, userIP.LastIndexOf(".")) == lockIpSZ[i].Substring(0, lockIpSZ[i].LastIndexOf(".")))
                            {

                                Response.Write("<script>top.location='" + WebInit.webBaseConfig.WebUrl + "NoRight.htm';</script>");
                                break;
                            }
                        }
                        else
                        {
                            if (userIP == lockIpSZ[i])
                            {
                                Response.Write("<script>top.location='" + WebInit.webBaseConfig.WebUrl + "NoRight.htm';</script>");
                                break;
                            }
                        }
                    }
                }
            }
        }


        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}