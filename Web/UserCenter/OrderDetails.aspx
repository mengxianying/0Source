<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="Pbzx.Web.UserCenter.OrderDetails" %>

<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/OrderInfo.ascx" TagName="OrderInfo" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<base target="_self">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单清单</title>
    <link  type="text/css" href="/css/css.css" rel="Stylesheet" />
        <link  type="text/css" href="/css/user_center.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div><table width="99%" border="0" align="center" cellpadding="2" cellspacing="0">
  <tr><td height="28" valign="bottom" align="left">&nbsp;&nbsp;<span class="shop14black">订单清单</span></td></tr>
  <tr>
    <td>
        <uc1:OrderDetail ID="OrderDetail1" runat="server" /></td>
  </tr>
  <tr>
    <td>
        <uc2:OrderInfo ID="OrderInfo1" runat="server" /></td>
  </tr>
  <tr>
    <td>
    <input id="btnNo" type="button"  class="page_Save" value="关 闭" onclick='window.returnValue ="close";window.close();' /></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
