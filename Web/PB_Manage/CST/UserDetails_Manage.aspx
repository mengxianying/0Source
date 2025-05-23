<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserDetails_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.UserDetails_Manage" %>

<%@ Register Src="~/PB_Manage/Controls/UcUdetailsSearch.ascx" TagName="UserSearch"
    TagPrefix="ucl" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>用户资料管理</title>
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
                                                当前位置：用户资料管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="3" cellpadding="3">
                                        <tr>
                                            <td align="CENTER">
                                                <a href="UserDetails.aspx" target="_blank" style="font-weight: normal">添加用户资料</a>
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
                        <ucl:UserSearch ID="UserSearch1" runat="server"></ucl:UserSearch>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:BoundField DataField="BbsName" HeaderText="论坛昵称">
                                    <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="客户名">
                                    <ItemStyle Width="7%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserTel" HeaderText="客户电话">
                                    <ItemStyle Width="21%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserAddress" HeaderText="客户地址">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Remarks" HeaderText="备注信息">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
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
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="25%"
                            CustomInfoTextAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
