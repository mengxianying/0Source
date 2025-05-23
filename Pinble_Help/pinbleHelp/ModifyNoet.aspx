<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ModifyNoet.aspx.cs" Inherits="Pinble_Help.pinbleHelp.ModifyNoet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>删除修改节点</title>
    <link rel="Stylesheet" href="../css/GridView.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_search"
            runat="server" Text="搜索" OnClick="btn_search_Click" /><font color="red">(说明：输入编号或是名称)</font> 
        <a href='ModifyNoet.aspx?id=<%=id %>'>查看全部</a>
        <div>
            <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" BorderStyle="Solid"
                CellPadding="0" GridLines="None" Width="99%"
                AllowPaging="True" CssClass="GridView_Table" OnRowCreated="MyGridView_RowCreated"
                OnRowDeleting="MyGridView_RowDeleting" OnPageIndexChanging="MyGridView_PageIndexChanging" OnRowCommand="MyGridView_RowCommand" PageSize="35">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号" />
                    <asp:TemplateField HeaderText="节点编号">
                        <ItemTemplate>
                            <%# Eval("Tree_num") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="节点名称">
                        <ItemTemplate>
                            <%# Eval("Tree_RootNotd") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="父节编号">
                        <ItemTemplate>
                         <a href='ModifyNoet.aspx?superiorNoet=<%# Eval("Tree_superiorNoet") %>&id=<%=id %>'><%# Eval("Tree_superiorNoet") %></a>      
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="对应说明地址">
                        <ItemTemplate>
                            <a href='<%#Eval("Tree_Path").ToString().Replace("~", "")%>' target="_blank">
                                <%# Eval("Tree_Path") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                    <asp:TemplateField HeaderText="修改">
                        <ItemTemplate>
                            <a href="upDateNoet.aspx?id=<%# Eval("Tree_num") %>">修改</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="GridView_Footer" />
                <PagerTemplate>
                    <br />
                    <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                    <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'
                        CommandName="Page" CommandArgument="First"></asp:LinkButton>
                    <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'
                        CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                    <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>'
                        CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                    <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>'
                        CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                    到第<asp:TextBox runat="server" ID="inPageNum" Width="80"></asp:TextBox>页
                    <asp:Button ID="Button1" CommandName="go" runat="server" Text="go" />
                    <br />
                </PagerTemplate>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="GridView_Pager" />
                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                <RowStyle CssClass="GridView_Row" />
                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
            </asp:GridView>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

