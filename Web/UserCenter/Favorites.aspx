<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Favorites.aspx.cs" Inherits="Pbzx.Web.UserCenter.Favorites" %>

<%@ Register Src="../Contorls/Favorites.ascx" TagName="Favorites" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/ShopServers.ascx" TagName="ShopServers" TagPrefix="uc6" %>
<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc4" %>
<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc5" %>
<%@ Register Src="~/Contorls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>
<%@ Register Src="~/Contorls/ShoppingCartList.ascx" TagName="ShoppingCartList" TagPrefix="uc2" %>
<%@ Register Src="~/Contorls/UcAddOrder.ascx" TagName="UcAddOrder" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head11">
    <title>收藏夹_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
        <div>
           <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="800" valign="top">
                        <div id="ShoppingCartList">
                            
                               <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                <tr>
                                    <td align="left" height="26" valign="bottom">
                                     &nbsp;<b>我的收藏</b></td>
                                </tr>
                            </table>
                            <uc1:Favorites ID="Favorites1" runat="server" OnFavorites_RowDeleting="Favorites_RowDeleting">
                            </uc1:Favorites>
                            <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                <tr>
                                    <td align="left" height="26" valign="bottom">
                                     &nbsp;<b>推荐商品</b></td>
                                </tr>
                            </table>
                            <asp:DataList ID="dtcommend" runat="server" Width="100%" RepeatColumns="2" RepeatDirection="Horizontal"
                                CellPadding="3" ShowFooter="False">
                                <HeaderTemplate>
                                    &nbsp;根据您挑选的商品，我们为您推荐:
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="75%" align="left">
                                                 · <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"  Target="_blank"><%#Eval("pb_SoftName") %></a>
                                            </td>
                                            <td width="25%" align="center">
                                                <asp:Button ID="btnAddProduct" runat="server" Text="加入收藏" CssClass="input_mybuy" CommandArgument='<%# Eval("pb_SoftID") %>' OnCommand="btnAddProduct_Command" /> </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                                <ItemStyle BackColor="White" BorderColor="#84B5FF" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#B0EAF9" BorderColor="#84B5FF" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="uc_font_blue12" HorizontalAlign="Left" />
                            </asp:DataList>
                        </div>
                    </td>
                                
                </tr>
            </table>       
        </div>
    </form>
</body>
</html>
