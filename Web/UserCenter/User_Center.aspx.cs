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
    public partial class User_Center : System.Web.UI.Page
    {
        public string lblText = "–ﬁ∏ƒ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {              
                this.lblUName.Text = Method.Get_UserName;                                      
                Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(this.lblUName.Text);
                if (UsModel.CurrentMoney != null)
                {
                    this.lbpinble.Text = Math.Round((Decimal)UsModel.CurrentMoney, 2)+"";
                   // this.lbjinbi.Text = (UsModel.CurrentMoney * 10).ToString()
                }
                else
                {
                    this.lbpinble.Text = "0";
                   // this.lbjinbi.Text = "0";
                }

                LoginSort login = new LoginSort();
                int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Method.Get_UserName + "' and State=1 ");

                if (intBroker > 0 )
                {
                    this.MyBroker.Visible = true;
                }
                else
                {
                    this.MyBroker.Visible = false;
                }

                if (WebFunc.IsDaili())
                {
                    this.MyDaili.Visible = true;
                }
                else
                {
                    this.MyDaili.Visible = false;
                }

               DataRow row =   WebFunc.GetQQLookUser();
               if (row == null)
               {
                   tbQQManager.Visible = false;
               }
               else
               {
                   tbQQManager.Visible = true;
               }
               object objMBWT = DbHelperSQLBBS.GetSingle(" select UserQuesion from Dv_User where UserName='" + Method.Get_UserName + "' ");

               if (objMBWT != null && objMBWT.ToString() != "")
               {
                   lblText = "–ﬁ∏ƒ";
               }
               else
               {
                   lblText = "…Ë÷√"; 
               }

                        
            }
        }
        protected void aLoginOut_Click(object sender, ImageClickEventArgs e)
        {
           Pbzx.BLL.PinbleLogin.UserOut();
           Response.Redirect("/.");
        }
    }
}
