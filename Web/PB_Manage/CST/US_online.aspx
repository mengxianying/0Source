<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_online.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.US_online"
    EnableEventValidation="false" %>

<%@ Register Src="../Controls/UcOnline_kuais.ascx" TagName="UcOnline_kuais" TagPrefix="uc2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Controls/Uc_online.ascx" TagName="Uc_online" TagPrefix="uc1" %>
<html>
<head runat="server">
    <title>在线用户信息管理</title>

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
                                                当前位置：在线用户信息管理</td>
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
                    <td bgcolor="#F7FBFF" align="left"> <uc2:UcOnline_kuais id="UcOnline_kuais1" runat="server">
                        </uc2:UcOnline_kuais>
                        <uc1:Uc_online ID="Uc_online1" runat="server"></uc1:Uc_online>
                       </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" DataKeyNames="ID" CssClass="GridView_Table" Width="100%" AllowSorting="True"
                            OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号" />
                                <asp:TemplateField HeaderText="用户名" SortExpression="Username">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>; bool: '1')?'color:#FF0000': '' %>;">
                                            <div title='服务ID号:<%#DataBinder.Eval(Container.DataItem,"ServiceID")%>&#13;用户索引:<%#DataBinder.Eval(Container.DataItem,"UserIndex")%>&#13;使用值:<%#DataBinder.Eval(Container.DataItem,"UseValue")%>&#13;用户类型:<%#GetUtype(DataBinder.Eval(Container.DataItem,"UseType"))%>&#13;'>
                                                &nbsp;[<a href='US_log.aspx?strName=<%# Eval("username") %>' class="LOG">LOG</a>]
                                                <a href="US_online.aspx?strName=<%#  Server.UrlEncode(Eval("username").ToString()) %>">
                                                 <%#Pbzx.Common.Method.GetNameSe(Eval("username"),Eval("UseType"))%>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="16%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称" SortExpression="SoftwareType">
                                    <ItemTemplate>
                                        <a href="US_online.aspx?SoftwareName=<%#Eval("SoftwareType") %>" class="wuxia">
                                            <%#ChkSoftType(Eval("SoftwareType"), Eval("InstallType")) %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="版本号" SortExpression="ProgramVer">
                                    <ItemTemplate>
                                        <a href="US_online.aspx?strVersion=<%#Eval("ProgramVer") %>">
                                            <%# Eval("ProgramVer")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="认证码" SortExpression="HDSN">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>">
                                            <div title='注册码:<%#DataBinder.Eval(Container.DataItem,"RN")%>&#13;'>
                                                <%#Eval("HDSN") %>
                                                [<a href='SoftOnline_Manage.aspx?yuan=yes&strHDSN=<%# DataBinder.Eval(Container.DataItem,"HDSN") %>'
                                                    target="_blank"> <font color='blue'>线</font></a>] [<a href='US_online.aspx?yuan=yes&strHDSN=<%#Eval("HDSN") %>'
                                                        class="wuxia"><font color='<%#Pbzx.Common.Method.CheckRegType(Eval("HDSN"))%>'>原</font></a>]
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IP地址" SortExpression="ip">
                                    <ItemTemplate>
                                        <div style="<%# (bool)(DataBinder.Eval(Container.DataItem,"Status").ToString() != "1")?"color:#FF0000": "" %>">
                                            <div title='IP地址:<%#DataBinder.Eval(Container.DataItem,"IP")%>&#13;'>
                                                <a href="US_online.aspx?strIP=<%#Eval("IP") %>">
                                                    <%# GetIpName(Eval("IP"))%>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="端口号" SortExpression="Port" DataField="Port">
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="登录时间" SortExpression="StartTime" DataField="StartTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="14%" />
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
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left" width="100px" style="height: 48px">
                        <span style="color: Black"></span>
                           </td>
                    <td align="right" style="height: 48px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" CustomInfoStyle='vertical-align:middle;'
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle">
                        </webdiyer:AspNetPager>
                        </td>
                </tr>
            </table>
        </div> 
        <asp:Literal ID="labdangqian" runat="server"></asp:Literal>   
       <asp:Label ID="lblFZ" runat="server"></asp:Label>
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
