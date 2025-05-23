<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsType_Editor.aspx.cs" Inherits="Pbzx.Web.PB_Manage.NewsType_Editor" %>

<html>
<head runat="server">
    <title>新闻类别</title>
        <link type="text/css" rel="stylesheet" href="stylecss/Admin-darkgreen.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" class="Manage_Table" style="left: 49%; top: 20px; width: 705px;">
        <tr>
            <td colspan="2" class="Manage_Header" style="height: 30px">
                <asp:Label ID="lblAction" runat="server"></asp:Label>新闻类别</td>
        </tr>
        <tr>
            <td class="Manage_Title" style="width: 40%; height: 30px;">
                <strong>
                类别名称：</strong></td>
            <td style="height: 30px">
                <asp:TextBox ID="txtVarTypeName" runat="server" Width="275px"></asp:TextBox></td>
        </tr>
                <tr>
            <td class="Manage_Title" style="width: 40%; height: 30px;">
                <strong>所属类别：</strong><br />
                添加类别所属的栏目
                </td>
            <td style="height: 30px">
                <asp:DropDownList ID="ddlParent" runat="server" Width="282px">
                </asp:DropDownList></td>
        </tr>
        <tr id="Tr2" runat="server" visible="true">
            <td class="Manage_Title" style="width: 40%; height: 56px;">
                <strong>是否显示：</strong>
                </td>
            <td style="height: 56px">
                &nbsp;<asp:RadioButtonList ID="rblIsAuditing" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
            <tr>
                <td class="Manage_Title" style="width: 40%; height: 22px;">
                    <strong>排序编号：</strong><br />
                    请输入数字，数字越小越在前边。
                    </td>
                <td style="height: 22px">
                    &nbsp;<asp:TextBox ID="txtOrder" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Manage_Title" style="width: 40%">
                </td>
                <td>
                </td>
            </tr>
        <tr>
            <td colspan="2" align="center" style="height: 30px">
                <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClientClick="history.back();return false;" />
                <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                &nbsp;
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
