<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LockUserIP.aspx.cs" Inherits="Pbzx.Web.PB_Manage.LockUserIP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head id="Head1" runat="server">
    <title>锁定用户IP_拼搏在线彩神通软件后台管理</title>
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
                        &nbsp;锁定用户IP
                    </td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" width="25%" height="28">
                        IP：
                    </td>
                    <td align="left" width="75%">
                        <asp:TextBox ID="txtIP" runat="server" MaxLength="25"></asp:TextBox>
                        <span style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIP"
                            ErrorMessage="IP不能为空"></asp:RequiredFieldValidator></td>
                </tr>              
                <tr bgcolor="#ffffff">
                    <td colspan="2" align="center" height="28">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="锁定" Width="50px" />&nbsp;&nbsp;&nbsp;
                        <asp:Button id="btnJie" onclick="btnJie_Click" runat="server" Width="50px" Text="解锁"></asp:Button>&nbsp;&nbsp;&nbsp;
                        <input type="button" value="关闭" onclick="window.close();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>