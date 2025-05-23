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
using System.Text.RegularExpressions;

namespace Pbzx.Web.Contorls
{
    public partial class UcRegRealInfo : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                
                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();
                BindData();
                this.RegeditAgreementGao.Text = WebInit.userConfig.PersonRegeditAgreementGao;
              
            }
        }

        // 密保问题
        public string  Question
        {

            get {
                string question = "";
                //string QQ = Input.FilterAll(this.txtQQ.Text);
                // string MSN = Input.FilterAll(this.txtMSN.Text);
                if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
                {
                    question = Input.FilterHTML(this.txtQuestion.Text);
                }
                else
                {
                    question = this.ddlPassWordQuestion.SelectedValue;
                }
                return question;
            }
        }

        public string Answer
        {
            get
            {
                string answer = "";
                if(!string.IsNullOrEmpty(this.txtPassWordAnswer.Text))
                {
                    answer = Input.MD5(this.txtPassWordAnswer.Text);
                }
                return answer;
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        { 
            LoginSort login = new LoginSort();
            if (login["manager_user"])
            {
                this.lblUserName.Text = Method.Get_UserName;
                ViewState["strEmail"] = DbHelperSQLBBS.GetSingle(" select top 1 UserEmail from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();
                this.txtEmail.Text = ViewState["strEmail"].ToString();
            }
            else
            { 
                    
            }
            //绑定省市
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Code";
            this.ddlProvince.DataBind();
            this.ddlProvince.Items[0].Selected = true;
            this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
            rblBankList.DataBind();
            this.rblBankList.Items[0].Selected = true;
            BindCity();
            if (login["user_RealInfo"])
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
                this.txtQQ.Text = MyModel.QQ;
                this.txtMSN.Text = MyModel.MSN;
                object obj = WebFunc.GetProvinceIdByName(MyModel.Province);
                if (obj != null)
                {
                    this.ddlProvince.SelectedValue = obj.ToString();
                }
                else
                {
                    this.ddlProvince.SelectedIndex = 0;
                }
                BindCity();
                this.ddlCity.SelectedValue = MyModel.City;
                this.txtPostCode.Text = MyModel.PostCode;
                this.txtAddress.Text = MyModel.Address;
                this.rblBankList.SelectedValue = MyModel.BankName;
                this.txtRealName.Text = MyModel.RealName;
                this.txtBankInfo.Text = MyModel.BankInfo;
                this.txtAccountNumber.Text = MyModel.AccountNumber;
                this._userTable = MyModel;
            }

        }

        private Pbzx.Model.PBnet_UserTable _userTable ;

        public Pbzx.Model.PBnet_UserTable UserTable
        {
            get
            {
                string question = "";
                //string QQ = Input.FilterAll(this.txtQQ.Text);
               // string MSN = Input.FilterAll(this.txtMSN.Text);
                if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
                {
                     question = this.txtQuestion.Text;
                }
                else
                {
                    question = this.ddlPassWordQuestion.SelectedValue;
                }

                LoginSort login = new LoginSort();
                _userTable = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                if (_userTable == null)
                {
                    Response.Write("<script type='text/javascript'>alert('登录超时，请重新登录！');location.href='/login.aspx';</script>");
                    Response.End();                    
                    return null;
                }
                string strErrMsg = "";
                //if (Session["ValidateCode"] == null)
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));                       
                //    return　null;
                //}
                if(string.IsNullOrEmpty(this.txtRealName.Text.Trim()))
                {
                    strErrMsg += "真实姓名不能为空.<br/>"; ;
                }
                DateTime dtTemp = new DateTime();
                if (!DateTime.TryParse(this.txtBirthday.Text, out dtTemp))
                {
                    strErrMsg += "出生日期格式不正确.<br/>"; ;
                }
                if (!Regex.IsMatch(this.txtTPWD.Text, @"^[a-zA-Z0-9_]{6,18}$"))
                {
                    strErrMsg += "交易密码必须为6-18位的字母和数字.<br/>"; ;
                }

                if (Input.IsInteger(this.txtTPWD.Text, true) || Input.IsAllLetter(this.txtTPWD.Text) || this.txtTPWD.Text.Contains("12345"))
                {
                    strErrMsg += "交易密码过于简单，交易密码必须是字母和数字的组合!<br/>";
                }

                string userPWD = DbHelperSQLBBS.GetSingle(" select top 1 UserPassword from  Dv_User where UserName='" + Method.Get_UserName + "'  ").ToString();
                if(userPWD == Input.MD5(this.txtTPWD.Text.Trim()))
                {
                    strErrMsg += "交易密码不能与登录密码相同!<br/>";
                }

                if (this.txtTPWD.Text != this.txtReTPWD.Text)
                {
                    strErrMsg += "两次密码输入不一致.<br/>"; ;
                }
                if (string.IsNullOrEmpty(question))
                {
                    strErrMsg += "交易密码密保问题不能为空.<br/>"; ;
                }
                if(string.IsNullOrEmpty(this.txtPassWordAnswer.Text))
                {
                    strErrMsg += "交易密码密保答案不能为空.";
                }
                if (!Regex.IsMatch(this.txtCardID.Text, @"\d{17}[\d|X]|\d{15}"))
                {
                    strErrMsg += "身份证号码格式不正确.<br/>"; ;
                }
                //if (!Regex.IsMatch(this.txtTel.Text, @"(\(\d{3}\)|\d{3}-)?\d{8}"))
                //{
                //    strErrMsg += "联系电话格式不正确.<br/>"; ;
                //}

                if ((string.IsNullOrEmpty(this.txtTel.Text)) && (string.IsNullOrEmpty(this.txtMobile.Text)))
                {

                    strErrMsg += "请至少输入一种联系方式.<br/>"; ;
                }
                else
                {
                    if (this.txtTel.Text != null&&this.txtTel.Text!="")
                    {
                        if (!Regex.IsMatch(this.txtTel.Text, @"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)"))
                        {
                            strErrMsg += "联系电话格式不正确.<br/>"; ;
                        }
                    }
                    else if (this.txtMobile.Text != null && this.txtMobile.Text != "")
                    {
                        if (this.txtMobile.Text.Length < 9 || this.txtMobile.Text.Length > 15)
                        {
                            strErrMsg += "手机号码格式不对.<br/>"; ;
                        }
                    }
                }

                string email = Input.FilterHTML(this.txtEmail.Text);

                if (string.IsNullOrEmpty(email))
                {
                    strErrMsg += "电子邮件不能为空!<br/>";
                }
                else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    strErrMsg += "Email格式不正确";
                }
                else if (ViewState["strEmail"].ToString() != email && DbHelperSQL.Exists("select * from PBnet_UserTable where Email='" + email + "'"))
                {
                    strErrMsg += "对不起,您的Email已经被占用！";
                }

                if (!Regex.IsMatch(this.txtPostCode.Text, @"\d{6}"))
                {
                    strErrMsg += "邮编格式不正确.<br/>"; ;
                }

                if (string.IsNullOrEmpty(this.txtAddress.Text))
                {
                    strErrMsg += "详细地址不能为空.<br/>"; ;
                }
                if (string.IsNullOrEmpty(this.txtBankInfo.Text))
                {
                    strErrMsg += "开户行不能为空.<br/>"; ;
                }
                if (string.IsNullOrEmpty(this.txtAccountNumber.Text))
                {
                    strErrMsg += "卡号不能为空.<br/>"; ;
                }                
                if (strErrMsg != "")
                {
                    strErrMsg = "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", strErrMsg, 500, "1", "", "", false, false));        

                    return null;
                }

                _userTable.UserName = Method.Get_UserName;
                _userTable.RealName = Input.FilterHTML(this.txtRealName.Text.Trim());
                _userTable.TradePwd = Input.MD5(Input.FilterHTML(this.txtTPWD.Text)); 
                

                _userTable.CardID = Input.FilterHTML(this.txtCardID.Text);
                _userTable.Province = this.ddlProvince.SelectedItem.Text;
                _userTable.City = this.ddlCity.SelectedItem.Text;
                _userTable.PostCode = Input.FilterHTML(this.txtPostCode.Text);
                _userTable.Address = Input.FilterHTML(this.txtAddress.Text);
                _userTable.Telphone = Input.FilterHTML(this.txtTel.Text);
                _userTable.Mobile = Input.FilterHTML(this.txtMobile.Text);
                _userTable.Email = email;
               
                _userTable.QQ = Input.FilterHTML(this.txtQQ.Text);
                _userTable.MSN = Input.FilterHTML(this.txtMSN.Text);
                _userTable.Birthday = DateTime.Parse(Input.FilterHTML(this.txtBirthday.Text));
                _userTable.Sex = this.rdlSex.Items[0].Selected;
                _userTable.BankInfo = Input.FilterHTML(this.txtBankInfo.Text);
                _userTable.BankName = this.rblBankList.SelectedValue;
                _userTable.AccountNumber = Input.FilterHTML(this.txtAccountNumber.Text);             

                return _userTable; 
            }
            set
            {
                this.txtRealName.Text = value.RealName;
                this.txtTPWD.Text = value.TradePwd;
                this.txtReTPWD.Text = value.TradePwd;
                this.txtCardID.Text = value.CardID;
                if(!string.IsNullOrEmpty(value.Province))
                {
                    object obj = WebFunc.GetProvinceIdByName(value.Province);
                    if (obj != null)
                    {
                        this.ddlProvince.SelectedValue = obj.ToString();
                    }
                    else
                    {
                        this.ddlProvince.SelectedIndex = 0;
                    }
                }
                BindCity();
                if (!string.IsNullOrEmpty(value.City))
                {
                    this.ddlCity.SelectedValue = value.City;
                }                               
                this.txtPostCode.Text = value.PostCode;
                this.txtAddress.Text = value.Address;
                this.txtTel.Text = value.Telphone;
                this.txtMobile.Text = value.Mobile;
                
                this.txtQQ.Text = value.QQ;
                this.txtMSN.Text = value.MSN;
                if(value.Birthday != null)
                {
                   this.txtBirthday.Text = DateTime.Parse(value.Birthday.ToString()).ToShortDateString();
                }

                if (value.Sex)
                {
                    this.rdlSex.Items[0].Selected = true;
                }
                else
                {
                    this.rdlSex.Items[1].Selected = true;
                }

               
                if (!string.IsNullOrEmpty(value.BankName))
                {
                    this.rblBankList.SelectedValue = value.BankName;
                }                
                this.txtBankInfo.Text = value.BankInfo;
                this.txtAccountNumber.Text = value.AccountNumber;
                _userTable = value;
            }
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }
        private void BindCity()
        {
            DataSet ds = DbHelperSQL.Query("select Code ,Name,ProvinceId from PBnet_City where ProvinceId='" + this.ddlProvince.SelectedValue + "' ");
            this.ddlCity.DataSource = ds;
            this.ddlCity.DataTextField = "Name";
            this.ddlCity.DataValueField = "Name";
            this.ddlCity.DataBind();               
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