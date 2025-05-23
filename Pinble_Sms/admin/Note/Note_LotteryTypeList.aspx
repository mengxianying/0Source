<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Note_LotteryTypeList.aspx.cs"
    Inherits="Pinble_Market.admin.Note.Note_LotteryTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <title>服务后台管理</title>
    <style type="text/css">
    body,td{
	margin:0 0 0 0;
	font-size:12px;
	color:#000;
	text-align:center;
}

#mainLayM {
	overflow:auto;
	height:auto;
	margin:auto;
	width:1033px!important;width:1033px;
	border-bottom:1px solid #A5C2E4;
	border-right:1px solid #A5C2E4;
	border-left:1px solid #A5C2E4;
	border-top:1px solid #A5C2E4;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainLayM" runat="server" style="width: 1033px; height: 383px">
            <asp:Button ID="btnfw" runat="server" OnClick="btnfw_Click" Text="添加新服务" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="913px"
                OnRowCommand="GridView1_RowCommand" 
                OnRowDataBound="GridView1_RowDataBound" CellPadding="4" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="SID" HeaderText="编号" SortExpression="SID" />
                    <asp:BoundField DataField="SName" HeaderText="服务类型名称" SortExpression="SName" />
                    <asp:TemplateField HeaderText="介绍" SortExpression="Explain">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Explain") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="已订购人数">
                        <ItemTemplate>
                            <%# Ren(Eval("SID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="添加时间" SortExpression="BeginTime">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("BeginTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="信息录入状态">
                        <ItemTemplate>
                            <%# MsgStatus(Eval("SID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否公开" SortExpression="Ispublic">
                        <EditItemTemplate>
                            &nbsp;
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# ISGK(Eval("Ispublic")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="编辑">
                        <ItemTemplate>
                            &nbsp;
                            <asp:LinkButton ID="linkbutUpdate" runat="server" CommandArgument='<%# Eval("SID") %>'
                                CommandName="Up">编辑</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton ID="linkbutdelete" runat="server" CommandArgument='<%# Eval("SID") %>'
                                CommandName="De">删除</asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="linkbutXX" runat="server" CommandArgument='<%# Eval("SID") %>'
                                CommandName="xx">详细订购信息</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
            &nbsp;
        </div>
    </form>
</body>
</html>
