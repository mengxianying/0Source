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

namespace Pinble_Help
{
    public partial class left : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        //private DataTable dtTree=new DataTable();
        //TreeView treeview=new TreeView();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TreeBind();

            }
        }
        /// <summary>
        /// �����νṹ����
        /// </summary>
        private void TreeBind()
        {
            string id = Input.FilterAll(Request["id"].ToString());
            
            if (string.IsNullOrEmpty(id))
            {
                DataTable dt = get_ts.GetList("order by Tree_sort asc").Tables[0];//��ȡ����Դ
                //int s = dt.Rows.Count;//
                DataView dv = new DataView(dt);
                dv.RowFilter = "Tree_superiorNoet=0";
                foreach (DataRowView drv in dv)
                {
                    TreeNode node = new TreeNode();
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Text = drv["Tree_RootNotd"].ToString();//��ʾ���ı�
                    node.Value = drv["Tree_num"].ToString();//����ʾ�� �ı� ֵ
                    node.NavigateUrl = drv["Tree_Path"].ToString();
                    //node.SelectAction = TreeNodeSelectAction.None;//�������¼�
                    //node.ImageUrl = "~/images/folder.GIF";//�ڵ��Ա���ʾ�Ľڵ�
                    node.Expanded = false;//�Ƿ�չ���ڵ�

                    node.ImageUrl = "/image/2.png";

                    node.Target = "left";
                    TreeView1.Nodes.Add(node);//��ӵ����ڵ�
                    AddReplies(dt, node);//�ݹ麯�� 
                }
            }
            else
            {
                DataTable dt = get_ts.GetList("Tree_name=" + "'" + id + "'" + " order by Tree_sort asc").Tables[0];//��ȡ����Դ
                //int s = dt.Rows.Count;//
                DataView dv = new DataView(dt);
                dv.RowFilter = "Tree_superiorNoet=0";
                foreach (DataRowView drv in dv)
                {
                    TreeNode node = new TreeNode();
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Text = drv["Tree_RootNotd"].ToString();//��ʾ���ı�
                    node.Value = drv["Tree_num"].ToString();//����ʾ�� �ı� ֵ
                    node.NavigateUrl = drv["Tree_Path"].ToString();
                    //node.SelectAction = TreeNodeSelectAction.None;//�������¼�
                    //node.ImageUrl = "~/images/folder.GIF";//�ڵ��Ա���ʾ�Ľڵ�
                    node.Expanded = false;//�Ƿ�չ���ڵ�

                    node.ImageUrl = "/image/2.png";

                    node.Target = "left";
                    TreeView1.Nodes.Add(node);//��ӵ����ڵ�
                    AddReplies(dt, node);//�ݹ麯�� 
                }
            }

        }
        /// <summary>
        /// TreeView �ݹ麯��
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="node"></param>
        protected void AddReplies(DataTable dt, TreeNode node)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "Tree_superiorNoet='" + node.Value + "'";//���� node��Value Ϊ�ϼ���treeNode ֵ
            foreach (DataRowView row in dv)
            {
                TreeNode replyNode = new TreeNode();//�½�һ���ڵ�
                replyNode.SelectAction = TreeNodeSelectAction.Expand;
                replyNode.Text = row["Tree_RootNotd"].ToString();//��ʾ���ı�
                replyNode.Value = row["Tree_num"].ToString();//����ʾ�� �ı� ֵ
                replyNode.NavigateUrl = row["Tree_Path"].ToString();
                replyNode.Expanded = false;
                
                //�ж���û���¼��ڵ� �������ʾ����ͼƬ
                DataSet dsNode = get_ts.GetList("Tree_superiorNoet=" + "'" + row["Tree_num"].ToString() + "'");
                if (dsNode != null && dsNode.Tables[0].Rows.Count > 0)
                {
                    replyNode.ImageUrl = "/image/9.gif";
                }
                else
                {
                    replyNode.ImageUrl = "/image/035.gif";
                }
                replyNode.Target = "left";
                node.ChildNodes.Add(replyNode);//��ӵ��ӽڵ�
                AddReplies(dt, replyNode);//�����ݹ麯��
            }
        }

    }
}
