<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftMessage_XML_2011.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftMessage_XML_2011" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>软件消息XML编辑</title>
    <style type="text/css"">
    body,td,th {
	font-size: 12px;
}
    </style>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1" style="width: 788px; height: 18px;">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center" style="height: 20px">
                                    <tr>
                                        <td width="91%" align="left" style="height: 20px">
                                            当前位置：软件消息配置XML管理</td>
                                        <td width="9%" align="right" style="height: 20px">
                                        </td>
                                    </tr>
                                </table>
                                </td>
                        </tr>
                    </table>
                     <strong>(<span style="color: #ff0033">此数据！非必要，请勿操作！以免造成数据混乱！</span>) </strong>
                    <br />
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 412px">
                        <tr>
                            <td style="width: 412px; height: 20px;">
                                <strong>注册限定信息列表：<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" ForeColor="Blue">添加注册限定</asp:LinkButton></strong>
                            </td>
                            <td style="width: 412px; height: 20px;">
                                <strong>消息类别：<asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click" ForeColor="Blue">添加类别限定</asp:LinkButton></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 412px; height: 154px;" valign="top">
                                <asp:GridView ID="Grvdzhuce" runat="server" AutoGenerateColumns="False" CssClass="GridView_Table"
                                    Width="369px" OnRowCommand="Grvdzhuce_RowCommand" AllowSorting="True">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:BoundField DataField="number" HeaderText="ID" SortExpression="number" />
                                        <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="Up">编辑</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="De">删除</asp:LinkButton>
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除吗！此操作可能使程序运行不正常！"
                                                    TargetControlID="LinkButton2">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" />
                                </asp:GridView>
                               </td>
                            <td style="width: 412px; height: 154px;" valign="top">
                                <asp:GridView ID="GrvdLB" runat="server" AutoGenerateColumns="False" Width="369px"
                                    OnRowCommand="GrvdLB_RowCommand" CssClass="GridView_Table">
                                    <Columns>
                                        <asp:BoundField DataField="number" HeaderText="ID" SortExpression="number" />
                                        <asp:TemplateField HeaderText="名称" SortExpression="name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <a href='SoftMessage_XML_2011.aspx?oneId=<%# Eval("number") %>'>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>'></asp:Label></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="Up">编辑</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="De">删除</asp:LinkButton>&nbsp;
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除吗！此操作可能使程序运行不正常！并且会删除对应的子项！"
                                                    TargetControlID="LinkButton4">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" HorizontalAlign="Center" />
                                </asp:GridView>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 412px; height: 14px;">
                                <strong>用户限定信息：<asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" ForeColor="Blue">添加用户限定</asp:LinkButton></strong></td>
                            <td style="width: 412px">
                                <strong>消息子类别：<asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click" ForeColor="Blue">添加子类别限定</asp:LinkButton></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 412px; height: 147px;" valign="top">
                                <asp:GridView ID="GrvdUserclass" runat="server" AutoGenerateColumns="False" Width="369px"
                                    OnRowCommand="GrvdUserclass_RowCommand" CssClass="GridView_Table">
                                    <Columns>
                                        <asp:BoundField DataField="number" HeaderText="ID" SortExpression="number" />
                                        <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="Up">编辑</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="De">删除</asp:LinkButton>&nbsp;
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除吗！此操作可能使程序运行不正常！"
                                                    TargetControlID="LinkButton4">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" HorizontalAlign="Center" />
                                </asp:GridView>
                                &nbsp;
                            </td>
                            <td rowspan="3" valign="top">
                                <asp:GridView ID="Grvdtwo" runat="server" AutoGenerateColumns="False" Width="369px"
                                    OnRowCommand="Grvdtwo_RowCommand" CssClass="GridView_Table">
                                    <Columns>
                                        <asp:BoundField DataField="number" HeaderText="ID" SortExpression="number" />
                                        <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("name") %>'
                                                    CommandName="Up">编辑</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("name") %>'
                                                    CommandName="De">删除</asp:LinkButton>&nbsp;
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除吗！此操作可能使程序运行不正常！"
                                                    TargetControlID="LinkButton4">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" HorizontalAlign="Center" />
                                </asp:GridView>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 412px; height: 5px;">
                                <strong>消息等级：<asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click" ForeColor="Blue">添加等级限定</asp:LinkButton></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 412px; height: 158px;" valign="top">
                                <asp:GridView ID="GrvdDJ" runat="server" AutoGenerateColumns="False" Width="369px"
                                    OnRowCommand="GrvdDJ_RowCommand" CssClass="GridView_Table">
                                    <Columns>
                                        <asp:BoundField DataField="number" HeaderText="ID" SortExpression="number" />
                                        <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                                        <asp:BoundField DataField="Msg_Minute" HeaderText="间隔时间" />
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="Up">编辑</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("number") %>'
                                                    CommandName="De">删除</asp:LinkButton>&nbsp;
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除吗！此操作可能使程序运行不正常！"
                                                    TargetControlID="LinkButton4">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" HorizontalAlign="Center" />
                                </asp:GridView>
                                &nbsp;
                            </td>
                        </tr>
                           <tr>
                            <td style="width: 412px; height: 5px;">
                                <strong>系统版本：<asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click" ForeColor="Blue">添加系统版本</asp:LinkButton></strong></td>
                        </tr>
                          <tr>
                            <td style="width: 412px; height: 158px;" valign="top"><asp:GridView ID="GridOS" runat="server" AutoGenerateColumns="False" Width="369px"
                                    OnRowCommand="GridOS_RowCommand" CssClass="GridView_Table">
                                <Columns>
                                    <asp:BoundField DataField="number" HeaderText="ID" SortExpression="number" />
                                    <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("number") %>'
                                                CommandName="Up">编辑</asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("number") %>'
                                                CommandName="De">删除</asp:LinkButton>&nbsp;
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除吗！此操作可能使程序运行不正常！"
                                                    TargetControlID="LinkButton4">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="GridView_Row" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <PagerStyle CssClass="GridView_Pager" />
                                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            </asp:GridView>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
