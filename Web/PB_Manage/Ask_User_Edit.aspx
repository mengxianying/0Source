<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_User_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_User_Edit" %>

<html>
<head runat="server">
    <title>用户查看 - 回复问题查看</title>
    <link href="stylecss/css.css" rel="stylesheet" type="text/css" />
</head>
<body >
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
                                                当前位置：回复问题查看</td>
                                            <td width="9%" align="right">
                                             </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" width="11%" height="32">
                                    BBS用户名:</td>
                                <td width="32%">
                                    &nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                                <td class="bold" width="12%">
                                    总得分:</td>
                                <td width="42%">
                                    &nbsp;<asp:Label ID="lblPoint" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    ID:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    悬赏付出:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblPointpenalty" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    开通时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOpenTime" runat="server"></asp:Label></td>
                                <td class="bold">
                                    罚分:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOtherPointpenalty" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    头衔:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                                <td valign="top" class="bold">
                                    总分数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblScore" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    用户组:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUserGroup" runat="server"></asp:Label></td>
                                <td valign="top" class="bold">
                                    问题数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblAskNum" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">正常</asp:ListItem>
                                        <asp:ListItem Value="1">锁定</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td valign="top" class="bold">
                                    回答数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblReplyNum" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    最佳答案数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBest_ReplyNum" runat="server"></asp:Label></td>
                                <td valign="top" class="bold">
                                    问题被删数:</td>
                                <td>
                                    <asp:Label ID="lblAsk_DelNum" runat="server"></asp:Label></td>
                            </tr>                        
                            <tr bgcolor="#F2F8FB">
                                <td colspan="8" align="center">
                                    <asp:Button ID="btn_ok" runat="server" Text="确定提交" OnClick="btn_ok_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
