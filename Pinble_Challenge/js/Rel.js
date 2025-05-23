/***////发布条件脚本****/
$(document).ready(function () {

    //查询个人也统计数据 (Personal.aspx 页面初始加载)
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/Period",
        data: "{lottID:'3'}",
        dataType: "json",
        complete: function (result) {
            var issue = result.responseText.split('"')[1].split('"')[0];
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/perTableS",
                data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + issue + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_Stati").html(HtmlDecode(data));

                }
            });
        }
    });

    //根据期数 显示列表数据
    $("#sel_issN").change(function () {
        if ($("#ssq").hasClass("chartTab_on")) {
            //获取期号
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Period",
                data: "{lottID:'3'}",
                dataType: "json",
                complete: function (result) {
                    var issue = result.responseText.split('"')[1].split('"')[0];
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/perTableS",
                        data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + issue + "'}",
                        dataType: "json",
                        success: function (data) {
                            $("#div_Stati").html(HtmlDecode(data));
                        }
                    });

                }
            });
        }
        if ($("#fd").hasClass("chartTab_on")) {
            //获取期号
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Period",
                data: "{lottID:'1'}",
                dataType: "json",
                complete: function (result) {
                    var issue = result.responseText.split('"')[1].split('"')[0];
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/perTableD",
                        data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + issue + "'}",
                        dataType: "json",
                        success: function (data) {
                            $("#div_Stati").html(HtmlDecode(data));
                        }
                    });

                }
            });
        }
        if ($("#pl").hasClass("chartTab_on")) {
            //获取期号
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Period",
                data: "{lottID:'4'}",
                dataType: "json",
                complete: function (result) {
                    var issue = result.responseText.split('"')[1].split('"')[0];
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/perTableP",
                        data: "{num:'" + $("#sel_issN").val() + "',username:'" + $("#uname").val() + "',issue:'" + issue + "'}",
                        dataType: "json",
                        success: function (data) {
                            $("#div_Stati").html(HtmlDecode(data));
                        }
                    });

                }
            });
        }

    });
    //全部成绩对比 （CompOF.aspx 页面初始加载）
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/TabCompOFS",
        data: "{issNum:'" + $("#sel_issue").val() + "'}",
        dataType: "json",
        success: function (data) {
            $("#div_table").html(HtmlDecode(data));
        }
    });
    //选择期数 绑定数据
    $("#sel_issue").change(function () {
        if ($("#sq").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/TabCompOFS",
                data: "{issNum:'" + $("#sel_issue").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_table").html(HtmlDecode(data));
                }
            });
        }
        if ($("#fd").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/TabCompOFS_D",
                data: "{issNum:'" + $("#sel_issue").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_table").html(HtmlDecode(data));
                }
            });
        }
        if ($("#pl").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/TabCompOFS_P",
                data: "{issNum:'" + $("#sel_issue").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_table").html(HtmlDecode(data));
                }
            });
        }

    });

    //成绩榜 （PerRank.aspx 页面初始加载）
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

    //个人成绩列表  （HistoryA.aspx 页面初始加载）
    var uName = getreqName();
    $("#s_uName").html(uName);
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/UserAchienement",
        data: "{userName:'" + uName + "',issueNum:'" + $("#issueNum").val() + "'}",
        dataType: "json",
        success: function (data) {
            $("#div_cond").html(HtmlDecode(data));
        }
    });
    //选择显示的个数（HistoryA.aspx）
    $("#issueNum").change(function () {
        if ($("#ss").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/UserAchienement",
                data: "{userName:'" + uName + "',issueNum:'" + $("#issueNum").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_cond").html(HtmlDecode(data));
                }
            });
        }
        if ($("#sd").hasClass("hover")) {

            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/UserAchienement_d",
                data: "{userName:'" + uName + "',issueNum:'" + $("#issueNum").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_cond").html(HtmlDecode(data));
                }
            });
        }
        if ($("#ps").hasClass("hover")) {

            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/UserAchienement_p",
                data: "{userName:'" + uName + "',issueNum:'" + $("#issueNum").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#div_cond").html(HtmlDecode(data));
                }
            });
        }
    });

    //初始化成绩对比页面   contrast.aspx
    var lottN = getreq();

    //显示条件名
    $("#cont").html(SwapName(lottN.split('&')[0]));
    $("#lcond").html(SwapName(lottN.split('&')[0]));
    //显示彩种名
    if (lottN.split('&')[1] == "n") {
        $("#lottName").html("双色球");
        $("#lottN").html("双色球");
    }
    if (lottN.split('&')[1] == "d") {
        $("#lottName").html("3D");
        $("#lottN").html("3D");
    }
    if (lottN.split('&')[1] == "p") {
        $("#lottName").html("排列三");
        $("#lottN").html("排列三");
    }
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/LottCon",
        data: "{num:'" + $("#selNum").val() + "',cond:'" + lottN.split('&')[0] + "'}",
        dataType: "json",
        success: function (data) {
            $("#result").html(HtmlDecode(data));
        }
    });
    //contrast.aspx 页面切换条数
    $("#selNum").change(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/LottCon",
            data: "{num:'" + $("#selNum").val() + "',cond:'" + lottN.split('&')[0] + "'}",
            dataType: "json",
            success: function (data) {
                $("#result").html(HtmlDecode(data));
            }
        });
    });
    //显示全部数据
    $("#ShawAll").click(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/LottCon",
            data: "{num:'100000',cond:'" + lottN.split('&')[0] + "'}",
            dataType: "json",
            success: function (data) {
                $("#result").html(HtmlDecode(data));
            }
        });
    });
    /******首页上下翻页*******/
    //显示期号
    //    $("#txt_issue").attr("value", $("#issue").val());
    $("#theLast").click(function () {
        //上一期期号
        var n_issue = $("#issue").val() - 1;
        $("#txt_issue").attr("value", n_issue);
        //双色球按钮被选中
        if ($("#lbtn_s").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'s',issue:'" + n_issue + "',name:'0'}",
                dataType: "json",
                success: function (data) {
                    $("#ssq_content").html(HtmlDecode(data));
                    $("#issue").attr("value", n_issue);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/lottOpenNum",
                        data: "{lottID:'3',issue:'" + n_issue + "'}",
                        dataType: "json",
                        complete: function (result) {
                            $("#openN").html(n_issue + "期双色球开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                        }
                    });

                }
            });
        }
        //福彩3D
        if ($("#lbtn_d").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'d',issue:'" + n_issue + "',name:'0'}",
                dataType: "json",
                success: function (data) {
                    $("#D_content").html(HtmlDecode(data));
                    $("#issue").attr("value", n_issue);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/lottOpenNum",
                        data: "{lottID:'1',issue:'" + n_issue + "'}",
                        dataType: "json",
                        complete: function (result) {
                            $("#openN").html(n_issue + "期福彩3D开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                        }
                    });
                }
            });
        }
        //排列3
        if ($("#lbtn_p").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'p',issue:'" + n_issue + "',name:'0'}",
                dataType: "json",
                success: function (data) {
                    $("#P_content").html(HtmlDecode(data));
                    $("#issue").attr("value", n_issue);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/lottOpenNum",
                        data: "{lottID:'9999',issue:'" + n_issue + "'}",
                        dataType: "json",
                        complete: function (result) {
                            $("#openN").html(n_issue + "期排列三开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                        }
                    });
                }
            });
        }
    });
    $("#next").click(function () {
        //下一期
        var n_issue = parseInt($("#issue").val()) + 1;
        $("#txt_issue").attr("value", n_issue);
        //双色球按钮被选中
        if ($("#lbtn_s").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'s',issue:'" + n_issue + "',name:'0'}",
                dataType: "json",
                success: function (data) {
                    $("#ssq_content").html(HtmlDecode(data));
                    $("#issue").attr("value", n_issue);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/lottOpenNum",
                        data: "{lottID:'3',issue:'" + n_issue + "'}",
                        dataType: "json",
                        complete: function (result) {
                            $("#openN").html(n_issue + "期双色去开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                        }
                    });
                }
            });
        }
        //福彩3D
        if ($("#lbtn_d").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'d',issue:'" + n_issue + "',name:'0'}",
                dataType: "json",
                success: function (data) {
                    $("#D_content").html(HtmlDecode(data));
                    $("#issue").attr("value", n_issue);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/lottOpenNum",
                        data: "{lottID:'1',issue:'" + n_issue + "'}",
                        dataType: "json",
                        complete: function (result) {
                            $("#openN").html(n_issue + "期福彩3D开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                        }
                    });
                }
            });
        }
        //排列3
        if ($("#lbtn_p").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'p',issue:'" + n_issue + "',name:'0'}",
                dataType: "json",
                success: function (data) {
                    $("#P_content").html(HtmlDecode(data));
                    $("#issue").attr("value", n_issue);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/lottOpenNum",
                        data: "{lottID:'9999',issue:'" + n_issue + "'}",
                        dataType: "json",
                        complete: function (result) {
                            $("#openN").html(n_issue + "期排列三开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                        }
                    });
                }
            });
        }
    });
    /***搜索***/
    $("#Search").click(function () {
        //双色球按钮被选中
        if ($("#lbtn_s").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'s',issue:'" + $("#txt_issue").val() + "',name:'" + $("#txt_issue").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#ssq_content").html(HtmlDecode(data));
                }
            });
        }
        //福彩3D
        if ($("#lbtn_d").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'d',issue:'" + $("#txt_issue").val() + "',name:'" + $("#txt_issue").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#D_content").html(HtmlDecode(data));
                }
            });
        }
        //排列3
        if ($("#lbtn_p").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../ChallSer.asmx/Flip",
                data: "{lottN:'p',issue:'" + $("#txt_issue").val() + "',name:'" + $("#txt_issue").val() + "'}",
                dataType: "json",
                success: function (data) {
                    $("#P_content").html(HtmlDecode(data));
                }
            });
        }
    });
    /***搜索***/

    //选择下拉期号
    $("#ddl_issue").change(function () {
        //        if ($("#ddl_issue").val() != 0) {
        //            $("#txt_issue").attr("value", $("#ddl_issue").val());
        //        }
        //双色球按钮被选中
        if ($("#lbtn_s").hasClass("hover")) {
            if ($("#ddl_issue").val() == 0) {
                //获取期号
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/Period",
                    data: "{lottID:'3'}",
                    dataType: "json",
                    complete: function (result) {
                        var n_issue = result.responseText.split('"')[1].split('"')[0];
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/Flip",
                            data: "{lottN:'s',issue:'" + n_issue + "',name:'0'}",
                            dataType: "json",
                            success: function (data) {
                                $("#ssq_content").html(HtmlDecode(data));
                                $("#issue").attr("value", n_issue);
                            }
                        });
                    }
                });
            }
            else {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/Flip",
                    data: "{lottN:'s',issue:'" + $("#ddl_issue").val() + "',name:'0'}",
                    dataType: "json",
                    success: function (data) {
                        $("#ssq_content").html(HtmlDecode(data));
                        $("#issue").attr("value", $("#ddl_issue").val());
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/lottOpenNum",
                            data: "{lottID:'3',issue:'" + $("#ddl_issue").val() + "'}",
                            dataType: "json",
                            complete: function (result) {
                                $("#openN").html($("#ddl_issue").val() + "期双色球开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                            }
                        });
                    }
                });
            }
        }
        //福彩3D
        if ($("#lbtn_d").hasClass("hover")) {
            if ($("#ddl_issue").val() == 0) {
                //获取期号
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/Period",
                    data: "{lottID:'1'}",
                    dataType: "json",
                    complete: function (result) {
                        var n_issue = result.responseText.split('"')[1].split('"')[0];
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/Flip",
                            data: "{lottN:'d',issue:'" + n_issue + "',name:'0'}",
                            dataType: "json",
                            success: function (data) {
                                $("#D_content").html(HtmlDecode(data));
                                $("#issue").attr("value", n_issue);
                            }
                        });
                    }
                });
            }
            else {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/Flip",
                    data: "{lottN:'d',issue:'" + $("#ddl_issue").val() + "',name:'0'}",
                    dataType: "json",
                    success: function (data) {
                        $("#D_content").html(HtmlDecode(data));
                        $("#issue").attr("value", $("#ddl_issue").val());
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/lottOpenNum",
                            data: "{lottID:'1',issue:'" + $("#ddl_issue").val() + "'}",
                            dataType: "json",
                            complete: function (result) {
                                $("#openN").html($("#ddl_issue").val() + "期福彩3D开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                            }
                        });
                    }
                });
            }
        }
        //排列3
        if ($("#lbtn_p").hasClass("hover")) {
            if ($("#ddl_issue").val() == 0) {
                //获取期号
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/Period",
                    data: "{lottID:'9999'}",
                    dataType: "json",
                    complete: function (result) {
                        var n_issue = result.responseText.split('"')[1].split('"')[0];
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/Flip",
                            data: "{lottN:'p',issue:'" + n_issue + "',name:'0'}",
                            dataType: "json",
                            success: function (data) {
                                $("#P_content").html(HtmlDecode(data));
                                $("#issue").attr("value", n_issue);
                            }
                        });
                    }
                });
            }
            else {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../ChallSer.asmx/Flip",
                    data: "{lottN:'p',issue:'" + $("#ddl_issue").val() + "',name:'0'}",
                    dataType: "json",
                    success: function (data) {
                        $("#P_content").html(HtmlDecode(data));
                        $("#issue").attr("value", $("#ddl_issue").val());
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../ChallSer.asmx/lottOpenNum",
                            data: "{lottID:'9999',issue:'" + $("#ddl_issue").val() + "'}",
                            dataType: "json",
                            complete: function (result) {
                                $("#openN").html($("#ddl_issue").val() + "期排列三开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                            }
                        });
                    }
                });
            }
        }
        var issue = $("#ddl_issue").val();
        var cond = $("#ddl_cond").val();
        var chart;
        var g_num = "";

        var playName = 0;
        if ($("#lbtn_s").hasClass("hover")) {
            playName = 3;
        }
        if ($("#lbtn_d").hasClass("hover")) {
            playName = 1;
        }
        if ($("#lbtn_p").hasClass("hover")) {
            playName = 9999;
        }

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/AppearNumIssue",
            data: "{playName:'" + playName + "',top:'*',cond:'" + cond + "',issue:'" + issue + "'}",
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
    });

    /*******柱状图表区**********/
    //    //初始化
    //    $.ajax({
    //            type: "POST",
    //            contentType: "application/json",
    //            url: "../ChallSer.asmx/AppearNum",
    //            data: "{playName:'3',top:'*',cond:'红球3胆'}",
    //            dataType: "json",
    //            complete: function (result) {
    //                g_num = result.responseText.split('"')[1].split('"')[0];
    //              document.getElementById("containerB").style.display = "none";
    //                        redColumn('红球3胆', g_num.split('+')[0], $("#issue").val());
    //            }
    //    });
    $("#ddl_cond").change(function () {
        //        var issue = $("#issue").val();
        var issue = $("#ddl_issue").val();
        var cond = $("#ddl_cond").val();
        var chart;
        var g_num = "";

        var playName = 0;
        if ($("#lbtn_s").hasClass("hover")) {
            playName = 3;
        }
        if ($("#lbtn_d").hasClass("hover")) {
            playName = 1;
        }
        if ($("#lbtn_p").hasClass("hover")) {
            playName = 9999;
        }

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/AppearNumIssue",
            data: "{playName:'" + playName + "',top:'*',cond:'" + cond + "',issue:'" + issue + "'}",
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

    });
    /*******柱状图表区**********/
    /******首页上下翻页*******/

    //添加关注
    $("#addTo").click(function () {
        //获取url中的 IdolName
        var Request = new Object();
        Request = GetRequest();
        //获取偶像名称
        var IdolName = Request['name'];

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/addTo",
            data: "{IdolName:'" + escape(IdolName) + "',sign:'pblt'}",
            dataType: "json",
            complete: function (result) {
                //            var prar = result.responseText.split('"')[1].split('"')[0];
                if (result.responseText == 3) {
                    alert("您没有登录，请先登录");
                    return false;
                }
                if (result.responseText == 0) {
                    alert("添加关注失败");
                    return false;
                }
                if (result.responseText == 2) {
                    alert("您已经关注了当前会员");
                    return false;
                }
                if (result.responseText == 1) {
                    alert("关注成功");
                    history.go(0);
                    return false;
                }
            }
        });
    });
    //取消关注
    $("#delTo").click(function () {

        //获取url中的 IdolName
        var Request = new Object();
        Request = GetRequest();
        //获取偶像名称
        var IdolName = Request['name'];
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/delTo",
            data: "{IdolName:'" + escape(IdolName) + "',sign:'pblt'}",
            dataType: "json",
            complete: function (result) {
                //            var prar = result.responseText.split('"')[1].split('"')[0];
                if (result.responseText == 3) {
                    alert("您没有登录，请先登录");
                    return false;
                }
                if (result.responseText == 0) {
                    alert("取消失败");
                    return false;
                }
                if (result.responseText == 2) {
                    alert("您还没有关注会员");
                    return false;
                }
                if (result.responseText == 1) {
                    alert("已取消对会员的关注");
                    return false;
                }
            }
        });
    });
    //切换显示区  我关注的人
    $("#Li2").click(function () {
        $("#Li3").removeClass("tabs-nav chartTab_on");
        $("#Li2").addClass("tabs-nav chartTab_on");
        //获取url中的 IdolName
        var Request = new Object();
        Request = GetRequest();
        //获取偶像名称
        var IdolName = Request['name'];
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/Ipayatt",
            data: "{name:'" + IdolName + "'}",
            dataType: "json",
            success: function (data) {
                $("#PayAttTable").html(HtmlDecode(data));
            }
        });
    });

    //关注我的人
    $("#Li3").click(function () {
        $("#Li2").removeClass("tabs-nav chartTab_on");
        $("#Li3").addClass("tabs-nav chartTab_on");

        //获取url中的 IdolName
        var Request = new Object();
        Request = GetRequest();
        //获取偶像名称
        var IdolName = Request['name'];
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/batt",
            data: "{name:'" + IdolName + "'}",
            dataType: "json",
            success: function (data) {
                $("#PayAttTable").html(HtmlDecode(data));
            }
        });
    });

});

