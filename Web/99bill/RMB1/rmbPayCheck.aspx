<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pbzx.Web._99bill.RMB1.test_rmbPayCheck"
    CodeBehind="rmbPayCheck.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人民币商户查询接口</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblSubmit" runat="server"></asp:Label><br />
        <asp:Label ID="lblPayResult" runat="server"></asp:Label><br />
        <asp:Button ID="btnPayCheck" runat="server" Text="payCheck" OnClick="btnPayCheck_Click" />
    </div>
    </form>
</body>
</html>
