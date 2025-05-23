using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pinble_Chipped
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataTable IsResult = new DataTable();
        Pbzx.BLL.Chipped_LaunchInfoManage get_info = new Pbzx.BLL.Chipped_LaunchInfoManage();

        protected void Page_Load(object sender, EventArgs e)
        {

           Response.Write(Method.GetXmlLottoryByValue(1, 1));
            //if (!IsPostBack)
            //{
            //    BindGridView();
            //}
        }
        //绑定数据
        public void BindGridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Winning='Win'");
            sb.Append(" and bounsAllost='FirstPrize' or bounsAllost='TwoPrize' or bounsAllost='ThreePrize'");
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult = get_info.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.GridView1.DataSource = IsResult;
            this.GridView1.DataBind();
            AspNetPagerConfig(mycount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            //重新绑定数据
            BindGridView();
        }
        /// <summary>
        /// 自动排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //分配双色球奖金
            DataSet ds = get_info.GetList("playName=3");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //处理一等奖
                if (ds.Tables[0].Rows[i]["bounsAllost"].ToString() == "FirstPrize")
                {
                    //中一等奖 分配奖金

                }
            }

        }

        /// <summary>
        /// 中奖分配
        /// </summary>
        /// <param name="BMoney">中奖金额</param>
        /// <param name="OrderNum">订单编号</param>
        /// <returns></returns>
        public static bool BonusD(decimal BMoney, string OrderNum)
        {
            //根据订单编号查询数据
            Pbzx.BLL.Chipped_LaunchInfoManage get_in = new Pbzx.BLL.Chipped_LaunchInfoManage();
            DataSet ds = get_in.GetList("QNumber=" + "'" + OrderNum + "'");

            return false;
        }

        /// <summary>
        /// 七乐彩分配奖金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 七星彩分配奖金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 大乐透分配奖金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 22选5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {

        }

    }
}