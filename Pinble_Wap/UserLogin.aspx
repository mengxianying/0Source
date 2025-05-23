<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Codebehind="UserLogin.aspx.cs" Inherits="Pinble_Wap.UserLogin" %>

<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.1//EN" " http://www.openmobilealliance.org/tech/DTD/xhtml-mobile11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理登录</title>
        <style type="text/css">
body,td,th {
	font-size: 12px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <table border="0" style="width: 100%; text-align: center; height: 98px;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2" style="height: 30px">
                        <strong>
                        拼搏后台管理中心</strong></td>
                </tr>
                <tr>
                    <td style="height: 24px; width: 40%;" align="right" >
                        用户名:
                    </td>
                    <td style="height: 24px; width:60%;" align="left">
                        &nbsp;
                        <asp:TextBox ID="TxtUserLogin" runat="server" Width="120px" MaxLength="20" Height="15px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td align="right" style="width: 40%;">
                        密 码:
                    </td>
                    <td align="left" style="width: 60%;">
                        &nbsp;
                        <asp:TextBox ID="Txtpassword" runat="server" Width="120px" MaxLength="20" TextMode="Password" Height="15px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 7px">
                        <asp:Label ID="labpassword" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 50px" > 
                        <asp:Button ID="BtnOk" runat="server" Text="登录" Width="65px" Height="22px" OnClick="BtnOk_Click" />
                        &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="linbutResetKJ" runat="server" OnClick="linbutResetKJ_Click">回开奖信息页</asp:LinkButton>&nbsp;
                    </td>
                   
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
