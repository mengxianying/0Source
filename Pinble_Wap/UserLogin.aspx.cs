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
using Pbzx.BLL;

namespace Pinble_Wap
{
    public partial class UserLogin : System.Web.UI.Page
    {
        Pbzx.BLL.PBnet_tpman AdminBLL = new Pbzx.BLL.PBnet_tpman();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("Manage/List3DManage.aspx");
                return;
            }
        }
        /// <summary>
        /// 回到开奖信息页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linbutResetKJ_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOk_Click(object sender, EventArgs e)
        {
            labpassword.Text = "";

            string username = TxtUserLogin.Text;
            string Password = Txtpassword.Text;

            if (username.Trim() == "" || username.Trim().Length == 0)
            {
                labpassword.Text = "用户名不能为空！";
            }
            if (Password.Trim() == "" || Password.Trim().Length == 0)
            {
                labpassword.Text =labpassword.Text+ "密码不能为空！";
                return;
            }
            //判断用户登录
            if (AdminBLL.ValidateLogin(username, Password))
            {
                Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(username);
                if (MyAdmin != null)
                {
                    Session["User"] = MyAdmin;
                    Response.Redirect("Manage/List3DManage.aspx");
                }
            }
            else
            {
                labpassword.Text = "用户或密码错误！";
            }
        }
    }
}
