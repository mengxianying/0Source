<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logion.aspx.cs" Inherits="Pinble_Challenge.logion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录页面</title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
<!--
a {blr:expression(this.onFocus=this.blur())}
-->
</style>
</head>
<body>
<form id="form1" runat="server">
    <div class="q_box">
        <div class="q_top">
            <p>
                <a href="#">
                    <img src="images/logo.png" width="317" height="86" /></a></p>
        </div>
        <div class="q_main">
            <div class="q_login">
                <ul>
                    <li class="xoa">登录账号:</li>
                    <li>
                        <input name="pss" type="text" id="pss" class="pss" /></li>
                    <li class="xoa"><a href="#">注册新账号</a></li>
                </ul>
                <ul>
                    <li class="xoa">用户密码:</li>
                    <li>
                        <input name="pss2" type="password" id="pss2" class="pss" /></li>
                    <li class="xoa"><a href="#">忘记密码？</a></li>
                </ul>
            </div>
            <div class="q_butt">
                <p style="float: left">
                    <asp:LinkButton ID="lkb_dl" runat="server">登录</asp:LinkButton>
                    </p>
                <p style="float: left; margin-left: 20px;">
                    <asp:LinkButton ID="lkb_Cancel" runat="server">取消</asp:LinkButton></p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
