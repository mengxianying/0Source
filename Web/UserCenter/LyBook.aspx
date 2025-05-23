<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LyBook.aspx.cs" Inherits="Pbzx.Web.UserCenter.LyBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head runat="server">
    <title>拼搏在线 - 用户留言</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <%-- target=bbc2188 --%>
        <div>
            <table width="600" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="10">
                        <img src="../images/web/UC_weibg1.jpg" width="10" height="28" alt="" />
                    </td>
                    <td width="789" background="../images/web/UC_weibg2.jpg">
                        <span class="uc_weib">用户留言</span>
                    </td>
                    <td width="6">
                        <img src="../images/web/UC_weibg3.jpg" width="6" height="28" />
                    </td>
                </tr>
            </table>
            <table width="600" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD"
                class="uc_MT10">
                <tr>
                    <td width="100" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        问题类型：
                    </td>
                    <td width="500" bgcolor="#FFFFFF">
                        <asp:DropDownList ID="ddlSort" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        标 题：
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        留言内容：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:TextBox ID="txtcontent" runat="server" Rows="6" TextMode="MultiLine" Width="420px"
                            MaxLength="800" Height="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td bgcolor="#F6F6F6">
                    </td>
                    <td bgcolor="#FFFFFF">
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="bton" runat="server" ImageUrl="~/Images/Web/UC_bton.jpg" OnClick="bton_Click" />&nbsp;
                        <asp:ImageButton ID="btreset" runat="server" ImageUrl="~/Images/Web/UC_btreset.jpg"
                            OnClick="btreset_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
