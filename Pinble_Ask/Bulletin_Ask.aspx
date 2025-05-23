<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bulletin_Ask.aspx.cs" Inherits="Pinble_Ask.Bulletin_Ask" %>

<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc3" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcType.ascx" TagName="UcType" TagPrefix="uc2" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>最新公告_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
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
                                <a href="/">拼搏吧</a> >> 最新公告</td>
                        </tr>
                    </table>
                    <asp:Repeater ID="RptList" runat="server">
                        <HeaderTemplate>
                            <table width="90%" border="0" cellpadding="1" cellspacing="0" align="center" class="MT">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td width="87%" align="left" class="ask_border">
                               &nbsp;<a href="/Bulletin_Ask_Show.aspx?id=<%#Input.Encrypt(Eval("IntID").ToString()) %>" class="Linl14" target="_blank" title='<%#Eval("NvarTitle") %>'>·<%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),36*2, " ")%></a></td>
                                <td width="13%"  class="ask_border f14gray" align="center">
                                    <%#Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Label ID="litContent" runat="server"></asp:Label>
                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="1">
                        <tr>
                            <td height="25" align="center">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                    ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                                    CustomInfoStyle='vertical-align:middle;' CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
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
