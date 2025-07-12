using System;
using System.Data;
using System.Web.UI;
using System.Text;
using Pbzx.Common;

namespace Pinble_Ask
{
    public partial class QuestionListOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" Auditing=1  and Deleted=0  ");
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "AskTime desc";
            int mycount = 0;
            DataTable IsResult = questionBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum, 3, AspNetPager1.CurrentPageIndex ,out mycount);
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
            BindData();
            //Response.Redirect();            
        }
        private string AddParameter()
        {

            StringBuilder bu = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["strTag"]))
            {
                if (Request["strTag"] == "Commend")
                {
                    bu.Append(" and IsCommend=1 and State not in(2)");
                    lblLink.Text ="�����Ƽ�";
                    lbltitle.Text = "�����Ƽ�";
                    this.Title = "�����Ƽ������б� - ƴ���� - ƴ�����߲���ͨ���";                    
                }
                else if (Request["strTag"] == "Hot")
                {
                   
                    bu.Append(" "+ Method.CheckQuestionHot(true)+" ");
                    lblLink.Text = "�����ȵ�";
                    lbltitle.Text = "�����ȵ�";
                    this.Title = "�����ȵ������б� - ƴ���� - ƴ�����߲���ͨ���"; 
                }
                else if (Request["strTag"] == "High")
                {
                    bu.Append(" and LargessPoint >'0' and State not in(2)");
                    lblLink.Text = "����������";
                    lbltitle.Text = "����������";
                    this.Title = "�����������б� - ƴ���� - ƴ�����߲���ͨ���"; 
                }
            }
            if (!string.IsNullOrEmpty(Request["strSate"]))
            {
                if (Request["strSate"] == "0") 
                {
                    bu.Append(" and State=0");
                    lblLink.Text = "�����������";
                    lbltitle.Text = "�����������";
                    this.Title = "������������б� - ƴ���� - ƴ�����߲���ͨ���"; 
                }
                else if (Request["strSate"] == "1")
                {
                    bu.Append(" and State=1");
                    lblLink.Text = "�½��������";
                    lbltitle.Text = "�½��������";
                    this.Title = "�½���������б� - ƴ���� - ƴ�����߲���ͨ���"; 
                }
            }
            return bu.ToString();
        }
    }
}
