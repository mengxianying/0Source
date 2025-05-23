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
using System.Text.RegularExpressions;

namespace Pbzx.Web.PB_Manage
{
    public partial class WebUser_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                On_load();
                Bindddl_Ntype();
            }
        }
        public void On_load()
        {
            string str = Request.QueryString["ID"];
            if (OperateText.IsNumber(str))
            {
                DataSet ds = DbHelperSQLBBS.Query("select UserName,UserEmail,JoinDate,LastLogin,UserClass,UserLastIP,LockUser,Mobile from Dv_User where UserID =" + str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    lblUserEmail.Text = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                    lblJoinDate.Text = ds.Tables[0].Rows[0]["JoinDate"].ToString();
                    lblLastLogin.Text = ds.Tables[0].Rows[0]["LastLogin"].ToString();
                    lblUserClass.Text = ds.Tables[0].Rows[0]["UserClass"].ToString();
                    this.lblUserLastIP.Text = ds.Tables[0].Rows[0]["UserLastIP"].ToString() + "（" + WebFunc.GetIpName(ds.Tables[0].Rows[0]["UserLastIP"]) + "）";
                    lblUserMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    if (string.IsNullOrEmpty(lblUserMobile.Text.Trim()))
                    {
                        lblUserMobile.Text = "";
                    }
                    TextUserMobile.Text = lblUserMobile.Text;
                    if (ds.Tables[0].Rows[0]["LockUser"].ToString() == "0")
                    {
                        lblLockUser.Text = "否";
                        rabBtn_yn.Items.FindByValue("0").Selected = true;
                    }
                    else if (ds.Tables[0].Rows[0]["LockUser"].ToString() == "1")
                    {
                        lblLockUser.Text = "是";
                        rabBtn_yn.Items.FindByValue("1").Selected = true;
                    }

                }
            }
            if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(UserName) from PBnet_UserTable where UserName='" + lblUserName.Text + "'")) < 1)
            {
                this.really.Visible = false;
            }
            else
            {
                this.really.Visible = true;
                Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(lblUserName.Text);

                lblRealName.Text = userModel.RealName;
                lblSex.Text = Convert.ToBoolean(userModel.Sex) ? "男" : "女";
                lblCardID.Text = userModel.CardID;

                lblBirthday.Text = userModel.Birthday.ToString();
                lblTelphone.Text = userModel.Telphone;
                lblEmail.Text = userModel.Email;

                lblMobile.Text = userModel.Mobile;
                lblQQ.Text = userModel.QQ;
                lblProvince.Text = userModel.Province;

                lblMSN.Text = userModel.MSN;
                lblCity.Text = userModel.City;
                lblPostCode.Text = userModel.PostCode;
                lblAddress.Text = userModel.Address;

                lblAccountNumber.Text = userModel.AccountNumber;
                lblBankName.Text = userModel.BankName;
                lblBankInfo.Text = userModel.BankInfo;
                lblCurrentMoney.Text = Convert.ToDecimal(userModel.CurrentMoney).ToString("0.00");
                lblFrozenMoney.Text = Convert.ToDecimal(userModel.FrozenMoney).ToString("0.00");
                lblKY.Text = Convert.ToDecimal(Convert.ToDecimal(userModel.CurrentMoney) - Convert.ToDecimal(userModel.FrozenMoney)).ToString("0.00");
                lblAccountNumberState.Text = WebFunc.GetAccountNumberStateName((int)userModel.AccountNumberState);
            }
        }
       
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebUser.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string str = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(txtPWD.Text) && txtPWD.Text.Trim() != "")
            {
                string sql = " update Dv_User set UserPassword='" + Input.MD5(this.txtPWD.Text) + "' where  UserID=" + str.Trim();
                int result = DbHelperSQLBBS.ExecuteSql(sql);
                if(result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("密码修改成功！"));
                }
            }
           
        }
        /// <summary>
        /// 绑定用户类别
        /// </summary>
        public void Bindddl_Ntype()
        {
            DataSet ds = DbHelperSQLBBS.Query("select * from Dv_UserGroups where Orders<100 order by Orders asc");
            ddl_Ntype.DataSource = ds;
            ddl_Ntype.DataValueField = "UserGroupID";
            ddl_Ntype.DataTextField = "usertitle";
            ddl_Ntype.DataBind();
        }

        /// <summary>
        /// 修改会员锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string str = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(rabBtn_yn.SelectedValue) && rabBtn_yn.SelectedValue != "")
            {
                string sql = " update Dv_User set LockUser='" + Convert.ToInt32(rabBtn_yn.SelectedValue) + "' where UserID=" + str.Trim();
                int result = DbHelperSQLBBS.ExecuteSql(sql);
                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("锁定状态修改成功！"));
                    On_load();
                }
            }
        }
        /// <summary>
        /// Email修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_UpdateEmail_Click(object sender, EventArgs e)
        {
            string str = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(txt_Email.Text) && txt_Email.Text != "")
            {
                string sql = " update Dv_User set UserEmail='" + txt_Email.Text.ToString() + "' where UserID=" + str.Trim();
                int result = DbHelperSQLBBS.ExecuteSql(sql);
                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("Email修改成功！"));
                    On_load();
                }
            }
        }

        /// <summary>
        /// UpdateUserMobile修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_UpdateUserMobile_Click(object sender, EventArgs e)
        {
            string str = Request.QueryString["ID"];
            TextUserMobile.Text = TextUserMobile.Text.Trim();
            if (string.IsNullOrEmpty(TextUserMobile.Text) || TextUserMobile.Text == "")
            {
                TextUserMobile.Text = "";
            }
            else
            {
                if (!Regex.IsMatch(TextUserMobile.Text, @"^1[3-9]\d{9}$") && TextUserMobile.Text.Length != 11)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("手机号码有错误！"));
                    return;
                }
            }
            if (lblUserMobile.Text != TextUserMobile.Text)
            {
                DbHelperSQL.ExecuteSql(" update PBnet_UserTable set Mobile ='" + TextUserMobile.Text.ToString() + "' where UserName='" + lblUserName.Text + "'");
                string sql = " update Dv_User set Mobile='" + TextUserMobile.Text.ToString() + "' where UserID=" + str.Trim();
                int result = DbHelperSQLBBS.ExecuteSql(sql);
                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("手机号码修改成功！"));
                    On_load();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("手机号码没有任何改动！"));
            }
        }

        /// <summary>
        /// 用户类别修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_UpdateType_Click(object sender, EventArgs e)
        {
            string str = Request.QueryString["ID"];
            if (ddl_Ntype.SelectedValue!="")
            {
                DataSet ds = DbHelperSQLBBS.Query("select usertitle from Dv_UserGroups where UserGroupID="+"'"+ ddl_Ntype.SelectedValue +"'");
                string sql = " update Dv_User set UserClass=" + "'" + ds.Tables[0].Rows[0]["usertitle"].ToString() + "'" + ",UserGroupID=" + "'" + ddl_Ntype.SelectedValue + "'" + " where UserID=" + str.Trim();
                int result = DbHelperSQLBBS.ExecuteSql(sql);
                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("用户类别修改成功！"));
                    On_load();
                }
            }
        }

    }
}
