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
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.Web.UserCenter
{
    public partial class ChangePWD_buy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='UserRealInfo.aspx';}</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_UserProtectPwd proPWD = new Pbzx.BLL.PBnet_UserProtectPwd();
                Pbzx.Model.PBnet_UserProtectPwd proModel = proPWD.GetModelName(Method.Get_UserName);
                this.lblMBWT.Text = proModel.SecurityQuestion;
                //DbHelperSQLBBS.GetSingle(" select UserQuesion from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();               
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["ValidateCode"] == null)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "验证码已经失效！", 400, "1", "", "", false, false) + "");
                return;
            }

            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "验证码输入错误！", 400, "1", "", "", false, false) + "");
                return;
            }

            string oldPwd = Input.MD5(Input.FilterAll(this.txtOldTrade.Text));
            bool isRight = ((int)DbHelperSQL.GetSingle("select count(1) from PBnet_UserTable where UserName='" + Method.Get_UserName + "' and TradePwd='" + oldPwd + "'")) > 0 ? true : false;
           
            if (!isRight)
            {

                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "旧交易密码输入错误！", 400, "1", "", "", false, false) + "");
                return;
            }
            else
            {
                int result = DbHelperSQL.ExecuteSql("update PBnet_UserTable set TradePwd='" + Input.MD5(this.txtTradePwd1.Text) + "' where UserName='" + Method.Get_UserName + "' ");
                if (result > 0)
                {
                    Method.record_user_log(Method.Get_UserName, "", "修改交易密码", "密码相关");
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "交易密码更新成功！", 400, "1", "location.href='/UserCenter/userManage.aspx'", "", false, false) + "");
                    return;
                }
                else
                {
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "交易密码更新失败！", 400, "1", "", "", false, false) + "");

                    return;
                }
            }
        }

        protected void btnKSYZ_Click(object sender, EventArgs e)
        {
            string answer = Input.MD5(Input.FilterAll(this.txtMBDA.Text));

            int count = Convert.ToInt32(DbHelperSQL.GetSingle(" select count(UserName)  from PBnet_UserProtectPwd where UserName='" + Method.Get_UserName + "' and SecurityQuestion='" + this.lblMBWT.Text + "' and Answer='" + answer + "' "));
            if (count < 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "密保答案输入不正确！", 400, "1", "", "", false, false) + "");
            }
            else
            {
                this.pnlYanZ.Visible = false;
                this.pnlXiuG.Visible = true;
            }
        }
    }
}
