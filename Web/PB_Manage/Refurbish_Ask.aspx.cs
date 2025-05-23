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
        /// ���ⳤ��
        /// </summary>
        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count = 8;
        /// <summary>
        /// ��ʾ����������
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";
        /// <summary>
        /// �����������
        /// </summary>
        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }

        private string _isHot = "";
        /// <summary>
        /// �Ƿ�����,1�����ȵ㣬0�������ȵ㣬 Ĭ��Ϊ�ȵ�����ȵ���
        /// </summary>
        public string IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }

        private string _state = "0";
        /// <summary>
        /// ״̬��0-�������1-�ѽ����2-�ѹرա�Ĭ�ϻ��߿��ַ���-���
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        private string _isCommend = "";
        /// <summary>
        /// �Ƿ��Ǿ����Ƽ���1���Ƽ� 0�����Ƽ���Ĭ��Ϊ��ϣ�
        /// </summary>
        public string IsCommend
        {
            get { return _isCommend; }
            set { _isCommend = value; }
        }

        private string _isHighLargessPoint = "";
        /// <summary>
        /// �Ƿ��Ǹ��������⣨1���� 0�����ǣ�Ĭ��Ϊ��ϣ�
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
        /// ������
        /// </summary>
        public void BindData()
        {
            DataTable dtData = null;
            //�Ƿ����ȵ�
            string strHot = "";
            if (IsHot == "1")
            {

                strHot = Method.CheckQuestionHot(true);
            }
            else if (IsHot == "0")
            {
                strHot = Method.CheckQuestionHot(false);
            }

            //״̬���������δ������ѹرգ�
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

            //�Ƿ��Ƽ�
            string strCommend = "";
            if (IsCommend == "0")
            {
                strCommend = "and IsCommend=0 ";
            }
            else if (IsCommend == "1")
            {
                strCommend = "and IsCommend=1 ";
            }

            //�Ƿ��Ǹ���������
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




            //ƴ���ַ���
            StringBuilder sb = new StringBuilder();
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head> <title>ƴ������-ƴ����-��������</title> <link href=\"/css/css.css\" rel=\"stylesheet\" type=\"text/css\" /></head><body>");
            sb.Append("<div  id=\"dvContent\" style=\"background-color:White;\" >");
            sb.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");

            foreach (DataRow row in dtData.Rows)
            {
                string fullName = row["Title"].ToString();
                string strID = Input.Encrypt(row["Id"].ToString());
                string id = row["Id"].ToString();
                sb.Append("<tr><td align='left'>��<a href='" + WebInit.ask.WebUrl + "Question.aspx?question=" + strID + "' target='_blank' title='" + fullName + "' >" + StrFormat.CutStringByNum(fullName, TitleLength, " ") + "</a></td></tr>");
            }
            sb.Append("</table></div></body></html>");

            //д���ļ�
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

            ///�������ʱ��
            XmlNode myTime = root.SelectSingleNode("/root/CreateTime");

            xml.SetAttribute("/root/CreateTime", "time", DateTime.Now.ToString());
            xml.SaveXmlDocument();
            // ���ñ�־
            HttpContext.Current.Application["askCreating"] = "0";
            //�ض���
            //  HttpContext.Current.Response.Redirect("/index_Ask.htm");
        }

    }
}
