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

namespace Pinble_Market
{
    public partial class rightFrom : System.Web.UI.Page
    {
        Pbzx.BLL.Market_CollASAtten collasAtten = new Pbzx.BLL.Market_CollASAtten();
        Pbzx.Model.Market_CollASAtten ModCollasAtten = new Pbzx.Model.Market_CollASAtten();
        Pbzx.BLL.Market_Page g_page = new Pbzx.BLL.Market_Page();

        private string str = "";
        DataTable IsResult3D = new DataTable();
        DataTable IsResultSeq = new DataTable();
        DataTable IsResultQxc = new DataTable();
        DataTable IsResultDlt = new DataTable();
        DataTable IsResultPl3 = new DataTable();
        DataTable IsResultPl5 = new DataTable();
        DataTable IsResult22x5 = new DataTable();
        DataTable IsResultQlc = new DataTable();
        private int rowCount = 0;
        private string num = "";
        private string numseq = "";
        private string numqxc = "";
        private string numdlt = "";
        private string numpl3 = "";
        private string numpl5 = "";
        private string num22x5 = "";
        private string numqlc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定3D数据
                Item3DBind();
                //绑定双色球数据
                ItemSeqBind();
                //绑定七星彩数据
                ItemQxcBind();
                //绑定大乐透
                ItemDltBind();
                //绑定排列5
                ItemPl5Bind();
                //绑定22选5
                Item22x5Bind();
                //绑定七乐彩
                ItemQlcBind();
                ////排列3
                //ItemPl3Bind();
            }
        }
        /// <summary>
        /// 绑定种3D的数据
        /// </summary>
        public void Item3DBind()
        {
            
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            num = get_web.lotteryNum("3D");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='3D'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResult3D = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.Item3D.DataSource = IsResult3D;
            this.Item3D.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult3D == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            rowCount = IsResult3D.Rows.Count;

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
            Item3DBind();
        }

        /// <summary>
        /// 绑定种双色球的数据
        /// </summary>
        public void ItemSeqBind()
        {
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            numseq = get_web.lotteryNum("双色球");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='双色球'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResultSeq = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager2.CurrentPageIndex, out mycount);
            this.ItemSeq.DataSource = IsResultSeq;
            this.ItemSeq.DataBind();

            AspNetPagerConfig2(mycount);
            if (IsResultSeq == null)
            {
                this.lab_seq.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.lab_seq.Text = "";
            }

        }

        protected void AspNetPagerConfig2(int tempCount)
        {
            AspNetPager2.PageSize = Convert.ToInt32(Input.GetCount());
            AspNetPager2.RecordCount = tempCount;
            AddCustomText2();
        }
        protected void AddCustomText2()
        {
            AspNetPager2.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager2.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager2.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager2.CurrentPageIndex.ToString() + "</b>/" + AspNetPager2.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            ItemSeqBind();
        }
        /// <summary>
        /// 绑定七星彩数据
        /// </summary>
        public void ItemQxcBind()
        {
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            numseq = get_web.lotteryNum("七星彩");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='七星彩'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResultQxc = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order,  Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.ItemQxc.DataSource = IsResultQxc;
            this.ItemQxc.DataBind();
            AspNetPagerConfig3(mycount);
            if (IsResultQxc == null)
            {
                this.labQxc.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.labQxc.Text = "";
            }

        }
        protected void AspNetPagerConfig3(int tempCount)
        {
            AspNetPager3.PageSize = Convert.ToInt32(Input.GetCount()); ;
            AspNetPager3.RecordCount = tempCount;
            AddCustomText3();
        }
        protected void AddCustomText3()
        {
            AspNetPager3.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager3.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager3.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager3.CurrentPageIndex.ToString() + "</b>/" + AspNetPager3.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            ItemQxcBind();
        }
        /// <summary>
        /// 绑定大乐透数据
        /// </summary>
        public void ItemDltBind()
        {
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            numdlt = get_web.lotteryNum("大乐透");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='大乐透'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResultDlt = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order,  Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.ItemDlt.DataSource = IsResultDlt;
            this.ItemDlt.DataBind();
            AspNetPagerConfig4(mycount);
            if (IsResultDlt == null)
            {
                AspNetPager4.Visible = false;
                this.labDlt.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.labDlt.Text = "";
            }

        }
        protected void AspNetPagerConfig4(int tempCount)
        {
            AspNetPager4.PageSize = Convert.ToInt32(Input.GetCount()); ;
            AspNetPager4.RecordCount = tempCount;
            AddCustomText4();
        }
        protected void AddCustomText4()
        {
            AspNetPager4.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager4.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager4.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager4.CurrentPageIndex.ToString() + "</b>/" + AspNetPager4.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            ItemDltBind();
        }

        ///// <summary>
        ///// 绑定排列3的数据
        ///// </summary>
        //public void ItemPl3Bind()
        //{
        //    localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
        //    numpl3 = get_web.lotteryNum("排列三");
        //    Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
        //    StringBuilder strBud = new StringBuilder();
        //    strBud.Append("On_off=0");
        //    strBud.Append(" and NvarName='排列san'");
        //    strBud.Append(" and UserId is not null");
        //    string Searchstr = strBud.ToString();
        //    string order = "price desc";
        //    int mycount = 0;
        //    IsResultPl3 = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
        //    this.ItemPl3.DataSource = IsResultPl3;
        //    this.ItemPl3.DataBind();
        //    AspNetPagerConfig5(mycount);
        //    if (IsResultPl3 == null)
        //    {
        //        this.labPl3.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
        //    }
        //    else
        //    {
        //        this.labPl3.Text = "";
        //    }

        //}
        //protected void AspNetPagerConfig5(int tempCount)
        //{
        //    AspNetPager5.PageSize = Convert.ToInt32(Input.GetCount()); ;
        //    AspNetPager5.RecordCount = tempCount;
        //    AddCustomText5();
        //}
        //protected void AddCustomText5()
        //{
        //    AspNetPager5.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager5.RecordCount.ToString() + "</b></font>条&nbsp;";
        //    AspNetPager5.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager5.CurrentPageIndex.ToString() + "</b>/" + AspNetPager5.PageCount.ToString() + "页</font>";
        //}
        //protected void AspNetPager5_PageChanged(object sender, EventArgs e)
        //{
        //    ItemPl3Bind();
        //}

        /// <summary>
        /// 绑定排列五的数据
        /// </summary>
        public void ItemPl5Bind()
        {
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            numpl5 = get_web.lotteryNum("排列五");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='排列五'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResultPl5 = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order,  Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.ItemPl5.DataSource = IsResultPl5;
            this.ItemPl5.DataBind();
            AspNetPagerConfig6(mycount);
            if (IsResultPl5 == null)
            {
                this.labPl5.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.labPl5.Text = "";
            }

        }
        protected void AspNetPagerConfig6(int tempCount)
        {
            AspNetPager6.PageSize = Convert.ToInt32(Input.GetCount()); ;
            AspNetPager6.RecordCount = tempCount;
            AddCustomText6();
        }
        protected void AddCustomText6()
        {
            AspNetPager6.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager6.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager6.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager6.CurrentPageIndex.ToString() + "</b>/" + AspNetPager6.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager6_PageChanged(object sender, EventArgs e)
        {
            ItemPl5Bind();
        }
        /// <summary>
        /// 绑定22选5的数据
        /// </summary>
        public void Item22x5Bind()
        {
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            num22x5 = get_web.lotteryNum("22选5");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='22选5'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResult22x5 = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order,  Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.Item22x5.DataSource = IsResult22x5;
            this.Item22x5.DataBind();
            AspNetPagerConfig7(mycount);
            if (IsResult22x5 == null)
            {
                this.lab22x5.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.lab22x5.Text = "";
            }

        }
        protected void AspNetPagerConfig7(int tempCount)
        {
            AspNetPager7.PageSize = Convert.ToInt32(Input.GetCount()); ;
            AspNetPager7.RecordCount = tempCount;
            AddCustomText7();
        }
        protected void AddCustomText7()
        {
            AspNetPager7.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager7.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager7.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager7.CurrentPageIndex.ToString() + "</b>/" + AspNetPager7.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager7_PageChanged(object sender, EventArgs e)
        {
            Item22x5Bind();
        }
        /// <summary>
        /// 绑定七乐彩
        /// </summary>
        public void ItemQlcBind()
        {
            //localhost.WebService1 get_web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            numqlc = get_web.lotteryNum("七乐彩");
            Pbzx.BLL.Market_appendItemManager get_page = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and NvarName='七乐彩'");
            strBud.Append(" and UserId is not null");
            string Searchstr = strBud.ToString();
            string order = "price desc";
            int mycount = 0;
            IsResultQlc = get_page.GuestGetBySearch(Searchstr, "TypeName,UserId,price,appendID,Charge,On_off,say", order,  Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.ItemQlc.DataSource = IsResultQlc;
            this.ItemQlc.DataBind();
            AspNetPagerConfig8(mycount);
            if (IsResultQlc == null)
            {
                this.labQlc.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.labQlc.Text = "";
            }
            
        }
        protected void AspNetPagerConfig8(int tempCount)
        {
            AspNetPager8.PageSize = Convert.ToInt32(Input.GetCount()); ;
            AspNetPager8.RecordCount = tempCount;
            AddCustomText8();
        }
        protected void AddCustomText8()
        {
            AspNetPager8.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager8.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager8.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager8.CurrentPageIndex.ToString() + "</b>/" + AspNetPager8.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager8_PageChanged(object sender, EventArgs e)
        {
            ItemQlcBind();
        }
        /// <summary>
        /// 购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buy_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 3D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Collection_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 3D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Attention_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion
        /// <summary>
        /// 3D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Item3D_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            foreach (RepeaterItem RI in this.Item3D.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_price = RI.FindControl("lab_price") as Label;
                    LinkButton Btn_buy = RI.FindControl("Btn_buy") as LinkButton;

                    Label lab_num = RI.FindControl("lab_num") as Label;
                    Label lab_gut = RI.FindControl("lab_gut") as Label;
                    if (IsResult3D != null && IsResult3D.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content,itemidentity,itemnumber", "appendID=" + "'" + IsResult3D.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");
                        if (Convert.ToInt32(IsResult3D.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_price.Text = "<font color='red'>免费</font>";
                            Btn_buy.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                //lab_gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                                if (ds.Tables[0].Rows[0]["itemidentity"] == null || ds.Tables[0].Rows[0]["itemidentity"].ToString() == "")
                                {
                                    lab_gut.Text = "";
                                }
                                else
                                {
                                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["itemidentity"]) == 0)
                                    {
                                        lab_gut.Text = "<font color='red'>定： </font>" + ds.Tables[0].Rows[0]["Content"].ToString();
                                    }
                                    else
                                    {
                                        lab_gut.Text = "<font color='red'>杀： </font>" + ds.Tables[0].Rows[0]["Content"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                lab_num.Text = "";
                                lab_gut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (num.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_gut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buySeq_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 双色球
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_CollectionSeq_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 双色球
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AttentionSeq_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion
        /// <summary>
        /// 双色球
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemSeq_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.ItemSeq.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    //金额
                    Label lab_seqPrice = RI.FindControl("lab_seqPrice") as Label;
                    //购买
                    LinkButton Btn_buySeq = RI.FindControl("Btn_buySeq") as LinkButton;

                    Label lab_seqnum = RI.FindControl("lab_seqnum") as Label;
                    Label lab_seqgut = RI.FindControl("lab_seqgut") as Label;
                    if (IsResultSeq != null && IsResultSeq.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResultSeq.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");
                        if (Convert.ToInt32(IsResultSeq.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_seqPrice.Text = "<font color='red'>免费</font>";
                            Btn_buySeq.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_seqnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_seqgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                            else
                            {
                                lab_seqnum.Text = "";
                                lab_seqgut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (numseq.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_seqnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_seqgut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_seqnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_seqgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 购买七星彩 彩票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buyQxc_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 七星彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_CollectionQxc_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 七星彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AttentionQxc_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion
        /// <summary>
        /// 七星彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemQxc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.ItemQxc.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    //金额
                    Label lab_QxcPrice = RI.FindControl("lab_QxcPrice") as Label;
                    //购买
                    LinkButton Btn_buyQxc = RI.FindControl("Btn_buyQxc") as LinkButton;

                    Label lab_qxcnum = RI.FindControl("lab_qxcnum") as Label;
                    Label lab_qxcgut = RI.FindControl("lab_qxcgut") as Label;
                    if (IsResultQxc != null && IsResultQxc.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResultQxc.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");
                        if (Convert.ToInt32(IsResultQxc.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_QxcPrice.Text = "<font color='red'>免费</font>";
                            Btn_buyQxc.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_qxcnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_qxcgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                            else
                            {
                                lab_qxcnum.Text = "";
                                lab_qxcgut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (numqxc.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_qxcnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_qxcgut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_qxcnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_qxcgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 购买大乐透
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buyDlt_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 大乐透
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_CollectionDlt_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 大乐透
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AttentionDlt_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion
        /// <summary>
        /// 大乐透
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemDlt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.ItemDlt.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    //条件内容
                    Label lab_dltgut = RI.FindControl("lab_dltgut") as Label;
                    //金额
                    Label lab_DltPrice = RI.FindControl("lab_DltPrice") as Label;
                    Label lab_dltnum = RI.FindControl("lab_dltnum") as Label;
                    //购买
                    LinkButton Btn_buyDlt = RI.FindControl("Btn_buyDlt") as LinkButton;
                    if (IsResultDlt != null && IsResultDlt.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResultDlt.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");

                        if (Convert.ToInt32(IsResultDlt.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_DltPrice.Text = "<font color='red'>免费</font>";
                            Btn_buyDlt.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_dltnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_dltgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                            else
                            {
                                lab_dltnum.Text = "";
                                lab_dltgut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (numdlt.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_dltnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_dltgut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_dltnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_dltgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 购买排列3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buyPl3_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 排列3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_CollectionPl3_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 排列3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AttentionPl3_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        /// <summary>
        /// 排列3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemPl3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.ItemPl3.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_pl3num = RI.FindControl("lab_pl3num") as Label;
                    //条件内容
                    Label lab_pl3gut = RI.FindControl("lab_pl3gut") as Label;
                    //金额
                    Label lab_Pl3Price = RI.FindControl("lab_Pl3Price") as Label;
                    //购买
                    LinkButton Btn_buyPl3 = RI.FindControl("Btn_buyPl3") as LinkButton;
                    if (IsResultPl3 != null && IsResultPl3.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResultPl3.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");

                        if (Convert.ToInt32(IsResultPl3.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_Pl3Price.Text = "<font color='red'>免费</font>";
                            Btn_buyPl3.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_pl3num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_pl3gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                            else
                            {
                                lab_pl3num.Text = "";
                                lab_pl3gut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (numpl3.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_pl3num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_pl3gut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_pl3num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_pl3gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 购买排列5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buyPl5_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 排列5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_CollectionPl5_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 排列5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AttentionPl5_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        /// <summary>
        /// 排列5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemPl5_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.ItemPl5.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_pl5num = RI.FindControl("lab_pl5num") as Label;
                    //条件内容
                    Label lab_pl5gut = RI.FindControl("lab_pl5gut") as Label;
                    //金额
                    Label lab_Pl5Price = RI.FindControl("lab_Pl5Price") as Label;
                    //购买
                    LinkButton Btn_buyPl5 = RI.FindControl("Btn_buyPl5") as LinkButton;
                    if (IsResultPl5 != null && IsResultPl5.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResultPl5.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");

                        if (Convert.ToInt32(IsResultPl5.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_Pl5Price.Text = "<font color='red'>免费</font>";
                            Btn_buyPl5.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_pl5num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_pl5gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                            else
                            {
                                lab_pl5num.Text = "";
                                lab_pl5gut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (numpl5.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_pl5num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_pl5gut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_pl5num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_pl5gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }
                    }

                }
            }
        }


        /// <summary>
        /// 购买22选5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_22x5_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 22选5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Collection22x5_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 22选5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Attention22x5_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        /// <summary>
        /// 22选5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Item22x5_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //foreach (RepeaterItem RI in this.ItemPl5.Items)
            //{

            //    if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
            //    {
            //        //条件内容
            //        Label lab_22x5Viscera = RI.FindControl("lab_22x5Viscera") as Label;
            //        //金额
            //        Label lab_22x5Price = RI.FindControl("lab_22x5Price") as Label;
            //        //购买
            //        LinkButton Btn_22x5 = RI.FindControl("Btn_22x5") as LinkButton;
            //        if (Convert.ToInt32(IsResult22x5.Rows[RI.ItemIndex]["Charge"]) == 0)
            //        {
            //            lab_22x5Price.Text = "<font color='red'>免费</font>";
            //            Btn_22x5.Visible = false;
            //        }
            //        else
            //        {
            //            //收费项目没开奖前不能查看
            //            DateTime datatime = new DateTime();
            //            if (datatime.Hour > 19 && datatime.Minute > 30)
            //            {
            //                //lab_viscera.Text = "";
            //            }
            //            else
            //            {
            //                lab_22x5Price.Text = "<font color='red'>未开奖</font>";
            //            }
            //        }


            //    }
            //}
        }

        /// <summary>
        /// 购买七乐彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_BuyQlc_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已购买过此项目！')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        #region 收藏项目
        /// <summary>
        /// 七乐彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_CollectionQlc_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        #region   关注项目
        /// <summary>
        /// 七乐彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AttentionQlc_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = g_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);

        }
        #endregion

        /// <summary>
        /// 七乐彩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ItemQlc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.ItemPl5.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_qlcnum = RI.FindControl("lab_qlcnum") as Label;
                    //条件内容
                    Label lab_qlcgut = RI.FindControl("lab_qlcgut") as Label;
                    //金额
                    Label lab_QlcPrice = RI.FindControl("lab_QlcPrice") as Label;
                    //购买
                    LinkButton Btn_buyQlc = RI.FindControl("Btn_buyQlc") as LinkButton;
                    if (IsResultQlc != null && IsResultQlc.Rows.Count > 0)
                    {
                        DataSet ds = g_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResultQlc.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");

                        if (Convert.ToInt32(IsResultQlc.Rows[RI.ItemIndex]["Charge"]) == 0)
                        {
                            lab_QlcPrice.Text = "<font color='red'>免费</font>";
                            Btn_buyQlc.Visible = false;
                            //不为空并且有数据
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                lab_qlcnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_qlcgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                            else
                            {
                                lab_qlcnum.Text = "";
                                lab_qlcgut.Text = "";
                            }
                        }
                        else
                        {
                            //收费条件
                            if (numqlc.ToString() == ds.Tables[0].Rows[0]["ExpectNum"].ToString())
                            {
                                lab_qlcnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_qlcgut.Text = "保密  <font color='red'>(订购查看)</font>";
                            }
                            else
                            {
                                lab_qlcnum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                                lab_qlcgut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                            }
                        }
                    }

                }
            }
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script>window.open('consult.aspx?search='+'" +Pbzx.Common.Input.Encrypt(Request.Form["username"].ToString()) + "')</script>");
        }


    }
}
