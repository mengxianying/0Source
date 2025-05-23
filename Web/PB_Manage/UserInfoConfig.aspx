<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserInfoConfig.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.UserInfoConfig" %>

<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站用户信息配置</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%">
                <tr>
                    <td align="right">
                        密码提示问题：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPassWordQuestion" runat="server" TextMode="MultiLine" Width="260px"
                            Height="90px"></asp:TextBox>
                    </td>
                    <td align="right">
                        银行选择配置：</td>
                    <td align="left">
                        <asp:TextBox ID="txtBanks" runat="server" Width="260px" Height="90px" TextMode="MultiLine"></asp:TextBox></td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        个人注册协议：</td>
                    <td colspan="3" align="left">
                        <DNTB:WebEditor ID="wePersonRegeditAgreement" runat="server" Height="280px" Width="90%">
                        </DNTB:WebEditor>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        高级用户注册协议：</td>
                    <td colspan="3" align="left">
                        <DNTB:WebEditor ID="wePersonRegeditAgreementGao" runat="server" Height="280px" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        经纪人注册协议：</td>
                    <td colspan="3" align="left">
                        <DNTB:WebEditor ID="weBrokerAgreement" runat="server" Height="280px" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        代理注册协议：</td>
                    <td colspan="3" align="left">
                        <DNTB:WebEditor ID="weAgentAgreement" runat="server" Height="280px" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left" colspan="3">
                        <asp:Button ID="btmUserConfig" runat="server" OnClick="btmUserConfig_Click" Text="保存修改" />
                        &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
