<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_softpost_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.US_softpost_Editor" EnableEventValidation="false" %>

<%@ Import Namespace="System.Data" %>
<html>
<head runat="server">
    <title>软件发贴管理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                                当前位置： 软件发贴管理</td>
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
                                    软件类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblName" runat="server" Width="200px"></asp:Label>
                                    <asp:UpdatePanel ID="upSoftType" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        软件类型:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged"
                                                            Width="80">
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        安装类型:</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstallType" runat="server" Width="80">
                                                            <asp:ListItem Value="">所有</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center">
                                    <b>对应版面信息</b></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                </td>
                                <td>
                                    <asp:DataList ID="dlBMXX" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                        Width="100%">
                                        <ItemTemplate>
                                            <%# showBoards(Eval("boardid"), Eval("BoardType"))%>
                                        </ItemTemplate>
                                    </asp:DataList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    发贴限制:</td>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#BADEFE">
                                        <tr>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <b>管理员</b></td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <b>最小主题帖数</b></td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <b>最小跟帖数</b></td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <b>最小发帖分配的天数</b></td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <b>最小精华数</b></td>
                                        </tr>
                                        <%
                                            string dsUserType = Maticsoft.DBUtility.DbHelperSQL1.GetSingle("Select ConfigValue From CN_Config Where ConfigName = 'AllPostUserType' ").ToString();
                                            string[] dsUserTypeSZ = dsUserType.Split(new char[] { '|' });
                                            for (int i = 0; i < dsUserTypeSZ.Length; i++)
                                            {
                                                if (dsUserTypeSZ[i].Length > 0)
                                                {                                                                                                 
                                        %>
                                        <tr>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <%=dsUserTypeSZ[i]%>
                                            </td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <input name="MinTopics<%=i %>" value="<%=MinTopics[i] %>" type="text" />
                                            </td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <input name="MinAnncounts<%=i %>" value="<%=MinAnncounts[i] %>" type="text" />
                                            </td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <input name="MinDays<%=i %>" value="<%=MinDays[i] %>" type="text" />
                                            </td>
                                            <td bgcolor="#FFFFFF" align="center">
                                                <input name="MinBests<%=i %>" value="<%=MinBests[i] %>" type="text" />
                                            </td>
                                        </tr>
                                        <%        }
                                              }
                                        %>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    信息:</td>
                                <td>
                                    &nbsp;名称：<asp:TextBox ID="txtLottery" runat="server"></asp:TextBox>&nbsp;&nbsp;ID:<asp:TextBox
                                        ID="txtLotteryID" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    情况:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblFlag" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">内部使用</asp:ListItem>
                                        <asp:ListItem Value="1">正常</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">启用</asp:ListItem>
                                        <asp:ListItem Value="2">禁用</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="btn_add" runat="server" Text="提交" OnClick="btn_add_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
