<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AgentAgree.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.AgentAgree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>代理合同协议</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />代理合同协议</td>
                                            <td width="9%" align="right">
                                              </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="AgentAgree.aspx">合同政策管理</a> |&nbsp; <a href="AgentAgree_Editor.aspx">添加合同政策</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID,Title" CssClass="GridView_Table"
                            PageSize="20" OnRowDeleting="MyGridView_RowDeleting" OnRowDataBound="MyGridView_RowDataBound"
                            AllowSorting="True">
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <FooterStyle CssClass="GridView_Footer" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField HeaderText="序号" DataField="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="标题">
                                    <ItemTemplate>
                                        <%#Eval("Title")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用途">
                                    <ItemTemplate>
                                        <%#Eval("Purpose")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <%#GetState(Eval("State"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="添加时间" SortExpression="AddTime">
                                    <ItemTemplate>
                                        <%#Eval("AddTime")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AgentAgree_Editor.aspx?ID={0}"
                                    HeaderText="编辑" Text="编辑"></asp:HyperLinkField>
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;" />
                            </Columns>
                            <RowStyle CssClass="GridView_Row" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        </asp:GridView>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
