<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcTradeInfo.ascx.cs"
    Inherits="Pbzx.Web.UserCenter.Contorls.UcTradeInfo" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center" style="width: 150px">
          <asp:RadioButtonList ID="rblDate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">ȫ������</asp:ListItem>
                <asp:ListItem Value="0">����ʱ��</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="width: 30px" align="right">
            ��
        </td>
        <td align="left" style="width: 260px">
            <asp:TextBox ID="txtCreateTime1" title='��ʼʱ��' onfocus="calendar();" runat="server"
                Width="100px" MaxLength="20"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtCreateTime2"
                    title='����ʱ��' onfocus="calendar();" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnLook" runat="server" OnClick="btnLook_Click" Text="����" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" class="input_btn2" /></td>
    </tr>
</table>
