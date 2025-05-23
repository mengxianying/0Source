<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Broker" %>

<%@ Register Src="Controls/UcBroker.ascx" TagName="UcBroker" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>经纪人信息管理</title>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
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
                                                当前位置：经纪人信息管理</td>
                                            <td width="9%" align="right">
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
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcBroker id="UcBroker1" runat="server">
                        </uc1:UcBroker></td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" DataKeyNames="ID" CssClass="GridView_Table" PageSize="20" Width="100%"
                            AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                    <ItemTemplate>
                                        <%# Eval("UserName")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审核时间" SortExpression="Pass_time">
                                    <ItemTemplate>
                                        <%# Eval("Pass_time", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="折扣等级" SortExpression="Discount_gradeName">
                                    <ItemTemplate>
                                        <%# (Eval("Discount_gradeName"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="折扣" SortExpression="Discount_rate">
                                    <ItemTemplate>
                                        <%# Eval("Discount_rate")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="State">
                                    <ItemTemplate>
                                        <%#GetState(Eval("State"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="审核者" SortExpression="Auditing_Manager">
                                    <ItemTemplate>
                                        <%# Eval("Auditing_Manager")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="本年总额" SortExpression="Year_tradeMoney">
                                    <ItemTemplate>
                                        <%# Eval("Year_tradeMoney", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="本年获益" SortExpression="Year_incomeMoney">
                                    <ItemTemplate>
                                        <%# Eval("Year_incomeMoney", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总金额" SortExpression="Total_tradeMoney">
                                    <ItemTemplate>
                                        <%# Eval("Total_tradeMoney", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总获益" SortExpression="Total_incomeMoney">
                                    <ItemTemplate>
                                        <%# Eval("Total_incomeMoney", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最后登陆时间" SortExpression="LastLogin_time">
                                    <ItemTemplate>
                                        <%# Eval("LastLogin_time", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
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
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            CustomInfoStyle='vertical-align:middle;' OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
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
