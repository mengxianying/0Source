<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSoftOnlineSearch2011.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftOnlineSearch2011" %>
<script src="../../javascript/calendar.js" type="text/javascript"></script>
<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table border="0" cellspacing="0" cellpadding="1" >
    <tr onmouseover="javascript:this.bgColor='#D9FFFF';" onmouseout="javascript:this.bgColor='#F9F9F9';">
        <td style="height: 29px">
            &nbsp;��&nbsp;֤&nbsp;��:</td>
        <td style="height: 29px">
            <asp:TextBox ID="txtHDSN" runat="server" Width="120"></asp:TextBox></td>
        <td style="height: 29px">
            <asp:CheckBox ID="chkYuan" runat="server" /></td>
        <td style="height: 29px">
            ԭ
        </td>
        <td style="height: 29px">
            ע����:
        </td>
        <td style="height: 29px">
            <asp:TextBox ID="txtAct_RN" runat="server" Width="166"></asp:TextBox>
        </td>
        <td style="height: 29px">
            ע�᷽ʽ:
        </td>
        <td style="height: 29px">
            <asp:DropDownList ID="ddlAct_RegType" runat="server" Width="60px" AppendDataBoundItems="True">
                <asp:ListItem>����</asp:ListItem>
            </asp:DropDownList>&nbsp;
        </td>
        <td style="height: 29px">
            <asp:RadioButtonList ID="rblCheckHDSN" runat="server" Font-Size="12px" RepeatDirection="Horizontal"
                Height="18px">
                <asp:ListItem Selected="True" Value="">ȫ��</asp:ListItem>
                <asp:ListItem Value="2">�Ƿ�</asp:ListItem>
                <asp:ListItem Value="3">��λ</asp:ListItem>
                <asp:ListItem Value="4">����</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="width: 70px; height: 29px; text-align: right;">
            �û�ȫ��ID</td>
        <td style="width: 105px; height: 29px">
            <asp:TextBox ID="txtGloba" runat="server"></asp:TextBox></td>
    </tr>
</table>
<table border="0" cellspacing="0" cellpadding="0" style="width: 892px">
    <tr onmouseover="javascript:this.bgColor='#D9FFFF';" onmouseout="javascript:this.bgColor='#F9F9F9';">
        <td style="width: 303px">
            <asp:UpdatePanel ID="UpSoftType" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                &nbsp;�������:</td>
                            <td>
                                <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td>
                                ��װ����:</td>
                            <td>
                                <asp:DropDownList ID="ddlInstallType" runat="server">
                                    <asp:ListItem Value="">����</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            �汾��:
        </td>
        <td>
            <asp:TextBox ID="txtVersion" runat="server" Width="79px"></asp:TextBox>
        </td>
        <td>
            ����ϵͳ:</td>
        <td style="width: 79px">
            <asp:DropDownList ID="ddlOSVersion" runat="server">
            </asp:DropDownList></td>
        <td style="width: 33px">
            &nbsp; IP:</td>
        <td>
            &nbsp;<asp:TextBox ID="txtIP" runat="server" Width="122px"></asp:TextBox>
        </td>
        <td style="text-align: right">
            �û����ͣ�</td>
        <td>
            <asp:DropDownList ID="ddlgbltype" runat="server">
                <asp:ListItem Selected="True" Value="0">ȫ��</asp:ListItem>
                <asp:ListItem Value="i">IDEӲ��</asp:ListItem>
                <asp:ListItem Value="s">SATAӲ��</asp:ListItem>
                <asp:ListItem Value="c">C�̾��</asp:ListItem>
                <asp:ListItem Value="n">δ��ɹ�</asp:ListItem>
                <asp:ListItem Value="v">�����</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
<table border="0" cellspacing="0" cellpadding="1">
    <tr onmouseover="javascript:this.bgColor='#D9FFFF';" onmouseout="javascript:this.bgColor='#F9F9F9';">
        <td>
            &nbsp;���ڶ�:
        </td>
        <td>
            <span>��<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="90"></asp:TextBox></span>
        </td>
        <td>
            ��<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="90"></asp:TextBox>
        </td>
        <td>
            &nbsp;
            ���ڷ�ʽ
        </td>
        <td style="width: 292px">
            <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">�����¼����</asp:ListItem>
                <asp:ListItem Value="2">��һ�ε�½����</asp:ListItem>
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" Width="71px" />
        </td>
        <td>
            <asp:Button ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" Width="70px" />
        </td>
    </tr>
</table>
