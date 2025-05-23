<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ask_Question.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ask_Question" %>

<%@ Register Src="Controls/UcAsk_Question.ascx" TagName="UcAsk_Question" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>问题管理 - 拼搏吧</title>
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
    <link href="stylecss/css.css" rel="stylesheet" type="text/css" />
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
                                            当前位置：问题管理信息
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
                                <a href="Ask_Question.aspx">问题管理信息</a> | <a href="Ask_Question_Deleted.aspx">问题管理回收站</a> |  <asp:LinkButton ID="linkbtn_geng" runat="server" onclick="linkbtn_geng_Click">生成首页拼搏吧信息</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
            class="MT">
            <tr>
                <td bgcolor="#F7FBFF" align="left">
                    <uc1:UcAsk_Question ID="UcAsk_Question1" runat="server"></uc1:UcAsk_Question>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    class="MT">
                    <tr bgcolor="#ffffff">
                        <td>
                            <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                AllowPaging="True" AllowSorting="True" CssClass="GridView_Table" DataKeyNames="Id"
                                Width="100%" OnRowDataBound="MyGridView_RowDataBound" OnSorting="MyGridView_Sorting">
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
                                    <asp:BoundField DataField="Id" HeaderText="序号">
                                        <ItemStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="问题标题" SortExpression="Title">
                                        <ItemTemplate>
                                            <%#Pbzx.Common.StrFormat.CutStringByNum(Eval("Title"),30*2)%>
                                            <font color="#666666">[</font><a href='Ask_Reply.aspx?ID=<%# Eval("Id") %>'><font
                                                color="#4070FD">查看</font></a><font color="#666666">]</font>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="分类" SortExpression="TypeName">
                                        <ItemTemplate>
                                            <a href="Ask_Question.aspx?TypeName=<%# Eval("TypeID") %>">
                                                <%# Eval("TypeName") %>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="12%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="赏分" SortExpression="LargessPoint">
                                        <ItemTemplate>
                                            <%# Eval("LargessPoint")%>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="精华">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnIsCommend" CommandArgument='<%# Eval("Id") %>' runat="server"
                                                OnCommand="lbtnIsCommend_Command"><%# Convert.ToBoolean(Eval("IsCommend")) ? "<font color='blue'>精</font>" : "<font color='black'>否</font>"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="审核" SortExpression="Auditing">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtsh" CommandArgument='<%# Eval("Id") %>' runat="server"
                                                OnCommand="lbtsh_Command"><%# Convert.ToBoolean(Eval("Auditing")) ? "<font color='blue'>已通过</font>" : "<font color='black'>未通过</font>"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态" SortExpression="State">
                                        <ItemTemplate>
                                            <%#GetState(Eval("State")) %>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="提问者" SortExpression="Asker">
                                        <ItemTemplate>
                                            <a href="Ask_Question.aspx?strAsker=<%# Eval("Asker") %>">
                                                <%# Eval("Asker") %>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <%--                                <asp:TemplateField HeaderText="精华">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnIsHot" CommandArgument='<%# Eval("Id") %>' runat="server"
                                            OnCommand="lbtnIsHot_Command"><%# Convert.ToBoolean(Eval("BitIsHot")) ? "<font color='blue'>精华</font>" : "<font color='black'>不精</font>"%></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="4%" />
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="点击" SortExpression="Views">
                                        <ItemTemplate>
                                            <%# Eval("Views") %>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="提问时间" SortExpression="AskTime">
                                        <ItemTemplate>
                                            <%# Eval("AskTime", "{0:yyyy-MM-dd HH:mm}")%>
                                        </ItemTemplate>
                                        <ItemStyle Width="13%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="结束时间" SortExpression="OverTime">
                                        <ItemTemplate>
                                            <%# Eval("OverTime", "{0:yyyy-MM-dd HH:mm}")%>
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
                                        <b>数据批量操作：</b>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return CheckBatchUpdate('批量删除')"
                                            OnClick="btnDelete_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnTJ" runat="server" Text="批量加精华" OnClientClick="return CheckBatchUpdate('批量推荐')"
                                            OnClick="btnTJ_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btntuij" runat="server" Text="批量取消精华" OnClientClick="return CheckBatchUpdate('批量不推荐')"
                                            OnClick="btnNottuij_Click" />
                                    </td>
                                    <%-- <td>
                                    <asp:Button ID="btnjing" runat="server" Text="批量精华" OnClientClick="return CheckBatchUpdate('批量精华')"
                                        OnClick="btnjing_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNotjing" runat="server" Text="批量不精华" OnClientClick="return CheckBatchUpdate('批量不精华')"
                                        OnClick="btnNotjing_Click" />
                                </td>--%>
                                    <td>
                                        <asp:Button ID="btntuij0" runat="server" OnClick="btntuij0_Click" 
                                            OnClientClick="return CheckBatchUpdate('批量不推荐')" Text="批量审核通过" />
                                    </td>
                                    <td style="width: 5px;">
                                        <asp:Button ID="btntuij1" runat="server" OnClick="btntuij1_Click" 
                                            OnClientClick="return CheckBatchUpdate('批量不推荐')" Text="批量审核不通过" />
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
                                <asp:Label ID="lblTotal" runat="server"></asp:Label></span>
                        </td>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                                CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="30%"
                                CustomInfoTextAlign="Center">
                            </webdiyer:AspNetPager>
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
