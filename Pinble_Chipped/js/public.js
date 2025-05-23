//切换显示区
function switchs() {
    //代购
    var rad_purchasing = document.getElementById("rad_purchasing");
    //合买
    var rad_chipped = document.getElementById("rad_chipped");
    //追号
    var rad_AfterNum = document.getElementById("TrackNum");
    if (rad_purchasing.checked == true) {
        document.getElementById("AfterNum").style.display = "none";
        document.getElementById("chipped").style.display = "none";
    }
    if (rad_chipped.checked == true) {
        document.getElementById("chipped").style.display = "block";
        document.getElementById("AfterNum").style.display = "none";
        //标题显示
        $("#J_UnitedTitle").attr("value", $("#ExpectNum").val() + "期");
        $("#J_UnitedTitle").attr("text", $("#ExpectNum").val() + "期");
        var obj = document.getElementById("J_UnitedTitle");
        checkLen(obj);
        $("#mytext").attr("value", "这个人有点懒，只惦记中大奖。");
        $("#mytext").attr("text", "这个人有点懒，只惦记中大奖。");
    }
    if (rad_AfterNum.checked == true) {
        document.getElementById("AfterNum").style.display = "block";
        document.getElementById("chipped").style.display = "none";
        catchOn();
    }
}
//显示追号部分
function catchOn() {
    /**************处理追号期号显示**************/
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/GeneratingSeries",
        data: "{preid:'" + $("#ExpectNum").val() + "',num:'" + $("#sel_track").val() + "',Lottory: 'TCDLTData',mod:'z',endtime:'" + $("#endtime").val() + "'}",
        dataType: "json",
        success: function (data) {
            $("#div_track").html(HtmlDecode(data));
            InsertShow();
        }
    });


    $("#sel_track").change(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/GeneratingSeries",
            data: "{preid:'" + $("#ExpectNum").val() + "',num:'" + $("#sel_track").val() + "',Lottory: 'TCDLTData',mod:'z',endtime:'" + $("#endtime").val() + "'}",
            dataType: "json",
            success: function (data) {
                $("#div_track").html(HtmlDecode(data));
                InsertShow();
            }
        });

    });
    /**************处理追号期号显示**************/
}


//选中保底 文本框可用
function protect() {
    var checkbox = document.getElementById("ck_protect");
    if (checkbox.checked == true) {
        document.getElementById("Text1").disabled = "";
    }
    else {
        document.getElementById("Text1").disabled = "disabled";
        document.getElementById("Text1").value = "1";
    }
}

