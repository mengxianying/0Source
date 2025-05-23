<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSearch.ascx.cs" Inherits="Pinble_Ask.Contorls.UcSearch" %>
<table  width="97%" border="0" align="center" cellpadding="2" cellspacing="0">
    <tr>
        <td width="52%">
            <asp:TextBox ID="txtKey" runat="server" class="inputH" Width="95%" MaxLength="60" ></asp:TextBox></td>
        <td width="12%">
         <asp:Button ID="btnSearchAnswer" runat="server" Text="搜索答案"  onkeydown="if(event.keyCode==13){return false;}"   class="f15black" OnClick="btnSearchAnswer_Click"  />
         </td>
        <td width="8%" align="left">
             <asp:Button ID="btnTW" runat="server" Text="提问" onkeydown="if(event.keyCode==13){return false;}"   class="f15black" OnClick="btnTW_Click"  />
           </td>
        <td width="28%" align="left">
            <a href="/Help.aspx" class="Link_Xia" target="_blank">新手入门</a>
    </tr>
</table>
