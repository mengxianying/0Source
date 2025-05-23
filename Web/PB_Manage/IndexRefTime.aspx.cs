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
    public partial class IndexRefTime : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindRefData();
            }
        }

        /// <summary>
        /// 首页内容刷新时间配置
        /// </summary>
        private void BindRefData()
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/Bar_Ref");
            XmlElement xe1 = (XmlElement)node1;
            this.txtBarBase.Text = xe1.Attributes["jg"].Value;
            XmlNode node2 = doc.SelectSingleNode("/root/Bbs_Ref");
            XmlElement xe2 = (XmlElement)node2;
            this.txtBbsBase.Text = xe2.Attributes["jg"].Value;


            XmlNodeList productList = doc.SelectNodes("/root/Bar_Ref/special");
            if (!(productList != null && productList.Count == 3))
            {
                Response.Write(JS.Alert("xml/WebConfig.xml不完整，请先创建Bar_Ref节点或者其子节点！"));
                return;
            }
            //节点一
            XmlElement productXe1 = (XmlElement)productList[0];
            this.txtBarStart1.Text = productXe1.Attributes["start"].Value;
            this.txtBarEnd1.Text = productXe1.Attributes["end"].Value;
            this.txtBarJG1.Text = productXe1.Attributes["jg"].Value;
            this.rblBarOpen1.SelectedValue = productXe1.Attributes["isOpen"].Value;
            //节点二
            XmlElement productXe2 = (XmlElement)productList[1];
            string barStart2 = productXe2.Attributes["start"].Value;
            string barEnd2 = productXe2.Attributes["end"].Value;
            string barJg2 = productXe2.Attributes["jg"].Value;
            string barIsOpen2 = productXe2.Attributes["isOpen"].Value;
            if (!string.IsNullOrEmpty(barStart2) && !string.IsNullOrEmpty(barEnd2) && !string.IsNullOrEmpty(barJg2))
            {
                txtBarStart2.Text = barStart2;
                txtBarEnd2.Text = barEnd2;
                txtBarJG2.Text = barJg2;
                this.rblBarOpen2.SelectedValue = barIsOpen2;
             
            }
            //节点三
            XmlElement productXe3 = (XmlElement)productList[2];
            string barStart3 = productXe3.Attributes["start"].Value;
            string barEnd3 = productXe3.Attributes["end"].Value;
            string barJg3 = productXe3.Attributes["jg"].Value;
            string barIsOpen3 = productXe3.Attributes["isOpen"].Value;
            if (!string.IsNullOrEmpty(barStart3) && !string.IsNullOrEmpty(barEnd3) && !string.IsNullOrEmpty(barJg3))
            {
                txtBarStart3.Text = barStart3;
                txtBarEnd3.Text = barEnd3;
                txtBarJG3.Text = barJg3;
                this.rblBarOpen3.SelectedValue = barIsOpen3;
               
            }





            XmlNodeList BbsList = doc.SelectNodes("/root/Bbs_Ref/special");
            if (!(BbsList != null && BbsList.Count == 3))
            {
                Response.Write(JS.Alert("xml/WebConfig.xml不完整，请先创建Bbs_Ref节点或者其子节点！"));
                return;
            }
            //节点一
            XmlElement bbsXe1 = (XmlElement)BbsList[0];
            this.txtBbsStart1.Text = bbsXe1.Attributes["start"].Value;
            this.txtBbsEnd1.Text = bbsXe1.Attributes["end"].Value;
            this.txtBbsJG1.Text = bbsXe1.Attributes["jg"].Value;
            this.rblBbsOpen1.SelectedValue = bbsXe1.Attributes["isOpen"].Value;
            //节点二
            XmlElement bbsXe2 = (XmlElement)BbsList[1];
            string BbsStart2 = bbsXe2.Attributes["start"].Value;
            string BbsEnd2 = bbsXe2.Attributes["end"].Value;
            string BbsJg2 = bbsXe2.Attributes["jg"].Value;
            string BbsIsOpen2 = bbsXe2.Attributes["isOpen"].Value;
            if (!string.IsNullOrEmpty(BbsStart2) && !string.IsNullOrEmpty(BbsEnd2) && !string.IsNullOrEmpty(BbsJg2))
            {
                txtBbsStart2.Text = BbsStart2;
                txtBbsEnd2.Text = BbsEnd2;
                txtBbsJG2.Text = BbsJg2;
                this.rblBbsOpen2.SelectedValue = BbsIsOpen2;
             
            }
            //节点三
            XmlElement bbsXe3 = (XmlElement)BbsList[2];
            string BbsStart3 = bbsXe3.Attributes["start"].Value;
            string BbsEnd3 = bbsXe3.Attributes["end"].Value;
            string BbsJg3 = bbsXe3.Attributes["jg"].Value;
            string BbsIsOpen3 = bbsXe3.Attributes["isOpen"].Value;
            if (!string.IsNullOrEmpty(BbsStart3) && !string.IsNullOrEmpty(BbsEnd3) && !string.IsNullOrEmpty(BbsJg3))
            {
                txtBbsStart3.Text = BbsStart3;
                txtBbsEnd3.Text = BbsEnd3;
                txtBbsJG3.Text = BbsJg3;
                this.rblBbsOpen3.SelectedValue = BbsIsOpen3;
             
            }

        }

      

        protected void btnBarSave_Click(object sender, EventArgs e)
        {
            string barBase = txtBarBase.Text;
            if (string.IsNullOrEmpty(this.txtBarBase.Text))
            {
                Response.Write(JS.Alert("基本刷新时间间隔不能为空！"));
                return;
            }
            //加载xml
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);


            XmlNode nodeGen1 = doc.SelectSingleNode("/root/Bar_Ref");
            XmlElement xeGen1 = (XmlElement)nodeGen1;
            xeGen1.Attributes["jg"].Value = barBase;


            //第一节点配置
            string barStart1 = WebFunc.CheckTimeFormart(txtBarStart1.Text);
            string barEnd1 = WebFunc.CheckTimeFormart(txtBarEnd1.Text);
            string barJG1 = txtBarJG1.Text;
            string isOpen1 = this.rblBarOpen1.SelectedValue;
            if (barStart1 == null || barEnd1 == null)
            {
                Response.Write(JS.Alert("开始或者结束时间格式不正确"));
                return;
            }
            else if (!string.IsNullOrEmpty(barStart1) && !string.IsNullOrEmpty(barEnd1) && !string.IsNullOrEmpty(barJG1))
            {
                XmlNode node1 = doc.SelectSingleNode("/root/Bar_Ref/special[@id='1']");
                XmlElement xe1 = (XmlElement)node1;
                xe1.Attributes["start"].Value = barStart1;
                xe1.Attributes["end"].Value = barEnd1;
                xe1.Attributes["jg"].Value = barJG1;
                xe1.Attributes["isOpen"].Value = isOpen1;
                //doc.Save(path);                                   
            }

          
                //第二节点配置
                string barStart2 = WebFunc.CheckTimeFormart(txtBarStart2.Text);
                string barEnd2 = WebFunc.CheckTimeFormart(txtBarEnd2.Text);
                string barJG2 = txtBarJG2.Text;
                string isOpen2 = this.rblBarOpen2.SelectedValue;
                if (barStart2 == null || barEnd2 == null)
                {
                    Response.Write(JS.Alert("开始或者结束时间格式不正确"));
                    return;
                }
                else if (!string.IsNullOrEmpty(barStart2) && !string.IsNullOrEmpty(barEnd2) && !string.IsNullOrEmpty(barJG2))
                {
                    XmlNode node1 = doc.SelectSingleNode("/root/Bar_Ref/special[@id='2']");
                    XmlElement xe1 = (XmlElement)node1;
                    xe1.Attributes["start"].Value = barStart2;
                    xe1.Attributes["end"].Value = barEnd2;
                    xe1.Attributes["jg"].Value = barJG2;
                    xe1.Attributes["isOpen"].Value = isOpen2;
                    //doc.Save(path);
                }
           
                //第三节点配置
                string barStart3 = WebFunc.CheckTimeFormart(txtBarStart3.Text);
                string barEnd3 = WebFunc.CheckTimeFormart(txtBarEnd3.Text);
                string barJG3 = txtBarJG3.Text;
                string isOpen3 = this.rblBarOpen3.SelectedValue;
                if (barStart3 == null || barEnd3 == null)
                {
                    Response.Write(JS.Alert("开始或者结束时间格式不正确"));
                    return;
                }
                else if (!string.IsNullOrEmpty(barStart3) && !string.IsNullOrEmpty(barEnd3) && !string.IsNullOrEmpty(barJG3))
                {
                    XmlNode node1 = doc.SelectSingleNode("/root/Bar_Ref/special[@id='3']");
                    XmlElement xe1 = (XmlElement)node1;
                    xe1.Attributes["start"].Value = barStart3;
                    xe1.Attributes["end"].Value = barEnd3;
                    xe1.Attributes["jg"].Value = barJG3;
                    xe1.Attributes["isOpen"].Value = isOpen3;
                    //   doc.Save(path);
                }
            
            doc.Save(path);
            BindRefData();
        }
        protected void btnBbsSave_Click(object sender, EventArgs e)
        {
            string barBase = txtBbsBase.Text;
            if (string.IsNullOrEmpty(this.txtBbsBase.Text))
            {
                Response.Write(JS.Alert("基本刷新时间间隔不能为空！"));
                return;
            }
            //加载xml
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);

            XmlNode nodeGen = doc.SelectSingleNode("/root/Bbs_Ref");
            XmlElement xeGen = (XmlElement)nodeGen;
            xeGen.Attributes["jg"].Value = barBase;

            //第一节点配置
            string BbsStart1 = WebFunc.CheckTimeFormart(txtBbsStart1.Text);
            string BbsEnd1 = WebFunc.CheckTimeFormart(txtBbsEnd1.Text);
            string BbsJG1 = txtBbsJG1.Text;
            string isOpen1 = this.rblBbsOpen1.SelectedValue;
            if (BbsStart1 == null || BbsEnd1 == null)
            {
                Response.Write(JS.Alert("开始或者结束时间格式不正确"));
                return;
            }
            else if (!string.IsNullOrEmpty(BbsStart1) && !string.IsNullOrEmpty(BbsEnd1) && !string.IsNullOrEmpty(BbsJG1))
            {
                XmlNode node1 = doc.SelectSingleNode("/root/Bbs_Ref/special[@id='1']");
                XmlElement xe1 = (XmlElement)node1;
                xe1.Attributes["start"].Value = BbsStart1;
                xe1.Attributes["end"].Value = BbsEnd1;
                xe1.Attributes["jg"].Value = BbsJG1;
                xe1.Attributes["isOpen"].Value = isOpen1;
                // doc.Save(path);
            }

          
                //第二节点配置
                string BbsStart2 = WebFunc.CheckTimeFormart(txtBbsStart2.Text);
                string BbsEnd2 = WebFunc.CheckTimeFormart(txtBbsEnd2.Text);
                string BbsJG2 = txtBbsJG2.Text;
                string isOpen2 = this.rblBbsOpen2.SelectedValue;
                if (BbsStart2 == null || BbsEnd2 == null)
                {
                    Response.Write(JS.Alert("开始或者结束时间格式不正确"));
                    return;
                }
                else if (!string.IsNullOrEmpty(BbsStart2) && !string.IsNullOrEmpty(BbsEnd2) && !string.IsNullOrEmpty(BbsJG2))
                {
                    XmlNode node1 = doc.SelectSingleNode("/root/Bbs_Ref/special[@id='2']");
                    XmlElement xe1 = (XmlElement)node1;
                    xe1.Attributes["start"].Value = BbsStart2;
                    xe1.Attributes["end"].Value = BbsEnd2;
                    xe1.Attributes["jg"].Value = BbsJG2;
                    xe1.Attributes["isOpen"].Value = isOpen2;
                    //doc.Save(path);
                }
          
                //第三节点配置
                string BbsStart3 = WebFunc.CheckTimeFormart(txtBbsStart3.Text);
                string BbsEnd3 = WebFunc.CheckTimeFormart(txtBbsEnd3.Text);
                string BbsJG3 = txtBbsJG3.Text;
                string isOpen3 = this.rblBbsOpen3.SelectedValue;
                if (BbsStart3 == null || BbsEnd3 == null)
                {
                    Response.Write(JS.Alert("开始或者结束时间格式不正确"));
                    return;
                }
                else if (!string.IsNullOrEmpty(BbsStart3) && !string.IsNullOrEmpty(BbsEnd3) && !string.IsNullOrEmpty(BbsJG3))
                {
                    XmlNode node1 = doc.SelectSingleNode("/root/Bbs_Ref/special[@id='3']");
                    XmlElement xe1 = (XmlElement)node1;
                    xe1.Attributes["start"].Value = BbsStart3;
                    xe1.Attributes["end"].Value = BbsEnd3;
                    xe1.Attributes["jg"].Value = BbsJG3;
                    xe1.Attributes["isOpen"].Value = isOpen3;
                    // doc.Save(path);
               
            }
            doc.Save(path);
            BindRefData();
        }
    }
}
