<%@ Control Language="C#" AutoEventWireup="true" Codebehind="OrderDetail.ascx.cs"
    Inherits="Pbzx.Web.Contorls.OrderDetail" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID,RegType"
    GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound"
    Width="100%" CssClass="GridView_Table1">
    <FooterStyle HorizontalAlign="Right" />
    <Columns>
        <asp:TemplateField HeaderText="软件名称">
            <ItemTemplate>
                &nbsp;<a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                    title='<%#Eval("pb_SoftName")%>' class="S_title1" target="_blank">
                    <%#Eval("pb_SoftName")%>
                </a>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" Width="28%" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="注册方式">
            <ItemTemplate>
                <%# Pbzx.Web.WebFunc.CheckRegTye(Eval("RegType"), Eval("pb_TypeName"), Eval("pb_DemoUrl"), Eval("pb_RegUrl"))%>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" Width="52%" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="数量">
            <ItemStyle HorizontalAlign="Center" Width="8%" />
            <ItemTemplate>
                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quatity") %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="总售价" HtmlEncode="False">
            <HeaderStyle HorizontalAlign="Center" Width="12%" />
        </asp:BoundField>
    </Columns>
    <HeaderStyle Font-Bold="True" CssClass="GridView_Header1" />
    <RowStyle CssClass="GridView_Row1" />
    <PagerSettings Mode="NumericFirstLast" Visible="False" />
</asp:GridView>
<table width="100%" border="0" cellpadding="2" cellspacing="0">
    <tr>
        <td style="width: 40%" align="center">
        </td>
        <td style="width: 20%">
        </td>
        <td style="width: 40%" align="center">
            <span class="shop14black">总数量:<span class="shop14red"><asp:Label ID="lblSumQuatity"
                runat="server" Text="0"></asp:Label></span>&nbsp;总价格:<span class="shop14red"><asp:Label
                    ID="lblSumBookPrice" runat="server" Text="0.00"></asp:Label></span> </span>
        </td>
    </tr>
</table>
