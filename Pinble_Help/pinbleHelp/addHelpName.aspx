<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addHelpName.aspx.cs" Inherits="Pinble_Help.pinbleHelp.addHelpName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��Ӱ����ļ�����</title>
    <link rel="stylesheet" href="../css/table.css" />
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tab">
        <tr>
            <td>
                �����ļ����ƣ�
            </td>
            <td>
                <asp:TextBox ID="txt_HelpName" runat="server"></asp:TextBox>  
                <br />
                ���磺����������ͨ���� 
                <br />
                <font color="red">˵������������ļ���ͬ���ļ�������дһ�μ��ɡ�</font>
            </td>
        </tr>
        <tr>
            <td>
                ״̬��
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">����</asp:ListItem>
                <asp:ListItem Value="2">�ر�</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_add" runat="server" Text="���" OnClick="btn_add_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
