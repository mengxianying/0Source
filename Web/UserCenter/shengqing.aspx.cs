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

            //��ʡ��
            this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
            this.ddlProvince.DataTextField = "Name";
            this.ddlProvince.DataValueField = "Name";
            this.ddlProvince.DataBind();
            this.txtUserName.Text = Method.Get_UserName;
           // this.ddlProvince.Attributes.Add("onchange", "provinceChange('" + this.ddlCity.ClientID + "',this.value)");
            //this.rblBankList.DataSource = WebInit.userConfig.Banks.Split(new char[] { ',' });
            //this.rblBankList.DataBind();
            //this.rblBankList.Items[0].Selected = true;
           
            // �Ѿ�ע�����ʵ��Ϣ���޸ġ�

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
               Response.Write(JS.Alert("���Ѿ���������������ظ����룡", "/Agent.aspx"));
                Response.End();
                return;
            }
            //else if (login["user_Broker"])
            //{
            //    Response.Write(JS.Alert("���Ѿ�������������ˣ��������������", "/Agent.aspx"));
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("�������Ķ�����ע��Э�飬ͬ����ύ!"));
                return;
            }
            //���δ��д��ϸ��Ϣ
            if (this.pnlBroker.Visible)
            {
                if (Session["ValidateCode"] == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("��֤���Ѿ�ʧЧ!"));
                    return;
                }

                if (this.txtYz.Text.ToUpper() != Session["ValidateCode"].ToString())
                {
                    strErrMsg += "��֤���������.\\r\\n"; ;
                }

                if ((this.txtTel.Text.Trim() == "") && (this.txtMobile.Text.Trim() == ""))
                {

                    strErrMsg += "����������һ����ϵ��ʽ.\\r\\n"; ;
                }
                else
                {
                    if (this.txtMobile.Text != null && this.txtMobile.Text.Trim() != "")
                    {
                        if (this.txtMobile.Text.Length < 9 || this.txtMobile.Text.Length > 15)
                        {
                            strErrMsg += "�ֻ������ʽ����.\\r\\n"; ;
                        }
                    }
                    else if (this.txtTel.Text.Trim() != null && this.txtTel.Text.Trim() != "")
                    {
                        if (!Regex.IsMatch(this.txtTel.Text, @"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)"))
                        {
                            strErrMsg += "��ϵ�绰��ʽ����.\\r\\n"; ;
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


                if (strErrMsg != "")
                {
                    strErrMsg = "���ύ�Ĵ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
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
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�����������ύ�ɹ�."));
                        Pbzx.BLL.PinbleLogin loginBll = new Pbzx.BLL.PinbleLogin();
                        loginBll.ReLogin();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("/Agent.aspx"));

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("���������ύʧ��."));
                    }
            
            }

        }

        protected void btcanl_Click(object sender, EventArgs e)
        {

        }
    }
}
