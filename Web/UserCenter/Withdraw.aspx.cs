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

namespace Pbzx.Web.UserCenter
{
    public partial class Withdraw : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='UserRealInfo.aspx';}</script>");
                Response.End();
                return;
            }
            //if (!login[ELoginSort.AccountNumber.ToString()])
            //{
            //    Response.Write(JS.Alert("您的银行卡还没有通过验证，无法取款！请先验证您得银行卡", "Bank_Info.aspx"));
            //    Response.End();
            //    return;
            //}
            if (!Page.IsPostBack)
            {
                this.tb1.Visible = true;
                this.tb2.Visible = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Pbzx.Model.PBnet_UserTable utModel = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                return;
            }

            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
            }

            if (Input.MD5(txtJyPWD.Text.Trim()) != utModel.TradePwd)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("交易密码不正确!"));
                return;
            }
            if (utModel.CurrentMoney.ToString() != "")
            {
                this.lblCurrent.Text = Convert.ToDecimal(utModel.CurrentMoney).ToString("0.00") + "元";
            }
            else
            {
                this.lblCurrent.Text = "0元";
            }
            this.tb1.Visible = false;
            this.tb2.Visible = true;
            this.lblUname.Text = utModel.UserName;
          
            this.lblBankName.Text = utModel.BankName;
            this.lblBankInfo.Text = utModel.BankInfo;
            this.lblAccountNumber.Text = utModel.AccountNumber;
            this.lblCity.Text = utModel.City;
            this.lblProvince.Text = utModel.Province;
            this.lblRealName.Text = utModel.RealName;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = new Pbzx.Model.PBnet_Charge();
            model.c_memo2 = "";
            model.OrderDate = DateTime.Now;
            model.OrderID = Method.CreateOrderID("QK", "PBnet_Charge");
            decimal mo = 0;
            if (!decimal.TryParse(this.txtDraw.Text, out mo))
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("错误！", "您输入的取款金额不正确！", 350, "1", "", "", false, false));
                return;
            }
            else if (mo < 0)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("错误！", "您输入的取款金额不正确！", 350, "1", "", "", false, false));                
                return;
            }
            else if (mo < 100)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("错误！", "最少取款金额为100元！", 350, "1", "", "", false, false));
                return;
            }
            model.PayMoney = mo;
            Pbzx.Model.PBnet_UserTable ut = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();

            //if (ut.AccountNumberState != 3)
            //{
            //    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("错误！", "你的银行账号未通过验证！", 350, "1", "", "", false, false));
            //    return;
            //}
           // model.State = 0;
           // model.Type = 1;
            if(Convert.ToDecimal(ut.CurrentMoney - ut.FrozenMoney) < mo)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("错误！", "您的可用余额不足，无法申请取款！", 350, "1", "", "", false, false));
                return;
            }
            
            model.PayNum = ut.AccountNumber;
            model.HasPayedPrice = 0;
            model.RealName = ut.RealName;
            model.UserID = int.Parse(Method.Get_UserID);
            model.UserName = Method.Get_UserName;
            model.c_memo1 = "";
            model.PayTypeID = 1;
            model.c_memo2 = ut.RealName + "取款申请";
            model.State = 0;
            model.Type = 1;
            model.UpdateStaticDate = DateTime.Now;
            model.IsPay = 1;
            model.UserIP = Request.UserHostAddress;
            int result = chargeBLL.Add(model);
            ut.FrozenMoney += mo;
            Pbzx.BLL.PBnet_UserTable utBll = new Pbzx.BLL.PBnet_UserTable();
            utBll.Update(ut);
            //Email email = new Email("@pinble.com", "用户取款通知（bbs用户名：" + ut.UserName + "；真实姓名：" + ut.RealName + "）", "用户取款通知（bbs用户名：" + ut.UserName + "；真实姓名：" + ut.RealName + "）====》<a href='" + WebInit.webBaseConfig.WebUrl + "UserCenter/MoneyLog_EditQK.aspx?' target='_blank'>点此查看详细</a>");
            //email.Send();
            if (result > 0)
            {
                Response.Write("<script>alert('您的取款申请已经提交，我们将在1－3个工作日内进行处理！');location.href='userManage.aspx';</script>");
                return;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('申请提交错误，请与管理员联系')", true);
                return;
            }
        }
    }
}
