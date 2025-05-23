<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTradeInfoDetail.aspx.cs" Inherits="Pbzx.Web.PB_Manage.UserTradeInfoDetail" %>

<html>
<head id="Head1" runat="server">
    <title>网络注册用户购买信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
</head>
<body >
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
                                                当前位置：用户交易日志详细信息</td>
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
                                    交易金额:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTradeMoney" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    交易时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTradeTime" runat="server"></asp:Label></td>
                                <td class="bold">
                                    交易类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTradeType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    银行名称:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                                <td class="bold" rowspan="7">
                                    备注信息:</td>
                                <td rowspan="7">
                                    &nbsp;
                                    &nbsp;<asp:TextBox ID="txtRemark" runat="server" Rows="6" TextMode="MultiLine" Width="291px" Enabled="False" Height="177px"></asp:TextBox>&nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 23px">
                                    帐户姓名:</td>
                                <td style="height: 23px">
                                    &nbsp;<asp:Label ID="lblAccount_UserName" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    账号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblAccountNumber" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    用户当前余额</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCurrentMoney" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    操作员:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOperateManager" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    </td>
                                <td>
                                    </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td  style="font-weight:bold;" align="center" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                               <%-- <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定提交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                   <input type="button" onclick="window.opener=null;window.open('','_self');window.close();" size="30" value="关闭" id="Button1" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

