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
    public partial class BuyLog : System.Web.UI.Page
    {
        Pbzx.BLL.Market_BuyInfo g_buy = new Pbzx.BLL.Market_BuyInfo();
        Pbzx.Model.Market_BuyInfo g_ModBuy = new Pbzx.Model.Market_BuyInfo();
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        DataTable g_ds = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GridView1.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGridView1();
            }
        }
        /// <summary>
        /// �󶨽��������б�
        /// ������: zhouwei\
        /// ����ʱ��: 2010-11-3
        /// </summary>
        public void BindGridView1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            string order = "buyid desc";
            int myCount = 0;
            g_ds = g_buy.GuestGetBySearchBuyInfo(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            GridView1.DataSource = g_ds;
            GridView1.DataKeyNames = new string[] { "issueInfoId","buyid" };
            GridView1.DataBind();
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
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + GridView1.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindGridView1();
        }


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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //��ȡgridview�󶨵�����
            int count = this.GridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //����gridview�е�lable�ؼ�
                Label Lab_ItemName = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_ItemName") as Label;
                Label Lab_ShopName = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_ShopName") as Label;
                Label Lab_buyContinue = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_buyContinue") as Label;
                Label Lab_state = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_state") as Label;

                //g_Modapp = g_app.GetModel(Convert.ToInt32(g_ds.Rows[i]["issueInfoId"]));


                //g_Modtype = g_type.GetModel(g_Modapp.TypeID);
                DataSet ds = get_page.Market_GetItme("NvarName,On_off", "appendId=" + Convert.ToInt32(g_ds.Rows[i]["issueInfoId"]));


                Lab_ItemName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                //�����̻���IDȥBBs�����ݿ��в�ѯ �̻�������
                Lab_ShopName.Text =g_ds.Rows[i]["ShopUserID"].ToString() ;
                 //�е�״̬�ǣ�����״̬ ���� ������           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (Lab_buyContinue != null)
                    {
                        if (Convert.ToInt32(g_ds.Rows[i]["buyContinue"]) == 0)
                        {
                            Lab_buyContinue.Text = "�Զ�����";
                        }
                        else
                        {
                            Lab_buyContinue.Text = "�ֶ�����";
                        }
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["On_off"]) == 0)
                    {
                        Lab_state.Text = "����";
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["On_off"]) == 1)
                    {
                        Lab_state.Text = "����";
                    }
                }
            }

            //����е����������ݰ���       
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //�е�״̬�ǣ� �༭״̬ ���� �����������Ǳ༭״̬��             
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    DropDownList ddl_Continue = e.Row.FindControl("ddl_Continue") as DropDownList;
                    DropDownList ddl_Term = e.Row.FindControl("ddl_Term") as DropDownList;
                    if (ddl_Continue != null)
                    {
                        ListItem item1 = new ListItem();
                        item1.Value = "0";
                        item1.Text = "�Զ�����";
                        ddl_Continue.Items.Add(item1);
                        ListItem item2 = new ListItem();
                        item2.Value = "1";
                        item2.Text = "�ֶ�����";
                        ddl_Continue.Items.Add(item2);
                    }

                    //�������� ֻ����ԭ���Ļ���������������
                    if (ddl_Term != null)
                    {
                        ListItem item0 = new ListItem();
                        item0.Value = "0";
                        item0.Text = "--��ѡ��--";
                        ddl_Term.Items.Add(item0);
                        ListItem item3 = new ListItem();
                        item3.Value = "1";
                        item3.Text = "����1����";
                        ddl_Term.Items.Add(item3);
                        ListItem item4 = new ListItem();
                        item4.Value = "3";
                        item4.Text = "����3����";
                        ddl_Term.Items.Add(item4);
                        ListItem item5 = new ListItem();
                        item5.Value = "6";
                        item5.Text = "����6����";
                        ddl_Term.Items.Add(item5);
                        ListItem item6 = new ListItem();
                        item6.Value = "12";
                        item6.Text = "����1��";
                        ddl_Term.Items.Add(item6);
                    }
                }
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView1();
        }

        //ȡ���༭
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView1();
        }

        //��������
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            g_ModBuy = g_buy.GetModel(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString()));
            g_ModBuy.buyid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[1].ToString());
            DropDownList ddl_Continue=(DropDownList)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("ddl_Continue"));
            DropDownList ddl_Term = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("ddl_Term"));

            TextBox txt_Price = (TextBox)(GridView1.Rows[e.RowIndex].Cells[8].FindControl("txt_Price"));

            if (ddl_Continue.SelectedValue == "0")
            {
                g_ModBuy.buyContinue = 0;
            }
            else
            {
                g_ModBuy.buyContinue = 1;
            }

            if (ddl_Term.SelectedValue != "0")
            {
                g_ModBuy.Term = Convert.ToInt32(g_ModBuy.Term) + Convert.ToInt32(ddl_Term.SelectedValue);
                g_ModBuy.EndTime = Convert.ToDateTime(g_ModBuy.EndTime).Date.AddMonths(Convert.ToInt32(ddl_Term.SelectedValue));
                //ͬʱҪ������۳����ѵĽ��  ��������� �������  �����������ʾ��
            }
            g_ModBuy.Price=Convert.ToDecimal(txt_Price.Text);
            if (Convert.ToInt32(g_buy.Update(g_ModBuy)) > 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('�޸ĳɹ���')", true);
                GridView1.EditIndex = -1;
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('�޸�ʧ�ܣ�')", true);
                return;
            }
        }
    }
}
