<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SoftTitle.ascx.cs" Inherits="Pbzx.Web.Contorls.SoftTitle" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td width="90%">
                <span class="dianse">¡¤</span><a href='Soft_explain.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>'
                    target="_blank"><%# StrFormat.CutStringByNum(Eval("pb_SoftName"), this.TilteLength*2)%></a></td>
           <%-- <td width="28%" class="TimeDate" align="left">
                <%#Eval("pb_UpdateTime", "{0:yyyy-MM-dd}")%>
            </td>--%>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
