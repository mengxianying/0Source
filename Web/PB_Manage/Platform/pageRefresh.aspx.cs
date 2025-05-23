using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Pbzx.Web.PB_Manage.Platform
{
    public partial class pageRefresh : AdminBasic
    {
        DataTable IResult = new DataTable();
        Pbzx.BLL.Challenge_config get_cg = new BLL.Challenge_config();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMy_GridView();
            }
        }

        /// <summary>
        /// 绑定我的购彩记录
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            string order = "CTime desc";
            int myCount = 0;
            IResult = get_cg.GuestGetBySearchconfig(Searchstr, "*", order, 60, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                MyGridView.DataSource = IResult;
                MyGridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 60;
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
            BindMy_GridView();
        }

        /// <summary>
        /// 序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }

        /// <summary>
        /// 绑定时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.MyGridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Label lab_attName = this.MyGridView.Rows[i].Cells[0].FindControl("lab_attName") as Label;
                if (IResult.Rows[i]["attState"].ToString() == "pblt")
                {
                    lab_attName.Text = "拼搏擂台";
                }
                if (IResult.Rows[i]["attState"].ToString() == "ddbp")
                {
                    lab_attName.Text = "大底比拼";
                }
                if (IResult.Rows[i]["attState"].ToString() == "hmdg")
                {
                    lab_attName.Text = "合买代购";
                }
            }
        }
    }
}