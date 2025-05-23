<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebUser_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.WebUser_Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站用户查看</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
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
                                                当前位置：网站用户信息查看</td>
                                            <td width="9%" align="right">
                                             </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="left">
                                    <b>&nbsp;用户基本信息：</b>
                                    <br />
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td width="15%" class="bold">
                                    用户名:</td>
                                <td width="36%">
                                    <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                                <td width="15%" class="bold">
                                    申请时间:</td>
                                <td width="34%">
                                    <asp:Label ID="lblJoinDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    Email:</td>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                             <asp:Label ID="lblUserEmail" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                             <asp:TextBox ID="txt_Email" runat="server" ></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Email"
                                                            ErrorMessage="Email格式不正确；" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                            <asp:Button ID="btn_UpdateEmail" runat="server" Text="修改" 
                                                    onclick="btn_UpdateEmail_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="bold">
                                    用户类别:</td>
                                <td>
                                <table width="100%" border="0"> 
                                <tr>
                                    <td>
                                    <asp:Label ID="lblUserClass" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:DropDownList ID="ddl_Ntype" runat="server">
                                    </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_UpdateType" runat="server" Text="修改" 
                                            onclick="btn_UpdateType_Click" />
                                    </td>
                                </tr>
                                </table>
                                    
                                    
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    最后登录IP:</td>
                                <td>
                                    <asp:Label ID="lblUserLastIP" runat="server"></asp:Label></td>
                                <td class="bold">
                                    最后登录时间:</td>
                                <td>
                                    <asp:Label ID="lblLastLogin" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    登录密码：</td>
                                <td>
                                    <asp:TextBox ID="txtPWD" runat="server" Width="150px" TextMode="Password" MaxLength="16"></asp:TextBox>
                                    （如果留空则不会修改密码）
                                    <asp:Button ID="btnOK" runat="server"  OnClientClick="return confirm('您确定要给该用户修改登录密码吗？')"
                                        Text="修改" OnClick="btnOK_Click" /></td>
                                <td class="bold">
                                    是否被锁定:</td>
                                <td>
                                    
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            <asp:Label ID="lblLockUser" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                            <asp:RadioButtonList ID="rabBtn_yn" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList>
                                            </td>
                                            <td>
                                            <asp:Button ID="btn_Update" runat="server" Text="修改" onclick="btn_Update_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    
                                    </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                               <td class="bold">
                                   手机号码:</td>
                               <td>
                                    <asp:Label ID="lblUserMobile" Visible="false" runat="server"></asp:Label>
                                    <asp:TextBox ID="TextUserMobile" runat="server" Width="100px" MaxLength="11"></asp:TextBox>
                                    （如果留空则会清空手机号码）
                                    <asp:Button ID="btn_UpdateUserMobile" runat="server"  OnClientClick="return confirm('您确定要给该用户修改手机号码吗？')"
                                        Text="修改" OnClick="btn_UpdateUserMobile_Click" /></td>
                                <td class="bold">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7" id="really"
                            runat="server" visible="false">
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="left">
                                    <b>&nbsp;用户真实信息：</b>
                                    <br />
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td width="15%" class="bold">
                                    真实姓名:</td>
                                <td width="36%">
                                    <asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                <td width="15%" class="bold">
                                    性别:</td>
                                <td width="34%">
                                    <asp:Label ID="lblSex" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    身份证号:</td>
                                <td>
                                    <asp:Label ID="lblCardID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    出生年月:</td>
                                <td>
                                    <asp:Label ID="lblBirthday" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    联系电话:</td>
                                <td>
                                    <asp:Label ID="lblTelphone" runat="server"></asp:Label></td>
                                <td class="bold">
                                    E-mail:</td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    手机号码:</td>
                                <td>
                                    <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                <td class="bold">
                                    QQ号码:</td>
                                <td>
                                    <asp:Label ID="lblQQ" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    省份:</td>
                                <td>
                                    <asp:Label ID="lblProvince" runat="server"></asp:Label></td>
                                <td class="bold">
                                    MSN:</td>
                                <td>
                                    <asp:Label ID="lblMSN" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    城市:</td>
                                <td>
                                    <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                <td class="bold">
                                    邮编:</td>
                                <td>
                                    <asp:Label ID="lblPostCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    详细地址:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td align="left" colspan="4">                                   
                                   <b>
                                   银行账号信息：
                                       <br />
                                   </b>
                                   </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    银行卡号:</td>
                                <td>
                                    <asp:Label ID="lblAccountNumber" runat="server"></asp:Label></td>
                                <td class="bold">
                                    发卡银行:</td>
                                <td>
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    开户行:</td>
                                <td>
                                    <asp:Label ID="lblBankInfo" runat="server"></asp:Label></td>
                                <td class="bold">
                                    账户余额:</td>
                                <td>
                                    <asp:Label ID="lblCurrentMoney" runat="server"></asp:Label>元</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 24px">
                                    冻结金额:</td>
                                <td style="height: 24px">
                                    <asp:Label ID="lblFrozenMoney" runat="server"></asp:Label>元</td>
                                <td class="bold" style="height: 24px">
                                    可用金额:</td>
                                <td style="height: 24px">
                                    <asp:Label ID="lblKY" runat="server"></asp:Label>元</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 24px">
                                    银行账号状态：</td>
                                <td style="height: 24px">
                                    <asp:Label ID="lblAccountNumberState" runat="server"></asp:Label></td>
                                <td class="bold" style="height: 24px">
                                </td>
                                <td style="height: 24px">
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    </td>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td align="center">                                    
                                    <input  type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" />
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
