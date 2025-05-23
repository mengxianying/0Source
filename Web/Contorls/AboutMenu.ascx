<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AboutMenu.ascx.cs" Inherits="Pbzx.Web.Contorls.AboutMenu" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="dlUsMenu" runat="server" Width="100%">
    <ItemTemplate>
        <table width="100%" height="30" border="0" cellpadding="0" cellspacing="0" background="images/web/AB_menubg.jpg">
            <tr>
                <td width="19%">
                    &nbsp;
                </td>
                <td width="81%" align="left">
                    <%--<a href="/About.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>" class="Amenu">
                        <%#Eval("UsTitle")%>
                    </a>--%>
                       <%# GetLinkTitle(Eval("UsTitle"), Eval("UsUrl"), Eval("HtmlUrl"))%> 
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>