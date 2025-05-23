
function Swit(obj) {            ///*****CompOFS.aspx 页面数据切换 查询表**/
    if (obj == "ssq") {
        document.getElementById("sq").className = "hover";
        document.getElementById("fd").className = "";
        document.getElementById("pl").className = "";
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/TabCompOFS",
            data: "{issNum:'50'}",
            dataType: "json",
            success: function (data) {
                $("#div_table").html(HtmlDecode(data));
            }
        });
        $("#lname").html(" 双色球");
        $("#lottN").html(" 双色球");
    }
    if (obj == "3D") {

        document.getElementById("sq").className = "";
        document.getElementById("fd").className = "hover";
        document.getElementById("pl").className = "";
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/TabCompOFS_D",
            data: "{issNum:'50'}",
            dataType: "json",
            success: function (data) {
                $("#div_table").html(HtmlDecode(data));
            }
        });
        $("#lname").html(" 福彩3D");
        $("#lottN").html(" 福彩3D");
    }
    if (obj == "pl3") {
        document.getElementById("sq").className = "";
        document.getElementById("fd").className = "";
        document.getElementById("pl").className = "hover";
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/TabCompOFS_P",
            data: "{issNum:'50'}",
            dataType: "json",
            success: function (data) {
                $("#div_table").html(HtmlDecode(data));
            }
        });
        $("#lname").html(" 排列三");
        $("#lottN").html(" 排列三");
    }
}

//导航图标切换样式
function ChangeColor(obj) {
    if (obj == s) {
        document.getElementById("s").className = "hover";
        document.getElementById("d").className = "";
        document.getElementById("p").className = "";
    }
    if (obj == d) {
        document.getElementById("s").className = "";
        document.getElementById("d").className = "hover";
        document.getElementById("p").className = "";
    }
    if (obj == p) {
        document.getElementById("s").className = "";
        document.getElementById("d").className = "";
        document.getElementById("p").className = "hover";
    }
}

//用户个人页彩种切换获取表格
function perTableS(obj) {
    //获取当前期号
    var n_issue = "";
    if (obj == "s") {
        $("#ssq").addClass("tabs-nav chartTab_on");
        $("#fd").removeClass("tabs-nav chartTab_on");
        $("#pl").removeClass("tabs-nav chartTab_on");
        //获取期号
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/Period",
            data: "{lottID:'3'}",
            dataType: "json",
            complete: function (result) {
                n_issue = result.responseText.split('"')[1].split('"')[0];
                //查询个人也统计数据
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/perTableS",
                    data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + n_issue + "'}",
                    dataType: "json",
                    success: function (data) {
                        $("#div_Stati").html(HtmlDecode(data));
                    }
                });
            }
        });


        
    }
    if (obj == "d") {
        $("#ssq").removeClass("tabs-nav chartTab_on");
        $("#fd").addClass("tabs-nav chartTab_on");
        $("#pl").removeClass("tabs-nav chartTab_on");
        //获取期号
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/Period",
            data: "{lottID:'1'}",
            dataType: "json",
            complete: function (result) {
                n_issue = result.responseText.split('"')[1].split('"')[0];
                //查询个人也统计数据
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/perTableD",
                    data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + n_issue + "'}",
                    dataType: "json",
                    success: function (data) {
                        $("#div_Stati").html(HtmlDecode(data));
                    }
                });
            }
        });
        
        
    }
    if (obj == "p") {
        $("#ssq").removeClass("tabs-nav chartTab_on");
        $("#fd").removeClass("tabs-nav chartTab_on");
        $("#pl").addClass("tabs-nav chartTab_on");
        //获取期号
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/Period",
            data: "{lottID:'9999'}",
            dataType: "json",
            complete: function (result) {
                n_issue = result.responseText.split('"')[1].split('"')[0];
                //查询个人也统计数据;
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/perTableP",
                    data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + n_issue + "'}",
                    dataType: "json",
                    success: function (data) {
                        $("#div_Stati").html(HtmlDecode(data));
                    }
                });
            }
        });
        
       
    }
}

