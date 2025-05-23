<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftMessage_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SoftMessage_Manage" %>

<%@ Register Src="../Controls/Uc_SoftMessage.ascx" TagName="Uc_SoftMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>软件消息管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
    <%--stylecss/admin.css--%>

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：软件消息管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="SoftMessage_Manage.aspx">软件消息管理</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加软件消息</asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                        class="MT">
                        <tr>
                            <td bgcolor="#F7FBFF" align="left">
                                <uc1:Uc_SoftMessage ID="Uc_SoftMessage1" runat="server"></uc1:Uc_SoftMessage>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                                    AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="序号" ItemStyle-Width="5%" />
                                        <asp:TemplateField HeaderText="标题" SortExpression="MsgTitle">
                                            <ItemTemplate>
                                                <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("MsgTitle"), 19*2)%>
                                            </ItemTemplate>
                                            <ItemStyle Width="30%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="等级" SortExpression="MsgLevel">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" Text='<%#Eval("MsgLevel").ToString()=="0"?"一般":"<font color=red>紧急</font>" %>'
                                                    runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="类别" SortExpression="MsgType">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("MsgType").ToString()=="0"?"HTML":"URL" %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="软件类型" SortExpression="MsgST">
                                            <ItemTemplate>
                                                <%#ChkSoftType(Eval("MsgST"), Eval("MsgIT")) %>
                                            </ItemTemplate>
                                            <ItemStyle Width="11%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布者" SortExpression="MsgSender">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("MsgSender") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布时间" SortExpression="MsgTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIP" runat="server" Text='<%#Eval("MsgTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="13%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="日访" SortExpression="LoginCount">
                                            <ItemTemplate>
                                                <%# Pbzx.Web.WebFunc.ChktLogin1(Eval("LoginCount"), Eval("LLTime"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TotalCount" HeaderText="总访" SortExpression="TotalCount">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="状态" SortExpression="MsgSend">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnAduting" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="lbtnAduting_Command"><%# Convert.ToBoolean(Eval("MsgSend")) ? "<font color=green>已发布</font>" : "<font color=red>未发布</font>"%>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <a href='SoftMessage_Editor.aspx?id=<%#Eval("ID") %>'>修改</a>&nbsp;|&nbsp;<asp:LinkButton
                                                    ID="lbtnDel" runat="server" OnClientClick="return confirm('您确定要删除吗?')" CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" />
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                    PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                                    ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                                    class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
