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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class Usermsg_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
           {
                Pbzx.BLL.CN_User userBLL = new Pbzx.BLL.CN_User();
                Pbzx.Model.CN_User Myuser;

                string str=Request.QueryString["ID"];
                Myuser = userBLL.GetModel(Convert.ToInt32(str));

                this.lblUsername.Text = Myuser.Username;
                this.lbluserType.Text ="�շ�"+GetUserType(Myuser.UserType);
                this.lblSoftwareType.Text = ChkSoftType(Myuser.SoftwareType, Myuser.InstallType); 

                this.lblUseCount.Text = Myuser.UseCount.ToString();
                this.lblServiceID.Text = Myuser.ServiceID.ToString();
                this.lblLastLoginID.Text = Myuser.LastLoginID.ToString();

                this.lblHDSNList.Text = Myuser.HDSNList;
                this.txtUserRemarks.Text = Myuser.UserRemarks;
                this.lblExpireDate.Text = Myuser.ExpireDate.ToString();

                this.lblValidDays.Text = Myuser.ValidDays.ToString();
                this.lblCreateTime.Text = Myuser.CreateTime.ToString();
                this.txtStatResult.Text = Myuser.StatResult.ToString();

                this.lblLastPayTime.Text = Myuser.LastPayTime.ToString();
                this.txtRemarks.Text = Myuser.Remarks;
            }
        }

        //ʹ������
        protected string GetUserType(object objUserType)
        {
            string strUserType = objUserType.ToString();
            string result = "";
            switch (strUserType)
            {
                case "1":
                    result = "����";
                    break;
                case "2":
                    result = "����";
                    break;
                case "3":
                    result = "��ʱ";
                    break;
                default:
                    result = "����";
                    break;
            }
            return result;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="num"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        protected string ChkSoftType(object num, object st)
        {

            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return result[0] + "(" + result[1] + ")";
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            if (!OperateText.IsNumber(this.txtStatResult.Text))
            {
                strErrMsg += "����ͳ�Ʋ�������.\\r\\n";
            }       
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            Pbzx.BLL.CN_User userBLL = new Pbzx.BLL.CN_User();
            Pbzx.Model.CN_User Myuser;

            string str = Request.QueryString["ID"];
            Myuser = userBLL.GetModel(Convert.ToInt32(str));

            Myuser.Username = this.txtUserRemarks.Text;
            Myuser.StatResult = int.Parse(this.txtStatResult.Text);
            Myuser.Remarks = this.txtRemarks.Text;

            if (userBLL.Update(Myuser))
            {

                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸ĳɹ�."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("SoftRegisterLog_Manager.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�޸�ʧ��."));
            }
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftRegisterLog_Manager.aspx");
        }
    }
}