//html编码
function HtmlEncode(text) {
    return text.replace(/&/g, '&amp').replace(/\"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');

}
//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}

// ReleasePage.aspx  页面彩种发布切换
//彩种切换
function lotSwitching(obj) {
    //清空期号
    $("#issue").attr("value", "");
    if (obj == "ssq") {
        //清空号码栏数据
        clearNum();

        //默认显示红球选择区
        document.getElementById("ssq_hq").style.display = "block";
        //隐藏3D选号区
        document.getElementById("haoma_d").style.display = "none";
        document.getElementById("haoma_q").style.display = "none";

        //双色球条件区
        document.getElementById("cd_ssq").style.display = "block";
        //3D 条件区
        document.getElementById("cd_3d").style.display = "none";
        $("#hq3d").attr("checked", "checked");
        $("#dd").removeAttr("checked");
        $("#lottID").attr("value", "");
        $("#lottID").attr("value", 3);
        //获取期号
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/Period",
            data: "{lottID:'3'}",
            dataType: "json",
            complete: function (result) {
                var issue = result.responseText.split('"')[1].split('"')[0];
                $("#issue").attr("value", issue);
                $("#iss").html(issue);
            }
        });
        
        $("#lottName").html(" 双色球");
        $("#lname").html(" 双色球");
        //查询是否截止发布
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/Allow",
            data: "{playName:'3'}",
            dataType: "json",
            complete: function (result) {
                if (result.responseText == 1) {
                    //按钮不可用  'disabled'
                    $("#btn_rel").attr("disabled", true);
                    $("#endTime").html("本期已经截止,开奖后可以发布下期内容");
                    return false;
                }
                else {
                    $("#btn_rel").attr("disabled", false);
                    //获取截止时间
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/AllowTime",
                        data: "{playName:'3'}",
                        dataType: "json",
                        complete: function (result) {
                            var dateTime = result.responseText.split('"')[1].split('"')[0];
                            //                            $("#clostime").html(dateTime);
                            $("#endTime").html("擂台截止时间为:" + dateTime);
                        }
                    });
                }
            }
        });

    }
    else {
        //清空号码栏数据
        clearNum();

        $("#dd").attr("checked", "checked");
        $("#hq3d").removeAttr("checked");
        if (obj == "3D") {
            $("#lottID").attr("value", "");
            $("#lottID").attr("value", 1);
            //获取期号
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Period",
                data: "{lottID:'1'}",
                dataType: "json",
                complete: function (result) {
                    var issue = result.responseText.split('"')[1].split('"')[0];
                    $("#issue").attr("value", issue);
                    $("#iss").html(issue);
                }
            });
            $("#lottName").html(" 福彩3D");
            $("#lname").html(" 福彩3D");

            //查询是否截止发布
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Allow",
                data: "{playName:'1'}",
                dataType: "json",
                complete: function (result) {
                    if (result.responseText == 1) {
                        //按钮不可用  'disabled'
                        $("#btn_rel").attr("disabled", true);
                        $("#endTime").html("本期已经截止,开奖后可以发布下期内容");
                        return false;
                    }
                    else {
                        $("#btn_rel").attr("disabled", false);
                        //获取截止时间
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/AllowTime",
                            data: "{playName:'1'}",
                            dataType: "json",
                            complete: function (result) {
                                var dateTime = result.responseText.split('"')[1].split('"')[0];
//                                $("#clostime").html(dateTime);
                                $("#endTime").html("擂台截止时间为:" + dateTime);
                            }
                        });
                    }
                }
            });

        }
        if (obj == "pl3") {
            $("#lottID").attr("value", "");
            $("#lottID").attr("value", 9999);
            //获取期号
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Period",
                data: "{lottID:'9999'}",
                dataType: "json",
                complete: function (result) {
                    var issue = result.responseText.split('"')[1].split('"')[0];
                    $("#issue").attr("value", issue);
                    $("#iss").html(issue);
                }
            });
            $("#lottName").html(" 排列三");
            $("#lname").html(" 排列三");
            //查询是否截止发布
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Allow",
                data: "{playName:'9999'}",
                dataType: "json",
                complete: function (result) {
                    if (result.responseText == 1) {
                        //按钮不可用  'disabled'
                        $("#btn_rel").attr("disabled", true);
                        $("#endTime").html("本期已经截止,开奖后可以发布下期内容");
                        return false;
                    }
                    else {
                        $("#btn_rel").attr("disabled", false);
                        //获取截止时间
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/AllowTime",
                            data: "{playName:'9999'}",
                            dataType: "json",
                            complete: function (result) {
                                var dateTime = result.responseText.split('"')[1].split('"')[0];
                                //                                $("#clostime").html(dateTime);
                                $("#endTime").html("擂台截止时间为:" + dateTime);
                            }
                        });
                    }
                }
            });


        }
        //显示3D默认选号区
        document.getElementById("haoma_d").style.display = "block";
        document.getElementById("haoma_q").style.display = "none";
        document.getElementById("ssq_hq").style.display = "none";
        document.getElementById("ssq_lq").style.display = "none";
        document.getElementById("ssq_con").style.display = "none";
        //双色球条件区
        document.getElementById("cd_ssq").style.display = "none";
        //3D 条件区
        document.getElementById("cd_3d").style.display = "block";

    }
}


