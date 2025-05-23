<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Buy_fatieListShow.aspx.cs"
    Inherits="Pbzx.Web.Buy_fatieListShow" %>

<%@ Register Src="/Contorls/Uc_BuyHmenn.ascx" TagName="Uc_BuyHmenn" TagPrefix="uc4" %>
<%@ Register Src="/Contorls/Buy_left.ascx" TagName="Buy_left" TagPrefix="uc3" %>
<%@ Register Src="/Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head id="Head2" runat="server" />
        <!--主体部分--->
        <div id="soft" class="bodyw MT">
            <!--左边--->
            <div id="Y_lw1">
                <uc3:buy_left id="Buy_left1" runat="server" />
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
                                        <table width="100%" border="0">
                                            <tr>
                                                <td align="center" style="font-size: 14px; color: '#cc0000'">
                                                    <asp:Label ID="lblUserBM" runat="server"></asp:Label>
                                                    版面<br />
                                                    <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>的发贴详细信息
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="98%" border="0" cellspacing="1" style="margin-top: 5px;" bgcolor="#9FCFD9"
                                            cellpadding="2" align="center">
                                            <tr bgcolor="#0000ff" height="22px">
                                                <td width="88" align="center" bgcolor="#D7E1E1" scope="col">
                                                    <b>普通主帖数</b></td>
                                                <td width="79" align="center" bgcolor="#D7E1E1" scope="col">
                                                    <b>精华主帖数</b></td>
                                                <td width="78" align="center" bgcolor="#D7E1E1" scope="col">
                                                    <b>普通跟帖数</b></td>
                                                <td width="71" align="center" bgcolor="#D7E1E1" scope="col">
                                                    <b>精华跟帖数</b></td>
                                                <td width="80" align="center" bgcolor="#D7E1E1" scope="col">
                                                    <b>被删除主帖数</b></td>
                                                <td width="80" align="center" bgcolor="#D7E1E1" scope="col">
                                                    <b>被删除跟帖数</b></td>
                                            </tr>
                                            <tr bgcolor="#ffffff">
                                                <td width="88" height="22" align="center">
                                                    <asp:Label ID="lblCommonHostT" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td width="79" height="22" align="center">
                                                    <asp:Label ID="lblBestHostT" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td height="22" align="center" scope="col">
                                                    <asp:Label ID="lblCommonHellT" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td height="22" align="center" scope="col">
                                                    <asp:Label ID="lblBestCommonT" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td height="22" align="center" scope="col">
                                                    <asp:Label ID="lblDelHostT" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td height="22" align="center" scope="col">
                                                    <asp:Label ID="lblDelHellT" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                                <td width="16%" align="center">
                                                    <b>主贴总数：</b></td>
                                                <td width="84%">
                                                    <asp:Label ID="lblTopicZS" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <b>跟贴总数：</b></td>
                                                <td>
                                                    <asp:Label ID="lblHellZS" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                            </table>
                            <br />
                            <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" GridLines="None"
                                Width="98%" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="序号">
                                        <ItemStyle HorizontalAlign="Center" Width="9%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="内容">
                                        <ItemTemplate>
                                           <%#Eval("ParentID").ToString() == "0" ? Pbzx.Common.StrFormat.CutStringByNum(Pbzx.Common.Input.FilterHTML(Eval("topic").ToString()), 100, "...") : Pbzx.Common.StrFormat.CutStringByNum(Pbzx.Common.Input.FilterHTML(Eval("Body").ToString()), 100, "...")%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="59%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类型">
                                        <ItemTemplate>
                                           <%# Pbzx.Web.WebFunc.FormartTypeTZ(Eval("BoardID"), Eval("ParentID"), Eval("isbest"))%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发贴时间">
                                        <ItemTemplate>
                                            <%#Eval("DateAndTime","{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridView_Header" />
                                <RowStyle CssClass="GridView_Row" />
                                <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页" />
                            </asp:GridView>
                            &nbsp;
                            <br />
                            <br />
                            
                            
                            <uc4:uc_buyhmenn id="Uc_BuyHmenn1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc2:footer id="Footer1" runat="server" />
    </form>
</body>
</html>

<script>GetKDJS();</script>

