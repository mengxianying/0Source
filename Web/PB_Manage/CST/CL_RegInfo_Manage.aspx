<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CL_RegInfo_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.CL_RegInfo_Manage" %>

<%@ Register Src="../Controls/UcRegInfoSearch.ascx" TagName="UcRegInfoSearch" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_online.ascx" TagName="Uc_online" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>打印注册信息管理</title>
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
                                                当前位置：打印注册信息</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%-- <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER" style="height: 28px">
                                    <a href="CL_RegInfo_Manage.aspx">管理打印注册信息</a> |&nbsp;
                                    <a href="CL_RegInfo_Editor.aspx">添加打印注册信息</a></td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left"><uc2:UcRegInfoSearch ID="UcRegInfoSearch1" runat="server"></uc2:UcRegInfoSearch>
                    </td>
                </tr>
            </table>
         <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                             AllowSorting="True" OnSorting="MyGridView_Sorting"  OnRowDataBound="MyGridView_RowDataBound">
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                  <asp:BoundField DataField="ID" HeaderText="序号" />     
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户姓名" SortExpression="Username">
                                    <ItemTemplate>
                                    <div title='操作员:<%#DataBinder.Eval(Container.DataItem,"Operator")%>&#13;电话:<%#DataBinder.Eval(Container.DataItem,"UserTel")%>&#13;邮件:<%#DataBinder.Eval(Container.DataItem,"UserEmail")%>&#13;地址:<%#DataBinder.Eval(Container.DataItem,"UserAddress")%>&#13;备注:<%#DataBinder.Eval(Container.DataItem,"Remarks")%>'>
                                                    <a href='CL_RegInfo_Manage.aspx?strUsername=<%#Eval("Username") %>'>
                                                        <%# Eval("UserName")%>
                                                    </a>
                                                </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付费方式" SortExpression="PayType">
                                    <ItemTemplate>
                                        <%#Eval("PayType")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="金额" SortExpression="PayMoney">
                                    <ItemTemplate>
                                        <%# Eval("PayMoney")%>
                                        元
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付费状态" SortExpression="PayStatus">
                                    <ItemTemplate>
                                        <%#GetPayStatus(Eval("PayStatus"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册方式" SortExpression="RegisterType">
                                    <ItemTemplate>
                                        <%# GetRegisterType(Eval("RegisterType"), Eval("AgentName"), Eval("CardInfo"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册日期" SortExpression="CreateTime">
                                    <ItemTemplate>
                                        <%# Eval("CreateTime", "{0:yyyy-MM-dd hh:mm}")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="打印线序列号" SortExpression="ExpireDate">
                                    <ItemTemplate>
                                        <%# FormartSn(Eval("SNs"))%>
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
                    <td style="width: 207px" align="right">
                        <span style="color: Black">
                            <asp:Label ID="lblTotal" runat="server" Width="200"></asp:Label></span></td>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
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
