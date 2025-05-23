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

namespace Pinble_Market.admin
{
    public partial class Attention_User : System.Web.UI.Page
    {
        Pbzx.BLL.Market_CollASAtten coll = new Pbzx.BLL.Market_CollASAtten();
        Pbzx.Model.Market_CollASAtten ModColl = new Pbzx.Model.Market_CollASAtten();
        DataTable g_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='../login.aspx'</script>");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                this.myGridView.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGridView1();
            }
        }
        /// <summary>
        /// 绑定数据
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-8
        /// </summary>
        public void BindGridView1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Uname=" + "'"+ Method.Get_UserName.ToString()+"'");
            sb.Append("and Statc=2");
            sb.Append(" and Mark=2");
            string Searchstr = sb.ToString();
            string order = "intId desc";
            int myCount = 0;

            g_dt = coll.GuestGetBySearchCollasAttention(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (g_dt.Rows.Count>0)
            {
                myGridView.DataSource = g_dt;
                myGridView.DataKeyNames = new string[] { "intId" };
                myGridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
                litContent.Text = "<font color='red'>您没有关注任何的用户！</font>";
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
        protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (coll.Delete(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value)) > 0)
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('删除成功！')", true);
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('删除失败！')", true);
            }
        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            int count = this.myGridView.Rows.Count;
            //行的状态是：正常状态 或者 交替行           
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    if (g_dt != null || g_dt.Rows.Count > 0)
                    {
                        DataSet ds = get_page.Market_GetItme("top 1 NvarName,TypeName,appendId", "UserId=" + "'" + g_dt.Rows[i]["appName"] + "'"+" order by appendId desc");
                        Label lab_New = (Label)this.myGridView.Rows[i].FindControl("lab_New");
                        lab_New.Text = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
        }

    }
}
