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
    public partial class US_free_Editor_2011 : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CN_FreeTestUser_2011 MyBLL = new Pbzx.BLL.CN_FreeTestUser_2011();
                Pbzx.Model.CN_FreeTestUser2011 MyUser;
                string str = Request.QueryString["ID"];
                MyUser = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblHDSN.Text = MyUser.HDSN.ToString();
                this.lblDiskCVol.Text = MyUser.GlobalID.ToString();
                this.lblSoftwareType.Text = ChkSoftType2(MyUser.SoftwareType.ToString());

                this.lblInstallType.Text = ChkSoftType((MyUser.SoftwareType.ToString()), (MyUser.InstallType.ToString()));
                this.lblFirstLoginTime.Text = MyUser.FirstLoginTime.ToString();
                this.lblLastLoginTime.Text = MyUser.LastLoginTime.ToString();

                this.lblLastLoginTime.Text = MyUser.LastLoginTime.ToString();
                this.lblUseCount.Text = MyUser.UseCount.ToString();
                this.lblLastLoginIP.Text = GetIpName(MyUser.LastLoginIP.ToString()) + "[" + "<font color='#FF0000'>" + MyUser.LastLoginIP.ToString() + "</Font>" + "]";

                this.ServiceID.Text = MyUser.ServiceID.ToString();
                this.lblLastLoginID.Text = MyUser.LastLoginID.ToString();
                this.rblStatus.SelectedValue = MyUser.Status.ToString();
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CN_FreeTestUser_2011 MyBLL = new Pbzx.BLL.CN_FreeTestUser_2011();
            Pbzx.Model.CN_FreeTestUser2011 MyUser;
            MyUser = MyBLL.GetModel(Convert.ToInt32(Request.QueryString["ID"]));

            MyUser.Status = int.Parse(this.rblStatus.SelectedValue);

            if (MyBLL.Update(MyUser) != 0)
            {
                // ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("US_free.aspx"));
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改免费试用管理[认证码：" + this.lblHDSN.Text + "C盘卷标：" + this.lblDiskCVol.Text + "].");
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改免费试用用户管理."));
            }
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
        protected string GetIpName(object obj)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(obj.ToString());
        }

    }
}