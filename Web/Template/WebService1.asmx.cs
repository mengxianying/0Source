using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using Maticsoft.DBUtility;
using System.IO;
using Pbzx.Common;
using Pbzx.Web.PB_Manage;
using Pbzx.SQLServerDAL;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace Pbzx.Web.Template
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 验证用户的提示问题是否为空
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string CueQuesion(string u)
        {
            string UserName = Server.UrlDecode(Input.FilterAll(u));
            string record = "false";
            DataSet ds_cue = DbHelperSQLBBS.Query("select UserQuesion,UserAnswer,UserPassword from Dv_user where UserName=" + "'" + UserName + "'");
            if (ds_cue != null && ds_cue.Tables[0].Rows.Count > 0)
            {
                if (ds_cue.Tables[0].Rows[0]["UserQuesion"].ToString() == "" || ds_cue.Tables[0].Rows[0]["UserAnswer"].ToString() == "")
                {
                    record = "true";
                    Method.record_user_log(UserName, "", "密码问题为空", "密码相关");
                }
            }

            return record;
        }
        /// <summary>
        /// 获取彩种对应的数据库的表名称
        /// </summary>
        /// <param name="lotteryName">彩种名称</param>
        /// <returns></returns>
        [WebMethod]
        public string lotteryNameData(string lotteryName)
        {
            Pbzx.BLL.PBnet_LotteryMenu get_lm = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = get_lm.GetList("NvarName=" + "'" + lotteryName + "'");
            return ds.Tables[0].Rows[0]["NvarApp_name"].ToString();
        }

        [WebMethod]
        public string strEncod(string u)
        {
            if (u == "pl")
            {
                string t1 = Input.Encrypt(DateTime.Now.ToString());
                return t1;
            }
            return "";
        }

        #region  主页开奖信息

        /// <summary>
        /// 计算时间差
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                //dateDiff = ts.Days.ToString() + "天"
                //                + ts.Hours.ToString() + "小时"
                //                + ts.Minutes.ToString() + "分钟"
                //                + ts.Seconds.ToString() + "秒";
                dateDiff = ts.Minutes.ToString();
            }
            catch
            {

            }
            return dateDiff;

        }  
        /// <summary>
        /// 主页开奖信息
        /// </summary>
        /// <returns></returns>
        
        //[System.Web.Services.Protocols.SoapHeader("myHeader")]//用户身份验证的soap头 
        [WebMethod]
        public string PresentInformation()
        {
            UpdateApplication("FC3DData");
            Hashtable hat3D = (Hashtable)Application["FC3DDataValue"];
            StringBuilder sb = new StringBuilder();
            string FirstPageTcodeDisp;

            FirstPageTcodeDisp = Pbzx.Common.WebInit.webBaseConfig.FirstPageTcodeDisp;

            string AttentionCode = hat3D["AttentionCode"].ToString();
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\" class=\"MT3\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"> <img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\">");
            sb.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=FC3D' target=\"_blank\" class=\"bluelink\">" + hat3D["issue"].ToString() + "期福彩3D</a>&nbsp;");
            sb.Append("</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hat3D["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            string code = hat3D["code"].ToString();
            string strfc3D = Formart5(hat3D["testcode"].ToString(), "zhong3");
            if (FirstPageTcodeDisp == "0" && string.IsNullOrEmpty(code))
            {
                strfc3D = "停发";
            }
            sb.Append("<table width=\"100%\" border=\"0\"><tr><td>");
            sb.Append("&nbsp;&nbsp;&nbsp;模拟试机号：[" + strfc3D + "]<br />");

            string sdCountent = hat3D["issue"].ToString() + "期福彩3D " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hat3D["date"].ToString())) + " 模拟试机号：[" + hat3D["testcode"].ToString() + "]";

            if (string.IsNullOrEmpty(code))
            {
                string strfcDY = Formart5(hat3D["decode"].ToString(), "zhong2");
                if (FirstPageTcodeDisp == "0" && string.IsNullOrEmpty(code))
                {
                    strfcDY = "暂无";
                }

                sb.Append("&nbsp;&nbsp;&nbsp;试机号对应码：[" + strfcDY + "]<br />");

                sdCountent += " 试机号对应码：[" + hat3D["decode"].ToString() + "]";
            }
// 徐增加 2024-09-11
            // 获取当前的UTC时间
            DateTime currentTime = DateTime.UtcNow;
            // 转换为Unix时间戳
            TimeSpan elapsedTime = currentTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 返回秒数
            long timestamp = (long)elapsedTime.TotalSeconds;
            String StrTimestamp = timestamp.ToString();

///////////////////////////////

            if (string.IsNullOrEmpty(code))
            {
                //sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;&nbsp;<a href=\"/pb_cst.htm\" target=\"_blank\" title='查看历史记录'>彩神通关注码</a>：");
                //sb.Append(Formart(AttentionCode.Substring(1, 1), "zhong3", true) + "<span class='zhong3'>,</span>" + Formart(AttentionCode.Substring(2, 1), "zhong3", true) + "&nbsp;金码：" + Formart(AttentionCode.Substring(0, 1), "zhong1") + "<br />");

//                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cst.htm\" target=\"_blank\" title='查看历史记录'>彩神通关注码</a>：");

                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cst.htm?t=" + StrTimestamp + "\" target=\"_blank\" title='查看彩神通关注码历史记录'>彩神通关注码</a>：");
                sb.Append(Formart(AttentionCode.Substring(1, 1), "zhong3", true) + "<span class='zhong3'>,</span>" + Formart(AttentionCode.Substring(2, 1), "zhong3", true) + "&nbsp;金码：" + Formart(AttentionCode.Substring(0, 1), "zhong1") + "<br />");
            }
            else
            {
//                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cst.htm\" target=\"_blank\" title='查看历史记录'>彩神通关注码</a>：");

                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cst.htm?t=" + StrTimestamp + "\" target=\"_blank\" title='查看彩神通关注码历史记录'>彩神通关注码</a>：");
                sb.Append(Formart(AttentionCode.Substring(1, 1), "zhong3", true) + "<span class='zhong3'>,</span>" + Formart(AttentionCode.Substring(2, 1), "zhong3", true) + "&nbsp;金码：" + Formart(AttentionCode.Substring(0, 1), "zhong1") + "<br />");
            }
            sdCountent += " 彩神通关注码：" + AttentionCode.Substring(1, 1) + "," + AttentionCode.Substring(2, 1) + " 金码：" + AttentionCode.Substring(0, 1);

            //if (!string.IsNullOrEmpty(code))
            //{
            //    sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hat3D["code"].ToString(), "zhong1") + "]");

            //    sdCountent += " 开奖号：[" + hat3D["code"].ToString() + "]";
            //}
            ////string sdCountent = hat3D["issue"].ToString() + "期福彩3D     " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hat3D["date"].ToString())) + "\r\n" + "试机号：[" + hat3D["testcode"].ToString() + "]";

            //sb.Append("</td><td align=\"right\" > <a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + sdCountent + "','','utf-8'));\">");
            //sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;' title='分享到新浪微博' /></a>&nbsp;</td></tr></table>");
            if (!string.IsNullOrEmpty(code))
            {
                sb.Append("&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hat3D["code"].ToString(), "zhong1") + "]");

                sdCountent += " 开奖号：[" + hat3D["code"].ToString() + "]";
            }
            sb.Append("</td><td align='right' valign='bottom'>");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + sdCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;' title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

// 排列三五旧版本屏蔽开始， 2022-03-20
//            //排列3
//            UpdateApplication("TCPL35Data");
//            Hashtable hatPl5 = (Hashtable)Application["TCPL35DataValue"];
//            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
//            sb.Append("<tr>");
//            sb.Append("<td width=\"7%\" class=\"D_Award2\"> <img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
////            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCPL35Data") + "&lx=pls&class=全国体彩&name=排列三' target=\"_blank\" class=\"bluelink\">" + hatPl5["issue"].ToString() + "期体彩排列三</a>&nbsp;</td>");
//            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCPL35Data") + "&lx=pls' target=\"_blank\" class=\"bluelink\">" + hatPl5["issue"].ToString() + "期体彩排列三</a>&nbsp;</td>");
//            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString())) + "</span>&nbsp;</td>");
//            sb.Append("</tr>");
//            sb.Append("</table>");
//            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" ><tr><td>&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hatPl5["code5"].ToString().Substring(0, 3), "zhong1") + "]");
//            //排列3
//            string plsCountent = hatPl5["issue"].ToString() + " 期体彩排列三 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString())) + " 开奖号：[" + hatPl5["code5"].ToString().Substring(0, 3) + "]";
//            sb.Append("</td><td align=\"right\" ><a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + plsCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;margin-right:2px;'  title='分享到新浪微博' /></a>&nbsp; </td></tr></table>");

