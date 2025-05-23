using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Pbzx.Common;

namespace Pbzx.Web
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string uid = Input.FilterAll(context.Request["uid"]);
            string upwd = Input.FilterAll(context.Request["pwd"]);
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(upwd))
            {
                Pbzx.BLL.PinbleLogin loignBll = new Pbzx.BLL.PinbleLogin();
                string result = loignBll.CheckLogin(uid, upwd);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
