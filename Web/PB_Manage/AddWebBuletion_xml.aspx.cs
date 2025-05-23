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
    public partial class AddWebBuletion_xml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode xn = doc.SelectSingleNode("/root/WebBaseConfig/Buy");
            XmlElement xe = (XmlElement)xn;
            this.weCartNotice.Text = xe.Attributes["value"].Value;
            //XmlNode xn1 = doc.SelectSingleNode("/WebBaseConfig/Buy");
            //XmlElement xe1 = (XmlElement)xn1;
            //this.txtRegediten.Text = xe1.Attributes["value"].Value;

        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/Xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node_Cart = doc.SelectSingleNode("/root/WebBaseConfig/Buy");
            ((XmlElement)node_Cart).SetAttribute("value", this.weCartNotice.Text);
            //XmlNode node_en = doc.SelectSingleNode("/WebBaseConfig/RegeditAgreement_en");
            //((XmlElement)node_en).SetAttribute("value", this.txtRegediten.Text);
            doc.Save(path);
        }
    }
}
