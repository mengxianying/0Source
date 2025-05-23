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
    public partial class Collection_item : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                this.myGridView.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGridView1();
            }
        }

        /// <summary>
        /// ������Դ
        /// ������: zhouwei
        /// ����ʱ��: 2010-11-8
        /// </summary>
        public void BindGridView1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Uname="+"'"+ Method.Get_UserName.ToString()+"'");
            sb.Append(" and Statc=1 and Mark=1");
            string Searchstr = sb.ToString();
            string order = "intId desc";
            int myCount = 0;

            g_dt = coll.GuestGetBySearchCollasAttention(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (g_dt.Rows.Count > 0)
            {
                myGridView.DataSource = g_dt;
                myGridView.DataKeyNames = new string[] { "intId" };
                myGridView.DataBind();
            }
            else
            {
                AspNetPager1.Visible = false;
                litContent.Text = "<font color='red'>��û���ղ��κ���Ŀ!</font>";
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
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + myGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindGridView1();
        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Pbzx.BLL.Market_Page g_page = new Pbzx.BLL.Market_Page();
            DataSet ds = new DataSet();
            int count = myGridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                ds = g_page.Market_GetItme("NvarName,TypeName","appendID=" + Convert.ToInt32(g_dt.Rows[i]["appName"]));
                Label Lab_itemName = (Label)this.myGridView.Rows[i].Cells[0].FindControl("Lab_itemName") as Label;
                LinkButton Lb_Btn_Attention = (LinkButton)this.myGridView.Rows[i].Cells[0].FindControl("Lb_Btn_Attention") as LinkButton;
                Lb_Btn_Attention.CommandArgument = g_dt.Rows[i]["appName"].ToString();
                if (ds.Tables[0].Rows.Count>0 && ds !=null)
                {
                    
                    Lab_itemName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString() + ds.Tables[0].Rows[0]["TypeName"].ToString();
                }
                else
                {
                    Lab_itemName.Text = "<font color='red'>��Ŀ��ɾ��</font>";
                }
            }
        }

        protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (coll.Delete(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value)) > 0)
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up1", "alert('ɾ���ɹ�')", true);
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up1", "alert('ɾ��ʧ�ܣ�')", true);
            }
        }
        //��ע��Ŀ
        protected void Lb_Btn_Attention_Command(object sender, CommandEventArgs e)
        {
            this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            str = get_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up1", "alert('"+ str +"')", true);
        }
        //����
        protected void lbtn_buy_Command(object sender, CommandEventArgs e)
        {
            //�Ƿ��շ���Ŀ
            Pbzx.BLL.Market_appendItemManager app = new Pbzx.BLL.Market_appendItemManager();
            Pbzx.Model.Market_appendItem modapp = app.GetModel(Convert.ToInt32(e.CommandArgument));
            if (modapp.Charge == 1)
            {
                str = get_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
                if (str == "0")
                {
                    this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up1", "alert('�Ѿ������������')", true);
                }
                else
                {
                    str = "../" + str;
                    Response.Write("<script>window.open('" + str + "')</script>");
                }
            }
            else
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('���������շ�')", true);
            }
            
        }
    }
}
