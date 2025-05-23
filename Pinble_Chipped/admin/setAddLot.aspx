<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setAddLot.aspx.cs" Inherits="Pinble_Chipped.admin.setAddLot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置彩种定制跟单</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="5" 
            RepeatDirection="Horizontal">
        </asp:CheckBoxList>
        <asp:Button ID="btn_add" runat="server" Text="Button" onclick="btn_add_Click" />
    </div>
    </form>
</body>
</html>
