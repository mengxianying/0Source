<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcMoney_Log.ascx.cs"
    Inherits="Pbzx.Web.UserCenter.Contorls.UcMoney_Log" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="800" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp; ���<asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Selected="True" Value="">����</asp:ListItem>
                <asp:ListItem Value="0">��ֵ</asp:ListItem>
                <asp:ListItem Value="1">ȡ��</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            ״̬��<asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Selected="True" Value="">����</asp:ListItem>
                <asp:ListItem Value="0">������</asp:ListItem>
                <asp:ListItem Value="1">�Ѵ���</asp:ListItem>
                <asp:ListItem Value="2">����</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:RadioButtonList ID="rblIsCancel" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">δȡ��</asp:ListItem>
                <asp:ListItem Value="1">��ȡ��</asp:ListItem>
            </asp:RadioButtonList>
        </td>
                
        <td>
           ����
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" title='��ʼʱ��' onfocus="calendar();" runat="server"
                Width="90px" MaxLength="20"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtCreateTime2"
                    title='����ʱ��' onfocus="calendar();" runat="server" Width="90px" MaxLength="20"></asp:TextBox>
        </td>
        <td>  <asp:RadioButtonList ID="rblDate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">ȫ��</asp:ListItem>
                <asp:ListItem Value="0">����</asp:ListItem>
            </asp:RadioButtonList>
          
        </td>
        <td>
            <asp:Button ID="btnLook" runat="server" OnClick="btnLook_Click" Text="����" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" class="input_btn2" /></td>
    </tr>
</table>
