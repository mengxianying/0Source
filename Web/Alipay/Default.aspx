<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=EDGE" />
    <title>订单提交成功页 - 支付宝付款 - 拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
    <body>
       <form  id="form1" runat="server">
            <uc1:Head ID="Head2" runat="server"/>
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
                                    您的订单<span class="order_14red"><%=v_oid %></span> 已经提交，您需要支付：<span class="order_14red"><%=amount %>元</span></td>
                            </tr>
                            <tr>
                                <td class="order_14black" align="center">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="44%" border="0" align="center" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td>
                                                <img src="/images/web/Pay_treasure.jpg" width="111" height="44" alt="" border="0" /></td>
                                            <td>                
<!-- <input type="submit" name="submit" value="付款" id="Submit1" class="order_wangyinbtn" onclick="return Submit1_onclick()" />  -->                          
                                                <asp:Button ID="ibtnFK" runat="server" Text="" CssClass="order_zhifubaobtn" OnClick="BtnAlipay_Click" /> </td>
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
            <table>
                <tr>
                    <td>                     
                    </td>
                </tr>
            </table>
            <uc2:Footer ID="Footer1" runat="server" />
        </form>
    </body>
</html>
