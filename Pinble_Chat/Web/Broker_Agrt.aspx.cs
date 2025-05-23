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
using System.Text;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Text.RegularExpressions;
namespace Pbzx.Web
{
    public partial class Broker_Agrt2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();
                if (Pbzx.Common.Method.Get_UserName == "0")
                {
                    Response.Write("<script>alert('您还没有登录！\\r\\n请您先登录，然后再申请！');</script>");
                    Response.Redirect("Broker_Agrt.aspx");
                    return;
                }
                MyInit();
                this.BrokerAgreement.Text = Input.FilterHTML(WebInit.userConfig.BrokerAgreement);

            }
        }
        protected void btsave_Click(object sender, EventArgs e)
        {
            string Name = Method.Get_UserName;
            string email = txtEmail.Text;
            LoginSort login = new LoginSort();
            string strErrMsg = "";
            if (this.ChkBroker.Checked != true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("请认真阅读经纪人注册协议，同意后提交!"));
                return;
            }
            int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Name + "' ");
            if (this.pnlBroker.Visible)
            {
                if (Session["ValidateCode"] == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                    return;
                }

                if (this.txtYz.Text.ToUpper() != Session["ValidateCode"].ToString())
                {
                    strErrMsg += "验证码输入错误.\\r\\n"; ;
                }

                if ((this.txtTel.Text.Trim() == "") && (this.txtMobile.Text.Trim() == ""))
                {

                    strErrMsg += "请至少输入一种联系方式.\\r\\n"; ;
                }
                else
                {
                    if (this.txtTel.Text != null)
                    {
                        if (!Regex.IsMatch(this.txtTel.Text, @"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)"))
                        {
                            strErrMsg += "固顶电话格式不对.\\r\\n"; ;
                        }
                    }
                    else if (this.txtMobile.Text != null)
                    {
                        if (this.txtMobile.Text.Length < 9 || this.txtMobile.Text.Length > 15)
                        {
                            strErrMsg += "手机号码格式不对.\\r\\n"; ;
                        }
                    }
                }

                if (txtBirthday.Text.Trim() == "" || txtBirthday.Text.Trim().Length == 0)
                {
                    strErrMsg += "出生年月不能为空!\\r\\n";
                }
                DateTime dtTemp = new DateTime();
                if (!DateTime.TryParse(this.txtBirthday.Text, out dtTemp))
                {
                    strErrMsg += "出生日期格式不正确.<br/>"; ;
                }
                if (string.IsNullOrEmpty(email))
                {
                    strErrMsg += "电子邮件不能为空!\\r\\n";
                }
                else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    strErrMsg += "Email格式不正确";
                }
                else if (DbHelperSQL.Exists("select * from PBnet_UserProtectPwd where Email='" + Input.FilterAll(this.txtEmail.Text.Trim()) + "'"))
                {
                    strErrMsg += "对不起,您的Email已经被占用！";
                }

                if (strErrMsg != "")
                {
                    strErrMsg = "您提交的公告信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                    return;
                }

                Pbzx.BLL.PBnet_UserTable UserBLL = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable UserModel = UserBLL.GetModelName(Name);

                Pbzx.BLL.PBnet_UserProtectPwd PwdBLL = new Pbzx.BLL.PBnet_UserProtectPwd();
                Pbzx.Model.PBnet_UserProtectPwd PwdModel = new Pbzx.Model.PBnet_UserProtectPwd();


                PwdModel.UserName = Input.FilterAll(this.txtUserName.Text);
                PwdModel.Email = email;
                if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
                {
                    PwdModel.SecurityQuestion = Input.FilterAll(this.txtQuestion.Text);
                }
                else
                {
                    PwdModel.SecurityQuestion = this.ddlPassWordQuestion.SelectedValue;
                }
                PwdModel.Answer = Input.MD5(Input.FilterAll(this.txtPassWordAnswer.Text));
                PwdModel.type = 1;

                Pbzx.BLL.PBnet_broker BkBLL = new Pbzx.BLL.PBnet_broker();
                Pbzx.Model.PBnet_broker BkModel;
                if (intBroker > 0)
                {
                    BkModel = BkBLL.GetModelName(Name);
                }
                else
                {
                    BkModel = new Pbzx.Model.PBnet_broker();
                }
                UserModel.UserName = Input.FilterAll(this.txtUserName.Text);
                UserModel.RealName = Input.FilterAll(this.txtRealName.Text);
                UserModel.TradePwd = Input.MD5(Input.FilterAll(this.txtTPWD.Text));
                UserModel.CardID = Input.FilterAll(this.txtCardID.Text);
                UserModel.Province = this.ddlProvince.SelectedItem.Text;
                UserModel.City = this.ddlCity.SelectedItem.Text;
                UserModel.PostCode = Input.FilterAll(this.txtPostCode.Text);
                UserModel.Address = Input.FilterAll(this.txtAddress.Text);
                UserModel.Telphone = Input.FilterAll(this.txtTel.Text);
                UserModel.Mobile = Input.FilterAll(this.txtMobile.Text);
                UserModel.Email = Input.FilterAll(this.txtEmail.Text);
                UserModel.QQ = Input.FilterAll(this.txtQQ.Text);
                UserModel.MSN = Input.FilterAll(this.txtMSN.Text);
                UserModel.Birthday = DateTime.Parse(this.txtBirthday.Text);
                UserModel.Sex = this.rdlSex.Items[0].Selected;
                UserModel.BankInfo = Input.FilterAll(this.txtBankInfo.Text);
                UserModel.BankName = this.rblBankList.SelectedValue;
                UserModel.AccountNumber = Input.FilterAll(this.txtAccountNumber.Text);
                UserModel.CreatTime = DateTime.Now;
                UserModel.State = 1;
                BkModel.UserName = Input.FilterAll(this.txtUserName.Text);
                BkModel.Apply_time = DateTime.Now;
                BkModel.State = 0;
                BkModel.Year_tradeMoney = 0;
                BkModel.Year_incomeMoney = 0;
                BkModel.Total_tradeMoney = 0;
                BkModel.Total_incomeMoney = 0;
                BkModel.Pass_time = DateTime.Now;

                if (UserBLL.Update(UserModel) && BkBLL.Add(BkModel) && PwdBLL.Add(PwdModel))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("申请成功."));
                    Pbzx.BLL.PinbleLogin loginBll = new Pbzx.BLL.PinbleLogin();
                    loginBll.ReLogin();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/Broker.aspx"));

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("申请失败."));
                }
            }///如果已经是高级用户
            else
            {
                Pbzx.BLL.PBnet_broker BkBLL = new Pbzx.BLL.PBnet_broker();
                Pbzx.Model.PBnet_broker BkModel;
                if (intBroker > 0)
                {
                    BkModel = BkBLL.GetModelName(Name);
                    if (BkModel.State == 3)
                    {
                        BkModel.Apply_time = DateTime.Now;
                        BkModel.State = 0;
                        if (BkBLL.Update(BkModel))
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("申请成功."));
                            Pbzx.BLL.PinbleLogin loginBll = new Pbzx.BLL.PinbleLogin();
                            loginBll.ReLogin();
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/Broker.aspx"));

                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("申请失败."));
                        }
                    }
                    else
                    {
                        Response.Write(JS.Alert("您已经申请了经纪人不用重复申请！", "Broker.aspx"));
                        return;
                    }
                }
                else
                {
                    BkModel = new Pbzx.Model.PBnet_broker();
                    BkModel.UserName = Input.FilterAll(this.txtUserName.Text);
                    BkModel.Apply_time = DateTime.Now;
                    BkModel.State = 0;
                    if (BkBLL.Add(BkModel))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("申请成功."));
                        Pbzx.BLL.PinbleLogin loginBll = new Pbzx.BLL.PinbleLogin();
                        loginBll.ReLogin();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/Broker.aspx"));

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("申请失败."));
                    }
                }
            }

        }

        protected void btcanl_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Broker_Agrt.aspx");
        }

        private void MyInit()
        {
            LoginSort login = new LoginSort();
            if (WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                this.pnlBroker.Visible = false;
                this.lblpasszhuce.Visible = true;
                this.lblzhuce.Visible = false;
//                int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Method.Get_UserName + "' and  state !=3   ");
                object objBroker = DbHelperSQL.GetSingle("select state from PBnet_broker where UserName='" + Method.Get_UserName + "'");
                int intBroker = -1;
                if (objBroker != null)
                {
                    intBroker = (int)objBroker;
                    if (intBroker == 0)
                    {
                        Response.Write(JS.Alert("您的经纪人申请已经提交过了，请等待审核结果！", "Broker.aspx"));
                        Response.End();
                        return;
                    }
                    else if (intBroker == 1)
                    {
                        Response.Write(JS.Alert("您已经是经纪人不用重复申请！", "Broker.aspx"));
                        Response.End();
                        return;
                    }
                    else if (intBroker == 2)
                    {
                        Response.Write(JS.Alert("您的经纪人已锁定，不能再次申请！如有疑问请与公司联系。", "Broker.aspx"));
                        Response.End();
                        return;
                    }
                    //else if (intBroker == 3)
                    //{
                    //    Response.Write(JS.Alert("您的经纪人申请未通过审核，不能再次申请！如有疑问请与公司联系。", "Broker.aspx"));
                    //    Response.End();
                    //    return;
                    //}
                }
                //else if (login["AgentInfo"])
                //{
                //    Response.Write(JS.Alert("您已经是代理了，不能再申请经纪人！", "Broker.aspx"));
                //    Response.End();
                //    return;
                //}
            }
            else
            {
                this.pnlBroker.Visible = true;
            }
            #region 注释时间：09-12-23；原因：修改
            //绑定省份
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Code";
            this.ddlProvince.DataBind();
            this.ddlProvince.Attributes.Add("onchange", "provinceChange('" + this.ddlCity.ClientID + "',this.value)");
            this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
            this.rblBankList.DataBind();
            this.rblBankList.Items[0].Selected = true;
            this.txtUserName.Text = Method.Get_UserName;
            // 已经注册过真实信息，修改。

            if (WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Pbzx.BLL.PBnet_UserTable MyBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable MyModel;
                MyModel = MyBll.GetModelName(Method.Get_UserName);
                this.txtRealName.Text = MyModel.RealName;
                this.txtBirthday.Text = MyModel.Birthday.ToString();
                this.rdlSex.SelectedValue = MyModel.Sex.ToString();
                this.txtCardID.Text = MyModel.CardID;
                this.txtTel.Text = MyModel.Telphone;
                this.txtMobile.Text = MyModel.Mobile;
                this.txtEmail.Text = MyModel.Email;
                this.txtQQ.Text = MyModel.QQ;
                this.txtMSN.Text = MyModel.MSN;
                this.ddlProvince.SelectedValue = MyModel.Province.ToString();
                this.ddlCity.SelectedValue = MyModel.City.ToString();
                this.txtPostCode.Text = MyModel.PostCode;
                this.txtAddress.Text = MyModel.Address;
                this.rblBankList.SelectedValue = MyModel.BankName;
                this.txtRealName.Text = MyModel.RealName;
                this.txtBankInfo.Text = MyModel.BankInfo;
                this.txtAccountNumber.Text = MyModel.AccountNumber;
            }
            # endregion
        }
        protected void ddlPassWordQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
            {
                this.txtQuestion.Visible = true;
                this.ddlPassWordQuestion.Visible = false;
            }
        }
    }
}