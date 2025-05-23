<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bulletin_list.aspx.cs"
    Inherits="Pbzx.Web.Bulletin_list" %>

<%@ Register Src="Contorls/Bulletin_Hot.ascx" TagName="Bulletin_Hot" TagPrefix="uc7" %>
<%@ Register Src="Contorls/Bulletin_l.ascx" TagName="Bulletin_l" TagPrefix="uc6" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc5" %>
<%@ Register Src="Contorls/BulletinClass.ascx" TagName="BulletinClass" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/new_search.ascx" TagName="search" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站公告列表 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩神通软件www.pinble.com" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/bulletin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"> </script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--TOP开始--->
        <uc1:Head ID="Head1" runat="server" />
        <!--主体部分--->
        <div class="bodyw MT8" id="DIVTonglan" runat="server" visible="false">
            <asp:Label ID="lblTonglan" runat="server" Text=""></asp:Label>
        </div>
        <div id="zhuti" class="MT8 bodyw">
            <!--左边--->
            <div class="B_list_l1">
                <div class="B_list_l1bg">
                    <div class="title">
                        <p style="text-align: left;">
                            <span style="text-align: left; margin-left:32px;">当前位置：<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>"
                                target="_self" class="school">拼搏在线彩神通软件首页</a> >> <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Bulletin.htm"
                                    class="school" target="_self">网站公告</a> >>
                                <asp:Label ID="lblTypeName" runat="server"></asp:Label>
                            </span>
                        </p>
                    </div>
                    <div class="content">
                        <asp:Repeater ID="rpt_list" runat="server">
                            <HeaderTemplate>
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr bgcolor="#ffffff">
                                    <td width="3%" style="height: 27px">
                                        <img src="/Images/Web/B_li2.gif" width="11" height="10" /></td>
                                    <td width="79%" align="left">
                                        <a href="<%# Eval("SavePath") %>" target="_blank"><font color='<%#Convert.ToBoolean(Eval("BitIsTop"))?"red":"" %>'>
                                            <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),76)%>
                                        </font></a>
                                    </td>
                                    <td width="18%">
                                        <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr bgcolor="#F0F1FF">
                                    <td width="3%" style="height: 27px">
                                        <img src="/Images/Web/B_li2.gif" width="11" height="10" /></td>
                                    <td width="79%" align="left">
                                        <a href="<%# Eval("SavePath") %>" target="_blank"><font color='<%#Convert.ToBoolean(Eval("BitIsTop"))?"red":"" %>'>
                                            <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),76)%>
                                        </font></a>
                                    </td>
                                    <td width="18%">
                                        <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoTextAlign="Center"
                                        FirstPageText="首页┊" LastPageText="尾页" NextPageText="下一页┊" OnPageChanged="AspNetPager1_PageChanged"
                                        PrevPageText="上一页┊" ShowCustomInfoSection="Right" ShowNavigationToolTip="True"
                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="0">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <!--右边--->
            <div class="B_r1">
                <div id="redian" class="B_boxr">
                    <div class="title">
                        <p>
                            <span>公告类别</span></p>
                    </div>
                    <div class="content">
                        <div>
                            <uc4:BulletinClass ID="BulletinClass1" runat="server"></uc4:BulletinClass>
                        </div>
                    </div>
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT"
                        background="/images/web/Bulletin_search.jpg" height="58">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td class="Bulletin_search_zi">
                                            公告搜索</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            关键字:<input type="text" id="txtSearchKey" onfocus='this.value=""' maxlength="80" style="width: 120px"
                                                class="input_border" />&nbsp;<input type="button" id="Button1" value="搜索" onclick="bulletinSearch();"
                                                    class="input_btnsearch" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="B_list_boxr MT">
                        <div class="title">
                            <p>
                                <a href="/Bulletin_list.aspx" class='more'>更多>></a><span><a href="/Bulletin_list.aspx">最新公告</a></span></p>
                        </div>
                        <div class="content">
                            <uc7:Bulletin_Hot ID="Bulletin_Hot1" runat="server" Count="8" TitleLength="17" />
                        </div>
                    </div>
                    <div class="B_list_boxr MT">
                        <div class="title">
                            <p>
                                <a href='/Bulletin_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>' class='more'>
                                    更多>></a><span><a href='/Bulletin_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'>热点推荐</a></span>
                            </p>
                        </div>
                        <div class="content">
                            <uc7:Bulletin_Hot ID="Bulletin_Hot2" runat="server" Count="8" IsHot="1" TitleLength="17" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--bottom开始--->
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
