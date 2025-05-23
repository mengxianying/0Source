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

namespace Pinble_Chat
{
    public partial class Chat_Bulletin_list : System.Web.UI.Page
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
            bu.Append("1=1");
            
            bu.Append(" and IntChannelID=10");
           
            bu.Append(" and BitIsPass=1");
           // bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "BitIsTop desc,DatDateAndTime desc";
            int myCount = 0;

            DataTable lsResult = new Pbzx.BLL.PBnet_Bulletin().GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex,out myCount);
            this.rpt_list.DataSource = lsResult;
            this.rpt_list.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
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
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum2;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
         //  AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + rpt_list.Items.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
