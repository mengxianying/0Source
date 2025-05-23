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
             
                //注册限定信息列表绑定
                zhuceBind();
                //用户限定信息绑定
                UserBind();
                //消息等级
                MsgDJBind();
                //消息类别
                MsgLbBind();

                towBind();
                //系统版本绑定
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
                    //得到他的ID
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


        #region 数据绑定方法
        /// <summary>
        /// 注册限定绑定
        /// </summary>
        private void zhuceBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_RegType.xml";
            Grvdzhuce.DataSource = das;
            Grvdzhuce.DataBind();
        }

        /// <summary>
        /// 用户限定信息
        /// </summary>
        private void UserBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_UserClass.xml";
            GrvdUserclass.DataSource = das;
            GrvdUserclass.DataBind();
        }
        /// <summary>
        /// 消息类别
        /// </summary>
        private void MsgLbBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_SortOne.xml";
            GrvdLB.DataSource = das;
            GrvdLB.DataBind();

        }
        /// <summary>
        /// 消息等级绑定
        /// </summary>
        private void MsgDJBind()
        {
            XmlDataSource das = new XmlDataSource();
            das.DataFile = "~/xml/Msg_Private.xml";
            GrvdDJ.DataSource = das;
            GrvdDJ.DataBind();
        }

        #endregion

        #region 事件
        /// <summary>
        /// 注册命令事件激发
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
        /// 用户限定表命令事件激发
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
        /// 消息等级表命令事件激发
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
        /// 消息类型表命令事件激发
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
        /// 系统类型命令激发
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

        #region 添加限定信息
        /// <summary>
        /// 添加注册限定
        /// 参数 TJ=1为添加注册限定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=1");
            return;
        }
        /// <summary>
        /// 添加用户限定
        /// 参数 TJ=2为添加用户限定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=2");
            return;
        }
        /// <summary>
        /// 添加消息等级限定
        /// 参数 TJ=3为添加等级限定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=3");
            return;
        }
        /// <summary>
        /// 添加消息类别限定
        /// 参数 TJ=4为添加类别限定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_EditXML_2011.aspx?TJ=4");
            return;
        }

        /// <summary>
        ///添加系统版本
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
        /// 删除公用方法
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
                //得到他的ID
                string ss = haha.SelectSingleNode("@number").Value;

                if (ss == e.CommandArgument.ToString())
                {
                    root.RemoveChild(haha);
                }
            }
            doc.Save(System.Web.HttpContext.Current.Server.MapPath(lj));
        }
        /// <summary>
        /// 命令激发时
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
                    //得到他的ID
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
        /// 添加子类别
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
