<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_log.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_log"
    EnableEventValidation="false" %>

<%@ Register Src="../Controls/UcLog_kuais.ascx" TagName="UcLog_kuais" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_log.ascx" TagName="Uc_log" TagPrefix="uc1" %>
<html>
<head runat="server">
    <title>用户日志管理</title>

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
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
                                                当前位置：用户日志管理</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--                      <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER">
                                    <a href="SoftMessage_Manage.aspx">软件消息管理</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加软件消息</asp:LinkButton></td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#E7A427"
                aligin="left" class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc2:UcLog_kuais ID="UcLog_kuais1" runat="server"></uc2:UcLog_kuais>
                        <br />
                        <uc1:Uc_log ID="Uc_log1" runat="server"></uc1:Uc_log>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="20" BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:TemplateField HeaderText="用户名" SortExpression="Username">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>">
                                            <div title='用户索引:<%#DataBinder.Eval(Container.DataItem,"UserIndex")%>&#13;使用值:<%#DataBinder.Eval(Container.DataItem,"UseValue")%>&#13;使用类型:<%#GetUtype(DataBinder.Eval(Container.DataItem,"UseType"))%>&#13;'>
                                                &nbsp;<a href="US_log.aspx?strName=<%# Server.UrlEncode(Eval("username").ToString()) %>">
                                                    <%#Pbzx.Common.Method.GetNameSe(Eval("username"),Eval("UseType"))%>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="9%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <a href="US_log.aspx?softwareType=<%#Eval("SoftwareType") %> &installType=<%#Eval("InstallType") %>"
                                            class="wuxia">
                                            <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="版本" SortExpression="ProgramVer">
                                    <ItemTemplate>
                                        <a href="US_log.aspx?strVersion=<%#Eval("ProgramVer") %>" class="wuxia">
                                            <%# Eval("ProgramVer")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="认证码" SortExpression="HDSN">
                                    <ItemTemplate>
                                        <div>
                                            <div title='注册码:<%#DataBinder.Eval(Container.DataItem,"RN")%>&#13;'>
                                                <%# CKHDNS(Eval("HDSN")) %>
                                                <%-- <a href='US_log.aspx?strHDSN=<%#Eval("HDSN") %>' class="wuxia">
                                                    <%#Eval("HDSN") %>
                                                </a>[<a href='US_log.aspx?yuan=yes&strHDSN=<%#Eval("HDSN") %>' class="wuxia"><font
                                                    color='<%#Pbzx.Common.Method.CheckRegType(Eval("HDSN"))%>'>原</font></a>]--%>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="17%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IP地址" SortExpression="ip">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>">
                                            <div title='IP地址:<%#DataBinder.Eval(Container.DataItem,"IP")%>&#13;端口号:<%#DataBinder.Eval(Container.DataItem,"Port")%>&#13;'>
                                                <a href="US_log.aspx?strIP=<%#Eval("IP") %>" class="wuxia">
                                                    <%# GetIpName(Eval("IP"))%>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="19%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="登录时间" SortExpression="StartTime" DataField="StartTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndTime" HeaderText="退出时间" SortExpression="EndTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="状态" SortExpression="Status">
                                    <ItemTemplate>
                                        <a href="US_log.aspx?strStatus=<%#Eval("Status") %>">
                                            <%#GetStatus(Eval("Status"))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
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
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="10"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
