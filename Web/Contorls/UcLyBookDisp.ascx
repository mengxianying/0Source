<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLyBookDisp.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcLyBookDisp" %>
<script src="/javascript/calendar.js" type="text/javascript"></script>
<table width="730" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
          &nbsp;问题状态:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="">全部</asp:ListItem>
                <asp:ListItem Value="0">未回复</asp:ListItem>
                <asp:ListItem Value="1">已回复</asp:ListItem>
            </asp:DropDownList></td>
        <td>
        类型:
        </td>
        <td>        
        <asp:DropDownList ID="ddlType" runat="server"> 
        </asp:DropDownList>
        </td>
        <td>
            时间:
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();" MaxLength="20"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();" MaxLength="20"></asp:TextBox></td>
             <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">创建时间</asp:ListItem>            
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
            <td><asp:Button ID="btsearch" runat="server" Text="查找" OnClick="btsearch_Click"  class="input_btn2" />&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click"  class="input_btn2"/></td>
        
    </tr>
</table>
