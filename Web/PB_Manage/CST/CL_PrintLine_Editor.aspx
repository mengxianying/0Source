<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CL_PrintLine_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.CL_PrintLine_Editor" %>

<html>
<head runat="server">
    <title>修改打印线信息</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--    <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="CENTER">
                               <a href="CL_PrintLine_Manage.aspx" class="zilan">管理打印线信息</a> |&nbsp;
                                    <a href="CL_PrintLine_Editor.aspx" class="zilan">添加打印线信息</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>
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
                                                当前位置：修改打印线信息</td>
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
                                    序列号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSN" runat="server"></asp:Label></td>
                                <td class="bold">
                                    入库时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblAcceptTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建时间:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
                                <td class="bold">
                                    入库者:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblAccepter" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建者:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreator" runat="server"></asp:Label></td>
                                <td class="bold">
                                    销售时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSellTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td>
                                    &nbsp;<asp:DropDownList ID="ddlStatus" runat="server">
                                        <asp:ListItem Value="0">新创建</asp:ListItem>
                                        <asp:ListItem Value="1">已入库</asp:ListItem>
                                        <asp:ListItem Value="2">已销售</asp:ListItem>
                                        <asp:ListItem Value="3">已丢失</asp:ListItem>
                                        <asp:ListItem Value="4">已损坏</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td class="bold">
                                    销售者:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSeller" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblType" runat="server"></asp:Label></td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    备注信息:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="7" TextMode="MultiLine" Width="520px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定提交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" />
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
