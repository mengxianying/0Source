<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="US_usermsg.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_usermsg" %>

<html>
<head runat="server">
    <title>用户信息管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <div class="title" style="width:100%;"> 用户信息管理</div>
  <table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#CCCCCC" style="margin: 5px 0px; text-align: right;">
                  <tr class="black" bgcolor="#F1F1F1">
                      <td>  查找控件</td>
                </tr>
                <tr class="black" bgcolor="#F1F1F1">
                    <td>
<%--                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="3" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                            PageSize="20" AllowSorting="True" OnSorting="MyGridView_Sorting">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" ReadOnly="True" SortExpression="ID">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="标题" SortExpression="MsgTitle">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("MsgTitle") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="24%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="等级" SortExpression="MsgLevel">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Text='<%#Eval("MsgLevel").ToString()=="0"?"一般":"紧急" %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类别" SortExpression="MsgType">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MsgType").ToString()=="0"?"HTML":"URL" %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="7%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件类型" SortExpression="MsgST">
                                    <ItemTemplate>
                                          <%#ChkSoftType(Eval("MsgST"), Eval("MsgIT")) %>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发布者" SortExpression="MsgSender">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("MsgSender") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发布时间" SortExpression="MsgTime">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIP" runat="server" Text='<%#Eval("MsgTime") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="LoginCount" HeaderText="日访" SortExpression="LoginCount">
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalCount" HeaderText="总访" SortExpression="TotalCount">
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="状态" SortExpression="MsgSend">
                                    <ItemTemplate>
                                        <%# Eval("MsgSend").ToString() == "0" ? "<font color=green>发布</font>" : "<font color=red>不发布</font>" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href='SoftMessage_Editor.aspx?ID=<%#Eval("ID") %>'>修改</a>|<asp:LinkButton ID="lbtnDel" runat="server"
                                            OnClientClick="return confirm('您确定要删除吗?')" CommandArgument='<%# Eval("ID") %>'
                                            OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        </asp:GridView>--%>
                    </td>
                </tr>
                <tr class="black" bgcolor="#F1F1F1">
                    <td class="GridView_Footer">
  <%--                      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页;" LastPageText="最后一页;" NextPageText="下一页;" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页;" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="White">
                        </webdiyer:AspNetPager>--%>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
