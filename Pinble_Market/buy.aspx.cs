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
using Pinble_Market.AppCod;
using System.Text;

namespace Pinble_Market
{
    public partial class buy : System.Web.UI.Page
    {
        public string NvarName = "";
        public string TypeName = "";
        public string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 判断用户是否登录是否是高级用户
                if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
                {
                    lab_name.Text = "您  " + Method.Get_UserName.ToString() + "还不是高级用户";
                }
                else
                {
                    lab_name.Text ="<font color='red'>"+"欢迎您：" + Method.Get_UserName.ToString()+"</font>     请选择要购买的期限";
                    lbtn_login.Visible = false;
                }
                main();
                BindTab_BuyInfo();
            }
        }

        private void main()
        {
            
            string appendID = Input.Decrypt(Request["appendId"]);

            buyItem(appendID);

            Pbzx.BLL.Market_Page MyPage = new Pbzx.BLL.Market_Page();
            //绑定标题的数据
            DataSet ds = MyPage.Market_GetItme("UserId,Time,say,NvarName,TypeName,Price","appendID="+Convert.ToInt32(appendID));
            //条件的介绍内容
            lab_say.Text = ds.Tables[0].Rows[0]["say"].ToString();
            lab_user.Text = ds.Tables[0].Rows[0]["UserId"].ToString();
            lan_NvarName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString() + ds.Tables[0].Rows[0]["TypeName"].ToString();
            NvarName = Pbzx.Common.Input.Encrypt(ds.Tables[0].Rows[0]["NvarName"].ToString());
            TypeName =Pbzx.Common.Input.Encrypt(ds.Tables[0].Rows[0]["TypeName"].ToString());
            userId = Pbzx.Common.Input.Encrypt(ds.Tables[0].Rows[0]["UserId"].ToString());
            //价格
            lab_price.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            //条件发布时间
            lab_time.Text = string.Format("{0:u}", Convert.ToDateTime(ds.Tables[0].Rows[0]["Time"])).Substring(0,10);

            //绑定具体期号等数据
            DataSet dsNum = MyPage.Market_GetNum("top 2 ExpectNum,Content", "appendID=" +Convert.ToInt32(appendID) + " order by ExpectNum desc");
            //查询这个项目发布了多少期
            DataSet num = MyPage.Market_GetNum("ExpectNum", "appendID=" + Convert.ToInt32(appendID));
            lab_num.Text = num.Tables[0].Rows.Count.ToString();
            //如果只发布一期
            if (dsNum != null && dsNum.Tables[0].Rows.Count < 2)
            { 
                lab_upNum.Text="<font color='red'>没有最新发布</font>";
                lab_NumGut.Text="暂无内容";
            }
            else
            {
                lab_upNum.Text = dsNum.Tables[0].Rows[1]["ExpectNum"].ToString();
                lab_NumGut.Text = dsNum.Tables[0].Rows[1]["Content"].ToString();
            }
            //查询到最新的期号
            //localhost.WebService1 web=new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 web = new Pinble_Market.admin.WebService1();
            lab_NewNum.Text = web.lotteryNum(ds.Tables[0].Rows[0]["NvarName"].ToString());
        }
        /// <summary>
        /// 验证用户是否购买过此项目
        /// </summary>
        private void buyItem(string appendID)
        { 
            //判断是否购买过此项目
            Pbzx.BLL.Market_BuyInfo Mybuy = new Pbzx.BLL.Market_BuyInfo();

            if (!Mybuy.Exists(Method.Get_UserName.ToString(), Convert.ToInt32(appendID)))
            {
                lab_beginTime.Text = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                
                DataSet ds = Mybuy.GetList("issueInfoId=" + Convert.ToInt32(appendID) + " and buyuserid=" + "'" + Method.Get_UserName.ToString() + "'");
                lab_buyHistory.Text = "<font color='red'>您已购买过条件，到期时间是：" + ds.Tables[0].Rows[0]["EndTime"].ToString()+" 继续购买延长时间</font>";
                lab_beginTime.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
            }
        }

        protected void Cob_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab_endTime.Text = Convert.ToDateTime(lab_beginTime.Text).AddMonths(Convert.ToInt32(Cob_time.SelectedValue)).ToString("yyyy-MM-dd"); 
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (agreement.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('请先查看《用户购买协议》内容并选择同意')", true);
                return;
            }
            string appendID = Input.Decrypt(Request["appendId"]);
            if (Cob_time.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('请先选择购买期限！')", true);
                return;
            }

            Pbzx.BLL.Market_BuyInfo Mybuy = new Pbzx.BLL.Market_BuyInfo();
            Pbzx.Model.Market_BuyInfo Mymod = new Pbzx.Model.Market_BuyInfo();

            Pbzx.BLL.Market_Page Mypage=new Pbzx.BLL.Market_Page();

            Pbzx.BLL.PBnet_UserTable g_user = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable g_Moduser = new Pbzx.Model.PBnet_UserTable();
            DataSet ds = Mypage.Market_GetItme("TypeName,Price,UserId", "appendID=" + Convert.ToInt32(appendID));
            //查询购买用户的帐户金额
            g_Moduser = g_user.GetModelName(Method.Get_UserName);
            decimal Money = Convert.ToDecimal(g_Moduser.CurrentMoney);
            decimal price = Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]);
            if (!Mybuy.Exists(Method.Get_UserName.ToString(), Convert.ToInt32(appendID)))
            {
                //没有购买过项目    
                Mymod.buyuserid = Method.Get_UserName.ToString();
                Mymod.issueInfoId = Convert.ToInt32(appendID);
                Mymod.LotteryType = ds.Tables[0].Rows[0]["TypeName"].ToString();
                Mymod.ShopUserID=ds.Tables[0].Rows[0]["UserId"].ToString();
                Mymod.Price =Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"].ToString());
                Mymod.Term =Convert.ToInt32(Cob_time.SelectedValue);
                Mymod.BeginTime = Convert.ToDateTime(lab_beginTime.Text);
                Mymod.EndTime = Convert.ToDateTime(lab_endTime.Text);
                Mymod.buyContinue = Convert.ToInt32(Request.Form["radiobutton"]);
                
                if (Money > price)
                {
                    if (Mybuy.Add(Mymod) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "UpdatePanel1", "<script>alert('购买成功！进入后台查看');window.close();</script>", false);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "if(confirm('您的余额不足，请充值！')){ window.open('" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx');window.close();}else{window.close();}", true);
                }
            }
            else
            { 
                //购买过项目
                Mymod.EndTime = Convert.ToDateTime(lab_endTime.Text);
                if (Money > price)
                {
                    if (Mybuy.Update(Mymod) > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "UpdatePanel1", "<script>alert('购买成功！进入后台查看');window.close();</script>", false);
                        ClientScript.RegisterStartupScript(this.GetType(), "Myscript", "<script>alert('购买成功！进入后台查看');window.close();</script>");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "if(confirm('您的余额不足，请充值！')){ window.open('" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx');window.close();}else{window.close();}", true);
                }
                
            }
        }

        //绑定购买项目查看列表
        /// <summary>
        /// 创建人: zhouwei
        /// 创建时间: 2010-12-22
        /// </summary>
        public void BindTab_BuyInfo()
        {
            int ID = Convert.ToInt32(Input.Decrypt(Request["appendId"]));

            Pbzx.BLL.Market_BuyInfo MyBLL = new Pbzx.BLL.Market_BuyInfo();
            StringBuilder str = new StringBuilder();
            str.Append("issueInfoId=" + ID);

            string Searchstr = str.ToString();
            string order = "buyid asc";
            int mycount = 0;
            DataTable IsResult = MyBLL.GuestGetBySearchBuyInfo(Searchstr, "*", order, 10, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.Tab_BuyInfo.DataSource = IsResult;
            this.Tab_BuyInfo.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }


        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 10;
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
            BindTab_BuyInfo();
        }
        //关注项目
        protected void lbtn_attention_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.Market_Page pa = new Pbzx.BLL.Market_Page();
            string appendID = Input.Decrypt(Request["appendId"]);

            //查询彩种
            DataSet ds = pa.Market_GetItme("NvarName", "appendID=" + Convert.ToInt32(appendID));
            Pbzx.BLL.Market_CollASAtten ca = new Pbzx.BLL.Market_CollASAtten();
            Pbzx.Model.Market_CollASAtten modca = new Pbzx.Model.Market_CollASAtten();
            if (!ca.Exists(Method.Get_UserName, appendID, 1, 2))
            {
                modca.appName = appendID;
                modca.appTime = DateTime.Now.Date;
                modca.mark = 2;
                modca.statc = 1;
                modca.Uname = Method.Get_UserName.ToString();
                if (ca.Add(modca) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('您成功关注了此项目')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('关注项目不成功！')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('您已经关注过此项目')", true);
            }
        }

    }
}
