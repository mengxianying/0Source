<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProductOrderManager.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.ProductOrderManager" %>

<%@ Register Src="Controls/UcProductOrderSearch.ascx" TagName="UcProductOrderSearch"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/UcRegLogSearch.ascx" TagName="UcRegLogSearch" TagPrefix="uc3" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品订单信息管理</title>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <link href="stylecss/css.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1" style="height: 26px">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：产品订单信息</td>
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
                        <uc1:UcProductOrderSearch ID="UcProductOrderSearch1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="OrderID" CssClass="GridView_Table"
                            AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:BoundField HeaderText="序号" DataField="OrderID" />
                                <asp:TemplateField HeaderText="订单编号" SortExpression="OrderID">
                                    <ItemTemplate>
                                        <%#Eval("OrderID")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="论坛名" SortExpression="UserName">
                                    <ItemTemplate>
                                        <a href="ProductOrderManager.aspx?strBbsName=<%#Eval("UserName")%>">
                                            <%#Eval("UserName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户名" SortExpression="ReceiverName">
                                    <ItemTemplate>
                                        <a href="ProductOrderManager.aspx?strUsername=<%# Eval("ReceiverName")%>" title='客户名地址：<%#DataBinder.Eval(Container.DataItem,"ReceiverAddress")%>&#13;客户名电话:<%#DataBinder.Eval(Container.DataItem,"ReceiverPhone")%>&#13;客户名Email:<%#DataBinder.Eval(Container.DataItem,"ReceiverEmail")%>'>
                                            <%# Eval("ReceiverName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="产品总价" SortExpression="TotalProductPrice">
                                    <ItemTemplate>
                                        <%# Eval("TotalProductPrice", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="邮费" SortExpression="PortPrice">
                                    <ItemTemplate>
                                        <%# Eval("PortPrice", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已付费用" SortExpression="HasPayedPrice">
                                    <ItemTemplate>
                                        <%#Eval("HasPayedPrice", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付款方式" SortExpression="PayTypeName">
                                    <ItemTemplate>
                                        <a href="ProductOrderManager.aspx?payType=<%#Eval("PayTypeID")%>">
                                            <%#Eval("PayTypeName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单状态" SortExpression="TipName">
                                    <ItemTemplate>
                                        <a href="ProductOrderManager.aspx?tipID=<%#Eval("TipID")%>">
                                            <%# Pbzx.Web.WebFunc.FormartTipName1(Eval("TipID"), Eval("IsPay"), Eval("IsCancel"))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单更新时间" SortExpression="UpdateStaticDate">
                                    <ItemTemplate>
                                        <%#Eval("UpdateStaticDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
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
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        &nbsp; &nbsp; 统计信息：总价（<asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                        ）；邮费（<asp:Label ID="lblPostPrice" runat="server"></asp:Label>）；已付费用（<asp:Label ID="lblHasPay"
                            runat="server"></asp:Label>）</td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
