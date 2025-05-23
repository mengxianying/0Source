<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_fatieList.aspx.cs"
    Inherits="Pbzx.Web.Buy_fatieList" %>

<%@ Register Src="/Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>
<%@ Register Src="/Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="/Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发帖查询详细 - 拼搏在线彩票网</title>
    <meta name="keywords" content="发帖查询详细 彩票 彩票软件 彩神通 3D P3 3D彩票 预测 彩票预测 拼搏 短信 排列三 排列五 双色球 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票  图表 走势图 选号 升级 购买 软件下载 代理 彩票论坛 彩票博客 彩票聊天室 彩票新闻 彩票技巧 中奖 开奖信息 号码 试机号" />
    <meta name="description" content="拼搏在线网站是国内资深的专业彩票网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线将一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析工具及彩票交流平台。" />
    <meta name="author" content="拼搏在线彩票网www.pinble.com" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/buy.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head2" runat="server" />
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
                                    <td height="30" align="center" valign="bottom" class="Y_xia">
                                        发帖查询</td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                            </table>
                            <table width="96%" border="0" align="center" cellpadding="6" cellspacing="1" bgcolor="#ECECEC">
                                <tr>
                                    <td align="left" bgcolor="#FCFCFC">
                                        <table width="90%" border="0" align="center" cellpadding="6" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <strong>用户名:</strong>
                                                    <asp:TextBox ID="txtName" runat="server" Width="160px"></asp:TextBox>
                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;<strong>软件名称:</strong>
                                                    <asp:DropDownList ID="ddlSoft" runat="server">
                                                    </asp:DropDownList>&nbsp;&nbsp;
                                                    <asp:Button ID="btnUp" runat="server" Text="上周帖子查询" OnClick="btnUp_Click" class="buy_btnbg" />
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnThis" runat="server" Text="本周帖子查询" OnClick="btnThis_Click" class="buy_btnbg" /></td>
                                            </tr>
                                        </table>
                                        <table width="98%" border="0" cellpadding="1" cellspacing="1" bgcolor="#9FCFD9" id="tb1"
                                            runat="server" align="center">
                                            <%--                                         <tr height="22">
                                                <td align="center" colspan="6" height="22">
                                                    aa</td>
                                            </tr>
                                            <tr bgcolor="#D7E1E1" height="22px">
                                                <td height="22px" align="center">
                                                    <b>论坛版面</b></td>
                                                <td align="center">
                                                    <b>主帖总数</b></td>
                                                <td align="center">
                                                    <b>跟帖总数</b></td>
                                                <td align="center">
                                                    <b>精华贴数</b></td>
                                                <td align="center">
                                                    <b>发贴跟帖天数</b></td>
                                                <td align="center">
                                                    <b>其它</b></td>
                                            </tr>
                                            <tr bgcolor="#FFFFFF">
                                                <td align="center">
                                                    a</td>
                                                <td align="center">
                                                    0</td>
                                                <td align="center">
                                                    0</td>
                                                <td align="center">
                                                    0</td>
                                                <td align="center">
                                                    0</td>
                                                <td align="center" style="color: #999999">
                                                    查看详情>>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#FCFCFC">
                                                <td align="center">
                                                    d
                                                </td>
                                                <td align="center">
                                                    2</td>
                                                <td align="center">
                                                    d</td>
                                                <td align="center">
                                                    s</td>
                                                <td align="center">
                                                    sd</td>
                                                <td align="center">
                                                    <font color="#0000ff">查看详情>></font></td>
                                            </tr>
                                            <tr bgcolor="#EAEAEA">
                                                <td align="center">
                                                    <b>总计</b></td>
                                                <td align="center">
                                                    fg</td>
                                                <td align="center">
                                                    t</td>
                                                <td align="center">
                                                    t</td>
                                                <td align="center">
                                                    j</td>
                                                <td align="center">
                                                    <img src="images/web/dui.gif" width="24" height="20" border="0" title="可以使用软件!">
                                                    <img src="images/web/ca.gif" width="24" height="20" border="0" title="不能使用软件!">
                                                </td>
                                            </tr>
                                            <tr bgcolor="#EAEAEA">
                                                <td align="center">
                                                    <b>发帖标准</b></td>
                                                <td align="center">
                                                    <b>df</b></td>
                                                <td align="center">
                                                    <b>yy</b></td>
                                                <td align="center">
                                                    <b>rt</b></td>
                                                <td align="center">
                                                    <b>yt</b></td>
                                                <td align="center">
                                                    <font color="#0000ff">查看详情>></font></td>
                                            </tr>--%>
                                        </table>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                            <tr>
                                                <td>
                                                    说明:主帖总数、跟帖总数、精华贴数和发贴跟贴天数必须同时满足“发贴标准”的要求。<br />
                                                    &nbsp;<img src="/images/web/dui.gif" width="18" height="15" border="0" title="可以使用软件!" />表示上周(星期一至星期日)发贴数量符合要求,本周可以免费使用软件;<font
                                                        color="FF0000">请选择“网络注册”方式,输入论坛名和密码登录即可使用。</font><br />
                                                    &nbsp;<img src="/images/web/ca.gif" width="18" height="15" border="0" title="不能使用软件!" />表示上周(星期一至星期日)发贴数量不符合要求,本周不能免费使用软件,希望努力发贴。</td>
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
