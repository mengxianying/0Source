<%@ Control Language="C#" AutoEventWireup="true" Codebehind="WebUserControl1.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.WebUserControl1" %>
<link type="text/css" rel="stylesheet" href="../stylecss/Admin_r.css" />
<table width="100%">
    <tr id="tr1" style="font-size: 12px;">
        <td colspan="9" style="height: 57px">
            <table width="100%">
                <tr>
                    <td style="width: 7%; height: 62px;" align="right">
                        ��֤��:</td>
                    <td style="width: 22%; height: 62px;">
                        <table>
                            <tr>
                                <td style="width: 70%" valign="bottom">
                                    <asp:TextBox ID="txtHDSN" runat="server" Width="100%"> </asp:TextBox></td>
                                <td style="width: 15%">
                                    <asp:CheckBox ID="chkYuan" runat="server" /></td>
                                <td style="width: 15%">
                                    ԭ
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 7%; height: 62px;" align="right">
                        ע����:
                    </td>
                    <td style="width: 12%; height: 62px;">
                        <asp:TextBox ID="txtAct_RN" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 10%; height: 62px;" align="right">
                        �ɵ���֤��&nbsp;</td>
                    <td style="width: 9%; height: 62px;">
                        &nbsp;<asp:TextBox ID="txtOldSN" runat="server" Width="130%"></asp:TextBox></td>
                    <td style="width: 33%; height: 62px;">
                        &nbsp;<table style="width: 100%">
                            <tr>
                                <td style="width: 54%;" align="right">
                                    ԭʼ��֤��:</td>
                                <td style="width: 46%;">
                                    <asp:TextBox ID="txtOrgSN" runat="server" Width="100%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="font-size: 12px">
        <td colspan="9" style="height: 57px">
            <table width="100%">
                <tr>
                    <td style="width: 7%" align="right">
                        ����:</td>
                    <td style="width: 32%">
                        <table width="100%">
                            <tr>
                                <td style="width: 34%">
                                    <asp:TextBox ID="txtUserName" runat="server" Width="100%"> </asp:TextBox>&nbsp;</td>
                                <td style="width: 33%">
                                    ��̳ID</td>
                                <td style="width: 33%">
                                    <asp:TextBox ID="TextBox1" Width="100%" runat="server"> </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 7%" align="right">
                        ����:
                    </td>
                    <td style="width: 12%">
                        &nbsp;<asp:DropDownList ID="ddlTimeType" runat="server">
                            <asp:ListItem Value=" ">����</asp:ListItem>
                            <asp:ListItem Value="1">1����</asp:ListItem>
                            <asp:ListItem Value="2">3����</asp:ListItem>
                            <asp:ListItem Value="3">����</asp:ListItem>
                            <asp:ListItem Value="4">1��</asp:ListItem>
                            <asp:ListItem Value="5">2��</asp:ListItem>
                            <asp:ListItem Value="6">3��</asp:ListItem>
                            <asp:ListItem Value="7">����</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 10%" align="right">
                        ���ѷ�ʽ:
                    </td>
                    <td style="width: 9%">
                        <asp:DropDownList ID="ddlPayType" runat="server" Width="105">
                            <asp:ListItem Value="">����</asp:ListItem>
                            <asp:ListItem Value="�������л��">�������л��</asp:ListItem>
                            <asp:ListItem Value="�������л��">�������л��</asp:ListItem>
                            <asp:ListItem Value="�������л��">�������л��</asp:ListItem>
                            <asp:ListItem>���жԹ����</asp:ListItem>
                            <asp:ListItem>ũҵ���л��</asp:ListItem>
                            <asp:ListItem>��ͨ���л��</asp:ListItem>
                            <asp:ListItem>����������</asp:ListItem>
                            <asp:ListItem>�ʾֻ��</asp:ListItem>
                            <asp:ListItem>����֧��</asp:ListItem>
                            <asp:ListItem>����֧��</asp:ListItem>
                            <asp:ListItem>��ֵ��֧��</asp:ListItem>
                            <asp:ListItem>������ʽ</asp:ListItem>
                            <asp:ListItem>���֧�����Զ���</asp:ListItem>
                            <asp:ListItem>����֧�����Զ���</asp:ListItem>
                            <asp:ListItem>�������ߣ��Զ���</asp:ListItem>
                            <asp:ListItem>��Ǯ֧�����Զ���</asp:ListItem>
                            <asp:ListItem>֧����֧�����Զ���</asp:ListItem>
                            <asp:ListItem>����֧�����Զ���</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 33%">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 58%;" align="right">
                                    ע�᷽ʽ:</td>
                                <td style="width: 42%;">
                                    <asp:DropDownList ID="ddlRegisterType" runat="server" Width="90%">
                                        <asp:ListItem>����</asp:ListItem>
                                        <asp:ListItem Value="1">����</asp:ListItem>
                                        <asp:ListItem Value="8">����</asp:ListItem>
                                        <asp:ListItem Value="9">�����</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="font-size: 12px">
        <td style="width: 9%" align="right">
            �������</td>
        <td align="right" style="width: 12%">
            <asp:DropDownList ID="ddlSoftwareType" runat="server" Width="90%">
            </asp:DropDownList></td>
        <td style="width: 9%" align="right">
            ��װ����</td>
        <td align="right" style="width: 13%">
            <asp:DropDownList ID="ddlInstallType" runat="server" Width="90%">
            </asp:DropDownList></td>
        <td style="width: 21%;">
            <table width="100%">
                <tr>
                    <td style="width: 40%; font-size: 12px;" align="right">
                        ʹ������
                    </td>
                    <td style="width: 60%">
                        &nbsp;<asp:DropDownList ID="ddlUseType" runat="server">
                            <asp:ListItem Selected="True" Value=" ">����</asp:ListItem>
                            <asp:ListItem Value="1">����</asp:ListItem>
                            <asp:ListItem Value="2">���</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </td>
        <td align="right" style="width: 8%">
            ��֤������</td>
        <td style="width: 13%">
            <asp:DropDownList ID="ddlRegType" runat="server" Width="90%">
                <asp:ListItem>����</asp:ListItem>
                <asp:ListItem Value="1">����</asp:ListItem>
                <asp:ListItem Value="8">����</asp:ListItem>
                <asp:ListItem Value="9">�����</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="2" style="width: 15%">
            <table style="width: 100%">
                <tr>
                    <td style="width: 20%" align="right">
                        ״̬��&nbsp;</td>
                    <td style="width: 80%">
                        &nbsp;
                        <asp:DropDownList ID="ddlTStatus" runat="server">
                            <asp:ListItem>����</asp:ListItem>
                            <asp:ListItem Value="1">���</asp:ListItem>
                            <asp:ListItem Value="2">�ϳ�</asp:ListItem>
                            <asp:ListItem Value="0">��ֹ</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="font-size: 12px">
        <td colspan="9">
            <table width="100%">
                <tr>
                    <td style="width: 10%">
                        ���ڶΣ�
                    </td>
                    <td style="width: 10%">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 10%">
                                    ��
                                </td>
                                <td style="width: 90%">
                                    <asp:TextBox ID="txtCreateTime1" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 10%">
                                    ��
                                </td>
                                <td style="width: 90%">
                                    <asp:TextBox ID="txtCreateTime2" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%" align="right">
                        ���ڷ�ʽ
                    </td>
                    <td style="width: 50%;">
                        <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">�����¼����</asp:ListItem>
                            <asp:ListItem Value="2">��һ�ε�½����</asp:ListItem>
                            <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 10%">
                        <asp:Button ID="btnOK" runat="server" Text="��������" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
