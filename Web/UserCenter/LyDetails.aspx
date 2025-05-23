<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LyDetails.aspx.cs" Inherits="Pbzx.Web.UserCenter.LyDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言详细信息</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="600" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT2">
                <tr>
                    <td width="10">
                        <img src="../images/web/UC_weibg1.jpg" width="10" height="28" alt="" /></td>
                    <td width="584" background="../images/web/UC_weibg2.jpg">
                        <span class="uc_weib">留言详细信息</span></td>
                    <td width="6">
                        <img src="../images/web/UC_weibg3.jpg" width="6" height="28" /></td>
                </tr>
            </table>
            <table width="600" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD"
                class="uc_MT2">
                <tr>
                    <td width="150" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        留言标题：</td>
                    <td width="450" bgcolor="#FFFFFF">
                        <asp:Label ID="lblLy_Email" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td width="150" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        留言类型：</td>
                    <td width="450" bgcolor="#FFFFFF">
                        <asp:Label ID="lblLySort" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td width="150" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        留言内容：</td>
                    <td width="450" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtLyContent" runat="server" Rows="7" TextMode="MultiLine" Width="320px"
                            ReadOnly="True" MaxLength="500"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="200" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        回复内容：</td>
                    <td width="400" bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtResume" runat="server" Rows="7" TextMode="MultiLine" Width="320px"
                            ReadOnly="True" MaxLength="500"></asp:TextBox></td>
                </tr>
                <tr>
                    <td bgcolor="#F6F6F6">
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        <a href="javascript:window.close()">
                            <img src="../Images/Web/UC_btcolse.jpg" alt="" border="0" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
