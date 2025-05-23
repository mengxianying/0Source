<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ask_Question_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_Question_Edit" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>
<head runat="server">
    <title>问题查看 - 拼搏吧</title>
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
                                            当前位置：问题查看信息
                                        </td>
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
                                问题标题:
                            </td>
                            <td width="35%">
                                &nbsp;<asp:Label ID="lblTitle" runat="server"></asp:Label>
                            </td>
                            <td class="bold" width="12%">
                                问题编号:
                            </td>
                            <td width="35%">
                                &nbsp;<asp:Label ID="lblId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                问题补充:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblRelay" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                提问时间:
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtAskTime" runat="server" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                所属分类:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblTypeName" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                结束时间:
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtOverTime" runat="server" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                类别编号:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblTypeID" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                更新时间:
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtUpdateTime" runat="server" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                父类别编号:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblFTypeID" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                赏分:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblLargessPoint" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                提问者:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblAsker" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                回答者:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblAnswerer" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                提问者编号:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblAskerId" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                回答者编号:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblAnswererId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                精华推荐:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblIsCommend" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">精华</asp:ListItem>
                                    <asp:ListItem>非精华</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="bold">
                                上传文件编号:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblAttachId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                是否匿名:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblIsNM" runat="server"></asp:Label>
                            </td>
                            <td class="bold">
                                回答次数:
                            </td>
                            <td>
                                &nbsp;<asp:Label ID="lblReplys" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <%-- <td class="bold">
                                    是否精华:</td>
                                <td>
                                 <asp:RadioButtonList ID="rblBitIsHot" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" >精华</asp:ListItem>
                                        <asp:ListItem >不精华</asp:ListItem>
                                    </asp:RadioButtonList></td>--%>
                            <td class="bold">
                                查看次数:
                            </td>
                            <td colspan="3">
                                &nbsp;<asp:Label ID="lblViews" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                问题状态:
                            </td>
                            <td>
                                &nbsp;<asp:DropDownList ID="ddlState" runat="server">
                                    <asp:ListItem Value="0">待解决</asp:ListItem>
                                    <asp:ListItem Value="1">已解决</asp:ListItem>
                                    <asp:ListItem Value="2">已关闭</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="bold">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td class="bold">
                                详细内容:
                            </td>
                            <td colspan="3">
                                <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="400px" Width="90%">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                        <tr bgcolor="#F2F8FB">
                            <td colspan="8" align="center">
                                <asp:Button ID="btn_ok" runat="server" Text="确定修改" OnClick="btn_ok_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();" />
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
