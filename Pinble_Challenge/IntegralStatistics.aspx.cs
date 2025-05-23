using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Pinble_Challenge
{
    public partial class IntegralStatistics : System.Web.UI.Page
    {
        Pbzx.BLL.PlatformPublic_UserWinning get_uw = new Pbzx.BLL.PlatformPublic_UserWinning();
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            if (Request.Params["id"] != "" && Request.Params["id"] != null)
            {
                string n_lotStr = Request["id"].ToString();

                if (n_lotStr == "s")
                {
                    lbtn_s.CssClass = "hover";
                    lbtn_d.CssClass = "";
                    lbtn_p.CssClass = "";

                    repConBind("u_lottId=3 and u_platform='match'");
                    lab_lname.Text = "双色球";
                }
                if (n_lotStr == "d")
                {
                    lbtn_d.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_p.CssClass = "";
                    repConBind("u_lottId=1 and u_platform='match'");
                    lab_lname.Text = "3D";
                }
                if (n_lotStr == "p")
                {
                    lbtn_p.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_d.CssClass = "";
                    repConBind("u_lottId=9999 and u_platform='match'");
                    lab_lname.Text = "排列三";
                }
            }
            else
            {
                lbtn_s.CssClass = "hover";
                lbtn_d.CssClass = "";
                lbtn_p.CssClass = "";

                repConBind("u_lottId=3 and u_platform='match'");
            }
        }
        public void repConBind(string term)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(term);
            //sb.Append(" group by u_name,u_id,u_coin");
            //string Searchstr = sb.ToString();
            ////发布时间倒序排列
            //string order = "coin desc";
            //int mycount = 0;
            //IsResult = get_uw.GuestGetBySearchIntegral(Searchstr, "u_name,SUM([u_coin]) as coin,u_id", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 100 u_name,sum(u_coin) as u_coin from PlatformPublic_UserWinning where " + term + " group by u_name order by u_coin desc");
            this.rep_con.DataSource = ds;
            this.rep_con.DataBind();
            //AspNetPagerConfig(mycount);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            //查询
            string sqlStr = string.Empty;
            if (txt_user.Text != "")
            {
                sqlStr += " and u_name="+"'"+ txt_user.Text.ToString() +"'";
            }
            if (txt_StarTime.Text != "")
            {
                sqlStr += " and u_time>"+"'"+ Convert.ToDateTime(txt_StarTime.Text) +"'";
            }
            if (txt_endTime.Text != "")
            {
                sqlStr += " and u_time<" + "'" + Convert.ToDateTime(txt_endTime.Text) + "'";
            }
            if (Request.Params["id"] != "" && Request.Params["id"] != null)
            {
                string n_lotStr = Request["id"].ToString();

                if (n_lotStr == "s")
                {
                    lbtn_s.CssClass = "hover";
                    lbtn_d.CssClass = "";
                    lbtn_p.CssClass = "";

                    repConBind("u_lottId=3 and u_platform='match'"+ sqlStr);
                    lab_lname.Text = "双色球";
                }
                if (n_lotStr == "d")
                {
                    lbtn_d.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_p.CssClass = "";
                    repConBind("u_lottId=1 and u_platform='match'" + sqlStr);
                    lab_lname.Text = "3D";
                }
                if (n_lotStr == "p")
                {
                    lbtn_p.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_d.CssClass = "";
                    repConBind("u_lottId=9999 and u_platform='match'" + sqlStr);
                    lab_lname.Text = "排列三";
                }
            }
            else
            {
                lbtn_s.CssClass = "hover";
                lbtn_d.CssClass = "";
                lbtn_p.CssClass = "";

                repConBind("u_lottId=3 and u_platform='match'" + sqlStr);
            }
           
        }
        //protected void AspNetPagerConfig(int tempCount)
        //{
        //    AspNetPager1.PageSize = 50;
        //    AspNetPager1.RecordCount = tempCount;
        //    AddCustomText();
        //}
        //protected void AddCustomText()
        //{
        //    AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
        //    AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        //}
        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    repConBind("u_platform='match' group by u_name");
        //}


    }
}