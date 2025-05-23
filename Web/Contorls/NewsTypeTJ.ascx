<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsTypeTJ.ascx.cs"
    Inherits="Pbzx.Web.Contorls.NewsTypeTJ" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
    CellPadding="0" Width="100%">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <a href='/News_list.aspx?NewsType=<%#Input.Encrypt(Eval("IntNewsTypeID").ToString()) %>'
            target='_self'>
            <div onmouseover="this.style.backgroundColor='#E7F4C6'" onmouseout="this.style.backgroundColor='#f8f8f8'"
                style="cursor: pointer; border: solid 1px #D7D7D7; width: 91px; height: 20px;
                text-align: center; line-height: 170%; margin: 0; padding: 0; margin-right: 4px;
                margin-bottom: 3px;">
                <%# StrFormat.CutStringByNum(Eval("VarTypeName"), this.TitleLength*2)%>
            </div>
        </a>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    <ItemStyle Height="24px" Width="50%" />
</asp:DataList>
