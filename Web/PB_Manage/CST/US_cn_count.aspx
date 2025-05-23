<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="US_cn_count.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_cn_count" %>

<%@ Register Src="../Controls/Uc_cnCount.ascx" TagName="Uc_cnCount" TagPrefix="uc4" %>

<%@ Register Src="../Controls/Uc_UserPost.ascx" TagName="Uc_UserPost" TagPrefix="uc3" %>

<%@ Register Src="~/PB_Manage/Controls/Uc_menu.ascx" TagName="Uc_menu" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_countlog.ascx" TagName="Uc_countlog" TagPrefix="uc2" %>
<html>
<head id="Head1" runat="server">
    <title>统计信息管理</title>
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
                                                当前位置：统计信息管理
                                            </td>
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
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        &nbsp;ff<uc4:Uc_cnCount id="Uc_cnCount1" runat="server"></uc4:Uc_cnCount></td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" AllowSorting="True" OnSorting="MyGridView_Sorting"
                            OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="Username">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?Username=<%#Eval("Username") %>"><%#Eval("NormalAnnounceCount") %></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="11%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="版面ID" SortExpression="BoardID">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?BoardID=<%#Eval("BoardID") %>"><%# BoardNameByID(Eval("BoardID"))%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="16%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="主题" SortExpression="NormalTopicCount">
                                    <ItemTemplate>
                                        <%#Eval("BestAnnounceCount") %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="精华主题" SortExpression="BestTopicCount">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?isbest=<%#Eval("BestTopicCount") %>"><%# Eval("BestAnnounceCount")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="跟帖" SortExpression="NormalAnnounceCount">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?NormalAnnounceCount=<%#Eval("NormalAnnounceCount") %>"><%#Eval("DelTopicCount") %></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="精华跟帖" SortExpression="BestAnnounceCount">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?BestAnnounceCount=<%#Eval("BestAnnounceCount") %>"><%# Eval("DelTopicCount")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="被删主帖" SortExpression="DelTopicCount">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?DelTopicCount=<%#Eval("DelTopicCount") %>"><%#Eval("DelAnnounceCount") %></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="被删跟帖" SortExpression="DelAnnounceCount">
                                    <ItemTemplate>
                                        &nbsp;<a href="US_cn_count.aspx?DelAnnounceCount=<%#Eval("DelAnnounceCount") %>"><%# Eval("DelAnnounceCount")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="主帖数" SortExpression="TotalTopicCount">
                                    <ItemTemplate>
                                        &nbsp;<%# Eval("TotalTopicCount")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="跟帖数" SortExpression="TotalAnnounceCount">
                                    <ItemTemplate>
                                        &nbsp;<%# Eval("TotalAnnounceCount")%>
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
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页;" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
