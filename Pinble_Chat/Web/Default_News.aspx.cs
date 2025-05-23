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
                    /////得到上次生成时间
                    MyXML xml = new MyXML("\\xml\\Default_News.xml");
                    XmlNode root = xml.GetXmlRoot();
                    DateTime dtLastTime = DateTime.Parse(root.SelectSingleNode("/root/CreateTime").Attributes["time"].Value);

                    /////得到时间间隔
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

                    /////如果上次生成时间与当前时间间隔小于自定值则重新生成数据
                    //if (dtLastTime.AddMinutes(jg) < DateTime.Now)
                    //{
                    //    Refurbish_News refur = new Refurbish_News();
                    //    lock (refur)
                    //    {
                    //        refur.BindData();
                    //    }
                    //}
                    string path = HttpRuntime.AppDomainAppPath + "\\index_News.htm";
                    if (!File.Exists(path)) //第一次 创建文件
                    {
                        Refurbish_News refur = new Refurbish_News();
                        Monitor.Enter(refur);//现在refur对象只能被当前线程操纵了
                        refur.BindData();
                        Monitor.Exit(refur);//释放锁  
                    }
                    else
                    {
                        if (Application["newsCreating"]!= null && Application["newsCreating"].ToString() == "1") //如果正在生成过程中，直接重定向
                        {
                            Response.Redirect("/index_News.htm");
                            return;
                        }
                        else
                        {
                            ///如果上次生成时间与当前时间间隔小于自定值则重新生成数据
                            if (dtLastTime.AddDays(1) < DateTime.Now)
                            {
                                Application["newsCreating"] = "1";
                                Refurbish_News refur = new Refurbish_News();
                                Monitor.Enter(refur);//现在refur对象只能被当前线程操纵了
                                refur.BindData();
                                Monitor.Exit(refur);//释放锁  
                            }
                            else //否则直接定向到html
                            {
                                Response.Redirect("/index_News.htm");
                            }  
                        }
                    }
           
                }
            }
        }

        ///// <summary>
        ///// 绑定数据
        ///// </summary>
        ///// <param name="xml"></param>
        //private void BindData(MyXML xml)
        //{
        //    XmlNode root = xml.GetXmlRoot();

        //    //上面4条
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

        //    //下面14条
        //    XmlNode children = root.SelectSingleNode("/root/children");
        //    StringBuilder sb14 = new StringBuilder();
        //    sb14.Append(" <ul>");
        //    foreach(XmlNode node in children.ChildNodes)
        //    {
        //        sb14.Append(" <li><span class='dianse'>·</span><a href='" + node.Attributes["href"].Value + "' target='_blank' title='" + node.Attributes["fullName"].Value + "' >" + node.Attributes["name"].Value + "</a></li>");        
        //    }
        //    sb14.Append("</ul>");
        //    div14.InnerHtml = sb14.ToString();

        //}
    }
}
