/*************处理数字彩统计***************/
function InsertShow() {	//重新统计
    //开始统计注数
    var Ps = 0; //注数变量
    var Temp = document.getElementById("schemeNum"); 	//下拉列表变量
    var code = "";
    var textstr = "";
    var valuestr = "";
    var Inab = Temp.length - 1;
    for (i = 0; i <= Inab; i++) {
        var Ts = Temp.options[i].value.split("|");
        Ps = Ps + parseInt(Ts[2]);
        if (i == Inab) {
            code = code + Ts[0] + "|" + Ts[1];
            textstr = textstr + Temp.options[i].text;
            valuestr = valuestr + Temp.options[i].value;
        }
        else {
            code = code + Ts[0] + "|" + Ts[1] + ";";
            textstr = textstr + Temp.options[i].text + ";";
            valuestr = valuestr + Temp.options[i].value + ";";
        }

    }
    if (Ps > 500) {
        alert('您一次最多能投500注');
        return false;
    }
    var beishu = document.getElementById("setbeishu").value;
    //倍数的最大值不能超过99
    if (beishu > 99) {
        beishu = 99;
        $("#setbeishu").attr("value", 99);
    }
    /*******处理追号倍数**********/
    //选择追号
    if ($("input[name='buy']:checked").val() == "track") {
        //添加期号信息
        var divID = document.getElementById("div_track");
        //获取input集合
        var inputSet = divID.getElementsByTagName("INPUT");
        for (var i = 0; i < inputSet.length; i++) {
            $("#txt_z_" + i).attr("value", $("#setbeishu").val());
            $("#money_z_" + i).html(formatCurrency(Ps * 2 * beishu));
        }
    }
    /*******处理追号倍数**********/
    document.getElementById("danbeizhushu").innerHTML = 0;
    document.getElementById("danbeimoney").innerHTML = 0;
    document.getElementById("showdanbeizhushu").innerHTML = Ps;
    document.getElementById("showbeishu").innerHTML = beishu;
    document.getElementById("showallmoney").innerHTML = Ps * 2 * beishu;

    //划分的份数
    var nOnlyCopy = $("#txt_copy").val();
    //划分的份数不能为0    根据分的 份数统计每一份的价格
    if ($("#txt_copy").val() == 0 || $("#txt_copy").val() == "" || $("#txt_copy").val() == null) {
        $("#lab_money").html("0");
        $("#money").html("0");
        $("#num_money").html("0");
        return false;
    }
    else {
        //划分份数后 金额小于0.2
        if (Ps != 0 && Ps * 2 * beishu / nOnlyCopy < 0.2) {

            $("#txt_copy").attr("value", Ps * 2 * beishu / 0.2);
            nOnlyCopy = Ps * 2 * beishu / 0.2
            $("#lab_money").html(Math.round((Ps * 2 * beishu / nOnlyCopy) * 10000) / 10000);
        }
        else {
            $("#lab_money").html(Math.round((Ps * 2 * beishu / nOnlyCopy) * 10000) / 10000);
        }
    }

    //计算选择份 后的 价格
    var buymoneey = document.getElementById("txt_pcopy").value;
    //自己认购的份数不能大于划分的份数
    if (parseInt(buymoneey) > parseInt(nOnlyCopy)) {
        alert('购买份数不能大于划分的份数');
        $("#txt_pcopy").attr("value", nOnlyCopy);
        buymoneey = nOnlyCopy;
    }
    $("#money").html(Math.round((Ps * 2 * beishu / nOnlyCopy * buymoneey) * 100) / 100);

    //是否保底
    if ($("#ck_protect").attr("checked")) {
        //保底的份数金额
        var txtbd = document.getElementById("Text1").value;
        //保底份数不能大于所划分的 份数
        if (parseInt(txtbd) > parseInt(nOnlyCopy / 2)) {
            alert('您最多能保底' + nOnlyCopy / 2 + "份");
            txtbd = nOnlyCopy / 2;
            $("#Text1").attr("value", nOnlyCopy / 2);

        }
        $("#num_money").html(Math.round((Ps * 2 * beishu / nOnlyCopy * txtbd) * 100) / 100);
    }

    document.getElementById("danzhushu").value = Ps;
    document.getElementById("allmoney").value = Ps * 2 * beishu;
    document.getElementById("fileorcode").value = code;
    document.getElementById("textstr").value = textstr;
    document.getElementById("valuestr").value = valuestr;
    document.getElementById("beishu").value = beishu;
}
/*************处理数字彩统计***************/

