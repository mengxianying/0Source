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
    public partial class CustomDoc : System.Web.UI.Page
    {
        Pbzx.BLL.publicMethod get_pd = new Pbzx.BLL.publicMethod();
        Pbzx.BLL.Chipped_LaunchInfoManage get_linfo = new Pbzx.BLL.Chipped_LaunchInfoManage();
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindrep_list();
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void Bindrep_list()
        {
            
            StringBuilder sb = new StringBuilder();
            int IntID = Convert.ToInt32(Request["IntId"]);
            if (IntID == 0)
            {

                sb.Append("State=0 and Purchasing=2");
                sb.Append(" group by UserName,playName,LaunchTime,QNumber ");
            }
            else
            {
                sb.Append("State=0 and Purchasing=2");
                sb.Append(" and playName=" + IntID);
                sb.Append(" group by UserName,playName,LaunchTime,QNumber ");
            }
            
            string Searchstr = sb.ToString();

            //发布时间倒序排列
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult = get_linfo.GuestGetBySearchChipped(Searchstr, "UserName,playName,LaunchTime,QNumber", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
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
            AspNetPager1.PageSize = 50;
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
            Bindrep_list();
        }

        protected void rep_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_list.Items)
            { 
                //累计中奖金额
                Label lab_CumAmount = RI.FindControl("lab_CumAmount") as Label;
                //已定制的人数
                Label lab_cus = RI.FindControl("lab_cus") as Label;
                //冻结资金
                Label lab_Frozen = RI.FindControl("lab_Frozen") as Label;



                //查询会员个人收取
                DataSet ds = get_pd.Chipped_Table("PlatformPublic_payments", "sum(Pp_data)", "Pp_belongs='Chipped' and Pp_name=" + "'" + Method.Get_UserName.ToString() + "'" + " and Pp_Type=2");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "")
                    {
                        lab_CumAmount.Text = "￥0.00元";
                    }
                    else
                    {
                        lab_CumAmount.Text =Convert.ToDecimal(ds.Tables[0].Rows[0][0]).ToString("￥#,##0.00");
                    }
                }
                //查询冻结资金
                DataSet ds_rozen = get_pd.Chipped_Table("PlatformPublic_payments", "sum(Pp_data)", "Pp_belongs='Chipped' and Pp_name=" + "'" + Method.Get_UserName.ToString() + "'" + " and Pp_Type=3");
                if (ds_rozen != null && ds_rozen.Tables[0].Rows.Count > 0)
                {
                    if (ds_rozen.Tables[0].Rows[0][0].ToString() == "")
                    {
                        lab_Frozen.Text = "￥0.00";
                    }
                    else
                    {
                        lab_Frozen.Text =Convert.ToDecimal(ds_rozen.Tables[0].Rows[0][0]).ToString("￥#,##0.00");
                    }
                }
                //查询跟单人数
                DataSet ds_userNum = get_pd.Chipped_Table("Chipped_TrackingOrders", "count(*)", "UserN=" + "'" + IsResult.Rows[RI.ItemIndex]["UserName"].ToString() + "'");
                if (ds_userNum != null && ds_userNum.Tables[0].Rows.Count > 0)
                {
                    if (ds_userNum.Tables[0].Rows[0][0].ToString() == "")
                    {
                        lab_cus.Text = "0";
                    }
                    else
                    {
                        lab_cus.Text = ds_userNum.Tables[0].Rows[0][0].ToString();
                       
                    }
                }
                
            }
        }

        //搜索
        protected void Button1_Click(object sender, EventArgs e)
        {
            //用户名
            string n_username = findstr.Text.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append("State=0 and Purchasing=2");
            sb.Append(" and UserName=" + "'" + n_username + "'");
            sb.Append(" group by UserName,playName,LaunchTime,QNumber ");

            string Searchstr = sb.ToString();

            //发布时间倒序排列
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult = get_linfo.GuestGetBySearchChipped(Searchstr, "UserName,playName,LaunchTime,QNumber", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
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
    }
}