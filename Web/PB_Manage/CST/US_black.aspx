<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_black.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_black" %>

<%@ Register Src="~/PB_Manage/Controls/Uc_menu.ascx" TagName="Uc_menu" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_black.ascx" TagName="Uc_black" TagPrefix="uc2" %>
<html>
<head runat="server">
    <title>黑名单信息管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
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
                                                当前位置：黑名单信息管理
                                                <asp:Button ID="btnhei" runat="server" OnClick="btnhei_Click" Text="添加黑名单信息" /></td>
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                        class="MT">
                        <tr>
                            <td bgcolor="#F7FBFF" align="left">
                                <uc2:Uc_black ID="Uc_black1" runat="server"></uc2:Uc_black>
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
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="黑名单内容" SortExpression="BlackValue">
                                            <ItemTemplate>
                                                &nbsp;<a href="US_black.aspx?strName=<%#Eval("BlackValue") %>"><%# Eval("BlackValue")%></a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="标志" SortExpression="BlackFlag">
                                            <ItemTemplate>
                                                <a href="US_black.aspx?softwareType=<%#Eval("BlackFlag") %>">
                                                    <%# GetFlag(Eval("BlackFlag"))%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="创建时间" SortExpression="CreateTime" DataField="CreateTime"
                                            DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                            <ItemStyle HorizontalAlign="center" Width="15%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="状态" SortExpression="Status">
                                            <ItemTemplate>
                                                <%#GetStatus(Eval("Status"))%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="详细内容" SortExpression="Details">
                                            <ItemTemplate>
                                                <%# Eval("Details")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <a href='Bacl_Editor.aspx?ID=<%#Eval("ID") %>' target="_blank">编辑</a>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lbtnAduting" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                                Text='<%#  Eval("Status").ToString()=="1" ? "<font color=green>解除</font>" : "<font color=red>启用</font>" %>'
                                                                Width="30px" OnCommand="lbtnAduting_Command"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
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
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" 
                                    BackColor="Transparent" class="pagestyle" 
                                    CustomInfoStyle="vertical-align:middle;" CustomInfoTextAlign="Center" 
                                    FirstPageText="首页" HorizontalAlign="Center" LastPageText="尾页" NextPageText="下页" 
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" 
                                    ShowCustomInfoSection="Right" ShowInputBox="Always" 
                                    ShowNavigationToolTip="True" Width="100%">
                                </webdiyer:AspNetPager>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            </td>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
