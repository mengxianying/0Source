<%@ Page Language="C#" AutoEventWireup="true" Codebehind="buy.aspx.cs" Inherits="Pinble_Market.buy" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>彩票超市购买</title>
    <meta http-equiv="pragma"  content="no-cache">  
    <meta http-equiv="Cache-Control"  content="no-cache,  must-revalidate">  
    <meta http-equiv="expires" content="0"> 
    <link href="Css/independent.css" rel="stylesheet" type="text/css" />
<style type="text/css">
body {
	color: #484848;
	padding:0;
	background-color: #E3F4F9;	
	font-size: 12px;
	margin-top: 0;
	margin-right: auto;
	margin-bottom: 0;
	margin-left: auto;
}
.HeadLogin{
	background-image: url(../image/login_Bt1.jpg);
	background-repeat: repeat-x;
	height: 23px;
	width: 55px;
	background-color: #FFF686;
	border:0px;
	cursor:pointer
}

.HeadReset{
	background-image: url(../image/login_Bt2.jpg);
	background-repeat: repeat-x;
	height: 23px;
	width: 55px;
	background-color: #FFF686;
	border:0px;
	cursor:pointer
}

</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="wrap">
    <div class="top">
        <ul class="topNav">
            <li class="nav1"><a href="http://market.pinble2.com">首页</a></li>
            <li class="nav2"><a href="#">欢迎注册</a></li>
            <li class="nav2"><a href="#">帮助中心</a></li>
        </ul>
        <h1 class="logo">
            <img src="image/sprite.png" /></h1>
        <h1 class="icon">
            <img src="image/sprite1.png" width="696" height="57" border="0" usemap="#Map" />
            <map name="Map" id="Map">
                <area shape="rect" coords="8,3,47,58" href="http://www.pinble.com" target="_blank" />
                <area shape="rect" coords="76,5,131,59" href="#" target="_blank" />
                <area shape="rect" coords="156,4,213,58" href="#" />
                <area shape="rect" coords="245,5,293,61" href="#" target="_blank" />
                <area shape="rect" coords="335,3,371,62" href="http://bar.pinble.com/" target="_blank" />
                <area shape="rect" coords="403,4,462,61" href="#" />
                <area shape="rect" coords="490,3,542,61" href="http://market.pinble.com" />
                <area shape="rect" coords="568,4,617,60" href="#" />
                <area shape="rect" coords="646,5,694,62" href="#" />
            </map>
        </h1>
    </div>
    <div class="clear">
    </div>

    <div class="main">
