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
                    ///�õ��ϴ�����ʱ��
                    MyXML xml = new MyXML("\\xml\\Default_BBS.xml");
                    XmlNode root = xml.GetXmlRoot();
                    DateTime dtLastTime = DateTime.Parse(root.SelectSingleNode("/root/CreateTime").Attributes["time"].Value);
                    string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_BBS.htm";
                    
                    //�õ�ˢ��ʱ����(�޸�ʱ��2010-01-19 ��) start
                    string[] barRefSZ1 = WebFunc.GetRefInfo("2", "1");//����ˢ��ʱ��1
                    string[] barRefSZ2 = WebFunc.GetRefInfo("2", "2");//����ˢ��ʱ��2
                    string[] barRefSZ3 = WebFunc.GetRefInfo("2", "3");//����ˢ��ʱ��3    
                    double jg = double.Parse(barRefSZ1[0]); ;
                    //�Ƿ��ڵ�һ��ˢ��ʱ���
                    if (barRefSZ1[6] == "true")
                    {
                        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(barRefSZ1[2]) && DateTime.Now.TimeOfDay <= TimeSpan.Parse(barRefSZ1[3]))
                        {
                            jg = double.Parse(barRefSZ1[4]);
                        }
                    }
                    //�Ƿ��ڵڶ���ˢ��ʱ���
                    if (barRefSZ2[6] == "true")
                    {
                        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(barRefSZ2[2]) && DateTime.Now.TimeOfDay <= TimeSpan.Parse(barRefSZ2[3]))
                        {
                            jg = double.Parse(barRefSZ2[4]);
                        }
                    }
                    //�Ƿ��ڵڶ���ˢ��ʱ���
                    if (barRefSZ3[6] == "true")
                    {
                        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse(barRefSZ3[2]) && DateTime.Now.TimeOfDay <= TimeSpan.Parse(barRefSZ3[3]))
                        {
                            jg = double.Parse(barRefSZ3[4]);
                        }
                    }
                    //�õ�ˢ��ʱ����(�޸�ʱ��2010-01-19 ��) end


                    if (!File.Exists(htmlPath)) //��һ�� �����ļ�
                    {
                        Refurbish_BBS refur = new Refurbish_BBS();
                        Monitor.Enter(refur);//����refur����ֻ�ܱ���ǰ�̲߳�����
                        refur.BindData();
                        Monitor.Exit(refur);//�ͷ���  
                    }
                    else
                    {
                        if (Application["bbsCreating"]!= null && Application["bbsCreating"].ToString() == "1") //����������ɹ����У�ֱ���ض���
                        {
                            Response.Redirect("/index_BBS.htm");
                            return;
                        }

                        ///����ϴ�����ʱ���뵱ǰʱ����С���Զ�ֵ��������������
                        if (dtLastTime.AddMinutes(jg) < DateTime.Now)
                        {
                            Application["bbsCreating"] = "1";
                            Refurbish_BBS refur = new Refurbish_BBS();
                            Monitor.Enter(refur);//����refur����ֻ�ܱ���ǰ�̲߳�����
                            refur.BindData();
                            Monitor.Exit(refur);//�ͷ���  
                        }
                        else //����ֱ�Ӷ���html
                        {
                            Response.Redirect("/index_BBS.htm");
                        }
                      
                    }                  
                }
            }
        }







        //#region ��ǰ��

        ///// <summary>
        ///// ������
        ///// </summary>
        ///// <param name="xml"></param>
        //private void BindData(MyXML xml)
        //{
        //    XmlNode root = xml.GetXmlRoot();

        //    //������Ϣ
        //    XmlNode children = root.SelectSingleNode("/root/children");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<table width='100%' cellpadding='0' cellspacing='0'>");
        //    foreach (XmlNode node in children.ChildNodes)
        //    {
        //        sb.Append("<tr><td align='left'>��<a href='http://bbs.pinble.com/dispbbs.asp?boardID=" + node.Attributes["boardID"].Value + "&ID=" + node.Attributes["id"].Value + "&page=1' target='_blank' title='" + node.Attributes["fullName"].Value + "' >" + node.Attributes["name"].Value + "</a></td></tr>");
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

        //    //Response.Write(html.ToString());  //����ҳ��

        //    Response.Redirect("/index_School.htm");      //�ض������ɵ�ҳ��
        //}
        //#endregion
    }
}
