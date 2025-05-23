<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcQuestion2.ascx.cs" Inherits="Pinble_Ask.Contorls.UcQuestion2" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="width: 100%; vertical-align: top;">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='Question.aspx?question=<%#Input.Encrypt(Eval("Id").ToString()) %>' target="_blank">
                       <font color="#0F0F0F"> <%# StrFormat.CutStringByNum(Eval("Title"), this.TitleLength*2, " ")%></font>
                    </a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
