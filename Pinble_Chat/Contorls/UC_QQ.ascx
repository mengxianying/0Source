<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UC_QQ.ascx.cs" Inherits="Pbzx.Web.Contorls.UC_QQ" %>
<asp:Repeater ID="RptQQ" runat="server">
    <HeaderTemplate>
        <table width="98%" border="0" align="center" cellpadding="1" cellspacing="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td height="22" valign="top" align="left">
                <span class="blue"><%# Eval("Team")%></span><%# Eval("Tel")%><a href="tencent://message/?uin=<%# Eval("VarQQNumber")%>&Site=www.pinble.com&Menu=yes"><img src='http://wpa.qq.com/pa?p=1:<%# Eval("VarQQNumber")%>:8' border="0" alt="点击这里给我发消息" /></a></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table></FooterTemplate>
</asp:Repeater>
