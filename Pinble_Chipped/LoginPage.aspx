<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Pinble_Chipped.LoginPage" %>

<%@ Register Src="Contorls/login.ascx" TagName="login" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache,  must-revalidate">
    <meta http-equiv="expires" content="0">
    <link href="loginCss/login.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href="Css/css.css" />
    <link rel="stylesheet" type="text/css" href="Css/Title.css" />
    <link type="text/css" rel="Stylesheet" href="Css/footer.css" />
    <script type="text/javascript" src="js/SearchAjax.js?date=new date().gettime()"></script>
    <style type="text/css">
        body, td, th
        {
            font-size: 12px;
        }
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <div style='width: expression(this.offsetParent.clientWidth<925 ? "925px" : "100%");
        min-width: 800px;'>
        <form id="form1" runat="server">
        <div class="header">
            <div class="logo">
            </div>
            <div class="login_info">
                <uc1:login ID="login2" runat="server" />
            </div>
        </div>
        <div class="page">
            <div class="content">
                <!--主要内容-->
                <div class="main" id="divTheme">
                    <!--主题链接-->
                    <div id="divLink">
                    </div>
                    <!--介绍-->
                    <div class="intro intro-noico" id="divText">
                    </div>
                    <!--登录框-->
                    <div class="login login-1" id="divLogin" style="margin-top: 10px; margin-bottom: 5px;">
                        <div class="tabs">
                            <ul>
                                <li class="tab tab-2"><i class="ico-focus for for-1"></i>会员登录</li>
                            </ul>
                        </div>
                        <div id="Login1" runat="server">
                            <div class="panel">
                                <table width="85%" border="1" style="border-style: dotted; height: 260px">
                                    <tr id="uName" class="fi">
                                        <td>
                                            <label class="lb for for-1">
                                                用户名：</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Width="130px" MaxLength="12"></asp:TextBox>
                                        </td>
                                        <td>
                                            <a style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/Register.aspx"
                                                tabindex="-1">免费注册</a>
                                        </td>
                                    </tr>
                                    <tr class="fi">
                                        <td>
                                            <label class="lb for for-1">
                                                密&nbsp;&nbsp;码：</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPWD" runat="server" MaxLength="16" Width="130px" TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td>
                                            <a style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx"
                                                target="_blank" tabindex="-2">密码找回</a>
                                        </td>
                                    </tr>
                                    <tr class="fi">
                                        <td>
                                            <label>
                                                验证码：</label>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtCode" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"
                                                runat="server" Style="width: 50px;"></asp:TextBox>
                                            <img src="publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                                id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
                                            <img alt="正确" src="../image/note_ok.gif" id="imgOKL" style="display: none;" />
                                            <img alt="错误" src="../image/note_error.gif" id="imgErrorL" style="display: none;" />
                                        </td>
                                    </tr>
                                    <tr class="fi fi-nolb">
                                        <td align="center">
                                            <asp:Button ID="btnLogin_1" runat="server" Text="登录" CssClass="loginbtn" OnClick="btnLogin_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="loginbtn2" OnClick="btnreset_Click" />
                                        </td>
                                        <td colspan="2">
                                            <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx" target="_top"
                                                class="blue">
                                                <asp:CheckBox ID="cbState" runat="server" Text="保存登录状态" /></a>
                                        </td>
                                    </tr>
                                    <tr class="ext for for-1">
                                        <ul>
                                            <li>拼搏在线彩神通软件应用平台登陆 </li>
                                        </ul>
                                    </tr>
                                </table>
                                <%-- <div id="uName" class="fi">
                                    <label class="lb for for-1">
                                        用户名：</label><asp:TextBox ID="txtName" runat="server" Width="130px" MaxLength="12"></asp:TextBox>&nbsp;<a
                                            style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/Register.aspx" tabindex="-1">免费注册</a>
                                </div>
                                <div class="fi">
                                    <label class="lb for for-1">
                                        密&nbsp;&nbsp;码：</label><asp:TextBox ID="txtPWD" runat="server" MaxLength="16" Width="130px"
                                            TextMode="Password"></asp:TextBox>&nbsp;<a style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx"
                                                target="_blank" tabindex="-2">密码找回</a>
                                </div>
                                <div class="fi">
                                    <label>
                                        验证码：</label>&nbsp;&nbsp;<asp:TextBox ID="txtCode" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"
                                            runat="server" Style="width: 50px;"></asp:TextBox>
                                    <img src="publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                        id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
                                    <img alt="正确" src="../image/note_ok.gif" id="imgOKL" style="display: none;" />
                                    <img alt="错误" src="../image/note_error.gif" id="imgErrorL" style="display: none;" />
                                </div>
                                <div class="fi fi-nolb">
                                    <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="loginbtn" OnClick="btnLogin_Click" />
                                    <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="loginbtn2" OnClick="btnreset_Click" />
                                    &nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx" target="_top" class="blue"><asp:CheckBox ID="cbState"
                                        runat="server" Text="保存登录状态" /></a>
                                </div>
                                <div class="ext for for-1">
                                    <ul>
                                        <li><a href="#" target="_blank">拼搏在线彩神通软件的彩民们登陆网站的快速通道</a> </li>
                                        <li><a href="#" target="_blank">最新试用版免费升级咯！</a></li>
                                    </ul>
                                </div>--%>
                            </div>
                        </div>
                        <div id="hasLogin" runat="server" visible="false">
                            <table cellspacing="4" cellpadding="4" width="100%" align="center" border="0" style="font-size:14px">
                                <tbody>
                                    <tr style="margin-bottom:10px;">
                                        <td align="left">
                                            <b>欢迎您：</b>
                                            <asp:Label ID="lblUName" runat="server" Text=""></asp:Label>用户
                                        </td>
                                    </tr>
                                    <tr style="margin-bottom:10px;">
                                        <td>
                                           1、 欢迎您来到合买代购平台，您在这里可以发布彩票合买订单，以及购买彩票。
                                        </td>
                                    </tr>
                                    <tr style="margin-bottom:10px;">
                                        <td>
                                            2、您可以购买优秀用户发布的和买订单。方便。快捷
                                        </td>
                                    </tr>
                                    <tr style="margin-bottom:10px;">
                                        <td>
                                            3、在网页左边导航栏有可以购买的彩种。您可以选择操作。
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                //随机主题
                var oThemes = [
                //多标签
		{
		'bgimg': 'image/login_bg.jpg',
		'link': '<a class="piclink" href="javascript:void(0)" style="cursor:default;"></a>',
		'text': '\
				<dl>\
					<dt>&nbsp;</dt>\
					<dd style="background:none;">欢迎您给我们提供宝贵的意见</dd>\
					<dd style="background:none;">多种彩种同步查看，最新信息尽收眼底</dd>\
				</dl>\
			'
}

	];

                var rdnum = Math.floor(oThemes.length * Math.random());
                document.getElementById("divLink").innerHTML = oThemes[rdnum].link;
                document.getElementById("divText").innerHTML = oThemes[rdnum].text;
                document.getElementById("divTheme").style.backgroundImage = "url(" + oThemes[rdnum].bgimg + ")";

	

	
            </script>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
        </form>
    </div>
</body>
</html>
