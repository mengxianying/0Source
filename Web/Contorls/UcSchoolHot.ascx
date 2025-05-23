<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSchoolHot.ascx.cs" Inherits="Pbzx.Web.Contorls.UcSchoolHot" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="width:95%; vertical-align: top; padding-left:5px;">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <span class="dianse">¡¤</span><a href='<%# Eval("SavePath") %>' target='_blank' class='school'><%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2) %></a><br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>
