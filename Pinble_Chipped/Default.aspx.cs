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
    public partial class Default : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_LaunchInfoManage get_lm = new Pbzx.BLL.Chipped_LaunchInfoManage();
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindrep_chipped();
                bindrep_winning();
            }
        }

        /// <summary>
        /// 绑定合买代购信息
        /// </summary>
        private void bindrep_chipped()
        {
            StringBuilder strBud = new StringBuilder();
            strBud.Append("Object!='2'");
            strBud.Append(" and Purchasing=2");
            strBud.Append(" and State=0");
            string Searchstr = strBud.ToString();
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult =get_lm.GuestGetBySearchChipped(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out mycount);
            if (IsResult != null && IsResult.Rows.Count > 0)
            {
                this.rep_chipped.DataSource = IsResult;
                this.rep_chipped.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 30;
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
            bindrep_chipped();
        }

        //  绑定最近中奖
        private void bindrep_winning()
        {

            DataSet ds_bsa = get_pub.Chipped_Table("Chipped_bounsAllost", "top 6 *", "1=1 order by ATime desc");
            if (ds_bsa.Tables[0].Rows.Count > 0 && ds_bsa.Tables[0] != null)
            {
                this.rep_winning.DataSource = ds_bsa;
                this.rep_winning.DataBind();
            }
        }

        ////绑定当日开奖彩种
        //public void OpenEndTime()
        //{
        //    //获取当前时间
        //    DateTime CTime = new DateTime();
        //    //获取当天截止的彩种
            
        //}

        protected void rep_chipped_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            Pbzx.BLL.PBnet_LotteryMenu get_lm = new Pbzx.BLL.PBnet_LotteryMenu();
            Pbzx.BLL.Chipped_InfoManage get_info = new Pbzx.BLL.Chipped_InfoManage();

            foreach (RepeaterItem RI in this.rep_chipped.Items)
            {
                //彩种
                Label lab_lottery = RI.FindControl("lab_lottery") as Label;
                //跟单人数
                Label lab_documentary = RI.FindControl("lab_documentary") as Label;
                //方案进度
                Label lab_progress = RI.FindControl("lab_progress") as Label;

                DataSet ds_lm = get_lm.GetList("IntId=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["playName"]));
                //lab_lottery.Text = ds_lm.Tables[0].Rows[0]["NvarName"].ToString();

                DataSet ds_documentary = get_info.GetList("QNumber=" + "'" + IsResult.Rows[RI.ItemIndex]["QNumber"].ToString() + "'");
                lab_documentary.Text = ds_documentary.Tables[0].Rows.Count.ToString();

                lab_progress.Text = get_pub.percent(IsResult.Rows[RI.ItemIndex]["QNumber"].ToString()) + "%";
            }
        }

    }
}
