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

namespace Pbzx.Web
{
    public partial class shengqing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyInit();
                this.BrokerAgreement.Text = Input.FilterHTML(WebInit.userConfig.AgentAgreement);
            }
        }
        private void MyInit()
        {
            LoginSort login = new LoginSort();

            //绑定省份
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Name";
            this.ddlProvince.DataBind();
            this.txtUserName.Text = Method.Get_UserName;
           // this.ddlProvince.Attributes.Add("onchange", "provinceChange('" + this.ddlCity.ClientID + "',this.value)");
            //this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
            //this.rblBankList.DataBind();
            //this.rblBankList.Items[0].Selected = true;
           
            // 已经注册过真实信息，修改。

            if (login["user_RealInfo"])
            {
                Pbzx.BLL.PBnet_UserTable MyBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable MyModel;
                MyModel = MyBll.GetModelName(Method.Get_UserName);
                this.txtRealName.Text = MyModel.RealName;
              //this.txtBirthday.Text =DateTime.Parse(MyModel.Birthday.ToString()).ToShortDateString();
              //this.rdlSex.SelectedValue = MyModel.Sex.ToString();
              //this.txtCardID.Text = MyModel.CardID;
                this.txtTel.Text = MyModel.Telphone;
                this.txtMobile.Text = MyModel.Mobile;
                this.txtEmail.Text = MyModel.Email;
               
                //this.txtMSN.Text = MyModel.MSN;
                this.ddlProvince.SelectedValue = MyModel.Province.ToString();
              //this.ddlCity.SelectedValue = MyModel.City.ToString();
                this.txtPostCode.Text = MyModel.PostCode;
                this.txtAddress.Text = MyModel.Address;
              // this.rblBankList.SelectedValue = MyModel.BankName;
              // this.txtRealName.Text = MyModel.RealName;
              // this.txtBankInfo.Text = MyModel.BankInfo;
              // this.txtAccountNumber.Text = MyModel.AccountNumber;
            }
            if (login["AgentInfo_Apply"])
            {
               Response.Write(JS.Alert("您已经申请过代理，无需重复申请！", "/Agent.aspx"));
                Response.End();
                return;
            }
            //else if (login["user_Broker"])
            //{
            //    Response.Write(JS.Alert("您已经申请过经纪人了，不能再申请代理！", "/Agent.aspx"));
            //    Response.End();
            //    return;
            //}
        }

        protected void btsave_Click(object sender, EventArgs e)
        {
            string Name = Method.Get_UserName;
            string email = Input.FilterHTML(this.txtEmail.Text.Trim());
            LoginSort login = new LoginSort();
            string strErrMsg = "";
            if (this.ChkBroker.Checked != true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("请认真阅读代理注册协议，同意后提交!"));
                return;
            }
            //如果未填写详细信息
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
                    if (this.txtMobile.Text != null && this.txtMobile.Text.Trim() != "")
                    {
                        if (this.txtMobile.Text.Length < 9 || this.txtMobile.Text.Length > 15)
                        {
                            strErrMsg += "手机号码格式不对.\\r\\n"; ;
                        }
                    }
                    else if (this.txtTel.Text.Trim() != null && this.txtTel.Text.Trim() != "")
                    {
                        if (!Regex.IsMatch(this.txtTel.Text, @"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)"))
                        {
                            strErrMsg += "联系电话格式不对.\\r\\n"; ;
                        }
                    }

                }
                if (string.IsNullOrEmpty(email))
                {
                    strErrMsg += "电子邮件不能为空!\\r\\n";
                }
                else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    strErrMsg += "Email格式不正确";
                }


                if (strErrMsg != "")
                {
                    strErrMsg = "您提交的代理信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                    return;
                }

                Pbzx.BLL.AgentInfo_Apply AgentABll = new Pbzx.BLL.AgentInfo_Apply();
                Pbzx.Model.AgentInfo_Apply AgentAModel = new Pbzx.Model.AgentInfo_Apply();
                AgentAModel.UserName = txtUserName.Text;
                AgentAModel.Name = Input.FilterHTML(txtRealName.Text);
                AgentAModel.PostCode = Input.FilterHTML(this.txtPostCode.Text);
                AgentAModel.Address = Input.FilterHTML(this.txtAddress.Text);
                AgentAModel.Telephone = Input.FilterHTML(this.txtTel.Text);
                AgentAModel.Mobile = Input.FilterHTML(this.txtMobile.Text);
                AgentAModel.EMail = Input.FilterHTML(this.txtEmail.Text);

                //AgentAModel.PostCode = "QQ:" + Input.FilterHTML(this.txtQQ.Text) + "MSN:" + Input.FilterAll(this.txtMSN.Text);
                AgentAModel.Fax = Input.FilterHTML(this.txtFax.Text);
                AgentAModel.Province = this.ddlProvince.SelectedValue;
               
                AgentAModel.ExpireDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                AgentAModel.Company = Input.FilterHTML(txtCompany.Text);
                AgentAModel.Remark = Input.FilterHTML(txtRemark.Text);
                AgentAModel.Status = 0;
                AgentAModel.delshow = false;
                AgentAModel.CreateDate = DateTime.Now;
             

                    if (AgentABll.Add(AgentAModel))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("代理申请已提交成功."));
                        Pbzx.BLL.PinbleLogin loginBll = new Pbzx.BLL.PinbleLogin();
                        loginBll.ReLogin();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/Agent.aspx"));

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("代理申请提交失败."));
                    }
            
            }

        }

        protected void btcanl_Click(object sender, EventArgs e)
        {

        }
    }
}
