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

namespace Pinble_Help.pinbleHelp
{
    public partial class upDateNoet : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        Pbzx.BLL.Help_HelpName get_help = new Pbzx.BLL.Help_HelpName();
        public static int t_sort;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                Bind();
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void Bind()
        {
            string id = Request["id"].ToString();
            DataSet ds = get_ts.GetList("Tree_num=" + "'" + id + "'");
            DataSet dsct = get_help.GetList("Hn_ID=" + Convert.ToInt32(ds.Tables[0].Rows[0]["Tree_name"]));
            lab_name.Text = dsct.Tables[0].Rows[0]["Hn_name"].ToString();
            txt_NoetName.Text = ds.Tables[0].Rows[0]["Tree_RootNotd"].ToString();
            fck_RootNoet.Value = ds.Tables[0].Rows[0]["Tree_countent"].ToString();
            txt_path.Text = ds.Tables[0].Rows[0]["Tree_Path"].ToString();
            txt_superior.Text = ds.Tables[0].Rows[0]["Tree_superiorNoet"].ToString();
            txt_sort.Text = ds.Tables[0].Rows[0]["Tree_sort"].ToString();
            //��������
            t_sort = Convert.ToInt32(ds.Tables[0].Rows[0]["Tree_sort"].ToString());

            //��ѯ������
            DataSet ds_Gname = get_ts.GetList("Tree_superiorNoet=" + "'" + ds.Tables[0].Rows[0]["Tree_superiorNoet"].ToString() + "'");
            Label1.Text = ds_Gname.Tables[0].Rows[0]["Tree_RootNotd"].ToString();

        }

        //�޸�
        protected void btn_upDate_Click(object sender, EventArgs e)
        {
            string id = Request["id"].ToString();
            Pbzx.Model.Help_TreeStructure mod_ts = new Pbzx.Model.Help_TreeStructure();
            DataSet ds = get_ts.GetList("Tree_num=" + "'" + id + "'");
            mod_ts = get_ts.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["Tree_id"]));
            int v=0;
            DataSet ds_data = new DataSet();
            //�޸������������ֶ�
            if (t_sort < Convert.ToInt32(txt_sort.Text))
            {
                //������ ID����
                v = Convert.ToInt32(txt_sort.Text) - t_sort;
                //��ѯ��Ҫ�Ķ�����������
                ds_data = get_ts.GetList("Tree_sort>" + "'" + t_sort + "'" + " and Tree_sort<=" + "'" + Convert.ToInt32(txt_sort.Text) + "'" + " order by tree_sort asc");
                for (int i = 0; i < v; i++)
                {
                    int tr_sort = Convert.ToInt32(ds_data.Tables[0].Rows[i]["Tree_sort"]) - 1;
                    int id_int = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update Help_TreeStructure set Tree_sort=" + "'" + tr_sort + "'" + " where Tree_id=" + "'" + Convert.ToInt32(ds_data.Tables[0].Rows[i]["Tree_id"]) + "'");
                    //��Ҫִ������ع� ѭ�����������ݳ����޸Ĺ������ݶ�Ҫ�޸Ļ���
                    //����ع�����
                }
            }
            else
            {
                //������  id��С
                v = t_sort - Convert.ToInt32(txt_sort.Text);
                //��ѯ��Ҫ�Ķ�����������
                ds_data = get_ts.GetList("Tree_sort<" + "'" + t_sort + "'" + " and Tree_sort>=" + "'" + Convert.ToInt32(txt_sort.Text) + "'" + " order by tree_sort asc");
                for (int i = 0; i < v; i++)
                {
                    int tr_sort = Convert.ToInt32(ds_data.Tables[0].Rows[i]["Tree_sort"]) +1;
                    int id_int = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update Help_TreeStructure set Tree_sort=" + "'" + tr_sort + "'" + " where Tree_id="+"'"+ Convert.ToInt32(ds_data.Tables[0].Rows[i]["Tree_id"]) +"'" );
                    //��Ҫִ������ع� ѭ�����������ݳ����޸Ĺ������ݶ�Ҫ�޸Ļ���
                    //����ع�����
                }
            }
            
            


            mod_ts.Tree_sort = Convert.ToInt32(txt_sort.Text);
            mod_ts.Tree_RootNotd = txt_NoetName.Text;
            mod_ts.Tree_countent = fck_RootNoet.Value;
            mod_ts.Tree_Path = txt_path.Text;
            mod_ts.Tree_superiorNoet = txt_superior.Text;
            if (get_ts.Update(mod_ts) > 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('�޸ĳɹ���');window.open('HelpList.aspx');window.opener=null;window.open('','_self');window.close();</script>");
                Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('�޸�ʧ�ܣ�')</script>");
            }
        }
    }
}
