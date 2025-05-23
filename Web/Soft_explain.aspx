<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soft_explain.aspx.cs" Inherits="Pbzx.Web.Soft_explain"
    EnableViewState="false" %>

<%@ Register Src="Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc8" %>
<%@ Register Src="Contorls/Uc_shopping.ascx" TagName="Uc_shopping" TagPrefix="uc7" %>
<%@ Register Src="Contorls/UcSoft.ascx" TagName="UcSoft" TagPrefix="uc6" %>
<%@ Register Src="Contorls/soft_verf.ascx" TagName="soft_verf" TagPrefix="uc5" %>
<%@ Register Src="Contorls/SoftTitle.ascx" TagName="SoftTitle" TagPrefix="uc4" %>
<%@ Register Src="Contorls/SoftClass.ascx" TagName="SoftClass" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>软件详细信息_拼搏在线彩神通软件</title>
    <meta name="keywords" content="体彩,福彩,福利彩票,体育彩票,彩票软件" />
    <meta name="description" content="软件详细信息" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/softpage.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Head ID="Head1" runat="server" />
    <!--主体部分--->
    <div class="bodyw div_wei">
        <table width="100%" border="0" cellspacing="0" cellpadding="2">
            <tr>
                <td width="29%" align="left">
                    当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'>拼博在线彩神通软件</a> >> <a
                        href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Soft.aspx' style="cursor: pointer;">
                        软件商城</a>
                </td>
                <td width="45%" align="center">
                    <uc7:Uc_shopping ID="Uc_shopping1" runat="server" />
                </td>
                <td width="26%" align="right">
                    <uc6:UcSoft ID="UcSoft1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="soft" class="bodyw">
        <!--左边--->
        <div class="S_lw1">
            <div id="N1" class="S_box S_l1" runat="server">
                <div>
                    <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0" background="images/web/S_lbg1.jpg">
                        <tr>
                            <td valign="bottom">
                                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="80" valign="bottom" class="title">
                                            <a href="Soft.aspx"><font color="#419713">软件类别</font></a>
                                        </td>
                                        <td width="62" valign="bottom" class="title2">
                                            <a href="Soft.aspx?vef=vef"><font color="#ffffff">版本类型</font></a>
                                        </td>
                                        <td width="72">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="content">
                    <div>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td>
                                    <uc3:SoftClass ID="SoftClass1" runat="server" TitleLength="9" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div id="N2" class="S_box S_l1" runat="server">
                <div>
                    <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0" background="images/web/S_lbg1.jpg">
                        <tr>
                            <td valign="bottom">
                                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="62" valign="bottom" class="title2">
                                            <a href="Soft.aspx"><font color="#ffffff">软件类别</font></a>
                                        </td>
                                        <td width="80" valign="bottom" class="title">
                                            <a href="Soft.aspx?vef=vef"><font color="#419713">版本类型</font></a>
                                        </td>
                                        <td width="72">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="content">
                    <div>
                        <table cellpadding="0" cellspacing="0" border="0" width="92%" align="center">
                            <tr>
                                <td>
                                    <uc5:soft_verf ID="Soft_verf1" runat="server" TitleLength="20"></uc5:soft_verf>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="S_box S_l2 MT">
                <div class="title">
                    <p>
                        <span>最新软件</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SoftTitle ID="SoftTitle2" runat="server" Count="8" TilteLength="12" />
                    </div>
                </div>
            </div>
            <div class="MT">
                <img src="Images/Web/buy.jpg" border="0" usemap="#Map" />
                <map name="Map" id="Map">
                    <area shape="rect" coords="43,39,100,58" href="Register.aspx" target="_blank" />
                    <area shape="rect" coords="161,41,220,58" href="/Soft.aspx" />
                    <area shape="rect" coords="41,86,100,104" href="/Contact.htm" target="_blank" />
                    <area shape="rect" coords="161,86,219,103" href="/Payment.htm" target="_blank" />
                </map>
            </div>
            <div class="S_box S_l2 MT">
                <div class="title">
                    <p>
                        <span>下载排行</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc4:SoftTitle ID="SoftTitle1" runat="server" Count="8" Hits="2" TilteLength="12" />
                    </div>
                </div>
            </div>
            <div class="S_box S_l2 MT">
                <div class="title">
                    <p>
                        <span>在线客服</span></p>
                </div>
                <div class="content">
                    <div>
                        <uc8:UC_QQ ID="UC_QQ1" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <!--右边--->
        <div class="S_rw1">
            <div class="S_r2">
                <div class="title">
                    <p>
                        <span>
                            <%=SoftName%>
                        </span>
                    </p>
                </div>
                <div class="content">
                    <div>
                        <table width="95%" border="0" cellpadding="0" cellspacing="0" align="center">
                            <tr>
                                <td width="71%" valign="middle">
                                    <table width="98%" border="0" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="15%" align="right">
                                                <strong>软件类别：</strong>
                                            </td>
                                            <td width="46%" align="left">
                                                <%=ClassID%>
                                            </td>
                                            <td width="16%" align="right">
                                                <strong>授权形式：</strong>
                                            </td>
                                            <td width="23%" align="left">
                                                <%=Copyright %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>文件大小：</strong>
                                            </td>
                                            <td align="left">
                                                <%=SoftSize%>
                                                KB
                                            </td>
                                            <td align="right">
                                                <strong>版&nbsp;本&nbsp;号：</strong>
                                            </td>
                                            <td align="left">
                                                <%=SoftVersion%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>使用环境：</strong>
                                            </td>
                                            <td align="left">
                                                <%=Operating%>
                                            </td>
                                            <%--  <td align="right">
                                                    <strong>信用等级：</strong></td>
                                                <td align="left">
                                                    <img border="0" src="/images/Web/star<%=Stars%>.gif" alt="星" /></td>--%>
                                            <td align="right">
                                                <strong>更新日期：</strong>
                                            </td>
                                            <td align="left">
                                                <%=UpdateTime%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <strong>单&nbsp;机&nbsp;版：</strong>
                                            </td>
                                            <td align="left">
                                                <%if (!pb_freeshow)
                                                  { %>
                                                <%=DemoUrl%>
                                                <%=RegUrl%>
                                                <%} %>
                                                <asp:Label ID="lblSoftDog" runat="server"></asp:Label>
                                            </td>
                                            <!--                                        <td align="right">
                                                <strong>下&nbsp;载&nbsp;数：</strong></td>
                                            <td align="left">
                                                <%= pb_Hits%>
                                                </td>
    -->
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>网&nbsp;络&nbsp;版：</strong>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblWLPrice" runat="server"></asp:Label>
                                                &nbsp;<%=TypeName %>
                                            </td>
                                            <!--
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                </td>
     -->
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>备注说明：</strong>
                                            </td>
                                            <td colspan="3" align="left">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="left">
                                                            <%=Author%>
                                                        </td>
                                                        <td align="right" style="width: 105px;">
                                                            <%=SinaWiki %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="29%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                        <tr>
                                            <td>
                                                <img src="<%=PicUrl%>" width="175" height="125" hspace="0" vspace="0" alt="" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="buyimg">
                                            <td align="center">
                                                <%
                                                    if (pb_freeshow) { }
                                                    else
                                                    {
                                                %>
                                                <a href='addtoshoppingcart.aspx?productID=<%=SoftID %>' style="cursor: pointer">
                                                    <img alt="购买" src="/Images/Web/mybuy2.gif" border="0" /></a>
                                                <%} %>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="xiazai2" class="content MT" style="background-color: #F8F8F8;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="70%" height="28" background="Images/Web/S_rbg3.jpg" class="S_r3_title">
                                简要说明
                            </td>
                            <td width="30%" background="Images/Web/S_rbg3.jpg">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" align="center" cellpadding="12" cellspacing="0">
                        <tr>
                            <td align="left">
                                <%=SoftIntro%>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--录像视频-->
                <div id="framid" class="content MT" visible="false" runat="server">
                </div>
                <div id="xiazai3" class="content MT" style="background-color: #F8F8F8;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="70%" height="28" background="Images/Web/S_rbg3.jpg" class="S_r3_title">
                                详细说明
                            </td>
                            <td width="30%" background="Images/Web/S_rbg3.jpg">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="97%" border="0" align="center" cellpadding="12" cellspacing="0">
                        <tr>
                            <td align="left">
                                <%=softContent%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="xiazai1" class="content MT" runat="server">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="70%" height="28" background="Images/Web/S_rbg3.jpg" class="S_r3_title">
                                下载地址列表
                            </td>
                            <td width="30%" background="Images/Web/S_rbg3.jpg">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="4" cellspacing="0" bgcolor="#F8F8F8">
                        <tr>
                            <td>
                                <table width="96%" border="0" align="center" cellpadding="3" cellspacing="0" id="tbDownLoad">
                                    <tr align="left">
                                        <td width="12%" height="28" id="tdDown1" runat="server" valign="bottom">
                                            <a href='<%=wtDown%>'>
                                                <img alt='' src="/images/Web/down.gif" width="14" height="14" hspace="5" align="bottom"
                                                    border="0" /><asp:Label ID="lblDown1" runat="server" Text=""></asp:Label>
                                            </a>
                                        </td>
                                        <td width="12%" id="tdDown2" runat="server" valign="bottom">
                                            <a href='<%=dxDown %>'>
                                                <img alt='' src="/images/Web/down.gif" width="14" height="14" hspace="5" border="0"
                                                    align="bottom" /><asp:Label ID="lblDown2" runat="server" Text=""></asp:Label>
                                            </a>
                                        </td>
                                        <td width="12%" valign="bottom" id="tdDown3" runat="server">
                                            <a href='<%=Down3a %>'>
                                                <img alt='' src="/images/Web/down.gif" width="14" height="14" hspace="5" align="bottom"
                                                    border="0" />
                                                <asp:Label ID="lblDown3" runat="server"></asp:Label>
                                            </a>
                                        </td>
                                        <td width="12%" valign="bottom" id="tdDown4" runat="server">
                                            <a href='<%=Down4a %>'>
                                                <img alt='' src="/images/Web/down.gif" width="14" height="14" hspace="5" align="bottom"
                                                    border="0" />
                                                <asp:Label ID="lblDown4" runat="server" Text=""></asp:Label>
                                            </a>
                                        </td>
                                        <td height="28" valign="bottom">
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
    </div>
    <uc2:Footer ID="Footer1" runat="server" />
    </form>

    <script type="text/javascript">
       window.onload = function setTextColorBasedOnTime() {
            var now = new Date();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var textElement = document.getElementById('timeColorText');
 
            if (hours = 16 && minutes >= 45 || hours = 17 && minutes <= 15 || hours = 21 && minutes >= 10 && minutes <= 40) {
                // 下午16:45 - 17:15和21:10 - 21:40，使用红色
                textElement.style.color = 'red';
            } else {
                // 其它时间，使用深蓝色
//                textElement.style.color = 'darkblue';
                textElement.style.color = 'orange';
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
