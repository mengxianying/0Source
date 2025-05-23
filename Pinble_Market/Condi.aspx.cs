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
    public partial class Condi : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_appendItemManager get_app = new Pbzx.BLL.Market_appendItemManager();
        private int rowCount = 0;
        private string str = "";
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItem();
                string name = Input.Decrypt(Request["name"]);
                if (name == "3D")
                {
                    Image1.ImageUrl = "../image/title1_3D.png";
                }
                else if (name == "双色球")
                {
                    Image1.ImageUrl = "../image/seq.png";
                }
                else if (name == "七星彩")
                {
                    Image1.ImageUrl = "../image/qxc.png";
                }
                else if (name == "大乐透")
                {
                    Image1.ImageUrl = "../image/dlt.png";
                }
                else if (name == "七乐彩")
                {
                    Image1.ImageUrl = "../image/qlc.png";
                }
                else if (name == "排列三")
                {
                    Image1.ImageUrl = "../image/pl3.png";
                }
                else if (name == "排列五")
                {
                    Image1.ImageUrl = "../image/pl5.png";
                }
                else if (name == "22选5")
                {
                    Image1.ImageUrl = "../image/22x5.png";
                }
            }
        }
        //数据绑定
        private void BindItem()
        {
            string name = Input.Decrypt(Request["name"]);
            string lott = Input.Decrypt(Request["lott"]);
            
            if (name == "0" || lott =="0")
            {
                StringBuilder strBud = new StringBuilder();
                strBud.Append("On_off=0");
                strBud.Append(" and NvarName=" + "'" + name + "'");
                strBud.Append(" or TypeName=" + "'" + lott + "'");

                string Searchstr = strBud.ToString();
                string order = "Time,Charge desc";
                int mycount = 0;
                IsResult = get_app.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
                myGridView.DataSource = IsResult;
                myGridView.DataBind();

                AspNetPagerConfig(mycount);
                if (IsResult == null)
                {
                    this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
                }
                else
                {
                    this.litContent.Text = "";
                }
                rowCount = IsResult.Rows.Count;
            }
            else
            {
                StringBuilder strBud = new StringBuilder();
                strBud.Append("NvarName=" + "'" + name + "'");
                strBud.Append(" and TypeName=" + "'" + lott + "'");
                strBud.Append(" and On_off=0");
                string Searchstr = strBud.ToString();
                string order = "Time,Charge desc";
                int mycount = 0;
                IsResult = get_app.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
                myGridView.DataSource = IsResult;
                myGridView.DataBind();

                AspNetPagerConfig(mycount);
                if (IsResult == null)
                {
                    this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
                }
                else
                {
                    this.litContent.Text = "";
                }
                rowCount = IsResult.Rows.Count;
            }
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
            //repItemBind();
            BindItem();
        }
        protected void myGridView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myGridView.Items)
            {
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_price = RI.FindControl("lab_price") as Label;
                    LinkButton Btn_buy = RI.FindControl("Btn_buy") as LinkButton;
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Charge"]) == 0)
                    { 
                        //免费条件
                        lab_price.Text = "<font color='red'>免费</font>";
                        Btn_buy.Visible = false;
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
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
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
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
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
        //搜索功能
        protected void Imbtn_hunt_Click(object sender, ImageClickEventArgs e)
        {
            string name = Input.Decrypt(Request["name"]);
            string lott = Input.Decrypt(Request["lott"]);

            StringBuilder strBud = new StringBuilder();
            strBud.Append("NvarName=" + "'" + name + "'");
            strBud.Append(" and TypeName=" + "'" + lott + "'");
            strBud.Append(" and On_off=0");
            strBud.Append(" and UserId like'%" +  Request.Form["username"].ToString()+"%'");
            string Searchstr = strBud.ToString();
            string order = "Time,Charge desc";
            int mycount = 0;
            IsResult = get_app.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            myGridView.DataSource = IsResult;
            myGridView.DataBind();

            AspNetPagerConfig(mycount);
            if (IsResult == null || IsResult.Rows.Count<1)
            {
                AspNetPager1.Visible = false;
                this.litContent.Text = "<b>抱歉！ 应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            rowCount = IsResult.Rows.Count;

        }
    }
}
