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
using System.Text;
using System.IO;
using System.Threading;

namespace Pbzx.Web
{
    public partial class Default_News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    /////�õ��ϴ�����ʱ��
                    MyXML xml = new MyXML("\\xml\\Default_News.xml");
                    XmlNode root = xml.GetXmlRoot();
                    DateTime dtLastTime = DateTime.Parse(root.SelectSingleNode("/root/CreateTime").Attributes["time"].Value);

                    /////�õ�ʱ����
                    //TimeSpan tsStart = new TimeSpan();
                    //double jg = 1;
                    //if (!double.TryParse(UIConfig.Bulletin_RefurbishTime, out jg))
                    //{
                    //    jg = 1;
                    //}
                    //else
                    //{
                    //    jg = double.Parse(UIConfig.Bulletin_RefurbishTime);
                    //}

                    /////����ϴ�����ʱ���뵱ǰʱ����С���Զ�ֵ��������������
                    //if (dtLastTime.AddMinutes(jg) < DateTime.Now)
                    //{
                    //    Refurbish_News refur = new Refurbish_News();
                    //    lock (refur)
                    //    {
                    //        refur.BindData();
                    //    }
                    //}
                    string path = HttpRuntime.AppDomainAppPath + "\\index_News.htm";
                    if (!File.Exists(path)) //��һ�� �����ļ�
                    {
                        Refurbish_News refur = new Refurbish_News();
                        Monitor.Enter(refur);//����refur����ֻ�ܱ���ǰ�̲߳�����
                        refur.BindData();
                        Monitor.Exit(refur);//�ͷ���  
                    }
                    else
                    {
                        if (Application["newsCreating"]!= null && Application["newsCreating"].ToString() == "1") //����������ɹ����У�ֱ���ض���
                        {
                            Response.Redirect("/index_News.htm");
                            return;
                        }
                        else
                        {
                            ///����ϴ�����ʱ���뵱ǰʱ����С���Զ�ֵ��������������
                            if (dtLastTime.AddDays(1) < DateTime.Now)
                            {
                                Application["newsCreating"] = "1";
                                Refurbish_News refur = new Refurbish_News();
                                Monitor.Enter(refur);//����refur����ֻ�ܱ���ǰ�̲߳�����
                                refur.BindData();
                                Monitor.Exit(refur);//�ͷ���  
                            }
                            else //����ֱ�Ӷ���html
                            {
                                Response.Redirect("/index_News.htm");
                            }  
                        }
                    }
           
                }
            }
        }

        ///// <summary>
        ///// ������
        ///// </summary>
        ///// <param name="xml"></param>
        //private void BindData(MyXML xml)
        //{
        //    XmlNode root = xml.GetXmlRoot();

        //    //����4��
        //    XmlNode children3 = root.SelectSingleNode("/root/children3");
        //    StringBuilder sb = new StringBuilder();

        //    for (int i = 0; i < children3.ChildNodes.Count; i++ )
        //    {
        //        if (i == 0)
        //        {
        //            XmlNode node1 = children3.ChildNodes[0];
        //            sb.Append("<ul><li><span>");
        //            sb.Append("<a href='" + node1.Attributes["href"].Value + "' target='_blank' title='" + node1.Attributes["fullName"].Value + "' >" + StrFormat.CutStringByNum(node1.Attributes["fullName"].Value, 24, "...") + "</a>");
        //            sb.Append("</span></li></ul>");
        //            sb.Append("<div><table style='width:100%'><tr>");
        //        }
        //        else
        //        {
        //            XmlNode nodeTemp = children3.ChildNodes[i];
        //            sb.Append("<td style='width:33%'><a href='" + nodeTemp.Attributes["href"].Value + "' target='_blank' title='" + nodeTemp.Attributes["fullName"].Value + "' class='school'>" + StrFormat.CutStringByNum(nodeTemp.Attributes["fullName"].Value, 13, "") + "</a></td>");
        //        }                
        //    }
        //    sb.Append("</tr></table></div>");

        //    divTop3.InnerHtml = sb.ToString();                  

        //    //����14��
        //    XmlNode children = root.SelectSingleNode("/root/children");
        //    StringBuilder sb14 = new StringBuilder();
        //    sb14.Append(" <ul>");
        //    foreach(XmlNode node in children.ChildNodes)
        //    {
        //        sb14.Append(" <li><span class='dianse'>��</span><a href='" + node.Attributes["href"].Value + "' target='_blank' title='" + node.Attributes["fullName"].Value + "' >" + node.Attributes["name"].Value + "</a></li>");        
        //    }
        //    sb14.Append("</ul>");
        //    div14.InnerHtml = sb14.ToString();

        //}
    }
}
