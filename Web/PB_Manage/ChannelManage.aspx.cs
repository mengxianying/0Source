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
using System.Text;
namespace Pbzx.Web.PB_Manage
{
    public partial class ChannelManage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             //   this.IsAuthority(0);
                Pbzx.BLL.PBnet_UrlMaping ModuleBLL = new Pbzx.BLL.PBnet_UrlMaping();
                ModuleBLL.BindUrlMaping(this.ddlParent, 0,0);
                ListItem item = new ListItem("=作为一级频道=", "0");
                ddlParent.Items.Insert(0, item);
                BindData();
                //  ddlParent.Attributes.Add("onchange", "ParentChange(this);");
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_UrlMaping urlBLL = new Pbzx.BLL.PBnet_UrlMaping();
            this.MyGridView.DataSource = urlBLL.GetListBySort(0);
            this.MyGridView.DataBind();
        }

        protected string showModule(object RootID, object mName, object mDepth)
        {
            int depth = Convert.ToInt32(mDepth);
            string name = mName.ToString();
            if (depth == 0)
            {
                name = "<b>" + name + "</b><a href='#' onclick=\"OpenEdite('PBnet_UrlMaping','MapID','PageName','Html','OrderID','and RootID=" + RootID.ToString() + " and Depth>0 and TypeID=0 ','600','350')\" >[子模块排序]</a>";
            }
            else
            {
                name = "├─" + name;
            }
            return name;
            //select 
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


            Pbzx.BLL.PBnet_UrlMaping ModuleBLL = new Pbzx.BLL.PBnet_UrlMaping();

            Pbzx.Model.PBnet_UrlMaping PModule = new Pbzx.Model.PBnet_UrlMaping();
            Pbzx.Model.PBnet_UrlMaping MyModule = new Pbzx.Model.PBnet_UrlMaping();


            if (ModuleID == 0)
            {
                //增加
                if (ParentID > 0)
                {
                    //不是根类别
                    PModule = ModuleBLL.GetModel(ParentID);
                    MyModule.RootID = PModule.MapID;
                    MyModule.Depth = PModule.Depth + 1;
                    MyModule.FID = PModule.MapID;
                }
                MyModule.PageName = txtName.Text;
                MyModule.Html = txtHtml.Text;
                MyModule.Aspx = txtAspx.Text;
                MyModule.TypeID = 0;
             //   MyModule.OrderID = this.ddlIntOrderID.SelectedValue;

                if (ModuleBLL.Add(MyModule))
                {
                    if (ParentID == 0)
                    {
                        MyModule.MapID = ModuleBLL.GetInsertID();
                        MyModule.FID = 0;
                        MyModule.RootID = MyModule.MapID;
                        MyModule.Depth = 0;
                        ModuleBLL.Update(MyModule);
                    }

                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增频道信息[" + MyModule.PageName + "].");
                    // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("新闻类别添加成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("频道信息添加失败."));
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
                    MyModule.RootID = PModule.MapID;
                    MyModule.FID = PModule.MapID;
                }
               // MyModule.OrderID = this.ddlIntOrderID.SelectedValue;
              //  MyModule.BitIsAuditing = this.cbMenu.Checked;
                MyModule.PageName = txtName.Text;
                MyModule.Html = txtHtml.Text;
                MyModule.Aspx = txtAspx.Text;
                if (ModuleBLL.Update(MyModule))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改频道信息[" + MyModule.PageName + "].");
                    //  ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("新闻类别修改成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("频道信息修改失败."));
                }
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          //  this.IsAuthority(0);
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

        //protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "EditCate")
        //    {
        //        this.IsAuthority(2);
        //        this.ShowEditor(e.CommandArgument.ToString());
        //    }
        //    else if (e.CommandName == "DelCate")
        //    {
        //        this.IsAuthority(3);
        //        this.DelModule(e.CommandArgument.ToString());
        //    }
        //}

        protected void DelModule(string e)
        {

            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_UrlMaping ModuleBLL = new Pbzx.BLL.PBnet_UrlMaping();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除频道信息[" + ModuleID + "].");
                //  ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("成功删除新闻类别."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("删除频道信息."));
            }
        }


        protected void ShowEditor(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.Model.PBnet_UrlMaping MyModule = new Pbzx.BLL.PBnet_UrlMaping().GetModel(ModuleID);
            txtName.Text = MyModule.PageName;
            txtHtml.Text = MyModule.Html;
            txtAspx.Text = MyModule.Aspx;          
            hfID.Value = MyModule.MapID.ToString();
           if (MyModule.Depth > 0)
            {
                Method.sltListBox(ref ddlParent, MyModule.OrderID.ToString());
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


        protected void btn_gl_Click(object sender, EventArgs e)
        {
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
          //  this.IsAuthority(1);
            hfID.Value = "0";
            txtName.Text = "";
            ddlParent.SelectedIndex = 0;
            ddlParent.Enabled = true;
            divOperator.Visible = true;
            divList.Visible = false;
        }
        //protected void LinkButton2_Command(object sender, CommandEventArgs e)
        //{
        //  //  this.IsAuthority(3);
        //    DelModule(e.CommandArgument.ToString());
        //}

        //protected void LinkButton_Command(object sender, CommandEventArgs e)
        //{
        ////    this.IsAuthority(2);
        //    this.ShowEditor(e.CommandArgument.ToString());
        //}

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = "(" + id.ToString() + ")";
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            int id = int.Parse(e.CommandArgument.ToString());
            if (bll.GetModel(id).PageName == "首页")
            {
                Application.Lock();
                Application["FC3DData"] = "false";
                Application["TCPL35Data"] = "false";
                Application["TC7XCData_New"] = "false";
                Application["FC7LC"] = "false";
                Application["FCSSData"] = "false";
                Application["TCDLTData"] = "false";
                Application["TC22X5Data"] = "false";
                Application["TC31X7Data"] = "false";
                Application.UnLock();
                Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=quanguo");
                Server.Execute("/PB_Manage/RefurbishGongGao.aspx");
                Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
            }
            bll.CreatHtmlByChannelID(id, false);
            Response.Write("<script>location='ChannelManage.aspx';</script>");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            else if(str.IndexOf("25") > -1)
            {
                Application.Lock();
                Application["FC3DData"] = "false";
                Application["TCPL35Data"] = "false";
                Application["TC7XCData_New"] = "false";
                Application["FC7LC"] = "false";
                Application["FCSSData"] = "false";
                Application["TCDLTData"] = "false";
                Application["TC22X5Data"] = "false";
                Application["TC31X7Data"] = "false";
                Application.UnLock();
                Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=quanguo");
                Server.Execute("/PB_Manage/RefurbishGongGao.aspx");
                Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
            }
            bll.CreateHtmlByBatch(str);
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("生成", "批量生成静态页面[" + str + "]");        
            BindData();
        }

        protected void btnAllCreate_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["FC3DData"] = "false";
            Application["TCPL35Data"] = "false";
            Application["TC7XCData_New"] = "false";
            Application["FC7LC"] = "false";
            Application["FCSSData"] = "false";
            Application["TCDLTData"] = "false";
            Application["TC22X5Data"] = "false";
            Application["TC31X7Data"] = "false";
            Application.UnLock();
            Server.Execute("/PB_Manage/RefurbishCpXml.aspx");
            Server.Execute("/PB_Manage/RefurbishGongGao.aspx");
            Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("生成", "全部生成静态页面");
            bll.CreateHtmlByBatch();
            BindData();
        }
    }
}






















                        //<asp:DataList ID="dlRoot" runat="server" Width="100%" ShowHeader="False" ShowFooter="False">
                        //    <HeaderTemplate>
                        //        <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
                        //        <tr>
                        //            <td>
                                        
                        //            </td>
                        //        </tr>
                        //    </HeaderTemplate>
                        //    <ItemTemplate>
                        //        <tr bgcolor="#D2E4FF">
                        //            <td>
                        //                <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center" background="images/admin_orderbg.jpg">
                        //                    <tr>
                        //                        <td style="width: 30%" height="25">
                        //                            &nbsp;&nbsp;<b><%#Eval("Name")%></b>
                        //                            <%# Eval("Depth").ToString() == "0" ? " <a href='#' onclick=\"OpenEdite('PBnet_Module','ID','Name','LinkUrl','Sort','and RootID=" + Eval("ID") + " and Depth>0 ','600','350')\" > 子模块排序</a>" : ""%>
                        //                        </td>
                        //                        <td style="width: 35%">
                        //                            路径
                        //                        </td>
                        //                        <td style="width: 18%" align="center">
                        //                            编号
                        //                        </td>
                        //                        <td style="width: 10%">
                        //                            <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                        //                                OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                        //                        </td>
                        //                        <td style="width: 7%">
                        //                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                        //                                OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                        //                        </td>
                        //                    </tr>
                        //                </table>
                        //            </td>
                        //        </tr>
                        //        <tr bgcolor="#ffffff">
                        //            <td>
                        //                <asp:DataList runat="server" ID="ChildDataList" GridLines="None" ShowFooter="False"
                        //                    ShowHeader="False" Width="100%" CellPadding="0" CellSpacing="0" Headerstyle-Font-Name="Arial"
                        //                    HeaderStyle-Font-Size="8" Font-Name="Arial" Font-Size="8" DataSource='<%# DataBinder.Eval(Container, "DataItem.myrelation") %>'>
                        //                    <HeaderTemplate>
                        //                        <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
                        //                    </HeaderTemplate>
                        //                    <ItemTemplate>
                        //                        <tr bgcolor="#ffffff">
                        //                            <td style="width: 30%">
                        //                                &nbsp;&nbsp;&nbsp;├─<%#Eval("Name")%>
                        //                            </td>
                        //                            <td style="width: 35%">
                        //                                <%#Eval("URL")%>
                        //                            </td>
                        //                            <td style="width: 18%" align="center">
                        //                                <%#Eval("Sort")%>
                        //                            </td>
                        //                            <td style="width: 10%">
                        //                                <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                        //                                    OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                        //                            </td>
                        //                            <td style="width: 7%">
                        //                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                        //                                    OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                        //                            </td>
                        //                        </tr>
                        //                    </ItemTemplate>
                        //                    <FooterTemplate>
                        //                        </table>
                        //                    </FooterTemplate>
                        //                </asp:DataList>
                        //            </td>
                        //        </tr>
                        //    </ItemTemplate>
                        //    <FooterTemplate>
                        //        </table>
                        //    </FooterTemplate>
                        //</asp:DataList>