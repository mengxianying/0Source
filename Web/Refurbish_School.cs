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
    public class Refurbish_School : System.Web.UI.Page
    {
        private int _titleLength = 28;

        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count = 8;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";

        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }
        private int _isHot;

        public int IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }

        public void BindData()
        {
            //string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_School.htm";

            //if (File.Exists(htmlPath))
            //{
            //    File.SetAttributes(htmlPath, FileAttributes.Normal);
            //    File.Delete(htmlPath);
            //}

            //DataTable dtData = null;
            //string strHot = "";
            //if (IsHot > 0)
            //{
            //    strHot = Method.CheckNewsHot(true);
            //}
            //else if (IsHot == 0)
            //{
            //    strHot = "";
            //}
            //else
            //{
            //    strHot = Method.CheckNewsHot(false);
            //}

            //Pbzx.BLL.PBnet_School newsBLL = new Pbzx.BLL.PBnet_School();
            //Pbzx.BLL.PBnet_SchoolType newsTypeBLL = new Pbzx.BLL.PBnet_SchoolType();
            //if (!string.IsNullOrEmpty(TypeName))
            //{
            //    Pbzx.Model.PBnet_SchoolType typemodel = newsTypeBLL.GetModelByTypeName(TypeName);
            //    if (typemodel == null)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        StringBuilder sb = new StringBuilder(" 1=1 ");
            //        sb.Append(strHot);
            //        sb.Append(" and IntShowType=" + typemodel.IntNewsTypeID + " ");
            //        dtData = newsBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " and ShowIndex=1  order by  BitIsTop desc,DatDateAndTime desc  ", this.Count);
            //    }
            //}
            //else
            //{
            //    StringBuilder sb = new StringBuilder(" 1=1 ");
            //    sb.Append(strHot);
            //    dtData = newsBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " and ShowIndex=1  order by  BitIsTop desc,DatDateAndTime desc ", this.Count);
            //}
            //if (dtData.Rows.Count < 1)
            //{
            //    return;
            //}

            //Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\Default_School.xml");
            //XmlNode root = xml.GetXmlRoot();

            //XmlNode children = root.SelectSingleNode("/root/children");
            //children.RemoveAll();


            //foreach (DataRow row in dtData.Rows)
            //{
            //    string fullName = row["NvarTitle"].ToString();
            //    string strID = Input.Encrypt(row["IntID"].ToString());
            //    string id = row["IntID"].ToString();
            //    xml.AddChildNode("/root/children", "child_" + id);
            //    xml.AddAttribute("/root/children/child_" + id, "name", StrFormat.CutStringByNum(fullName, this.TitleLength, " "));
            //    xml.AddAttribute("/root/children/child_" + id, "href", row["SavePath"].ToString());
            //    xml.AddAttribute("/root/children/child_" + id, "fullName", fullName);
            //    xml.AddAttribute("/root/children/child_" + id, "time", row["DatDateAndTime"].ToString());
            //    //  xml.SaveXmlDocument();
            //}


            /////添加生成时间
            //XmlNode myTime = root.SelectSingleNode("/root/CreateTime");
            //xml.SetAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
            //xml.SaveXmlDocument();
            //HttpContext.Current.Application["schoolCreating"] = "0";
        }
    }
}
