<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HisAchi.aspx.cs" Inherits="Pinble_Challenge.HisAchi" %>

<%@ Register src="Contorls/logion1.ascx" tagname="logion1" tagprefix="uc1" %>

<%@ Register src="Contorls/Navigation.ascx" tagname="Navigation" tagprefix="uc2" %>

<%@ Register src="Contorls/Footer.ascx" tagname="Footer" tagprefix="uc3" %>

<%@ Register src="Contorls/adv.ascx" tagname="adv" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title>历史成绩 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
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
                        <div class="subtitle">
                            <p>
                                <span>当前位置：双色球历史成绩</span></p>
                        </div>
                        <div class="tabtype">
                            <ul>
                                <li id="ss" class="hover"><a href="javascript:void(0)" onclick="HisLottSwitch('s')">双色球</a></li>
                                <li id="sd"><a href="javascript:void(0)" onclick="HisLottSwitch('d')">福彩3D</a></li>
                                <li id="ps"><a href="javascript:void(0)" onclick="HisLottSwitch('p')">排列三</a></li>
                            </ul>
                            <span class="right-type">（小贴士：点击期数可查看当期预测详情）</span>
                        </div>
                        <div class="main-title1">
                            <div class="title-middle">
                               <div class="title-text title-text-l">
                            【<span id="s_uName" style="text-decoration: underline; color: red;"></span>】<span id="s_lottName"> 双色球</span>历史成绩</div>
                                <div class="cyc_bai title-text-r">
                                    历史近
                            <select id="issueNum" name="">
                                <option value="10">10</option>
                                <option value="15" selected="selected">15</option>
                                <option value="30">30</option>
                                <option value="50">50</option>
                            </select>
                            期
                                    </div>
                            </div>
                        </div>
                        <div id="div_cond" class="cyc_leftb">
                            
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
