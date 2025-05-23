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
                                <uc1:Uc_Flash ID="Uc_Flash1" runat="server" PlaceType="����Flash" />
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
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>" id="a_Ask">ƴ �� ��</a></td>
                                <td align="center">
                                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx" id="a_Broker">�� �� ��</a></td>
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
<!--��վ��Ŀ����--->
<div class="bodyw">
    <div class="menu">
        <ul class="menu_li">
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ƴ����ҳ</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Bulletin.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ��վ����</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>News.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ������Ѷ</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Soft.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                �����̳�</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>SoftwarePrices.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ע�Ṻ��</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Source.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ��Դ����</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Lottery.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ������Ϣ</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>graph.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ����ͼ��</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>School.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ���ѧԺ</a></li>
            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.ChatUrl %>" onmouseover="this.style.color='#000000'"
                onmouseout="this.style.color='#ffffff'">�����Ĳ�</a></li>
            <li><a href="http://bbs.pinble.com/" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                ƴ����̳</a></li>
        </ul>
    </div>
</div>
