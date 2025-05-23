<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShowOrder.aspx.cs" Inherits="Pbzx.Web.ShowOrder" %>

<%@ Register Src="../Contorls/ShopServers.ascx" TagName="ShopServers" TagPrefix="uc3" %>
<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc4" %>
<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/OrderInfo.ascx" TagName="OrderInfo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head11">
    <title>查看订单_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc4:Head ID="Head1" runat="server" />
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="750" valign="top">
                        <div id="OrderDetail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT">
                                <tr>
                                    <td>
                                        <img src="/Images/Web/shop_wei1.jpg" width="750" height="30" /></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" align="center" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td height="23" align="center" valign="top">
                                        <asp:Label ID="lblToEmailMsg" runat="server" Text="系统已将订单信息发送到您的Email:" Visible="False"
                                            CssClass="shop14red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <uc1:OrderDetail ID="OrderDetail1" runat="server" />
                            <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"  id="tbBroker"  runat="server" visible="false">
                                <tr bgcolor="#D4D4D4">
                                    <td height="20" align="left" background="/Images/Web/shop_serve.jpg">
                                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="height: 19px">
                                                    <strong>经纪人信息</strong></td>
                                                <td align="right" style="height: 19px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#ffffff">
                                        经纪人用户名：<asp:Label ID="lblBroker" runat="server" Width="160px"></asp:Label></td>
                                </tr>
                            </table>
                            <uc2:OrderInfo ID="OrderInfo1" runat="server" />
                            <table width="200" border="0" align="center" cellpadding="4" cellspacing="0">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnPay" runat="server" Text="付 款" OnClick="btnPay_Click" class="shop_Button2" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td width="230" valign="top">
                        <uc3:ShopServers ID="ShopServers1" runat="server" />
                    </td>
                </tr>
            </table>
            <uc5:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
