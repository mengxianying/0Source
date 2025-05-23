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

namespace Pbzx.Web.UserCenter
{
    public partial class Bank_Info : System.Web.UI.Page
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

                BindData();

            }
        }


        private void BindData()
        {
            this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
            rblBankList.DataBind();
            Pbzx.BLL.PBnet_UserTable MyBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable MyModel;
            MyModel = MyBll.GetModelName(Method.Get_UserName);

            try
            {
                rblBankList.SelectedValue = MyModel.BankName;
            }
            catch(Exception ex)
            {
                this.rblBankList.Items[0].Selected = true;
            }

            txtBankInfo.Text = MyModel.BankInfo;
            txtAccountNumber.Text = MyModel.AccountNumber;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Pbzx.Model.PBnet_UserTable utModel = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            if (Session["ValidateCode"] == null)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "验证码已经失效！", 400, "1", "location.href='userManage.aspx'", "", false, false) + "");
                return;
            }

            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "验证码输入错误！", 400, "1", "", "", false, false) + "");
                
                return;
            }

            if (Input.MD5(txtJyPWD.Text.Trim()) != utModel.TradePwd)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "交易密码不正确！", 400, "1", "", "", false, false) + "");
                return;
            }

            this.pnlYanZ.Visible = false;
            this.pnlXiuG.Visible = true;
            BindData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_UserTable MyBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable MyModel;
            MyModel = MyBll.GetModelName(Method.Get_UserName);
            MyModel.BankName = this.rblBankList.SelectedValue;
            MyModel.BankInfo = Input.FilterHTML(this.txtBankInfo.Text);
            MyModel.AccountNumber = Input.FilterHTML(this.txtAccountNumber.Text);
            MyBll.Update(MyModel);
            Method.record_user_log(Method.Get_UserName, "", "修改银行账号信息", "密码相关");
            Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "修改成功！", 350, "1", "location.href='userManage.aspx'", "", false, false) + "");
        }

    }
}
