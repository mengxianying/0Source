<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebDomainConfig.aspx.cs" Inherits="Pbzx.Web.PB_Manage.WebDomainConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table width="97%" cellpadding="0" cellspacing="1" border="0" align="center">
                                        <tr>
                                            <td style="height: 18px">
                                                <strong>聊彩室WebDomain配置</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="height: 26px" align="right">
                                                            网站地址：
                                                        </td>
                                                        <td style="height: 26px" align="left">
                                                            &nbsp;<asp:TextBox ID="txtWwwUrl" runat="server" Width="180px"></asp:TextBox></td>
                                                        <td style="height: 26px" align="right">
                                                            拼搏吧地址：</td>
                                                        <td style="height: 26px" align="left">
                                                            <asp:TextBox ID="txtBarUrl" runat="server" Width="180px"></asp:TextBox></td>
                                                        <td style="height: 26px">
                                                        </td>
                                                        <td style="height: 26px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            聊彩室地址：</td>
                                                        <td align="left">
                                                            &nbsp;<asp:TextBox ID="txtChatUrl1" runat="server" Width="180px"></asp:TextBox></td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                        </td>
                                                        <td align="center" colspan="3">
                                                            <asp:Button ID="btnChatConfig" runat="server" OnClick="btnChatConfig_Click" Text="保存修改" />
                                                            &nbsp; &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                        </td>
                                                        <td align="right" colspan="3">
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
