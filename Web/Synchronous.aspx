<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Synchronous.aspx.cs" Inherits="Pbzx.Web.Synchronous"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>聊彩室同步_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/blue/css/css.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" src="/javascript/public.js" type="text/javascript"></script>
    <script language="javascript" src="/javascript/Prototype.js" type="text/javascript"></script>
        <script language="javascript" src="/javascript/jquery.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="TongBu" runat="server">
                <tr>
                    <td>
                        <table style="width: 100%; margin: 5px auto;" border="0" align="center" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td align="center" class="red">
                                    聊彩室同步敬告</td>
                            </tr>
                            <tr>
                                <td class="blue">
                                    &nbsp; 一、为什么要同步？<br />
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 由于网站升级，为了解决用户名和密码过多难以记忆的烦恼，本系统决定采用用户名密码统一管理，您只要注册一次，本系统所有平台，您都无需再注册，为了保持原聊彩室用户的级别和权限等资料，需要您登录后同步一次。<br />
                                    &nbsp;二、注意事项<br />
                                    &nbsp;1、同步后您必须使用论坛用户名和密码登录，原聊彩室用户名和密码作废，每个用户只能同步一次。一次后本功能消失。<br />
                                    &nbsp;2、如果您是原聊彩室用户，输入资料后点“同步”按钮，如果您是新用户，无需输入原聊彩室用户名和密码，请直接点击“新用户”按钮。<br />
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="blue">
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table style="width: 100%; height: 106px;" border="0" align="center" cellpadding="0"
                            cellspacing="0" class="kuang_line">
                            <tr>
                                <td valign="top">
                                    <form id="form2" name="form1" method="post" action="chat_user.asp">
                                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="blue">
                                            <tr>
                                                <td colspan="2" align="center">
                                                    聊彩室同步</td>
                                            </tr>
                                            <tr>
                                                <td width="47%">
                                                    论坛用户名：</td>
                                                <td width="53%">
                                                    <asp:TextBox ID="txtBbsName" runat="server" Width="140px" MaxLength="20"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    论坛的密码：</td>
                                                <td>
                                                    <asp:TextBox ID="txtBbsPWD" runat="server" TextMode="Password" Width="140px" MaxLength="20"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    原聊彩室用户名：</td>
                                                <td>
                                                    <asp:TextBox ID="txtLcsName" runat="server" Width="140px" MaxLength="20"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    原聊彩室密码：</td>
                                                <td>
                                                    <asp:TextBox ID="txtLcsPWD" runat="server" Width="140px" MaxLength="20" TextMode="Password"></asp:TextBox></td>
                                            </tr>
                                            <tr align="center">
                                                <td>
                                                    <asp:Button ID="btnTB" runat="server" Text="同  步" OnClick="btnTB_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnNew" runat="server" Text="新用户" OnClick="btnNew_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <input class="form" type="button" value=" 关 闭 " onclick="javascript:CloseDiv();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </form>
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

<script type="text/javascript">
{     
	parent.getValue(rvalue);
}

function CloseDiv()
{
    parent.document.getElementById("LabelDivid").style.display="none";
}


</script>

