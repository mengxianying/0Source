<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_cnCount.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_cnCount" %>
<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="740" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td style="height: 26px">
            �û���:</td>
        <td  style="height: 26px">
            <asp:TextBox ID="txtUserName" runat="server" Width="120px" ></asp:TextBox></td>

        <td style="height: 26px">
            ��ͨ����:</td>
        <td style="height: 26px">
            <asp:TextBox ID="txtNormalTopicCount" runat="server" Width="60px"></asp:TextBox></td>
           <td style="height: 26px; ">
               ��������:</td>
        <td style="height: 26px">
            <asp:TextBox ID="txtBestTopicCount" runat="server" Width="60px"></asp:TextBox>&nbsp;</td>
         <td style="height: 26px">
             ��ͨ����:&nbsp;</td>
        <td style="height: 26px">
            <asp:TextBox ID="txtNormalAnnounceCount" runat="server" Width="60px"></asp:TextBox></td>
         <td style="height: 26px">
             ��������:&nbsp;</td>
         <td style="height: 26px">
             <asp:TextBox ID="txtBestAnnounceCount" runat="server" Width="60px"></asp:TextBox>&nbsp;</td>
    </tr>
</table>
<table>
    <tr>
     <td style="height: 26px">
            ����:</td>
        <td style="height: 26px">
            &nbsp;<asp:DropDownList ID="ddlBoard" runat="server">
            </asp:DropDownList></td>
    </tr>
</table>
<table width="740" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;��ɾ����:</td>
        <td colspan="2">
            &nbsp;
            <asp:TextBox ID="txtDelTopicCount" runat="server" Width="60px"></asp:TextBox></td>
        <td colspan="1">
            ��ɾ����:&nbsp;</td>
        <td>
            &nbsp;<asp:TextBox ID="txtDelAnnounceCount" runat="server" Width="60px" ></asp:TextBox></td>
        <td>
            ����������:</td>
        <td>
            &nbsp;<asp:TextBox ID="txtTotalTopicCount" runat="server"  Width="60px"></asp:TextBox></td>
        <td>
            ��������&nbsp;</td>
        <td>
            &nbsp;<asp:TextBox ID="txtTotalAnnounceCount" runat="server"  Width="60px"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="��������" />&nbsp;<asp:Button
                ID="btn_cancel" runat="server" OnClick="btnReset_Click" Text="����" /></td>
    </tr>
</table>

