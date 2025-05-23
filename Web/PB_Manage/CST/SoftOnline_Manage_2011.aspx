<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftOnline_Manage_2011.aspx.cs"
    EnableEventValidation="false" Inherits="Pbzx.Web.PB_Manage.SoftOnline_Manage_2011" %>

<%@ Register Src="../Controls/UcSoftOnlineSearch2011.ascx" TagName="UcSoftOnlineSearch2011"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/UcSoftOnlineSearch.ascx" TagName="UcSoftOnlineSearch"
    TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新软件上线管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td bgcolor="F3F3F3" class="Right_bg1" >
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td width="91%" align="left">
                                    当前位置：软件上线管理</td>
                                <td width="9%" align="right">
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="3" cellpadding="3">
                            <tr>
                                <td align="CENTER" style="font-weight:normal">
                                    <a href="SoftOnline_Iterance_2011.aspx" target="_blank">用户全局ID查重</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="1" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                aligin="left" class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left" style="height: 10px;">
                        <uc2:UcSoftOnlineSearch2011 ID="UcSoftOnlineSearch2011_1" runat="server" />
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
                                <asp:TemplateField HeaderText="认证码" SortExpression="HDSN" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <%# ChkHDSN(Eval("HDSN"), Eval("RN"), Eval("Status"), Eval("HDSNType"))%>
                                        [<a title='<%#Eval("RN") %>' href='SoftOnline_Manage_2011.aspx?yuan=yes&strHDSN=<%#Eval("HDSN") %>'><font
                                            color='<%#Pbzx.Common.Method.CheckRegType(Eval("HDSN"))%>'>原</font></a>]
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件类型" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册用户" SortExpression="RN">
                                    <ItemTemplate>
                                        <%#ChkHDSType(Eval("RN"), Eval("HDSNType"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="版本号" SortExpression="Version">
                                    <ItemTemplate>
                                        <a href='SoftOnline_Manage_2011.aspx?strVersion=<%# Eval("Version") %>'>
                                            <%# Eval("Version") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作系统" SortExpression="OSName">
                                    <ItemTemplate>
                                        <a href='SoftOnline_Manage_2011.aspx?oSVersion=<%# Eval("OSName") %>'>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("OSName") %>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="登陆时间" SortExpression="LastLoginTime">
                                    <ItemTemplate>
                                        <font title='普通(紧急)消息获取时间：<%# Eval("NormalMsgTime","{0:yyyy-MM-dd HH:mm:ss}") %> &#13;网页消息获取时间：<%# Eval("WebMsgTime","{0:yyyy-MM-dd HH:mm:ss}") %> &#13;最新资讯获取时间：<%# Eval("NewsMsgTime","{0:yyyy-MM-dd HH:mm:ss}") %>'>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("LastLoginTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label></font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户全局ID">
                                    <ItemTemplate>
                                        <a href='SoftOnline_Manage_2011.aspx?GlobaID=<%# Eval("GlobalID") %>'>
                                            <%# ISGloBal(Eval("GlobalID")) %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="登录IP" SortExpression="LastLoginIP">
                                    <ItemTemplate>
                                        <%#GetIp(Eval("LastLoginIP")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="TodayCount" HeaderText="当日" SortExpression="TodayCount"
                                    ItemStyle-HorizontalAlign="left" />
                                <asp:BoundField DataField="TotalCount" HeaderText="总次数" SortExpression="TotalCount"
                                    ItemStyle-HorizontalAlign="left" />
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
                    <td style="height: 32px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" CustomInfoSectionWidth="42%" HorizontalAlign="Center" PagingButtonSpacing="1px"
                            ShowBoxThreshold="20">
                        </webdiyer:AspNetPager>
                        &nbsp;
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left" style="height: 20px">
                        <asp:Label ID="lblFZ" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
