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
using System.Xml;

namespace Pbzx.Web.PB_Manage
{
    public partial class WebDomainConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindChatDomain();
            }
        }

        /// <summary>
        /// ¡ƒ≤  “WebDomain≈‰÷√
        /// </summary>
        private void BindChatDomain()
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebDomainConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/Root/WwwUrl");
            XmlElement xe1 = (XmlElement)node1;
            this.txtWwwUrl.Text = xe1.Attributes["value"].Value;

            XmlNode node2 = doc.SelectSingleNode("/Root/BarUrl");
            XmlElement xe2 = (XmlElement)node2;
            this.txtBarUrl.Text = xe2.Attributes["value"].Value;

            XmlNode node3 = doc.SelectSingleNode("/Root/ChatUrl");
            XmlElement xe3 = (XmlElement)node3;
            this.txtChatUrl1.Text = xe3.Attributes["value"].Value;
        }

        /// <summary>
        /// ¡ƒ≤  “WebDomain≈‰÷√ ±£¥Ê∞¥≈•
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChatConfig_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebDomainConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/Root/WwwUrl");
            XmlElement xe1 = (XmlElement)node1;
            xe1.Attributes["value"].Value = txtWwwUrl.Text;

            XmlNode node2 = doc.SelectSingleNode("/Root/BarUrl");
            XmlElement xe2 = (XmlElement)node2;
            xe2.Attributes["value"].Value = txtBarUrl.Text;

            XmlNode node3 = doc.SelectSingleNode("/Root/ChatUrl");
            XmlElement xe3 = (XmlElement)node3;
            xe3.Attributes["value"].Value = txtChatUrl1.Text;

            doc.Save(path);
            BindChatDomain();
        }

    }
}
