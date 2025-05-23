<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bulletin.aspx.cs" Inherits="Pbzx.Web.Bulletin"
    EnableViewState="false" %>

<%@ Register Src="../Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc13" %>
<%@ Register Src="../Contorls/Bulletin_news.ascx" TagName="Bulletin_news" TagPrefix="uc12" %>
<%@ Register Src="../Contorls/Bulletin_Hot.ascx" TagName="Bulletin_Hot" TagPrefix="uc11" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc10" %>
<%@ Register Src="../Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc9" %>
<%@ Register Src="../Contorls/BulletinClass.ascx" TagName="BulletinClass" TagPrefix="uc8" %>
<%@ Register Src="../Contorls/OtherSoft2.ascx" TagName="OtherSoft" TagPrefix="uc7" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Bulletin_l.ascx" TagName="Bulletin_l" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Bulletin_c.ascx" TagName="Bulletin_c" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/new_search.ascx" TagName="search" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站公告_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"></script>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/bulletin.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />   
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <div>
            <!--TOP开始--->
            <!--主体部分--->
            <div class="bodyw MT8" id="DIVTonglan" runat="server" visible="false">
                <%=Pbzx.Common.Input.Encrypt("1") %>
            </div>
            <div id="zhuti" class="MT8 bodyw">
                <!--左边--->
                <div class="B_l1">
                    <div class="B_boxl">
                        <div class="title">
                            <p>
                                <span>公告类别</span></p>
                        </div>
                        <div class="content">
                            <table width="98%" border="0" cellspacing="0" cellpadding="3" align="center" style="margin-left: 3px;">
                                <tr>
                                    <td>
                                        <uc8:BulletinClass ID="BulletinClass1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="B_boxl MT">
                        <div class="title">
                            <p>
                                <a href='/Bulletin_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>' class="more">
                                    更多>></a><span><a href='/Bulletin_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'>热点推荐</a></span></p>
                        </div>
                        <div class="content">
                            <uc11:Bulletin_Hot ID="Bulletin_Hot1" runat="server" IsHot="1" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft1" runat="server" PlaceType="公告首页左一" />
                    <uc9:UcJsADs ID="UcJsADsLeft1" runat="server" PlaceType="公告首页左一JS" />
                    <div id="dvLeft1" class="B_boxl MT" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft1" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l1" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft2" runat="server" PlaceType="公告首页左二" />
                    <uc9:UcJsADs ID="UcJsADsLeft2" runat="server" PlaceType="公告首页左二JS" />
                    <div class="B_boxl MT" id="dvLeft2" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft2" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l2" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft3" runat="server" PlaceType="公告首页左三" />
                    <uc9:UcJsADs ID="UcJsADsLeft3" runat="server" PlaceType="公告首页左三JS" />
                    <div id="dvLeft3" class="B_boxl MT" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft3" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l3" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft4" runat="server" PlaceType="公告首页左四" />
                    <uc9:UcJsADs ID="UcJsADsLeft4" runat="server" PlaceType="公告首页左四JS" />
                    <div class="B_boxl MT" id="dvLeft4" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft4" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l4" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft5" runat="server" PlaceType="公告首页左五" />
                    <uc9:UcJsADs ID="UcJsADsLeft5" runat="server" PlaceType="公告首页左五JS" />
                    <div class="B_boxl MT" id="dvLeft5" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft5" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l5" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft6" runat="server" PlaceType="公告首页左六" />
                    <uc9:UcJsADs ID="UcJsADsLeft6" runat="server" PlaceType="公告首页左六JS" />
                    <div class="B_boxl MT" id="dvLeft6" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft6" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l6" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft7" runat="server" PlaceType="公告首页左七" />
                    <uc9:UcJsADs ID="UcJsADsLeft7" runat="server" PlaceType="公告首页左七JS" />
                    <div class="B_boxl MT" id="dvLeft7" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft7" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l7" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsLeft8" runat="server" PlaceType="公告首页左八" />
                    <uc9:UcJsADs ID="UcJsADs7" runat="server" PlaceType="公告首页左八JS" />
                    <div class="B_boxl MT" id="dvLeft8" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblLeft8" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:Bulletin_l ID="Bulletin_l8" runat="server" TitleLength="16" />
                        </div>
                    </div>
                    <div class="B_boxl MT" runat="server">
                        <div class="title">
                            <p>
                                <span style="margin-left: 22px;">在线客服</span>
                            </p>
                        </div>
                        <div class="content">
                            <uc13:UC_QQ ID="UC_QQ1" runat="server" />
                        </div>
                    </div>
                </div>
                <!--中间--->
                <div class="B_c1">
                    <div id="redian2" class="B_boxc">
                        <div class="title">
                            <p>
                                <a href="/Bulletin_list.aspx" class="more">更多>></a><span><a href="/Bulletin_list.aspx">最新公告</a></span></p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc12:Bulletin_news ID="Bulletin_news1" runat="server" TitleLength="29"></uc12:Bulletin_news>
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAds1" runat="server" PlaceType="公告首页中一" />
                    <uc9:UcJsADs ID="UcJsADs1" runat="server" PlaceType="公告首页中一JS" />
                    <div id="divCenter1" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter1" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div class="B_boxc_border">
                                <uc7:OtherSoft ID="OtherSoft1" runat="server" />
                            </div>
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c1" runat="server" TitleLength="30" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter2" runat="server" PlaceType="公告首页中二" />
                    <uc9:UcJsADs ID="UcJsADsCenter2" runat="server" PlaceType="公告首页中二JS" />
                    <div id="divCenter2" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter2" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c2" runat="server" TitleLength="30" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter3" runat="server" PlaceType="公告首页中三" />
                    <uc9:UcJsADs ID="UcJsADsCenter3" runat="server" PlaceType="公告首页中三JS" />
                    <div id="divCenter3" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter3" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c3" runat="server" TitleLength="23" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter4" runat="server" PlaceType="公告首页中四" />
                    <uc9:UcJsADs ID="UcJsADsCenter4" runat="server" PlaceType="公告首页中四JS" />
                    <div id="divCenter4" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter4" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c4" runat="server" TitleLength="23" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter5" runat="server" PlaceType="公告首页中五" />
                    <uc9:UcJsADs ID="UcJsADs5" runat="server" PlaceType="公告首页中五JS" />
                    <div id="divCenter5" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter5" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c5" runat="server" TitleLength="23" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter6" runat="server" PlaceType="公告首页中六" />
                    <uc9:UcJsADs ID="UcJsADs6" runat="server" PlaceType="公告首页中六JS" />
                    <div id="divCenter6" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter6" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c6" runat="server" TitleLength="23" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter7" runat="server" PlaceType="公告首页中七" />
                    <uc9:UcJsADs ID="UcJsADsCenter7" runat="server" PlaceType="公告首页中七JS" />
                    <div id="divCenter7" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter7" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c7" runat="server" TitleLength="23" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsCenter8" runat="server" PlaceType="公告首页中八" />
                    <uc9:UcJsADs ID="UcJsADsCenter8" runat="server" PlaceType="公告首页中八JS" />
                    <div id="divCenter8" runat="server" class="B_boxc MT">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblCenter8" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <div class="content">
                            <div class="B_boxc2">
                                <uc4:Bulletin_c ID="Bulletin_c8" runat="server" TitleLength="23" />
                            </div>
                        </div>
                    </div>
                </div>
                <!--右边--->
                <div class="B_r1">
                    <div class="B_boxr2" id="divRight1" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight1" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r1" runat="server" ClassCss="newslink1" TitleLength="18" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight1" runat="server" PlaceType="公告首页右一" />
                    <uc9:UcJsADs ID="UcJsADsRight1" runat="server" PlaceType="公告首页右一JS" />
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT"
                        background="/images/web/Bulletin_search.jpg" height="58">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td align="left" class="Bulletin_search_zi">
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
                    <uc10:UcPicAds ID="UcPicAdsRight2" runat="server" PlaceType="公告首页右二" />
                    <uc9:UcJsADs ID="UcJsADsRight2" runat="server" PlaceType="公告首页右二JS" />
                    <div class="B_boxr2 MT" id="divRight2" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight2" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r2" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight3" runat="server" PlaceType="公告首页右三" />
                    <uc9:UcJsADs ID="UcJsADsRight3" runat="server" PlaceType="公告首页右三JS" />
                    <div class="B_boxr2 MT" id="divRight3" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight3" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r3" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight4" runat="server" PlaceType="公告首页右四" />
                    <uc9:UcJsADs ID="UcJsADsRight4" runat="server" PlaceType="公告首页右四JS" />
                    <div class="B_boxr2 MT" id="divRight4" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight4" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r4" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight5" runat="server" PlaceType="公告首页右五" />
                    <uc9:UcJsADs ID="UcJsADsRight5" runat="server" PlaceType="公告首页右四JS" />
                    <div class="B_boxr2 MT" id="divRight5" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight5" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r5" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight6" runat="server" PlaceType="公告首页右六" />
                    <uc9:UcJsADs ID="UcJsADsRight6" runat="server" PlaceType="公告首页右六JS" />
                    <div class="B_boxr2 MT" id="divRight6" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight6" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r6" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight7" runat="server" PlaceType="公告首页右七" />
                    <uc9:UcJsADs ID="UcJsADsRight7" runat="server" PlaceType="公告首页右七JS" />
                    <div class="B_boxr2 MT" id="divRight7" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight7" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r7" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                    <uc10:UcPicAds ID="UcPicAdsRight8" runat="server" PlaceType="公告首页右八" />
                    <uc9:UcJsADs ID="UcJsADsRight8" runat="server" PlaceType="公告首页右八JS" />
                    <div class="B_boxr2 MT" id="divRight8" runat="server">
                        <div class="title">
                            <p>
                                <asp:Label ID="lblRight8" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="content">
                            <div style="padding-left: 7px; padding-top: 3px; padding-bottom: 1px;">
                                <uc5:Bulletin_r ID="Bulletin_r8" runat="server" TitleLength="18" ClassCss="newslink1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--bottom开始--->
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
