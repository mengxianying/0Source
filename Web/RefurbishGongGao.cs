using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Collections;
using System.Text;
using System.IO;

namespace Pbzx.Web
{
    public class RefurbishGongGao : System.Web.UI.Page
    {

        private int _titleLength = 22;
        /// <summary>
        /// 标题长度
        /// </summary>
        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count = 10;
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
            //string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_Bulletin.htm";



            //DataTable dtData = null;
            //Pbzx.BLL.PBnet_Bulletin MyBLL = new Pbzx.BLL.PBnet_Bulletin();
            //Pbzx.BLL.PBnet_BulletinType MyTypeBLL = new Pbzx.BLL.PBnet_BulletinType();
            //if (!string.IsNullOrEmpty(TypeName))
            //{
            //    Pbzx.Model.PBnet_BulletinType typemodel = MyTypeBLL.GetModelByTypeName(TypeName);
            //    if (typemodel == null)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        StringBuilder sb = new StringBuilder(" 1=1 ");
            //        sb.Append(" and IntShowType=" + typemodel.IntNewsTypeID + " ");
            //        if (!string.IsNullOrEmpty(IntDisPosition.ToString()))
            //        {
            //            if (!OperateText.IsNumber(IntDisPosition))
            //            {
            //                return;
            //            }
            //            sb.Append(" and IntDisPosition='" + IntDisPosition + "' ");
            //        }//NewsFilter
            //        dtData = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " and ShowIndex=1  order by  BitIsTop desc,DatDateAndTime desc  ", this.Count);
            //    }
            //}
            //else
            //{
            //    StringBuilder sb = new StringBuilder(" 1=1 ");
            //    if (!string.IsNullOrEmpty(IntDisPosition.ToString()))
            //    {
            //        sb.Append(" and IntDisPosition='" + IntDisPosition.ToString().Trim() + "' ");
            //    }
            //    dtData = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " and ShowIndex=1  order by  BitIsTop desc,DatDateAndTime desc ", this.Count);
            //}

            //if (dtData.Rows.Count < 1)
            //{
            //    return;
            //}

            //Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\GongGao.xml");
            //XmlNode root = xml.GetXmlRoot();

            //XmlNode children = root.SelectSingleNode("/root/children");
            //children.RemoveAll();

            ////拼接字符串
            //StringBuilder sb1 = new StringBuilder();
            //sb1.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>拼搏在线彩神通软件-最新公告</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" />  <script type=\"text/javascript\" language=\"javascript\">//document.oncontextmenu = new Function(\"event.returnValue=false;\");</script></head><body>");
            //sb1.Append("<div style='width: 100%; background-color: White;'>");
            //sb1.Append("<div id='dvContent' style='margin-bottom: 4px; margin-left: 6px; width: 98%;' class='D_P2'>");
            //sb1.Append("<table width='100%' cellpadding='0' cellspacing='0'>");

            //foreach (DataRow row in dtData.Rows)
            //{
            //    if (row["NvarShortTitle"].ToString() == null || row["NvarShortTitle"].ToString() == "")
            //    {
            //        sb1.Append("<tr><td align='left'>·<a href='" + row["SavePath"].ToString() + "' target='_blank' title='" + row["NvarTitle"].ToString() + "'>" + StrFormat.CutStringByNum(row["NvarTitle"].ToString(), this.TitleLength, " ") + "</a></td></tr>");

            //    }

            //    else {
            //        sb1.Append("<tr><td align='left'>·<a href='" + row["SavePath"].ToString() + "' target='_blank' title='" + row["NvarShortTitle"].ToString() + "'>" + StrFormat.CutStringByNum(row["NvarShortTitle"].ToString(), this.TitleLength, " ") + "</a></td></tr>");
            //    }
            //}
            //sb1.Append("</table></div></div></body></html>");


            ////写入文件
            //string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_Bulletin.htm";
            //if (File.Exists(htmlPath))
            //{
            //    File.SetAttributes(htmlPath, FileAttributes.Normal);
            //    File.Delete(htmlPath);
            //}
            //DirectoryFile.CreateFile(htmlPath);
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(htmlPath, false, System.Text.Encoding.GetEncoding(Pbzx.Common.WebInit.webBaseConfig.Encoding)))
            //{
            //    sw.Write(sb1.ToString());
            //    sw.Close();
            //}

            /////添加生成时间
            //XmlNode myTime = root.SelectSingleNode("/root/CreateTime");
            //myTime.Attributes.RemoveAll();
            //xml.AddAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
            //xml.SaveXmlDocument();

            ////重置标志
            //HttpContext.Current.Application["bulletinCreating"] = "0";
            ////重定向
            //HttpContext.Current.Server.Transfer("/index_Bulletin.htm");


            
        }
    }
}
