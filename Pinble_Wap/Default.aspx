<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Pinble_Wap._Default" %>
<%@ Import Namespace="Pbzx.Common" %>
<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.1//EN" " http://www.openmobilealliance.org/tech/DTD/xhtml-mobile11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>全国开奖信息_拼搏在线彩神通软件</title>
   <style type="text/css">
body,td,div,th{margin:0;padding:0;font-size:12px;font-style:normal;}
</style>
    <%-- <meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <meta name="keywords" content="开奖号,试机号,3d,排列三,福彩,体彩" />
    <meta name="description" content="全国联网彩票开奖号码"/>
    <%--    <meta http-equiv="Refresh" content="300"/>--%>
</head>
<body>
    <form runat="server" id="form1" style="height: 100%">
        <div style="text-align: center">
            <a href='http://www.pinble.com'  target='_blank'>
                <img src="image/top.gif" style="border: 0px;" alt="最新开奖信息" /></a></div>
        <div class="D_Award box2">
            <div style="text-align: center">
                <br />
                <a href="/" title="刷新最新开奖信息" class="kai more">刷新最新开奖信息</a>
            </div>
            <div id="UserDiv" runat="server" visible="false" style="text-align: center">
                <br />
                管理员：
                <asp:Label ID="labusername" runat="server" Text=""></asp:Label>
                您好！
                <asp:LinkButton ID="lnkBtn" runat="server" OnClick="lnkBtn_Click">返回后台</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkBtnreselt" runat="server" OnClick="lnkBtnreselt_Click">退出</asp:LinkButton></div>
            <hr />
            <div>
                <table width="100%" border="0" cellpadding="1" cellspacing="0" class="MT3">
                    <tr>
                        <td width="3%">
                            .</td>
                        <td width="60%" align="left" valign="bottom">
                            <b><font color='#004899'>
                                <asp:Label ID="lbl3DIssue" runat="server" Font-Bold="True"></asp:Label>
                                期福彩3D</font></b>
                        </td>
                        <td width="37%" align="right">
                            <span>
                                <asp:Label ID="lbl3dTime" runat="server" Text=""></asp:Label></span>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>

                &nbsp;&nbsp;&nbsp;模拟试机号：
                [<b><asp:Label ID="lblTestCode" runat="server"></asp:Label></b>]<br />
                <asp:Label ID="lblTestCodeDY" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;彩神通关注码：<b><asp:Label ID="lblCst3dgzm" runat="server"></asp:Label></b>&nbsp;金码：<b><asp:Label
                    ID="lblJin" runat="server"></asp:Label></b> 

                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCode"
                        runat="server" ForeColor="Black"></asp:Label>
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%" class="D_Award2">
                            .</td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <b><font color='#004899'>
                                <asp:Label ID="lblTcpl3Issue" runat="server" Font-Bold="True" Font-Italic="False"></asp:Label>
                                期体彩排列三</font></b>
                        </td>
                        <td width="37%" class="D_Award2" align="right">
                            <asp:Label ID="lblPl3Time" runat="server" Text=""></asp:Label>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>

                &nbsp;&nbsp;&nbsp;模拟试机号：
                [<b><asp:Label ID="lblTestCode3" runat="server"></asp:Label></b>]<br />
                <asp:Label ID="lblTestCodeDY3" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;彩神通关注码：<b><asp:Label ID="lblCstp3gzm" runat="server"></asp:Label></b>&nbsp;金码：<b><asp:Label
                    ID="lblJin3" runat="server"></asp:Label></b> 

                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCode3"
                        runat="server" ForeColor="Black"></asp:Label>
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%" class="D_Award2">
                            .</td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <b><font color='#004899'>
                                <asp:Label ID="lblTcpl5Issue" runat="server" Font-Bold="True" Font-Italic="False"></asp:Label>
                                期体彩排列五</font></b>
                        </td>
                        <td width="37%" class="D_Award2" align="right">
                            <asp:Label ID="lblPl5Time" runat="server" Text=""></asp:Label>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;开奖号：[<b><asp:Label ID="lblTcpl5Code" runat="server"></asp:Label></b>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%" class="D_Award2">
                            .</td>
                        <td width="60%" align="left" valign="bottom" class="D_Award1">
                            <b><font color='#004899'>
                                <asp:Label ID="lbl7xcIssue" runat="server" Font-Bold="True"></asp:Label>
                                期体彩七星彩</font></b>
                        </td>
                        <td width="37%" class="D_Award2" align="right">
                            <span class="kaiTime">
                                <asp:Label ID="lbl7xTime" runat="server"></asp:Label></span>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;开奖号：[<b><asp:Label ID="lbl7xcCode" runat="server"></asp:Label></b>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%">
                            .</td>
                        <td width="60%" align="left" valign="bottom">
                            <b><font color='#004899'>
                                <asp:Label ID="lbl7lcIssue" runat="server" Font-Bold="True"></asp:Label>
                                期福彩七乐彩</font></b>
                        </td>
                        <td width="37%" align="right">
                            <asp:Label ID="lbl7lTime" runat="server"></asp:Label>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<b><asp:Label ID="lbl7lcCode" runat="server"></asp:Label></b>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%" style="height: 16px">
                            .</td>
                        <td width="60%" align="left" valign="bottom" style="height: 16px">
                            <b><font color='#004899'>
                                <asp:Label ID="lblSsqIssue" runat="server" Font-Bold="True"></asp:Label>
                                期福彩双色球</font></b>
                        </td>
                        <td width="37%" align="right" style="height: 16px">
                            <asp:Label ID="lblSsqTime" runat="server"></asp:Label>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<b><asp:Label ID="lblSsqCode" runat="server" Text=""></asp:Label></b>]<br />
                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%" valign="top">
                            .</td>
                        <td width="60%" align="left" valign="bottom">
                            <b><font color='#004899'>
                                <asp:Label ID="lblDltIssue" runat="server" Font-Bold="True"></asp:Label>
                                期体彩大乐透</font></b>
                        </td>
                        <td width="37%" align="right">
                            <asp:Label ID="lblDltTime" runat="server"></asp:Label>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<b><asp:Label ID="lblDltCode" runat="server" Text=""></asp:Label></b>]<br />

                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                    <tr>
                        <td width="3%">
                            .</td>
                        <td width="60%" align="left" valign="bottom">
                            <b><font color='#004899'>
                                <asp:Label ID="lblKL8Issue" runat="server" Font-Bold="True"></asp:Label>
                                期福彩快乐8</font></b>
                        </td>
                        <td width="37%" align="right">
                            <asp:Label ID="lblKL8Time" runat="server"></asp:Label>&nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;[<b><asp:Label ID="lblKL8Code" runat="server" Text=""></asp:Label></b>]
            </div>
            <hr />
            <div style="text-align: center">
                拼搏在线（北京）科技发展有限公司<br />
                版权所有 &copy; 2004-<script>document.write(new Date().getFullYear());</script> <a href='http://www.pinble.com' target='_blank'>pinble.com</a><br />
                京ICP备05051578号-1<br />
            </div>
        </div>
    </form>
</body>
</html>
