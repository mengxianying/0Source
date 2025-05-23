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
    public partial class Refurbish_Ask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private int _titleLength = 56;
        /// <summary>
        /// 标题长度
        /// </summary>
        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count = 8;
        /// <summary>
        /// 显示多少条数据
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";
        /// <summary>
        /// 所属类别名称
        /// </summary>
        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }

        private string _isHot = "";
        /// <summary>
        /// 是否热门,1代表热点，0代表不是热点， 默认为热点与非热点混合
        /// </summary>
        public string IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }

        private string _state = "0";
        /// <summary>
        /// 状态：0-待解决；1-已解决；2-已关闭。默认或者空字符串-混合
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        private string _isCommend = "";
        /// <summary>
        /// 是否是精彩推荐（1：推荐 0：不推荐，默认为混合）
        /// </summary>
        public string IsCommend
        {
            get { return _isCommend; }
            set { _isCommend = value; }
        }

        private string _isHighLargessPoint = "";
        /// <summary>
        /// 是否是高悬赏问题（1：是 0：不是，默认为混合）
        /// </summary>
        public string IsHighLargessPoint
        {
            get { return _isHighLargessPoint; }
            set { _isHighLargessPoint = value; }
        }

        protected string FormartReplys(object objId)
        {
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            return replyBLL.GetSingleData("select count(1) from PBnet_ask_Reply where QuestionId='" + objId.ToString() + "' ").ToString();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            DataTable dtData = null;
            //是否是热点
            string strHot = "";
            if (IsHot == "1")
            {

                strHot = Method.CheckQuestionHot(true);
            }
            else if (IsHot == "0")
            {
                strHot = Method.CheckQuestionHot(false);
            }

            //状态（待解决，未解决，已关闭）
            string strState = "";
 //           if (State == "0")
 //           {
 //               strState = " and State=0 ";
 //           }
 //           else if (State == "1")
 //           {
 //               strState = " and State=1 ";
 //           }
 //           else if (State == "2")
 //           {
 //               strState = " and State=2 ";
 //           }

            //是否推荐
            string strCommend = "";
            if (IsCommend == "0")
            {
                strCommend = "and IsCommend=0 ";
            }
            else if (IsCommend == "1")
            {
                strCommend = "and IsCommend=1 ";
            }

            //是否是高悬赏问题
            //string strHighLargessPoint = "";
            if (IsHighLargessPoint == "0")
            {
                strCommend = "and LargessPoint < " + WebInit.ask.AskHighLargessPoint + " ";
            }
            else if (IsHighLargessPoint == "1")
            {
                strCommend = "and LargessPoint >= " + WebInit.ask.AskHighLargessPoint + " ";
            }

            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();

            Pbzx.BLL.PBnet_ask_Type askTypeBLL = new Pbzx.BLL.PBnet_ask_Type();
            StringBuilder sb1 = new StringBuilder(" Deleted='false' and Auditing='true'");
            sb1.Append(strState);
            sb1.Append(strHot);
            sb1.Append(strCommend);

            if (!string.IsNullOrEmpty(TypeName))
            {
                Pbzx.Model.PBnet_ask_Type typemodel = askTypeBLL.GetModelByTypeName(TypeName);
                if (typemodel == null)
                {
                    return;
                }
                else
                {
                    sb1.Append(" and TypeName='" + typemodel.TypeName + "' ");
                    dtData = questionBLL.GetTitleListByCount(sb1.ToString(), this.Count);
                }
            }
            else
            {
                dtData = questionBLL.GetTitleListByCount(sb1.ToString(), this.Count);
            }
            if (dtData.Rows.Count < 1)
            {
                return;
            }




            //拼接字符串
            StringBuilder sb = new StringBuilder();
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>拼搏在线-拼搏吧-最新问题</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" /></head><body>");
            sb.Append("<div  id=\"dvContent\" style=\"background-color:White;\" >");
            sb.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");

            foreach (DataRow row in dtData.Rows)
            {
                string fullName = row["Title"].ToString();
                string strID = Input.Encrypt(row["Id"].ToString());
                string id = row["Id"].ToString();
                sb.Append("<tr><td align='left'>·<a href='" + WebInit.ask.WebUrl + "Question.aspx?question=" + strID + "' target='_blank' title='" + fullName + "' >" + StrFormat.CutStringByNum(fullName, TitleLength, " ") + "</a></td></tr>");
            }
            sb.Append("</table></div></body></html>");

            //写入文件
            string htmlPath = HttpRuntime.AppDomainAppPath + "\\index_Ask.htm";
            DirectoryFile.CreateFile(htmlPath);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(htmlPath, false, System.Text.Encoding.GetEncoding(Pbzx.Common.WebInit.webBaseConfig.Encoding)))
            {
                sw.Write(sb.ToString());
                sw.Close();
            }

            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\Default_Ask.xml");
            XmlNode root = xml.GetXmlRoot();

            XmlNode children = root.SelectSingleNode("/root/children");
            children.RemoveAll();

            ///添加生成时间
            XmlNode myTime = root.SelectSingleNode("/root/CreateTime");

            xml.SetAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
            xml.SaveXmlDocument();
            // 重置标志
            HttpContext.Current.Application["askCreating"] = "0";
            //重定向
            //  HttpContext.Current.Response.Redirect("/index_Ask.htm");
        }

    }
}
