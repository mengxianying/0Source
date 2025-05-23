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

namespace Pinble_DataRivalry.admin
{
    public partial class ReleaseManage : System.Web.UI.Page
    {
        DataTable IsResult = new DataTable();
        Pbzx.BLL.DataRivalry_UpLoadFile get_up = new Pbzx.BLL.DataRivalry_UpLoadFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindMy_GridView();
            }
        }

        /// <summary>
        /// 自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void my_GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            string order = "F_drID desc";
            int myCount = 0;
            IsResult = get_up.GuestGetBySearchUp(Searchstr, "*", order, 60, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.my_GridView.DataSource = IsResult;
            my_GridView.DataKeyNames = new string[] { "F_drID"};
            my_GridView.DataBind();
            AspNetPagerConfig(myCount);
            if (IsResult == null || IsResult.Rows.Count <= 0)
            {
                AspNetPager1.Visible = false;
            }
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize =60;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + my_GridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindMy_GridView();
        }

        

        /// <summary>
        /// 删除数据
        /// </summary>
        protected void my_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            try
            {
                Pbzx.BLL.DataRivalry_Contrast get_c = new Pbzx.BLL.DataRivalry_Contrast();
                get_c.DeleteJoint(Convert.ToInt32(my_GridView.DataKeys[e.RowIndex].Value));
                Pbzx.BLL.DataRivalry_Rt get_rt = new Pbzx.BLL.DataRivalry_Rt();
                get_rt.DeleteJoint(Convert.ToInt32(my_GridView.DataKeys[e.RowIndex].Value));
                if (get_up.Delete(Convert.ToInt32(this.my_GridView.DataKeys[e.RowIndex].Value)) > 0)
                {
                    cb_full.Checked = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                    BindMy_GridView();
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

        /// <summary>
        /// 编辑操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void my_GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            my_GridView.EditIndex = e.NewEditIndex;
            BindMy_GridView();
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= my_GridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)my_GridView.Rows[i].FindControl("cb");
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
            for (int i = 0; i < my_GridView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)my_GridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {
                    try
                    {
                        Pbzx.BLL.DataRivalry_Contrast get_c = new Pbzx.BLL.DataRivalry_Contrast();
                        get_c.DeleteJoint(Convert.ToInt32(my_GridView.DataKeys[i].Value));
                        Pbzx.BLL.DataRivalry_Rt get_rt = new Pbzx.BLL.DataRivalry_Rt();
                        get_rt.DeleteJoint(Convert.ToInt32(my_GridView.DataKeys[i].Value));
                        n_state = get_up.Delete(Convert.ToInt32(my_GridView.DataKeys[i].Value));
                    }
                    catch(Exception ex)
                    {
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }
                    
                }
            }
            if (n_state > 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                BindMy_GridView();
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
            for (int i = 0; i <= my_GridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)my_GridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }
        }

    }
}
