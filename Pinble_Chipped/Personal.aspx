<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="Pinble_Chipped.Personal" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人主页</title>
    <link href="Css/Pgrenr.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" charset="gb2312" src="js/Apply.js?date=new date().gettime()"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>

</head>
<body>
    <div>
        <!--左侧部分-->
        <div class="userm_left">
            <%--            <div class="okbox">
                <ul>
                    <li>邮件服务第一期：双色球投注信息通知邮件上线啦！</li>
                </ul>
            </div>--%>
            <!--个人档案信息部分-->
            <div class="foldbox ">
                <div class="fold_top">
                    <em></em>
                </div>
                <div class="fold_center">
                    <div class="title">
                        <em><b>个人档案</b></em></div>
                    <div class="j-wgt-body">
                        <div class="user_info">
                            <dl class="first">
                                <table width="100%" border="0">
                                    <tr>
                                        <td rowspan="2" width="12%">
                                            <img src="images/avatar-60.png" />
                                        </td>
                                        <td>
                                            <span class="tit">
                                                <asp:Label ID="lab_winName" runat="server"></asp:Label>：<asp:Label ID="lab_UserName"
                                                    runat="server"></asp:Label>&nbsp;&nbsp;</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="javascript:void(0)" class="abtn" id="Attention" onclick="attention()"><cite>
                                                关注他</cite></a>&nbsp;&nbsp;&nbsp;<a href="#" class="abtn"><cite>点击收藏他</cite></a>
                                        </td>
                                    </tr>
                                </table>
                            </dl>
                            <div class="j-wgt-content hide">
                                <dl>
                                    <dt>上次登录：</dt>
                                    <dd>
                                        2011年03月04日 10:57:23
                                    </dd>
                                </dl>
                                <dl class="dl1" style="">
                                    <dt>注册日期：</dt>
                                    <dd class="fixwidth">
                                        2011年3月10日15:36:07</dd>
                                </dl>
                                <dl class="dl1" style="">
                                    <dt>数据统计部分：</dt>
                                </dl>
                                <dl class="dl1" style="">
                                    <dt>最近中奖：</dt>
                                    <dd class="fixwidth">
                                        <asp:Label ID="lab_money" runat="server"></asp:Label></dd>
                                    <dd>
                                    </dd>
                                </dl>
                                <dl class="dl2">
                                    <dd class="line1">
                                        发单次数：
                                        <asp:Label ID="lab_num" runat="server"></asp:Label>
                                        次<a href="#" class="edit_a">查看</a></dd>
                                </dl>
                                <dl class="dl1">
                                    <dt>获奖记录：</dt>
                                    <dd class="fixwidth">
                                        <asp:Label ID="lab_record" runat="server"></asp:Label></dd>
                                    <dd>
                                        <a href="">查看</a></dd>
                                </dl>
                                <dl class="dl2">
                                    <dd class="line1">
                                        发单成功率：<span style="color: Red"><asp:Label ID="lab_success" runat="server"></asp:Label>
                                        </span><a href="" class="edit_a">查看</a></dd>
                                </dl>
                                <div class="linedot1">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="fold_bottom">
                    <em></em>
                </div>
            </div>
            <!--历史战绩-->
            <div class="foldbox ">
                <div class="fold_top">
                    <em></em>
                </div>
                <div class="fold_center">
                    <div class="title">
                        <em><b>他的历史战绩</b></em></div>
                    <div class="j-wgt-body">
                            <asp:DataList ID="dl_history" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                OnItemDataBound="dl_history_ItemDataBound">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                <table width="100%" border="0" class="tables">
                                    <tr>
                                        <td rowspan="2" width="15%">
                                            <asp:Image ID="image_lottery" runat="server" />
                                        </td>
                                        <td>
                                            彩种：<asp:Label ID="lab_lotteryName" runat="server"></asp:Label>   <%--定制跟单 <a href="#">详情</a>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            发单中奖次数：<asp:Label ID="lab_num" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            总金额：￥<asp:Label ID="lab_totalMoney" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                               </table>
                                </ItemTemplate>
                                <FooterTemplate></FooterTemplate>
                            </asp:DataList>
                       
                    </div>
                </div>
                <div class="fold_bottom">
                    <em></em>
                </div>
            </div>
            <!--最新动态-->
            <div class="foldbox ">
                <div class="fold_top">
                    <em></em>
                </div>
                <div class="fold_center">
                    <div class="title">
                        <em><b>他的最新动态</b></em></div>
                    <div class="j-wgt-body">
                        <table width="100%" border="0" class="tabled">
                            <asp:Repeater ID="rep_dynamic" runat="server" OnItemDataBound="rep_dynamic_ItemDataBound">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lab_Lname" runat="server"></asp:Label>
                                            第<%# Eval("ExpectNum") %>期，
                                            <%# Eval("UserName")%>
                                            发起了￥<%# Eval("AtotalMoney") %>元的合买方案。
                                        </td>
                                        <td width="25%">
                                            <%# Convert.ToDateTime(Eval("LaunchTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="rep_pp" runat="server" OnItemDataBound="rep_pp_ItemDataBound">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lab_Lname_pp" runat="server"></asp:Label>
                                            第<asp:Label ID="lab_ExpectNum_pp" runat="server"></asp:Label>期，
                                            <%# Eval("ChippedName")%>
                                            参与了￥
                                            <asp:Label ID="lab_AtotalMoney_pp" runat="server"></asp:Label>元的合买方案。
                                        </td>
                                        <td width="25%">
                                            <%# Convert.ToDateTime(Eval("ChippedTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <%--                <div class="fold_bottom">
                    <em></em>
                </div>--%>
            </div>
        </div>
        <!--左侧部分结束-->
        <%-- <uc1:Footer ID="Footer1" runat="server" />--%>
    </div>
    <input id="Aname" type="hidden" value="<%=name%>" />
</body>
</html>
