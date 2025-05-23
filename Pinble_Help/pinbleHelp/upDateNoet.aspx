<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upDateNoet.aspx.cs" Inherits="Pinble_Help.pinbleHelp.upDateNoet" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改帮助</title>
    <link type="text/css" rel="Stylesheet" href="../css/table.css" />
    <script language="javascript" type="text/javascript">
function FCKeditor_OnComplete( editorInstance )
{
editorInstance.SwitchEditMode();
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellspacing="1" class="tab">
        <tr >
            <td align="right">
                软件名称:
            </td>
            <td>
                <asp:Label ID="lab_name" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                上级编号：
            </td>
            <td>
                 <asp:TextBox ID="txt_superior" runat="server" Width="191px"></asp:TextBox>&nbsp;&nbsp;上级组名称: <font color="red"> <asp:Label
                     ID="Label1" runat="server" Text="Label"></asp:Label></font>
            </td>
        </tr>
        <tr>
            <td>
                排序编号：
            </td>
            <td>
                 <asp:TextBox ID="txt_sort" runat="server" Width="191px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;修改排序编号可以改变排序的顺序
            </td>
        </tr>
        <tr>
            <td align="right">
                名称：
            </td>
            <td>
                <asp:TextBox ID="txt_NoetName" runat="server" Width="197px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                页面代码：
            </td>
            <td>
                <FCKeditorV2:FCKeditor ID="fck_RootNoet" runat="server" Width="95%" Height="380">
                                    </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td align="right">
                静态页面地址：
            </td>
            <td>
                <asp:TextBox ID="txt_path" runat="server" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_upDate" runat="server" Text="修改" OnClick="btn_upDate_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
