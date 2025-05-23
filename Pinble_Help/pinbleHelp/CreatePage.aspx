<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePage.aspx.cs" Inherits="Pinble_Help.pinbleHelp.CreatePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>生成静态页面</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">

    <script type="text/javascript" charset="gb2312" src="../script/JScript.js"></script>

    <link href="../css/GridView.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table3" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tbody>
                    <tr>
                        <td valign="top">
                            
                            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                                class="MT">
                                <tr>
                                    <td>
                                        生成帮助页面
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td>
                                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                            CellPadding="0" Width="100%" DataKeyNames="Tree_id" CssClass="GridView_Table"
                                            OnRowDataBound="MyGridView_RowDataBound" OnPageIndexChanging="MyGridView_PageIndexChanging"
                                            OnRowCommand="MyGridView_RowCommand" AllowPaging="True" PageSize="35">
                                            <RowStyle CssClass="GridView_Row" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="全选">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input type="checkbox" name="sel" value="<%#Eval("Tree_id") %>" /></ItemTemplate>
                                                    <ItemStyle Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="序号">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tree_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="栏目名称">
                                                    <ItemTemplate>
                                                        <div align="left" style="padding-left: 5px;">
                                                            <%# showModule(Eval("Tree_RootNotd"), Eval("Tree_superiorNoet"))%>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="HTML地址">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("Tree_Path").ToString().Replace("~", "")%>' style="cursor: pointer;"
                                                            target="_blank">
                                                            <%#Eval("Tree_Path")%>
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ASPX地址">
                                                    <ItemTemplate>
                                                        <a href='/right.aspx?noet=<%#Eval("Tree_num").ToString().Replace("~", "")%>' style="cursor: pointer;"
                                                            target="_blank">/right.aspx?noet=<%# Eval("Tree_num")%>
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="生成">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("Tree_id")+","+Eval("Tree_num") %>'
                                                            runat="server" OnCommand="LinkButton1_Command">生成</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
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
                                            <PagerStyle CssClass="GridView_Pager" />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="4" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 20%">
                                        <b>数据批量操作：</b></td>
                                    <td colspan="4" style="width: 80%">
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Button ID="btnCreate" runat="server" Text="批量生成" OnClientClick="return CheckBatchUpdate('批量生成')"
                                                        OnClick="btnCreate_Click" Height="26px" /></td>
                                                <td colspan="3">
                                                    &nbsp;<asp:Button ID="btnAllCreate" runat="server" Text="全部生成" OnClick="btnAllCreate_Click" Height="26px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 10px;">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        生成树形列表
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridViewTree" runat="server" DataKeyNames="Hn_ID" AutoGenerateColumns="False"
                                            BorderStyle="Solid" CellPadding="0" Width="100%" CssClass="GridView_Table" OnRowCreated="GridViewTree_RowCreated">
                                            <FooterStyle CssClass="GridView_Footer" />
                                            <Columns>
                                                <asp:BoundField HeaderText="序号" />
                                                <asp:TemplateField HeaderText="帮助文件名称">
                                                    <ItemTemplate>
                                                        <%# Eval("Hn_name") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Html页面">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("Hn_path").ToString().Replace("~", "")%>' style="cursor: pointer;"
                                                            target="_blank">
                                                            <%# Eval("Hn_path") %>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Aspx页面">
                                                    <ItemTemplate>
                                                        <a href='/left.aspx?id=<%#Eval("Hn_ID").ToString().Replace("~", "")%>'
                                                            style="cursor: pointer;" target="_blank">/left.aspx?id=<%# Eval("Hn_ID")%>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="生成">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="link_Create" runat="server" CommandArgument='<%# Eval("Hn_ID") %>'
                                                            OnCommand="link_Create_Command">生成</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="GridView_Pager" />
                                            <%--<HeaderStyle Font-Bold="True" CssClass="GridView_Header" />--%>
                                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                            <RowStyle CssClass="GridView_Row" />
                                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
