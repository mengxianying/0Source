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
    public partial class ChatRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();        
            }

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            //this.p2.Visible = false;
            string userName = Input.FilterAll(this.txtUserName.Text);
            string pwd = Input.FilterAll(this.txtPassWord.Text);
            string age = Input.FilterAll(txtAge.Text);
            string sex = rblSex.SelectedValue;
            string email = Input.FilterAll(this.txtEmail.Text);
            string Oicq = Input.FilterAll(this.txtOicq.Text);
            string question = this.ddlPassWordQuestion.SelectedValue;
            string answer = Input.FilterAll(this.txtPassWordAnswer.Text);
            string resume = Input.FilterAll(this.txtResume.Text);
            string strErrMsg = "";
            int strLength = Method.GetStrLen(userName);
            if (userName == "")
            {
                strErrMsg += "用户名不能为空！\\r\\n";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                strErrMsg += "用户名只允许字母、数字、汉字！\\r\\n";
            }
            else if (strLength < 3 || strLength > 12)
            {
                strErrMsg += "用户名必须是3-12位！\\r\\n";
            }
            else if (DbHelperSQLBBS.Exists("select count(1) from Dv_User where UserName='" + userName + "'"))
            {
                strErrMsg += "对不起,您的用户名已经被占用！\\r\\n";
            }


            if (string.IsNullOrEmpty(pwd))
            {
                strErrMsg += "密码不能为空!\\r\\n";
            }
            if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            {
                strErrMsg += "密码必须是6-16位的字母和数字!\\r\\n";
            }

            if(string.IsNullOrEmpty(age))
            {
                strErrMsg += "年龄不能为空!\\r\\n";
            }
            else if (!Regex.IsMatch(age, @"^[0-9]+$"))
            {
                strErrMsg += "年龄必须为数字";
            }
            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "电子邮件不能为空!\\r\\n";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email格式不正确";
            }
            else if (DbHelperSQLBBS.Exists("select count(1)  from Dv_User where UserEmail='" + email + "'"))
            {
                strErrMsg += "对不起,您的Email已经被占用！";
            }

            if (string.IsNullOrEmpty(question))
            {
                strErrMsg += "密码问题不能为空!\\r\\n";
            }
            if (string.IsNullOrEmpty(answer))
            {
                strErrMsg += "密码答案不能为空!\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的新闻信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            //bbs论坛插入记录
            int result = DbHelperSQLBBS.ExecuteSql("insert into Dv_User(UserName,UserPassword,UserEmail,UserQuesion,UserAnswer,UserClass,UserFace,UserIM,JoinDate) values('" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','新兵','images/userface/image1.gif','||||||||||||||||||','"+DateTime.Now+"')");
            //用户真实信息插入记录
            Pbzx.Model.PBnet_UserTable userReal = new Pbzx.Model.PBnet_UserTable();
            userReal.UserName = userName;
            userReal.Email = email;
            userReal.CreatTime = DateTime.Now;
            userReal.CurrentMoney = 0;
            userReal.FrozenMoney = 0;
            Pbzx.BLL.PBnet_UserTable userRealBLL = new Pbzx.BLL.PBnet_UserTable();
            userRealBLL.Add(userReal);
            //聊彩室插入记录
            string[] icon = hfImg.Value.Split(new char[] { '/' });
            string icon1 = icon[1].Substring(0, icon[1].Length - 4);
            int chat = DbHelperSQLMeChat.ExecuteSql("insert into UserInfo(UserName,LoginTime,Alias,Password,Email,Question,Answer,Grade,RegistTime,status,IP,LogoutTime,age,sex,Oicq,Icon,Photo,Resume) values('" + userName + "','" + DateTime.Now + "','" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','1','" + DateTime.Now + "','1','" + Request.UserHostAddress + "','" + DateTime.Now + "','"+age+"','"+rblSex.SelectedValue+"','"+Oicq+"','"+icon1+"','','"+resume+"')");

            //密码保护表插入记录
            int mifa = DbHelperSQL.ExecuteSql("insert into PBnet_UserProtectPwd(UserName,SecurityQuestion,Answer,Email) values('" + userName + "','" + question + "','" + answer + "','" + email + "')");
            //拼搏吧插入记录
            Pbzx.Model.PBnet_ask_User askUserModel = new Pbzx.Model.PBnet_ask_User();
            askUserModel.OpenTime = DateTime.Now;
            askUserModel.Point = 300;
            askUserModel.Score = 300;
            askUserModel.State = 0;
            askUserModel.UserName = userName;
            Pbzx.BLL.PBnet_ask_User askUserBLL = new Pbzx.BLL.PBnet_ask_User();
            bool ask = askUserBLL.Add(askUserModel);

            if (result > 0 && chat > 0 && mifa > 0 && ask)
            {
                Pbzx.BLL.PinbleLogin loginBLL = new Pbzx.BLL.PinbleLogin();
                loginBLL.CheckLogin(userName, pwd);
                if (Request["ReturnURL"] != null)
                {
                    Response.Write("<script>alert('注册成功！');window.top.location.href='" + Server.UrlDecode(Request["ReturnURL"]) + "';</script>");
                    Response.End();
                }
                else
                {
                    Response.Redirect(WebInit.webBaseConfig.WebUrl);
                }
                //  Page.ClientScript.RegisterStartupScript(GetType(), "tiao", "<script type='text/javascript'> setTimeout('countDown(3)',2000);<script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "error", "<script type='text/javascript'>alert('抱歉,由于网络原因注册失败！请您与管理员联系！'); location.href='/.';<script>");
                Response.End();
                return;
            }
        }

        protected void rblSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rblSex.Items[0].Selected)
            {
                this.imgPhoto.ImageUrl = "icon/1.gif";
                this.hfImg.Value = "icon/1.gif";
            }
            else
            {
                this.imgPhoto.ImageUrl = "icon/0.gif";
                this.hfImg.Value = "icon/0.gif";
            }
          
        }
    }
}