//选号区 显示
function ChoiceCon() {

    //显示蓝球区
    if ($("input[name='ssq']:checked").val() == "lq3d" || $("input[name='ssq']:checked").val() == "lq1d" || $("input[name='ssq']:checked").val() == "s6lq" || $("input[name='ssq']:checked").val() == "s3lq") {
        //显示蓝球选号区
        document.getElementById("ssq_lq").style.display = "block";
        //隐藏红球选号区
        document.getElementById("ssq_hq").style.display = "none";
        document.getElementById("ssq_con").style.display = "none";
        clearall();
        ContainBall();
    }
    //显示号码选择区
    if ($("input[name='ssq']:checked").val() == "h3l" || $("input[name='ssq']:checked").val() == "h2l") {
        //显示选号区
        document.getElementById("ssq_con").style.display = "block";
        //隐藏其他选号区
        document.getElementById("ssq_lq").style.display = "none";
        document.getElementById("ssq_hq").style.display = "none";
        clearall();
        ContainBall();
    }
    if ($("input[name='ssq']:checked").val() == "hq3d" || $("input[name='ssq']:checked").val() == "hq6d" || $("input[name='ssq']:checked").val() == "s3hq" || $("input[name='ssq']:checked").val() == "s6hq") {
        //显示红球区
        document.getElementById("ssq_hq").style.display = "block";
        //隐藏选号区
        document.getElementById("ssq_lq").style.display = "none";
        document.getElementById("ssq_con").style.display = "none";
        clearall();
        ContainBall();
    }

    //3D、排列3部分
    //独胆、双胆、杀1码、杀2码、独跨、杀1跨、独合、杀1合、5码
    if ($("input[name='ssq']:checked").val() == "dd" || $("input[name='ssq']:checked").val() == "sd" || $("input[name='ssq']:checked").val() == "s1m" || $("input[name='ssq']:checked").val() == "s2m" || $("input[name='ssq']:checked").val() == "dk" || $("input[name='ssq']:checked").val() == "s1k" || $("input[name='ssq']:checked").val() == "dh" || $("input[name='ssq']:checked").val() == "s1h" || $("input[name='ssq']:checked").val() == "m") {
        //显示选号区
        document.getElementById("haoma_d").style.display = "block";
        //隐藏选号区
        document.getElementById("haoma_q").style.display = "none";
        clearall();
        ContainBall();
    }
    //组选1注、5*5*5定位、3*3*3定位、直选1注
    if ($("input[name='ssq']:checked").val() == "zx1z" || $("input[name='ssq']:checked").val() == "5dw" || $("input[name='ssq']:checked").val() == "3dw" || $("input[name='ssq']:checked").val() == "zx") {

        //显示选号区
        document.getElementById("haoma_q").style.display = "block";
        //隐藏
        document.getElementById("haoma_d").style.display = "none";
        clearall();
        ContainBall();
    }

    
}

