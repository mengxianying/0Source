<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bulletin_Hot.ascx.cs" Inherits="Pbzx.Web.Contorls.Bulletin_Hot" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table border="0" cellpadding="0" cellspacing="1" width="97%" style="margin-top: 3px;
            margin-bottom: 2px; margin-left:6px;" >
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td align="left">
                <img src="/Images/Web/B_li1.jpg" width="11" height="11" border="0" class="img_boder2" />
                <a href="<%# Eval("SavePath") %>" target="_blank" class="newslink1">
                    <%# GetTitleByCount(Eval("NvarTitle"), Eval("NvarShortTitle"))%>
                </a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table></FooterTemplate>
</asp:Repeater>
