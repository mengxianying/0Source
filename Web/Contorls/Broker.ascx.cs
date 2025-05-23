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

namespace Pbzx.Web.Contorls
{
    public partial class Broker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {   BindData();
                LoginSort login = new LoginSort();
                if (!login["manager_user"])
                {
                    this.user.Visible = false;
                }
                else
                {
                    this.user.Visible = true;
                    //已经成为经纪人  
                    int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Method.Get_UserName + "' ");
                    if (intBroker > 0)
                    {                           
                        string strName = Method.Get_UserName;
                        Pbzx.BLL.PBnet_broker MyBll = new Pbzx.BLL.PBnet_broker();
                        Pbzx.Model.PBnet_broker MyModel = MyBll.GetModelName(strName);
                        if(MyModel.State == 3)
                        {
                            this.shenq.Visible = true;
                            this.menu.Visible = false;          
                        }
                        else
                        {
                            this.shenq.Visible = false;
                            this.menu.Visible = true;
                            if (MyModel.State != 1)
                            {
                                this.lblBrokerState.Visible = true;
                                this.lblBrokerState.Text = GetState(MyModel.State);
                            }
                        }
                    }
                    else//还未成为经纪人                    
                    {
                        this.shenq.Visible = true;
                        this.menu.Visible = false;
                    }                 

                } 
                Bulletin_r1.Count = int.Parse(WebInit.pageConfig.BrokerBulletin);
            }
            
        }
        public static string GetState(object sState)
        {
            string state = "";
            int intState = int.Parse(sState.ToString());
            switch (intState)
            { 
                case 0:
                    state = "审核中，请耐心等待！";
                    break;
                case 2:
                    state = "已锁定，请与管理员联系！";
                    break;
                default:
                    state = "";
                    break;
            }
            return state.ToString();
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_broker_content ContentBll = new Pbzx.BLL.PBnet_broker_content();

            dtliuc.DataSource = ContentBll.GetList("Btype='申请流程' and IsAuditing=1 ");
            dtliuc.DataBind();

            dtxiangx.DataSource = ContentBll.GetList("Btype='详细介绍'and IsAuditing=1");
            dtxiangx.DataBind();

            dthaoc.DataSource = ContentBll.GetList("Btype='经纪人好处'and IsAuditing=1 order by IntSortID asc ");
            dthaoc.DataBind();   
            
        }

    }
}
