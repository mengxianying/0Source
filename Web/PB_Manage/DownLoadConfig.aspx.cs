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
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class DownLoadConfig : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData();
            }
        }


        /// <summary>
        /// 商品下载配置
        /// </summary>
        private void BindData()
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);

            XmlNodeList productList = doc.SelectNodes("/root/ProductDownLoad/Down");
            if (!(productList != null && productList.Count == 4))
            {
                Response.Write(JS.Alert("xml/WebConfig.xml不完整，请先创建ProductDownLoad节点，及其子节点！"));
                return;
            }
            XmlElement productXe1 = (XmlElement)productList[0];
            this.txtProductName1.Text = productXe1.Attributes["name"].Value;
            this.txtProductUrl1.Text = productXe1.Attributes["Url"].Value;
            this.rblProductOpen1.SelectedValue = productXe1.Attributes["IsOpen"].Value;
            this.rblProductNeedLogin1.SelectedValue = productXe1.Attributes["NeedLogin"].Value;
            XmlElement productXe2 = (XmlElement)productList[1];
            this.txtProductName2.Text = productXe2.Attributes["name"].Value;
            this.txtProductUrl2.Text = productXe2.Attributes["Url"].Value;
            this.rblProductOpen2.SelectedValue = productXe2.Attributes["IsOpen"].Value;
            this.rblProductNeedLogin2.SelectedValue = productXe2.Attributes["NeedLogin"].Value;
            XmlElement productXe3 = (XmlElement)productList[2];
            this.txtProductName3.Text = productXe3.Attributes["name"].Value;
            this.txtProductUrl3.Text = productXe3.Attributes["Url"].Value;
            this.rblProductOpen3.SelectedValue = productXe3.Attributes["IsOpen"].Value;
            this.rblProductNeedLogin3.SelectedValue = productXe3.Attributes["NeedLogin"].Value;
            XmlElement productXe4 = (XmlElement)productList[3];
            this.txtProductName4.Text = productXe4.Attributes["name"].Value;
            this.txtProductUrl4.Text = productXe4.Attributes["Url"].Value;
            this.rblProductOpen4.SelectedValue = productXe4.Attributes["IsOpen"].Value;
            this.rblProductNeedLogin4.SelectedValue = productXe4.Attributes["NeedLogin"].Value;



            XmlNodeList softList = doc.SelectNodes("/root/SoftDownLoad/Down");
            XmlElement softXe1 = (XmlElement)softList[0];
            this.txtSoftName1.Text = softXe1.Attributes["name"].Value;
            this.txtSoftUrl1.Text = softXe1.Attributes["Url"].Value;
            this.rblSoftOpen1.SelectedValue = softXe1.Attributes["IsOpen"].Value;
            this.rblSoftNeedLogin1.SelectedValue = softXe1.Attributes["NeedLogin"].Value;
            XmlElement softXe2 = (XmlElement)softList[1];
            this.txtSoftName2.Text = softXe2.Attributes["name"].Value;
            this.txtSoftUrl2.Text = softXe2.Attributes["Url"].Value;
            this.rblSoftOpen2.SelectedValue = softXe2.Attributes["IsOpen"].Value;
            this.rblSoftNeedLogin2.SelectedValue = softXe2.Attributes["NeedLogin"].Value;
            XmlElement softXe3 = (XmlElement)softList[2];
            this.txtSoftName3.Text = softXe3.Attributes["name"].Value;
            this.txtSoftUrl3.Text = softXe3.Attributes["Url"].Value;
            this.rblSoftOpen3.SelectedValue = softXe3.Attributes["IsOpen"].Value;
            this.rblSoftNeedLogin3.SelectedValue = softXe3.Attributes["NeedLogin"].Value;
            XmlElement softXe4 = (XmlElement)softList[3];
            this.txtSoftName4.Text = softXe4.Attributes["name"].Value;
            this.txtSoftUrl4.Text = softXe4.Attributes["Url"].Value;
            this.rblSoftOpen4.SelectedValue = softXe4.Attributes["IsOpen"].Value;
            this.rblSoftNeedLogin4.SelectedValue = softXe4.Attributes["NeedLogin"].Value;
        }

        protected void btnProduct1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/ProductDownLoad/Down[@Id='1']");
            XmlElement xe1 = (XmlElement)node1;
            xe1.Attributes["name"].Value = this.txtProductName1.Text.Trim();
            xe1.Attributes["Url"].Value = this.txtProductUrl1.Text.Trim();
            xe1.Attributes["IsOpen"].Value = this.rblProductOpen1.SelectedValue;
            xe1.Attributes["NeedLogin"].Value = this.rblProductNeedLogin1.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnProduct2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node2 = doc.SelectSingleNode("/root/ProductDownLoad/Down[@Id='2']");
            XmlElement xe2 = (XmlElement)node2;
            xe2.Attributes["name"].Value = this.txtProductName2.Text.Trim();
            xe2.Attributes["Url"].Value = this.txtProductUrl2.Text.Trim();
            xe2.Attributes["IsOpen"].Value = this.rblProductOpen2.SelectedValue;
            xe2.Attributes["NeedLogin"].Value = this.rblProductNeedLogin2.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnProduct3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node3 = doc.SelectSingleNode("/root/ProductDownLoad/Down[@Id='3']");
            XmlElement xe3 = (XmlElement)node3;
            xe3.Attributes["name"].Value = this.txtProductName3.Text.Trim();
            xe3.Attributes["Url"].Value = this.txtProductUrl3.Text.Trim();
            xe3.Attributes["IsOpen"].Value = this.rblProductOpen3.SelectedValue;
            xe3.Attributes["NeedLogin"].Value = this.rblProductNeedLogin3.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnProduct4_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node4 = doc.SelectSingleNode("/root/ProductDownLoad/Down[@Id='4']");
            XmlElement xe4 = (XmlElement)node4;
            xe4.Attributes["name"].Value = this.txtProductName4.Text.Trim();
            xe4.Attributes["Url"].Value = this.txtProductUrl4.Text.Trim();
            xe4.Attributes["IsOpen"].Value = this.rblProductOpen4.SelectedValue;
            xe4.Attributes["NeedLogin"].Value = this.rblProductNeedLogin4.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnSoft1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/SoftDownLoad/Down[@Id='1']");
            XmlElement xe1 = (XmlElement)node1;
            xe1.Attributes["name"].Value = this.txtSoftName1.Text.Trim();
            xe1.Attributes["Url"].Value = this.txtSoftUrl1.Text.Trim();
            xe1.Attributes["IsOpen"].Value = this.rblSoftOpen1.SelectedValue;
            xe1.Attributes["NeedLogin"].Value = this.rblSoftNeedLogin1.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnSoft2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node2 = doc.SelectSingleNode("/root/SoftDownLoad/Down[@Id='2']");
            XmlElement xe2 = (XmlElement)node2;
            xe2.Attributes["name"].Value = this.txtSoftName2.Text.Trim();
            xe2.Attributes["Url"].Value = this.txtSoftUrl2.Text.Trim();
            xe2.Attributes["IsOpen"].Value = this.rblSoftOpen2.SelectedValue;
            xe2.Attributes["NeedLogin"].Value = this.rblSoftNeedLogin2.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnSoft3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node3 = doc.SelectSingleNode("/root/SoftDownLoad/Down[@Id='3']");
            XmlElement xe3 = (XmlElement)node3;
            xe3.Attributes["name"].Value = this.txtSoftName3.Text.Trim();
            xe3.Attributes["Url"].Value = this.txtSoftUrl3.Text.Trim();
            xe3.Attributes["IsOpen"].Value = this.rblSoftOpen3.SelectedValue;
            xe3.Attributes["NeedLogin"].Value = this.rblSoftNeedLogin3.SelectedValue;
            doc.Save(path);
            BindData();
        }

        protected void btnSoft4_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node4 = doc.SelectSingleNode("/root/SoftDownLoad/Down[@Id='4']");
            XmlElement xe4 = (XmlElement)node4;
            xe4.Attributes["name"].Value = this.txtSoftName4.Text.Trim();
            xe4.Attributes["Url"].Value = this.txtSoftUrl4.Text.Trim();
            xe4.Attributes["IsOpen"].Value = this.rblSoftOpen4.SelectedValue;
            xe4.Attributes["NeedLogin"].Value = this.rblSoftNeedLogin4.SelectedValue;
            doc.Save(path);
            BindData();
        }
    }
}
