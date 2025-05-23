<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrderAgent.aspx.cs" Inherits="Pbzx.Web.UserCenter.AddOrderAgent" %>


<%@ Register Src="../Contorls/ShopServers.ascx" TagName="ShopServers" TagPrefix="uc6" %>

<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc4" %>
<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc5" %>

<%@ Register Src="~/Contorls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<%@ Register Src="~/Contorls/ShoppingCartList.ascx" TagName="ShoppingCartList" TagPrefix="uc2" %>
<%@ Register Src="~/Contorls/UcAddOrder.ascx" TagName="UcAddOrder" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head11">
    <title>软件购买下单_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
     <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
        <uc4:Head ID="Head1" runat="server" />
     
     <table width="990" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="750" valign="top"><div id="ShoppingCartList">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT MB">
     <tr>
       <td><img src="/Images/Web/shop_wei1.jpg" width="750" height="30" /></td>
     </tr>
   </table>           
                 <br />    
         <uc3:UcAddOrder ID="AddOrder1" runat="server"  OnAddOrders_Command="AddOrders_Command"></uc3:UcAddOrder>
         </div>
       </td>
    <td width="10"></td>
    <td width="230" valign="top">
        <uc6:ShopServers ID="ShopServers1" runat="server" />
    </td>
  </tr>
</table>  
        <uc5:Footer ID="Footer1" runat="server" />  </div>
    </form>
   
</body>
</html>
