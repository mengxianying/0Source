<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcTradeInfo.ascx.cs"
    Inherits="Pbzx.Web.UserCenter.Contorls.UcTradeInfo" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center" style="width: 150px">
          <asp:RadioButtonList ID="rblDate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">全部交易</asp:ListItem>
                <asp:ListItem Value="0">交易时间</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="width: 30px" align="right">
            从
        </td>
        <td align="left" style="width: 260px">
            <asp:TextBox ID="txtCreateTime1" title='开始时间' onfocus="calendar();" runat="server"
                Width="100px" MaxLength="20"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtCreateTime2"
                    title='结束时间' onfocus="calendar();" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnLook" runat="server" OnClick="btnLook_Click" Text="查找" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" class="input_btn2" /></td>
    </tr>
</table>
