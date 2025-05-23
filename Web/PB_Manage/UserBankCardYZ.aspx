<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserBankCardYZ.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.UserBankCardYZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head runat="server">
    <title>银行卡验证</title>
      <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <style type="text/css">
<!--
body {
	margin: 0px;
	padding: 0px;
	font:"宋体";
	font-size:12px;
	line-height:170%;
	color:#000000;
}
.user_btn{
	font-size: 12px;
	line-height: 170%;
	font-weight: 600;
	color: #FFFFFF;
	background-image: url(images/user_btn.gif);
	text-align: center;
	border-top-style: none;
	border-right-style: none;
	border-bottom-style: none;
	border-left-style: none;
	height: 21px;
	width: 72px;
}
.Right_bg1{
	font-family: "宋体";
	font-size: 12px;
	font-weight: 600;
	color: #FFFFFF;
	background-image: url(images/Us_r_bg1.jpg);
	background-repeat: repeat-x;
	height:26px;
}
-->
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                  <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                用户银行卡验证                                            </td>
                                          <td width="9%" align="right">&nbsp;</td>
                                        </tr>
                                    </table>                                </td>
                            </tr>
                        </table>
                        <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                          <tr>
                            <td height="9"></td>
                          </tr>
                        </table>
        <table width="95%" border="0" align="center" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="25%" height="28" align="right">
                                    用户账号：</td>
                                <td width="75%" align="left"><font color="#FF0000"><b>
                              <asp:Label ID="lblAccountNumber" runat="server" Text=""></asp:Label></b></font></td>
						  </tr>
									<Tr>
									<td height="28" align="right">
									充值金额：</td><td align="left">
									<b><asp:Label
                                        ID="lblAccountNumberCode" runat="server" Text=""></asp:Label>元</b></td>
									</Tr>
									<tr>
									<td height="35">									</td>
									<td valign="top">
								<a href='https://ibsbjstar.ccb.com.cn/V5/index.html' target='_blank'
                                        style='cursor: pointer'><img src="images/user_chong.gif" border="0" /></a>                                </td>
                            </tr>
                            <tr>
                                <td height="28" align="right">
                                    汇款单号：</td><td align="left"><asp:TextBox ID="txtDH" runat="server" Width="180px" MaxLength="30"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="28" align="center">&nbsp;</td>
                              <td align="left"><asp:Button ID="btnOK" runat="server" Text="充值成功" OnClick="btnOK_Click"  CssClass="user_btn"/>&nbsp;<asp:Button ID="btnFail" runat="server" Text="充值失败"  CssClass="user_btn" OnClick="btnFail_Click" />                              </td>
                            </tr>
                      </table>
                    <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr>
                        <td height="8"></td>
                      </tr>
                    </table></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
