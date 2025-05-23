using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.Platform.match
{
    public partial class adminData : AdminBasic
    {
        DataTable IsResult = new DataTable();
        Pbzx.BLL.Challenge_Cinfo get_cf = new Pbzx.BLL.Challenge_Cinfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView1("1=1");
            }
        }
        //绑定数据
        public void BindGridView1(string Condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("C_name is not null and C_Num is not null");
            sb.Append(" and "+ Condition);
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "c_Time desc";
            int mycount = 0;
            IsResult = get_cf.GuestGetBySearchCinfo(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataKeyNames = new string[] { "C_id" };
            this.MyGridView.DataBind();
            AspNetPagerConfig(mycount);
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 30;
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
            BindGridView1("1=1");
        }

        /// <summary>
        /// 序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_cf.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                cb_full.Checked = false;
                BindGridView1("1=1");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
            }
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int n_count = this.MyGridView.Rows.Count;
            for (int i = 0; i < n_count; i++)
            {
                Label lab_win = this.MyGridView.Rows[i].Cells[0].FindControl("lab_win") as Label;
                //查询开奖号码
                Label lab_num = this.MyGridView.Rows[i].Cells[0].FindControl("lab_num") as Label;

                //彩种
                Label lab_lottName = this.MyGridView.Rows[i].Cells[0].FindControl("lab_lottName") as Label;
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
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
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
            bool n_state = false;
            for (int i = 0; i < MyGridView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {

                    n_state = get_cf.Delete(Convert.ToInt32(MyGridView.DataKeys[i].Value));
                }
            }
            if (n_state == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                BindGridView1("1=1");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminData.aspx");
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.ToString() != "" && txtDate.Text.ToString() != "" && txtCondition.Text.ToString() != "")
            {
                BindGridView1("C_name=" + "'" + txtName.Text.ToString() + "'" + " and C_issue like" + "'" + txtDate.Text.ToString()+ "%" + "'" + " and T_cond=" + "'" + txtCondition.Text.ToString() + "'");
            }
            else if (txtName.Text.ToString() != "" && txtDate.Text.ToString() != "")
            {
                BindGridView1("C_name=" + "'" + txtName.Text.ToString() + "'" + " and C_issue like" + "'" + txtDate.Text.ToString()+ "%" + "'");
            }
            else if (txtName.Text.ToString() != "" && txtCondition.Text.ToString() != "")
            {
                BindGridView1("C_name=" + "'" + txtName.Text.ToString() + "'" + " and T_cond=" + "'" + txtCondition.Text.ToString() + "'");
            }
            else if (txtDate.Text.ToString() != "" && txtCondition.Text.ToString() != "")
            {
                BindGridView1("C_issue like" + "'" + txtDate.Text.ToString()+ "%" + "'" + " and T_cond=" + "'" + txtCondition.Text.ToString() + "'");
            }

            else if (txtName.Text.ToString() != "")
            {
                BindGridView1("C_name=" + "'" + txtName.Text.ToString() + "'");
            }
            else if (txtDate.Text.ToString() != "")
            {
                BindGridView1("C_issue like" + "'" + txtDate.Text.ToString()+"%" + "'");
            }
            else if (txtCondition.Text.ToString() != "")
            {
                BindGridView1("T_cond=" + "'" + txtCondition.Text.ToString() + "'");
            }
        }
    }
}