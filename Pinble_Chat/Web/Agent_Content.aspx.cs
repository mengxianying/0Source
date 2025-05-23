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
    public partial class Agent_Content : System.Web.UI.Page
    {
        public string DownAdd = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                           
                Pbzx.BLL.AgentAgree AgentBll = new Pbzx.BLL.AgentAgree();
                Pbzx.Model.AgentAgree AgentModel;
                string id = Input.Decrypt(Request.QueryString["ID"]);
                if (OperateText.IsNumber(id))
                {
                   AgentModel = AgentBll.GetModel(Convert.ToInt32(id));
                   this.Title = AgentModel.Purpose + " - " + "拼搏在线彩神通软件";
                   lbltitle.Text = AgentModel.Title;
                   lblContent.Text = AgentModel.Content;
                   lblPurpose.Text = AgentModel.Purpose;

                   DownAdd = AgentModel.AgreeUrl;
                }
                else 
                {
                    AgentModel = AgentBll.GetModelName();
                    lbltitle.Text = AgentModel.Title;
                    lblContent.Text = AgentModel.Content;
                    lblPurpose.Text = AgentModel.Purpose;
                    DownAdd = AgentModel.AgreeUrl;
                }

            }
        }
    }
}
