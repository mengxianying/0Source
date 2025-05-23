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

namespace Pinble_Chipped.admin
{
    public partial class MyAttention : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_Attention get_att = new Pbzx.BLL.Chipped_Attention();
        DataTable IsRseult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href ='/LoginPage.aspx'</script>");
                //Response.Write("<script type='text/javascript'>window.top.location.href ='/LoginPage.aspx'</script>");
                Response.End();
                return;
            }

            if (!IsPostBack)
            {
                BindAttention();
            }
        }

        //¹ÜÀí°ïÖú
        public void BindAttention()
        {
           
            StringBuilder sb = new StringBuilder();
            sb.Append("Attention=" + "'" + Method.Get_UserName.ToString() + "'");
            string Searchstr = sb.ToString();
            string order = "ATime desc";
            int myCount = 0;
            IsRseult = get_att.GuestGetBySearchChipped(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IsRseult != null && IsRseult.Rows.Count > 0)
            {
                My_GridView.DataSource = IsRseult;
                My_GridView.DataKeyNames = new string[] { "Attention" };
                My_GridView.DataBind();
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
            AspNetPager1.CustomInfoHTML = "×Ü<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>Ìõ&nbsp;";
            AspNetPager1.CustomInfoHTML += "±¾Ò³<font color=\"red\"><b>" + My_GridView.Rows.Count + "</b></font>Ìõ&nbsp;";
            AspNetPager1.CustomInfoHTML += "·ÖÒ³:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "Ò³</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindAttention();
        }
        //°ó¶¨ÐòºÅ
        protected void My_GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                //e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }

        //É¾³ý
        protected void My_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (get_att.Delete(My_GridView.DataKeys[e.RowIndex].Value.ToString()) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script>alert('É¾³ý³É¹¦')</script>");
                BindAttention();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script>alert('É¾³ýÊ§°Ü')</script>");
            }
        }
    }
}
