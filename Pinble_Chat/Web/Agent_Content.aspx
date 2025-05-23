<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Agent_Content.aspx.cs"
    Inherits="Pbzx.Web.Agent_Content" EnableViewState="false"  %>

<%@ Register Src="Contorls/Agent_AD.ascx" TagName="Agent_AD" TagPrefix="uc5" %>
<%@ Register Src="Contorls/Agent_menu.ascx" TagName="Agent_menu" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Agent_province.ascx" TagName="Agent_province" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>经销政策 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩神通软件www.pinble.com" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/agent.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <uc5:Agent_AD ID="Agent_AD1" runat="server" />
            <div class="bodyw MT">
                <div class="A_l">
                    <uc3:Agent_menu ID="Agent_menu1" runat="server" />
                    &nbsp;</div>
                <div class="A_r">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                        <tr>
                            <td bgcolor="#f5f5f5">
                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="87%" height="25" valign="bottom" class="A_biao">
                                            当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'><span class="A_biao">拼博在线彩神通软件</span></a>
                                            >> <a href="/Agent.aspx"><span class="A_biao">代理专区</span></a> >>
                                            <asp:Label ID="lblPurpose" runat="server"></asp:Label>
                                        </td>
                                        <td width="13%">
                                            &nbsp;
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
                                            </asp:Label></td>
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
                                            </asp:Label><br />
                                        </td>
                                    </tr>
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
