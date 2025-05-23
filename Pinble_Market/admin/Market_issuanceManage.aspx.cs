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
using Pinble_Market.AppCod;
using System.Text;


namespace Pinble_Market.admin
{
    public partial class Market_issuanceManage : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page g_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_NumManager g_num = new Pbzx.BLL.Market_NumManager();
        DataSet g_ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='/login.aspx'</script>");
                //Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='" + WebInit.market.WebUrl + "/login.aspx'</script>");
                Response.End();
                return;
            }
            //�ж��û��Ƿ��¼�Ƿ��Ǹ߼��û�
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");
                Response.End();
                return;

            }
            if (!IsPostBack)
            {
                this.myGridView.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGridView1();
            }
        }

        //�������
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }

        /// <summary>
        /// �󶨹����б�
        /// ������: zhouwei
        /// ����ʱ��: 2010-11-10
        /// </summary>
        public void BindGridView1()
        {
            int id = Convert.ToInt32(Input.Decrypt(Request["id"]));
            DateTime time = Convert.ToDateTime(Input.Decrypt(Request["time"]));
            StringBuilder sb = new StringBuilder();
            sb.Append("ItemID=" + id);
            sb.Append(" and IssueTime>"+"'"+ time +"'");
            string Searchstr = sb.ToString();
            string order = "ExpectNum desc";
            int myCount = 0;

            dt = g_num.GuestGetBySearchNum(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);

            if (dt != null && dt.Rows.Count > 0)
            {
                myGridView.DataSource = dt;
                myGridView.DataKeyNames = new string[] { "id", "ItemID" };
                myGridView.DataBind();

            }
            else
            {
                AspNetPager1.Visible = false;
                litContent.Text = "<p>����û�з�����������������κ�����</p>";
            }
            AspNetPagerConfig(myCount);
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = Convert.ToInt32(myGridView.Rows.Count);

            g_ds = g_page.Market_GetItme("appendID=" + Convert.ToInt32(dt.Rows[0]["ItemID"]));

            if (g_ds != null)
            {
                for (int i = 0; i < count; i++)
                {
                    Label lab_Name = (Label)this.myGridView.Rows[i].FindControl("lab_Name") as Label;
                    lab_Name.Text = g_ds.Tables[0].Rows[0]["NvarName"].ToString() + g_ds.Tables[0].Rows[0]["TypeName"].ToString();
                }
            }
            
        }
        //���ں�����
        protected void Ibtn_scout_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(Input.Decrypt(Request["id"]));
            StringBuilder sb = new StringBuilder();
            sb.Append("ItemID=" + id);
            sb.Append("ExpectNum=" + "'" + Request.Form["username"].ToString() + "'");
            string Searchstr = sb.ToString();
            string order = "ExpectNum desc";
            int myCount = 0;

            dt = g_num.GuestGetBySearchNum(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = dt;
            myGridView.DataKeyNames = new string[] { "id", "ItemID" };
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }

        //���ںŵ�˳������
        protected void lbtn_order_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Input.Decrypt(Request["id"]));
            StringBuilder sb = new StringBuilder();
            sb.Append("ItemID=" + id);
            string Searchstr = sb.ToString();
            string order = "ExpectNum";
            int myCount = 0;

            dt = g_num.GuestGetBySearchNum(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = dt;
            myGridView.DataKeyNames = new string[] { "id", "ItemID" };
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
            
        }

        //���ںŵĵ�������
        protected void lbtn_desc_Click(object sender, EventArgs e)
        {
            BindGridView1();
        }

        //protected void Btn_appraise_Command(object sender, CommandEventArgs e)
        //{
        //    Page.RegisterStartupScript("scriptOpen","<script>window.open(Opinion.aspx?opid='"+ Convert.ToInt32(e.CommandArgument) +"')</script>");
        //}
    }
}
