<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBuyLogList.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Platform.tobuy.AdminBuyLogList" %>

    <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户购买记录</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/css.css" />
    <script language="javascript" src="../../JScript/javascript.js" type="text/javascript"></script>
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
                            虚拟购彩--用户购买记录
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
                    Width="100%" EnableModelValidation="True" GridLines="Vertical" OnRowCreated="MyGridView_RowCreated"
                    OnRowDeleting="MyGridView_RowDeleting" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                    <FooterStyle CssClass="GridView_Footer" />
                    <Columns>
                        <asp:BoundField HeaderText="序号" />
                        <asp:TemplateField HeaderText="期号">
                            <ItemTemplate>
                                <%# Eval("Pp_issue")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="消费类型">
                            <ItemTemplate>
                                <%#  IsTypeName(Eval("Pp_Type"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="彩种类型">
                            <ItemTemplate>
                                <%#  GetLottoryName(Eval("Pp_LotName"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="说明">
                            <ItemTemplate>
                                <%# Eval("Pp_explain")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作金额">
                            <ItemTemplate>
                                <%# Eval("Pp_data")%>元
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作时间">
                            <ItemTemplate>
                                <%# Eval("Pp_Time")%>
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
