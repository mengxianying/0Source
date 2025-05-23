<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfo.aspx.cs" Inherits="Pinble_DataRivalry.MemberInfo"
    EnableViewState="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>个人统计 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/jsTable.js"></script>
    <script type="text/javascript">
        function tran(obj) {
            if (obj == "zx") {
                $("#s").addClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
            }
            if (obj == "zux") {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").addClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
            }
            if (obj == "pzx") {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").addClass("tabs-nav chartTab_on");
                $("#Li1").removeClass("tabs-nav chartTab_on");
            }
            if (obj == "pzux") {
                $("#s").removeClass("tabs-nav chartTab_on");
                $("#d").removeClass("tabs-nav chartTab_on");
                $("#p").removeClass("tabs-nav chartTab_on");
                $("#Li1").addClass("tabs-nav chartTab_on");
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
                                    <%=n_uName %></strong></p>
                            <%-- <div class="btnBox">
                                <p>
                                    <a href="" target="_blank">成绩</a> <a href=""
                                        target="_blank">成绩对比</a><br />
                                    <a href="" target="_blank">排行</a> <a href="" target="_blank">
                                        排行</a>
                                </p>
                            </div>
                            <ul class="info hO">
                                <li class="infoO"><a href="" target="_blank">查看会员所获积分</a> </li>
                            </ul>--%>
                            <div class="line">
                            </div>
                            <ul class="info hT">
                                <%--<li class="infoF">历史访问：17967次</li>--%>
                                <li class="infoFi">关 注 量：<asp:Label ID="lab_payAtt" runat="server"></asp:Label>人</li>
                            </ul>
                            <div class="line">
                            </div>
                            <p class="intro">
                                <%--<strong>个人简介：</strong>盼望中奖是我最开心的事。--%></p>
                            <div class="line">
                            </div>
                            <div class="shareBox">
                                <div class="abtned">
                                    <span><a href="#;" class="cr" id="deletePayatt">取消关注</a></span>
                                </div>
                                <input class="abtn" type="button" id="addPayatt" />
                                <%-- <div class="bdshare_t bds_tools get-codes-bdshare">
                                    <span class="bds_more" style="height: 16px; line-height: 16px; color: #0E51EB;">分享</span>
                                </div>

                                                               <p>
                                    <a href="#" class="color-red">推荐给朋友</a></p>--%>
                            </div>
                        </div>
                        <!--左侧的部分结束-->
                        <!--右侧的部分开始-->
                        <div class="boxR">
                            <div id="div_Stati" class="tabs-main">
                                <table width="710px" border="0">
                                    <tr>
                                        <td colspan="4">
                                            <span style="font-size: 14px">会员：</span><span style="color: #FF0000; font-size: 14px"><asp:Label
                                                ID="lab_userName" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            发布个数：
                                        </td>
                                        <td>
                                            <span style="color: #FF0000; padding-left: 25px">
                                                <asp:Label ID="lab_releaseNum" runat="server"></asp:Label></span>个
                                        </td>
                                        <td>
                                            被下载次数：
                                        </td>
                                        <td>
                                            <span style="color: #FF0000; padding-left: 25px">
                                                <asp:Label ID="lab_download" runat="server"></asp:Label></span>次
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--发单注数：--%>
                                        </td>
                                        <td>
                                            <%-- <span style="color: #FF0000; padding-left: 25px">
                                                <asp:Label ID="lab_noteNum" runat="server" Text="Label"></asp:Label></span>次--%>
                                        </td>
                                        <td>
                                            中奖次数：
                                        </td>
                                        <td>
                                            <span style="color: #FF0000; padding-left: 25px">
                                                <asp:Label ID="lab_winning" runat="server"></asp:Label></span>次
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            个人积分：
                                        </td>
                                        <td>
                                            <span style="color: #FF0000; padding-left: 25px">
                                                <asp:Label ID="lab_integral" runat="server"></asp:Label></span>分
                                        </td>
                                        <td>
                                            等级：
                                        </td>
                                        <td>
                                            <span style="color: #FF0000; padding-left: 25px">
                                                <asp:Label ID="lab_level" runat="server"></asp:Label></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="details">
                            </div>
                            <div class="clear">
                            </div>
                            <div class="chartTitle">
                                <h2 class="fl" style="color: #005399">
                                    大底详情</h2>
                                <ul class="chartTab fl">
                                    <li id="s" class="tabs-nav chartTab_on"><a href="MemberInfo.aspx?name=<%=n_uName %>&lottName=zx">
                                        3D直选</a> </li>
                                    <li id="d" class="tabs-nav "><a href="MemberInfo.aspx?name=<%=n_uName %>&lottName=zux">
                                        3D组选</a></li>
                                    <li id="p" class="tabs-nav "><a href="MemberInfo.aspx?name=<%=n_uName %>&lottName=pzx">
                                        排三直选</a></li>
                                    <li id="Li1" class="tabs-nav "><a href="MemberInfo.aspx?name=<%=n_uName %>&lottName=pzux">
                                        排三组选</a></li>
                                </ul>
                                <span><font color="red">(数据在发布后半小时内允许删除)</font></span>
                            </div>
                            <div class="boxB">
                                <div class="expert-article-text">
                                </div>
                                <div class="tabs-main" style="width: 100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <asp:Repeater ID="rep_data" runat="server" OnItemDataBound="rep_data_ItemDataBound"
                                            OnItemCommand="rep_data_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="expert-chart-main-top td_white">
                                                    <td>
                                                        序号
                                                    </td>
                                                    <td>
                                                        会员名称
                                                    </td>
                                                    <td>
                                                        提交时间
                                                    </td>
                                                    <td>
                                                        期号
                                                    </td>
                                                    <td>
                                                        注数
                                                    </td>
                                                    <td>
                                                        中组
                                                    </td>
                                                    <td>
                                                        2D
                                                    </td>
                                                    <td>
                                                        1D
                                                    </td>
                                                    <td>
                                                        0D
                                                    </td>
                                                    <td>
                                                        开奖号
                                                    </td>
                                                    <td>
                                                        删除
                                                    </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("F_username") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("F_addTime")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("F_Period")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("F_FileNum")%>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_group" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_2D" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_1D" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_0D" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lab_awer" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div id="delete" runat="server" visible="false">
                                                        <asp:LinkButton ID="lb_del" runat="server" CommandArgument='<%# Eval("F_drID") %>'
                                                            CommandName="del" OnClientClick="return confirm('确认删除数据？')">删除</asp:LinkButton>
                                                            </div>
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
                                                    CustomInfoSectionWidth="50%" HorizontalAlign="Center">
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
                                    <li id="Li2" class="tabs-nav chartTab_on"><a href="javascript:void(0)">我关注的人</a>
                                    </li>
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
                                                        <a href="MemberInfo.aspx?name=<%# Eval("Pa_Idol") %>" target="_blank">
                                                            <%# Eval("Pa_Idol")%></a>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Pa_time")%>
                                                    </td>
                                                    <td>
                                                        <a href="javascript:void(0)" onclick="CancelPayAtt('<%# Eval("Pa_Idol") %>')">取消关注</a>
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
            <div class="yny_neirong_C">
            </div>
        </div>
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
            <div class="footer" style="clear: both;">
                <uc3:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>
    <input id="uName" type="hidden" value="<%= n_uName %>" />
    </form>
</body>
</html>
