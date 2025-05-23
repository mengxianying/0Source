using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Collections;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftMessage_XML_2011 : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                //ע���޶���Ϣ�б��
                zhuceBind();
                //�û��޶���Ϣ��
                UserBind();
                //��Ϣ�ȼ�
                MsgDJBind();
                //��Ϣ���
                MsgLbBind();

                towBind();
                //ϵͳ�汾��
                OSviso();
            }
        }

        private void OSviso()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/OSVersion.xml";
            GridOS.DataSource = das;
            GridOS.DataBind();
        }

        private void towBind()
        {
            if (Request.QueryString["oneId"] != null && Request.QueryString["oneId"] != "")
            {
                DataTable tab = new DataTable();
                tab.Columns.Add("number");
                tab.Columns.Add("name");

                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));

                XmlElement root = doc.DocumentElement;
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {

                    XmlNode haha = root.SelectNodes("reg")[i];
                    //�õ�����ID
                    string ss = haha.SelectSingleNode("@number").Value;

                    if (ss == Request.QueryString["oneId"])
                    {
                        tab.Rows.Add(haha.SelectSingleNode("@number").Value, haha.SelectSingleNode("@name").Value);
                    }
                }
                Grvdtwo.DataSource = tab;
                Grvdtwo.DataBind();
            }
        }


        #region ���ݰ󶨷���
        /// <summary>
        /// ע���޶���
        /// </summary>
        private void zhuceBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_RegType.xml";
            Grvdzhuce.DataSource = das;
            Grvdzhuce.DataBind();
        }

        /// <summary>
        /// �û��޶���Ϣ
        /// </summary>
        private void UserBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_UserClass.xml";
            GrvdUserclass.DataSource = das;
            GrvdUserclass.DataBind();
        }
        /// <summary>
        /// ��Ϣ���
        /// </summary>
        private void MsgLbBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_SortOne.xml";
            GrvdLB.DataSource = das;
            GrvdLB.DataBind();

        }
        /// <summary>
        /// ��Ϣ�ȼ���
        /// </summary>
        private void MsgDJBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_Private.xml";
            GrvdDJ.DataSource = das;
            GrvdDJ.DataBind();
        }

        #endregion

        #region �¼�
        /// <summary>
        /// ע�������¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grvdzhuce_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                Response.Redirect("SoftMessage_EditXML_2011.aspx?number=" + e.CommandArgument.ToString() + "&TJ=1");
                return;
            }
            if (e.CommandName == "De")
            {
                DeleteXML(e, "~/xml/Msg_RegType.xml");
                Response.Redirect("SoftMessage_XML_2011.aspx");
            }
        }

        /// <summary>
        /// �û��޶��������¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrvdUserclass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                Response.Redirect("SoftMessage_EditXML_2011.aspx?number=" + e.CommandArgument.ToString() + "&TJ=2");
                return;
            }
            if (e.CommandName == "De")
            {
                DeleteXML(e, "~/xml/Msg_UserClass.xml");
                Response.Redirect("SoftMessage_XML_2011.aspx");
            }
        }

        /// <summary>
        /// ��Ϣ�ȼ��������¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrvdDJ_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                Response.Redirect("SoftMessage_EditXML_2011.aspx?number=" + e.CommandArgument.ToString() + "&TJ=3");
                return;
            }
            if (e.CommandName == "De")
            {
                DeleteXML(e, "~/xml/Msg_Private.xml");
                Response.Redirect("SoftMessage_XML_2011.aspx");
            }
        }
        /// <summary>
        /// ��Ϣ���ͱ������¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrvdLB_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                Response.Redirect("SoftMessage_EditXML_2011.aspx?number=" + e.CommandArgument.ToString() + "&TJ=4");
                return;
            }
            if (e.CommandName == "De")
            {
                DeleteXML(e, "~/xml/Msg_SortOne.xml");
                DeleteXML(e, "~/xml/Msg_SortTwo.xml");
                Response.Redirect("SoftMessage_XML_2011.aspx");
            }
        }
        /// <summary>
        /// ϵͳ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridOS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                Response.Redirect("SoftMessage_EditXML_2011.aspx?number=" + e.CommandArgument.ToString() + "&TJ=5");
                return;
            }
            if (e.CommandName == "De")
            {
                DeleteXML(e, "~/xml/OSVersion.xml");
                Response.Redirect("SoftMessage_XML_2011.aspx");
            }
        }
        #endregion

        #region ����޶���Ϣ
        /// <summary>
        /// ���ע���޶�
        /// ���� TJ=1Ϊ���ע���޶�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=1");
            return;
        }
        /// <summary>
        /// ����û��޶�
        /// ���� TJ=2Ϊ����û��޶�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=2");
            return;
        }
        /// <summary>
        /// �����Ϣ�ȼ��޶�
        /// ���� TJ=3Ϊ��ӵȼ��޶�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=3");
            return;
        }
        /// <summary>
        /// �����Ϣ����޶�
        /// ���� TJ=4Ϊ�������޶�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=4");
            return;
        }

        /// <summary>
        ///���ϵͳ�汾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=5");
            return;
        }
        #endregion

        /// <summary>
        /// ɾ�����÷���
        /// </summary>
        /// <param name="e"></param>
        /// <param name="lj"></param>
        private static void DeleteXML(GridViewCommandEventArgs e, string lj)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath(lj));

            XmlElement root = doc.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //�õ�����ID
                string ss = haha.SelectSingleNode("@number").Value;

                if (ss == e.CommandArgument.ToString())
                {
                    root.RemoveChild(haha);
                }
            }
            doc.Save(System.Web.HttpContext.Current.Server.MapPath(lj));
        }
        /// <summary>
        /// �����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grvdtwo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Up")
            {
                Response.Redirect("SoftMessage_EditXML_2011.aspx?name=" + e.CommandArgument.ToString() + "&TJ=100&oneId=" + Request.QueryString["oneId"]);
                return;
            }
            if (e.CommandName == "De")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));

                XmlElement root = doc.DocumentElement;
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    XmlNode haha = root.SelectNodes("reg")[i];
                    //�õ�����ID
                    string ss = haha.SelectSingleNode("@name").Value;

                    if (ss == e.CommandArgument.ToString())
                    {
                        root.RemoveChild(haha);
                    }
                }
                doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));
                Response.Redirect("SoftMessage_XML_2011.aspx?oneId=" + Request.QueryString["oneId"]);
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=100");
            return;
        }




    }
}
