<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Bulletin_r.ascx.cs"
    Inherits="Pinble_Chat.Contorls.Bulletin_r" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <span style="color: #0044BB;">¡¤</span><a href='Chat_Bulletin_Show.aspx?ID=<%#Input.Encrypt(Eval("IntID").ToString()) %>'
            target="_blank" class="<%=ClassCss%>"><%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength," ") %></a><br />
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>
