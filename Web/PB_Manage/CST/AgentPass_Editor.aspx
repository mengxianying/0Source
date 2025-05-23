<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AgentPass_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.AgentPass_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<html>
<head id="Head1" runat="server">
    <title>添加编辑正式代理</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="AgentPass_Manage.aspx" class="zilan">代理商信息管理</a> |&nbsp; <a href="AgentPass_Editor.aspx"
                                        class="zilan">添加代理商信息</a>
                                </td>
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
                                                当前位置：添加代理商信息</td>
                                            <td width="9%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F1F1F1">
                                <td width="13%" class="bold">
                                    编号:</td>
                                <td>
                                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                </td>
                                <td  class="bold">
                                    用户名:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator></span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    真实姓名:</td>
                                <td width="38%">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><span class="red12" style="color: #ff0000">*<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="真实姓名不能为空"></asp:RequiredFieldValidator></span></td>
                                <td width="12%" class="bold">
                                    <span class="forumRow">传真:</span></td>
                                <td width="37%">
                                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    范围:</td>
                                <td>
                                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox><span style="color: #ff0000">*</span><span
                                        style="color: #333;">例：海口代理<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                            runat="server" ControlToValidate="txtType" ErrorMessage="范围不能为空"></asp:RequiredFieldValidator></span></td>
                                <td class="bold">
                                    <span class="forumRow">手机:</span></td>
                                <td>
                                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox><span style="color: #ff0000"></span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    电话:</td>
                                <td>
                                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTel" ErrorMessage="电话不能为空"></asp:RequiredFieldValidator></span></td>
                                <td class="bold">
                                    <span class="forumRow">电子邮件:</span></td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    公司:</td>
                                <td>
                                    <asp:TextBox ID="txtCompany" runat="server" Width="250"></asp:TextBox></td>
                                <td class="bold">
                                    <span class="forumRow">邮编:</span></td>
                                <td>
                                    <asp:TextBox ID="txtPost" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    详细地址:</td>
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtAddress" runat="server" Width="250"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ErrorMessage="详细地址不能为空"></asp:RequiredFieldValidator></span></td>
                                <td class="bold">
                                    <span class="forumRow">所在省市:</span></td>
                                <td style="height: 30px">
                                    <asp:DropDownList ID="ddlProvince" runat="server">
                                    </asp:DropDownList>
                                    <%--  <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>--%>
                                    <span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    代理折扣:</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtPrice" runat="server" Width="46px"></asp:TextBox>%</td>
                                <td class="bold">
                                    过期时间:&nbsp;</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtExpireD" runat="server" onfocus="calendar();"></asp:TextBox><span
                                        style="color: #ff0000">*</span><span style="color: #333;">（格式：2005-12-31）</span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    <span class="forumRow">状态:</span></td>
                                <td>
                                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">许可</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">禁用</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td class="bold">
                                    <span class="forumRow">是否前台显示:</span></td>
                                <td>
                                    <asp:RadioButtonList ID="rblshow" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    其它联系方式:</td>
                                <td colspan="3">
                                    <%--   &nbsp;<asp:TextBox ID="txtNote" runat="server" Rows="4" TextMode="MultiLine" Width="450px"></asp:TextBox>内部看不对外显示--%>
                                    <asp:TextBox ID="txtPostmore" runat="server" MaxLength="50" Width="280px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    简介:</td>
                                <td colspan="3">
                                    <br />
                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="1020" Rows="8" TextMode="MultiLine"
                                        Width="550px"></asp:TextBox>（对外显示）<br />
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    备注:</td>
                                <td colspan="3">
                                    <br />
                                  <asp:TextBox ID="txtAgtmore" runat="server" MaxLength="1020" Rows="8" TextMode="MultiLine"
                                        Width="550px"></asp:TextBox>(内部使用，不对外显示)<br />
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                        ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    &nbsp;&nbsp; &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button"
                                        Text="取消" OnClientClick="history.back();return false;" />
                                    <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
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
