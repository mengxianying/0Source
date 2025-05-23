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
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;
namespace Pinble_Market.admin
{
    public partial class Market_ItemManage : System.Web.UI.Page
    {
        Market_appendItemManager appenditem = new Market_appendItemManager();
        Market_TypeManager marktype = new Market_TypeManager();
        Pbzx.BLL.PBnet_UserTable usertype = new Pbzx.BLL.PBnet_UserTable();
        Pbzx.BLL.PBnet_LotteryMenu lotterymenu = new Pbzx.BLL.PBnet_LotteryMenu();
        Pbzx.BLL.Market_BuyInfo byinfomanager = new Pbzx.BLL.Market_BuyInfo();
        Pbzx.BLL.Market_NumManager numnamage = new Pbzx.BLL.Market_NumManager();
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
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='/UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");
                Response.End();
                return;


            }

            if (!IsPostBack)
            {
                BindDiv();
            }

        }
        /// <summary>
        /// DIV数据绑定
        /// </summary>
        private void BindDiv()
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataKeyNames = new string[] { "appendId" };
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (g_ds == null || g_ds.Rows.Count == 0)
            {
                cb_full.Visible = false;
                btn_delete.Visible = false;
                btn_cancel.Visible = false;
                AspNetPager1.Visible = false;
                litContent.Text = "<font color='blue'>您没有设定任何项目！ </font></b>&nbsp;&nbsp;&nbsp;<a href='/ItemEnactment.aspx' target='mainFrame' ><font color='red'>现在就去发布</font></a>";
            }
            else
            {
                litContent.Visible = false;
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
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + myGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDiv();
        }

        /// <summary>
        /// 格式化收费类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string BindSF(object obj)
        {
            if (obj != null)
            {
                if (Convert.ToInt32(obj) == 0)
                {
                    return "免费";
                }
                else
                {
                    return "收费";
                }
            }
            else
            {
                return "出现异常";
            }
        }
        /// <summary>
        /// 格式化状态显示
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string BindZT(object obj)
        {
            if (obj != null)
            {
                if (Convert.ToInt32(obj) == 0)
                {
                    return "<font color='green'>开放</font>";
                }
                else if (Convert.ToInt32(obj) == 1)
                {
                    return "<font color='green'>锁定</font>";
                }
                else
                {
                    return "<font color='red'>关闭<font>";
                }
            }
            else
            {
                return "出现异常";
            }
        }
        /// <summary>
        /// 当出现事件激发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gvidlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Market_appendItem model = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                if (model != null)
                {
                    //3为用户删除
                    model.On_off = 3;

                    if (appenditem.Update(model) > 0)
                    {
                        this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
                        BindDiv();
                        return;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");

                    }
                }
            }
            else if (e.CommandName == "GB")
            {
                Market_appendItem mark = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                mark.On_off = 2;
                appenditem.Update(mark);
                BindDiv();
                return;
            }
            else if (e.CommandName == "SD")
            {
                Market_appendItem mark = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                mark.On_off = 1;
                appenditem.Update(mark);
                BindDiv();
                return;
            }
            else if (e.CommandName == "KF")
            {
                Market_appendItem mark = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                mark.On_off = 0;
                appenditem.Update(mark);
                BindDiv();
                return;
            }
            else if (e.CommandName == "URL")
            {
                Response.Redirect("ItemEnactment.aspx?itemid=" + e.CommandArgument.ToString());
            }
        }
        /// <summary>
        /// 在数据行绑定时激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gvidlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //判断是否收费
                string fei = (e.Row.Cells[3].FindControl("Label3") as Label).Text;


                if (fei == "收费")
                {
                    //当为收费项目，但订购人为0或者是订购人都过期，可以允许删除
                    //传入项目ID
                    string itemid = (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).CommandArgument;
                    if (itemid != null && itemid != "")
                    {
                        DataSet ds = byinfomanager.GetList(" issueInfoId='" + itemid + "' and EndTime>= '" + DateTime.Now.ToString() + "' ");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = false;
                        }
                        else
                        {
                            (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = true;
                        }
                    }
                    else
                    {
                        (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = false;
                    }

                }
                else
                {
                    (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = true;
                }

                string kf = (e.Row.Cells[8].FindControl("Label4") as Label).Text;
                if (kf == "<font color='green'>开放</font>")
                    (e.Row.Cells[9].FindControl("linkbut1") as LinkButton).Enabled = false;
                else if (kf == "<font color='green'>锁定</font>")
                    (e.Row.Cells[9].FindControl("linkbut2") as LinkButton).Enabled = false;
                else if (kf == "<font color='red'>关闭<font>")
                    (e.Row.Cells[9].FindControl("linkbut3") as LinkButton).Enabled = false;

                (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Attributes.Add("onclick", "javascript:return confirm('确定要删除此项目吗！');");
                (e.Row.Cells[9].FindControl("linkbut3") as LinkButton).Attributes.Add("onclick", "javascript:return confirm('确定真要关闭此项目吗！关闭后，您将停止对此项目的发布！');");
            }
        }
        /// <summary>
        /// 数据格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string TextFormat(object obj, int length)
        {

            string source = obj.ToString();
            if (length <= 0)
            {
                return source;
            }
            else
            {
                int tempLength = Method.GetStrLen(source);
                int charLength = 0;
                int hzLength = 0;

                //string tempResult = "";
                if (tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
                    //int intLen = 0;
                    for (int i = 0; i < cc.Length; i++)
                    {
                        if (Convert.ToInt32(cc[i]) > 255)
                        {
                            hzLength++;

                        }
                        else
                        {
                            charLength++;
                        }

                        if ((hzLength * 2 + charLength) % 2 == 0 && hzLength * 2 + charLength >= length || (hzLength * 2 + charLength) % 2 == 1 && hzLength * 2 + charLength >= length - 1)
                        {
                            break;
                        }
                    }
                    return source.Substring(0, (hzLength + charLength) - 1) + "..";
                }
                else
                {
                    return source;
                }
            }
        }

        protected void Gvidlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// 编辑格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public string zu(object obj, object obj1, object obj2)
        {
            return obj + "," + obj1 + "," + obj2.ToString();
        }

        /// <summary>
        /// ID自动编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gvidlist_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }
        //收费项目列表
        protected void lbtn_speakfor_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and Charge=1");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }
        //免费项目列表
        protected void lbtn_free_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and Charge=0");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }
        /// <summary>
        /// 判断是否发布了最新一期的内容
        /// </summary>
        /// obj 传入彩种类型，判断是否发布了最后一期
        /// obj1 项目ID
        /// <returns></returns>
        public string BindNR(object obj, object obj1)
        {
            WebService1 wbs = new WebService1();
            string issus = wbs.lotteryNum(obj.ToString());
            DataSet dst = numnamage.GetList("ExpectNum='" + issus + "' and ItemID='" + obj1.ToString() + "'");
            if (dst.Tables[0].Rows.Count > 0)
            {
                return "<font color='green'>" + issus + " 期已发布</font>";
            }
            else
            {
                return "<font color='red'>" + issus + " 期未发布</font>";
            }
        }
        //重置
        protected void lbtn_resetTool_Click(object sender, EventArgs e)
        {
            BindDiv();
        }

        //开放状态
        protected void lbtn_open_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and On_off=0");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }

        //关闭状态
        protected void lbtn_close_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and On_off=2");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }
        //删除选中
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            //{
            //    CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
            //    if (cb.Checked == true)
            //    {
            //        Market_appendItem model = appenditem.GetModel(Convert.ToInt32(myGridView.DataKeys[i].Value));
            //        if (model != null)
            //        {
            //            //3为用户删除
            //            model.On_off = 3;

            //            if (appenditem.Update(model) > 0)
            //            {
            //                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
            //                BindDiv();
            //                return;
            //            }
            //            else
            //            {
            //                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");

            //            }
            //        }
            //    }
            //}

        }
        //取消删除
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }

        }
        //全选事件
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                if (cb_full.Checked == true)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }

    }
}
