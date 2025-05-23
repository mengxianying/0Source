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
using System.Xml;

namespace Pbzx.Web.PB_Manage
{
    public partial class AskXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindAxkXML();

                BindNewsXML();
            }
        }
        string tempLJ = HttpRuntime.AppDomainAppPath.Substring(0, HttpRuntime.AppDomainAppPath.Length - 1);

        private void BindNewsXML()
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
            XmlElement xe1 = (XmlElement)node1;
            string barWJJ = xe1.Attributes["value"].Value;

            string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

            XmlDocument XmlDoc;
            XmlNodeList NodeList;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");

            //�õ����ڵ�
            XmlElement root = XmlDoc.DocumentElement;
            XmlNode haha = root.SelectNodes("Ask_astrict")[0];
            //�õ�����ID
            string address = haha.SelectSingleNode("@address").Value;
            string value = haha.SelectSingleNode("@value").Value;
            string ip = haha.SelectSingleNode("@ip").Value;
            string msg = haha.SelectSingleNode("@msg").Value;

            string status = haha.SelectSingleNode("@status").Value;

            txtxzaddress.Text = address;
            txtxzip.Text = ip;
            txtxzzf.Text = value;
            txtmsg.Text = msg;


            if (bool.Parse(status))
            {
                rdblistsh.SelectedValue = "1";
            }
            else
            {
                rdblistsh.SelectedValue = "0";
            }

            XmlNode haha1 = root.SelectNodes("userlogin")[0];
            txtuserloginip.Text = haha1.SelectSingleNode("@ip").Value;
            txtuserloginaddress.Text = haha1.SelectSingleNode("@address").Value;
        }
        private void BindAxkXML()
        {
            SiteConfig sitefonfig = WebInit.siteconfig;
            //ҳ������
            txtCommend.Text = sitefonfig.CommendNum;
            txtHot.Text = sitefonfig.HotNum;
            txtPoint.Text = sitefonfig.PointNum;
            txtStateN.Text = sitefonfig.StateNNum;
            txtStateY.Text = sitefonfig.StateYNum;

            //����
            // txtWebTitle.Text = sitefonfig.WebTitle;
            txtwenkf.Text = sitefonfig.wenkf;
            txtdajiadf.Text = sitefonfig.dajiadf;
            txtdakf.Text = sitefonfig.dakf;
            txtregf.Text = sitefonfig.regf;

            txtdadf.Text = sitefonfig.dadf;
            txttjwendf.Text = sitefonfig.tjwendf;
            txtmdf.Text = sitefonfig.mdf;
            txttjdadf.Text = sitefonfig.tjdadf;
            txtgqkf.Text = sitefonfig.gqkf;

            //  txtclwendf.Text = sitefonfig.clwendf;
            txtOverTime.Text = sitefonfig.OverTime;
            //  txtplkf.Text = sitefonfig.plkf;
            txtBarBulletin.Text = sitefonfig.BarBulletin;

        }

        protected void btnIndex_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            int intWebPageNum = 20;
            if (!int.TryParse(this.txtCommend.Text, out intWebPageNum))
            {
                errMsg += "�����Ƽ�����Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtHot.Text, out intWebPageNum))
            {
                errMsg += "�����ȵ�������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtPoint.Text, out intWebPageNum))
            {
                errMsg += "���ͷ���������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtStateN.Text, out intWebPageNum))
            {
                errMsg += "���������������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtStateY.Text, out intWebPageNum))
            {
                errMsg += "�½������������Ӧ��Ϊ������";
            }



            if (!int.TryParse(this.txtwenkf.Text, out intWebPageNum))
            {
                errMsg += "�������ߺ󱻹���Աɾ�����۳��Ļ���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtdajiadf.Text, out intWebPageNum))
            {
                errMsg += "�ش����ߺ󱻹���Աɾ�����۳��Ļ���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtdakf.Text, out intWebPageNum))
            {
                errMsg += "�ش����ߺ󱻹���Աɾ�����۳��Ļ���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtregf.Text, out intWebPageNum))
            {
                errMsg += "�û�ע��ʱ��õĻ���Ӧ��Ϊ������";
            }




            if (!int.TryParse(this.txtdadf.Text, out intWebPageNum))
            {
                errMsg += "�û��ش�һ���������õĻ���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txttjwendf.Text, out intWebPageNum))
            {
                errMsg += "���ⱻѡΪ�����Ƽ����������õĻ���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtmdf.Text, out intWebPageNum))
            {
                errMsg += "�û����������������Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txttjdadf.Text, out intWebPageNum))
            {
                errMsg += "���ⱻѡΪ�����Ƽ���ѻش������õĻ���Ӧ��Ϊ������";
            }
            if (!int.TryParse(this.txtgqkf.Text, out intWebPageNum))
            {
                errMsg += "����15���ڲ��������۳��Ļ���Ӧ��Ϊ������";
            }


            //if (!int.TryParse(this.txtclwendf.Text, out intWebPageNum))
            //{
            //    errMsg += "�����������Ӧ��Ϊ������";
            //}
            if (!int.TryParse(this.txtOverTime.Text, out intWebPageNum))
            {
                errMsg += "��Ϊ��������ʱ��Ӧ��Ϊ������";
            }
            //if (!int.TryParse(this.txtplkf.Text, out intWebPageNum))
            //{
            //    errMsg += "���۱�ɾ���������ߵĻ��ֽ����۳���Ӧ��Ϊ������";
            //}
            if (!int.TryParse(this.txtBarBulletin.Text, out intWebPageNum))
            {
                errMsg += "ƴ�������¹�����ʾ��Ӧ��Ϊ������";
            }
            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("����", JS.Alert("���ύ����Ϣ�����´������޸ĺ��ύ��\\r\\n" + errMsg));
                return;
            }

            SiteConfig sitefonfig = new SiteConfig();
            sitefonfig.CommendNum = txtCommend.Text;
            sitefonfig.HotNum = txtHot.Text;
            sitefonfig.PointNum = txtPoint.Text;
            sitefonfig.StateNNum = txtStateN.Text;
            sitefonfig.StateYNum = txtStateY.Text;
            //����
            // sitefonfig.WebTitle=txtWebTitle.Text;
            sitefonfig.wenkf = txtwenkf.Text;
            sitefonfig.dajiadf = txtdajiadf.Text;
            sitefonfig.dakf = txtdakf.Text;
            sitefonfig.regf = txtregf.Text;

            sitefonfig.dadf = txtdadf.Text;
            sitefonfig.tjwendf = txttjwendf.Text;
            sitefonfig.mdf = txtmdf.Text;
            sitefonfig.tjdadf = txttjdadf.Text;
            sitefonfig.gqkf = txtgqkf.Text;

            //  sitefonfig.clwendf = txtclwendf.Text ;
            sitefonfig.OverTime = txtOverTime.Text;

            // sitefonfig.plkf = txtplkf.Text;
            sitefonfig.BarBulletin = txtBarBulletin.Text;
            WebInit.siteconfig = sitefonfig;
            BindAxkXML();
        }

        protected void btnyz_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
            XmlElement xe1 = (XmlElement)node1;
            string barWJJ = xe1.Attributes["value"].Value;

            string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

            XmlDocument XmlDoc;
            XmlNodeList NodeList;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");

            //�õ����ڵ�
            XmlElement root = XmlDoc.DocumentElement;
            XmlNode haha = root.SelectNodes("Ask_astrict")[0];
            //�õ�����ID
            haha.SelectSingleNode("@address").Value = txtxzaddress.Text;
            haha.SelectSingleNode("@value").Value = txtxzzf.Text;
            haha.SelectSingleNode("@ip").Value = txtxzip.Text;
            haha.SelectSingleNode("@msg").Value = txtmsg.Text;

            if (rdblistsh.SelectedValue == "1")
            {
                haha.SelectSingleNode("@status").Value = "true";
            }
            else
            {
                haha.SelectSingleNode("@status").Value = "false";
            }

            XmlDoc.Save(currentASK + "\\Xml\\AskConfig.xml");
        }
        /// <summary>
        /// �û���¼������֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnuserlogin_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
            XmlElement xe1 = (XmlElement)node1;
            string barWJJ = xe1.Attributes["value"].Value;

            string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

            XmlDocument XmlDoc;
            XmlNodeList NodeList;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");

            //�õ����ڵ�
            XmlElement root = XmlDoc.DocumentElement;
            XmlNode haha = root.SelectNodes("userlogin")[0];
            //�õ�����ID
            haha.SelectSingleNode("@address").Value = txtuserloginaddress.Text;
            haha.SelectSingleNode("@ip").Value = txtuserloginip.Text;
            XmlDoc.Save(currentASK + "\\Xml\\AskConfig.xml");
        }
    }
}
