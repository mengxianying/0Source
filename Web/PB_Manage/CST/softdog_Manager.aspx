<%@ Page Language="C#" AutoEventWireup="true" Codebehind="softdog_Manager.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.softdog_Manager" %>

<%@ Register Src="~/PB_Manage/Controls/UcSoftdogsearch.ascx" TagName="UcSoftdogsearch"
    TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>软件狗管理首页</title>
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
                                                当前位置：软件狗管理首页</td>
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
                                    <a href="softdog_Manager.aspx">管理软件狗</a> |&nbsp;
                                    <a href="softdog_Editor.aspx">添加软件狗</a></td>
                            </tr>
                        </table>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcSoftdogsearch ID="UcSoftdogsearch1" runat="server"></uc1:UcSoftdogsearch>
                    </td>
                </tr>
            </table>
           <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            BorderStyle="Solid" CellPadding="0" CssClass="GridView_Table" DataKeyNames="ID"
                            PageSize="20" Width="100%" AllowSorting="True"  OnRowDataBound="MyGridView_RowDataBound" OnSorting="MyGridView_Sorting">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="序号">
                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="软件狗号">
                                    <ItemTemplate>
                                        &nbsp;<a href="softdog_Manager.aspx?strSN=<%#Eval("SN") %>"><%# Eval("SN")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="付费方式" DataField="PayType" SortExpression="PayType" >
                                    <ItemStyle HorizontalAlign="Center" Width="11%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                
                                <asp:TemplateField HeaderText="销售者" SortExpression="Seller">
                                    <ItemTemplate>
                                 <a href="softdog_Manager.aspx?strSeller=<%#Eval("Seller") %>"><%#Eval("Seller")%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                             
                                <asp:BoundField HeaderText="价格" DataField="SellPrice" SortExpression="SellPrice">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <%# GetStatus(Eval("Status"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="销售时间" DataField="SellTime"  SortExpression="SellTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="17%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="备注" >
                                    <ItemTemplate>
                                        <span style="color: #1A3A77">
                                            <%#Eval("Remarks") %>
                                        </span>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="34%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href='softdog_Editor.aspx?ID=<%#Eval("ID") %>'>修改</a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
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
