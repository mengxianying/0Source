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


namespace Pinble_Market.admin
{
    public partial class Attention : System.Web.UI.Page
    {
        Pbzx.BLL.Market_CollASAtten coll = new Pbzx.BLL.Market_CollASAtten();
        Pbzx.Model.Market_CollASAtten ModColl = new Pbzx.Model.Market_CollASAtten();
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        DataTable g_dt = new DataTable();
        private string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='../login.aspx'</script>");
                Response.End();
                return;
            }
            if(!IsPostBack)
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
            StringBuilder sb=new StringBuilder();
            sb.Append("Uname="+ "'"+ Method.Get_UserName.ToString()+"'" );
            sb.Append(" and Statc=1 and Mark=2");
            string Searchstr = sb.ToString();
            string order = "intId desc";
            int myCount = 0;

            g_dt = coll.GuestGetBySearchCollasAttention(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()) , 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (g_dt.Rows.Count > 0 && g_dt!=null)
            {

                myGridView.DataSource = g_dt;
                myGridView.DataKeyNames = new string[] { "intId","appName" };
                myGridView.DataBind();

            }
            else
            {
                AspNetPager1.Visible = false;
                litContent.Text = "<font color='red'>您没有关注项目!</font>";
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
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('删除成功')", true);
                
                //Page.ClientScript.RegisterClientScript(this.GetType(), "upScript", "<script>alert('删除成功！')</script>");
                BindGridView1();
            }
            else
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "upScript", "<script>alert('删除失败！')</script>");
            }
        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Pbzx.BLL.Market_Page page = new Pbzx.BLL.Market_Page();
            DataSet ds = new DataSet();
            int count = myGridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                ds = page.Market_GetNum("top 1 ExpectNum,NvarName,TypeName", "appendID=" + Convert.ToInt32(g_dt.Rows[i]["appName"]) + " order by ExpectNum desc");

                Label Lab_ItemName = (Label)this.myGridView.Rows[i].Cells[0].FindControl("Lab_ItemName") as Label;
                Lab_ItemName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString() + ds.Tables[0].Rows[0]["TypeName"].ToString();

                //最新期号
                Label lab_Num = (Label)this.myGridView.Rows[i].Cells[0].FindControl("lab_Num") as Label;
                lab_Num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();

                LinkButton lbtn_buy = (LinkButton)this.myGridView.Rows[i].Cells[0].FindControl("lbtn_buy") as LinkButton;
                lbtn_buy.CommandArgument = g_dt.Rows[i]["appName"].ToString();

                LinkButton Lb_Btn_Collection = (LinkButton)this.myGridView.Rows[i].Cells[0].FindControl("Lb_Btn_Collection") as LinkButton;
                Lb_Btn_Collection.CommandArgument = g_dt.Rows[i]["appName"].ToString();
            }


        }
        //购买
        protected void lbtn_buy_Command(object sender, CommandEventArgs e)
        {
            //判断是否收费项目
            //是否收费项目
            Pbzx.BLL.Market_appendItemManager app = new Pbzx.BLL.Market_appendItemManager();
            Pbzx.Model.Market_appendItem modapp = app.GetModel(Convert.ToInt32(e.CommandArgument));
            if (modapp.Charge == 1)
            {
                //Response.Write("<script>window.open(buy.aspx?appendId='" + Input.Encrypt(e.CommandArgument.ToString()) + "')</script>");
                Response.Write("<script>window.open('../buy.aspx?appendId=" + Input.Encrypt(e.CommandArgument.ToString()) + "')</script>");
            }
            else
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('此条件不收费')", true);
            }
        }
        //收藏
        protected void Lb_Btn_Collection_Command(object sender, CommandEventArgs e)
        {
            str = get_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('"+ str +"')", true);
        }

    }
}
