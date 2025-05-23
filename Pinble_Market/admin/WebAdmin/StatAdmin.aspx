<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatAdmin.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.StatAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>统计销售</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="序号"></asp:TemplateField>
                <asp:TemplateField HeaderText="彩种"></asp:TemplateField>
                <asp:TemplateField HeaderText="项目条件"></asp:TemplateField>
                <asp:TemplateField HeaderText="出售价格"></asp:TemplateField>
                <asp:TemplateField></asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
