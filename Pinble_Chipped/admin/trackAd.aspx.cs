using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pinble_Chipped.admin
{
    public partial class trackAd : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_TrackNum get_tn = new Pbzx.BLL.Chipped_TrackNum();
        DataTable IResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cb_full.Checked = false;
                BindMyGridView();
            }
        }
        /// <summary>
        /// 绑定序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }

        //绑定数据
        public void BindMyGridView()
        {
            string reqStr = "";
            if (!string.IsNullOrEmpty(Request["prar"]))
            {
                reqStr = Request["prar"].ToString();
            }

            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(reqStr))
            {
                sb.Append("tn_orderNum like '%" + reqStr + "%' or tn_username like '%" + reqStr + "%' or tn_playname like '%"+ reqStr +"%'");
            }
            else
            {
                sb.Append("1=1");
            }
            string Searchstr = sb.ToString();
            string order = "tn_time desc";
            int myCount = 0;
            IResult = get_tn.GuestGetBySearchTrackNum(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                MyGridView.DataSource = IResult;
                MyGridView.DataKeyNames = new string[] { "tn_Id" };
                MyGridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            cb_full.Checked = false;
            AspNetPager1.PageSize = 30;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMyGridView();
        }

        //全选事件
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

        //全选删除
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {
                    if (!get_tn.Delete(Convert.ToInt32(MyGridView.DataKeys[i].Value)))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除数据出现错误，请重新删除')</script>");
                        break;
                        
                    }
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功')</script>");
            BindMyGridView();
        }
        //取消删除
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }
        }

        //删除数据
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            if (get_tn.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功！')</script>");
                BindMyGridView();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败！')</script>");
            }
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             //如果是绑定数据行   
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //删除提示
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[15].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除:第" + e.Row.Cells[1].Text + "行/吗?')");
                }

                //行的状态是： 编辑状态 或者 （交替行且是编辑状态）             
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                { 
                    
                }
            }


        }

        protected void MyGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MyGridView.EditIndex = e.NewEditIndex;
            BindMyGridView();
        }

        //更新 修改
        protected void MyGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //停止条件
            TextBox txt_stopCondition = (TextBox)(MyGridView.Rows[e.RowIndex].Cells[5].Controls[0]);
        }
    }
}