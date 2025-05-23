<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_msg_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.US_msg_Editor" %>
<html>
<head runat="server">
    <title>用户信息-修改</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
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
                                                当前位置： 用户信息修改</td>
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
                                    &nbsp;<asp:Label ID="lblUsername" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    用户备注:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtUserRemarks" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    用户类型:</td>
                                <td>
                                   <asp:DropDownList ID="ddlUserType" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                    <asp:ListItem Value="0">初始值</asp:ListItem>
<%--
                                    <asp:ListItem Value="2">无限免费</asp:ListItem>
--%>
                                    <asp:ListItem Value="3">临时使用</asp:ListItem>
                                    <asp:ListItem Value="10">收费记天</asp:ListItem>
<%--
                                    <asp:ListItem Value="11">免费记天</asp:ListItem>
--%>
                                    <asp:ListItem Value="20">收费包月</asp:ListItem>
<%--
                                    <asp:ListItem Value="21">免费包月</asp:ListItem>
--%>
                                    <asp:ListItem Value="200">禁止使用</asp:ListItem>
                                   </asp:DropDownList>
              &nbsp;<span class="red12"></span></td>
                                <td class="bold">
                                    到期日期:</td>
                                <td>
                               &nbsp; <asp:TextBox ID="txtExpireDate" runat="server"></asp:TextBox>
                                  </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件名称:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSoftwareType" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    剩余天数:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtValidDays" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    使用次数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUseCount" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    创建时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    服务ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblServiceID" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    发帖统计:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtStatResult" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    登录ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastLoginID" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    登录时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastPayTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    登录信息:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblHDSNList" runat="server"></asp:Label><span class="red12"></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    备注信息:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="6" TextMode="MultiLine" Width="450px"></asp:TextBox><span
                                        class="red12"></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td>
                                    &nbsp;</td>
                                <td colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                        ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnreset" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();" />
                                    <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
              <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td class="bold">
                                    <a href="" class="zilan">用户信息管理表中的用户的发帖统计值</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
               <tr bgcolor="#F2F8FB">
                    <td width="13%" align="center">
                        未统计</td>
                    <td width="34%">
                        -1</td>
                    <td width="13%" align="center">
                        发帖不够</td>
                    <td width="34%">
                        0</td>
                </tr>
             <tr bgcolor="#F2F8FB">
                    <td align="center">
                        可使用3D</td>
                    <td width="34%">
                        256</td>
                    <td align="center">
                        可使用排列3</td>
                    <td width="34%">
                        512</td>
                </tr>
           <tr bgcolor="#F2F8FB">
                    <td align="center">
                        可使用3D和排列3</td>
                    <td width="34%">
                        768</td>
                    <td align="center">
                        可使用排列五</td>
                    <td width="34%">
                        1024</td>
                </tr>
               <tr bgcolor="#F2F8FB">
                    <td align="center">
                        可使用七星彩</td>
                    <td width="34%">
                        2048</td>
                    <td align="center">
                        可使用双色球</td>
                    <td width="34%">
                        4096</td>
                </tr>
             <tr bgcolor="#F2F8FB">
                    <td align="center">
                        可使用七乐彩</td>
                    <td width="34%">
                        8192</td>
                    <td align="center">
                        可使用大乐透</td>
                    <td width="34%">
                        16384</td>
                </tr>
                <tr>
                    <td colspan="4" bgcolor="#F2F8FB">
                        <b>注意：数字三软件中，只有数字三标准版和数字三专业版可以发帖免费，其他比如3D标准版（或数字三（3D标准）版）均不能发帖免费使用</b></td>
                </tr>
            </table>
            </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>
