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
    public partial class UserRealInfo : System.Web.UI.Page
    {

        private Pbzx.Model.PBnet_UserTable model = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoginSort login = new LoginSort();
                model = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                if (model == null)
                {
                    model = new Pbzx.Model.PBnet_UserTable();     
                }
                this.UcRegRealInfo1.UserTable = model;
            }
        }

        protected void btmSemd_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_UserTable utBll = new Pbzx.BLL.PBnet_UserTable();           
            Pbzx.Model.PBnet_UserTable m1 = this.UcRegRealInfo1.UserTable;         
            if (m1 != null)
            {      
                m1.State = 1;          
                Email realEmail = new Email(m1.Email,"拼搏在线邮件验证","");
                if (utBll.Update(m1))
                {
                    //密码保护表插入记录
                    int tempCount = Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from PBnet_UserProtectPwd where UserName='" + Method.Get_UserName + "' "));
                    if (tempCount > 0)
                    {
                        int mifa = DbHelperSQL.ExecuteSql("update PBnet_UserProtectPwd set SecurityQuestion='" + this.UcRegRealInfo1.Question + "' ,Answer='" + this.UcRegRealInfo1.Answer + "',Email='" + m1.Email + "',type='1' where UserName='" + Method.Get_UserName + "' ");
                    }
                    else
                    {
                        int mifa = DbHelperSQL.ExecuteSql("insert into PBnet_UserProtectPwd(UserName,SecurityQuestion,Answer,Email,type) values('" + Method.Get_UserName + "','" + this.UcRegRealInfo1.Question + "','" + this.UcRegRealInfo1.Answer + "','" + m1.Email + "','1')");
                    }
                    DbHelperSQLBBS.ExecuteSql(" update Dv_User set UserEmail='" + m1.Email + "' where  UserName='" + Method.Get_UserName + "' ");
                    Pbzx.BLL.PinbleLogin loginBLL = new Pbzx.BLL.PinbleLogin();
                    loginBLL.ReLogin();
                    Response.Write(JS.Alert("您已经升级为高级会员！","/"));
                    return;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('注册失败，请与管理员联系！');window.returnValue ='close';window.close()</script>");
                    return;
                }
            }
            else
            {               
                return;
            }
        }

        //protected void btnTong_Click(object sender, EventArgs e)
        //{
        //    this.tb1.Visible = false;
        //    this.tb2.Visible = true;
        //}
    }
}
