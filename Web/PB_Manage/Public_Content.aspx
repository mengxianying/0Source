<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Public_Content.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Public_Content" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公共内容</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                                当前位置：管理内容</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="CENTER" style="height: 26px">
                                    <a href="Public_Content.aspx">内容管理</a> |&nbsp; <a href="Public_Content_Edit.aspx">添加内容</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="IntID,NvarTitle"
                                    CssClass="GridView_Table" OnRowDeleting="MyGridView_RowDeleting" OnRowDataBound="MyGridView_RowDataBound">
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="序号">
                                            <ItemStyle Width="4%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("IntID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="标题">
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            <ItemTemplate>
                                                <%#Eval("NvarTitle") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="类别">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <ItemTemplate>
                                                <%#Eval("NvarClass")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="动态页面地址">
                                            <ItemTemplate>
                                                <%#Eval("AspxUrl")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="静态页面地址">
                                            <ItemTemplate>
                                                <%#Eval("HtmUrl")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnShow" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                                    OnCommand="lbtnShow_Command"><%# Convert.ToBoolean(Eval("BitState")) ? "审核" : "<font color=red>未审</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="生成">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("IntID") %>'
                                                    OnCommand="LinkButton1_Command">生成</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="4%" />
                                        </asp:TemplateField>
                                        <asp:HyperLinkField DataNavigateUrlFields="IntID" DataNavigateUrlFormatString="Public_Content_Edit.aspx?IntID={0}"
                                            HeaderText="编辑" Text="编辑">
                                            <ItemStyle Width="4%" />
                                        </asp:HyperLinkField>
                                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;">
                                            <ItemStyle Width="4%" />
                                        </asp:CommandField>
                                    </Columns>
                                    <RowStyle CssClass="GridView_Row" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                    PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                    Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                    class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                                </webdiyer:AspNetPager>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
