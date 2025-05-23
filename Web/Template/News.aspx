<%@ Page Language="C#" AutoEventWireup="true" Codebehind="News.aspx.cs" Inherits="Pbzx.Web.News" %>

<%@ Register Src="../Contorls/News_Hot.ascx" TagName="News_Hot" TagPrefix="uc8" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc7" %>
<%@ Register Src="../Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc6" %>
<%@ Register Src="../Contorls/NewsTypeTJ.ascx" TagName="NewsTypeTJ" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/NewsOneTableByType.ascx" TagName="NewsOneTableByType"
    TagPrefix="uc4" %>
<%@ Register Src="../Contorls/NewsOneTitleByType.ascx" TagName="NewsOneTitleByType"
    TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻资讯_拼搏在线彩神通软件</title>
    <meta name="keywords" content="新闻资讯" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />

    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"> </script>

    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divHeader">
                <uc1:Head ID="Head1" runat="server" />
            </div>
            <div id="news" class="bodyw MT8">
                <div class="N_l1">
                    <div class="N_lw1 N_box">
                        <div class="title">
                            <p>
                                <span>&nbsp;&nbsp;资讯类别</span></p>
                        </div>
                        <div class="content">
                            <div style="margin-left: 6px; margin-top: 4px; margin-bottom: 2px;">
                                <uc5:NewsTypeTJ ID="NewsTypeTJ1" runat="server" IntTypeLevel="3" />
                            </div>
                        </div>
                    </div>
                    <div class="N_box  N_lw1 MT">
                        <div class="title">
                            <p>
                                <a href="/News_list.aspx" class="more">更多>></a><span><a href="/News_list.aspx"><span>&nbsp;最新资讯</span></a></span></p>
                        </div>
                        <div class="content">
                            <uc8:News_Hot ID="News_Hot1" runat="server" IntChannelID="3" TitleLength="15"></uc8:News_Hot>
                        </div>
                    </div>
                    <div class="N_box  N_lw1 MT">
                        <div class="title">
                            <p>
                                <a href='/News_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>' class="more">
                                    更多>></a><span><a href='/News_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'><span>&nbsp;热点推荐</span></a></span></p>
                        </div>
                        <div class="content">
                            <uc8:News_Hot ID="News_Hot2" runat="server" IntChannelID="3" IsHot="1" TitleLength="15" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft1" runat="server" PlaceType="新闻首页左一" />
                    <uc6:UcJsADs ID="UcJsADsLeft1" runat="server" PlaceType="新闻首页左一JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft1" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft1" runat="server" Text=""></asp:Label></span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft1" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft2" runat="server" PlaceType="新闻首页左二" />
                    <uc6:UcJsADs ID="UcJsADsLeft2" runat="server" PlaceType="新闻首页左二JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft2" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft2" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft2" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft3" runat="server" PlaceType="新闻首页左三" />
                    <uc6:UcJsADs ID="UcJsADsLeft3" runat="server" PlaceType="新闻首页左三JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft3" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft3" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft3" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft4" runat="server" PlaceType="新闻首页左四" />
                    <uc6:UcJsADs ID="UcJsADsLeft4" runat="server" PlaceType="新闻首页左四JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft4" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft4" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft4" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft5" runat="server" PlaceType="新闻首页左五" />
                    <uc6:UcJsADs ID="UcJsADsLeft5" runat="server" PlaceType="新闻首页左五JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft5" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft5" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft5" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft6" runat="server" PlaceType="新闻首页左六" />
                    <uc6:UcJsADs ID="UcJsADsLeft6" runat="server" PlaceType="新闻首页左六JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft6" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft6" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft6" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft7" runat="server" PlaceType="新闻首页左七" />
                    <uc6:UcJsADs ID="UcJsADsLeft7" runat="server" PlaceType="新闻首页左七JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft7" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft7" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft7" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsLeft8" runat="server" PlaceType="新闻首页左八" />
                    <uc6:UcJsADs ID="UcJsADsLeft8" runat="server" PlaceType="新闻首页左八JS" />
                    <div class="N_box  N_lw1 MT" id="divLeft8" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblLeft8" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeLeft8" runat="server" TitleLength="15"
                                IntChannelID="3" />
                        </div>
                    </div>
                </div>
                <div class="N_c1w">
                    <div class="tupian" id="dvHDP">

                        <script type="text/javascript">

    $.ajax({ 
        type:'POST',
        url: '/reg.aspx', 
        data:'newsSlide=Yes',
        cache: false, 
        complete: function(msg,textStatus) { 
            if(msg.responsetext != "")
            {
                     var focus_width=506
                     var focus_height=240
                     var swf_height = focus_height 
                     var srcAndUrl = new   Array();
                      srcAndUrl = msg.responsetext.split('!');                      
                     var pics= srcAndUrl[0];
                     var links= srcAndUrl[1];
                     var result ="";
                     result +='<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">';
                     result +='<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/Images/UploadFiles/focus/focus.swf"><param name="quality" value="high"><param name="bgcolor" value="#F0F0F0">';
                     result +='<param name="menu" value="false"><param name=wmode value="opaque">';
                     result +='<param name="FlashVars" value="pics='+pics+'&links='+links+'&borderwidth='+focus_width+'&borderheight='+focus_height+'">';
                     result +='</object>';     
                     $("#divNewsSlide").html(result);              
            }
            else
            {
                document.getElementById("dvHDP").style.display = "none";                       
            }                                               
        } 
    });
                            
                        </script>

                        <div id="divNewsSlide">
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter1" runat="server" PlaceType="新闻首页中一" />
                    <uc6:UcJsADs ID="UcJsADsCenter1" runat="server" PlaceType="新闻首页中一JS" />
                    <div class="N_box N_c1 MT" id="divCenter1" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter1" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter1" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter2" runat="server" PlaceType="新闻首页中二" />
                    <uc6:UcJsADs ID="UcJsADsCenter2" runat="server" PlaceType="新闻首页中二JS" />
                    <div id="divCenter2" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter2" runat="server" Text=""></asp:Label></span>
                            </p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter2" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter3" runat="server" PlaceType="新闻首页中三" />
                    <uc6:UcJsADs ID="UcJsADsCenter3" runat="server" PlaceType="新闻首页中三JS" />
                    <div id="divCenter3" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter3" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter3" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter4" runat="server" PlaceType="新闻首页中四" />
                    <uc6:UcJsADs ID="UcJsADsCenter4" runat="server" PlaceType="新闻首页中四JS" />
                    <div id="divCenter4" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter4" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter4" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter5" runat="server" PlaceType="新闻首页中五" />
                    <uc6:UcJsADs ID="UcJsADsCenter5" runat="server" PlaceType="新闻首页中五JS" />
                    <div id="divCenter5" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter5" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter5" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter6" runat="server" PlaceType="新闻首页中六" />
                    <uc6:UcJsADs ID="UcJsADsCenter6" runat="server" PlaceType="新闻首页中六JS" />
                    <div id="divCenter6" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter6" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter6" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter7" runat="server" PlaceType="新闻首页中七" />
                    <uc6:UcJsADs ID="UcJsADsCenter7" runat="server" PlaceType="新闻首页中七JS" />
                    <div id="divCenter7" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter7" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter7" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsCenter8" runat="server" PlaceType="新闻首页中八" />
                    <uc6:UcJsADs ID="UcJsADsCenter8" runat="server" PlaceType="新闻首页中八JS" />
                    <div id="divCenter8" runat="server" class="N_box N_c1 MT">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblCenter8" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <div>
                                <uc4:NewsOneTableByType ID="NewsOneTableByTypeCenter8" runat="server" TitleLength="30"
                                    IntChannelID="3"></uc4:NewsOneTableByType>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="N_r1">
                    <div class="N_rw1 N_box" id="divRight1" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight1" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight1" runat="server" IntChannelID="3"
                                TitleLength="17" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight1" runat="server" PlaceType="新闻首页右一" />
                    <uc6:UcJsADs ID="UcJsADsRight1" runat="server" PlaceType="新闻首页右一JS" />
                    <div class="N_rw1 N_box MT">
                        <div class="title">
                            <p>
                                <span>&nbsp;&nbsp;资讯搜索</span></p>
                        </div>
                        <div class="content">
                            <div>
                                <table cellpadding="6" border="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <input type="text" id="txtSearch" onfocus='this.value=""' maxlength="80" value="请输入资讯关键字"
                                                style="width: 160px" class="input_border" />&nbsp;<input type="button" id="btnSearch"
                                                    value="搜索" onclick="newsSearch();" class="input_btnsearch" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight2" runat="server" PlaceType="新闻首页右二" />
                    <uc6:UcJsADs ID="UcJsADsRight2" runat="server" PlaceType="新闻首页右二JS" />
                    <div class="N_box  N_rw1 MT" id="divRight2" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight2" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight2" runat="server" TitleLength="17"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight3" runat="server" PlaceType="新闻首页右三" />
                    <uc6:UcJsADs ID="UcJsADsRight3" runat="server" PlaceType="新闻首页右三JS" />
                    <div class="N_box  N_rw1 MT" id="divRight3" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight3" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight3" runat="server" TitleLength="17"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight4" runat="server" PlaceType="新闻首页右四" />
                    <uc6:UcJsADs ID="UcJsADsRight4" runat="server" PlaceType="新闻首页右四JS" />
                    <div class="N_box  N_rw1 MT" id="divRight4" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight4" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight4" runat="server" TitleLength="17"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight5" runat="server" PlaceType="新闻首页右五" />
                    <uc6:UcJsADs ID="UcJsADsRight5" runat="server" PlaceType="新闻首页右五JS" />
                    <div class="N_box  N_rw1 MT" id="divRight5" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight5" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight5" runat="server" TitleLength="17"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight6" runat="server" PlaceType="新闻首页右六" />
                    <uc6:UcJsADs ID="UcJsADsRight6" runat="server" PlaceType="新闻首页右六JS" />
                    <div class="N_box  N_rw1 MT" id="divRight6" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight6" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight6" runat="server" TitleLength="17"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight7" runat="server" PlaceType="新闻首页右七" />
                    <uc6:UcJsADs ID="UcJsADsRight7" runat="server" PlaceType="新闻首页右七JS" />
                    <div class="N_box  N_rw1 MT" id="divRight7" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight7" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight7" runat="server" TitleLength="17"
                                IntChannelID="3" />
                        </div>
                    </div>
                    <uc7:UcPicAds ID="UcPicAdsRight8" runat="server" PlaceType="新闻首页右八" />
                    <uc6:UcJsADs ID="UcJsADsRight8" runat="server" PlaceType="新闻首页右八JS" />
                    <div class="N_box  N_rw1 MT" id="divRight8" runat="server">
                        <div class="title">
                            <p>
                                <span>
                                    <asp:Label ID="lblRight8" runat="server" Text=""></asp:Label></span></p>
                        </div>
                        <div class="content">
                            <uc3:NewsOneTitleByType ID="NewsOneTitleByTypeRight8" runat="server" TitleLength="17"
                                IntChannelID="3" />
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
