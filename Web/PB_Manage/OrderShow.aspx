<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderShow.aspx.cs" Inherits="Pbzx.Web.PB_Manage.OrderShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<base target="_self">
<head id="Head1" runat="server">
    <title>订单详细</title>
    <link type="text/css" rel="stylesheet" href="/css/user_center.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="600" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="10">
                        <img src="../images/web/UC_weibg1.jpg" width="10" height="28" alt="" /></td>
                    <td width="789" background="../images/web/UC_weibg2.jpg">
                        <span class="uc_weib">订单详细</span></td>
                    <td width="6">
                        <img src="../images/web/UC_weibg3.jpg" width="6" height="28" /></td>
                </tr>
            </table>
            <table width="600" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD"
                class="uc_MT10">
                <tr>
                    <td width="100" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        订单号：</td>
                    <td width="200" bgcolor="#FFFFFF">
                        <asp:Label ID="lblOrderID" runat="server"></asp:Label></td>
                         <td width="100" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        客户论坛名：</td>
                    <td width="200" bgcolor="#FFFFFF">
                        <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                </tr>
                   <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        购买总价：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblTotalProductPrice" runat="server"></asp:Label></td>
                           <td  align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                             更新日期：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblUpdateStaticDate" runat="server"></asp:Label></td>
                </tr>
                       <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        已付费用：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblHasPayedPrice" runat="server"></asp:Label></td>
                         <td  align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                             下单日期：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>
                </tr>
                       <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        付款方式：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblPayTypeName" runat="server"></asp:Label></td>
                        <td  align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                             邮费：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblPortPrice" runat="server"></asp:Label></td>
                </tr>
                       <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        订单状态：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblTipName" runat="server"></asp:Label></td>
                         <td  align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                       </td>
                    <td bgcolor="#FFFFFF">
                       
                       </td>
                </tr>
                       <tr>  
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        收货人姓名：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblReceiverName" runat="server"></asp:Label></td>
                         <td  align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                             收货人电话：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblReceiverPhone" runat="server"></asp:Label></td>
                </tr>
                       <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        收货人邮编：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblRPostalCode" runat="server"></asp:Label></td>
                         <td  align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                             收货人Email：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lblReceiverEmail" runat="server"></asp:Label></td>
                </tr>
                       <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        收货人地址：</td>
                    <td bgcolor="#FFFFFF" colspan="3">
                        <asp:Label ID="lblReceiverAddress" runat="server"></asp:Label></td>
                     
                </tr>   <tr>              
                <td align="left" bgcolor="#FFFFFF" colspan="4">
                                    &nbsp; 应付款：产品总价<asp:Label ID="lblProductPrice" runat="server"></asp:Label>
                                    + 邮费:<asp:Label ID="lblPort" runat="server"></asp:Label>
                                    =
                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    ; &nbsp; 已付款：<asp:Label ID="lblHasPay" runat="server"></asp:Label>
                                    ; &nbsp; 未付款：<asp:Label ID="lblNoPay" runat="server"></asp:Label></td>                
                      
                </tr>
                       <tr>
                  <td bgcolor="#FFFFFF" colspan="4" align="center">
                     <input id="btnNo" type="button"  class="page_Save" value="关 闭" onclick='window.returnValue ="close";window.close();' />
                  </td>  
                </tr>               
                </table>
    </div>
    </form>
</body>
</html>
