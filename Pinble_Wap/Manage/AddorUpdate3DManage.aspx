<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddorUpdate3DManage.aspx.cs"
    Inherits="Pinble_Wap.Manage.AddorUpdate3DManage" %>
<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.1//EN" " http://www.openmobilealliance.org/tech/DTD/xhtml-mobile11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加修改页面</title>
    <style type="text/css">
body,td,th {
	font-size: 12px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table bgcolor="#ced7f7" cellpadding="2" cellspacing="1" width="100%">
                <tr bgcolor="#f2f8fb">
                    <td class="bold" width="25%">
                        开奖期号:
                    </td>
                    <td width="75%">
                        <asp:TextBox ID="txtIssue" runat="server" Width="55px" Height="15px" MaxLength="10"></asp:TextBox>
                        （格式：2004101）</td>
                </tr>
                <tr bgcolor="#f2f8fb">
                    <td class="bold">
                        开奖日期:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" Width="100px" Height="15px"></asp:TextBox>
                        （格式：2004-6-4）</td>
                </tr>
                <tr bgcolor="#f2f8fb" runat="server" visible="false">
                    <td class="bold" style="height: 26px">
                        机球号:
                    </td>
                    <td style="height: 26px">
                        <asp:RadioButtonList ID="rblMachineAndBall" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1-1">1机1球</asp:ListItem>
                            <asp:ListItem Value="1-2">1机2球</asp:ListItem>
                            <asp:ListItem Value="2-1">2机1球</asp:ListItem>
                            <asp:ListItem Value="2-2">2机2球</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr bgcolor="#f2f8fb">
                    <td class="bold" style="height: 26px">
                        试机号:</td>
                    <td style="height: 26px">
                        <asp:TextBox ID="txtTestcode" runat="server" MaxLength="3" Width="55px" Height="15px"></asp:TextBox>（格式：123）</td>
                </tr>
                <tr bgcolor="#f2f8fb">
                    <td class="bold">
                        &nbsp;开奖号码:</td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" MaxLength="3" Width="55px" Height="15px"></asp:TextBox>（格式：123）</td>
                </tr>
                <tr bgcolor="#f2f8fb">
                    <td colspan="2">
                        &nbsp; &nbsp;
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="添加" Height="20px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="返回" Height="20px" />
                        <br />
                       <asp:Label ID="labMessage" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
