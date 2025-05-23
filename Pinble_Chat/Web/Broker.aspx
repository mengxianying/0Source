<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker.aspx.cs" Inherits="Pbzx.Web.Broker" %>

<%@ Register Src="Contorls/Broker.ascx" TagName="Broker" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>『彩神通』经纪人 - 拼搏在线彩神通软件</title>
    <meta name="keywords" content="经纪人 软件代理 软件经销商 软件推广 软件销售 中国福利彩票 福利彩票 体育彩票 双色球 快乐8 3D彩票 3D试机号 七乐彩 乐透彩票 排列三 排列五 七星彩 超级大乐透 福彩 体彩 开奖 走势图 资讯 社区" />
    <meta name="description" content="拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩神通软件www.pinble.com" />
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
