<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_Reply.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ask_Reply" %>

<%@ Register Src="Controls/UcAsk_Reply.ascx" TagName="UcAsk_Reply" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>回复管理 - 拼搏吧</title>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <link href="stylecss/css.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
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
                                                当前位置：问题回复管理
                                            </td>
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
                                    <a href="Ask_Reply.aspx">回复信息管理</a>&nbsp;|&nbsp;<a href="Ask_Reply_Deleted.aspx">回复信息回收站</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcAsk_Reply ID="UcAsk_Reply1" runat="server"></uc1:UcAsk_Reply>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowSorting="True" BorderStyle="Solid"
                            AllowPaging="True" CellPadding="0" Width="100%" CssClass="GridView_Table" DataKeyNames="ID"
                            AutoGenerateColumns="False" OnRowDataBound="MyGridView_RowDataBound" OnSorting="MyGridView_Sorting">
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <Columns>
                                <asp:TemplateField HeaderText="全选">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="sel" value="<%#Eval("Id") %>" /></ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="序号">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="回复者" SortExpression="Replyer">
                                    <ItemTemplate>
                                  <a href="Ask_Reply.aspx?Replyer=<%#Eval("Replyer")%>"><%#Eval("Replyer")%></a>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回复内容" SortExpression="Content">
                                    <ItemTemplate>
                                        <div title='回复问题:<%#GetTitle(Eval("QuestionId"))%>'>
                                            &nbsp;<%# Pbzx.Common.StrFormat.CutStringByNum(Eval("Content"),38*2,"...") %></div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="50%" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="最佳" SortExpression="IsBest">
                                    <ItemTemplate>
                                        <%#Convert.ToBoolean(Eval("IsBest")) ? "<font color='red'>是</font>" : "<font color='blue'>否</font>"%>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="审核" SortExpression="Auditing">
                                    <ItemTemplate>
                                                                                 <asp:LinkButton ID="lbtsh" CommandArgument='<%# Eval("Id") %>' runat="server"
                                                OnCommand="lbtsh_Command"><%# Convert.ToBoolean(Eval("Auditing")) ? "<font color='blue'>已通过</font>" : "<font color='black'>未通过</font>"%></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回复时间" SortExpression="ReplyTime">
                                    <ItemTemplate>
                                        <%#Eval("ReplyTime", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                            runat="server" OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="4%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <table cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <b>数据批量操作：</b></td>
                                <td>
                                    <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return CheckBatchUpdate('批量删除')"
                                        OnClick="btnDelete_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnsh" runat="server" Text="批量审核不通过"
                                        OnClick="btnsh_Click" />
                                </td>
                                <td width="70%">
                                    <asp:Button ID="btnsh0" runat="server" Text="批量审核通过"
                                        OnClick="btnsh0_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" NumericButtonCount="3" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="30%"
                            CustomInfoTextAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
            <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
        </div>
    </form>
</body>
</html>
