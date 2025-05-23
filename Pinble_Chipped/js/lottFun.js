

//机选号码
function jxhq(colorn) {
    var selectValueh = document.getElementById("J_JxRedNum");
    var selectValuel = document.getElementById("J_JxBlueNum");
    var arr = new Array();
    //机选红球
    if (colorn == "h") {
        var hongqiu = document.getElementsByName("hongqiu");
        for (var i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" }
        arr = random_select(selectValueh.value, 33, 1);

        for (var j = 0; j < arr.length; j++) {
            if ((arr[j] - 1) >= 0)
                hongqiu[arr[j] - 1].className = "numberh";
            else
                hongqiu[0].className = "numberh";
        }
        DisNum();
    }
    //机选蓝球
    if (colorn == "l") {
        var lanqiu = document.getElementsByName("lanqiu");
        for (var i = 0; i < lanqiu.length; i++) { lanqiu[i].className = "number" } //清空蓝球
        arr = random_select(selectValuel.value, 16, 1);

        for (var j = 0; j < arr.length; j++) {
            lanqiu[arr[j] - 1].className = "numberl";
        }
        DisNum();
    }
}

//显示选了几个号码
function DisNum() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = 0;
    if ($("input[name='a']:checked").val() == "sd") {

        for (var i = 0; i < str.split("\r\n").length; i++) {
            if (str.split("\r\n")[i].split('-').length != 2) {
                return false;
            }
            if (str.split("\r\n")[i].split('-')[1].length < 2) {
                return false;
            }
            if (Math.floor(str.split("\r\n")[i].split('-')[0].length / 2) >= 6 && Math.floor(str.split("\r\n")[i].split('-')[1].length / 2) >= 1) {
                //红球
                var Rball = new Array();
                //蓝球
                var Lball = new Array();
                //处理红球
                for (var j = 0; j < Math.floor(str.split("\r\n")[i].split('-')[0].length / 2); j++) {
                    Rball[j] = repNum(str.split("\r\n")[i].split('-')[0]).substr(j * 2, 2);
                }
                //处理蓝球
                for (var j = 0; j < Math.floor(str.split("\r\n")[i].split('-')[1].length / 2); j++) {
                    Lball[j] = repNum(str.split("\r\n")[i].split('-')[1]).substr(j * 2, 2);
                }
                //判断是否有重复号码
                var doubNumh = 0;
                var doubNuml = 0;
                doubNumh = doobNum(Rball);
                doubNuml = doobNum(Lball);
                if (doubNumh != 1 && doubNuml != 1) {
                    //红球
                    var RedBall = "";
                    //蓝球
                    var BlueBall = "";
                    for (var k = 0; k < Rball.length; k++) {
                        RedBall += Rball[k] + " ";
                    }
                    for (var k = 0; k < Lball.length; k++) {
                        BlueBall += Lball[k] + " ";
                    }
                }
                else {
                    alert('您输入的号码有重复！');
                    return false;
                }
                zhushu += getZhushu1(RedBall.substring(RedBall.length - 1, 0) + "-" + BlueBall.substring(BlueBall.length - 1, 0));
            }
        }

    }
    else {
        zhushu = getZhushu1(str);
    }
    $("#danbeizhushu").html(zhushu);
    $("#danbeimoney").html(zhushu * 2);

}
//胆拖 显示选择了几个
function DisNumDT() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = 0;
    //红球个数
    var Hnum = 0;
    //胆拖
    var Rnum = 0;
    if (str.split('$')[0] == "") {
        Hnum = 0;
    }
    else {
        Hnum = str.split('$')[0].split(' ').length;
    }
    if (str.split('$')[1] == "") {
        Rnum = 0;
    }
    else {
        if (str.split('$')[1].split('-')[0] == "") {
            Rnum = 0;
        }
        else {
            Rnum = str.split('$')[1].split('-')[0].split(' ').length;
        }
    }
    $("#J_PreDantuoSize").html(Hnum + Rnum);
    //胆码个数
    $("#J_PreDanSize").html(Hnum);
    //拖码个数
    $("#J_PreTuoSize").html(Rnum);
    //蓝球个数
    var lnum = 0;
    if (str.split('-')[1] == "") {
        lnum = 0;
    }
    else {
        lnum = str.split('-')[1].split(' ').length;
    }
    $("#J_PreDantuoBlueSize").html(lnum);
    if (Hnum >= 1 && Rnum >= 2 && Hnum + Rnum >= 7 && lnum >= 1) {
        zhushu = getZhushuDT(str);
    }
    //注数
    $("#J_PreDantuoMulti").html(zhushu);
    //金额
    $("#J_PreDantuoMoney").html(zhushu * 2);
}
//胆拖选号
function DTxuanhao(obj, sort) {
    var Cname = obj.className;
    if (Cname == "number") {
        if (sort == "dh") {
            obj.className = "numberh";
        } else if (sort == "dl") {
            obj.className = "numberl";
        }
    }
    if (Cname == "numberh") { obj.className = "number"; }
    if (Cname == "numberl") { obj.className = "number"; }
    var hdanma = document.getElementsByName("hdanma");
    var htuma = document.getElementsByName("htuma");
    for (var i = 0; i < 33; i++) {
        if (hdanma[i].className == "numberh" && hdanma[i].id == obj.id) {
            htuma[i].className = "number";

        }
        if (htuma[i].className == "numberh" && htuma[i].id == obj.id) {
            hdanma[i].className = "number";

        }

    }
    DisNumDT();

}


