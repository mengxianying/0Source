<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_lianxzhc.aspx.cs" Inherits="Pbzx.Web.Buy_lianxzhc" %>

<%@ Register Src="../Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>

<%@ Register Src="../Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人工购买_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/buy.css" rel="stylesheet" type="text/css" />
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
                        当前位置：<a href="/">拼搏在线彩神通软件</a> >> <a href="/SoftwarePrices.htm">注册购买</a> >> 人工购买
                    </div>
                    <div class="Y_box Y_r1 MT">
                        <div class="title">
                            <p>
                                <a href="#"><span>人工购买 </span></a>
                            </p>
                        </div>
                        <div class="content">
                            <div>
                                <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="30" align="center" valign="bottom" class="Y_xia">
                                            人工购买</td>
                                    </tr>
                                    <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                </table>
                                <table width="97%" border="0" align="center" cellpadding="15" cellspacing="1" bgcolor="#ECECEC">
                                    <tr>
                                        <td align="left" bgcolor="#FCFCFC">
                                            <span class="blue">『彩神通』软件为注册软件，『彩神通』软件需要不断完善和研发，离不开开发者的投入和使用者的支持，这一切都需要使用这个软件的用户的经济支持。热诚欢迎广大彩民朋友注册软件！只有注册用户才能享受我们更完善、更满意、更周到的服务。</span><br />
                                            <br />
                                            <b>一、注册流程</b><br />
                                            <table width="550" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td colspan="7" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <table width="98%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#BEBEBE">
                                                            <tr>
                                                                <td align="center" bgcolor="#D8D8D8">
                                                                    转账汇款</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center">
                                                        <img src="/Images/Web/buy_jian.jpg" border="0" /></td>
                                                    <td>
                                                        <table width="98%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#BEBEBE">
                                                            <tr>
                                                                <td align="center" bgcolor="#D8D8D8">
                                                                    联系客服</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center">
                                                        <img src="/Images/Web/buy_jian.jpg" border="0" /></td>
                                                    <td>
                                                        <table width="98%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#BEBEBE">
                                                            <tr>
                                                                <td align="center" bgcolor="#D8D8D8">
                                                                    提供注册信息</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center">
                                                        <img src="../Images/Web/buy_jian.jpg" border="0" /></td>
                                                    <td>
                                                        <table width="98%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#BEBEBE">
                                                            <tr>
                                                                <td align="center" bgcolor="#D8D8D8">
                                                                    注册成功</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <b>二、联系注册时需要提供哪些信息？</b><br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;1、单机绑定方式注册用户请提供软件认证码和您的姓名、电话、所在城市;<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2、软件狗方式注册用户请提供您的姓名、电话和详细地址。我们将为您邮寄软件狗，请一定要把邮寄地址留全,否则无法保证您及时准确地收到软件狗;在软件狗邮寄期间如需使用临时软件，还请提供您的网站用户名。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;3、网络方式注册用户请提供您在拼搏在线彩神通软件网站注册的用户名及您的真实姓名、电话、所在城市。
                                            <br />
                                            <b>三、注册联系方式</b>
                                            <table width="45%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="18%">
                                                        在线客服：</td>
                                                    <td width="82%">
                                                        <asp:DataList ID="dtQq" runat="server" Width="100%" RepeatColumns="6" RepeatDirection="Horizontal">
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <a href="tencent://message/?uin=<%# Eval("VarQQNumber")%>&Site=www.pinble.com&Menu=yes">
                                                                    <img src='http://wpa.qq.com/pa?p=1:<%# Eval("VarQQNumber")%>:8' border="0" alt="点击这里给我发消息" /></a>&nbsp;
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:DataList></td>
                                                </tr>
                                            </table>
                                            公司电话：010-62132803
                                            <br />
                                            工作时间：周一至周五9：30分至18：30分，国家法定节假日休息
                                            <br />
                                            E-MAIL：<a href="mailto:sale@pinble.com">sale@pinble.com</a>（非上班时间请采用邮件联系或<a href="/Soft.aspx" target="_blank">在线购买</a>方式）<br />
                                            <b>四、其它注意事项</b><br />
                                            为了维护您及其他正版软件用户的利益，请您在安装、使用本软件时注意并遵守以下原则：
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;1、按单机绑定方式注册保证每套只在一台计算机上安装并使用本软件，如需要再多台计算机上使用，请购买软件狗或选择网络注册方式。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;2、本公司只为按单机绑定方式注册的用户提供一次本软件安装所需的注册码，当更换硬盘或电脑以后注册码将会失效，因此在购买时必须确定是否购买软件狗。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;3、对于注册成单机绑定的注册用户想更换为软件狗注册方式，需另付最新公布的软件使用费的50%加软件狗的相关费用（成本费100元，快递费20元），而且只能更换一次。所以建议您在注册时选择软件狗注册方式。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;4、使用软件狗的用户购买软件时，公司只负责提供一次软件狗，如果用户丢失了软件狗，必须按该软件狗里安装的所有软件最新公布价格的50%
                                            + 软件狗的费用重新购买，并负担快递费，而且只能补发一次。如果丢失以后又找到了，也禁止使用原来的软件狗，否则，补发的软件狗也将被废止。<br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;5、『彩神通』系列软件的著作权及版权归拼搏在线（北京）科技发展有限公司所有。任何破解、盗版行为，都将构成侵权，将被追究法律责任。由于破解本软件或使用盗版软件造成硬盘故障和系统运行错误，本公司将不负任何责任。对于在非规范的设备上使用本软件造成的失误，本公司也将不负任何责任。为防止未经授权的非法使用，每套软件在注册后已内置认证识别码，如发现盗版软件的认证码和注册码来源于正版用户，则该正式用户的使用资格和升级权利将被永久废除。所以注册用户购买软件后，请勿把自己的软件认证码和注册码告诉无关人员（不管是有意还是无意行为），以免给您带来不必要的麻烦和损失。
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
