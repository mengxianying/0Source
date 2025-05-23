<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bulletin_Ask_Show.aspx.cs"
    Inherits="Pinble_Ask.Bulletin_Ask_Show" %>

<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc3" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcType.ascx" TagName="UcType" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拼搏吧 - 拼搏在线彩神通软件 </title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:UcAskHead ID="UcAskHead1" runat="server" />
            <div class="main">
                <!----左边开始---->
                <div class="ml">
                    <uc2:UcType ID="UcType1" runat="server" />
                </div>
                <!----右边开始---->
                <div class="m_rGGao">
                    <table width="100%" border="0" cellspacing="0" cellpadding="3" bgcolor="#FBF5C6">
                        <tr>
                            <td width="2">
                            </td>
                            <td>
                                <a href="/">拼搏吧</a> >> <a href="/Bulletin_Ask.aspx"><font color="black">最新公告</font></a></td>
                        </tr>
                    </table>
                    <table width="95%" border="0" cellspacing="0" cellpadding="2" align="center" class="MT">
                        <tr>
                            <td class="ask_border font_14blue" align="center">
                                <%=title %>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="37" style="padding-bottom: 5px;">
                                <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>" class="school">
                                    <%= Pbzx.Common.WebInit.webBaseConfig.WebUrl.Substring(0,Pbzx.Common.WebInit.webBaseConfig.WebUrl.Length-1)%>
                                </a>&nbsp;<span class="song"><asp:Label ID="lblAndTime" runat="server"></asp:Label></span>
                                &nbsp;<span class="source"><asp:Label ID="lblSource" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                    </table>
                    <table width="95%" border="0" cellspacing="0" cellpadding="6" align="center">
                        <tr>
                            <td class="f14black" valign="top" height="120">
                              <%=content%></td>
                        </tr>
                    </table>
                    <table width="95%" border="0" align="center" cellpadding="6" cellspacing="0">
                        <tr>
                            <td align="right" class="ask_border">
                            </td>
                        </tr>
                    </table>
                  
                </div>
            </div>
        </div>
        <uc3:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
