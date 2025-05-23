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
    public partial class Broker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Method.Get_UserName + "' and  state !=3   ");
                if (intBroker > 0)
                {
                    this.shengqing.Visible = false;
                }
            
                Pbzx.BLL.PBnet_broker_content ContentBll = new Pbzx.BLL.PBnet_broker_content();

                if (Request["ID"] != null)
                {
                    if (!string.IsNullOrEmpty(Input.FilterAll(Input.Decrypt(Request["ID"]))))
                    {
                        Pbzx.Model.PBnet_broker_content ContentModel = ContentBll.GetModel(int.Parse(Input.FilterAll(Input.Decrypt(Request["ID"]))));
                        lbltitle.Text = ContentModel.Btitle;
                        lblContent.Text = ContentModel.Bcontent;
                    }
                }
                else
                {
                    Pbzx.Model.PBnet_broker_content ContentModelLC = ContentBll.GetModelName();
                    if (ContentModelLC != null)
                    {
                        lbltitle.Text = ContentModelLC.Btitle;
                        lblContent.Text = ContentModelLC.Bcontent;
                    }
                   
                }
            }
          
        }
    

        protected void ibtnApply1_Click(object sender, ImageClickEventArgs e)
        {
            if (Pbzx.Common.Method.Get_UserName == "0")
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("提示！", "您还没有登录！<br/>请您先登录，然后再申请！", 400, "1", "", "", false, false) + "");               
                return;
            }
            else
            {
                Server.Transfer("Broker_Agrt.aspx");
            }
        }

    }
}
