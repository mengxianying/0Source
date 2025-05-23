<%@ Page Language="C#" AutoEventWireup="true" Codebehind="login.aspx.cs" Inherits="Pinble_Market.login" %>

<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登陆页</title>
    <meta http-equiv="pragma"  content="no-cache">  
    <meta http-equiv="Cache-Control"  content="no-cache,  must-revalidate">  
    <meta http-equiv="expires" content="0"> 

    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/login.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

body,td,th {
	font-size: 12px;
}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}

</style>
</head>
<body>
<uc1:head ID="Head1" runat="server" />
<div id="wrap">
    <form id="form1" runat="server">
        
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
                        <div class="login login-1" id="divLogin" style=" margin-top:10px; margin-bottom:5px;">
                            <div class="tabs">
                                <ul>
                                    <li class="tab tab-2"><i class="ico-focus for for-1"></i>会员登录</li>
                                </ul>
                            </div>
                            <div id="Login1" runat="server">
                                <div class="panel">
                                        <div id="uName" class="fi">
                                            <label class="lb for for-1">
                                                用户名：</label><asp:TextBox ID="txtName" runat="server" Width="130px" MaxLength="12"></asp:TextBox>&nbsp;<a
                                                style="cursor: pointer;" href="http://www.pinble.com/Register.aspx" target="_blank" tabindex="-1">免费注册</a>
                                        </div>
                                        <div class="fi">
                                            <label class="lb for for-1">
                                                密&nbsp;&nbsp;码：</label><asp:TextBox ID="txtPWD" runat="server" MaxLength="16" Width="130px" TextMode="Password"></asp:TextBox>&nbsp;<a
                                                style="cursor: pointer;" href="http://www.pinble.com/RecoverPasswd1.aspx" target="_blank" tabindex="-2">密码找回</a>
                                        </div>
                                        <div class="fi">
                                            <label>
                                                验证码：</label>&nbsp;&nbsp;<asp:TextBox ID="txtCode" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"
                                                runat="server" style="width: 50px;"></asp:TextBox>
                                            <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                                id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
                                            <img alt="正确" src="../image/note_ok.gif" id="imgOKL" style="display: none;" />
                                            <img alt="错误" src="../image/note_error.gif" id="imgErrorL" style="display: none;" />
                                            
                                        </div>
                                       
                                        <div class="fi fi-nolb">
                                           <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="loginbtn" OnClick="btnLogin_Click" />
                                            <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="loginbtn2" OnClick="btnreset_Click" />
                                            &nbsp;<a href="/RecoverPasswd1.aspx" target="_top" class="blue"><asp:CheckBox ID="cbState"
                                                runat="server" Text="保存登录状态" /></a>
                                        </div>
                                    <div class="ext for for-1">
                                        <ul>
                                            <li><a href="#" target="_blank">拼搏在线彩神通软件的彩民们登陆网站的快速通道</a> </li>
                                            <li><a href="#" target="_blank">最新试用版免费升级咯！</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div id="hasLogin" runat="server" visible="false">
                                <table cellspacing="4" cellpadding="4" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="left">
                                                <b>欢迎您：</b>
                                                <asp:Label ID="lblUName" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
<%--                                                <asp:Button ID="btnChangePWD" runat="server" CssClass="loginbtn3" Text="修改密码" OnClick="btnChangePWD_Click" />
                                                <asp:Button ID="btnExit" runat="server" Text="退出" CssClass="loginbtn" OnClick="btnExit_Click" />--%>
                                                
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                欢迎您来到彩票超市，您在这里可以找到您最需要的彩票信息。
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                您可以在彩票平台上发布自己满意的条件。
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
			'bgimg':'image/login_bg.jpg',
			'link':'<a class="piclink" href="javascript:void(0)" style="cursor:default;"></a>',
			'text':'\
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
	document.getElementById("divTheme").style.backgroundImage = "url("+oThemes[rdnum].bgimg+")";

	

	
                </script>

            </div>
            
    </form>
    </div>
    <uc2:MakFooter ID="MakFooter1" runat="server" />
</body>
</html>
