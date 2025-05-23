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

namespace Pbzx.Web
{
    public partial class links : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindLinkPic();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Links MyBll = new Pbzx.BLL.PBnet_Links();
            this.dtLinks.DataSource = MyBll.GetList(" BitIsOK=1 and IntLinkType=1 order by SortOrder asc");
            this.dtLinks.DataBind();
        }
        //NteSiteUrl
        private void BindLinkPic()
        {
            Pbzx.BLL.PBnet_Links PicBll = new Pbzx.BLL.PBnet_Links();
            this.dlPic.DataSource = PicBll.GetList("BitIsOK=1 and IntLinkType=0 order by SortOrder desc");
            this.dlPic.DataBind();
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Links MyBll = new Pbzx.BLL.PBnet_Links();
            Pbzx.Model.PBnet_Links MyModel = new Pbzx.Model.PBnet_Links();
            if (Session["ValidateCode"] == null)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "验证码已经失效！", 350, "1", "", "", false, false) + "");
                return;
            }
            if (this.txtTry.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "验证码输入错误！", 350, "1", "", "", false, false) + "");
                return;
            }
            if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(NteSiteUrl) from PBnet_Links where NteSiteUrl='" + Input.Filter(this.txtSiteUrl.Text) + "' and BitIsOK!=0 ")) > 0)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "该网站已经申请过，请勿重复申请，请耐心等待审核。", 400, "1", "location.href='/Default.htm';", "", false, false) + "");
                return;
            }

            MyModel.IntLinkType = int.Parse(this.ddlType.SelectedValue);
            MyModel.IntSiteName = Input.FilterHTML(this.txtSiteName.Text);
            MyModel.NteSiteUrl = Input.FilterHTML(this.txtSiteUrl.Text);
            MyModel.NteLogoUrl = Input.FilterHTML(this.txtLogoUrl.Text);
            MyModel.NvarSiteAdmin = Input.FilterHTML(this.txtSiteAdmin.Text);
            MyModel.NvarEmail = Input.FilterHTML(this.txtEmail.Text);
            MyModel.NteSiteIntro = Input.FilterHTML(this.txtSiteIntro.Text);
            MyModel.Tel = Input.FilterHTML(this.txtTel.Text);
            MyModel.QQ = Input.FilterHTML(this.txtQQ.Text);
            MyModel.ModifyTime = DateTime.Now;
            MyModel.BitIsOK = 2;
            int sortOrder = Convert.ToInt32(DbHelperSQL.GetSingle("select max(SortOrder) from PBnet_Links")) + 1;
            MyModel.SortOrder = sortOrder;
            if (MyBll.Add(MyModel))
            {
                Method.record_user_log("匿名用户", "友情链接申请成功", "友情链接申请成功", "登录");
                this.shenqing.Visible = false;
                this.cheng.Visible = true;
            }
            else
            {
                Method.record_user_log("匿名用户", "友情链接申请失败", "友情链接申请失败", "登录");
                Response.Write("<script>alert('申请发生错误，请稍候再试！')</script>");

            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("/links.aspx");
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/links.aspx");
        }

    }
}
