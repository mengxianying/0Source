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

namespace Pinble_DataRivalry.admin
{
    public partial class UserWinningRecords : System.Web.UI.Page
    {
        Pbzx.BLL.DataRivalry_Rt get_result = new Pbzx.BLL.DataRivalry_Rt();
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                MyGridViewBind();
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        public void MyGridViewBind()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Rt_UserName="+"'"+ Method.Get_UserName.ToString() +"'");
            string Searchstr = sb.ToString();
            string order = "Rt_ID desc";
            int myCount = 0;
            IsResult = get_result.GuestGetBySearchResult(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = IsResult;
            MyGridView.DataKeyNames = new string[] { "Rt_ID" };
            MyGridView.DataBind();
            AspNetPagerConfig(myCount);
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            MyGridViewBind();
        }
    }
}
