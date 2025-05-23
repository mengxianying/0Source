<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageRefresh.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Platform.pageRefresh" %>

    <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>平台刷新详情</title>
    <link type="text/css" rel="stylesheet" href="../StyleCss/css.css" />
    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            GridViewColor();
        }

    </script>
</head>
<body>
    <form id="form2" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Right_bg1">
                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <td width="91%" align="left">
                            平台开奖页面执行详情--页面执行详情
                        </td>
                        <td width="9%" align="right">
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
                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    Width="100%" EnableModelValidation="True" GridLines="Vertical" 
                    OnRowCreated="MyGridView_RowCreated" CssClass="GridView_Table" 
                    onrowdatabound="MyGridView_RowDataBound">
                    <FooterStyle CssClass="GridView_Footer" />
                    <Columns>
                        <asp:BoundField HeaderText="序号" />
                        <asp:TemplateField HeaderText="平台名称">
                            <ItemTemplate>
                                <asp:Label ID="lab_attName" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否执行">
                            <ItemTemplate>
                                <%# Convert.ToInt32(Eval("Complete"))==1 ? "已执行" : "未执行"%>（注：请对照执行时间）
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="执行时间">
                            <ItemTemplate>
                                <%#  Eval("CTime")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="执行IP">
                            <ItemTemplate>
                                <%# Eval("lastIP")%>
                            </ItemTemplate>
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
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 10px;
            margin-bottom: 15px">
            <tr>
                <td align="left" style="padding-left: 10px">
                    <asp:Label ID="lab_count" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT2">
        <tr>
            <td height="32px">
                <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" custominfotextalign="Center"
                    firstpagetext="第一页" lastpagetext="最后一页" nextpagetext="下一页" onpagechanged="AspNetPager1_PageChanged"
                    prevpagetext="上一页" showcustominfosection="Right" showinputbox="Always" shownavigationtooltip="True"
                    width="100%" backcolor="Transparent" custominfostyle='vertical-align:middle;'
                    custominfosectionwidth="35%" horizontalalign="Center">
                                    </webdiyer:aspnetpager>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
