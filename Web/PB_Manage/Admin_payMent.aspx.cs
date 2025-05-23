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
    public partial class Admin_payMent : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                XmlDocument doc = new XmlDocument();
                string path = Server.MapPath("~/YunWangCncard/Web.config");
                doc.Load(path);
                XmlNode cnCardSH = doc.SelectSingleNode("/configuration/appSettings/add[@key='c_mid']");
                XmlElement xeCnCardSH = (XmlElement)cnCardSH;
                this.txtCncardSH.Text = xeCnCardSH.Attributes["value"].Value;

                XmlNode cnCardMY = doc.SelectSingleNode("/configuration/appSettings/add[@key='c_pass'] ");
                XmlElement xeCnCardMY = (XmlElement)cnCardMY;
                this.txtCncardMY.Text = xeCnCardMY.Attributes["value"].Value;

                
                XmlNode cnCardWZ = doc.SelectSingleNode("/configuration/appSettings/add[@key='receiveUrl'] ");
                XmlElement xeCnCardWZ = (XmlElement)cnCardWZ;
                this.txtCncardWZ.Text = xeCnCardWZ.Attributes["value"].Value;



            }
        }

        protected void btnCnCard_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/YunWangCncard/Web.config");
            doc.Load(path);
            XmlNode cnCardSH = doc.SelectSingleNode("/configuration/appSettings/add[@key='c_mid']");
            ((XmlElement)cnCardSH).SetAttribute("value", this.txtCncardSH.Text);

            XmlNode cnCardMY = doc.SelectSingleNode("/configuration/appSettings/add[@key='c_pass']");
            ((XmlElement)cnCardMY).SetAttribute("value", this.txtCncardMY.Text);

            XmlNode cnCardWZ = doc.SelectSingleNode("/configuration/appSettings/add[@key='receiveUrl']");
            ((XmlElement)cnCardWZ).SetAttribute("value", this.txtCncardWZ.Text);

            //XmlNode node_en = doc.SelectSingleNode("/WebBaseConfig/RegeditAgreement_en");
            //((XmlElement)node_en).SetAttribute("value", this.txtRegediten.Text);
            doc.Save(path);
        }
    }
}
