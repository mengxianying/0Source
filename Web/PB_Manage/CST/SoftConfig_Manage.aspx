<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoftConfig_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftConfig_Manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>软件配置管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>
    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>
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
                                            当前位置：软件配置管理
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
                                <a href="SoftConfig_Manage.aspx">软件配置管理</a> |&nbsp;
                                <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加软件配置</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--          <table width="796" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427" aligin="left"
                class="MT">
                <tr>
                    <td bgcolor="#ffffff">
                      <uc1:UcSoftOnlineSearch ID="UcSoftOnlineSearch2" runat="server"></uc1:UcSoftOnlineSearch>
                        查找控件
                    </td>
                </tr>
            </table>--%>
        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr bgcolor="#ffffff">
                <td>
                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="CstID,CstName"
                        CssClass="GridView_Table" AllowSorting="True" OnSorting="MyGridView_Sorting"
                        OnRowDeleting="MyGridView_RowDeleting" OnRowDataBound="MyGridView_RowDataBound">
                        <FooterStyle CssClass="GridView_Footer" />
                        <Columns>
                            <asp:BoundField DataField="CstID" HeaderText="序号" ItemStyle-Width="5%" />
                            <asp:TemplateField HeaderText="软件名" SortExpression="CstName">
                                <ItemTemplate>
                                    <%#Eval("CstName")%>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="软件类型" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <a href='SoftConfig_Manage.aspx?softwareType= <%#Eval("SoftwareType")%>'>
                                            <%#Eval("SoftwareType")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="软件类型名" SortExpression="SoftwareName">
                                <ItemTemplate>
                                    <font color='<%#Eval("SoftwareNameColor")%>'>
                                        <%#Eval("SoftwareName")%>
                                    </font>
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="安装类型" SortExpression="InstallType">
                                    <ItemTemplate>
                                        <a href='SoftConfig_Manage.aspx?installType= <%#Eval("InstallType")%>'>
                                            <%#Eval("InstallType")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="安装类型名" SortExpression="InstallName">
                                <ItemTemplate>
                                    <font color='<%#Eval("InstallNameColor")%>'>
                                        <%#Eval("InstallName")%>
                                    </font>
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CstID" SortExpression="InstallName">
                                <ItemTemplate>
                                    <%#Eval("CstID")%>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ST" SortExpression="InstallName">
                                <ItemTemplate>
                                    <font color='<%#Eval("InstallNameColor")%>'>
                                        <%#Eval("SoftwareType")%>
                                    </font>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IT" SortExpression="InstallName">
                                <ItemTemplate>
                                    <font color='<%#Eval("InstallNameColor")%>'>
                                        <%#Eval("InstallType")%>
                                    </font>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="年费用" SortExpression="YearMoney">
                                <ItemTemplate>
                                    <%#Eval("YearMoney").ToString() == "0" ? "---" : Eval("YearMoney")+"元"%>
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="终身费用" SortExpression="LifeMoney">
                                <ItemTemplate>
                                    <%#Eval("LifeMoney").ToString() == "0" ? "---" : Eval("LifeMoney")+"元"%>
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否对外" SortExpression="InstallName">
                                <ItemTemplate>
                                    <%# Eval("Flag").ToString() == "1" ? "正常" : "内部使用" %>
                                </ItemTemplate>
                                <ItemStyle Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="版本名称" SortExpression="InstallName">
                                <ItemTemplate>
                                    <%# Eval("VersionTypeName")%>
                                </ItemTemplate>
                                <ItemStyle Width="6%" />
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="编辑">
                                <ItemTemplate>
                                    <a href='SoftConfig_Editor.aspx?ID=<%#Eval("CstID") %>'>编辑</a>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>--%>
                            <%--  <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt;">
                                <ItemStyle Width="6%" />
                            </asp:CommandField>--%>
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
        <table cellpadding="2" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                        ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
