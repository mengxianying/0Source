<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcTradeInfo.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcTradeInfo" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="790" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 50px;">
            �û���:</td>
        <td style="width: 105px;">
            <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td style="width: 30px;">
            ���:
        </td>
        <td>
            <asp:DropDownList ID="ddlType" runat="server" Width="165">
                <asp:ListItem Selected="True" Value="">����</asp:ListItem>
                <asp:ListItem Value="311">����ת��</asp:ListItem>
                <asp:ListItem Value="312">�ֽ�ת�루��������</asp:ListItem>
                <asp:ListItem Value="313">�ֹ�ת�루���û���ֵ��</asp:ListItem>
                <asp:ListItem Value="151">��ͨ����</asp:ListItem>
                <asp:ListItem Value="152">������</asp:ListItem>
                <asp:ListItem Value="153">�����˻����</asp:ListItem>
                <asp:ListItem Value="171">��ͨ�������֧����</asp:ListItem>
                <asp:ListItem Value="172">���������֧����</asp:ListItem>
                <asp:ListItem Value="173">�����˻�������֧����</asp:ListItem>
                <asp:ListItem Value="771">���֣�����ת����</asp:ListItem>
                <asp:ListItem Value="772">���֣��ֽ�֧����</asp:ListItem>
                <asp:ListItem Value="773">�ֹ�ת�������û��ۿ</asp:ListItem>
                <asp:ListItem Value="511">�������Ƽ�����</asp:ListItem>
                <asp:ListItem Value="512">��¼�û�����</asp:ListItem>
                <asp:ListItem Value="501">���������</asp:ListItem>               
            </asp:DropDownList>
        </td>
        <td>
            ʱ��:��
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" title='��ʼʱ��' onfocus="calendar();" runat="server"
                Width="80px" MaxLength="20"></asp:TextBox>&nbsp;��&nbsp;<asp:TextBox ID="txtCreateTime2"
                    title='����ʱ��' onfocus="calendar();" runat="server" Width="80px" MaxLength="20"></asp:TextBox></td>
        <td>
            <asp:RadioButtonList ID="rblDate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">����ʱ��</asp:ListItem>
                <asp:ListItem Selected="True">��ʱ������</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
</table>
<table width="790">
    <tr>
        <td align="right">
            <asp:Button ID="btnLook" runat="server" OnClick="btnLook_Click" Text="����" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" class="input_btn2" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
