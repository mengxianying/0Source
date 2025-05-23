<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNoet.aspx.cs" Inherits="Pinble_Help.pinbleHelp.addNoet" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加节点</title>
    <link rel="stylesheet" href="../css/table.css" />
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
            <div id="RootNoet" runat="server">
                &nbsp;</div>
            <div id="Noet" runat="server">
                <table width="100%" class="tab">
                    <%--                <tr>
                    <td>
                        名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>  说明： 帮助文件的名称
                    </td>
                </tr>--%>
                    <tr>
                        <td align="left">
                            选择父节点：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_fatherNoet" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
                            &nbsp; 说明：如果没有选择的帮助说明，请直接添加
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            节点名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_NoetName" runat="server"></asp:TextBox> 添加一个名称
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            内容：
                        </td>
                        <td>
                            <FCKeditorV2:FCKeditor ID="fck_Noet" runat="server" Width="95%" Height="380">
                            </FCKeditorV2:FCKeditor>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            静态网页名称：
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="ddl_path" runat="server">
                            </asp:DropDownList>
                            <font color="red">说明：请选择帮助文件的类型（公共的帮助文件请选择——公用说明，其它的选择--说明）</font>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_addNoet" runat="server" Text="添加节点" OnClick="btn_addNoet_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
