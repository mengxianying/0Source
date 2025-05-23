<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Agent_Editor.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Cst.Agent_Editor" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<html>
<head runat="server">
    <title>注册代理商查看编辑</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        }  
    </script>

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
                                    <a href="Agent_Manage.aspx" class="zilan">注册代理商信息管理</a> |&nbsp; <a href="AgentPass_Editor.aspx"
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
                            <%--  <tr bgcolor="#F1F1F1"><td class="bold" style="width: 120px">
                                    编号:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblID" runat="server"></asp:Label></td>
                            </tr>--%>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    真实姓名:</td>
                                <td width="38%">
                                    &nbsp;<asp:Label ID="lblName" runat="server"></asp:Label><span class="red12"></span></td>
                                <td width="12%" class="bold">
                                    用户名:</td>
                                <td width="37%">
                                    &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator></span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    范围:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtagttype" runat="server" Width="100px"></asp:TextBox><span
                                        style="color: #ff0000"></span></td>
                                <td class="bold">
                                    <span class="forumRow">传真:</span></td>
                                <td>
                                    <asp:Label ID="lblfax" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    电话:</td>
                                <td>
                                    <asp:Label ID="lblTelphone" runat="server"></asp:Label><span style="color: #ff0000"></span></td>
                                <td class="bold">
                                    <span class="forumRow">手机:</span></td>
                                <td>
                                    <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    公司:</td>
                                <td>
                                    <asp:Label ID="lblCompany" runat="server"></asp:Label></td>
                                <td class="bold">
                                    <span class="forumRow">电子邮件:</span></td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    详细地址:</td>
                                <td style="height: 30px">
                                    <span style="color: #ff0000">
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label></span></td>
                                <td class="bold">
                                    <span class="forumRow">邮编:</span></td>
                                <td style="height: 30px">
                                    <asp:Label ID="lblPostCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    代理折扣:</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtPrice" runat="server" Width="46px" MaxLength="2" onkeypress="isnum()"></asp:TextBox>%<span
                                        style="color: #ff0000">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                            runat="server" ControlToValidate="txtPrice" ErrorMessage="代理折扣不能为空"></asp:RequiredFieldValidator></span></td>
                                <td class="bold">
                                    <span class="forumRow">所在省份:</span></td>
                                <td style="height: 28px">
                                    <span style="color: #ff0000">
                                        <asp:Label ID="lblProvince" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <%--                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    <span class="forumRow">状态:</span></td>
                                <td>
                                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Selected="True">许可</asp:ListItem>
                                        <asp:ListItem Value="1">禁用</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td class="bold">
                                    <span class="forumRow">是否前台显示:</span></td>
                                <td>
                                    <asp:RadioButtonList ID="rblshow" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>--%>
                            <%--        <tr bgcolor="#F1F1F1"><td class="bold" style="width: 120px">
                                    备注:</td>
                                <td colspan="3">
                                  &nbsp;<asp:TextBox ID="txtNote" runat="server" Rows="4" TextMode="MultiLine" Width="450px"></asp:TextBox>内部看不对外显示</td>
                            </tr>--%>
                            <tr bgcolor="#f1f1f1">
                                <td class="bold" style="width: 120px">
                                    状态:
                                </td>
                                <td>
                                    <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="right">
                                    <span class="bold">过期时间:&nbsp;</span></td>
                                <td>
                                    <span style="height: 28px">
                                        <asp:TextBox ID="txtExpireD" runat="server" onfocus="calendar();" Width="100px"></asp:TextBox>
                                        <span style="color: #ff0000">*</span><span style="color: #333;">（格式：2005-12-31）</span></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtExpireD"
                                        ErrorMessage="过期日期不能为空"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr bgcolor="#f1f1f1">
                                <td class="bold" style="width: 120px">
                                    其它联系方式:</td>
                                <td>
                                    <asp:TextBox ID="txtPostmore" runat="server" MaxLength="50" Width="280px"></asp:TextBox></td>
                                <td align="right">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    简介:</td>
                                <td colspan="3">
                                    <br />
                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="1020" Rows="8"
                                        TextMode="MultiLine" Width="550px"></asp:TextBox>（对外显示）<br />
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold" style="width: 120px">
                                    备注:</td>
                                <td colspan="3">
                                    <br />
                                    &nbsp;<asp:TextBox ID="txtAgtmore" runat="server" MaxLength="510" Rows="8"
                                        TextMode="MultiLine" Width="550px"></asp:TextBox>(内部使用，不对外显示)<br />
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td style="width: 120px">
                                    &nbsp;
                                </td>
                                <td colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                        ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    &nbsp;&nbsp; &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button"
                                        Text="取消" OnClientClick="history.back();return false;" />
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="btnUP" runat="server" CssClass="K2046_Button" Text="提升为正式代理" OnClick="btnUP_Click" />
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
