<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcRecordSearch.ascx.cs" Inherits="Pbzx.Web.UserCenter.Contorls.UcRecordSearch" %>
<table width="660" border="0" cellspacing="0" cellpadding="0">
    <tr>
    <td> &nbsp;QQ��:</td>
    <td>    
        <asp:TextBox ID="txtQQ_ID" runat="server" Width="100px"></asp:TextBox>
    </td>
    <td>
         ��̳�û���:</td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server" Width="100px" ></asp:TextBox></td>
        <td>
            ����״̬</td>
        <td>
            <asp:RadioButtonList ID="rblOnlineState" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="">����</asp:ListItem>
                <asp:ListItem Value="0">����</asp:ListItem>
                <asp:ListItem Value="1">�˳�</asp:ListItem>
                <asp:ListItem Value="2">����</asp:ListItem>
            </asp:RadioButtonList>
          
          </td>
       
        <td>
            </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click"  class="input_btn2" />&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="����"  class="input_btn2" OnClick="btnReset_Click" /></td>
       </tr>
</table>