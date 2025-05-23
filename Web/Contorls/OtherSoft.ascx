<%@ Control Language="C#" AutoEventWireup="true" Codebehind="OtherSoft.ascx.cs" Inherits="Pbzx.Web.Contorls.OtherSoft" %>
<asp:DataList ID="DataList1" runat="server" Width="99%" HorizontalAlign="Center"
    BorderWidth="0px" BorderStyle="None" ShowFooter="False">
    <HeaderTemplate>
        <table width="95%" border="0" cellpadding="2" cellspacing="1" align="center" bgcolor="#D8D8D8">
            <tr>
                <td width="82%" bgcolor="#F4F4F4">
                    <strong>&nbsp;Èí¼þÃû³Æ</strong></td>
                <td width="18%" align="center" bgcolor="#F4F4F4">
                    <strong>°æ±¾</strong></td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        ¡¤<a href="/Soft_explain.aspx?ID=<%# Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
            title='<%#Eval("pb_SoftName") %>'><%#Eval("pb_SoftName") %>
        </a></td>
        <td align="center" bgcolor="#FFFFFF">
            <%#Eval("pb_SoftVersion")%>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
    <ItemStyle BackColor="White" />
</asp:DataList>
</td> </tr></table>