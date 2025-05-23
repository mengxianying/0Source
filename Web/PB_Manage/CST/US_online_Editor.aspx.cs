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
    public partial class US_online_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CN_Online MyBLL = new Pbzx.BLL.CN_Online();
                Pbzx.Model.CN_Online MyCn;
                string str = Request.QueryString["ID"];
                MyCn = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblUsername.Text = MyCn.Username.ToString();
                this.lblProgramVer.Text = MyCn.ProgramVer.ToString();
                this.lblRN.Text = MyCn.RN.ToString();

                this.lblHDSN.Text = MyCn.HDSN.ToString();
                this.lblSoftwaretype.Text = ChkSoftType2(MyCn.SoftwareType.ToString());
                this.lblInstallType.Text = ChkSoftType(MyCn.SoftwareType.ToString(), MyCn.InstallType.ToString());

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
       protected string ChkSoftType(object num, object st)
       {
           Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
           string[] result = softBLL.Chksettype(num, st);
           return result[0] + "(" + result[1] + ")";
       }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("US_online.aspx");
        }
        public static string GetStatus(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "未登录";
                    break;
                case 1:
                    type = "登录";
                    break;
                case 2:
                    type = "退出";
                    break;
                case 3:
                    type = "超时";
                    break;
                case 4:
                    type = "超时2";
                    break;
                case 10:
                    type = "强退";
                    break;
                case 20:
                    type = "服务名错";
                    break;
                case 21:
                    type = "用户名或密码错";
                    break;
                case 22:
                    type = "ID锁定";
                    break;
                case 23:
                    type = "ID禁用";
                    break;
                case 24:
                    type = "数超额";
                    break;
                case 30:
                    type = "贴不够";
                    break;
                case 31:
                    type = "停试用";
                    break;
                case 32:
                    type = "超试次";
                    break;
                case 33:
                    type = "超试期";
                    break;
                case 34:
                    type = "超PC数";
                    break;
                case 35:
                    type = "超用期";
                    break;
                default:
                    type = "错误";
                    break;
            }
            return type;
        }
    }
}
