<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Head_ChatHav.ascx.cs" Inherits="Pinble_Chat.Contorls.Head_ChatHav" %>

<link type="text/css" href="/css/themes/base/ui.all.css" rel="stylesheet" />
<link href="/css/demos.css" rel="stylesheet" type="text/css" />
<%--<link type="text/css" href="/css/css.css" rel="stylesheet" />--%>
<%--<link type="text/css" href="/css/demos.css" rel="stylesheet" />--%>

<script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

<script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

<script type="text/javascript" src="/javascript/ui/effects.core.js"></script>

<script type="text/javascript" src="/javascript/ui/effects.highlight.js"></script>

<script type="text/javascript" src="/javascript/Header.js"></script>

<script type="text/javascript"  src="/javascript/CustomService.js"></script>

<!--网站栏目导航--->
<div class="margin0auto">
    <div class="bg1">
        <div class="logoNew">
            <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="158" height="72" align="center">
                        <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                    </td>
                </tr>
            </table>
        </div>
                <div class="nav_Has_been_selected">
            <a href="http://www.pinble.com" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">首页</a>
        </div>
        <asp:Repeater ID="data_nav" runat="server">
        <ItemTemplate>
            <div class="nav_Not_selected1">
                                <a href='<%# Eval("P_pfPath") %>' target="_blank">
                                    <%# Eval("P_pfName")%></a>
                            </div>
        </ItemTemplate>
        </asp:Repeater>
        
    </div>
    <div class="nav_Navigation" id="zdh">
        <ul>
            <li class="nav_l_no"><a href="http://www.pinble.com" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                拼搏首页</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Bulletin.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                网站公告</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>News.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                新闻资讯</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Soft.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                软件商城</a></li>
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