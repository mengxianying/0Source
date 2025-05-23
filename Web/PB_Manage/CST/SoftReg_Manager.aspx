<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftReg_Manager.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftReg_Manager" EnableEventValidation="false" %>

<%@ Register Src="../Controls/UcSoftRegSearch.ascx" TagName="UcSoftRegSearch" TagPrefix="uc1" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <title>软件注册信息管理</title>

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
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：软件注册信息
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
                        <uc1:UcSoftRegSearch ID="UcSoftRegSearch1" runat="server"></uc1:UcSoftRegSearch>                        
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
                                <asp:BoundField DataField="ID" HeaderText="序号">
                                    <ItemStyle Width="5%" />
                                    <HeaderStyle Width="50px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户认证码" SortExpression="HDSN">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>">
                                            <div title='注册码:<%#DataBinder.Eval(Container.DataItem,"RN")%>&#13;升级次数:<%#DataBinder.Eval(Container.DataItem,"UpdateCount")%>&#13;最后升级日期:<%#DataBinder.Eval(Container.DataItem,"LastUpdateDate")%>&#13;最后升级版本:<%#DataBinder.Eval(Container.DataItem,"LastUpdateVersion")%>&#13;数据下载时间:<%#DataBinder.Eval(Container.DataItem,"DD_Time")%>&#13;当日下载次数:<%#DataBinder.Eval(Container.DataItem,"DD_Count")%>&#13;操作员:<%#DataBinder.Eval(Container.DataItem,"Operator")%>'>
                                                <a style='<%#BindHdsn_A(DataBinder.Eval(Container.DataItem,"OldSN"),DataBinder.Eval(Container.DataItem,"IsReRegistered"))  %>'
                                                    href='SoftReg_Manager.aspx&strHDSN=<%#DataBinder.Eval(Container.DataItem,"HDSN") %>'>
                                                    <%# ChkHDSN(DataBinder.Eval(Container.DataItem,"HDSN"),DataBinder.Eval(Container.DataItem,"RN"),DataBinder.Eval(Container.DataItem,"Status"))%>
                                                </a>[<a href='SoftOnline_Manage.aspx?yuan=yes&strHDSN=<%# DataBinder.Eval(Container.DataItem,"HDSN") %>'
                                                    target="_blank"><font color='<%#Pbzx.Common.Method.CheckRegType(DataBinder.Eval(Container.DataItem,"HDSN"))%>'>
                                                        线</font></a>]</div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户名" SortExpression="Username">
                                    <ItemTemplate>
                                        <a href='SoftReg_Manager.aspx?strUserName=<%#Eval("Username") %>' style='<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"#FF0000": "" %>'
                                            title='用户电话:<%#DataBinder.Eval(Container.DataItem,"UserTel")%>&#13;用户邮箱:<%#DataBinder.Eval(Container.DataItem,"UserEmail")%>&#13;用户地址:<%#DataBinder.Eval(Container.DataItem,"UserAddress")%>&#13;用户BBSID:<%#DataBinder.Eval(Container.DataItem,"BBsID")%>'>
                                            <%# DataBinder.Eval(Container.DataItem,"Username")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="使用" SortExpression="UseType">
                                    <ItemTemplate>
                                        <%#  BindGetUseType(Eval("UseType")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="包月" SortExpression="TimeType">
                                    <ItemTemplate>
                                        <%# BindGetTimeType(Eval("TimeType")) %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付费方式" SortExpression="PayType">
                                    <ItemTemplate>
                                   <a href='SoftReg_Manager.aspx?PayType=<%#Eval("PayType") %>'> <%#Eval("PayType") %></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="11%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="价格" SortExpression="PayMoney">
                                    <ItemTemplate>
                                        <%#Eval("PayMoney")%>
                                        元
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册方式" SortExpression="AgentName">
                                    <ItemTemplate>
                                        <a href='SoftReg_Manager.aspx?RegisterType=<%#Eval("AgentName")%>'>
                                            <%#Eval("AgentName")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="模式">
                                    <ItemTemplate>
                                        <a href='SoftReg_Manager.aspx?RegisterMode=<%#Eval("RegisterMode")%>'><%# Method.GetRegMode(Eval("RegisterMode"))%></a>
                                    </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" Width="5%" />                              
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册日期" SortExpression="RegisterDate">
                                    <ItemTemplate>
                                        <%#Eval("RegisterDate", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="过期日期">
                                    <ItemTemplate>
                                        <%# Method.FormartExpireDate(Eval("ExpireDate")) %>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
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
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <span style="color: Black">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label></span></td>
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
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
