<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLyBookDisp.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcLyBookDisp" %>
<script src="/javascript/calendar.js" type="text/javascript"></script>
<table width="730" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
          &nbsp;����״̬:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="">ȫ��</asp:ListItem>
                <asp:ListItem Value="0">δ�ظ�</asp:ListItem>
                <asp:ListItem Value="1">�ѻظ�</asp:ListItem>
            </asp:DropDownList></td>
        <td>
        ����:
        </td>
        <td>        
        <asp:DropDownList ID="ddlType" runat="server"> 
        </asp:DropDownList>
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
            <td><asp:Button ID="btsearch" runat="server" Text="����" OnClick="btsearch_Click"  class="input_btn2" />&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click"  class="input_btn2"/></td>
        
    </tr>
</table>
