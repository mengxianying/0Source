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
using Pinble_Market.AppCod;

namespace Pinble_Market.admin
{
    public partial class BuyLog : System.Web.UI.Page
    {
        Pbzx.BLL.Market_BuyInfo get_buy = new Pbzx.BLL.Market_BuyInfo();
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        private int rowCount = 0;
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='/login.aspx'</script>");
                Response.End();
                return;
            }
            //判断用户是否登录是否是高级用户
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");
                Response.End();
                return;

            }
            if (!IsPostBack)
            {
                BindMyRep_buyLog();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void BindMyRep_buyLog()
        {

            StringBuilder strBud = new StringBuilder();
            strBud.Append("ShopUserID="+"'"+ Method.Get_UserName +"'");

            string Searchstr = strBud.ToString();
            string order = "buyid desc";
            int mycount = 0;
            IsResult = get_buy.GuestGetBySearchBuyInfo(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyRep_buyLog.DataSource = IsResult;
            this.MyRep_buyLog.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                AspNetPager1.Visible = false;
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            rowCount = IsResult.Rows.Count;

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetManageCount());
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
            
            BindMyRep_buyLog();
        }
        protected void MyRep_buyLog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.MyRep_buyLog.Items)
            {
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    DataSet ds = get_page.Market_GetItme("NvarName", "appendId=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["issueInfoId"]));
                    Label lab_NvarName = RI.FindControl("lab_NvarName") as Label;
                    lab_NvarName.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }
        //页面搜索
        protected void Ibtn_scout_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder strBud = new StringBuilder();
            strBud.Append("ShopUserID=" + "'" + Method.Get_UserName + "'" + " and (Price like '%" + Request.Form["username"].ToString() + "%' or buyuserid like '%" + Request.Form["username"].ToString() + "%'" + " or LotteryType like '%" + "'" + Request.Form["username"].ToString() + "'"+"%')");

            string Searchstr = strBud.ToString();
            string order = "buyid desc";
            int mycount = 0;
            IsResult = get_buy.GuestGetBySearchBuyInfo(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyRep_buyLog.DataSource = IsResult;
            this.MyRep_buyLog.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                AspNetPager1.Visible = false;
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            rowCount = IsResult.Rows.Count;
            
        }
    }
}
