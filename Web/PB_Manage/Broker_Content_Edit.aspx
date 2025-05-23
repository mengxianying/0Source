<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker_Content_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Broker_Content_Edit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加编辑经纪人页面信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script src="javascript/calendar.js" type="text/javascript"></script>

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
                                    <a href="Broker_Content.aspx" class="zilan">页面信息管理</a> |&nbsp; <a href="Broker_Content_Edit.aspx"
                                        class="zilan">添加页面信息</a>
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
                                                当前位置：添加页面信息</td>
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
                                    标题：</td>
                                <td width="85%">
                                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    类别：</td>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server">
                                        <asp:ListItem Value="申请流程  ">申请流程</asp:ListItem>
                                        <asp:ListItem Value="详细介绍  ">详细介绍</asp:ListItem>
                                        <asp:ListItem Value="经纪人好处">经纪人好处</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    状态：</td>
                                <td>
                                    <asp:CheckBox ID="cbIsAuditing" runat="server" Text="已审核" /></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    排序：</td>
                                <td align="left">
                                    <asp:TextBox ID="txtIntSortID" runat="server" MaxLength="3" Width="50px">0</asp:TextBox><span
                                        style="color: #ff0000">*</span>（注：数字越小越靠前）</td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" valign="top">
                                    内容：</td>
                                <td>
                                    <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Width="95%" Height="380">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
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
