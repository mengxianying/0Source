$(document).ready(function () {

    //选择下拉期号
    $("#ddl_issue").change(function () {
        //福彩3D
        if ($("#lbtn_dx").hasClass("hover") || $("#lbtn_zx").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../DataList.asmx/lottOpenNum",
                data: "{lottID:'1',issue:'" + $("#ddl_issue").val() + "'}",
                dataType: "json",
                complete: function (result) {
                    $("#openN").html($("#ddl_issue").val() + "期  福彩3D开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                }
            });
        }
        //排列3
        if ($("#lbtn_p").hasClass("hover") || $("#lbtn_pz").hasClass("hover")) {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "../DataList.asmx/lottOpenNum",
                data: "{lottID:'9999',issue:'" + $("#ddl_issue").val() + "'}",
                dataType: "json",
                complete: function (result) {
                    $("#openN").html($("#ddl_issue").val() + "期  排列三开奖号码：<font color='red'>" + result.responseText.split('"')[1].split('"')[0] + "</font>");
                }
            });
        }
    });


});