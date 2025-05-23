<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Bulletin_r.ascx.cs"
    Inherits="Pinble_Ask.Contorls.Bulletin_r" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="margin-left:6px; margin-top:5px; margin-bottom:3px;">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           ¡¤ <a href="/Bulletin_Ask_Show.aspx?id=<%#Input.Encrypt(Eval("IntID").ToString()) %>"
                target="_blank" class="<%=ClassCss%>" title='<%#Eval("NvarTitle")%>'><%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2," ") %></a><br />
        </ItemTemplate>
    </asp:Repeater>
</div>
