<%@ Page Language="C#" AutoEventWireup="true" Inherits="Send" Codebehind="Send.aspx.cs" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单提交成功页 - 网银在线支付 - 拼搏在线彩神通软件</title>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%--onLoad="javascript:document.E_FORM.submit()" --%>
    <form action="https://pay3.chinabank.com.cn/PayGate" method="post" name="E_FORM">
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
                                您的订单<span class="order_14red"><%=v_oid %></span> 已经提交，您需要支付：<span class="order_14red"><%= Convert.ToDecimal(v_amount).ToString("0.00")%></span>元</td>
                        </tr>
                        <tr>
                            <td class="order_14black" align="center">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="40%" border="0" align="center" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td>
                                            <img src="../Images/Web/wangyin.jpg" width="111" height="44" alt="" border="0" /></td>
                                        <td>
                                            <input type="submit" name="submit" value=" " id="Submit1" class="order_wangyinbtn" /></td>
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
                            <td align="left" colspan="5">
                                <input type="hidden" name="v_md5info" value="<%=v_md5info%>" size="100" /></td>
                            <td align="left">
                                <input type="hidden" name="v_mid" value="<%=v_mid%>" /></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <input type="hidden" name="v_oid" value="<%=v_oid%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_amount" value="<%=v_amount%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_moneytype" value="<%=v_moneytype%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_url" value="<%=v_url%>" /></td>
                            <!--以下几项项为网上支付完成后，随支付反馈信息一同传给信息接收页-->
                            <td align="left">
                                <input type="hidden" name="remark1" value="<%=remark1%>" /></td>
                            <td align="left">
                                <input type="hidden" name="remark2" value="<%=remark2%>" /></td>
                        </tr>
                        <tr>
                            <!--以下几项只是用来记录客户信息，可以不用，不影响支付 -->
                            <td align="left">
                                <input type="hidden" name="v_rcvname" value="<%=v_rcvname%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_rcvaddr" value="<%=v_rcvaddr%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_rcvtel" value="<%=v_rcvtel%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_rcvpost" value="<%=v_rcvpost%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_rcvemail" value="<%=v_rcvemail%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_rcvmobile" value="<%=v_rcvmobile%>" /></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <input type="hidden" name="v_ordername" value="<%=v_ordername%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_orderaddr" value="<%=v_orderaddr%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_ordertel" value="<%=v_ordertel%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_orderpost" value="<%=v_orderpost%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_orderemail" value="<%=v_orderemail%>" /></td>
                            <td align="left">
                                <input type="hidden" name="v_ordermobile" value="<%=v_ordermobile%>" /></td>
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