//点击标题改变样式和内容
function ChangeColor(obj) {
    if (obj == 'xuanhao') {
        document.getElementById("xuanhao").className = "on";
        document.getElementById("canyu").className = "";
        document.getElementById("dingzhi").className = "";
        document.getElementById("fangan").className = "";
        //显示合买
        document.getElementById("doc").style.display = "none";
        document.getElementById("Large").style.display = "block";
        document.getElementById("Myproject").style.display = "none";

        document.getElementById("Tracking").style.display = "none";

        document.getElementById("playTabsDd").style.display = "block";
    }
    if (obj == 'canyu') {
        document.getElementById("xuanhao").className = "";
        document.getElementById("canyu").className = "on";
        document.getElementById("dingzhi").className = "";
        document.getElementById("fangan").className = "";

        //显示合买
        document.getElementById("doc").style.display = "block";
        document.getElementById("Large").style.display = "none";
        document.getElementById("Myproject").style.display = "none";

        document.getElementById("Tracking").style.display = "none";

        document.getElementById("playTabsDd").style.display = "none";
    }
    if (obj == 'dingzhi_ssq') {
        TheDocumentary(3);

    }
    if (obj == 'dingzhi_dlt') {
        TheDocumentary(6);
    }
    if (obj == 'dingzhi_qlc') {
        TheDocumentary(2);
    }
    if (obj == 'fanan_3D') {
        Scheme(1);

    }
    if (obj == "fanan_plw") {
        Scheme(4);
    }
    /****双色球begin******/
    if (obj == 'fanan_ssq') {
        Scheme(3);
    }
    /****双色球end******/

    /****大乐透begin*****/
    if (obj == 'fanan_dlt') {
        Scheme(6);
    }
    /****大乐透end*****/
    /****七星彩***/
    if (obj == 'fanan_qxc') {
        Scheme(5);
    }
    /****七星彩***/
    /****排列三***/
    if (obj == 'fanan_pls') {
        Scheme(9999);
    }
    /****排列三***/

    /******七乐彩begion******/
    if (obj == 'fanan_qlc') {
        Scheme(2);
    }
    /******七乐彩begion******/
}
//html编码
function HtmlEncode(text) {
    return text.replace(/&/g, '&amp').replace(/\"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');

}
//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}
//我的项目
function Scheme(Lstate) {
    //判断是否登录
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //已登录
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == null || result.responseText == "") {
                $("#pagelist").html("您还没有登录，请先<a href='LoginPage.aspx'>登录</a>");
                $("#Div1").html("您还没有登录，请先<a href='LoginPage.aspx'>登录</a>");
                $("#Div2").html("您还没有登录，请先<a href='LoginPage.aspx'>登录</a>");
                document.getElementById("xuanhao").className = "";
                document.getElementById("canyu").className = "";
                document.getElementById("dingzhi").className = "";
                document.getElementById("fangan").className = "on";
            }
            else {
                $("#pagelist").html("");
                $("#Div1").html("");
                $("#Div2").html("");
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/BindList",
                    data: "{playName:'" + Lstate + "'}",
                    dataType: "json",
                    success: function (data) {
                        //获取的表格                         
                        $("#tab_MY").html(HtmlDecode(data));
                    }
                });
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/BindList_pp",
                    data: "{playName:'" + Lstate + "'}",
                    dataType: "json",
                    success: function (data) {
                        $("#MY_pp").html(HtmlDecode(data));
                    }
                });
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/BindList_Attention",
                    data: "{playName:'" + Lstate + "'}",
                    dataType: "json",
                    success: function (data) {
                        $("#my_Attention").html(HtmlDecode(data));
                    }

                });

            }
        }
    });
    
    if (Lstate == 2 || Lstate == 3 || Lstate == 6) {
        //显示我的方案
        document.getElementById("Myproject").style.display = "block";
        document.getElementById("doc").style.display = "none";
        document.getElementById("Large").style.display = "none";
        document.getElementById("Tracking").style.display = "none";
    }
    else {
        //显示我的方案
        document.getElementById("Myproject").style.display = "block";
        document.getElementById("doc").style.display = "none";
        document.getElementById("Large").style.display = "none";
    }
}
//定制跟单
function TheDocumentary(Lid) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/TrackingOrders",
        data: "{playName:'" + Lid + "'}",
        dataType: "json",
        success: function (data) {
            //获取的表格                         
            $("#tra").html(HtmlDecode(data));
        }
    });
    document.getElementById("xuanhao").className = "";
    document.getElementById("canyu").className = "";
    document.getElementById("dingzhi").className = "on";
    document.getElementById("fangan").className = "";


    document.getElementById("doc").style.display = "none";
    document.getElementById("Large").style.display = "none";
    document.getElementById("Myproject").style.display = "none";
    document.getElementById("Tracking").style.display = "block";
}


//列表的参与弹出框方法  	
function state(obj, Qnum) {
    var val = document.getElementById(obj.id).value;
    var username;
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //判断是否登录
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                //                $.XYTipsWindow({
                //                    ___title: "用户登录",    //窗口标题文字
                //                    ___content: "iframe:login.aspx",    //内容{text|id|img|url|iframe}
                //                    ___width: "350",            //窗口宽度
                //                    ___height: "170",          //窗口离度
                //                    ___titleClass: "boxTitle", //窗口标题样式名称
                //                    ___closeID: "", 	//关闭窗口ID
                //                    ___time: "", 	    //自动关闭等待时间
                //                    ___drag: "___boxTitle", 	    //拖动手柄ID
                //                    ___showbg: true, 	//是否显示遮罩层
                //                    //	        ___offsets:{left:"auto",top:"auto"},//设定弹出层位置,默认居中
                //                    ___fns: function () {
                //                    } //关闭窗口后执行的函数
                //                });
                alert("您还没有登录，请先登录");
                return false;
            }
            else {

                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/shareNum",
                    data: "{num:'" + val + "',Qnum:'" + Qnum + "'}",
                    dataType: "json",
                    complete: function (result) {
                        if (result.responseText == 1) {
                            alert('该方案已经截止');
                            return false;
                        }
                        if (result.responseText == 2) {
                            alert('您输入数字大于剩余的份数！');
                            return false;
                        }
                        if (result.responseText == 3) {
                            $.XYTipsWindow({
                                ___title: "第 '" + $("#ExpectNum").val() + "' 期  合买方案",    //窗口标题文字
                                ___content: "iframe:ChippedInfo.aspx?id=" + Qnum + "&share=" + val,    //内容{text|id|img|url|iframe}
                                ___width: "600",            //窗口宽度
                                ___height: "350",          //窗口离度
                                ___drag: "___boxTitle", 	    //拖动手柄ID
                                ___showbg: true		//是否显示遮罩层
                            });
                        }
                    }
                });
            }
        }
    });

}

