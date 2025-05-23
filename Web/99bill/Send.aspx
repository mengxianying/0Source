<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Send.aspx.cs" Inherits="Pbzx.Web._99bill.Send" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>订单提交成功页 - 拼搏在线彩神通软件 - 云网支付 </title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Submit1_onclick() {

}

// ]]>
    </script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
            <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%">
                                <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" /></td>
                            <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                                请认真审核您的信息</td>
                            <td width="1%">
                                <img src="/Images/Web/order_bg1c.jpg" width="10" height="44" border="0" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="10" background="/Images/Web/order_bg2a.jpg">
                    &nbsp;
                </td>
                <td width="970" align="center" bgcolor="#FFFFFF">
                    <br />
                    <table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="6%">
                                <img src="/Images/Web/order_xuanze.gif" /></td>
                            <td width="94%" class="order_XZbigtitle">
                                请选择快钱支付方式</td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td height="1" bgcolor="#9999FF">
                            </td>
                        </tr>
                    </table>
                    <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                        <tr>
                            <td width="50%" class="order_XZrightborder">
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <td width="12%" align="right">
                                            <img src="/Images/Web/order_xuanzeli1.gif" /></td>
                                        <td width="88%" align="left" valign="bottom" class="order_14black">
                                            人民币支付：</td>
                                    </tr>
                                    
                                    <tr>
                                        <td height="105" colspan="2" align="center">
                                        <asp:ImageButton ID="ibtnRMB" runat="server" ImageUrl="/Images/Web/order_xuanzebt1.gif" OnClick="ibtnRMB_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="50%">
                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                    <tr>
                                        <td width="11%" align="right">
                                            <img src="/Images/Web/order_xuanzeli2.gif" /></td>
                                        <td width="89%" align="left" valign="bottom" class="order_14black">
                                            神州行支付：</td>
                                    </tr>
                                    <tr>
                                        <td height="105" colspan="2" align="center">
                                             <asp:ImageButton ID="ibtnSZX" runat="server" ImageUrl="/Images/Web/order_xuanzebt2.gif" OnClick="ibtnSZX_Click" />
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10" background="/Images/Web/order_bg2c.jpg">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" /></td>
                <td background="/Images/Web/order_bg3b.jpg">
                </td>
                <td>
                    <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" /></td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
