<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UC_QQa.ascx.cs" Inherits="Pbzx.Web.Contorls.UC_QQa" %>
<asp:Repeater ID="RptQQ" runat="server">
    <HeaderTemplate>
        <table width="100%" border="0" align="center" cellpadding="1" cellspacing="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td height="22" valign="top" align="center">
                <span class="blue"><%# Eval("Team")%></span><%# Eval("Tel")%>&nbsp;<a href="tencent://message/?uin=<%# Eval("VarQQNumber")%>&Site=www.pinble.com&Menu=yes"><img src='http://wpa.qq.com/pa?p=1:<%# Eval("VarQQNumber")%>:8' border="0"  width="58" height="16" alt="点击这里给我发消息" /></a></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table></FooterTemplate>
</asp:Repeater>
