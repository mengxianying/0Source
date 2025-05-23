<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker_TradeInfo.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Broker_TradeInfo" EnableEventValidation="false" %>

<%@ Register Src="Controls/UcBroker_Trade.ascx" TagName="UcBroker_Trade" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>经纪人交易信息</title>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script type="text/javascript" language="javascript">
        function OpenEdite(id)
        {
            var result =  window.showModalDialog('OrderShow.aspx?ID='+id+'','','dialogHeight:400px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
            if(result == 'yes')
            {
               location.reload();    
            }
        }
    </script>

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
                                                当前位置：经纪人交易信息管理</td>
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
                        <uc1:UcBroker_Trade ID="UcBroker_Trade1" runat="server"></uc1:UcBroker_Trade>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" DataKeyNames="ID" CssClass="GridView_Table"  Width="100%"
                            AllowSorting="True" OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="序号">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="经纪人用户名" SortExpression="BrokerName">
                                    <ItemTemplate>
                                        <%#Eval("BrokerName")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="13%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单编号" SortExpression="OrderID">
                                    <ItemTemplate>
                                        <a onclick='OpenEdite(<%#Eval("OrderID") %>);' href="#">
                                            <%#Eval("OrderID") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="18%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户用户名" SortExpression="CustomerName">
                                    <ItemTemplate>
                                        <%# Eval("CustomerName")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户付款" SortExpression="CustomerPay">
                                    <ItemTemplate>
                                        <%#Eval("CustomerPay", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="11%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注册人" SortExpression="RegManager">
                                    <ItemTemplate>
                                        <%# Eval("RegManager")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="经纪人收益" SortExpression="BrokerIncome">
                                    <ItemTemplate>
                                        <%#Eval("BrokerIncome", "{0:f2}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="创建时间" SortExpression="CreateTime" DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                    <ItemStyle HorizontalAlign="Center" Width="16%" />
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
                    <td align="right">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            CustomInfoStyle='vertical-align:middle;' OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblSort" Visible="false" runat="server" Text="desc"></asp:Label>
    </form>
</body>
</html>
