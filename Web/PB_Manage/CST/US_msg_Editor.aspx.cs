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
    public partial class US_msg_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CN_User MyBLL = new Pbzx.BLL.CN_User();
                Pbzx.Model.CN_User MyUser;
                string str = Request.QueryString["ID"];
                MyUser = MyBLL.GetModel(Convert.ToInt32(str));

                this.lblUsername.Text = MyUser.Username.ToString();
                //this.lblUserType.Text = Pbzx.Common.Method.ShowUserType(MyUser.UserType.ToString());
                ddlUserType.SelectedValue = MyUser.UserType.ToString();
                this.lblSoftwareType.Text = ChkSoftType(MyUser.SoftwareType.ToString(), MyUser.InstallType.ToString());

                this.lblUseCount.Text = MyUser.UseCount.ToString();
                this.lblServiceID.Text = MyUser.ServiceID.ToString();
                this.lblLastLoginID.Text = MyUser.LastLoginID.ToString();

                this.lblHDSNList.Text = MyUser.HDSNList.ToString();
                this.txtExpireDate.Text = MyUser.ExpireDate.ToString();
                this.txtValidDays.Text = MyUser.ValidDays.ToString();

                this.lblCreateTime.Text = MyUser.CreateTime.ToString();
                this.lblLastPayTime.Text = MyUser.LastPayTime.ToString();

                this.txtUserRemarks.Text = MyUser.UserRemarks.ToString();
                this.txtStatResult.Text = MyUser.StatResult.ToString();
                this.txtRemarks.Text = MyUser.Remarks.ToString();
            }
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return result[0] + "(" + result[1] + ")";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (!OperateText.IsNumber(this.txtStatResult.Text))
            {
                strErrMsg += "发帖统计不是数字.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.BLL.CN_User MyBLL = new Pbzx.BLL.CN_User();
            Pbzx.Model.CN_User MyUser;

            MyUser = MyBLL.GetModel(Convert.ToInt32(Request.QueryString["ID"]));

            MyUser.UserRemarks = this.txtUserRemarks.Text;
            MyUser.Remarks = this.txtRemarks.Text;
            MyUser.StatResult =int.Parse(this.txtStatResult.Text);
            MyUser.UserType =  int.Parse(ddlUserType.SelectedValue);
            MyUser.ExpireDate = DateTime.Parse(this.txtExpireDate.Text) ;
            MyUser.ValidDays = int.Parse(this.txtValidDays.Text);

            if (MyBLL.Update(MyUser))
            {                
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改用户管理信息[用户名：" + this.lblUsername.Text + " 软件名称：" + Input.FilterHTML(this.lblSoftwareType.Text) + "].");
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else 
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改用户管理信息."));
            }
        }



    }
}