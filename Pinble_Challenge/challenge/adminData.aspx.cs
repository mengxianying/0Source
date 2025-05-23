using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pinble_Challenge.challenge
{
    public partial class adminData : System.Web.UI.Page
    {
        DataTable IsResult = new DataTable();
        Pbzx.BLL.Challenge_Cinfo get_cf = new Pbzx.BLL.Challenge_Cinfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindGridView1();
            }
        }

        //自定义序号
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }

        //绑定数据
        public void BindGridView1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("C_name is not null and C_Num is not null");
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "c_Time desc";
            int mycount = 0;
            IsResult = get_cf.GuestGetBySearchCinfo(Searchstr, "*", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.GridView1.DataSource = IsResult;
            this.GridView1.DataKeyNames = new string[] { "C_id" };
            this.GridView1.DataBind();
            AspNetPagerConfig(mycount);
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 50;
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
            BindGridView1();
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int n_count = this.GridView1.Rows.Count;
            for (int i = 0; i < n_count; i++)
            {
                Label lab_win = this.GridView1.Rows[i].Cells[0].FindControl("lab_win") as Label;
                //查询开奖号码
                Label lab_num = this.GridView1.Rows[i].Cells[0].FindControl("lab_num") as Label;

                //彩种
                Label lab_lottName = this.GridView1.Rows[i].Cells[0].FindControl("lab_lottName") as Label;
                //行的状态是：正常状态 或者 交替行           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (Convert.ToInt32(IsResult.Rows[i]["C_win"]) == 0)
                    {
                        lab_win.Text = "未开奖";
                    }
                    if (Convert.ToInt32(IsResult.Rows[i]["C_win"]) == 1)
                    {
                        lab_win.Text = "中奖";
                    }
                    if (Convert.ToInt32(IsResult.Rows[i]["C_win"]) == 2)
                    {
                        lab_win.Text = "未中奖";
                    }
                   

                    //开奖号码
                    string num = Method.RlotteryNum(Convert.ToInt32(IsResult.Rows[i]["C_lottID"]), Convert.ToInt32(IsResult.Rows[i]["C_issue"]));

                    lab_num.Text = num;

                    if (Convert.ToInt32(IsResult.Rows[i]["C_lottID"]) == 1)
                    {
                        lab_lottName.Text = "福彩3D";
                    }
                    if (Convert.ToInt32(IsResult.Rows[i]["C_lottID"]) == 3)
                    {
                        lab_lottName.Text = "双色球";
                    }
                    if (Convert.ToInt32(IsResult.Rows[i]["C_lottID"]) == 9999)
                    {
                        lab_lottName.Text = "排列三";
                    }

                }
                //如果是绑定数据行 
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        ((LinkButton)e.Row.Cells[10].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[2].Text + "\"吗?')");
                    }
                } 


            }


        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_cf.Delete(Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value)))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                cb_full.Checked = false;
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("cb");
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

        /// <summary>
        /// 删除选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            bool n_state=false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {

                    n_state = get_cf.Delete(Convert.ToInt32(GridView1.DataKeys[i].Value));
                }
            }
            if (n_state == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
            }
        }

        /// <summary>
        /// 取消选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("cb");
                cb.Checked = false;
            }
        }

        /// <summary>
        /// 搜索 按会员名或是期号或是条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_search_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("C_name is not null and C_Num is not null");
            if (IsNumeric(txt_condition.Text.ToString()))
            {
                sb.Append(" and C_issue=" + "'" + txt_condition.Text.ToString() + "'");
            }
            else
            {
                sb.Append(" and C_name=" + "'" + txt_condition.Text.ToString() + "'");
                sb.Append(" or T_cond=" + "'" + txt_condition.Text.ToString() + "'");

            }

            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "C_Time desc";
            int mycount = 0;
            IsResult = get_cf.GuestGetBySearchCinfo(Searchstr, "*", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.GridView1.DataSource = IsResult;
            this.GridView1.DataKeyNames = new string[] { "C_id" };
            this.GridView1.DataBind();
            AspNetPagerConfig(mycount);
        }
        private static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        } 
    }
}