<%@ Control Language="C#" AutoEventWireup="true" Codebehind="WebUserControl1.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.WebUserControl1" %>
<link type="text/css" rel="stylesheet" href="../stylecss/Admin_r.css" />
<table width="100%">
    <tr id="tr1" style="font-size: 12px;">
        <td colspan="9" style="height: 57px">
            <table width="100%">
                <tr>
                    <td style="width: 7%; height: 62px;" align="right">
                        认证码:</td>
                    <td style="width: 22%; height: 62px;">
                        <table>
                            <tr>
                                <td style="width: 70%" valign="bottom">
                                    <asp:TextBox ID="txtHDSN" runat="server" Width="100%"> </asp:TextBox></td>
                                <td style="width: 15%">
                                    <asp:CheckBox ID="chkYuan" runat="server" /></td>
                                <td style="width: 15%">
                                    原
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 7%; height: 62px;" align="right">
                        注册码:
                    </td>
                    <td style="width: 12%; height: 62px;">
                        <asp:TextBox ID="txtAct_RN" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 10%; height: 62px;" align="right">
                        旧的认证码&nbsp;</td>
                    <td style="width: 9%; height: 62px;">
                        &nbsp;<asp:TextBox ID="txtOldSN" runat="server" Width="130%"></asp:TextBox></td>
                    <td style="width: 33%; height: 62px;">
                        &nbsp;<table style="width: 100%">
                            <tr>
                                <td style="width: 54%;" align="right">
                                    原始认证码:</td>
                                <td style="width: 46%;">
                                    <asp:TextBox ID="txtOrgSN" runat="server" Width="100%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="font-size: 12px">
        <td colspan="9" style="height: 57px">
            <table width="100%">
                <tr>
                    <td style="width: 7%" align="right">
                        姓名:</td>
                    <td style="width: 32%">
                        <table width="100%">
                            <tr>
                                <td style="width: 34%">
                                    <asp:TextBox ID="txtUserName" runat="server" Width="100%"> </asp:TextBox>&nbsp;</td>
                                <td style="width: 33%">
                                    论坛ID</td>
                                <td style="width: 33%">
                                    <asp:TextBox ID="TextBox1" Width="100%" runat="server"> </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 7%" align="right">
                        包月:
                    </td>
                    <td style="width: 12%">
                        &nbsp;<asp:DropDownList ID="ddlTimeType" runat="server">
                            <asp:ListItem Value=" ">所有</asp:ListItem>
                            <asp:ListItem Value="1">1个月</asp:ListItem>
                            <asp:ListItem Value="2">3个月</asp:ListItem>
                            <asp:ListItem Value="3">半年</asp:ListItem>
                            <asp:ListItem Value="4">1年</asp:ListItem>
                            <asp:ListItem Value="5">2年</asp:ListItem>
                            <asp:ListItem Value="6">3年</asp:ListItem>
                            <asp:ListItem Value="7">终身</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 10%" align="right">
                        付费方式:
                    </td>
                    <td style="width: 9%">
                        <asp:DropDownList ID="ddlPayType" runat="server" Width="105">
                            <asp:ListItem Value="">所有</asp:ListItem>
                            <asp:ListItem Value="招商银行汇款">招商银行汇款</asp:ListItem>
                            <asp:ListItem Value="工商银行汇款">工商银行汇款</asp:ListItem>
                            <asp:ListItem Value="建设银行汇款">建设银行汇款</asp:ListItem>
                            <asp:ListItem>建行对公汇款</asp:ListItem>
                            <asp:ListItem>农业银行汇款</asp:ListItem>
                            <asp:ListItem>交通银行汇款</asp:ListItem>
                            <asp:ListItem>邮政储蓄汇款</asp:ListItem>
                            <asp:ListItem>邮局汇款</asp:ListItem>
                            <asp:ListItem>在线支付</asp:ListItem>
                            <asp:ListItem>上门支付</asp:ListItem>
                            <asp:ListItem>充值卡支付</asp:ListItem>
                            <asp:ListItem>其他方式</asp:ListItem>
                            <asp:ListItem>余额支付（自动）</asp:ListItem>
                            <asp:ListItem>云网支付（自动）</asp:ListItem>
                            <asp:ListItem>网银在线（自动）</asp:ListItem>
                            <asp:ListItem>快钱支付（自动）</asp:ListItem>
                            <asp:ListItem>支付宝支付（自动）</asp:ListItem>
                            <asp:ListItem>京东支付（自动）</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 33%">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 58%;" align="right">
                                    注册方式:</td>
                                <td style="width: 42%;">
                                    <asp:DropDownList ID="ddlRegisterType" runat="server" Width="90%">
                                        <asp:ListItem>所有</asp:ListItem>
                                        <asp:ListItem Value="1">单机</asp:ListItem>
                                        <asp:ListItem Value="8">网络</asp:ListItem>
                                        <asp:ListItem Value="9">软件狗</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="font-size: 12px">
        <td style="width: 9%" align="right">
            软件类型</td>
        <td align="right" style="width: 12%">
            <asp:DropDownList ID="ddlSoftwareType" runat="server" Width="90%">
            </asp:DropDownList></td>
        <td style="width: 9%" align="right">
            安装类型</td>
        <td align="right" style="width: 13%">
            <asp:DropDownList ID="ddlInstallType" runat="server" Width="90%">
            </asp:DropDownList></td>
        <td style="width: 21%;">
            <table width="100%">
                <tr>
                    <td style="width: 40%; font-size: 12px;" align="right">
                        使用类型
                    </td>
                    <td style="width: 60%">
                        &nbsp;<asp:DropDownList ID="ddlUseType" runat="server">
                            <asp:ListItem Selected="True" Value=" ">所有</asp:ListItem>
                            <asp:ListItem Value="1">购买</asp:ListItem>
                            <asp:ListItem Value="2">免费</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </td>
        <td align="right" style="width: 8%">
            认证码类型</td>
        <td style="width: 13%">
            <asp:DropDownList ID="ddlRegType" runat="server" Width="90%">
                <asp:ListItem>所有</asp:ListItem>
                <asp:ListItem Value="1">单机</asp:ListItem>
                <asp:ListItem Value="8">网络</asp:ListItem>
                <asp:ListItem Value="9">软件狗</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="2" style="width: 15%">
            <table style="width: 100%">
                <tr>
                    <td style="width: 20%" align="right">
                        状态：&nbsp;</td>
                    <td style="width: 80%">
                        &nbsp;
                        <asp:DropDownList ID="ddlTStatus" runat="server">
                            <asp:ListItem>所有</asp:ListItem>
                            <asp:ListItem Value="1">许可</asp:ListItem>
                            <asp:ListItem Value="2">废除</asp:ListItem>
                            <asp:ListItem Value="0">禁止</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="font-size: 12px">
        <td colspan="9">
            <table width="100%">
                <tr>
                    <td style="width: 10%">
                        日期段：
                    </td>
                    <td style="width: 10%">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 10%">
                                    从
                                </td>
                                <td style="width: 90%">
                                    <asp:TextBox ID="txtCreateTime1" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 10%">
                                    至
                                </td>
                                <td style="width: 90%">
                                    <asp:TextBox ID="txtCreateTime2" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%" align="right">
                        日期方式
                    </td>
                    <td style="width: 50%;">
                        <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">最近登录日期</asp:ListItem>
                            <asp:ListItem Value="2">第一次登陆日期</asp:ListItem>
                            <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 10%">
                        <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