//            //排列5
//            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
//            sb.Append("<tr>");
//            sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
////            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCPL35Data") + "&class=全国体彩&name=排列五' target=\"_blank\" class=\"bluelink\">" + hatPl5["issue"].ToString() + "期体彩排列五</a>&nbsp;</td>");
//            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCPL35Data") + "' target=\"_blank\" class=\"bluelink\">" + hatPl5["issue"].ToString() + "期体彩排列五</a>&nbsp;</td>");
//            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString())) + "</span>&nbsp;</td>");
//            sb.Append("</tr>");
//            sb.Append("</table>");
//            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hatPl5["code5"].ToString(), "zhong1") + "]");
//            //排列5
//            string plwCountent = hatPl5["issue"].ToString() + " 期体彩排列五 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString())) + " 开奖号：[" + hatPl5["code5"].ToString() + "]";
//            sb.Append("</td><td align=\"right\" > <a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + plwCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;</td></tr></table>");
// 排列三五旧版本屏蔽结束， 2022-03-20

// 排列三五新版本开始， 2022-03-20
            //排列3
            UpdateApplication("WeiXin_MoNiTestCode");
            Hashtable hatPl3 = (Hashtable)Application["WeiXin_MoNiTestCodeValue"];
            string AttentionCodeP3 = hatPl3["AttentionCode"].ToString();
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\" class=\"MT3\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"> <img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\">");
            sb.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCPL35Data") + "&lx=pls&class=全国体彩&name=排列三' target=\"_blank\" class=\"bluelink\">" + hatPl3["issue"].ToString() + "期体彩排列三</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl3["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            string strtcpl3 = Formart5(hatPl3["testcode"].ToString(), "zhong3");
            string code3 = hatPl3["code"].ToString();
            if (FirstPageTcodeDisp == "0" && string.IsNullOrEmpty(code3))
            {
                strtcpl3 = "停发";
            }
            sb.Append("<table width=\"100%\" border=\"0\"><tr><td>");
            sb.Append("&nbsp;&nbsp;&nbsp;模拟试机号：[" + strtcpl3 + "]<br />");

            string plsCountent = hatPl3["issue"].ToString() + "期体彩排列三 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl3["date"].ToString())) + " 模拟试机号：[" + hatPl3["testcode"].ToString() + "]";

            if (string.IsNullOrEmpty(code3))
            {
                string strfcDY = Formart5(hatPl3["decode"].ToString(), "zhong2");
                if (FirstPageTcodeDisp == "0" && string.IsNullOrEmpty(code))
                {
                    strfcDY = "暂无";
                }

                sb.Append("&nbsp;&nbsp;&nbsp;试机号对应码：[" + strfcDY + "]<br />");

                plsCountent += " 试机号对应码：[" + hatPl3["decode"].ToString() + "]";
            }
            if (string.IsNullOrEmpty(code3))
            {
//                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cstp3.htm\" target=\"_blank\" title='查看历史记录'>彩神通关注码</a>：");
                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cstp3.htm?t=" + StrTimestamp + "\" target=\"_blank\" title='查看彩神通关注码历史记录'>彩神通关注码</a>：");
                sb.Append(Formart(AttentionCodeP3.Substring(1, 1), "zhong3", true) + "<span class='zhong3'>,</span>" + Formart(AttentionCodeP3.Substring(2, 1), "zhong3", true) + "&nbsp;金码：" + Formart(AttentionCodeP3.Substring(0, 1), "zhong1") + "<br />");
            }
            else
            {
                sb.Append("&nbsp;&nbsp;&nbsp;<a href=\"/pb_cstp3.htm?t=" + StrTimestamp + "\" target=\"_blank\" title='查看彩神通关注码历史记录'>彩神通关注码</a>：");
                sb.Append(Formart(AttentionCodeP3.Substring(1, 1), "zhong3", true) + "<span class='zhong3'>,</span>" + Formart(AttentionCodeP3.Substring(2, 1), "zhong3", true) + "&nbsp;金码：" + Formart(AttentionCodeP3.Substring(0, 1), "zhong1") + "<br />");
            }
            plsCountent += " 彩神通关注码：" + AttentionCodeP3.Substring(1, 1) + "," + AttentionCodeP3.Substring(2, 1) + " 金码：" + AttentionCodeP3.Substring(0, 1);

            if (!string.IsNullOrEmpty(code3))
            {
                sb.Append("&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hatPl3["code"].ToString(), "zhong1") + "]");

                plsCountent += " 开奖号：[" + hatPl3["code"].ToString() + "]";
            }
            sb.Append("</td><td align='right' valign='bottom'>");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + plsCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;' title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

            //排列5
            UpdateApplication("TCPL35Data");
            Hashtable hatPl5 = (Hashtable)Application["TCPL35DataValue"];
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCPL35Data") + "' target=\"_blank\" class=\"bluelink\">" + hatPl5["issue"].ToString() + "期体彩排列五</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hatPl5["code5"].ToString(), "zhong1") + "]");
            //排列5
            string plwCountent = hatPl5["issue"].ToString() + " 期体彩排列五 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString())) + " 开奖号：[" + hatPl5["code5"].ToString() + "]";
            sb.Append("</td><td align=\"right\">");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + plwCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");
            // 排列三五新版本结束， 2022-03-20


            //七星彩
            UpdateApplication("TC7XCData_New");
            Hashtable hatTc7XC = (Hashtable)Application["TC7XCData_NewValue"];
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
//            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TC7XCData_New") + "&class=全国体彩&name=七星彩' target=\"_blank\" class=\"bluelink\">" + hatTc7XC["issue"].ToString() + "期体彩七星彩</a>&nbsp;</td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TC7XCData_New") + "' target=\"_blank\" class=\"bluelink\">" + hatTc7XC["issue"].ToString() + "期体彩七星彩</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc7XC["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hatTc7XC["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatTc7XC["tcode"].ToString() + "</span>" + "]");
            //七星彩
            string qxcCountent = hatTc7XC["issue"].ToString() + " 期体彩七星彩 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc7XC["date"].ToString())) + " 开奖号：[" + hatTc7XC["code"].ToString() + "+" + hatTc7XC["tcode"].ToString() + "]";
            sb.Append("</td><td align=\"right\" >");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + qxcCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

            //七乐彩
            UpdateApplication("FC7LC");
            Hashtable hatFc7lc = (Hashtable)Application["FC7LCValue"];
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
//            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("FC7LC") + "&class=全国福彩&name=七乐彩' target=\"_blank\" class=\"bluelink\">" + hatFc7lc["issue"].ToString() + "期福彩七乐彩</a>&nbsp;</td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("FC7LC") + "' target=\"_blank\" class=\"bluelink\">" + hatFc7lc["issue"].ToString() + "期福彩七乐彩</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFc7lc["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td >&nbsp;&nbsp;[" + Formart2(hatFc7lc["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatFc7lc["tcode"].ToString() + "</span>" + "]");
            //七乐彩
            string qlcCountent = hatFc7lc["issue"].ToString() + " 期福彩七乐彩 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFc7lc["date"].ToString())) + " 开奖号：[" + FormartNews(hatFc7lc["code"].ToString()) + "+" + FormartNews(hatFc7lc["tcode"].ToString()) + "]";
            sb.Append("</td><td align=\"right\" >");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + qlcCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

            //双色球
            UpdateApplication("FCSSData");
            Hashtable hatSsq = (Hashtable)Application["FCSSDataValue"];
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
//            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("FCSSData") + "&class=全国福彩&name=双色球' target=\"_blank\" class=\"bluelink\">" + hatSsq["issue"].ToString() + "期福彩双色球</a>&nbsp;</td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("FCSSData") + "' target=\"_blank\" class=\"bluelink\">" + hatSsq["issue"].ToString() + "期福彩双色球</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatSsq["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;[" + Formart2(hatSsq["redcode"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatSsq["bluecode"].ToString() + "</span>" + "]");
            //双色球
            string ssqCountent = hatSsq["issue"].ToString() + " 期福彩双色球 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatSsq["date"].ToString())) + " 开奖号：[" + FormartNews(hatSsq["redcode"].ToString()) + "+" + FormartNews(hatSsq["bluecode"].ToString()) + "]";
            sb.Append("</td><td align=\"right\" >");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + ssqCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

            //大乐透
            UpdateApplication("TCDLTData");
            Hashtable hatDlt = (Hashtable)Application["TCDLTDataValue"];
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" valign=\"top\" class=\"D_Award1\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
//            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCDLTData") + "&class=全国体彩&name=大乐透' target=\"_blank\" class=\"bluelink\">" + hatDlt["issue"].ToString() + "期体彩大乐透</a>&nbsp;</td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TCDLTData") + "' target=\"_blank\" class=\"bluelink\">" + hatDlt["issue"].ToString() + "期体彩大乐透</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatDlt["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;[" + Formart2(hatDlt["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;" + Formart2(hatDlt["code2"].ToString(), "zhong2") + "]");
            //大乐透
            string dltCountent = hatDlt["issue"].ToString() + " 期体彩大乐透 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatDlt["date"].ToString())) + " 开奖号：[" + FormartNews(hatDlt["code"].ToString()) + "+" + FormartNews(hatDlt["code2"].ToString()) + "]";
            sb.Append("</td><td align=\"right\" >");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + dltCountent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

            //快乐8
            UpdateApplication("FCKL8Data");
            Hashtable hatFCKL8 = (Hashtable)Application["FCKL8DataValue"];
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
            sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("FCKL8Data") + "' target=\"_blank\" class=\"bluelink\">" + hatFCKL8["issue"].ToString() + "期福彩快乐8</a>&nbsp;</td>");
            sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFCKL8["date"].ToString())) + "</span>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;[" + FormartKL8(hatFCKL8["code"].ToString(), "zhong1") + "]");
            //快乐8
            string kl8Countent = hatFCKL8["issue"].ToString() + " 期福彩快乐8 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFCKL8["date"].ToString())) + " 开奖号：[" + FormartNews(hatFCKL8["code"].ToString()) + "]";
            sb.Append("</td><td align=\"right\" >");