//更改球体样式
function xuanhao(obj, sort) {		//改变球体 Class
    var Cname = obj.className;
    if (Cname == "number") {
        if (sort == "h") {
            obj.className = "numberh";
        } else if (sort == "l") {
            obj.className = "numberl";
        }
    }
    if (Cname == "numberh") { obj.className = "number"; }
    if (Cname == "numberl") { obj.className = "number"; } //当等于三的时候不能改变球的样式
    //    Show();
    DisNum();

}

//根据选择号码样式设置投注号码串 
function setcode() {
    var str = "";
    //普通选号
    if ($("input[name='a']:checked").val() == "fs") {
        var hongqiu = document.getElementsByName("hongqiu");
        var lanqiu = document.getElementsByName("lanqiu");
        var hongqiustr = "", lanqiustr = "";
        for (var i = 0; i < hongqiu.length; i++) {
            if (hongqiu[i].className == "numberh") {
                hongqiustr += ToLength(parseInt(i + 1)) + " ";
            }
        } //清空红球
        for (var i = 0; i < lanqiu.length; i++) {
            if (lanqiu[i].className == "numberl") {
                lanqiustr += ToLength(parseInt(i + 1)) + " ";
            }
        }
        str = hongqiustr.substring(hongqiustr.length - 1, 0) + "-" + lanqiustr.substring(lanqiustr.length - 1, 0);
    }
    //胆拖选号
    if ($("input[name='a']:checked").val() == "dt") {
        //红胆
        var hdanma = document.getElementsByName("hdanma");
        //红球拖码
        var htuma = document.getElementsByName("htuma");
        //蓝球
        var lq = document.getElementsByName("lq");
        var dama = "";
        var tuoma = "";
        var lqq = "";
        //组合胆码
        for (var i = 0; i < hdanma.length; i++) {
            if (hdanma[i].className == "numberh") {
                dama += ToLength(parseInt(i + 1)) + " ";
            }
        }
        //组合拖码
        for (var i = 0; i < htuma.length; i++) {
            if (htuma[i].className == "numberh") {
                tuoma += ToLength(parseInt(i + 1)) + " ";
            }
        }
        //蓝球
        for (var i = 0; i < lq.length; i++) {
            if (lq[i].className == "numberl") {
                lqq += ToLength(parseInt(i + 1)) + " ";
            }
        }
        str = dama.substring(dama.length - 1, 0) + "$" + tuoma.substring(tuoma.length - 1, 0) + "-" + lqq.substring(lqq.length - 1, 0);
    }
    //手动选号
    if ($("input[name='a']:checked").val() == "sd") {
        str = $("#tb_ManualInput").val();
    }
    document.getElementById("code").value = str;
}
//根据号码串统计注数，并设置显示信息
function Show() {
    //    setcode();
    var str = document.getElementById("code").value;
    //    var zhushu = getZhushu(str, "0")
}


//添加号码
function Insert() {
    var Ret = setcode();
    if (Ret != false) {
        setcode();
        var str = document.getElementById("code").value;

        var zhushu = getZhushu(str, "1");
        InsertShow();
    }


}

