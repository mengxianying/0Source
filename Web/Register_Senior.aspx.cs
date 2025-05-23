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

namespace Pbzx.Web
{
    public partial class Register_Senior : System.Web.UI.Page
    {
        
        private Pbzx.Model.PBnet_UserTable model = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                if (utBll.Update(m1))
                {
                    Pbzx.BLL.PinbleLogin loginBLL = new Pbzx.BLL.PinbleLogin();
                    loginBLL.ReLogin();
                    Response.Write("<script language='javascript'>alert('您已经升级为高级会员！');window.returnValue ='yes';window.close()</script>");
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
    }
}
