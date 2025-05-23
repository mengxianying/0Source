<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShowShoppingCart1.aspx.cs"
    Inherits="Pbzx.Web.ShowShoppingCart1" EnableEventValidation="false" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc7" %>
<%@ Register Src="Contorls/ShoppingCartNotice.ascx" TagName="ShoppingCartNotice"
    TagPrefix="uc6" %>
<%@ Register Src="Contorls/ShopServers.ascx" TagName="ShopServers" TagPrefix="uc5" %>
<%@ Register Src="Contorls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc4" %>
<%@ Register Src="Contorls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>购物车_拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩神通软件,购物车列表" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc2:Head ID="Head2" runat="server"></uc2:Head>
            <table width="990px;" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" valign="top">
                        <uc6:ShoppingCartNotice ID="ShoppingCartNotice1" runat="server"></uc6:ShoppingCartNotice>
                        <uc4:ShoppingCart ID="ShoppingCart1" runat="server" />
                        <table width="990" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top" width="750">
                                    <table width="750" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="8">
                                                <img src="/Images/Web/shop_serve1l.jpg" alt="" border="0" />
                                            </td>
                                            <td width="734" align="left" background="/Images/Web/shop_serve1bg.jpg">
                                                <b>在线购买流程</b></td>
                                            <td width="8">
                                                <img src="/Images/Web/shop_serve1r.jpg" alt="" border="0" /></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="8" cellspacing="1" bgcolor="#F9A533">
                                        <tr>
                                            <td bgcolor="#FFFFFF">
                                                <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="17%">
                                                            <img src="/images/web/shop_flow_pic1.jpg" width="119" height="92" /></td>
                                                        <td width="11%" align="center">
                                                            <img src="/images/web/shop_flow_li.jpg" width="29" height="22" /></td>
                                                        <td width="17%">
                                                            <img src="/images/web/shop_flow_pic2.jpg" width="119" height="92" /></td>
                                                        <td width="11%" align="center">
                                                            <img src="/images/web/shop_flow_li.jpg" width="29" height="22" /></td>
                                                        <td width="17%">
                                                            <img src="/images/web/shop_flow_pic3.jpg" width="119" height="92" /></td>
                                                        <td width="10%" align="center">
                                                            <img src="/images/web/shop_flow_li.jpg" width="29" height="22" /></td>
                                                        <td width="17%">
                                                            <img src="/images/web/shop_flow_pic4.jpg" width="119" height="92" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 10px;">
                                </td>
                                <td style="width: 230px;">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td bgcolor="#FFFFFF">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                                                    <tr>
                                                        <td height="28" align="left" background="/Images/Web/shop_serve2.jpg">
                                                            &nbsp;&nbsp;<strong>在线客服</strong></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="1" bgcolor="#69B2F6">
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="padding-left:5px;">
                                                <uc7:UC_QQ ID="UC_QQ1" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc3:Footer ID="Footer1" runat="server"></uc3:Footer>
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
