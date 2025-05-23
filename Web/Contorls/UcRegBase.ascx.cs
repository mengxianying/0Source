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
using System.Collections.Generic;

namespace Pbzx.Web.Contorls
{
    public partial class UcRegBase : System.Web.UI.UserControl
    {
        PBnet_UserLog userlogmanager = new PBnet_UserLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnSave.Visible = false;
                ViewState["RegistrationData"] = new Dictionary<string, string>();
                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();
                this.RegeditAgreement.Text = WebInit.userConfig.PersonRegeditAgreement;


            }
        }



        // 下一步按钮通用处理
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int currentStep = Convert.ToInt32(((Button)sender).CommandArgument);
                string strErrMsg = SaveStepData(currentStep);
                if (string.IsNullOrEmpty(strErrMsg))
                {
                    MultiView1.ActiveViewIndex = currentStep;
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                    return;
                }
            }
        }

        // 上一步按钮处理
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex--;
        }

        // 发送验证码（邮箱/手机）
        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string code = GenerateRandomCode();

            if (btn.ID == "btnSendEmailCode")
            {
                Session["EmailCode"] = code;
                //SendEmail(txtEmail.Text, "邮箱验证码", $"您的验证码是：{code} （有效期5分钟）");
            }
            else if (btn.ID == "btnSendSmsCode")
            {
                Session["SmsCode"] = code;
                //SendSms(txtMobile.Text, $"验证码：{code}，5分钟内有效");
            }
        }

        // 保存步骤数据
        private string SaveStepData(int step)
        {
            var data = (Dictionary<string, string>)ViewState["RegistrationData"];
            string strErrMsg = "";
            switch (step)
            {
                case 1:
                    //检查账户信息
                    strErrMsg = checkAccount();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                        break;
                    }
                    else
                    {
                        data["Username"] = Input.FilterAll(this.txtUserName.Text.Trim());
                        data["Password"] = Input.FilterAll(this.txtPassWord.Text.Trim());
                        Session["Username"] = Input.FilterAll(this.txtUserName.Text.Trim());
                        Session["Password"] = Input.MD5(Input.FilterAll(this.txtPassWord.Text.Trim()));
                        break;
                    }
                case 2:
                    //检查邮箱信息
                    strErrMsg = checkEmail();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                        break;
                    }
                    else
                    {
                        data["Email"] = Input.FilterAll(txtEmail.Text);
                        Session["Email"] = Input.FilterAll(txtEmail.Text);
                        break;
                    }
                case 3:
                    //检查手机信息
                    strErrMsg = checkPhone();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                        break;
                    }
                    else
                    {
                        data["Mobile"] = Input.FilterAll(txtQQ.Text);
                        btnSave.Visible = true;
                        break;
                    }
                case 4:
                    //检查密码保护问题信息
                    strErrMsg = checkPW();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                        break;
                    }
                    else
                    {
                        //data["Mobile"] = Input.FilterAll(txtQQ.Text);
                        break;
                    }
            }
            ViewState["RegistrationData"] = data;
            return strErrMsg;


        }

        // 完成注册
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var data = (Dictionary<string, string>)ViewState["RegistrationData"];
                data["SecurityQuestion"] = "";// ddlQuestion.SelectedValue;
                data["SecurityAnswer"] = "";// EncryptPassword(txtAnswer.Text);

                // 保存到数据库
                if (SaveToDatabase(data))
                {
                    MultiView1.Visible = false;
                    lblMessage.Text = "注册成功！";
                    lblMessage.Visible = true;
                }
            }
        }

        // 辅助方法
        private string GenerateRandomCode()
        {
            return new Random().Next(100000, 999999).ToString();
        }

        private string EncryptPassword(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }

        private bool SaveToDatabase(Dictionary<string, string> data)
        {
            return true;
        }



        protected void btnDisagree_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepairMobile.aspx");
        }

        private string checkAccount()
        {
            string strErrMsg = "";
            string userName = "", pwd = "",rePwd="", email = "", answer = "";
            try
            {
                userName = Input.FilterAll(this.txtUserName.Text.Trim());
            }
            catch (Exception ex)
            {
                strErrMsg += "用户名含有非法字符！<br/>";
            }

            try
            {
                pwd = Input.FilterAll(this.txtPassWord.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "登录密码含有非法字符！<br/>";
            }


            try
            {
                rePwd = Input.FilterAll(this.txtRePassWord.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "确认密码含有非法字符！<br/>";
            }


            int strLength = Method.GetStrLen(userName);

            if (userName == "")
            {
                strErrMsg += "用户名不能为空！<br/>";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                strErrMsg += "用户名必须是3-12位(允许字母、数字、汉字)！<br/>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                strErrMsg += "用户名必须是3-12位！<br/>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                strErrMsg += "对不起,您的用户名已经被占用！<br/>";
            }
            else if (userName.ToLower() == "master" || userName.ToLower() == "admin" || userName.ToLower() == "script" || userName.ToLower() == "iframe" || userName.ToLower() == "exists" || userName.ToLower() == "union" || userName.ToLower() == "cast" || userName.ToLower() == "unicode" || userName.ToLower() == "alert" || userName.ToLower() == "exec" || userName.ToLower() == "insert" || userName.ToLower() == "select" || userName.ToLower() == "delete" || userName.ToLower() == "update" || userName.ToLower() == "count" || userName.ToLower() == "chr" || userName.ToLower() == "mid" || userName.ToLower() == "truncate" || userName.ToLower() == "char" || userName.ToLower() == "declare" || userName.ToLower() == "user" || userName.ToLower() == "xp_cmdshell" || userName.ToLower() == "net" || userName.ToLower() == "localgroup" || userName.ToLower() == "administrators" || userName.ToLower() == "asc" || userName.ToLower() == "nchar" || userName.ToLower() == "substring" || userName.ToLower() == "between" || userName.ToLower() == "sysobjects" || userName.ToLower() == "administrators" || userName.ToLower() == "db_name" || userName.ToLower() == "backup" || userName.ToLower() == "object_id" || userName.ToLower() == "xtype")
            {
                strErrMsg += "您输入的用户名包含系统禁止注册字符！<br/>";
            }
            else
            {

                //////////////////////////检测限制IP和地址//////////////////////////////////////////
                //InitRegistIP();
                ////////////////////检测注册过滤字符////////////////////////////////////////////////
                try
                {
                    XmlDocument doc = new XmlDocument();
                    //加载xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                    //得到根节点
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        XmlNode chirot = root.SelectNodes("userchar")[0];
                        string userpb = chirot.SelectSingleNode("@value").Value;
                        if (userpb.Substring(userpb.Length - 1) == ",")
                        {
                            userpb = userpb.Substring(0, userpb.Length - 1);
                        }

                        if (userpb != "")
                        {
                            string[] upb = userpb.Split(',');

                            for (int i = 0; i < upb.Length; i++)
                            {
                                if (userName.Contains(upb[i]))
                                {
                                    strErrMsg += "用户名包含系统禁止注册字符！<br/>";
                                    break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    strErrMsg += "系统繁忙！<br/>";
                }


                object objDvSettings = DbHelperSQLBBS.GetSingle(" select top 1 forum_Setting from Dv_Setup ");
                string strDvSettings = "";
                if (objDvSettings != null && !string.IsNullOrEmpty(objDvSettings.ToString()))
                {
                    strDvSettings = objDvSettings.ToString();
                }
                strDvSettings = strDvSettings.Replace("|||", "｜");
                string[] settingsSZ = strDvSettings.Split(new char[] { '｜' });
                if (settingsSZ.Length >= 5)
                {
                    string[] keyWords = settingsSZ[4].Split(new char[] { ',' });
                    foreach (string temp in keyWords)
                    {
                        if (userName.ToUpper().Contains(temp.ToUpper()))
                        {
                            strErrMsg += "您输入的用户名包含系统禁止注册字符！<br/>";
                            break;
                        }
                    }
                }
                ////////////////////检测注册过滤字符////////////////////////////////////////////////
            }

            if (string.IsNullOrEmpty(pwd))
            {
                strErrMsg += "密码不能为空!<br/>";
            }
            if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            {
                strErrMsg += "密码必须是6-16位的字母和数字!<br/>";
            }
            if (Input.IsInteger(pwd, true) || Input.IsAllLetter(pwd) || pwd.Contains("12345"))
            {
                strErrMsg += "密码过于简单，密码必须是字母和数字的组合!<br/>";
            }
            if(pwd != rePwd)
            {
                 strErrMsg += "两次密码输入不一致!<br/>";
            }
            //Session["Username"] = userName;
            //Session["Password"] = Input.MD5(pwd);
            return strErrMsg;

        }

        private string checkEmail()
        {
            string strErrMsg = "";
            string email = "";
            try
            {
                email = Input.FilterAll(this.txtEmail.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "Email含有非法字符！<br/>";
            }
            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "电子邮件不能为空!<br/>";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email格式不正确";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + email + "'"))
            {
                strErrMsg += "对不起,您的Email已经被占用！";
            }
            else if (Session["Email_CHECKCODE"] == null)
            {
                strErrMsg += "请先获取Email验证码！";
            }
            else if (Input.FilterAll(txtEmailCode.Text) != Session["Email_CHECKCODE"].ToString())
            {
                strErrMsg += "Email验证码错误！";
            }
            //Session["Email"] = email;
            return strErrMsg;
        }

        private string checkPhone()
        {
             string strErrMsg = "";

            String mobile = Input.FilterAll(this.txtQQ.Text);
            String mobilecheckcode = Input.FilterAll(this.txtPhoneCode.Text);

            if (string.IsNullOrEmpty(mobile))
            {
                strErrMsg += "手机号不能为空!<br/>";
            }
            if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "手机验证码不能为空!<br/>";
            }

            if (Session["MOBILE_CHECKCODE"] == null)
            {
                strErrMsg += "请先获取手机验证码！<br/>";
            }
            else if (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
            {
                strErrMsg += "手机验证码错误！<br/>";
            }

            return strErrMsg;
        }

        private string checkPW()
        {
            string strErrMsg = "";
            string userName = "", pwd = "", email = "", answer = "";


            string question = "";
            if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
            {
                try
                {
                    question = Input.FilterAll(this.txtQuestion.Text);
                }
                catch (Exception ex)
                {
                    strErrMsg += "密码提示问题中含有非法字符！<br/>";
                }
                if (question == this.txtUserName.Text.Trim())
                {
                    strErrMsg += "自定义问题不能和用户名相同！<br/>";
                }

            }
            else
            {
                question = this.ddlPassWordQuestion.SelectedValue;
            }
            if (question == "")
            {
                strErrMsg += "自定义密码提示问题不能为空！<br/>";
            }
            if (question == this.txtPassWordAnswer.Text.ToString())
            {
                strErrMsg += "密码提示问题不能和答案相同！<br/>";
            }
            answer = Input.MD5(this.txtPassWordAnswer.Text);

            if (string.IsNullOrEmpty(answer))
            {
                strErrMsg += "密码答案不能为空!<br/>";
            }

            return strErrMsg;
        }


        /// <summary>
        /// 点击注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            string strErrMsg = "";
            string userName = "", pwd = "", email = "", answer = "";
            try
            {
                userName = Input.FilterAll(this.txtUserName.Text.Trim());
            }
            catch (Exception ex)
            {
                strErrMsg += "用户名含有非法字符！<br/>";
            }

            try
            {
                pwd = Input.FilterAll(this.txtPassWord.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "登录密码含有非法字符！<br/>";
            }

            try
            {
                email = Input.FilterAll(this.txtEmail.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "Email含有非法字符！<br/>";
            }

            string question = "";
            if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
            {
                try
                {
                    question = Input.FilterAll(this.txtQuestion.Text);
                }
                catch (Exception ex)
                {
                    strErrMsg += "密码提示问题中含有非法字符！<br/>";
                }
                if (question == this.txtUserName.Text.Trim())
                {
                    strErrMsg += "自定义问题不能和用户名相同！<br/>";
                }

            }
            else
            {
                question = this.ddlPassWordQuestion.SelectedValue;
            }
            if (question == "")
            {
                strErrMsg += "自定义密码提示问题不能为空！<br/>";
            }
            if (question == this.txtPassWordAnswer.Text.ToString())
            {
                strErrMsg += "密码提示问题不能和答案相同！<br/>";
            }
            answer = Input.MD5(this.txtPassWordAnswer.Text);

            int strLength = Method.GetStrLen(userName);

            if (userName == "")
            {
                strErrMsg += "用户名不能为空！<br/>";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                strErrMsg += "用户名必须是3-12位(允许字母、数字、汉字)！<br/>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                strErrMsg += "用户名必须是3-12位！<br/>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                strErrMsg += "对不起,您的用户名已经被占用！<br/>";
            }
            else if (userName.ToLower() == "master" || userName.ToLower() == "admin" || userName.ToLower() == "script" || userName.ToLower() == "iframe" || userName.ToLower() == "exists" || userName.ToLower() == "union" || userName.ToLower() == "cast" || userName.ToLower() == "unicode" || userName.ToLower() == "alert" || userName.ToLower() == "exec" || userName.ToLower() == "insert" || userName.ToLower() == "select" || userName.ToLower() == "delete" || userName.ToLower() == "update" || userName.ToLower() == "count" || userName.ToLower() == "chr" || userName.ToLower() == "mid" || userName.ToLower() == "truncate" || userName.ToLower() == "char" || userName.ToLower() == "declare" || userName.ToLower() == "user" || userName.ToLower() == "xp_cmdshell" || userName.ToLower() == "net" || userName.ToLower() == "localgroup" || userName.ToLower() == "administrators" || userName.ToLower() == "asc" || userName.ToLower() == "nchar" || userName.ToLower() == "substring" || userName.ToLower() == "between" || userName.ToLower() == "sysobjects" || userName.ToLower() == "administrators" || userName.ToLower() == "db_name" || userName.ToLower() == "backup" || userName.ToLower() == "object_id" || userName.ToLower() == "xtype")
            {
                strErrMsg += "您输入的用户名包含系统禁止注册字符！<br/>";
            }
            else
            {

                //////////////////////////检测限制IP和地址//////////////////////////////////////////
                //InitRegistIP();
                ////////////////////检测注册过滤字符////////////////////////////////////////////////
                try
                {
                    XmlDocument doc = new XmlDocument();
                    //加载xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                    //得到根节点
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        XmlNode chirot = root.SelectNodes("userchar")[0];
                        string userpb = chirot.SelectSingleNode("@value").Value;
                        if (userpb.Substring(userpb.Length - 1) == ",")
                        {
                            userpb = userpb.Substring(0, userpb.Length - 1);
                        }

                        if (userpb != "")
                        {
                            string[] upb = userpb.Split(',');

                            for (int i = 0; i < upb.Length; i++)
                            {
                                if (userName.Contains(upb[i]))
                                {
                                    strErrMsg += "用户名包含系统禁止注册字符！<br/>";
                                    break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    strErrMsg += "系统繁忙！<br/>";
                }


                object objDvSettings = DbHelperSQLBBS.GetSingle(" select top 1 forum_Setting from Dv_Setup ");
                string strDvSettings = "";
                if (objDvSettings != null && !string.IsNullOrEmpty(objDvSettings.ToString()))
                {
                    strDvSettings = objDvSettings.ToString();
                }
                strDvSettings = strDvSettings.Replace("|||", "｜");
                string[] settingsSZ = strDvSettings.Split(new char[] { '｜' });
                if (settingsSZ.Length >= 5)
                {
                    string[] keyWords = settingsSZ[4].Split(new char[] { ',' });
                    foreach (string temp in keyWords)
                    {
                        if (userName.ToUpper().Contains(temp.ToUpper()))
                        {
                            strErrMsg += "您输入的用户名包含系统禁止注册字符！<br/>";
                            break;
                        }
                    }
                }
                ////////////////////检测注册过滤字符////////////////////////////////////////////////
            }

            //if (string.IsNullOrEmpty(pwd))
            //{
            //    strErrMsg += "密码不能为空!<br/>";
            //}
            //if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            //{
            //    strErrMsg += "密码必须是6-16位的字母和数字!<br/>";
            //}
            //if (Input.IsInteger(pwd, true) || Input.IsAllLetter(pwd) || pwd.Contains("12345"))
            //{
            //    strErrMsg += "密码过于简单，密码必须是字母和数字的组合!<br/>";
            //}

            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "电子邮件不能为空!<br/>";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email格式不正确";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + email + "'"))
            {
                strErrMsg += "对不起,您的Email已经被占用！";
            }
            //if (string.IsNullOrEmpty(question))
            //{
            //    strErrMsg += "密码问题不能为空!<br/>";
            //}
            if (string.IsNullOrEmpty(answer))
            {
                strErrMsg += "密码答案不能为空!<br/>";
            }

            String mobile = Input.FilterAll(this.txtQQ.Text);
            //String checkcode = Input.FilterAll(this.txtMSN.Text);
            String mobilecheckcode = Input.FilterAll(this.txtPhoneCode.Text);

            if (string.IsNullOrEmpty(mobile))
            {
                strErrMsg += "手机号不能为空!<br/>";
            }
            if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "手机验证码不能为空!<br/>";
            }
            if (Session["MOBILE_CHECKCODE"] == null)
            {
                strErrMsg += "请先获取手机验证码！<br/>";
            }
            else if (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
            {
                strErrMsg += "手机验证码错误！<br/>";
            }


            if (strErrMsg != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                return;
            }

            //bbs论坛插入记录
            //判断是否是被封的IP号和地址
            int result = 0;
            if (XMLMessage())
                result = DbHelperSQLBBS.ExecuteSql("insert into Dv_User(UserName,UserPassword,UserEmail,UserQuesion,UserAnswer,UserClass,LockUser,UserSex,UserFace,UserWidth,UserHeight,UserIM,UserLogins,userWealth,userEP,userCP,UserLastIP,UserFav,UserInfo,UserSetting,UserGroupID,TitlePic,UserMsg,UserToday,MOBILE) values('" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','新兵','1','1','images/userface/image1.gif','48','48','||||||||||||||||||','1','1000','200','30','" + Request.UserHostAddress + "','陌生人,我的好友,黑名单','||||||||||||||||||||||||||||||||||||||||||','1|||0|||0|||0','25','level0.gif','1||264317||拼搏在线彩票论坛','0|0|0|0|0','" + mobile + "')");
            else
                result = DbHelperSQLBBS.ExecuteSql("insert into Dv_User(UserName,UserPassword,UserEmail,UserQuesion,UserAnswer,UserClass,LockUser,UserSex,UserFace,UserWidth,UserHeight,UserIM,UserLogins,userWealth,userEP,userCP,UserLastIP,UserFav,UserInfo,UserSetting,UserGroupID,TitlePic,UserMsg,UserToday,MOBILE) values('" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','新兵','0','1','images/userface/image1.gif','48','48','||||||||||||||||||','1','1000','200','30','" + Request.UserHostAddress + "','陌生人,我的好友,黑名单','||||||||||||||||||||||||||||||||||||||||||','1|||0|||0|||0','25','level0.gif','1||264317||拼搏在线彩票论坛','0|0|0|0|0','" + mobile + "')");


            //判断IP
            string ip = "";
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
            {
                // 得到真实的客户端地址
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
            }
            else//如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP 
            {

                //得到服务端的地址 
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }
            // 由于使用了高防，IP地址堵一样了，所以不能使用下面的判断， 2025-03-18
            ////当IP在用户日志表出现过，并且是被封了的，则注册的用户默认为封号的用户
            //Pbzx.BLL.PBnet_UserLog newsBLL = new Pbzx.BLL.PBnet_UserLog();
            //DataSet ds = newsBLL.GetList(" log_Ip='" + ip + "' and log_state='ID被封'");
            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    DbHelperSQLBBS.ExecuteSql(" update Dv_User set LockUser=1 where username='" + userName + "' and LockUser=0 ");
            //}

            //用户真实信息插入记录
            Pbzx.Model.PBnet_UserTable userReal = new Pbzx.Model.PBnet_UserTable();
            userReal.UserName = userName;
            userReal.Email = email;
            userReal.Mobile = mobile;
            userReal.CreatTime = DateTime.Now;
            Pbzx.BLL.PBnet_UserTable userRealBLL = new Pbzx.BLL.PBnet_UserTable();
            userRealBLL.Add(userReal);
            //聊彩室插入记录
            int chat = DbHelperSQLMeChat.ExecuteSql("insert into UserInfo(UserName,LoginTime,Alias,Password,Email,Question,Answer,Grade,RegistTime,status,IP,LogoutTime,age,sex,Oicq,Icon,Photo,Resume,MOBILE) values('" + userName.ToLower() + "','" + DateTime.Now + "','" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','1','" + DateTime.Now + "','1','" + Request.UserHostAddress + "','" + DateTime.Now + "','20','1','','1','','该用户还未填写个人简介 ','" + mobile + "')");

            //拼搏吧插入记录
            Pbzx.Model.PBnet_ask_User askUserModel = new Pbzx.Model.PBnet_ask_User();
            askUserModel.UserName = userName;
            askUserModel.Point = Int32.Parse(WebInit.siteconfig.regf);
            askUserModel.Pointpenalty = 0;
            askUserModel.OtherPointpenalty = 0;
            askUserModel.AskNum = 0;
            askUserModel.ReplyNum = 0;
            askUserModel.Best_ReplyNum = 0;
            askUserModel.OpenTime = DateTime.Now;
            askUserModel.Ask_DelNum = 0;
            askUserModel.UserGroup = "";
            askUserModel.Score = Int32.Parse(WebInit.siteconfig.regf);


            askUserModel.State = 0;

            Pbzx.BLL.PBnet_ask_User askUserBLL = new Pbzx.BLL.PBnet_ask_User();
            bool ask = askUserBLL.Add(askUserModel);

            if (result > 0 && chat > 0 && ask)
            {
                //DbHelperSQL.ExecuteSql("update PBnet_ask_User set MOBILE='" + mobile + "' where username = '" + userName + "'");

                Method.record_user_log(userName, "", "注册成功", "密码相关");
                Pbzx.BLL.PinbleLogin loginBLL = new Pbzx.BLL.PinbleLogin();
                loginBLL.CheckLogin(userName, pwd);

                this.p3.Visible = false;
                this.pgaoji.Visible = true;

                this.lblNmaeT.Text = userName;
                lblName.Text = userName;
                this.lblUserEmail.Text = email;
                // this.p3.Visible = false;
                //if (Request["ReturnURL"] != null)
                //{
                //    Response.Write(" <script type=\"text/javascript\" src=\"/UserCenter/js/advance.js\"></script>");
                //    Response.Write("<script>if(confirm('恭喜您成功注册为拼搏在线彩神通软件用户！<br/>升级为高级用户您将拥有更多的服务，您是否要升级为高级用户？')){setTimeout(LoadRegNo,100);}else{window.top.location.href='" + Server.UrlDecode(Request["ReturnURL"]) + "';}</script>");
                //    Response.End();
                //    return;
                //}
                //else
                //{
                //    Response.Write(" <script type=\"text/javascript\" src=\"/UserCenter/js/advance.js\"></script>");
                //    Response.Write("<script>if(confirm('恭喜您成功注册为拼搏在线彩神通软件用户！<br/>升级为高级用户您将拥有更多的服务，您是否要升级为高级用户？')){setTimeout(LoadRegNo,100);}else{window.top.location.href='/login.aspx';}</script>");
                //    Response.End();
                //    return;
                //}
                //  Page.ClientScript.RegisterStartupScript(GetType(), "tiao", "<script type='text/javascript'> setTimeout('countDown(3)',2000);<script>");
                //Response.Write("<script   language='javascript'>setTimeout(\"{location.href='/Default.htm'}\",3000);</script>"); 
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "抱歉,由于网络原因注册失败！请您与管理员联系！", 500, "1", "location.href='/.';", "", false, false));
                Response.End();
                return;
            }

        }

        private void InitRegistIP()
        {
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("regist")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //给它不可能的地址
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
                //判断IP
                string ip = "";
                if (Context.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
                {
                    // 得到真实的客户端地址
                    ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
                }
                else//如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP 
                {
                    //得到服务端的地址 
                    ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
                }
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log("游客", "", "已屏蔽该IP用户注册", "注册相关");
                    Response.Redirect("http://www.pinble.com");
                }
                //判断省份
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log("游客", "", "已屏蔽该地址用户注册", "注册相关");
                    Response.Redirect("http://www.pinble.com");
                }
            }
        }

        protected void ddlPassWordQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlPassWordQuestion.SelectedItem.Text == "自定义问题")
            {
                this.txtQuestion.Visible = true;
                this.ddlPassWordQuestion.Visible = false;
            }
        }

        protected void imbbtn_Click(object sender, ImageClickEventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/UserCenter/UserRealInfo.aspx"));
        }

        /// <summary>
        /// 判断是否被封的IP和地址
        /// </summary>
        /// <returns>true or false</returns>
        public bool XMLMessage()
        {

            int number = 0;
            int number1 = 0;
            //判断IP
            string ip = "";
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
            {
                // 得到真实的客户端地址
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
            }
            else//如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP 
            {

                //得到服务端的地址 
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }

            //判断IP是否是在以前日志里出现过，并且是被封的IP
            if (DbHelperSQL.Query("SELECT * FROM PBnet_UserLog where log_state='ID被封' and log_ip='" + ip + "'").Tables[0].Rows.Count > 0)
            {
                number = 1;
            }

            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("pz")[0];
                //得到他的ID
                string address = haha.SelectSingleNode("@address").Value;
                //当IP通过时，再判断省份
                string s_temp = Method.S_getIPaddress(ip);
                //当存在时
                if (NewMethod(s_temp, address))
                {
                    number1 = 1;
                }
            }
            //两方都满足的时候
            if (number == 1 && number1 == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 循环判断
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool NewMethod(string s_temp, string sfs)
        {
            sfs = sfs.Replace("|\r\n", "|");
            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected void btnDisagree_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Register.aspx");
        }


    }
}