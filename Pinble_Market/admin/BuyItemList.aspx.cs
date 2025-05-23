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
using Maticsoft.DBUtility;

namespace Pinble_Market.admin
{
    public partial class BuyItemList : System.Web.UI.Page
    {
        Pbzx.BLL.Market_BuyInfo g_buy = new Pbzx.BLL.Market_BuyInfo();
        Pbzx.BLL.Market_appendItemManager g_app = new Pbzx.BLL.Market_appendItemManager();
        Pbzx.BLL.Market_TypeManager g_type = new Pbzx.BLL.Market_TypeManager();
        Pbzx.Model.Market_BuyInfo g_modBuy=new Pbzx.Model.Market_BuyInfo();
        Pbzx.Model.Market_appendItem g_modapp=new Pbzx.Model.Market_appendItem();
        Pbzx.Model.Market_Type g_modtype=new Pbzx.Model.Market_Type();
        //DataSet ds=new DataSet();
        DataTable g_dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //�ж��û��Ƿ��¼
            if (Method.Get_UserName.ToString() == "0")
            {
                 Response.Write("<script>parent.mainFrame.location.href='../login.aspx'</script>");
                 Response.End();
                 return;
                
            }
            if (!IsPostBack)
            {
                this.myGridView.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGv_BuyList();
            }
        }

        /// <summary>
        /// �󶨹�����Ŀ�б�
        /// ������:zhouwei
        /// ����ʱ��:2010-11-1
        /// </summary>
        public void BindGv_BuyList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("buyuserid=" + '"' + Method.Get_UserName.ToString() + '"');
            sb.Append(" and getdate()<endTime");
            sb.Append(" and market=0");
            string Searchstr = sb.ToString();
            string order = "buyid desc";
            int myCount = 0;

