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
        /// 绑定交易数据列表
        /// 创建人: zhouwei\
        /// 创建时间: 2010-11-3
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
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + GridView1.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
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
            //获取gridview绑定的行数
            int count = this.GridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //声明gridview中的lable控件
                Label Lab_ItemName = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_ItemName") as Label;
                Label Lab_ShopName = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_ShopName") as Label;
                Label Lab_buyContinue = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_buyContinue") as Label;
                Label Lab_state = (Label)this.GridView1.Rows[i].Cells[0].FindControl("Lab_state") as Label;

                //g_Modapp = g_app.GetModel(Convert.ToInt32(g_ds.Rows[i]["issueInfoId"]));


                //g_Modtype = g_type.GetModel(g_Modapp.TypeID);
                DataSet ds = get_page.Market_GetItme("NvarName,On_off", "appendId=" + Convert.ToInt32(g_ds.Rows[i]["issueInfoId"]));


                Lab_ItemName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                //根据商户的ID去BBs的数据库中查询 商户的名称
                Lab_ShopName.Text =g_ds.Rows[i]["ShopUserID"].ToString() ;
                 //行的状态是：正常状态 或者 交替行           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (Lab_buyContinue != null)
                    {
                        if (Convert.ToInt32(g_ds.Rows[i]["buyContinue"]) == 0)
                        {
                            Lab_buyContinue.Text = "自动续费";
                        }
                        else
                        {
                            Lab_buyContinue.Text = "手动续费";
                        }
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["On_off"]) == 0)
                    {
                        Lab_state.Text = "开放";
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["On_off"]) == 1)
                    {
                        Lab_state.Text = "锁定";
                    }
                }
            }

            //如果行的类型是数据绑定行       
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //行的状态是： 编辑状态 或者 （交替行且是编辑状态）             
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    DropDownList ddl_Continue = e.Row.FindControl("ddl_Continue") as DropDownList;
                    DropDownList ddl_Term = e.Row.FindControl("ddl_Term") as DropDownList;
                    if (ddl_Continue != null)
                    {
                        ListItem item1 = new ListItem();
                        item1.Value = "0";
                        item1.Text = "自动续费";
                        ddl_Continue.Items.Add(item1);
                        ListItem item2 = new ListItem();
                        item2.Value = "1";
                        item2.Text = "手动续费";
                        ddl_Continue.Items.Add(item2);
                    }

                    //续费设置 只能在原来的基础上增加月数。
                    if (ddl_Term != null)
                    {
                        ListItem item0 = new ListItem();
                        item0.Value = "0";
                        item0.Text = "--请选择--";
                        ddl_Term.Items.Add(item0);
                        ListItem item3 = new ListItem();
                        item3.Value = "1";
                        item3.Text = "续费1个月";
                        ddl_Term.Items.Add(item3);
                        ListItem item4 = new ListItem();
                        item4.Value = "3";
                        item4.Text = "续费3个月";
                        ddl_Term.Items.Add(item4);
                        ListItem item5 = new ListItem();
                        item5.Value = "6";
                        item5.Text = "续费6个月";
                        ddl_Term.Items.Add(item5);
                        ListItem item6 = new ListItem();
                        item6.Value = "12";
                        item6.Text = "续费1年";
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

        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView1();
        }

        //更新数据
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
                //同时要在这里扣除续费的金额  如果金额够续费 程序继续  如果不够则提示。
            }
            g_ModBuy.Price=Convert.ToDecimal(txt_Price.Text);
            if (Convert.ToInt32(g_buy.Update(g_ModBuy)) > 0)
            {

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
    }
}
