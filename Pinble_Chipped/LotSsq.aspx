<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotSsq.aspx.cs" Inherits="Pinble_Chipped.LotSsq" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>双色球</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link rel="stylesheet" type="text/css" href="cssNew/global.css" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link rel="stylesheet" type="text/css" href="Css/lotterycss.css" />
    <link href="Css/lottery.css" rel="stylesheet" type="text/css" />
    <link href="cssNew/buy.css" rel="stylesheet" type="text/css" />
    <link href="Css/public.css" rel="stylesheet" type="text/css" />
    <link href="cssNew/hmbuy.css" rel="stylesheet" type="text/css" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link href="Css/footer.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script type="text/javascript" charset="gb2312" src="js/lHandls.js?date=new date().gettime()"></script>
    <script language="javascript" type="text/javascript" charset="gb2312" src="js/lottFun.js?date=new date().gettime()"></script>
    <script language="javascript" type="text/javascript" charset="gb2312" src="js/public.js?date=new date().gettime()"></script>
    <script src="js/dqxh.js?date=new date().gettime()" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".J_SelectBuyMethod").click(function () {
                $("#ssq_fs").attr("class", "uchoose");
                $("#ssq_dt").attr("class", "uchoose");
                $("#ssq_sc").attr("class", "uchoose");
                $("#ssq_sd").attr("class", "uchoose");
                $("#ssq_dqxh").attr("class", "uchoose");

                if ($("input[name='a']:checked").val() == "fs") {
                    //默认选中代购
                    $("#rad_purchasing").attr("checked", "dg");
                    $("#ssq_fs").attr("class", "choose");
                    document.getElementById("fsy").style.display = "block";
                    document.getElementById("scy").style.display = "none";
                    document.getElementById("dty").style.display = "none";
                    document.getElementById("fsTab").style.display = "block";
                    document.getElementById("dqxh_1").style.display = "none";
                    document.getElementById("betting").style.display = "block";
                    //显示号码区
                    $("#hmq").show();
                    $("#hmq1").show();
                    $("#hmq2").show();
                    //隐藏手动收入区
                    document.getElementById("sdsrh").style.display = "none";
                    document.getElementById("dis_mon").style.display = "block";

                }
                if ($("input[name='a']:checked").val() == "sc") {
                    $("#ssq_sc").attr("class", "choose");
                    document.getElementById("scy").style.display = "block";
                    document.getElementById("fsy").style.display = "none";
                    document.getElementById("dty").style.display = "none";
                    document.getElementById("dqxh_1").style.display = "none";
                    document.getElementById("betting").style.display = "block";
                    document.getElementById("dis_mon").style.display = "block";


                }
                if ($("input[name='a']:checked").val() == "dt") {

                    $("#ssq_dt").attr("class", "choose");
                    document.getElementById("scy").style.display = "none";
                    document.getElementById("fsTab").style.display = "none";
                    document.getElementById("dty").style.display = "block";
                    document.getElementById("betting").style.display = "block";
                    document.getElementById("dqxh_1").style.display = "none";
                    document.getElementById("dis_mon").style.display = "block";
                    document.getElementById("fsy").style.display = "block";

                }
                //手动输入号码
                if ($("input[name='a']:checked").val() == "sd") {
                    $("#ssq_sd").attr("class", "choose");
                    //隐藏号码区
                    $("#hmq").hide();
                    $("#hmq1").hide();
                    $("#hmq2").hide();
                    document.getElementById("scy").style.display = "none";
                    document.getElementById("dty").style.display = "none";
                    document.getElementById("fsTab").style.display = "block";
                    //显示手动输入区
                    document.getElementById("sdsrh").style.display = "block";
                    document.getElementById("betting").style.display = "block";
                    //显示所有的区域
                    document.getElementById("fsy").style.display = "block";
                    document.getElementById("dis_mon").style.display = "block";
                    document.getElementById("dqxh_1").style.display = "none";
                }

                //选择多期选号
                if ($("input[name='a']:checked").val() == "dqxh") {
                    $("#ssq_dqxh").attr("class", "choose");
                    //隐藏说明区
                    document.getElementById("fsy").style.display = "none";
                    //隐藏号码区
                    document.getElementById("scy").style.display = "none";
                    document.getElementById("betting").style.display = "none";
                    document.getElementById("dqxh_1").style.display = "block";
                    //隐藏合买信息区
                    document.getElementById("dis_mon").style.display = "none";
                    //隐藏追号显示区
                    document.getElementById("AfterNum").style.display = "none";
                    //隐藏公共选号区
                    document.getElementById("chipped").style.display = "none";

                    Insertdqxh();
                }


            });

        });
        function returnstate() { }
    </script>
    <style type="text/css">
        /*选号球样式*/
        .numberh
        {
            line-height: 24px;
            width: 28px;
            height: 28px;
            text-align: center;
            font-size: 14px;
            font-weight: bold;
            color: #fff;
            cursor: pointer;
            float: left;
            margin: 8px 0px 0px 7px;
            display: inline;
            background-image: url(../image/red.png);
            background-repeat: no-repeat;
        }
        .number
        {
            line-height: 24px;
            width: 28px;
            height: 28px;
            text-align: center;
            font-size: 14px;
            font-weight: bold;
            color: #3e3f3f;
            cursor: pointer;
            float: left;
            display: inline;
            margin-top: 8px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 7px;
            background-image: url(../image/yellow.png);
            background-repeat: no-repeat;
        }
        
        .numberl
        {
            line-height: 24px;
            width: 28px;
            height: 28px;
            text-align: center;
            font-size: 14px;
            font-weight: bold;
            color: #fff;
            cursor: pointer;
            float: left;
            display: inline;
            margin-top: 8px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 7px;
            background-image: url(../image/blue.png);
            background-repeat: no-repeat;
        }
        /*新增的样式*/
        .login_info
        {
            position: absolute;
            top: 15px;
            right: 100px;
            color: #333;
            font-family: "微软雅黑";
            float: right;
        }
        .login_info em
        {
            padding: 0 11px;
            color: #ccc;
        }
        .choose
        {
            vertical-align: top;
            margin-left: 3px;
            color: #FF0000;
            margin-right: 20px;
            font-weight: bold;
        }
        .uchoose
        {
            vertical-align: top;
            margin-left: 3px;
            margin-right: 20px;
        }
    </style>
    <!--多期机选开始部分-->
    <style type="text/css">
        .input1
        {
            width: 35px;
            height: 18px;
            color: #FF0000;
            font-weight: bold;
            border: 1px solid #cccccc;
        }
        .sel_table
        {
            border: 1px #ccccc solid;
            width: 100%;
        }
        .sel_table th
        {
            background: #f5f5f5;
            border-bottom: 1px solid #ccc;
            padding-right: 10px;
            border-right: 1px #f3f3f3 solid;
        }
        .sel_table td
        {
            border-bottom: 1px solid #ccc;
            padding: 12px;
            padding-left: 20px;
        }
    </style>
