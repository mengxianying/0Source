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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftMessage_EditXML_2011 : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TJ"] == "100")
                {
                    Txtnumber.Visible = false;
                    Droplist.Visible = true;
                    if (Request.QueryString["name"] != "")
                    {
                        XmlDocument doc = new XmlDocument();
                        //�ж������ʲô�����޶�
                        XMLLoad(doc);

                        //�õ����ڵ�
                        XmlElement root = doc.DocumentElement;
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {

                            XmlNode haha = root.SelectNodes("reg")[i];
                            //�õ�����ID
                            string ss = haha.SelectSingleNode("@name").Value;

                            if (ss == Request.QueryString["name"])
                            {
                                Droplist.SelectedValue = haha.SelectSingleNode("@number").Value;
                                Txtname.Text = haha.SelectSingleNode("@name").Value;
                                if (Request.QueryString["TJ"] == "3")
                                {
                                    txtMsg_Minute.Text = haha.SelectSingleNode("@Msg_Minute").Value;
                                }
                                return;
                            }
                        }

                    }
                    return;
                }
                //������Ϊ���ʱ 
                if (Request.QueryString["TJ"] != null && Request.QueryString["number"] == null)
                {
                    //�ж������ʲô�����޶�
                    switch (Request.QueryString["TJ"])
                    {
                        case "1":
                            btnOk.Text = "���ע���޶�";
                            break;
                        case "2":
                            btnOk.Text = "����û��޶�";
                            break;
                        case "3":
                            Label1.Visible = true;
                            txtMsg_Minute.Visible = true;
                            btnOk.Text = "�����Ϣ�ȼ��޶�";
                            break;
                        case "4":
                            btnOk.Text = "�����Ϣ����޶�";
                            break;
                        case "5":
                            btnOk.Text = "���ϵͳ�汾";
                            break;
                    }
                }
                else if (Request.QueryString["number"] != null)
                {
                    XmlDocument doc = new XmlDocument();
                    //�ж������ʲô�����޶�
                    XMLLoad(doc);

                    //�õ����ڵ�
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {

                        XmlNode haha = root.SelectNodes("reg")[i];
                        //�õ�����ID
                        string ss = haha.SelectSingleNode("@number").Value;

                        if (ss == Request.QueryString["number"])
                        {
                            if (Request.QueryString["TJ"] == "3")
                            {
                                txtMsg_Minute.Text = haha.SelectSingleNode("@Msg_Minute").Value;
                            }
                            Txtnumber.Text = haha.SelectSingleNode("@number").Value;
                            Txtnumber.Enabled = false;
                            Txtname.Text = haha.SelectSingleNode("@name").Value;
                            return;
                        }
                    }
                }

            }
        }
        /// <summary>
        /// ����ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            //����
            if (Request.QueryString["TJ"] == "100")
            {
                //�ж�����ӻ����޸�
                if (Request.QueryString["TJ"] != null && Request.QueryString["name"] == null)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();

                        XMLLoad(doc);

                        //�õ����ڵ�
                        XmlElement root = doc.DocumentElement;
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {

                            XmlNode haha = root.SelectNodes("reg")[i];
                            //�õ�����name
                            string ss = haha.SelectSingleNode("@name").Value;

                            if (ss == Txtname.Text)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�������Ѵ��ڣ�');</script>");
                                return;
                            }
                        }

                        XmlElement ele = doc.CreateElement("reg");
                        ele.SetAttribute("name", Txtname.Text);
                        ele.SetAttribute("number", Droplist.SelectedValue);
                        root.AppendChild(ele);

                        XMLSave(doc);
                        return;
                    }
                    catch
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�������ʧ�ܣ�');</script>");
                        return;
                    }
                }
                else
                {
                    //��Ϊ�޸�ʱ
                    if (Request.QueryString["name"] != null)
                    {
                        XmlDocument doc = new XmlDocument();
                        //�ж������ʲô�����޶�

                        XMLLoad(doc);

                        //�õ����ڵ�
                        XmlElement root = doc.DocumentElement;
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {

                            XmlNode haha = root.SelectNodes("reg")[i];
                            //�õ�����ID
                            string ss = haha.SelectSingleNode("@name").Value;

                            if (ss == Request.QueryString["name"])
                            {
                                haha.SelectSingleNode("@name").Value = Txtname.Text;
                                haha.SelectSingleNode("@number").Value = Droplist.SelectedValue;
                            }
                        }
                        XMLSave(doc);
                        return;

                    }

                }

                return;
            }


            if (Txtnumber.Text == "" || Txtnumber.Text.Trim().Length <= 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('����дID��');</script>");
                return;
            }
            //int id = 0;
            //if (!int.TryParse(Txtnumber.Text, out id))
            //{
            //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('����ȷ��дID(����Ϊ����)��');</script>");
            //    return;
            //}
            if (Txtname.Text == "" || Txtname.Text.Trim().Length <= 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('����д����');</script>");
                return;
            }

            //�ж�����ӻ����޸�
            if (Request.QueryString["TJ"] != null && Request.QueryString["number"] == null)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();

                    XMLLoad(doc);

                    //�õ����ڵ�
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {

                        XmlNode haha = root.SelectNodes("reg")[i];
                        //�õ�����ID
                        string ss = haha.SelectSingleNode("@number").Value;

                        if (ss == Txtnumber.Text)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('��ID���Ѵ��ڣ�');</script>");
                            return;
                        }
                        string name = haha.SelectSingleNode("@name").Value;

                        if (name == Txtname.Text)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�������Ѵ��ڣ�');</script>");
                            return;
                        }
                    }

                    XmlElement ele = doc.CreateElement("reg");
                    ele.SetAttribute("name", Txtname.Text);
                    ele.SetAttribute("number", Txtnumber.Text);
                    if (Request.QueryString["TJ"] == "3")
                    {
                        ele.SetAttribute("Msg_Minute", txtMsg_Minute.Text);
                    }
                    root.AppendChild(ele);

                    XMLSave(doc);
                    return;
                }
                catch
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�������ʧ�ܣ�');</script>");
                    return;
                }
            }
            else
            {
                //��Ϊ�޸�ʱ
                if (Request.QueryString["number"] != null)
                {
                    XmlDocument doc = new XmlDocument();
                    //�ж������ʲô�����޶�

                    XMLLoad(doc);

                    //�õ����ڵ�
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {

                        XmlNode haha = root.SelectNodes("reg")[i];
                        //�õ�����ID
                        string ss = haha.SelectSingleNode("@number").Value;

                        if (ss == Request.QueryString["number"])
                        {
                            haha.SelectSingleNode("@name").Value = Txtname.Text;
                            if (Request.QueryString["TJ"] == "3")
                            {
                                haha.SelectSingleNode("@Msg_Minute").Value = txtMsg_Minute.Text;
                            }
                        }
                    }

                    XMLSave(doc);
                    return;

                }

            }

        }
        /// <summary>
        /// xml���ط���
        /// </summary>
        /// <param name="doc"></param>
        private void XMLLoad(XmlDocument doc)
        {
            //�ж������ʲô�����޶�
            switch (Request.QueryString["TJ"])
            {
                case "1":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_RegType.xml"));
                    break;
                case "2":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_UserClass.xml"));
                    break;
                case "3":
                    Label1.Visible = true;
                    txtMsg_Minute.Visible = true;
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
                    break;
                case "4":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortOne.xml"));//װ��XML�ĵ� 
                    break;
                case "100":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));//װ��XML�ĵ� 
                    break;
                case "5":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/OSVersion.xml"));//װ��XML�ĵ� 
                    break;
            }
        }
        /// <summary>
        /// xml���淽��
        /// </summary>
        /// <param name="doc"></param>
        private void XMLSave(XmlDocument doc)
        {
            switch (Request.QueryString["TJ"])
            {
                case "1":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_RegType.xml"));
                    break;
                case "2":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_UserClass.xml"));
                    break;
                case "3":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
                    break;
                case "4":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortOne.xml"));//װ��XML�ĵ� 
                    break;
                case "100":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));//װ��XML�ĵ� 
                    break;
                case "5":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/OSVersion.xml"));//װ��XML�ĵ� 
                    break;
            }

            Response.Redirect("SoftMessage_XML_2011.aspx?oneId=" + Droplist.SelectedValue);
            return;
        }

        /// <summary>
        ///���ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btnreset_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["oneId"] != "")
            {
                Response.Redirect("SoftMessage_XML_2011.aspx?oneId=" + Request.QueryString["oneId"]);
            }
            Response.Redirect("SoftMessage_XML_2011.aspx");
            return;
        }
    }
}