//PerRank.aspx 页面彩种切换样式
function lottColorRank(obj) {
    if (obj == "ssq") {
        //显示标题双色球
        $("#lottName").html("双色球");
        $("#Span1").html("双色球");
        document.getElementById("s").className = "hover";
        document.getElementById("d").className = "";
        document.getElementById("p").className = "";
        if ($("#state").val() == "achi") {
            //绑定成绩榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perRankData",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        if ($("#state").val() == "inte") {
            //双色球积分榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/IntegralTable",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        
    }
    if (obj == "fd") {
        $("#lottName").html("福彩3D ");
        $("#Span1").html("福彩3D ");
        document.getElementById("s").className = "";
        document.getElementById("d").className = "hover";
        document.getElementById("p").className = "";
        if ($("#state").val() == "achi") {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perRankData_D",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        if ($("#state").val() == "inte") {
            //3D积分榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/IntegralTable_d",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
    }
    if (obj == "pl") {
        $("#lottName").html("排列三 ");
        $("#Span1").html("排列三 ");
        document.getElementById("s").className = "";
        document.getElementById("d").className = "";
        document.getElementById("p").className = "hover";
        if ($("#state").val() == "achi") {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perRankData_P",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
            
        }
        if ($("#state").val() == "inte") {
            //排列3积分榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/IntegralTable_p",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
    }
}
//  HistoryA.aspx 页面彩种切换  数据表转换
//取值
function getReturn() {
    //获取url中的 lottery参数
    var Request = new Object();
    Request = GetRequest();
    var name = Request['name'];

    return name;
}
function HisLottSwitch(obj) {
    var name = getReturn();
    if (obj == "s") {
        //双色球
        $("#ss").addClass("hover");
        $("#sd").removeClass("hover");
        $("#ps").removeClass("hover");
        $("#lotNam").html("双色球 ");
        $("#s_lottName").html("双色球");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/UserAchienement",
            data: "{userName:'" + name + "',issueNum:'" + $("#issueNum").val() + "'}",
            dataType: "json",
            success: function (data) {
                $("#div_cond").html(HtmlDecode(data));
            }
        });
    }
    if (obj == "d") {
        //3D  UserAchienement_d
        $("#ss").removeClass("hover");
        $("#sd").addClass("hover");
        $("#ps").removeClass("hover");
        $("#lotNam").html("福彩3D ");
        $("#s_lottName").html("福彩3D");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/UserAchienement_d",
            data: "{userName:'" + name + "',issueNum:'" + $("#issueNum").val() + "'}",
            dataType: "json",
            success: function (data) {
                $("#div_cond").html(HtmlDecode(data));
            }
        });

    }
    if (obj == "p") {
        //排列3
        $("#ss").removeClass("hover");
        $("#sd").removeClass("hover");
        $("#ps").addClass("hover");
        $("#lotNam").html("排列三 ");
        $("#s_lottName").html("排列三");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/UserAchienement_P",
            data: "{userName:'" + name + "',issueNum:'" + $("#issueNum").val() + "'}",
            dataType: "json",
            success: function (data) {
                $("#div_cond").html(HtmlDecode(data));
            }
        });
    }
}


//切换积分榜 和成绩榜 PerRank.aspx 页面
function IntegralSwit() {
    //初始是成绩榜

    //切换的时候 成绩榜 和积分榜颠倒
    if ($("#state").val() == "achi") {
        //切换到积分榜
        if ($("#s").hasClass("hover")) {
            //双色球积分榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/IntegralTable",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        if ($("#d").hasClass("hover")) {
            //3D积分榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/IntegralTable_d",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        if ($("#p").hasClass("hover")) {
            //排列3积分榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/IntegralTable_p",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        $("#hName").html("切换到成绩榜");
        $("#state").attr("value", "");
        $("#state").attr("value", "inte");
        return false;
    }
    if ($("#state").val() == "inte") {
        //切换到成绩榜
        if ($("#s").hasClass("hover")) {
            //双色球成绩榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perRankData",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        if ($("#d").hasClass("hover")) {
            //3D成绩榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perRankData_D",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        if ($("#p").hasClass("hover")) {
            //排列3成绩榜
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perRankData_P",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $("#perBank").html(HtmlDecode(data));
                }
            });
        }
        $("#hName").html("切换到积分榜");
        $("#state").attr("value", "");
        $("#state").attr("value", "achi");
        return false;
    }
}

