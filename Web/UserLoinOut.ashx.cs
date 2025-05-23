using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Pbzx.Web
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserLoinOut : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Pbzx.BLL.PinbleLogin.UserOut();           
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
