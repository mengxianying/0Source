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
using Maticsoft.DBUtility;
using System.Text.RegularExpressions;
using System.Xml;
using Pbzx.BLL;

namespace Pbzx.Web.Contorls
{
    public partial class UcRepairMobile : System.Web.UI.UserControl
    {
        PBnet_UserLog userlogmanager = new PBnet_UserLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 

            }
        }

        /// <summary>
        /// 点击保存电话号码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRepair_update(object sender, ImageClickEventArgs e)
        {
            string strErrMsg = "";
            string userName = "";
            String mobile = Input.FilterAll(this.txtQQ.Text);
            String checkcode = Input.FilterAll(this.txtMSN.Text);
            String mobilecheckcode = Input.FilterAll(this.TextBox1.Text);

            if (string.IsNullOrEmpty(mobile))
            {
                strErrMsg += "手机号不能为空!<br/>";
            }
            if (string.IsNullOrEmpty(checkcode))
            {
                strErrMsg += "验证数字不能为空!<br/>";
            }
            if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "手机验证码不能为空!<br/>";
            }
            if (!checkcode.Equals(Session["CHECKCODEIMG"].ToString().Trim()))
            {
                strErrMsg += "验证数字错误!<br/>";
            }
            if (!checkcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
            {
                strErrMsg += "手机验验证码错误!<br/>";
            }
             

            if (strErrMsg != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                return;
            }
             
            //用户真实信息更新记录

            DbHelperSQLBBS.ExecuteSql("update PBnet_ask_User set MOBILE='" + mobile + "' where username = '" + userName + "'");

            Method.record_user_log(userName, "", "更新成功", "用户补充电话信息");
             
            Response.Write("<script>window.top.location.href='" + Session["ReturnIndexUrl"] + "';</script>");
        }
         
        
    }

}