function getZhushu1(BuyNum) {
    BuyNumTemp = BuyNum.split("-");
    if (parseInt(BuyNumTemp.length) != 2) { return 0; }
    var rn = parseInt((BuyNumTemp[0].split(" ")).length);
    var bn = parseInt((BuyNumTemp[1].split(" ")).length);
    var tempNum = 1;

    if (rn < 6) { BuyZhu = 0; return 0; }
    if (bn < 1) { BuyZhu = 0; return 0; }
    if (BuyNumTemp[1] != "") {
        bn = bn;
    } else {
        bn = 0;
    }
    if (rn == 6) {
        if (BuyNumTemp[1] != "") {
            BuyZhu = bn;
        } else {
            BuyZhu = 0;
        }
        return BuyZhu;
    }
    for (var i = 7; i <= rn; i++) {
        tempNum = tempNum * i;
    }
    for (var i = 2; i <= rn - 6; i++) {
        tempNum = tempNum / i;
    }
    BuyZhu = tempNum * bn;
    return parseInt(BuyZhu);
}
//计算胆拖的方案注数
function getZhushuDT(str) {
    var Temp = str.split("-");
    var TempNum = Temp[0].split('$');

    //胆码个数
    var danma = TempNum[0].split(' ').length;
    //拖码个数
    var tuoma = TempNum[1].split(' ').length;
    //蓝球个数
    var lanqiu = Temp[1].split(' ').length;

    var BuyZhu = 0;
    var dNum = 1;
    var TNum = 1;
    if (danma > 0 || danma < 6) {
        for (var i = 0; i < 6 - danma; i++) {
            dNum = dNum * (tuoma - i);
            TNum = TNum * (6 - danma - i);
        }
    }
    var BuyZhu = dNum / TNum * lanqiu;
    return parseInt(BuyZhu);
}


//计算方案注数
function getZhushu(str, inset) {
    var zhushu = 0;
    //普通选号
    if ($("input[name='a']:checked").val() == "fs") {

        var codestr = ""
        zhushu = getZhushu1(str);
        codestr = str;
        if (str.split('-')[0].split(' ').length < 6) {
            alert('至少选择6个红球');
            return false;
        }
        if (str.split('-')[1].length<1) {
            alert('至少选择1个蓝球');
            return false;
        }
        if (zhushu < 1) {
            alert("您没有选择合法的投注号码！");
            return false;
        }
        add(codestr, zhushu);
        clearall();
    }
    //胆拖
    if ($("input[name='a']:checked").val() == "dt") {
        //至少选择一个胆码
        var TempNum = str.split('$');
        if (TempNum[0] == "" || TempNum[0].split(' ').length < 1) {
            alert('至少选择一个胆码');
            return false;
        }
        if (TempNum[0].split(' ').length > 5) {
            alert('最多选择5个胆码');
            return false;
        }
        //判断拖码
        if (TempNum[1].split('-')[0].split(' ').length < 2) {
            alert('最少选择2个拖码');
            return false;
        }
        var leng = parseInt(TempNum[0].split(' ').length) + parseInt(TempNum[1].split('-')[0].split(' ').length);
        if (leng < 7) {
            alert('胆码加拖码最少选择7个红球');
            return false;
        }

        if (TempNum[1].split('-')[1].split(' ')[0].length == 0) {
            alert('请选择一个蓝球');
            return false;
        }
        if (TempNum[1].split('-')[1].split(' ').length < 1) {
            alert('请选择一个蓝球');
            return false;
        }
        zhushu = getZhushuDT(str);
        var retStr = "[胆码]" + str.split('$')[0] + " [拖码]" + str.split('$')[1].split('-')[0] + " [蓝球]" + str.split('$')[1].split('-')[1];
        writeselect(retStr, str + "|" + zhushu);
        clearall();
    }
    //手动输入
    if ($("input[name='a']:checked").val() == "sd") {
        //判断手动输入号码是否为空
        if (str == "" || str == null) {
            alert('请您输入或是粘贴号码到输入框');
            return false;
        }
        //定制数组 排序用
        var arrh = new Array();
        var arrl = new Array();

        //根据换行符截取
        for (var i = 0; i < str.split('\r\n').length; i++) {
            //判断输入的数否符合标准 红球+篮球 格式
            if (str.split('\r\n')[i].split('-')[0] == null || str.split('\r\n')[i].split('-')[0].toString == "") {
                alert('注意双色球输入格式');
                return false;
            }
            if (str.split('\r\n')[i].split('-')[1] == null || str.split('\r\n')[i].split('-')[1].toString == "") {
                alert('注意双色球输入格式');
                return false;
            }

            //定义红球
            var HNum = repNum(str.split('\r\n')[i].split('-')[0]);
            //定义蓝球
            var LNum = repNum(str.split('\r\n')[i].split('-')[1]);
            //判断号码是否合法 
            if (Math.floor(HNum.length / 2) < 6 || Math.floor(LNum.length / 2) < 1) {
                alert('请检查红球号码个数和蓝球号码个数，提示：红球最少6个 蓝球最少1个');
                return false;
            }
            //清空数组
            arrh.splice(0, arrh.length);
           
            //重新组合号码 

            //红球
            for (var j = 0; j < Math.floor(HNum.length / 2); j++) {
                //验证单个号码是否合法
                if (HNum.substr(j * 2, 2) <= 0 || HNum.substr(j * 2, 2) > 33) {
                    alert('红球范围01-33');
                    return false;
                }
                arrh[j] = HNum.substr(j * 2, 2);
            }
            arrl.splice(0, arrl.length);
            // 排序并去除重复
            var retArrh = new Array();
            retArrh = BubbleSort(arrh);
            //蓝球
            for (var j = 0; j < Math.floor(LNum.length / 2); j++) {
                //验证单个号码是否合法
                if (LNum.substr(j * 2, 2) <= 0 || LNum.substr(j * 2, 2) > 16) {
                    alert('蓝球范围01-16');
                    return false;
                }
                arrl[j] = LNum.substr(j * 2, 2);
            }
            var retArrl = new Array();
            retArrl = BubbleSort(arrl);
            //红球
            var NHNum = "";
            var doubStateh;
            var doubStatel
            doubStateh = doobNum(retArrh);
            doubStatel = doobNum(retArrl);
            if (doubStateh == 1) {
                alert('您的红球有重复号码！');
                return false;
            }
            if (doubStatel == 1) {
                alert('您的蓝球有重复号码');
                return false;
            }
            for (j = 0; j < retArrh.length; j++) {
                NHNum += retArrh[j] + " ";
            }
            //蓝球
            var NLNum = "";
            for (j = 0; j < retArrl.length; j++) {
                NLNum += retArrl[j] + " ";
            }
            //组合号码
            var Number = NHNum.substr(0,NHNum.length - 1) + "-" + NLNum.substr(0,NLNum.length - 1);
            var zhushu = getZhushu1(Number);
            add(Number, zhushu);
        }
        //清空输入框
        document.getElementById("tb_ManualInput").value = "";
    }
    return zhushu;
}



