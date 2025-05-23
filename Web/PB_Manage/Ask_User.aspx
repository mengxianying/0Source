<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_User.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ask_User" %>

<%@ Register Src="Controls/UcAsk_User.ascx" TagName="UcAsk_User" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>用户管理 - 拼搏吧</title>

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
                                                当前位置：拼搏吧用户管理
                                            </td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
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
                        <uc1:UcAsk_User ID="UcAsk_User1" runat="server"></uc1:UcAsk_User>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowSorting="True" BorderStyle="Solid"
                            AllowPaging="True" CellPadding="0" Width="100%" CssClass="GridView_Table" DataKeyNames="ID,UserName"
                            AutoGenerateColumns="False" OnRowDataBound="MyGridView_RowDataBound" OnRowDeleting="MyGridView_RowDeleting"
                            OnSorting="MyGridView_Sorting">
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                    <ItemTemplate>
                                        <%#Eval("UserName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="头衔" SortExpression="Title">
                                    <ItemTemplate>
                                        <%#Eval("Title")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="问题数" SortExpression="AskNum">
                                    <ItemTemplate>
                                        <%#Eval("AskNum")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回答数" SortExpression="ReplyNum">
                                    <ItemTemplate>
                                        <%#Eval("ReplyNum")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="State">
                                    <ItemTemplate>
                                        <%#GetState(Eval("State"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总分数" SortExpression=" Score-Pointpenalty-otherPointpenalty ">
                                    <ItemTemplate>
                                        <%# Convert.ToInt32(Eval("Score")) - Convert.ToInt32(Eval("Pointpenalty")) - Convert.ToInt32(Eval("otherPointpenalty")) %>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户头衔" SortExpression=" Score-Pointpenalty-otherPointpenalty ">
                                    <ItemTemplate>
                                        <%#  Pbzx.Common.Method.GetUserTitle(Convert.ToString(Convert.ToInt32(Eval("Score")) - Convert.ToInt32(Eval("Pointpenalty")) - Convert.ToInt32(Eval("otherPointpenalty"))))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开通时间" SortExpression="OpenTime">
                                    <ItemTemplate>
                                        <%#Eval("OpenTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="11%" />
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="删除" InsertVisible="False" ShowCancelButton="False"
                                    ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;">
                                    <ItemStyle Width="5%" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
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
