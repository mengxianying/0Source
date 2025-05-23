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

namespace Pinble_Help.pinbleHelp
{
    public partial class ModifyNoet : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        DataTable IsResult = new DataTable();
        DataSet dsIsResult = new DataSet();
        public static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                
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
                e.Row.Cells[1].Text = (MyGridView.PageIndex * MyGridView.PageSize + e.Row.RowIndex + 1).ToString();


            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindMyGridView()
        {
            id = Request["id"].ToString();
            if (!string.IsNullOrEmpty(Request["superiorNoet"]))
            {
                dsIsResult = get_ts.GetList("Tree_name=" + "'" + id + "'" + " and Tree_superiorNoet=" + "'" + Request["superiorNoet"].ToString() + "'" + " order by Tree_sort asc");

                MyGridView.DataSource = dsIsResult;
                MyGridView.DataKeyNames = new string[] { "Tree_id" };
                MyGridView.DataBind();
            }
            else
            {

                dsIsResult = get_ts.GetList("Tree_name=" + "'" + id + "'" + " order by Tree_sort asc");

                MyGridView.DataSource = dsIsResult;
                MyGridView.DataKeyNames = new string[] { "Tree_id" };
                MyGridView.DataBind();
            }
        }



        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = get_ts.GetList("Tree_id=" + "'" + this.MyGridView.DataKeys[e.RowIndex].Value + "'");

            //查询是否有子节点
            DataSet dsNoet = get_ts.GetList("Tree_superiorNoet=" + "'" + ds.Tables[0].Rows[0]["Tree_num"].ToString() + "'");


            if (dsNoet.Tables[0].Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>if(!confirm('删除的节点下还有子节点！确定删除？')){return false;}</script>");
                //删除子节点数据
                if (get_ts.Delete(ds.Tables[0].Rows[0]["Tree_superiorNoet"].ToString()) > 0)
                {
                    //删除本身的数据
                    if (get_ts.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功！')</script>");
                        BindMyGridView();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败！')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败！')</script>");
                }
            }
            else
            {
                if (get_ts.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功！')</script>");
                    BindMyGridView();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败！')</script>");
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
        //删除选中
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {
                    if (get_ts.Delete(Convert.ToInt32(MyGridView.DataKeys[i].Value)) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除成功')</script>");
                        BindMyGridView();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('删除失败')</script>");
                    }
                }
            }

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
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                MyGridView.PageIndex = e.NewPageIndex;
                BindMyGridView();
                TextBox tb = (TextBox)MyGridView.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (MyGridView.PageIndex + 1).ToString();
            }
            catch { }
        }

        protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)MyGridView.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    MyGridView_PageIndexChanging(null, ea);
                }
                catch { }
            }
        }

        //搜索
        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataSet dsSearch = get_ts.GetList("Tree_RootNotd like '%" + txt_search.Text + "%' or Tree_num like '%"+txt_search.Text+"%'");
            MyGridView.DataSource = dsSearch;
            MyGridView.DataKeyNames = new string[] { "Tree_id" };
            MyGridView.DataBind();
        }

    }
}

