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
using System.IO;
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class Refurbish_Soft : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private int _count = 6;

        /// <summary>
        /// 显示多少条
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private int _tileLength = 12;
        /// <summary>
        /// 标题长度
        /// </summary>

        public int TileLength
        {
            get { return _tileLength; }
            set { _tileLength = value; }
        }
        public void BindData()
        {

            string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_Soft.htm";

            if (File.Exists(htmlPath))
            {
                File.SetAttributes(htmlPath, FileAttributes.Normal);
                File.Delete(htmlPath);
            }

            DataTable dtData = null;
            Pbzx.BLL.PBnet_Product ProductBll = new Pbzx.BLL.PBnet_Product();

            dtData = ProductBll.GetSoftPic(this.Count);
            if (dtData.Rows.Count < 1)
            {
                return;
            }

            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\Default_soft.xml");
            XmlNode root = xml.GetXmlRoot();

            XmlNode children = root.SelectSingleNode("/root/children");
            children.RemoveAll();

            XmlNode children2 = root.SelectSingleNode("/root/children2");
            children2.RemoveAll();


            Pbzx.BLL.PBnet_Soft softBll = new Pbzx.BLL.PBnet_Soft();
            DataTable dtData2 = softBll.GetSoft(this.Count);

            if (dtData2.Rows.Count < 1)
            {
                return;
            }

            foreach (DataRow row in dtData.Rows)
            {
                string fullName = row["pb_SoftName"].ToString();
                //string href = row["pb_Hits"].ToString();
                string id = row["pb_SoftID"].ToString();
                xml.AddChildNode("/root/children", "child_" + id);
                xml.AddAttribute("/root/children/child_" + id, "name", StrFormat.CutStringByNum(fullName, this.TileLength, " "));
                xml.AddAttribute("/root/children/child_" + id, "href", Input.Encrypt(id));
                xml.AddAttribute("/root/children/child_" + id, "fullName", fullName);
                xml.AddAttribute("/root/children/child_" + id, "Version", row["pb_SoftVersion"].ToString());
            }

            foreach (DataRow row2 in dtData2.Rows)
            {
                string fullName = row2["PBnet_SoftName"].ToString();
                //  string href = row2["pb_Hits"].ToString();
                string id = row2["PBnet_SoftID"].ToString();
                xml.AddChildNode("/root/children2", "child_" + id);
                xml.AddAttribute("/root/children2/child_" + id, "name", StrFormat.CutStringByNum(fullName, this.TileLength, " "));
                xml.AddAttribute("/root/children2/child_" + id, "href", Input.Encrypt(id));
                xml.AddAttribute("/root/children2/child_" + id, "fullName", fullName);
                xml.AddAttribute("/root/children2/child_" + id, "Version", row2["PBnet_SoftVersion"].ToString());
            }
            string result = BindData(xml);

            //写入文件
            DirectoryFile.CreateFile(htmlPath);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(htmlPath, false, System.Text.Encoding.GetEncoding(Pbzx.Common.WebInit.webBaseConfig.Encoding)))
            {
                sw.Write(result);
                sw.Close();
            }

            ///添加生成时间
            XmlNode myTime = root.SelectSingleNode("/root/CreateTime");
            xml.SetAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
            xml.SaveXmlDocument();
            // 重置标志
            HttpContext.Current.Application["softCreating"] = "0";
            //重定向
            //HttpContext.Current.Response.Redirect("/index_Soft.htm");
        }


        private string BindData(MyXML xml)
        {
            XmlNode root = xml.GetXmlRoot();

            //上面4条
            XmlNode children = root.SelectSingleNode("/root/children");
            StringBuilder sb = new StringBuilder();
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>拼搏在线彩神通软件--最新软件</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" /></head><body>");
            sb.Append("<div id=\"soft\" width=\"100%\" style=\"background-color:White;\">");
            sb.Append("<table width='95%' border='0' cellpadding='2' cellspacing='1' align='center' bgcolor='#D8D8D8'>");
            sb.Append("<tr><td width='80%' bgcolor='#F4F4F4' align='left'>");
            sb.Append(" <strong>&nbsp;名称</strong>");
            sb.Append("</td><td width='20%' align='center' bgcolor='#F4F4F4'>");
            sb.Append("<strong>版本</strong>");
            sb.Append("</td></tr>");

            for (int i = 0; i < children.ChildNodes.Count; i++)
            {
                XmlNode node1 = children.ChildNodes[i];
                sb.Append("<tr><td bgcolor='#FFFFFF' align='left'>");
                sb.Append("·<a href='Soft_explain.aspx?ID=" + node1.Attributes["href"].Value + "' target='_blank' title='" + node1.Attributes["fullName"].Value + "' >" + StrFormat.CutStringByNum(node1.Attributes["name"].Value, 11, "...") + "</a>");
                sb.Append("</td>");
                sb.Append("<td  align='center' bgcolor='#FFFFFF'  title='" + node1.Attributes["Version"].Value + "'>");
                sb.Append("" + StrFormat.CutStringByNum(node1.Attributes["Version"].Value, 5) + "");
                sb.Append("</td></tr>");

            }


            XmlNode root2 = xml.GetXmlRoot();


            XmlNode children2 = root2.SelectSingleNode("/root/children2");
            StringBuilder sb2 = new StringBuilder();

            for (int i = 0; i < children2.ChildNodes.Count; i++)
            {
                XmlNode node2 = children2.ChildNodes[i];
                sb2.Append("<tr><td  bgcolor='#FFFFFF' align='left'>");
                sb2.Append("·<a href='Source_explain.aspx?ID=" + node2.Attributes["href"].Value + "' target='_blank' title='" + node2.Attributes["fullName"].Value + "' >" + StrFormat.CutStringByNum(node2.Attributes["fullName"].Value, 11, "...") + "</a>");
                sb2.Append("</td>");
                sb2.Append("<td  bgcolor='#FFFFFF' title='" + node2.Attributes["Version"].Value + "'>");
                sb2.Append("" + StrFormat.CutStringByNum(node2.Attributes["Version"].Value, 5) + "");
                sb2.Append("</td></tr>");
            }
            sb2.Append("</table>");
            sb2.Append("</div></body></html>");
            return sb.ToString() + sb2.ToString();
        }

        }
    }

