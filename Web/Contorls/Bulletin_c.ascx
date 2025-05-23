<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Bulletin_c.ascx.cs"
    Inherits="Pbzx.Web.Contorls.Bulletin_c" %>
<%@ Import Namespace="Pbzx.Common" %>
<div>
    <asp:DataList ID="DataList1" runat="server" Width="100%" RepeatColumns="1">
        <HeaderTemplate>
            <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td width="82%">
                    <span class="new_Time">¡¤</span><a href="<%# Eval("SavePath") %>" target="_blank"
                        class="hot"><%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2," ") %>
                    </a>
                </td>
                <td width="18%" class="new_Time">
                    <%#Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                </td>
            </tr>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" />
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList></div>
