<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_softpost.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_softpost" %>

<%@ Register Src="~/PB_Manage/Controls/Uc_menu.ascx" TagName="Uc_menu" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_countlog.ascx" TagName="Uc_countlog" TagPrefix="uc2" %>
<html>
<head runat="server">
    <title>软件发贴管理 </title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
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
                                                当前位置：软件发贴管理
                                                <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="添加" /></td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td>
                                    <uc1:Uc_menu ID="Uc_menu1" runat="server"></uc1:Uc_menu>
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
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="序号">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="软件名" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        &nbsp;<%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="对应版面" SortExpression="Boards">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_softpost.aspx?strBoards=<%#Eval("Boards") %>"><%# Eval("Boards")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最小主题数">
                                    <ItemTemplate>
                                        <%# Eval("MinTopics")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="14%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最小跟帖数" SortExpression="MinAnncounts">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_softpost.aspx?strMinAnncounts=<%#Eval("MinAnncounts") %>"><%# Eval("MinAnncounts")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="14%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最小发帖分配的天数" SortExpression="MinDays">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_softpost.aspx?strMinDays=<%#Eval("MinDays") %>"><%# Eval("MinDays")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="16%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最小精华数" SortExpression="MinBests">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_countlog.aspx?strMinBests=<%#Eval("MinBests") %>"><%# Eval("MinBests")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="14%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="Days">
                                    <ItemTemplate>
                                        <%#GetStatus(Eval("Status"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="情况" SortExpression="Flag">
                                    <ItemTemplate>
                                        <%#  Eval("Flag") == "0" ? "内部使用" : "正常"%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
