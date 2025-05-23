<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_Reply_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_Reply_Edit" %>

<html>
<head runat="server">
    <title>问题回复查看 - 拼搏吧</title>
    <link href="stylecss/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
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
                                    问题标题:</td>
                                <td width="32%">
                                    &nbsp;<asp:Label ID="lblQuestionId" runat="server"></asp:Label></td>
                                <td class="bold" width="12%">
                                    回复者:</td>
                                <td width="42%">
                                    &nbsp;<asp:Label ID="lblReplyer" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    回复时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblReplyTime" runat="server"></asp:Label></td>
                                <td class="bold">
                                    回复者编号:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblReplyerId" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    是否最佳:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblIsBest" runat="server"></asp:Label></td>
                                <td class="bold">
                                    上传文件编号:</td>
                                <td>&nbsp;
                                    <asp:Label ID="lblAttachId" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    好评:</td>
                                <td>
                              <asp:TextBox ID="txtGoodComment" runat="server" Rows="1" Width="80px" Enabled="False"></asp:TextBox></td>
                                <td valign="top" class="bold">
                                    坏评:</td>
                                <td>
                              <asp:TextBox ID="txtBadComment" runat="server" Rows="1" Width="80px" Enabled="False"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td valign="top" class="bold">
                                    参考资料:</td>
                                <td>
                              <asp:TextBox ID="txtReferenceBook" runat="server" Rows="5" TextMode="MultiLine" Width="260px" Enabled="False"></asp:TextBox></td>
                                <td valign="top" class="bold">
                                    评论:</td>
                                <td>
                              <asp:TextBox ID="txtComment" runat="server" Rows="5" TextMode="MultiLine" Width="260px" Enabled="False"></asp:TextBox></td>
                          <tr bgcolor="#F2F8FB">
                                    <td valign="top" class="bold">
                                        回复内容:</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtContent" runat="server" Rows="10" TextMode="MultiLine" Width="600px" Enabled="False"></asp:TextBox></td>
                          </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td colspan="8" align="center">
                                        <asp:Button ID="btn_ok" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();" />&nbsp;</td>
                                </tr>
                      </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
