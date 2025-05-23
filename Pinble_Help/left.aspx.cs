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
        /// 绑定树形结构数据
        /// </summary>
        private void TreeBind()
        {
            string id = Input.FilterAll(Request["id"].ToString());
            
            if (string.IsNullOrEmpty(id))
            {
                DataTable dt = get_ts.GetList("order by Tree_sort asc").Tables[0];//获取数据源
                //int s = dt.Rows.Count;//
                DataView dv = new DataView(dt);
                dv.RowFilter = "Tree_superiorNoet=0";
                foreach (DataRowView drv in dv)
                {
                    TreeNode node = new TreeNode();
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Text = drv["Tree_RootNotd"].ToString();//显示的文本
                    node.Value = drv["Tree_num"].ToString();//不显示的 文本 值
                    node.NavigateUrl = drv["Tree_Path"].ToString();
                    //node.SelectAction = TreeNodeSelectAction.None;//不引发事件
                    //node.ImageUrl = "~/images/folder.GIF";//节点旁边显示的节点
                    node.Expanded = false;//是否展开节点

                    node.ImageUrl = "/image/2.png";

                    node.Target = "left";
                    TreeView1.Nodes.Add(node);//添加到根节点
                    AddReplies(dt, node);//递归函数 
                }
            }
            else
            {
                DataTable dt = get_ts.GetList("Tree_name=" + "'" + id + "'" + " order by Tree_sort asc").Tables[0];//获取数据源
                //int s = dt.Rows.Count;//
                DataView dv = new DataView(dt);
                dv.RowFilter = "Tree_superiorNoet=0";
                foreach (DataRowView drv in dv)
                {
                    TreeNode node = new TreeNode();
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Text = drv["Tree_RootNotd"].ToString();//显示的文本
                    node.Value = drv["Tree_num"].ToString();//不显示的 文本 值
                    node.NavigateUrl = drv["Tree_Path"].ToString();
                    //node.SelectAction = TreeNodeSelectAction.None;//不引发事件
                    //node.ImageUrl = "~/images/folder.GIF";//节点旁边显示的节点
                    node.Expanded = false;//是否展开节点

                    node.ImageUrl = "/image/2.png";

                    node.Target = "left";
                    TreeView1.Nodes.Add(node);//添加到根节点
                    AddReplies(dt, node);//递归函数 
                }
            }

        }
        /// <summary>
        /// TreeView 递归函数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="node"></param>
        protected void AddReplies(DataTable dt, TreeNode node)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "Tree_superiorNoet='" + node.Value + "'";//过滤 node。Value 为上级的treeNode 值
            foreach (DataRowView row in dv)
            {
                TreeNode replyNode = new TreeNode();//新建一个节点
                replyNode.SelectAction = TreeNodeSelectAction.Expand;
                replyNode.Text = row["Tree_RootNotd"].ToString();//显示的文本
                replyNode.Value = row["Tree_num"].ToString();//不显示的 文本 值
                replyNode.NavigateUrl = row["Tree_Path"].ToString();
                replyNode.Expanded = false;
                
                //判断有没有下级节点 如果有显示其它图片
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
                node.ChildNodes.Add(replyNode);//添加到子节点
                AddReplies(dt, replyNode);//继续递归函数
            }
        }

    }
}
