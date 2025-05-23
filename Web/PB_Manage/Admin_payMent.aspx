<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Admin_payMent.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Admin_payMent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>支付方式管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
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
                                                当前位置：财务管理&gt;&gt;支付方式管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table id="MyGridView" width="97%" cellpadding="2" cellspacing="1" border="0" align="center">
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    名称
                                </td>
                                <td>
                                    商户编号
                                </td>
                                <td>
                                    密钥
                                </td>
                                <td>
                                    接收网址
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    云网</td>
                                <td>
                                    <asp:TextBox ID="txtCncardSH" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtCncardMY" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtCncardWZ" runat="server" Width="240px"></asp:TextBox></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnCnCard" runat="server" Text="修改" OnClick="btnCnCard_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    快钱</td>
                                <td>
                                    <asp:TextBox ID="txt99BillSH" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt99BillMY" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt99BillWZ" runat="server" Width="240px"></asp:TextBox></td>
                                <td>
                                    &nbsp;<asp:Button ID="btn99Bill" runat="server" Text="修改" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