//删除号码栏的单行
function Del_S() {
    var index = 0;
    var temp = document.getElementById('schemeNum');
    if (temp.length > 0) {
        index = temp.selectedIndex;
        if (index >= 0) {
            temp.remove(index);
        }
        try {
            if (index != 0 && temp.length > 0 && index < temp.length) {
                temp.options[index].selected = true;
            }
        }
        catch (e) { }
    }
    InsertShow();
}

//清空号码栏
function clearNum() {
    var Temp = document.getElementById("schemeNum");
    var len = Temp.options.length;
    for (i = 0; i < len; i++) {
        Temp.options[0] = null;
    }
    InsertShow();
}


function returnstate() {

}
//冒泡排序
function BubbleSort(arr) { //交换排序->冒泡排序
    var temp, exchange;
    for (var i = 0; i < arr.length; i++) {
        exchange = false;
        for (var j = arr.length - 2; j >= i; j--) {
            if (arr[j + 1] < (arr[j])) {
                temp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = temp;
                exchange = true;
            }
        }
        if (!exchange) break;
    }
    return arr;
}

function sort(arr) {			//冒泡排序	
    var temp, exchange;
    for (var i = 0; i < arr.length; i++) {
        exchange = false;
        for (var j = arr.length - 2; j >= i; j--) {
            if (arr[j + 1] < (arr[j])) {
                temp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = temp;
                exchange = true;
            }
        }
        if (!exchange) break;
    }
    return arr;
}
//去除重复 号码
function RemoveDuplicate(arr) {
    for (var i = 0; i < arr.length; i++) {
        for (var j = arr.length - 1; j > i; j--) {
            if (arr[j] == arr[i]) {
                arr.splice(j, 1);
            }
        }
    }
    return arr;
}

//分割字符
function Division(str) {
    //定义接收变量
    var ReturnStr="";
    for (var i = 0; i < str.length; i++) {
        ReturnStr += str.substr(i, 1) + ",";
    }
    return ReturnStr.substring(ReturnStr.length - 1, 0);
}

