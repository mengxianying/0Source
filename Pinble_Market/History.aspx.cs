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
using Pbzx.Common;
using System.Text;

namespace Pinble_Market
{
    public partial class History : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        private int rowCount = 0;
        private string str = "";
        DataTable IsResult = new DataTable();
        private string num = "";
        public string NvarName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMyGridView();
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindMyGridView()
        {

            string lottery = Input.Decrypt(Request["lottery"]);
            string name = Input.Decrypt(Request["name"]);
            string user = Input.Decrypt(Request["user"]);
            //彩种
            lab_NvarName.Text = lottery;
            NvarName =Pbzx.Common.Input.Encrypt(lottery);
            //条件
            lab_TypeName.Text = name;
            lab_username.Text = user;
            //获取最新一期
            // localhost.WebService1 get_web = new Pinble_Market.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            num = get_web.lotteryNum(lottery);

            StringBuilder strBud = new StringBuilder();
            strBud.Append("NvarName=" + "'" + lottery + "'");
            strBud.Append(" and TypeName=" + "'" + name + "'");
            strBud.Append(" and UserId=" + "'" + user + "'");
            strBud.Append(" and ExpectNum is not null");
            string Searchstr = strBud.ToString();
            string order = "ExpectNum desc";
            int mycount = 0;
            IsResult = get_page.GuestGetBySearch(Searchstr, "NvarName,TypeName,itemradio,ExpectNum,Content,UserId,itemidentity,Charge,appendId,Price,itemnumber", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            myGridView.DataSource = IsResult;
            myGridView.DataBind();

            AspNetPagerConfig(mycount);
            if (IsResult == null || IsResult.Rows.Count == 0)
            {
                AspNetPager1.Visible = false;
                Btn_buy.Visible = false;
                this.litContent.Text = "<b>抱歉！应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
                //判断是否是免费
                if (Convert.ToInt32(IsResult.Rows[0]["Charge"]) == 0)
                {
                    //免费的就没有购买按钮
                    Btn_buy.Visible = false;
                    Btn_Attention.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    Btn_Collection.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    lab_price.Text = "<font color='red'>免费</fond>";
                }
                else
                {
                    Btn_buy.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    Btn_Attention.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    Btn_Collection.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    lab_price.Text = IsResult.Rows[0]["Price"].ToString().Split('.')[0] + "金币/月";
                }
            }
            rowCount = IsResult.Rows.Count;
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetCount());
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
            BindMyGridView();
        }

        protected void myGridView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myGridView.Items)
            {
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_viscera = RI.FindControl("lab_viscera") as Label;
                    if (Convert.ToInt32(IsResult.Rows[0]["Charge"]) == 0)
                    {
                        //免费的显示全部信息
                        if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["itemidentity"]) == 0)
                        {
                            lab_viscera.Text = "定：<font color='red'> " + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                        }
                        else
                        {
                            lab_viscera.Text = "杀：<font color='red'>" + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                        }
                        if (IsResult.Rows[RI.ItemIndex]["Content"].ToString() == "" || IsResult.Rows[RI.ItemIndex]["Content"] == null)
                        {
                            lab_viscera.Text = "未发布";
                        }
                    }
                    else
                    {
                        DateTime date = new DateTime();
                        DataSet ds = get_page.Market_GetNum("ExpectNum", "appendId=" + Convert.ToInt32(IsResult.Rows[0]["appendId"]) + " order by ExpectNum desc");
                        if (ds != null && ds.Tables[0].Rows[RI.ItemIndex]["ExpectNum"].ToString() == num.ToString())
                        {
                            //发布了最新一期 那么收费项目保密， 
                            if (RI.ItemIndex == 0 && date.Minute < 30 && date.Hour < 21)
                            {
                                lab_viscera.Text = "保密";
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["itemidentity"]) == 0)
                            {
                                lab_viscera.Text = "定：<font color='red'> " + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                            }
                            else
                            {
                                lab_viscera.Text = "杀：<font color='red'>" + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                            }
                            if (IsResult.Rows[RI.ItemIndex]["Content"].ToString() == "" || IsResult.Rows[RI.ItemIndex]["Content"] == null)
                            {
                                lab_viscera.Text = "未发布";
                            }
                        }
                    }
                }

            }
        }

        //购买项目
        protected void Btn_buy_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }

        }
        //关注
        protected void Btn_Attention_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
            ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('" + str + "')</script>");
        }
        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Collection_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('" + str + "')</script>");
        }
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        private void loginInfo()
        {
            //判断用户是否登录
            if (Method.Get_UserName.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "<script type='text/javascript' language='javascript' > if (confirm('请先登录网站！')){ parent.mainFrame.location.href='../login.aspx';}else{ history.go(-1);}</script>", false);
            }
        }

    }
}
