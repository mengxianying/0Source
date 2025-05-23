<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Note_Restore.aspx.cs" Inherits="Pinble_Sms.admin.Note.Note_Restore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>短信回复</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None" Width="443px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                <asp:BoundField DataField="Phone" HeaderText="手机号码" SortExpression="Phone" />
                <asp:BoundField DataField="Content" HeaderText="内容" SortExpression="Content" />
                <asp:BoundField DataField="BeginTime" HeaderText="发送时间" 
                    SortExpression="BeginTime" />
                <asp:BoundField DataField="Sp_PID" HeaderText="Sp_PID" 
                    SortExpression="Sp_PID" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
