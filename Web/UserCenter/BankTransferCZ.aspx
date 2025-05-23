<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankTransferCZ.aspx.cs" Inherits="Pbzx.Web.UserCenter.BankTransferCZ" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>订单提交成功页_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                    &nbsp;
                </td>
                <td width="970" align="center" bgcolor="#FFFFFF">
                    <br />
                    <table width="95%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7%" align="center">
                                <img src="../Images/Web/order_bankli.jpg" width="38" height="35"></td>
                            <td width="93%" align="left" class="order_18black">

                                您的订单<span  color="red" ><%=c_order %></span> 已经提交，您需要支付：<span class="order_14red"><%=c_orderamount.ToString("0.00")%>元</span>；如果您已汇款，请点击 “<a href="/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx" target="_blank" style="font-size:14px;">我的帐户</a>”进行汇款确认。</td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                            <td align="left">
                                款项到达拼搏在线彩神通软件帐户后，我们将会为您充值。</td>
                        </tr>
                    </table>
                    <table width="90%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="12">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" cellpadding="0" cellspacing="0" bgcolor="#81BBF5">
                        <tr>
                            <td height="1">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" cellpadding="18" cellspacing="1" bgcolor="#81BBF5">
                        <tr>
                            <td bgcolor="#ECF1FF">
                                <table width="100%" border="0" cellpadding="5" cellspacing="0" bgcolor="#FFFFFF">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <b>请您按照以下帐户汇款：</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <font color="red">注:</font>银行汇款时最好加上一个零头以便确认，如汇款
                                                        <asp:Label ID="lblMoney" runat="server" Text=""></asp:Label>
                                                        ；如果没有银行卡也可以直接到银行做银行转帐或个人电子汇款,需带身份证，请务必在电汇单的用途栏内注明订单号！</td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellpadding="4" cellspacing="0">
                                                <tr>
                                                    <td width="46%" valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://ibsbjstar.ccb.com.cn/index.html" target="_blank">
                                                                                    <img src="/Images/Web/bank_jians.jpg" border="0" align="absmiddle"></a>(即时到帐)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                开户行：建设银行北京市分行门头沟支行双峪路储蓄所<span lang="EN-US" style="font-size: 9pt; color: #336699;
                                                                                    font-family: 宋体"> </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                卡&nbsp;&nbsp;号：4367 4200 1315 0118 036</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                备&nbsp;&nbsp;注：若已申请个人银行专业版可通过网上银行转账</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="46%" valign="top">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="http://www.bj.cmbchina.com/" target="_blank">
                                                                                    <img src="/Images/Web/bank_zhaos.jpg" border="0" align="absmiddle"></a>(即时到帐)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                开户行：北京招行海淀区万寿路支行</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                卡&nbsp;&nbsp;号：6225 8801 0299 0190</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                备&nbsp;&nbsp;注：若已申请个人银行专业版可通过网上银行转账</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="8%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://mybank.icbc.com.cn/icbc/perbank/index.jsp" target="_blank">
                                                                                    <img src="/Images/Web/bank_gongs.jpg" border="0" align="absmiddle"></a>(即时到帐)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                开户行：北京工行海淀区五棵松桥东储蓄所</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                卡&nbsp;&nbsp;号：9558 8002 0020 3039892</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                备&nbsp;&nbsp;注：工商银行的“直通车”非常便捷，只要告知银行账号和姓名，以“直通车” 方式汇款，可立即到账。需带身份证。牡丹灵通卡也可用于网上银行转账。</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://www.95559.com.cn/personbank/servlet/com.bocom.eb.cs.html.EBEstablishSessionServlet?module=card"
                                                                                    target="_blank">
                                                                                    <img src="/Images/Web/bank_jiaot.jpg" border="0" align="absmiddle"></a>(即时到帐)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                开户行：北京交行海淀区公主坟支行</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                卡&nbsp;&nbsp;号：405512 2591 9570709</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                备&nbsp;&nbsp;注：若已申请个人银行专业版可通过网上银行转账</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <a href="https://www.95599bj.com.cn/Rbank/login.htm" target="_blank">
                                                                                    <img src="/Images/Web/bank_nongy.jpg" border="0" align="absmiddle"></a>(即时到帐)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                开户行：北京农行海淀区万寿路支行西翠路分理处</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                卡&nbsp;&nbsp;号：95599 8001 43116 58117</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                备&nbsp;&nbsp;注：银行汇款需带本人身份证。</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <img src="/Images/Web/bank_post.jpg" border="0" align="absmiddle">(即时到帐)</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                开户行：北京市海淀区沙窝邮电所</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                卡&nbsp;&nbsp;号：95510 01000 01091 2584</td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                备&nbsp;&nbsp;注：若已申请个人银行专业版可通过网上银行转账</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td bgcolor="#FFFFFF">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                <img src="/Images/Web/y_cft.gif" border="0" align="absmiddle"></td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                收款人：徐春华
                                                                            </td>
                                                                        </tr>
                                                                        <tr bgcolor="#ffffff">
                                                                            <td align="left" bgcolor="#ffffff">
                                                                                财付通账号：tenpay@pinble.com</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                      <table width="93%" border="0" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                    <tr>
                                        <td align="left">
                                            <strong>提示：</strong></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="font-size:14px; color:Red">
                                            * 当您付款完毕后，需要在“<a href="/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx" target="_blank" style="font-size:14px;">我的帐户</a>”中选择您的订单，然后点击订单号对您的订单继续处理！<br />
                                            <br />
                                            * 当您的订单通过管理员审核之后，我们会为您的账号充值，请登录“<a href="/UserCenter/User_Center.aspx" target="_blank" style="font-size:14px;">用户中心</a>”，在“<a
                                                href="/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx" target="_blank" style="font-size:14px;">我的帐户</a>”中查看处理结果。
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
<%--                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="imgNoPay" ImageUrl="/Images/Web/orderz_btnContinue.gif" runat="server"
                                    AlternateText="订单继续处理" OnClick="img_Click" align="absmiddle" /></td>
                        </tr>
                    </table>--%>
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
                    <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" /></td>
                <td background="/Images/Web/order_bg3b.jpg" style="height: 4px">
                </td>
                <td style="height: 4px">
                    <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" /></td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>

