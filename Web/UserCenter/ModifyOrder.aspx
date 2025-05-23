<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ModifyOrder.aspx.cs" Inherits="Pbzx.Web.UserCenter.ModifyOrder" %>

<%@ Register Src="../Contorls/ShopServers.ascx" TagName="ShopServers" TagPrefix="uc7" %>

<%@ Register Src="../Contorls/AddOrder.ascx" TagName="AddOrder" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/UcAddOrder.ascx" TagName="UcAddOrder" TagPrefix="uc6" %>
<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc4" %>
<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/OrderInfo.ascx" TagName="OrderInfo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head11">
    <title>查看订单_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />  
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc4:Head ID="Head1" runat="server" />
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="750" valign="top">
            <div id="OrderDetail">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT MB">
     <tr>
       <td><img src="/Images/Web/shop_wei1.jpg" width="750" height="30" /></td>
     </tr>
   </table>    
                <uc1:OrderDetail ID="OrderDetail1" runat="server" />
                <br />
                <uc6:UcAddOrder ID="AddOrder1" runat="server" OnModifyOrdersClick="ModifyOrdersClick" />       
            </div>
            </td>
    <td width="10"></td>
    <td width="230" valign="top">
        <uc7:ShopServers ID="ShopServers1" runat="server" />
    </td>
        </tr>
      </table>
            <uc5:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
