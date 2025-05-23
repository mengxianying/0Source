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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class AgentAgree : AdminBasic
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
            Pbzx.BLL.AgentAgree AgentBll = new Pbzx.BLL.AgentAgree();
            MyGridView.DataSource = AgentBll.GetAllList();
            MyGridView.DataBind();
        }
        
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("必须保证至少有一条记录");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["Title"].ToString();
            Pbzx.BLL.AgentAgree bll = new Pbzx.BLL.AgentAgree();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除代理协议[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除代理[" + nvarname + "]成功！");
            }
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "("+id.ToString()+")";
            }
        }
        //用户类型
        public static string GetState(object num)
        {
            string state = "";
            int Intnum = int.Parse(num.ToString());
            switch (Intnum)
            {
                case 0:
                    state = "<font color='#003399'>已审核</font>";
                    break;
                case 1:
                    state = "<font color=red>未审核</font>";
                    break;
                default:
                    state = "<font color='#888888'>未知</font>";
                    break;
            }
            return state;
        }
    }
}