//获取url地址栏的值  contrast.aspx 获取传递的值
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
//取值
function getreq() {
    //获取url中的 lottery参数
    var Request = new Object();
    Request = GetRequest();
    var lottery = Request['Ind'];

    var lott = Request['n'];
    return lottery+"&"+lott;
}

//取值 //个人成绩列表  （HistoryA.aspx 页面初始加载获取会员名）
function getreqName() {
    //获取url中的 lottery参数
    var Request = new Object();
    Request = GetRequest();
    var name = Request['name'];
    return name;
}



//html编码
function HtmlEncode(text) {
    return text.replace(/&/g, '&amp').replace(/\"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');

}
//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}



//对换条件名称
function SwapName(name) {
    if (name == "hq3d") {
        return "红球3胆";
    }
    if (name == "hq6d") {
        return "红球6胆";
    }
    if (name == "s3hq") {
        return "杀3红球";
    }
    if (name == "s6hq") {
        return "杀6红球";
    }
    if (name == "lq1d") {
        return "蓝球1胆";
    }
    if (name == "lq3d") {
        return "蓝球3胆";
    }
    if (name == "s3lq") {
        return "杀3蓝球";
    }
    if (name == "s6lq") {
        return "杀6蓝球";
    }
    if (name == "h3l") {
        return "12红+3蓝";
    }
    if (name == "h2l") {
        return "9红+2蓝";
    }
    if (name == "dd") {
        return "独胆";
    }
    if (name == "sd") {
        return "双胆";
    }
    if (name == "zx1z") {
        return "组选1注";
    }
    if (name == "s1m") {
        return "杀1码";
    }
    if (name == "s2m") {
        return "杀2码";
    }
    if (name == "dk") {
        return "独跨";
    }
    if (name == "dh") {
        return "独合";
    }
    if (name == "s1h") {
        return "杀1合";
    }
    if (name == "5dw") {
        return "5*5*5定位";
    }
    if (name == "3dw") {
        return "3*3*3定位";
    }
    if (name == "zx") {
        return "组选1注";
    }
    if (name == "m") {
        return "5码";
    }
}
//快速选号的处理函数
function selectcode(num, strtext,obj) {
    var str = "";
    switch (strtext) {
        case 'selall':
            {
                str = '0,1,2,3,4,5,6,7,8,9'; break;
            } case 'delall':
            {
                str = "";
                break;
            } case 'seljin':
            {
                str = '1,3,5,7,9'; break;
            } case 'selou':
            {
                str = '0,2,4,6,8'; break;
            } case 'selda':
            {
                str = '5,6,7,8,9'; break;
            } case 'selxiao':
            {
                str = '0,1,2,3,4'; break;
            }
    }

    var haoma = document.getElementsByName("haoma"+obj);
    for (j = 0; j < 10; j++) {
        if (str.indexOf(j) != -1) {
            haoma[j].className = "rb";
        }
        else {
            haoma[j].className = "gb";
        }

    }
}

//contrast.aspx 页面彩种切换
function btnColorNa(obj) {
    if (obj == "s") {
        $("#s").addClass("hover");
        $("#d").removeClass("hover");
        $("#p").removeClass("hover");
        $("#lottName").html("双色球");
        $("#lcond").html("红球3胆");
        $("#lottN").html("双色球");
        $("#cont").html("红球3胆");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/LottCon",
            data: "{num:'" + $("#selNum").val() + "',cond:'hq3d'}",
            dataType: "json",
            success: function (data) {
                $("#result").html(HtmlDecode(data));
            }
        });
    }
    if (obj == "d") {
        $("#d").addClass("hover");
        $("#s").removeClass("hover");
        $("#p").removeClass("hover");
        $("#lottName").html("福彩3D");
        $("#lcond").html("独胆");
        $("#lottN").html("福彩3D");
        $("#cont").html("独胆");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/LottCon",
            data: "{num:'" + $("#selNum").val() + "',cond:'dd'}",
            dataType: "json",
            success: function (data) {
                $("#result").html(HtmlDecode(data));
            }
        });
    }
    if (obj == "p") {
        $("#p").addClass("hover");
        $("#d").removeClass("hover");
        $("#s").removeClass("hover");
        $("#lottName").html("排列三");
        $("#lcond").html("独胆");
        $("#lottN").html("排列三");
        $("#cont").html("独胆");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/LottCon",
            data: "{num:'" + $("#selNum").val() + "',cond:'pdd'}",
            dataType: "json",
            success: function (data) {
                $("#result").html(HtmlDecode(data));
            }
        });
    }
}