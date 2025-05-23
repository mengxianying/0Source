<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Public_Content_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Public_Content_Edit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>内容添加</title>
    <link href="StyleCss/css.css" rel="stylesheet" type="text/css" />
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
                                    <a href="Public_Content.aspx" class="zilan">内容管理</a> |&nbsp; <a href="Public_Content_Edit.aspx"
                                        class="zilan">添加内容</a>
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
                                                当前位置：添加内容</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" width="15%">
                                    标题：</td>
                                <td width="85%">
                                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="200"></asp:TextBox><span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    类别：</td>
                                <td>
                                    <span style="color: #ff0000">
                                        <asp:DropDownList ID="ddlClass" runat="server">
                                            <asp:ListItem Selected="True" Value="网站版权">网站版权</asp:ListItem>
                                        </asp:DropDownList></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态：</td>
                                <td>
                                    <asp:CheckBox ID="chbState" runat="server" Checked="false" Text="已审核" /></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    内容：</td>
                                <td>
                                    <span style="color: #ff0000">
                                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="320px" Width="90%">
                                        </FCKeditorV2:FCKeditor>
                                    </span>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 28px">
                                    静态页面地址：</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtHtmUrl" runat="server" MaxLength="200" Width="380px"></asp:TextBox><span
                                        style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click"  />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" Visible="False" />
                                    <asp:HiddenField ID="hfContentID" runat="server" Value="0" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
