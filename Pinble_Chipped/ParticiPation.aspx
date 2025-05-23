<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ParticiPation.aspx.cs"
    Inherits="Pinble_Chipped.ParticiPation" %>

<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>合买详情</title>
<%--    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
    <meta name="author" content="" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="Css/detail.css" rel="stylesheet" type="text/css" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="loginCss/css.css" rel="stylesheet" />
    <link href="Css/footer.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.tablepanl{
border:1px solid #b4d8fc;
border-top:none;
text-align:center;
}
.tablepanl td{height:30px; border:0}
</style>

       <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
     <script type="text/javascript" src="js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" charset="gb2312" src="js/login.js?date=new date().gettime()"></script>

    <script type="text/javascript" src="js/SearchAjax.js"></script>
    <script type="text/javascript" charset="gb2312" src="js/Apply.js"></script>

    <script type="text/javascript">
    function display()
    {
        var hidden=document.getElementById("hidden");
        //循环点击
    }
    function money() {

        //购买份数《=剩余份数
        if (parseInt($("#setbeishu").val()) >parseInt($("#lab_surplusNum").text())) {
            alert('您最多可以买 ' + $("#lab_surplusNum").text() + " 份");
            $("#setbeishu").attr("value", $("#lab_surplusNum").text());
        }

        $("#permoney").html(Math.round(($("#setbeishu").val() * $("#shareMoney").val()) * 100) / 100);
    }
    //获取url地址栏的值
    function GetRequest()   
    {   
        var url = location.search; //获取url中"?"符后的字串   
        var theRequest = new Object();   
        if(url.indexOf("?") != -1)   
        {   
          var str = url.substr(1);   
            var strs = str.split("&");   
          for(var i = 0; i < strs.length; i ++)   
            {   
             theRequest[strs[i].split("=")[0]]=unescape(strs[i].split("=")[1]);   
            }   
        }   
        return theRequest;   
    }
    //显示余额 user_balance
    function disM() {
        $("#balance").html($("#user_balance").val());
    }

    $(document).ready(function () {
        money();
        //获取url中的 lottery参数
        var Request = new Object();
        Request = GetRequest();
        var lottery = Request['lottery'];
        //判断彩种
        if (lottery == 1) {
            //3D
            $("#lottery").css("background-position", "0 -450px");
            $("#lotteryName").html("福彩3D");
        }
        if (lottery == 3) {
            //双色球
            $("#lottery").css("background-position", "0 -1px");
            $("#lotteryName").html("双色球");
        }
        //七乐彩
        if (lottery == 2) {
            $("#lottery").css("background-position", "0 -900px");
            $("#lotteryName").html("七乐彩");
        }
        //排列5
        if (lottery == 4) {
            $("#lottery").css("background-position", "0 -600px");
            $("#lotteryName").html("排列五");
        }
        //七星彩
        if (lottery == 5) {
            $("#lottery").css("background-position", "0 -975px");
            $("#lotteryName").html("七星彩");
        }
        //大乐透
        if (lottery == 6) {
            $("#lottery").css("background-position", "0 -225px");
            $("#lotteryName").html("大乐透");
        }
        //        //22选5
        //        if (lottery == 6) {
        //            $("#lottery").css("background-position", "0 -225px");
        //            $("#lotteryName").html("22选5");
        //        }
        $("#permoney").html(Math.round(($("#setbeishu").val() * $("#shareMoney").val()) * 100) / 100);
        //判断是否登录
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/username",
            data: "{}",
            dataType: "json",
            complete: function (result) {
                if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                    //$("#userMoneyInfo").html("您尚未登录，请先<span id='aloginShow' style=\"cursor: pointer; color: #003399;\"><a href=\"#\">登录</a>&nbsp;</span> <span id=\"spUser\"></span>   <a href=\"<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx\" id='aNewUserReg' target=\"_blank\">&nbsp;用户注册</a><a href=\"#\" id='aLoginOut' style=\"display: none;\">&nbsp;退出</a>！");
                }
                else {
                    $("#userMoneyInfo").html("用户<font color='red'> " + result.responseText.split('"')[1].split('"')[0] + "</font>已登录  您的账户余额为：<span id='balance'>******</span>元<a id='ckmoney' onclick='disM()' href='javascript:void(0)'>   显示余额</a>");
                }
            }
        });

        //购买
        $("#submitCaseBtn3").click(function () {
            //判断是否登录
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../WebChipped.asmx/username",
                data: "{}",
                dataType: "json",
                complete: function (result) {
                    if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                        alert('您没有登录，请先登陆');
                        return false;
                    }
                    else {
                        //购买的份数是否合法
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "WebChipped.asmx/shareNum",
                            data: "{num:'" + $("#setbeishu").val() + "',Qnum:'" + $("#Number").val() + "'}",
                            dataType: "json",
                            complete: function (result) {
                                if (result.responseText == 1) {

                                    alert('方案销售完毕！');
                                    return false;
                                    //
                                }
                                if (result.responseText == 2) {
                                    alert('剩余份数不足');
                                    history.go(0);
                                    return false;
                                }
                                if (result.responseText == 3) {
                                    //正常
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json",
                                        url: "WebChipped.asmx/ChippedAdd",
                                        data: "{Qnum:'" + $("#Number").val() + "',share:'" + $("#setbeishu").val() + "'}",
                                        dataType: "json",
                                        complete: function (result) {
                                            if (result.responseText == 0) {
                                                alert('下单失败');
                                                return false;
                                            }
                                            if (result.responseText == 1) {
                                                alert('下单成功');
                                                parent.$.XYTipsWindow.removeBox();
                                                history.go(0);
                                                return false;
                                            }
                                            if (result.responseText == 2) {
                                                alert('您的余额不够支付本次购买金额，请先充值');
                                                return false;
                                            }
                                            if (result.responseText == 3) {
                                                alert('下单成功');
                                                $.ajax({
                                                    type: "POST",
                                                    contentType: "application/json",
                                                    url: "../WebChipped.asmx/selectDrawer",
                                                    data: "{Qnum:'" + $("#Qnum").val() + "'}",
                                                    dataType: 'json',
                                                    complete: function (result) {
                                                    }
                                                });
                                                parent.$.XYTipsWindow.removeBox();
                                                history.go(0);
                                                return false;
                                            }
                                        }
                                    });
                                }
                            }
                        });

                    }
                }
            });
        });

    });
    function switching(obj)
    {
        if(obj=='joinCount')
        {
            document.getElementById("joinCount").className="an_cur";
            document.getElementById("show_list_div").style.display="block";
            document.getElementById("meyBuy").className="";
            document.getElementById("IBuy").style.display="none";
        }
        if(obj=='meyBuy')
        {
         //判断是否登录
            $.ajax({
                type:"POST",
                contentType: "application/json",
                url:"../WebChipped.asmx/username",
                data:"{}",
                dataType:"json",
                complete:function(result){
                    if(result.responseText.split('"')[1].split('"')[0]==0 || result.responseText=="" || result.responseText==null)
                    {
                        alert('您没有登录，请先登陆');
                        return false;
                    }
                    else
                    {
                        document.getElementById("joinCount").className="";
                        document.getElementById("show_list_div").style.display="none";
                        document.getElementById("meyBuy").className="an_cur";
                        document.getElementById("IBuy").style.display="block";
                    }
                }
            });
            
        }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="divLogin" style="display: none; cursor: default;">
                <table width="350" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="40" style="background: url(image/login1.jpg)">
                            <table width="98%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%">
                                    </td>
                                    <td width="5%">
                                        <img style="cursor: pointer;" src="image/close.gif" width="15" height="15" id="btnCancelMeng"
                                            alt="" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="160" valign="middle" style="background: url(image/login2.jpg)">
                            <table width="85%" border="0" align="center" cellpadding="4" cellspacing="0" height="145">
                                <tr>
                                    <td colspan="2" height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="23%" align="right">
                                        用户名：</td>
                                    <td width="77%" align="left">
                                        <input type="text" id="txtUsername" maxlength="12" style="width: 150px;" />&nbsp;<a
                                            style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx"
                                            tabindex='-1'>免费注册</a></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        密 &nbsp;码：</td>
                                    <td align="left">
                                        <input id="txtPassword" type="password" maxlength="16" style="width: 150px;" />&nbsp;<a
                                            style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx" target="_blank" tabindex='-2'>密码找回</a></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        验证码：</td>
                                    <td align="left">
                                        <input type="text" id="txtCode" maxlength="4" style="width: 50px;" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
                                        <img src="/publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                                            onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: hand;" />
                                        <img alt="正确" src="image/note_ok.gif" id="imgOKH" style="display: none;" />
                                        <img alt="错误" src="image/note_error.gif" id="imgErrorH" style="display: none;" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;&nbsp;&nbsp;
                                        <input type="button" id="btnLogin" class="HeadLogin" />
                                        &nbsp;
                                        <input type="button" id="imgReset" class="HeadReset" />
                                        &nbsp;&nbsp;<input type="checkbox" id="cbState" title="保存我的登录状态" />保存登录状态
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../image/login3.jpg" width="350" height="13" alt="" /></td>
                    </tr>
                </table>
            </div>
        <div id="doc" class="cp_3d">
            <div class="b-top">
                <div class="b-top-inner">
                    <h2 id="lottery">
                     </h2>
                    <div class="b-top-info">
                        <a href="javascript:void(0)" title="" class="on">当前<%=ExpectNum%>期</a><span>固定奖，玩法简单，每晚20：30开奖！
                        </span>
                    </div>
                    <dl class="b-top-nav">
                        <dt><span id="lotteryName"></span>&nbsp;&nbsp;&nbsp;&nbsp;第<span id="ExpectNum" style="color:Black"><%=ExpectNum%></span>  期 合买方案 </dt>
                        <dd id="playTabsDd">
                            <a href="avascript:void(0);" title="" class="on"><em>方案基本信息</em></a></dd>
                    </dl>
                    <div class="b-top-tips">
                        <div class="b-top-ql">
                            .
                        </div>
                        <div class="b-top-time">
                            截止时间： <span id="endtimeSpan"><%=endTime %></span> <span id="countDownSpan">还剩
                                <span id="_lefttime" style="color: Red"></span></span>

                            <script type="text/javascript">
                                function _fresh()
                                {
                                    //结束时间取配置文件中的数据                                    
                                    var endtime = new Date("<%=endTime %>".replace(/-/g, "/")); 
                                    
                                    var nowtime = new Date();
                                    var leftsecond=parseInt((endtime.getTime()-nowtime.getTime())/1000);
                                    if(leftsecond<0){leftsecond=0;}
                                    __d=parseInt(leftsecond/3600/24);
                                    __h=parseInt((leftsecond/3600)%24);
                                    __m=parseInt((leftsecond/60)%24);
                                    __s=parseInt(leftsecond%60);
                                    __all = __d+"天"+__h+"小时"+__m+"分"+__s+"秒";
                                    document.getElementById("_lefttime").innerHTML=__all;
                                    
                                }
                                    _fresh()
                                    setInterval(_fresh,1000);
                            </script>

                        </div>
                    </div>
                </div>
            </div>
            <div id="main">
                <div class="box_top">
                    <div class="box_top_l">
                    </div>
                </div>
                <div class="box_m">
                    <div id="xx1">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="buy_table">
                            <tr>
                                <td class="td_title2">
                                    发起人信息</td>
                                <td class="con_content">
                                    <div class="detail_d">
                                        <p>
                                            <span class="m_r50 record"><a href="#">
                                                <asp:Label ID="lab_name" runat="server"></asp:Label></a></span> <span class="m_r50">
                                                    <a href="#">查看发起人所有合买记录</a></span><span class="m_r50"><a href="javascript:void(0)" onclick="attention()">关注发起人</a> </span>
                                        </p>
                                        <%--                                    <p class="gray">
                                        <span id="zjinfo">总中奖次数：<span class="black"><span id="cnt">34783</span>次</span><br />
                                            总中奖金额：<span class="red eng" id="after_bonus">23423423</span>元
                                            <br />
                                        </span>
                                    </p>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title2">
                                    方案信息</td>
                                <td class="con_content">
                                    <div id="fanandiv" class="tdbback" style="width: 625px;">
                                        <table cellspacing="0" cellpadding="0" border="0" width="100%" class="tablelay eng">
                                            <asp:Repeater ID="myRep_info" runat="server" OnItemDataBound="myRep_info_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr>
                                                        <th>
                                                            总金额</th>
                                                        <th>
                                                            倍数</th>
                                                        <th>
                                                            份数</th>
                                                        <th>
                                                            每份</th>
                                                        <th>
                                                            发起人提成</th>
                                                        <th>
                                                            保底</th>
                                                        <th class="last_th">
                                                            购买进度</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="last_tr">
                                                        <td>
                                                            <span class="red eng">￥<%# Eval("AtotalMoney")%></span>元</td>
                                                        <td>
                                                            <%# Eval("doubles")%>
                                                            倍</td>
                                                        <td>
                                                            <%# Eval("Share")%>
                                                            份</td>
                                                        <td>
                                                           <font color="red"> ￥<%# (Convert.ToDecimal(Eval("AtotalMoney")) / Convert.ToInt32(Eval("Share"))).ToString("0.##")%> </font>元</td>
                                                        <td>
                                                            <span class="red eng">
                                                                <%# Eval("commission") %>
                                                                %</span></td>
                                                        <td>
                                                            <%# Convert.ToInt32(Eval("Protect")) %> 份</td>
                                                        <td class="last_td">
                                                            <span class="red eng">
                                                                <asp:Label ID="lab_jindu" runat="server"></asp:Label>%</span>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title2 p_tb8">
                                    方案内容</td>
                                <td class="con_content p_tb8">
                                    <p>
                                        <asp:Label ID="lab_display" runat="server"></asp:Label><a href="javascript:display();"><label
                                            id="displayHidden" runat="server" class="dis">显示全部</label>
                                        </a>
                                        <div id="hidden" style="display: none">
                                            <asp:Label ID="lab_hidden" runat="server"></asp:Label>
                                        </div>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_title2">
                                    我要认购</td>
                                <td class="con_content">
                                    <div class="buy_btn">
                                        <input id="submitCaseBtn3" type="button" class="btn_buy_m" />
                                    </div>
                                    <div id="userMoneyInfo">
                                    您尚未登录，请先<span id='aloginShow' style="cursor: pointer; color: #003399;"><a href="#">登录</a>&nbsp;</span>
                            <span id="spUser"></span>   <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx" id='aNewUserReg' target="_blank">
                            &nbsp;用户注册</a>  <a href="#" id='aLoginOut' style="display: none;">&nbsp;退出</a>
                                    </div>
                                    还可以认购 <span class="red eng">
                                        <asp:Label ID="lab_surplusNum" runat="server"></asp:Label></span> 份，我要认购
                                    <input type="text" size="5" name="setbeishu" id="setbeishu" onkeyup="this.value=this.value.replace(/[^\d]/g,'');money();" onbeforepaste="BeforePaste();"
                                        value="1" />
                                    份 总金额<span class="red eng">￥</span><span class="red eng" id="permoney"></span>元
                                    <p class="read">
                                        <span class="hide_sp">
                                            <input type="checkbox" checked="checked" id="agreement" value="1" /></span>我已阅读并同意《<a
                                                href="Agreement.aspx" target="_blank">用户合买代购协议</a>》</p>
                                    <input type="hidden" value="1" id="agreement2" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="xx2">
                        <div class="det_g_t">
                            方案分享信息</div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="buy_table">
                            <tr>
                                <td class="td_title2">
                                    方案宣传</td>
                                <td class="con_content">
                                    <div class="detail_d clearfix">
                                        <%--                                    <div class="copy_link">
                                        <a href="javascript:void(0);" onclick="copyurl('www.pinble.com')" class="public_Lblue"
                                            id="copystr"><b>点击复制方案地址</b></a></div>--%>
                                        <p class="gray">
                                            方案标题：<asp:Label ID="lab_title" runat="server"></asp:Label><br />
                                            
                                        </p>
                                        <p class="gray">
                                            方案描述：<asp:Label ID="lab_say" runat="server"></asp:Label><br />
                                        </p>
                                        <%--                                    <div class="add_div">
                                        <span class="shouc_box"><span class="ttitle">分享至：</span></span>
                                        <div class="C-shareUrl">
                                            <a id="C_share_tao" href="#" target="_blank" title="分享到淘江湖">
                                                <img src="images/x6.png" />
                                                淘江湖</a> <a id="C_share_sina" href="#" target="_blank" title="分享到新浪微博">
                                                    <img src="images/x5.gif" />
                                                    新浪微博</a> <a id="C_share_tc" href="#" target="_blank" title="分享到腾讯微博">
                                                        <img src="images/x7.png" />
                                                        腾讯微博</a> <a id="C_share_qzone" href="#" target="_blank" title="分享到QQ空间">
                                                            <img src="images/x2.gif" />
                                                            QQ空间</a> <a id="C_share_douban" href="#" target="_blank" title="分享到豆瓣">
                                                                <img src="images/x1.png" />
                                                                豆瓣</a> <a id="C_share_ren" href="#" target="_blank" title="分享到人人网">
                                                                    <img src="images/x4.gif" />
                                                                    人人网</a> <a id="C_share_kai" href="#" target="_blank" title="分享到开心网">
                                                                        <img src="images/x3.gif" />
                                                                        开心网</a></div>
                                    </div>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr class="last_tr">
                                <td class="td_title2">
                                    合买用户</td>
                                <td class="con_content">
                                    <p style="word-wrap: break-word; width: 500px; overflow: hidden;">
                                        <asp:Label ID="lab_open" runat="server"></asp:Label></p>
                                    <div class="yh_tab">
                                        <ul class="clearfix" id="My_buy">
                                            <li id="joinCount" class="an_cur"><a href="javascript:void(0)" onclick="switching('joinCount')">总参与人数</a>  </li>
                                            <li id="meyBuy" class=""><a href="javascript:void(0)" onclick="switching('meyBuy')">您的认购记录</a></li>
                                        </ul>
                                    </div>
                                    <div id="show_list_div">
                                        <table width="100%" border="0" class="tablepanl">
                                            <asp:Repeater ID="myRep_Chipped" runat="server" OnItemDataBound="myRep_Chipped_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr style="height: 33px; line-height: 33px; color: #4f5152; font-weight: normal;
                                                        background: url(images/hm_th_bg1.png) repeat-x;">
                                                        <td>
                                                            用户名
                                                        </td>
                                                        <td>
                                                            认购份数
                                                        </td>
                                                        <td>
                                                            认购金额
                                                        </td>
                                                        <td>
                                                            购买时间
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#dff0f4"%>'>
                                                        <td>
                                                            <%# Eval("ChippedName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedShare") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_money" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedTime") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <asp:Label ID="litContent" runat="server"></asp:Label><td colspan="4">
                                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="IBuy" style=" display:none;">
                                         <table width="100%" border="0" class="tablepanl">
                                            <asp:Repeater ID="rep_IBuy" runat="server" OnItemDataBound="rep_IBuy_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr style="height: 33px; line-height: 33px; color: #4f5152; font-weight: normal;
                                                        background: url(images/hm_th_bg1.png) repeat-x;">
                                                        <td>
                                                            用户名
                                                        </td>
                                                        <td>
                                                            认购份数
                                                        </td>
                                                        <td>
                                                            认购金额
                                                        </td>
                                                        <td>
                                                            购买时间
                                                        </td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#dff0f4"%>'>
                                                        <td>
                                                            <%# Eval("ChippedName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedShare") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_BuyMoney" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("ChippedTime") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <asp:Label ID="litContentBuy" runat="server"></asp:Label><td colspan="4">
                                                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager2_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
        <%--每份的价格--%>
        <input id="shareMoney" type="hidden" value="<%=shareMoney %>" />
        <%--流水号--%>
        <input id="Number" type="hidden" value="<%= Qnumber %>" />
        <%--关注会员--%>
         <input id="Aname" type="hidden" value="<%=name%>" />


        <input id="user_balance" type="hidden" value="<%=user_balance %>" />
        
         
    </form>
</body>
</html>
