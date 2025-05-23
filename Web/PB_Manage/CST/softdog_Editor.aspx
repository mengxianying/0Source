<%@ Page Language="C#" AutoEventWireup="true" Codebehind="softdog_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.softdog_Editor" %>

<html>
<head runat="server">
    <title>修改软件狗信息</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--    <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="CENTER">
                                 <a href="softdog_Manager.aspx" class="zilan">管理软件狗</a> |&nbsp;
                                    <a href="softdog_Editor.aspx" class="zilan">添加软件狗</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：修改软件狗信息</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    序列号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="labID" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="labCreateTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    代理商ID:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtAgentID" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    代理商:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtAgentName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建者:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtCreater" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    销售者:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtSeller" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 28px">
                                    销售时间:</td>
                                <td style="height: 28px">
                                    &nbsp;<asp:TextBox ID="txtSellTime" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    支付方式:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayType" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    补发前序列号:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtOldSN" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件狗价格:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtSellPrice" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    备注:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="7" TextMode="MultiLine" Width="380px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td>
                                  <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Selected="True">未出售</asp:ListItem>
                                        <asp:ListItem Value="1">已出售</asp:ListItem>
                                        <asp:ListItem Value="10">禁止</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="bt_ok" runat="server" OnClick="bt_ok_Click" Text="提交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
