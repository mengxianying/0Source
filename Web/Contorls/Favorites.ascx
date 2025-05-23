<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Favorites.ascx.cs" Inherits="Pbzx.Web.Contorls.Favorites" %>
<div id="Favorites" style="width:100%;">
<asp:GridView ID="gvFavorites" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" DataKeyNames="FavoritesID" OnRowDeleting="gvFavorites_RowDeleting" CssClass="GridViewStyle2">
    <Columns>
        <asp:TemplateField HeaderText="软件名称">
        <ItemTemplate>
       · <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("ProductID").ToString()) %>"  Target="_blank"><%#Eval("pb_SoftName")%> </a>        
        </ItemTemplate>
         <ItemStyle HorizontalAlign="Left" Width="40%" />
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
       
        <asp:HyperLinkField DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="~/AddToShoppingCart.aspx?productID={0}"
            HeaderText="加入购物车" NavigateUrl="~/AddToShoppingCart.aspx" Target="_blank" Text="加入购物车">
            <ItemStyle HorizontalAlign="Center" Width="25%" />
            <HeaderStyle HorizontalAlign="Center" />
        </asp:HyperLinkField>
       <asp:TemplateField HeaderText="收藏时间">
       <ItemTemplate>
       <%#Eval("DateAdded","{0:yyyy-MM-dd HH:mm}") %>
       </ItemTemplate>
        
          <ItemStyle HorizontalAlign="Center" Width="23%" />
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:CommandField HeaderText="删 除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt; ">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="12%" />
        </asp:CommandField>  
    </Columns>
    <RowStyle CssClass="RowStyle2" />
   <HeaderStyle CssClass="HeaderStyle2" />
</asp:GridView></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" height="30">
  <tr>
    <td width="30%" valign="bottom"><asp:HyperLink ID="hyperGoBack" runat="server" CssClass="My_Back">返回继续收藏</asp:HyperLink></td>
    <td width="32%">&nbsp;</td>
    <td width="38%"><b><asp:Label ID="lblMsg" CssClass="msg" runat="server"></asp:Label></b></td>
  </tr>
</table>