//投注提交
$(document).ready(function () {
    //提交按钮的点击事件（发起合买）
    $("#J_SubmitPay").click(function () {
        //是否选择了协议
        if ($("#Checkbox2").attr("checked") == false) {
            if (!confirm('您需要阅读并同意《用户合买代购协议》其中条款 才能进行投注！是否同意该规则？')) {
                return false;
            }
            else {
                $("#Checkbox2").attr("checked", "checked");
            }
        }
        //是否已过截止时间
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/Allow",
            data: "{playName:'" + $("#playName").val() + "'}",
            dataType: "json",
            complete: function (result) {
                if (result.responseText == 1) {
                    alert($("#ExpectNum").val() + '期投注已截止！');
                    return false;
                }
                else {
                    var username;
                    var Ps = 0; //注数变量
                    var Temp = document.getElementById("schemeNum");
                    var Inab = Temp.length - 1
                    for (i = 0; i <= Inab; i++) {
                        var Ts = Temp.options[i].value.split("|");
                        Ps = Ps + parseInt(Ts[2]);
                        Znum = Ps;
                    }
                    if (Ps == "" || Ps < 1) {
                        alert("请先选择投注号码，再投注!");
                        return false;
                    }
                    if (Ps > 500) {
                        alert('您最多能选择500注！');
                        return false;
                    }

                    //****添加信息*****//
                    var beishu = document.getElementById("setbeishu").value;
                    if (beishu == "" || beishu <= 0) {
                        alert("倍数设置不正确!");
                        return false;
                    }
                    //生成合买流水号
                    var qNum;

                    //获取选择或是上传的号码
                    var ChoiceNum = $("#fileorcode").val();
                    /****判断会员是否登录  Begin*****/
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "../WebChipped.asmx/username",
                        data: "{}",
                        dataType: "json",
                        complete: function (result) {
                            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                                //                                location.href="LoginPage.aspx";
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
                                if (result.responseText.split('"')[1].split('"')[0] == 1) {
                                    if (confirm('您不是高级用户，现在申请？')) {
                                        window.open('http://www.pinble.com/UserCenter/UserRealInfo.aspx')
                                        return false;
                                    }
                                    else {

                                        return false;
                                    }
                                }
                                username = result.responseText.split('"')[1].split('"')[0];
                                //获取流水号
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json",
                                    url: "../WebChipped.asmx/isomux",
                                    data: "{ExpectNum:'" + $("#ExpectNum").val() + "',playName:'" + $("#playName").val() + "'}",
                                    dataType: "json",
                                    complete: function (result) {
                                        if (result.responseText.split('"')[1].split('"')[0] == 0) {
                                            alert('流水号生成错误');
                                            return false;
                                        }
                                        else {
                                            //限制每一份最少是0.2元 且整除到分
                                            qNum = result.responseText.split('"')[1].split('"')[0];
                                            if (qNum == null || qNum == "" || qNum == 0) {
                                                return false;
                                            }
                                            /*****添加数据******/

                                            var protect;
                                            if ($("#ck_protect").attr("checked") == false) {
                                                //不保底
                                                protect = 0;
                                            }
                                            else {
                                                //保底份数
                                                protect = $("#Text1").val();
                                                if (protect == "" || protect == null) {
                                                    protect = 0;
                                                }
                                            }
                                            var nOnlyCopy = Ps * 2 * beishu / $("#txt_copy").val();
                                            if (nOnlyCopy.toString().indexOf('.') != -1 && nOnlyCopy.toString().split('.')[1].length > 2) {
                                                alert('划分份数要能整除到分,小数点后保留2位小数！请您重新划分');
                                                $("#txt_copy").attr("value", "1");
                                                $("#txt_pcopy").attr("value", "1");
                                                $("#lab_money").html(Ps * 2 * beishu / $("#txt_copy").val());
                                                $("#money").html(Ps * 2 * beishu / $("#txt_copy").val() * $("#txt_pcopy").val());
                                                return false;
                                            }
                                            //获取当前时间
                                            var time = new Date();
                                            var month = time.getMonth() < 10 ? time.getMonth() : time.getMonth();
                                            var day = time.getDate() < 10 ? "0" + time.getDate() : time.getDate();
                                            var date = time.getFullYear() + "-" + (parseInt(month) + 1) + "-" + day + " " + time.toLocaleTimeString();
                                            //代购合买
                                            if ($("input[name='buy']:checked").val() == "hm") {
                                                //方案标题
                                                if ($("#J_UnitedTitle").val() == "") {
                                                    alert('请给本次方案设置一个标题');
                                                    return false;
                                                }
                                                //划分的份数不能为空
                                                if ($("#txt_copy").val() == "" || $("#txt_copy").val() == 0) {
                                                    alert('最少要分1份');
                                                    return false;
                                                }
                                                //                                                //购买份数不能为空
                                                if ($("#txt_pcopy").val() == "" || $("#txt_pcopy").val() == 0) {
                                                    alert('您最少需要购买1份');
                                                    return false;
                                                }
                                                if ($("#txt_pcopy").val() > $("#txt_copy").val()) {
                                                    alert('您购买的份额超过划分份额');
                                                    return false;
                                                }
                                                if (!confirm("您本次投注方案金额为" + Ps * beishu * 2 + "元，共分" + $("#txt_copy").val() + "份 每份" + Ps * 2 * beishu / $("#txt_copy").val() + "元 请确认您的投注!")) {
                                                    return false;
                                                }
                                                $.ajax({
                                                    type: "POST",
                                                    contentType: "application/json",
                                                    url: "../WebChipped.asmx/addChipped",
                                                    data: "{num:'" + qNum + "',title:'" + $("#J_UnitedTitle").val() + "',say:'" + $("#mytext").val() + "',launchtime:'" + date + "',playname:'" + $("#playName").val() + "',expectnum:'" + $("#ExpectNum").val() + "',choicenum:'" + ChoiceNum + "',username:'" + username + "',doubles:'" + $("#beishu").val() + "',share:'" + $("#txt_copy").val() + "',obj:'" + $("input[name='isSecret']:checked").val() + "',buyshare:'" + $("#txt_pcopy").val() + "',protect:'" + protect + "',commisstion:'" + $("#proportion").val() + "',purchasing:'2',AtotalMoney:'" + $("#allmoney").val() + "',Statc:'0'}",
                                                    dataType: 'json',
                                                    complete: function (result) {
                                                        //result返回的值
                                                        if (result.responseText == 1) {
                                                            if (confirm("下单成功！\r\n点击取消：继续购买彩票！\r\n点击确定：可立即查看订单状态！\r\n请您在“购彩记录”查询所有订单状态")) {
                                                                $("#J_SubmitPay").hide();
                                                                parent.mainFrame.location.href = "../admin/BuyRecord.aspx";
                                                                return false;
                                                            }
                                                            else {
                                                                //刷新页面
                                                                history.go(0);
                                                                return false;
                                                            }
                                                        }
                                                        if (result.responseText == 3) {
                                                            if (confirm("下单成功！\r\n点击取消：继续购买彩票！\r\n点击确定：可立即查看订单状态！\r\n请您在“购彩记录”查询所有订单状态")) {
                                                                $.ajax({
                                                                    type: "POST",
                                                                    contentType: "application/json",
                                                                    url: "../WebChipped.asmx/selectDrawer",
                                                                    data: "{Qnum:'" + qNum + "'}",
                                                                    dataType: 'json',
                                                                    complete: function (result) {
                                                                    }
                                                                });
                                                                $("#J_SubmitPay").hide();
                                                                parent.mainFrame.location.href = "../admin/BuyRecord.aspx";
                                                                return false;
                                                            }
                                                            else {
                                                                $.ajax({
                                                                    type: "POST",
                                                                    contentType: "application/json",
                                                                    url: "../WebChipped.asmx/selectDrawer",
                                                                    data: "{Qnum:'" + qNum + "'}",
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
                                                            alert('下单失败');
                                                            return false;
                                                        }
                                                    }
                                                });

                                            }
                                            if ($("input[name='buy']:checked").val() == "dg") {
                                                if (!confirm("您本次投注方案金额为" + Ps * beishu * 2 + "元，请确认您的投注!")) {
                                                    return false;
                                                }
                                                $.ajax({
                                                    type: "POST",
                                                    contentType: "application/json",
                                                    url: "../WebChipped.asmx/addChipped",
                                                    data: "{num:'" + qNum + "',title:'',say:'',launchtime:'" + date + "',playname:'" + $("#playName").val() + "',expectnum:'" + $("#ExpectNum").val() + "',choicenum:'" + ChoiceNum + "',username:'" + username + "',doubles:'" + $("#beishu").val() + "',share:'" + $("#txt_copy").val() + "',obj:'0',buyshare:'" + $("#txt_pcopy").val() + "',protect:'" + protect + "',commisstion:'" + $("#proportion").val() + "',purchasing:'1',AtotalMoney:'" + $("#allmoney").val() + "',Statc:'0'}",
                                                    dataType: 'json',
                                                    //  error:function(re){
                                                    //                        debugger;
                                                    //                         alert(re.d);
                                                    //                         },
                                                    complete: function (result) {
                                                        //result返回的值
                                                        if (result.responseText == 1) {
                                                            if (confirm("下单成功！\r\n点击取消：继续购买彩票！\r\n点击确定：可立即查看订单状态！\r\n请您在“购彩记录”查询所有订单状态")) {
                                                                $.ajax({
                                                                    type: "POST",
                                                                    contentType: "application/json",
                                                                    url: "../WebChipped.asmx/selectDrawer",
                                                                    data: "{Qnum:'" + qNum + "'}",
                                                                    dataType: 'json',
                                                                    complete: function (result) {
                                                                    }
                                                                });
                                                                $("#J_SubmitPay").hide();
                                                                parent.mainFrame.location.href = "../admin/BuyRecord.aspx";
                                                                return false;
                                                            }
                                                            else {
                                                                $.ajax({
                                                                    type: "POST",
                                                                    contentType: "application/json",
                                                                    url: "../WebChipped.asmx/selectDrawer",
                                                                    data: "{Qnum:'" + qNum + "'}",
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
                                                            alert('下单失败');
                                                            return false;
                                                        }
                                                    }
                                                });
                                            }
                                            if ($("input[name='buy']:checked").val() == "track") {
                                                //选择了截止条件 不能为空

                                                var cond = "";
                                                if ($("#zh_bonus").attr("checked") == true) {
                                                    if ($("#zh_money").val() == "") {
                                                        alert("请设定一个结束追号的数字");
                                                        return false;
                                                    }
                                                    else {
                                                        cond = $("#zh_money").val();
                                                    }
                                                }
                                                //添加期号信息
                                                var divID = document.getElementById("div_track");
                                                //获取input集合
                                                var inputSet = divID.getElementsByTagName("INPUT");
                                                //期号
                                                var issue = "";
                                                //倍数
                                                var doubel = "";
                                                var InMoney = "";
                                                var dg = 0;
                                                for (var i = 1; i < inputSet.length / 2 + 1; i++) {
                                                    if ($("#check_z_" + i).attr("checked") == true) {
                                                        //倍数
                                                        doubel += $("#txt_z_" + i).val() + "|";
                                                        issue += $("#exp_z_" + i).text().replace(/\s+/g, "") + "|";
                                                        InMoney += $("#txt_z_" + i).val() * $("#danzhushu").val() * 2 + "|";
                                                        dg = dg + 1;
                                                    }

                                                }
                                                if ($("#ExpectNum").val() == issue.split('|')[0]) {
                                                    if (!confirm("您本次共追" + dg + "期,扣除您本期消费金额" + InMoney.split('|')[0] + "元")) {
                                                        return false;
                                                    }
                                                }
                                                else {
                                                    if (!confirm("您本次共追" + dg + "期")) {
                                                        return false;
                                                    }
                                                }
                                                $.ajax({
                                                    type: "POST",
                                                    contentType: "application/json",
                                                    url: "../WebChipped.asmx/trackNum",
                                                    data: "{SerialNum:'" + qNum + "',username:'" + username + "',playName:'" + $("#playName").val() + "',stopCondition:'" + cond + "',issue:'" + issue.substring(issue.length - 1, 0) + "',num:'" + ChoiceNum + "',multiple:'" + doubel.substring(doubel.length - 1, 0) + "',money:'" + InMoney.substring(InMoney.length - 1, 0) + "',message:'1',CurrentIssue:'" + $("#ExpectNum").val() + "'}",
                                                    dataType: 'json',
                                                    complete: function (result) {
                                                        //result返回的值
                                                        if (result.responseText == 1) {
                                                            if (confirm("下单成功！\r\n点击取消：继续购买彩票！\r\n点击确定：可立即查看订单状态！\r\n请您在“追号记录”查询所有订单状态")) {
                                                                $.ajax({
                                                                    type: "POST",
                                                                    contentType: "application/json",
                                                                    url: "../WebChipped.asmx/DrawerSuc",
                                                                    data: "{Qnum:'" + qNum + "',issue:'" + $("#ExpectNum").val() + "'}",
                                                                    dataType: 'json',
                                                                    complete: function (result) {
                                                                    }
                                                                });

                                                                parent.mainFrame.location.href = "../admin/TrackNum.aspx";
                                                                return false;
                                                            }
                                                            else {
                                                                $.ajax({
                                                                    type: "POST",
                                                                    contentType: "application/json",
                                                                    url: "../WebChipped.asmx/DrawerSuc",
                                                                    data: "{Qnum:'" + qNum + "',issue:'" + $("#ExpectNum").val() + "'}",
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
                                                            alert('发起失败，请重新发起');
                                                            return false;
                                                        }
                                                    }
                                                });

                                            }
                                            /*****添加数据******/
                                        }
                                    }

                                });

                            }
                        }
                    });
                    /****判断会员是否登录 End*****/
                }
            }
        });

    });
});