<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Usermsg_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.Usermsg_Editor" %>

<html>
<head runat="server">
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
    <title>网络版用户信息查看</title>
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
                                                当前位置：网络版用户信息查看</td>
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
                                    用户名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUsername" runat="server"></asp:Label></td>
                            <td class="bold">用户备注</td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtUserRemarks" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    用户类型:</td>
                                <td style="height: 25px">
                                    &nbsp;<asp:Label ID="lbluserType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    到期日期:</td>
                                <td style="height: 25px">
                                    &nbsp;<asp:Label ID="lblExpireDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件名称:</td>
                                <td style="height: 25px">
                                    &nbsp;<asp:Label ID="lblSoftwareType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    剩余天数:</td>
                                <td style="height: 25px">
                                    &nbsp;<asp:Label ID="lblValidDays" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    使用次数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUseCount" runat="server"></asp:Label></td>
                                <td class="bold">
                                    创建时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    服务ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblServiceID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    发帖统计:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtStatResult" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    登录ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastLoginID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    登录时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastPayTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    登录信息:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblHDSNList" runat="server"></asp:Label></td>
                                <td align="right" style="width: 114px">
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 122px">
                                    备注信息:</td>
                                <td colspan="3" style="height: 122px">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="7" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">                                   
                                    <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定提交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_reset" runat="server" Text="取消" OnClick="btn_reset_Click" />
                                </td>
                            </tr>
                        </table>
        </div>
        
    </form>
</body>
</html>
