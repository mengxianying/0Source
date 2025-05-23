<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Bulletin_Hot_List.ascx.cs"
    Inherits="Pbzx.Web.Contorls.Bulletin_Hot_List" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table border="0" cellpadding="3" cellspacing="1" width="98%" style="margin-top: 3px;
            margin-bottom: 2px; margin-left: 6px;">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td align="left">
                <img src="/Images/Web/B_li1.jpg" width="11" height="11" border="0" class="img_boder2" />
                <a href="<%# Eval("SavePath") %>" target="_blank" class="newslink1">
                    <%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2," ") %>
                </a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table></FooterTemplate>
</asp:Repeater>
