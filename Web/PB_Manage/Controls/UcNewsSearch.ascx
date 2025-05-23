<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcNewsSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcNewsSearch" %>
<table width="95%" align="left" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
            &nbsp;新闻标题:</td>
        <td>
            <asp:TextBox ID="txtNvarTitle" runat="server" Width="120"></asp:TextBox>
       </td>
       <td>
            所属频道：
       </td>
       <td>
           <asp:DropDownList ID="ddlChannel" runat="server" Width="80px">
           </asp:DropDownList>
       </td>
        <td>
            所属类别:</td>
        <td>
            <asp:DropDownList ID="ddlIntShowType" runat="server"  Width="110px">
            </asp:DropDownList></td>
        <td >
            发布时间:</td>
        <td>
            <asp:DropDownList ID="ddlTime" runat="server" Width="70">
                <asp:ListItem Value="-1">今天</asp:ListItem>
                <asp:ListItem Value="-7">近7天</asp:ListItem>
                <asp:ListItem Value="-15">近15天</asp:ListItem>
                <asp:ListItem Value="-30">近30天</asp:ListItem>
                <asp:ListItem Value="-60">近2个月</asp:ListItem>
                <asp:ListItem Value="-180">半年内</asp:ListItem>
                <asp:ListItem Selected="True">所有</asp:ListItem>
            </asp:DropDownList></td>
                     <td>
                是否显示
            </td>
            <td>
                <asp:DropDownList ID="ddlAccording" runat="server">
                <asp:ListItem Value="0">不显示</asp:ListItem>
                <asp:ListItem Value="1">显示</asp:ListItem>
                <asp:ListItem Selected="True">所有</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                是否发布
            </td>
            <td>
                <asp:DropDownList ID="ddlrelease" runat="server">
                <asp:ListItem Value="0">不发布</asp:ListItem>
                <asp:ListItem Value="1">发布</asp:ListItem>
                <asp:ListItem Selected="True">所有</asp:ListItem>
                </asp:DropDownList>
            </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" /></td>
    </tr>
</table>
