<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QQ_GroupEdite.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.QQ_GroupEdite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QQ群修改</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />

    <script src="/javascript/calendar.js" type="text/javascript"></script>

    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />


    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div>
               &nbsp;&nbsp;<strong> <asp:Label ID="lblAction" runat="server" Text=""></asp:Label></strong>
            </div>
            <table runat="server" id="tbEdite" style="width:800px; border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        QQ群号：
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:TextBox ID="txtQQ_GroupID" runat="server" MaxLength="18"></asp:TextBox><font
                            color="red">*</font>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        群名称：
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:TextBox ID="txtQQ_GroupName" runat="server" MaxLength="25" Width="190px"></asp:TextBox><font
                            color="red">*</font>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        群类型：
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:RadioButtonList ID="rblQQ_GroupType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">福彩群</asp:ListItem>
                            <asp:ListItem Value="1">体彩群</asp:ListItem>
                            <asp:ListItem Value="2">双彩群</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        是否是软件用户群：
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:RadioButtonList ID="rblIsSoftGroup" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        群管理员：
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:TextBox ID="txtAdmin" runat="server" MaxLength="60" Width="300px"></asp:TextBox>
                        <%--&nbsp;<asp:ListBox ID="lsbAdmin" runat="server"></asp:ListBox>--%>
                        (格式：m1|m2|m3|m4)最多4个</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        群备注：
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        &nbsp;<asp:TextBox ID="txtDetails" runat="server" MaxLength="200" TextMode="MultiLine"
                            Width="450px" Height="120px"></asp:TextBox>(注：最多200字)</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        是否启用：</td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:RadioButtonList ID="rblIsEnable" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        排序编号：</td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid">
                        <asp:TextBox ID="txtSortID" runat="server" MaxLength="3" Width="50px">0</asp:TextBox><span
                            style="color: #ff0000">*</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        <asp:HiddenField ID="hfID" runat="server" />
                    </td>
                    <td style="border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack1_Click" /></td>
                    <td style="height: 46px">
                    </td>
                </tr>
            </table>
            <table id="tbSee" runat="server" style="width:800px; line-height:26px; border-right: #d4d4d4 1px solid; border-top: #d4d4d4 1px solid; border-left: #d4d4d4 1px solid; border-bottom: #d4d4d4 1px solid;">
                <tr>
                    <td align="right" width="20%">
                        QQ群号：
                    </td>
                    <td  width="80%">
                        <asp:Label ID="lblQQ_GroupID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        群名称：
                    </td>
                    <td>
                        <asp:Label ID="lblQQ_GroupName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        群类型：
                    </td>
                    <td>
                        <asp:Label ID="lblQQ_GroupType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        是否是软件用户群：
                    </td>
                    <td>
                        <asp:Label ID="lblIsSoftGroup" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        群管理员：
                    </td>
                    <td>
                        <asp:Label ID="lblAdmin" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        群备注：
                    </td>
                    <td>
                        <asp:Label ID="lblDetails" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        是否启用：</td>
                    <td>
                        <asp:Label ID="lblIsEnable" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        排序编号：</td>
                    <td>
                        <asp:Label ID="lblSortID" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td>
                        &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnBack1" runat="server" Text="返回" OnClick="btnBack1_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
