<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker.aspx.cs" Inherits="Pbzx.Web.Broker" %>

<%@ Register Src="Contorls/Broker.ascx" TagName="Broker" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>彩神通经纪人_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/broker.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
    </script>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <div class="bodyw MT">
            <!---左边--->
            <div class="br_l">
                <uc3:Broker ID="Broker1" runat="server"></uc3:Broker>
            </div>
            <!---右边--->
            <div class="br_r">
                <%--   <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><img src="images/web/br_banner.jpg" width="770" height="88" /></td>
    </tr>
  </table>--%>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0">
                    <tr>
                        <td bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td background="images/web/br_rbg.jpg" height="27" class="br_rZ">
                                        <asp:Label ID="lbltitle" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                <tr>
                                    <td align="left" class="br_z">
                                        <table width="98%" border="0" align="center" cellpadding="5" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="36" align="center" valign="top" id="shengqing" runat="server">
                                        <a href="Broker_Agrt.aspx">
                                            <asp:ImageButton ID="ibtnApply1" runat="server" ImageUrl="/images/web/br_sq.gif"
                                                Width="209" Height="32" border="0" AlternateText="申请成为『彩神通』经纪人" OnClick="ibtnApply1_Click" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
