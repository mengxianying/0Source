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


namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_GradeConfig : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                BindData();               
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_ask_GradeConfig MyBll = new Pbzx.BLL.PBnet_ask_GradeConfig();
            this.MyGridView.DataSource = MyBll.GetAllList();
            this.MyGridView.DataBind();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + id.ToString() + ")";
            }
        }
     

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("必须保证至少有一条记录");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.Rows[e.RowIndex].Cells[2].Text;
            Pbzx.BLL.PBnet_ask_GradeConfig bll = new Pbzx.BLL.PBnet_ask_GradeConfig();
            if (bll.Delete(id))
            {
                //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除类别[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除类别[" + nvarname + "]成功！");
            }
            BindData();
        }
    }
}
