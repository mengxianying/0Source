<%@ Page Language="C#" AutoEventWireup="true" Codebehind="EmailYZ.aspx.cs" Inherits="Pbzx.Web.UserCenter.EmailYZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email验证_拼搏在线彩神通软件</title>
     <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFCB99" align="center"
                class="uc_MT10">
                <tr>
                    <td height="24" bgcolor="#FFF8EE" class="uc_font_black">
                        <span class="uc_font_orange">&nbsp;我的资料：</span><a href="ChangePWD.aspx"><b>修改登录密码</b></a>&nbsp;|&nbsp;<a
                            href="PWD_Ask.aspx">修改密码问题</a>&nbsp;|&nbsp;<a href="User_Info.aspx">修改详细信息</a>&nbsp;|&nbsp;<a
                                href="ChangePWD_buy.aspx">修改交易密码</a>&nbsp;|&nbsp;<a href="Bank_Info.aspx">修改银行信息</a></td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="5" bgcolor="#FF7300">
                    </td>
                    <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                        &nbsp;Email验证</td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#DDDDDD" align="center">
                <tr>
                    <td width="150" align="right" valign="top" bgcolor="#F6F6F6">
                         请输入Email验证码：</td>
                    <td width="655"  align="left" bgcolor="#FFFFFF"> <asp:TextBox ID="txtYZM" runat="server" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtYZM"
                            ErrorMessage="Email验证码不能为空"></asp:RequiredFieldValidator> <br />
                            <span class="uc_font_gray">（注：拼搏在线彩神通软件已将验证码发送到您得真实Email，您只需在主题为"拼搏在线邮件验证"的邮件中读取到验证码输入到文本框，Email验证就成功完成。验证码有效期为14天。）</span> </td>
                </tr>
                <tr bgcolor="#FFFFFF"><td></td><td  bgcolor="#FFFFFF"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="22%" align="center"><asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="提交"  CssClass="page_Save" /></td>
                      <td width="78%" >&nbsp;</td>
                    </tr>
                  </table></td></tr>
                </table>
      
        
        
        </div>
    </form>
</body>
</html>
