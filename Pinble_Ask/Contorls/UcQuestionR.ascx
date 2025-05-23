<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcQuestionR.ascx.cs" Inherits="Pinble_Ask.Contorls.UcQuestionR" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="width: 100%; vertical-align: top;">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
       <a href='Question.aspx?question=<%#Input.Encrypt(Eval("Id").ToString()) %>' target="_blank" title='<%#Eval("Title") %>'>¡¤<%#Convert.ToBoolean(Eval("IsCommend")) ? "<font color='red'>[¾«]</font>" : ""%> <%# StrFormat.CutStringByNum(Eval("Title"), this.TitleLength*2, " ")%></a><br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>
