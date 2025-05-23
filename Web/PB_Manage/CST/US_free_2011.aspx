<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_free_2011.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_free_2011" %>

<%@ Register Src="../Controls/Uc_free_2011.ascx" TagName="Uc_free_2011" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>新免费试用管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

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
                                                当前位置：免费试用用户管理</td>
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
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr valign="top">
                    <td bgcolor="#ffffff" valign="top">
                       <uc2:Uc_free_2011 ID="Uc_free_2011_1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#F7FBFF" align="left">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:TemplateField HeaderText="全局ID" SortExpression="GlobalID">
                                    <ItemTemplate>
                                        <a href="US_free_2011.aspx?GlobalID=<%#Eval("GlobalID") %>">
                                            <%# Eval("GlobalID")%>
                                            [<a href='SoftOnline_Manage_2011.aspx?GlobaID=<%# DataBinder.Eval(Container.DataItem,"GlobalID") %>'
                                                target="_blank"><font color='<%# DataBinder.Eval(Container.DataItem,"GlobalID")%>'>
                                                    <font color='blue'>线</font></font></a>] </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="17%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="认证码" SortExpression="HDSN">
                                    <ItemTemplate>
                                        <%#Eval("HDSN")%>
                                        [<a href='SoftOnline_Manage_2011.aspx?yuan=yes&strHDSN=<%# DataBinder.Eval(Container.DataItem,"HDSN") %>'
                                            target="_blank"><font color='<%#Pbzx.Common.Method.CheckRegType(DataBinder.Eval(Container.DataItem,"HDSN"))%>'>
                                                <font color='blue'>线</font></font></a>]
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <a href="US_free_2011.aspx?softwareType=<%#Eval("SoftwareType") %>" class="wuxia">
                                            <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="第一次登录" SortExpression="FirstLoginTime" DataField="FirstLoginTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="最近一次登录" SortExpression="LastLoginTime" DataField="LastLoginTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="状态" SortExpression="Status">
                                    <ItemTemplate>
                                        <%# GetStatus(Eval("Status"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IP地址" SortExpression="LastLoginIP">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>">
                                            <div title='IP地址:<%#DataBinder.Eval(Container.DataItem,"LastLoginIP")%>&#13;'>
                                                <a href="US_free_2011.aspx?strLastLoginIP=<%#Eval("LastLoginIP") %>">
                                                    <%# GetIpName(Eval("LastLoginIP"))%>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="次数" SortExpression="UseCount" DataField="UseCount">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 31px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="25%"
                            CustomInfoTextAlign="Center">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
