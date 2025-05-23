<%@ Control Language="C#" AutoEventWireup="true" Codebehind="BulletinClass.ascx.cs"
    Inherits="Pbzx.Web.Contorls.BulletinClass" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" Width="100%">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <a href="/Bulletin_list.aspx?NewsType=<%#Input.Encrypt(Eval("IntNewsTypeID").ToString()) %>"
            target="_self" class="class_zi">
            <div onmouseover="this.style.backgroundColor='#E7F4C6'" onmouseout="this.style.backgroundColor='f8f8f8'"
                style="cursor: pointer; border: solid 1px #D7D7D7; width: 100px; height: 21px;
                text-align: center; line-height: 170%; margin: 0; padding: 0;">
                <%# StrFormat.CutStringByNum(Eval("VarTypeName"), this.TitleLength*2)%>
            </div>
        </a>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:DataList>