//清空球体样式
function clearall() {
    // 清空3D号码
    var haoma3D = document.getElementsByName("sd_haoma");
    for (var i = 0; i < haoma3D.length; i++) {
        haoma3D[i].className = "gb";
    }

    //清空3D 定位号码
    for (var i = 1; i < 4; i++) {
        var haomaDw = document.getElementsByName("haoma" + i);
        for (var j = 0; j < haomaDw.length; j++) {
            haomaDw[j].className = "gb";
        }
    }

    //请空双色球红球
    var haomaSSq = document.getElementsByName("haoma_ssq");
    for (var i = 0; i < haomaSSq.length; i++) {
        haomaSSq[i].className = "gb";
    }

    //清空双色球蓝球
    var haomaLq = document.getElementsByName("haoma_ssql");
    for (var i = 0; i < haomaLq.length; i++) {
        haomaLq[i].className = "gb";
    }

    //清空双色球红篮球 
    var haoma_hq = document.getElementsByName("ssq_haoma1");
    for (var i = 0; i < haoma_hq.length; i++) {
        haoma_hq[i].className = "gb";
    }
    var haoma_lq = document.getElementsByName("ssql_haoma");
    for (var i = 0; i < haoma_lq.length; i++) {
        haoma_lq[i].className = "gb";
    }
}
//清空号码栏
function clearNum() {
    var Temp = document.getElementById("schemeNum");
    var len = Temp.options.length;
    for (i = 0; i < len; i++) {
        Temp.options[0] = null;
    }
    $("#fileorcode").attr("value", "");
    clearall();
}

