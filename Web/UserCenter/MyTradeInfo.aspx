<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyTradeInfo.aspx.cs" Inherits="Pbzx.Web.UserCenter.MyTradeInfo" %>

<%@ Register Src="Contorls/UcTradeInfo.ascx" TagName="UcTradeInfo" TagPrefix="uc2" %>
<%@ Register Src="Contorls/UcMoney_Log.ascx" TagName="UcMoney_Log" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资金往来</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="780" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">交易明细</span></td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="1" cellspacing="1" bgcolor="#FFCB99" align="center">
                <tr>
                    <td bgcolor="#FFF8EE">
                       <uc2:UcTradeInfo ID="UcTradeInfo1" runat="server"></uc2:UcTradeInfo>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowDataBound="MyGridView_RowDataBound" CssClass="GridViewStyle" DataKeyNames="ID,UserName">
                            <Columns>
                                <asp:BoundField HeaderText="序号" DataField="Id">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="交易类型" SortExpression="TradeType">
                                    <ItemTemplate>
                                      <a href="MyTradeInfo.aspx?strType=<%# Eval("TradeType")%>"> <%# Pbzx.Web.WebFunc.GetUserTradeType(Eval("TradeType"))%></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" Width="24%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="收入">
                                    <ItemTemplate>
                                        <%# (Convert.ToInt32(Eval("TradeType"))/10%10) < 5 ? Eval("TradeMoney", "{0:C2}") : "" %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="支出">
                                    <ItemTemplate>
                                       <%# (Convert.ToInt32(Eval("TradeType")) / 10 % 10) >= 7 && (Convert.ToInt32(Eval("TradeType")) / 10 % 10) <= 8 ? Eval("TradeMoney", "{0:C2}") : ""%>                                        
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="帐户余额" SortExpression="CurrentMoney">
                                    <ItemTemplate>
                                        <%# (Convert.ToInt32(Eval("TradeType")) / 10 % 10) >= 5 && (Convert.ToInt32(Eval("TradeType")) / 10 % 10) <= 6 ? "" : Eval("CurrentMoney", "{0:C2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="支付金额" SortExpression="CurrentMoney">
                                    <ItemTemplate>
                                     <%# (Convert.ToInt32(Eval("TradeType")) / 10 % 10) >= 5 && (Convert.ToInt32(Eval("TradeType")) / 10 % 10)<=6 ? Eval("TradeMoney", "{0:C2}") : ""%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="交易时间">
                                    <ItemTemplate>
                                        <%#Eval("TradeTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>                                                                
                                <asp:TemplateField HeaderText="订单号">
                                    <ItemTemplate>
                                        <%# Pbzx.Web.WebFunc.GetUserOrderLook(Eval("ForeignKey_id"), Eval("TradeType"))%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>
                                
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EmptyDataTemplate>
                                <table width="100%" border="0" cellpadding="3" cellspacing="0" bgcolor="#DCEDFC">
                                    <tr>
                                        <td width="5%" align="center">
                                            序号
                                        </td>
                                        <td width="18%" align="center">
                                            交易类型</td>
                                        <td width="12%" align="center">
                                            收入</td>
                                        <td width="12%" align="center">
                                            支出</td>
                                        <td width="12%" align="center">
                                            当前余额</td>
                                        <td width="15%" align="center">
                                            交易时间</td>
                                            <td width="15%" align="center">
                                            订单号</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" height="28" valign="bottom">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页;" LastPageText="最后一页;" NextPageText="下一页;" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页;" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center" SubmitButtonClass="page_go">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        统计信息 ： 总收入金额（<asp:Label ID="lblSR" runat="server"></asp:Label>）， 总支出金额（<asp:Label ID="lblZC" runat="server"></asp:Label>），总支付金额（<asp:Label ID="lblZFJE" runat="server"></asp:Label>），当前可用余额（<asp:Label
                            ID="lblKYYE" runat="server"></asp:Label>）</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
