<%@ Control Language="C#" AutoEventWireup="true" Codebehind="OrderInfo.ascx.cs" Inherits="Pbzx.Web.Contorls.OrderInfo" %>
<asp:FormView ID="FormView1" runat="server" Width="100%">
    <ItemTemplate>
        <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="0"
            class="MT">
            <tr>
                <td height="20" bgcolor="#FFF4DD" align="left" colspan="8" background="/Images/Web/shop_serve.jpg">
                    &nbsp;<b class="bTitle">������Ϣ</b></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td width="6%" align="right">
                    �����ţ�</td>
                <td width="12%" align="left" bgcolor="#ffffff">
                    <%#Eval("OrderID") %>
                </td>
                <td width="8%" align="right" bgcolor="#ffffff">
                    �µ�ʱ�䣺</td>
                <td width="12%" align="left" bgcolor="#ffffff">
                    <%#Eval("OrderDate") %>
                </td>
                <td width="8%" align="right">
                    ����״̬��
                </td>
                <td width="20%" align="left">
                    <span class="msg">
                        <%# Pbzx.Web.WebFunc.FormartTipName(Eval("TipID"),Eval("IsPay")) %>
                    </span>(<%#Eval("UpdateStaticDate") %>)
                </td>
                <td width="6%" align="right">
                    �µ�IP��
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
                    &nbsp;<b class="bTitle">�ջ�����Ϣ</b></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td width="13%" align="right">
                    ������</td>
                <td width="17%" align="left">
                    <%#Eval("ReceiverName") %>
                </td>
                <td width="13%" align="right">
                    �绰��</td>
                <td width="57%" align="left">
                    <%#Eval("ReceiverPhone")%>
                </td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="right">
                    �ʱࣺ</td>
                <td align="left">
                    <%#Eval("ReceiverPostalCode")%>
                </td>
                <td align="right">
                    Email��</td>
                <td align="left">
                    <%#Eval("ReceiverEmail")%>
                </td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="right">
                    *��ַ��</td>
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
                        &nbsp;<b class="bTitle">�ջ���ʽ</b></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td width="13%" align="right">
                        �ջ���ʽ��</td>
                    <td width="17%" align="left">
                        <%#Eval("PortTypeName") %>
                    </td>
                    <td width="10%" align="right">
                        �˷ѣ�</td>
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
                        &nbsp;<b class="bTitle">���ʽ</b></td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td width="13%" align="right">
                         ���ʽ��</td>
                    <td align="left" colspan="5">
                        <%#Eval("PayTypeName") %>
                    </td>
                </tr>
            </table>
        <table width="100%" border="1" bordercolor="#D4D4D4" cellpadding="4" cellspacing="1"
            bgcolor="#D4D4D4" class="MT">
            <tr>
                <td height="20" bgcolor="#FFF4DD" align="left" colspan="6" background="/Images/Web/shop_serve.jpg">
                    &nbsp;<b class="bTitle">������Ϣ</b></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td width="13%" align="right">
                    ��Ʒ�ܼ۸�</td>
                <td width="17%" align="left">
                    <%#Eval("TotalProductPrice", "{0:f2}")%>
                </td>
                <td width="10%" align="right">
                    �˷ѣ�</td>
                <td width="20%" align="left">
                    <%#Eval("PortPrice", "{0:f2}")%>
                </td>
                <td width="10%" align="right">
                    �ܷ��ã�
                </td>
                <td width="30%" align="left">
                    <%# Eval("SumPrice", "{0:f2}")%>
                </td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="right">
                    �Ѹ����ã�
                </td>
                <td align="left">
                    <%#Eval("HasPayedPrice", "{0:f2}")%>
                </td>
                <td align="right">
                    δ�����ã�
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

