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
using Pbzx.Common;
using System.Xml;

namespace Pbzx.Web.PB_Manage
{
    public partial class Refurbish_News : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private int _count3 = 4;
        /// <summary>
        /// 显示多少条
        /// </summary>
        public int Count3
        {
            get { return _count3; }
            set { _count3 = value; }
        }

        private int _titleLength3 = 16;
        /// <summary>
        /// 标题长度
        /// </summary>
        public int TitleLength3
        {
            get { return _titleLength3; }
            set { _titleLength3 = value; }
        }


        private int _titleLength = 23;
        /// <summary>
        /// 标题长度
        /// </summary>
        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count = 18;
        /// <summary>
        /// 显示多少条
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }



        private string _typeName = "";
        /// <summary>
        ///所属类别名称
        /// </summary>
        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }

        private string intDisPosition = "";
        /// <summary>
        /// 显示位置        
        /// </summary>
        public string IntDisPosition
        {
            get { return intDisPosition.Trim(); }
            set { intDisPosition = value; }
        }

        private string _classCss = "newslink";
        /// <summary>
        /// 内容行使用样式
        /// </summary>
        public string ClassCss
        {
            get { return _classCss; }
            set { _classCss = value; }
        }

        public void BindData()
        {
          //  DataTable dtData = null;
          //  Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
          //  Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
          //  if (!string.IsNullOrEmpty(TypeName))
          //  {
          //      Pbzx.Model.PBnet_NewsType typemodel = newsTypeBLL.GetModelByTypeName(TypeName);
          //      if (typemodel == null)
          //      {
          //          return;
          //      }
          //      else
          //      {
          //          StringBuilder sb1 = new StringBuilder(" 1=1 ");
          //          sb1.Append(" and IntShowType=" + typemodel.IntNewsTypeID + " ");
          //          dtData = newsBLL.GetTitleListByCount(sb1.ToString() + Method.Where_News + " and ShowIndex=1  order by BitIsTop  DESC,DatDateAndTime desc  ", this.Count);
          //      }
          //  }
          //  else
          //  {
          //      StringBuilder sb2 = new StringBuilder(" 1=1 ");
          //      dtData = newsBLL.GetTitleListByCount(sb2.ToString() + Method.Where_News + " and ShowIndex=1  order by BitIsTop  DESC,DatDateAndTime desc ", this.Count);
          //  }

          //  if (dtData.Rows.Count < 1)
          //  {
          //      return;
          //  }

          //  Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\Default_News.xml");
          //  XmlNode root = xml.GetXmlRoot();

          //  XmlNode children3 = root.SelectSingleNode("/root/children3");

          //  children3.RemoveAll();
          //  XmlNode children = root.SelectSingleNode("/root/children");
          //  children.RemoveAll();

          //  DataTable dtData1 = newsBLL.GetTitleListByCount(" 1=1 and ShowIndex=1 and charindex('2|',IntDisPosition)> 0   order by DatDateAndTime desc ", 1);

          //  DataTable dtData3 = newsBLL.GetTitleListByCount(" 1=1 and ShowIndex=1 and charindex('3|',IntDisPosition)> 0   order by DatDateAndTime desc ", 3);

          //  if (dtData3.Rows.Count < 1)
          //  {
          //      return;
          //  }

          //  //foreach (DataRow row3 in dtData3.Rows)
          //  //{
          //  //    string fullName = row3["NvarTitle"].ToString();
          //  //    string href = row3["SavePath"].ToString();
          //  //    string id = row3["IntID"].ToString();
          //  //    xml.AddChildNode("/root/children3", "child_" + id);
          //  //    xml.AddAttribute("/root/children3/child_" + id, "name", StrFormat.CutStringByNum(fullName, this.TitleLength3, " "));
          //  //    xml.AddAttribute("/root/children3/child_" + id, "href", href);
          //  //    xml.AddAttribute("/root/children3/child_" + id, "fullName", fullName);
          //  //    xml.AddAttribute("/root/children3/child_" + id, "time", row3["DatDateAndTime"].ToString());
          //  //}

          //  //foreach (DataRow row in dtData.Rows)
          //  //{
          //  //    string fullName = row["NvarTitle"].ToString();
          //  //    string href = row["SavePath"].ToString();
          //  //    string id = row["IntID"].ToString();
          //  //    xml.AddChildNode("/root/children", "child_" + id);
          //  //    xml.AddAttribute("/root/children/child_" + id, "name", StrFormat.CutStringByNum(fullName, this.TitleLength, " "));
          //  //    xml.AddAttribute("/root/children/child_" + id, "href", href);
          //  //    xml.AddAttribute("/root/children/child_" + id, "fullName", fullName);
          //  //    xml.AddAttribute("/root/children/child_" + id, "time", row["DatDateAndTime"].ToString());
          //  //}


          //  //拼接字符串
          //  StringBuilder sb = new StringBuilder();
          //  sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>拼搏在线彩神通软件-最新资讯</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" />  <script type=\"text/javascript\" language=\"javascript\">document.oncontextmenu = new Function(\"event.returnValue=false;\");</script></head><body>");
          //  sb.Append("<div class=\"D_P\" style='width:100%;'>");
          //  sb.Append("<div  id=\"dvContent\" style=\"margin-bottom:5px; margin-left:7px; width:98%;\" >");
          //  sb.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td align=\"center\"><div class=\"xia_7margin\" id=\"divTop3\">");


          //  ///首页第一条
          //  string fullName1 = dtData1.Rows[0]["NvarTitle"].ToString();       
          //  string href1 = dtData1.Rows[0]["SavePath"].ToString();
          
          //          sb.Append("<ul><li><span>");
          //          sb.Append("<a href='" + href1 + "' target='_blank' title='" + fullName1 + "' >" + StrFormat.CutStringByNum(fullName1, 24, "...") + "</a>");
          //          sb.Append("</span></li></ul>");
          //          sb.Append("<div><table style='width:100%'><tr>");
              

          //  ///上面3条
          //  for (int i = 0; i < dtData3.Rows.Count; i++)
          //  {
          //      string fullName = dtData3.Rows[i]["NvarTitle"].ToString();
          //      string shortTitle = dtData3.Rows[i]["NvarShortTitle"].ToString();
          //      string href = dtData3.Rows[i]["SavePath"].ToString();
          //      string id = dtData3.Rows[i]["IntID"].ToString();

          //          if (shortTitle == null || shortTitle == "")
          //          {
          //              sb.Append("<td style='width:33%'><a href='" + href + "' target='_blank' title='" + fullName + "' class='school'>" + StrFormat.CutStringByNum(fullName, 12, "") + "</a></td>");

          //          }
          //          else {

          //              sb.Append("<td style='width:33%'><a href='" + href + "' target='_blank' title='" + shortTitle + "' class='school'>" + StrFormat.CutStringByNum(shortTitle, 12, "") + "</a></td>");
          //          }
          //  }
          //  sb.Append("</tr></table></div>");

          //  sb.Append(" </div></td></tr>     <tr><td align=\"center\"><div class=\"content D_P2\"  id=\"div14\">");

          //  //下面14条
          //  sb.Append("<ul>");
          //  foreach (DataRow row in dtData.Rows)
          //  {
          //      string fullName = row["NvarTitle"].ToString();
          //      string shortTitle = row["NvarShortTitle"].ToString();
          //      string href = row["SavePath"].ToString();
          //      string id = row["IntID"].ToString();
          //      if (shortTitle == null || shortTitle == "")
          //      {
          //          sb.Append(" <li><span class='dianse'>·</span><a href='" + href + "' target='_blank' title='" + fullName + "' >" + StrFormat.CutStringByNum(fullName, 17, "") + "</a></li>");

          //      }
          //      else {

          //          sb.Append(" <li><span class='dianse'>·</span><a href='" + href + "' target='_blank' title='" + shortTitle + "' >" + StrFormat.CutStringByNum(shortTitle, 17, "") + "</a></li>");
          //      }
          //  }
          //  sb.Append("</ul>");

          //  sb.Append("</div></td><tr></table></div></div></body></html>");

          //  //写入文件
          //  string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_News.htm";
          //  DirectoryFile.CreateFile(htmlPath);
          //  using (System.IO.StreamWriter sw = new System.IO.StreamWriter(htmlPath, false, System.Text.Encoding.GetEncoding(Pbzx.Common.WebInit.webBaseConfig.Encoding)))
          //  {
          //      sw.Write(sb.ToString());
          //      sw.Close();
          //  }
          //  ///添加生成时间
          //  XmlNode myTime = root.SelectSingleNode("/root/CreateTime");


          //  myTime.Attributes.RemoveAll();
          //  xml.AddAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
          //  xml.SaveXmlDocument();


          //  // 重置标志
          //  HttpContext.Current.Application["newsCreating"] = "0";
          //  //重定向
          ////  HttpContext.Current.Server.Transfer("/index_News.htm");


        }
    }
}
