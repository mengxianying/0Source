<%@ Page Language="C#" AutoEventWireup="true" Codebehind="admin_Ly.aspx.cs" Inherits="Pbzx.Web.PB_Manage.admin_Ly" %>

<%@ Register Src="Controls/Ucadmin_Ly.ascx" TagName="Ucadmin_Ly" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户留言管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

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
                                                当前位置：用户留言管理</td>
                                            <td width="9%" align="right">
                                                <%-- <asp:Button ID="Button2" runat="server" Text=">>返回" OnClientClick="history.back();return false;" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                aligin="left" class="MT">
                <tr>
                    <td bgcolor="#ffffff">
                        <uc1:Ucadmin_Ly ID="Ucadmin_Ly1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td style="height: 22px">
                        <asp:GridView ID="MyGridView" runat="server" CssClass="GridView_Table" Width="100%"
                            AutoGenerateColumns="False" OnRowDataBound="MyGridView_RowDataBound" OnSorting="MyGridView_Sorting"
                            DataKeyNames="SystemNumber" AllowSorting="True">
                            <Columns>
                                <asp:BoundField DataField="SystemNumber" HeaderText="序号" ItemStyle-Width="5%" />
                                <asp:TemplateField HeaderText="用户名" SortExpression="LyUserName">
                                    <ItemTemplate>
                                        <%#Eval("LyUserName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="7%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标题" SortExpression="Ly_Email">
                                    <ItemTemplate>
                                        <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("Ly_Email"),12*2)%>
                                    </ItemTemplate>
                                    <ItemStyle Width="16%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="留言内容">
                                    <ItemTemplate>
                                        <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("LyContent"), 20*2)%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="留言类型" SortExpression="LySort">
                                    <ItemTemplate>
                                        <a href="admin_Ly.aspx?Sort=<%#Eval("LySort")%>">
                                             <%# Pbzx.Web.WebFunc.GetLyTypeByID(Eval("LySort"))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="7%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="LyState">
                                    <ItemTemplate>
                                        <a href="admin_Ly.aspx?State=<%#Eval("LyState")%>">
                                            <%# Convert.ToBoolean(Eval("LyState")) ? "<font color=green>已回复</font>" : "<font color=red>未回复</font>" %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="留言时间" SortExpression="LyLogTime">
                                    <ItemTemplate>
                                        <%#Eval("LyLogTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="14%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href='admin_Ly_Edit.aspx?ID=<%#Eval("SystemNumber") %>' target="_blank">
                                            <%# Convert.ToBoolean(Eval("LyState")) ? "<font color=green>查看</font>":"<font color=red>回复</font>"%>
                                        </a>|<asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('您确定要删除吗?')"
                                            CommandArgument='<%# Eval("SystemNumber") %>' OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
