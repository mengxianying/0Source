<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_fatie.aspx.cs" Inherits="Pbzx.Web.Buy_fatie" %>

<%@ Register Src="Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>

<%@ Register Src="Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发帖查询 - 拼搏在线彩票网</title>
    <meta name="keywords" content="发帖查询 彩票 彩票软件 彩神通 3D P3 3D彩票 预测 彩票预测 拼搏 短信 排列三 排列五 双色球 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票  图表 走势图 选号 升级 购买 软件下载 代理 彩票论坛 彩票博客 彩票聊天室 彩票新闻 彩票技巧 中奖 开奖信息 号码 试机号" />
    <meta name="description" content="拼搏在线网站是国内资深的专业彩票网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线将一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩票网www.pinble.com" />
    <meta name="robots" content="all" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/buy.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <!--主体部分--->
        <div id="soft" class="bodyw MT">
            <!--左边--->
            <div id="Y_lw1">
                <uc3:Buy_left ID="Buy_left1" runat="server" />
                                
            </div>
            <!--右边--->
            <div id="Y_rw1">
                <div class="Y_wei">
                 您当前的位置：<a href="/">拼搏在线彩票网</a> >> <a href="/Buy_jiage.htm">注册购买</a> >> 发帖查询
                </div>
                <div class="Y_box Y_r1 MT">
                    <div class="title">
                        <p>
                            <a href=""><span>发帖查询</span></a></p>
                    </div>
                    <div class="content">
                        <div>
                            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" valign="bottom" class="Y_xia" style="height: 30px">
                                        发帖查询</td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                            </table>
                            <table width="92%" border="0" align="center" cellpadding="15" cellspacing="1" bgcolor="#ECECEC">
                                <tr>
                                    <td align="left" bgcolor="#FCFCFC">
                                        <span class="blue">请输入论坛的用户名和密码查询发贴信息!</span><br />
                                        <br />
                                        <table width="70%" border="0" align="center" cellpadding="5" cellspacing="0">
                                            <tr>
                                                <td width="23%" height="30" align="right">
                                                    用户名:</td>
                                                <td width="77%">
                                                    <asp:TextBox ID="txtName" runat="server" Width="160px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right">
                                                    密&nbsp;&nbsp;码:</td>
                                                <td>
                                                   <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="160px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="right">
                                                    软件名称:</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSoft" runat="server">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>                                                
                                                <td height="30" colspan="2">
                                                  <table width="56%" border="0" align="center" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td>
                                                   <asp:Button ID="btnUp" runat="server" Text="上周帖子查询" OnClick="btnUp_Click" class="buy_btnbg"/>
                                                    <asp:Button ID="btnThis" runat="server" Text="本周帖子查询" OnClick="btnThis_Click" class="buy_btnbg"/>
                                              </td>
                                                  </tr>
                                                  </table>
                                              </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <uc4:Uc_BuyHmenn ID="Uc_BuyHmenn1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<script>GetKDJS();</script>
</html>
