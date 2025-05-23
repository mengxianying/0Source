<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails_EditeRG.aspx.cs" Inherits="Pbzx.Web.PB_Manage.OrderDetails_EditeRG" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head id="Head1" runat="server">
    <title>订单详细编辑_拼搏在线彩神通软件后台管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script type="text/javascript" language="javascript" src="JScript/javascript.js"></script>

    <script type="text/javascript" language="javascript">
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="97%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2" align="center">
                <tr bgcolor="#149CE6">
                    <td colspan="2" align="left" class="Right_bg1" height="16">
                        &nbsp;产品注册管理
                    </td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" style="height: 28px" width="20%">
                    </td>
                    <td align="left" style="height: 28px" width="80%">
                        <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;请先使用人工注册完成后，再填写以下信息</strong></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" width="20%" style="height: 28px">
                       软件名称：
                    </td>
                    <td align="left" width="80%" style="height: 28px">
                        &nbsp;<asp:Label ID="lblProductName" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" height="28">
                        注册方式：
                    </td>
                    <td>
                        &nbsp;<asp:Label ID="lblRegType" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" height="28">
                        售价：</td>
                    <td>
                        &nbsp;<asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" height="28">
                        处理结果：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="txtSerial" runat="server" Width="300px"></asp:TextBox><br />
                        &nbsp;网络版格式填写（直接输入处理结果）： 注册成功，到期日期：2010年04月20日<br />
                        单机注册方式（只输入认证码）：433182-264293-419423-165154<br />
                        软件狗方式【用以前软件狗】（只输入认证码）：433182-264293-419423-165154<br />
                    </td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" height="28">
                        状态：</td>
                    <td>
                        <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">未处理</asp:ListItem>
                            <asp:ListItem Value="1">处理成功</asp:ListItem>
                            <asp:ListItem Value="2">处理失败</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td colspan="2" align="center" height="28">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" Width="50px" />&nbsp;
                        <input type="button" value="返回" onclick="history.back(-1)"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
