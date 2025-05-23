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

namespace Pbzx.Web.PB_Manage
{
    public partial class Master_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            Pbzx.Model.PBnet_tpman MyAdmin = Pbzx.BLL.PBnet_tpman.GetNowUser();
            if (!IsPostBack)
            {
                this.IsAuthority(1);
                Pbzx.Model.PBnet_tpman MyUser = new Pbzx.Model.PBnet_tpman();
                
                string strAction = "";
                if (Request.QueryString["ID"] != null)
                {
                    string UID = Request.QueryString["ID"].ToString().Trim();
                    if (OperateText.IsNumber(UID))
                    {
                        MyUser = new Pbzx.BLL.PBnet_tpman().GetModel(Convert.ToInt32(UID));
                        if (MyUser.State)
                        {
                            this.rblState.Items[0].Selected = true;
                            this.rblState.Items[1].Selected = false;
                        }
                        else
                        {
                            this.rblState.Items[0].Selected = false;
                            this.rblState.Items[1].Selected = true;
                        }
                        txtAdminName.Enabled = false;
                        strAction = "修改";
                    }
                }
                else
                {
                    MyUser = new Pbzx.Model.PBnet_tpman();
                    strAction = "新增";
                }

                txtUserID.Text = MyUser.Master_Id.ToString();
                txtAdminName.Text = MyUser.Master_Name;
                lblAction.Text = strAction;

                txtIPLimit.Text = MyUser.ipLimit;
                txtRegionLimit.Text = MyUser.regionLimit;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(txtUserID.Text);
            string strAdminName = txtAdminName.Text.Trim(); 
            string strPwd1 = txtPassword1.Text.Trim();
            string strPwd2 = txtPassword2.Text.Trim();

            string stripLimit = txtIPLimit.Text.Trim();
            string strregionLimit = txtRegionLimit.Text.Trim();

            Pbzx.BLL.PBnet_tpman UserBLL = new Pbzx.BLL.PBnet_tpman();
            Pbzx.Model.PBnet_tpman MyUser;
            
            if (UserID == 0)
            {
                MyUser = new Pbzx.Model.PBnet_tpman();
                if (UserBLL.GetEntityByUserName(strAdminName) != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "hasuser", JS.Alert("该用户名已经在使用中."));
                    return;
                }

                if (strPwd1 == "" || strPwd2 == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "pwdnull", JS.Alert("密码不能为空."));
                    return;
                }
                if (strPwd1 != strPwd2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "pwderr", JS.Alert("两次输入的密码不一致."));
                    return;
                }
                if (strPwd1.Length < 6)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "pwdlen", JS.Alert("密码长度必须大于等于6个字符."));
                    return;
                }
                MyUser.Master_Name = strAdminName;
                MyUser.Master_Password = Pbzx.Common.Input.MD5(strPwd1,false);
            }
            else
            {
                MyUser = UserBLL.GetModel(UserID);
                if (strPwd1 != "" && strPwd2 != "")
                {
                    if (strPwd1 != strPwd2)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "pwderr", JS.Alert("两次输入的密码不一致."));
                        return;
                    }
                    if (strPwd1.Length < 6)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "pwdlen", JS.Alert("密码长度必须大于等于6个字符."));
                        return;
                    }
                    if (strPwd1 == "" || strPwd2 == "")
                    {
                    }
                    else
                    {
                        MyUser.Master_Password = Pbzx.Common.Input.MD5(strPwd1, false);
                    }
                }
            }


            //MyUser.UserGroup = "管理员";
            MyUser.State = this.rblState.Items[0].Selected;
            MyUser.ipLimit = txtIPLimit.Text;
            MyUser.regionLimit = txtRegionLimit.Text;
            if (UserBLL.Save(MyUser))
            {                      
                //Response.Write("<script>alert('操作成功！');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                Response.Redirect("Master_Manage.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "saveerr", JS.Alert("用户保存失败."));
            }
        }
    }
}
