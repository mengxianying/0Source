<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Email_Success.aspx.cs"
    Inherits="Pbzx.Web.Template.Email_Success"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Pbzx.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单成功页</title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="610" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="330">
                    <img src="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>images/web/EmailLogo.gif" width="215" height="50" /></td>
                <td width="280" valign="bottom">
                    <div style="background-color: #FB7D00; width: 100%; padding-top: 7px; font-size: 12px;
                        color: #FFFFFF; text-align: center;">
                        <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>" target="_blank" style="color: #FFFFFF; text-decoration: none;">
                            拼搏首页</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Soft.aspx" target="_blank" style="color: #FFFFFF;
                                text-decoration: none;">软件商城</a> | <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>SoftwarePrices.htm"
                                    target="_blank" style="color: #FFFFFF; text-decoration: none;">注册购买</a>
                        | <a href="http://bbs.pinble.com/" target="_blank" style="color: #FFFFFF; text-decoration: none;">
                            拼搏论坛</a></div>
                </td>
            </tr>
        </table>
        <table width="610" border="0" align="center" cellpadding="0" cellspacing="7" bgcolor="#FB7D00"
            style="height: 25px; font-size: 12px; color: #000000; line-height: 180%; text-align: left;">
            <tr>
                <td align="center" valign="top" bgcolor="#FFFFFF">
                    <div style="background-color: #FFECD9; text-align: left; line-height: 28px;">
                        &nbsp;[小提醒]<font color="#666666"> 如有其它疑问，请到<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>" target="_blank">Http://www.pinble.com/</a>查询，或电话010-62132803咨询! </font>
                    </div>
                    <div style="width: 95%; text-align: left; border-bottom: dashed #999999; border-bottom-width: 1px;
                        padding: 7px;">
                        <strong>亲爱的<asp:Label ID="lblUname" runat="server" Text="Label"></asp:Label>，您好！</strong><br />
                        <asp:Label ID="lblContent" runat="server"></asp:Label></div>
                        
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
