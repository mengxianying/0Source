<%@ Page Language="C#" AutoEventWireup="true" Codebehind="OrderDetails_Edite.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.OrderDetails_Edite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head runat="server">
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
                        &nbsp;产品订单信息查看
                    </td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" width="25%" height="28">
                        软件狗编号：
                    </td>
                    <td align="left" width="75%">
                        <asp:TextBox ID="txtSoftDogID" runat="server" MaxLength="9"></asp:TextBox>
                        <span style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSoftDogID"
                            ErrorMessage="软件狗编号不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" height="28">
                        快递公司：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKDGS" runat="server">
                        </asp:DropDownList><span style="color: #ff0000">*</span>
                    </td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td class="bold" height="28">
                        快递单号：</td>
                    <td>
                        <asp:TextBox ID="txtKDDH" runat="server" Width="200px" MaxLength="27"></asp:TextBox><span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKDDH"
                            ErrorMessage="快递单号不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td colspan="2" align="center" height="28">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" Width="50px" />&nbsp;
                        <input type="button" value="返回" onclick="history.back(-1)" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
