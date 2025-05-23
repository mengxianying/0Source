<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Contact.aspx.cs" Inherits="Pbzx.Web.Contact" EnableViewState="false" %>

<%@ Register Src="Contorls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>联系我们_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc2:Head ID="Head1" runat="server"></uc2:Head>
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                <tr>
                    <td width="190" valign="top" background="images/web/AB_lbg1.jpg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/web/AB_l1.jpg" width="190" height="30" /></td>
                            </tr>
                        </table>
                        <table width="190" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="10">
                                    &nbsp;</td>
                                <td width="180" valign="top">
                                    <uc1:AboutMenu ID="AboutMenu1" runat="server"></uc1:AboutMenu>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="10">
                    </td>
                    <td width="790" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/web/AB_banner.jpg" width="790" height="90" /></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="2%" height="25">
                                    <img src="images/web/AB_li.jpg" width="14" height="13" /></td>
                                <td width="98%" align="left" valign="bottom">
                                    你的当前位置：拼搏在线&gt;&gt;联系我们</td>
                            </tr>
                        </table>
                        <table width="100%" height="28" border="0" cellpadding="0" cellspacing="0" background="images/web/AB_weibg.jpg">
                            <tr>
                                <td width="5%">
                                    &nbsp;</td>
                                <td width="95%" align="left" style="padding-top: 4px;">
                                    <strong>联系我们</strong></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="6">
                            <tr>
                                <td align="left" valign="top">
                                    <table width="80%" border="0" align="center" cellpadding="4" cellspacing="0">
                                        <tr>
                                            <td align="center">
                                                <strong>联系我们</strong></td>
                                        </tr>
                                    </table>
                                    <table width="90%" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#CCCCCC">
                                        <tr>
                                            <td width="20%" align="right" bgcolor="#FFFFFF">
                                                公司电话：</td>
                                            <td width="80%" align="left" bgcolor="#FFFFFF">
                                                010-62132803 （软件注册时间为星期一至星期五 9:00—17:00）
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                市场销售部Email：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                sale@pinble.com
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                技术支持部Email：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                service@pinble.com</td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                网站运行部Email：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                webmaster@pinble.com</td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                软件注册QQ：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                416883852</td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                软件咨询QQ：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                416883852</td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                短信客服QQ：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                416883852</td>
                                        </tr>
<%--                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF" style="height: 27px">
                                                技术支持QQ：</td>
                                            <td align="left" bgcolor="#FFFFFF" style="height: 27px">
                                                464006494</td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                市场推广QQ：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                               524669918</td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                广告服务QQ：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                524669918</td>
                                        </tr>
                                        <tr>
                                            <td align="right" bgcolor="#FFFFFF">
                                                公司地址：</td>
                                            <td align="left" bgcolor="#FFFFFF">
                                                北京市海淀区大慧寺19号院9号楼608室 （邮编：100081）</td>
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
