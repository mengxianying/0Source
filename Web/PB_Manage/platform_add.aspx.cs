using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class platform_add : AdminBasic
    {
        Pbzx.BLL.PBnet_platfrom_icon get_pm_l = new BLL.PBnet_platfrom_icon();
        Pbzx.Model.PBnet_platfrom_icon mod_pm_l = new Model.PBnet_platfrom_icon();
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyGridViewBind();
            }
        }



        /// <summary>
        /// 绑定数据
        /// </summary>
        public void MyGridViewBind()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("1=1");
            string Searchstr = strSql.ToString();
            string order = "P_Sort asc";
            int mycount = 0;
            IsResult = get_pm_l.GuestGetBySearchplatfrom(Searchstr, "*", order, 40, 3, AspNetPager1.CurrentPageIndex, out mycount);

            MyGridView.DataSource = IsResult;
            MyGridView.DataKeyNames = new string[] { "p_id" };
            MyGridView.DataBind();
            
            AspNetPagerConfig(mycount);
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 40;
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
            MyGridViewBind();
        }

        /// <summary>
        /// 自动生成序号
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
                    if (!get_pm_l.Delete(Convert.ToInt32(MyGridView.DataKeys[i].Value)))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除数据出现错误，请重新删除')</script>");
                        break;

                    }
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功')</script>");
            MyGridViewBind();
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

        /// <summary>
        /// 添加平台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (get_pm_l.Exists(txtPname.Text.ToString()))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('平台已存在')</script>");
            }
            else {
                mod_pm_l.p_imgName = txtImgName.Text.ToString();
                mod_pm_l.P_pfName = txtPname.Text.ToString();
                mod_pm_l.P_Sort = 0;
                mod_pm_l.P_pfPath = txtUrl.Text.ToString();
                mod_pm_l.P_state = 0;
                if (get_pm_l.Add(mod_pm_l) > 0)
                {
                    DataSet ds = get_pm_l.GetList("P_pfName=" + "'" + txtPname.Text.ToString() + "'");
                    mod_pm_l = get_pm_l.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["P_id"]));
                    mod_pm_l.P_Sort = Convert.ToInt32(ds.Tables[0].Rows[0]["P_id"]);
                    get_pm_l.Update(mod_pm_l);
                    Response.Write("<script>alert('添加成功');</script>");
                    MyGridViewBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加失败')</script>");
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //图片名称
            TextBox txt_imgName = (TextBox)MyGridView.Rows[e.RowIndex].Cells[2].FindControl("txt_imgName") as TextBox;

            //网址
            TextBox txt_pfPath = (TextBox)MyGridView.Rows[e.RowIndex].Cells[3].FindControl("txt_pfPath") as TextBox;

            //名称
            TextBox txt_pfName = (TextBox)MyGridView.Rows[e.RowIndex].Cells[4].FindControl("txt_pfName") as TextBox;

            RadioButtonList RadioButtonList2 = (RadioButtonList)MyGridView.Rows[e.RowIndex].Cells[5].FindControl("RadioButtonList2") as RadioButtonList;
            //排序字段
            TextBox txt_sort = (TextBox)MyGridView.Rows[e.RowIndex].Cells[6].FindControl("txt_sort") as TextBox;

            if (RadioButtonList2.SelectedIndex==-1)
            {
                //没有选择状态
                mod_pm_l = get_pm_l.GetModel(Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value.ToString()));

                mod_pm_l.p_imgName = txt_imgName.Text.ToString();
                mod_pm_l.P_pfPath = txt_pfPath.Text.ToString();
                mod_pm_l.P_pfName = txt_pfName.Text.ToString();
                //判断是否和序号相同
                if (Convert.ToInt32(txt_sort.Text) != Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value.ToString()))
                {
                    //修改
                    mod_pm_l.P_Sort =Convert.ToInt32(txt_sort.Text);
                }
              

                if (get_pm_l.Update(mod_pm_l))
                {
                    Response.Write("<script>alert('修改成功');</script>");
                    MyGridView.EditIndex = -1;
                    MyGridViewBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改失败')</script>");
                }
            }
            else
            {
                mod_pm_l = get_pm_l.GetModel(Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value.ToString()));

                mod_pm_l.p_imgName = txt_imgName.Text.ToString();
                mod_pm_l.P_pfPath = txt_pfPath.Text.ToString();
                mod_pm_l.P_pfName = txt_pfName.Text.ToString();
                mod_pm_l.P_state = Convert.ToInt32(RadioButtonList2.SelectedValue);
                //判断是否和序号相同
                if (Convert.ToInt32(txt_sort.Text) != Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value.ToString()))
                {
                    //修改
                    mod_pm_l.P_Sort = Convert.ToInt32(txt_sort.Text);
                }
                if (get_pm_l.Update(mod_pm_l))
                {
                    Response.Write("<script>alert('修改成功');</script>");
                    MyGridView.EditIndex = -1;
                    MyGridViewBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改失败')</script>");
                }
            }
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MyGridView.EditIndex = -1;
            MyGridViewBind();
        }

        protected void MyGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MyGridView.EditIndex = e.NewEditIndex;
            MyGridViewBind();
        }

        /// <summary>
        /// bound 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //查询GV_BuyList有多少条数据
            int count = this.MyGridView.Rows.Count;

            //行的状态是：正常状态 或者 交替行           
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    //((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text + "\"吗?')");
                }
            }
            //如果行的类型是数据绑定行       
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //行的状态是： 编辑状态 或者 （交替行且是编辑状态）             
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    RadioButtonList rad_btn = (RadioButtonList)e.Row.Cells[5].FindControl("RadioButtonList2") as RadioButtonList;
                    if (IsResult.Rows[0]["P_state"].ToString() == "1")
                    {
                        rad_btn.Items[1].Selected = true;
                    }
                    if (IsResult.Rows[0]["P_state"].ToString() == "0")
                    {
                        rad_btn.Items[0].Selected = true;
                    }
                }

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_pm_l.Delete(Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value.ToString())))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功')</script>");
                MyGridViewBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败')</script>");
            }
        }

    }
}