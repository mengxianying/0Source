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
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='UserRealInfo.aspx';}</script>");
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
                        strErrMsg += "��ϵ�绰��ʽ����ȷ.\\r\\n"; ;
                    }
                }
                if (this.txtMobile.Text.Trim() != "")
                {
                    if (this.txtMobile.Text.Length > 13 || this.txtMobile.Text.Length < 9)
                    {
                        strErrMsg += "�ֻ������ʽ����.\\r\\n"; ;
                    }

                }
            }
            else
            {
                strErrMsg += "����������һ����ϵ��ʽ.\\r\\n"; ;
            }
            if (!Regex.IsMatch(this.txtPostCode.Text, @"\d{6}"))
            {
                strErrMsg += "�ʱ��ʽ����ȷ.\\r\\n"; ;
            }

            if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                strErrMsg += "��ϸ��ַ����Ϊ��.\\r\\n"; ;
            }

            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "�����ʼ�����Ϊ��!<br/>";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email��ʽ����ȷ";
            }
            else if (ViewState["strEmail"].ToString() != email && DbHelperSQL.Exists("select * from PBnet_UserTable where Email='" + email + "'"))
            {
                strErrMsg += "�Բ���,����Email�Ѿ���ռ�ã�";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĺ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸ĳɹ�."));
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸�ʧ��."));
            }
        }

        private void MyInit()
        {
            //��ʡ��
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Code";
            this.ddlProvince.DataBind();

            //this.txtUserName.Text = Method.Get_UserName;
            // �Ѿ�ע�����ʵ��Ϣ���޸ġ�
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
        /// ������֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEmailYZ_Click(object sender, EventArgs e)
        {
            if (btnEmailYZ.Text == "������֤" || btnEmailYZ.Text == "����������֤")
            {
                Pbzx.Model.PBnet_UserTable realUser = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                string result = Pbzx.Common.Method.GetEmailContent(("/Template/Email_Success.aspx?type=EmailYZ"));

                try
                {


                    //Զ���ʼ����Ϳ���
                    string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                    if (jmailString == null || jmailString != "true")
                    {

                        //Email email = new Email(realUser.Email, "ƴ�����߲���ͨ���Email��֤��ϵͳ�Զ����ͣ�����ظ���", result);
                        //email.Send("ƴ�����߲���ͨ���");
                    }
                    else
                    {
                        //Զ�̵���
                        Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                        wb.GetEmail(realUser.Email, "ƴ�����߲���ͨ���Email��֤��ϵͳ�Զ����ͣ�����ظ�", result);
                    }
                    Pbzx.Common.ErrorLog.WriteLogMeng("������֤�ʼ�����", "�ʼ����ͳɹ�", true, true);
                }
                catch (Exception ex)
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("������֤�ʼ�����", ex.ToString(), true, true);

                }
                Response.Write(JS.Alert("�Ѿ����������䷢��һ����֤�ʼ�������գ�"));
                this.lblEmailYZ.Text = "ƴ�����߲���ͨ����Ѵ�����������������Email��֤��������";
                this.btnEmailYZ.Text = "Email��֤";
            }
            else if (btnEmailYZ.Text == "Email��֤")
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

