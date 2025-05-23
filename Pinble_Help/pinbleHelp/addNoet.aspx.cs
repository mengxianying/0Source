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
    public partial class addNoet : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        Pbzx.Model.Help_TreeStructure mod_ts = new Pbzx.Model.Help_TreeStructure();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                ddlBind();
                ddl_pathBind();
            }
        }
        /// <summary>
        /// �������б�̬��ַ
        /// </summary>
        private void ddl_pathBind()
        {
            int id = Convert.ToInt32(Request["id"]);
            ddl_path.Items.Add(new ListItem("--��ѡ��--", "0"));
            ddl_path.Items.Add(new ListItem("˵��", "/html/" + id + "/"));
            ddl_path.Items.Add(new ListItem("����˵��", "/publicHtml/"));
        }



        /// <summary>
        /// ��ӽڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addNoet_Click(object sender, EventArgs e)
        {
            int TreeName = Convert.ToInt32(Request["id"]);
            string NoetName = "";
            if (txt_NoetName.Text == "")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('����д�������ƣ�')</script>");
                return;
            }
            else
            {
                if (txt_NoetName.Text.Split('.').Length > 0)
                {
                    NoetName = txt_NoetName.Text.Split('.')[0].ToString();
                }
                else
                {
                    NoetName = txt_NoetName.Text;
                }
            }
            if (get_ts.Exists(txt_NoetName.Text,ddl_fatherNoet.SelectedValue, TreeName))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('����ӵĽڵ������Ѵ��ڣ�')</script>");

                return;
            }
            else
            {
                if (ddl_path.SelectedValue == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('��ѡ���Ӧ��·����')</script>");
                    return;
                }
                if (ddl_path.SelectedValue == "/publicHtml/")
                {
                    Random ran = new Random();
                    int RandKey = ran.Next(1, 99);
                    int RandHeadKey = ran.Next(1, 10);
                    string id = Request["id"].ToString();
                    //ȡ��ҳ������ֵ
                    mod_ts.Tree_name = id;
                    mod_ts.Tree_num = "1" + RandKey.ToString() + DateTime.Now.Second.ToString() + RandHeadKey + id;
                    mod_ts.Tree_superiorNoet = ddl_fatherNoet.SelectedValue;
                    mod_ts.Tree_RootNotd = NoetName;
                    mod_ts.Tree_countent = fck_Noet.Value;
                    mod_ts.Tree_Path = ddl_path.SelectedValue + NoetName + ".htm";
                    if (get_ts.Add(mod_ts) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('��ӳɹ���');</script>");
                        ddlBind();
                        txt_NoetName.Text = "";
                        fck_Noet.Value = "";

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('���ʧ�ܣ���������ӣ�')</script>");

                    }
                }
                else
                {
                    if (fck_Noet.Value == "")
                    {

                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('�������ҳ��')</script>");
                        return;
                    }
                    Random ran = new Random();
                    int RandKey = ran.Next(1, 99);
                    int RandHeadKey = ran.Next(1, 10);
                    string id = Request["id"].ToString();
                    //ȡ��ҳ������ֵ
                    mod_ts.Tree_name = id;
                    mod_ts.Tree_num = "1" + RandKey.ToString() + DateTime.Now.Second.ToString() + RandHeadKey + id;
                    mod_ts.Tree_superiorNoet = ddl_fatherNoet.SelectedValue;
                    mod_ts.Tree_RootNotd = NoetName;
                    mod_ts.Tree_countent = fck_Noet.Value;
                    mod_ts.Tree_Path = ddl_path.SelectedValue + NoetName + ".htm";
                    if (get_ts.Add(mod_ts) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('��ӳɹ���');</script>");
                        ddlBind();
                        txt_NoetName.Text = "";
                        fck_Noet.Value = "";

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('���ʧ�ܣ���������ӣ�')</script>");

                    }
                }
                

            }
        }

        /// <summary>
        /// �������б�
        /// </summary>
        private void ddlBind()
        {
            string id = Request["id"].ToString();
            ddl_fatherNoet.Items.Clear();
            ddl_fatherNoet.Items.Add(new ListItem("--��ѡ��--", "0"));
           
            DataSet ds = get_ts.GetList("Tree_name=" + "'" + id + "'"+" order by Tree_id asc");
            MakeTree(ds.Tables[0], "Tree_superiorNoet", "0", "Tree_num", "Tree_RootNotd", this.ddl_fatherNoet, -1);
        }
        /// <summary> 
        /// ������һ�������ṹ�������˵� 
        /// </summary> 
        /// <param name="dtNodeSets">�˵���¼�������ڵı�</param> 
        /// <param name="strParentColumn">�������ڱ�Ǹ���¼���ֶ�</param> 
        /// <param name="strRootValue">��һ���¼�ĸ���¼ֵ(ͨ�����Ϊ0����-1����Null)������ʾû�и���¼</param> 
        /// <param name="strIndexColumn">�����ֶΣ�Ҳ���Ƿ���DropDownList��Value������ֶ�</param> 
        /// <param name="strTextColumn">��ʾ�ı��ֶΣ�Ҳ���Ƿ���DropDownList��Text������ֶ�</param> 
        /// <param name="drpBind">��Ҫ�󶨵�DropDownList</param> 
        /// <param name="i">����������������ֵ��������-1</param> 
        private void MakeTree(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, DropDownList drpBind, int i)
        {
            //ÿ����һ�㣬��һ�����뵥λ 
            i++;
            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //�����ַ� 
            //ͨ��i�����������ַ��ĳ��ȣ��������趨����һ��ȫ�ǵĿո� 
            for (int j = 0; j < i; j++)
                strPading += "��";//���Ҫ��������ĳ��ȣ��ĳ�����ȫ�ǵĿո�Ϳ����� 
            foreach (DataRowView drv in dvNodeSets)
            {
                ListItem li = new ListItem(strPading + "��" + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());
                drpBind.Items.Add(li);
                MakeTree(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, drpBind, i);
            }
            //�ݹ������Ҫ�ص���һ�㣬��������������һ����λ 
            i--;
        }


    }
}

