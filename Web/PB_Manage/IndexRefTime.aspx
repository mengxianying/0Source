<%@ Page Language="C#" AutoEventWireup="true" Codebehind="IndexRefTime.aspx.cs" Inherits="Pbzx.Web.PB_Manage.IndexRefTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>首页内容刷新时间配置</title>
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
                                    <strong>首页内容刷新时间配置</strong></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="3" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                            <tr bgcolor="#f2f8fb">
                                <td colspan="2">
                                    <strong>首页拼搏吧刷新时间：</strong>                                                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td width="19%" align="right">
                                    基本刷新时间间隔:</td>
                                <td width="81%">
                                    <asp:TextBox ID="txtBarBase" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                    <span style="color: #ff0000">*</span>分钟<span style="color: #ff0000"></span></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>                                </td>
                                <td>
                                    特殊刷新起始时间和时间间隔(开始、结束、刷新间隔任何一个为空则该条记录不起作用)                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>&nbsp;                                    </td>
                                <td>
                                    <table width="88%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">                                                        </td>
                                                        <td width="27%">
                                                            开始时间</td>
                                                        <td width="29%">
                                                            结束时间</td>
                                                        <td width="27%">
                                                            刷新间隔</td>
                                                        <td width="14%">
                                                            是否开启</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            1、                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarStart1" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
                                                            —</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarEnd1" runat="server" Width="60px" MaxLength="6"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarJG1" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                                            分钟                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rblBarOpen1" runat="server" RepeatDirection="Horizontal"
                                                                Width="120px">
                                                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            2、                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarStart2" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
                                                            —</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarEnd2" runat="server" Width="60px" MaxLength="6"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarJG2" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                                            分钟                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rblBarOpen2" runat="server" RepeatDirection="Horizontal"
                                                                Width="120px">
                                                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            3、                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarStart3" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
                                                            —</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarEnd3" runat="server" Width="60px" MaxLength="6"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtBarJG3" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                                            分钟                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rblBarOpen3" runat="server" RepeatDirection="Horizontal"
                                                                Width="120px">
                                                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                </table>                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnBarSave" runat="server" Text="保存修改" OnClick="btnBarSave_Click" />                                            </td>
                                        </tr>
                                    </table>                                </td>
                            </tr></table><br /><table width="100%" cellpadding="3" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                            <tr bgcolor="#f2f8fb">
                                <td colspan="2">
                                    <strong>首页BBS刷新时间：</strong>                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    基本刷新时间间隔:</td>
                                <td>
                                    <asp:TextBox ID="txtBbsBase" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                    <span style="color: #ff0000">*</span>分钟</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td>&nbsp;                                    </td>
                                <td>
                                    <table width="88%" border="0" align="left" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">                                                        </td>
                                                        <td width="28%">
                                                            开始时间</td>
                                                        <td width="29%">
                                                            结束时间</td>
                                                        <td width="28%">
                                                            刷新间隔</td>
                                                        <td width="12%">
                                                            是否开启</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            1、                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsStart1" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
                                                            —                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsEnd1" runat="server" Width="60px" MaxLength="6"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsJG1" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                                            分钟                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rblBbsOpen1" runat="server" RepeatDirection="Horizontal"
                                                                Width="120px">
                                                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            2、                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsStart2" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
                                                            —</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsEnd2" runat="server" Width="60px" MaxLength="6"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsJG2" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                                            分钟                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rblBbsOpen2" runat="server" RepeatDirection="Horizontal"
                                                                Width="120px">
                                                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            3、                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsStart3" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
                                                            —</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsEnd3" runat="server" Width="60px" MaxLength="6"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtBbsJG3" runat="server" Width="40px" MaxLength="3" onkeypress="isnum()"></asp:TextBox>
                                                            分钟                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="rblBbsOpen3" runat="server" RepeatDirection="Horizontal"
                                                                Width="120px">
                                                                <asp:ListItem Selected="True" Value="1">开启</asp:ListItem>
                                                                <asp:ListItem Value="0">关闭</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                </table>                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnBbsSave" runat="server" Text="保存修改" OnClick="btnBbsSave_Click" />                                            </td>
                                        </tr>
                                    </table>                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
