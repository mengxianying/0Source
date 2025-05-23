<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Chat_Bulletin_list.aspx.cs"
    Inherits="Pinble_Chat.Chat_Bulletin_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head_Chat.ascx" TagName="Head_Chat" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>公告列表_语音视频聊彩室_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/chat.css" rel="stylesheet" type="text/css" />
    <link href="/css/blue/css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <script language="javascript" src="/javascript/public.js" type="text/javascript"></script>

    <script language="javascript" src="/javascript/Prototype.js" type="text/javascript"></script>

</head>

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

<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <uc2:Head_Chat ID="Head_Chat1" runat="server"></uc2:Head_Chat>
            <div class="bodyw MT">
                <!--左边--->
                <div class="ct_l1">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="24" background="/images/web/CT_lbg1.jpg" class="ct_title1">
                                用户指南</td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#55A3EF">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="75%" border="0" align="center" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx" class="ct_biao"
                                                target="_blank">用户注册</a></td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/userguide.htm" class="ct_biao" target="_blank">
                                                功能说明</a></td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://download2.pinble.com/softdown/MeChatUser8.exe" class="ct_biao">控件下载</a></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/allusers.htm" class="ct_biao" target="_blank">在线用户</a></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="javascript:OnFindUser();" class="ct_biao">聊友查寻</a></td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/top.htm" class="ct_biao" target="_blank">聊神榜</a></td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td align="left" class="ct_xia">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>RecoverPasswd1.aspx" class="ct_biao"
                                                target="_blank">密码找回</a></td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" /></td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/userhelp.htm" class="ct_biao" target="_blank">帮助中心</a></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td>
                                <img src="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Images/AD/ct_G2.jpg" width="210" /></td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td background="/images/web/CT_lbg2.jpg">
                                     <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 2px;">
                                    <tr>
                                        <td height="22" class="ct_title2">
                                            最新公告</td>
                                        <td valign="bottom" align="right">
                                            <a href="Chat_Bulletin_list.aspx" target="_self">>>更多</a>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9ACAFA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0" style="margin-top: 2px;">
                                    <tr>
                                        <td align="left">
                                            <uc3:Bulletin_r ID="Bulletin_r1" runat="server" Count="8" IntChannelID="10" TitleLength="30">
                                            </uc3:Bulletin_r>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--中间--->
                <div class="ct_r1">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="28" background="/images/Web/ct_cbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="12%" class="ct_title2">
                                            最新公告</td>
                                        <td width="88%" align="left" valign="bottom">
                                            <font color="blue"></font>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#4E9EEB">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <asp:Repeater ID="rpt_list" runat="server">
                                    <HeaderTemplate>
                                        <table width="96%" border="0" cellspacing="0" cellpadding="0" align="center" class="MT">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr bgcolor="#ffffff">
                                            <td width="3%" style="height: 27px">
                                                <img src="/Images/Web/B_li2.gif" width="11" height="10" /></td>
                                            <td width="79%" align="left">
                                                <a href="Chat_Bulletin_Show.aspx?ID=<%#Input.Encrypt(Eval("IntID").ToString()) %>"
                                                    target="_blank">
                                                    <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),76)%>
                                                </a>
                                            </td>
                                            <td width="18%">
                                                <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr bgcolor="#F0F1FF">
                                            <td width="3%" style="height: 27px">
                                                <img src="/Images/Web/B_li2.gif" width="11" height="10" /></td>
                                            <td width="79%" align="left">
                                                <a href="Chat_Bulletin_Show.aspx?ID=<%#Input.Encrypt(Eval("IntID").ToString()) %>"
                                                    target="_blank">
                                                    <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),76)%>
                                                </a>
                                            </td>
                                            <td width="18%">
                                                <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1">
                                    <tr>
                                        <td align="center">
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoTextAlign="Center"
                                                FirstPageText="首页┊" LastPageText="尾页" NextPageText="下一页┊" OnPageChanged="AspNetPager1_PageChanged"
                                                PrevPageText="上一页┊" ShowCustomInfoSection="Right" ShowNavigationToolTip="True"
                                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="25">
                                            </webdiyer:AspNetPager>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <uc4:Footer ID="Footer1" runat="server"></uc4:Footer>
            </div>
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
