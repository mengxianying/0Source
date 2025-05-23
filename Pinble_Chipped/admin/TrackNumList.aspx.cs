using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pinble_Chipped.admin
{
    public partial class TrackNumList : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_TrackNum get_tn = new Pbzx.BLL.Chipped_TrackNum();
        DataTable IResult = new DataTable();
        Pbzx.BLL.publicMethod get_pm = new Pbzx.BLL.publicMethod();
        Pbzx.BLL.PBnet_LotteryMenu get_lmu = new Pbzx.BLL.PBnet_LotteryMenu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                string orderNum=Request["orderNum"].ToString();
                //订单号
                lab_orderNum.Text = orderNum;
                DataSet ds_time = get_pm.Chipped_Table("Chipped_TrackNum", "top 1 tn_time", "tn_order=" + "'" + orderNum + "'"+" order by tn_Id desc");
                lab_time.Text = ds_time.Tables[0].Rows[0][0].ToString();

                //总金额
                DataSet ds_money = get_pm.Chipped_Table("Chipped_TrackNum", "sum(tn_money)", "tn_order=" + "'" + orderNum + "'");
                lab_TotalAmount.Text = ds_money.Tables[0].Rows[0][0].ToString();

                BindMy_GridView();

                //共多少期
                lab_Intotal.Text = IResult.Rows.Count.ToString();

                //完成期数
                DataSet ds_Complete = get_pm.Chipped_Table("Chipped_TrackNum", "count(*)", "tn_order=" + "'" + orderNum + "'" + " and tn_complete=1");
                lab_Complete.Text = ds_Complete.Tables[0].Rows[0][0].ToString();
            }
        }

        //自定义序号
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
        public void BindMy_GridView()
        {
            string orderNum=Request["orderNum"].ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append("tn_order=" + "'" + orderNum + "'");
         
            string Searchstr = sb.ToString();
            string order = "tn_time desc";
            int myCount = 0;
            IResult = get_tn.GuestGetBySearchTrackNum(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);
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
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + My_GridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMy_GridView();
        }

        //绑定控件时触发的事件
        protected void My_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.My_GridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //状态
                Label lab_state = this.My_GridView.Rows[i].FindControl("lab_state") as Label;
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 1)
                {
                    lab_state.Text = "已出票";
                }
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 0)
                {
                    lab_state.Text = "等待追号";
                }
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 2)
                {
                    lab_state.Text = "已终止";
                }
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 3)
                {
                    lab_state.Text = "追号失败";
                }
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 4)
                {
                    lab_state.Text = "出票中";
                }
                //中奖信息
                Label lab_info = this.My_GridView.Rows[i].FindControl("lab_info") as Label;
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 1 && IResult.Rows[i]["tn_Inward"].ToString() =="0")
                {
                    lab_info.Text = "未中奖";
                }
                
                if (Convert.ToInt32(IResult.Rows[i]["tn_complete"]) == 1 && IResult.Rows[i]["tn_Inward"].ToString() == "")
                {
                    lab_info.Text = "等待开奖";
                }
                
                //开奖号
                Label lab_ln = this.My_GridView.Rows[i].FindControl("lab_ln") as Label;

                DataSet ds_lmu = new DataSet();
                if (Convert.ToInt32(IResult.Rows[i]["tn_playname"]) == 9999)
                {
                    ds_lmu = get_pm.Chipped_Table("PBnet_LotteryMenu", "NvarApp_name", "IntId=4");
                }
                else
                {
                    ds_lmu = get_pm.Chipped_Table("PBnet_LotteryMenu", "NvarApp_name", "IntId=" + Convert.ToInt32(IResult.Rows[i]["tn_playname"]));
                }
                 
                try
                {
                    string lotteryNum = get_pm.RlotteryNum(ds_lmu.Tables[0].Rows[0][0].ToString(), Convert.ToInt32(IResult.Rows[i]["tn_playname"]), Convert.ToInt32(IResult.Rows[i]["tn_issue"]));
                    if (lotteryNum == "")
                    {
                        lab_ln.Text = "";
                    }
                    else
                    {
                        lab_ln.Text = lotteryNum;
                    }
                }
                catch { }

                

                
            }
        }

     

    }
}