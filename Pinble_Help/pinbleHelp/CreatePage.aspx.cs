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
    public partial class CreatePage : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        Pbzx.BLL.Help_HelpName get_help = new Pbzx.BLL.Help_HelpName();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                BindData();
                BindTree();
            }
        }


        private void BindData()
        {
            string Tree_name = Request["name"].ToString();
            DataTable dt = get_ts.GetListBySort(Tree_name);
            this.MyGridView.DataSource = dt;

            this.MyGridView.DataBind();
        }

        protected string showModule(object mName, object mDepth)
        {
            int depth = Convert.ToInt32(mDepth);
            string name = mName.ToString();
            if (depth == 0)
            {
                name = "<b>" + name + "</b>";
            }
            else
            {
                name = "├─" + name;
            }
            return name;
            //select 
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id =MyGridView.PageIndex * MyGridView.PageSize+e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = "(" + id.ToString() + ")";
            }
        }

        /// <summary>
        /// 生成帮助说明页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString().Split(',')[0]);
            string aspxHtml = " /right.aspx?noet=" + e.CommandArgument.ToString().Split(',')[1];
            get_ts.CreatHtmlByChannelID(id, aspxHtml, false);
            //Response.Write("<script>location='CreatePage.aspx';</script>");
        }
        /// <summary>
        /// 批量生成页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {

            string str = Request.Form["sel"];
            if (str == null || str == "")
            {
                return;
            }
            get_ts.CreateHtmlByBatch(str);
            Pbzx.BLL.Help_TreeStructure.WriteMasterOperate("生成", "批量生成静态页面[" + str + "]");
            BindData();
        }
        /// <summary>
        /// 全部生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAllCreate_Click(object sender, EventArgs e)
        {
            //Pbzx.BLL.Help_TreeStructure.WriteMasterOperate("生成", "全部生成静态页面");
            //get_ts.CreateHtmlByBatch();
            //BindData();
        }

        /// <summary>
        /// 绑定树形生成
        /// </summary>
        private void BindTree()
        {
            string hn_id = Request["name"].ToString();
            Pbzx.BLL.Help_HelpName get_help = new Pbzx.BLL.Help_HelpName();
            DataSet ds = get_help.GetList("Hn_ID=" + "'" + hn_id + "'");
            GridViewTree.DataSource = ds;
            GridViewTree.DataBind();
        }

        /// <summary>
        /// 生成树形结构静态页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void link_Create_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            string aspxHtml = " /left.aspx?id=" + e.CommandArgument.ToString();
            get_help.CreatTree(id, aspxHtml, false);
            //Response.Write("<script>location='CreatePage.aspx?name='" + e.CommandArgument.ToString() + "';</script>");
        }

        /// <summary>
        /// 生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewTree_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
            }
        }

        /// <summary>
        /// 绑定生成分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                MyGridView.PageIndex = e.NewPageIndex;
                BindData();
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




    }
}