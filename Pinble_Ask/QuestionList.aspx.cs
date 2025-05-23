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
using Maticsoft.DBUtility;
using System.Text;

namespace Pinble_Ask
{
    public partial class QuestionList1 : System.Web.UI.Page
    {
        protected string fTypeName = "";

        protected string[] myChange = new string[5];
        protected string divHead1 = "<div class='f14blackB' style='width:100%; height:100%;background-image:url(images/A_qie1.jpg); '>";
        protected string divFoot1 = "</div>";
        protected string divHead2 = "<div class='f14black2' style='width:100%; height:100%;background-image:url(images/A_qie2.jpg); '><a href='QuestionList.aspx?type=";
        protected string divHead3 = "&parm=";
        protected string divbody2 = "' style='cursor:pointer;'>";
        protected string divFoot2 = "</a></div>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                Bulletin_r1.Count = int.Parse(WebInit.siteconfig.BarBulletin);
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        private void BindData()
        {
            //�󶨵���
            Pbzx.BLL.PBnet_ask_Type typeBLL = new Pbzx.BLL.PBnet_ask_Type();
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                ViewState["type"] = Input.Decrypt(Input.FilterAll(Request["type"]));
                lblLink.Text = typeBLL.ChannelGetNavigation(int.Parse(ViewState["type"].ToString()), true, "&nbsp>>&nbsp");
                fTypeName = typeBLL.GetModel(int.Parse(ViewState["type"].ToString())).TypeName;
                this.Title = fTypeName + "�����б� - ƴ���� - ƴ�����߲���ͨ���";
                dlTypes.DataSource = typeBLL.GetList("FTypeID=" + ViewState["type"].ToString() + " and BitIsAuditing=1 order by OrderID ");
                dlTypes.DataBind();
                switch (Request["parm"])
                {
                    case "1":
                        ChangeSelect(Request["parm"]);
                        break;
                    case "2":
                        ChangeSelect(Request["parm"]);
                        break;
                    case "3":
                        ChangeSelect(Request["parm"]);
                        break;
                    case "4":
                        ChangeSelect(Request["parm"]);
                        break;
                    case "5":
                        ChangeSelect(Request["parm"]);
                        break;
                    default:
                        ChangeSelect("1");
                        break;
                }
                BindQuestions();
            }
            else
            {
                //Response.Redirect(""); 
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        private void BindQuestions()
        {
            //�ظ�ҵ������
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" Auditing=1  and Deleted=0  ");           
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "AskTime desc ";
            int mycount = 0;
            DataTable IsResult = questionBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum,3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }

        /// <summary>
        /// ���÷�ҳ����
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.ask.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        /// <summary>
        /// ��ʾ��ҳ��Ϣ
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>����¼&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        /// <summary>
        /// ҳ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindQuestions();
        }
        private string AddParameter()
        {

            StringBuilder sbType = new StringBuilder();
            if (IsHasChild(ViewState["type"]))
            {
                sbType.Append(" and FTypeID=" + ViewState["type"].ToString() + " ");
            }
            else
            {
                sbType.Append(" and TypeID =" + ViewState["type"].ToString());
            }

            switch (Request["parm"])
            {
                case "1":
                    ChangeSelect(Request["parm"]);
                    break;
                case "2":
                    ChangeSelect(Request["parm"]);
                    sbType.Append(" and State=1 ");                   
                    break;
                case "3":
                    ChangeSelect(Request["parm"]);
                    sbType.Append(" and State=0 ");
                    break;
                case "4":
                    ChangeSelect(Request["parm"]);
                    sbType.Append("and LargessPoint > 0 ");
                    sbType.Append(" and State not in(2) ");
                    break;
                case "5":
                    ChangeSelect(Request["parm"]);
                    sbType.Append(" and Replys=0 ");
                    sbType.Append(" and State not in(2) ");
                    break;
                default:
                    ChangeSelect("1");
                    break;
            }
            return sbType.ToString();
        }

        /// <summary>
        /// ѡ��ı��¼�
        /// </summary>
        /// <returns></returns>
        private void ChangeSelect(string myid)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (i.ToString() == myid)
                {
                    myChange[i - 1] = divHead1 + GetNameById(i.ToString()) + divFoot1;
                }
                else
                {
                    myChange[i - 1] = divHead2 + Request["type"] + divHead3 + i.ToString() + divbody2 + GetNameById(i.ToString()) + divFoot2;
                }
            }
        }

        private string GetNameById(string id)
        {
            switch (id)
            {
                case "1":
                    return "ȫ��";
                case "2":
                    return "�ѽ��";
                case "3":
                    return "�����";
                case "4":
                    return "����";
                case "5":
                    return "��ش�";
                default:
                    return "ȫ��";
            }
        }


        /// <summary>
        /// �õ����������Ϣ
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        protected string GetTypeInfo(object typeId, object typeName)
        {
            StringBuilder sbResult = new StringBuilder();
            //����ҵ�����
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            string count = questionBLL.GetCountByTypeID(typeId.ToString()).ToString();
            string linkA = "<a class='Linl14' href='QuestionList.aspx?type=" + Input.Encrypt(typeId.ToString()) + "'>";
            sbResult.Append(linkA + typeName + "</a>");
            if (IsHasChild(typeId))
            {
                sbResult.Append("&nbsp;" + linkA + "<img src='Add.gif' title='�����ӷ���' />&nbsp;");
            }
            sbResult.Append("&nbsp;(" + count.ToString() + ")");
            return sbResult.ToString();
        }

        /// <summary>
        /// �ж�����Ƿ�����ӷ���
        /// </summary>
        /// <param name="typeId">�����</param>
        /// <returns>�Ƿ����</returns>
        private bool IsHasChild(object typeId)
        {
            int childTypes = (int)DbHelperSQL.GetSingle("SELECT COUNT(1)  FROM PBnet_ask_Type WHERE (FTypeID = " + typeId.ToString() + ") ");
            if (childTypes > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
