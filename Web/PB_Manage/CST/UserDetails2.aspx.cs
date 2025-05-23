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
    public partial class UserDetails2 : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Pbzx.BLL.CN_UserDetails detailsBLL = new Pbzx.BLL.CN_UserDetails();
                Pbzx.Model.CN_UserDetails Mydetails;
                string str = Request.QueryString["ID"];
                Mydetails = detailsBLL.GetModel(Convert.ToInt32(str));

                this.txtBss.Text = Mydetails.BbsName;
                this.txtName.Text = Mydetails.UserName;
                this.txtTel.Text = Mydetails.UserTel;

                this.txtEmail.Text = Mydetails.UserEmail;
                this.txtAddress.Text = Mydetails.UserAddress;
                this.rblStatus.SelectedValue = Mydetails.Status.ToString();
                this.txtRemarks.Text = Mydetails.Remarks;
                hfFriendLinkID.Value = Mydetails.ID.ToString();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtBss.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", Pbzx.Common.JS.Alert("论坛名称不能为空."));
                return;
            }

            if (txtName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "tagnull", JS.Alert("姓名不能为空"));
                return;
            }

            Pbzx.BLL.CN_UserDetails MyBLL = new Pbzx.BLL.CN_UserDetails();
            Pbzx.Model.CN_UserDetails MyUd;

            int LinkID = Convert.ToInt32(hfFriendLinkID.Value);

            if (LinkID > 0)
            {
                MyUd = MyBLL.GetModel(LinkID);

            }
            else
            {
                MyUd = new Pbzx.Model.CN_UserDetails();
            }

            MyUd.BbsName = this.txtBss.Text.Trim();
            MyUd.UserName = this.txtName.Text.Trim();
            MyUd.UserTel = this.txtTel.Text.Trim();
            MyUd.UserEmail = this.txtEmail.Text.Trim();
            MyUd.UserAddress = this.txtAddress.Text.Trim();
            MyUd.Status = int.Parse(this.rblStatus.SelectedValue);
            MyUd.Remarks = this.txtRemarks.Text.Trim();


            if (MyUd.ID > 0)
            {
                if (MyBLL.Update(MyUd))
                {
                    //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("用户修改成功."));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("SoftRegisterLog_Manager.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改用户[" + MyUd.UserName + "].");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改用户失败."));
                }
            }
            else
            {

                if (MyBLL.Add(MyUd))
                {
                    //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("用户添加成功."));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("UserDetails_Manage.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增用户[" + MyUd.UserName + "].");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("用户添加失败."));
                }
            }

        }
    }
}
