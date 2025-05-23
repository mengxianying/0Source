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

namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_Type : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_ask_Type MyBll = new Pbzx.BLL.PBnet_ask_Type();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1");
            //bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            //string order = "RootID,Depth,FTypeID,TypeID";
            int myCount = 0;

            DataTable lsResult = MyBll.GetListBySort(1);
                
           //MyBll.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, false, AspNetPager1.CurrentPageIndex, out myCount);




            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
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
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
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
        BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();


            //if (!string.IsNullOrEmpty(Request["IntShowType"]))
            //{
            //    bu.Append(" and IntShowType =" + Request["IntShowType"] + " ");
            //}
            //if (!string.IsNullOrEmpty(Request["regedit"]))
            //{
            //    bu.Append(" and DatDateAndTime between dateAdd(day," + this.Request["regedit"].ToString() + ",getdate()) and getdate()  ");
            //}
            //if (!string.IsNullOrEmpty(Request["NvarTitle"]))
            //{
            //    bu.Append(" and NvarTitle like '%" + Request["NvarTitle"] + "%' ");
            //}
            return bu.ToString();

        }

        protected string showModule(object mName, object mDepth)
        {
            int depth = Convert.ToInt32(mDepth);
            string name = mName.ToString();
            if (depth == 0)
            {
                name = "<b>" + name + "</b>";
            }
            else
            {
                name = "├─" + name;
            }
            return name;
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }
        protected void lbtnIsAuditing_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_ask_Type.ChangeAudit(id, "BitIsAuditing");
            BindData();
        }
    }
}