function view(number) {
    var num = "";
    //双色球
    if ($("#playName").val() == 3) {
        if (number.split(';').length > 0) {
            for (var i = 0; i < number.split(';').length; i++) {
                num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font>+" + "<font color='blue'>" + number.split(';')[i].split('-')[1] + "</font><br/>";
            }
        }
        else {
            num += "<font color='red'>" + number.split('-')[0] + "</font>+" + "<font color='blue'>" + number.split('-')[1] + "</font><br/>";
        }

    }

    //3D
    if ($("#playName").val() == 1) {
        for (var i = 0; i < number.split(';').length; i++) {
            if (i % 3 == 0) {
                num += "<br/>";
            }
            //判断3D的选号规则
            if (number.split(';')[i].split('|')[0] == "1") {

                num += "<font color='red'>[直选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {

                num += "<font color='red'>[直选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组选号码
            if (number.split(';')[i].split('|')[0] == "6") {

                num += "<font color='red'>[组选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S9") {

                num += "<font color='red'>[组选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组三选号
            if (number.split(';')[i].split('|')[0] == "F3") {

                num += "<font color='red'>[组三包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {

                num += "<font color='red'>[组三和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组六选号
            if (number.split(';')[i].split('|')[0] == "F6") {

                num += "<font color='red'>[组六包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {

                num += "<font color='red'>[组六和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //1D
            if (number.split(';')[i].split('|')[0] == "1D") {

                num += "<font color='red'>[1D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //2D
            if (number.split(';')[i].split('|')[0] == "2D") {

                num += "<font color='red'>[2D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //通选
            if (number.split(';')[i].split('|')[0] == "tx") {

                num += "<font color='red'>[通选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //和数选
            if (number.split(';')[i].split('|')[0] == "hsx") {

                num += "<font color='red'>[和数选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }



    }
    //七星彩
    if ($("#playName").val() == 5) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[号码]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }

    //大乐透
    if ($("#playName").val() == 6) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font>+" + "<font color='blue'>" + number.split(';')[i].split('-')[1] + "</font><br/>";
        }
    }
    //七乐彩
    if ($("#playName").val() == 2) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font><br/>";
        }
    }
    //排列3
    if ($("#playName").val() == 9999) {
        for (var i = 0; i < number.split(';').length; i++) {
            //直选
            if (number.split(';')[i].split('|')[0] == "1") {
                num += "<font color='red'>[直选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {
                num += "<font color='red'>[直选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组选
            if (number.split(';')[i].split('|')[0] == "6") {
                num += "<font color='red'>[组选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[组选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组三选号
            if (number.split(';')[i].split('|')[0] == "F3") {
                num += "<font color='red'>[组三包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {
                num += "<font color='red'>[组三和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组六选号
            if (number.split(';')[i].split('|')[0] == "F6") {
                num += "<font color='red'>[组六包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[组六和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }
    }
    //排列五
    if ($("#playName").val() == 4) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[号码]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }
    //   $.XYTipsWindow({
    //       ___title: "方案内容",    //窗口标题文字
    //       ___content: "iframe:Number.aspx?CStr=" + num + "&play=" + $("#playName").val(),    //内容{text|id|img|url|iframe}
    //       ___width: "600",            //窗口宽度
    //       ___height: "350",          //窗口离度
    //       ___drag: "___boxTitle", 	    //拖动手柄ID
    //       ___showbg: true		//是否显示遮罩层
    //   });

    $.XYTipsWindow({
        ___title: "方案内容",    //窗口标题文字
        ___content: "text:" + num,    //内容{text|id|img|url|iframe}
        ___width: "400",            //窗口宽度
        ___height: "270",          //窗口离度
        ___titleClass: "boxTitle", //窗口标题样式名称
        ___closeID: "", 	//关闭窗口ID
        ___time: "", 	    //自动关闭等待时间
        ___drag: "___boxTitle", 	    //拖动手柄ID
        ___showbg: true		//是否显示遮罩层
    });


}
function view_s(number, playName) {

    var num = "";
    //双色球
    if (playName == 3) {
        if (number.split(';').length > 0) {
            for (var i = 0; i < number.split(';').length; i++) {
                num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font>+" + "<font color='blue'>" + number.split(';')[i].split('-')[1] + "</font><br/>";
            }
        }
        else {
            num += "<font color='red'>" + number.split('-')[0] + "</font>+" + "<font color='blue'>" + number.split('-')[1] + "</font><br/>";
        }

    }

    //3D
    if (playName == 1) {
        for (var i = 0; i < number.split(';').length; i++) {
            if (i % 3 == 0) {
                num += "<br/>";
            }
            //判断3D的选号规则
            if (number.split(';')[i].split('|')[0] == 1) {

                num += "<font color='red'>[直选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {

                num += "<font color='red'>[直选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组选号码
            if (number.split(';')[i].split('|')[0] == 6) {

                num += "<font color='red'>[组选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S9") {

                num += "<font color='red'>[组选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组三选号
            if (number.split(';')[i].split('|')[0] == "F3") {

                num += "<font color='red'>[组三包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {

                num += "<font color='red'>[组三和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组六选号
            if (number.split(';')[i].split('|')[0] == "F6") {

                num += "<font color='red'>[组六包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {

                num += "<font color='red'>[组六和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //1D
            if (number.split(';')[i].split('|')[0] == "1D") {

                num += "<font color='red'>[1D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //2D
            if (number.split(';')[i].split('|')[0] == "2D") {

                num += "<font color='red'>[2D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //通选
            if (number.split(';')[i].split('|')[0] == "tx") {

                num += "<font color='red'>[通选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //和数选
            if (number.split(';')[i].split('|')[0] == "hsx") {

                num += "<font color='red'>[和数选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }

    }
    //七星彩
    if (playName == 5) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[号码]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }

    //大乐透
    if (playName == 6) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font>+" + "<font color='blue'>" + number.split(';')[i].split('-')[1] + "</font><br/>";
        }
    }
    //七乐彩
    if (playName == 2) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font><br/>";
        }
    }
    //排列3
    if (playName == 9999) {
        for (var i = 0; i < number.split(';').length; i++) {
            //直选
            if (number.split(';')[i].split('|')[0] == "1") {
                num += "<font color='red'>[直选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {
                num += "<font color='red'>[直选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组选
            if (number.split(';')[i].split('|')[0] == "6") {
                num += "<font color='red'>[组选]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[组选和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组三选号
            if (number.split(';')[i].split('|')[0] == "F3") {
                num += "<font color='red'>[组三包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {
                num += "<font color='red'>[组三和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //组六选号
            if (number.split(';')[i].split('|')[0] == "F6") {
                num += "<font color='red'>[组六包号]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[组六和值]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }
    }
    //排列5
    if (playName == 4) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[号码]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }


    $.XYTipsWindow({
        ___title: "方案内容",    //窗口标题文字
        ___content: "text:" + num,    //内容{text|id|img|url|iframe}
        ___width: "400",            //窗口宽度
        ___height: "270",          //窗口离度
        ___titleClass: "boxTitle", //窗口标题样式名称
        ___closeID: "", 	//关闭窗口ID
        ___time: "", 	    //自动关闭等待时间
        ___drag: "___boxTitle", 	    //拖动手柄ID
        ___showbg: true		//是否显示遮罩层
    });


}

/*iframe宽高自适应*/
function TuneHeight(fm_name, fm_id) {
    var frm = document.getElementById(fm_id);
    var subWeb = document.frames ? document.frames[fm_name].document : frm.contentDocument;
    if (frm != null && subWeb != null) {
        frm.style.height = subWeb.documentElement.scrollHeight + "px";
        //如需自适应宽高,去除下行的“//”注释即可 
        frm.style.width = subWeb.documentElement.scrollWidth + "px";
    }
}


/************订制跟单*****************/
function Display_tarcking(obj, LN, num) {  //ln: 行号   num：总行数
    var n_display = document.getElementById("div_" + LN).style.display;
    if (n_display == "block") {
        document.getElementById("div_" + LN).style.display = "none";
    }
    else {
        document.getElementById("div_" + LN).style.display = "block";
        for (var j = 1; j < num + 1; j++) {
            if (LN != j) {
                document.getElementById("div_" + j).style.display = "none";
            }
        }
    }

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/TrackingExc",
        data: "{name:'" + $("#name").val() + "',num:'" + $("#Tracing_" + LN).val() + "',playName:'" + obj + "'}",
        dataType: "json",
        success: function (data) {
            $("#trackingExc_" + LN).html(HtmlDecode(data));

        }
    });
    $("#Tracing_" + LN).change(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebChipped.asmx/TrackingExc",
            data: "{name:'" + $("#name").val() + "',num:'" + $("#Tracing_" + LN).val() + "',playName:'" + obj + "'}",
            dataType: "json",
            success: function (data) {
                $("#trackingExc_" + LN).html(HtmlDecode(data));
                
            }
        });
    });

}
//当前期金额(多期和追号显示金额方法)
function dataChage(obj, i) {
    var m = obj.split('_')[1];
    /**处理追号倍数和价格显示**/
    if ($("input[name='buy']:checked").val() == "track" && $("input[name='a']:checked").val() != "dqxh") {
        if ($("#" + obj).val() > 99) {
            $("#" + obj).attr("value", 99);
        }
        
        $("#money_"+m +"_"+ i).html(formatCurrency($("#txt_"+m+"_" + i).val() * $("#danzhushu").val() * 2));

    }
    /**处理追号倍数和价格显示**/
    else {
        if ($("#" + obj).val() > 500) {
            $("#" + obj).attr("value", 500);
        }
        if (obj == "txt_" + m+"_" + "1") {
            $("#CurrentMoney").html(formatCurrency($("#txt_"+ m+"_" +"1").val() * 2 * $("#txt_num").val()));
            //添加金额到隐藏变量中
            $("#curr_money").attr("value", $("#txt_"+ m+"_" +"1").val() * 2 * $("#txt_num").val());
        }
        $("#money_"+m+"_" + i).html(formatCurrency($("#txt_"+m+"_" + i).val() * 2 * $("#txt_num").val()));

        //用户余额      
        if ($("#lab_accMoney").text() != "" || $("#lab_accMoney").text() > 0) {
            $("#user_Balance").html($("#lab_accMoney").text() - $("#curr_money").val());
        }
        else {
            $("#user_Balance").html(0);
        }
    }
}

//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}

//定制跟单添加数据
//彩种编号，会员名,行编号
function Frozen(playname, name,num) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //判断是否登录
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                //                                window.top.location.href="LoginPage.aspx";
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
                if ($("#txtNum_" + num).val() == 0 || $("#txtNum_" + num).val() == "") {
                    alert('认购的方案个数最少为一个');
                    return false;
                }
                if ($("#tbMoney_" + num).val() < 1 || $("#tbMoney_" + num).val() == "") {
                    alert('每次认购的金额不能小于1元');
                    return false;
                }
                //提交
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/AddTracking",
                    data: "{UserName:'" + name + "',playName:'" + playname + "',num:'" + $("#txtNum_" + num).val() + "',money:'" + $("#tbMoney_" + num).val() + "'}",
                    dataType: "json",
                    complete: function (result) {

                        if (result.responseText == 0) {
                            alert('您上次的跟单还未全部完成');
                            return false;
                        }
                        if (result.responseText == 1) {
                            if (confirm("定制成功！\r\n点击取消：继续定制其他彩种！\r\n点击确定：可立即查看定制信息！\r\n请您在“定制记录”查询所有订单状态")) {

                                parent.mainFrame.location.href = "../admin/TrackingList.aspx";
                                return false;
                            }
                            else {
                                //刷新页面
                                history.go(0);
                                return false;
                            }
                        }
                        if (result.responseText == 1) {
                            alert("定制已满，只允许1000人定制");
                            return false;
                        }
                    }
                });
            }
        }
    });

}


//验证是否登录
function login() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //判断是否登录
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                //                                window.top.location.href="LoginPage.aspx";
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
                //                window.location = "Tracking.aspx?name=" + obj;
                return 1;
            }
        }
    });
}
/************订制跟单*****************/

//格式化价格显示
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + '.' + cents);
}

/*******合买标题输入字数限制*********/
function checkLen(term) {

    if (30 - term.value.length <= 0) {
        alert("您输入的消息过长！");
        term.value = term.value.substring(0, 30);
        $("#J_UnitedTitleLen").html(30 - term.value.length);
        return false;
    }
    else {
        $("#J_UnitedTitleLen").html(30 - term.value.length);
    }
}
function Check() {
    var fm = document.FormMsg;
    fm.message.value = fTrim(fm.message.value); //Trim the input value. 
    if (fm.message.value == "") {
        window.alert("\内容不能为空！");
        fm.message.focus();
        return false;
    }
    return true;
}
function fTrim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
/*******合买标题输入字数限制*********/
//合买宣言字数限制
//限制说明的字数输入
function limitChars(id, count) {
    var obj = document.getElementById(id);
    $("#J_UnitedDescLen").html(50 - obj.value.length);
    if (obj.value.length > count) {
        obj.value = obj.value.substr(0, count);
    }
}

//限制输入数字范围 （定制跟单列表）
function Range(obj) {
    var num = obj.id;

    if (obj.value > 10) {
        obj.value = 10;
        return false;
    }
}


