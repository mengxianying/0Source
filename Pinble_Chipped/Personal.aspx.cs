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
    public partial class Personal : System.Web.UI.Page
    {
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        DataSet ds = new DataSet();
        DataSet ds_pp = new DataSet();
        DataSet dsDataList = new DataSet();
        public string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                name = Request["name"].ToString();
                personInfo();
                rep_dynamicBind();
                
                rep_ppBind();
                dl_historyBind();
                
            }
        }

        //个人信息
        public void personInfo()
        {
            //设置奖名称 
            //DataSet dsWin = get_pub.Chipped_Table("v_Winning", "top 1 bonus", "UserName=" + "'" + name + "'" + " and Purchasing=2 and State=1 order by bonus desc");
            DataSet dsWin = get_pub.Chipped_Table("PlatformPublic_UserWinning", "top 1 u_Monery", "u_name=" + "'" + name + "'" + " and u_platform='Chipped' order by u_Monery desc");
            if (dsWin != null && dsWin.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 10000000)
                {
                    lab_winName.Text = "千万大奖得主";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 1000000)
                {
                    lab_winName.Text = "百万大奖得主";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 100000)
                {
                    lab_winName.Text = "十万大奖得主";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 10000)
                {
                    lab_winName.Text = "万元大奖得主";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 1000)
                {
                    lab_winName.Text = "千元大奖得主";
                }
                else
                {
                    lab_winName.Text = "暂时未或千元以上大奖";
                }
            }
            else
            {
                lab_winName.Text = "暂时未千元以上大奖";
            }
            
            //个人的用户名
            lab_UserName.Text = name;
            
            //发单次数
            DataSet dsNum = get_pub.Chipped_Table("Chipped_LaunchInfo", "count(*)", "UserName=" + "'" + name + "'");
            lab_num.Text = dsNum.Tables[0].Rows[0][0].ToString();

            //发单成功率
            DataSet dsSuccess = get_pub.Chipped_Table("Chipped_LaunchInfo", "count(*)", "UserName=" + "'" + name + "'" + " and State=1");
            lab_success.Text = Convert.ToString(Convert.ToInt32(Convert.ToInt32(dsSuccess.Tables[0].Rows[0][0])/Convert.ToInt32(dsNum.Tables[0].Rows[0][0])*100)) +"%";

            //最近中奖


        }


        /// <summary>
        /// 绑定最新动态 发起
        /// </summary>
        public void rep_dynamicBind()
        {
            ds = get_pub.Chipped_Table("Chipped_LaunchInfo", "top 3 *", "UserName=" + "'" + name + "'" + " order by LaunchTime desc");
            this.rep_dynamic.DataSource = ds;
            this.rep_dynamic.DataBind();
        }
        /// <summary>
        /// 最新动态的绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rep_dynamic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            foreach (RepeaterItem RI in this.rep_dynamic.Items)
            {
                Label lab_Lname = RI.FindControl("lab_Lname") as Label;
                //查询对应的彩种
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 1)
                { 
                    //3D
                    lab_Lname.Text = "福彩3D";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 3)
                {
                    lab_Lname.Text = "双色球";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 2)
                {
                    lab_Lname.Text = "七乐彩";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 4)
                {
                    lab_Lname.Text = "排列五";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 5)
                {
                    lab_Lname.Text = "七星彩";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 6)
                {
                    lab_Lname.Text = "大乐透";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 7)
                {
                    lab_Lname.Text = "22选5";
                }
            }
        }

        /// <summary>
        /// 绑定参与方案
        /// </summary>
        public void rep_ppBind()
        {
            
            ds_pp = get_pub.Chipped_Table("v_Merger", "top 5 *", "ChippedName=" + "'" + name + "'");
            this.rep_pp.DataSource = ds_pp;
            this.rep_pp.DataBind();
        }
        protected void rep_pp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Pbzx.BLL.Chipped_LaunchInfoManage get_lm = new Pbzx.BLL.Chipped_LaunchInfoManage();
            
            foreach (RepeaterItem RI in this.rep_pp.Items)
            {
                Label lab_Lname_pp = RI.FindControl("lab_Lname_pp") as Label;
                Label lab_ExpectNum_pp = RI.FindControl("lab_ExpectNum_pp") as Label;
                Label lab_AtotalMoney_pp = RI.FindControl("lab_AtotalMoney_pp") as Label;
                DataSet ds_ppBund=get_lm.GetList("QNumber="+"'"+ ds_pp.Tables[0].Rows[RI.ItemIndex]["QNumber"].ToString() +"'");
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 1)
                {
                    lab_Lname_pp.Text = "福彩3D";   
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 2)
                {
                    lab_Lname_pp.Text = "七乐彩";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 3)
                {
                    lab_Lname_pp.Text = "双色球";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 4)
                {
                    lab_Lname_pp.Text = "排列五";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 5)
                {
                    lab_Lname_pp.Text = "七星彩";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 6)
                {
                    lab_Lname_pp.Text = "大乐透";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 7)
                {
                    lab_Lname_pp.Text = "22选5";
                }
                lab_ExpectNum_pp.Text = ds_ppBund.Tables[0].Rows[0]["ExpectNum"].ToString();
                lab_AtotalMoney_pp.Text = ds_ppBund.Tables[0].Rows[0]["AtotalMoney"].ToString();

            }
        }

        /// <summary>
        /// 绑定历史战绩
        /// </summary>
        public void dl_historyBind()
        {
            dsDataList = get_pub.Chipped_Table("v_participation", "distinct playName", "UserName=" + "'" + name + "'" + " or ChippedName=" + "'" + name + "'" + " and Purchasing=2 and State=1 " + " group by playName");
            this.dl_history.DataSource = dsDataList;
            this.dl_history.DataBind();


        }
        //DataList 绑定事件
        protected void dl_history_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Pbzx.BLL.PlatformPublic_UserWinning get_win = new Pbzx.BLL.PlatformPublic_UserWinning();
            int lotteryInt = 0;
            decimal WinMoneysd = 0;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) //交替的偶数行
            {
                //彩种名称
                Label lab_lotteryName = e.Item.FindControl("lab_lotteryName") as Label;
                //和彩种相对应的图片
                Image image_lottery = e.Item.FindControl("image_lottery") as Image;

                //中奖次数
                Label lab_num = e.Item.FindControl("lab_num") as Label;
                //中奖总金额
                Label lab_totalMoney = e.Item.FindControl("lab_totalMoney") as Label;
                //查询所有本会员参与的3D的项目 lotteryInt
                DataSet dsLott = get_pub.Chipped_Table("v_Merger", "distinct QNumber", "ChippedName=" + "'" + name + "'" + " group by QNumber");
                for (int i = 0; i < dsLott.Tables[0].Rows.Count; i++)
                {
                    //查询中奖次数
                    if (get_win.Exists(dsLott.Tables[0].Rows[i]["QNumber"].ToString(), "Chipped"))
                    {
                        lotteryInt++;
                    }
                    //计算中奖金额
                    DataSet dsWin = get_win.GetList("u_wItem=" + "'" + dsLott.Tables[0].Rows[i]["QNumber"].ToString() + "'" + " and u_platform='Chipped'");
                    if (dsWin != null && dsWin.Tables[0].Rows.Count > 0)
                    {
                        WinMoneysd += Convert.ToDecimal(dsWin.Tables[0].Rows[0]["u_Monery"]);
                    }
                }

                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 1)
                {
                    lab_lotteryName.Text = "福彩3D";
                    image_lottery.ImageUrl = "~/images/sd.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 3)
                {
                    lab_lotteryName.Text = "双色球";
                    image_lottery.ImageUrl = "~/images/ssq.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 2)
                {
                    lab_lotteryName.Text = "七乐彩";
                    image_lottery.ImageUrl = "~/images/ssq.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 6)
                {
                    lab_lotteryName.Text = "大乐透";
                    image_lottery.ImageUrl = "~/images/dlt.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 4)
                {
                    lab_lotteryName.Text = "排列五";
                    image_lottery.ImageUrl = "~/images/plw.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 5)
                {
                    lab_lotteryName.Text = "七星彩";
                    image_lottery.ImageUrl = "~/images/plw.png";
                }
                lab_num.Text = lotteryInt.ToString();
                lab_totalMoney.Text = WinMoneysd.ToString();
            }
        }
    }
}
