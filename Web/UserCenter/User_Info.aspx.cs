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

namespace Pbzx.Web.UserCenter
{
    public partial class User_Info : System.Web.UI.Page
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
                MyInit();
            }
        }
        protected void btsave_Click(object sender, EventArgs e)
        {
            string Name = Method.Get_UserName;

            Pbzx.BLL.PBnet_UserTable UserBLL = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable UserModel = UserBLL.GetModelName(Name); ;
            string strErrMsg = "";
            string email = Input.FilterAll(txtEmail.Text);

            if ((this.txtTel.Text.Trim() != "") || (this.txtMobile.Text.Trim() != ""))
            {
                if (this.txtTel.Text.Trim() != "")
                {
                    if (!Regex.IsMatch(this.txtTel.Text, @"(\(\d{3}\)|\d{3}-)?\d{8}"))
                    {
                        strErrMsg += "联系电话格式不正确.\\r\\n"; ;
                    }
                }
                if (this.txtMobile.Text.Trim() != "")
                {
                    if (this.txtMobile.Text.Length > 13 || this.txtMobile.Text.Length < 9)
                    {
                        strErrMsg += "手机号码格式不对.\\r\\n"; ;
                    }

                }
            }
            else
            {
                strErrMsg += "请至少输入一种联系方式.\\r\\n"; ;
            }
            if (!Regex.IsMatch(this.txtPostCode.Text, @"\d{6}"))
            {
                strErrMsg += "邮编格式不正确.\\r\\n"; ;
            }

            if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                strErrMsg += "详细地址不能为空.\\r\\n"; ;
            }

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
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的公告信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            //UserModel.RealName = this.txtRealName.Text;
            //UserModel.CardID = this.txtCardID.Text;
            UserModel.Province = this.ddlProvince.SelectedItem.Text;
            UserModel.City = this.ddlCity.SelectedItem.Text;
            UserModel.PostCode = Input.FilterAll(this.txtPostCode.Text);
            UserModel.Address = Input.FilterAll(this.txtAddress.Text);
            UserModel.Telphone = Input.FilterAll(this.txtTel.Text);
            UserModel.Mobile = Input.FilterAll(this.txtMobile.Text);
            UserModel.QQ = Input.FilterAll(this.txtQQ.Text);
            UserModel.MSN = Input.FilterAll(this.txtMSN.Text);
            UserModel.Email = email;
            //   UserModel.Birthday = DateTime.Parse(this.txtBirthday.Text);                     
            UserModel.Sex = this.rdlSex.Items[0].Selected;
            UserModel.CreatTime = DateTime.Now;
            UserModel.State = 1;

            if (UserBLL.Update(UserModel))
            {
                int sex = this.rdlSex.Items[0].Selected ? 1 : 0;
                DbHelperSQLBBS.ExecuteSql("update Dv_User set UserEmail='" + email + "',UserSex='" + sex + "' where  UserName='" + Method.Get_UserName + "' ");
                DbHelperSQLMeChat.ExecuteSql("update UserInfo set Sex='" + sex + "' where  UserName='" + Method.Get_UserName + "' ");
                if (ViewState["strEmail"].ToString() != email)
                {
                    Pbzx.Model.PBnet_UserTable UserModel1 = UserBLL.GetModelName(Name);
                    UserModel1.EmailState = 0;
                    UserBLL.Update(UserModel1);
                    MyInit();
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改失败."));
            }
        }

        private void MyInit()
        {
            //绑定省份
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Code";
            this.ddlProvince.DataBind();

            //this.txtUserName.Text = Method.Get_UserName;
            // 已经注册过真实信息，修改。
            Pbzx.BLL.PBnet_UserTable MyBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable MyModel;
            MyModel = MyBll.GetModelName(Method.Get_UserName);
            this.lblRealName.Text = MyModel.RealName;
            this.lblBirthday.Text = ((DateTime)MyModel.Birthday).ToShortDateString();
            if (MyModel.Sex)
            {
                this.rdlSex.Items[0].Selected = true;
                this.rdlSex.Items[1].Selected = false;
            }
            else
            {
                this.rdlSex.Items[0].Selected = false;
                this.rdlSex.Items[1].Selected = true;
            }
            this.lblCardID.Text = MyModel.CardID;
            this.txtTel.Text = MyModel.Telphone;
            this.txtMobile.Text = MyModel.Mobile;
            //this.txtEmail.Text = MyModel.Email;
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

            //lblEmail.Text = MyModel.Email;
            txtEmail.Text = MyModel.Email;
            ViewState["strEmail"] = MyModel.Email;
            string[] result = Method.GetYZNameByState(MyModel.EmailState, "1");
            this.lblEmailState.Text = result[0];
            this.btnEmailYZ.Text = result[1];
            if (string.IsNullOrEmpty(result[1]))
            {
                this.btnEmailYZ.Visible = false;
            }
            else
            {
                this.btnEmailYZ.Visible = true;
            }

        }

        /// <summary>
        /// 申请验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEmailYZ_Click(object sender, EventArgs e)
        {
            if (btnEmailYZ.Text == "申请验证" || btnEmailYZ.Text == "重新申请验证")
            {
                Pbzx.Model.PBnet_UserTable realUser = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                string result = Pbzx.Common.Method.GetEmailContent(("/Template/Email_Success.aspx?type=EmailYZ"));

                try
                {


                    //远程邮件发送开关
                    string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                    if (jmailString == null || jmailString != "true")
                    {

                        //Email email = new Email(realUser.Email, "拼搏在线彩神通软件Email验证（系统自动发送，请勿回复）", result);
                        //email.Send("拼搏在线彩神通软件");
                    }
                    else
                    {
                        //远程调用
                        Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                        wb.GetEmail(realUser.Email, "拼搏在线彩神通软件Email验证（系统自动发送，请勿回复", result);
                    }
                    Pbzx.Common.ErrorLog.WriteLogMeng("申请验证邮件发送", "邮件发送成功", true, true);
                }
                catch (Exception ex)
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("申请验证邮件发送", ex.ToString(), true, true);

                }
                Response.Write(JS.Alert("已经向您的邮箱发送一封验证邮件，请查收！"));
                this.lblEmailYZ.Text = "拼搏在线彩神通软件已处理您的请求，请点击“Email验证”继续。";
                this.btnEmailYZ.Text = "Email验证";
            }
            else if (btnEmailYZ.Text == "Email验证")
            {
                Response.Redirect("/UserCenter/EmailYZ.aspx");
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
    }
}

