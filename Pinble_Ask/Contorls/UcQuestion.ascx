<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcQuestion.ascx.cs"
    Inherits="Pinble_Ask.Contorls.UcQuestion" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="width: 100%; vertical-align: top;">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <%# GetTitle(Eval("TypeID"), Eval("Title"), Eval("Id"), Eval("IsCommend"))%>
        </ItemTemplate>
    </asp:Repeater>
</div>
