<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinDetails.aspx.cs" Inherits="Pbzx.Web.Template.BulletinDetails" %>
<%@ Register Src="../Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc9" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc8" %>
<%@ Register Src="../Contorls/Bulletin_Hot_List.ascx" TagName="Bulletin_Hot_List" TagPrefix="uc7" %>
<%@ Register Src="../Contorls/Bulletin_Hot.ascx" TagName="Bulletin_Hot" TagPrefix="uc6" %>
<%@ Register Src="../Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc4" %>
<%@ Register Src="../Contorls/BulletinClass.ascx" TagName="BulletinClass" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Bulletin_l.ascx" TagName="Bulletin_l" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta name="Keywords" content="{$Keywords$}" />
  <meta name="Description" content="{$Summary$}" />
  <title> {$Title$}_网站公告_拼搏在线彩神通软件 </title>
  <meta name="robots" content="all" />
  <link href="/css/css.css" rel="stylesheet" type="text/css" />
  <link href="/css/bulletin.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js">
  </script>
  <script type="text/javascript" language="javascript" src="/reg.aspx?BulletinClick={$id$}">
  </script>
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
    /*IE 6 and below. Adjust non linked LIs slightly to account
      for bugs*/
    
    margin-right: 5px;
    padding-right: 0;
  }
  .STYLE3 {
    font-size: 12px;
    padding: 10px;
  }
  -->
  </style>
  <!-- <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css"
    />
    -->
</head>

<body>
  <form id="form1" runat="server">
    <div>
      <uc2:Head ID="Head1" runat="server" /> </div>
    <!--主体部分--->
    <!-- <div class="bodyw MT8" id="DIVTonglan" runat="server" visible="false">
      <%=Tonglan%>
      </div>
      -->
    <!--主体部分--->
    <div class="MT8 bodyw">
      <!--左边--->
      <div class="B_list_l1">
        <div class="B_list_l1bg">
          <div class="title">
            <p> <span style="text-align: left; margin-left: 32px;">
                  当前位置：{$Article_hot$}
                </span> </p>
          </div>
          <div class="content">
            <div>
              <table width="90%" border="0" cellspacing="0" cellpadding="0" align="center">
                <tr>
                  <td style="height: 55px">
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr>
                        <td class="B_explain">
                          <h3>
                              {$Title$}
                            </h3> </td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td align="center" height="37" style="padding-bottom: 5px;"> &nbsp; <span class="song">
                        {$DateAndTime$}
                      </span> &nbsp; <span class="source">
                        {$Source$}
                      </span> </td>
                </tr>
                <tr>
                  <td align="left">
                    <%--<div style="text-align: center;"> {$myImg$} </div> --%>
            <table style="width: 100%">
              <tr>
                <td class="B_explain_zi"> {$Content$} </td>
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
                <uc8:UcPicAds ID="UcPicAds1" PlaceType="公告详细页正文下面" runat="server" />
                <uc4:UcJsADs ID="UcJsADs2" PlaceType="公告详细页正文下面JS" runat="server" /> </td>
            </tr>
            </table>
          </div>
          <table width="99%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr>
              <td height="30" align="right">
                <%-- <a href="#" onclick="window.close();"> 【关闭窗口】 </a> --%> </td>
            </tr>
          </table>
        </div>
      </div>
    </div>
    <!--右边--->
    <div class="B_r1">
      <div id="redian" class="B_boxr">
        <div class="title">
          <p> <span>
                公告类别
              </span> </p>
        </div>
        <div class="content" style="text-align: center;">
          <table width="95%" border="0" cellspacing="0" cellpadding="2" align="center">
            <tr>
              <td width="72%" align="center">
                <uc5:BulletinClass ID="BulletinClass1" runat="server" /> </td>
            </tr>
          </table>
        </div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT" background="/images/web/Bulletin_search.jpg" height="58">
          <tr>
            <td>
              <table width="100%" border="0" cellpadding="2" cellspacing="0">
                <tr>
                  <td class="Bulletin_search_zi"> 公告搜索 </td>
                </tr>
                <tr>
                  <td align="center"> 关键字:
                    <input type="text" id="txtSearchKey" onfocus='this.value=""' maxlength="80" style="width: 120px" class="input_border" /> &nbsp;
                    <input type="button" id="Button1" value="搜索" onclick="bulletinSearch();" class="input_btnsearch" /> &nbsp;&nbsp; </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
        <div class="B_list_boxr MT">
          <div class="title">
            <p> <a href="/Bulletin_list.aspx" class='more'>
                  更多>>
                </a> <span>
                  <a href="/Bulletin_list.aspx">
                    最新公告
                  </a>
                </span> </p>
          </div>
          <div class="content">
            <uc7:Bulletin_Hot_List ID="Bulletin_Hot_List1" runat="server" TitleLength="17"> </uc7:Bulletin_Hot_List>
          </div>
        </div>
        <div class="B_list_boxr MT">
          <div class="title">
            <p> <a href='/Bulletin_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>' class='more'>
                  更多>>
                </a> <span>
                  <a href='/Bulletin_list.aspx?BitIsHot=<%=Pbzx.Common.Input.Encrypt("1") %>'>
                    热点推荐
                  </a>
                </span> </p>
          </div>
          <div class="content">
            <uc7:Bulletin_Hot_List ID="Bulletin_Hot_List2" runat="server" IsHot="1" TitleLength="17" /> </div>
          <div>
            <uc8:UcPicAds ID="UcPicAds2" PlaceType="公告详细页右下" runat="server" />
            <uc4:UcJsADs ID="UcJsADs1" runat="server" IntWidth="206" PlaceType="公告详细页右下JS" /> </div>
        </div>
        <div class="B_list_boxr MT">
          <div class="title">
            <p> <span>
                  在线客服
                </span> </p>
          </div>
          <div class="content">
            <div style="margin-left: 5px;">
              <uc9:UC_QQ ID="UC_QQ1" runat="server" /> </div>
          </div>
        </div>
      </div>
    </div>
    </div>
    <!--网站底部--->
    <uc3:Footer ID="Footer1" runat="server" /> </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
<script type="text/javascript">
    ;
    $(function () {
        $("#spClick").text(clickcount);
    });
</script>

</html>
