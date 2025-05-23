<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftOnline_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SoftOnline_Manage" EnableEventValidation="false" %>

<%@ Register Src="../Controls/UcSoftOnlineSearch.ascx" TagName="UcSoftOnlineSearch"
    TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>软件上线管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td width="91%" align="left">
                                   当前位置：软件上线管理</td>
                                <td width="9%" align="right">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                aligin="left" class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcSoftOnlineSearch ID="UcSoftOnlineSearch2" runat="server"></uc1:UcSoftOnlineSearch>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                            AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowCreated="MyGridView_RowCreated"
                            OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:TemplateField HeaderText="认证码" SortExpression="HDSN">
                                    <ItemTemplate>
                                        <%# ChkHDSN(Eval("HDSN"), Eval("RN"), Eval("Status"))%>
                                        [<a href='SoftOnline_Manage.aspx?yuan=yes&strHDSN=<%#Eval("HDSN") %>'><font color='<%#Pbzx.Common.Method.CheckRegType(Eval("HDSN"))%>'>原</font></a>]
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件类型" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="版本号" SortExpression="Version">
                                    <ItemTemplate>
                                        <a href='SoftOnline_Manage.aspx?strVersion=<%# Eval("Version") %>'>
                                            <%# Eval("Version") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作系统" SortExpression="OSVersion">
                                    <ItemTemplate>
                                        <a href='SoftOnline_Manage.aspx?oSVersion=<%# Eval("OSVersion") %>'>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("OSVersion") %>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="登陆时间" SortExpression="LoginTime">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("LoginTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="登录IP" SortExpression="IP">
                                    <ItemTemplate>
                                        <%#GetIp(Eval("IP")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="LoginCount" HeaderText="当日" SortExpression="LoginCount" />
                                <asp:BoundField DataField="TotalCount" HeaderText="总次数" SortExpression="TotalCount" />
                                <asp:TemplateField HeaderText="第一次登录" SortExpression="FirstLoginTime">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstLoginTime", "{0:yyyy-MM-dd }") %>'></asp:Label>
                                    </ItemTemplate>
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
                    <td  style="height: 32px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" CustomInfoSectionWidth="42%" HorizontalAlign="Center" PagingButtonSpacing="1px"
                            ShowBoxThreshold="20">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblFZ" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
