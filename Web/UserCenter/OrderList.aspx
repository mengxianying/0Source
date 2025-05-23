<%@ Page Language="C#" AutoEventWireup="true" Codebehind="OrderList.aspx.cs" Inherits="Pbzx.Web.UserCenter.OrderList" %>

<%@ Register Src="Contorls/UcOrder.ascx" TagName="UcOrder" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/AddOrder.ascx" TagName="AddOrder" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/UcAddOrder.ascx" TagName="UcAddOrder" TagPrefix="uc6" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/OrderInfo.ascx" TagName="OrderInfo" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head11">
    <title>查看订单_拼搏在线彩神通软件</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="680" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">我的订单</span>&nbsp;&nbsp;</td>
                    <td width="680" class="uc_xia" valign="bottom" align="right">
                        <%--（如果订单还未付款，您可以点击“取消”按钮，取消该订单。）--%></td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#FFCB99">
                <tr>
                    <td bgcolor="#FFF8EE" align="left">
                        <uc4:UcOrder ID="UcOrder1" runat="server"></uc4:UcOrder>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellspacing="0" align="center" cellpadding="0" class="uc_MT10">
                <tr>
                    <td>
                        <asp:GridView ID="gvOrderList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            Width="100%" GridLines="Horizontal" OnPageIndexChanging="gvOrderList_PageIndexChanging"
                            PageSize="20" CssClass="GridViewStyle" OnRowDataBound="gvOrderList_RowDataBound"
                            OnRowCreated="gvOrderList_RowCreated" DataKeyNames="OrderID,PayTypeID,PayTypeName,Type,IsCancel,TipID,TipName,IsPay">
                            <Columns>
                                <asp:BoundField HeaderText="序号">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="订单号">
                                    <ItemTemplate>
                                        <a href="/UserCenter/detailsorder.aspx?OrderID=<%#Eval("OrderID") %>" target="_blank">
                                            <%#Eval("OrderID") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="付款方式">
                                    <ItemTemplate>
                                        <%#Eval("PayTypeName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总费用">
                                    <ItemTemplate>
                                        <%# Totall(Eval("TotalProductPrice"), Eval("PortPrice"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="HasPayedPrice" DataFormatString="{0:C2}" HeaderText="已付费用"
                                    HtmlEncode="False">
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="订单状态">
                                    <ItemStyle CssClass="msg" HorizontalAlign="Center" Width="16%" />
                                    <ItemTemplate>
                                        <%# Pbzx.Web.WebFunc.FormartTipName(Eval("TipID"),Eval("IsPay")) %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="未付费用">
                                    <ItemTemplate>
                                        <%# NotPlay(Eval("TotalProductPrice"), Eval("PortPrice"), Eval("HasPayedPrice"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="下单时间">
                                    <ItemTemplate>
                                        <%#Eval("OrderDate","{0:yyyy-MM-dd HH:mm}")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="12%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnCancel" runat="server" OnCommand="lbtnCancel_Command"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="21%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EmptyDataTemplate>
                                <table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#DCEDFC">
                                    <tr>
                                        <td width="6%" align="center">
                                            序号
                                        </td>
                                        <td width="14%" align="center">
                                            订单号</td>
                                        <td width="9%" align="center">
                                            付款方式</td>
                                        <td width="9%" align="center">
                                            总费用</td>
                                        <td width="9%" align="center">
                                            已付费用</td>
                                        <td width="16%" align="center">
                                            订单状态</td>
                                        <td width="9%" align="center">
                                            未付费用</td>
                                        <td width="16%" align="center">
                                            下单时间</td>
                                        <td width="12%" align="center">
                                            操作
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellspacing="0" align="center" cellpadding="4">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                            ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                            CustomInfoStyle='vertical-align:middle;' class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center" PageSize="20" SubmitButtonClass="page_go">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
