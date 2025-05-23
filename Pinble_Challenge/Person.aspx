<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="Pinble_Challenge.Person" %>

<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register src="Contorls/adv.ascx" tagname="adv" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>个人统计 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/Rel.js" charset="gb2312"></script>
    <script type="text/javascript" src="js/btnSwitch.js" charset="gb2312"></script>
    <script type="text/javascript">
        function tran(obj) {
            if (obj == 3) {
                $("#s").addClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");

                $("#Li3").addClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
                $("#Li9999").removeClass("tabs-nav chartTab_on");

            }
            if (obj == 1) {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").addClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");

                $("#Li3").removeClass("tabs-nav chartTab_on");
                $("#Li1").addClass("tabs-nav chartTab_on");
                $("#Li9999").removeClass("tabs-nav chartTab_on");
            }
            if (obj == 9999) {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").addClass("tabs-nav chartTab_on");

                $("#Li3").removeClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
                $("#Li9999").addClass("tabs-nav chartTab_on");
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
        <uc1:logion1 ID="logion11" runat="server" />
    </div>
<%--    <div class="zanneiy_top_B">
        
        <uc4:adv ID="adv1" runat="server" />
        
    </div>--%>
    <div class="zanneiy_top_C">
        <uc2:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj">
                    <!--中间替换的内容区域-->
                    <div class="all">
                        <!--左侧的部分-->
                        <div class="boxL">
                            <div class="face">
                                <img alt="" src="images/img.jpg" width="130" height="130" /></div>
                            <p class="name">
                                <strong>
                                    <%=name %></strong></p>
                            <div class="btnBox">
                                <p>
                                    <a href="HisAchi.aspx?name=<%= name %>" target="_blank">历史成绩</a> <a href="CompOF.aspx" target="_blank">
                                        成绩对比</a><br />
                                    <a href="PRanking.aspx" target="_blank">成绩排行</a> 
                                  <%-- <a href="PRanking.aspx" target="_blank">
                                        积分排行</a>--%>
                                </p>
                            </div>
                            <ul class="info hO">
                                <li class="infoO">
                                    <a href="challenge/UserIntegral.aspx?name=<%= Pbzx.Common.Input.URLEncode(name) %>" target="_blank">查看会员所获积分</a>
                                    </li>
                                <%-- <li class="infoT">彩豆文章：<span class="cB">47 </span>篇</li>
                                <li class="infoTh">免费文章：377 篇</li>--%>
                            </ul>
                            <div class="line">
                            </div>
                            <ul class="info hT">
                                <%--<li class="infoF">历史访问：17967次</li>--%>
                                <li class="infoFi">关 注 量：<asp:Label ID="lab_payAtt" runat="server"></asp:Label>人</li>
                            </ul>
                            <div class="line">
                            </div>
                            <p class="intro">
                                <strong>个人简介：</strong>盼望中奖是我最开心的事。</p>
                            <div class="line">
                            </div>
                            <div class="shareBox">
                                <div class="abtned">
                                    <span><a href="javascript:void(0)" class="cr" id="delTo">取消关注</a></span>
                                </div>
                                <input id="addTo" class="abtn" type="button" />

                                <!-- Baidu Button BEGIN -->
<%--                                <div class="bdshare_t bds_tools get-codes-bdshare">
                                    <span class="bds_more" style="height: 16px; line-height: 16px; color: #0E51EB;">分享</span>
                                </div>--%>
                                <!-- Baidu Button END -->
<%--                                <p>
                                    <a href="#" class="color-red">推荐给朋友</a></p>--%>
                            </div>
                        </div>
                        <!--左侧的部分结束-->
                        <!--右侧的部分开始-->
                        <div class="boxR">
                            <div class="chartTitle">
                                <h2 class="fl" style="color: #FF0000">
                                    <%=name %>
                                    近期成绩</h2>
                                <%--<ul class="chartTab fl">
                                    <li id="ssq" class="tabs-nav chartTab_on"><a href="javascript:void(0)" onclick="perTableS('s')">
                                        双色球</a></li>
                                    <li id="fd" class="tabs-nav "><a href="javascript:void(0)" onclick="perTableS('d')">
                                        福彩3D</a></li>
                                    <li id="pl" class="tabs-nav "><a href="javascript:void(0)" onclick="perTableS('p')">
                                        排列三</a></li>
                                </ul>--%>  
                                 <ul class="chartTab fl">
                                    <li id="Li3" class="tabs-nav chartTab_on"><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=3">
                                        双色球</a> </li>
                                    <li id="Li1" class="tabs-nav "><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=1">福彩3D</a></li>
                                    <li id="Li9999" class="tabs-nav "><a href="Person.aspx?name=<%= Server.UrlEncode(name) %>&lottN=9999">排列三</a></li>
                                </ul>                              
                                <div class="expert-article-choose fl">
                                    期数
                                    <select id="sel_issN" name="qishu" class="qishu" >
                                        <option value="7">7</option>
                                        <option value="15" selected="selected">15</option>
                                        <option value="30">30</option>
                                    </select>
                                    <asp:DropDownList ID="ddl_issN" runat="server">
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="15" Selected="True">15</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div id="div_Stati1" class="tabs-main" runat="server">
                                <table width="710px">
                                    <tbody>
                                        <tr>
                                        <td></td>
                                        <td>红球3胆</td>
                                        <td>红球6胆</td>
                                        <td>杀3红球</td>
                                        <td>杀6红球</td>
                                        <td>蓝球1胆</td>
                                        <td>蓝球3胆</td>
                                        <td>杀3蓝球</td>
                                        <td>杀6蓝球</td>
                                        <td>12红+3蓝</td>
                                        <td>9红+2蓝</td>

                                        </tr>
                                    </tbody>
                                 </table>
                            </div>
                            <div class="details">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="chartTitle">
                                <h2 class="fl" style="color: #005399">
                                    <%=name %>
                                    发布详情</h2>
                                <ul class="chartTab fl">
                                    <li id="s" class="tabs-nav chartTab_on"><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=3">
                                        双色球</a> </li>
                                    <li id="d" class="tabs-nav "><a href="Person.aspx?name=<%=Server.UrlEncode(name) %>&lottN=1">福彩3D</a></li>
                                    <li id="p" class="tabs-nav "><a href="Person.aspx?name=<%= Server.UrlEncode(name) %>&lottN=9999">排列三</a></li>
                                </ul>
                            </div>
                            <div class="boxB">
                                <%--<ul class="expertChoose">
                                    <li class="chooseunchk"><a href="#">显示全部</a></li>
                                    <li class="choosechk"><a href="#">最近15期</a></li>
                                    <li class="choosechk"><a href="#">成绩展示</a></li>
                                    <li class="choosechk"><a href="#">专家公告</a></li>
                                </ul>--%>
                                <div class="expert-article-text">
                                </div>
                                <div class="tabs-main" style=" width:100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <asp:Repeater ID="rep_data" runat="server" OnItemDataBound="rep_data_ItemDataBound">
                                            <HeaderTemplate>
                                                <tr class="expert-chart-main-top td_white">
                                                    <td>
                                                        序号
                                                    </td>
                                                    <td>
                                                        期号
                                                    </td>
                                                    <td>
                                                        条件名称
                                                    </td>
                                                    <td>
                                                        发布号码
                                                    </td>
                                                    <td>
                                                        是否中奖
                                                    </td>
                                                    <td>
                                                        中奖号码
                                                    </td>
                                                    <td>
                                                        开奖号码
                                                    </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="td_blue">
                                                    <td>
                                                        <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("C_issue")%>
                                                    </td>
                                                    <td>
                                                        <a href="/Person.aspx?ts=<%# Eval("T_id") %>&name=<%= Server.UrlEncode(name) %>&lottN=<%# Eval("C_lottID") %>"><%# Eval("T_cond") %></a>
                                                    </td>
                                                    <td>
                                                       
                                                        <asp:Label ID="lab_cNum" runat="server" ></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_win" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_num" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="labONum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                
                                <!--分页信息部分-->
                                <div class="pageNav">
                                 <table width="100%">
                                    <tr>
                                        <td>
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                                PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                CustomInfoSectionWidth="50%" HorizontalAlign="Center" PageSize="6">
                                            </webdiyer:AspNetPager>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </div>
                            <div class="details">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="chartTitle">
<%--                            <h2 class="fl" style="color: #005399">
                                    我的关注</h2>--%>
                                    <ul class="chartTab fl">
                                    <li id="Li2" class="tabs-nav chartTab_on"><a href="javascript:void(0)">我关注的人</a> </li>
                                    <li id="Li3" class="tabs-nav "><a href="javascript:void(0)">关注我的人</a></li>
                                </ul>
                            </div>
                            <div class="boxB">
                                <div class="expert-article-text">
                                </div>
                                <div class="tabs-main" style="width: 100%" id="PayAttTable">
                                   <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <asp:Repeater ID="rep_payatt" runat="server">
                                       <HeaderTemplate>
                                        <tr>
                                            <td>
                                                序号
                                            </td>
                                            <td>
                                                会员名
                                            </td>
                                            <td>
                                                关注时间
                                            </td>
                                            <td>
                                                操作
                                            </td>
                                        </tr>
                                       </HeaderTemplate>
                                       <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# (Container.ItemIndex + 1) %>
                                            </td>
                                            <td>
                                                <a href='Person.aspx?name=<%# Server.UrlEncode(Eval("Pa_Idol").ToString()) %>' target="_blank"> <%# Eval("Pa_Idol")%></a>
                                            </td>
                                            <td>
                                                <%# Eval("Pa_time")%>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" onclick="CancelPayAtt('<%# Server.UrlEncode(Eval("Pa_Idol").ToString()) %>')">取消关注</a>
                                            </td>
                                        </tr>
                                       </ItemTemplate>
                                       <FooterTemplate>
                                       </FooterTemplate>
                                       </asp:Repeater>
                                </table>
                                </div>

                                <div class="pageNav">
                                </div>
                            </div>

                        </div>
                    </div>
                    <!--中间替换的内容区域结束-->
                </div>
            </div>
<%--            <div class="yny_neirong_C">
            </div>--%>
        </div>
       
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
        <div class="footer" style="clear: both;">
            <uc3:Footer ID="Footer1" runat="server" />
        </div>
    </div>
    </div>

    
    <input id="uname" type="hidden" value="<%=name %>" />
    <!---用户名--->

    </form>
</body>
</html>
