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
using Pbzx.Common;
using Pbzx.Model;

namespace Pbzx.Web.Template.CM_mainTemplate
{
    public partial class CM_mainTemplate2011_6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["title"] != null && Request["content"] != null)
            {
                StringBuilder but = new StringBuilder();
                but.Append("<table width='550px' cellpadding='0' cellspacing='0'>");

                but.Append("<tr>");
                but.Append("<td height='29'  align='center' colspan='2'>");
                but.Append(" <font style=' text-decoration:none;color:blue;'><strong title='" + Server.UrlDecode(Request.QueryString["title"]) + "'>" + Server.UrlDecode(Request.QueryString["title"]) + "</strong></font>");
                but.Append("<td>");
                but.Append("</tr>");

                but.Append(" <tr>");
                but.Append("<td valign='top'align='center' style='height: 62px; width: 550px; word-break:break-all;'colspan='2'; >");
                but.Append(" <div  align='left' style='width: 500px;overflow:hidden'>");
                but.Append(Server.UrlDecode(Request.QueryString["content"]));
                but.Append("</div>");
                but.Append("</td>");
                but.Append("</tr>");

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
                        but.Append("<table width='550px' cellpadding='0' cellspacing='0'>");

                        but.Append("<tr>");
                        but.Append("<td height='29' align='center' colspan='2'>");
                        but.Append("<strong style='Color:blue;' title='" + cmmain.Title + "'>" + cmmain.Title + "</strong>");
                        but.Append("<td>");
                        but.Append("</tr>");

                        but.Append(" <tr>");
                        but.Append("<td valign='top' align='center' colspan='2' style='height: 62px; width: 550px;word-break:break-all;'>");
                        but.Append(" <div  align='left' style='width: 500px;overflow:hidden'>");
                        but.Append(cmmain.Content);
                        but.Append("</div>");
                        but.Append("</td>");
                        but.Append("</tr>");



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

                if (tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
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
