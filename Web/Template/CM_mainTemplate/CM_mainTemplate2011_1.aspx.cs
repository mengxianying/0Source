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
using System.Text;
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;

namespace Pbzx.Web.Template
{
    public partial class CM_mainTemplate2011_1 : System.Web.UI.Page
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["title"] != null && Request["content"] != null)
            {
                StringBuilder but = new StringBuilder();
                but.Append("<table cellpadding='0' cellspacing='0' style='width: 266px'>");

                but.Append("<tr>");
                but.Append("<td style='width: 250px'>");
                but.Append(" <img src='../../Images/Web/CM_main/public_top.jpg' />");
                but.Append("<td>");
                but.Append("</tr>");

                but.Append("<tr>");
                but.Append("<td height='29' align='center' style='width: 266px'>");
                if (Request["titleurl"] != "")
                {
                    but.Append("<a href='" + Request["titleurl"] + "' target='_blank'>");
                    but.Append("<strong title='" + Server.UrlDecode(Request.QueryString["title"]) + "'>" + Server.UrlDecode(Request.QueryString["title"]) + "</strong>");
                    but.Append("</a>");
                }
                else
                {
                    but.Append("<strong title='" + Server.UrlDecode(Request.QueryString["title"]) + "'>" + Server.UrlDecode(Request.QueryString["title"]) + "</strong>");
                }
                but.Append("</td>");
                but.Append("</tr>");

                but.Append(" <tr>");
                but.Append("<td valign='top'align='center' style='height: 62px; width: 266px; word-break:break-all;'>");
                but.Append(" <div  align='left' style='width: 230px;height:68px; overflow:hidden'>");
                if (Request["titleurl"] != "")
                {
                    but.Append("<a href='" + Request["titleurl"] + "'target='_blank'>");
                    but.Append(Server.UrlDecode(Request.QueryString["content"].Replace("\r\n", "<br/>")));
                    but.Append("</a>");
                }
                else
                {
                    but.Append(Server.UrlDecode(Request.QueryString["content"].Replace("\r\n", "<br/>")));
                }
                but.Append("</div>");
                but.Append("</td>");
                but.Append("</tr>");

                but.Append(" <tr>");
                but.Append("<td style='height: 16px; width: 250px;'>");
                but.Append("<img src='../../Images/Web/CM_main/public_foot.png' />");
                but.Append("</td>");
                but.Append(" </tr>");

                but.Append("</table>");
                divcontent.InnerHtml = but.ToString();
                return;
            }
            if (Request.QueryString["ID"] != null)
            {
                int id = 0;
                CM_MainManager cmmanager = new CM_MainManager();
                if (int.TryParse(Request.QueryString["ID"], out id))
                {
                    CM_Main cmmain = cmmanager.GetMain(id);
                    if (cmmain != null)
                    {
                        StringBuilder but = new StringBuilder();
                        but.Append("<table cellpadding='0' cellspacing='0' style='width: 266px'>");

                        but.Append("<tr>");
                        but.Append("<td style='width: 250px'>");
                        but.Append(" <img src='../../../../Images/Web/CM_main/public_top.jpg' />");
                        but.Append("<td>");
                        but.Append("</tr>");

                        but.Append("<tr>");
                        but.Append("<td height='29' align='center' style='width: 266px'>");
                        if (cmmain.Linkurl != "")
                        {
                            but.Append("<a href='" + cmmain.Linkurl + "'target='_blank'>");
                            but.Append("<strong title='" + cmmain.Title + "'>" + cmmain.Title + "</strong>");
                            but.Append("</a>");
                        }
                        else
                        {
                            but.Append("<font style=' text-decoration:none; color:#003E3E;'><strong title='" + cmmain.Title + "'>" + cmmain.Title + "</strong></font>");
                        }
                        but.Append("</td>");
                        but.Append("</tr>");

                        but.Append(" <tr valign='top'>");
                        but.Append("<td valign='top' align='center' style='height: 62px; width: 266px; word-break:break-all;'>");
                        but.Append(" <div  align='left' style='width: 230px;height:68px; overflow:hidden'>");
                        if (cmmain.Linkurl != "")
                        {
                            but.Append("<a href='" + cmmain.Linkurl + "'target='_blank'>");
                            but.Append(cmmain.Content.Replace("\r\n", "<br/>"));
                            but.Append("</a>");
                        }
                        else
                        {
                            but.Append(cmmain.Content.Replace("\r\n", "<br/>"));
                        }
                        but.Append("</div>");
                        but.Append("</td>");
                        but.Append("</tr>");

                        but.Append(" <tr>");
                        but.Append("<td style='height: 16px; width: 250px;'>");
                        but.Append("<img src='../../../../Images/Web/CM_main/public_foot.png'/>");
                        but.Append("</td>");
                        but.Append(" </tr>");

                        but.Append("</table>");
                        divcontent.InnerHtml = but.ToString();
                    }
                    else
                    {

                        divcontent.InnerHtml = " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;抱歉，该数据可能已被删除！";
                    }
                }
                else
                {
                    divcontent.InnerHtml = " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;非发访问ID！";

                }
            }
            else
            {
                divcontent.InnerHtml = " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;无访问ID！";
            }
        }
        /// <summary>
        /// 数据格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string TextFormat(object obj, int length)
        {

            string source = obj.ToString();
            if (length <= 0)
            {
                return source;
            }
            else
            {
                int tempLength = Method.GetStrLen(source);
                int charLength = 0;
                int hzLength = 0;

                //string tempResult = "";
                if (tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
                    //int intLen = 0;
                    for (int i = 0; i < cc.Length; i++)
                    {
                        if (Convert.ToInt32(cc[i]) > 255)
                        {
                            hzLength++;

                        }
                        else
                        {
                            charLength++;
                        }

                        if ((hzLength * 2 + charLength) % 2 == 0 && hzLength * 2 + charLength >= length || (hzLength * 2 + charLength) % 2 == 1 && hzLength * 2 + charLength >= length - 1)
                        {
                            break;
                        }
                    }
                    return source.Substring(0, hzLength + charLength) + "...";
                }
                else
                {
                    return source;
                }
            }
        }
    }
}
