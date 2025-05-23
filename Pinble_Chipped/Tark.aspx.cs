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
using Pbzx.BLL;

namespace Pinble_Chipped
{
    public partial class Tark : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_cofig get_cg = new Chipped_cofig();
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        DataSet ds = new DataSet();
        public string name = "";
        public int g_num = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rep_trackingBind();
            }
        }
        /// <summary>
        /// 绑定订制跟单的彩种
        /// </summary>
        public void rep_trackingBind()
        {
            name = Request["name"].ToString();


            //查询允许
            ds = get_cg.GetList("cfg_tarState=0");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.rep_tracking.DataSource = ds;
                this.rep_tracking.DataBind();
            }
            else
            {
                this.rep_tracking.Visible = false;
                lab_Info.Text = "用户暂时没有可订制跟单的彩种";
            }

            //if (playN != 0)
            //{
            //    ds = get_pub.Chipped_Table("Chipped_UserTrack", "*", "ut_Lname=" + "'" + playN + "'" + " and ut_username=" + "'" + name + "'");
            //}
            //else
            //{
            //    ds = get_pub.Chipped_Table("Chipped_UserTrack", "*", "ut_username=" + "'" + name + "'");
            //}
            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    this.rep_tracking.DataSource = ds;
            //    this.rep_tracking.DataBind();
            //}
            //else
            //{
            //    this.rep_tracking.Visible = false;
            //    lab_Info.Text = "用户暂时没有可订制跟单的彩种";
            //}
        }

        protected void rep_tracking_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            g_num = this.rep_tracking.Items.Count;
            foreach (RepeaterItem RI in this.rep_tracking.Items)
            {
                //判断跟单是否已满（允许1000人跟单） 人数满了不允许点击


                //声明控件
                Label lab_lotteryName = RI.FindControl("lab_lotteryName") as Label;
                Label lab_allMoney = RI.FindControl("lab_allMoney") as Label;
                Label lab_trackingNum = RI.FindControl("lab_trackingNum") as Label;

                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["cfg_state"]) == 9999)
                {
                    lab_lotteryName.Text = "排列3";
                }
                else
                {
                    DataSet ds_lot = get_pub.Chipped_Table("PBnet_LotteryMenu", "NvarName", "IntId=" + Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["cfg_state"]));
                    if (ds_lot != null && ds_lot.Tables[0].Rows.Count > 0)
                    {

                        lab_lotteryName.Text = ds_lot.Tables[0].Rows[0]["NvarName"].ToString();
                    }
                    else
                    {
                        lab_lotteryName.Text = "";
                    }
                }
                //中奖总金额
                DataSet dsWinning = get_pub.Chipped_Table("PlatformPublic_payments", "sum(Pp_data)", "Pp_name=" + "'" + name + "'" + " and Pp_belongs='Chipped'" + " and Pp_LotName=" + Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["cfg_state"]));
                if (dsWinning.Tables[0].Rows[0][0].ToString() == "" || dsWinning.Tables[0].Rows[0][0] == null)
                {
                    lab_allMoney.Text = "0";
                }
                else
                {
                    lab_allMoney.Text = dsWinning.Tables[0].Rows[0][0].ToString();
                }
                DataSet dsTracking = get_pub.Chipped_Table("Chipped_TrackingOrders", "count(*)", "UserN=" + "'" + name + "'");
                lab_trackingNum.Text = dsTracking.Tables[0].Rows[0][0].ToString();

            }
        }
    }
}