</head>
<body class="cur-ssq">
    <form id="form1" runat="server">
    <div id="page">
        <div class="grid-c2-s6f">
            <div class="b-top">
                <div class="b-top-inner">
                    <h2 class="ssq-logo">
                        双色球</h2>
                    <div class="b-top-info">
                        <a href="javascript:void 0" title="" class="on">第<%=Pbzx.BLL.publicMethod.Period("FCSSData") %>期</a><span>开奖时间：<%--<%= Pbzx.BLL.publicMethod.lotteryNameData("FCSSData")%>--%>
                           每周二、四、日 21:30开奖</span>
                    </div>
                    <!--新增的用户信息部分-->
                    <div class="login_info">
                        <uc2:login ID="login1" runat="server" />
                    </div>
                    <dl class="b-top-nav">
                        <dt><a href="javascript:ChangeColor('xuanhao')" title="" class="on" id="xuanhao">选号投注</a>
                            <a href="javascript:ChangeColor('canyu')" title="" class="" id="canyu">参与合买</a>
                            <a href="javascript:ChangeColor('dingzhi_ssq')" title="" class="" id="dingzhi" style="display: none">定制跟单</a>
                            <a href="javascript:ChangeColor('fanan_ssq')" title="" class="" id="fangan">我的方案</a>
                        </dt>
                        <dd id="playTabsDd">
                            <%--<a href="#" title="" class="on"><em>自助选号</em></a> <a href="#" title=""><em>多期机选</em></a>--%>
                        </dd>
                    </dl>
                    <div class="b-top-tips">
                        <div class="b-top-ql">
                            .
                        </div>
                        <div class="b-top-time">
                            截止时间： <span id="endtimeSpan">
                                <%=Pbzx.Common.Method.GetSSQDateTime.ToString() %>
                            </span>
                            <%--<input id="txt_time" type="text" value="" />--%>
                            <span id="countDownSpan">还剩 <span id="_lefttime" style="color: Red"></span></span>
                            <script type="text/javascript">
                                function _fresh() {

                                    //结束时间取配置文件中的数据                                    
                                    var endtime = new Date("<%=Pbzx.Common.Method.GetSSQDateTime.ToString() %>".replace(/-/g, "/"));

                                    var nowtime = new Date();
                                    var leftsecond = parseInt((endtime.getTime() - nowtime.getTime()) / 1000);
                                    if (leftsecond < 0) { leftsecond = 0; }
                                    __d = parseInt(leftsecond / 3600 / 24);
                                    __h = parseInt((leftsecond / 3600) % 24);
                                    __m = parseInt((leftsecond / 60) % 24);
                                    __s = parseInt(leftsecond % 60);
                                    __all = __d + "天" + __h + "小时" + __m + "分" + __s + "秒";
                                    document.getElementById("_lefttime").innerHTML = __all;

                                }
                                _fresh()
                                setInterval(_fresh, 1000);
                            </script>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-main">
                <div id="Large">
                    <div class="main-wrap">
                        <div class="box draw-box single-buy">
                            <!--detail-info:投注详细内容块,该class页面内唯一 start-->
                            <div class="detail-info">
                                <!--不同选号方式的tab-->
                                <div id="J_SelectNumTab" class="cp-tab">
                                    <div class="cp-subnav">
                                        <div class="tab-subcontent">
                                            <div class="tab-pannel">
                                                <label class="cp-typecheck">
                                                    <input class="J_SelectBuyMethod" name="a" type="radio" value="fs" checked="checked" />
                                                    <span id="ssq_fs" class="choose">普通</span></label>
                                                <label class="cp-typecheck">
                                                    <input class="J_SelectBuyMethod" name="a" type="radio" value="dt" />
                                                    <span id="ssq_dt" class="uchoose">胆拖</span></label>
                                                <label class="cp-typecheck" style="display: none">
                                                    <input class="J_SelectBuyMethod" name="a" type="radio" value="sc" />
                                                    <span id="ssq_sc" class="uchoose">上传</span></label>
                                                <label class="cp-typecheck">
                                                    <input class="J_SelectBuyMethod" name="a" type="radio" value="sd" />
                                                    <span id="ssq_sd" class="uchoose">手动输入</span></label>
                                                <label class="cp-typecheck">
                                                    <input class="J_SelectBuyMethod" name="a" type="radio" value="dqxh" />
                                                    <span id="ssq_dqxh" class="uchoose">多期机选</span></label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="uploadTips" style="display: none" rel="提示说明文字">
                                        玩法提示：选择1-5个你认为必出的红球号码（胆码）、2个以上你认为可能会出的红球号码（拖码）、至少一个蓝球号码组合进行投注。</div>
                                    <div class="uploadTips" style="display: none" rel="提示说明文字">
                                        玩法提示：至少选择6个红球，1个蓝球
                                    </div>
                                    <!-- start 复式 -->
                                    <div class="buy-box" id="fsy">
                                        <table class="J_BallArea ball-area" border="0" width="80%" border="0" cellspacing="0"
                                            cellpadding="0" id="fsTab">
                                            <tr id="hmq">
                                                <th class="th1">
                                                    &nbsp;
                                                </th>
                                                <td class="td1">
                                                    <p class="select-tips" id="J_RedSelectTips">
                                                        <span class="wrapper">[红球区&nbsp;至少选择6个红球 ]</span></p>
                                                </td>
                                                <td class="td2">
                                                    <p class="select-assist-tips">
                                                        <span class="blueWraper" id="J_BlueWeaper">[ 蓝球区&nbsp;至少选择1个蓝球]</span></p>
                                                </td>
                                            </tr>
                                            <tr class="ball-line J_BallLine" id="hmq1">
                                                <th class="th1">
                                                    <div class="txt-select">
                                                        选择号码</div>
                                                    &nbsp;
                                                </th>
                                                <td class="td1">
                                                    <ul class="ball-list red J_BallList" id="J_RedRandHook">
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">01</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">02</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">03</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">04</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">05</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">06</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">07</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">08</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">09</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">10</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">11</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">12</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">13</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">14</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">15</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">16</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">17</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">18</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">19</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">20</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">21</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">22</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">23</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">24</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">25</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">26</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">27</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">28</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">29</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">30</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">31</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">32</span></li>
                                                        <li><span onclick="xuanhao(this,'h');" id="hongqiu" name="hongqiu" class="number"
                                                            style="cursor: pointer;">33</span></li>
                                                    </ul>
                                                </td>
                                                <td class="td2">
                                                    <ul class="ball-list blue J_BallList" id="J_BlueRandHook">
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            01</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            02</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            03</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            04</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            05</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            06</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            07</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            08</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            09</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            10</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            11</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            12</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            13</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            14</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            15</span></li>
                                                        <li><span onclick="xuanhao(this,'l');" id="lanqiu" name="lanqiu" class="number" style="cursor: pointer;">
                                                            16</span></li>
                                                    </ul>
                                                </td>
                                            </tr>
                                            <tr id="hmq2">
                                                <td>
                                                </td>
                                                <td>
                                                    <div class="alignRight">
                                                        <select id="J_JxRedNum">
                                                            <option value="6">6</option>
                                                            <option value="7">7</option>
                                                            <option value="8">8</option>
                                                            <option value="9">9</option>
                                                            <option value="10">10</option>
                                                            <option value="11">11</option>
                                                            <option value="12">12</option>
                                                            <option value="13">13</option>
                                                            <option value="14">14</option>
                                                            <option value="15">15</option>
                                                            <option value="16">16</option>
                                                            <option value="17">17</option>
                                                            <option value="18">18</option>
                                                            <option value="19">19</option>
                                                            <option value="20">20</option>
                                                        </select>
                                                        <input type="button" class="jxRedBtn" id="J_JxRedBtn" value="机选红球" onclick="jxhq('h');" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="alignRight">
                                                        <select id="J_JxBlueNum">
                                                            <option value="1">1</option>
                                                            <option value="2">2</option>
                                                            <option value="3">3</option>
                                                            <option value="4">4</option>
                                                            <option value="5">5</option>
                                                            <option value="6">6</option>
                                                            <option value="7">7</option>
                                                            <option value="8">8</option>
                                                            <option value="9">9</option>
                                                            <option value="10">10</option>
                                                            <option value="11">11</option>
                                                            <option value="12">12</option>
                                                            <option value="13">13</option>
                                                            <option value="14">14</option>
                                                            <option value="15">15</option>
                                                            <option value="16">16</option>
                                                        </select>
                                                        <input type="button" class="jxBlueBtn" id="J_JxBlueBtn" value="机选蓝球" onclick="jxhq('l');" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <!--手动输入框-->
                                                    <div id="sdsrh" style="width: 100%; margin-left: 20px; display: none">
                                                        <textarea id="tb_ManualInput" cols="20" rows="2" style="width: 450px; height: 150px;
                                                            float: left; margin-right: 30px;" onkeyup="DisNum();"></textarea>
                                                        <div style="font-size: 14px; color: #FF0000; font-weight: bold;">
                                                            号码输入方式：红球与蓝球之间用减号“-”间隔。<br />
                                                        </div>
                                                        <span class="bigfont">1、把号码写入左边文本框内；<br />
                                                            2、从彩神通软件编辑器内复制投注的号码到左边文本框内；<br />
                                                            3、从你的文档中直接复制投注的号码到左边文本框内；<br />
                                                            4、从其他网页复制投注的号码到左边文本框内。<br />
                                                            <br />
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <div class="select-count-tips">
                                                        <p class="wrapper">
                                                            [ 您一共选择了 <em id="danbeizhushu">0</em> 注，共 <em class="money" id="danbeimoney">0</em>
                                                            元 ]</p>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- End 复式 -->
                                        <!-- start 胆拖 -->
                                        <table style="display: none;" class="J_BallArea ball-area method-dt" border="0" cellspacing="0"
                                            cellpadding="0" id="dty">
                                            <tr>
                                                <td colspan="3" class="uploadTips">
                                                    玩法提示：选择1-5个你认为必出的红球号码（胆码）、2个以上你认为可能会出的红球号码（拖码）、至少一个蓝球号码组合进行投注。
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="th1">
                                                    &nbsp;
                                                </th>
                                                <td width="750px">
                                                    <p class="select-tips" id="J_RedDanSelectTips">
                                                        <span class="wrapper">[ <em>胆码区 我认为必出的红球</em>&nbsp;至少选择1个，最多5个 ]</span></p>
                                                </td>
                                            </tr>
                                            <tr class="ball-line J_BallLine">
                                                <th class="th3">
                                                    <div class="txt-select">
                                                        红球胆码</div>
                                                </th>
                                                <td>
                                                    <ul class="ball-list red J_BallList">
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">01</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">02</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">03</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">04</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">05</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">06</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">07</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">08</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">09</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">10</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">11</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">12</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">13</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">14</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">15</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">16</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">17</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">18</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">19</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">20</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">21</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">22</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">23</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">24</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">25</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">26</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">27</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">28</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">29</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">30</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">31</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">32</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="hdanma" name="hdanma" class="number"
                                                            style="cursor: pointer;">33</span></li>
                                                    </ul>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="th1">
                                                    &nbsp;
                                                </th>
                                                <td colspan="2">
                                                    <p class="select-assist-tips" id="J_RedTuoSelectTips">
                                                        <span class="wrapper">[ <em>拖码区 我认为可能出的红球</em>&nbsp;至少选择2个 ]</span></p>
                                                </td>
                                            </tr>
                                            <tr class="ball-line J_BallLine J_RedDtBallLine">
                                                <th class="th3">
                                                    <div class="txt-select">
                                                        红球拖码</div>
                                                </th>
                                                <td>
                                                    <ul class="ball-list red J_BallList">
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">01</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">02</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">03</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">04</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">05</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">06</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">07</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">08</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">09</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">10</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">11</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">12</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">13</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">14</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">15</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">16</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">17</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">18</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">19</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">20</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">21</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">22</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">23</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">24</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">25</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">26</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">27</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">28</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">29</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">30</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">31</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">32</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dh');" id="htuma" name="htuma" class="number"
                                                            style="cursor: pointer;">33</span></li>
                                                    </ul>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="th1">
                                                    &nbsp;
                                                </th>
                                                <td colspan="2">
                                                    <p class="select-assist-tips">
                                                        <span class="blueWraper" id="J_BlueDantuoWeaper">[ <em>蓝球区</em>&nbsp;至少选择1个蓝球 ]</span></p>
                                                </td>
                                            </tr>
                                            <tr class="ball-line J_BallLine">
                                                <th class="th3">
                                                    <em class="txt-select">蓝球</em>
                                                </th>
                                                <td class="td2">
                                                    <ul class="ball-list blue J_BallList">
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            01</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            02</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            03</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            04</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            05</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            06</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            07</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            08</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            09</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            10</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            11</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            12</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            13</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            14</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            15</span></li>
                                                        <li><span onclick="DTxuanhao(this,'dl');" id="lq" name="lq" class="number" style="cursor: pointer;">
                                                            16</span></li>
                                                    </ul>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <div class="select-count-tips">
                                                        <p class="wrapper">
                                                            [ <em id="J_PreDantuoSize">0</em> 个红球(<span id="J_PreDanSize">0</span>个胆码,<span id="J_PreTuoSize">0</span>个拖码)，<em
                                                                id="J_PreDantuoBlueSize">0</em> 个蓝球，共 <em id="J_PreDantuoMulti">0</em> 注，金额
                                                            <em class="money" id="J_PreDantuoMoney">0</em> 元 ]</p>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- End 胆拖 -->
                                        <!--公共部分start-->
                                        <!--操作选号-->
                                        <div id="J_operateSelect" class="operate-select">
                                            <span id="J_operateSelectSpan"><a class="add-select-to-list" href="javascript:void(null);"
                                                onclick="Insert()">添加选号到投注列表</a> <a class="clear-select" href="javascript:void(null);"
                                                    onclick="clearall()"></a></span>
                                        </div>
                                        <a name="UnitedAnchor"></a><a name="numsAnchor"></a>
                                        <!--选号列表&操作选号列表-->
                                        <div class="num-list">
                                            <select name="schemeNum" id="schemeNum" size="5" class="select-list" style="height: 132px">
                                            </select>
                                            <ul class="liebiao">
                                                <li class="random-one"><a href="javascript:void(null);" onclick="jixuan(1)">机选1注</a></li>
                                                <li class="random-five"><a href="javascript:void(null);" onclick="jixuan(6)">机选6注</a></li>
                                                <li class="random-one"><a href="javascript:void(null);" onclick="jixuan(2)">机选2注</a></li>
                                                <li class="random-five"><a href="javascript:void(null);" onclick="jixuan(8)">机选8注</a></li>
                                                <li class="random-one"><a href="javascript:void(null);" onclick="jixuan(4)">机选4注</a></li>
                                                <li class="random-five"><a href="javascript:void(null);" onclick="jixuan(10)">机选10注</a></li>
                                                <li class="modify-one"><a href="javascript:returnstate();" class="btn_blue" onclick="Del_S()">
                                                    删除单注</a></li>
                                                <li class="clear-list"><a href="javascript:returnstate();" class="btn_blue" onclick="clearNum()">
                                                    清空号码</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!--文件上传部分start-->
                                    <div style="display: none" class="J_BallArea ball-area method-upload" id="scy">
                                        <!-- 文件上传 -->
                                        <input id="File1" type="file" />
                                        <strong class="tit">双色球文件上传的规则</strong><a class="demostrate J_ReturnClass" href="#"
                                            target="_blank">下载文件示例</a>
                                        <p class="">
                                            1、文档必须是.txt格式，不能超过250k<br />
                                            2、一行一个投注号<br />
                                            3、只支持单式号码上传<br />
                                            4、号码之间以单个分隔符分隔(允许的分隔符包括空格、逗号、短横线)，每个号码为2位数字<br />
                                            5、红球和蓝球间用加号或冒号分隔。如果文件中没有蓝球，可以指定蓝球<br />
                                        </p>
                                    </div>
                                    <!--文件上传部分end-->
                                </div>
                            </div>
                        </div>
                        <div class="more-operate" id="dis_mon">
                            <p class="multi-buy" id="J_MultiBuyDiv">
                                倍投：<input type="text" size="5" class="red" name="setbeishu" id="setbeishu" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                                    onbeforepaste="BeforePaste();" value="1" />倍( 最大99倍 )</p>
                            <p class="stake-count" id="J_StakeCountDiv">
                                注数：<em id="showdanbeizhushu">0</em> 注</p>
                            <p class="stake-count" id="J_StakeCountDiv1">
                                <span class="red" id="showbeishu">1</span>倍</p>
                            <p class="select-amount" id="J_SelectAmountDiv">
                                金额：<em class="money" id="showallmoney">0</em> 元</p>
                            <label class="stop-after-win" id="J_UnitedBtnLabel">
                                <input id="rad_purchasing" type="radio" name="buy" checked="checked" onclick="switchs()"
                                    value="dg" /><em class="h">代购</em>
                            </label>
                            <label class="follow" id="J_PursueBtnLabel">
                                <input id="rad_chipped" type="radio" name="buy" onclick="switchs()" value="hm" /><em
                                    class="h">发起合买</em></label>
                            <label class="follow" id="lab_TrackNum">
                                <input id="TrackNum" type="radio" name="buy" onclick="switchs()" value="track" /><em
                                    class="h">追号</em></label>
                        </div>
                        <!------追号显示期号部分------>
                        <div id="AfterNum" class="confirm" style="display: none">
                            <table class="sel_table">
                                <tr>
                                    <th align="right">
                                        <label>
                                            自动跟单期数：</label>
                                    </th>
                                    <td colspan="2" align="left">
                                        <select name="qs" class="zh_sel" id="sel_track">
                                            <option value="10" selected="selected">10期</option>
                                            <option value="20">20期</option>
                                            <option value="30">30期</option>
                                            <option value="40">40期</option>
                                            <option value="50">50期</option>
                                            <option value="60">60期</option>
                                            <option value="70">70期</option>
                                            <option value="80">80期</option>
                                            <option value="90">90期</option>
                                            <option value="100">100期</option>
                                        </select>
                                        <div class="zh_qihao" id="div_track" style="width: 90%; height: 230px; border: 1px solid #ccc;
                                            margin-top: 5px; overflow-y: scroll;">
                                            选择期号列表
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <label>
                                            结束条件：</label>
                                    </th>
                                    <td colspan="2" align="left">
                                        <input id="zh_bonus" type="checkbox" />&nbsp;&nbsp;单期奖金≥
                                        <input id="zh_money" type="text" class="input1" style="width: 75px;" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" />
                                        元终止追号
                                        <br />
                                        <%--<input name="" type="checkbox" value="begin" />&nbsp;&nbsp;跟单余额不足短信提示<br />
                                        <input name="" type="checkbox" value="end" id="Checkbox4" />&nbsp;&nbsp;任务结束短信提示。--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!------追号显示期号部分------>
                        <!--公共部分end-->
                        <div id="chipped" style="display: none;" class="united-buy-plan">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>方案标题：</em></label>
                                    </td>
                                    <td>
                                        <em class="h">*</em>
                                        <input type="text" id="J_UnitedTitle" value="" class="plan-title txt" onkeypress="checkLen(this)"
                                            onkeyup="checkLen(this)" onchange="checkLen(this)" />&nbsp;<span class="notice">您还可输入<span
                                                id="J_UnitedTitleLen" style="color: Red">0</span>个字符，最多30个</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>方案宣言：</em></label>
                                    </td>
                                    <td>
                                        <textarea id="mytext" cols="" rows="5" class="plan-des" onkeydown="limitChars('mytext', 50)"
                                            onchange="limitChars('mytext', 50)" onpropertychange="limitChars('mytext', 50)"></textarea>&nbsp;
                                        <span class="notice">您还可输入<span id="J_UnitedDescLen">0</span>个字符，最多50个</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>提成：</em></label>
                                    </td>
                                    <td>
                                        <select id="proportion" class="prize-brokerage txt J_MultiText">
                                            <option selected="selected" value="0">0</option>
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            <option value="6">6</option>
                                            <option value="7">7</option>
                                            <option value="8">8</option>
                                            <option value="9">9</option>
                                            <option value="10">10</option>
                                        </select>
                                        % <span class="notice">(提成为1-10的整数，设置提成后至少认购与提成相等比例份额，无提成就选择0)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>我要分为：</em></label>
                                    </td>
                                    <td>
                                        <input size="5" id="txt_copy" type="text" class="fall-into  txt J_MultiText" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                                            onbeforepaste="BeforePaste();" value="1" />
                                        份，每份￥<span class="money" id="lab_money">0</span>元 <span class="notice">(每份至少0.2元，且必须能整除到分)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>我要认购：</em></label>
                                    </td>
                                    <td>
                                        <em class="h">*</em>
                                        <input size="5" id="txt_pcopy" class="take-up txt J_MultiText" type="text" style="width: 50px"
                                            onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();" onbeforepaste="BeforePaste();"
                                            value="1" />
                                        份 共计￥<span class="money" id="money">0</span>元 <span class="notice">(至少要认购<span id="J_UniteBuyMinSubscribeCent">1</span>份)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>是否保密：</em></label>
                                    </td>
                                    <td>
                                        <input type="radio" name="isSecret" id="J_Secret_1" value="0" checked="checked" />
                                        公开<br />
                                        <input type="radio" name="isSecret" id="J_Secret_0" value="1" />
                                        相对保密 <span class="notice">(选号方案对未跟单人保密，开奖后公开)</span><br />
                                        <input type="radio" name="isSecret" id="J_Secret_2" value="2" />
                                        完全保密 <span class="notice">(选号方案对所有人保密，开奖后公开)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <label>
                                            <em>保底：</em></label>
                                    </td>
                                    <td>
                                        <input id="ck_protect" type="checkbox" onclick="protect()" />
                                        我要保底：
                                        <input size="5" id="Text1" type="text" class="baodi txt J_MultiText" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                                            onbeforepaste="BeforePaste();" value="0" disabled="disabled" />
                                        份 共计￥<span class="money" id="num_money">0</span>元 <span class="notice">(不能大于总份数)</span>
                                        <a href="#" target="_blank" title="什么是保底？">
                                            <img src="images/1212.png" width="12" height="12" class="J_ReturnClass" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--投注按钮-->
                        <input type="hidden" name="textstr" id="textstr" />
                        <!-- 号码 （记录select里的text值）-->
                        <input type="hidden" name="valuestr" id="valuestr" />
                        <!-- 号码（记录select里的value值） -->
                        <input type="hidden" name="code" id="code" />
                        <!-- 临时号码（为选号时准备） -->
                        <input type="hidden" name="lotId" id="playName" value="3" />
                        <!-- 彩种ID（为提交投注准备）-->
                        <input type="hidden" name="playid" id="playid" value="3" />
                        <!-- 玩法ID（为提交投注准备） 双色球为3-->
                        <input type="hidden" name="source" value="0" />
                        <!-- 方案涞源 -->
                        <input type="hidden" name="allmoney" value="0" id="allmoney" />
                        <!-- 方案总金额（为提交投注准备） -->
                        <input type="hidden" name="danzhushu" value="0" id="danzhushu" />
                        <!-- 方案注数（为提交投注准备） -->
                        <input type="hidden" name="expect" id="ExpectNum" value="<%=ExpectNum %>" />
                        <!-- 方案期号（为提交投注准备） -->
                        <input type="hidden" name="beishu" value="1" id="beishu" />
                        <!-- 方案倍数（为提交投注准备） -->
                        <input type="hidden" name="fileorcode" id="fileorcode" />
                        <input type="hidden" name="endtime" id="endtime" value="<%=Pbzx.Common.Method.GetSSQDateTime.ToString() %>" />
                        <!-- 号码（为提交投注准备） -->
                        <div class="confirm" id="betting">
                            <p class="agree-clause">
                                <input name="" type="checkbox" value="" id="Checkbox2" checked="checked" />我已阅读了<a
                                    href="Agreement.aspx" target="_blank">《用户合买代购协议》</a>并同意其中条款
                            </p>
                            <div class="cfm-btn">
                                <button id="J_SubmitPay" onclick="return false">
                                </button>
                            </div>
                            <script type="text/javascript" language="javascript">
                                  <%=Pbzx.Common.Method.IsLottory(Pbzx.Common.Method.GetSSQDateTime.ToString()) %>
                            </script>
                        </div>
                    </div>
                    <%--多期选号--%>
                    <div id="dqxh_1" style="display: none">
                        <table class="sel_table">
                            <tr>
                                <th>
                                    <label>
                                        单期注数：</label>
                                </th>
                                <td>
                                    &nbsp; 每期机选：
                                    <input type="text" maxlength="2" id="txt_num" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'');Insertdqxh()" />注
                                    <input id="txt_multiple" type="text" style="width: 30px" maxlength="3" value="1"
                                        onkeyup="this.value=this.value.replace(/[^\d]/g,'');Insertdqxh()" />倍 根据您指定的注数(每期最多10注)，每期系统自动机选不同号码
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label>
                                        自动跟单期数：</label>
                                </th>
                                <td>
                                    <select name="qs" class="zh_sel" id="EXc">
                                        <option value="5" selected="selected">5期</option>
                                        <option value="10">10期</option>
                                        <option value="15">15期</option>
                                        <option value="20">20期</option>
                                        <option value="30">30期</option>
                                        <option value="50">50期</option>
                                    </select>
                                    <div class="zh_qihao" id="Exc_Display" style="width: 90%; height: 230px; overflow-y: scroll;">
                                        选择期号列表
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label>
                                        终止条件：</label>
                                </th>
                                <td>
                                    <input id="ck_end" type="checkbox" />单期奖金≥
                                    <input id="txt_money" type="text" maxlength="14" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" />
                                    元终止追号。说明：跟单余额不足当期自动中止。
                                    <br />
                                    <%--<input name="" type="checkbox" value="begin" />跟单余额不足短信提示<br />
                                    <input name="" type="checkbox" value="end" id="message" />任务结束短信提示。--%>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    确认购买：
                                </th>
                                <td>
                                    <div>
                                        <span id="username"></span>，您的账户余额为<font color="red">￥<asp:Label ID="lab_accMoney"
                                            runat="server">0</asp:Label>元</font>【账户充值】<br />
                                        本次投注金额为<span id="CurrentMoney"></span>元， 购买后您的账户余额为 <font color="red">￥<span id="user_Balance"></span>元</font><br />
                                        <input id="Checkbox1" type="checkbox" checked="checked" />我已阅读了<a href="Agreement.aspx"
                                            target="_blank">《用户合买代购协议》</a>并同意其中条款
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <input id="btn_Confirm" type="button" value="确认" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!--当前期号--->
                    <input id="preid" type="hidden" value='<%=Pbzx.BLL.publicMethod.Period("FCSSData")%>' />
                    <!------当前购买金额------->
                    <input id="curr_money" type="hidden" />
                </div>
                <%--合买方案begin--%>
                <div id="doc" style="display: none">
                    <div id="main">
                        <div class="content">
                            <div class="c-wrap">
                                <div class="c-inner">
                                    <div class="an_title p-l0">
                                        <ul class="l" id="stype_t">
                                            <li class="an_cur">全部方案</li>
                                        </ul>
                                       <%-- <span>置顶规则<s class="i-qw"></s> </span>--%>
                                    </div>
                                    <div class="c-search">
                                        <span class="l">
                                            <input type="text" id="findstr" class="c-s-txt" value="请输入用户名" onfocus="this.value=='请输入用户名'?this.value='':this.value"
                                                onblur="this.value==''?this.value='请输入用户名':this.value" onkeydown='enter_search(event)' /><input
                                                    type="button" name="srearch" class="m-r btn_Lblue_s" value="搜索" onclick="do_search(1,Y.one('#findstr').value)" />
                                            <span class="c-s-hot"></span></span>
                                    </div>
                                    <div id="n1">
                                        <div id="list_data">
                                            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                                                <asp:Repeater ID="rep_list" runat="server" OnItemDataBound="rep_list_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <td>
                                                                序号
                                                            </td>
                                                            <td>
                                                                发起人
                                                            </td>
                                                            <td>
                                                                战绩
                                                            </td>
                                                            <td>
                                                                彩种
                                                            </td>
                                                            <td>
                                                                期号
                                                            </td>
                                                            <td>
                                                                方案标题
                                                            </td>
                                                            <td>
                                                                方案金额
                                                            </td>
                                                            <td>
                                                                份数
                                                            </td>
                                                            <td>
                                                                每份金额
                                                            </td>
                                                            <td>
                                                                方案内容
                                                            </td>
                                                            <td>
                                                                方案进度
                                                            </td>
                                                            <td>
                                                                是否出票
                                                            </td>
                                                            <td>
                                                                剩余份数
                                                            </td>
                                                            <td>
                                                                认购份数
                                                            </td>
                                                            <td>
                                                                操作
                                                            </td>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                            <td>
                                                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                                            </td>
                                                            <td>
                                                                <a href="PersonalPage.aspx?name=<%# Eval("UserName") %>" target="mainFrame">
                                                                    <%# Eval("UserName") %>
                                                                </a>
                                                            </td>
                                                            <td>
                                                                战绩
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lab_LName" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <%# Eval("ExpectNum")%>
                                                            </td>
                                                            <td>
                                                                <font color="blue" title='<%# Eval("Title").ToString() %>'>
                                                                    <%# Pbzx.Common.Input.GetSubString(Eval("Title").ToString(),7) %></font>
                                                            </td>
                                                            <td>
                                                                <%# Eval("AtotalMoney") %>元
                                                            </td>
                                                            <td>
                                                                <%# Eval("Share")%>份
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lab_Each" runat="server"></asp:Label>元
                                                            </td>
                                                            <td>
                                                                <div id="Content" runat="server">
                                                                    <a href='javascript:void(0)' onclick="view('<%# Eval("ChoiceNum") %>')">查看</a>
                                                                </div>
                                                                <asp:Label ID="lab_Content" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lab_progress" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lab_ticket" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lab_surplus" runat="server"></asp:Label>份
                                                            </td>
                                                            <td>
                                                                <input id="txt_num_<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>"
                                                                    type="text" size="3" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" />
                                                            </td>
                                                            <td>
                                                                <div id="SchemeSpeed" runat="server">
                                                                    <input id="btn_cy_<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>"
                                                                        type="button" class="btn_cy" value="参与" onclick="state(txt_num_<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>,'<%# Eval("QNumber") %>');" />
                                                                    <a href="ParticiPation.aspx?num=<%# Eval("QNumber") %>&lottery=<%# Eval("playName") %>"
                                                                        target="_blank">详情</a>
                                                                </div>
                                                                <div id="dis" runat="server" visible="false">
                                                                    已完成
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <asp:Label ID="litContent" runat="server"></asp:Label></table>
                                        </div>
                                        <div id="changesize">
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                                PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                            </webdiyer:AspNetPager>
                                        </div>
                                        <div class="c-intro">
                                            <dl class="clearfix">
                                                <dt>战绩说明：</dt><dd><ul class="c-i-list">
                                                    <li>
                                                        <img src="" alt="" width="13" height="14" />
                                                        金杯：直选合买成功每中5注一等奖得一个金杯</li>
                                                </ul>
                                                </dd>
                                            </dl>
                                            <dl class="clearfix m-t20">
                                                <dt>*%+*%保： </dt>
                                                <dd>
                                                    <ol class="c-i-list">
                                                        <li>1）保指保底，保底是由发起人设定在合买截止时，如果方案尚未满员，将以保底时所承诺的金额最大限度的促进方案满员。保底金额最低为方案总金额的20%。</li>
                                                        <li>2）*%+*%保，指进度百分比+保底百分比。</li>
                                                    </ol>
                                                </dd>
                                            </dl>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--合买方案end--%>
                <%--定制跟单--%>
                <div class="c-wrap" id="Tracking" style="display: none">
                    <div id="tra">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                            <colgroup>
                                <col width="6%" />
                                <col width="10%" />
                                <col width="12%" />
                                <col width="12%" />
                                <col width="10%" />
                                <col width="10%" />
                                <col width="10%" />
                            </colgroup>
                            <tbody>
                                <tr class="">
                                    <th>
                                        排序
                                    </th>
                                    <th class="th_name">
                                        用户名
                                    </th>
                                    <th>
                                        <a href="#" title="">战绩</a>
                                    </th>
                                    <th class="fa_money">
                                        <a href="#" title="">累计中奖</a>
                                    </th>
                                    <th>
                                        被关注人次
                                    </th>
                                    <th>
                                        已订制人数
                                    </th>
                                    <th>
                                        订制跟单
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div id="Div3" style="text-align: center;">
                        <%--分页--%>
                    </div>
                </div>
                <%--定制跟单--%>
                <%--我的方案--%>
                <div id="Myproject" style="display: none;">
                    <%--我发布的方案begin--%>
                    <div class="c-wrap" style="margin-top: 5px;">
                        <div class="c-inner">
                            <div class="an_title p-l0">
                                <div class="an_title">
                                    我发布的方案
                                </div>
                            </div>
                            <div id="tab_MY">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                                    <colgroup>
                                        <col width="6%" />
                                        <col width="10%" />
                                        <col width="12%" />
                                        <col width="12%" />
                                        <col width="10%" />
                                        <col width="10%" />
                                    </colgroup>
                                    <tbody>
                                        <tr class="">
                                            <th>
                                                排序
                                            </th>
                                            <th class="th_name">
                                                发起人
                                            </th>
                                            <th>
                                                <a href="#" title="">战绩</a>
                                            </th>
                                            <th class="fa_money">
                                                <a href="#" title="">方案金额</a>
                                            </th>
                                            <th>
                                                方案内容
                                            </th>
                                            <th>
                                                是否成功
                                            </th>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="pagelist" style="text-align: center;">
                                <%--分页--%>
                            </div>
                        </div>
                    </div>
                    <%--我发布的方案end--%>
                    <%--我参与的方案begin--%>
                    <div class="c-wrap" style="margin-top: 5px;">
                        <div class="c-inner">
                            <div class="an_title p-l0">
                                <div class="an_title">
                                    我参与的方案
                                </div>
                            </div>
                            <div id="MY_pp">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                                    <tbody>
                                        <tr class="">
                                            <th>
                                                排序
                                            </th>
                                            <th class="th_name">
                                                发起人
                                            </th>
                                            <th>
                                                战绩
                                            </th>
                                            <th class="fa_money">
                                                方案金额
                                            </th>
                                            <th class="fa_money">
                                                每份金额
                                            </th>
                                            <th>
                                                方案内容
                                            </th>
                                            <th>
                                                进度
                                            </th>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="Div1" style="text-align: center;">
                                <%--分页--%>
                            </div>
                        </div>
                    </div>
                    <%--我参与的方案end--%>
                    <%--我关注的方案begin--%>
                    <div class="c-wrap" style="margin-top: 5px;">
                        <div class="c-inner">
                            <div class="an_title p-l0">
                                <div class="an_title">
                                    我关注的方案
                                </div>
                            </div>
                            <div id="my_Attention">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                                    <colgroup>
                                        <col width="6%" />
                                        <col width="14%" />
                                        <col width="12%" />
                                        <col width="12%" />
                                        <col width="10%" />
                                        <col width="10%" />
                                        <col width="8%" />
                                        <col width="10%" />
                                    </colgroup>
                                    <tbody>
                                        <tr class="">
                                            <th>
                                                排序
                                            </th>
                                            <th class="th_name">
                                                发起人
                                            </th>
                                            <th>
                                                战绩
                                            </th>
                                            <th class="fa_money">
                                                方案金额
                                            </th>
                                            <th class="fa_money">
                                                每份金额
                                            </th>
                                            <th>
                                                方案内容
                                            </th>
                                            <th>
                                                进度
                                            </th>
                                            <th>
                                                剩余份数
                                            </th>
                                        </tr>
                                        <tr class="">
                                            <td colspan="11">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="Div2" style="text-align: center;">
                                <%--分页--%>
                            </div>
                        </div>
                    </div>
                    <%--我关注的方案end--%>
                </div>
            </div>
        </div>
        <uc1:Footer ID="Footer1" runat="server"></uc1:Footer>
    </div>
    </form>
</body>
</html>
