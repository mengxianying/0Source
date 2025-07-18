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
using Pbzx.Common;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class BulletinType_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                this.IsAuthority(0);

                Pbzx.BLL.PBnet_BulletinType ModuleBLL = new Pbzx.BLL.PBnet_BulletinType();
                ddlParent.DataSource = ModuleBLL.GetList("Depth=0");
                ddlParent.DataBind();

                ListItem item = new ListItem("=作为顶级类别=", "0");
                ddlParent.Items.Insert(0, item);

               // ddlParent.Attributes.Add("onchange", "ParentChange(this);");
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_BulletinType typeBll = new Pbzx.BLL.PBnet_BulletinType();
            this.MyGridView.DataSource = typeBll.GetListBySort();
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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int ModuleID = Convert.ToInt32(hfID.Value);
            int ParentID = Convert.ToInt32(ddlParent.SelectedValue);
            if (txtName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("名称不能为空."));
                return;
            }
            int disCount = 8;
            if (!int.TryParse(this.txtDisCount.Text.Trim(),out disCount))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("显示条数必须是数字."));
                return;
            }

            int sortID = 0;
            if (!int.TryParse(this.txtSortID.Text.Trim(), out sortID))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("排序编号必须是数字."));
                return;
            }

            if (this.ddlChannel.SelectedValue == "-1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("请选择所属频道."));
                return;
            }


            Pbzx.BLL.PBnet_BulletinType ModuleBLL = new Pbzx.BLL.PBnet_BulletinType();

            Pbzx.Model.PBnet_BulletinType PModule = new Pbzx.Model.PBnet_BulletinType();
            
            Pbzx.Model.PBnet_BulletinType MyModule = new Pbzx.Model.PBnet_BulletinType();


            if (ModuleID == 0)
            {
                //增加
                if (ParentID > 0)
                {
                    //不是根类别
                    PModule = ModuleBLL.GetModel(ParentID);
                    MyModule.RootID = PModule.IntNewsTypeID;
                    MyModule.Depth = PModule.Depth + 1;
                    MyModule.IntTypeFID = PModule.IntNewsTypeID;
                }
                else
                {
                    MyModule.Depth = 0;
                }

               MyModule.BitIsAuditing = this.cbMenu.Checked;

                MyModule.BitComment = this.chbDisplay.Checked;
                if (Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from PBnet_BulletinType where VarTypeName='" + txtName.Text.Trim() + "' ")) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("已经存在该公告类别名称"));
                    return;
                }

                MyModule.VarTypeName = txtName.Text;
                MyModule.DisCount = disCount;
                MyModule.IntSortID = sortID;
                MyModule.IntOrderID = this.ddlIntOrderID.SelectedValue;
                MyModule.IntTypeLevel = int.Parse(this.ddlChannel.SelectedValue);
                if (ModuleBLL.Add(MyModule))
                {
                    if (ParentID == 0)
                    {
                        MyModule.IntNewsTypeID = ModuleBLL.GetInsertID();
                        MyModule.IntTypeFID = 0;
                        MyModule.RootID = MyModule.IntNewsTypeID;
                        MyModule.Depth = 0;
                        MyModule.ModuleFIDS = MyModule.IntNewsTypeID.ToString();
                        ModuleBLL.Update(MyModule);
                    }
                    else
                    {
                        MyModule.ModuleFIDS = PModule.ModuleFIDS + "|" + ModuleBLL.GetInsertID();
                    }

                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("公告", "新增公告类别[" + MyModule.VarTypeName + "].");
              //      ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("公告类别添加成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("BulletinType_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("公告类别添加失败."));
                }
            }
            else
            {
                MyModule = ModuleBLL.GetModel(ModuleID);
                if (MyModule.Depth == 1 && ParentID == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("二级模块无法转成顶级模块."));
                    return;
                }

                if (MyModule.Depth > 0)
                {
                    PModule = ModuleBLL.GetModel(ParentID);
                    MyModule.RootID = PModule.IntNewsTypeID;
                    MyModule.IntTypeFID = PModule.IntNewsTypeID;
                }
                MyModule.IntOrderID = this.ddlIntOrderID.SelectedValue;
                MyModule.BitIsAuditing = this.cbMenu.Checked;
                MyModule.BitComment = chbDisplay.Checked;
                if (this.txtName.Text.Trim() != MyModule.VarTypeName && Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from PBnet_BulletinType where VarTypeName='" + txtName.Text.Trim() + "' ")) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("已经存在该公告类别名称"));
                    return;
                }
                MyModule.VarTypeName = txtName.Text;
                MyModule.DisCount = disCount;
                MyModule.IntSortID = sortID;
                MyModule.IntTypeLevel = int.Parse(this.ddlChannel.SelectedValue);
                if (ModuleBLL.Update(MyModule))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改公告类别[" + MyModule.VarTypeName + "].");
                 //   ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("公告类别修改成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("BulletinType_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("公告类别修改失败."));
                }
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.IsAuthority(0);
            hfID.Value = "0";
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex >= 0)
            //{
            //    TableCell MyCell = e.Row.Cells[6];
            //    MyCell.Attributes.Add("onclick", "return confirm('您确定要删除吗?');");
            //}
        }
        

        protected void DelModule(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_BulletinType ModuleBLL = new Pbzx.BLL.PBnet_BulletinType();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除新闻类别[" + ModuleID + "].");
             //   ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("成功删除新闻类别."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("BulletinType_Manage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("删除新闻类别失败."));
            }
        }

        protected void ShowEditor(string e)
        {
            Pbzx.BLL.PBnet_Channel channelBLL = new Pbzx.BLL.PBnet_Channel();
            channelBLL.BindChannelType(this.ddlChannel, 0);
            ddlChannel.Items.Insert(0, "==请选择==");
            ddlChannel.Items[0].Value = "-1";    

            int ModuleID = Convert.ToInt32(e);
            Pbzx.Model.PBnet_BulletinType MyModule = new Pbzx.BLL.PBnet_BulletinType().GetModel(ModuleID);
            txtName.Text = MyModule.VarTypeName;            
            this.txtDisCount.Text = MyModule.DisCount.ToString();
            this.txtSortID.Text = MyModule.IntSortID.ToString();
            hfID.Value = MyModule.IntNewsTypeID.ToString();
            ddlIntOrderID.SelectedValue = MyModule.IntOrderID.ToString();
            cbMenu.Checked = MyModule.BitIsAuditing;
            chbDisplay.Checked = MyModule.BitComment;
            ddlChannel.SelectedValue = MyModule.IntTypeLevel.ToString();
            if (MyModule.Depth > 0)
            {
                Method.sltListBox(ref ddlParent, MyModule.RootID.ToString());
                // txtUrl.Attributes.Remove("disabled");
            }
            else
            {
                ddlParent.SelectedIndex = 0;

            }
            ddlParent.Enabled = (MyModule.Depth > 0);
            divOperator.Visible = true;
            divList.Visible = false;
        }

 

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Channel channelBLL = new Pbzx.BLL.PBnet_Channel();
            channelBLL.BindChannelType(this.ddlChannel, 0);
            ddlChannel.Items.Insert(0, "==请选择==");
            ddlChannel.SelectedValue = "2";    

            hfID.Value = "0";
            txtName.Text = "";
            
            ddlParent.SelectedIndex = 0;
            cbMenu.Checked = true;
            ddlParent.Enabled = true;
            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           divOperator.Visible = false;
            divList.Visible = true;
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
            Pbzx.BLL.PBnet_BulletinType.ChangeAudit(id, "BitIsAuditing");
            BindData();
        }

        protected void lbtnBitComment_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_BulletinType.ChangeAudit(id, "BitComment");
            BindData();
        }

        protected void lbtnUpdateNews_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("网站公告");
        }

    }
}




                                    //<asp:TemplateField HeaderText="删除">
                                    //    <ItemTemplate>
                                    //        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("IntNewsTypeID") %>'
                                    //            OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                                    //    </ItemTemplate>
                                    //</asp:TemplateField>