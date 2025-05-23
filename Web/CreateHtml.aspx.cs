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
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.Web
{
    public partial class CreateHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //WebFunc.RefPagesBy("新闻详细页模板");
            //DataSet _data = new Pbzx.BLL.PBnet_News().GetList(1, "1=1", "IntID desc");

            //int newsID = int.Parse(_data.Tables[0].Rows[0]["IntID"].ToString());
            //Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
            //Pbzx.Model.PBnet_News myNews = newsBLL.GetModel(newsID);
            //myNews.BitIsPass = true;
            //new Pbzx.BLL.PBnet_News().Update(myNews);

            //newsBLL.ArticleUpdate(myNews);




            DateTime dtStart = DateTime.Now;
            TimeSpan tsStart = dtStart.TimeOfDay;
            string userIP = Request.UserHostAddress;
            string serverIP = "";   // ConfigurationManager.AppSettings["ServerIP"];
            if (serverIP == "" || serverIP.Contains(userIP))
            {
                Response.Clear();
                Response.Write("<a href='refresh'>refresh</a><br>");
                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                if (!string.IsNullOrEmpty(Request["News"]))
                {
                    if (Request["News"] == "NewsID")   // 不带ID号生成页面
                    {
                        WebFunc.RefPagesBy("新闻详细页模板");
                        DataSet _data = new Pbzx.BLL.PBnet_News().GetList(1, "BitIsPass=0 and IsStatic=0 and DATEDIFF(hour, DatDateAndTime, { fn NOW() }) <= 24", "IntID desc");
                        if (_data.Tables[0].Rows.Count > 0)
                        {
                            int newsID = int.Parse(_data.Tables[0].Rows[0]["IntID"].ToString());
                            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
                            Pbzx.Model.PBnet_News myNews = newsBLL.GetModel(newsID);
                            myNews.BitIsPass = true;
                            new Pbzx.BLL.PBnet_News().Update(myNews);
                            newsBLL.ArticleUpdate(myNews);
                            CreatAspx2Html("新闻资讯");
                            Response.Write("生成成功！<br/>");
                        }
                    }
                    else     // 生成指定ID号的页面
                    {
                        WebFunc.RefPagesBy("新闻详细页模板");
                       
                        int newsID = 0;
                        if (int.TryParse(Request["News"],out newsID))
                        {
                            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
                            Pbzx.Model.PBnet_News myNews = newsBLL.GetModel(newsID);
                            myNews.BitIsPass = true;
                            new Pbzx.BLL.PBnet_News().Update(myNews);
                            newsBLL.ArticleUpdate(myNews);
                            CreatAspx2Html("新闻资讯");
                            Response.Write("生成成功！<br/>");
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Request["School"]))
                {
                    if (Request["School"] == "SchoolID")   // 不带ID号生成页面
                    {
                        WebFunc.RefPagesBy("软件学院详细页模板");
                        DataSet _data = new Pbzx.BLL.PBnet_School().GetList(1, "BitIsPass=0 and IsStatic=0 and DATEDIFF(hour, DatDateAndTime, { fn NOW() }) <= 24", "IntID desc");
                        if (_data.Tables[0].Rows.Count > 0)
                        {
                            int newsID = int.Parse(_data.Tables[0].Rows[0]["IntID"].ToString());
                            Pbzx.BLL.PBnet_School newsBLL = new Pbzx.BLL.PBnet_School();
                            Pbzx.Model.PBnet_School myNews = newsBLL.GetModel(newsID);
                            myNews.BitIsPass = true;
                            newsBLL.ArticleUpdate(myNews);
                            CreatAspx2Html("软件学院");
                            Response.Write("生成成功！<br/>");
                        }
                    }
                    else     // 生成指定ID号的页面
                    {
                        WebFunc.RefPagesBy("软件学院详细页模板");
                        int newsID = 0;
                        if (int.TryParse(Request["School"],out newsID))
                        {
                            Pbzx.BLL.PBnet_School newsBLL = new Pbzx.BLL.PBnet_School();
                            Pbzx.Model.PBnet_School myNews = newsBLL.GetModel(newsID);
                            myNews.BitIsPass = true;
                            newsBLL.ArticleUpdate(myNews);
                            CreatAspx2Html("软件学院");
                            Response.Write("生成成功！<br/>");
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Request["Bulletin"]))
                {
                    if (Request["Bulletin"] == "BulletinID")   // 不带ID号生成页面
                    {
                        WebFunc.RefPagesBy("公告详细页模板");
                        DataSet _data = new Pbzx.BLL.PBnet_Bulletin().GetList(1, "BitIsPass=0 and IsStatic=0 and DATEDIFF(hour, DatDateAndTime, { fn NOW() }) <= 24", "IntID desc");
                        if (_data.Tables[0].Rows.Count > 0)
                        {
                            int newsID = int.Parse(_data.Tables[0].Rows[0]["IntID"].ToString());
                            Pbzx.BLL.PBnet_Bulletin newsBLL = new Pbzx.BLL.PBnet_Bulletin();
                            Pbzx.Model.PBnet_Bulletin myNews = newsBLL.GetModel(newsID);
                            myNews.BitIsPass = true;
                            newsBLL.ArticleUpdate(myNews);
                            CreatAspx2Html("网站公告");
                            Response.Write("生成成功！<br/>");
                        }
                    }
                    else     // 生成指定ID号的页面
                    {
                        WebFunc.RefPagesBy("公告详细页模板");
                        int newsID = 0;
                        if (int.TryParse(Request["Bulletin"], out newsID))
                        {
                            Pbzx.BLL.PBnet_Bulletin newsBLL = new Pbzx.BLL.PBnet_Bulletin();
                            Pbzx.Model.PBnet_Bulletin myNews = newsBLL.GetModel(newsID);
                            myNews.BitIsPass = true;
                            newsBLL.ArticleUpdate(myNews);
                            CreatAspx2Html("网站公告");
                            Response.Write("生成成功！<br/>");
                        }
                    }
                }
//                else if (!string.IsNullOrEmpty(Request["Index"]) && Request["Index"] == "IndexID")
//                {
//                    Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
//                    DataSet _data = new Pbzx.BLL.PBnet_UrlMaping().GetList(1, "MapID=25", "OrderID desc");
//                    int id = int.Parse(_data.Tables[0].Rows[0]["MapID"].ToString());
//                    if (bll.GetModel(id).PageName == "首页")
//                    {
//// 徐春华 2017-04-16 屏蔽
////                        Application.Lock();
////                        Application["FC3DData"] = "false";
////                        Application["TCPL35Data"] = "false";
////                        Application["TC7XCData_New"] = "false";
////                        Application["FC7LC"] = "false";
////                        Application["FCSSData"] = "false";
////                        Application["TCDLTData"] = "false";
////                        Application["TC22X5Data"] = "false";
////                        Application["TC31X7Data"] = "false";
////                        Application.UnLock();
////                        Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=quanguo");

//                        Server.Execute("/PB_Manage/RefurbishGongGao.aspx");
//                        Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
//                    }
//                    bll.CreatHtmlBy(id, false);
//                }
                else if (!string.IsNullOrEmpty(Request["Index"]) && Request["Index"] == "IndexID")
                {
                    string strPageName = Input.FilterAll(Request["PageName"]);
                    CreatAspx2Html(strPageName);
                }
                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                DateTime dtEnd = DateTime.Now;
                TimeSpan tsJG = dtEnd - dtStart;
                Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
            }
        }

        private void CreatAspx2Html(string strPageName)
        {
            if (!string.IsNullOrEmpty(strPageName))
            {
                Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
                DataSet _data = new Pbzx.BLL.PBnet_UrlMaping().GetList(1, "PageName='" + strPageName + "'", "OrderID desc");
                int id = int.Parse(_data.Tables[0].Rows[0]["MapID"].ToString());
                if (id > 0)
                {
                    bll.CreatHtmlBy(id, false);
                }
            }
        }

    }
}