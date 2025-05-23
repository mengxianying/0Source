<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserRealInfo.aspx.cs" Inherits="Pbzx.Web.UserRealInfo" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="~/Contorls/UcRegRealInfo.ascx" TagName="UcRegRealInfo" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head runat="server">
    <title>高级用户注册_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/broker.css" rel="stylesheet" type="text/css" />
    <link href="/css/user.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body onunload="window.returnValue ='close';" onkeydown="if (event.keyCode==116){reload.click()}">
    <form id="form1" runat="server">
        <div>
            <uc2:Head ID="Head1" runat="server" />
            <%--<table width="990" border="0" align="center" cellpadding="0" cellspacing="0" id="tb1" runat="server">
                <tr>
                    <td>
                        <table id="rule" width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="padding-bottom: 10px; padding-left: 10px; padding-top: 2px;">
                                    <!--<div style="overflow:auto; height:650px">-->
                                    <p align="center" class="blue_bold">
                                        高级用户注册服务协议</p>
                                    <p style="line-height: 150%; text-align: left;">
                                        一、 请您在申请注册『拼搏在线』高级用户之前仔细阅读本用户注册服务协议。如果您同意并申请注册用了『拼搏在线』高级用户的有偿服务，即表示您完全同意遵守所有这些条款。<br />
                                        二、 如果您不同意接受这些条款，请您立即离开。<br />
                                        三、注册成为『拼搏在线』高级用户时，需按要求填写真实详细的个人身分资料、姓名、住址、联系电话、银行帐号、电子邮箱等相关资料；<br />
                                        四、高级用户注册成功后，要保管好您的用户名和交易密码，并要对您的用户名和交易密码安全负全部责任。您可以不定期来更换您的交易密码，以提高安全性。<br />
                                        五、高级用户注册成功后，您要对以其用户名进行的所有活动和事件负全责。<br />
                                        六、高级用户在接受有偿服务时，要按规定方式支付相关的服务费用；<br />
                                        七、高级用户的权利与义务：<br />
                                        1、高级用户可以访问所申请或购买的有偿服务内容；<br />
                                        2、高级用户必须遵守所有使用网络服务的相关法律、协议、规定和惯例，不得干扰或破坏与本服务相连的服务器和网络。<br />
                                        3、高级用户不得发表任何非法的、骚扰性的、中伤他人的、辱骂性的、恐吓性的、伤害性的、庸俗的，淫秽的等信息内容。<br />
                                        4、高级用户要遵守『拼搏在线』关于有偿服务内容与资料及其他文件的版权声明和其他的管理规定，本站所提供的有偿服务内容与资料仅用于高级用户本人参考使用，不得随意转载或传播。<br />
                                        5、高级用户要保证注册资料的真实可靠性，并保证账号使用的唯一性，不得将账号信息提供给他人使用或进行网络传播。<br />
                                        八、本网站的权利与义务：<br />
                                        1、『拼搏在线』按时提供对付费高级用户权利中所包含的有偿服务内容与资料。<br />
                                        2、『拼搏在线』所提供的有偿服务内容与资料仅供付费高级用户参考使用，不保证所提供的有偿服务内容与资料一定中奖，不承担任何赔偿责任；<br />
                                        3、『拼搏在线』对违反高级用户义务中所提到条款的用户，本站有权独立作出判断并冻结该高级用户的使用权限；<br />
                                        4、『拼搏在线』对已开通有偿服务内容的用户所交纳的服务费用无特殊原因本站恕不退还。<br />
                                        5、『拼搏在线』如因系统维护或升级而需暂停高级用户服务时将事先公告。因此而造成的正常服务中断，请您予以理解。如因不可抗力或其他无法控制的原因，而导致高级用户服务暂停，于暂停服务期间造成的一切不便与损失，本站将不承担任何责任与赔偿；<br />
                                        九、在您确认本注册协议后，本注册协议即在您和『拼搏在线』之间产生法律效力。请您务必在注册之前认真阅读全部协议内容，如有任何疑问，可向『拼搏在线』咨询。
                                    </p>
                                    <p align="right">
                                        拼搏在线（北京）科技发展有限公司</p>
                                    <!--</div>-->
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnTong" runat="server" Text="我同意本协议" OnClick="btnTong_Click" />                       
                        &nbsp; &nbsp;&nbsp;
                        <input id="btnNo" type="button" value="暂不申请高级用户" onclick='window.returnValue ="close";window.close();' />
                    </td>
                </tr>
            </table>--%>
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0"
                id="tb2"  runat="server">
                <tr>
                    <td>
                        <uc1:UcRegRealInfo ID="UcRegRealInfo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 24px">
                        <asp:Button ID="btmSemd" runat="server" Text=" " OnClick="btmSemd_Click" class="U_Gaobtn1" />&nbsp;&nbsp;&nbsp;&nbsp;<input id="btnNo1" type="button" value=" " onclick='window.returnValue ="close";window.close();' class="U_Gaobtn2" />
                    </td>
                </tr>
            </table>
        </div>
        <uc3:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
