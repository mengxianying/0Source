<%@ Page Language="C#" AutoEventWireup="true" Codebehind="zhengce.aspx.cs" Inherits="Pbzx.Web.zhengce"
    EnableViewState="false" %>

<%@ Register Src="Contorls/Agent_AD.ascx" TagName="Agent_AD" TagPrefix="uc5" %>
<%@ Register Src="Contorls/Agent_menu.ascx" TagName="Agent_menu" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Agent_province.ascx" TagName="Agent_province" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>经销政策_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/agent.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <uc5:Agent_AD ID="Agent_AD1" runat="server" />
            <div class="bodyw MT">
                <!--左边---->
                <div class="A_l">
                    <uc3:Agent_menu ID="Agent_menu1" runat="server" />
                    &nbsp;</div>
                <!--右边---->
                <div class="A_r">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                        <tr>
                            <td bgcolor="#f5f5f5">
                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="87%" height="25" valign="bottom" class="A_biao">
                                            当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'><span class="A_biao">拼博在线彩神通软件</span></a>
                                            >> <a href="/Agent.aspx"><span class="A_biao">代理专区</span></a> >> 经销政策
                                        </td>
                                        <td width="13%">
                                            &nbsp;
                                            <uc4:Agent_province ID="Agent_province1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>                   
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr bgcolor="#4099F2">
                            <td height="2" bgcolor="#69B2F6">
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#CCCCCC">
                        <tr bgcolor="#FFFFFF">
                            <td bgcolor="#FFFFFF" class="red12">
                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="40" valign="bottom" class="shuoming_biao">
                                            <asp:Label ID="lbltitle" runat="server">
                                            </asp:Label>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#CCCCCC">
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" align="center" cellpadding="4" cellspacing="0">
                                    <tr>
                                        <td align="left" valign="top" class="shuoming">
                                            <asp:Label ID="lblContent" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#CCCCCC">
                                        </td>
                                    </tr>
                                    <td height="26" align="center" valign="bottom">
                                        <a href="javascript:self.close()">&gt;&gt;关闭窗口 </a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:history.go(-1);">&gt;&gt;返回</a></td>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
