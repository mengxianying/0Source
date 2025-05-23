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

namespace Pbzx.Web.Contorls
{
    public partial class Agent_menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClass();
            }
        }

        private void BindClass()
        {
            Pbzx.BLL.AgentAgree AgreeBll = new Pbzx.BLL.AgentAgree();
            rptClass.DataSource = AgreeBll.GetList(" State=0");
            rptClass.DataBind();
        }
        protected void imbtn_centerdl_Click(object sender, ImageClickEventArgs e)
        {
            LoginSort login = new LoginSort();
            if (!login["manager_user"])
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "请登录后再使用此功能！", 400, "1", "location.href='/login.aspx';", "", false, false));
            }
            else
            {               
                //已经成为经纪人                            
                //if (login["user_Broker"])
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("您是经纪人，不能代理自助购买！"));

                //}
                //已经是代理
                if (login["delegate_User"])
                {
                    Response.Write("<script>window.top.location.href='/UserCenter/User_Center.aspx?myUrl=OrderList.aspx'</script>");
                }
                //还未成为经纪人
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "您还不是代理，请申请成为代理！", 400, "1", "location.href='/login.aspx';", "", false, false));
                }
            }
        }
    }
}