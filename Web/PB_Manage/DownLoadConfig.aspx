<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DownLoadConfig.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.DownLoadConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品-资源下载配置</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" cellpadding="0" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
                <tr bgcolor="#f2f8fb">
                    <td background="images/Us_table _bg.jpg">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="images/Us_table _bg.jpg" class="webconfigbg">
                                    <strong>商品下载配置</strong>&nbsp;&nbsp;<font color="red">说明（当修改了其中一行配置后，一定要点击当前行后面的保存修改，修改才会生效）</font></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">
                                    前台显示名称</td>
                                <td>
                                    地址
                                </td>
                                <td>
                                    是否开启
                                </td>
                                <td>
                                    是否登录
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址一：</td>
                                <td>
                                    <asp:TextBox ID="txtProductName1" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtProductUrl1" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductOpen1" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductNeedLogin1" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnProduct1" runat="server" Text="保存修改" OnClick="btnProduct1_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址二：</td>
                                <td>
                                    <asp:TextBox ID="txtProductName2" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtProductUrl2" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductOpen2" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductNeedLogin2" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnProduct2" runat="server" Text="保存修改" OnClick="btnProduct2_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址三：</td>
                                <td>
                                    <asp:TextBox ID="txtProductName3" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtProductUrl3" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductOpen3" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductNeedLogin3" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnProduct3" runat="server" Text="保存修改" OnClick="btnProduct3_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址四：</td>
                                <td>
                                    <asp:TextBox ID="txtProductName4" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtProductUrl4" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductOpen4" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblProductNeedLogin4" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnProduct4" runat="server" Text="保存修改" OnClick="btnProduct4_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td colspan="5">
                                    <strong>资源下载配置</strong></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址一：</td>
                                <td>
                                    <asp:TextBox ID="txtSoftName1" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSoftUrl1" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftOpen1" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftNeedLogin1" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnSoft1" runat="server" Text="保存修改" OnClick="btnSoft1_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址二：</td>
                                <td>
                                    <asp:TextBox ID="txtSoftName2" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSoftUrl2" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftOpen2" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftNeedLogin2" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnSoft2" runat="server" Text="保存修改" OnClick="btnSoft2_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址三：</td>
                                <td>
                                    <asp:TextBox ID="txtSoftName3" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSoftUrl3" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftOpen3" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftNeedLogin3" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnSoft3" runat="server" Text="保存修改" OnClick="btnSoft3_Click" /></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>
                                    下载地址四：</td>
                                <td>
                                    <asp:TextBox ID="txtSoftName4" runat="server" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSoftUrl4" runat="server" Width="260px"></asp:TextBox></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftOpen4" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                        <asp:ListItem Value="0">关闭</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RadioButtonList ID="rblSoftNeedLogin4" runat="server" RepeatDirection="Horizontal"
                                        Width="120px">
                                        <asp:ListItem Selected="True" Value="1">登录</asp:ListItem>
                                        <asp:ListItem Value="0">游客</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    &nbsp;<asp:Button ID="btnSoft4" runat="server" Text="保存修改" OnClick="btnSoft4_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
