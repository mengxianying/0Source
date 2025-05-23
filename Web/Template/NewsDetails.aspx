<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NewsDetails.aspx.cs" Inherits="Pbzx.Web.Template.NewsDetails" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc8" %>
<%@ Register Src="../Contorls/News_Hot.ascx" TagName="News_Hot" TagPrefix="uc7" %>
<%@ Register Src="../Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc6" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/NewsOneTitleByType.ascx" TagName="NewsOneTitleByType" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/new_search2.ascx" TagName="new_search2" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/NewsTypeTJ.ascx" TagName="NewsTypeTJ" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta name="Keywords" content="{$Keywords$}" />
  <meta name="Description" content="{$Summary$}" />
  <title>{$Title$}_新闻资讯_拼搏在线彩神通软件</title>
  <meta name="robots" content="all" />
  <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js">
  </script>
  <script type="text/javascript" language="javascript" src="/reg.aspx?NewsClick={$id$}">
  </script>
  <link href="/css/css.css" rel="stylesheet" type="text/css" />
  <link href="/css/news.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
  <!-- .pagination {
    padding: 2px;
  }
  .pagination ul {
    margin: 0;
    padding: 0;
    text-align: left;
    /*Set to "right" to right align pagination interface*/
    
    font-size: 16px;
  }
  .pagination li {
    margin-left: 5px;
    list-style-type: none;
    display: inline;
    padding-bottom: 1px;
  }
  .pagination a,
  .pagination a:visited {
    padding: 0 5px;
    border: 1px solid #9aafe5;
    text-decoration: none;
    color: #2e6ab1;
  }
  .pagination a:hover,
  .pagination a:active {
    border: 1px solid #2b66a5;
    color: #000;
    background-color: lightyellow;
  }
  .pagination li.currentpage {
    font-weight: bold;
    padding: 0 5px;
    border: 1px solid navy;
    background-color: #2e6ab1;
    color: #FFF;
  }
  .pagination li.disablepage {
    padding: 0 5px;
    border: 1px solid #929292;
    color: #929292;
    font-size: 13px;
  }
  .pagination li.nextpage {
    font-weight: bold;
  }
  * html .pagination li.currentpage,
  * html .pagination li.disablepage {
    /*IE 6 and below. Adjust non linked LIs slightly to account for bugs*/
    
    margin-right: 5px;
    padding-right: 0;
  }
  .STYLE3 {
    font-size: 12px;
    padding: 10px;
  }
  -->
  </style>
</head>

<body>
  <form id="form1" runat="server">
    <div>
      <!--网站头部--->
      <uc5:Head ID="Head1" runat="server" /> </div>
    <div class="bodyw MT news">
      <!--左边--->
      <div class="N_list_r1x">
        <div class="N_list_r1">
          <div class="title">
            <p> <span style="text-align: left; margin-left: 33px;">当前位置：{$Article_hot$}</span>
            </p>
          </div>
          <div class="content">
            <div>
              <table width="88%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td>
                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-top: 3px;">
                      <tr>
                        <td class="N_explain">
                          <h3>
                                                        {$Title$}</h3> </td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td align="center" height="37" style="padding-bottom: 5px;"> &nbsp;<span class="song">{$DateAndTime$}</span> &nbsp;来源：<span class="N_explain_zi2">{$Source$}</span> </td>
                </tr>
                <tr>
                  <td align="left">
                    <%--<div style="text-align: center;"> {$myImg$}</div>--%>
            <table style="width: 100%">
              <tr>
                <td class="N_explain_zi"> {$Content$} </td>
              </tr>
              <tr>
                <td align="right">
                  <p /> {$SinaWiki} </td>
              </tr>
            </table>
            </td>
            </tr>
            <tr>
              <td>
                <uc8:UcPicAds ID="UcPicAdsCenter1" PlaceType="新闻详细页正文下面" runat="server" />
                <uc6:UcJsADs ID="UcJsADsCenter1" runat="server" PlaceType="新闻详细页正文下面JS" /> </td>
            </tr>
            </table>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
              <tr>
                <td height="30" align="center">
                  <%--<a href="#" onclick="window.close();">【关闭窗口】</a><a href="#" onclick="history.back(1)">【返回】</a>--%> </td>
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
          <p> <span>&nbsp;&nbsp;资讯类别</span>
          </p>
        </div>
        <div class="content">
          <div style="margin-left: 6px; margin-top: 4px; margin-bottom: 2px;">
            <uc1:NewsTypeTJ ID="NewsTypeTJ2" runat="server" IntTypeLevel="3" /> </div>
        </div>
      </div>
      <div class="N_lw1 N_box MT">
        <div class="title">
          <p> <span>&nbsp;&nbsp;资讯搜索</span>
          </p>
        </div>
<!--
        <div class="content">
          <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 5px;"> &nbsp;
            <input type="text" id="txtSearch" onfocus='this.value=""' maxlength="80" value="请输入资讯关键字" style="width: 120px" class="input_border" />&nbsp;
            <input type="button" id="btnSearch" value="搜索" onclick="newsSearch();" class="input_btnsearch" /> </div>
        </div>
-->
        <td>
            <input type="text" id="txtSearch" onfocus='this.value=""' maxlength="80" value="请输入资讯关键字"
                style="width: 120px" class="input_border" />&nbsp;<input type="button" id="btnSearch"
                    value="搜索" onclick="newsSearch();" class="input_btnsearch" />
        </td>

      </div>
      <div class="N_box  N_lw1 MT8">
        <div class="title">
          <p> <a href="/News_list.aspx" class='more'>更多>></a><span><a href="/News_list.aspx"><span
                                class="title2">&nbsp;最新资讯</span>
            </a>
            </span>
          </p>
        </div>
        <div class="content">
          <uc7:News_Hot ID="News_Hot1" runat="server" IntChannelID="3" TitleLength="14" /> </div>
      </div>
      <div class="N_box  N_lw1 MT">
        <div class="title">
          <p> <a href='/News_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>' class='more'>
                                更多>></a><span><a href='/News_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'><span
                                    class="title2">&nbsp;热点推荐</span>
            </a>
            </span>
          </p>
        </div>
        <div class="content">
          <uc7:News_Hot ID="News_Hot2" runat="server" IntChannelID="3" IsHot="1" TitleLength="14" /> </div>
      </div>
      <div>
        <uc8:UcPicAds ID="UcPicAds1" runat="server" PlaceType="新闻资讯详细页面左下" />
        <uc6:UcJsADs ID="UcJsADs1" runat="server" IntWidth="206" PlaceType="新闻资讯详细页面左下JS" /> </div>
    </div>
    </div>
    <!--网站底部--->
    <uc4:Footer ID="Footer1" runat="server" /> </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
<script type="text/javascript">
    ;
    $(function () {
        $("#spClick").text(clickcount);
    });
</script>
</html>
<script type="text/javascript" language="javascript">    
 //   document.getElementById('click').innerText=unescape(clickcount);
</script>

