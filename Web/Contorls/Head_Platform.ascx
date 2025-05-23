<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Head_Platform.ascx.cs"
    Inherits="Pbzx.Web.Contorls.Head_Platform" %>
<div runat="server" id="dvImgAD">
    
        <asp:DataList ID="datalist_platform" runat="server" Width="100%" 
            RepeatDirection="Horizontal" RepeatColumns="8">
        <ItemTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
            <td align="center">

             <a href='<%# Eval("P_pfPath") %>' target="_blank"><img src='../Images/Web/<%# Eval("p_imgName") %>' alt="" border="0" /></a>   

            </td>
        </tr>
        <tr>
            <td align="center">
                <a href="<%# Eval("P_pfPath") %>" target="_blank"><%# Eval("P_pfName")%></a>
            </td>
        </tr>
            </table>
        </ItemTemplate>
        </asp:DataList>
        

</div>
