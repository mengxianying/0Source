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
    public partial class Agent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {            
            Pbzx.BLL.AgentInfo MyBLL = new Pbzx.BLL.AgentInfo();
            StringBuilder bu = new StringBuilder();
            
            bu.Append(" 1=1 ");
            bu.Append(" and Status=1");
            bu.Append(" and delshow=1");
            bu.Append(" and ExpireDate>getdate()");
            bu.Append(this.AddParameter());         

            string Searchstr = bu.ToString();
            string order = "Province asc ";
            int myCount = 0;
            DataTable lsResult = new Pbzx.BLL.AgentInfo().GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.rptList.DataSource = lsResult;
            this.rptList.DataBind();
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
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>����¼&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + rptList.Items.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            //Response.Write("zhi==" + Input.Decrypt(Request["province"]));
            //Response.End();
            StringBuilder bu1 = new StringBuilder();           
            if (!string.IsNullOrEmpty(Request["province"]))
            { 
              string result = Request["province"];
              result= Input.FilterAll(result);
              result= Input.Decrypt(result);
          
              bu1.Append(" and Province like '%" +result + "%'");
            }
            return bu1.ToString();
        }

    }
}

