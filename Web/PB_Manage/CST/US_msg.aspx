<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_msg.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_msg"
    EnableEventValidation="false" %>

<%@ Register Src="../Controls/UcMsg_kuais.ascx" TagName="UcMsg_kuais" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_msg.ascx" TagName="Uc_msg" TagPrefix="uc1" %>
<link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

<script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

<html>
<head runat="server">
    <title>用户信息管理 </title>
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
                                                当前位置：用户信息管理</td>
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
                        <uc2:UcMsg_kuais ID="UcMsg_kuais1" runat="server"></uc2:UcMsg_kuais>
                        <br />
                        <uc1:Uc_msg ID="Uc_msg1" runat="server"></uc1:Uc_msg>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            Width="100%" AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:TemplateField HeaderText="用户名" SortExpression="Username">
                                    <ItemTemplate>
                                        &nbsp;[<a href='US_log.aspx?strName=<%# Eval("username")%>' class="LOG" >LOG</a>]
                                        <a href="US_msg.aspx?strName=<%#Eval("username") %>">
                                            <%# Eval("username")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <a href="US_msg.aspx?softwareType=<%#Eval("SoftwareType") %>" class="wuxia">
                                            <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户类型" SortExpression="UserType">
                                    <ItemTemplate>
                                        <a href="US_msg.aspx?strUserType=<%#Eval("UserType") %>" class="wuxia">
                                            <%--<span style="color:#333333">--%>
                                            <%#GetUtype(Eval("UserType"))%>
                                            <%--</span>--%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="到期日期" SortExpression="ExpireDate">
                                    <ItemTemplate>
                                        <%#GetData((Eval("UserType")), (Eval("ExpireDate")), (Eval("StatResult")))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="天数" SortExpression="ValidDays">
                                    <ItemTemplate>
                                        <%#GetDay(Eval("ValidDays"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="创建时间" SortExpression="CreateTime" DataField="CreateTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="18%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="次数" SortExpression="UseCount" DataField="UseCount">
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="pc" SortExpression="ServiceID" DataField="ServiceID">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LastPayTime" HeaderText="最后登录时间" SortExpression="LastPayTime"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle Width="16%" HorizontalAlign="center" />
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
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            CustomInfoStyle='vertical-align:middle;' Width="100%" BackColor="Transparent"
                            CssClass="pagestyle" EnableTheming="True" HorizontalAlign="Center" CustomInfoSectionWidth="25%"
                            CustomInfoTextAlign="Center" PageSize="20">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
