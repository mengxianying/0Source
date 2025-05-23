/****发布彩种****/

$(document).ready(function () {
    jQuery.ajaxSetup({ cache: false });

    //查询 publish.aspx 页的发布时间
    //查询是否截止发布
    //初始化  当前期号 (默认双色球发布)
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
                    complete: function (resultTime) {

                        var dateTime = resultTime.responseText.split('"')[1].split('"')[0];
                        //                            $("#clostime").html(dateTime);
                        $("#endTime").html("擂台截止时间为:" + dateTime);
                    }
                });

            }
        }
    });

    $("#btn_rel").click(function () {
        /****判断会员是否登录  Begin*****/
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../ChallSer.asmx/ulogin",
            data: "{}",
            dataType: "json",
            complete: function (result) {
                if (result.responseText.split('"')[1].split('"')[0] == 0) {
                    alert('您还没有登录请先登录');
                    return false;
                }
                else {

                    var username = result.responseText.split('"')[1].split('"')[0];
                    //提交按钮不可用  'disabled'
//                    $("#btn_rel").attr("disabled", true);

                    //判断是否选择了 必选项
                    if (!Verification()) {
                        alert("带*号得为必选项");
                        return false;
                    }
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../ChallSer.asmx/Allow",
                        data: "{playName:'" + $("#lottID").val() + "'}",
                        dataType: "json",
                        complete: function (result) {
                            if (result.responseText == 1) {
                                //提交按钮不可用  'disabled'
//                                $("#btn_rel").attr("disabled", false);
                                alert($("#issue").val() + '期擂台已截止！');
                                return false;
                            }
                            else {
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json",
                                    url: "../ChallSer.asmx/addChall",
                                    data: "{name:'" + username + "',lott:'" + $("#lottID").val() + "',issue:'" + $("#issue").val() + "',cond:'" + $("input[name='ssq']:checked").val() + "',num:'" + $("#fileorcode").val() + "'}",
                                    dataType: "json",
                                    complete: function (result) {
                                        //提交按钮不可用  'disabled'
//                                        $("#btn_rel").attr("disabled", false);
                                        if (result.responseText == 2) {
                                            alert('您本期已经参与，不能重复发布！');
                                            return false;
                                        }
                                        if (result.responseText == 1) {
                                            alert('发布成功');
                                            clearNum();
                                            return false;
                                        }
                                        if (result.responseText == 1) {
                                            alert('发布失败');
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

    //初始化 登录状态
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../ChallSer.asmx/ulogin",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            if (result.responseText.split('"')[1].split('"')[0] == 0) {
                //显示用户名
                $("#uName").html("您没有登录");
                return false;
            }
            else {
                //显示用户名
                $("#uName").html(result.responseText.split('"')[1].split('"')[0]);
                return false;
            }
        }

    });

});


//验证条件必选项 是否添加
function Verification() {
    //判断是否已经有选择是值
    if ($("#fileorcode").val() != "" || $("#fileorcode").val() != null) {

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
    }
    if ($("#lottID").val() == 3) {
        var n = 0;
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == "hq3d") {
                n = n + 1;
            }
            if (arr[i] == "s3hq") {
                n = n + 1;
            }
            if (arr[i] == "lq1d") {
                n = n + 1;
            }
            if (arr[i] == "s3lq") {
                n = n + 1;
            }
            if (arr[i] == "h3l") {
                n = n + 1;
            }

        }
        if (n == 5) {
            return true;
        }
        else {
            return false;
        }

    }
    if ($("#lottID").val() == 1) {
        var n = 0;
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == "dd") {
                n = n + 1;
            }
            if (arr[i] == "sd") {
                n = n + 1;
            }
            if (arr[i] == "zx1z") {
                n = n + 1;
            }
            if (arr[i] == "s1m") {
                n = n + 1;
            }
            if (arr[i] == "s2m") {
                n = n + 1;
            }
        }
        if (n == 5) {
            return true;
        }
        else {
            return false;
        }

    }
    if ($("#lottID").val() == 9999) {
        var n = 0;
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == "pdd") {
                n = n + 1;
            }
            if (arr[i] == "psd") {
                n = n + 1;
            }
            if (arr[i] == "pzx1z") {
                n = n + 1;
            }
            if (arr[i] == "ps1m") {
                n = n + 1;
            }
            if (arr[i] == "ps2m") {
                n = n + 1;
            }
        }
        if (n == 5) {
            return true;
        }
        else {
            return false;
        }

    }


}