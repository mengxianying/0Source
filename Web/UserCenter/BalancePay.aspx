s<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BalancePay.aspx.cs" Inherits="Pbzx.Web.UserCenter.BalancePay" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>订单提交成功页_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form2" name="form1" runat="server">
    <uc1:Head ID="Head1" runat="server" />
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT"
        runat="server" visible="true" id="tbZF">
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
                <table width="85%" border="0" cellpadding="8" cellspacing="0">
                    <tr>
                        <td class="order_14black" align="center">
                            您的订单号：<span class="order_14red">
                                <asp:Label ID="lblOrderID" runat="server"></asp:Label></span>
                        </td>
                    </tr>
                </table>
                <div runat="server" id="dvFail">
                    <table width="75%" border="0" cellspacing="0" cellpadding="6">
                        <tr>
                            <td width="13%" align="right">
                                <img src="/Images/Web/order_banklierro.jpg" hspace="5" />
                            </td>
                            <td width="87%">
                                支付结果： 支付失败！可能是您得余额不足导致支付失败， 请登录“<a href="/UserCenter/User_Center.aspx" target="_blank">后台中心</a>”查看您的余额。
                            </td>
                        </tr>
                    </table>
                </div>
                <div runat="server" id="dvSuccess" visible="false">
                    <table width="60%" border="0" cellspacing="0" cellpadding="6">
                        <tr>
                            <td width="14%" align="right">
                                <img src="/Images/Web/order_bankli.jpg" hspace="5" />
                            </td>
                            <td width="86%">
                                支付结果： 支付成功！请登录“<a href="/UserCenter/User_Center.aspx" target="_blank">用户中心</a>”，在“<a
                                    href="/UserCenter/User_Center.aspx?myUrl=OrderList.aspx" target="_blank">我的订单</a>”中查看注册信息
                            </td>
                        </tr>
                    </table>
                </div>
                <table width="90%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td class="order_xia">
                            &nbsp;
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
