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
    public partial class Stat : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_BuyInfo get_buy = new Pbzx.BLL.Market_BuyInfo();
        DataTable IsResult = new DataTable();
        private int rowCount = 0;
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
                BindMy_rep();
            }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindMy_rep()
        {
            //总共出售的项目
            DataSet ds = get_buy.GetList("ShopUserId="+"'"+ Method.Get_UserName +"'");
            lab_FullItem.Text = ds.Tables[0].Rows.Count.ToString();
            // 总收入
            DataSet dsbuy = get_page.Market_Table("Market_BuyInfo", "sum(Price)", "ShopUserId=" + "'" + Method.Get_UserName + "'");
            lab_earning.Text = dsbuy.Tables[0].Rows[0][0].ToString();
            
            //当前年
            string year =DateTime.Now.Year.ToString();
            //当前月
            string month =DateTime.Now.Month.ToString();
            //当月出售项目个数
            DataSet dsNonce = get_buy.GetList("ShopUserId=" + "'" + Method.Get_UserName + "'" + " and BeginTime>=" + "'"+Convert.ToDateTime(year + "-" + month + "-" + "1").ToString("yyyy-MM-dd")+"'" + " and BeginTime<=" + "'"+Convert.ToDateTime(year + "-" + month + "-" + "31").ToString("yyyy-MM-dd")+"'");
            lab_NonceItem.Text = dsNonce.Tables[0].Rows.Count.ToString();
            //当月收入
            DataSet dsNoncebuy = get_page.Market_Table("Market_BuyInfo", "sum(Price)", "ShopUserId=" + "'" + Method.Get_UserName + "'" + " and BeginTime>=" +"'"+ Convert.ToDateTime(year + "-" + month + "-" + "1").ToString("yyyy-MM-dd")+"'" + " and BeginTime<=" + "'"+Convert.ToDateTime(year + "-" + month + "-" + "31").ToString("yyyy-MM-dd")+"'");
            lab_NonceMonth.Text = dsNoncebuy.Tables[0].Rows[0][0].ToString();


            StringBuilder str = new StringBuilder();
            str.Append("UserId="+"'"+ Method.Get_UserName +"'");
            str.Append(" and Charge=1 group by NvarName,TypeName,Price,appendId");
            string Searchstr = str.ToString();
            string order = "Price desc";
            int mycount = 0;
            IsResult = get_page.GuestGetBySearch(Searchstr, "NvarName,TypeName,Price,appendId", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            My_rep.DataSource = IsResult;
            My_rep.DataBind();
            AspNetPagerConfig(mycount);
            rowCount = IsResult.Rows.Count;
            if (IsResult == null)
            {
                AspNetPager1.Visible = false;
            }
        }
        protected void My_rep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.My_rep.Items)
            {
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    //单个条件订购人数
                    Label lab_HumanNum = RI.FindControl("lab_HumanNum") as Label;
                    //单个条件收入
                    Label lab_FullPricer = RI.FindControl("lab_FullPricer") as Label;

                    DataSet dsNum = get_buy.GetList("issueInfoId=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["appendId"]));
                    if (dsNum != null || dsNum.Tables[0].Rows.Count > 0)
                    {
                        lab_HumanNum.Text = dsNum.Tables[0].Rows.Count.ToString();
                        lab_FullPricer.Text = (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Price"]) * Convert.ToInt32(dsNum.Tables[0].Rows.Count)).ToString();
                    }
                    else
                    {
                        lab_HumanNum.Text = "无人订购";
                        lab_FullPricer.Text = "0";
                    }
                }
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetManageCount());
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + IsResult.Rows.Count.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMy_rep();
        }
    }
}
