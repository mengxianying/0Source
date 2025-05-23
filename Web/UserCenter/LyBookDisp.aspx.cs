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

namespace Pbzx.Web.UserCenter
{
    public partial class LyBookDisp : System.Web.UI.Page
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
            Pbzx.BLL.PBnet_LyBook tpmanBLL = new Pbzx.BLL.PBnet_LyBook();
            StringBuilder bu = new StringBuilder();

            bu.Append(" 1=1 and LyUserName='" + Method.Get_UserName + "' ");
            bu.Append(this.AddParameter());
            string strCount = bu.ToString();
            ///////////////////////////////////////////////////////////////////////////////////

            string Searchstr = bu.ToString();
            string order = "LyLogTime desc ";
            int myCount = 0;

            DataTable lsResult = tpmanBLL.GuestGetBySearch(Searchstr, "*", order, 20,3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }


        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条记录&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页共计<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条记录&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }


        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int SystemNumber = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + SystemNumber).ToString() + ")";
            }
           
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();


            if (!string.IsNullOrEmpty(Request["strState"]))
            {
                bu1.Append(" and LyState='" + Input.FilterAll(Request["strState"]) + "'");
            }
            if (!string.IsNullOrEmpty(Request["strType"]))
            {
                bu1.Append(" and LySort='" + Input.FilterAll(Request["strType"]) + "'");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {

                bu1.Append(" and LyLogTime between '" + Input.FilterAll(Request["strCreateTime1"].Trim()) + "' and '" + DateTime.Parse(Input.FilterAll(Request["strCreateTime2"])).AddDays(1).ToShortDateString() + "'  ");
               
            }
            return bu1.ToString();
        }
    }
}
