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
                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();
                if (Pbzx.Common.Method.Get_UserName == "0")
                {
                    Response.Write("<script>alert('����û�е�¼��\\r\\n�����ȵ�¼��Ȼ�������룡');</script>");
                    Response.Redirect("Agent.aspx");
                    return;
                }
                MyInit();
             //   this.BrokerAgreement.Text = WebInit.userConfig.BrokerAgreement;
            }
        }
        private void MyInit()
        {
            LoginSort login = new LoginSort();
            //��ʡ��
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Code";
            this.ddlProvince.DataBind();
            this.ddlProvince.Attributes.Add("onchange", "provinceChange('" + this.ddlCity.ClientID + "',this.value)");
            this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
            this.rblBankList.DataBind();
            this.rblBankList.Items[0].Selected = true;
            this.txtUserName.Text = Method.Get_UserName;
            // �Ѿ�ע�����ʵ��Ϣ���޸ġ�

            if (login["user_RealInfo"])
            {
                this.already.Visible = true;
                this.really.Visible = false;
                this.tishi.Visible = false;
                this.btkai.Visible = true;
                this.btsave.Visible = false;             
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

        protected void btsave_Click(object sender, EventArgs e)
        {
            string Name = Method.Get_UserName;
            string email =Input.FilterAll(this.txtEmail.Text.Trim());
            LoginSort login = new LoginSort();
            string strErrMsg = "";
            if (this.ChkBroker.Checked != true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("�������Ķ�������ע��Э�飬ͬ����ύ!"));
                return;
            }
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("��֤���Ѿ�ʧЧ!"));
                return;
            }

            if (this.txtYz.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                strErrMsg += "��֤���������.\\r\\n"; ;
            }

            if ((this.txtTel.Text == null) && (this.txtMobile.Text == null))
            {

                strErrMsg += "����������һ����ϵ��ʽ.\\r\\n"; ;
            }
            else
            {
                if (this.txtTel.Text != null)
                {
                    if (this.txtTel.Text.Length < 9 || this.txtTel.Text.Length > 13)
                    {
                        strErrMsg += "�̶��绰��ʽ����.\\r\\n"; ;
                    }
                }
                else if (this.txtMobile.Text != null)
                {
                    if (this.txtMobile.Text.Length < 9 || this.txtMobile.Text.Length > 15)
                    {
                        strErrMsg += "�ֻ������ʽ����.\\r\\n"; ;
                    }
                }

            }
            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "�����ʼ�����Ϊ��!\\r\\n";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email��ʽ����ȷ";
            }
            else if (DbHelperSQL.Exists("select * from PBnet_UserProtectPwd where Email='" + Input.FilterAll(this.txtEmail.Text.Trim()) + "'"))
            {
                strErrMsg += "�Բ���,����Email�Ѿ���ռ�ã�";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĺ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
            }
            Pbzx.BLL.PBnet_UserTable UserBLL = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable UserModel = new Pbzx.Model.PBnet_UserTable();

            Pbzx.BLL.PBnet_UserProtectPwd PwdBLL = new Pbzx.BLL.PBnet_UserProtectPwd();
            Pbzx.Model.PBnet_UserProtectPwd PwdModel = new Pbzx.Model.PBnet_UserProtectPwd();


            PwdModel.UserName = Input.FilterAll(this.txtUserName.Text);
            PwdModel.Email = email;
            if (this.ddlPassWordQuestion.SelectedItem.Text == "�Զ�������")
            {
                PwdModel.SecurityQuestion = Input.FilterAll(this.txtQuestion.Text);
            }
            else
            {
                PwdModel.SecurityQuestion = this.ddlPassWordQuestion.SelectedValue;
            }
            PwdModel.Answer = Input.MD5(Input.FilterAll(this.txtPassWordAnswer.Text));


             Pbzx.BLL.AgentInfo_Apply AgentABll = new Pbzx.BLL.AgentInfo_Apply();
             Pbzx.Model.AgentInfo_Apply AgentAModel = new Pbzx.Model.AgentInfo_Apply();

            UserModel.UserName = Input.FilterAll(txtUserName.Text.Trim());
            UserModel.RealName = Input.FilterAll(this.txtRealName.Text);
            UserModel.TradePwd = Input.FilterAll(this.txtTPWD.Text);
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
            AgentAModel.Name = Input.FilterAll(txtUserName.Text.Trim());
            AgentAModel.Company = Input.FilterAll(txtCompany.Text.Trim());
            AgentAModel.Remark = Input.FilterAll(txtRemark.Text.Trim());
            AgentAModel.ExpireDate =Convert.ToDateTime(DateTime.Now.ToLongDateString());
            AgentAModel.Status = 1;
            AgentAModel.delshow = Convert.ToBoolean("0".ToString());

            //if (login["user_RealInfo"] && login["user_Broker"])
            //{
            //    if (UserBLL.Update(UserModel) && BkBLL.Update(BkModel))
            //    {
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸ĳɹ�."));
            //    }
            //    else
            //    {
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸�ʧ��."));
            //    }
            //}
            //else
            //{
            if (UserBLL.Add(UserModel) && AgentABll.Add(AgentAModel) && PwdBLL.Add(PwdModel))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("ע��ɹ�."));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Agent.aspx"));

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("ע��ʧ��."));
                }
           // }

        }

        protected void btcanl_Click(object sender, EventArgs e)
        {

        }

        protected void btkai_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("��֤���Ѿ�ʧЧ!"));
                return;
            }

            if (this.txtYz.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                strErrMsg += "��֤���������.\\r\\n"; ;
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĺ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
            }

            Pbzx.BLL.AgentInfo_Apply AgentABll = new Pbzx.BLL.AgentInfo_Apply();
            Pbzx.Model.AgentInfo_Apply AgentAModel = new Pbzx.Model.AgentInfo_Apply();

            AgentAModel.Name = Input.FilterAll(txtUserName.Text.Trim());
            AgentAModel.Company = Input.FilterAll(txtCompany.Text.Trim());
            AgentAModel.Remark = Input.FilterAll(txtRemark.Text.Trim());
            AgentAModel.ExpireDate =Convert.ToDateTime(DateTime.Now.ToLongDateString());
            AgentAModel.Status = 1;
            AgentAModel.delshow = Convert.ToBoolean("0".ToString());
          
            if (AgentABll.Add(AgentAModel))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("����ɹ�."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Agent.aspx"));
            }
            else {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("����ʧ��."));
            }

        }
    }
}
