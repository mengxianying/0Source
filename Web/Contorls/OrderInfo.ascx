<%@ Control Language="C#" AutoEventWireup="true" Codebehind="OrderInfo.ascx.cs" Inherits="Pbzx.Web.Contorls.OrderInfo" %>
<asp:FormView ID="FormView1" runat="server" Width="100%">
    <ItemTemplate>
        <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="0"
            class="MT">
            <tr>
                <td height="20" bgcolor="#FFF4DD" align="left" colspan="8" background="/Images/Web/shop_serve.jpg">
                    &nbsp;<b class="bTitle">订单信息</b></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td width="6%" align="right">
                    订单号：</td>
                <td width="12%" align="left" bgcolor="#ffffff">
                    <%#Eval("OrderID") %>
                </td>
                <td width="8%" align="right" bgcolor="#ffffff">
                    下单时间：</td>
                <td width="12%" align="left" bgcolor="#ffffff">
                    <%#Eval("OrderDate") %>
                </td>
                <td width="8%" align="right">
                    订单状态：
                </td>
                <td width="20%" align="left">
                    <span class="msg">
                        <%# Pbzx.Web.WebFunc.FormartTipName(Eval("TipID"),Eval("IsPay")) %>
                    </span>(<%#Eval("UpdateStaticDate") %>)
                </td>
                <td width="6%" align="right">
                    下单IP：
                </td>
                <td width="20%" align="left">
                    <%#Eval("UserIP") + "(" + Pbzx.Web.WebFunc.GetIpName(Eval("UserIP")) + ")"%>
                </td>
              
            </tr>
        </table>
        <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="0"
            bgcolor="#D4D4D4" class="MT">
            <tr>
                <td height="20" bgcolor="#FFF4DD" align="left" colspan="4" background="/Images/Web/shop_serve.jpg">
                    &nbsp;<b class="bTitle">收货人信息</b></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td width="13%" align="right">
                    姓名：</td>
                <td width="17%" align="left">
                    <%#Eval("ReceiverName") %>
                </td>
                <td width="13%" align="right">
                    电话：</td>
                <td width="57%" align="left">
                    <%#Eval("ReceiverPhone")%>
                </td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="right">
                    邮编：</td>
                <td align="left">
                    <%#Eval("ReceiverPostalCode")%>
                </td>
                <td align="right">
                    Email：</td>
                <td align="left">
                    <%#Eval("ReceiverEmail")%>
                </td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="right">
                    *地址：</td>
                <td colspan="3" align="left">
                    <%#Eval("ReceiverAddress")%>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlPortType" runat="server" >
            <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="1"
                bgcolor="#D4D4D4" class="MT">
                <tr>
                    <td height="20" bgcolor="#FFF4DD" align="left" colspan="6" background="/Images/Web/shop_serve.jpg">
                        &nbsp;<b class="bTitle">收货方式</b></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td width="13%" align="right">
                        收货方式：</td>
                    <td width="17%" align="left">
                        <%#Eval("PortTypeName") %>
                    </td>
                    <td width="10%" align="right">
                        运费：</td>
                    <td align="left" colspan="3">
                        <%#Eval("PortPrice","{0:C2}") %>
                    </td>
                </tr>
            </table>
        </asp:Panel>
           <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="1"
                bgcolor="#D4D4D4" class="MT">
                <tr>
                    <td height="20" bgcolor="#FFF4DD" align="left" colspan="6" background="/Images/Web/shop_serve.jpg">
                        &nbsp;<b class="bTitle">付款方式</b></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td width="13%" align="right">
                         付款方式：</td>
                    <td align="left" colspan="5">
                        <%#Eval("PayTypeName") %>
                    </td>
                </tr>
            </table>
        <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="1"
            bgcolor="#D4D4D4" class="MT">
            <tr>
                <td height="20" bgcolor="#FFF4DD" align="left" colspan="6" background="/Images/Web/shop_serve.jpg">
                    &nbsp;<b class="bTitle">费用信息</b></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td width="13%" align="right">
                    产品总价格：</td>
                <td width="17%" align="left">
                    <%#Eval("TotalProductPrice", "{0:f2}")%>
                </td>
                <td width="10%" align="right">
                    运费：</td>
                <td width="20%" align="left">
                    <%#Eval("PortPrice", "{0:f2}")%>
                </td>
                <td width="10%" align="right">
                    总费用：
                </td>
                <td width="30%" align="left">
                    <%# Eval("SumPrice", "{0:f2}")%>
                </td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="right">
                    已付费用：
                </td>
                <td align="left">
                    <%#Eval("HasPayedPrice", "{0:f2}")%>
                </td>
                <td align="right">
                    未付费用：
                </td>
                <td align="left">
                    <%#Eval("HasNotPayedPrice", "{0:f2}")%>
                </td>
                <td align="right">
              <%=TxtZK1 %>
                </td>
                <td align="left">
              <%=TxtZK2 %>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>

