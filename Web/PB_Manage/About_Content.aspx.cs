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
    public partial class About_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_About ContentBll = new Pbzx.BLL.PBnet_About();
            MyGridView.DataSource = ContentBll.GetList(" 1=1  order by UsOrder asc ");
            MyGridView.DataBind();
        }
       

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + id.ToString() + ")";
            }
        }
        protected void lbtnIsAuditing_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_About.ChangeAudit(id, "UsState");
            BindData();
        }
        protected void lbtnBtommShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_About.ChangeAudit(id, "UsIsBtommShow");
            BindData();
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_About bll = new Pbzx.BLL.PBnet_About();
            Pbzx.Model.PBnet_About model = bll.GetModel(id);
            string nvarname = model.UsTitle.ToString();

            Pbzx.BLL.PBnet_UrlMaping UrlBll = new Pbzx.BLL.PBnet_UrlMaping();

            if (bll.Delete(id) && UrlBll.DelName(nvarname) > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除页面信息[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除页面信息[" + nvarname + "]成功！");
            }
            BindData();
        }
    }
  
}
