<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotSD.aspx.cs" Inherits="Pinble_Chipped.LotSD" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/login.ascx" TagName="login" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>3D合买代购</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link rel="stylesheet" type="text/css" href="cssNew/global.css" />
    <link href="cssNew/ballpannel.css" rel="stylesheet" type="text/css" />
    <link href="cssNew/hmbuy.css" rel="stylesheet" type="text/css" />
    <link href="Css/public.css" rel="stylesheet" type="text/css" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link href="cssNew/buy.css" rel="stylesheet" type="text/css" />
    <link href="Css/footer.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script language="javascript" type="text/javascript" charset="gb2312" src="js/LotSD.js?date=new date().gettime()"></script>
    <script type="text/javascript" charset="gb2312" src="js/public.js?date=new date().gettime()"></script>
    <script type="text/javascript" charset="gb2312" src="js/NHandls.js?date=new date().gettime()"></script>
    <style type="text/css"> 
	/*选号球样式*/
.numberh {
	line-height:24px;
    width:28px;
	height:28px;
	text-align:center;
	font-size:14px;
	font-weight:bold;
	color:#fff;
	cursor:pointer;
	float:left;
	margin: 8px 0px 0px 7px;
	display:inline;
	background-image: url(image/red.png);
	background-repeat: no-repeat;
}
.number {
	line-height:24px;
	width:28px;
	height:28px;
	text-align:center;
	font-size:14px;
	font-weight:bold;
	color:#3e3f3f;
	cursor:pointer;
	float:left;
	display:inline;
	margin-top: 8px;
	margin-right: 0px;
	margin-bottom: 0px;
	margin-left: 7px;
	background-image: url(image/yellow.png);
	background-repeat: no-repeat;
}
 
