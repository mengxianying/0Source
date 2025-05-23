<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Source.aspx.cs" Inherits="Pbzx.Web.Source" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc6" %>
<%@ Register Src="Contorls/UcSource.ascx" TagName="UcSource" TagPrefix="uc5" %>
<%@ Register Src="Contorls/SourceTitle.ascx" TagName="SourceTitle" TagPrefix="uc4" %>
<%@ Register Src="Contorls/SourceClass.ascx" TagName="SourceClass" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源下载_拼搏在线彩神通软件</title>
    <meta name="keywords" content="演示录像,操作方法,软件使用,下载" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/res.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Head ID="Head1" runat="server"></uc1:Head>
    <!--主体部分--->
    <div class="bodyw div_wei">
        <table width="100%" border="0" cellspacing="0" cellpadding="2">
            <tr>
                <td width="50%" align="left">
                    当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'>拼博在线彩神通软件</a> >> <a
                        href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Source.aspx'>资源下载</a>
                </td>
                <td width="50%" align="right">
                    <uc5:UcSource ID="UcSource1" runat="server"></uc5:UcSource>
                </td>
            </tr>
        </table>
    </div>
    <div id="soft" class="bodyw">
        <!--左边--->
        <div class="R_lw1">
            <div class="R_r1 R_box">
                <div id="tuijian" runat="server" visible="false" style="margin-bottom: 10px;">
                    <div class="title">
                        <p>
                            <span>推荐资源下载</span></p>
                    </div>
                    <div class="content" style="padding-top: 4px;">
                        <asp:DataList ID="dlProductTop" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <td width="5">
                                        </td>
                                        <td width="130" align="center">
                                            <a href="Source_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>"
                                                target="_blank">
                                                <img src='<%#Eval("PBnet_SoftPicUrl")%>' width="130" height="93" hspace="0" vspace="0"
                                                    alt='<%#Eval("PBnet_SoftName")%>' border="0" /></a>
                                        </td>
                                        <td width="202">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                                <tr>
                                                    <td align="left">
                                                        <a href="Source_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>"
                                                            target="_blank">
                                                            <%#Eval("PBnet_SoftName")%>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        资源类型：<%#Eval("PBnet_SoftVersion")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        发布日期：<%#Eval("pb_UpdateTime", "{0:yyyy-MM-dd HH:mm}")%>
                                                    </td>
                                                </tr>
                                                <%--  <tr>
                                        <td align="left">
                                            价格：<span class="S_zi3">￥<%#Eval("pb_DemoUrl")%>&nbsp;￥<%#Eval("pb_RegUrl")%></span></td>
                                    </tr>--%>
                                                <tr>
                                                    <td align="left">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                        <!--                        <td width="30%">
                                                                    下载地址：
                                                                </td>
                                                                <td width="6%" align="left">
                                                                    <img src="/images/Web/download1.gif" width="12" height="12" alt="" />
                                                                </td>
                                                                <td width="64%">
                                                                 <a href='Source_explain.aspx?ID=<%# Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>'
                                                class="S_title1" target="_blank">下载</a>
                                                                </td>
                                        -->
                                                                <!--
                                                                <td width="27%">
                                                                    <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"SoftDownLoad.aspx?id="+ Eval("PBnet_SoftID")+"&reUrl=1" %>'>
                                                                        北方联通</a>
                                                                </td>
                                                                <td width="7%" align="left">
                                                                    <img src="/images/Web/download1.gif" width="12" height="12" alt="" />
                                                                </td>
                                                                <td width="27%">
                                                                    <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"SoftDownLoad.aspx?id="+ Eval("PBnet_SoftID")+"&reUrl=1" %>'>
                                                                        南方电信</a>
                                                                </td>
                                                                -->
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="title">
                    <p>
                        <span>资源下载列表</span></p>
                </div>
                <div class="content">
                    <div>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table width="96%" border="0" align="center" cellpadding="2" cellspacing="2">
                                    <tr bgcolor="#E3F5FD">
                                        <td width="80%" height="22" colspan="4" align="left" class="R_title_pd">
                                            <a href='Source_explain.aspx?ID=<%# Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>'
                                                class="S_title1" target="_blank"><strong>
                                                    <%#Eval("PBnet_SoftName")%>
                                                </strong></a>&nbsp;<span class="S_zi1">
                                                    <%# Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(Eval("pb_ClassID").ToString()))   %>
                                                </span>
                                        </td>
                                        <td width="20%" align="right" class="R_zi3">
                                            发布日期：<%#Eval("pb_UpdateTime","{0:yyyy-MM-dd HH:mm}")%>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="left" class="R_title_pd">
                                            <span class="res_show">
                                                <%#Pbzx.Common.StrFormat.CutStringByNum(Pbzx.Common.Input.FilterHTML(Eval("PBnet_SoftIntro").ToString()), 220, "...")%>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="12%" height="22" align="left" class="R_title_pd">
                                            授权形式：<%#GetType(Eval("pb_CopyrightType"))%>
                                        </td>
                                        <td width="10%">
                                            大小：<%#Eval("PBnet_SoftSize")%>KB
                                        </td>
                                        <td width="10%">
                                            资源类型：<%#Eval("PBnet_SoftVersion")%>
                                        </td>
                                        <td  width="10%">
                                        &nbsp;
 <!--
                                        下载数：<%#Eval("pb_Hits") %>次
 -->
                                        </td>
                                        <td align="right">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="7%">
                                                    </td>
                                                    <td width="31%" align="right">
                                            <!--
                                                        下载地址：
                                            -->
                                                    </td>
                                                    <td width="10%">
                                            <!--
                                                        <img src="/images/Web/download1.gif" width="12" height="12" alt="" />&nbsp;
                                            -->
                                                    </td>
                                                     <td width="59%"  align="left"> 
                                            <!--
                                                     <a href='Source_explain.aspx?ID=<%# Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>'
                                                class="S_title1" target="_blank">&nbsp;下载</a>
                                             -->
                                                </td>
                                                 <!--  
                                                    <td width="22%" align="left">
                                                        <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"SoftDownLoad.aspx?id="+ Eval("PBnet_SoftID")+"&reUrl=1" %>'>
                                                            北方联通</a>
                                                    </td>
                                                 
                                                <td width="10%">
                                                        <img src="/images/Web/download1.gif" width="12" height="12" alt="" />&nbsp;
                                                    </td>
                                                    <td width="30%" align="left">
                                                        <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"SoftDownLoad.aspx?id="+ Eval("PBnet_SoftID")+"&reUrl=1" %>'>
                                                            南方电信</a>
                                                    </td>
                                                    -->
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Label ID="litContent" runat="server"></asp:Label>
                        <table width="97%" border="0" align="center" cellpadding="1" cellspacing="0">
                            <tr>
                                <td bgcolor="#83B5E2" style="height: 1px">
                                </td>
                            </tr>
                            <tr>
                                <td height="40" valign="top">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--右边--->
        <div class="R_rw1">
            <div class="R_box R_l1">
                <div class="title">
                    <p>
                        <span>资源分类</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc3:SourceClass ID="SourceClass1" runat="server" />
                    </div>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>最新资源</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SourceTitle ID="SourceTitle1" runat="server" Count="8" TilteLength="16"></uc4:SourceTitle>
                    </div>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>在线客服</span></p>
                </div>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-top: 5px;
                        padding-left: 3px; padding-bottom: 3px;">
                        <tr>
                            <td align="center">
                                <uc6:UC_QQ ID="UC_QQ1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>资源总下载排行 Top <label id="labzong" runat="server"></label></span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SourceTitle ID="SourceTitle2" runat="server" Count="8" Hits="2" TilteLength="16">
                        </uc4:SourceTitle>
                    </div>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>本月资源下载排行 Top <label id="labyue" runat="server"></label></span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SourceTitle ID="SourceTitle3" runat="server" Count="8" Hits="3" TilteLength="16">
                        </uc4:SourceTitle>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc2:Footer ID="Footer1" runat="server"></uc2:Footer>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
