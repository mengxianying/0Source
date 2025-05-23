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
    public partial class Delegate_change : System.Web.UI.Page
    { 
         public  string strName = Method.Get_UserName;    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (WebFunc.IsDaili())
                {                 
                    Pbzx.BLL.AgentInfo agentBll = new Pbzx.BLL.AgentInfo();
                    Pbzx.Model.AgentInfo agentModel = agentBll.GetModelName(strName);

                    //txtRealName.Text = agentModel.Name;
                    lblRealName.Text = agentModel.Name;
                    txtTel.Text = agentModel.Telephone;
                    txtMobile.Text = agentModel.Mobile;

                    txtFax.Text = agentModel.Fax;
                    txtEmail.Text = agentModel.EMail;

                    txtPostCode.Text = agentModel.PostCode;
                    txtCompany.Text = agentModel.Company;
                    txtAddress.Text = agentModel.Address;
                    txtRemark.Text = agentModel.Remark;
                    this.lblProvince.Text = agentModel.Province;
                    this.lblExpireDate.Text = agentModel.ExpireDate.ToShortDateString();
                    lblPricePercent.Text = agentModel.PricePercent + "%";
                }
                else {
                                 
                    Response.Write("�������Ǵ����޷��鿴��ҳ�棻");
                    Response.End();  
                }
              // MyInit();

            }
        }
        //private void MyInit()
        //{ 
        //    //��ʡ��
        //    this.ddlProvince.DataSource = DbHelperSQL.Query("select * from PBnet_Province ");
        //    this.ddlProvince.DataTextField = "Name";
        //    this.ddlProvince.DataValueField = "Code";
        //    this.ddlProvince.DataBind();
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            string email = Input.FilterAll(this.txtEmail.Text.Trim());
            if (this.txtTel.Text != null)
            {
                if (!Regex.IsMatch(this.txtTel.Text, @"(\(\d{3}\)|\d{3}-)?\d{8}"))
                {
                    strErrMsg += "�̶��绰��ʽ����.<br/>"; ;
                }
            }
            else if (this.txtMobile.Text != null)
            {
                if (this.txtMobile.Text.Length < 9 || this.txtMobile.Text.Length > 15)
                {
                    strErrMsg += "�ֻ������ʽ����.<br/>"; ;
                }
            }
            if (string.IsNullOrEmpty(email))
            {
                strErrMsg += "�����ʼ�����Ϊ��!<br/>";
            }
            else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                strErrMsg += "Email��ʽ����ȷ";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĵ�����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", strErrMsg, 400, "1", "", "", false, false));
                return;
            }
            else
            {

                Pbzx.BLL.AgentInfo AgentABll = new Pbzx.BLL.AgentInfo();
                Pbzx.Model.AgentInfo AgentAModel = AgentABll.GetModelName(strName);
                //AgentAModel.Name = Input.FilterAll(txtRealName.Text); 
                AgentAModel.Telephone = Input.FilterAll(this.txtTel.Text);
                AgentAModel.Mobile = Input.FilterAll(this.txtMobile.Text);
                AgentAModel.Fax = Input.FilterAll(this.txtFax.Text);
                AgentAModel.EMail = Input.FilterAll(this.txtEmail.Text);
                AgentAModel.PostCode = Input.FilterAll(this.txtPostCode.Text);                 
                AgentAModel.Company = Input.FilterAll(txtCompany.Text);
                AgentAModel.Address = Input.FilterAll(this.txtAddress.Text);
                AgentAModel.Remark = Input.FilterAll(txtRemark.Text);
                // AgentAModel.Status = 1;
                //  AgentAModel.delshow = false;


                if (AgentABll.Update(AgentAModel))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", "������Ϣ�޸ĳɹ�.", 400, "1", "", "", false, false));

                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������Ϣ�޸ĳɹ�."));
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Delegate.aspx"));

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������Ϣ�޸�ʧ��."));
                }
            }

        }
    }
}
