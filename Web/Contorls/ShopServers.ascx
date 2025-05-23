<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ShopServers.ascx.cs"
    Inherits="Pbzx.Web.Contorls.ShopServers" %>
<%@ Register Src="UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc1" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td bgcolor="#FFFFFF">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td height="28" align="left" background="/Images/Web/shop_serve1.jpg">
                        &nbsp;&nbsp;<strong>购物须知</strong></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#F9A533">
    <tr>
        <td bgcolor="#FFF8E8">
            <table width="99%" border="0" cellspacing="0" cellpadding="8" align="center">
                <tr>
                    <td align="left" class="shop_Grend">
                        <%=Message %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td bgcolor="#FFFFFF">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF"
                class="MT">
                <tr>
                    <td height="28" align="left" background="/Images/Web/shop_serve2.jpg">
                        &nbsp;&nbsp;<strong>联系客服</strong></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="6" cellspacing="1" bgcolor="#69B2F6">
    <tr>
        <td bgcolor="#FFFFFF">
            <uc1:UC_QQ ID="UC_QQ1" runat="server" />            
        </td>
    </tr>
</table>
