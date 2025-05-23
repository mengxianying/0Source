<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soft.aspx.cs" Inherits="Pbzx.Web.Soft" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc8" %>
<%@ Register Src="Contorls/Uc_shopping.ascx" TagName="Uc_shopping" TagPrefix="uc7" %>
<%@ Register Src="Contorls/UcSoft.ascx" TagName="UcSoft" TagPrefix="uc6" %>
<%@ Register Src="Contorls/soft_verf.ascx" TagName="soft_verf" TagPrefix="uc5" %>
<%@ Register Src="Contorls/SoftTitle.ascx" TagName="SoftTitle" TagPrefix="uc4" %>
<%@ Register Src="Contorls/SoftClass.ascx" TagName="SoftClass" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>软件商城_拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩票软件,3D,P3,排列三,排列五,七乐彩,双色球,七星彩,超级大乐透" />
    <meta name="description" content="拼搏在线彩神通软件网站出品的彩神通系列彩票软件。" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/softpage.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Head ID="Head1" runat="server" />
        <!--主体部分--->
        <div class="bodyw div_wei">
            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                <tr>
                    <td width="29%" align="left">
                        当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'>拼博在线彩神通软件</a> >> <a
                            href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Soft.aspx'>软件商城</a>
                    </td>
                    <td width="45%" align="center">
                        <uc7:Uc_shopping ID="Uc_shopping1" runat="server" />
                        <a href="/ShowShoppingCart.aspx"></a>
                    </td>
                    <td width="26%" align="right">
                        <uc6:UcSoft ID="UcSoft1" runat="server"></uc6:UcSoft>
                    </td>
                </tr>
            </table>
        </div>
        <div id="soft" class="bodyw">
            <!--左边--->
            <div class="S_lw1">
                <div id="N1" class="S_box S_l1" runat="server">
                    <div>
                        <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0" background="images/web/S_lbg1.jpg">
                            <tr>
                                <td valign="bottom">
                                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="80" valign="bottom" class="title">
                                                <a href="Soft.aspx"><font color="#419713">软件类别</font></a>
                                            </td>
                                            <td width="62" valign="bottom" class="title2">
                                                <a href="Soft.aspx?vef=vef"><font color="#ffffff">版本类型</font></a>
                                            </td>
                                            <td width="72">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content">
                        <div>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td>
                                        <uc3:SoftClass ID="SoftClass1" runat="server" TitleLength="9" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="N2" class="S_box S_l1" runat="server">
                    <div>
                        <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0" background="images/web/S_lbg1.jpg">
                            <tr>
                                <td valign="bottom">
                                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="62" valign="bottom" class="title2">
                                                <a href="Soft.aspx"><font color="#ffffff">软件类别</font></a>
                                            </td>
                                            <td width="80" valign="bottom" class="title">
                                                <a href="Soft.aspx?vef=vef"><font color="#419713">版本类型</font></a>
                                            </td>
                                            <td width="72">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content">
                        <div>
                            <table cellpadding="0" cellspacing="0" border="0" width="92%" align="center">
                                <tr>
                                    <td>
                                        <uc5:soft_verf ID="Soft_verf1" runat="server" TitleLength="20"></uc5:soft_verf>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="S_box S_l2 MT">
                    <div class="title">
                        <p>
                            <span>最新软件</span></p>
                    </div>
                    <div class="content">
                        <div>
                            <uc4:SoftTitle ID="SoftTitle2" runat="server" Count="8" TilteLength="12" Hits="-1" />
                        </div>
                    </div>
                </div>
                <div class="MT">
                    <img src="Images/Web/buy.jpg" border="0" usemap="#Map" />
                    <map name="Map" id="Map">
                        <area shape="rect" coords="43,39,100,58" href="Register.aspx" target="_blank" />
                        <area shape="rect" coords="161,41,220,58" href="/Soft.aspx" />
                        <area shape="rect" coords="41,86,100,104" href="/Contact.htm" target="_blank" />
                        <area shape="rect" coords="161,86,219,103" href="/Payment.htm" target="_blank" />
                    </map>
                </div>
                <div class="S_box S_l2 MT">
                    <div class="title">
                        <p>
                            <span>软件总下载排行 Top
                                <label id="labzong" runat="server">
                                </label>
                            </span>
                        </p>
                    </div>
                    <div class="content">
                        <div>
                            <uc4:SoftTitle ID="SoftTitle1" runat="server" Count="8" Hits="2" TilteLength="12" />
                        </div>
                    </div>
                </div>
                <div class="S_box S_l2 MT">
                    <div class="title">
                        <p>
                            <span>本月软件下载排行 Top
                                <label id="labyue" runat="server">
                                </label>
                            </span>
                        </p>
                    </div>
                    <div class="content">
                        <div>
                            <uc4:SoftTitle ID="SoftTitle3" runat="server" Count="8" Hits="3" TilteLength="12" />
                        </div>
                    </div>
                </div>
                <div class="S_box S_l2 MT">
                    <div class="title">
                        <p>
                            <span>在线客服</span></p>
                    </div>
                    <div class="content">
                        <div>
                            <uc8:UC_QQ ID="UC_QQ1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <!--右边--->
            <div class="S_rw1">
                <div class="S_r1 S_box">
                    <div id="tuijian" runat="server" visible="false" style="margin-bottom: 10px;">
                        <div class="title">
                            <p>
                                <span>推荐软件</span></p>
                        </div>
                        <div class="content" style="padding-top: 4px;">
                            <asp:DataList ID="dlProductTop" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                        <tr>
                                            <td width="5">
                                            </td>
                                            <td width="140" align="center">
                                                <a href="Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                    target="_blank">
                                                    <img src='<%#Eval("pb_SoftPicUrl")%>' width="130" height="97" border="0" alt='<%#Eval("pb_SoftName")%>' />
                                                </a>
                                            </td>
                                            <td width="202">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="left">
                                                            <a href="Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">
                                                                <%#Eval("pb_SoftName")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            版本号：<%#Eval("pb_SoftVersion")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            单机版：<span class="S_zi3">
                                                                 <%#GetPrice(Eval("pb_DemoUrl"), Eval("pb_RegUrl"), Eval("pb_freeshow"))%>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            网络版：<span class="S_zi3">
                                                            <%#GetMoney(Eval("pb_TypeName"))%>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <a href='addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>'>
                                                                <img alt='购买' src='/Images/Web/buy_btn.jpg' align='middle' border='0' /></a>&nbsp;
                                                            <a href="/UserCenter/AddToFavorites.aspx?productID=<%#Eval("pb_SoftID") %>&classId=<%#Eval("pb_ClassID") %>">
                                                                <img src="/Images/Web/collection_btn.jpg" border="0" align="middle" alt="收藏" /></a>
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
                            <span>软件列表</span></p>
                    </div>
                    <div class="content">
                        <div>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="96%" border="0" align="center" cellpadding="2" cellspacing="0">
                                        <tr bgcolor="#E3F5FD">
                                            <td height="22" colspan="5">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" align="left" class="S_title_pd">
                                                            <a href="Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank" class="S_title1"><strong>
                                                                    <%#Eval("pb_SoftName")%>
                                                                </strong></a>&nbsp;<span class="S_zi1"><%# Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(Eval("pb_ClassID").ToString()))   %></span>
                                                        </td>
                                                        <td width="50%" align="right">
                                                            <%#GetPrice(Eval("pb_DemoUrl"), Eval("pb_RegUrl"), Eval("pb_freeshow"))%>
                                                            &nbsp;&nbsp;<%#GetBuyPic(Eval("pb_DemoUrl"), Eval("pb_SoftID"), Eval("pb_TypeName"), Eval("pb_freeshow"))%>&nbsp;<a
                                                                href="/UserCenter/AddToFavorites.aspx?productID=<%#Eval("pb_SoftID") %>&classId=<%#Eval("pb_ClassID") %>"><%#Eval("pb_TypeName").ToString() == "出票系统" ? "" : "<img src='/Images/Web/mystow.gif' border='0' align='middle' alt='收藏' />" %></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="left" class="S_title_pd">
                                                <span class="S_title">
                                                    <%#Pbzx.Common.StrFormat.CutStringByNum(Eval("pb_SoftIntro"),220,"...")%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" align="left" height="22" class="S_title_pd">
                                                授权形式：<%#GetType(Eval("pb_CopyrightType"))%>
                                            </td>
                                            <td width="15%">
                                                大小：<%#Eval("pb_SoftSize")%>KB
                                            </td>
                                            <td width="15%">
                                                版本号：<%#Eval("pb_SoftVersion")%>
                                            </td>
                                            <td width="24%" align="left">
                                                更新日期：<%#Eval("pb_UpdateTime", "{0:yyyy-MM-dd HH:mm}")%>
                                            </td>

                                            <td width="33%">
                                            <!--
                                           <table width="100%" border="0" cellspacing="0" cellpadding="0"><tbody>
                                           <tr><td width="27%" align="right">下载地址：</td>
                                           <td width="10%"><img src="/images/Web/download1.gif" width="12" height="12" alt="">&nbsp;</td>
                                           <td width="63%" align="left"> <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;下载</a></td></tr></tbody></table>
                                             -->
<!--
                                                <%#GetDownLoad(Eval("pb_DownloadUrl1"), Eval("pb_DownloadUrl2"), Eval("pb_SoftID"))%>
-->                                                
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
                            <table width="96%" border="0" align="center" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td bgcolor="#83B5E2" style="height: 1px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
