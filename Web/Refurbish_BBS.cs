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
using System.Text;

namespace Pbzx.Web
{
    public class Refurbish_BBS :System.Web.UI.Page
    {
        private  int _titleLength = 28;

        public  int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private  int _count = 8;

        public  int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public void BindData()
        {
            try
            {
                //DataSet dsData = DbHelperSQLBBS.Query("select top " + _count + " DateAndTime, boardID,Title,TopicID from Dv_Topic where boardID<>444 and boardID<>8 and boardID<>20 and boardID<>32 order by TopicID desc ");
                DataSet dsData = DbHelperSQLBBS.Query("select top " + _count + " DateAndTime, boardID,Title,TopicID from Dv_Topic where boardID<>444 and boardID<>777 and boardID<>8 and boardID<>20 and boardID<>32 order by TopicID desc ");
                if (!(dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0))
                {
                    return;
                }
                //拼接字符串
                StringBuilder sb = new StringBuilder();

                //sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>论坛最新帖子</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" /></head><body>");
                //sb.Append("<div style=\"width:100%;background-color:White; padding-top:0px;\">");
                //sb.Append("<div  id=\"dvContent\" style=\"margin-bottom:0px; margin-left:7px; width:98%;\" >");
                //sb.Append("<table width='100%' cellpadding='0' cellspacing='0'>");

                sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>论坛最新帖子</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" /></head><body>");
                sb.Append("<div  id=\"dvContent\" style=\"background-color:White;\" >");
                sb.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");
                
                foreach (DataRow row in dsData.Tables[0].Rows)
                {
                    string fullName = row["Title"].ToString();
                    string boardID = row["boardid"].ToString();
                    string id = row["TopicID"].ToString();
                    sb.Append("<tr><td align='left'>·<a href='http://bbs.pinble.com/dispbbs.asp?boardID=" + boardID + "&ID=" + id + "&page=1' target='_blank' title='" + fullName + "' >" + StrFormat.CutStringByNum(fullName, TitleLength*2, " ") + "</a></td></tr>");
                }
                sb.Append("</table></div></body></html>");

//                sb.Append("</table></div></div></body></html>");

                //写入文件
                string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_BBS.htm";
                DirectoryFile.CreateFile(htmlPath);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(htmlPath, false, System.Text.Encoding.GetEncoding(Pbzx.Common.WebInit.webBaseConfig.Encoding)))
                {
                    sw.Write(sb.ToString());
                    sw.Close();
                }

                ///添加生成时间
                Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\Default_BBS.xml");
                XmlNode root = xml.GetXmlRoot();
                XmlNode children = root.SelectSingleNode("/root/children");
                children.RemoveAll();
                XmlNode myTime = root.SelectSingleNode("/root/CreateTime");
                xml.SetAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
                xml.SaveXmlDocument();

                // 重置标志
                HttpContext.Current.Application["bbsCreating"] = "0";
                //重定向
                HttpContext.Current.Response.Redirect("/index_BBS.htm");
            }
            catch(Exception ex)
            {
                HttpContext.Current.Response.Redirect("/index_BBS.htm");
            }
        }

        //public void BindData()
        //{
        //    DataSet dsData = DbHelperSQLBBS.Query("SELECT TOP 8 TopicID,boardid,title,hits,isvote,child,pollid,LockTopic,PostTable,BoardID,TopicMode,DateAndTime,Expression,GetMoneyType,PostUserid  FROM dbo.Dv_Topic WHERE (BoardID IN (10, 12, 22, 24, 64, 69, 70, 71)) order by DateAndTime desc");
        //    if (!(dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0))
        //    {
        //        return;
        //    }

        //    Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("~/xml/Default_BBS.xml");
        //    XmlNode root = xml.GetXmlRoot();

        //    XmlNode children = root.SelectSingleNode("/root/children");
        //    children.RemoveAll();

        //    foreach (DataRow row in dsData.Tables[0].Rows)
        //    {
        //        string fullName = row["Title"].ToString();
        //        string boardID = row["boardid"].ToString();
        //        string id = row["TopicID"].ToString();
        //        xml.AddChildNode("/root/children", "child_" + id);
        //        xml.AddAttribute("/root/children/child_" + id, "name", StrFormat.CutStringByNum(fullName, this.TitleLength, " "));
        //        xml.AddAttribute("/root/children/child_" + id, "boardID", boardID);
        //        xml.AddAttribute("/root/children/child_" + id, "fullName", fullName);
        //        xml.AddAttribute("/root/children/child_" + id, "id", id);
        //        xml.AddAttribute("/root/children/child_" + id, "time", row["DateAndTime"].ToString());
        //    }

        //    ///添加生成时间
        //    XmlNode myTime = root.SelectSingleNode("/root/CreateTime");
        //    myTime.Attributes.RemoveAll();
        //    xml.AddAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
        //    xml.SaveXmlDocument();           
        //}



    }
}
