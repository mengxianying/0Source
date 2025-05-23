<%@ Control Language="C#" AutoEventWireup="true" Codebehind="OtherSoft2.ascx.cs"
    Inherits="Pbzx.Web.Contorls.OtherSoft2" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="4" Width="100%" HorizontalAlign="Center">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <table width="99%" border="0" align="center" cellpadding="1" cellspacing="0" class="MT5">
            <tr>
                <td align="center">
                    <table border="0" cellspacing="0" cellpadding="1" width="112">
                        <tr>
                            <td align="center">
                                <a href="/Soft_explain.aspx?ID=<%# Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>">
                                    <img src="<%#Eval("pb_SoftPicUrl") %>" width="92" height="60" alt="<%#Eval("pb_SoftName") %>"
                                        border="0" /></a></td>
                        </tr>
                        <tr>
                            <td align="center" height="23">
                                <a href="/Soft_explain.aspx?ID=<%# Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                    class="newslink1">
                                        <%#Pbzx.Common.StrFormat.CutStringByNum(Eval("pb_SoftName").ToString(),8*2)%>
                                    </a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    <FooterStyle HorizontalAlign="Center" />
    <ItemStyle HorizontalAlign="Center" />
</asp:DataList>