<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AdminLogin.aspx.cs" Inherits="Pbzx.Web.PB_Manage.AdminLogin"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拼搏在线后台管理中心</title>
    <style type="text/css">
<!--
td {
	font-family: "宋体";
	font-size: 12px;
	line-height: 170%;
	color: #0F0F0F;
}
-->
</style>

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <form action="" name="form1" method="post" onsubmit="return checkData()" onfocus="return form1_onfocus()">
                <table cellspacing="1" cellpadding="1" width="500" align="center" bgcolor="#cccccc"
                    border="0" style="margin-top: 100px;">
                    <tr bgcolor="#ffffff">
                        <td>
                            <table cellspacing="0" cellpadding="0" width="500" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <img height="129" src="images/1.jpg" width="500" /></td>
                                    </tr>
                                </tbody>
                            </table>
                            <table height="153" cellspacing="0" cellpadding="0" width="500" align="center" background="images/3.jpg"
                                border="0">
                                <tr>
                                    <td width="10">
                                    </td>
                                    <td width="158" background="images/2.jpg">
                                        &nbsp;
                                    </td>
                                    <td align="middle">
                                        <table width="100%" height="120" border="0" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    用户名：<asp:TextBox ID="txtUname" runat="server" MaxLength="12"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    密&nbsp;&nbsp;码：<asp:TextBox ID="txtUpwd" runat="server" TextMode="Password" Width="146px" MaxLength="16"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    验证码：<asp:TextBox ID="txtCode" runat="server" Width="61px" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"
                                                        MaxLength="4"></asp:TextBox>
                                                    <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" width="63"
                                                        height="23" align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" />
                                                    <img alt="正确" src="../Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                    <img alt="错误" src="../Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button1" runat="server" class="btn" Text="登录" OnClick="btnLogin_Click" />&nbsp;
                                                    <asp:Button ID="btnReset" class="btn" runat="server" Text="重填" OnClick="btnReset_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
            </form>
        </div>
    </form>
</body>
</html>
