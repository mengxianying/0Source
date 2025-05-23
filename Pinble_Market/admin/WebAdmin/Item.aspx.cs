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
    public partial class Item : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page g_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_appendItemManager g_app = new Pbzx.BLL.Market_appendItemManager();
        Pbzx.Model.Market_appendItem g_Modapp = new Pbzx.Model.Market_appendItem();
        //DataSet g_ds = new DataSet();
        DataTable g_dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.myGridView.PageSize = Convert.ToInt32(Input.GetManageCount());
                BindGridView1();
            }

        }
        /// <summary>
        /// �Զ�������ţ����ǰ�����
        /// ������:zhouwei
        /// ����ʱ��: 2010-11-3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }

        /// <summary>
        /// ������Դ
        /// ������:zhouwei
        /// ����ʱ��:2010-11-3
        /// </summary>
        public void BindGridView1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1 ");
            sb.Append(this.strParametr());
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_dt = g_app.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_dt;
            myGridView.DataKeyNames = new string[] { "appendID" };
            myGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (g_dt == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        /// <summary>
        /// �����ַ�����ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        public string strParametr()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["name"]))
            {
                sb.Append("and NvarName=" + "'" + Request["name"] + "'" + " ");
            }
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                sb.Append("and TypeName="+"'"+ Request["type"] +"'"+" ");
            }
            return sb.ToString();
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
            //��ѯGV_BuyList�ж���������
            int count = this.myGridView.Rows.Count;

            //�е�״̬�ǣ�����״̬ ���� ������           
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    Label Lab_state = (Label)this.myGridView.Rows[i].FindControl("Lab_state");
                    if (Lab_state != null)
                    {
                        if (Convert.ToInt32(g_dt.Rows[i]["On_off"]) == 0)
                        {
                            Lab_state.Text = "����";

                        }
                        else if (Convert.ToInt32(g_dt.Rows[i]["On_off"]) == 1)
                        {
                            Lab_state.Text = "����";

                        }
                        else if (Convert.ToInt32(g_dt.Rows[i]["On_off"]) == 2)
                        {
                            Lab_state.Text = "�ر�";
                        }
                        else
                        {
                            Lab_state.Text = "�û�ɾ��";
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
                    DropDownList ddl_state = (DropDownList)e.Row.FindControl("ddl_state") as DropDownList;
                    if (ddl_state != null)
                    {
                        ListItem item1 = new ListItem();
                        item1.Value = "0";
                        item1.Text = "����";
                        ddl_state.Items.Add(item1);
                        ListItem item2 = new ListItem();
                        item2.Value = "1";
                        item2.Text = "����";
                        ddl_state.Items.Add(item2);
                        ListItem item3 = new ListItem();
                        item3.Value = "2";
                        item3.Text = "�ر�";
                        ddl_state.Items.Add(item3);
                    }
                }
            }
        }

        protected void myGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myGridView.EditIndex = e.NewEditIndex;
            BindGridView1();
        }

        protected void myGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            g_Modapp = g_app.GetModel(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value.ToString()));
            DropDownList ddl_state = (DropDownList)(myGridView.Rows[e.RowIndex].Cells[5].FindControl("ddl_state"));
            TextBox txt_Price = (TextBox)(myGridView.Rows[e.RowIndex].Cells[5].Controls[0]);

            if (ddl_state != null && txt_Price != null)
            {
                g_Modapp.Price = Convert.ToDecimal(txt_Price.Text.ToString());
                if (ddl_state.SelectedValue == "0")
                {
                    g_Modapp.On_off = 0;
                }
                if (ddl_state.SelectedValue == "1")
                {
                    g_Modapp.On_off = 1;
                }
                if (ddl_state.SelectedValue == "2")
                {
                    g_Modapp.On_off = 2;
                }
            }
            int ret = g_app.Update(g_Modapp);
            if (ret > 0)
            {

                //Response.Write(JS.Alert("�޸ĳɹ���"));
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('�޸ĳɹ���')", true);
                myGridView.EditIndex = -1;
                BindGridView1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('�޸�ʧ�ܣ�')", true);
                return;
            }
        }

        //ȡ���༭
        protected void myGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            myGridView.EditIndex = -1;
            BindGridView1();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //�ж���û���û�����
            //�ж��û����Ƶ���Ŀ�Ƿ��ڡ�
            //���û��������������������ɾ�������ǿ�����������Ŀ
            //if (g_app.Delete(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value)) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('ɾ���ɹ�')", true);
            //    BindGridView1();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('ɾ��ʧ��')", true);
            //}
        }

        //ɾ��ѡ��
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {
                    //�ж���û���û�����
                    //�ж��û����Ƶ���Ŀ�Ƿ��ڡ�
                    //���û��������������������ɾ�������ǿ�����������Ŀ
                    //if (g_app.Delete(Convert.ToInt32(myGridView.DataKeys[i].Value)) > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('ɾ���ɹ�')", true);
                    //    BindGridView1();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "deleteScript", "alert('ɾ��ʧ��')", true);
                    //}
                }
            }

        }
        //ȡ��ɾ��
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }

        }
        //ȫѡ�¼�
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                if (cb_full.Checked == true)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }
}
