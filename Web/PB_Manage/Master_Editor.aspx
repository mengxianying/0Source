<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Master_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Master_Editor" %>
<html>
<head id="Head1" runat="server">
    <title>添加修改管理员</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="Master_Manage.aspx" class="zilan">管理员管理</a> |&nbsp;
                                     <a href="Master_Editor.aspx" class="zilan">添加管理员</a> </td>
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
                                            <asp:Label ID="lblAction" runat="server"></asp:Label>帐户</td>
                                        <td width="9%" align="right">
                                           </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#CED7F7">
                        <tr bgcolor="#F2F8FB">
                            <td width="25%" class="bold">
                                用 户 名:</td>
                            <td width="75%" align="left">
                                <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtUserID" runat="server" Visible="False" Width="30px">0</asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                新
                                密 码:</td>
                            <td align="left" style="height: 30px">
                                <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" Width="150px"></asp:TextBox>(注：如果不想修改密码请留空！)</td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                确认密码:</td>
                            <td align="left">
                                <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                允许登录ip地址:</td>
                            <td align="left">
                                <asp:TextBox ID="txtIPLimit" runat="server" Width="228px" Height="143px" 
                                    TextMode="MultiLine"></asp:TextBox>(注：多个IP地址请用“|”隔开！例：192.168.1.1|192.168.1.2   不限制可以为空)
                             </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                允许登录省份:</td>
                            <td align="left">
                                <asp:TextBox ID="txtRegionLimit" runat="server" Width="228px" Height="143px"  TextMode="MultiLine"></asp:TextBox>(注：多个省份请用“|”隔开！例：北京|上海   不限制可以为空)
                             </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                登陆状态:</td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">正常</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">禁止</asp:ListItem>
                                </asp:RadioButtonList>(默认情况新添加的管理员是禁止登录的，如果允许登陆，请选“正常”)</td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td colspan="2" align="center">
                                <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
