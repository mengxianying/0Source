<%@ Page Language="C#" AutoEventWireup="true" Codebehind="admin_Ly_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.admin_Ly_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户留言回复查看</title>
    <link href="StyleCss/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：留言详细信息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    留言标题:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLy_Email" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    留言姓名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLyUserName" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    留言类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLySort" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    留言内容:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtLyContent" runat="server" ReadOnly="True" Rows="7" TextMode="MultiLine"
                                        Width="360px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    回复内容:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtResume" runat="server" Rows="7" TextMode="MultiLine" Width="360px"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btBack" runat="server" Text="回复" OnClick="btBack_Click" />&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btClose" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close()" />
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
