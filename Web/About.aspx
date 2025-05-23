<%@ Page Language="C#" AutoEventWireup="true" Codebehind="About.aspx.cs" Inherits="Pbzx.Web.About"
    EnableViewState="false" %>

<%@ Register Src="Contorls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司简介_拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩神通,拼搏在线" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />   
    <link href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
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
                                    你的当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'>拼搏在线彩神通软件</a>&gt;&gt;<asp:Label
                                        ID="lblWeiTitle" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <table width="100%" height="28" border="0" cellpadding="0" cellspacing="0" background="images/web/AB_weibg.jpg">
                            <tr>
                                <td width="5%">
                                    &nbsp;</td>
                                <td width="95%" align="left" style="padding-top: 4px;">
                                    <strong>
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label></strong></td>
                            </tr>
                        </table>

                        <table width="100%" border="0" cellspacing="0" cellpadding="6">
                            <tr>
                                <td align="left" valign="top">
                                    <p>
                                        <asp:Label ID="lblContent" runat="server"></asp:Label></p>
<!--
                                       <iframe width="600px" height="592px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://map.sogou.com/card/index+s=600,360&p=1111&m=go2map&d=cor_1365313514994460.html#c=12949499,4831312,14"></iframe>
-->
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </div>
        <uc3:Footer ID="Footer1" runat="server"></uc3:Footer>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
