<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserIntegral.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Platform.match.UserIntegral" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户积分 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/css.css" />
    <script language="javascript" src="../../JScript/javascript.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            GridViewColor();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Right_bg1">
                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <td width="91%" align="left">
                            用户积分 -- 拼搏擂台
                        </td>
                        <td width="9%" align="right">
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
                               <table width="80%" border="0" cellspacing="0" cellpadding="1">
                                    <tr>
                                        <td>
                                            会员名称：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Width="125"></asp:TextBox></td>
<%--                                            <td>
                                                &nbsp;期号：</td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" Width="80"></asp:TextBox></td>--%>
                                            <td>
                                                &nbsp;条件名称：
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCondition" runat="server" Width="80"></asp:TextBox></td>
                                          <td><asp:Button ID="btnOK" runat="server" Text="查找" onclick="btnOK_Click" />&nbsp;<asp:Button 
                                                  ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
        class="MT">
        <tr bgcolor="#ffffff">
            <td>
                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    Width="100%" EnableModelValidation="True" GridLines="Vertical" OnRowCreated="MyGridView_RowCreated"
                    OnRowDeleting="MyGridView_RowDeleting" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                    <FooterStyle CssClass="GridView_Footer" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cb" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="序号" />
                        <asp:TemplateField HeaderText="用户名">
                            <ItemTemplate>
                                <%# Eval("I_name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="彩种">
                            <ItemTemplate>
                                <asp:Label ID="lab_lott" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="条件名称">
                            <ItemTemplate>
                                <asp:Label ID="lab_name" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="积分">
                            <ItemTemplate>
                                <%# Eval("I_Integral")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
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
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT2">
        <tr>
            <td align="left">
                <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" Style="height: 21px" />
            </td>
            <td height="32px">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                    Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                    CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
