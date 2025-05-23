<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SoftClass.ascx.cs" Inherits="Pbzx.Web.Contorls.SoftClass" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
    Width="100%">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <table width="90%" border="0" align="center" cellpadding="1" cellspacing="0">
            <tr>
                <td class="xia_line">
                    <img alt="" src="/Images/Web/soft_li2.jpg" border="0" hspace="7" /><a href='Soft.aspx?id=<%#Input.Encrypt(Eval("IntClassID").ToString()) %>'><%#StrFormat.CutStringByNum(Eval("NvarClassName"), this.TitleLength*2)%></a></td>
            </tr>
        </table>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:DataList>
