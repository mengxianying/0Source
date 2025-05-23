<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regset.aspx.cs" Inherits="Pinble_Wap.Regset" %>

<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.1//EN" " http://www.openmobilealliance.org/tech/DTD/xhtml-mobile11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>返回页面</title>
            <style type="text/css">
body,td,th {
	font-size: 12px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="labtext" runat="server"></asp:Label><br />
        请点击返回列表页
        <asp:LinkButton ID="lnkbut" runat="server" OnClick="lnkbut_Click">返回</asp:LinkButton></div>
    </form>
</body>
</html>
