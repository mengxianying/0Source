<%@ Page Language="C#" AutoEventWireup="true" Codebehind="userManage.aspx.cs" Inherits="Pbzx.Web.UserCenter.userManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人中心</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="20" class="uc_xia" height="25">
                        <img src="../images/web/Uc_li.gif" alt="" /></td>
                    <td width="780" class="uc_xia" valign="bottom">
                        <span class="uc_font_blue14">个人中心</span></td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="../images/web/UC_welcome.jpg" width="800" height="60" /></td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD"
                class="uc_MT10">
                <tr>
                    <td width="15%" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        用户类别：</td>
                    <td width="35%" bgcolor="#FFFFFF">
                        <%=UserClass %>
                        <asp:Label ID="lblTypeName" runat="server"></asp:Label></td>
                  <%--  <td width="20%" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        彩票超市商户：                       
                    </td>
                    <td width="30%" bgcolor="#FFFFFF">
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        注册时间：</td>
                    <td bgcolor="#FFFFFF">
                        <%=JoinDate%>
                    </td>
               <%--     <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        拼搏擂台等级：</td>
                    <td bgcolor="#FFFFFF">
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        上次登录时间：</td>
                    <td bgcolor="#FFFFFF">
                        <%=LastLogin%>
                    </td>
                  <%--  <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        拼搏擂台积分：</td>
                    <td bgcolor="#FFFFFF">
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        上次登录IP：</td>
                    <td bgcolor="#FFFFFF">
                        <%=UserLastIP%>
                    </td>
                 <%--   <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        大底比拼等级：
                    </td>
                    <td bgcolor="#FFFFFF">
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        拼搏吧积分：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lbScore" runat="server"></asp:Label></td>
                   <%-- <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        大底比拼积分：</td>
                    <td bgcolor="#FFFFFF">
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                        拼搏吧等级：</td>
                    <td bgcolor="#FFFFFF">
                        <asp:Label ID="lbtitle" runat="server"></asp:Label></td>
                   <%-- <td bgcolor="#F6F6F6">
                        &nbsp;</td>
                    <td bgcolor="#FFFFFF">
                        &nbsp;</td>--%>
                </tr>
                <tr id="trTS" runat="server">
                    <td align="left" bgcolor="#f6f6f6" class="uc_font_blue" colspan="2">
                        提示信息：</td>
                </tr>
                <tr id="trMMBH" runat="server" visible="false">
                    <td align="right" bgcolor="#f6f6f6" class="uc_font_blue">
                    </td>
                    <td bgcolor="#ffffff" class="uc_font_blue" >
                        您还没有设置密码保护，为了您的密码安全，<a href="PWD_Ask.aspx">请点击此处设置您的密码保护。</a></td>
                </tr>
                <tr id="trGJYH" runat="server" visible="false">
                    <td align="right" bgcolor="#f6f6f6" class="uc_font_blue">
                    </td>
                    <td bgcolor="#ffffff" class="uc_font_blue" >
                        您还不是高级用户，<a href="#" onclick="top.location='UserRealInfo.aspx';">点击此处升级为高级用户。</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