.numberl {
	line-height:24px;
	width:28px;
	height:28px;
	text-align:center;
	font-size:14px;
	font-weight:bold;
	color:#fff;
	cursor:pointer;
	float:left;
	display:inline;
	margin-top: 8px;
	margin-right: 0px;
	margin-bottom: 0px;
	margin-left: 7px;
	background-image: url(image/blue.png);
	background-repeat: no-repeat;
}
label{padding-right:10px;font-size:12px;font-weight:bold;color:#404040;}
label input{height:20px;line-height:20px;*line-height:17px;font-size:12px;color:#808080;}
.navchoose{ float:left}
.choose{vertical-align:top; margin-left:3px;color:#FF0000;margin-right:20px; font-weight:bold; }
.uchoose{vertical-align:top; margin-left:3px;margin-right:20px; }
 
/*新增的样式*/
.login_info{position:absolute;top:15px;right:100px;color:#333;font-family:"微软雅黑"; float:right}
.login_info em{padding:0 11px;color:#ccc;}
 
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
<body>
    <form id="form1" runat="server">
    <div id="doc3D" class="cp_3d">
        <!--头部开始-->
        <div class="b-top">
            <div class="b-top-inner">
                <h2 class="sd-logo">
                    福彩3D</h2>
                <div class="b-top-info">
                    <a href="javascript:void(0)" title="" class="on">第<%=Pbzx.BLL.publicMethod.Period("FC3DData")%>期</a><span>开奖时间：<%= Pbzx.BLL.publicMethod.lotteryNameData("FC3DData")%>
                        &nbsp; 20:30 </span>
                </div>
                <!--新增的用户信息部分-->
                <div class="login_info">
                    <uc2:login ID="login1" runat="server" />
                </div>
                <dl class="b-top-nav">
                    <dt><a href="javascript:ChangeColor('xuanhao')" title="" class="on" id="xuanhao">选号投注</a>
                        <a href="javascript:ChangeColor('canyu')" title="" class="" id="canyu">参与合买</a>
                        <a href="javascript:ChangeColor('dingzhi')" title="" class="" id="dingzhi" style="display: none">
                            定制跟单</a> <a href="javascript:ChangeColor('fanan_3D')" title="" class="" id="fangan">
                                我的方案</a> </dt>
                    <dd id="playTabsDd">
                        <div class="navchoose">
                            <input type="radio" name="Buytype" id="Buytype" value="zx" checked="checked" onclick="Eclear('zx')" /><span
                                id="zxid" class="choose">直选</span></div>
                        <div class="navchoose">
                            <input type="radio" name="Buytype" id="Buytype" value="zux" onclick="Eclear('zux')" /><span
                                id="zuxid" class="uchoose">组选</span></div>
                        <div class="navchoose">
                            <input type="radio" name="Buytype" id="Buytype" value="z3bh" onclick="Eclear('z3bh')" /><span
                                id="z3id" class="uchoose">组选三</span></div>
                        <div class="navchoose">
                            <input type="radio" name="Buytype" id="Buytype" value="zl" onclick="Eclear('zl')" /><span
                                id="z6id" class="uchoose">组选六</span></div>
                        <div class="navchoose" style="display: none">
                            <input type="radio" name="Buytype" id="Buytype" value="oneD" onclick="Eclear('oneD')" /><span
                                id="oneDs" class="uchoose">1D</span></div>
                        <div class="navchoose" style="display: none">
                            <input type="radio" name="Buytype" id="Buytype" value="twoD" onclick="Eclear('twoD')" /><span
                                id="twoD" class="uchoose">2D</span></div>
                        <div class="navchoose" style="display: none">
                            <input type="radio" name="Buytype" id="Buytype" value="TX" onclick="Eclear('TX')" /><span
                                id="TX" class="uchoose">通选</span></div>
                        <div class="navchoose" style="display: none">
                            <input type="radio" name="Buytype" id="Buytype" value="hsx" onclick="Eclear('HSX')" /><span
                                id="HSX" class="uchoose">和数选</span>
                        </div>
                    </dd>
                </dl>
                <div class="b-top-tips">
                    <div class="b-top-ql">
                        .
                    </div>
                    <div class="b-top-time">
                        截止时间： <span id="endtimeSpan">
                            <%= Pbzx.Common.Method.GetFCDateTime.ToString() %>
                        </span><span id="countDownSpan">还剩 <span id="_lefttime" style="color: Red"></span>
                        </span>
                        <%--倒计时器--%>
                        <script type="text/javascript">
                            function _fresh() {
                                //结束时间取配置文件中的数据                                    
                                var endtime = new Date("<%=Pbzx.Common.Method.GetFCDateTime.ToString() %>".replace(/-/g, "/"));

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
        <div id="Large">
            <!--二级目录部分-->
            <div id="J_mainav" class="cp-tab">
                <div id="J_subnav" class="cp-subnav">
                    <div class="tab-subcontent">
                        <div class="tab-pannel">
                            <!--直选-->
                            <label class="cp-typecheck">
                                <input class="J_SelectBuyMethod" name="a" type="radio" value="zixuan" checked="checked" />
                                <span>普通</span></label>
                            <label class="cp-typecheck">
                                <input class="J_SelectBuyMethod" name="a" type="radio" value="dt" />
                                <span>和值</span></label>
                            <label class="cp-typecheck" style="display: none">
                                <input class="J_SelectBuyMethod" name="a" type="radio" value="shangchuan" />
                                <span>上传</span></label>
                            <label class="cp-typecheck">
                                <input class="J_SelectBuyMethod" name="a" type="radio" value="sdsr" />
                                <span>手动输入</span></label>
                            <span class="cp-tip hidden" rel="提示说明文字">玩法提示</span>
                        </div>
                    </div>
                </div>
            </div>
            <!------组选3------->
            <div id="zx3" class="cp-tab" style="display: none">
                <div class="cp-subnav">
                    <div class="tab-subcontent">
                        <div class="tab-pannel">
                            <label class="cp-typecheck">
                                <input class="J_zx3" name="b" type="radio" value="zx3p" checked="checked" />
                                <span>普通</span></label>
                            <label class="cp-typecheck">
                                <input class="J_zx3" name="b" type="radio" value="zx3h" />
                                <span>和值</span></label>
                            <label class="cp-typecheck" style="display: none">
                                <input class="J_zx3" name="b" type="radio" value="zx3sc" />
                                <span>上传</span></label>
                            <label class="cp-typecheck">
                                <input class="J_zx3" name="b" type="radio" value="zx3sd" />
                                <span>手动输入</span></label>
                            <span class="cp-tip hidden" rel="提示说明文字">玩法提示</span>
                        </div>
                    </div>
                </div>
            </div>
            <!------组选3------->
            <!------组选6------->
            <div id="zx6" class="cp-tab" style="display: none">
                <div class="cu-subnav">
                    <div class="tab-subcontent">
                        <div class="tab-pannel">
                            <label class="cp-typecheck">
                                <input class="J_zx6" name="c" type="radio" value="zx6p" checked="checked" />
                                <span id="zx6p_1" class="choose">普通</span></label>
                            <label class="cp-typecheck">
                                <input class="J_zx6" name="c" type="radio" value="zx6hz" />
                                <span id="zx6hz_1" class="uchoose">和值</span></label>
                            <label class="cp-typecheck" style="display: none">
                                <input class="J_zx6" name="c" type="radio" value="zx6sc" />
                                <span id="zx6sc_1" class="uchoose">上传</span></label>
                            <label class="cp-typecheck" style="display: none">
                                <input class="J_zx6" name="c" type="radio" value="zx6sd" />
                                <span id="zx6sd_1" class="uchoose">手动输入</span></label>
                            <span class="cp-tip hidden" rel="提示说明文字">玩法提示</span>
                        </div>
                    </div>
                </div>
            </div>
            <!------组选6------->
            <!-------------1D、2D、通选---------------->
            <div id="oneD" class="cp-subnav" style="display: none">
                <div class="tab-subcontent">
                    <div class="tab-pannel">
                        <label class="cp-typecheck">
                            <input class="J_D" name="d" type="radio" value="ptD" checked="checked" />
                            <span class="uchoose" id="txp">普通</span></label>
                        <label class="cp-typecheck" id="shuru">
                            <input class="J_D" name="d" type="radio" value="ptDs" />
                            <span class="uchoose" id="txs">手动输入</span></label>
                        <span class="cp-tip hidden" rel="提示说明文字">玩法提示</span>
                    </div>
                </div>
                <div class="uploadTips" id="explain">
                    玩法提示:</div>
            </div>
            <!-------------1D、2D、通选---------------->
            <!---------------和数选------------------------->
            <div id="hsx" class="cp-subnav" style="display: none">
                <div class="tab-subcontent">
                    <div class="tab-pannel">
                        <label class="cp-typecheck">
                            <input class="J_hsx" name="e" type="radio" value="pthsx" checked="checked" />
                            <span class="choose">普通</span></label>
                        <label class="cp-typecheck" style="display: none">
                            <input class="J_hsx" name="e" type="radio" value="sdhsx" />
                            <span>手动输入</span></label>
                        <span class="cp-tip hidden" rel="提示说明文字">玩法提示</span>
                    </div>
                </div>
                <div class="uploadTips" id="Div5">
                    玩法提示:玩法提示：北京地区特有玩法，所选号码与开奖和值相同即中奖，和值不同对应的奖金也不同，查看<a href="javascript:void(0)" id="Bouns"
                        onclick="BounsControl()"> 奖金对照表</a></div>
            </div>
            <!---------------和数选-------------------------->
            <div id="hiddenT">
                <!--二级目录结束部分-->
                <!--直选普通选号盘开始-->
                <div id="touzhushow1" class="abacus  mode-2">
                    <div class="uploadTips" id="zxPrompt">
                        玩法提示：所选号码与开奖号码相同（且顺序一致）即中1000元</div>
                    <div class="hd" id="szhd">
                        <!--提示语区-->
                        <div class="main-tip" id="Prompt">
                            每位至少选择一个号码
                        </div>
                    </div>
                    <div class="bd">
                        <!--选球-->
                        <div id="xuanqiu" style="display: ">
                            <table width="80%" border="0" cellspacing="10" cellpadding="0">
                                <tr>
                                    <td>
                                        <div class="indicate">
                                            <span class="cp-digit">百 位</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div>
                                            <span class="number" id="three_haoma1" name="three_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">0</span> <span class="number" id="three_haoma1" name="three_haoma1"
                                                    style="cursor: pointer" onclick="xuanhao(this);">1</span> <span class="number" id="three_haoma1"
                                                        name="three_haoma1" style="cursor: pointer" onclick="xuanhao(this);">2</span>
                                            <span class="number" id="three_haoma1" name="three_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">3</span> <span class="number" id="three_haoma1" name="three_haoma1"
                                                    style="cursor: pointer" onclick="xuanhao(this);">4</span> <span class="number" id="three_haoma1"
                                                        name="three_haoma1" style="cursor: pointer" onclick="xuanhao(this);">5</span>
                                            <span class="number" id="three_haoma1" name="three_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">6</span> <span class="number" id="three_haoma1" name="three_haoma1"
                                                    style="cursor: pointer" onclick="xuanhao(this);">7</span> <span class="number" id="three_haoma1"
                                                        name="three_haoma1" style="cursor: pointer" onclick="xuanhao(this);">8</span>
                                            <span class="number" id="three_haoma1" name="three_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="help">
                                            <a class="cp-op all" href="javascript:selectcode(1,'selall');">全</a> <a class="cp-op big"
                                                href="javascript:selectcode(1,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(1,'selxiao');">
                                                    小</a> <a class="cp-op odd" href="javascript:selectcode(1,'seljin');">奇</a>
                                            <a class="cp-op even" href="javascript:selectcode(1,'selou');">偶</a> <a class="cp-op clear"
                                                href="javascript:selectcode(1,'delall');">清除</a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="indicate">
                                            <span class="cp-digit">十 位</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div>
                                            <span class="number" id="three_haoma2" name="three_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">0</span> <span class="number" id="three_haoma2" name="three_haoma2"
                                                    style="cursor: pointer" onclick="xuanhao(this);">1</span> <span class="number" id="three_haoma2"
                                                        name="three_haoma2" style="cursor: pointer" onclick="xuanhao(this);">2</span>
                                            <span class="number" id="three_haoma2" name="three_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">3</span> <span class="number" id="three_haoma2" name="three_haoma2"
                                                    style="cursor: pointer" onclick="xuanhao(this);">4</span> <span class="number" id="three_haoma2"
                                                        name="three_haoma2" style="cursor: pointer" onclick="xuanhao(this);">5</span>
                                            <span class="number" id="three_haoma2" name="three_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">6</span> <span class="number" id="three_haoma2" name="three_haoma2"
                                                    style="cursor: pointer" onclick="xuanhao(this);">7</span> <span class="number" id="three_haoma2"
                                                        name="three_haoma2" style="cursor: pointer" onclick="xuanhao(this);">8</span>
                                            <span class="number" id="three_haoma2" name="three_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="help">
                                            <a class="cp-op all" href="javascript:selectcode(2,'selall');">全</a> <a class="cp-op big"
                                                href="javascript:selectcode(2,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(2,'selxiao');">
                                                    小</a> <a class="cp-op odd" href="javascript:selectcode(2,'seljin');">奇</a>
                                            <a class="cp-op even" href="javascript:selectcode(2,'selou');">偶</a> <a class="cp-op clear"
                                                href="javascript:selectcode(2,'delall');">清除</a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="indicate">
                                            <span class="cp-digit">个 位</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div>
                                            <span class="number" id="three_haoma3" name="three_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">0</span> <span class="number" id="three_haoma3" name="three_haoma3"
                                                    style="cursor: pointer" onclick="xuanhao(this);">1</span> <span class="number" id="three_haoma3"
                                                        name="three_haoma3" style="cursor: pointer" onclick="xuanhao(this);">2</span>
                                            <span class="number" id="three_haoma3" name="three_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">3</span> <span class="number" id="three_haoma3" name="three_haoma3"
                                                    style="cursor: pointer" onclick="xuanhao(this);">4</span> <span class="number" id="three_haoma3"
                                                        name="three_haoma3" style="cursor: pointer" onclick="xuanhao(this);">5</span>
                                            <span class="number" id="three_haoma3" name="three_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">6</span> <span class="number" id="three_haoma3" name="three_haoma3"
                                                    style="cursor: pointer" onclick="xuanhao(this);">7</span> <span class="number" id="three_haoma3"
                                                        name="three_haoma3" style="cursor: pointer" onclick="xuanhao(this);">8</span>
                                            <span class="number" id="three_haoma3" name="three_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="help">
                                            <a class="cp-op all" href="javascript:selectcode(3,'selall');">全</a> <a class="cp-op big"
                                                href="javascript:selectcode(3,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(3,'selxiao');">
                                                    小</a> <a class="cp-op odd" href="javascript:selectcode(3,'seljin');">奇</a>
                                            <a class="cp-op even" href="javascript:selectcode(3,'selou');">偶</a> <a class="cp-op clear"
                                                href="javascript:selectcode(3,'delall');">清除</a>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-----和值选号区------->
                        <div class="row clearfix" style="display: none" id="touzhushow3">
                            <table width="80%" border="0" cellspacing="10" cellpadding="0">
                                <tr>
                                    <td>
                                        <!--1行-->
                                        <div class="indicate">
                                            <span class="cp-digit full">选择和值 </span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="main1">
                                            <div id="zxhz1">
                                                <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">0</span>
                                            </div>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">1</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">2</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">3</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">4</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">5</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">6</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">7</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">8</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">9</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">10</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">11</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">12</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">13</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">14</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">15</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">16</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">17</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">18</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">19</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">20</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">21</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">22</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">23</span> <span class="number" id="hezhi_haoma"
                                                        name="hezhi_haoma" style="cursor: pointer" onclick="xuanhao(this);">24</span>
                                            <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">25</span> <span class="number" id="hezhi_haoma" name="hezhi_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">26</span>
                                            <div id="zxhz2">
                                                <span class="number" id="hezhi_haoma" name="hezhi_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">27</span>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-----和值选号区------->
                    </div>
                    <!------组3 组6 选号区------->
                    <div id="zxxq">
                        <div id="zxhm" style="display: none">
                            <table width="100%" cellpadding="0">
                                <tr>
                                    <td>
                                        <span id="zxh"></span>
                                    </td>
                                    <td>
                                        <span class="number" id="three_haoma5" name="three_haoma5" style="cursor: pointer"
                                            onclick="xuanhao(this);">0</span> <span class="number" id="three_haoma5" name="three_haoma5"
                                                style="cursor: pointer" onclick="xuanhao(this);">1</span> <span class="number" id="three_haoma5"
                                                    name="three_haoma5" style="cursor: pointer" onclick="xuanhao(this);">2</span>
                                        <span class="number" id="three_haoma5" name="three_haoma5" style="cursor: pointer"
                                            onclick="xuanhao(this);">3</span> <span class="number" id="three_haoma5" name="three_haoma5"
                                                style="cursor: pointer" onclick="xuanhao(this);">4</span> <span class="number" id="three_haoma5"
                                                    name="three_haoma5" style="cursor: pointer" onclick="xuanhao(this);">5</span>
                                        <span class="number" id="three_haoma5" name="three_haoma5" style="cursor: pointer"
                                            onclick="xuanhao(this);">6</span> <span class="number" id="three_haoma5" name="three_haoma5"
                                                style="cursor: pointer" onclick="xuanhao(this);">7</span> <span class="number" id="three_haoma5"
                                                    name="three_haoma5" style="cursor: pointer" onclick="xuanhao(this);">8</span>
                                        <span class="number" id="three_haoma5" name="three_haoma5" style="cursor: pointer"
                                            onclick="xuanhao(this);">9</span>
                                    </td>
                                    <td>
                                        <div class="help">
                                            <a class="cp-op all" href="javascript:selectcode(5,'selall');">全</a> <a class="cp-op big"
                                                href="javascript:selectcode(5,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(5,'selxiao');">
                                                    小</a> <a class="cp-op odd" href="javascript:selectcode(5,'seljin');">奇</a>
                                            <a class="cp-op even" href="javascript:selectcode(5,'selou');">偶</a> <a class="cp-op clear"
                                                href="javascript:selectcode(5,'delall');">清除</a>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-----组选三和值选号区------->
                        <div class="row clearfix" style="display: none" id="z3hzxh">
                            <!--1行-->
                            <table width="70%">
                                <tr>
                                    <td>
                                        <!--1行-->
                                        <div class="indicate">
                                            <span class="cp-digit full">选择和值 </span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="main1">
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer; display: none"
                                                onclick="xuanhao(this);">0</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">1</span> <span class="number" id="zx_haoma"
                                                        name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">2</span>
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                3</span> <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">4</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">5</span> <span class="number" id="zx_haoma"
                                                            name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">6</span>
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                7</span> <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">8</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">9</span> <span class="number" id="zx_haoma"
                                                            name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">10</span>
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                11</span> <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">12</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">13</span> <span class="number" id="zx_haoma"
                                                            name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">14</span>
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                15</span> <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">16</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">17</span> <span class="number" id="zx_haoma"
                                                            name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">18</span>
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                19</span> <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">20</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">21</span> <span class="number" id="zx_haoma"
                                                            name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">22</span>
                                            <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                23</span> <span class="number" id="zx_haoma" name="zx_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">24</span> <span class="number" id="zx_haoma" name="zx_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">25</span> <span class="number" id="zx_haoma"
                                                            name="zx_haoma" style="cursor: pointer" onclick="xuanhao(this);">26</span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-----和值选号区------->
                        <!-----组选六和值选号区------->
                        <div class="row clearfix" style="display: none" id="xhz6">
                            <!--1行-->
                            <table width="70%">
                                <tr>
                                    <td>
                                        <div class="indicate">
                                            <span class="cp-digit full">选择和值 </span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="main1">
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer; display: none"
                                                onclick="xuanhao(this);">0</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                    style="cursor: pointer; display: none" onclick="xuanhao(this);">1</span>
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer; display: none"
                                                onclick="xuanhao(this);">2</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">3</span> <span class="number" id="zx6_haoma"
                                                        name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">4</span>
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                5</span> <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">6</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">7</span> <span class="number" id="zx6_haoma"
                                                            name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">8</span>
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                9</span> <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">10</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">11</span> <span class="number" id="zx6_haoma"
                                                            name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">12</span>
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                13</span> <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">14</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">15</span> <span class="number" id="zx6_haoma"
                                                            name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">16</span>
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                17</span> <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">18</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">19</span> <span class="number" id="zx6_haoma"
                                                            name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">20</span>
                                            <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                                21</span> <span class="number" id="zx6_haoma" name="zx6_haoma" style="cursor: pointer"
                                                    onclick="xuanhao(this);">22</span> <span class="number" id="zx6_haoma" name="zx6_haoma"
                                                        style="cursor: pointer" onclick="xuanhao(this);">23</span> <span class="number" id="zx6_haoma"
                                                            name="zx6_haoma" style="cursor: pointer" onclick="xuanhao(this);">24</span>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-----和值选号区------->
                    </div>
                    <!------组3 组6 选号区------->
                    <!------1D、2D、通选开始--------->
                    <div id="chooseD" style="display: none">
                        <table width="90%" border="0" cellspacing="10" cellpadding="0">
                            <tr>
                                <td>
                                    <div class="indicate">
                                        <span class="cp-digit">百 位</span>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <span class="number" id="D_haoma1" name="D_haoma1" style="cursor: pointer" onclick="xuanhao(this);">
                                            0</span> <span class="number" id="D_haoma1" name="D_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">1</span> <span class="number" id="D_haoma1" name="D_haoma1"
                                                    style="cursor: pointer" onclick="xuanhao(this);">2</span> <span class="number" id="D_haoma1"
                                                        name="D_haoma1" style="cursor: pointer" onclick="xuanhao(this);">3</span>
                                        <span class="number" id="D_haoma1" name="D_haoma1" style="cursor: pointer" onclick="xuanhao(this);">
                                            4</span> <span class="number" id="D_haoma1" name="D_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">5</span> <span class="number" id="D_haoma1" name="D_haoma1"
                                                    style="cursor: pointer" onclick="xuanhao(this);">6</span> <span class="number" id="D_haoma1"
                                                        name="D_haoma1" style="cursor: pointer" onclick="xuanhao(this);">7</span>
                                        <span class="number" id="D_haoma1" name="D_haoma1" style="cursor: pointer" onclick="xuanhao(this);">
                                            8</span> <span class="number" id="D_haoma1" name="D_haoma1" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="help">
                                        <a class="cp-op all" href="javascript:selectcode(1,'selall');">全</a> <a class="cp-op big"
                                            href="javascript:selectcode(1,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(1,'selxiao');">
                                                小</a> <a class="cp-op odd" href="javascript:selectcode(1,'seljin');">奇</a>
                                        <a class="cp-op even" href="javascript:selectcode(1,'selou');">偶</a> <a class="cp-op clear"
                                            href="javascript:selectcode(1,'delall');">清除</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="indicate">
                                        <span class="cp-digit">十 位</span>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <span class="number" id="D_haoma2" name="D_haoma2" style="cursor: pointer" onclick="xuanhao(this);">
                                            0</span> <span class="number" id="D_haoma2" name="D_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">1</span> <span class="number" id="D_haoma2" name="D_haoma2"
                                                    style="cursor: pointer" onclick="xuanhao(this);">2</span> <span class="number" id="D_haoma2"
                                                        name="D_haoma2" style="cursor: pointer" onclick="xuanhao(this);">3</span>
                                        <span class="number" id="D_haoma2" name="D_haoma2" style="cursor: pointer" onclick="xuanhao(this);">
                                            4</span> <span class="number" id="D_haoma2" name="D_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">5</span> <span class="number" id="D_haoma2" name="D_haoma2"
                                                    style="cursor: pointer" onclick="xuanhao(this);">6</span> <span class="number" id="D_haoma2"
                                                        name="D_haoma2" style="cursor: pointer" onclick="xuanhao(this);">7</span>
                                        <span class="number" id="D_haoma2" name="D_haoma2" style="cursor: pointer" onclick="xuanhao(this);">
                                            8</span> <span class="number" id="D_haoma2" name="D_haoma2" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="help">
                                        <a class="cp-op all" href="javascript:selectcode(2,'selall');">全</a> <a class="cp-op big"
                                            href="javascript:selectcode(2,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(2,'selxiao');">
                                                小</a> <a class="cp-op odd" href="javascript:selectcode(2,'seljin');">奇</a>
                                        <a class="cp-op even" href="javascript:selectcode(2,'selou');">偶</a> <a class="cp-op clear"
                                            href="javascript:selectcode(2,'delall');">清除</a>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="indicate">
                                        <span class="cp-digit">个 位</span>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <span class="number" id="D_haoma3" name="D_haoma3" style="cursor: pointer" onclick="xuanhao(this);">
                                            0</span> <span class="number" id="D_haoma3" name="D_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">1</span> <span class="number" id="D_haoma3" name="D_haoma3"
                                                    style="cursor: pointer" onclick="xuanhao(this);">2</span> <span class="number" id="D_haoma3"
                                                        name="D_haoma3" style="cursor: pointer" onclick="xuanhao(this);">3</span>
                                        <span class="number" id="D_haoma3" name="D_haoma3" style="cursor: pointer" onclick="xuanhao(this);">
                                            4</span> <span class="number" id="D_haoma3" name="D_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">5</span> <span class="number" id="D_haoma3" name="D_haoma3"
                                                    style="cursor: pointer" onclick="xuanhao(this);">6</span> <span class="number" id="D_haoma3"
                                                        name="D_haoma3" style="cursor: pointer" onclick="xuanhao(this);">7</span>
                                        <span class="number" id="D_haoma3" name="D_haoma3" style="cursor: pointer" onclick="xuanhao(this);">
                                            8</span> <span class="number" id="D_haoma3" name="D_haoma3" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="help">
                                        <a class="cp-op all" href="javascript:selectcode(3,'selall');">全</a> <a class="cp-op big"
                                            href="javascript:selectcode(3,'selda');">大</a> <a class="cp-op small" href="javascript:selectcode(3,'selxiao');">
                                                小</a> <a class="cp-op odd" href="javascript:selectcode(3,'seljin');">奇</a>
                                        <a class="cp-op even" href="javascript:selectcode(3,'selou');">偶</a> <a class="cp-op clear"
                                            href="javascript:selectcode(3,'delall');">清除</a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-------1D、2D、通选结束--------->
                    <!---------------和数选------------------>
                    <div class="row clearfix" style="display: none" id="hsxuanhao">
                        <table width="70%">
                            <tr>
                                <td>
                                    <!--1行-->
                                    <div class="indicate">
                                        <span class="cp-digit full">选择和值 </span>
                                    </div>
                                </td>
                                <td>
                                    <div class="main1">
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            0</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">1</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">2</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">3</span>
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            4</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">5</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">6</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">7</span>
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            8</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">9</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">10</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">11</span>
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            12</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">13</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">14</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">15</span>
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            16</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">17</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">18</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">19</span>
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            20</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">21</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">22</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">23</span>
                                        <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">
                                            24</span> <span class="number" id="hsx_haoma" name="hsx_haoma" style="cursor: pointer"
                                                onclick="xuanhao(this);">25</span> <span class="number" id="hsx_haoma" name="hsx_haoma"
                                                    style="cursor: pointer" onclick="xuanhao(this);">26</span> <span class="number" id="hsx_haoma"
                                                        name="hsx_haoma" style="cursor: pointer" onclick="xuanhao(this);">27</span>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!---------------和数选------------------>
                    <!--手动输入框-->
                    <div id="sdsrh" style="width: 100%; margin-left: 20px; display: none;">
                        <div>
                            <textarea id="tb_ManualInput" cols="20" rows="2" style="width: 550px; height: 150px;
                                float: left; margin-right: 30px;" onkeyup="DisNum();"></textarea>
                            <div style="font-size: 14px; color: #FF0000; font-weight: bold;">
                                号码输入方式：<br />
                            </div>
                            <span class="bigfont">1、把号码写入左边文本框内；<br />
                                2、从彩神通软件编辑器内复制投注的号码到左边文本框内；<br />
                                3、从你的文档中直接复制投注的号码到左边文本框内；<br />
                                4、从其他网页复制投注的号码到左边文本框内。<br />
                                <br />
                            </span>
                        </div>
                    </div>
                    <!--手动输入框-->
                    <div class="" align="center">
                        <p class="indicator">
                            [ 您一共选择了 <em id="danbeizhushu">0</em> 注，共 <em class="money" id="danbeimoney">0</em>
                            元 ]</p>
                        <div id="J_operateSelect" class="operate-select">
                            <span id="J_operateSelectSpan"><a class="add-select-to-list" href="javascript:void(null);"
                                onclick="Insert()">添加选号到投注列表</a> <a class="clear-select" href="javascript:void(null);"
                                    onclick="clearall()"></a></span>
                        </div>
                    </div>
                    <!--直选普通选号盘结束-->
                    <!--* 投注容器 *-->
                    <div class="num-list" style="margin-left: 50px;" id="J_Basket">
                        <select name="schemeNum" size="5" id="schemeNum" class="select-list">
                        </select>
                        <ul class="liebiao">
                            <li class="random-one"><a href="javascript:void(null);" onclick="jixuan(1)">直选机选1注</a></li>
                            <li class="random-one"><a href="javascript:void(null);" onclick="jixuan_zx(1)">组选机选1注</a></li>
                            <li class="random-one"><a href="javascript:void(null);" onclick="jixuan(5)">直选机选5注</a></li>
                            <li class="random-one"><a href="javascript:void(null);" onclick="jixuan_zx(5)">组选机选5注</a></li>
                            <li class="modify-one"><a href="javascript:returnstate();" class="btn_blue" onclick="Del_S()">
                                删除单注</a></li>
                            <li class="clear-list"><a href="javascript:returnstate();" class="btn_blue" onclick="clearNum()">
                                清空号码</a></li>
                        </ul>
                    </div>
                    <!--投注容器-->
                </div>
                <!--直选上传选号开始-->
                <div id="zx_upload" class="abacus mode-2" style="display: none">
                    <div class="uploadTips">
                        玩法提示：所选号码与开奖号码相同（且顺序一致）即中1000元</div>
                    <dl class="uplIntro">
                        <dt>3D文件上传的规则</dt>
                        <dd>
                            1、文档必须是.txt格式，不能超过250k</dd>
                        <dd>
                            2、一行一个投注号</dd>
                        <dd>
                            3、只支持单式号码上传</dd>
                        <dd>
                            4、号码之间以单个分隔符分隔(允许的分隔符包括空格、逗号、短横线)，每个号码为1位数字
                        </dd>
                        <dd>
                            5、单式投注请勿超过500注，详细规则请查看<a href="#" target="_blank">上传文件格式说明</a></dd>
                    </dl>
                    <div class="uplMain">
                        <label>
                            选择文件：<input type="text" name="upload_file" />
                        </label>
                        <input type="submit" id="upload_file_submit" name="upload_file_submit" value="上传" />
                    </div>
                </div>
                <!--直选上传结束-->
                <!--* 辅助操作区 *-->
                <div class="donkeyman">
                    <div class="dkm-toolbar">
                        <!--操作导航-->
                        <span class="dkm-bt">倍投：<input type="text" size="5" class="red" name="setbeishu"
                            id="setbeishu" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                            value="1" />倍(最大<em>99</em>倍)</span>&nbsp; <span class="dkm-zhs">注数：<em id="showdanbeizhushu">0</em>
                                注</span> 倍数：<span class="dkm-zhs" id="showbeishu">1</span>倍 <span class="dkm-je">金额：<em
                                    class="money" id="showallmoney">￥0</em> 元 </span>
                        <!--发起合买checkbox-->
                        <span class="dkm-groupBuy">
                            <input id="rad_purchasing" type="radio" name="buy" checked="checked" onclick="switchs()"
                                value="dg" /><em class="h">代购</em>
                            <input id="rad_chipped" type="radio" name="buy" onclick="switchs()" value="hm" /><em
                                class="h">发起合买</em></span>
                        <input id="TrackNum" type="radio" name="buy" onclick="switchs()" value="track" /><em
                            class="h">追号</em>
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
                    <div id="chipped" style="display: none;" class="united-buy-plan">
                        <!--发起合买开始-->
                        <div id="dkm-groupBuy" class="dkm-pannel">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="td1">
                                        方案标题：
                                    </td>
                                    <td class="td2">
                                        <em class="pa red">*</em>
                                        <input type="text" id="J_UnitedTitle" value="" class="plan-title txt" onkeypress="checkLen(this)"
                                            onkeyup="checkLen(this)" onchange="checkLen(this)" />&nbsp;<span class="notice">您还可输入<span
                                                id="J_UnitedTitleLen">0</span>个字符，最多30个</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        方案宣言：
                                    </td>
                                    <td class="td2 declar">
                                        <textarea id="mytext" cols="50" rows="5" class="plan-des" onkeydown="limitChars('mytext', 50)"
                                            onchange="limitChars('mytext', 50)" onpropertychange="limitChars('mytext', 50)"></textarea><span
                                                class="notice">您还可输入<span id="J_UnitedDescLen" class="str">0</span>个字符，最多50个</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        提成：
                                    </td>
                                    <td class="td2">
                                        <select id="proportion">
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
                                        %<em class="gray">(提成为1-10的整数，设置提成后至少认购与提成相等比例份额，无提成就选择0)</em>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        我要分为：
                                    </td>
                                    <td class="td2">
                                        <em class="pa red">*</em>
                                        <input size="5" id="txt_copy" type="text" class="txt1 splitnum" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                                            onbeforepaste="BeforePaste();" value="1" />
                                        份，每份<span class="s4" id="lab_money"> <em class="fee">￥0</em></span>元(每份至少0.2元，且必须能整除到分)
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        我要认购：
                                    </td>
                                    <td class="td2">
                                        <em class="pa red">*</em>
                                        <input size="5" id="txt_pcopy" class="txt1 buynum" type="text" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                                            onbeforepaste="BeforePaste();" value="1" />
                                        份 共计￥<span class="money" id="money">0</span>元 (至少要认购<span class="s1" id="J_UniteBuyMinSubscribeCent">1</span>份）
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        是否保密：
                                    </td>
                                    <td class="td2">
                                        <input type="radio" name="isSecret" id="J_Secret_1" value="0" checked="checked" />
                                        公开<br>
                                        <input type="radio" name="isSecret" id="J_Secret_0" value="1" />
                                        相对保密<em class="gray">(选号方案对未跟单人保密，开奖后公开)</em><br>
                                        <input type="radio" name="isSecret" id="J_Secret_2" value="2" />
                                        完全保密<em class="gray">(选号方案对所有人保密，开奖后公开)</em>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        保底：
                                    </td>
                                    <td class="td2">
                                        <input id="ck_protect" type="checkbox" onclick="protect()" />
                                        我要保底：<input size="5" id="Text1" type="text" class="baodi txt J_MultiText" onkeyup="this.value=this.value.replace(/[^\d]/g,'');InsertShow();"
                                            onbeforepaste="BeforePaste();" value="1" disabled="disabled" />
                                        份 共计 <span class="minfee" id="num_money">0</span>元 <em class="gray">(保底加认购不能大于总份数)</em><a
                                            class="whatzh" href="#" target="_blank" title="什么是保底？"></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1">
                                        &nbsp;
                                    </td>
                                    <td class="td2">
                                        <p class="tips">
                                            发起合买不能使用红包付款，否则您的合买付款会被自动退款，合买无法成立，您可以用红包进行代购、追号、参与合买。</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--发起合买结束-->
                    </div>
                </div>
                <!--辅助操作区-->
                <div class="confirm">
                    <div class="cfm-info">
                        <input name="" type="checkbox" value="" id="Checkbox2" checked="checked" />我已阅读了<a
                            href="Agreement.aspx" target="_blank">《用户合买代购协议》</a>并同意其中条款
                    </div>
                    <div class="cfm-btn">
                        <button id="J_SubmitPay" class="status1" onclick="return false">
                        </button>
                        <script>
                              <%=Pbzx.Common.Method.IsLottory(Pbzx.Common.Method.GetFCDateTime.ToString()) %>
                        </script>
                    </div>
                    <div class="cfm-document">
                        <p>
                            福利彩票发行中心温馨提示</p>
                        <p class="item">
                            1、“3D彩”是福彩中心发行的彩种。</p>
                        <p class="item">
                            2、根据福利彩票发行中心对“3D彩”限号的规定，您所选择的某些投注单（包括追号）可能因限号无法投注，未成功投注单将作为失败订单处理。</p>
                        <p class="item">
                            3、因网络中断、系统故障、彩票机故障等不可抗力因素引起的投注下单失败，视为委托服务未成立，福利彩票发行中心将对下单失败的订单做返款处理，并在当期期次开奖前退还用户已支付的费用。除此之外，不再承担任何责任。</p>
                        <p class="item">
                            4、为了保证您能投注成功，请您尽早下单。</p>
                        <p class="item red">
                            5、 感谢您支持社会公益事业，彩市有风险，投注需谨慎。未满18岁不得购买彩票。</p>
                    </div>
                </div>
                <div id="ft">
                    <input type="hidden" name="textstr" id="textstr" />
                    <!-- 号码 （记录select里的text值）-->
                    <input type="hidden" name="valuestr" id="valuestr" />
                    <!-- 号码（记录select里的value值） -->
                    <input type="hidden" name="code" id="code" />
                    <!-- 临时号码（为选号时准备） -->
                    <input type="hidden" name="lotId" id="playName" value="1" />
                    <!-- 彩种ID（为提交投注准备）-->
                    <input type="hidden" name="playid" value="1" />
                    <!-- 玩法ID（为提交投注准备）-->
                    <input type="hidden" name="source" value="0" />
                    <!-- 方案涞源 -->
                    <input type="hidden" name="allmoney" value="0" id="allmoney" />
                    <!-- 方案总金额（为提交投注准备） -->
                    <input type="hidden" name="danzhushu" value="0" id="danzhushu" />
                    <!-- 方案注数（为提交投注准备） -->
                    <input type="hidden" name="expect" id="ExpectNum" value="<%=Pbzx.BLL.publicMethod.Period("FC3DData")%>" />
                    <!-- 方案期号（为提交投注准备） -->
                    <input type="hidden" name="beishu" value="1" id="beishu" />
                    <input type="hidden" name="endtime" id="endtime" value="<%=Pbzx.Common.Method.GetFCDateTime.ToString() %>" />
                    <!-- 方案倍数（为提交投注准备） -->
                    <input type="hidden" name="fileorcode" id="fileorcode" />
                    <!-- 号码（为提交投注准备） -->
                </div>
            </div>
        </div>
    </div>
    <div id="doc" style="display: none">
        <div id="main">
            <div class="content">
                <div class="c-wrap">
                    <div class="c-inner">
                        <div class="an_title p-l0">
                            <ul class="l" id="stype_t">
                                <li class="an_cur">全部方案</li>
                            </ul>
                            <%--<span>置顶规则<s class="i-qw"></s>--%>
                        </div>
                        <div class="c-search">
                            <span class="l">
                                <input type="text" id="findstr" class="c-s-txt" value="请输入用户名" onfocus="this.value=='请输入用户名'?this.value='':this.value"
                                    onblur="this.value==''?this.value='请输入用户名':this.value" onkeydown='enter_search(event)' />
                                <input type="button" name="srearch" class="m-r btn_Lblue_s" value="搜索" onclick="do_search(1,Y.one('#findstr').value)" /></span></div>
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
                                                    <a href="PersonalPage.aspx?name=<%# Eval("UserName") %>">
                                                        <%# Eval("UserName") %></a>
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
                                                    ￥<%# Eval("AtotalMoney") %>元
                                                </td>
                                                <td>
                                                    <%# Eval("Share")%>份
                                                </td>
                                                <td>
                                                    ￥<asp:Label ID="lab_Each" runat="server"></asp:Label>元
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
    <div id="Myproject" style="display: none;">
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
                    <div id="pagelist" style="text-align: center;">
                    </div>
                </div>
            </div>
        </div>
        <div class="c-wrap" id="Tracking" style="display: none">
        </div>
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
                    <div id="Div1" style="text-align: center;">
                    </div>
                </div>
            </div>
        </div>
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
                </div>
                <div>
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
                <div id="Div3" style="text-align: center;">
                </div>
            </div>
        </div>
    </div>
    <div id="wrap">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    </form>
</body>
</html>
