<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMy_Broker.ascx.cs" Inherits="Pbzx.Web.Contorls.UcMy_Broker" %>
<script src="/javascript/calendar.js" type="text/javascript"></script>
<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="685" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
          &nbsp;�ͻ��û���:</td>
        <td>
        <asp:TextBox ID="txtBrokerName" runat="server" Width="120px" MaxLength="12"></asp:TextBox>
           </td>
        <td>
            ʱ��:
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();" MaxLength="20"></asp:TextBox></td>
        <td>
            ��</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();" MaxLength="20"></asp:TextBox></td>
                <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">����ʱ��</asp:ListItem>            
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList></td>
            <td><asp:Button ID="btsearch" runat="server" Text="����" OnClick="btsearch_Click"  class="input_btn2" />&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="����"  class="input_btn2" OnClick="btnReset_Click"  /></td>
        
    </tr>
</table>