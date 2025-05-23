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

namespace Pbzx.Web
{
    public partial class News_list : System.Web.UI.Page
    {
        public string TypeName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindClass();
                if (!string.IsNullOrEmpty(Input.FilterAll(Request["BitIsHot"])))
                {
                    lblTypeName.Text = "热点推荐";
                }
                News_Hot1.Count = int.Parse(WebInit.pageConfig.NewsNewUpdateCount);
                News_Hot2.Count = int.Parse(WebInit.pageConfig.NewsNewHotCount);

                this.Title = lblTypeName.Text + "列表_新闻资讯_拼搏在线彩神通软件";
            }
        }
        private void BindClass()
        {
            Pbzx.BLL.PBnet_NewsType TypeBll = new Pbzx.BLL.PBnet_NewsType();
            Pbzx.Model.PBnet_NewsType TypeModel;
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["NewsType"])))
            {
                TypeModel = TypeBll.GetModel(int.Parse(Input.FilterAll(Input.Decrypt(Request["NewsType"]))));
                lblTypeName.Text = TypeModel.VarTypeName;
            }
            else
            {
                lblTypeName.Text = "最新资讯";
            }

        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_News MyBLL = new Pbzx.BLL.PBnet_News();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(" and IntChannelID=3");
            bu.Append(" and BitIsPass=1");
            bu.Append(this.AddParameter());         
            string Searchstr = bu.ToString();
            string order = "DatDateAndTime desc";
            int myCount = 0;

            DataTable lsResult = new Pbzx.BLL.PBnet_News().GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.rpt_list.DataSource = lsResult;
            this.rpt_list.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum2;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            //AspNetPager1.CustomInfoHTML += "本页共计<font color=\"red\"><b>" + rpt_list.Items.Count + "</b></font>条记录&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
           
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["Title"])))
            {
                bu1.Append("NvarTitle like '% " + Input.FilterAll(Input.Decrypt(Request["Title"])) + " %'");
            }
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["BitIsHot"])))
            {
               if(Input.FilterAll(Input.Decrypt(Request["BitIsHot"]))=="1")
               {
                   bu1.Append(Method.CheckNewsHot(true));
               }
               else
               {
                    bu1.Append(Method.CheckNewsHot(false));
               }
            }
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["NewsType"])))
            {

                bu1.Append(" and IntShowType=" + Input.FilterAll(Input.Decrypt(Request["NewsType"])) + " ");
            }
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["Search"])))
            {
                string result = Input.FilterAll(Input.Decrypt(Request["Search"]));
                if(result.Length > 0)
                {
                    bu1.Append(" and NvarTitle like '%" + result + "%' ");
                }                
            }
            return bu1.ToString();
        }
    }
}