//            sb.Append("<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + kl8Countent + "','','utf-8'));\">");
//            sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;");
            sb.Append("</td></tr></table>");

            ////22选5
            //UpdateApplication("TC22X5Data");
            //Hashtable hatTc22X5 = (Hashtable)Application["TC22X5DataValue"];
            //sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
            //sb.Append("<tr>");
            //sb.Append("<td width=\"7%\" class=\"D_Award2\"><img src=\"../Images/Web/D_Awardli.gif\" width=\"4\" height=\"11\" class=\"img_boder\" /></td>");
            //sb.Append("<td width=\"60%\" align=\"left\" valign=\"bottom\" class=\"D_Award1\"><a href='" + WebInit.webBaseConfig.WebUrl + "Lottery.htm?myUrl=" + GetPar("TC22X5Data") + "' target=\"_blank\" class=\"bluelink\">" + hatTc22X5["issue"].ToString() + "期体彩22选5</a>&nbsp;</td>");
            //sb.Append("<td width=\"33%\" class=\"D_Award2\" align=\"right\"><span class=\"kaiTime\">" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc22X5["date"].ToString())) + "</span>&nbsp;</td>");
            //sb.Append("</tr>");
            //sb.Append("</table>");
            //sb.Append("<table width=\"100%\" border=\"0\" ><tr><td>&nbsp;&nbsp;[" + Formart2(hatTc22X5["code"].ToString(), "zhong1") + "]");
            ////22选5
            //string eexwCountent = hatTc22X5["issue"].ToString() + " 期体彩22选5 " + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc22X5["date"].ToString())) + " 开奖号：[" + FormartNews(hatTc22X5["code"].ToString()) + "]";
            //sb.Append("</td><td align=\"right\" ><a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){ var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','" + eexwCountent + "','','utf-8'));\">");
            //sb.Append("<img src='/Images/Web/sina.png' border='0' style='vertical-align:middle;'  title='分享到新浪微博' /></a>&nbsp;</td></tr></table>");


            //return HttpContext.Current.Server.HtmlEncode(sb.ToString());
            return sb.ToString();

        }

        private void UpdateApplication(string cpName)
        {
            string tempValue = cpName + "Value";
          
            if (Application[tempValue] == null || Application[cpName] == null || !(Application[cpName] != null && Application[cpName].ToString() == "true"))
            {
                string strissue = " issue ";
                string strWhere="";
                if (cpName == "WeiXin_MoNiTestCode")
                {
                    strissue = " issue3 ";
                    strWhere = " where status=1 ";
                }
                DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from  " + cpName + " WITH (NOLOCK) " + strWhere + " order by "+ strissue + " desc ");
                DataRow row = dsAppData.Tables[0].Rows[0];
                Hashtable hatData = new Hashtable();
                hatData.Add("date", row["date"]);
                if (cpName == "WeiXin_MoNiTestCode")
                {
                    hatData.Add("issue", row["issue3"]);
                }
                else
                {
                    hatData.Add("issue", row["issue"]);
                }
                switch (cpName)
                {
                    case "FC3DData":
                        hatData.Add("testcode", row["testcode"]);
                        hatData.Add("code", row["code"]);
                        hatData.Add("machine", row["machine"]);
                        hatData.Add("ball", row["ball"]);
                        hatData.Add("decode", row["decode"]);
                        hatData.Add("AttentionCode", row["AttentionCode"]);
                        break;
// 排列三
                    case "WeiXin_MoNiTestCode":
                        hatData.Add("testcode", row["testcode3"]);
                        hatData.Add("code", row["code3"]);
                        hatData.Add("decode", row["decode3"]);
                        hatData.Add("AttentionCode", row["AttentionCode3"]);
                        break;
// 排列五
                    case "TCPL35Data":
                        hatData.Add("code5", row["code5"]);
                        break;
                    case "TC7XCData_New":
//                Pbzx.Common.ErrorLog.WriteLogMeng("SQL", " select top 1 * from  " + cpName + " order by issue desc ", true, true);
//                Pbzx.Common.ErrorLog.WriteLogMeng("Code", row["code"].ToString(), true, true);
//                Pbzx.Common.ErrorLog.WriteLogMeng("TCode", row["tcode"].ToString(), true, true);
                        hatData.Add("code", row["code"]);
                        hatData.Add("tcode", row["tcode"]);
                        break;
                    case "FC7LC":
                        hatData.Add("code", row["code"]);
                        hatData.Add("tcode", row["tcode"]);
                        break;
                    case "FCSSData":
                        hatData.Add("redcode", row["redcode"]);
                        hatData.Add("bluecode", row["bluecode"]);
                        break;
                    case "TCDLTData":
                        hatData.Add("code", row["code"]);
                        hatData.Add("code2", row["code2"]);
                        break;
                    case "FCKL8Data":
                        hatData.Add("code", row["code"]);
                        break;
                    //case "TC22X5Data":
                    //    hatData.Add("code", row["code"]);
                    //    break;
                    //case "TC31X7Data":
                    //    hatData.Add("code", row["code"]);
                    //    hatData.Add("tcode", row["tcode"]);
                    //    break;
                }

                Application.Lock();
//                Pbzx.Common.ErrorLog.WriteLogMeng("Application更新", "Application['" + cpName + "']发生改变", true, true);
                Application[tempValue] = hatData;
                Application[cpName] = "true";
                Application.UnLock();
            }
        }

        protected string GetPar(string type)
        {
            return Input.Encrypt(type);
        }

        private string Formart5(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>"); // .Substring(i, 1);
                }
            }
            return sbResult.ToString();
        }

        private string Formart(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "&nbsp;</span>"); // .Substring(i, 1);
                }
            }
            return sbResult.ToString();
        }

        private string Formart(string code, string type, bool isTest)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length - 1)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "&nbsp;</span>"); // .Substring(i, 1);
                }
            }
            return sbResult.ToString();
        }

        private string Formart2(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i += 2)
            {
                if (i < code.Length - 2)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "&nbsp;</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "</span>");
                }
            }
            return sbResult.ToString();
        }


        private string FormartKL8(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i += 2)
            {
                if (i == 18)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "</span><br>");
                }
                else if (i == 20)
                {
                    sbResult.Append("<span class='" + type + "'>" + "&nbsp;&nbsp;" + code.Substring(i, 2) + "&nbsp;</span>");
                }
                else if (i < code.Length - 2)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "&nbsp;</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "</span>");
                }
            }
            return sbResult.ToString();
        }

        private string FormartNews(string code)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i += 2)
            {
                if (i < code.Length - 2)
                {
                    sbResult.Append(code.Substring(i, 2) + " ");
                }
                else
                {
                    sbResult.Append(code.Substring(i, 2) + " ");
                }
            }
            return sbResult.ToString();
        }


        #endregion


        private string GetLott_date(string lot)
        {
            return (string)DbHelperSQL.GetSingle("select NvarLott_date from PBnet_LotteryMenu where NvarApp_name='" + lot + "' ");
        }

        /// <summary>
        /// 3D开奖详细列表
        /// </summary>
        /// <param name="pageindex">当前页数</param>
        /// <param name="lottory">彩种名称</param>
        /// <param name="pl3">排列3</param>
        /// <returns></returns>

        [WebMethod]
        public string Present3DList(string pageindex, string lottory, string pl3, string name, string isgp)
        {
            #region 开奖信息
            StringBuilder but = new StringBuilder();

            //得到彩种的类型
            object lotteryTypeInfo = "";
            if (lottory != "")
            {
                lotteryTypeInfo = DbHelperSQL.GetSingle("select LottTypeInfo from PBnet_LotteryMenu where NvarApp_name=" + "'" + lottory + "'" + " and BItIs_show=1");
            }

            string riQi = "";
            object objTime = DbHelperSQL.GetSingle("select TimeList from PBnet_LotteryMenu where NvarApp_name=" + "'" + lottory + "'" + " and BItIs_show=1");
            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
            {
                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                TimeSpan tsStart = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[0], out tsStart))
                {
                }

                TimeSpan tsEnd = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[1], out tsEnd))
                {
                }
                int jg = 0;
                tsEnd.Subtract(tsStart);
                while (tsStart < tsEnd)
                {
                    tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                    jg++;
                }
                riQi = "每" + jg.ToString() + "分钟";
            }
            else
            {
                riQi = Method.GetLottDate1(GetLott_date(lottory));
            }



            if (pl3 == "pl3")
            {
                name = "排列三";
            }

            but.Append("  <div class='kai_lwone'>");
            but.Append(" <table width='100%' border='0' cellspacing='0' cellpadding='2' class='kai_rbg3'>");
            but.Append(" <tr><td width='60%' class='kai_rbg_zi'>" + name + " 开奖信息</td><td width='40%' align='right'>开奖周期：<font color='#A20010'>" + riQi + "&nbsp;&nbsp;</font></td></tr></table>");

            but.Append("<table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' bgcolor='#B6CBE8' class='MT6'>");
            but.Append("<tr>");
            but.Append("<td>");
            but.Append(" <div>");
            but.Append(" <table cellspacing='0' cellpadding='0' rules='all' bordercolor='#B6CBE8' border='1' id='MyGridView' style='width: 100%; border-collapse: collapse;'>");
            but.Append(" <tr> <th scope='col'>");
            but.Append(" <div style='height: 26px; background-color: #E9F3FE' class='L_zi1'>开奖时间</div></th>");
            but.Append("<th scope='col'>");
            but.Append("<div style='height: 26px; background-color: #E9F3FE' class='L_zi1'> 期号</div></th>");
            if (lottory == "FC3DData")
            {
                but.Append("<th scope='col'>");
                but.Append(" <div style='height: 26px; background-color: #E9F3FE' class='L_zi1'>模拟试机号</div>");
                but.Append("</th>");
            }
            but.Append("<th scope='col'>");
            but.Append("<div style='height: 26px; background-color: #E9F3FE' class='L_zi1'> 开奖号码</div>");
            but.Append("</th>");
            but.Append("</tr>");
            int myCount = 0;
            ////获取分页数据"FC3DData"

            DataTable lsResult = Basic.CstGetRecordFromPagesDs(lottory, "*", "", "issue", 40, Convert.ToInt32(pageindex), true, 2, " 1=1", out myCount);

            #region
            //string code = "";

            //string tcode = "";

            //switch (lottory)
            //{
            //    case "FC3DData": //3D
            //        {
            //            code = "code";
            //            tcode = "testcode";
            //        }
            //        break;
            //    case "FC7LC":  //7彩乐
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FCSSData":  //双色球
            //        {
            //            code = "redcode";
            //            tcode = "bluecode";
            //        }
            //        break;
            //    case "TCPL35Data":  //排列3 5
            //        {
            //            code = "code5";
            //        }
            //        break;
            //    case "TC7XCData":   //7星彩
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TCDLTData":   //大乐透
            //        {
            //            code = "code";
            //            tcode = "code2";
            //        }
            //        break;
            //    case "FC15X5Data_HD6S":  //华东六省15选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FCP61Data_HD6S":    //东方6＋1
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "TC22X5Data":   //22选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC36X7Data_FZ3J":  //泛珠三角36选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC25X5Data_AnH":   //安徽25选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC26X5Data_GuangD":    //广东26选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC36X7Data_GuangD":   //广东36选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC20X5Data_HeB":     //河北20选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FCPL5Data_HeB":    //河北排列5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC7XCData_HeB":     //河北排列7
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC22X5Data_HeN":   //河南22选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC22X5Data_HeiLJ":   //黑龙江22选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC36X7Data_HeiLJ":    //黑龙江36选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FCP62Data_HeiLJ":    //黑龙江P62
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC22X5Data_HuB":    //湖北22选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC35X7Data_LiaoN":    //辽宁35选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC23X5Data_ShanD":        //山东23选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC21X5Data_ShanX2":        //山西21选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC4DData_ShangH":        //上海4D
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC35X7Data_ShenZ":        //深圳35选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC15X5Data_TianJ":        //天津15选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC18X7Data_XinJ":        //新疆18选7
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "FC25X7Data_XinJ":        //新疆25选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC35X7Data_XinJ":        //新疆35选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FC22X5Data_YGC":        //云贵川22选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC33X7Data_BeiJ":        //北京33选7
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC22X5Data_FuJ":        //福建22选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC31X7Data_FuJ":        //福建31选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "TC36X7Data_FuJ":        //福建36选7
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "TCP61Data_HeiLJ":        //黑龙江6＋1
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "TC7XCData_jiangS":       //江苏七星彩
            //        {
            //            code = "code";
            //        }
            //        break;

            //    case "TCP41Data_HaiN":        //海南4＋1
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "TC20X5Data_ZheJ":        //浙江20选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TCP61Data_ZheJ":        //浙江6＋1
            //        {
            //            code = "code";
            //            tcode = "tcode";
            //        }
            //        break;
            //    case "FCSSLData_SH":        //上海时时乐
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_ChongQ":        //重庆时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_XinJ":        //新疆时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_JiangX":        //江西时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_FuJ":        //福建时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_HeiLJ":        //黑龙江时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_TianJ":        //天津时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_YunN":        //云南时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_AnH":        //安徽时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FCSSCData_HuN":        //湖南时时彩
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FC20X8Data_GuangD":        //广东快乐十分
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FC21X5Data_GuangX":        //广西快乐十分
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "FC23X5Data_GP_ShanD":        //山东群英会
            //        {
            //            code = "Code";
            //        }
            //        break;

            //    case "":        //四川快乐12
            //        {

            //        }
            //        break;

            //    case "TC11X5Data_ShanD":        //山东十一运夺金
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_AnH":        //安徽11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_JiangX":        //江西多乐彩
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_GuangD":        //广东11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_SiC":        //四川11选5
            //        {
            //            code = "code";
            //        }
            //        break;

            //    case "TC11X5Data_ChongQ":        //重庆11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_TianJ":        //天津11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_HuB":        //湖北11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_HeN":        //河南11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_FuJ":        //福建11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_GanS":        //甘肃11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_GuiZ":        //贵州11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC11X5Data_ShanX2":        //山西11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC12X5Data_HeiLJ":        //黑龙江运动生肖
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC12X5Data_NeiM":        //内蒙11选5
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC12X5Data_HeB":        //河北运动生肖
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC22X5Data_ShangH":        //上海即乐彩
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC22X5Data_LiaoN":        //辽宁即乐彩
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC22X5Data_ShanX":        //陕西即乐彩
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC22X5Data_HuN":        //湖南即乐彩
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC30X3Data_YunN":        //云南快乐123
            //        {
            //            code = "code";
            //        }
            //        break;
            //    case "TC481Data_TianJ":        //天津481
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TC481Data_HeN":        //河南481
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TC481Data_NeiM":        //内蒙481
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TC481Data_ShanX2":        //山西481
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TC481Data_ZheJ":        //浙江481
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TC481Data_GanS":        //甘肃481
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_ShanD":        //山东扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_HeiLJ":        //黑龙江扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_HuB":        //湖北扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_JiangS":        //江苏扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_HeB":        //河北扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_LiaoN":        //辽宁扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_JiL":        //吉林扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    case "TCPKData_NingX":        //宁夏扑克
            //        {
            //            code = "Code";
            //        }
            //        break;
            //    default:
            //        code = "code";
            //        break;
            //}
            #endregion

            foreach (DataRow row in lsResult.Rows)
            {
                but.Append("<tr style='background-color: White; border-color: #B6CBE8;'>");
                but.Append(" <td align='center' style='width: 20%;'>");

                if (isgp == "0")
                {
                    but.Append(FormatData(row["date"]));
                }
                else
                {
                    but.Append(FormatData1(row["date"]));
                }

                but.Append(" </td>");
                but.Append(" <td style='width: 20%;'>");
                but.Append(row["issue"]);
                but.Append("  </td>");



                int number = lotteryTypeInfo.ToString().Split('|').Length; //是否有+后面数字1，2




                if (lottory == "FC3DData")
                {
                    but.Append("<td align='center' style='width: 30%;'>");
                    but.Append(" <span id='MyGridView_ctl02_lblHaoTest'>" + row["testcode"] + "</span>");
                    but.Append("</td>");
                    but.Append("<td align='center' style='width: 30%;'>");
                    but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[lotteryTypeInfo.ToString().Split(',')[4]] + "</span>");
                }
                else if (lottory == "TCPL35Data")
                {
                    if (pl3 == "pl3")
                    {
                        but.Append("<td align='center' style='width: 60%;'>");
                        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[lotteryTypeInfo.ToString().Split(',')[4]].ToString().Substring(0, 3).ToString() + "</span>");
                    }
                    else
                    {
                        but.Append("<td align='center' style='width: 60%;'>");
                        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[lotteryTypeInfo.ToString().Split(',')[4]].ToString() + "</span>");
                    }
                }
                else if (number == 1)
                {

                    if (lotteryTypeInfo.ToString().Split(',')[5] == "乐透型" || lotteryTypeInfo.ToString().Split(',')[5] == "按位乐透型")
                    {
                        but.Append("<td align='center' style='width: 60%;'>");
                        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + Method.FormartCode(row[lotteryTypeInfo.ToString().Split(',')[4]].ToString(), "") + "</span>");

                    }
                    else
                    {

                        but.Append("<td align='center' style='width: 60%;'>");
                        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[lotteryTypeInfo.ToString().Split(',')[4]] + "</span>");
                    }

                }
                else
                {
                    but.Append("<td align='center' style='width: 60%;'>");

                    if (lotteryTypeInfo.ToString().Split('|')[0].Split(',')[5].ToString() == "数字型")
                    {
                        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[lotteryTypeInfo.ToString().Split('|')[0].Split(',')[4]].ToString() + " + " + row[lotteryTypeInfo.ToString().Split('|')[1].Split(',')[4]].ToString() + "</span>");
                    }
                    else
                    {

                        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + Method.FormartCode(row[lotteryTypeInfo.ToString().Split('|')[0].Split(',')[4]].ToString(), "") + " + " + Method.FormartCode(row[lotteryTypeInfo.ToString().Split('|')[1].Split(',')[4]].ToString(), "") + "</span>");

                    }

                }
                #region
                //if (lottory == "FC3DData")
                //{
                //    but.Append("<td align='center' style='width: 30%;'>");
                //    but.Append(" <span id='MyGridView_ctl02_lblHaoTest'>" + row[tcode] + "</span>");
                //    but.Append("</td>");
                //    but.Append("<td align='center' style='width: 30%;'>");
                //    but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[code] + "</span>");
                //}
                //else
                //{
                //    if (lottory == "FC7LC" || lottory == "FCSSData" || lottory == "TC36X7Data_FZ3J" || lottory == "TCDLTData" || lottory == "FCP61Data_HD6S" || lottory == "TC36X7Data_FZ3J" || lottory == "FC36X7Data_GuangD" || lottory == "FC36X7Data_HeiLJ" || lottory == "FCP62Data_HeiLJ" || lottory == "FC35X7Data_LiaoN" || lottory == "FC35X7Data_ShenZ" || lottory == "FC25X7Data_XinJ" || lottory == "FC35X7Data_XinJ" || lottory == "TC31X7Data_FuJ" || lottory == "TC36X7Data_FuJ" || lottory == "TCP61Data_HeiLJ" || lottory == "TCP41Data_HaiN" || lottory == "TCP61Data_ZheJ")
                //    {
                //        but.Append("<td align='center' style='width: 60%;'>");
                //        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + Method.FormartCode(row[code].ToString(), "") + " + " + Method.FormartCode(row[tcode].ToString(), "") + "</span>");
                //    }
                //    else if (lottory == "TC11X5Data_ShanD" || lottory == "TC11X5Data_AnH" || lottory == "TC11X5Data_JiangX" || lottory == "TC11X5Data_GuangD" || lottory == "TC11X5Data_SiC" || lottory == "TC11X5Data_ChongQ" || lottory == "TC11X5Data_TianJ" || lottory == "TC11X5Data_HuB" || lottory == "TC11X5Data_HeN" || lottory == "TC11X5Data_FuJ" || lottory == "TC11X5Data_GanS" || lottory == "TC11X5Data_GuiZ" || lottory == "TC11X5Data_ShanX2" || lottory == "TC12X5Data_HeiLJ" || lottory == "TC12X5Data_NeiM" || lottory == "TC22X5Data_ShangH" || lottory == "TC22X5Data_ShangH" || lottory == "TC22X5Data_LiaoN" || lottory == "TC22X5Data_ShanX" || lottory == "TC22X5Data_HuN" || lottory == "TC30X3Data_YunN" || lottory == "FC20X8Data_GuangD" || lottory == "FC21X5Data_GuangX" || lottory == "TC12X5Data_HeB" || lottory == "FC23X5Data_GP_ShanD" || lottory == "TC22X5Data" || lottory == "TC33X7Data_BeiJ" || lottory == "TC20X5Data_ZheJ" || lottory == "FC22X5Data_HeN" || lottory == "FC22X5Data_HeiLJ" || lottory == "FC25X5Data_AnH" || lottory == "FC26X5Data_GuangD" || lottory == "FC20X5Data_HeB" || lottory == "FC22X5Data_HuB" || lottory == "FC23X5Data_ShanD" || lottory == "FC21X5Data_ShanX2" || lottory == "FC15X5Data_TianJ" || lottory == "FC18X7Data_XinJ" || lottory == "FC22X5Data_YGC")
                //    {
                //        but.Append("<td align='center' style='width: 60%;'>");
                //        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + Method.FormartCode(row[code].ToString(), "") + "</span>");
                //    }
                //    else if (pl3 == "pl3")
                //    {
                //        but.Append("<td align='center' style='width: 60%;'>");
                //        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[code].ToString().Substring(0, 3).ToString() + "</span>");
                //    }

                //    else
                //    {

                //        but.Append("<td align='center' style='width: 60%;'>");
                //        but.Append(" <span id='MyGridView_ctl02_lblHao'>" + row[code].ToString() + "</span>");
                //    }
                //}
                #endregion

                but.Append("</td>");
                but.Append("</tr>");
            }

            but.Append("<tr style='background-color: White; border-color: #B6CBE8;'>");
            but.Append(" <td align='center' colspan='4'>");

            //分页方法
            BindPage(pageindex, but, myCount, lottory, name, isgp);

            return but.ToString();
            #endregion
        }

        private void BindPage(string pageindex, StringBuilder but, int myCount, string lottory, string name, string isgp)
        {

            //判断总页数
            int pagecount = 0;
            if (myCount % 40 != 0)
            {
                pagecount = (myCount / 40) + 1;
            }
            else
            {
                pagecount = myCount / 40;
            }

            but.Append("<div><nobr><a href='javascript:void(0);' class='page0' id='page0'>首页</a> &nbsp;");

            if (Convert.ToInt32(pageindex) == 1)
            {
                but.Append(" <input type='hidden' value='" + (Convert.ToInt32(pageindex) - 1).ToString() + "' id='pgeshang' /><a href='javascript:void(0);' id='page1'>上一页</a> &nbsp;");
            }
            else
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex) - 1).ToString() + "' id='pgeshang' /> <a href='javascript:void(0);' id='page1'>上一页</a> &nbsp;");
            }




            if (Convert.ToInt32(pageindex) <= pagecount)
            {
                but.Append("<input type='hidden' value='" + (pageindex).ToString() + "' id='pge1' /> <a href='javascript:void(0);' id='pge1_1'>" + (pageindex).ToString() + "</a>&nbsp;");
            }
            if (Convert.ToInt32(pageindex) + 1 <= pagecount)
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex) + 1).ToString() + "' id='pge2' /> <a href='javascript:void(0);' id='pge2_1'>" + (Convert.ToInt32(pageindex) + 1).ToString() + "</a>&nbsp;");
            }

            if (Convert.ToInt32(pageindex) + 2 <= pagecount)
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex) + 2).ToString() + "' id='pge3' /> <a href='javascript:void(0);' id='pge3_1'>" + (Convert.ToInt32(pageindex) + 2).ToString() + "</a>&nbsp;");
            }
            if (Convert.ToInt32(pageindex) + 3 <= pagecount)
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex) + 3).ToString() + "' id='pge4' /> <a href='javascript:void(0);' id='pge4_1'>" + (Convert.ToInt32(pageindex) + 3).ToString() + "</a>&nbsp;");
            }
            if (Convert.ToInt32(pageindex) + 4 <= pagecount)
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex) + 4).ToString() + "' id='pge5' /> <a href='javascript:void(0);' id='pge5_1'>" + (Convert.ToInt32(pageindex) + 4).ToString() + "</a>&nbsp;");
            }

            if (Convert.ToInt32(pageindex) == pagecount)
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex)).ToString() + "' id='pgexia' /><a href='javascript:void(0);' id='page2' disabled>下一页</a> &nbsp;");
            }
            else
            {
                but.Append("<input type='hidden' value='" + (Convert.ToInt32(pageindex) + 1).ToString() + "' id='pgexia' /><a href='javascript:void(0);' id='page2'>下一页</a> &nbsp;");
            }

            but.Append("<a href='javascript:void(0);' id='page3'>末页 </a>&nbsp;");

            but.Append("共：" + myCount.ToString() + "条 " + "本页共40条  分页:" + pageindex + "/" + pagecount.ToString() + "页 </nobr></div>");

            but.Append("</td>");
            but.Append("</tr>");
            but.Append("</table>");

            //JS 首页
            but.Append(" <script type='text/javascript'>");
            //        but.Append("$(document).ready(function(){");
            but.Append(" $(\"#page0\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '1',lottory:'" + lottory + "',pl3: '',name: '" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            //      but.Append("});");

            //JS 上一页
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#page1\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pgeshang\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");

            //JS 下一页
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#page2\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pgexia\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");


            //末页
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#page3\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '" + pagecount.ToString() + "',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");


            //JS 数字分页1
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#pge1_1\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pge1\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");

            //JS 数字分页2
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#pge2_1\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pge2\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");

            //JS 数字分页3
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#pge3_1\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pge3\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");

            //JS 数字分页4
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#pge4_1\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pge4\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");

            //JS 数字分页5
            but.Append("$(document).ready(function(){");
            but.Append(" $(\"#pge5_1\").click(function(){");
            but.Append("$.ajax({ type:\"POST\",");
            but.Append("contentType:\"application/json\",");
            but.Append("url:\"/Template/WebService1.asmx/Present3DList\",");
            but.Append("data:\"{pageindex: '\"+$(\"#pge5\").val()+\"',lottory:'" + lottory + "',pl3: '',name:'" + name + "',isgp:'" + isgp + "'}\",");
            but.Append("dataType:\"json\",");
            but.Append("success:function(data){ ");
            but.Append("$(\"#rather\").html(HtmlDecode(data));");
            but.Append("}");
            but.Append("})");
            but.Append("});");
            but.Append("});");
            but.Append("</script>");
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        protected string FormatData(object objDate)
        {
            //string name = GetName();
            //if ("上海时时乐 | 重庆时时彩 | 新疆时时彩 | 江西时时彩 | 福建时时彩 | 广东快乐十分 | 广西快乐十分 | 山东群英会 |山东十一运夺金 | 黑龙江运动生肖 | 上海即乐彩 | 辽宁即乐彩 | 福建即乐彩 | 甘肃即乐彩 | 云南快乐123 | 重庆快乐123 | 河南481 | 内蒙481 | 山西481 | 安徽扑克 | 山东扑克 | 黑龙江扑克 | 四川扑克 | 湖北扑克 | 浙江扑克 | 江苏扑克 | 陕西扑克 | 河北扑克 | 辽宁扑克 | 山西扑克 | 吉林扑克 | 宁夏扑克".IndexOf(name) > -1)
            //{
            //    return string.Format("{0:yyyy-MM-dd  HH:mm:ss}", (DateTime)objDate);
            //}
            //else
            //{
            return string.Format("{0:yyyy-MM-dd}", (DateTime)objDate);
            //}
        }
        /// <summary>
        /// 格式化时间
        /// </summary>
        protected string FormatData1(object objDate)
        {
            //string name = GetName();
            //if ("上海时时乐 | 重庆时时彩 | 新疆时时彩 | 江西时时彩 | 福建时时彩 | 广东快乐十分 | 广西快乐十分 | 山东群英会 |山东十一运夺金 | 黑龙江运动生肖 | 上海即乐彩 | 辽宁即乐彩 | 福建即乐彩 | 甘肃即乐彩 | 云南快乐123 | 重庆快乐123 | 河南481 | 内蒙481 | 山西481 | 安徽扑克 | 山东扑克 | 黑龙江扑克 | 四川扑克 | 湖北扑克 | 浙江扑克 | 江苏扑克 | 陕西扑克 | 河北扑克 | 辽宁扑克 | 山西扑克 | 吉林扑克 | 宁夏扑克".IndexOf(name) > -1)
            //{
            //    return string.Format("{0:yyyy-MM-dd  HH:mm:ss}", (DateTime)objDate);
            //}
            //else
            //{
            return string.Format("{0:yyyy-MM-dd HH:mm}", (DateTime)objDate);
            //}
        }

        [WebMethod]
        public string PresentList(string type)
        {

            #region  开奖数据
            StringBuilder but = new StringBuilder();
            but.Append(" <div class='kai_rbg'>");
            but.Append(type + " <span class='kai_rbgz'>&nbsp;" + DateTime.Now.ToShortDateString() + "</span>");
            but.Append("</div>");


            but.Append("<table id='tb1' width='100%' border='0' align='center' cellpadding='0' cellspacing='1' bgcolor='#B6CBE8' class='MT'>");
            but.Append("<tr>");
            but.Append("<td width='120px' bgcolor='#E9F3FE' class='L_zi1' style='height: 26px'>彩种</td>");
            but.Append("<td width='118px' bgcolor='#E9F3FE' class='L_zi1' style='height: 26px'>开奖时间</td>");
            but.Append("<td width='72px' bgcolor='#E9F3FE' class='L_zi1' style='height: 26px'>期号</td>");
            but.Append(" <td width='270' bgcolor='#E9F3FE' class='L_zi1' style='height: 26px'>开奖号码</td>");
            but.Append("<td width='60px' bgcolor='#E9F3FE' class='L_zi1' style='height: 26px'>历史</td>");
            but.Append(" <td width='160px' bgcolor='#E9F3FE' class='L_zi1' style='height: 26px'>开奖周期</td>");
            but.Append("</tr>");



            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\QuanGuoCpDate.xml");
            XmlNode root = xml.GetXmlRoot();
            //全国福彩
            XmlNode QGFC = root.SelectSingleNode("/CpDate/QGFC");
            //全国体彩
            XmlNode QGTC = root.SelectSingleNode("/CpDate/QGTC");

            Pbzx.BLL.PBnet_LotteryMenu lotteryMenuBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotteryMenuBLL.GetList(" BitState=1 and BitIs_show=1  and NvarClass='" + type + "' order by NvarOrderId  ");

            if (type == "全国开奖")
            {
                #region
                //遍历全国福彩
                foreach (XmlNode tempNode in QGFC.ChildNodes)
                {
                    string issue = "";
                    string date = "";
                    string code = "";

                    if (tempNode.Attributes["app"].Value == "FC3DData")
                    {
                        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + tempNode.Attributes["app"].Value + " where code IS NOT NULL and len(code)>0  order by issue desc").Tables[0];

                        issue = dtWeb.Rows[0]["issue"].ToString();
                        date = dtWeb.Rows[0]["date"].ToString();
                        code = dtWeb.Rows[0]["code"].ToString();
                    }
                    else
                    {
                        issue = tempNode.Attributes["issue"].Value;
                        date = tempNode.Attributes["date"].Value;
                    }
                    but.Append("<tr>");
                    but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                    but.Append(" <a href=\"javascript:void(0);\" onclick=\"ListClick('" + tempNode.Attributes["name"].Value + "','0')\"  class='caibiao1'>" + tempNode.Attributes["name"].Value + "</a>");
                    but.Append("</td>");
                    but.Append("<td bgcolor='#FFFFFF' align='center' width='116px' height='26px'>" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date)) + "</td>");
                    but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                    but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='342px' height='26px' align='left'>");
                    but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                    but.Append(" <tr>");



                    //双色球
                    if ("双色球" == tempNode.Name)
                    {

                        string[] redCodes = Method.FormartCode(tempNode.Attributes["redcode"].Value, " ").Split(new char[] { ' ' });
                        foreach (string tempRedCode in redCodes)
                        {
                            but.Append("<td class='Lred'>" + tempRedCode + "</td>");
                        }

                        but.Append("<td class='Lblue'>" + tempNode.Attributes["bluecode"].Value + "</td>");

                    }
                    else if ("_3D" == tempNode.Name)
                    {
                        char[] M3Dcode = code.ToCharArray();
                        if (M3Dcode.Length > 1)
                        {
                            foreach (char tempChar in M3Dcode)
                            {
                                but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                            }
                        }
                    }
                    else if ("东方6X1" == tempNode.Name)
                    {
                        char[] M3Dcode = tempNode.Attributes["code"].Value.ToCharArray();
                        foreach (char tempChar in M3Dcode)
                        {
                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");

                        }
                        but.Append(" <td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>");
                    }
                    else
                    {
                        string[] redCodes = Method.FormartCode(tempNode.Attributes["code"].Value, " ").Split(new char[] { ' ' });
                        foreach (string tempRedCode in redCodes)
                        {
                            but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                        }
                        if (tempNode.Attributes["tcode"] != null)
                        {
                            but.Append("<td class='Lred'>" + tempNode.Attributes["tcode"].Value + "</td>");
                        }
                    }
                    but.Append("</tr>");
                    but.Append(" </table>");
                    but.Append(" </td>");
                    but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                    but.Append("  <a href=\"javascript:void(0);\" onclick=\"ListClick('" + tempNode.Attributes["name"].Value + "','0')\" class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                    but.Append("</td>");
                    but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" + Method.GetLottDate1(tempNode.Attributes["lott_date"].Value) + "</td>");
                    but.Append(" </tr>");

                }


                //遍历全国体彩
                foreach (XmlNode tempNode in QGTC.ChildNodes)
                {
                    string issue = "";
                    string date = "";
                    string code = "";

                    if (tempNode.Attributes["app"].Value == "FC3DData")
                    {
                        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + tempNode.Attributes["app"].Value + " where code IS NOT NULL and len(code)>0  order by issue desc").Tables[0];

                        issue = dtWeb.Rows[0]["issue"].ToString();
                        date = dtWeb.Rows[0]["date"].ToString();
                        code = dtWeb.Rows[0]["code"].ToString();
                    }
                    else
                    {
                        issue = tempNode.Attributes["issue"].Value;
                        date = tempNode.Attributes["date"].Value;
                    }

                    //添加排列3
                    if ("排列五" == tempNode.Name)
                    {
                        but.Append("<tr>");
                        but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                        but.Append(" <a href=\"javascript:void(0);\" onclick=\"ListClick('pl3','0')\" class='caibiao1'>排列三</a>");
                        but.Append("</td>");
                        but.Append("<td bgcolor='#FFFFFF' align='center' width='116px' height='26px'>" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date)) + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='342px' height='26px' align='left'>");
                        but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                        but.Append(" <tr>");

                        char[] redCodes = tempNode.Attributes["code5"].Value.ToCharArray();
                        if (redCodes.Length >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                but.Append("<td class='Lorange'>" + redCodes[i].ToString() + "</td>");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                but.Append("<td class='Lorange'></td>");
                            }
                        }
                        but.Append("</tr>");
                        but.Append(" </table>");
                        but.Append(" </td>");
                        but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                        but.Append("  <a href=\"javascript:void(0);\" onclick=\"ListClick('" + tempNode.Attributes["name"].Value + "','0')\"  class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                        but.Append("</td>");
                        but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" + Method.GetLottDate1(tempNode.Attributes["lott_date"].Value) + "</td>");
                        but.Append(" </tr>");

                    }

                    but.Append("<tr>");
                    but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                    but.Append(" <a href=\"javascript:void(0);\" onclick=\"ListClick('" + tempNode.Attributes["name"].Value + "','0')\" class='caibiao1'>" + tempNode.Attributes["name"].Value + "</a>");
                    but.Append("</td>");
                    but.Append("<td bgcolor='#FFFFFF' align='center' width='116px' height='26px'>" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date)) + "</td>");
                    but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                    but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='342px' height='26px' align='left'>");
                    but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                    but.Append(" <tr>");


                    if ("排列五" == tempNode.Name)
                    {
                        char[] redCodes = tempNode.Attributes["code5"].Value.ToCharArray();
                        foreach (char tempChar in redCodes)
                        {
                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                        }
                    }
                    else
                    {
                        if ("七星彩" == tempNode.Name)
                        {
                            char[] M3Dcode = tempNode.Attributes["code"].Value.ToCharArray();
                            if (M3Dcode.Length > 1)
                            {
                                foreach (char tempChar in M3Dcode)
                                {
                                    but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                }
                                but.Append(" <td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>");
                            }
                        }
                        else
                        {

                            string[] redCodes = Method.FormartCode(tempNode.Attributes["code"].Value, " ").Split(new char[] { ' ' });
                            //Lred
                            if ("大乐透" == tempNode.Name)
                            {
                                foreach (string tempRedCode in redCodes)
                                {
                                    but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                }
                                if (tempNode.Attributes["code2"].Value.Length == 4)
                                {

                                    but.Append(" <td class='Lblue'>" + tempNode.Attributes["code2"].Value.Substring(0, 2) + "</td>");
                                    but.Append(" <td class='Lblue'>" + tempNode.Attributes["code2"].Value.Substring(2, 2) + "</td>");

                                }
                            }
                            else
                            {
                                foreach (string tempRedCode in redCodes)
                                {
                                    but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                }
                                if (tempNode.Attributes["tcode"] != null)
                                {
                                    but.Append(" <td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>");
                                }
                            }
                        }
                    }




                    but.Append("</tr>");
                    but.Append(" </table>");
                    but.Append(" </td>");
                    but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                    but.Append(" <a href=\"javascript:void(0);\" onclick=\"ListClick('" + tempNode.Attributes["name"].Value + "','0')\"  class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                    but.Append("</td>");
                    but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" +
                        Method.GetLottDate1(tempNode.Attributes["lott_date"].Value)
                        + "</td>");
                    but.Append(" </tr>");

                }
                #endregion
            }
            else if (type == "各省福彩")
            {
                #region
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                        string issue = dtWeb.Rows[0]["issue"].ToString();
                        string date = dtWeb.Rows[0]["date"].ToString();
                        string code = dtWeb.Rows[0]["code"].ToString();
                        bool tcode = dtWeb.Columns.Contains("tcode");


                        but.Append("<tr>");
                        but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                        but.Append(" <a href=\"javascript:void(0);\" onclick=\"ListClick('" + row["NvarName"].ToString() + "','0')\" class='caibiao1'>" + row["NvarName"].ToString() + "</a>");
                        but.Append("</td>");
                        but.Append("<td bgcolor='#FFFFFF' align='center' width='116px' height='26px'>" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date)) + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='342px' height='26px' align='left'>");
                        but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                        but.Append(" <tr>");



                        object objCpInfo = row["LottTypeInfo"];
                        object objLottTypeCount = row["LottTypeCount"];
                        if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                        {

                            if (Convert.ToInt32(objLottTypeCount) < 2)
                            {
                                if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                {
                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {
                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {

                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }
                            }
                            else
                            {
                                string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                string qian = sz[0];
                                string hou = sz[1];
                                if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                {
                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {
                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {
                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }
                                but.Append("<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>");
                            }

                            but.Append("</tr>");
                            but.Append(" </table>");
                            but.Append(" </td>");
                            but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                            but.Append("  <a href=\"javascript:void(0);\" onclick=\"ListClick('" + row["NvarName"].ToString() + "','0')\" class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                            but.Append("</td>");
                            but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" +
                                Method.GetLottDate1(row["NvarLott_date"].ToString()) + "</td>");
                            but.Append(" </tr>");

                        }

                    }
                }
                #endregion
            }
            else if (type == "各省体彩")
            {

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                        string issue = dtWeb.Rows[0]["issue"].ToString();
                        string date = dtWeb.Rows[0]["date"].ToString();
                        string code = dtWeb.Rows[0]["code"].ToString();
                        bool tcode = dtWeb.Columns.Contains("tcode");


                        but.Append("<tr>");
                        but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                        but.Append("<a href=\"javascript:void(0);\" onclick=\"ListClick('" + row["NvarName"].ToString() + "','0')\" class='caibiao1'>" + row["NvarName"].ToString() + "</a>");
                        but.Append("</td>");
                        but.Append("<td bgcolor='#FFFFFF' align='center' width='116px' height='26px'>" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date)) + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='342px' height='26px' align='left'>");
                        but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                        but.Append(" <tr>");


                        object objCpInfo = row["LottTypeInfo"];
                        object objLottTypeCount = row["LottTypeCount"];
                        if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                        {

                            if (Convert.ToInt32(objLottTypeCount) < 2)
                            {
                                if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                {

                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {
                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {

                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }
                            }
                            else
                            {
                                string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                string qian = sz[0];
                                string hou = sz[1];
                                if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                {
                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {

                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {
                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }

                                but.Append("<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>");
                            }

                            but.Append("</tr>");
                            but.Append(" </table>");
                            but.Append(" </td>");
                            but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                            but.Append("  <a href=\"javascript:void(0);\" onclick=\"ListClick('" + row["NvarName"].ToString() + "','0')\" class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                            but.Append("</td>");
                            but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" + Method.GetLottDate1(row["NvarLott_date"].ToString()) + "</td>");
                            but.Append(" </tr>");
                        }
                    }
                }


            }
            else if (type == "高频福彩")
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                        string issue = dtWeb.Rows[0]["issue"].ToString();
                        string date = dtWeb.Rows[0]["date"].ToString();
                        string code = dtWeb.Rows[0]["code"].ToString();
                        bool tcode = dtWeb.Columns.Contains("tcode");



                        but.Append("<tr>");
                        but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                        but.Append(" <a href=\"javascript:void(0);\"  onclick=\"ListClick('" + row["NvarName"].ToString() + "','1')\" class='caibiao1'>" + row["NvarName"].ToString() + "</a>");
                        but.Append("</td>");
                        but.Append("<td bgcolor='#FFFFFF' align='center' width='136px' height='26px'>" + string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Parse(date)) + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='322px' height='26px' align='left'>");
                        but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                        but.Append(" <tr>");


                        object objCpInfo = row["LottTypeInfo"];
                        object objLottTypeCount = row["LottTypeCount"];
                        if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                        {

                            if (Convert.ToInt32(objLottTypeCount) < 2)
                            {
                                if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                {

                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {
                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {

                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");

                                    }
                                }
                            }
                            else
                            {
                                string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                string qian = sz[0];
                                string hou = sz[1];
                                if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                {
                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {

                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {
                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }

                                but.Append("<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>");
                            }

                            string a = "";
                            object objTime = row["TimeList"];
                            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
                            {
                                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });

                                TimeSpan tsStart = new TimeSpan();
                                if (!TimeSpan.TryParse(tmSZ[0], out tsStart))
                                {

                                }

                                TimeSpan tsEnd = new TimeSpan();
                                if (!TimeSpan.TryParse(tmSZ[1], out tsEnd))
                                {

                                }
                                int jg = 0;
                                tsEnd.Subtract(tsStart);
                                while (tsStart < tsEnd)
                                {
                                    tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                                    jg++;
                                }
                                a = "每" + jg.ToString() + "分钟";
                            }

                            but.Append("</tr>");
                            but.Append(" </table>");
                            but.Append(" </td>");
                            but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                            but.Append(" <a href=\"javascript:void(0);\"  onclick=\"ListClick('" + row["NvarName"].ToString() + "','1')\" class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                            but.Append("</td>");
                            but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" + a + "</td>");
                            but.Append(" </tr>");
                        }
                    }
                }
            }
            else if (type == "高频体彩")
            {

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                        if (dtWeb.Rows.Count < 1)
                        {
                            break;
                        }
                        string issue = dtWeb.Rows[0]["issue"].ToString();
                        string date = dtWeb.Rows[0]["date"].ToString();
                        string code = dtWeb.Rows[0]["code"].ToString();
                        bool tcode = dtWeb.Columns.Contains("tcode");



                        but.Append("<tr>");
                        but.Append(" <td align='left' class='left_top left_pd' width='137px' height='26px'>");
                        but.Append("<a href=\"javascript:void(0);\"  onclick=\"ListClick('" + row["NvarName"].ToString() + "','1')\" class='caibiao1'>" + row["NvarName"].ToString() + "</a>");
                        but.Append("</td>");
                        but.Append("<td bgcolor='#FFFFFF' align='center' width='136px' height='26px'>" + string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Parse(date)) + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' align='center' width='81px' height='26px'>" + issue + "</td>");
                        but.Append(" <td bgcolor='#FFFFFF' valign='bottom' width='322px' height='26px' align='left'>");
                        but.Append(" <table border='0' cellspacing='0' cellpadding='2'>");
                        but.Append(" <tr>");



                        object objCpInfo = row["LottTypeInfo"];
                        object objLottTypeCount = row["LottTypeCount"];
                        if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                        {
                            if (Convert.ToInt32(objLottTypeCount) < 2)
                            {
                                if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                {
                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {
                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {
                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {

                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }
                            }
                            else
                            {
                                string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                string qian = sz[0];
                                string hou = sz[1];
                                if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                {
                                    char[] M3Dcode = code.ToCharArray();
                                    if (M3Dcode.Length > 1)
                                    {
                                        foreach (char tempChar in M3Dcode)
                                        {
                                            but.Append("<td class='Lorange'>" + tempChar.ToString() + "</td>");
                                        }
                                    }
                                }
                                else
                                {
                                    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        but.Append("<td class='Lorange'>" + tempRedCode + "</td>");
                                    }
                                }
                                but.Append("<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>");
                            }


                            string a = "";

                            object objTime = row["TimeList"];
                            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
                            {
                                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });

                                TimeSpan tsStart = new TimeSpan();
                                if (!TimeSpan.TryParse(tmSZ[0], out tsStart))
                                {
                                }

                                TimeSpan tsEnd = new TimeSpan();
                                if (!TimeSpan.TryParse(tmSZ[1], out tsEnd))
                                {
                                }
                                int jg = 0;
                                tsEnd.Subtract(tsStart);
                                while (tsStart < tsEnd)
                                {
                                    tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                                    jg++;
                                }
                                a = "每" + jg.ToString() + "分钟";
                            }


                            but.Append("</tr>");
                            but.Append(" </table>");
                            but.Append(" </td>");
                            but.Append("<td bgcolor='#FFFFFF' align='center' width='73px' height='26px'>");
                            but.Append(" <a href=\"javascript:void(0);\"  onclick=\"ListClick('" + row["NvarName"].ToString() + "','1')\" class='caibiao1'><img border='0' src='/Images/Web/history.jpg' width='19' height='14' /></a>");
                            but.Append("</td>");
                            but.Append(" <td bgcolor='#FFFFFF' align='center' width='134px' height='26px'>" + a + "</td>");
                            but.Append(" </tr>");

                        }
                    }
                }
            }
            return but.ToString();
            #endregion
        }
    }
}
