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
using Pbzx.BLL;

namespace Pinble_Chipped.admin
{
    public partial class TrackingList : System.Web.UI.Page
    {
        
        Pbzx.BLL.Chipped_TrackingOrders get_t = new Pbzx.BLL.Chipped_TrackingOrders();
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        DataTable ISRseult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='/LoginPage.aspx'</script>");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                BindMy_GridView();
            }
        }

        /// <summary>
        /// 绑定我的订制跟单
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TrackingName=" + "'" + Method.Get_UserName.ToString() + "'");
            string Searchstr = sb.ToString();
            string order = "TrackingTime desc";
            int myCount = 0;
            ISRseult = get_t.GuestGetBySearchTracking(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.My_GridView.DataSource = ISRseult;
            this.My_GridView.DataBind();
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

        /// <summary>
        /// 自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        protected void My_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.My_GridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //彩种名称
                Label lab_lottery = this.My_GridView.Rows[i].Cells[0].FindControl("lab_lottery") as Label;
                //定制
                Label lab_tar = this.My_GridView.Rows[i].Cells[0].FindControl("lab_tar") as Label;
                //行的状态是：正常状态 或者 交替行           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    lab_tar.Text = "<font color='red'>" + Convert.ToDecimal(ISRseult.Rows[i]["BuyMoney"]).ToString("￥#,##0.00") + "</font>" + " X " + ISRseult.Rows[i]["SubscribeNum"].ToString();

                    if (Convert.ToInt32(ISRseult.Rows[i]["TrackingLNum"]) == 9999)
                    {
                        lab_lottery.Text = "排列3";
                    }
                    else
                    {
                        DataSet ds_lot = get_pub.Chipped_Table("PBnet_LotteryMenu", "NvarName", "IntId=" + Convert.ToInt32(ISRseult.Rows[i]["TrackingLNum"]));
                        if (ds_lot != null && ds_lot.Tables[0].Rows.Count > 0)
                        {

                            lab_lottery.Text = ds_lot.Tables[0].Rows[0]["NvarName"].ToString();
                        }
                        else
                        {
                            lab_lottery.Text = "";
                        }
                    }
                    
                    
                }
            }
        }


    }
}
