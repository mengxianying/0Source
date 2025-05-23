<%@ Page Language="C#" AutoEventWireup="true" Inherits="Alipay_Return" Codebehind="Alipay_Return.aspx.cs" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>支付宝返回结果 - 拼搏在线彩神通软件</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style>
			BODY { FONT-SIZE: 9pt }
			INPUT { FONT-SIZE: 9pt }
			TD { FONT-SIZE: 9pt }
		</style>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form2" method="post" runat="server">
        <div align="center">
            <uc1:Head ID="Head1" runat="server" />
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                <tr>
                    <td colspan="3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12%">
                                    <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" /></td>
                                <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                                    请认真审核您的信息</td>
                                <td width="1%">
                                    <img src="/Images/Web/order_bg1c.jpg" width="10" height="44" border="0" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="10" background="/Images/Web/order_bg2a.jpg">
                        &nbsp;</td>
                    <td width="970" align="center" bgcolor="#FFFFFF">
                        <br />
                        <table width="85%" border="0" cellpadding="4" cellspacing="1" bgcolor="#C9CCD3">
                            <tr>
                                <td bgcolor="#F4FBFF">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="12%">
                                                <img src="/Images/Web/buy_okli.gif" border="0" /></td>
                                            <td width="88%" align="left">
                                                <span class="buy_oktitle">
                                                    <asp:Label ID="payMsg" ForeColor="#E10900" runat="server">支付结果</asp:Label></span></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table width="85%" border="0" cellspacing="0" cellpadding="4" id="tbOrder" runat="server">
                            <tr>
                                <td width="12%" align="right" class="order_xia buy_okbiao">
                                    订&nbsp;单&nbsp;号：</td>
                                <td width="37%" align="left" class="order_xia buy_okshuo">
                                    <asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label>
                                </td>
                                <td width="12%" align="right" class="order_xia buy_okbiao">
                                    订单日期：</td>
                                <td width="39%" align="left" class="order_xia buy_okshuo">
                                    <font color="#000080">
                                          <asp:Label ID="lblOrderDate" runat="server" Text=""></asp:Label>
                                    </font>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="order_xia buy_okbiao">
                                    支付方式：</td>
                                <td align="left" class="order_xia buy_okshuo">
                                    <font color="#000080">支付宝 
                                    </font>
                                </td>
                                <td align="right" class="order_xia buy_okbiao">
                                    支付金额：</td>
                                <td align="left" class="order_xia buy_okshuo">
                                    <font color="#000080">
                                      <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>    
                                        元</font></td>
                            </tr>
                            <tr>
                                <td align="right" class="order_xia buy_okbiao">
                                    支付结果：</td>
                                <td colspan="3" align="left" class="order_xia buy_okshuo">
                                    <font color="#e10900">
                                     <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>    
                                    </font>
                                </td>
                            </tr>
                        </table>
                        <table width="85%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td align="left">
                                    <b>注：</b>在支付完1-3分钟后，我们将收到您的支付信息，并自动完成相应的操作；<br/>
                                    <%
                                    string strOrderType = Pbzx.Web.WebFunc.GetOrderType(Request["out_trade_no"]);
                                    if (strOrderType == "0")
                                    {
                                    %>          
                                    &nbsp; &nbsp; 请到用户中心，在“我的订单”中找到您刚刚支付完成的订单，然后点击订单号，查看注册信息。
                                  <%}
                                    else if (strOrderType =="2")
                                    {%>
                                    &nbsp; &nbsp; 请到用户中心查看您的帐户余额；或点击“我的帐户”，在“充值/取款”中找到您刚刚支付完成的订单，然后点击订单号，查看详细信息。                                    
                                  <%}
                                %>
                                    
                                    </td>
                            </tr>
                        </table>
                        <table width="85%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td align="center">
                                    <a href="<%=orderDetailUrl %>">
                                        <img src="/Images/Web/see_register.jpg" border="0" /></a></td>
                            </tr>
                        </table>
                    </td>
                    <td width="10" background="/Images/Web/order_bg2c.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" /></td>
                    <td background="/Images/Web/order_bg3b.jpg">
                    </td>
                    <td>
                        <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" /></td>
                </tr>
            </table>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
