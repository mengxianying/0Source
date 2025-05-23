
function Insertdqxh() {
    var p = document.getElementById("Exc_Display");
    var inputs = p.getElementsByTagName("INPUT");

    var txt = document.getElementById("txt_multiple");
    if (txt.value > 500) {
        txt.value = 500;
    }
    if ($("#txt_num").val() > 10) {
        $("#txt_num").attr("value", 10);
    }
    for (var i = 0; i < inputs.length; i++) {
        inputs[i].value = txt.value;
        $("#CurrentMoney").html(formatCurrency(inputs[0].value * 2 * $("#txt_num").val()));
        //金额添加到隐藏变量
        $("#curr_money").attr("value", formatCurrency(inputs[0].value * 2 * $("#txt_num").val()));
        var money = inputs[i].value * 2 * $("#txt_num").val();
        //页面控件的下标
        var subnum = i + 1;
        $("#money_d_" + subnum).html(formatCurrency(money));

    }
    //用户余额 
    if ($("#lab_accMoney").text() != "" && $("#lab_accMoney").text() > 0) {
        $("#user_Balance").html($("#lab_accMoney").text() - $("#curr_money").val());
    }
    else {
        $("#user_Balance").html(0);
    }
}

$(document).ready(function () {
    //判断是否登录
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //判断是否登录
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                $("#username").html("您当前未登录");
            }
            else {
                //已登录
                $("#username").html(result.responseText.split('"')[1].split('"')[0]);
            }
        }
    });
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/GeneratingSeries",
        data: "{preid:'" + $("#preid").val() + "',num:'" + $("#EXc").val() + "',Lottory: 'TCDLTData',mod:'d',endtime:'" + $("#endtime").val() + "'}",
        dataType: "json",
        success: function (data) {
            $("#Exc_Display").html(HtmlDecode(data));
            Insertdqxh();
        }
    });
    $("#EXc").change(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/GeneratingSeries",
            data: "{preid:'" + $("#preid").val() + "',num:'" + $("#EXc").val() + "',Lottory: 'TCDLTData',mod:'d',endtime:'" + $("#endtime").val() + "'}",
            dataType: "json",
            success: function (data) {
                $("#Exc_Display").html(HtmlDecode(data));
                Insertdqxh();
            }
        });

    });

    //多期机选添加
    $("#btn_Confirm").click(function () {

        if ($("#check_d_1").attr("checked") == false) {
            if (!confirm("当前期: " + $("#ExpectNum").val() + " 已取消或暂停销售，确定将继续跟单其他期，否则请取消？")) {
                return false;
            }
        }

        if ($("#Checkbox1").attr("checked") != true) {
            if (!confirm('您需要阅读并同意《用户合买代购协议》其中条款 才能进行投注！是否同意该规则？')) {
                return false;
            }
            else {
                $("#Checkbox1").attr("checked", "checked");
            }
        }
        //是否选择结束条件
        //        if ($("#ck_end").attr("checked") != true) {
        //            alert('请选择结束条件');
        //            return false;
        //        }
        var begmoney = "0";
        if ($("#ck_end").attr("checked") == true) {
            if ($("#txt_money").val() != null && $("#txt_money").val() != "") {
                begmoney = $("#txt_money").val();
            }
            else {
                alert('请填写一个金额为截止条件！');
                return false;
            }
        }
        //判断是否登录
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/username",
            data: "{}",
            dataType: "json",
            complete: function (result) {
                //判断是否登录
                if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                    $.XYTipsWindow({
                        ___title: "用户登录",    //窗口标题文字
                        ___content: "iframe:login.aspx",    //内容{text|id|img|url|iframe}
                        ___width: "350",            //窗口宽度
                        ___height: "170",          //窗口离度
                        ___titleClass: "boxTitle", //窗口标题样式名称
                        ___closeID: "", 	//关闭窗口ID
                        ___time: "", 	    //自动关闭等待时间
                        ___drag: "___boxTitle", 	    //拖动手柄ID
                        ___showbg: true, 	//是否显示遮罩层
                        //	        ___offsets:{left:"auto",top:"auto"},//设定弹出层位置,默认居中
                        ___fns: function () {

                        } //关闭窗口后执行的函数
                    });
                }
                else {
                    //已登录

                    //余额是否充足
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../WebChipped.asmx/userMoneyInsufficient",
                        data: "{money:'" + $("#curr_money").val() + "'}",
                        dataType: "json",
                        complete: function (result) {
                            if (result.responseText == 0) {
                                alert('您的余额不足请先充值');
                            }
                            else {
                                //是否短信提示
                                var massage = 0;
                                if ($("#message").attr("checked") == true) {
                                    massage = 1;
                                }
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json",
                                    url: "../WebChipped.asmx/RandomNum",
                                    data: "{note:'" + $("#txt_num").val() + "',multiple:'" + $("#txt_multiple").val() + "',tmtion:'" + begmoney + "',mess:'" + massage + "',playState:'" + $("#playid").val() + "'}",
                                    dataType: "json",
                                    complete: function (result1) {
                                        if (result1.responseText == 0) {
                                            alert('发起失败，请重新发起');
                                        }
                                        else {
                                            //添加期号信息
                                            var divID = document.getElementById("Exc_Display");
                                            //获取input集合
                                            var inputSet = divID.getElementsByTagName("INPUT");
                                            var rdid = result1.responseText;
                                            var str = "";
                                            var InMoney = "";
                                            var doubel = "";
                                            for (var i = 1; i < inputSet.length / 2 + 1; i++) {
                                                if ($("#check_d_" + i).attr("checked") == true) {
                                                    //倍数
                                                    doubel += $("#txt_d_" + i).val() + "|";
                                                    //花费的金额
                                                    InMoney += $("#txt_d_" + i).val() * $("#txt_num").val() * 2 + "|";
                                                    str += $("#exp_d_" + i).text() + "|";
                                                }

                                            }
                                            $.ajax({
                                                type: "POST",
                                                contentType: "application/json",
                                                url: "../WebChipped.asmx/issueNum",
                                                data: "{RdID:'" + rdid + "',issue:'" + str.substring(str.length - 1, 0) + "',multiple:'" + doubel.substring(doubel.length - 1, 0) + "',money:'" + InMoney.substring(InMoney.length - 1, 0) + "'}",
                                                dataType: "json",
                                                complete: function (result2) {

                                                    if (result2.responseText.split('"')[1].split('"')[0] == 0) {
                                                        alert('添加期号出现错误。请重新添加');
                                                        return false;
                                                    }
                                                    else {
                                                        $.ajax({
                                                            type: "POST",
                                                            contentType: "application/json",
                                                            url: "../WebChipped.asmx/HandleIssue",
                                                            data: "{issueId:'" + result2.responseText.split('"')[1].split('"')[0] + "',playName:'" + $("#playid").val() + "',num:'" + $("#txt_num").val() + "',money:'" + formatCurrency($("#curr_money").val()) + "',expectnum: '" + str.split('|')[0] + "',RdID:'" + rdid + "'}",
                                                            dataType: "json",
                                                            complete: function (result3) {
                                                                if (result3.responseText == 1) {
                                                                    //购买成功 不包括当前期
                                                                    if (confirm("下单成功！\r\n点击取消：继续购买彩票！\r\n点击确定：可立即查看订单状态！\r\n请您在“多期记录”查询所有订单状态")) {
                                                                        parent.mainFrame.location.href = "../admin/ExpectList.aspx";
                                                                        return false;
                                                                    }
                                                                    else {
                                                                        //刷新页面
                                                                        history.go(0);
                                                                        return false;
                                                                    }
                                                                }
                                                                if (result3.responseText == 3) {
                                                                    //购买成功 并冻结了当前期金额 

                                                                    if (confirm("下单成功！\r\n点击取消：继续购买彩票！\r\n点击确定：可立即查看订单状态！\r\n请您在“多期记录”查询所有订单状态")) {
                                                                        $.ajax({
                                                                            type: "POST",
                                                                            contentType: "application/json",
                                                                            url: "../WebChipped.asmx/sDrawerDQ",
                                                                            data: "{Rn_id:'" + rdid + "',issue:'" + $("#ExpectNum").val() + "'}",
                                                                            dataType: 'json',
                                                                            complete: function (result) {
                                                                            }
                                                                        });
                                                                        parent.mainFrame.location.href = "../admin/ExpectList.aspx";
                                                                        return false;
                                                                    }
                                                                    else {
                                                                        $.ajax({
                                                                            type: "POST",
                                                                            contentType: "application/json",
                                                                            url: "../WebChipped.asmx/sDrawerDQ",
                                                                            data: "{Rn_id:'" + rdid + "',issue:'" + $("#ExpectNum").val() + "'}",
                                                                            dataType: 'json',
                                                                            complete: function (result) {
                                                                            }
                                                                        });
                                                                        //刷新页面
                                                                        history.go(0);
                                                                        return false;
                                                                    }
                                                                }
                                                                else {
                                                                    deleteDx(rdid);
                                                                }

                                                            }
                                                        });
                                                    }
                                                }
                                            });
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

//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}

//多期数据添加失败后删除
function deleteDx(rdid) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/deleteData",
        data: "{id:'" + rdid + "'}",
        dataType: "json",
        complete: function (result6) {
        }
    });
    alert('添加失败！');
    return false;
}