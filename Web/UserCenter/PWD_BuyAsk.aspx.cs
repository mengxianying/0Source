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
    public partial class PWD_BuyAsk : System.Web.UI.Page
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

                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();

                Pbzx.BLL.PBnet_UserProtectPwd proPWD = new Pbzx.BLL.PBnet_UserProtectPwd();
                Pbzx.Model.PBnet_UserProtectPwd proModel = proPWD.GetModelName(Method.Get_UserName);
                this.lblMBWT.Text = proModel.SecurityQuestion;

                //Pbzx.BLL.PBnet_UserProtectPwd PwdBll = new Pbzx.BLL.PBnet_UserProtectPwd();
                //Pbzx.Model.PBnet_UserProtectPwd PwdModel = PwdBll.GetModel(Method.Get_UserName);

                //this.lblOldAsk.Text = PwdModel.SecurityQuestion;
                //this.lblOldAnswer.Text = PwdModel.Answer;
                // this.lblOldAsk.Text = DbHelperSQLBBS.GetSingle("select top 1 UserQuesion from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();
                // this.lblOldAnswer.Text = DbHelperSQLBBS.GetSingle("select top 1 UserAnswer from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtPassWordAnswer.Text.Trim() == "")
            {
                strErrMsg += "请输入问题答案.<br/>";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.";
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", strErrMsg, 400, "1", "", "", false, false) + "");

                return;
            }
            else
            {
                string Quesion = this.ddlPassWordQuestion.SelectedValue;
                string Answertxt = Input.MD5(Input.FilterAll(this.txtPassWordAnswer.Text.Trim()));
                if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
                {
                    Quesion = this.txtWordQuestion.Text;
                }
                else
                {
                    Quesion = this.ddlPassWordQuestion.SelectedValue;
                }

                int result = DbHelperSQL.ExecuteSql("update PBnet_UserProtectPwd set SecurityQuestion='" + Quesion + "',Answer='" + Answertxt + "' where UserName='" + Method.Get_UserName + "' ");

                if (result > 0)
                {
                    Method.record_user_log(Method.Get_UserName, "", "修改交易密保", "密码相关");
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "交易密保更新成功！", 400, "1", "location.href='userManage.aspx';", "", false, false) + "");
                    return;
                }
                else
                {
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "交易密保更新失败！", 400, "1", "", "", false, false) + "");
                    return;
                }
            }
        }

        protected void ddlPassWordQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
            {
                this.ddlPassWordQuestion.Visible = false;
                this.txtWordQuestion.Visible = true;
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
