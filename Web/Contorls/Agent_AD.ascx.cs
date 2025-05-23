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

namespace Pbzx.Web.Contorls
{
    public partial class Agent_AD : System.Web.UI.UserControl
    {
        public string Tonglan = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowAllAd();
            }
        }
        private void ShowAllAd()
        {
            Pbzx.BLL.PBnet_Adv AdBll = new Pbzx.BLL.PBnet_Adv();
            Pbzx.Model.PBnet_Adv AdModel_Tonglan = AdBll.GetModelName("代理广告第1行，第1列");

            if ((AdModel_Tonglan.pb_ENDTime > DateTime.Now.Date) && AdModel_Tonglan.pb_IsSelected)
            {
                this.AgentAd.Visible = true;
                Tonglan += "<a href='" + AdModel_Tonglan.pb_SiteUrl + "' title='" + AdModel_Tonglan.pb_SiteName + "' target='_blank'>";
                Tonglan += "<img src='" + AdModel_Tonglan.pb_ImgUrl + "' width='" + AdModel_Tonglan.pb_ImgWidth + "' border='0' height='" + AdModel_Tonglan.pb_ImgHeight + "'>";
                Tonglan += "</a>";
            }
        }
    }
}