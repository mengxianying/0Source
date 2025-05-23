<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserTradeInfo.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.UserTradeInfo" %>

<%@ Register Src="Controls/UcTradeInfo.ascx" TagName="UcTradeInfo" TagPrefix="uc3" %>
<%@ Register Src="Controls/UcUserCharge.ascx" TagName="UcUserCharge" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Controls/UcBulletinSearch.ascx" TagName="UcBulletinSearch" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <title>用户交易日志管理</title>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3" align="center">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />交易日志管理</td>
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
                        &nbsp;<uc3:UcTradeInfo ID="UcTradeInfo1" runat="server"></uc3:UcTradeInfo>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="Id,UserName" CssClass="GridView_Table"
                            OnRowDataBound="MyGridView_RowDataBound">
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <FooterStyle CssClass="GridView_Footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="全选" Visible="False">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="sel" value="<%#Eval("Id") %>" /></ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="序号" DataField="ID" >
                                    <ItemStyle Width="3%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户名" SortExpression="UserName">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <a href="WebUser_Editor.aspx?ID=<%#GetUserIDByUserName(Eval("UserName")) %>" target="_blank">
                                            <%#Eval("UserName")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="交易类型" SortExpression="TradeType">
                                    <ItemTemplate>
                                        <a href="UserTradeInfo.aspx?strType=<%# Eval("TradeType")%>">
                                            <%# Pbzx.Web.WebFunc.GetTradeType(Eval("TradeType"))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="14%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="毛收入">
                                    <ItemTemplate>
                                        <%# ((Convert.ToInt32(Eval("TradeType")) / 100) >= 3) && ((Convert.ToInt32(Eval("TradeType")) / 100) <= 4) ? Eval("TradeMoney", "{0:f2}") : ""%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="毛支出">
                                    <ItemTemplate>
                                        <%# (Convert.ToInt32(Eval("TradeType")) / 100) >= 7 ? Eval("TradeMoney", "{0:f2}") : ""%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="收入">
                                    <ItemTemplate>
                                        <%# (Convert.ToInt32(Eval("TradeType")) / 100) <= 2 ? Eval("TradeMoney", "{0:f2}") : ""%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="支出">
                                    <ItemTemplate>
                                        <%# ((Convert.ToInt32(Eval("TradeType")) / 100) >= 5) && ((Convert.ToInt32(Eval("TradeType")) / 100) <= 6) ? Eval("TradeMoney", "{0:f2}") : ""%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" 交易日期" SortExpression="TradeTime">
                                    <ItemTemplate>
                                        <%#Eval("TradeTime", "{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单号" SortExpression="ForeignKey_id">
                                    <ItemTemplate>
                                        <%#   Pbzx.Web.WebFunc.GetOrderLook(Eval("ForeignKey_id"), Eval("TradeType"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作员" SortExpression="OperateManager">
                                    <ItemTemplate>
                                        <%#Eval("OperateManager")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a target="_blank" href='UserTradeInfoDetail.aspx?ID=<%#Eval("Id") %>'>查看</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="GridView_Row" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td style="height: 68px">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" CustomInfoStyle='vertical-align:middle;'
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>统计信息：毛收入（<asp:Label ID="lblSR"
                            runat="server"></asp:Label>）－毛支出（<asp:Label ID="lblZC" runat="server"></asp:Label>）＝毛利润（<asp:Label
                                ID="lblMLR" runat="server"></asp:Label>）<br />
                        &nbsp; &nbsp; &nbsp; &nbsp; 实际收入（<asp:Label ID="lblSJSR" runat="server"></asp:Label>）－实际支出（<asp:Label
                            ID="lblSJZC" runat="server"></asp:Label>）＝实际利润（<asp:Label ID="lblSJLR" runat="server"></asp:Label>）<br />
                        &nbsp; &nbsp; &nbsp; &nbsp; 统计余额（<asp:Label ID="lblTJYE" runat="server"></asp:Label>）=毛收入（<asp:Label
                            ID="lblSR2" runat="server"></asp:Label>）+ 用户返点（<asp:Label ID="lblLoginFD" runat="server"></asp:Label>）+
                        经纪人收入（<asp:Label ID="lblJJR" runat="server"></asp:Label>）－毛支出（<asp:Label ID="lblZC2"
                            runat="server"></asp:Label>）－余额支付（<asp:Label ID="lblYEZF" runat="server"></asp:Label>）<br />
                        &nbsp; &nbsp; &nbsp; &nbsp; 实际余额（<asp:Label ID="lblUserTotal" runat="server"></asp:Label>）<br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
