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

namespace Pinble_Help.pinbleHelp
{
    public partial class ModifyNoet : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        DataTable IsResult = new DataTable();
        DataSet dsIsResult = new DataSet();
        public static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                
                BindMyGridView();
            }
        }

        /// <summary>
        /// �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[1].Text = (MyGridView.PageIndex * MyGridView.PageSize + e.Row.RowIndex + 1).ToString();


            }
        }

        /// <summary>
        /// ������
        /// </summary>
        private void BindMyGridView()
        {
            id = Request["id"].ToString();
            if (!string.IsNullOrEmpty(Request["superiorNoet"]))
            {
                dsIsResult = get_ts.GetList("Tree_name=" + "'" + id + "'" + " and Tree_superiorNoet=" + "'" + Request["superiorNoet"].ToString() + "'" + " order by Tree_sort asc");

                MyGridView.DataSource = dsIsResult;
                MyGridView.DataKeyNames = new string[] { "Tree_id" };
                MyGridView.DataBind();
            }
            else
            {

                dsIsResult = get_ts.GetList("Tree_name=" + "'" + id + "'" + " order by Tree_sort asc");

                MyGridView.DataSource = dsIsResult;
                MyGridView.DataKeyNames = new string[] { "Tree_id" };
                MyGridView.DataBind();
            }
        }



        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = get_ts.GetList("Tree_id=" + "'" + this.MyGridView.DataKeys[e.RowIndex].Value + "'");

            //��ѯ�Ƿ����ӽڵ�
            DataSet dsNoet = get_ts.GetList("Tree_superiorNoet=" + "'" + ds.Tables[0].Rows[0]["Tree_num"].ToString() + "'");


            if (dsNoet.Tables[0].Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>if(!confirm('ɾ���Ľڵ��»����ӽڵ㣡ȷ��ɾ����')){return false;}</script>");
                //ɾ���ӽڵ�����
                if (get_ts.Delete(ds.Tables[0].Rows[0]["Tree_superiorNoet"].ToString()) > 0)
                {
                    //ɾ�����������
                    if (get_ts.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ���ɹ���')</script>");
                        BindMyGridView();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ��ʧ�ܣ�')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ��ʧ�ܣ�')</script>");
                }
            }
            else
            {
                if (get_ts.Delete(Convert.ToInt32(this.MyGridView.DataKeys[e.RowIndex].Value)) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ���ɹ���')</script>");
                    BindMyGridView();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ��ʧ�ܣ�')</script>");
                }
            }
        }
        //ȫѡ�¼�
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
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
        //ɾ��ѡ��
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                if (cb.Checked == true)
                {
                    if (get_ts.Delete(Convert.ToInt32(MyGridView.DataKeys[i].Value)) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ���ɹ�')</script>");
                        BindMyGridView();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ɾ��ʧ��')</script>");
                    }
                }
            }

        }
        //ȡ��ɾ��
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)MyGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }

        }

        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                MyGridView.PageIndex = e.NewPageIndex;
                BindMyGridView();
                TextBox tb = (TextBox)MyGridView.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (MyGridView.PageIndex + 1).ToString();
            }
            catch { }
        }

        protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)MyGridView.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    MyGridView_PageIndexChanging(null, ea);
                }
                catch { }
            }
        }

        //����
        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataSet dsSearch = get_ts.GetList("Tree_RootNotd like '%" + txt_search.Text + "%' or Tree_num like '%"+txt_search.Text+"%'");
            MyGridView.DataSource = dsSearch;
            MyGridView.DataKeyNames = new string[] { "Tree_id" };
            MyGridView.DataBind();
        }

    }
}

