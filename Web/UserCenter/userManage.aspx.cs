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

namespace Pbzx.Web.UserCenter
{
    public partial class userManage : System.Web.UI.Page
    {
        public string JoinDate = "";
        public string LastLogin = "";
        public string UserClass = "";
        public string UserLastIP = "";
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBasic();
                Pbzx.Model.PBnet_ask_User UserModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();                
                
                this.lbScore.Text = Convert.ToString(UserModel.Score - UserModel.Pointpenalty - UserModel.OtherPointpenalty);
                this.lbtitle.Text = Method.GetUserTitle(this.lbScore.Text);
                LoginSort login = new LoginSort();
                lblTypeName.Text = login[ELoginSort.user_RealInfo.ToString()] ? "高级用户" : "普通用户";

                object objMBWT = DbHelperSQLBBS.GetSingle(" select UserQuesion from Dv_User where UserName='" + Method.Get_UserName + "' ");

                if (objMBWT != null && objMBWT.ToString() != "")
                {
                    this.trMMBH.Visible = false;
                }
                else
                {
                    this.trMMBH.Visible = true;
                }
                if (login[ELoginSort.user_RealInfo.ToString()])
                {
                    this.trGJYH.Visible = false;
                }
                else
                {
                    this.trGJYH.Visible = true;
                }
                if (trMMBH.Visible || trGJYH.Visible)
                {
                    trTS.Visible = true;
                }
                else
                {
                    trTS.Visible = false;
                }

            }
        }
        private void BindBasic()
        {
            DataRow row = DbHelperSQLBBS.Query("select top 1 JoinDate,LastLogin,UserLastIP from Dv_User where UserName='" + Input.FilterAll(Method.Get_UserName) + "' ").Tables[0].Rows[0];
           // JoinDate = DbHelperSQLBBS.GetSingle("select top 1 JoinDate from Dv_User where UserName='" + Method.Get_UserName +"' ").ToString();
           // LastLogin = DbHelperSQLBBS.GetSingle("select top 1 LastLogin from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();
           //// UserClass = DbHelperSQLBBS.GetSingle("select top 1 UserClass from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();
           // UserLastIP = DbHelperSQLBBS.GetSingle("select top 1 UserLastIP from Dv_User where UserName='" + Method.Get_UserName + "' ").ToString();
            JoinDate = row["JoinDate"].ToString();
            LastLogin = row["LastLogin"].ToString();
            UserLastIP = row["UserLastIP"].ToString();
        }
    }
}
