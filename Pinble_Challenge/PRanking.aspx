<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRanking.aspx.cs" Inherits="Pinble_Challenge.PRanking" EnableViewState="false" %>

<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register src="Contorls/adv.ascx" tagname="adv" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>排行榜 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/Rel.js"></script>
    <script type="text/javascript" src="js/btnSwitch.js?date=new date().gettime()"></script>
    <style type="text/css">
        .exper-table var
        {
            background: url(images/nub.gif) no-repeat;
            color: #FFF;
            display: inline-block;
            font-style: normal;
            height: 16px;
            line-height: 16px;
            width: 16px;
        }
    </style>
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
        <uc3:Navigation ID="Navigation1" runat="server" />
    </div>
    <div class="yny_main">
        <div class="yny_neirong">
            <div class="yny_neirong_A">
            </div>
            <div class="yny_neirong_B">
                <div class="yny_zhongj">
                    <div class="all">
                        <div class="subtitle">
                            <p>
                                <span>当前位置：<span id="lottName">双色球</span>历史成绩</span></p>
                        </div>
                        <div class="tabtype">
                            <ul>
                                <li><a href="javascript:lottColorRank('ssq')" id="s" class="hover">双色球</a></li>
                                <li><a href="javascript:lottColorRank('fd')" id="d">福彩3D</a></li>
                                <li><a href="javascript:lottColorRank('pl')" id="p">排列三</a></li>
                            </ul>
                        </div>
                        <div class="main-title">
                            <div class="title-left">
                            </div>
                            <div class="title-middle">
                                <p class="title-text title-text-l">
                            <font color="red"><span id="Span1">双色球</span></font>成绩排行榜</p>
                                <div class="cyc_bai">
<%--                                     历史:
                            <select>
                                <option value="10">10</option>
                                <option value="15" selected='selected'>15</option>
                                <option value="30">30</option>
                            </select>&nbsp;期--%>
                                </div>
                               <div class="rank-type"><a href="javascript:void(0)" onclick="IntegralSwit()"><span id="hName" >切换到积分榜 </span> </a></div>
                                <p class="rule">
                                    <a href="/积分.xlsx">积分规则说明</a>   </p>
                            </div>
                            <div class="title-right">
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="mainbody">
                        <div id="perBank" class="zjphb_leftb">
                    
                        </div>
                    </div>
                </div>
            </div>
            <div class="yny_neirong_C">
            </div>
        </div>
        <div style="width: 100%; float: left; margin-top: 10px; height: 100px;">
        <div class="footer" style="clear: both;">
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </div>
    </div>

    
    <input id="state" type="hidden" value="achi" />
    </form>
</body>
</html>
