<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Head_Chat.ascx.cs" Inherits="Pbzx.Web.Contorls.Head_Chat" %>
<%@ Register Src="Uc_Flash.ascx" TagName="Uc_Flash" TagPrefix="uc1" %>


<link type="text/css" href="/css/themes/base/ui.all.css" rel="stylesheet" />
<link href="/css/demos.css" rel="stylesheet" type="text/css" />
<link type="text/css" href="/css/css.css" rel="stylesheet" />
<link type="text/css" href="/css/demos.css" rel="stylesheet" />

<script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

<script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

<script type="text/javascript" src="/javascript/ui/effects.core.js"></script>

<script type="text/javascript" src="/javascript/ui/effects.highlight.js"></script>

<script type="text/javascript" src="/javascript/Header.js"></script>

<script type="text/javascript"  src="/javascript/CustomService.js"></script>

<div id="header" class="bodyw">
    <div class="logo">
        <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="158" height="72" align="center">
                    <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                </td>
            </tr>
        </table>
    </div>
    <div class="Topmenu">
        <div class="Icon">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="2" align="right" width="100%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="87%" height="73" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="96%" height="62" align="center">
                                <uc1:Uc_Flash ID="Uc_Flash1" runat="server" PlaceType="顶部Flash" />
                                </td>
                                <td width="4%">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="13%">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>">
                                        <img src="/images/Web/head_icon7.jpg" alt="" border="0" /></a></td>
                                <td>
                                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx">
                                        <img src="/images/Web/head_icon8.jpg" alt="" border="0" /></a></td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>" id="a_Ask">拼 搏 吧</a></td>
                                <td align="center">
                                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx" id="a_Broker">经 纪 人</a></td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<!--网站栏目导航--->
<div class="bodyw">
    <div class="menu">
        <ul class="menu_li">
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                拼搏首页</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Bulletin.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                网站公告</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>News.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                新闻资讯</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Soft.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                网上商城</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>SoftwarePrices.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                注册购买</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Source.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                资源下载</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Lottery.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                开奖信息</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>graph.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                数据图表</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>School.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                软件学院</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.ChatUrl %>" onmouseover="this.style.color='#000000'"
                onmouseout="this.style.color='#ffffff'">语音聊彩</a></li>
            <li><a href="http://bbs.pinble.com/" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                拼搏论坛</a></li>
        </ul>
    </div>
</div>
