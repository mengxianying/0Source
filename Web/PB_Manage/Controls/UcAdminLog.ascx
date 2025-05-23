<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAdminLog.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcAdminLog" %>

<script src="../javascript/calendar.js" type="text/javascript"></script>

<table width="770" border="0" cellspacing="0" cellpadding="1">
    <tr>      
        <td>
            操作者:
        </td>
        <td>
            <asp:TextBox ID="txtOperator" runat="server" Width="90px"></asp:TextBox>
        </td>
        <td>
            操作者IP:
        </td>
        <td>
            <asp:TextBox ID="txtUserIP" runat="server" Width="140px"></asp:TextBox>
        </td>
        <td>
            类型:
        </td>
        <td>
            <asp:DropDownList ID="ddlActionType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlActionType_SelectedIndexChanged"
                Width="154px">
                <asp:ListItem Selected="True">所有</asp:ListItem>
                <asp:ListItem>后台登录</asp:ListItem>
                <asp:ListItem>新增</asp:ListItem>
                <asp:ListItem>修改</asp:ListItem>
                <asp:ListItem>删除</asp:ListItem>
            </asp:DropDownList>
        </td>
          <td>
              具体操作关键字:
        </td>
        <td>
            <asp:TextBox ID="txtKey" runat="server" Width="90px"></asp:TextBox>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            日期:</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="65" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至<asp:TextBox ID="txtCreateTime2" runat="server" Width="65" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式：</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">申请时间</asp:ListItem>
                <asp:ListItem Value="2">最后登录时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" />
            &nbsp;<asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="重置" /></td>
    </tr>
</table>
