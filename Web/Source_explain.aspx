<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Source_explain.aspx.cs"
    Inherits="Pbzx.Web.Source_explain" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc6" %>
<%@ Register Src="Contorls/UcSource.ascx" TagName="UcSource" TagPrefix="uc5" %>
<%@ Register Src="Contorls/SourceTitle.ascx" TagName="SourceTitle" TagPrefix="uc4" %>
<%@ Register Src="Contorls/SourceClass.ascx" TagName="SourceClass" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资源详细信息_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="资源详细信息" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/res.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Head ID="Head2" runat="server"></uc1:Head>
    <!--主体部分--->
    <div class="bodyw div_wei">
        <table width="100%" border="0" cellspacing="0" cellpadding="2">
            <tr>
                <td width="50%" align="left">
                    当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'>拼博在线彩神通软件</a> >> <a
                        href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Source.aspx'>资源下载</a>
                </td>
                <td width="50%" align="right">
                    <uc5:UcSource ID="UcSource1" runat="server"></uc5:UcSource>
                </td>
            </tr>
        </table>
    </div>
    <div id="soft" class="bodyw">
        <!--左边--->
        <div class="R_lw1">
            <div class="R_r1 R_box">
                <div class="title">
                    <p>
                        <span>资源下载中心</span></p>
                </div>
                <div class="content">
                    <div>
                        <table width="93%" border="0" cellpadding="0" cellspacing="0" align="center">
                            <tr>
                                <td height="40" colspan="2" align="center">
                                    <h2>
                                        <%=SoftName %>
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td width="27%" align="center">
                                    <img src="<%=PicUrl%>" width="172" height="120" hspace="0" vspace="0" alt="" />
                                </td>
                                <td width="73%" align="right" valign="middle">
                                    <table width="500" border="0" cellpadding="4" cellspacing="0">
                                        <tr>
                                            <td colspan="4" align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="80" align="right">
                                                <strong>文件大小：</strong>
                                            </td>
                                            <td width="150" align="left">
                                                <%=SoftSize%>
                                                KB
                                            </td>
                                            <td width="75" align="right">
                                                <strong>发布日期：</strong>
                                            </td>
                                            <td width="195" align="left">
                                                <%=UpdateTime%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>资源类别：</strong>
                                            </td>
                                            <td align="left">
                                                <%=ClassID%>
                                            </td>
                                            <td align="right">
                                                <strong>资源类型：</strong>
                                            </td>
                                            <td align="left">
                                                <%=SoftVersion%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>使用环境：</strong>
                                            </td>
                                            <td align="left" colspan="3">
                                                <%=YXSystem %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>备注说明：</strong>
                                            </td>
                                            <td colspan="2" align="left">
                                                <%=RegUrl%>
                                            </td>
                                            <td align="center">
                                                <%=SinaWiki %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <!--
                                                <td align="right">
                                                     <strong>下&nbsp;载&nbsp;数：&nbsp;</strong></td>
                                                <td colspan="2" align="left">
                                                    <%=pb_Hits%></td>
                                                <td align="center">
                                                    &nbsp;</td>
-->
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="10%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td height="12">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--录像视频-->
                <div id="framid" class="content MT" visible="false" runat="server">
                </div>
                <div class="content MT" id="xia2">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="78%" height="26" background="Images/Web/R_lbg2.jpg" class="R_r2_title">
                                详细说明
                            </td>
                            <td width="22%" background="Images/Web/R_lbg2.jpg">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" align="center" cellpadding="12" cellspacing="0" bgcolor="#FFFFFF">
                        <tr>
                            <td align="left">
                                <%=SoftIntro%>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--下载列表-->
                <div class="content MT" id="xiazai1" runat="server">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="78%" height="26" background="Images/Web/R_lbg2.jpg" class="R_r2_title">
                                下载地址列表
                            </td>
                            <td width="22%" background="Images/Web/R_lbg2.jpg">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                        <tr>
                            <td bgcolor="#f8f8f8">
                                <table width="96%" border="0" align="center" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td width="12%" align="left" height="28" valign="bottom" id="tdDown1" runat="server">
                                            <a href='<%=wtDown %>'>
                                                <img src="images/Web/down.gif" border="0" width="12" height="12" hspace="5" align="bottom" />
                                                <asp:Label ID="lblDown1" runat="server" Text=""></asp:Label></a>
                                        </td>
                                        <td width="12%" align="left" valign="bottom" id="tdDown2" runat="server">
                                            <a href='<%= dxDown %>'>
                                                <img src="images/Web/down.gif" border="0" width="12" height="12" hspace="5" align="bottom" />
                                                <asp:Label ID="lblDown2" runat="server" Text=""></asp:Label></a>
                                        </td>
                                        <td width="12%" align="left" valign="bottom" id="tdDown3" runat="server">
                                            <a href='<%=Down3a %>'>
                                                <img src="images/Web/down.gif" border="0" width="12" height="12" hspace="5" align="bottom" />
                                                <asp:Label ID="lblDown3" runat="server" Text=""></asp:Label></a>
                                        </td>
                                        <td width="12%" align="left" valign="bottom" id="tdDown4" runat="server">
                                            <a href='<%=Down4a %>'>
                                                <img src="images/Web/down.gif" border="0" width="12" height="12" hspace="5" align="bottom" />
                                                <asp:Label ID="lblDown4" runat="server" Text=""></asp:Label></a>
                                        </td>
                                        <td height="28" valign="bottom" align="left">
                                            <span style="color: rgb(255, 0, 0);"><%=DowloadTips%></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!--右边--->
        <div class="R_rw1">
            <div class="R_box R_l1">
                <div class="title">
                    <p>
                        <span>资源分类</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc3:SourceClass ID="SourceClass1" runat="server" />
                    </div>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>最新资源</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SourceTitle ID="SourceTitle1" runat="server" Count="8" TilteLength="16"></uc4:SourceTitle>
                    </div>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>在线客服</span></p>
                </div>
                <div class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-top: 5px;
                        padding-left: 3px; padding-bottom: 3px;">
                        <tr>
                            <td align="center">
                                <uc6:UC_QQ ID="UC_QQ1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="R_box R_l2 MT">
                <div class="title">
                    <p>
                        <span>热点资源</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SourceTitle ID="SourceTitle2" runat="server" Count="8" Hits="2" TilteLength="16">
                        </uc4:SourceTitle>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc2:Footer ID="Footer1" runat="server"></uc2:Footer>
    </form>
    <script type="text/javascript">
      window.onload =  function setTextColorBasedOnTime() {
            var now = new Date();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var textElement = document.getElementById('timeColorText');
 
            if (hours = 16 && minutes >= 45 || hours = 17 && minutes <= 15 || hours = 21 && minutes >= 10 && minutes <= 40) {
                // 下午16:45 - 17:15和21:10 - 21:40，使用红色
                textElement.style.color = 'red';
            } else {
                // 其它时间，使用深蓝色
                textElement.style.color = 'darkblue';
            }
        }
 
        // 页面加载时调用函数设置文字颜色
//        setTextColorBasedOnTime();
        
        // 每隔一小时更新一次颜色（可选）
//        setInterval(setTextColorBasedOnTime, 3600000);
    </script>

</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
