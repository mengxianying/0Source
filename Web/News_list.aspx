<%@ Page Language="C#" AutoEventWireup="true" Codebehind="News_list.aspx.cs" Inherits="Pbzx.Web.News_list" %>

<%@ Register Src="Contorls/News_Hot.ascx" TagName="News_Hot" TagPrefix="uc7" %>
<%@ Register Src="Contorls/NewsOneTitleByType.ascx" TagName="NewsOneTitleByType"
    TagPrefix="uc6" %>
<%@ Register Src="Contorls/NewsTypeTJ.ascx" TagName="NewsTypeTJ" TagPrefix="uc5" %>
<%@ Register Src="Contorls/NewClass.ascx" TagName="NewClass" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/new_search2.ascx" TagName="search" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻资讯_拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩票资讯,新闻，获奖故事" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/news.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"> </script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--TOP开始--->
            <uc1:Head ID="Head1" runat="server" />
            <!--主体部分--->
            <div class="bodyw MT8 news">
                <!--左边--->
                <div class="N_list_r1x">
                    <div class="N_list_r1">
                        <div class="title">
                            <p>
                                <span  style="text-align: left; margin-left: 33px;">当前位置：<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>"  target="_self"
                                    class="school">拼搏在线彩神通软件</a> >> <a href="/News.htm"  target="_self" class="school">新闻资讯</a> >> <asp:Label ID="lblTypeName" runat="server" Text=""></asp:Label>
                                </span>
                            </p>
                        </div>
                        <div class="content">
                            <div>
                                <asp:Repeater ID="rpt_list" runat="server">
                                    <HeaderTemplate>
                                        <table width="95%" border="0" align="center" cellpadding="1" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" class="N_xia">
                                                <img src="/images/web/N_li1.jpg" width="10" height="10" /></td>
                                            <td width="84%" align="left" class="N_xia">
                                                <a href="<%# Eval("SavePath") %>" target="_blank">
                                                    <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"), 70)%>
                                                </a>
                                            </td>
                                            <td width="12%" align="left" class="N_xia new_Time">
                                                <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1">
                                    <tr>
                                        <td align="center" style="height: 28px">
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                FirstPageText="首页┊" LastPageText="尾页" NextPageText="下一页┊"
                                                OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页┊" ShowCustomInfoSection="Right"
                                                ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="25">
                                            </webdiyer:AspNetPager>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!--右边--->
                <div class="N_l1x">
                    <div class="N_lw1 N_box">
                        <div class="title">
                            <p>
                                <span>&nbsp;&nbsp;资讯类别</span></p>
                        </div>
                        <div class="content">
                            <div>
                                <div style="margin-left: 6px; margin-top: 2px; margin-bottom: 1px;">
                                    <uc5:NewsTypeTJ ID="NewsTypeTJ1" runat="server" TitleLength="7" IntTypeLevel="3" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="N_lw1 N_box MT">
                        <div class="title">
                            <p>
                                <span>&nbsp;&nbsp;资讯搜索</span></p>
                        </div>
                        <div class="content">
                            <div>
                                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 5px;">
                                    &nbsp;<input type="text" id="txtSearch" onfocus='this.value=""' maxlength="80" value="请输入资讯关键字"
                                        style="width: 135px" class="input_border" />&nbsp;<input type="button" id="btnSearch"
                                            value="搜索" onclick="newsSearch();" class="input_btnsearch" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="N_box  N_lw1 MT">
                        <div class="title">
                            <p>
                                <a href="/News_list.aspx" class='more'>更多>></a><span><a href="/News_list.aspx"><span
                                    class="title2">&nbsp;最新资讯</span></a></span></p>
                        </div>
                        <div class="content">
                            <uc7:News_Hot ID="News_Hot1" runat="server"  IntChannelID="3" TitleLength="15" />
                        </div>
                    </div>
                    <div class="N_box  N_lw1 MT">
                        <div class="title">
                            <p>
                               <a href='/News_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>' class='more'>更多>></a><span><a href='/News_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'><span
                                    class="title2">&nbsp;热点推荐</span></a></span></p>
                        </div>
                        <div class="content">
                            <uc7:News_Hot ID="News_Hot2" runat="server" IntChannelID="3" IsHot="1"
                                TitleLength="15" />
                        </div>
                    </div>
                </div>
            </div>
            <!--bottom开始--->
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