//条件包含  显示号码
function ContainBall() {
    if ($("#fileorcode").val() != "" && $("#fileorcode").val() != null) {
        //保存条件的数组
        var arr = new Array();

        //保存号码的数组
        var arrN = new Array();

        var n_StrNum = $("#fileorcode").val();
        for (var i = 0; i < n_StrNum.split(';').length; i++) {
            //获取条件名称
            arr[i] = n_StrNum.split(';')[i].split('|')[0];
            //获取号码
            arrN[i] = n_StrNum.split(';')[i].split('|')[1];
        }
        for (var j = 0; j < arr.length; j++) {
            if ($("input[name='ssq']:checked").val() == "hq6d") {
                if (arr[j] == "hq3d") {
                    var haoma = document.getElementsByName("haoma_ssq");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haoma.length+1; i++) {
                            if (arrN[j].split(',')[k] == ToLength(i)) {

                                haoma[i - 1].className = "rb";
                                
                            }
                        }
                    }
                }

            }
            if ($("input[name='ssq']:checked").val() == "s6hq") {
                if (arr[j] == "s3hq") {
                    var haoma = document.getElementsByName("haoma_ssq");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haoma.length+1; i++) {
                            if (arrN[j].split(',')[k] == ToLength(i)) {

                                haoma[i - 1].className = "rb";
                            }
                        }
                    }


                }
            }
            if ($("input[name='ssq']:checked").val() == "lq3d") {
                if (arr[j] == "lq1d") {
                    var haoma = document.getElementsByName("haoma_ssql");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haoma.length+1; i++) {
                            if (arrN[j].split(',')[k] == ToLength(i)) {

                                haoma[i - 1].className = "bb";
                            }
                        }
                    }


                }
            }
            if ($("input[name='ssq']:checked").val() == "s6lq") {
                if (arr[j] == "s3lq") {
                    var haoma = document.getElementsByName("haoma_ssql");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haoma.length+1; i++) {
                            if (arrN[j].split(',')[k] == ToLength(i)) {

                                haoma[i - 1].className = "bb";
                            }
                        }
                    }


                }
            }
            if ($("input[name='ssq']:checked").val() == "h3l") {
                if (arr[j] == "h2l") {
                    var haoma = document.getElementsByName("ssq_haoma1");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split('+')[0].split(',').length; k++) {
                        for (var i = 1; i < haoma.length + 1; i++) {
                            if (arrN[j].split('+')[0].split(',')[k] == ToLength(i)) {

                                haoma[i - 1].className = "rb";
                            }
                        }
                    }
                    var haomaL = document.getElementsByName("ssql_haoma");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split('+')[1].split(',').length; k++) {
                        for (var i = 1; i < haomaL.length + 1; i++) {
                            if (arrN[j].split('+')[1].split(',')[k] == ToLength(i)) {

                                haomaL[i - 1].className = "bb";
                            }
                        }
                    }

                }
                else {
                    if (arr[j] == "hq6d") {
                        var haoma = document.getElementsByName("ssq_haoma1");
                        var codstr = 0;

                        for (var k = 0; k < arrN[j].split(',').length; k++) {
                            for (var i = 1; i < haoma.length + 1; i++) {
                                if (arrN[j].split(',')[k] == ToLength(i)) {

                                    haoma[i - 1].className = "rb";
                                }
                            }
                        }
                    }
                    else {
                        if (arr[j] == "hq3d") {
                            var haoma = document.getElementsByName("ssq_haoma1");
                            var codstr = 0;

                            for (var k = 0; k < arrN[j].split(',').length; k++) {
                                for (var i = 1; i < haoma.length + 1; i++) {
                                    if (arrN[j].split(',')[k] == ToLength(i)) {

                                        haoma[i - 1].className = "rb";
                                    }
                                }
                            }
                        }
                    }

                }
                if (arr[j] == "lq3d") {
                    var haomaL = document.getElementsByName("ssql_haoma");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haomaL.length + 1; i++) {
                            if (arrN[j].split(',')[k] == ToLength(i)) {

                                haomaL[i - 1].className = "bb";
                            }
                        }
                    }
                }
                else {
                    if (arr[j] == "lq1d") {
                        var haomaL = document.getElementsByName("ssql_haoma");
                        var codstr = 0;

                        for (var k = 0; k < arrN[j].split(',').length; k++) {
                            for (var i = 1; i < haomaL.length + 1; i++) {
                                if (arrN[j].split(',')[k] == ToLength(i)) {

                                    haomaL[i - 1].className = "bb";
                                }
                            }
                        }
                    }
                }
            }
            if ($("input[name='ssq']:checked").val() == "h2l") {
                if (arr[j] == "hq6d") {
                    var haoma = document.getElementsByName("ssq_haoma1");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haoma.length + 1; i++) {
                            if (arrN[j].split(',')[k] == ToLength(i)) {

                                haoma[i - 1].className = "rb";
                            }
                        }
                    }
                }
                else {
                    if (arr[j] == "hq3d") {
                        var haoma = document.getElementsByName("ssq_haoma1");
                        var codstr = 0;

                        for (var k = 0; k < arrN[j].split(',').length; k++) {
                            for (var i = 1; i < haoma.length + 1; i++) {
                                if (arrN[j].split(',')[k] == ToLength(i)) {

                                    haoma[i - 1].className = "rb";
                                }
                            }
                        }
                    }
                }
                if (arr[j] == "lq1d") {
                    var haomaL = document.getElementsByName("ssql_haoma");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 1; i < haomaL.length + 1; i++) {
                            if (arrN[j].split(',')[k] == i) {

                                haomaL[i - 1].className = "bb";
                            }
                        }
                    }
                }

            }
            if ($("input[name='ssq']:checked").val() == "sd") {
                if (arr[j] == "dd" || arr[j] == "pdd") {
                    var haoma = document.getElementsByName("sd_haoma");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 0; i < haoma.length ; i++) {
                            if (arrN[j].split(',')[k] == i) {

                                haoma[i].className = "rb";
                            }
                        }
                    }
                }
            }
            if ($("input[name='ssq']:checked").val() == "s2m") {
                if (arr[j] == "s1m" || arr[j] == "ps1m") {
                    var haoma = document.getElementsByName("sd_haoma");
                    var codstr = 0;

                    for (var k = 0; k < arrN[j].split(',').length; k++) {
                        for (var i = 0; i < haoma.length; i++) {
                            if (arrN[j].split(',')[k] == i) {
                               
                                haoma[i].className = "rb";
                            }
                        }
                    }
                }
            }
            if ($("input[name='ssq']:checked").val() == "5dw") {
                if (arr[j] == "3dw" || arr[j] == "p3dw") {
                    var ANum = new Array();
                    for (var w = 1; w < 4; w++) {
                        for (var p = 0; p < arrN[j].split(',')[w - 1].length; p++) {
                            ANum[p] = arrN[j].split(',')[w - 1].substr(p, 1);
                        }
                        var haoma = document.getElementsByName("haoma" + w);

                        for (var l = 0; l < ANum.length; l++) {
                            for (var i = 0; i < haoma.length; i++) {
                                if (ANum[l] == i) {
                                    haoma[i].className = "rb";
                                }
                            }
                        }
                    }

                }
                else {
                    if (arr[j] == "zx" || arr[j] == "pzx") {
                        for (var i = 1; i < 4; i++) {
                            var haoma = document.getElementsByName("haoma" + i);
                            for (var p = 0; p < haoma.length; p++) {
                                if (arrN[j].split(',')[i - 1] == p) {
                                    haoma[p].className = "rb";
                                }
                            }
                        }
                    }
                }
            }
            if ($("input[name='ssq']:checked").val() == "3dw") {
                if (arr[j] == "zx" || arr[j] == "pzx") {
                    for (var i = 1; i < 4; i++) {
                        var haoma = document.getElementsByName("haoma" + i);
                        for (var p = 0; p < haoma.length; p++) {
                            if (arrN[j].split(',')[i - 1] == p) {
                                haoma[p].className = "rb";
                            }
                        }
                    }
                }
            }


        }
    }
}
//在各位数前加0  组合号码为01
function ToLength(num) {
    if (num <= 9) {
        return "0" + num;
    }
    else {
        return num;
    }
}

