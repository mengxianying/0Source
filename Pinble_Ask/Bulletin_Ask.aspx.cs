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

namespace Pinble_Ask
{
    public partial class Bulletin_Ask : System.Web.UI.Page
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
            Pbzx.BLL.PBnet_Bulletin MyBLL = new Pbzx.BLL.PBnet_Bulletin();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1");
            bu.Append(this.AddParameter());
            bu.Append(" and IntChannelID=13");
           
            string Searchstr = bu.ToString();
            string order = "DatDateAndTime desc ";
            int mycount = 0;
            DataTable IsResult = MyBLL.GuestGetBySearch(Searchstr, "*", order, 19,3, AspNetPager1.CurrentPageIndex, out mycount);
            this.RptList.DataSource = IsResult;
            this.RptList.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 19;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>����¼&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + RptList.Items.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            //if (!string.IsNullOrEmpty(Request["Search"]))
            //{
            //    bu1.Append(" and NvarTitle like '%" + Input.FilterAll(Request["Search"]) + "%'");
            //}
            return bu1.ToString();
        }
    }
}
