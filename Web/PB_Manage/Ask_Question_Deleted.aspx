<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_Question_Deleted.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_Question_Deleted" %>
    <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>问题回收站管理 - 拼搏吧</title>

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
                                                当前位置：问题回收站管理
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
                                    <a href="Ask_Question.aspx">问题管理信息</a> | <a href="Ask_Question_Deleted.aspx">问题回收站管理</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
           
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            AllowPaging="True" PageSize="20" AllowSorting="True" CssClass="GridView_Table"
                            DataKeyNames="Id" Width="100%" OnRowDataBound="MyGridView_RowDataBound" OnSorting="MyGridView_Sorting">
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
                                    <ItemStyle Width="4%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="序号">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="问题标题" SortExpression="Title">
                                    <ItemTemplate>
                                        &nbsp;<%#Pbzx.Common.StrFormat.CutStringByNum(Eval("Title"),34*2)%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="分类" SortExpression="TypeName">
                                    <ItemTemplate>
                                        <%# Eval("TypeName") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="赏分" SortExpression="LargessPoint">
                                    <ItemTemplate>
                                        <%# Eval("LargessPoint")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="State">
                                    <ItemTemplate>
                                        <%#GetState(Eval("State")) %>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="提问者" SortExpression="Asker">
                                    <ItemTemplate>
                                        <%# Eval("Asker") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="11%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="查看数" SortExpression="Views">
                                    <ItemTemplate>
                                        <%# Eval("Views") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="7%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="提问时间" SortExpression="AskTime">
                                    <ItemTemplate>
                                        <%# Eval("AskTime", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="结束时间" SortExpression="OverTime">
                                    <ItemTemplate>
                                        <%# Eval("OverTime", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDel" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗?')"
                                            runat="server" OnCommand="lbtnDel_Command">彻底删除</asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="lbtnPb_Elite" CommandArgument='<%# Eval("Id") %>' runat="server"
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
                                    &nbsp;<asp:Button ID="btnManySH" runat="server" Text="还原选中问题" OnClientClick="return CheckBatchUpdate('还原')"
                                        OnClick="btnManySH_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btnGD" runat="server" Text="还原所有问题" OnClientClick="return CheckBatchUpdate('还原所有')"
                                        OnClick="btnGD_Click" />
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnTJ" runat="server" Text="彻底删除选中问题" OnClientClick="return CheckBatchUpdate('彻底删除')"
                                        OnClick="btnTJ_Click" />&nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnNotIndex" runat="server" Text="清空回收站" OnClientClick="return CheckBatchUpdate('清空')"
                                        OnClick="btnNotIndex_Click" />&nbsp;
                                </td>
                                <td>
                                </td>
                                <td style="width: 15px;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <span style="color: Black">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label></span></td>
                    <td>
                        <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" firstpagetext="首页"
                            lastpagetext="尾页" nextpagetext="下页" numericbuttoncount="3" onpagechanged="AspNetPager1_PageChanged"
                            prevpagetext="上页" showcustominfosection="Right" showinputbox="Always" shownavigationtooltip="True"
                            custominfostyle='vertical-align:middle;' width="100%" backcolor="Transparent"
                            cssclass="pagestyle" enabletheming="True" horizontalalign="Center" custominfosectionwidth="30%"
                            custominfotextalign="Center">
                        </webdiyer:aspnetpager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
