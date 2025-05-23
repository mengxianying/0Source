<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Broker_System.aspx.cs" Inherits="Pbzx.Web.Broker_System" %>

<%@ Register Src="Contorls/Broker.ascx" TagName="Broker" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>申请经纪人_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
      <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/broker.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc2:Head ID="Head1" runat="server" />
    <div class="bodyw MT">
<!---左边--->
<div class="br_l">
    <uc1:Broker ID="Broker1" runat="server" />
    </div>
<!---右边--->
<div class="br_r">
<%--   <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><img src="images/web/br_banner.jpg" width="770" height="88" /></td>
    </tr>
  </table>--%>
  <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0">   
    <tr>
      <td bgcolor="#FFFFFF">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">      
       <tr>
      <td background="/Images/Web/br_rbg.jpg" height="27" class="br_rZ">
          彩神通经纪人奖励制度
      </td>
    </tr>
      </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="4">
        <tr>
		
          <td align="left" class="br_z">

<table width="97%" border="0" cellspacing="0" cellpadding="0"  align="center" class="MT">
  <tr>    
    <td width="95%" align="center" class="br_biao br_xia" height="32">
        彩神通经纪人奖励制度</td>
  </tr>
</table>
<table width="96%" border="0" align="center" cellpadding="5" cellspacing="0">
  <tr>
    <td>（一）、符合以下条件之一者，奖励标准为 “10%”：<br />
1、推广『彩神通』软件数字三（专业版）终身客户（1~4）套；<br />
2、推广『彩神通』系列其它类别软件，按同步市场价格合计（1000~4000）元；<br />
（二）、符合以下条件之一者，奖励标准为 “15%”：<br />
1、推广『彩神通』软件数字三（专业版）终身客户（5~9）套；<br />
2、推广『彩神通』系列多种类别软件，按同步市场价格合计（4000~9000）元；<br />
（三）、符合以下条件之一者，奖励标准为 “20%（注：奖励最高封顶即20%）”：<br />
1、推广『彩神通』软件数字三（专业版）终身客户≥10套以上；<br />
2、推广『彩神通』系列多种类别软件，按同步市场价格合计≥10000元以上。

</td>
  </tr>
</table>
</td>
        </tr>
      </table></td>
    </tr>
  </table>
</div>
</div>
    </div>
        <uc3:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
