<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Pinble_Challenge.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
    你的代理IP是：<asp:Label ID="lbl_daili" runat="server" Text=""/><br/><br/>
    你的真实IP是：<asp:Label ID="lbl_zhenshi" runat="server" Text=""/><br/><br/>
    电脑名称是：<asp:Label ID="lbl_pcname" runat="server" Text=""/><br/><br/>
    
        <asp:Button ID="btn_caozuo" runat="server" Text="操作看看" OnClick="btn_caozuo_Click" />
    </div>
    </div>
    </form>
</body>
</html>
