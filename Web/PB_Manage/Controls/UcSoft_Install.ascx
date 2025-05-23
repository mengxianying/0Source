<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSoft_Install.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcSoft_Install" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpSoftType" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    &nbsp;软件类型:</td>
                <td>
                    <asp:DropDownList ID="ddlSoftwareType" runat="server" Width="72" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>
                    安装类型:</td>
                <td>
                    <asp:DropDownList ID="ddlInstallType" runat="server" Width="72">
                        <asp:ListItem Value="">所有</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
