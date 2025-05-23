<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Login.aspx.cs" Inherits="Pinble_Ask.Login" %>

<%@ Register Src="Contorls/UcSearch.ascx" TagName="UcSearch" TagPrefix="uc5" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Register Src="Contorls/UcLogin.ascx" TagName="UcLogin" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> 用户登录_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
.blue14 {
	font-size: 14px;
	font-weight: 600;
	color: #135AAA;
}
-->
</style>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript"  src="/javascript/SearchAjax.js"></script>
    <script type="text/javascript"  src="/javascript/CustomService.js"></script>
</head>
<body>
    <form id="form1" runat="server" onkeydown="if(event.keyCode==13){return false;}">
        <div>
            <div class="main">
                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td align="left" style="height: 25px">
                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>">网站首页</a>&nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Bulletin.htm">网站公告</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>News.htm">新闻资讯</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Soft.aspx">软件商城</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>SoftwarePrices.htm">注册购买</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Source.aspx">资源下载</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Lottery.htm">开奖信息</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>graph.htm">数据图表</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>School.htm">软件学院</a>
                            &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx">经纪人</a>
                            &nbsp;&nbsp;<a href="http://bbs.pinble.com">论坛</a>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class="main">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="13%" align="right" valign="top">
                            <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="158" height="72" align="center">
                                        <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="12%">
                            <a href="<%=Pbzx.Common.WebInit.ask.WebUrl%>">
                                <img src="/images/A_Logo.jpg" width="120" height="58" border="0" /></a></td>
                        <td width="2%">
                        </td>
                        <td align="left" colspan="4">
                            <uc5:UcSearch ID="UcSearch1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <table width="750" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" height="35">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="370">
                        <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">
                                    <img src="images/Web/l_l_title.gif" width="160" height="58" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="images/Web/l_lbg1.gif" width="320" height="10" /></td>
                            </tr>
                            <tr>
                                <td background="images/Web/l_lbg2.gif">
                                    <uc3:UcLogin ID="UcLogin1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="images/Web/l_lbg3.gif" width="320" height="10" /></td>
                            </tr>
                            <tr>
                                <td height="38">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="80" background="images/Web/l_center.gif" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td width="300" valign="top">
                        <table width="280" border="0" align="center" cellpadding="4" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <img src="images/Web/l_r-title.jpg" width="150" height="50" /></td>
                            </tr>
                            <tr>
                                <td align="left" class="blue14">
                                    如果您还不是拼搏会员？</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <img src="images/Web/l_li.jpg" width="6" height="11" hspace="3" />请先注册一个免费会员后，登录查看。</td>
                            </tr>
                            <tr>
                                <td height="50" align="center">
                                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>/Register.aspx">
                                        <img src="images/Web/l_register.jpg" width="132" height="28" border="0" /></a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="30">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <uc2:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
