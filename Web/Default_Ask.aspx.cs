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
                    ///得到上次生成时间
                    MyXML xml = new MyXML("\\xml\\Default_Ask.xml");
                    XmlNode root = xml.GetXmlRoot();
                    DateTime dtLastTime = DateTime.Parse(root.SelectSingleNode("/root/CreateTime").Attributes["time"].Value);
                    string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_Ask.htm";

                    //得到刷新时间间隔(修改时间2010-01-19 孟) start
                    string[] barRefSZ1 = WebFunc.GetRefInfo("1", "1");//特殊刷新时间1
                    string[] barRefSZ2 = WebFunc.GetRefInfo("1", "2");//特殊刷新时间2
                    string[] barRefSZ3 = WebFunc.GetRefInfo("1", "3");//特殊刷新时间3    
                    double jg = double.Parse(barRefSZ1[0]); ;
                    //是否处于第一个刷新时间段
                    if(barRefSZ1[6] =="true")
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
                        Application["askCreating"] = "1";
                        Refurbish_Ask refur = new Refurbish_Ask();
                        Monitor.Enter(refur);//现在refur对象只能被当前线程操纵了
                        refur.BindData();
                        Monitor.Exit(refur);//释放锁  
                    }
                    else
                    {
                        if (Application["askCreating"] != null &&  Application["askCreating"].ToString() == "1") //如果正在生成过程中，直接重定向
                        {
                            Response.Redirect("/index_Ask.htm");
                            return;
                        }
                        else
                        {
                            ///如果上次生成时间与当前时间间隔小于自定值则重新生成数据
                            if (dtLastTime.AddMinutes(jg)<DateTime.Now)
                            {
                                Application["askCreating"] = "1";
                                Refurbish_Ask refur = new Refurbish_Ask();
                                Monitor.Enter(refur);//现在refur对象只能被当前线程操纵了
                                refur.BindData();
                                Monitor.Exit(refur);//释放锁  
                            }
                            else //否则直接定向到html
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
