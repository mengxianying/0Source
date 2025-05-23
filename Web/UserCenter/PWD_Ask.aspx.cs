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

namespace Pbzx.Web.UserCenter
{
    public partial class PWD_Ask : System.Web.UI.Page
    {
        public string lblText = "�޸�";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ddlPassWordQuestion.DataSource = WebInit.userConfig.PassWordQuestion.Split(new char[] { ',' });
                ddlPassWordQuestion.DataBind();


                object objMBWT = DbHelperSQLBBS.GetSingle(" select UserQuesion from Dv_User where UserName='" + Method.Get_UserName + "' ");
                if (objMBWT != null && objMBWT.ToString() != "")
                {
                    //this.lblMBWT.Text = objMBWT.ToString();
                    lblText = "�޸�";
                }
                else
                {
                    lblText = "����";
                    this.pnlYanZ.Visible = false;
                    this.pnlXiuG.Visible = true;
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtPassWordAnswer.Text.Trim() == "")
            {
                strErrMsg += "�����������.<br/>";
            }
            if (this.txtPassWordAnswer.Text.Length <2)
            {
                strErrMsg += "����������2������.<br/>";
            }
            if (this.txtPassWordAnswer.Text.ToString() == Method.Get_UserName.ToString())
            {
                strErrMsg += "��ʾ����𰸲��ܺ��û�����ͬ���������޸�.<br/>";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.";
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", strErrMsg, 400, "1", "", "", false, false) + "");
                return;
            }
            else
            {
                string Quesion = this.ddlPassWordQuestion.SelectedValue;
                string Answer = Input.MD5(this.txtPassWordAnswer.Text);
                if (this.ddlPassWordQuestion.SelectedItem.Text == "�Զ�������")
                {
                    if (Quesion.Length < 4)
                    {
                        strErrMsg += "�Զ�����������������4������.<br/>";
                    }
                    if (this.txtWordQuestion.Text.ToString() == Method.Get_UserName.ToString())
                    {
                        strErrMsg += "�Զ������ⲻ�����û�����ͬ.<br/>";
                    }
                    Quesion = this.txtWordQuestion.Text;
                }
                else
                {
                    Quesion = this.ddlPassWordQuestion.SelectedValue;
                }
                if (Quesion == this.txtPassWordAnswer.Text)
                {
                    strErrMsg += "�Զ������ⲻ�ܴ���ͬ.<br/>";
                }
                if (strErrMsg != "")
                {
                    strErrMsg = "���ύ����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.";
                    Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", strErrMsg, 400, "1", "", "", false, false) + "");
                    return;
                }
                else
                {
                    int result = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserQuesion='" + Quesion + "',UserAnswer='" + Answer + "' where UserName='" + Method.Get_UserName + "' ");

                    if (result > 0)
                    {
                        Method.record_user_log(Method.Get_UserName, "", "�޸ĵ�¼�ܱ�", "�������");
                        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "���뱣�����³ɹ���", 400, "1", "location.href='userManage.aspx'", "", false, false) + "");
                        return;
                    }
                    else
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "���뱣������ʧ�ܣ�", 400, "1", "location.href='userManage.aspx'", "", false, false) + "");

                        return;
                    }
                }
            }
        }

        protected void ddlPassWordQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlPassWordQuestion.SelectedItem.Text == "�Զ�������")
            {
                this.ddlPassWordQuestion.Visible = false;
                this.txtWordQuestion.Visible = true;
            }
        }

        protected void btnYZ_Click(object sender, EventArgs e)
        {
            //string answer = Input.MD5(Input.FilterAll(this.txtMBDA.Text));

            string answer = Input.MD5(Input.FilterAll(this.tb_logionPassword.Text));
            //int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle(" select count(UserName)  from Dv_User where UserName='" + Method.Get_UserName + "' and UserQuesion='" + this.lblMBWT.Text + "' and UserAnswer='" + answer + "' "));
            int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle(" select count(UserName)  from Dv_User where UserName='" + Method.Get_UserName + "' and UserPassword='" + answer + "' "));
            if (count < 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "������ľ��ܱ��𰸲���ȷ��", 400, "1", "", "", false, false) + "");
            }
            else
            {
                this.pnlYanZ.Visible = false;
                this.pnlXiuG.Visible = true;
            }
        }
    }
}
