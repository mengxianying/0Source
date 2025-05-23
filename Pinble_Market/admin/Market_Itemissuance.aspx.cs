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
using Maticsoft.DBUtility;
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;

namespace Pinble_Market
{
    public partial class Market_Itemissuance : System.Web.UI.Page
    {
        Market_NumManager markmanager = new Market_NumManager();
        Pbzx.BLL.PBnet_UserTable usertype = new Pbzx.BLL.PBnet_UserTable();
        
        Pbzx.BLL.Market_Page markepage = new Market_Page();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='/login.aspx'</script>");
                Response.End();
                return;
            }
            // 判断用户是否登录是否是高级用户
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alertScript", "if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}", true);

                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");

                Response.End();
                return;

            }
            if (!IsPostBack)
            {
                //绑定彩种
                ddlLotteryBind();
                //期数绑定
                QSBind();
                

                ////绑定时间
                //BindDate();
            }
        }

        /// <summary>
        /// 绑定设置时间
        /// </summary>
        private void BindDate()
        {
            //ddlDateH.Items.Clear();
            //ddlDateY.Items.Clear();
            //ddlDateR.Items.Clear();
            //ddlDateS.Items.Clear();
            //ddlDateF.Items.Clear();
            //绑定年份
            //for (int i = 0; i < 5; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = (DateTime.Now.Year + i).ToString();
            //    list.Value = (DateTime.Now.Year + i).ToString();
            //    ddlDateH.Items.Add(list);
            //}
            ////绑定月份
            //for (int i = 1; i < 13; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = i.ToString();
            //    list.Value = i.ToString();
            //    ddlDateY.Items.Add(list);
            //}
            ////绑定日
            //Bindrq();

            ////绑定时
            //for (int i = 0; i < 24; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = i.ToString();
            //    list.Value = i.ToString();
            //    ddlDateS.Items.Add(list);
            //}

            ////绑定分
            //for (int i = 0; i < 60; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = i.ToString();
            //    list.Value = i.ToString();
            //    ddlDateF.Items.Add(list);
            //}
        }
        /// <summary>
        /// 绑定彩种
        /// </summary>
        private void ddlLotteryBind()
        {
            //Pbzx.BLL.PBnet_LotteryMenu lm = new Pbzx.BLL.PBnet_LotteryMenu();
            //DataSet ds = lm.GetList("NvarClass='全国福彩' or NvarClass='全国体彩'");

            //ddlLottery.DataSource = ds;
            //ddlLottery.DataTextField = "NvarName";
            //ddlLottery.DataValueField = "Intid";
            //ddlLottery.DataBind();
            DataSet daset = DbHelperSQL.Query("SELECT LotteryID FROM Market_Type GROUP BY LotteryID");
            //当数据大于0时
            string ids = "";
            for (int i = 0; i < daset.Tables[0].Rows.Count; i++)
            {
                if (daset.Tables[0].Rows[i]["LotteryID"].ToString() != "")
                {
                    ids = ids + daset.Tables[0].Rows[i]["LotteryID"].ToString() + ",";
                }
            }
            if (ids != "")
            {

                ids = ids.Substring(0, ids.Length - 1);
                ddlLottery.DataSource = DbHelperSQL.Query("SELECT IntId, NvarName FROM PBnet_LotteryMenu WHERE (IntId IN (" + ids + ")) ");

                ddlLottery.DataTextField = "NvarName";
                ddlLottery.DataValueField = "IntId";
                ddlLottery.DataBind();

            }
            ListItem it = new ListItem("--请选择彩种--", "0");
            ddlLottery.Items.Insert(0, it); 

        }
        private void XMBind()
        {
            ddlitemName.Items.Clear();
            ddlitemName.Items.Add(new ListItem("--请选择条件--", "0"));
            ////修改前
            //DataSet dds = markepage.Market_GetItme("NvarName, TypeName,appendId", "Userid=" + Method.Get_UserID);
            //修改后
            DataSet dds = markepage.Market_GetItme("distinct NvarName, TypeName,appendId ", "Userid=" + "'" + Method.Get_UserName.ToString() + "'" + " and On_off <>3 and LotteryID=" + Convert.ToInt32(ddlLottery.SelectedValue) + " and On_Off<>3");
            for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
            {

                if (dds.Tables[0].Rows.Count > 0)
                {
                    ListItem list = new ListItem();
                    list.Text = dds.Tables[0].Rows[i]["TypeName"].ToString();
                    //修改了绑定的Value值。  同一个用户只能有1个 彩票类型。   后面根据 typeID  和 用户ID  得到 项目ID  
                    //id 是彩票类型表里的id  和 项目表里的typeID 对应。
                    list.Value = dds.Tables[0].Rows[i]["appendId"].ToString();
                    ddlitemName.Items.Add(list);
                }

                //  绑定到ddl数据列表中

            }
            if (ddlitemName.Items.Count <= 0)
            {
                ListItem lite = new ListItem();
                lite.Text = "无最新项目";
                lite.Value = "无最新项目";
                ddlitemName.Items.Clear();
                ddlitemName.Items.Add(lite);
            }
        }
        /// <summary>
        /// 期数绑定方法
        /// </summary>
        private void QSBind()
        {
            ////开发期间,这里只是模拟
            //Random ra = new Random();
            //txtYCqs.Text = ra.Next(10000, 99999).ToString();
        }

        /// <summary>
        /// 点击发布期数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button1_Click(object sender, EventArgs e)
        //{
            //if (ddlitemName.SelectedValue == "无最新项目" || ddlitemName.SelectedValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('暂时没有最新的项目发布！请随时留意我们的pinble论坛！');", true);
            //    return;
            //}

            //Market_Num mark = new Market_Num();

            //mark.ItemID = Convert.ToInt32(ddlitemName.SelectedValue);
            //mark.ExpectNum = txtYCqs.Text;

            ////发布时间
            //if (rdbtfabu.SelectedValue == "0")
            //    mark.IssueTime = "0";
            //else
            //    mark.IssueTime = ddlDateH.SelectedValue + "-" + ddlDateY.SelectedValue + "-" + ddlDateR.SelectedValue + " " + ddlDateS.SelectedValue + ":" + ddlDateF.SelectedValue;


            //mark.Commend = Convert.ToInt32(rdbttuijian.SelectedValue);

            //mark.Content = txtContent.Text;
            //if (markmanager.Add(mark) > 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
            //    Response.Write("<script language=javascript>window.close();</script>");

            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
            //}

        //}

        /// <summary>
        /// 设置发布时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbtfabu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdbtfabu.SelectedValue == "0")
            //{
            //    txtDate.Visible = false;
            //}
            //else
            //{
            //    ddlDateY.SelectedValue = DateTime.Now.Month.ToString();
            //    ddlDateR.SelectedValue = (DateTime.Now.Day + 1).ToString();
            //    txtDate.Visible = true;
            //}
        }
        /// <summary>
        /// 根据选择的月份来判断每个月的天数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDateY_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindrq();
        }
        /// <summary>
        /// 绑定日期的方法
        /// </summary>
        private void Bindrq()
        {
            //ddlDateR.Items.Clear();
            ////绑定日期
            //if (Convert.ToInt32(ddlDateY.SelectedValue) % 2 != 0)
            //{
            //    for (int i = 1; i < 31; i++)
            //    {
            //        ListItem list = new ListItem();
            //        list.Text = i.ToString();
            //        list.Value = i.ToString();
            //        ddlDateR.Items.Add(list);
            //    }
            //}
            //else
            //{

            //    if (ddlDateY.SelectedValue == "2")
            //    {
            //        for (int i = 1; i < 29; i++)
            //        {
            //            ListItem list = new ListItem();
            //            list.Text = i.ToString();
            //            list.Value = i.ToString();
            //            ddlDateR.Items.Add(list);
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 1; i < 32; i++)
            //        {
            //            ListItem list = new ListItem();
            //            list.Text = i.ToString();
            //            list.Value = i.ToString();
            //            ddlDateR.Items.Add(list);
            //        }
            //    }
            //}
        }

        protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //项目列表绑定
            XMBind();
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ItemEnactment.aspx");
        }


    }
}
