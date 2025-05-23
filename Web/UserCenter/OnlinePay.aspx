<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlinePay.aspx.cs" Inherits="Pbzx.Web.UserCenter.OnlinePay" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>订单提交成功页_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form2" name="form1" runat="server">
    <uc1:Head ID="Head1" runat="server" />
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
        <tr>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12%">
                            <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" />
                        </td>
                        <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                            在线支付信息
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
                <table width="95%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="7%" align="center">
                            <img src="../Images/Web/order_bankli.jpg" width="38" height="35" />
                        </td>
                        <td width="93%" align="left" class="order_18black">
                            您的订单号：<asp:Label ID="lblOrderID" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;应付金额：<span
                                class="order_18red"><asp:Label ID="lblMoneyPay" runat="server"></asp:Label></span>元
                        </td>
                    </tr>
                    <tr>
                        <td align="center" height="50">
                            &nbsp;
                        </td>
                        <td align="left">
                            立即支付, 请选择以下在线支付平台：（若支付失败，请点击网页右上角的“用户中心”在“我的订单”中找到未支付的该订单，点击“网上支付”继续支付。）
                        </td>
                    </tr>
                </table>
                <div runat="server" id="dvSuccess">
                    <table width="72%" border="0" align="center" cellpadding="7" cellspacing="0">
                        <tr>
                            <td align="center">
                                <a href=""></a>&nbsp;<asp:ImageButton ID="ibtnAlipay" runat="server" AlternateText="支付宝支付"
                                    OnClick="ibtnAlipay_Click" ImageUrl="~/Images/Web/Pay_treasure.jpg" CssClass="order_Cursor" />
                            </td>
                            <td align="center">
                               <%-- <a href=""></a>&nbsp;<asp:ImageButton ID="imgYunWang" runat="server" AlternateText="云网支付"
                                    OnClick="imgYunWang_Click" ImageUrl="~/Images/Web/yunwang.jpg" CssClass="order_Cursor" /> --%>
                            </td>
                            <td align="center">
                               <%-- <a href=""></a>&nbsp;<asp:ImageButton Height="50px"  Width="120px" ID="ibtnChinaBank" runat="server" AlternateText="京东支付"
                                    OnClick="ibtnChinaBank_Click" ImageUrl="~/Images/Web/jdzf.png" CssClass="order_Cursor" /> 
                                    <br/> <!-- <span style="color:Red">测试中请勿用</span> --> --%>
                            </td>
                            <td align="center">
                                <%--<a href=""></a>&nbsp;<asp:ImageButton ID="ibtn99Bill" runat="server" AlternateText="快钱支付"
                                    OnClick="ibtn99Bill_Click" ImageUrl="~/Images/Web/kuaiqian.jpg" CssClass="order_Cursor" /> --%>
                            </td>
                        </tr>
                    </table>
                </div>
                <table width="90%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="order_xia" height="10">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 32px">
                            当您支付成功后，系统将实时自动开通您注册的软件，软件即可使用，购买新软件狗的用户请注意查收您的快递，并且点击网页右上角的“用户中心”在“我的订单”中点击订单号打开订单详细页面，然后点击“开通临时使用”按钮可以免费获得临时的软件使用。
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
