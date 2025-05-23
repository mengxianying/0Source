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
using System.Data.SqlClient;

namespace Pbzx.Web.PB_Manage
{
    public partial class Module_Manage  : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindModules();
                this.IsAuthority(0);
                
                Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
                ddlParent.DataSource = ModuleBLL.GetList("Depth=0 order by Sort ");
                ddlParent.DataBind();
                ListItem item = new ListItem("=作为顶级模块=", "0");
                ddlParent.Items.Insert(0, item);

                ddlParent.Attributes.Add("onchange", "ParentChange(this);");
                txtUrl.Attributes.Add("disabled", "true");
            }
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

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int ModuleID = Convert.ToInt32(hfID.Value);
            int ParentID = Convert.ToInt32(ddlParent.SelectedValue);
            if (txtName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("名称不能为空."));
                return;
            }

            if (txtUrl.Text.Trim() == "" && ParentID > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "tagnull", JS.Alert("URL不能为空."));
                return;
            }

            if (this.txtSortID.Text.Trim() == "" )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SortNull", JS.Alert("排序编号不能为空."));
                return;
            }


            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            
            Pbzx.Model.PBnet_Module PModule = new Pbzx.Model.PBnet_Module();
            Pbzx.Model.PBnet_Module MyModule = new Pbzx.Model.PBnet_Module();

            if (ModuleID == 0)
            {
                if (ParentID > 0)
                {
                    if (ModuleBLL.GetURLCount(txtUrl.Text) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("该模块标签已存在."));
                        return;
                    }
                    PModule = ModuleBLL.GetModel(ParentID);
                    MyModule.RootID = PModule.RootID;
                    MyModule.Depth = 1;             
                }    
                if (cbMenu.Checked) MyModule.FlagMenu = 1;
                else
                {
                     MyModule.FlagMenu = 0;
                }
                MyModule.URL = txtUrl.Text.Trim();
                MyModule.Sort = int.Parse(this.txtSortID.Text);
                MyModule.Name = txtName.Text;
                
                if (ModuleBLL.Add(MyModule))
                {
                    MyModule.ID = ModuleBLL.GetInsertID();
                    if (ParentID == 0)
                    {                       
                        MyModule.RootID = MyModule.ID;
                       // MyModule.FlagMenu = 1;
                    }
                    MyModule.TempID = Method.AdminPowerSettingFormart(ModuleBLL.GetInsertID().ToString());
                    ModuleBLL.Update(MyModule);
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增模块[" + MyModule.Name + "].");
                    ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("模块添加成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Module_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("模块添加失败."));
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
                    MyModule.URL = txtUrl.Text;
                    MyModule.RootID = PModule.ID;
                    if (cbMenu.Checked) { MyModule.FlagMenu = 1; }
                    else
                    {
                        MyModule.FlagMenu = 0;
                    }
                }
                MyModule.Sort = int.Parse(this.txtSortID.Text);
                MyModule.Name = txtName.Text;
                MyModule.TempID =  Method.AdminPowerSettingFormart(MyModule.ID.ToString());
                if (ModuleBLL.Update(MyModule))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改模块[" + MyModule.Name + "].");
                    ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("模块修改成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Module_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("模块修改失败."));
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

        //protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex >= 0)
        //    {
        //        TableCell MyCell = e.Row.Cells[5];
        //        MyCell.Attributes.Add("onclick", "return confirm('您确定要删除吗?');");
        //    }
        //}

        protected void DelModule(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除模块[" + ModuleID + "].");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("成功删除模块."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("Module_Manage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("删除模块失败."));
            }
        }

        protected void ShowEditor(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.Model.PBnet_Module MyModule = new Pbzx.BLL.PBnet_Module().GetModel(ModuleID);
            txtName.Text = MyModule.Name;
            txtUrl.Text = MyModule.URL;
            txtSortID.Text = MyModule.Sort.ToString();
            hfID.Value = MyModule.ID.ToString();
            cbMenu.Checked = (MyModule.FlagMenu == 1);
            if (MyModule.Depth > 0)
            {
                Method.sltListBox(ref ddlParent, MyModule.RootID.ToString());
                txtUrl.Attributes.Remove("disabled");
            }
            else
            {
                ddlParent.SelectedIndex = 0;

            }
            ddlParent.Enabled = (MyModule.Depth > 0);
            divOperator.Visible = true;
            divList.Visible = false;
        }

 
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.IsAuthority(1);
            hfID.Value = "0";
            txtName.Text = "";
            txtUrl.Text = "";
            this.txtSortID.Text = "0";
            ddlParent.SelectedIndex = 0;
            cbMenu.Checked = true;
            ddlParent.Enabled = true;
            divOperator.Visible = true;
            divList.Visible = false;
        }

        //protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex != -1)
        //    {
        //        int id = e.Row.RowIndex + 1;
        //        e.Row.Cells[0].Text ="("+id.ToString()+")";
        //    }

        //}

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            this.IsAuthority(3);
            DelModule(e.CommandArgument.ToString());
            string str = Method.AdminPowerSettingFormart(e.CommandArgument.ToString()) + ",";
            DbHelperSQL.ExecuteSql("update  PBnet_tpman set Setting=replace(Setting,'"+str+",','')  WHERE charindex('"+str+"',Setting)> 0");
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            this.IsAuthority(2);
            this.ShowEditor(e.CommandArgument.ToString());
        }


        private void BindModules()
        {
            string constring = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

            DataSet ds = new DataSet();
            string sql1 = "select * from PBnet_Module where Depth=0 order by Sort ";
            SqlDataAdapter sda1 = new SqlDataAdapter(sql1, constring);
            sda1.Fill(ds, "province");

            string sql2 = "select * from PBnet_Module where Depth>0 order by Sort";
            SqlDataAdapter sda2 = new SqlDataAdapter(sql2, constring);
            sda2.Fill(ds, "city");

            ds.Relations.Add("myrelation", ds.Tables["province"].Columns["RootID"], ds.Tables["city"].Columns["RootID"]);

            dlRoot.DataSource = ds.Tables["province"].DefaultView;
            dlRoot.DataBind();


            //string sql1 = "select * from PBnet_Module where Depth=0 and FlagMenu=1 order by Sort ";
            //DataSet ds  =DbHelperSQL.Query(sql1);
            //ds.Tables[0].TableName = "Root";

            // string sql2 = "select * from PBnet_Module where Depth>0 and FlagMenu=1 order by Sort ";
            //SqlDataAdapter sda2 = new SqlDataAdapter(sql2, constring);
            //sda2.Fill(ds, "city");

            //ds.Relations.Add("myrelation", ds.Tables["province"].Columns["provinceID"], ds.Tables["city"].Columns["father"]);
            //dlCategories.DataSource = ds.Tables["province"].DefaultView;
            //dlCategories.DataBind();

        }
        protected void DelTemp(string strTemp)
        {
            //  DbHelperSQL.ExecuteSql(update PBnet_tpman set Setting='" + EnCodePower() + "' where Master_Name='" + ViewState["currentUser"].ToString() + "' ");
          
        }

        protected void lblSortAll_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            DataSet dsRoot = ModuleBLL.GetList("Depth=0 order by Sort ");
            int tempK = 0;
            if(dsRoot.Tables.Count > 0 && dsRoot.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsRoot.Tables[0].Rows.Count;i++ )
                {
                    DataRow row = dsRoot.Tables[0].Rows[i];
                    tempK++;
                    DbHelperSQL.ExecuteSql(" update PBnet_Module set AllSort=" + tempK + " where ID=" + row["ID"] + " ");
                    DataSet dsChild = DbHelperSQL.Query("select * from PBnet_Module where RootID=" + row["RootID"] + " and Depth>0 order by Sort ");
                    for (int j = 0; j < dsChild.Tables[0].Rows.Count; j++ )
                    {
                        DataRow rowChild = dsChild.Tables[0].Rows[j];
                        tempK++;
                        DbHelperSQL.ExecuteSql(" update PBnet_Module set AllSort=" + tempK + " where ID=" + rowChild["ID"] + " ");   
                    }
                }
            }
        }
     

    }
}











                        //<asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        //    CellPadding="0" Width="100%" DataSourceID="odsMaster" DataKeyNames="ID" OnRowCreated="MyGridView_RowCreated"
                        //    CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                        //    <FooterStyle CssClass="GridView_Footer" />
                        //    <Columns>
                        //        <asp:TemplateField HeaderText="序号">
                        //            <ItemTemplate>
                        //                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        //            </ItemTemplate>
                        //        </asp:TemplateField>
                        //        <asp:TemplateField HeaderText="模块名称">
                        //            <ItemTemplate>
                        //                <div align="left" style="padding-left: 5px;">
                        //                    <%# showModule(Eval("Name"), Eval("Depth"))%>
                        //                    <%# Eval("Depth").ToString() == "0" ? " <a href='#' onclick=\"OpenEdite('PBnet_Module','ID','Name','LinkUrl','Sort','and RootID=" + Eval("ID") + "','600','350')\" > 子模块排序</a>" : ""%>
                        //                </div>
                        //            </ItemTemplate>
                        //        </asp:TemplateField>
                        //        <asp:BoundField DataField="URL" HeaderText="路径" />
                        //        <asp:BoundField DataField="Sort" HeaderText="排序编号" />
                        //        <asp:TemplateField HeaderText="编辑">
                        //            <ItemTemplate>
                        //                <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                        //                    OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                        //            </ItemTemplate>
                        //        </asp:TemplateField>
                        //        <asp:TemplateField HeaderText="删除">
                        //            <ItemTemplate>
                        //                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                        //                    OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                        //            </ItemTemplate>
                        //        </asp:TemplateField>
                        //    </Columns>
                        //    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        //    <PagerStyle CssClass="GridView_Pager" />
                        //    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                        //    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        //    <RowStyle CssClass="GridView_Row" />
                        //    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        //</asp:GridView>