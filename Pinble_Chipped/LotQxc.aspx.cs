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

namespace Pinble_Chipped
{
    public partial class LotQxc : System.Web.UI.Page
    {
        public static string ExpectNum = "";
        DataTable IsResult = new DataTable();
        Pbzx.BLL.Chipped_LaunchInfoManage mybll = new Pbzx.BLL.Chipped_LaunchInfoManage();
        Pbzx.BLL.publicMethod get_pp = new Pbzx.BLL.publicMethod();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExpectNum = Pbzx.BLL.publicMethod.Period("TCPL35Data");
                rep_list_Bind();
            }
        }
        //绑定合买列表
        private void rep_list_Bind()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("playName=5");
            sb.Append(" and Purchasing=2");
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult = mybll.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.rep_list.DataSource = IsResult;
            this.rep_list.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/>暂时没有合买信息</b>";
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
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            rep_list_Bind();
        }

        //repeater 的绑定事件
        protected void rep_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_list.Items)
            {
                //声明控件（每份的金额）
                Label lab_Each = RI.FindControl("lab_Each") as Label;
                //声明控件（方案内容）
                Label lab_Content = RI.FindControl("lab_Content") as Label;
                //声明控件（方案进度）
                Label lab_progress = RI.FindControl("lab_progress") as Label;
                //声明控件（剩余份数）
                Label lab_surplus = RI.FindControl("lab_surplus") as Label;

                //是否出票
                Label lab_ticket = RI.FindControl("lab_ticket") as Label;

                //彩种
                Label lab_LName = RI.FindControl("lab_LName") as Label;
                DataSet ds_LottM = get_pp.Chipped_Table("PBnet_LotteryMenu", "NvarName,NvarApp_Name", "IntId=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["playName"]));
                lab_LName.Text = ds_LottM.Tables[0].Rows[0]["NvarName"].ToString();
                //过期的信息不允许购买
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["ExpectNum"]) < Convert.ToInt32(Pbzx.BLL.publicMethod.Period(ds_LottM.Tables[0].Rows[0]["NvarApp_Name"].ToString())))
                {
                    RI.FindControl("SchemeSpeed").Visible = false;
                }

                decimal nEachMo = Convert.ToDecimal(IsResult.Rows[RI.ItemIndex]["AtotalMoney"]) / Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Share"]);
                //计算单份的金额
                lab_Each.Text = nEachMo.ToString("0.##");
                //方案内容的设置判断
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Object"]) == 0)
                {
                    //对所有人公开
                    lab_Content.Text = "";
                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Object"]) == 1)
                {
                    RI.FindControl("Content").Visible = false;
                    lab_Content.Text = "仅跟单人可看";
                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Object"]) == 2)
                {
                    RI.FindControl("Content").Visible = false;
                    lab_Content.Text = "号码保密";
                }
                //显示进度
                Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();

                DataSet get_ds = get_pub.Statistics("QNumber=" + "'" + IsResult.Rows[RI.ItemIndex]["QNumber"].ToString() + "'");

                //计算剩余多少份=总份-购买的份
                lab_surplus.Text = Convert.ToString(Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Share"]) - Convert.ToInt32(get_ds.Tables[0].Rows[0][0]));

                //方案进度
                string nSop = get_pp.percent(IsResult.Rows[RI.ItemIndex]["QNumber"].ToString()) + "%";
                lab_progress.Text = nSop;
                if (nSop == "100%")
                {
                    //是否出票
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["State"]) == 1)
                    {
                        lab_ticket.Text = "已出票";
                    }
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["State"]) == 3)
                    {
                        lab_ticket.Text = "未出票";
                    }
                    lab_Content.Text = "已完成";
                    RI.FindControl("Content").Visible = false;
                    RI.FindControl("SchemeSpeed").Visible = false;
                    RI.FindControl("dis").Visible = true;

                }
            }
        }

    }
}