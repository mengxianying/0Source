<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsThree.ascx.cs" Inherits="Pbzx.Web.Contorls.NewsThree" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
    CellPadding="0" Width="100%">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <a href='/News_explain.aspx?id=<%#Input.Encrypt(Eval("IntID").ToString()) %>'><font
            color="#000">
            <%# StrFormat.CutStringByNum(Eval("NvarTitle"), this.TitleLength*2)%>
        </font></a>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    <ItemStyle HorizontalAlign="Center" />
</asp:DataList>