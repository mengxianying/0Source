<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddOrder.aspx.cs" Inherits="Pbzx.Web.AddOrder" %>

<%@ Register Src="../Contorls/ShopServers.ascx" TagName="ShopServers" TagPrefix="uc6" %>
<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc4" %>
<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc5" %>
<%@ Register Src="~/Contorls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<%@ Register Src="~/Contorls/ShoppingCartList.ascx" TagName="ShoppingCartList" TagPrefix="uc2" %>
<%@ Register Src="~/Contorls/UcAddOrder.ascx" TagName="UcAddOrder" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head11">
    <title>软件购买下单_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <uc4:Head ID="Head1" runat="server" />
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="750" valign="top">
                        <div id="ShoppingCartList">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT MB">
                                <tr>
                                    <td>
                                        <img src="/Images/Web/shop_wei1.jpg" width="750" height="30" /></td>
                                </tr>
                            </table>
                            <uc2:ShoppingCartList ID="ShoppingCartList1" runat="server" />
                            <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#D4D4D4"  runat="server" id="tbJingJiRen">
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
                                    <td bgcolor="#ffffff" align="left">
                                        <asp:UpdatePanel ID="upBroker" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chbIsJingJR" runat="server" Text="是否『彩神通』经纪人推荐" AutoPostBack="True" OnCheckedChanged="chbIsJingJR_CheckedChanged" />  &nbsp;&nbsp;&nbsp;
                                                <span id="spJingJR" runat="server" visible="false">
                                                经纪人用户名：<asp:TextBox ID="txtBrokerName" runat="server" Width="180px" OnTextChanged="txtBrokerName_TextChanged"
                                                    AutoPostBack="True" MaxLength="20"></asp:TextBox>（注：请如实填写，如果没有请留空！）</span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <uc3:UcAddOrder ID="AddOrder1" runat="server" OnAddOrders_Command="AddOrders_Command">
                            </uc3:UcAddOrder>
                        </div>
                    </td>
                    <td width="10">
                    </td>
                    <td valign="top" style="width: 242px">
                        <uc6:ShopServers ID="ShopServers1" runat="server" />
                    </td>
                </tr>
            </table>
            <uc5:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
