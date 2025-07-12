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
                this.litContent.Text = "<b>抱歉！<p/><br/>没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        /// <summary>
        /// 配置分页参数
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.ask.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        /// <summary>
        /// 显示分页信息
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条记录&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页共计<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条记录&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        /// <summary>
        /// 页码改变事件
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
                    lblLink.Text ="精华推荐";
                    lbltitle.Text = "精华推荐";
                    this.Title = "精华推荐问题列表 - 拼搏吧 - 拼搏在线彩神通软件";                    
                }
                else if (Request["strTag"] == "Hot")
                {
                   
                    bu.Append(" "+ Method.CheckQuestionHot(true)+" ");
                    lblLink.Text = "近期热点";
                    lbltitle.Text = "近期热点";
                    this.Title = "近期热点问题列表 - 拼搏吧 - 拼搏在线彩神通软件"; 
                }
                else if (Request["strTag"] == "High")
                {
                    bu.Append(" and LargessPoint >'0' and State not in(2)");
                    lblLink.Text = "高悬赏问题";
                    lbltitle.Text = "高悬赏问题";
                    this.Title = "高悬赏问题列表 - 拼搏吧 - 拼搏在线彩神通软件"; 
                }
            }
            if (!string.IsNullOrEmpty(Request["strSate"]))
            {
                if (Request["strSate"] == "0") 
                {
                    bu.Append(" and State=0");
                    lblLink.Text = "待解决的问题";
                    lbltitle.Text = "待解决的问题";
                    this.Title = "待解决的问题列表 - 拼搏吧 - 拼搏在线彩神通软件"; 
                }
                else if (Request["strSate"] == "1")
                {
                    bu.Append(" and State=1");
                    lblLink.Text = "新解决的问题";
                    lbltitle.Text = "新解决的问题";
                    this.Title = "新解决的问题列表 - 拼搏吧 - 拼搏在线彩神通软件"; 
                }
            }
            return bu.ToString();
        }
    }
}
