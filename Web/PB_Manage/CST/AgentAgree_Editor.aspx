<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AgentAgree_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.AgentAgree_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加合同政策</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="AgentAgree.aspx" class="zilan">合同政策管理</a> |&nbsp; <a href="AgentAgree_Editor.aspx"
                                        class="zilan">添加合同政策</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：添加代理信息</td>
                                            <td width="9%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" width="15%">
                                    名称:</td>
                                <td width="85%">
                                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="50"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    用途:</td>
                                <td>
                                    <asp:TextBox ID="txtPurpose" runat="server" MaxLength="20"></asp:TextBox>不要随便更改，前台调用的时候根据这一列来调用的！</td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Selected="True">已审核</asp:ListItem>
                                        <asp:ListItem Value="1">未审核</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" valign="top">
                                    内容:</td>
                                <td>
                                    <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Width="95%" Height="360">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                      <%--      <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    附件:</td>
                                <td>
                                    <asp:TextBox ID="txtAddUrl" runat="server" MaxLength="150" Width="300px"></asp:TextBox>
                                    当前地址：<asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr bgcolor="#F1F1F1">
                                <td>
                                </td>
                                <td>
                                    <span class="red12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp; &nbsp;<asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="取消"
                                            OnClick="btnCancel_Click" /></span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
