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

namespace Pbzx.Web
{
    public partial class AjaxReq1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["uName"] != null && Request["uPwd"] != null && Request["uCode"] != null)
            {
                MyCheckLogin(Request["uName"], Request["uPwd"],Request["uCode"]);
            }
            if (Request["loginOut"] != null)
            {
                MyLoginOut();
            }
        }

        /// <summary>
        /// µÇÂ¼
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <param name="uCode"></param>
        private void MyCheckLogin(string uName, string uPwd, string uCode)
        {
            string strResult = "";
            Pbzx.BLL.PinbleLogin LoginBll = new Pbzx.BLL.PinbleLogin();
            string result = LoginBll.CheckLogin(uName, uPwd);
            if (uCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                strResult = "ÑéÖ¤Âë´íÎó";
            }
            else
            {
                if (!string.IsNullOrEmpty(result))
                {
                    strResult = result;
                }
                else
                {
                    strResult = "true";
                }
            }
            Response.Clear();
            Response.Write(strResult);
            Response.End();
        }

        /// <summary>
        /// ÍË³ö
        /// </summary>
        private void MyLoginOut()
        {
            try
            {
                Pbzx.BLL.PinbleLogin.UserOut();
                Response.Write("true");
            }
            catch(Exception ex)
            {
                Response.Write("false");
            }   
            
        }
    }
}
