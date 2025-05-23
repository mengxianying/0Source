<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_free.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_free"
    EnableEventValidation="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_free.ascx" TagName="Uc_free" TagPrefix="uc1" %>
<html>
<head runat="server">
    <title>免费试用用户管理</title>
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
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#ffffff">
                        <uc1:Uc_free ID="Uc_free1" runat="server"></uc1:Uc_free>
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
                                <asp:TemplateField HeaderText="认证码" SortExpression="HDSN">
                                    <ItemTemplate>
                                        <%#Eval("HDSN")%>
                                        [<a href='US_free.aspx?yuan=yes&strHDSN=<%#Eval("HDSN") %>' class="wuxia"><font color='<%#Pbzx.Common.Method.CheckRegType(Eval("HDSN"))%>'>原</font></a>][<a
                                            href='SoftOnline_Manage.aspx?yuan=yes&strHDSN=<%# DataBinder.Eval(Container.DataItem,"HDSN") %>'
                                            target="_blank"><font color='<%#Pbzx.Common.Method.CheckRegType(DataBinder.Eval(Container.DataItem,"HDSN"))%>'>
                                                <font color='blue'>线</font></font></a>]
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C盘卷标" SortExpression="DiskCVol">
                                    <ItemTemplate>
                                        <a href="US_free.aspx?strVersion=<%#Eval("DiskCVol") %>">
                                            <%# Eval("DiskCVol")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <a href="US_free.aspx?softwareType=<%#Eval("SoftwareType") %>" class="wuxia">
                                            <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="第一次登录" SortExpression="FirstLoginTime" DataField="FirstLoginTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="center" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="最近一次登录" SortExpression="LastLoginTime" DataField="LastLoginTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="center" Width="13%" />
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
                                                <a href="US_free.aspx?strLastLoginIP=<%#Eval("LastLoginIP") %>">
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
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
