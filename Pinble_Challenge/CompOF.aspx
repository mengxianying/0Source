<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompOF.aspx.cs" Inherits="Pinble_Challenge.CompOF" %>

<%@ Register src="Contorls/logion1.ascx" tagname="logion1" tagprefix="uc1" %>

<%@ Register src="Contorls/Navigation.ascx" tagname="Navigation" tagprefix="uc2" %>

<%@ Register src="Contorls/Footer.ascx" tagname="Footer" tagprefix="uc3" %>

<%@ Register src="Contorls/adv.ascx" tagname="adv" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title>成绩对比 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/Rel.js"></script>
    <script type="text/javascript" src="js/btnSwitch.js"></script>
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
                        <div class="clear">
                        </div>
                        <div class="subtitle">
                            <p>
                                <span>当前位置：>> <span id="lname">双色球</span> 预测会员对比</span></p>
                        </div>
                        <div class="tabtype">
                            <ul>
                        <li><a href="javascript:Swit('ssq')" id="sq" class="hover">双色球</a></li>
                        <li><a href="javascript:Swit('3D')" id="fd">福彩3D</a></li>
                        <li><a href="javascript:Swit('pl3')" id="pl">排列三</a></li>
                    </ul>
                            <span class="right-type"><font style="color: #005399">>> 温馨提示：按近15期独胆成绩排名</font></span>
                        </div>
                        <div class="duimain-title">
                            <div class="title-middle">
                                <span class="title-text title-text-l"><span id="lottN">双色球</span> 预测会员对比</span>  <span style="margin: 11px 0 0 10px;"
                                    class="title-text-l">
                                    <span style="margin-right: 15px;">近
                                        <select id="sel_issue">
                                            <option value="50">50</option>
                                            <option value="100" selected="selected">100</option>
                                            <option value="150">150</option>
                                        </select>
                                        期 </span><%--<span style="margin-right: 15px;">指标
                                            <select>
                                                <option value="1" selected>独胆</option>
                                                <option value="2">双胆</option>
                                                <option value="3">三胆</option>
                                                <option value="4">五码组选</option>
                                                <option value="5">六码组选</option>
                                                <option value="7">杀一码</option>
                                                <option value="8">杀二码</option>
                                                <option value="9">杀三码</option>
                                                <option value="10">定位杀三码</option>
                                                <option value="11">定位杀四码</option>
                                                <option value="13">定三跨度</option>
                                                <option value="15">定四和值</option>
                                                <option value="17">杀二和尾</option>
                                                <option value="19">包星两组</option>
                                                <option value="22">定位5*5*5</option>
                                            </select>
                                        </span><span>前
                                            <select id="selValue" name="lottery_num">
                                                <option value="10" >10</option>
                                                <option value="15" selected="selected">15</option>
                                                <option value="10" >30</option>
                                            </select>
                                            名会员 </span>--%>
                                </span><span class="title-text title-text-r"><a href="http://www.pinble.com/Lottery.htm" target="_blank" style="color: #FF0000;font-size: 12px">开奖结果查询</a> </span></span>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div id="div_table" class="cyc_leftb">
                   
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

    
    </form>
</body>
</html>
