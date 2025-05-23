using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Pbzx.Web.PB_Manage.Platform.num
{
    public partial class ReleaseManage : AdminBasic
    {
        DataTable IsResult = new DataTable();
        Pbzx.BLL.DataRivalry_UpLoadFile get_up = new Pbzx.BLL.DataRivalry_UpLoadFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMyGridView("1=1");
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindMyGridView(string sqlwhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(sqlwhere);
            string Searchstr = sb.ToString();
            string order = "F_drID desc";
            int myCount = 0;
            IsResult = get_up.GuestGetBySearchUp(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = IsResult;
            MyGridView.DataKeyNames = new string[] { "F_drID" };
            MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (IsResult == null || IsResult.Rows.Count <= 0)
            {
                AspNetPager1.Visible = false;
            }
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
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
            BindMyGridView("1=1");
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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Pbzx.BLL.DataRivalry_Contrast get_c = new Pbzx.BLL.DataRivalry_Contrast();
                get_c.DeleteJoint(Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value));
                Pbzx.BLL.DataRivalry_Rt get_rt = new Pbzx.BLL.DataRivalry_Rt();
                get_rt.DeleteJoint(Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value));
                if (get_up.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                    cb_full.Checked = false;
                    BindMyGridView("1=1");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
                }
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MyGridView.EditIndex = e.NewEditIndex;
            BindMyGridView("1=1");
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
            int n_state = 0;
            for (int i = 0; i < MyGridView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {
                    try
                    {
                        Pbzx.BLL.DataRivalry_Contrast get_c = new Pbzx.BLL.DataRivalry_Contrast();
                        get_c.DeleteJoint(Convert.ToInt32(MyGridView.DataKeys[i].Value));
                        Pbzx.BLL.DataRivalry_Rt get_rt = new Pbzx.BLL.DataRivalry_Rt();
                        get_rt.DeleteJoint(Convert.ToInt32(MyGridView.DataKeys[i].Value));
                        n_state = get_up.Delete(Convert.ToInt32(MyGridView.DataKeys[i].Value));
                    }
                    catch (Exception ex)
                    {
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }

                }
            }
            if (n_state > 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                BindMyGridView("1=1");
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
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sqlwere = new StringBuilder();
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (sqlwere.Length > 0)
                {
                    sqlwere.Append(" and F_UserName=" + "'" + txtName.Text.ToString() + "'");
                }
                else
                {
                    sqlwere.Append("F_UserName=" + "'" + txtName.Text.ToString() + "'");
                }
            }
            if (!string.IsNullOrEmpty(txtDate.Text))
            {
                if (sqlwere.Length > 0)
                {
                    sqlwere.Append(" and F_FileName like " + "'" +"%"+ txtDate.Text.ToString()+"%" + "'");
                }
                else
                {
                    sqlwere.Append("F_FileName like " + "'" + "%" + txtDate.Text.ToString() + "%" + "'");
                }
            }
            if (!string.IsNullOrEmpty(txtIssue.Text))
            {
                if (sqlwere.Length > 0)
                {
                    sqlwere.Append(" and F_Period=" + "'" + txtIssue.Text.ToString() + "'");
                }
                else
                {
                    sqlwere.Append("F_Period=" + "'" + txtIssue.Text.ToString() + "'");
                }
            }
            if (!string.IsNullOrEmpty(txtSmall.Text) && !string.IsNullOrEmpty(txtBig.Text))
            {
                if (!IsNumeric(txtSmall.Text) && !IsNumeric(txtBig.Text))
                {
                    if (sqlwere.Length > 0)
                    {
                        sqlwere.Append(" and F_FileNum>" + Convert.ToInt32(txtSmall.Text) + " and F_FileNum<" + Convert.ToInt32(txtBig.Text));
                    }
                    else
                    {
                        sqlwere.Append("F_FileNum>" + Convert.ToInt32(txtSmall.Text) + " and F_FileNum<" + Convert.ToInt32(txtBig.Text));
                    }
                }
            }
            BindMyGridView(sqlwere.ToString());
        }
        //验证字符串是否是纯数字
        private static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReleaseManage.aspx");
        }

    }
}