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
using System.Text;

namespace Pinble_Ask
{
    public partial class SearchList : System.Web.UI.Page
    {
        protected string[] myChange = new string[3];
        private string divHead = "<div class='As_list_qie1bg'>";//style='width:100%; height:100% 
        private string divHead1 = "<div class='As_list_qie2bg'>";
        private string divfoot = "</div>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // BindJFBang();
                BindData();
            }
        }
        private void BindData()
        {
            if (!string.IsNullOrEmpty(Request["searchKey"]))
            {
                ViewState["key"] = Input.Decrypt(Input.FilterAll(Request["searchKey"]));
                BindQuestions();
            }
        }

        /// <summary>
        /// ѡ��ı�÷���
        /// </summary>
        /// <returns></returns>
        private void ChangeSelect(string myid)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (i.ToString() == myid)
                {
                    myChange[i - 1] = divHead + GetNameById(i.ToString()) + divfoot;
                }
                else
                {
                    myChange[i - 1] = divHead1 + "<a href='SearchList.aspx?searchKey=" + Request["searchKey"] + "&parm=" + i.ToString() + "' style='cursor:pointer;'>" + GetNameById(i.ToString()) + "</a>" + divfoot;
                }
            }
        }

        /// <summary>
        /// ����ID�õ�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetNameById(string id)
        {
            switch (id)
            {
                case "1":
                    return "ȫ��";
                case "2":
                    return "�ѽ������";
                case "3":
                    return "���������";
                default:
                    return "ȫ��";
            }
        }

        /// <summary>
        /// ��ʽ����ѻش�����Ϣ
        /// </summary>
        /// <param name="answerID"></param>
        /// <param name="answerer"></param>
        /// <returns></returns>
        protected string GetBestAnswer(object answerID, object answerer)
        {
            string result = "";
            if (answerID != null && answerID.ToString().Trim() != "")
            {
                result = "-��ѻش��ߣ�<a href='UserInfo.aspx?user=" + Input.Encrypt(answerID.ToString()) + "' target='_blank' class='Link_Xia'>" + answerer + "</a>";
            }
            else
            {
                return "";
            }
            return result;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="objType"></param>
        /// <returns></returns>
        protected string GetNavigation(object objType)
        {
            Pbzx.BLL.PBnet_ask_Type typeBLL = new Pbzx.BLL.PBnet_ask_Type();
            if (objType != null && objType.ToString().Trim() != "")
            {
                return "-" + typeBLL.ChannelGetNavigation(int.Parse(objType.ToString()), false, "&nbsp>>&nbsp");
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// �������б�
        /// </summary>
        private void BindQuestions()
        {
            switch (Request["parm"])
            {
                case "1":
                    ChangeSelect("1");
                    break;
                case "2":
                    ChangeSelect("2");
                    break;
                case "3":
                    ChangeSelect("3");
                    break;
                default:
                    ChangeSelect("1");
                    break;
            }
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and Deleted=0 ");
            bu.Append(" and State !=3 ");
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "AskTime desc ";
            int mycount = 0;
            DataTable IsResult = questionBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out mycount);
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
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {

            StringBuilder sbType = new StringBuilder();
            if (ViewState["key"] != null)
            {
                string[] keys = ViewState["key"].ToString().Split(new char[] { ' ' });
                StringBuilder sb = new StringBuilder("");
                foreach (string temp in keys)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {

                        sb.Append("or Title like'%" + temp.Replace("'", "") + "%' or Content LIKE '%" + temp.Replace("'", "") + "%' ");
                    }
                }

                if (sb.Length > 3)
                {

                    sbType.Append(" and ( " + sb.ToString().Substring(2) + ") ");
                }
            }

            switch (Request["parm"])
            {
                case "2":
                    sbType.Append(" and state=1 ");
                    break;
                case "3":
                    sbType.Append(" and State=0 ");
                    break;
                default:
                    break;
            }
            return sbType.ToString();
        }



        /// <summary>
        /// ��ʽ������
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        protected string FormartTitle(object title)
        {
            string result = "";
            if (title != null)
            {
                result = title.ToString();
                string[] keys = ViewState["key"].ToString().Split(new char[] { ' ' });
                StringBuilder sb = new StringBuilder("");
                foreach (string temp in keys)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        result = result.Replace(temp, "<font color='red'>" + temp + "</font>");
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// ��ʽ������
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        protected string FormartContent(object content)
        {
            string result = "";
            if (content != null)
            {
                result = content.ToString();
                string[] keys = ViewState["key"].ToString().Split(new char[] { ' ' });
                StringBuilder sb = new StringBuilder("");
                foreach (string temp in keys)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        result = result.Replace(temp, "<font color='red'>" + temp + "</font>");
                    }
                }
            }
            return result;
        }


        ///// <summary>
        ///// ���ְ󶨵�һ��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex != -1)
        //    {
        //        int id = e.Row.RowIndex + 1;

        //        e.Row.Cells[1].Text = "<a href='UserShow.aspx?name=" + Input.Encrypt(GridView1.DataKeys[e.Row.RowIndex]["ID"].ToString()) + "' target='_blank'><img src=\"images/N" + id.ToString() + ".jpg\" width=\"15\" height=\"12\" border='0' />" + "</a>";
        //    }
        //}

        /// <summary>
        /// �󶨻�������
        /// </summary>
        private void BindJFBang()
        {
            //Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            //this.GridView1.DataSource = userBLL.Query(" select top 8 * from PBnet_ask_User  order by Point desc ");
            //this.GridView1.DataBind();
        }


    }
}



