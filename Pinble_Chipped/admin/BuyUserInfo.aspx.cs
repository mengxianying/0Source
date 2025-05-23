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
    public partial class BuyUserInfo : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_InfoManage get_inf = new Pbzx.BLL.Chipped_InfoManage();
        DataTable IResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMy_GridView();
            }
        }

        /// <summary>
        /// 绑定合买用户信息
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            string order = "chippedTime desc";
            int myCount = 0;
            IResult = get_inf.GuestGetBySearchChipped_Info(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                myGridView.DataSource = IResult;
                myGridView.DataKeyNames = new string[] { "QNumber" };
                myGridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 30;
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
            BindMy_GridView();
        }

        protected void myGridView_RowCreated1(object sender, GridViewRowEventArgs e)
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

        //删除数据
        protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_inf.Delete(myGridView.DataKeys[e.RowIndex].Value.ToString()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除成功')", true);
                BindMy_GridView();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('删除失败')", true);
            }
        }
    }
}