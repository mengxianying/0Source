<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Delegate_change.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.Delegate_change" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改代理信息</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="/Images/web/Uc_li.gif" alt="" /></td>
                    <td width="670" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">修改代理基本信息</span></td>
                    <td width="110" valign="bottom">
                    </td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="4" align="center" cellspacing="1" bgcolor="#DDDDDD">
                <tr>
                    <td width="24%" align="right" bgcolor="#F6F6F6">
                        真实姓名：</td>
                    <td width="22%" align="left" bgcolor="#FFFFFF">
                        <%--<asp:TextBox ID="txtRealName" runat="server" Width="180px" MaxLength="20"></asp:TextBox>--%>
                        <asp:Label ID="lblRealName" runat="server"></asp:Label>
                        <span style="color: #ff0000">
                            </span></td>
                    <td width="54%" align="left" class="user_gray" bgcolor="#FFFFFF">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        联系电话：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtTel" runat="server" Width="180px" MaxLength="15"></asp:TextBox><%--<span style="color: #ff0000">*<br /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTel" ErrorMessage="请填写联系电话"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="联系电话格式不正确" ValidationExpression="^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$" Display="Dynamic"></asp:RegularExpressionValidator></span>--%></td>
                    <td align="left" class="user_gray" bgcolor="#FFFFFF">
                        电话号码中应包括区号，如：010-62132803</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        手机号码：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtMobile" runat="server" Width="180px" MaxLength="13"></asp:TextBox></td>
                    <td align="left" class="user_gray" bgcolor="#FFFFFF">
                        方便客户与您直接联系。</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        传真号码：</td>
                    <td align="left" colspan="2" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtFax" runat="server" Width="180px" MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        E-mail：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox><span style="color: #ff0000">*</span>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="请填写Email" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Email格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </span>
                    </td>
                    <td align="left" class="user_gray" bgcolor="#FFFFFF">
                        请输入常用的邮箱！</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        省份：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblProvince" runat="server" Text=""></asp:Label></td>
                    <td align="left" class="user_gray" bgcolor="#FFFFFF">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        邮编：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtPostCode" runat="server" Width="180px" MaxLength="10"></asp:TextBox><span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostCode"
                            ErrorMessage="请填写邮编" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostCode"
                            ErrorMessage="邮编格式不正确" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator></td>
                    <td align="left" class="user_gray" bgcolor="#FFFFFF">
                        </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        公司名称：</td>
                    <td colspan="2" align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtCompany" runat="server" Width="180px"></asp:TextBox><span class="user_gray"></span></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        详细地址：</td>
                    <td align="left" bgcolor="#FFFFFF" colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" Width="250px"></asp:TextBox>
                        <span style="color: #ff0000">*<asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server" ControlToValidate="txtAddress" ErrorMessage="请填写详细地址" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#f6f6f6">
                        代理折扣：</td>
                    <td align="left" bgcolor="#ffffff" colspan="2">
                        <asp:Label ID="lblPricePercent" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#f6f6f6">
                        到期日期：</td>
                    <td align="left" bgcolor="#ffffff" colspan="2">
                        <asp:Label ID="lblExpireDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        代理简介：</td>
                    <td colspan="2" bgcolor="#ffffff">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server" Rows="6" TextMode="MultiLine" Width="320px"></asp:TextBox></td>
                                <td>
                                    <span class="user_gray">为了让更多的彩民，请您详细填写自己熟悉的彩种技巧；</span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        &nbsp;</td>
                    <td colspan="2" bgcolor="#ffffff">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="保存修改" CssClass="page_Save" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
                        <input type="button" name="button" id="button" value="取消修改" onclick="location='userManage.aspx';"
                            class="page_Save" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
