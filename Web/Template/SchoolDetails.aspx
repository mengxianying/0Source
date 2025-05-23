<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SchoolDetails.aspx.cs" Inherits="Pbzx.Web.Template.SchoolDetails" %>
<%@ Register Src="../Contorls/UcSchol_list.ascx" TagName="UcSchol_list" TagPrefix="uc1" %>
<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
  <meta name="Keywords" content="{$Keywords$}" />
  <meta name="Description" content="{$Summary$}" />
  <title>{$Title$}_软件学院_拼搏在线彩神通软件</title>
  <meta name="robots" content="all" />
  <link href="/css/css.css" rel="stylesheet" type="text/css" />
  <link href="/css/bulletin.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js">
  </script>
  <script type="text/javascript" language="javascript" src="/reg.aspx?SchoolClick={$id$}">
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
  <link href="/css/school.css" rel="stylesheet" type="text/css" /> </head>

<body>
  <form name="form1" runat="server" id="form1">
    <uc2:Head ID="Head1" runat="server" />
    <!--主体部分--->
    <div class="bodyw MT">
      <!--左边--->
      <div id="C_lw1x">
        <div class="C_c1">
          <div class="title">
            <p> <span style="text-align: left; margin-left: 33px;">当前位置：{$Article_hot$}</span>
            </p>
          </div>
          <div class="content">
            <table width="88%" border="0" cellspacing="0" cellpadding="0" class="MT2" align="center">
              <tr>
                <td>
                  <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td class="B_explain">
                        <h3>
                                                    {$Title$}</h3> </td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td align="center" height="37" style="padding-bottom: 5px;"> &nbsp;<span class="song">{$DateAndTime$}</span> &nbsp;<span class="source">{$Source$}</span> </td>
              </tr>
              <tr>
                <td align="left">
                  <%-- <div style="text-align: center;"> {$myImg$}</div>--%>
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
          </table>
          <table width="99%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr>
              <td height="30" align="center"> &nbsp;
                <%-- <a href="#" onclick="window.close();">【关闭窗口】</a><a href="#" onclick="history.back(1)">【返回】</a>--%> </td>
            </tr>
          </table>
        </div>
      </div>
    </div>
    <!--右边--->
    <div id="C_list_rw1">
      <uc1:UcSchol_list ID="UcSchol_list1" runat="server" /> </div>
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
<script type="text/javascript" language="javascript">
  //  document.getElementById('click').innerText=clickcount;
</script>

