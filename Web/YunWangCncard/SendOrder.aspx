<%@ Page Language="c#" Codebehind="SendOrder.aspx.cs" AutoEventWireup="True" Inherits="Pbzx.Web.PortSampleForDotNet.SendOrder" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>订单提交成功页_拼搏在线彩神通软件 - 云网支付 </title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Submit1_onclick() {

}

// ]]>
    </script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form name="cnPayForm" action="https://www.cncard.net/purchase/getorder.asp" method="POST">
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
                    <table width="90%" border="0" cellpadding="8" cellspacing="0">
                        <tr>
                            <td class="order_14black" align="center">
                                您的订单<span class="order_14red"><%=c_order %></span> 已经提交，您需要支付：<span class="order_14red"><%= Convert.ToDecimal(c_orderamount).ToString("0.00")%></span>元</td>
                        </tr>
                        <tr>
                            <td class="order_14black" align="center">
                               </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="46%" border="0" align="center" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td>
                                            <img src="/Images/Web/yun_logo.jpg" width="157" height="40" alt="" border="0" /></td>
                                        <td>
                                            <input type="submit" name="submit" value=" " id="Submit1" class="order_sendbtn" onclick="return Submit1_onclick()"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="90%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td class="order_xia">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table width="89%" border="0" cellpadding="2" cellspacing="0" class="order_gray">
                        <tr>
                            <td align="left">
                                <input type="hidden" name="c_mid" value="<%=c_mid%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_order" value="<%=c_order%>"></td>
                          
                            <td align="left">
                                <input type="hidden" name="c_orderamount" value="<%=c_orderamount%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_ymd" value="<%=c_ymd%>"></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <input type="hidden" name="c_moneytype" value="<%=c_moneytype%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_retflag" value="<%=c_retflag%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_paygate" value="<%=c_paygate%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_returl" value="<%=c_returl%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_memo1" value="<%=c_memo1%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_memo2" value="<%=c_memo2%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_language" value="<%=c_language%>"></td>
                            <td align="left">
                                <input type="hidden" name="notifytype" value="<%=notifytype%>"></td>
                            <td align="left">
                                <input type="hidden" name="c_signstr" value="<%=c_signstr%>"></td>
                            <td align="left">
                                &nbsp;</td>
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
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
