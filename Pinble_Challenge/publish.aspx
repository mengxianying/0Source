<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publish.aspx.cs" Inherits="Pinble_Challenge.publish" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="Contorls/logion1.ascx" TagName="logion1" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Src="Contorls/adv.ascx" TagName="adv" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />

    <title>发布数据 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="js/Program.js"></script>
    <script type="text/javascript" src="js/relott.js"></script>
    <script type="text/javascript" src="js/btnSwitch.js"></script>
   <script type="text/javascript" src="js/Rel.js"></script>
</head>
<body>

    <form id="form1" runat="server">
    <div class="zanneiy_top_A">
        <uc2:logion1 ID="logion11" runat="server" />
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
                    <!--中间替换的内容区域-->
                    <div class="all">
                        <!--头部导航开始-->
                        <!--头部导航结束-->
                        <div class="member-body">
                            <div class="member-body-l">
                                <div class="member_left_top">
                                </div>
                                <div class="member-left">
                                    <!--菜单项-->
                                    <div>
                                        <div class="gr-box">
                                            <div class="gr-top">
                                                <div class="gr-left">
                                                </div>
                                                <div class="gr-right">
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="gr-main">
                                                <dl class="left-list">
                                                    <dt class="left-list-title"><a href="#" class="color-blue ">
                                                        <img class="img_2" src="images/member-left-ico11.gif">发布预测</a> </dt>
                                                    <dd class="left_icon">
                                                        <a href="javascript:lotSwitching('ssq')" class='yuce-a'>
                                                            <img src="images/member-left-triangle.gif">双色球</a></dd>
                                                    <dd class="left_icon">
                                                        <a href="javascript:lotSwitching('3D')" class='yuce-a'>
                                                            <img src="images/member-left-triangle.gif">福彩3D</a></dd>
                                                    <dd class="left_icon">
                                                        <a href="javascript:lotSwitching('pl3')" class='yuce-a'>
                                                            <img src="images/member-left-triangle.gif">排列三</a></dd>
                                                    <dd class="left_icon">
                                                        <a href="Person.aspx?name=<%=userName %>" target="_blank">
                                                            <img src="images/member-left-triangle.gif">我的成绩</a></dd>
                                                    <%--                                                    <dt class="left-list-title"><a href="#" class="color-blue ">
                                                        <img class="img_2" src="images/member-left-ico15.gif">账户中心</a></dt>--%>
                                                </dl>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </div>
                                <div class="member_left_bottom">
                                </div>
                            </div>
                            <div class="member-body-r">
                                <div class="main-body">
                                    <div class="listMain ha">
                                        <p class="fs14">
                                            <span style="padding-top: 2px;"><span id="iss"></span>期 <span id="lname">双色球</span>
                                                <font color="red"><span id="uName">您没有登录</span></font></span>&nbsp;&nbsp;&nbsp
                                                <font color="#FF0000">提醒：带星号(*)为必选条件&nbsp;&nbsp;</font> <span id="endTime" style="margin-left:50px"> 擂台截止时间：<span id="clostime"></span></span></p>
                                               
                                    </div>
                                    
                                    <div class="listTab" style="display: none;">
                                        <p class="fl listNubT fontW">
                                            添加内容</p>
                                         
                                    </div>
                                    <div class="listTab" style="display: ;">
                                        <p class="fl listNubT fontW">
                                            选择预测指标</p>
                                            <p class="fl listNubT fontW"><span style="margin-left:20px; color:#D90000">期待你的神机妙算</span></p>
                                    </div>
                                    <div id="show-hide-area" style="display: ">
                                        <!--条件指标--双色球-->
                                        <div id="cd_ssq" class="condition">
                                            <ul>
                                                <li>
                                                    <label>
                                                        <input type="radio" id="hq3d" name="ssq" value="hq3d" checked="checked" onclick="ChoiceCon()" />红球3胆<font
                                                            class="star" color="red">*</font>
                                                    </label>
                                                </li>
                                                <li>
                                                    <label>
                                                        <input id="hq6d" type="radio" name="ssq" value="hq6d" onclick="ChoiceCon()" />红球6胆
                                                    </label>
                                                </li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s3hq" onclick="ChoiceCon()" />杀3红球</label><font
                                                            class="star" color="red">*</font> </li>
                                                            <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s6hq" onclick="ChoiceCon()" />杀6红球</label>
                                                </li>
                                                <li>

                                                    <label>
                                                        <input type="radio" name="ssq" value="lq1d" onclick="ChoiceCon()" />篮球1胆<font class="star"
                                                            color="red">*</font></label>
                                                </li>
                                                <li>
                                                    <label>
                                                    <input type="radio" name="ssq" value="lq3d" onclick="ChoiceCon()" />篮球3胆</label>
                                                        
                                                </li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s3lq" onclick="ChoiceCon()" />杀3篮球<font class="star"
                                                            color="red">*</font></label>
                                                </li>
                                                
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s6lq" onclick="ChoiceCon()" />杀6篮球</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="h2l" onclick="ChoiceCon()" />9红+2蓝</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="h3l" onclick="ChoiceCon()" />12红+3蓝<font class="star"
                                                            color="red">*</font></label>
                                                </li>
                                            </ul>
                                        </div>
                                        <!--条件指标--3D--排列三-->
                                        <div id="cd_3d" class="condition" style="display: none">
                                            <ul>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="dd" onclick="ChoiceCon()" />独胆<font
                                                            class="star" color="red">*</font></label>
                                                </li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="sd" onclick="ChoiceCon()" />双胆<font class="star"
                                                            color="red">*</font></label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="zx1z" onclick="ChoiceCon()" />组选1注<font class="star"
                                                            color="red">*</font></label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s1m" onclick="ChoiceCon()" />杀1码</label><font
                                                            class="star" color="red">*</font></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s2m" onclick="ChoiceCon()" />杀2码</label><font
                                                            class="star" color="red">*</font></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="dk" onclick="ChoiceCon()" />独跨</label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="dh" onclick="ChoiceCon()" />独合</label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="s1h" onclick="ChoiceCon()" />杀1合</label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="zx" onclick="ChoiceCon()" />直选1注</label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="3dw" onclick="ChoiceCon()" />3*3*3定位</label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="5dw" onclick="ChoiceCon()" />5*5*5定位</label></li>
                                                <li>
                                                    <label>
                                                        <input type="radio" name="ssq" value="m" onclick="ChoiceCon()" />5码</label></li>
                                                <li>
                                            </ul>
                                        </div>
                                        <div class="listTab">
                                            <p class="fl listNubT fontW">
                                                选择号码</p>
                                        </div>
                                        <div class="ball-area">
                                            <!---3D 排三部分---->
                                            <div id="haoma_d" class="ball-area-content-27" style="display: none;">
                                                <div class="ball-area-l-27">
                                                    <ul class="three-line-27">
                                                        <li class="ball-ball ball-27"><span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                            flag="0">0</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                flag="0">1</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                    flag="0">2</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                        flag="0">3</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                            flag="0">4</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                                flag="0">5</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                                    flag="0">6</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                                        flag="0">7</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                                            flag="0">8</span> <span class="gb" id="sd_haoma" name="sd_haoma" onclick="xuanhao(this)"
                                                                                                flag="0">9</span> </li>
                                                    </ul>
                                                </div>
                                                <div class="ball-area-r-27">
                                                    <%--<ul class="three-line-27">
                                                        <li>大</li>
                                                        <li>小</li>
                                                        <li>奇</li>
                                                        <li>偶</li>
                                                        <li>全部</li>
                                                    </ul>--%>
                                                </div>
                                            </div>
                                            <div id="haoma_q" class="ball-area-content-27" style="display: none;">
                                                <div class="ball-area-l-27">
                                                    <ul>
                                                        <li class="ball-wei">百位</li>
                                                        <li class="ball-ball ball-27"><span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                            flag="0">0</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                flag="0">1</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                    flag="0">2</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                        flag="0">3</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                            flag="0">4</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                                flag="0">5</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                                    flag="0">6</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                                        flag="0">7</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                                            flag="0">8</span> <span class="gb" id="haoma1" name="haoma1" onclick="xuanhao(this)"
                                                                                                flag="0">9</span> 
                                                             </li>
                                                    </ul>
                                                    <ul >
                                                        <li class="ball-wei">十位</li>
                                                        <li class="ball-ball ball-27"><span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                            flag="0">0</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                flag="0">1</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                    flag="0">2</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                        flag="0">3</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                            flag="0">4</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                                flag="0">5</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                                    flag="0">6</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                                        flag="0">7</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                                            flag="0">8</span> <span class="gb" id="haoma2" name="haoma2" onclick="xuanhao(this)"
                                                                                                flag="0">9</span> </li>
                                                    </ul>
                                                    <ul>
                                                        <li class="ball-wei">个位</li>
                                                        <li class="ball-ball ball-27"><span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                            flag="0">0</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                flag="0">1</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                    flag="0">2</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                        flag="0">3</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                            flag="0">4</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                                flag="0">5</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                                    flag="0">6</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                                        flag="0">7</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                                            flag="0">8</span> <span class="gb" id="haoma3" name="haoma3" onclick="xuanhao(this)"
                                                                                                flag="0">9</span> </li>
                                                    </ul>
                                                </div>
                                                                                                <div class="ball-area-r-27">
                                                    <ul class="three-line-27">
                                                        <li><a href="javascript:selectcode(1,'selda',1);">大</a></li>
                                                        <li><a href="javascript:selectcode(1,'selxiao',1);">小</a></li>
                                                        <li><a href="javascript:selectcode(1,'seljin',1);">奇</a></li>
                                                        <li><a href="javascript:selectcode(1,'selou',1);">偶</a></li>
                                                        <li> <a href="javascript:selectcode(1,'selall',1);">全部</a></li>
                                                    </ul>
                                                    <ul class="three-line-27">
                                                        <li><a href="javascript:selectcode(1,'selda',2);">大</a></li>
                                                        <li><a href="javascript:selectcode(1,'selxiao',2);">小</a></li>
                                                        <li><a href="javascript:selectcode(1,'seljin',2);">奇</a></li>
                                                        <li><a href="javascript:selectcode(1,'selou',2);">偶</a></li>
                                                        <li> <a href="javascript:selectcode(1,'selall',2);">全部</a></li>
                                                    </ul>
                                                    <ul class="three-line-27">
                                                        <li><a href="javascript:selectcode(1,'selda',3);">大</a></li>
                                                        <li><a href="javascript:selectcode(1,'selxiao',3);">小</a></li>
                                                        <li><a href="javascript:selectcode(1,'seljin',3);">奇</a></li>
                                                        <li><a href="javascript:selectcode(1,'selou',3);">偶</a></li>
                                                        <li> <a href="javascript:selectcode(1,'selall',3);">全部</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <!---双色球部分--->
                                            <div id="ssq_hq" class="ball-area-content-27" style="">
                                                <div class="ball-area-l-27">
                                                    <ul class="three-line-27">
                                                        <li class="ball-ball ball-27"><span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                            flag="0">01</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                flag="0">02</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                    flag="0">03</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                        flag="0">04</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                            flag="0">05</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                flag="0">06</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                    flag="0">07</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                        flag="0">08</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                            flag="0">09</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                flag="0">10</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                    flag="0">11</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                        flag="0">12</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                            flag="0">13</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                                flag="0">14</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                                    flag="0">15</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                                        flag="0">16</span> <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)"
                                                                                                                            flag="0">17</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">18</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">19</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">20</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">21</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">22</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">23</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">24</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">25</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">26</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">27</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">28</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">29</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">30</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">31</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">32</span>
                                                            <span class="gb" id="haoma_ssq" name="haoma_ssq" onclick="xuanhao(this)" flag="0">33</span>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <div class="ball-area-r-27">
                                                    <%-- <ul class="three-line-27">
                                                    <li>大</li>
                                                    <li>小</li>
                                                    <li>奇</li>
                                                    <li>偶</li>
                                                    <li>全部</li>
                                                </ul>--%>
                                                </div>
                                            </div>
                                            <div id="ssq_lq" class="ball-area-content-16" style="display: none">
                                                <div class="ball-area-l-16">
                                                    <ul class="three-line-16">
                                                        <li class="ball-ball ball-16"><span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                            onclick="xuanhao(this)" flag="0">01</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                onclick="xuanhao(this)" flag="0">02</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                    onclick="xuanhao(this)" flag="0">03</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                        onclick="xuanhao(this)" flag="0">04</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                            onclick="xuanhao(this)" flag="0">05</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                                onclick="xuanhao(this)" flag="0">06</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                                    onclick="xuanhao(this)" flag="0">07</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                                        onclick="xuanhao(this)" flag="0">08</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                                            onclick="xuanhao(this)" flag="0">09</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                                                onclick="xuanhao(this)" flag="0">10</span> <span class="gb" id="haoma_ssql" name="haoma_ssql"
                                                                                                    onclick="xuanhao(this)" flag="0">11</span>
                                                            <span class="gb" id="haoma_ssql" name="haoma_ssql" onclick="xuanhao(this)" flag="0">
                                                                12</span> <span class="gb" id="haoma_ssql" name="haoma_ssql" onclick="xuanhao(this)"
                                                                    flag="0">13</span> <span class="gb" id="haoma_ssql" name="haoma_ssql" onclick="xuanhao(this)"
                                                                        flag="0">14</span> <span class="gb" id="haoma_ssql" name="haoma_ssql" onclick="xuanhao(this)"
                                                                            flag="0">15</span> <span class="gb" id="haoma_ssql" name="haoma_ssql" onclick="xuanhao(this)"
                                                                                flag="0">16</span> </li>
                                                    </ul>
                                                </div>
                                                <div class="ball-area-r-16">
                                                    <%--<ul class="three-line-16">
                                                    <li>大</li>
                                                    <li>小</li>
                                                    <li>奇</li>
                                                    <li>偶</li>
                                                    <li>全部</li>
                                                </ul>--%>
                                                </div>
                                            </div>
                                            <div id="ssq_con" class="ball-area-content-122" style="display: none;">
                                                <div id="h" class="ball-area-l-122">
                                                    <ul class="three-line-122">
                                                        <li class="ball-ball ball-122"><span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                            onclick="xuanhao(this)" flag="0">01</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                onclick="xuanhao(this)" flag="0">02</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                    onclick="xuanhao(this)" flag="0">03</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                        onclick="xuanhao(this)" flag="0">04</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                            onclick="xuanhao(this)" flag="0">05</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                                onclick="xuanhao(this)" flag="0">06</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                                    onclick="xuanhao(this)" flag="0">07</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                                        onclick="xuanhao(this)" flag="0">08</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                                            onclick="xuanhao(this)" flag="0">09</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                                                onclick="xuanhao(this)" flag="0">10</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1"
                                                                                                    onclick="xuanhao(this)" flag="0">11</span>
                                                            <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)" flag="0">
                                                                12</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                    flag="0">13</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                        flag="0">14</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                            flag="0">15</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                flag="0">16</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                    flag="0">17</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                        flag="0">18</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                            flag="0">19</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                flag="0">20</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                    flag="0">21</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                        flag="0">22</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                            flag="0">23</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                                flag="0">24</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                                    flag="0">25</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                                        flag="0">26</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                                                            flag="0">27</span>
                                                            <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)" flag="0">
                                                                28</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                    flag="0">29</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                        flag="0">30</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                            flag="0">31</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                flag="0">32</span> <span class="gb" id="ssq_haoma1" name="ssq_haoma1" onclick="xuanhao(this)"
                                                                                    flag="0">33</span> </li>
                                                    </ul>
                                                </div>
                                                <div class="ball-area-r-122">
                                                    <ul class="three-line-122">
                                                        <li><span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)" flag="0">
                                                            01</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                flag="0">02</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                    flag="0">03</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                        flag="0">04</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                            flag="0">05</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                flag="0">06</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                    flag="0">07</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                        flag="0">08</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                            flag="0">09</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                flag="0">10</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                    flag="0">11</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                        flag="0">12</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                            flag="0">13</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                                flag="0">14</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                                    flag="0">15</span> <span class="gb" id="ssql_haoma" name="ssql_haoma" onclick="xuanhao(this)"
                                                                                                                        flag="0">16</span>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="addto-area">
