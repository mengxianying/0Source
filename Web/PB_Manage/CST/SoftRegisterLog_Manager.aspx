<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftRegisterLog_Manager.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftRegisterLog_Manager" EnableEventValidation="false" %>

<%@ Register Src="../Controls/UcRegLogSearch.ascx" TagName="UcRegLogSearch" TagPrefix="uc3" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>网络注册购买</title>

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

    <link href="../stylecss/css.css" rel="stylesheet" type="text/css" />
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1" style="height: 26px">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：网络注册购买</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER" style="height: 28px">
                                    <a href="SoftRegisterLog_Manager.aspx">管理网络注册用户购买信息</a> |&nbsp;
                                    <a href="SoftRegisterLog_Editor.aspx">添加网络注册用户购买信息</a></td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc3:UcRegLogSearch ID="UcRegLogSearch1" runat="server"></uc3:UcRegLogSearch>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                            AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="BbsName">
                                    <ItemTemplate>
                                        <a href="SoftRegisterLog_Manager.aspx?bbsName=<%#Eval("BbsName") %>">
                                            <%#Eval("BbsName") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户姓名" SortExpression="Username">
                                    <ItemTemplate>
                                        <div title='操作员:<%#DataBinder.Eval(Container.DataItem,"Operator")%>&#13;备注:<%#DataBinder.Eval(Container.DataItem,"Remarks")%>'>
                                            <a href='SoftRegisterLog_Manager.aspx?strUsername=<%#Eval("Username") %>'>
                                                <%#Eval("Username") %>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类型" SortExpression="UseType">
                                    <ItemTemplate>
                                        <%# Pbzx.Common.Method.GetNetUseType(Eval("UseType"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="使用值" SortExpression="UseValue">
                                    <ItemTemplate>
                                        <%# Pbzx.Common.Method.GetNetUseValue(Eval("UseType"), Eval("UseValue"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付费方式" SortExpression="PayType">
                                    <ItemTemplate>
                                        <a href="SoftRegisterLog_Manager.aspx?PayType=<%#Eval("PayType") %>">
                                            <%#Eval("PayType")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="金额" SortExpression="PayMoney">
                                    <ItemTemplate>
                                        <%#Eval("PayMoney")%>
                                        元
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付费状态" SortExpression="PayStatus">
                                    <ItemTemplate>
                                        <%#GetPayStatus(Eval("PayStatus"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册方式" SortExpression="RegisterType">
                                    <ItemTemplate>
                                        <%# GetRegisterType(Eval("RegisterType"), Eval("AgentName"), Eval("CardInfo"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="模式">
                                    <ItemTemplate>
                                        <a href='SoftRegisterLog_Manager.aspx?RegisterMode=<%#Eval("RegisterMode")%>'>
                                            <%# Method.GetRegMode(Eval("RegisterMode"))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册日期" SortExpression="CreateTime">
                                    <ItemTemplate>
                                        <%#Eval("CreateTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="其它相关信息">
                                    <ItemTemplate>
                                        <a href='Usermsg_Editor.aspx?ID=<%# Eval("CNUserID")%>'>软件</a>&nbsp;&nbsp;<a href='UserDetails2.aspx?ID=<%# Eval("CNUserDetailsID")%>'>客户</a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
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
                    <td style="width: 207px" align="center">
                        <span style="color: Black">
                            <asp:Label ID="lblTotal" runat="server" Width="200"></asp:Label></span></td>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
