$(document).ready(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../DataList.asmx/ulogin",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            if (result.responseText.split('"')[1].split('"')[0] != 0) {
                $("#uName").html(result.responseText.split('"')[1].split('"')[0] + "&nbsp;<font color=\"black\">已登录</font>");
            }

        }
    });

});