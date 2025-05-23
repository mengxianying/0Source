<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BalancePayQueRen.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.BalancePayQueRen" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>订单提交成功页_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form2" name="form1" runat="server">
    <uc1:Head ID="Head1" runat="server" />
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT"
        runat="server" id="tbZF">
        <tr>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12%">
                            <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" />
                        </td>
                        <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                            余额支付信息
                        </td>
                        <td width="1%">
                            <img src="/Images/Web/order_bg1c.jpg" width="10" height="44" border="0" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="10" background="/Images/Web/order_bg2a.jpg">
                &nbsp;
            </td>
            <td width="970" align="center" bgcolor="#FFFFFF">
                <br />
                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="7%" align="center">
                            <img src="../Images/Web/order_bankli.jpg" width="38" height="35">
                        </td>
                        <td width="93%" align="left" class="order_18black">
                            您的订单号：<span class="order_14red"><asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label></span>
                            &nbsp;应付金额：<span class="order_14red"><asp:Label ID="lblOrderMoney" runat="server"
                                Text="Label"></asp:Label>
                                &nbsp; &nbsp; </span>支付方式：余额支付
                        </td>
                    </tr>
                </table>
                <br />
                <font style="font-size: 14px;">点击余额支付完成交易：&nbsp;</font><asp:ImageButton ID="ibtnBalancePay"
                    runat="server" OnClick="ibtnBalancePay_Click" ImageUrl="~/Images/Web/yue_btn.jpg"
                    align="absmiddle" />
                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="order_xia" height="10">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="32">
                            完成支付后，您可以：<a href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx">查看我的订单</a>&nbsp;
                            &nbsp;&nbsp;<a href="/ShowShoppingCart.aspx"> 继续购物</a>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="10" background="/Images/Web/order_bg2c.jpg">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 4px">
                <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" />
            </td>
            <td background="/Images/Web/order_bg3b.jpg" style="height: 4px">
            </td>
            <td style="height: 4px">
                <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" />
            </td>
        </tr>
    </table>
    <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
