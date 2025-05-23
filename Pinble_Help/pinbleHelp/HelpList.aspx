<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpList.aspx.cs" Inherits="Pinble_Help.pinbleHelp.HelpList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>帮助文件详细</title>
    <link rel="Stylesheet" href="../css/GridView.css" />
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2">
            <tr bgcolor="#ffffff" align="center">
                <td>
                    名称
                </td>
                <td>
                    aspx地址
                </td>
                <td>
                    HTML地址
                </td>
                <td>
                    生成
                </td>
            </tr>
            <tr bgcolor="#ffffff" align="center">
                <td>
                    帮助文档导航
                </td>
                <td>
                    <a href="../Help.aspx" target="_blank">Help.aspx</a>
                </td>
                <td>
                    <a href="/Help.htm" target="_blank">Help.htm</a>
                </td>
                <td>
                    <asp:LinkButton ID="linkb_help" runat="server" OnClick="linkb_help_Click">生成</asp:LinkButton>
                </td>
            </tr>
        </table>
        <div>
            <a href="addHelpName.aspx?n=<%=n %>" target="_blank">添加帮助文件名称</a>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                CellPadding="0" Width="100%" AllowPaging="True" OnRowCreated="myGridView_RowCreated"
                CssClass="GridView_Table" OnRowDataBound="myGridView_RowDataBound" OnRowDeleting="myGridView_RowDeleting" OnRowCancelingEdit="myGridView_RowCancelingEdit" OnRowEditing="myGridView_RowEditing" OnRowUpdating="myGridView_RowUpdating">
                <FooterStyle CssClass="GridView_Footer" />
                <Columns>
                    <asp:BoundField HeaderText="序号" />
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                           <%# Eval("Hn_id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="帮助文件名称">
                        <ItemTemplate>
                            <%# Eval("Hn_name") %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="Hn_name" HeaderText="帮助名称" />
                    <asp:TemplateField HeaderText="帮助目录">
                        <ItemTemplate>
                            <a href='<%#Eval("Hn_path").ToString().Replace("~", "")%>' style="cursor: pointer;"
                                target="_blank">
                                <%#Eval("Hn_path")%>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("Hn_Open"))==1 ? "开放" : "关闭" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="适用范围">
                        <ItemTemplate>
                            <asp:Label ID="lab_software" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="保存地址">
                        <ItemTemplate>
                           /html/<%# Eval("Hn_id") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="查看帮助">
                        <ItemTemplate>
                            <a href="../ViewHelp.aspx?id=<%# Eval("Hn_ID") %>&name=<%# Eval("Hn_name") %>&helpName=0" target="_blank">
                                查看</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="添加">
                        <ItemTemplate>
                            <a href="software.aspx?id=<%# Eval("Hn_ID") %>&name=<%# Eval("Hn_name") %>" target="_blank">
                                添加软件</a> <a href="addNoet.aspx?id=<%# Eval("Hn_ID") %>" target="_blank">添加帮助</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="管理">
                        <ItemTemplate>
                            <a href="ModifyNoet.aspx?id=<%# Eval("Hn_ID") %>" target="_blank">管理</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="生成静态页面">
                        <ItemTemplate>
                            <a href="CreatePage.aspx?name=<%# Eval("Hn_ID") %>" target="_blank">查看生成列表</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    <asp:CommandField HeaderText="修改" ShowEditButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="GridView_Pager" />
                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                <RowStyle CssClass="GridView_Row" />
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
            </asp:GridView>
        </div>

    </form>
</body>
</html>