<%--        <div class="z_title">
            <h2>
                3D号码组</h2>
        </div>--%>
       
        <div class="infojiezhi">
            项目条件：<asp:Label ID="lan_NvarName" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">价格： <asp:Label
                ID="lab_price" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
            发布时间：<asp:Label ID="lab_time" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            发布会员：<asp:Label ID="lab_user" runat="server"></asp:Label>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="infotable">
            <tr>
                <td class="tdl">
                    会员信息</td>
                <td class="tdr">
                    <span class="blue2 bold">中奖概率<img src="image/gold.gif" border="0" /> 37%
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </span><span class="gz_detail"><span class="blue2 bold">关注人数：<asp:Label ID="lab_attention"
                        runat="server"></asp:Label>人</span><span class="blue2 bold">&nbsp;&nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton
                            ID="lbtn_attention" runat="server" OnClick="lbtn_attention_Click">关注这个项目</asp:LinkButton></span>
                        <!--<span id="zjinfo" style="display:none;">-->
                        <span class="getmoney"><span class="blue2 bold">总中奖次数：</span><span id="cnt"></span><span
                            class="red" id="after_bonus">10次&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span><span
                                class="getmoney"><span class="gray">已经发布 <font color="green"><asp:Label ID="lab_num" runat="server"></asp:Label></font> 期</span><span class="gray"></span>&nbsp;&nbsp;
          &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<a href='History.aspx?lottery=<%=NvarName %>&name=<%=TypeName %>&user=<%= userId%>' target="_blank"><span class="red"
                                        id="Span1">查看详情</span></a>(提示：详情不显示当前这一期。只有一期的项目条件。详情没内容) </span>
                </td>
            </tr>
            <tr>
                <td class="tdl">
                    方案信息</td>
                <td height="30" class="tdr">
                    <span class="getmoney"><span class="gray">上期期号：</span><span class="gray"><asp:Label
                        ID="lab_upNum" runat="server"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<span class="gray">最新期号：</span><asp:Label
                            ID="lab_NewNum" runat="server"></asp:Label></span>
                        <span class="getmoney"><span class="gray">上期内容：<asp:Label ID="lab_NumGut" runat="server"></asp:Label> </span><span class="getmoney"><span
                            class="gray">方案内容介绍：<asp:Label ID="lab_say" runat="server"></asp:Label> </span><span class="gray"></span>&nbsp;</span>
                </td>
            </tr>
            <tr>
                <td class="tdl">
                    我要购买</td>
                <td class="tdr">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <div style="margin-top: 5px; margin-bottom:15px ">
                                    <div id="showUserInfo" class="tishi">
                                        <strong><asp:Label ID="lab_name" runat="server"></asp:Label></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                            ID="lbtn_login" runat="server">注册成为高级用户</asp:LinkButton> 
                                        <asp:Label ID="lab_buyHistory" runat="server"></asp:Label></div>
                                </div>
                                <span class="blue2 bold">选择订购时间：<asp:DropDownList ID="Cob_time" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Cob_time_SelectedIndexChanged">
                                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                                </span><span class="blue2 bold">&nbsp;&nbsp;开始时间：<asp:Label ID="lab_beginTime" runat="server"></asp:Label></span> <span class="blue2 bold">
                                    &nbsp;&nbsp;&nbsp;结束时间：<asp:Label ID="lab_endTime" runat="server"></asp:Label></span> <span class="getmoney"><span class="blue2 bold">
                                        续费设置：
                                        <input type="radio" name="radiobutton" value="0" />
                                        自动设置
                                        <input type="radio" name="radiobutton" value="1" checked="CHECKED" />
                                        手动设置</span></span> <span class="quedingr">
                                            <div style="line-height: 30px">
                                                <%--<input id="agreement" type="checkbox" value="1" checked="checked" />--%>
                                                <asp:CheckBox ID="agreement" runat="server" Checked="True" />
                                                我已阅读了<a href="UserAgreement.aspx" target="_blank">《用户购买协议》</a>并同意其中条款。</div>
                                        </span>
                            </td>
                            <td width="1" align="right" style="padding: 0 40px 0 20px; height: 134px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/btn_queding2.bmp" OnClick="ImageButton1_Click" />
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="tdl">
                    订购历史</td>
                <td class="td_fangan">
                    <table width="100%" border="0" align="center" cellspacing="1" class="fangan_table">
                                <asp:Repeater ID="Tab_BuyInfo" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                                            <td >
                                                序号</td>
                                            <td >
                                                买家</td>
                                            <td >
                                                开始时间</td>
                                            <td >
                                                结束时间</td>
                                            <td >
                                                订制时间</td>
                                            <td >
                                                价格</td>
                                            <td >
                                                评价</td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                            <td >
                                               <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                            </td>
                                            <td >
                                            <asp:Label ID="Lab_username" runat="server"></asp:Label><%# Eval("buyuserid") %></td>
                                            <td >
                                                <%# string.Format("{0:u}", Eval("BeginTime")).Substring(0, 10) %>
                                            </td>
                                            <td >
                                                <%# string.Format("{0:u}", Eval("EndTime")).Substring(0, 10)  %>
                                            </td>
                                            <td >
                                                <%# Eval("Term") %>个月
                                            </td>
                                            <td >
                                                <%# Eval("Price") %>元/月
                                            </td>
                                            <td >
                                                方案不错，每次都有收获
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="litContent" runat="server"></asp:Label><tr>
                                    <td colspan="9" style="background-color: #FFFFFF;">
                                        <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="True" custominfotextalign="Center"
                                            firstpagetext="第一页" lastpagetext="最后一页" nextpagetext="下一页" onpagechanged="AspNetPager1_PageChanged"
                                            prevpagetext="上一页" showcustominfosection="Right" showinputbox="Always" shownavigationtooltip="True"
                                            width="100%" backcolor="Transparent" custominfostyle='vertical-align:middle;'
                                            custominfosectionwidth="35%" horizontalalign="Center">
                            </webdiyer:aspnetpager>
                                    </td>
                                </tr>
                            </table>
                </td>
            </tr>
        </table>
    </div>
     
    <div class="footbg">
        <div class="wrap_footer">
            <div class="kong10">
            </div>
            <div class="footer_nav01">
                关于我们 | 拼搏在线 | 用户注册 | 联系我们 | 网站加盟</div>
            <div class="footer_nav02">
                <strong>热点导读：</strong>彩票 | 购买彩票 | 开奖信息 | 即时比分 | 胜负彩 | 进球彩 | 双色球 | 七星彩 | 排列3 | 排列5
                | 福彩3D | 22选5 | 29选7 | 大乐透 | 时时彩 | 时时乐</div>
            <div class="copy_new">
                版权所有：拼搏在线（北京）科技发展有限公司 版权所有2004-2010 京ICP备05051578号 京ICP证050806号<br />
                <font color="#ff0000">！免责声明：</font>非本站内部广告请仔细甄别真伪，本站不承担因非本站广告给您带来的任何损失和任何法律责任。
                <div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
