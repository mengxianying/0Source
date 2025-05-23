<%@ Control Language="C#" AutoEventWireup="true" Codebehind="School_Time.ascx.cs"
    Inherits="Pbzx.Web.Contorls.School_Time" %>
      <%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table width="98%" border="0" cellpadding="1" cellspacing="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td width="78%" class="C_xia">
                <a href="<%# Eval("SavePath") %>"> class="schoollink">¡¤<%# StrFormat.CutStringByNum(Eval("NvarTitle"), this.TitleLength*2)%></a></td>
            <td width="22%" class="C_xia">
                <%#Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
