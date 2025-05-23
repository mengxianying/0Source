<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List3DManage.aspx.cs" Inherits="Pinble_Wap.Manage.List3DManage" %>


<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.1//EN" " http://www.openmobilealliance.org/tech/DTD/xhtml-mobile11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>3D开奖列表</title>
        <style type="text/css">
body,td,th {
	font-size: 12px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        管理员：<asp:Label ID="labname" runat="server" ForeColor="Red"></asp:Label>
        您好！<br />
        <asp:LinkButton ID="lnkTJ" runat="server" OnClick="lnkTJ_Click">添加开奖信息</asp:LinkButton>
        <asp:LinkButton ID="lnkbutsx" runat="server" OnClick="lnkbutsx_Click">刷新开奖页面</asp:LinkButton> &nbsp;
        <asp:LinkButton ID="lnkbutQT" runat="server" OnClick="lnkbutQT_Click">前台预览</asp:LinkButton>&nbsp;
         &nbsp;
        <asp:LinkButton ID="lnkBtnreselt" runat="server" OnClick="lnkBtnreselt_Click">退出</asp:LinkButton>
        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
            CssClass="GridView_Table" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="开奖日期" SortExpression="date">
                    <ItemStyle Width="5%" />
                    <ItemTemplate>
                        <%# Eval("date","{0:yyyy-MM-dd}") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期号" SortExpression="issue">
                    <ItemStyle Width="5%" />
                    <ItemTemplate>
                        <%# Eval("issue") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="机球信息" SortExpression="redcode">
                    <ItemStyle Width="5%" />
                    <ItemTemplate>
                        <font color="#FF00FF">
                            <%#Eval("machine")%>
                            机<%#Eval("ball")%>球 </font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="试机号" SortExpression="code">
                    <ItemStyle Width="3%" />
                    <ItemTemplate>
                        <font color="#9933FF">
                            <%# Eval("testcode")%>
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开奖号">
                    <ItemStyle Width="3%" />
                    <ItemTemplate>
                        <font color="#0000FF">
                            <%# Eval("code")%>
                        </font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemStyle Width="3%" />
                    <ItemTemplate>
                        &nbsp;<asp:LinkButton ID="lbtnUpdate" runat="server" CommandArgument='<%# Eval("issue") %>'
                            OnClientClick="changeTab(1)" OnCommand="LinkButton1_Command">修改</asp:LinkButton>
                        &nbsp; &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="GridView_Row" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="GridView_Pager" />
            <HeaderStyle CssClass="GridView_Header" Font-Bold="True" />
            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
