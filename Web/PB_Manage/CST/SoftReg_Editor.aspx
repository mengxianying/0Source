<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftReg_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftReg_Editor" %>

<html>
<head runat="server">
    <title>软件注册信息管理</title>
    <link href="../stylecss/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="SoftReg_Manager.aspx" class="zilan">软件注册信息管理</a> |&nbsp;
                                     <a href="SoftReg_Editor.aspx" class="zilan">修改软件注册信息</a> </td>
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
                                                当前位置：修改软件注册信息</td>
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
                                    认证码:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblHDSN" runat="server"></asp:Label></td>
                                <td class="bold">
                                    注册码:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblRN" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件类型:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblSoftwaretype" runat="server"></asp:Label></td>
                                <td class="bold">
                                    安装类型:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblInstallType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册时间:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblRegisterDate" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户类型:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblUserType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    过期日期:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:Label ID="lblExpireDate" runat="server"></asp:Label></td>
                                <td class="bold">
                                    使用类型:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:Label ID="lblUserType2" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    升级次数:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblUpdateCount" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户姓名:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    最后升级日期:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblLastUpdateDate" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户电话:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtUserTel" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    最后升级版本:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblLastUpdateVersion" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户邮箱:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtUserEmail" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    数据下载时间:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblDD_Date" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户地址:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtUserAddress" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    当日下载次数:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblDD_Count" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户BBSID:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtBBsID" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    操作员:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:Label ID="lblOperator" runat="server"></asp:Label></td>
                                <td class="bold">
                                    支付金额:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:TextBox ID="txtPayMoney" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    充值卡帐号:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:Label ID="lblCardNo" runat="server"></asp:Label></td>
                                <td class="bold">
                                    支付方式:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:TextBox ID="txtPayType" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    充值卡密码:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:Label ID="lblCardPassword" runat="server"></asp:Label></td>
                                <td class="bold">
                                    支付的详细信息:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<asp:TextBox ID="txtPayDetails" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    包月类型:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblTimeType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    代理ID:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtAgentID" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    原始认证码:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblOrgSN" runat="server"></asp:Label></td>
                                <td class="bold">
                                    代理商姓名:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtAgentName" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    旧的认证码:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblOldSN" runat="server"></asp:Label></td>
                                <td class="bold">
                                </td>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    是否更换:</td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="rdlIsReh" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">没有更换</asp:ListItem>
                                        <asp:ListItem Value="1">已经更换</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td class="bold">
                                    状态:</td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="rdlstatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">许可</asp:ListItem>
                                        <asp:ListItem Value="2">废除</asp:ListItem>
                                        <asp:ListItem Value="0">禁止</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册模式：</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblRegisterMode" runat="server"></asp:Label></td>
                                <td class="bold">
                                    备注:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="7" TextMode="MultiLine" Width="260px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="8" align="center">
                                    <asp:Button ID="btn_ok" runat="server" Text="确定修改" OnClick="btn_ok_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
