using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Pbzx.Common;

namespace Pinble_Chipped.admin
{
    public partial class TrackNum : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_TrackNum get_tn = new Pbzx.BLL.Chipped_TrackNum();
        DataTable IResult = new DataTable();
        Pbzx.BLL.PBnet_LotteryMenu get_lmu = new Pbzx.BLL.PBnet_LotteryMenu();
        Pbzx.BLL.publicMethod get_pm = new Pbzx.BLL.publicMethod();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href ='/LoginPage.aspx'</script>");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                BindTrackNumData();
            }
        }


        //生成序号
        protected void My_GridView_RowCreated(object sender, GridViewRowEventArgs e)
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
        //绑定数据
        public void BindTrackNumData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("tn_username=" + "'" + Method.Get_UserName.ToString() + "'");
            sb.Append(" group by tn_order,tn_username,tn_time,tn_playname");
            string Searchstr = sb.ToString();
            string order = "tn_time desc";
            int myCount = 0;
            IResult = get_tn.GuestGetBySearchTrackNum(Searchstr, "tn_order,tn_username,tn_time,tn_playname", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                My_GridView.DataSource = IResult;
                My_GridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 30;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + My_GridView.Rows.Count.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + My_GridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindTrackNumData();
        }

        //绑定数据时触发的事件
        protected void My_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = Convert.ToInt32(My_GridView.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                //查询彩种
                Label lab_lottery = this.My_GridView.Rows[i].FindControl("lab_lottery") as Label;
                if (Convert.ToInt32(IResult.Rows[i]["tn_playname"]) == 9999)
                {
                    lab_lottery.Text = "排列三";
                }
                else
                {
                    DataSet ds = get_lmu.GetList("IntId=" + Convert.ToInt32(IResult.Rows[i]["tn_playname"]));

                    lab_lottery.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                }

                //已完结
                Label lab_endNum = this.My_GridView.Rows[i].FindControl("lab_endNum") as Label;
                //总期数
                Label lab_totalNum = this.My_GridView.Rows[i].FindControl("lab_totalNum") as Label;

                //
                Label lab_time = this.My_GridView.Rows[i].FindControl("lab_time") as Label;


                //查询总数和已完结数

                //总数
                DataSet ds_ncount = get_pm.Chipped_Table("Chipped_TrackNum", "count(*)", "tn_order=" + "'" + IResult.Rows[i]["tn_order"] + "'");
                //已完结数
                DataSet ds_nendCount = get_pm.Chipped_Table("Chipped_TrackNum", "count(*)", "tn_order=" + "'" + IResult.Rows[i]["tn_order"] + "'" + " and tn_complete=1");

                if (ds_nendCount == null || ds_nendCount.Tables[0].Rows.Count == 0)
                {
                    lab_endNum.Text = "0";
                }
                else
                {
                    lab_endNum.Text = ds_nendCount.Tables[0].Rows[0][0].ToString();
                }

                lab_totalNum.Text = ds_ncount.Tables[0].Rows[0][0].ToString();
            }
        }
    }
}