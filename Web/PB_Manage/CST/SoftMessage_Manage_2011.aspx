<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftMessage_Manage_2011.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SoftMessage_Manage_2011" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/Uc_SoftMessage_2011.ascx" TagName="Uc_SoftMessage_2011"
    TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <%-- <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title>软件消息管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
    <%--stylecss/admin.css--%>

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true " runat="server"
            EnableScriptGlobalization="true ">
        </asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1" style="width: 788px">
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
                                    <a href="SoftMessage_XML_2011.aspx">软件消息XML管理</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加软件消息</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#e7a427"
                        class="MT">
                        <tr>
                            <td bgcolor="#f7fbff" align="left" style="width: 819px">
                                <uc1:Uc_SoftMessage_2011 ID="Uc_SoftMessage_2011_1" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694d2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                                    AllowSorting="True" OnRowDataBound="MyGridView_RowDataBound" OnRowCommand="MyGridView_RowCommand"
                                    OnSorting="MyGridView_Sorting">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="序号">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="标题" SortExpression="Title">
                                            <ItemTemplate>
                                                <a href='<%# Eval("ContentURL") %>' target="_blank" title='发布者：<%# Pbzx.Common.StrFormat.CutStringByNum(Eval("Sender"), 19 * 2)%>  类别：<%# LeibieGSH(Eval("Content")) %>'>
                                                    <%# TitleFmt(Pbzx.Common.StrFormat.CutStringByNum(Eval("Title"), 16 * 2), Eval("BeginTime"), Eval("endTime"), Eval("State"))%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="消息类型" SortExpression="Type">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# MsgGSH(Eval("Type")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发布时间" SortExpression="PostTime">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("PostTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="日访" SortExpression="TodayCount">
                                            <ItemTemplate>
                                                <%# JrfwGSH(Eval("TodayCount")) %>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="总访" SortExpression="TotalCount">
                                            <ItemTemplate>
                                                <%# JrfwGSH(Eval("TotalCount"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态" SortExpression="State">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkstatus" runat="server" Text='<%# StatusGSF(Eval("State")) %>'
                                                    CommandArgument='<%# Eval("Id") %>' CommandName="Upda"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="软件限定">
                                            <ItemTemplate>
                                                <%# RJGSH_01(Eval("Id"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="注册限定">
                                            <ItemTemplate>
                                                <%# ZCGSH(Eval("RegType"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户限定">
                                            <ItemTemplate>
                                                <%# YHGSH(Eval("UserClass"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="lbtnDel_Command">删除</asp:LinkButton>
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="确定要删除此软件消息吗！"
                                                    TargetControlID="LinkButton1">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <ItemStyle Width="2%" HorizontalAlign="Left" />
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
                            <td style="height: 48px">
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
