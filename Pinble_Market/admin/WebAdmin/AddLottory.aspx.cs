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

namespace Pinble_Market.admin.WebAdmin
{
    public partial class AddLottory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["lottoryname"] != null)
                {
                    Label1.Text = Request.QueryString["lottoryname"];
                    if (Request.QueryString["number"] != null)
                    {
                        txtnumber.Text = Request.QueryString["number"];
                        txtname.Text = Request.QueryString["itemname"];
                        txtnumber.Enabled = false;
                        btnok.Text = "�� ��";
                    }
                    else
                    {
                        btnok.Text = "�� ��";
                    }
                }
            }
        }
        /// <summary>
        /// ����޸Ļ����ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnok_Click(object sender, EventArgs e)
        {
            if (txtnumber.Text == "" || txtname.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�뽫��Ϣ��д������');</script>");
                return;
            }
            int ot = 0;
            if (!int.TryParse(txtnumber.Text, out ot))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('���ֻ����Ϊ������');</script>");
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));
            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                XmlNode haha = root.SelectNodes("CP" + Request.QueryString["lottoryname"])[0];
                //Ϊ�޸�
                if (Request.QueryString["number"] != null)
                {

                    for (int i = 0; i < haha.ChildNodes.Count; i++)
                    {
                        XmlNode haha1 = haha.SelectNodes("chi")[i];
                        string number = haha1.SelectSingleNode("@number").Value;
                        if (number == Request.QueryString["number"])
                        {
                            haha1.SelectSingleNode("@name").Value = txtname.Text;
                        }
                    }

                }
                else
                {
                    if (ExistsCP(haha))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�Ѿ��������Ӧ��ID�ˣ������ID');</script>");
                        return;
                    }

                    XmlElement ele = doc.CreateElement("chi");
                    ele.SetAttribute("name", txtname.Text);
                    ele.SetAttribute("number", txtnumber.Text);
                    haha.AppendChild(ele);
                    root.AppendChild(haha);
                }
            }
            doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));
            Response.Redirect("PageCount.aspx");
        }

        private bool ExistsCP(XmlNode haha)
        {
            for (int i = 0; i < haha.ChildNodes.Count; i++)
            {
                XmlNode haha1 = haha.SelectNodes("chi")[i];
                string number = haha1.SelectSingleNode("@number").Value;
                if (number == txtnumber.Text)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ���ز鿴�б�ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutresult_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageCount.aspx");
        }
    }
}
