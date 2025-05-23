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
                        //判断是添加什么类型限定
                        XMLLoad(doc);

                        //得到根节点
                        XmlElement root = doc.DocumentElement;
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {

                            XmlNode haha = root.SelectNodes("reg")[i];
                            //得到他的ID
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
                //当数据为添加时 
                if (Request.QueryString["TJ"] != null && Request.QueryString["number"] == null)
                {
                    //判断是添加什么类型限定
                    switch (Request.QueryString["TJ"])
                    {
                        case "1":
                            btnOk.Text = "添加注册限定";
                            break;
                        case "2":
                            btnOk.Text = "添加用户限定";
                            break;
                        case "3":
                            Label1.Visible = true;
                            txtMsg_Minute.Visible = true;
                            btnOk.Text = "添加消息等级限定";
                            break;
                        case "4":
                            btnOk.Text = "添加消息类别限定";
                            break;
                        case "5":
                            btnOk.Text = "添加系统版本";
                            break;
                    }
                }
                else if (Request.QueryString["number"] != null)
                {
                    XmlDocument doc = new XmlDocument();
                    //判断是添加什么类型限定
                    XMLLoad(doc);

                    //得到根节点
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {

                        XmlNode haha = root.SelectNodes("reg")[i];
                        //得到他的ID
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
        /// 点击提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            //特殊
            if (Request.QueryString["TJ"] == "100")
            {
                //判断是添加还是修改
                if (Request.QueryString["TJ"] != null && Request.QueryString["name"] == null)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();

                        XMLLoad(doc);

                        //得到根节点
                        XmlElement root = doc.DocumentElement;
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {

                            XmlNode haha = root.SelectNodes("reg")[i];
                            //得到他的name
                            string ss = haha.SelectSingleNode("@name").Value;

                            if (ss == Txtname.Text)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该名称已存在！');</script>");
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
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据添加失败！');</script>");
                        return;
                    }
                }
                else
                {
                    //当为修改时
                    if (Request.QueryString["name"] != null)
                    {
                        XmlDocument doc = new XmlDocument();
                        //判断是添加什么类型限定

                        XMLLoad(doc);

                        //得到根节点
                        XmlElement root = doc.DocumentElement;
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {

                            XmlNode haha = root.SelectNodes("reg")[i];
                            //得到他的ID
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
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写ID！');</script>");
                return;
            }
            //int id = 0;
            //if (!int.TryParse(Txtnumber.Text, out id))
            //{
            //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请正确填写ID(必须为整数)！');</script>");
            //    return;
            //}
            if (Txtname.Text == "" || Txtname.Text.Trim().Length <= 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请填写名称');</script>");
                return;
            }

            //判断是添加还是修改
            if (Request.QueryString["TJ"] != null && Request.QueryString["number"] == null)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();

                    XMLLoad(doc);

                    //得到根节点
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {

                        XmlNode haha = root.SelectNodes("reg")[i];
                        //得到他的ID
                        string ss = haha.SelectSingleNode("@number").Value;

                        if (ss == Txtnumber.Text)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该ID号已存在！');</script>");
                            return;
                        }
                        string name = haha.SelectSingleNode("@name").Value;

                        if (name == Txtname.Text)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该名称已存在！');</script>");
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
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据添加失败！');</script>");
                    return;
                }
            }
            else
            {
                //当为修改时
                if (Request.QueryString["number"] != null)
                {
                    XmlDocument doc = new XmlDocument();
                    //判断是添加什么类型限定

                    XMLLoad(doc);

                    //得到根节点
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {

                        XmlNode haha = root.SelectNodes("reg")[i];
                        //得到他的ID
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
        /// xml加载方法
        /// </summary>
        /// <param name="doc"></param>
        private void XMLLoad(XmlDocument doc)
        {
            //判断是添加什么类型限定
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
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortOne.xml"));//装载XML文档 
                    break;
                case "100":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));//装载XML文档 
                    break;
                case "5":
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/OSVersion.xml"));//装载XML文档 
                    break;
            }
        }
        /// <summary>
        /// xml保存方法
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
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortOne.xml"));//装载XML文档 
                    break;
                case "100":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));//装载XML文档 
                    break;
                case "5":
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/OSVersion.xml"));//装载XML文档 
                    break;
            }

            Response.Redirect("SoftMessage_XML_2011.aspx?oneId=" + Droplist.SelectedValue);
            return;
        }

        /// <summary>
        ///点击取消
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