<%--                                            <div class="listTab tips-mid">
                                                <p class="fl listNubT fontW">
                                                    添加到预测列表</p>
                                                
                                                </div>--%>
                                            <div class="btn-area">
                                                <span class="add-btn" data=""><a href="javascript:Insert()"></a></span><span class="clear-btn">
                                                    <a href="javascript:clearNum()" id="clear-all">清空预测列表</a></span><span class="clear-btn">
                                                        <a href="javascript:Del_S()" id="A1">删除单行</a></span>
                                            </div>
                                        </div>
                                        <!--显示列表-->
                                        <div class="show">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <select name="schemeNum" size="5" id="schemeNum" style="width: 500px; height: 170px;">
                                                        </select>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="to-editor">
                                            <div class="btn-area">
                                                <span><font color="red" size="2">提示：&nbsp;&nbsp;本期截止发布后，按钮锁定不可操作。开奖后才可发布下一期内容</font></span><span class="quick-sub">
                                                    <input id="btn_rel" type="button" class="submit-btn" value="" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <!--编辑器-->
                                    <!---号码为提交准备--->
                                    <input type="hidden" name="fileorcode" id="fileorcode" />
                                    <input type="hidden" name="expect" id="issue" />
                                    <!-- 方案期号（为提交投注准备） -->
                                    <input type="hidden" id="lottID" value="3" />
                                    
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
                <uc1:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
