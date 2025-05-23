<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftRegisterLog_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftRegisterLog_Editor" %>

<html>
<head runat="server">
    <title>网络注册用户购买信息</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="CENTER">
                                 <a href="SoftRegisterLog_Manager.aspx" class="zilan">管理网络注册用户购买信息</a> |&nbsp;
                                    <a href="SoftRegisterLog_Editor.aspx" class="zilan">添加网络注册用户购买信息</a></td>
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
                                                当前位置：网络注册用户购买信息</td>
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
                                    论坛ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBbsName" runat="server"></asp:Label></td>
                                <td class="bold">
                                    客户姓名:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件名称:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSoftwareType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费方式</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayType" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    使用类型:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lbluserType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费金额:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayMoney" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    使用值:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUseValue" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblPayStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">未付费</asp:ListItem>
                                        <asp:ListItem Value="2">已付费</asp:ListItem>
                                        <asp:ListItem Value="3">免费</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    操作员:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOperator" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费时间:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayTime" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    代理名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblRegisterType" runat="server"></asp:Label></td>
                                <td rowspan="4" class="bold">
                                    备注信息:</td>
                                <td rowspan="4">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="6" TextMode="MultiLine" Width="260px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册前用户类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOld_UserType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册前过期日期:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOld_ExpireDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 24px">
                                    注册前剩余点数:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblOld_ValidDays" runat="server"></asp:Label></td>
                                <td class="bold" style="height: 24px">
                                    注册模式:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblRegisterMode" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定提交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
