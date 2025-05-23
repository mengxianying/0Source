<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsOneTableByType.ascx.cs"
    Inherits="Pbzx.Web.Contorls.NewsOneTableByType" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="width: 100%">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="85%" align="left">
                        <a href="<%# Eval("SavePath") %>" target="_blank" class="newslink">
                            <%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2) %>
                        </a>
                    </td>
                    <td width="15%" align="left" class="new_Time">
                        <%#Eval("DatDateAndTime","{0:yyyy-MM-dd}") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>
