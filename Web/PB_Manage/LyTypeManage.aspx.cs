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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class LyTypeManage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindData()
        {
            Pbzx.BLL.PBnet_LyType typeBll = new Pbzx.BLL.PBnet_LyType();
            this.MyGridView.DataSource = typeBll.GetListBySort();
            this.MyGridView.DataBind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int ModuleID = Convert.ToInt32(hfID.Value);
            if (txtName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("留言类别名称不能为空."));
                return;
            }
            int orderID = 0;
            if (!int.TryParse(this.txtSortID.Text.Trim(), out orderID))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("排序编号必须是数字."));
                return;
            }
            Pbzx.BLL.PBnet_LyType ModuleBLL = new Pbzx.BLL.PBnet_LyType();
            Pbzx.Model.PBnet_LyType PModule = new Pbzx.Model.PBnet_LyType();
            Pbzx.Model.PBnet_LyType MyModule = new Pbzx.Model.PBnet_LyType();
            if (ModuleID == 0)
            {
                //增加                
                MyModule.IsAuditing = this.cbMenu.Checked;
                if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from PBnet_LyType where TypeName='" + txtName.Text.Trim() + "' ")) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("已经存在该留言类别名称"));
                    return;
                }
                MyModule.TypeName = txtName.Text;
                MyModule.OrderID = orderID;
                if (ModuleBLL.Add(MyModule))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增留言类别[" + MyModule.TypeName + "].");                 
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("LyTypeManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("留言类别添加失败."));
                }
            }
            else
            {
                MyModule = ModuleBLL.GetModel(ModuleID);
                MyModule.IsAuditing = this.cbMenu.Checked;
                if (this.txtName.Text.Trim() != MyModule.TypeName && Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from PBnet_LyType where TypeName='" + txtName.Text.Trim() + "' ")) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("已经存在该留言类别名称"));
                    return;
                }
                MyModule.TypeName = txtName.Text;
                MyModule.OrderID = orderID;
                if (ModuleBLL.Update(MyModule))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改留言类别[" + MyModule.TypeName + "].");
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("LyTypeManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("留言类别修改失败."));
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            hfID.Value = "0";
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void DelModule(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_LyType ModuleBLL = new Pbzx.BLL.PBnet_LyType();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除留言类别[" + ModuleID + "].");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("LyTypeManage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("删除留言类别失败."));
            }
        }

        protected void ShowEditor(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.Model.PBnet_LyType MyModule = new Pbzx.BLL.PBnet_LyType().GetModel(ModuleID);
            txtName.Text = MyModule.TypeName;
            this.txtSortID.Text = MyModule.OrderID.ToString();
            hfID.Value = MyModule.ID.ToString();           
            cbMenu.Checked = MyModule.IsAuditing;           
            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void btn_gl_Click(object sender, EventArgs e)
        {
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            hfID.Value = "0";
            txtName.Text = "";           
            cbMenu.Checked = true;
            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            this.IsAuthority(3);
            DelModule(e.CommandArgument.ToString());
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            this.IsAuthority(2);
            this.ShowEditor(e.CommandArgument.ToString());
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
            Pbzx.BLL.PBnet_LyType.ChangeAudit(id, "IsAuditing");
            BindData();
        }
    }
}
