$(document).ready(function () {
    //添加关注
    $("#addPayatt").click(function () {
        //验证是否登录
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../DataList.asmx/ulogin",
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
                        url: "../DataList.asmx/addPayAtt",
                        data: "{fansName:'" + result.responseText.split('"')[1].split('"')[0].toString() + "',idolName:'" + $("#uName").val() + "'}",
                        dataType: "json",
                        complete: function (result) {
                            if (result.responseText == 0) {
                                alert("添加关注失败,请请重新添加");
                                return false;
                            }
                            if (result.responseText == 1) {
                                alert("添加成功");
                                return false;
                            }
                            if (result.responseText == 2) {
                                alert("您已关注过该用户");
                                return false;
                            }
                            if (result.responseText == 3) {
                                alert("您不能关注自己!");
                                return false;
                            }
                        }
                    });
                }
            }
        });
    });

    //取消关注
    $("#deletePayatt").click(function () {
        //验证是否登录
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../DataList.asmx/ulogin",
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
                        url: "../DataList.asmx/DeletePayAtt",
                        data: "{fansName:'" + result.responseText.split('"')[1].split('"')[0].toString() + "',idolName:'" + $("#uName").val() + "'}",
                        dataType: "json",
                        complete: function (result) {
                            if (result.responseText == 0) {
                                alert("添加关注失败,请请重新添加");
                                return false;
                            }
                            if (result.responseText == 1) {
                                alert("取消成功");
                                return false;
                            }
                            if (result.responseText == 2) {
                                alert("您还未关注当前用户");
                                return false;
                            }
                        }
                    });
                }
            }
        });
    });

    //切换显示区  我关注的人
    $("#Li2").click(function () {

        $("#Li3").removeClass("tabs-nav chartTab_on");
        $("#Li2").addClass("tabs-nav chartTab_on");

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../DataList.asmx/Ipayatt",
            data: "{name:'" + $("#uName").val() + "'}",
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
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../DataList.asmx/batt",
            data: "{name:'" + $("#uName").val() + "'}",
            dataType: "json",
            success: function (data) {
                $("#PayAttTable").html(HtmlDecode(data));
            }
        });
    });

});

//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}

//取消关注 （我关注的人列表）
function CancelPayAtt(objName) {
    //验证是否登录
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../DataList.asmx/ulogin",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            if (result.responseText.split('"')[1].split('"')[0] == 0) {
                alert("请您先登录");
                return false;
            }
            else {
                if (result.responseText.split('"')[1].split('"')[0].toString() == $("#uName").val()) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../DataList.asmx/DeletePayAtt",
                        data: "{fansName:'" + result.responseText.split('"')[1].split('"')[0].toString() + "',idolName:'" + objName + "'}",
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
                else {
                    alert("您不能取消关注");
                    return false;
                }
            }
        }
    });
}