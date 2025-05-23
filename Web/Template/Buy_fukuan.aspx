<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_fukuan.aspx.cs" Inherits="Pbzx.Web.Buy_fukuan" %>

<%@ Register Src="../Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>

<%@ Register Src="../Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>付款方式_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/buy.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />  
    <link href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <!--主体部分--->
            <div id="soft" class="bodyw MT">
                <!--左边--->
                <div id="Y_lw1">
                    <uc3:Buy_left ID="Buy_left1" runat="server" />
                </div>
                <!--右边--->
                <div id="Y_rw1">
                    <div class="Y_wei">
                        当前位置：<a href="/">拼搏在线彩神通软件</a> >> <a href="/SoftwarePrices.htm">注册购买</a> >> 付款方式
                    </div>
                    <div class="Y_box Y_r1 MT">
                        <div class="title">
                            <p>
                                <a href="#"><span>付款方式</span></a></p>
                        </div>
                        <div class="content">
                            <div>
                                <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="30" align="center" valign="bottom" class="Y_xia">
                                            付款方式</td>
                                    </tr>
                                    <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" align="center" cellpadding="12" cellspacing="1" bgcolor="#ECECEC">
                                    <tr>
                                        <td align="left" bgcolor="#FCFCFC">
                                            <strong>(一)网上支付</strong><br />
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
<%--                                                        &nbsp;&nbsp;&nbsp;&nbsp;我们为您提供银行卡在线支付（工商银行、农业银行、建设银行、招商银行、交通银行、邮政储蓄汇款）、网银在线、快钱、支付宝、财付通等支付方式。 --%>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;我们为您提供银行卡在线支付（工商银行、农业银行、建设银行、招商银行、交通银行、邮政储蓄汇款）、支付宝等支付方式。
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong>1.银行卡在线支付所支持的卡种有：</strong></td>
                                                </tr>
                                            </table>
                                            <table width="70%" border="0" cellpadding="4" cellspacing="1" bgcolor="#666666">
                                                <tr>
                                                    <td width="39%" align="center" bgcolor="#E1E1E1">
                                                        <strong>银行名称</strong></td>
                                                    <td width="61%" align="center" bgcolor="#E1E1E1">
                                                        <strong>支持网上支付的银行卡名称</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_zhaos.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        一卡通</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_gongs.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        借记卡</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_jians.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        龙卡储蓄卡</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/bank_nongy.jpg" width="140" height="30" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        借记卡</td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
                                                        <strong>2.网上支付平台所支持的银行卡种有：</strong></td>
                                                </tr>
                                            </table>
                                            <table width="70%" border="0" cellpadding="4" cellspacing="1" bgcolor="#666666">
                                                <tr>
                                                    <td colspan="2" align="center" bgcolor="#E1E1E1">
                                                        <strong>支付平台名称</strong></td>
                                                    <td width="31%" align="center" bgcolor="#E1E1E1">
                                                        <strong>支持银行卡种</strong></td>
                                                </tr>
                                                <%--<tr>
                                                    <td width="32%" align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/yunwang.jpg" /></td>
                                                    <td width="37%" align="center" bgcolor="#FFFFFF">
                                                        云网支付</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://www.cncard.net/bank/sustain.asp" target="_blank"><strong>点击查看</strong></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/wangyin.jpg" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        网银在线</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://www.chinabank.com.cn/gateway/china/cardtype.shtml" target="_blank"><strong>点击查看</strong></a></td>
                                                </tr>
                                                <tr>
                                                    <td  align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/kuaiqian.jpg" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        快钱支付</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://help.99bill.com/viewthread.php?tid=44547&amp;extra=page%3D1%26amp%3Bfilter%3Dtype%26amp%3Btypeid%3D41"
                                                            target="_blank"><strong>点击查看</strong></a></td>
                                                </tr>
                                                --%>
                                                <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/Pay_treasure.jpg" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        支付宝</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="http://help.alipay.com/lab/help_detail.htm?help_id=1193" target="_blank"><strong>点击查看</strong></a></td>
                                                </tr>
                                               <%-- <tr>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <img src="/Images/Web/y_cft.gif" /></td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        财付通（选择离线支付）</td>
                                                    <td align="center" bgcolor="#FFFFFF">
                                                        <a href="https://www.tenpay.com/" target="_blank"><strong>点击查看</strong></a></td>
                                                </tr> --%>
                                            </table>
                                            <%--  <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                <tr>
                                                    <td>
                                                        <table width="80%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    <span class="red">温馨提示：</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="height: 24px">
                                                                    （1）目前使用快钱网上支付单笔支付金额最高可达到1万元（不同的银行支付的金额不同）。</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    （2）快钱网上大额支付支持的银行有：工商银行、农业银行、建设银行和招商银行等。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            --%>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
                                                        <strong>3.怎样判断网上支付是否成功？</strong></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    （1）当您完成网上在线支付过程后，系统应提示支付成功；如果系统没有提示支付失败或成功，您可通过电话、ATM 、柜台或登录网上银行等各种方式查询银行卡余额，如果款项已被扣除，说明您已支付成功。</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="height: 24px">
                                                                    （2）如果出现存折余额不足、意外断线等导致支付不成功，请您到拼搏在线彩神通软件的“用户中心”，找到该笔未支付成功的订单，重新完成支付。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                <tr>
                                                    <td>
                                                        <strong>4.造成“支付被拒绝”的原因有哪些？</strong></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                <tr>
                                                    <td>
                                                        <table width="80%" cellpadding="2" cellspacing="0">
                                                            <tr>
                                                                <td width="49%" height="24" align="left">
                                                                    （1）所持银行卡尚未开通网上在线支付功能；</td>
                                                                <td width="51%" align="left">
                                                                    （2）所持银行卡已过期、作废、挂失；</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    （3）所持银行卡内余额不足；
                                                                </td>
                                                                <td align="left">
                                                                    （4）输入银行卡卡号或密码不符；</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    （5）输入证件号不符；
                                                                </td>
                                                                <td align="left">
                                                                    （6）银行系统数据传输出现异常；
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="24" align="left">
                                                                    （7）网络中断。</td>
                                                                <td align="left">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" align="center" cellpadding="12" cellspacing="1" bgcolor="#ECECEC">
                                    <tr>
                                        <td align="left" bgcolor="#FCFCFC">
                                            <strong>(二)银行转账</strong><br />
                                            <span class="red">注：银行汇款时最好加上一个零头以便确认，如汇款380.06；如果没有开通个人网上银行转账功能，也可以直接到银行柜台办理转帐汇款，需带身份证。以下是汇款账号信息（汇款后请及时与我们联系进行注册，具体见
                                                <a href="/ArtificialBuy.htm" class="red">注册购买说明</a>）</span><br />
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="http://www.bj.cmbchina.com/"><font color="#0000ff">招商银行</font></a><br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    卡&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>6225 8801 0299 0190</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    徐春华
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    开户行</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    北京招行海淀区万寿路支行</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    若已申请个人银行专业版可通过网上银行转账。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://mybank.icbc.com.cn/icbc/perbank/index.jsp"><font color="#0000ff">工商银行</font></a><br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    卡&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>9558 8002 0020 3039892</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    徐春华
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    开户行</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    北京工行海淀区五棵松桥东储蓄所</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    工商银行的“直通车”非常便捷，只要告知银行账号和姓名，以“直通车” 方式汇款，可立即到账。需带身份证。牡丹灵通卡也可用于网上银行转账。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://ibsbjstar.ccb.com.cn/index.html"><font color="#0000ff">建设银行</font></a><br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    卡&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>4367 4200 1315 0118 036</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    徐春华
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    开户行</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    建设银行北京市分行门头沟支行双峪路储蓄所<span lang="EN-US" style="font-size: 9pt; color: #336699; font-family: 宋体">
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    若已申请个人银行专业版可通过网上银行转账。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://www.95559.com.cn/personbank/servlet/com.bocom.eb.cs.html.EBEstablishSessionServlet?module=card">
                                                            <font color="#0000ff">交通银行</font></a><br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    卡&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>4055 1225 9195 70709</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    徐春华
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    开户行</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    北京交行海淀区公主坟支行</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    若已申请个人银行专业版可通过网上银行转账。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        <a href="https://www.95599bj.com.cn/Rbank/login.htm"><font color="#0000ff">农业银行</font></a><br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    卡&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>95599 8001 43116 58117</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    徐春华
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    开户行</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    北京农行海淀区万寿路支行西翠路分理处</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    银行汇款需带本人身份证。</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        邮政储蓄<br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    卡 &nbsp; &nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>6221501000004372504</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    <span style="background-color: #f4f7f7">徐春华</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    开户行</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    北京市海淀区万寿路支行
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    若已申请个人银行专业版可通过网上银行转账。
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#F4F7F7">
                                                <tr>
                                                    <td width="15%" align="center">
                                                        支付宝<br />
                                                        （即时到帐）</td>
                                                    <td width="85%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#111111">
                                                            <tr>
                                                                <td width="15%" align="center" bgcolor="#F4F7F7">
                                                                    帐 &nbsp; &nbsp;号</td>
                                                                <td width="85%" align="left" bgcolor="#F4F7F7">
                                                                    <b>alipay@pinble.com</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    收款人</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    <span style="background-color: #f4f7f7">徐春华</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bgcolor="#F4F7F7">
                                                                    备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                                                                <td align="left" bgcolor="#F4F7F7">
                                                                    只有离线方式下才需要用支付宝账号转账；在线方式下直接付款后即刻开通。
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <uc4:Uc_BuyHmenn ID="Uc_BuyHmenn1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
