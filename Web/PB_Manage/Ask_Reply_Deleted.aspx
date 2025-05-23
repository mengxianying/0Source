<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_Reply_Deleted.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_Reply_Deleted" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>问题回复信息回收站 - 拼搏吧</title>

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
                                                当前位置：回复信息回收站
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
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowSorting="True" BorderStyle="Solid"
                            AllowPaging="True" PageSize="20" CellPadding="0" Width="100%" CssClass="GridView_Table"
                            DataKeyNames="ID" AutoGenerateColumns="False" OnRowDataBound="MyGridView_RowDataBound"
                            OnSorting="MyGridView_Sorting">
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
                                        <%#Eval("Replyer")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回复内容" SortExpression="Content">
                                    <ItemTemplate>
                                        <div title='回复问题:<%#GetTitle(Eval("QuestionId"))%>'>
                                            &nbsp;<%# Pbzx.Common.StrFormat.CutStringByNum(Eval("Content"),35*2,"...") %>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="50%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最佳" SortExpression="IsBest">
                                    <ItemTemplate>
                                        <%#Convert.ToBoolean(Eval("IsBest")) ? "<font color='red'>是</font>" : "<font color='blue'>否</font>"%>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回复时间" SortExpression="ReplyTime">
                                    <ItemTemplate>
                                        <%#Eval("ReplyTime", "{0:yyyy-MM-dd}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                            runat="server" OnCommand="lbtnDel_Command">彻底删除</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="lbtnPb_Elite" CommandArgument='<%# Eval("ID") %>' runat="server"
                                            OnCommand="lbtnPb_Elite_Command">还原</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="18%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <table cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <b>数据批量操作：</b></td>
                                <td>
                                    <asp:Button ID="btnDelete" runat="server" Text="彻底删除选中回复" OnClientClick="return CheckBatchUpdate('彻底删除')"
                                        OnClick="btnDelete_Click" />
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnManySH" runat="server" Text="还原选中回复" OnClientClick="return CheckBatchUpdate('还原')"
                                        OnClick="btnManySH_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnGD" runat="server" Text="还原所有回复" OnClientClick="return CheckBatchUpdate('还原所有')"
                                        OnClick="btnGD_Click" />
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnNotIndex" runat="server" Text="清空回收站" OnClientClick="return CheckBatchUpdate('清空')"
                                        OnClick="btnNotIndex_Click" />&nbsp;
                                </td>
                                <td style="width: 5px;">
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
