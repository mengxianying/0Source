using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Pinble_Chipped.admin
{
    public partial class Customized : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_LaunchInfoManage get_lo = new Pbzx.BLL.Chipped_LaunchInfoManage();
        Pbzx.BLL.publicMethod get_pd = new Pbzx.BLL.publicMethod();
        Pbzx.BLL.Chipped_TrackingOrders get_ts = new Pbzx.BLL.Chipped_TrackingOrders();
        DataTable IResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取合买订单发起人的用户名
                string name = Request["name"].ToString();
                //获取彩种编号
                int n_playID = Convert.ToInt32(Request["tNum"]);
                //获取定制跟单信息表ID
                int n_id = Convert.ToInt32(Request["id"]);

                DataSet ds_ts = get_ts.GetList("TrackingID=" + n_id);

                //发起人
                lab_name.Text = name;
                //每次认购
                lab_buy.Text = Convert.ToDecimal(ds_ts.Tables[0].Rows[0]["BuyMoney"]).ToString("￥#,##0.00");
                lab_TotalAmount.Text = (Convert.ToDecimal(ds_ts.Tables[0].Rows[0]["BuyMoney"]) * Convert.ToInt32(ds_ts.Tables[0].Rows[0]["SubscribeNum"])).ToString("￥#,##0.00");
                //认购时间
                lab_time.Text = Convert.ToDateTime(ds_ts.Tables[0].Rows[0]["TrackingTime"]).ToString("yyyy-mm-dd hh:mm:ss");

                //已认购的次数
                lab_buyNum.Text = ds_ts.Tables[0].Rows[0]["TrackingN"].ToString();


                //剩余次数
                int n_num = Convert.ToInt32(ds_ts.Tables[0].Rows[0]["SubscribeNum"]) - Convert.ToInt32(ds_ts.Tables[0].Rows[0]["TrackingN"]);
                lab_Surplus.Text = n_num.ToString();

                //定制的单号
                DataSet ds_order = get_pd.Chipped_Table("Chipped_LaunchInfo", "top 1 QNumber", "UserName=" + "'" + name + "'" + " and playName=" + n_playID);
                if (ds_order != null && ds_order.Tables[0].Rows.Count > 0)
                {
                    lab_orderNum.Text = ds_order.Tables[0].Rows[0]["QNumber"].ToString();
                }
                BindMy_GridView();
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
            //获取合买订单发起人的用户名
            string name = Request["name"].ToString();
            //获取彩种编号

            int n_playID = Convert.ToInt32(Request["tNum"]);

            StringBuilder sb = new StringBuilder();
            sb.Append("UserName=" + "'" + name + "'");
            sb.Append(" and playName=" + n_playID);

            string Searchstr = sb.ToString();
            string order = "LaunchTime desc";
            int myCount = 0;
            IResult = get_lo.GuestGetBySearchChipped(Searchstr, "QNumber,playName,UserName,State,bounsAllost,LaunchTime", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
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
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + My_GridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMy_GridView();
        }

        protected void My_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < this.My_GridView.Rows.Count; i++)
            {
                //彩种名称
                Label lab_lotter = this.My_GridView.Rows[i].Cells[0].FindControl("lab_lotter") as Label;
                //方案进度
                Label lab_speed = this.My_GridView.Rows[i].Cells[0].FindControl("lab_speed") as Label;
                string n_plan = get_pd.percent(IResult.Rows[i]["QNumber"].ToString());
                lab_speed.Text = n_plan + "%";

                //方案状态
                Label lab_SState = this.My_GridView.Rows[i].Cells[0].FindControl("lab_SState") as Label;

                //查询彩种
                if (Convert.ToInt32(IResult.Rows[i]["playName"]) == 9999)
                {
                    lab_lotter.Text = "排列3";
                }
                else
                {
                    DataSet ds = get_pd.Chipped_Table("PBnet_LotteryMenu", "NvarName", "IntId=" + Convert.ToInt32(IResult.Rows[i]["playName"]));
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        lab_lotter.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                    }
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 2)
                {
                    lab_SState.Text = "已退款";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 1)
                {
                    lab_SState.Text = "已出票";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 0)
                {
                    lab_SState.Text = "进行中";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 3)
                {
                    lab_SState.Text = "未出票";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 4)
                {
                    lab_SState.Text = "订单失败,等待退款";
                }
                

            }
        }
    }
}