//首页的上一期下一期
//上一期绑定
//$(document).ready(function () {



//});

//红球图表
function redColumn(cond, g_num, issue) {
    var colors = Highcharts.getOptions().colors,
            categories = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31', '32', '33'],
            name = cond,
            data = [{
                y: parseInt(g_num.split('&')[0]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[1]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[2]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[3]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[4]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[5]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[6]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[7]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[8]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[9]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[10]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[11]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[12]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[13]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[14]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[15]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[16]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[17]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[18]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[19]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[20]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[21]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[22]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[23]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[24]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[25]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[26]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[27]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[28]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[29]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[30]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[31]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[32]),
                color: colors[0]
            }];

    chart = new Highcharts.Chart({
        chart: {
            renderTo: 'container',
            type: 'column'
        },
        title: {
            text: issue + '期 ' + cond + ' (红球)号码出现情况'
        },

        xAxis: {
            categories: categories
        },
        yAxis: {
            title: {
                text: '红球号码选择次数'
            }
        },
        legend: {
                enabled: false
            },

        plotOptions: {
            column: {
                cursor: 'pointer',
                //
                dataLabels: {
                    enabled: true,
                    color: colors[0],
                    style: {
                        fontWeight: 'bold'
                    },
                    formatter: function () {
                        return this.y;
                    }
                }
            }
        },
        tooltip: {
            formatter: function () {
//                var point = this.point,
                s = this.x + ' 出现 ' + this.y + ' 次';
                return s;
            }
        },

        series: [{
            name: "ad",
            data: data,
            color: 'white'
        }],
        exporting: {
            enabled: false
        }
    });
}

//蓝球图表
function buleColumn(cond, g_num, issue,tab) {
    var colors = Highcharts.getOptions().colors,
            categories = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16'],
            name = cond,
            data = [{
                y: parseInt(g_num.split('&')[0]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[1]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[2]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[3]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[4]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[5]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[6]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[7]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[8]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[9]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[10]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[11]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[12]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[13]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[14]),
                color: colors[1]
            }, {
                y: parseInt(g_num.split('&')[15]),
                color: colors[1]

            }];

    chart = new Highcharts.Chart({
        chart: {
            renderTo: tab,
            type: 'column'
        },
        title: {
            text: issue + '期 ' + cond + ' (蓝球)号码出现情况'
        },

        xAxis: {
            categories: categories
        },
        yAxis: {
            title: {
                text: '蓝球号码选择次数'
            }
        },
        legend: {
                enabled: false
            },
        plotOptions: {
            column: {
                cursor: 'pointer',
                //
                dataLabels: {
                    enabled: true,
                    color: colors[1],
                    style: {
                        fontWeight: 'bold'
                    },
                    formatter: function () {
                        return this.y;
                    }
                }
            }
        },
        tooltip: {
            formatter: function () {
                var point = this.point,
                                    s = this.x + ' 出现 ' + this.y + ' 次';
                return s;
            }
        },

        series: [{
            name: name,
            data: data,
            color: 'white'
        }],
        exporting: {
            enabled: false
        }
    });
}

