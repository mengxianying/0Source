<%@ Control Language="C#" AutoEventWireup="true" Codebehind="OrderDetail2.ascx.cs"
    Inherits="Pbzx.Web.Contorls.OrderDetail2" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID,RegType"
    GridLines="Horizontal"
    Width="100%" CellSpacing="-1" BorderColor="#B8C9D9" BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
    <FooterStyle HorizontalAlign="Right" BorderStyle="None"/>
    <Columns>
        <asp:TemplateField HeaderText="软件名称">
            <ItemTemplate>
                &nbsp;<a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                    title='<%#Eval("pb_SoftName")%>' class="S_title1" target="_blank">
                    <%#Eval("pb_SoftName")%>
                </a>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" Width="28%" />
            <ItemStyle HorizontalAlign="Left" BorderStyle="None" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="注册方式">
            <ItemTemplate>
                 <%# Pbzx.Web.WebFunc.CheckRegTye(Eval("RegType"), Eval("pb_TypeName"), Eval("pb_DemoUrl"), Eval("pb_RegUrl"))%>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" Width="52%" />
            <ItemStyle HorizontalAlign="Left" BorderStyle="None" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="数量">
            <ItemStyle HorizontalAlign="Center" Width="8%" BorderStyle="None" />
            <ItemTemplate>
                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quatity") %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="总售价" HtmlEncode="False">
            <HeaderStyle HorizontalAlign="Center" Width="12%" />
            <ItemStyle BorderStyle="None" />
        </asp:BoundField>
    </Columns>
    <PagerSettings Mode="NumericFirstLast" Visible="False" /> 
    <HeaderStyle BackColor="#EBF2F8" BorderStyle="None" />
</asp:GridView>
<table style="width: 100%">
    <tr>
        <td style="width: 40%" align="center">
        </td>
        <td style="width: 20%">
        </td>
        <td style="width: 40%" align="center">
            <span class="uc_12bold">总数量:<span class="uc_font_redB"><asp:Label ID="lblSumQuatity"
                runat="server" Text="0"></asp:Label></span>&nbsp;总价格:<span class="shop14red"><asp:Label
                    ID="lblSumBookPrice" runat="server" Text="0.00"></asp:Label></span> </span>
        </td>
    </tr>
</table>
