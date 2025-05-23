using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Pinble_Challenge.challenge
{
    public partial class UserIntegral : System.Web.UI.Page
    {
        DataSet ds_u = new DataSet();
        DataTable IsResult = new DataTable();
        Pbzx.BLL.Challenge_integral get_il = new Pbzx.BLL.Challenge_integral();
        Pbzx.BLL.Challenge_type get_te = new Pbzx.BLL.Challenge_type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["name"] == null)
                {
                    BindGridView1();
                    gd1.Visible = true;
                    gduser.Visible = false;
                }
                else
                {
                    //获取用户name
                    string UserName = Pbzx.Common.Input.URLDecode(Request["name"].ToString());
                    UserName = Pbzx.Common.Input.FilterAll(UserName);
                    BindGridViewUser(UserName);
                    gd1.Visible = false;
                    gduser.Visible = true;
                }
               
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
            
            
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "I_integral desc";
            int mycount = 0;
            IsResult = get_il.GuestGetBySearchIntegral(Searchstr, "*", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.GridView1.DataSource = IsResult;
            this.GridView1.DataKeyNames = new string[] { "I_id" };
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
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_il.Delete(Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value)))
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
            bool n_state = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {

                    n_state = get_il.Delete(Convert.ToInt32(GridView1.DataKeys[i].Value));
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
        /// 绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int n_count = this.GridView1.Rows.Count;
            for (int i = 0; i < n_count; i++)
            {
                //彩种
                Label lab_lott = this.GridView1.Rows[i].Cells[0].FindControl("lab_lott") as Label;

                //条件名称
                Label lab_name = this.GridView1.Rows[i].Cells[0].FindControl("lab_name") as Label;

                //行的状态是：正常状态 或者 交替行           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (Convert.ToInt32(IsResult.Rows[i]["I_lottid"]) == 3)
                    {
                        lab_lott.Text = "双色球";
                    }
                    if (Convert.ToInt32(IsResult.Rows[i]["I_lottid"]) == 1)
                    {
                        lab_lott.Text = "福彩3D";
                    }
                    if (Convert.ToInt32(IsResult.Rows[i]["I_lottid"]) == 9999)
                    {
                        lab_lott.Text = "排列三";
                    }

                    DataSet ds_name = get_te.GetList("T_state="+"'"+ IsResult.Rows[i]["I_condName"].ToString() +"'");
                    lab_name.Text = ds_name.Tables[0].Rows[0]["T_cond"].ToString();
                }
            }
        }

        //绑定数据
        public void BindGridViewUser(string Uname)
        {
            ds_u = get_il.GetList("I_name=" + "'" + Uname + "'");
            this.GridView2.DataSource = ds_u;
            this.GridView2.DataBind();

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int n_count = this.GridView2.Rows.Count;
            for (int i = 0; i < n_count; i++)
            {
                //彩种
                Label lab_lott = this.GridView2.Rows[i].Cells[0].FindControl("lab_lott") as Label;

                //条件名称
                Label lab_name = this.GridView2.Rows[i].Cells[0].FindControl("lab_name") as Label;

                //行的状态是：正常状态 或者 交替行           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (Convert.ToInt32(ds_u.Tables[0].Rows[i]["I_lottid"]) == 3)
                    {
                        lab_lott.Text = "双色球";
                    }
                    if (Convert.ToInt32(ds_u.Tables[0].Rows[i]["I_lottid"]) == 1)
                    {
                        lab_lott.Text = "福彩3D";
                    }
                    if (Convert.ToInt32(ds_u.Tables[0].Rows[i]["I_lottid"]) == 9999)
                    {
                        lab_lott.Text = "排列三";
                    }

                    DataSet ds_name = get_te.GetList("T_state=" + "'" + ds_u.Tables[0].Rows[i]["I_condName"].ToString() + "'");
                    lab_name.Text = ds_name.Tables[0].Rows[0]["T_cond"].ToString();
                }
            }
        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
            }
        }


    }
}