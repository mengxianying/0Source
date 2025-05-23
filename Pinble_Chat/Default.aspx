<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pinble_Chat._Default" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc5" %>
<%@ Register Src="Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc3" %>

<%@ Register Src="Contorls/Head_Chat.ascx" TagName="Head_Chat" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>语音视频聊彩室_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/chat.css" rel="stylesheet" type="text/css" />
    <link href="/css/blue/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/XYTipsWindow.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <script language="javascript" src="/javascript/public.js" type="text/javascript"></script>
    <script language="javascript" src="/javascript/Prototype.js" type="text/javascript"></script>




    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<script language="javascript" type="text/javascript">
    function OnFindUser() // 显示在线用户总列表
    {
        var strUserName = prompt("请输入您要查找的用户名?", "找谁?");
        if (strUserName == null || strUserName == "找谁?" || strUserName.length < 1) return;
        window.open("http://chat.pinble.com:8888//finduser.htm?FindUser=" + strUserName, "_FindUser", "toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,resizable=yes");
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
                <div class="ct_l1" style="float: left; width:206px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="24" background="/images/web/CT_lbg1.jpg" class="ct_title1">
                                用户指南
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#55A3EF">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="75%" border="0" align="center" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx" class="ct_biao"
                                                target="_blank">用户注册</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/userguide.htm" class="ct_biao" target="_blank">
                                                功能说明</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://download2.pinble.com/softdown/MeChatUser8.exe" class="ct_biao">控件下载</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/allusers.htm" class="ct_biao" target="_blank">在线用户</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td width="80%" align="left" class="ct_xia">
                                            <a href="javascript:OnFindUser();" class="ct_biao">聊友查寻</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/top.htm" class="ct_biao" target="_blank">聊神榜</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>RecoverPasswd1.aspx" class="ct_biao"
                                                target="_blank">密码找回</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ct_xia">
                                            <img src="/images/web/ct_li1.jpg" width="4" height="9" />
                                        </td>
                                        <td align="left" class="ct_xia">
                                            <a href="http://chat.pinble.com:8888/userhelp.htm" class="ct_biao" target="_blank">帮助中心</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <uc1:UcPicAds ID="UcPicAds1" runat="server" PlaceType="聊彩室左一" />
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td background="/images/web/CT_lbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 2px;">
                                    <tr>
                                        <td height="22" class="ct_title2">
                                            最新公告
                                        </td>
                                        <td valign="bottom" align="right">
                                            <a href="Chat_Bulletin_list.aspx" target="_self">>>更多</a>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9ACAFA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0">
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td background="/images/web/CT_lbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 2px;">
                                    <tr>
                                        <td height="22" class="ct_title2">
                                            在线客服
                                        </td>
                                        <td valign="bottom" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9ACAFA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <uc5:UC_QQ ID="UC_QQ1" runat="server"></uc5:UC_QQ>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--中间--->
                <div class="ct_r1" style="float: right;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="1">
                        <tr>
                            <td height="28" background="/images/Web/ct_cbg1.jpg" align="center">
                                <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left">
                                            <div id="Login" runat="server">
                                                &nbsp;用户名：<asp:TextBox ID="txtName" runat="server" Width="110px" Style="margin-top: 2px;
                                                    margin-bottom: 2px;" MaxLength="12"></asp:TextBox>&nbsp; 密&nbsp;码：<asp:TextBox ID="txtPWD"
                                                        runat="server" MaxLength="16" Width="110px" Style="margin-top: 2px; margin-bottom: 2px;"
                                                        TextMode="Password"></asp:TextBox>&nbsp; 验证码：<asp:TextBox ID="txtCode" MaxLength="4"
                                                            onkeyup="CheckYZM(this.value,'1','','imgOKH','imgErrorH')" runat="server" Width="46px"></asp:TextBox>
                                                <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="top"
                                                    id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" /><img
                                                        alt="正确" src="/Images/Web/note_ok.gif" id="imgOKH" style="display: none;" />
                                                <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorH" style="display: none;" />&nbsp;&nbsp;<asp:CheckBox
                                                    ID="chbState" runat="server" Text="保存我的登录状态" />&nbsp;
                                                <asp:ImageButton ID="ibtnLogin" runat="server" AlternateText="登录拼搏" OnClick="ibtnLogin_Click"
                                                    ImageUrl="~/Images/Web/Lo.jpg" align="absmiddle" CausesValidation="False" />
                                            </div>
                                            <div id="hasLogin" runat="server" visible="false">
                                                欢迎： <font color="blue">
                                                    <asp:Label ID="lblUName" runat="server" Text=""></asp:Label></font> &nbsp;<asp:Label
                                                        ID="lblMessage" runat="server" Text="Label"></asp:Label>
                                                <%--昵称：<font color="blue"><asp:Label ID="lblAlias" runat="server" Text=""></asp:Label></font>--%>
                                                &nbsp;&nbsp;头衔：<font color="blue"><asp:Label ID="lblAge" runat="server" Text=""></asp:Label></font>
                                                &nbsp;&nbsp;级别：<font color="blue"><asp:Label ID="lblGrade" runat="server" Text=""></asp:Label></font>
                                                &nbsp;&nbsp;上一次登录时间：<font color="blue"><asp:Label ID="lblLogoutTime" runat="server"
                                                    Text=""></asp:Label></font> &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/User_Center.aspx"
                                                        target="_blank"><img src="/images/web/user_center.jpg" border="0" id="IMG1" align="middle" /></a>&nbsp;<asp:ImageButton
                                                            ID="ibtnLoginOut" runat="server" AlternateText="退出登录" ImageUrl="~/Images/Web/LoginOut.jpg"
                                                            align="middle" CausesValidation="False" OnClick="ibtnLoginOut_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <span id="address"></span>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="MT">
                        <tr>
                            <td height="28" background="/images/Web/ct_cbg2.jpg">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="12%" class="ct_title2">
                                            聊彩室
                                        </td>
                                        <td width="88%" align="left" valign="bottom">
                                            <font color="blue">提示：输入拼搏在线论坛用户名和密码，登录后点击房间名称即可进入聊彩室。</font>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#4E9EEB">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <iframe runat="server" name="chatmain" id="chatmain" frameborder="0" scrolling="no"
                                    style="overflow: visible; width: 740px; height: 272px; background-color: #f7f7f7;"
                                    src="http://chat.pinble.com:8888/index.htm"></iframe>
                            </td>
                        </tr>
                    </table>
                    <uc1:UcPicAds ID="UcPicAds2" runat="server" PlaceType="聊彩室中一" />
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT">
                        <tr>
                            <td width="550" valign="top">
                                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#4E9EEB">
                                    <tr bgcolor="#ffffff">
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="26" align="left" background="/images/Web/ct_cbg3.jpg">
                                                        &nbsp;&nbsp;<strong>注意事项：</strong>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="98%" border="0" align="center" cellpadding="8" cellspacing="0">
                                                <tr>
                                                    <td align="left" height="56">
                                                        1、听不到声音的或者声音断断续续的，请退出聊彩室后[下载]并安装最新语音插件；<br />
                                                        2、聊彩室内不得谈论与本房间无关的话题，严禁做广告，遵守聊彩室的各项规定！
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="10">
                            </td>
                            <td width="210" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="25" background="/images/web/CT_Rbg1.jpg" class="ct_title2">
                                            工具下载
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#4E9EEB">
                                    <tr>
                                        <td bgcolor="#FFFFFF">
                                            <table width="98%" border="0" align="center" cellpadding="4" cellspacing="0">
                                                <tr>
                                                    <td align="left">
                                                        <a href="http://download2.pinble.com/softdown/MeChatUser8.exe">·语音视频控件下载</a><br />
                                                        <a href="http://chat.pinble.com:8888/userhelp.htm#f1">·如何进入语音视频聊彩室</a><br />
                                                        <a href="http://www.pinble.com/Source_explain.aspx?ID=10209B5254442924" target="_blank">
                                                            ·语音聊彩室操作指南录像</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <uc1:UcPicAds ID="UcPicAds3" runat="server" Direction="1" PlaceType="聊彩室中二" />
                    <%--              <div id="Synchronous" style="display: none; width:480px; height:360px;">
                    <table id="TongBu" runat="server">
                        <tr>
                            <td>
                                <table style="width: 100%; margin: 5px auto;" border="0" align="center" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td align="center" class="red">
                                            聊彩室同步敬告</td>
                                    </tr>
                                    <tr>
                                        <td class="blue">
                                            &nbsp; 一、为什么要同步？<br />
                                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 由于网站升级，为了解决用户名和密码过多难以记忆的烦恼，本系统决定采用用户名密码统一管理，您只要注册一次，本系统所有平台，您都无需再注册，为了保持原聊彩室用户的级别和权限等资料，需要您初次登录新聊彩室后同步一次。<br />
                                            &nbsp;二、注意事项<br />
                                            &nbsp;1、同步后您必须使用论坛用户名和密码登录，原聊彩室用户名和密码作废，每个用户只能同步一次。一次后本功能消失。<br />
                                            &nbsp;2、如果您是原聊彩室用户，输入资料后点“同步”按钮，如果您是新用户，无需输入原聊彩室用户名和密码，请直接点击“新用户”按钮。<br />
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="blue">
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <table style="width: 100%; height: 106px;" border="0" align="center" cellpadding="0"
                                    cellspacing="0" class="kuang_line">
                                    <tr>
                                        <td valign="top">
                                            <form id="form2" name="form1" method="post" action="chat_user.asp">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="blue">
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            聊彩室同步</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="47%">
                                                            论坛用户名：</td>
                                                        <td width="53%">
                                                            <asp:TextBox ID="txtBbsName" runat="server" Width="140px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            论坛的密码：</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsPWD" runat="server" TextMode="Password" Width="140px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            原聊彩室用户名：</td>
                                                        <td>
                                                            <asp:TextBox ID="txtLcsName" runat="server" Width="140px" MaxLength="20"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            原聊彩室密码：</td>
                                                        <td>
                                                            <asp:TextBox ID="txtLcsPWD" runat="server" Width="140px" MaxLength="20" TextMode="Password"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            验证码：</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCode" MaxLength="4" onKeyDown="{if (event.keyCode==13) return chk_userfrm();}"
                                                                runat="server" Width="50px"></asp:TextBox>
                                                            <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                                                id="imgVerify" onclick="this.src=this.src+'?'" style="width: 80px; height: 25px" />
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="2">
                                                        <table style="width:100%">
                                                            <tr>
                                                                <td>
                                                                     <asp:Button ID="btnTB" runat="server" Text="同  步" OnClick="btnTB_Click" />
                                                                </td>
                                                                <td>
                                                                 <asp:Button ID="btnNew" runat="server" Text="新用户" OnClick="btnNew_Click" />
                                                                </td>
                                                                <td>
                                                                 <input ID="btncannel"  type="button" value="取消" />
                                                                </td>
                                                            </tr>
                                                        
                                                        </table>
                                                           
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </form>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>--%>
                </div>
        </div>
        <uc4:Footer ID="Footer1" runat="server"></uc4:Footer>
    </div>
    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="/javascript/jquery.XYTipsWindow.2.7.js" ></script>
        <script type="text/javascript">
            //提示
            function cue(name) {
                $.ajax({
                    type: 'POST',
                    url: '/Reg.aspx',
                    data: 'cueName=' + escape(name),
                    cache: false,
                    complete: function (msgcue, textStatus1) {
                        // unblock when remote call returns 
                        if (msgcue.responsetext == "true") {
                            var txt = "<div style=\"font-size:14px; width:500px; text-align:left; margin-top:10px\">1：您的密码找回问题为空，一旦忘记密码则无法找回密码。<br/><br/>2：请点击<a href=\"http://www.pinble.com/UserCenter/User_Center.aspx\" target=\"_blank\">用户中心</a>我的资料选择“修改登录密保”及时来完善密码找回问题和答案。<br/><br/>3：密码找回问题和答案请勿一样，答案也不要跟网站用户名一样。<br/><br/>4：密码找回答案请勿太简单，也不要太容易被猜测，否则很容易被非法人员通过密码找回功能来盗取您的网站用户名密码。<br/><br/>5：密码找回问题可以设成：“您的出生地？”，“您的生日？”，“您孩子的名字？”等等；密码找回答案应该设置成别人根据密码问题猜测不出来的答案。<br/></div>";
                            $.XYTipsWindow({
                                ___title: "<div style=\"border:0px solid #ccc; height:25px; line-height:25px;\"><font color='red'>友情提醒：您的密码提示问题和答案存在风险！</font></div>",    //窗口标题文字
                                ___content: "text:" + txt,    //内容{text|id|img|url|iframe}
                                ___width: "515",            //窗口宽度
                                ___height: "300",          //窗口离度
                                ___drag: "___boxTitle", 	    //拖动手柄ID
                                ___showbg: true		//是否显示遮罩层
                            });
                        }
                    }
                });
            }
    </script>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
