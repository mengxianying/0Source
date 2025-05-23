<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AdvPlace_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.AdvPlace_Manage" %>

<%@ Register Src="Controls/UcADwei.ascx" TagName="UcADwei" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告位管理</title>
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
                                                当前位置：广告位管理>>广告位管理列表</td>
                                            <td width="9%" align="right">
                                                <%--  <asp:Button ID="Button2" runat="server" Text=">>返回" OnClientClick="history.back();return false;" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="AdvPlace_Manage.aspx">广告位列表</a> | <a href="AdPlaceSum.aspx">广告位批量(添加/修改)</a><%--|
                                    <a href="AdvPlace_Edit.aspx">添加广告位</a>--%>
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
                        <uc1:UcADwei ID="UcADwei1" runat="server"></uc1:UcADwei>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                            OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <Columns>
                                <asp:TemplateField HeaderText="序号" SortExpression="ID">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbxu" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="位置名称" SortExpression="PlaceName">
                                    <ItemTemplate>
                                        <%#Eval("PlaceName")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类别" SortExpression="TypeID">
                                    <ItemTemplate>
                                        <a href='AdvPlace_Manage.aspx?ADType=<%#Eval("TypeID")%>'>
                                            <%#Pbzx.Common.Method.GetadClass(Eval("TypeID"))%>
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="频道" SortExpression="ChannelID">
                                    <ItemTemplate>
                                        <a href='AdvPlace_Manage.aspx?Channel=<%#Eval("ChannelID")%>'>
                                            <%#Pbzx.Common.Method.GetadChanl(Eval("ChannelID"))%>
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="位置类别" SortExpression="PlaceType">
                                    <ItemTemplate>
                                        <a href='AdvPlace_Manage.aspx?PlaceType=<%#Eval("PlaceType")%>'>
                                            <%#Eval("PlaceType")%>
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="left" Width="16%" />
                                </asp:TemplateField>
<%--                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm('您确定要删除吗?')"
                                            CommandArgument='<%# Eval("ID") %>' OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="17%" />
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                           FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