//3D 排列3 图表
function d_redColumn(cond, g_num, issue) {
    var colors = Highcharts.getOptions().colors,
            categories = ['0','1', '2', '3', '4', '5', '6', '7', '8', '9'],
            name = cond,
            data = [{
                 y: parseInt(g_num.split('&')[33]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[0]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[1]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[2]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[3]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[4]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[5]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[6]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[7]),
                color: colors[0]
            }, {
                y: parseInt(g_num.split('&')[8]),
                color: colors[0]
            
            }];

    chart = new Highcharts.Chart({
        chart: {
            renderTo: 'container',
            type: 'column'
        },
        title: {
            text: issue + '期 ' + cond + ' 号码出现情况'
        },

        xAxis: {
            categories: categories
        },
        yAxis: {
            title: {
                text: '号码选择次数'
            }
        },
        legend: {
                enabled: false
            },

        plotOptions: {
            column: {
                cursor: 'pointer',
                //
                dataLabels: {
                    enabled: true,
                    color: colors[0],
                    style: {
                        fontWeight: 'bold'
                    },
                    formatter: function () {
                        return this.y;
                    }
                }
            }
        },
        tooltip: {
            formatter: function () {
//                var point = this.point,
                s = this.x + ' 出现 ' + this.y + ' 次';
                return s;
            }
        },

        series: [{
            name: "ad",
            data: data,
            color: 'white'
        }],
        exporting: {
            enabled: false
        }
    });
}

//初始化显示数据
function TheCallData() {
    var issue = $("#issue").val();
    var cond = "";
    var chart;
    var g_num = "";

    var playName = 0;
    if ($("#lbtn_s").hasClass("hover")) {
        playName = 3;
        cond = "红球3胆";
    }
    if ($("#lbtn_d").hasClass("hover")) {
        playName = 1;
        cond = "独胆";
    }
    if ($("#lbtn_p").hasClass("hover")) {
        playName = 9999;
        cond = "独胆";
    }

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/AppearNum",
        data: "{playName:'" + playName + "',top:'*',cond:'" + cond + "'}",
        dataType: "json",
        complete: function (result) {
            g_num = result.responseText.split('"')[1].split('"')[0];
            if (playName == 3) {
                if (cond == "蓝球1胆" || cond == "蓝球3胆" || cond == "杀3蓝球" || cond == "杀6蓝球") {
                    document.getElementById("containerB").style.display = "none";
                    buleColumn(cond, g_num.split('+')[0], issue, 'container');
                }
                if (cond == "红球3胆" || cond == "红球6胆" || cond == "杀3红球" || cond == "杀6红球") {
                    document.getElementById("containerB").style.display = "none";
                    redColumn(cond, g_num.split('+')[0], issue);
                }
                if (cond == "12红+3蓝" || cond == "9红+2蓝") {
                    document.getElementById("containerB").style.display = "block";
                    /******红球图标*******/
                    redColumn(cond, g_num.split('+')[0], issue);
                    /******红球图标*******/

                    /******蓝球图标*******/
                    buleColumn(cond, g_num.split('+')[1], issue, 'containerB');
                    /******蓝球图标*******/
                }
            }
            if (playName == 1 || playName == 9999) {
                d_redColumn(cond, g_num.split('+')[0], issue);
            }


        }
    });
}




//获取url地址栏的值
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串   
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        var strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}

//取消关注 （我关注的人列表）
function CancelPayAtt(objName) {
    //验证是否登录
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/ulogin",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            if (result.responseText.split('"')[1].split('"')[0] == 0) {
                alert("请您先登录");
                return false;
            }
            else {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/delTo",
                    data: "{IdolName:'" + objName + "',sign:'pblt'}",
                    dataType: "json",
                    complete: function (result) {
                        if (result.responseText == 0) {
                            alert("添加关注失败,请请重新添加");
                            return false;
                        }
                        if (result.responseText == 1) {
                            alert("取消成功");

                            history.go(0);
                            return false;
                        }
                        if (result.responseText == 2) {
                            alert("您没关注过此用户");
                            return false;
                        }
                    }
                });
            }
        }
    });
}