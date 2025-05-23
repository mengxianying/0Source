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
    public partial class US_log_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CN_Log MyBLL = new Pbzx.BLL.CN_Log();
                Pbzx.Model.CN_Log MyCn;
                string str = Request.QueryString["ID"];
                MyCn = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblUsername.Text = MyCn.Username.ToString();
                this.lblProgramVer.Text = MyCn.ProgramVer.ToString();
                this.lblRN.Text = MyCn.RN.ToString();

                this.lblHDSN.Text = MyCn.HDSN.ToString();
                Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
                string[] result = softBLL.Chksettype(MyCn.SoftwareType.ToString(), MyCn.InstallType.ToString());

                this.lblSoftwaretype.Text = result[0];
                this.lblInstallType.Text = result[1];
                this.lblIP.Text = MyCn.IP.ToString();
                this.lblPort.Text = MyCn.Port.ToString();
                this.lblStartTime.Text = MyCn.StartTime.ToString();

                this.lblEndTime.Text = MyCn.EndTime.ToString();
                this.lblLoginMutex.Text = MyCn.LoginMutex.ToString();
                this.lblStatus.Text = GetStatus(MyCn.Status.ToString());

                this.lblServiceID.Text = MyCn.ServiceID.ToString();
                this.lblUserIndex.Text = MyCn.UserIndex.ToString();
                this.lblUseType.Text = GetUserType(MyCn.UseType);

                this.lblUseValue.Text = MyCn.UseValue.ToString();
             }
        }
           
       public string GetUserType(object num)
       {
          return Pbzx.Common.Method.ShowUserType(num);
       }
        protected string ChkSoftType2(object num)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            return softBLL.Chksofttype(num);
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("US_log.aspx");
        }
        public static string GetStatus(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "δ��¼";
                    break;
                case 1:
                    type = "��¼";
                    break;
                case 2:
                    type = "�˳�";
                    break;
                case 3:
                    type = "��ʱ";
                    break;
                case 4:
                    type = "��ʱ2";
                    break;
                case 10:
                    type = "ǿ��";
                    break;
                case 20:
                    type = "����";
                    break;
                case 21:
                    type = "�����";
                    break;
                case 22:
                    type = "ID����";
                    break;
                case 23:
                    type = "ID����";
                    break;
                case 24:
                    type = "������";
                    break;
                case 30:
                    type = "������";
                    break;
                case 31:
                    type = "ͣ����";
                    break;
                case 32:
                    type = "���Դ�";
                    break;
                case 33:
                    type = "������";
                    break;
                case 34:
                    type = "��PC��";
                    break;
                case 35:
                    type = "������";
                    break;
                default:
                    type = "����";
                    break;
            }
            return type;
        }
    }
}
