<%@ Page Language="C#" AutoEventWireup="true" Codebehind="User_Info.aspx.cs" Inherits="Pbzx.Web.UserCenter.User_Info"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户详细信息</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../javascript/SearchAjax.js"> </script>

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script src="/javascript/calendar.js" type="text/javascript"></script>

    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFCB99" align="center"
                class="uc_MT10">
                <tr>
                    <td height="24" bgcolor="#FFF8EE" class="uc_font_black">
                        <span class="uc_font_orange">&nbsp;我的资料：</span><a href="ChangePWD.aspx"><b>修改登录密码</b></a>&nbsp;|&nbsp;<a
                            href="PWD_Ask.aspx">登录密保修改</a>&nbsp;|&nbsp;<a href="User_Info.aspx">修改详细信息</a>&nbsp;|&nbsp;<a href="Bank_Info.aspx">修改银行信息</a>&nbsp;|&nbsp;<a
                                href="ChangePWD_buy.aspx">修改交易密码</a>&nbsp;|&nbsp;<a
                                href="PWD_BuyAsk.aspx">交易密保修改</a></td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="5" bgcolor="#FF7300">
                    </td>
                    <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                        &nbsp;修改详细信息</td>
                </tr>
            </table>
            <table width="800" border="0" cellspacing="1" bgcolor="#DDDDDD" align="center" cellpadding="3">
                <tr>
                    <td width="169" align="right" bgcolor="#F6F6F6">
                        真实姓名：</td>
                    <td width="217" align="left" bgcolor="#FFFFFF" >
                        <span style="color: #ff0000">
                  <asp:Label ID="lblRealName" runat="server"></asp:Label></span></td>
                    <td width="392" align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                        您的真实姓名，不可更改!                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        出生日期：</td>
                    <td align="left" bgcolor="#FFFFFF" >
                        <asp:Label ID="lblBirthday" runat="server"></asp:Label></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                        出生日期不可修改!</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        性别：</td>
                    <td align="left" bgcolor="#FFFFFF" >
                        <asp:RadioButtonList ID="rdlSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                            <asp:ListItem Value="1">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" >
                        身份证号码：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:Label ID="lblCardID" runat="server"></asp:Label></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                        身份证号码，不能更改!</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        联系电话：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtTel" runat="server" MaxLength="15"></asp:TextBox></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                        电话号码中应包括区号，如：010-62132803</td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        手机号码：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="13"></asp:TextBox><span style="color: #ff0000"></span></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                        方便我们与您直接联系。</td>
                </tr>
                <%--   <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        E-mail：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTel" ErrorMessage="请填写Email"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Email格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                        非常重要，当您要找回密码时候使用！</td>
                </tr>--%>
                <tr>
                    <td align="right" bgcolor="#f6f6f6">
                        真实Email：</td>
                    <td align="left" bgcolor="#ffffff">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox><span style="color: #ff0000">*</span><br />
                        &nbsp;<asp:Label ID="lblEmailState" runat="server" BackColor="LightSteelBlue"></asp:Label></td>
                    <td align="left" bgcolor="#ffffff" class="uc_font_gray">
                        <asp:Button ID="btnEmailYZ" runat="server" Text="验证"  class="page_validate2" OnClick="btnEmailYZ_Click" />
                        <asp:Label ID="lblEmailYZ" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        QQ号码：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtQQ" runat="server" MaxLength="15"></asp:TextBox></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">&nbsp;
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        MSN：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtMSN" runat="server" MaxLength="30"></asp:TextBox></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">&nbsp;
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        邮编：</td>
                    <td align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtPostCode" runat="server" MaxLength="6"></asp:TextBox>
                        <span style="color: #ff0000">*<br /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostCode" ErrorMessage="请填写邮编"
                            Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostCode"
                                ErrorMessage="邮编格式不正确" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                    <td align="left" bgcolor="#FFFFFF" class="uc_font_gray">
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        省市：</td>
                    <td align="left" bgcolor="#FFFFFF" colspan="2">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="10%" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <span style="width: 350px; text-align: left;">
                                                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlCity" runat="server">
                                                </asp:DropDownList>
                                                <span style="color: #ff0000">*</span> </span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                      </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6">
                        详细地址：</td>
                    <td colspan="2" align="left" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtAddress" runat="server" Width="280" MaxLength="50"></asp:TextBox>
                        <span style="color: #ff0000">*<br /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ErrorMessage="请填写详细地址"
                            Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                </tr>              
                <tr>
                    <td colspan="3" align="center" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
  <tr>
    <td width="22%">&nbsp;</td>
    <td width="23%"><asp:Button ID="btsave" runat="server" Text="保存" OnClick="btsave_Click"  CssClass="page_SaveS"/>&nbsp;&nbsp;
                    <input type="button" name="button" id="button" value="取消"  onclick="location='userManage.aspx';" Class="page_SaveS"/>
   </td>
    <td width="55%">&nbsp;</td>
  </tr>
</table></td>
                </tr>
            </table>
        </div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
