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
    public partial class WebBaseAdminConfig : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/Other";
                Session["DefaultSelect"] = "/Images/UploadFiles/Other";
                BindWebBaseConfig();
                DataBinds();

                BindDefault();
            }
        }


        private void BindDefault()
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebDescribe.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("Default")[0];
                //�õ�����ID
                keywords.Text = haha.SelectSingleNode("@keywords").Value;
                description.Text = haha.SelectSingleNode("@description").Value;
                author.Text = haha.SelectSingleNode("@author").Value;

            }
        }

        /// <summary>
        /// ���ݰ󶨷���
        /// </summary>
        private void DataBinds()
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("pz")[0];
                //�õ�����ID
                txtcount.Text = haha.SelectSingleNode("@count").Value;
                txtjg.Text = haha.SelectSingleNode("@Hours").Value;
                string ips = haha.SelectSingleNode("@ip").Value;
                string sfs = haha.SelectSingleNode("@address").Value;
                txtip.Text = ips;
                txtsf.Text = sfs;

                XmlNode chirot = root.SelectNodes("userchar")[0];
                txtuserpb.Text = chirot.SelectSingleNode("@value").Value;


                XmlNode regs = root.SelectNodes("regist")[0];
                //�õ�����ID
                string ips1 = regs.SelectSingleNode("@ip").Value;
                string sfs1 = regs.SelectSingleNode("@address").Value;
                txtregistip.Text = ips1;
                txtregistsf.Text = sfs1;

                XmlNode userlogin = root.SelectNodes("userlogin")[0];
                string ips2 = userlogin.SelectSingleNode("@ip").Value;
                string sfs2 = userlogin.SelectSingleNode("@address").Value;
                txtuserloginip.Text = ips2;
                txtuserloginaddress.Text = sfs2;


                XmlNode adminloginIP = root.SelectNodes("adminloginIP")[0];
                string uIP1 = adminloginIP.SelectSingleNode("@ip").Value;
                string uIP2 = adminloginIP.SelectSingleNode("@address").Value;
                txtloginip.Text = uIP1;
                txtsave.Text = uIP2;

                XmlNode porxy = root.SelectNodes("proxy")[0];
                string p1 = porxy.SelectSingleNode("@proxyIP").Value;
                string p2 = porxy.SelectSingleNode("@award").Value;
                if (p1 == "1")
                {
                    RadioButtonList1.Items[0].Selected = true;
                }
                else
                {
                    RadioButtonList1.Items[1].Selected = true;
                }
                if (p2 == "0")
                {
                    RadioButtonList2.Items[0].Selected = true;
                }
                else
                {
                    RadioButtonList2.Items[1].Selected = true;
                }

            }
        }

        /// <summary>
        /// ��վ�������ð�����
        /// </summary>
        private void BindWebBaseConfig()
        {
            WebBaseConfig baseConfig = WebInit.webBaseConfig;
            this.txtExpress.Text = baseConfig.Express;
            this.txtChatUrl.Text = baseConfig.ChatUrl;
            this.txtWebUrl.Text = baseConfig.WebUrl;
            this.txtSoftdogPrice.Text = baseConfig.SoftdogPrice.ToString("0");
            txtWebPageNum.Text = baseConfig.WebPageNum.ToString();
            weBuy.Value = baseConfig.Buy;
            txtYearStart.Text = baseConfig.YearStart;
            txtYearEnd.Text = baseConfig.YearEnd;
            txtUserGet.Text = baseConfig.UserGet.ToString();
            TxtIP_ValideCode_Count.Text = baseConfig.IP_ValideCode_Count.ToString();
            TxtDowloadTips.Text = baseConfig.DowloadTips;
            TxtFirstPageTcodeDisp.Text = baseConfig.FirstPageTcodeDisp.ToString();

            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode xn = doc.SelectSingleNode("/root/UserConfig/BrokerAgreement");
            XmlElement xe = (XmlElement)xn;
            this.txtBrokerAgreement.Value = xe.Attributes["value"].Value;


            XmlNode xnDL = doc.SelectSingleNode("/root/UserConfig/AgentAgreement");
            XmlElement xeDL = (XmlElement)xnDL;
            this.txtAgentAgreement.Value = xeDL.Attributes["value"].Value;




        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnok_Click(object sender, EventArgs e)
        {
            if (txtcount.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('���ƴ�������Ϊ�գ�');</script>");
                return;
            }
            if (txtjg.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('����ʱ�䲻��Ϊ�գ�');</script>");
                return;
            }
            int cou = 0;
            if (!int.TryParse(txtcount.Text, out cou))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('���ƴ���ֻ��Ϊ������');</script>");
                return;
            }
            if (!int.TryParse(txtjg.Text, out cou))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('����ʱ��ֻ��Ϊ������Сʱ����');</script>");
                return;
            }
            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("pz")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@count").Value = txtcount.Text;
                    haha.SelectSingleNode("@Hours").Value = txtjg.Text;
                    haha.SelectSingleNode("@ip").Value = txtip.Text;
                    haha.SelectSingleNode("@address").Value = txtsf.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }

        /// <summary>
        /// ��վ�������� ���水ť�¼�
        /// </summary>
        protected void btnBaseConfig_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            decimal dcSoftdogPrice = 120;
            if (!decimal.TryParse(this.txtSoftdogPrice.Text, out dcSoftdogPrice))
            {
                errMsg += "������۸��ʽ����ȷ��";
            }
            int intWebPageNum = 20;
            if (!int.TryParse(this.txtWebPageNum.Text, out intWebPageNum))
            {
                errMsg += "ÿҳ��ʾ����Ӧ��Ϊ������";
            }

            if (!string.IsNullOrEmpty(this.txtYearStart.Text))
            {
                DateTime tempTM = new DateTime();
                if (!DateTime.TryParse(this.txtYearStart.Text, out tempTM))
                {
                    errMsg += "�������п�ʼʱ���ʽ����ȷ��";
                }
            }

            if (!string.IsNullOrEmpty(this.txtYearEnd.Text))
            {
                DateTime tempTM = new DateTime();
                if (!DateTime.TryParse(this.txtYearEnd.Text, out tempTM))
                {
                    errMsg += "�������н���ʱ���ʽ����ȷ��";
                }
            }
            decimal dcUserGet = 0;
            if (!decimal.TryParse(this.txtUserGet.Text, out dcUserGet))
            {
                errMsg += "�û���д�����˺����÷����ʽ����ȷ��";
            }
            else
            {
                if (dcUserGet >= 1 || dcUserGet < 0)
                {
                    errMsg += "�û���д�����˺����÷��������0��1֮���С����";
                }
            }

            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("����", JS.Alert("���ύ����Ϣ�����´������޸ĺ��ύ��\\r\\n" + errMsg));
                return;
            }
            WebBaseConfig baseConfig = WebInit.webBaseConfig;
            baseConfig.Express = this.txtExpress.Text;
            baseConfig.ChatUrl = this.txtChatUrl.Text;
            baseConfig.WebUrl = this.txtWebUrl.Text;
            baseConfig.SoftdogPrice = Convert.ToDecimal(this.txtSoftdogPrice.Text);
            baseConfig.Buy = weBuy.Value.Trim();
            baseConfig.WebPageNum = int.Parse(txtWebPageNum.Text);
            baseConfig.YearStart = this.txtYearStart.Text;
            baseConfig.YearEnd = this.txtYearEnd.Text;
            baseConfig.UserGet = decimal.Parse(this.txtUserGet.Text);

            baseConfig.IP_ValideCode_Count = int.Parse(this.TxtIP_ValideCode_Count.Text);
            baseConfig.DowloadTips = this.TxtDowloadTips.Text;
            baseConfig.FirstPageTcodeDisp = this.TxtFirstPageTcodeDisp.Text;
            WebInit.webBaseConfig = baseConfig;
            BindWebBaseConfig();
        }



        protected void btnDLJJJ_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = Server.MapPath("~/Xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/UserConfig/BrokerAgreement");
            ((XmlElement)node1).SetAttribute("value", this.txtBrokerAgreement.Value);
            //XmlNode node_en = doc.SelectSingleNode("/WebBaseConfig/RegeditAgreement_en");
            //((XmlElement)node_en).SetAttribute("value", this.txtRegediten.Text);

            XmlNode node2 = doc.SelectSingleNode("/root/UserConfig/AgentAgreement");
            ((XmlElement)node2).SetAttribute("value", this.txtAgentAgreement.Value);

            doc.Save(path);

        }
        /// <summary>
        /// ע���û������ַ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnuserpb_Click(object sender, EventArgs e)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("userchar")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@value").Value = txtuserpb.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }
        /// <summary>
        /// �û�ע��IP����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnregist_Click(object sender, EventArgs e)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("regist")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@ip").Value = txtregistip.Text;
                    haha.SelectSingleNode("@address").Value = txtregistsf.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }
        /// <summary>
        /// �û���¼����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnuserlogin_Click(object sender, EventArgs e)
        {

            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("userlogin")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@ip").Value = txtuserloginip.Text;
                    haha.SelectSingleNode("@address").Value = txtuserloginaddress.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }
        /// <summary>
        /// �������seo��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Default_Click(object sender, EventArgs e)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebDescribe.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("Default")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@keywords").Value = keywords.Text;
                    haha.SelectSingleNode("@description").Value = description.Text;
                    haha.SelectSingleNode("@author").Value = author.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebDescribe.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }

        /// <summary>
        /// ���õ�¼IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_UserIp_Click(object sender, EventArgs e)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("adminloginIP")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@ip").Value = txtloginip.Text;
                    haha.SelectSingleNode("@address").Value = txtsave.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }

        /// <summary>
        /// ���ô���ip�Ŀ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("proxy")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@proxyIP").Value =RadioButtonList1.SelectedValue;
                    haha.SelectSingleNode("@award").Value = RadioButtonList2.SelectedValue;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }
    }
}
