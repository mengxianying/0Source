<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Register.aspx.cs" Inherits="Pbzx.Web.Register" %>

<%@ Register Src="Contorls/UcRegBase.ascx" TagName="UcRegBase" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新用户注册_拼搏在线彩神通软件</title>
    <meta name="keywords" content="网站用户注册" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/user.css" rel="stylesheet" type="text/css" />
    <link href="css/verify.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>
    <script type="text/javascript" src="/js/CrossBrowserHumanCheck.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                <tr>
                    <td style="height: 85px">
                        <img src="images/web/rg.jpg" width="990" height="82" />
                    </td>
                </tr>
            </table>
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#D0E3F9">
                <tr>
                    <td bgcolor="#F5F9FE">
                        <uc3:UcRegBase ID="UcRegBase1" runat="server" />
                    </td>
                </tr>
            </table>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
