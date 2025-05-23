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



        // ��һ����ťͨ�ô���
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
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
                    return;
                }
            }
        }

        // ��һ����ť����
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex--;
        }

        // ������֤�루����/�ֻ���
        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string code = GenerateRandomCode();

            if (btn.ID == "btnSendEmailCode")
            {
                Session["EmailCode"] = code;
                //SendEmail(txtEmail.Text, "������֤��", $"������֤���ǣ�{code} ����Ч��5���ӣ�");
            }
            else if (btn.ID == "btnSendSmsCode")
            {
                Session["SmsCode"] = code;
                //SendSms(txtMobile.Text, $"��֤�룺{code}��5��������Ч");
            }
        }

        // ���沽������
        private string SaveStepData(int step)
        {
            var data = (Dictionary<string, string>)ViewState["RegistrationData"];
            string strErrMsg = "";
            switch (step)
            {
                case 1:
                    //����˻���Ϣ
                    strErrMsg = checkAccount();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
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
                    //���������Ϣ
                    strErrMsg = checkEmail();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
                        break;
                    }
                    else
                    {
                        data["Email"] = Input.FilterAll(txtEmail.Text);
                        Session["Email"] = Input.FilterAll(txtEmail.Text);
                        break;
                    }
                case 3:
                    //����ֻ���Ϣ
                    strErrMsg = checkPhone();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
                        break;
                    }
                    else
                    {
                        data["Mobile"] = Input.FilterAll(txtQQ.Text);
                        btnSave.Visible = true;
                        break;
                    }
                case 4:
                    //������뱣��������Ϣ
                    strErrMsg = checkPW();
                    if (strErrMsg != "")
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
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

        // ���ע��
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var data = (Dictionary<string, string>)ViewState["RegistrationData"];
                data["SecurityQuestion"] = "";// ddlQuestion.SelectedValue;
                data["SecurityAnswer"] = "";// EncryptPassword(txtAnswer.Text);

                // ���浽���ݿ�
                if (SaveToDatabase(data))
                {
                    MultiView1.Visible = false;
                    lblMessage.Text = "ע��ɹ���";
                    lblMessage.Visible = true;
                }
            }
        }

        // ��������
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
                strErrMsg += "�û������зǷ��ַ���<br/>";
            }

            try
            {
                pwd = Input.FilterAll(this.txtPassWord.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "��¼���뺬�зǷ��ַ���<br/>";
            }


            try
            {
                rePwd = Input.FilterAll(this.txtRePassWord.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "ȷ�����뺬�зǷ��ַ���<br/>";
            }


            int strLength = Method.GetStrLen(userName);

            if (userName == "")
            {
                strErrMsg += "�û�������Ϊ�գ�<br/>";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                strErrMsg += "�û���������3-12λ(������ĸ�����֡�����)��<br/>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                strErrMsg += "�û���������3-12λ��<br/>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                strErrMsg += "�Բ���,�����û����Ѿ���ռ�ã�<br/>";
            }
            else if (userName.ToLower() == "master" || userName.ToLower() == "admin" || userName.ToLower() == "script" || userName.ToLower() == "iframe" || userName.ToLower() == "exists" || userName.ToLower() == "union" || userName.ToLower() == "cast" || userName.ToLower() == "unicode" || userName.ToLower() == "alert" || userName.ToLower() == "exec" || userName.ToLower() == "insert" || userName.ToLower() == "select" || userName.ToLower() == "delete" || userName.ToLower() == "update" || userName.ToLower() == "count" || userName.ToLower() == "chr" || userName.ToLower() == "mid" || userName.ToLower() == "truncate" || userName.ToLower() == "char" || userName.ToLower() == "declare" || userName.ToLower() == "user" || userName.ToLower() == "xp_cmdshell" || userName.ToLower() == "net" || userName.ToLower() == "localgroup" || userName.ToLower() == "administrators" || userName.ToLower() == "asc" || userName.ToLower() == "nchar" || userName.ToLower() == "substring" || userName.ToLower() == "between" || userName.ToLower() == "sysobjects" || userName.ToLower() == "administrators" || userName.ToLower() == "db_name" || userName.ToLower() == "backup" || userName.ToLower() == "object_id" || userName.ToLower() == "xtype")
            {
                strErrMsg += "��������û�������ϵͳ��ֹע���ַ���<br/>";
            }
            else
            {

                //////////////////////////�������IP�͵�ַ//////////////////////////////////////////
                //InitRegistIP();
                ////////////////////���ע������ַ�////////////////////////////////////////////////
                try
                {
                    XmlDocument doc = new XmlDocument();
                    //����xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                    //�õ����ڵ�
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
                                    strErrMsg += "�û�������ϵͳ��ֹע���ַ���<br/>";
                                    break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    strErrMsg += "ϵͳ��æ��<br/>";
                }


                object objDvSettings = DbHelperSQLBBS.GetSingle(" select top 1 forum_Setting from Dv_Setup ");
                string strDvSettings = "";
                if (objDvSettings != null && !string.IsNullOrEmpty(objDvSettings.ToString()))
                {
                    strDvSettings = objDvSettings.ToString();
                }
                strDvSettings = strDvSettings.Replace("|||", "��");
                string[] settingsSZ = strDvSettings.Split(new char[] { '��' });
                if (settingsSZ.Length >= 5)
                {
                    string[] keyWords = settingsSZ[4].Split(new char[] { ',' });
                    foreach (string temp in keyWords)
                    {
                        if (userName.ToUpper().Contains(temp.ToUpper()))
                        {
                            strErrMsg += "��������û�������ϵͳ��ֹע���ַ���<br/>";
                            break;
                        }
                    }
                }
                ////////////////////���ע������ַ�////////////////////////////////////////////////
            }

            if (string.IsNullOrEmpty(pwd))
            {
                strErrMsg += "���벻��Ϊ��!<br/>";
            }
            if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            {
                strErrMsg += "���������6-16λ����ĸ������!<br/>";
            }
            if (Input.IsInteger(pwd, true) || Input.IsAllLetter(pwd) || pwd.Contains("12345"))
            {
                strErrMsg += "������ڼ򵥣������������ĸ�����ֵ����!<br/>";
            }
            if(pwd != rePwd)
            {
                 strErrMsg += "�����������벻һ��!<br/>";
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
                strErrMsg += "Email���зǷ��ַ���<br/>";
            }
            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "�����ʼ�����Ϊ��!<br/>";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email��ʽ����ȷ";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + email + "'"))
            {
                strErrMsg += "�Բ���,����Email�Ѿ���ռ�ã�";
            }
            else if (Session["Email_CHECKCODE"] == null)
            {
                strErrMsg += "���Ȼ�ȡEmail��֤�룡";
            }
            else if (Input.FilterAll(txtEmailCode.Text) != Session["Email_CHECKCODE"].ToString())
            {
                strErrMsg += "Email��֤�����";
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
                strErrMsg += "�ֻ��Ų���Ϊ��!<br/>";
            }
            if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "�ֻ���֤�벻��Ϊ��!<br/>";
            }

            if (Session["MOBILE_CHECKCODE"] == null)
            {
                strErrMsg += "���Ȼ�ȡ�ֻ���֤�룡<br/>";
            }
            else if (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
            {
                strErrMsg += "�ֻ���֤�����<br/>";
            }

            return strErrMsg;
        }

        private string checkPW()
        {
            string strErrMsg = "";
            string userName = "", pwd = "", email = "", answer = "";


            string question = "";
            if (this.ddlPassWordQuestion.SelectedItem.Text == "�Զ�������")
            {
                try
                {
                    question = Input.FilterAll(this.txtQuestion.Text);
                }
                catch (Exception ex)
                {
                    strErrMsg += "������ʾ�����к��зǷ��ַ���<br/>";
                }
                if (question == this.txtUserName.Text.Trim())
                {
                    strErrMsg += "�Զ������ⲻ�ܺ��û�����ͬ��<br/>";
                }

            }
            else
            {
                question = this.ddlPassWordQuestion.SelectedValue;
            }
            if (question == "")
            {
                strErrMsg += "�Զ���������ʾ���ⲻ��Ϊ�գ�<br/>";
            }
            if (question == this.txtPassWordAnswer.Text.ToString())
            {
                strErrMsg += "������ʾ���ⲻ�ܺʹ���ͬ��<br/>";
            }
            answer = Input.MD5(this.txtPassWordAnswer.Text);

            if (string.IsNullOrEmpty(answer))
            {
                strErrMsg += "����𰸲���Ϊ��!<br/>";
            }

            return strErrMsg;
        }


        /// <summary>
        /// ���ע��
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
                strErrMsg += "�û������зǷ��ַ���<br/>";
            }

            try
            {
                pwd = Input.FilterAll(this.txtPassWord.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "��¼���뺬�зǷ��ַ���<br/>";
            }

            try
            {
                email = Input.FilterAll(this.txtEmail.Text);
            }
            catch (Exception ex)
            {
                strErrMsg += "Email���зǷ��ַ���<br/>";
            }

            string question = "";
            if (this.ddlPassWordQuestion.SelectedItem.Text == "�Զ�������")
            {
                try
                {
                    question = Input.FilterAll(this.txtQuestion.Text);
                }
                catch (Exception ex)
                {
                    strErrMsg += "������ʾ�����к��зǷ��ַ���<br/>";
                }
                if (question == this.txtUserName.Text.Trim())
                {
                    strErrMsg += "�Զ������ⲻ�ܺ��û�����ͬ��<br/>";
                }

            }
            else
            {
                question = this.ddlPassWordQuestion.SelectedValue;
            }
            if (question == "")
            {
                strErrMsg += "�Զ���������ʾ���ⲻ��Ϊ�գ�<br/>";
            }
            if (question == this.txtPassWordAnswer.Text.ToString())
            {
                strErrMsg += "������ʾ���ⲻ�ܺʹ���ͬ��<br/>";
            }
            answer = Input.MD5(this.txtPassWordAnswer.Text);

            int strLength = Method.GetStrLen(userName);

            if (userName == "")
            {
                strErrMsg += "�û�������Ϊ�գ�<br/>";
            }
            else if (!Regex.IsMatch(userName, @"^[\u4E00-\u9FA5a-zA-Z0-9]+$"))
            {
                strErrMsg += "�û���������3-12λ(������ĸ�����֡�����)��<br/>";
            }
            else if (strLength < 3 || strLength > 12)
            {
                strErrMsg += "�û���������3-12λ��<br/>";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                strErrMsg += "�Բ���,�����û����Ѿ���ռ�ã�<br/>";
            }
            else if (userName.ToLower() == "master" || userName.ToLower() == "admin" || userName.ToLower() == "script" || userName.ToLower() == "iframe" || userName.ToLower() == "exists" || userName.ToLower() == "union" || userName.ToLower() == "cast" || userName.ToLower() == "unicode" || userName.ToLower() == "alert" || userName.ToLower() == "exec" || userName.ToLower() == "insert" || userName.ToLower() == "select" || userName.ToLower() == "delete" || userName.ToLower() == "update" || userName.ToLower() == "count" || userName.ToLower() == "chr" || userName.ToLower() == "mid" || userName.ToLower() == "truncate" || userName.ToLower() == "char" || userName.ToLower() == "declare" || userName.ToLower() == "user" || userName.ToLower() == "xp_cmdshell" || userName.ToLower() == "net" || userName.ToLower() == "localgroup" || userName.ToLower() == "administrators" || userName.ToLower() == "asc" || userName.ToLower() == "nchar" || userName.ToLower() == "substring" || userName.ToLower() == "between" || userName.ToLower() == "sysobjects" || userName.ToLower() == "administrators" || userName.ToLower() == "db_name" || userName.ToLower() == "backup" || userName.ToLower() == "object_id" || userName.ToLower() == "xtype")
            {
                strErrMsg += "��������û�������ϵͳ��ֹע���ַ���<br/>";
            }
            else
            {

                //////////////////////////�������IP�͵�ַ//////////////////////////////////////////
                //InitRegistIP();
                ////////////////////���ע������ַ�////////////////////////////////////////////////
                try
                {
                    XmlDocument doc = new XmlDocument();
                    //����xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                    //�õ����ڵ�
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
                                    strErrMsg += "�û�������ϵͳ��ֹע���ַ���<br/>";
                                    break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    strErrMsg += "ϵͳ��æ��<br/>";
                }


                object objDvSettings = DbHelperSQLBBS.GetSingle(" select top 1 forum_Setting from Dv_Setup ");
                string strDvSettings = "";
                if (objDvSettings != null && !string.IsNullOrEmpty(objDvSettings.ToString()))
                {
                    strDvSettings = objDvSettings.ToString();
                }
                strDvSettings = strDvSettings.Replace("|||", "��");
                string[] settingsSZ = strDvSettings.Split(new char[] { '��' });
                if (settingsSZ.Length >= 5)
                {
                    string[] keyWords = settingsSZ[4].Split(new char[] { ',' });
                    foreach (string temp in keyWords)
                    {
                        if (userName.ToUpper().Contains(temp.ToUpper()))
                        {
                            strErrMsg += "��������û�������ϵͳ��ֹע���ַ���<br/>";
                            break;
                        }
                    }
                }
                ////////////////////���ע������ַ�////////////////////////////////////////////////
            }

            //if (string.IsNullOrEmpty(pwd))
            //{
            //    strErrMsg += "���벻��Ϊ��!<br/>";
            //}
            //if ((!string.IsNullOrEmpty(pwd) && (!Regex.IsMatch(pwd, @"^[a-zA-Z0-9_]{6,18}$"))))
            //{
            //    strErrMsg += "���������6-16λ����ĸ������!<br/>";
            //}
            //if (Input.IsInteger(pwd, true) || Input.IsAllLetter(pwd) || pwd.Contains("12345"))
            //{
            //    strErrMsg += "������ڼ򵥣������������ĸ�����ֵ����!<br/>";
            //}

            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "�����ʼ�����Ϊ��!<br/>";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email��ʽ����ȷ";
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + email + "'"))
            {
                strErrMsg += "�Բ���,����Email�Ѿ���ռ�ã�";
            }
            //if (string.IsNullOrEmpty(question))
            //{
            //    strErrMsg += "�������ⲻ��Ϊ��!<br/>";
            //}
            if (string.IsNullOrEmpty(answer))
            {
                strErrMsg += "����𰸲���Ϊ��!<br/>";
            }

            String mobile = Input.FilterAll(this.txtQQ.Text);
            //String checkcode = Input.FilterAll(this.txtMSN.Text);
            String mobilecheckcode = Input.FilterAll(this.txtPhoneCode.Text);

            if (string.IsNullOrEmpty(mobile))
            {
                strErrMsg += "�ֻ��Ų���Ϊ��!<br/>";
            }
            if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "�ֻ���֤�벻��Ϊ��!<br/>";
            }
            if (Session["MOBILE_CHECKCODE"] == null)
            {
                strErrMsg += "���Ȼ�ȡ�ֻ���֤�룡<br/>";
            }
            else if (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
            {
                strErrMsg += "�ֻ���֤�����<br/>";
            }


            if (strErrMsg != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
                return;
            }

            //bbs��̳�����¼
            //�ж��Ƿ��Ǳ����IP�ź͵�ַ
            int result = 0;
            if (XMLMessage())
                result = DbHelperSQLBBS.ExecuteSql("insert into Dv_User(UserName,UserPassword,UserEmail,UserQuesion,UserAnswer,UserClass,LockUser,UserSex,UserFace,UserWidth,UserHeight,UserIM,UserLogins,userWealth,userEP,userCP,UserLastIP,UserFav,UserInfo,UserSetting,UserGroupID,TitlePic,UserMsg,UserToday,MOBILE) values('" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','�±�','1','1','images/userface/image1.gif','48','48','||||||||||||||||||','1','1000','200','30','" + Request.UserHostAddress + "','İ����,�ҵĺ���,������','||||||||||||||||||||||||||||||||||||||||||','1|||0|||0|||0','25','level0.gif','1||264317||ƴ�����߲�Ʊ��̳','0|0|0|0|0','" + mobile + "')");
            else
                result = DbHelperSQLBBS.ExecuteSql("insert into Dv_User(UserName,UserPassword,UserEmail,UserQuesion,UserAnswer,UserClass,LockUser,UserSex,UserFace,UserWidth,UserHeight,UserIM,UserLogins,userWealth,userEP,userCP,UserLastIP,UserFav,UserInfo,UserSetting,UserGroupID,TitlePic,UserMsg,UserToday,MOBILE) values('" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','�±�','0','1','images/userface/image1.gif','48','48','||||||||||||||||||','1','1000','200','30','" + Request.UserHostAddress + "','İ����,�ҵĺ���,������','||||||||||||||||||||||||||||||||||||||||||','1|||0|||0|||0','25','level0.gif','1||264317||ƴ�����߲�Ʊ��̳','0|0|0|0|0','" + mobile + "')");


            //�ж�IP
            string ip = "";
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // �������� using proxy 
            {
                // �õ���ʵ�Ŀͻ��˵�ַ
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
            }
            else//���û��ʹ�ô�����������ߵò����ͻ��˵�ip  not using proxy or can't get the Client IP 
            {

                //�õ�����˵ĵ�ַ 
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }
            // ����ʹ���˸߷���IP��ַ��һ���ˣ����Բ���ʹ��������жϣ� 2025-03-18
            ////��IP���û���־����ֹ��������Ǳ����˵ģ���ע����û�Ĭ��Ϊ��ŵ��û�
            //Pbzx.BLL.PBnet_UserLog newsBLL = new Pbzx.BLL.PBnet_UserLog();
            //DataSet ds = newsBLL.GetList(" log_Ip='" + ip + "' and log_state='ID����'");
            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    DbHelperSQLBBS.ExecuteSql(" update Dv_User set LockUser=1 where username='" + userName + "' and LockUser=0 ");
            //}

            //�û���ʵ��Ϣ�����¼
            Pbzx.Model.PBnet_UserTable userReal = new Pbzx.Model.PBnet_UserTable();
            userReal.UserName = userName;
            userReal.Email = email;
            userReal.Mobile = mobile;
            userReal.CreatTime = DateTime.Now;
            Pbzx.BLL.PBnet_UserTable userRealBLL = new Pbzx.BLL.PBnet_UserTable();
            userRealBLL.Add(userReal);
            //�Ĳ��Ҳ����¼
            int chat = DbHelperSQLMeChat.ExecuteSql("insert into UserInfo(UserName,LoginTime,Alias,Password,Email,Question,Answer,Grade,RegistTime,status,IP,LogoutTime,age,sex,Oicq,Icon,Photo,Resume,MOBILE) values('" + userName.ToLower() + "','" + DateTime.Now + "','" + userName + "','" + Input.MD5(pwd) + "','" + email + "','" + question + "','" + answer + "','1','" + DateTime.Now + "','1','" + Request.UserHostAddress + "','" + DateTime.Now + "','20','1','','1','','���û���δ��д���˼�� ','" + mobile + "')");

            //ƴ���ɲ����¼
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

                Method.record_user_log(userName, "", "ע��ɹ�", "�������");
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
                //    Response.Write("<script>if(confirm('��ϲ���ɹ�ע��Ϊƴ�����߲���ͨ����û���<br/>����Ϊ�߼��û�����ӵ�и���ķ������Ƿ�Ҫ����Ϊ�߼��û���')){setTimeout(LoadRegNo,100);}else{window.top.location.href='" + Server.UrlDecode(Request["ReturnURL"]) + "';}</script>");
                //    Response.End();
                //    return;
                //}
                //else
                //{
                //    Response.Write(" <script type=\"text/javascript\" src=\"/UserCenter/js/advance.js\"></script>");
                //    Response.Write("<script>if(confirm('��ϲ���ɹ�ע��Ϊƴ�����߲���ͨ����û���<br/>����Ϊ�߼��û�����ӵ�и���ķ������Ƿ�Ҫ����Ϊ�߼��û���')){setTimeout(LoadRegNo,100);}else{window.top.location.href='/login.aspx';}</script>");
                //    Response.End();
                //    return;
                //}
                //  Page.ClientScript.RegisterStartupScript(GetType(), "tiao", "<script type='text/javascript'> setTimeout('countDown(3)',2000);<script>");
                //Response.Write("<script   language='javascript'>setTimeout(\"{location.href='/Default.htm'}\",3000);</script>"); 
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "��Ǹ,��������ԭ��ע��ʧ�ܣ����������Ա��ϵ��", 500, "1", "location.href='/.';", "", false, false));
                Response.End();
                return;
            }

        }

        private void InitRegistIP()
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("regist")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //���������ܵĵ�ַ
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
                //�ж�IP
                string ip = "";
                if (Context.Request.ServerVariables["HTTP_VIA"] != null) // �������� using proxy 
                {
                    // �õ���ʵ�Ŀͻ��˵�ַ
                    ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
                }
                else//���û��ʹ�ô�����������ߵò����ͻ��˵�ip  not using proxy or can't get the Client IP 
                {
                    //�õ�����˵ĵ�ַ 
                    ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
                }
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log("�ο�", "", "�����θ�IP�û�ע��", "ע�����");
                    Response.Redirect("http://www.pinble.com");
                }
                //�ж�ʡ��
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log("�ο�", "", "�����θõ�ַ�û�ע��", "ע�����");
                    Response.Redirect("http://www.pinble.com");
                }
            }
        }

        protected void ddlPassWordQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlPassWordQuestion.SelectedItem.Text == "�Զ�������")
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
        /// �ж��Ƿ񱻷��IP�͵�ַ
        /// </summary>
        /// <returns>true or false</returns>
        public bool XMLMessage()
        {

            int number = 0;
            int number1 = 0;
            //�ж�IP
            string ip = "";
            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // �������� using proxy 
            {
                // �õ���ʵ�Ŀͻ��˵�ַ
                ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
            }
            else//���û��ʹ�ô�����������ߵò����ͻ��˵�ip  not using proxy or can't get the Client IP 
            {

                //�õ�����˵ĵ�ַ 
                ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }

            //�ж�IP�Ƿ�������ǰ��־����ֹ��������Ǳ����IP
            if (DbHelperSQL.Query("SELECT * FROM PBnet_UserLog where log_state='ID����' and log_ip='" + ip + "'").Tables[0].Rows.Count > 0)
            {
                number = 1;
            }

            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("pz")[0];
                //�õ�����ID
                string address = haha.SelectSingleNode("@address").Value;
                //��IPͨ��ʱ�����ж�ʡ��
                string s_temp = Method.S_getIPaddress(ip);
                //������ʱ
                if (NewMethod(s_temp, address))
                {
                    number1 = 1;
                }
            }
            //�����������ʱ��
            if (number == 1 && number1 == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// ѭ���ж�
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