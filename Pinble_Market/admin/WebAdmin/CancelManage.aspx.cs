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

namespace Pinble_Market.admin.WebAdmin
{
    public partial class CancelManage : System.Web.UI.Page
    {
        Pbzx.BLL.Market_CancelIndent get_cl = new Pbzx.BLL.Market_CancelIndent();
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        DataTable get_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView1();
            }
        }

        //绑定数据
        public void BindGridView1()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            string order = "CancelID desc";
            int myCount = 0;
            get_dt = get_cl.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = get_dt;
            myGridView.DataKeyNames = new string[] { "CancelID" };
            myGridView.DataBind();
            if (get_dt != null && get_dt.Rows.Count > 0)
            {
                this.litContent.Text = "";
            }
            else
            {
                this.litContent.Text = "<p>没有要管理的数据</p>";
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);
        }

        ////自动排序。
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
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
            BindGridView1();
        }
        //删除
        protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_cl.Delete(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value)) > 0)
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                BindGridView1();
            }
            else
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
            }
        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.myGridView.Rows.Count;
            
            //判断是否绑定数据
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    //项目
                    Label lab_item = (Label)this.myGridView.Rows[i].FindControl("lab_item");
                    //状态
                    Label lab_state = (Label)this.myGridView.Rows[i].FindControl("lab_state");
                    DataSet ds = get_page.Market_GetItme("NvarName,TypeName", "appendId=" + Convert.ToInt32(get_dt.Rows[i]["CancelItem"]));
                    lab_item.Text = ds.Tables[0].Rows[0]["NvarName"].ToString() + " " + ds.Tables[0].Rows[0]["TypeName"].ToString();

                    if (Convert.ToInt32(get_dt.Rows[i]["CApprove"]) == 1)
                    {
                        lab_state.Text = "退款成功";
                    }
                    if (Convert.ToInt32(get_dt.Rows[i]["CApprove"]) == 2)
                    {
                        lab_state.Text = "退款失败";
                    }
                    if (Convert.ToInt32(get_dt.Rows[i]["CApprove"]) == 3)
                    {
                        lab_state.Text = "<font color='red'>处理中</font>";
                    }
                    if (Convert.ToInt32(get_dt.Rows[i]["CApprove"]) == 4)
                    {
                        lab_state.Text = "驳回申请";
                    }
                }
            }
        }

    }
}