            g_dt = g_buy.GuestGetBySearchBuyInfo(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_dt;
            myGridView.DataKeyNames = new string[] { "buyid" };//����
            myGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (g_dt == null || g_dt.Rows.Count==0)
            {
                AspNetPager1.Visible = false;
                this.litContent.Text = "<b><br/>��û�й����κε���Ŀ</b>&nbsp;&nbsp; <a href='/rightFrom.aspx' target='mainFrame' ><font color='red'>����ȥ����</font></a>";
                
                return;
            }
            else
            {
                this.litContent.Text = "";
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
            BindGv_BuyList();
        }


        //�Զ�������
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1) 
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }

        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet ds = new DataSet();
            Pbzx.BLL.Market_Page page = new Pbzx.BLL.Market_Page();
            //��ѯmyGridView�ж���������
            int count = this.myGridView.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                //����Lable�ؼ�
                Label Lab_Lottery = (Label)this.myGridView.Rows[i].Cells[0].FindControl("Lab_Lottery") as Label;
                Label Lab_Name = (Label)this.myGridView.Rows[i].Cells[0].FindControl("Lab_Name") as Label;
                Label Lab_Continue = (Label)this.myGridView.Rows[i].Cells[0].FindControl("Lab_Continue") as Label;
                Label lab_shopName = (Label)this.myGridView.Rows[i].Cells[0].FindControl("lab_shopName") as Label;
                

                lab_shopName.Text = g_dt.Rows[i]["ShopUserID"].ToString();

                

                //�����Ŀʵ��
                //g_modapp = g_app.GetModel(Convert.ToInt32(g_dt.Rows[i]["issueInfoId"]));
                ds = page.Market_GetItme("NvarName,TypeName", "appendId=" + Convert.ToInt32(g_dt.Rows[i]["issueInfoId"]));

                Lab_Name.Text =  ds.Tables[0].Rows[0]["TypeName"].ToString();
                Lab_Lottery.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                //�е�״̬�ǣ�����״̬ ���� ������           
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (Lab_Continue != null)
                    {
                        if (Convert.ToInt32(g_dt.Rows[i]["buyContinue"]) == 0)
                        {
                            Lab_Continue.Text = "�Զ�����";
                        }
                        else
                        {
                            Lab_Continue.Text = "�ֶ�����";
                        }
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

        protected void myGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myGridView.EditIndex = e.NewEditIndex;
            BindGv_BuyList();
        }

        //�޸���Ϣ
        protected void myGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = new DataSet();
            ds = g_buy.GetList("buyid=" + Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value.ToString()));
            
            g_modBuy = g_buy.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["issueInfoId"]));
            g_modBuy.buyid = Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value.ToString());
            
            //��ѯ��Ŀ��״̬�Ƿ����������ǹر�
            DataSet dsYN = g_app.GetList("appendID="+g_modBuy.issueInfoId);
            //��û�б�������û������
            if (dsYN.Tables.Count > 0 && dsYN.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(dsYN.Tables[0].Rows[0]["On_off"]) != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('����Ŀ�Ѿ�ȡ��������������')", true);
                    return;
                }
                else
                {
                    DropDownList ddl = (DropDownList)(myGridView.Rows[e.RowIndex].Cells[8].FindControl("ddl_Continue"));
                    if (ddl.SelectedValue == "0")
                    {
                        g_modBuy.buyContinue = 0;
                    }
                    else
                    {
                        g_modBuy.buyContinue = 1;
                    }
                    //�޸Ĺ���ʱ��
                    DropDownList ddlTime = (DropDownList)(this.myGridView.Rows[e.RowIndex].Cells[5].FindControl("ddl_Term"));
                    if (ddlTime.SelectedValue != "0")
                    {
                        g_modBuy.Term = Convert.ToInt32(g_modBuy.Term) + Convert.ToInt32(ddlTime.SelectedValue);
                        g_modBuy.EndTime = Convert.ToDateTime(g_modBuy.EndTime).Date.AddMonths(Convert.ToInt32(ddlTime.SelectedValue));
                        //ͬʱҪ������۳����ѵĽ��  ��������� �������  �����������ʾ��
                    }

                    int atr = g_buy.Update(g_modBuy);
                    if (atr > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('�޸ĳɹ���')", true);
                        myGridView.EditIndex = -1;
                        BindGv_BuyList();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('�޸�ʧ�ܣ�')", true);
                        return;
                    }
                }
            }

        }
        //ȡ��
        protected void myGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            myGridView.EditIndex = -1;
            BindGv_BuyList();
        }
        //�����˶�
        protected void lbtn_cancel_Command(object sender, CommandEventArgs e)
        {
            

            DataSet dstime = g_buy.GetList("issueInfoId=" + Convert.ToInt32(e.CommandArgument) + " and buyuserid=" + "'" + Method.Get_UserName + "'");
            //����һ�������ڲ����˶�
            if (Convert.ToInt32(DateTime.Now.Day) - Convert.ToInt32(Convert.ToDateTime(dstime.Tables[0].Rows[0]["BeginTime"]).Day) < 5)
            {
                this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('����δ����5�첻���˶�')", true);
                return;
            }
            else
            {
                Response.Write("<script>window.open('Cancel.aspx?item='+'" + Input.Encrypt(e.CommandArgument.ToString()) + "');</script>");
            }
            ////�����˶���Ŀ
            //Pbzx.BLL.Market_CancelIndent can = new Pbzx.BLL.Market_CancelIndent();
            //Pbzx.Model.Market_CancelIndent canapp = new Pbzx.Model.Market_CancelIndent();
            ////�ύ��
            //canapp.CancelName = Method.Get_UserName.ToString();
            ////�ύʱ��
            //canapp.CTime = DateTime.Now.Date;
            ////�˶���ĿID
            //canapp.CancelItem =Convert.ToInt32(e.CommandArgument);
            ////�˶���־ 1:�����˶���  2:ȡ�������˶�
            //canapp.CancelIndent = 1;
            ////�ж�����Ŀ�Ѿ��ύ������
            //if (!can.Exists(canapp.CancelName, Convert.ToInt32(e.CommandArgument)))
            //{
            //    //û���ύ������
            //    if (can.Add(canapp) > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('����ɹ�')", false);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('����ʧ�ܡ�����������')", false);
            //    }
            //}
            //else
            //{ 
            //    //�Ѿ��ύ������
            //    ScriptManager.RegisterStartupScript(this.Page,this.GetType(),"upScript","alert('�Ѿ��ύ���˿�����')",false);
            //}
           
            
        }

        //��������
        protected void Ibtn_scout_Click(object sender, ImageClickEventArgs e)
        {
            int num=9;
            if (Request.Form["username"].ToString() == "�ֶ�����")
            {
                num = 0;
            }
            if (Request.Form["username"].ToString() == "�Զ�����")
            {
                num = 1;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("buyuserid=" + "'" + Method.Get_UserName.ToString() + "'" + " and (Price like '%" + Request.Form["username"].ToString() + "%' or ShopUserID like '%" + Request.Form["username"].ToString() + "%'" + " or LotteryType like '%" +  Request.Form["username"].ToString() + "%'" + " or buyContinue="+num+")");
            sb.Append(" and getdate()<endTime");
            string Searchstr = sb.ToString();
            string order = "buyid desc";
            int myCount = 0;

            g_dt = g_buy.GuestGetBySearchBuyInfo(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_dt;
            myGridView.DataKeyNames = new string[] { "buyid" };//����
            myGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (g_dt == null || g_dt.Rows.Count == 0)
            {
                AspNetPager1.Visible = false;
                this.litContent.Text = "<b>û����������Ҫ����Ŀ</b>";
                return;
            }
            else
            {
                this.litContent.Text = "";
            }
        }

     

    }
}
