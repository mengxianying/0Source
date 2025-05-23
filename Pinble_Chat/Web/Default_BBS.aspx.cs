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
using System.Threading;
using System.IO;

namespace Pbzx.Web
{
    public partial class Default_BBS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    ///得到上次生成时间
                    MyXML xml = new MyXML("\\xml\\Default_BBS.xml");
                    XmlNode root = xml.GetXmlRoot();
                    DateTime dtLastTime = DateTime.Parse(root.SelectSingleNode("/root/CreateTime").Attributes["time"].Value);
                    string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_BBS.htm";
                    
                    //得到刷新时间间隔(修改时间2010-01-19 孟) start
                    string[] barRefSZ1 = WebFunc.GetRefInfo("2", "1");//特殊刷新时间1
                    string[] barRefSZ2 = WebFunc.GetRefInfo("2", "2");//特殊刷新时间2
                    string[] barRefSZ3 = WebFunc.GetRefInfo("2", "3");//特殊刷新时间3    
                    double jg = double.Parse(barRefSZ1[0]); ;
                    //是否处于第一个刷新时间段
                    if (barRefSZ1[6] == "true")
                    {
                        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(barRefSZ1[2]) && DateTime.Now.TimeOfDay <= TimeSpan.Parse(barRefSZ1[3]))
                        {
                            jg = double.Parse(barRefSZ1[4]);
                        }
                    }
                    //是否处于第二个刷新时间段
                    if (barRefSZ2[6] == "true")
                    {
                        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(barRefSZ2[2]) && DateTime.Now.TimeOfDay <= TimeSpan.Parse(barRefSZ2[3]))
                        {
                            jg = double.Parse(barRefSZ2[4]);
                        }
                    }
                    //是否处于第二个刷新时间段
                    if (barRefSZ3[6] == "true")
                    {
                        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(barRefSZ3[2]) && DateTime.Now.TimeOfDay <= TimeSpan.Parse(barRefSZ3[3]))
                        {
                            jg = double.Parse(barRefSZ3[4]);
                        }
                    }
                    //得到刷新时间间隔(修改时间2010-01-19 孟) end


                    if (!File.Exists(htmlPath)) //第一次 创建文件
                    {
                        Refurbish_BBS refur = new Refurbish_BBS();
                        Monitor.Enter(refur);//现在refur对象只能被当前线程操纵了
                        refur.BindData();
                        Monitor.Exit(refur);//释放锁  
                    }
                    else
                    {
                        if (Application["bbsCreating"]!= null && Application["bbsCreating"].ToString() == "1") //如果正在生成过程中，直接重定向
                        {
                            Response.Redirect("/index_BBS.htm");
                            return;
                        }

                        ///如果上次生成时间与当前时间间隔小于自定值则重新生成数据
                        if (dtLastTime.AddMinutes(jg) < DateTime.Now)
                        {
                            Application["bbsCreating"] = "1";
                            Refurbish_BBS refur = new Refurbish_BBS();
                            Monitor.Enter(refur);//现在refur对象只能被当前线程操纵了
                            refur.BindData();
                            Monitor.Exit(refur);//释放锁  
                        }
                        else //否则直接定向到html
                        {
                            Response.Redirect("/index_BBS.htm");
                        }
                      
                    }                  
                }
            }
        }







        //#region 以前得

        ///// <summary>
        ///// 绑定数据
        ///// </summary>
        ///// <param name="xml"></param>
        //private void BindData(MyXML xml)
        //{
        //    XmlNode root = xml.GetXmlRoot();

        //    //公告信息
        //    XmlNode children = root.SelectSingleNode("/root/children");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<table width='100%' cellpadding='0' cellspacing='0'>");
        //    foreach (XmlNode node in children.ChildNodes)
        //    {
        //        sb.Append("<tr><td align='left'>·<a href='http://bbs.pinble.com/dispbbs.asp?boardID=" + node.Attributes["boardID"].Value + "&ID=" + node.Attributes["id"].Value + "&page=1' target='_blank' title='" + node.Attributes["fullName"].Value + "' >" + node.Attributes["name"].Value + "</a></td></tr>");
        //    }
        //    sb.Append("</table>");
        //    dvContent.InnerHtml = sb.ToString();
        //}
        //protected override void Render(HtmlTextWriter writer)
        //{

        //    string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_School.htm";

        //    if (File.Exists(htmlPath))
        //    {
        //        Response.Redirect("/index_School.htm");
        //    }

        //    System.IO.StringWriter html = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter tw = new System.Web.UI.HtmlTextWriter(html);
        //    base.Render(tw);
        //    System.IO.StreamWriter sw;

        //    sw = new System.IO.StreamWriter(htmlPath, false, System.Text.Encoding.Default);

        //    sw.Write(html.ToString());

        //    sw.Close();

        //    tw.Close();

        //    //Response.Write(html.ToString());  //呈现页面

        //    Response.Redirect("/index_School.htm");      //重定向生成的页面
        //}
        //#endregion
    }
}
