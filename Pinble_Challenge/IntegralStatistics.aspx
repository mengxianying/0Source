<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntegralStatistics.aspx.cs" Inherits="Pinble_Challenge.IntegralStatistics" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="keywords" content='彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码' />
    <meta name="description" content='拼搏在线彩神通软件网站是国内资深的专业彩票软件网站，旗下的彩神通系列彩票软件获得全国广大彩民的深切厚爱，拼搏在线始终一如既往推出更为优秀的彩票软件及更全面的网络增值服务，为广大彩民提供最好的彩票分析软件工具及彩票交流平台。' />
    <meta name="author" content='拼搏在线彩神通软件 www.pinble.com' />
    <meta name="robots" content="all" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <title>拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    

        <script type="text/javascript" src="js/calendar.js"></script>
    <style type="text/css">
        .ball-0
        {
            height: 20px;
            width: 20px;
            cursor: pointer;
        }
        .ball-0 span
        {
            float: left;
            width: 24px;
            height: 24px;
            line-height: 19px;
            margin: 3px 4px 3px 4px;
            text-align: center;
            font-size: 10px;
            cursor: pointer;
        }
        .rb
        {
            background: url(../images/ball-area.gif) -80px 0 no-repeat;
            color: #fff;
            font-weight: bold;
        }
        .fun
        {
            background: url(../images/ball-area.gif) -80px 0 no-repeat;
            color: #fff;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
        <uc2:logion1 ID="logion11" runat="server" />
    </div>
    <div class="zanneiy_top_C">
        <uc3:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj">
                    <div class="all">
                        <div class="tabtype" style="margin-top: 10px;">
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lbtn_s" runat="server" PostBackUrl="~/IntegralStatistics.aspx?id=s">双色球</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_d" runat="server" PostBackUrl="~/IntegralStatistics.aspx?id=d">福彩3D</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lbtn_p" runat="server" PostBackUrl="~/IntegralStatistics.aspx?id=p">排列三</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="ssq-expert-title">
                            <p class="title-text title-text-l">
                                <asp:Label ID="lab_lname" runat="server" Text="Label">双色球</asp:Label>预测汇总</p>
                            <%--                                                        <div class="btn_sf on_btn">

                                </div>--%>
                            <%--<div class="btn_sf">
                                <a class="btn_link" href="#">专家</a></div>--%>
                            <div class="ssq-check" style="float: right; margin-right: 20px;">
                            用户名：<asp:TextBox ID="txt_user" runat="server" style="border: 1px solid; height: 20px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               开始时间：<asp:TextBox ID="txt_StarTime" onfocus="calendar();" runat="server" style="border: 1px solid; height: 20px"></asp:TextBox>--结束时间：<asp:TextBox ID="txt_endTime" onfocus="calendar();"
                                    runat="server" style="border: 1px solid; height: 20px"></asp:TextBox>
                                <asp:Button ID="btnQuery" class="seach-button" runat="server" Text="查询" 
                                    onclick="btnQuery_Click" />
                            </div>
                        </div>
                        <div id="content" runat="server">
                            <table class="ssq-expert-charts">
                                <asp:Repeater ID="rep_con" runat="server">
                                    <HeaderTemplate>
                                        <tr height="30px" class="back-color color-blue">
                                            <td>
                                                名次
                                            </td>
                                            <td>
                                                用户名
                                            </td>
                                            <td>
                                                积分
                                            </td>

                                        </tr>
                                        <tbody id="info">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# (Container.ItemIndex + 1) %>
                                            </td>
                                            <td>
                                                <%# Eval("u_name")%>
                                            </td>
                                            <td>
                                                <%# Eval("u_coin")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody></FooterTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
<%--                        <table width="98%" style="margin-top:20px">
                            <tr>
                                <td align="center">
                                    <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" custominfotextalign="Center"
                                        firstpagetext="第一页" lastpagetext="最后一页" nextpagetext="下一页" onpagechanged="AspNetPager1_PageChanged"
                                        prevpagetext="上一页" showcustominfosection="Right" showinputbox="Always" shownavigationtooltip="True"
                                        width="100%" backcolor="Transparent" custominfostyle='vertical-align:middle;'
                                        custominfosectionwidth="35%" horizontalalign="Center">
                                    </webdiyer:aspnetpager>
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                </div>
            </div>
            <div class="yny_neirong_C">
            </div>
        </div>
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
            <div class="footer" style="clear: both;">
                <uc1:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>