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
using System.Text;
using System.Drawing;

namespace Pinble_Market.admin.WebAdmin
{
    public partial class ItemSupervise : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page g_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_appendItemManager g_app = new Pbzx.BLL.Market_appendItemManager();
        Pbzx.Model.Market_appendItem g_Modapp = new Pbzx.Model.Market_appendItem();
        //DataSet g_ds = new DataSet();
        DataTable g_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GridView1.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGridView1();
            }
        }

        /// <summary>
        /// 自动生成序号，不是绑定数据
        /// 创建人:zhouwei
        /// 创建时间: 2010-11-3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }

        /// <summary>
        /// 绑定数据源
        /// 创建人:zhouwei
        /// 创建时间:2010-11-3
        /// </summary>
        public void BindGridView1()
        {
            //g_ds = g_page.Market_GetItme("1=1");
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;

            g_dt = g_app.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            GridView1.DataSource = g_dt;
            GridView1.DataKeyNames = new string[] { "appendID" };
            GridView1.DataBind();

            AspNetPagerConfig(myCount);
            if (g_dt == null)
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
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetManageCount());
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + GridView1.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindGridView1();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //查询GV_BuyList有多少条数据
            int count = this.GridView1.Rows.Count;
            


            //行的状态是：正常状态 或者 交替行           
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    Label Lab_state = (Label)this.GridView1.Rows[i].FindControl("Lab_state");
                    Label lab_userName = (Label)this.GridView1.Rows[i].FindControl("lab_userName");
                    lab_userName.Text = g_dt.Rows[i]["UserId"].ToString();
                    if (Lab_state != null)
                    {
                        if (Convert.ToInt32(g_dt.Rows[i]["On_off"]) == 0)
                        {
                            Lab_state.Text = "开放";
                            Lab_state.ForeColor = Color.Green;

                        }
                        if (Convert.ToInt32(g_dt.Rows[i]["On_off"]) == 1)
                        {
                            Lab_state.Text = "锁定";
                            Lab_state.ForeColor = Color.Red;

                        }
                        if (Convert.ToInt32(g_dt.Rows[i]["On_off"]) == 2)
                        {
                            Lab_state.Text = "关闭";
                            Lab_state.ForeColor = Color.Black;
                        }
                    }
                }
            }
            //如果行的类型是数据绑定行       
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //行的状态是： 编辑状态 或者 （交替行且是编辑状态）             
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    DropDownList ddl_state = (DropDownList)e.Row.FindControl("ddl_state") as DropDownList;
                    if (ddl_state != null)
                    {
                        ListItem item1 = new ListItem();
                        item1.Value = "0";
                        item1.Text = "开放";
                        ddl_state.Items.Add(item1);
                        ListItem item2 = new ListItem();
                        item2.Value = "1";
                        item2.Text = "锁定";
                        ddl_state.Items.Add(item2);
                        ListItem item3 = new ListItem();
                        item3.Value = "2";
                        item3.Text = "关闭";
                        ddl_state.Items.Add(item3);
                    }
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView1();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            g_Modapp = g_app.GetModel(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            DropDownList ddl_state = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("ddl_state"));
            TextBox txt_Price = (TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0]);

            if (ddl_state != null && txt_Price != null)
            {
                g_Modapp.Price = Convert.ToDecimal(txt_Price.Text.ToString());
                if (ddl_state.SelectedValue == "0")
                {
                    g_Modapp.On_off = 0;
                }
                if (ddl_state.SelectedValue == "1")
                {
                    g_Modapp.On_off = 1;
                }
                if (ddl_state.SelectedValue == "2")
                {
                    g_Modapp.On_off = 2;
                }
            }
            int ret = g_app.Update(g_Modapp);
            if (ret > 0)
            {

                //Response.Write(JS.Alert("修改成功！"));
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('修改成功！')", true);
                GridView1.EditIndex = -1;
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('修改失败！')", true);
                return;
            }
        }

        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView1();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //先判断这个项目有没有用户的 订制没有到期的。如果有。  那这个项目就是锁定状态。但是不能删除 如果没有就直接删除
            //if (g_app.Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value)) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('删除成功！')", true);
            //    BindGridView1();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('删除失败！')", true);
            //}
        }


    }
}