//号码栏状态恢复
function clearall() {
    var hongqiu = document.getElementsByName("hongqiu");

    var lanqiu = document.getElementsByName("lanqiu");
    for (var i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" } //清空红球
    for (var i = 0; i < lanqiu.length; i++) { lanqiu[i].className = "number" } //清空蓝球

    var hdanma = document.getElementsByName("hdanma"); //红球胆码

    var htuma = document.getElementsByName("htuma"); //红球胆拖

    var lq = document.getElementsByName("lq"); //蓝球

    for (var i = 0; i < hdanma.length; i++) {
        hdanma[i].className = "number";
    }
    for (var i = 0; i < htuma.length; i++) {
        htuma[i].className = "number";
    }
    for (var i = 0; i < lq.length; i++) {
        lq[i].className = "number";
    }
    $("#J_PreDantuoSize").html(0);
    //胆码个数
    $("#J_PreDanSize").html(0);
    //拖码个数
    $("#J_PreTuoSize").html(0);

    $("#J_PreDantuoBlueSize").html(0);

    //注数
    $("#J_PreDantuoMulti").html(0);
    //金额
    $("#J_PreDantuoMoney").html(0);
    return;
}

function jixuan(n) {
    BuyNum = "";
    type = "jixuan";
    for (var i = 0; i < n; i++) {
        var Itmp1 = Math.ceil(Math.random() * 33); //机选第一个数值
        Itmp1 = ToLength(parseInt(Itmp1));
        while (true) {
            var Itmp2 = Math.ceil(Math.random() * 33); //机选第二个数值
            if (Itmp2 != Itmp1) { Itmp2 = ToLength(parseInt(Itmp2)); break; }
        }
        while (true) {
            var Itmp3 = Math.ceil(Math.random() * 33); //机选第三个数值
            if (Itmp3 != Itmp1 && Itmp3 != Itmp2) { Itmp3 = ToLength(parseInt(Itmp3)); break; }
        }
        while (true) {
            var Itmp4 = Math.ceil(Math.random() * 33); //机选第四个数值
            if (Itmp4 != Itmp1 && Itmp4 != Itmp2 && Itmp4 != Itmp3) { Itmp4 = ToLength(parseInt(Itmp4)); break; }
        }
        while (true) {
            var Itmp5 = Math.ceil(Math.random() * 33); //机选第五个数值
            if (Itmp5 != Itmp1 && Itmp5 != Itmp2 && Itmp5 != Itmp3 && Itmp5 != Itmp4) { Itmp5 = ToLength(parseInt(Itmp5)); break; }
        }
        while (true) {
            var Itmp6 = Math.ceil(Math.random() * 33); //机选第六个数值
            if (Itmp6 != Itmp1 && Itmp6 != Itmp2 && Itmp6 != Itmp3 && Itmp6 != Itmp4 && Itmp6 != Itmp5) { Itmp6 = ToLength(parseInt(Itmp6)); break; }
        }

        var Itmp7 = Math.ceil(Math.random() * 16); //机选蓝球数值
        Itmp7 = ToLength(parseInt(Itmp7));
        var tempmun = new Array(Itmp1, Itmp2, Itmp3, Itmp4, Itmp5, Itmp6); 	//生成数组
        BubbleSort(tempmun); //排序数组
        //alert(tempmun);

        str = tempmun + "-" + Itmp7
        add(str.replace(/,/g, " "), 1);
    }
    InsertShow();
}


function jixuan_1(n) {
    BuyNum = "";
    type = "jixuan";
    for (var i = 0; i < n; i++) {
        var Itmp1 = Math.ceil(Math.random() * 33); //机选第一个数值
        Itmp1 = ToLength(parseInt(Itmp1));
        while (true) {
            var Itmp2 = Math.ceil(Math.random() * 33); //机选第二个数值
            if (Itmp2 != Itmp1) { Itmp2 = ToLength(parseInt(Itmp2)); break; }
        }
        while (true) {
            var Itmp3 = Math.ceil(Math.random() * 33); //机选第三个数值
            if (Itmp3 != Itmp1 && Itmp3 != Itmp2) { Itmp3 = ToLength(parseInt(Itmp3)); break; }
        }
        while (true) {
            var Itmp4 = Math.ceil(Math.random() * 33); //机选第四个数值
            if (Itmp4 != Itmp1 && Itmp4 != Itmp2 && Itmp4 != Itmp3) { Itmp4 = ToLength(parseInt(Itmp4)); break; }
        }
        while (true) {
            var Itmp5 = Math.ceil(Math.random() * 33); //机选第五个数值
            if (Itmp5 != Itmp1 && Itmp5 != Itmp2 && Itmp5 != Itmp3 && Itmp5 != Itmp4) { Itmp5 = ToLength(parseInt(Itmp5)); break; }
        }
        while (true) {
            var Itmp6 = Math.ceil(Math.random() * 33); //机选第六个数值
            if (Itmp6 != Itmp1 && Itmp6 != Itmp2 && Itmp6 != Itmp3 && Itmp6 != Itmp4 && Itmp6 != Itmp5) { Itmp6 = ToLength(parseInt(Itmp6)); break; }
        }

        while (true) {
            var Itmp7 = Math.ceil(Math.random() * 33); //机选第七个数值
            if (Itmp7 != Itmp1 && Itmp7 != Itmp2 && Itmp7 != Itmp3 && Itmp7 != Itmp4 && Itmp7 != Itmp5 && Itmp7 != Itmp6) { Itmp7 = ToLength(parseInt(Itmp7)); break; }
        }

        var Itmp8 = Math.ceil(Math.random() * 16); //机选蓝球数值
        Itmp8 = ToLength(parseInt(Itmp8));
        var tempmun = new Array(Itmp1, Itmp2, Itmp3, Itmp4, Itmp5, Itmp6, Itmp7); 	//生成数组
        BubbleSort(tempmun); //排序数组ZZ
        //alert(tempmun);
        str = tempmun + "-" + Itmp8
        add(str,1);
    }
    InsertShow();
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
//判断是否有重复号码
function doobNum(arr) {
    for (var i = 0; i < arr.length; i++) {
        for (var j = arr.length - 1; j > i; j--) {
            if (arr[j] == arr[i]) {
                return 1;
            }
        }
    }
    return 0;
}
