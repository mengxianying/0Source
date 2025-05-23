<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="software.aspx.cs" Inherits="Pinble_Help.pinbleHelp.software" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加关联节点</title>
    <link type="text/css" rel="stylesheet" href="../css/table.css" />
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" class="tab">
        <tr>
            <td>
                帮助名称：
            </td>
            <td>
                <asp:Label ID="lab_helpName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                选择软件：
            </td>
            <td>
                <asp:CheckBoxList ID="cb_listSoftware" runat="server" RepeatDirection="Horizontal" RepeatColumns="5" OnDataBound="cb_listSoftware_DataBound">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_add" runat="server" Text="添加" OnClick="btn_add_Click" />&nbsp;
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
