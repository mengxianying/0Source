<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Head_Chat2.ascx.cs"
    Inherits="Pinble_Chat.Contorls.Head_Chat2" %>
<%@ Register Src="Uc_Flash.ascx" TagName="Uc_Flash" TagPrefix="uc1" %>
<link type="text/css" href="/css/themes/base/ui.all.css" rel="stylesheet" />
<link href="/css/demos.css" rel="stylesheet" type="text/css" />
<link type="text/css" href="/css/css.css" rel="stylesheet" />
<link type="text/css" href="/css/demos.css" rel="stylesheet" />

<script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

<script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

<script type="text/javascript" src="/javascript/ui/effects.core.js"></script>

<script type="text/javascript" src="/javascript/ui/effects.highlight.js"></script>

<script language="javascript" type="text/javascript">

function OnFindUser() // 显示在线用户总列表
{
	var strUserName = prompt("请输入您要查找的用户名?", "找谁?") ;
	if(strUserName == null || strUserName == "找谁?" || strUserName.length <1)	return ;
	window.open("http://chat.pinble.com:8888//finduser.htm?FindUser="+strUserName,"_FindUser","toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,resizable=yes");
}


/*脚本定义完毕*/
//-->
</script>

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
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>" onmousemove="$('#a_Ask').addClass('platformSelect')"
                                        onmouseout="$('#a_Ask').removeClass('platformSelect')">
                                        <img src="/images/Web/head_icon7.jpg" alt="" border="0" /></a></td>
                                <td>
                                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx" onmousemove="$('#a_Broker').addClass('platformSelect')"
                                        onmouseout="$('#a_Broker').removeClass('platformSelect')">
                                        <img src="/images/Web/head_icon8.jpg" alt="" border="0" /></a></td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>" id="a_Ask">拼 搏 吧</a></td>
                                <td align="center">
                                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx" id="a_Broker">经
                                        纪 人</a></td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <tr>
                <td width="6"">
                    <img src="/images/web/help_mn_bgl.jpg" width="6" height="30" border="0"></td>
                <td width="938" background="/images/web/help_mn_bg.jpg"> 
                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx"  target="_blank">
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            用户注册</div>
                    </a><a href="/User_Help.aspx?myUrl=function" target="_self">
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            功能说明</div>
                    </a><a href="http://download2.pinble.com/softdown/MeChatUser8.exe">
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            控件下载</div>
                    </a><a href="/User_Help.aspx?myUrl=user" target="_blank"  target="_self">
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            在线用户</div>
                    </a><a href="javascript:OnFindUser();">
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            聊友查寻</div>
                    </a><a href="/User_Help.aspx?myUrl=model" target="_self" >
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            聊神榜</div>
                    </a> <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>RecoverPasswd1.aspx" target="_blank">
                        <div class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            密码找回</div>
                    </a><a href="/User_Help.aspx?myUrl=help" target="_self">
                        <div  class="help_meun" onmouseover="this.className='help_over'" onmouseout="this.className='help_out'">
                            帮助中心</div>
                    </a>
                </td>
                <td width="6">
                    <img src="/images/web/help_mn_bgr.jpg" width="6" height="30" border="0"></td>
            </tr>
        </tbody>
    </table>
</div>
