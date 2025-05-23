<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contrast.aspx.cs" Inherits="Pinble_Challenge.contrast" %>

<%@ Register src="Contorls/Footer.ascx" tagname="Footer" tagprefix="uc1" %>

<%@ Register src="Contorls/logion1.ascx" tagname="logion1" tagprefix="uc2" %>

<%@ Register src="Contorls/Navigation.ascx" tagname="Navigation" tagprefix="uc3" %>

<%@ Register src="Contorls/adv.ascx" tagname="adv" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title>历史成绩对比 - 拼搏擂台 - 拼搏在线彩神通软件</title>
    <link href="cssTab/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="cssTab/global.css" />
    <script type="text/javascript" src="js/jquery-1.4.4.js"></script>
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
                        <div class="subtitle">
                            <p>
                                 <span>当前位置：<span id="lottName"> 双色球</span>&nbsp;&nbsp;&nbsp;<span id="lcond">杀一蓝</span>  成绩对比 </span>

                            </p>
                        </div>
                        <div class="tabtype">
                            <ul>
                                <li id="s" class="hover"><a href="javascript:void(btnColorNa('s'))">双色球</a></li>
                        <li id="d"><a href="javascript:void(btnColorNa('d'))">福彩3D</a></li>
                        <li id="p"><a href="javascript:void(btnColorNa('p'))">排列三</a></li>
                            </ul>

                        </div>
                        <div class="duimain-title">
                            <div class="title-left">
                            </div>
                            <div class="title-middle">
                                <p class="title-text title-text-l">
                           <span id="lottN">双色球</span> &nbsp;&nbsp;&nbsp;<font color="red"><span id="cont"></span>&nbsp;</font>成绩对比</p>
                                <div class="dui_bai">
                                    前:
                                    <select id="selNum">
                                        <option value="5">5</option>
                                        <option value="7">7</option>
                                        <option value="10">10</option>
                                        <option value="15" selected='selected'>15</option>
                                        <option value="30">30</option>
                                    </select>期排名
                                </div>
                                <%--<dl class="fl btn_zj">
                                    <dd class='btn_mf'>
                                        <a href="#">选择专家对比</a></dd>
                                </dl>--%>
                             <%--   <div class="dui-type">
                                    按积分排名</div>--%>
                            </div>
                            <div class="title-right">
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="mainbody" style="border: none">
                        <!--<div class="zjphb_leftb">
-->
                        <!--成绩排行-->
                        <div class="dui_lefts linebox" id="result" style="border-right: 1px solid #D1E0EE;">
                            <div class="clear">
                            </div>
                        </div>
                        <!--积分排行-->
                        <div class="dui_leftb">
                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td>
                                       
                                        <input id="ShawAll" type="button" value="显示全部" class="fxbutton"  />
                                    </td>
                                </tr>
                            </table>
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
