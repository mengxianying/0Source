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
    public partial class Default_Ask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    ///�õ��ϴ�����ʱ��
                    MyXML xml = new MyXML("\\xml\\Default_Ask.xml");
                    XmlNode root = xml.GetXmlRoot();
                    DateTime dtLastTime = DateTime.Parse(root.SelectSingleNode("/root/CreateTime").Attributes["time"].Value);
                    string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_Ask.htm";

                    //�õ�ˢ��ʱ����(�޸�ʱ��2010-01-19 ��) start
                    string[] barRefSZ1 = WebFunc.GetRefInfo("1", "1");//����ˢ��ʱ��1
                    string[] barRefSZ2 = WebFunc.GetRefInfo("1", "2");//����ˢ��ʱ��2
                    string[] barRefSZ3 = WebFunc.GetRefInfo("1", "3");//����ˢ��ʱ��3    
                    double jg = double.Parse(barRefSZ1[0]); ;
                    //�Ƿ��ڵ�һ��ˢ��ʱ���
                    if(barRefSZ1[6] =="true")
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
                        Application["askCreating"] = "1";
                        Refurbish_Ask refur = new Refurbish_Ask();
                        Monitor.Enter(refur);//����refur����ֻ�ܱ���ǰ�̲߳�����
                        refur.BindData();
                        Monitor.Exit(refur);//�ͷ���  
                    }
                    else
                    {
                        if (Application["askCreating"] != null &&  Application["askCreating"].ToString() == "1") //����������ɹ����У�ֱ���ض���
                        {
                            Response.Redirect("/index_Ask.htm");
                            return;
                        }
                        else
                        {
                            ///����ϴ�����ʱ���뵱ǰʱ����С���Զ�ֵ��������������
                            if (dtLastTime.AddMinutes(jg)<DateTime.Now)
                            {
                                Application["askCreating"] = "1";
                                Refurbish_Ask refur = new Refurbish_Ask();
                                Monitor.Enter(refur);//����refur����ֻ�ܱ���ǰ�̲߳�����
                                refur.BindData();
                                Monitor.Exit(refur);//�ͷ���  
                            }
                            else //����ֱ�Ӷ���html
                            {
                                Response.Redirect("/index_Ask.htm");
                            }
                        }
                    }                                
                }
            }
        }
    }
}
