
//机选号码
function jxhq(colorn) {
    var selectValueh = document.getElementById("J_JxRedNum");
    var selectValuel = document.getElementById("J_JxBlueNum");
    var arr = new Array();
    //机选前去号码
    if (colorn == "h") {
        var hongqiu = document.getElementsByName("hongqiu");
        for (var i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" }
        arr = random_select(selectValueh.value, 35, 1);

        for (var j = 0; j < arr.length; j++) {
            if ((arr[j] - 1) >= 0)
                hongqiu[arr[j] - 1].className = "numberh";
            else
                hongqiu[0].className = "numberh";
        }
    }
    //机选后区号码
    if (colorn == "l") {
        var lanqiu = document.getElementsByName("lanqiu");
        for (var i = 0; i < lanqiu.length; i++) { lanqiu[i].className = "number" } //清空蓝球
        arr = random_select(selectValuel.value, 12, 1);

        for (var j = 0; j < arr.length; j++) {
            lanqiu[arr[j] - 1].className = "numberl";
        }
    }
    Show();
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
    Show();
}
//胆拖选号
function DTxuanhao(obj, sort) {
    var Cname = obj.className;
    if (Cname == "number") {
        if (sort == "h") {
            obj.className = "numberh";
        } else if (sort == "l") {
            obj.className = "numberl";
        }
    }
    if (Cname == "numberh") { obj.className = "number"; }
    if (Cname == "numberl") { obj.className = "number"; }
    var hdanma = document.getElementsByName("Qdama");
    var htuma = document.getElementsByName("Qtuoma");
    for (var i = 0; i < 35; i++) {
        if (hdanma[i].className == "numberh" && hdanma[i].id == obj.id) {
            htuma[i].className = "number";

        }
        if (htuma[i].className == "numberh" && htuma[i].id == obj.id) {
            hdanma[i].className = "number";

        }
    }
    var Ldanma = document.getElementsByName("Hdanma");
    var Ltuoma = document.getElementsByName("Htuoma");
    for (var i = 0; i < 12; i++) {
        if (Ldanma[i].className == "numberl" && Ldanma[i].id == obj.id) {
            Ltuoma[i].className = "number";

        }
        if (Ltuoma[i].className == "numberl" && Ltuoma[i].id == obj.id) {
            Ldanma[i].className = "number";

        }
    }
    DisNumDT();
}
//胆拖选号文字显示处理
function DisNumDT() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = 0;
    //前区胆码
    var FrontNum = 0;
    if (str.split('-')[0].split('$')[0] != "") {
        FrontNum = str.split('-')[0].split('$')[0].split(' ').length;
    }
    //前区拖码
    var FrontTuoN = 0;
    if (str.split('-')[0].split('$')[1] != "") {
        FrontTuoN = str.split('-')[0].split('$')[1].split(' ').length;
    }
    //后区胆码
    var BackNum = 0;
    if (str.split('-')[1].split('$')[0] != "") {
        BackNum = str.split('-')[1].split('$')[0].split(' ').length;
    }
    //后区拖码
    var BackTuoN = 0;
    if (str.split('-')[1].split('$')[1] != "") {
        BackTuoN = str.split('-')[1].split('$')[1].split(' ').length;
    }
    //前区号码
    $("#J_PreDantuoSize").html(FrontNum + FrontTuoN);
    //前区胆码
    $("#J_PreDanSize").html(FrontNum);
    //前区拖码
    $("#J_PreTuoSize").html(FrontTuoN);
    //后区号码
    $("#J_PreDantuoBlueSize").html(BackNum + BackTuoN);
    //后区胆码
    $("#J_AreaDanSize").html(BackNum);
    //后区拖码
    $("#J_AreaTuoSize").html(BackTuoN);
    zhushu = DTzhushu(str);
    if (FrontNum + FrontTuoN > 5 && BackNum + BackTuoN > 2) {
        $("#J_PreDantuoMulti").html(zhushu);
        $("#J_PreDantuoMoney").html(zhushu * 2);
    }
    else {
        $("#J_PreDantuoMulti").html(0);
        $("#J_PreDantuoMoney").html(0);
    }
}


//根据选择号码样式设置投注号码串 
function setcode() {
    var str = "";
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
    //手动输入
    if ($("input[name='a']:checked").val() == "sd") {
        str = $("#tb_ManualInput").val();
    }
    //胆拖选号
    if ($("input[name='a']:checked").val() == "dt") {
        //前区胆码
        var FrontAreaDan = document.getElementsByName("Qdama");
        var FrontAreaBallD = "";
        //前区拖码
        var FrontAreaTuo = document.getElementsByName("Qtuoma");
        var FrontAreaBallT = "";
        //后区胆码
        var BackAreaDan = document.getElementsByName("Hdanma");
        var BackAreaBallD = "";
        //后区拖码
        var BackAreaTuo = document.getElementsByName("Htuoma");
        var BackAreaBallT = "";
        for (var i = 0; i < FrontAreaDan.length; i++) {
            if (FrontAreaDan[i].className == "numberh") {
                FrontAreaBallD += ToLength(parseInt(i+1))+" ";
            }
        }
        for (var i = 0; i < FrontAreaTuo.length; i++) {
            if (FrontAreaTuo[i].className == "numberh") {
                FrontAreaBallT += ToLength(parseInt(i+1))+" ";
            }
        }
        for (var i = 0; i < BackAreaDan.length; i++) {
            if (BackAreaDan[i].className == "numberl") {
                BackAreaBallD += ToLength(parseInt(i+1))+" ";
            }
        }
        for (var i = 0; i < BackAreaTuo.length; i++) {
            if (BackAreaTuo[i].className == "numberl") {
                BackAreaBallT += ToLength(parseInt(i+1))+" ";
            }
        }
        str = FrontAreaBallD.substring(FrontAreaBallD.length-1,0) + "$" + FrontAreaBallT.substring(FrontAreaBallT.length-1,0) + "-" + BackAreaBallD.substring(BackAreaBallD.length-1,0) + "$" + BackAreaBallT.substring(BackAreaBallT.length-1,0);
    }

    document.getElementById("code").value = str;
}
//根据号码串统计注数，并设置显示信息
function Show() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = 0;
    if ($("input[name='a']:checked").val() == "fs") {
        if (str.split('-')[0].split(' ').length >= 5 && str.split('-')[1].split(' ').length >= 2) {
            zhushu = getZhushu1(str);
        }
    }
    //手动输入
    if ($("input[name='a']:checked").val() == "sd") {
        for (var i = 0; i < str.split("\r\n").length; i++) {
            if (str.split("\r\n")[i].split('-').length != 2) {
                return false;
            }
            if (str.split("\r\n")[i].split('-')[1].length < 2) {
                return false;
            }
            if (Math.floor(str.split("\r\n")[i].split('-')[0].length / 2) >= 5 && Math.floor(str.split("\r\n")[i].split('-')[1].length / 2) >= 2) {
                //红球
                var Rball = new Array();
                //蓝球
                var Lball = new Array();
                //处理红球
                for (j = 0; j < Math.floor(str.split("\r\n")[i].split('-')[0].length / 2); j++) {
                    Rball[j] = repNum(str.split("\r\n")[i].split('-')[0]).substr(j * 2, 2);
                }
                //处理蓝球
                for (j = 0; j < Math.floor(str.split("\r\n")[i].split('-')[1].length / 2); j++) {
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
                    for (k = 0; k < Rball.length; k++) {
                        RedBall += Rball[k] + " ";
                    }
                    for (k = 0; k < Lball.length; k++) {
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
    $("#danbeizhushu").html(zhushu);
    $("#danbeimoney").html(zhushu*2);
   
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

    if (rn < 5) { BuyZhu = 0; return 0; }
    if (bn < 2) { BuyZhu = 0; return 0; }
    if (BuyNumTemp[1] != "") {
        bn = bn/2;
    } else {
        bn = 0;
    }
    if (rn == 5) {
        if (BuyNumTemp[1] != "") {
            BuyZhu = bn;
        } else {
            BuyZhu = 0;
        }
        return BuyZhu;
    }
    for (var i = 6; i <= rn; i++) {
        tempNum = tempNum * i;
    }
    for (var i = 1; i <= rn - 5; i++) {
        tempNum = tempNum / i;
    }
    BuyZhu = tempNum * bn;
    return parseInt(BuyZhu);
}



//计算方案注数
function getZhushu(str, inset) {
    var zhushu = 0;
    if ($("input[name='a']:checked").val() == "fs") {
        
        var codestr = ""
        if (str.split('-').length != 2) {
            alert('您输入的格式有误！例：前区号码+后区号码');
            return false;
        }
        if (str.split('-')[0].split(' ').length < 5) {
            alert('至少选择5个前区号码！');
            return false;
        }
        if (str.split('-')[1].split(' ').length < 2) {
            alert('至少选择2个后区号码');
            return false; 
        }
        zhushu = getZhushu1(str);
        codestr = str;
        add(codestr, zhushu);
        clearall();
    }
    //手动输入
    if ($("input[name='a']:checked").val() == "sd") {
        //判断手动输入号码是否为空
        if (str == "" || str == null) {
            alert('请您输入号码');
            return false;
        }
        //根据换行符截取
        for (var i = 0; i < str.split('\r\n').length; i++) {
            //判断输入的数否符合标准 红球+篮球 格式
            if (str.split('\r\n')[i].split('-')[0] == null || str.split('\r\n')[i].split('-')[0].toString == "") {
                alert('注意大乐透输入格式');
                return false;
            }
            if (str.split('\r\n')[i].split('-')[1] == null || str.split('\r\n')[i].split('-')[1].toString == "") {
                alert('注意大乐透输入格式');
                return false;
            }

            //定义红球
            var HNum = repNum(str.split('\r\n')[i].split('-')[0]);
            //定义蓝球
            var LNum = repNum(str.split('\r\n')[i].split('-')[1]);

            //判断号码是否合法
            if (Math.floor(HNum.length / 2) < 5 || Math.floor(LNum.length / 2) < 2) {
                alert('前区号码不能少于5个，后区号码不能少于2个');
                return false;
            }
            //重新组合号码 
            
            var Rball = new Array();
            for (var j = 0; j < Math.floor(HNum.length / 2); j++) {
                //验证单个号码是否合法
                if (HNum.substr(j * 2, 2) <=0 || HNum.substr(j* 2, 2) > 35) {
                    alert('前区号码范围01-35');
                    return false;
                }
                Rball[j]= HNum.substr(j * 2, 2);
            }
            
            var bBall = new Array();
            for(var j = 0; j < Math.floor(LNum.length / 2); j++) {
                //验证单个号码是否合法
                if (LNum.substr(j * 2, 2) <=0 || LNum.substr(j * 2, 2) > 12) {
                    alert('后区号码范围01-12');
                    return false;
                }
                bBall[j]= LNum.substr(j * 2, 2);
            }
            //排序号码
            var sortR = new Array();
            var sortL = new Array();
            //红球
            var NHNum = "";
            //蓝球
            var NLNum = "";
            sortR = BubbleSort(Rball);
            sortL = BubbleSort(bBall);
            //判断是否有重复号码
            var doubR = doobNum(sortR);
            var doubL = doobNum(sortL);
            if (doubR != 1 && doubL != 1) {
                for (var j = 0; j < sortR.length; j++) {
                    NHNum += sortR[j] + " ";
                }
                for (var j = 0; j < sortL.length; j++) {
                    NLNum += sortL[j] + " ";
                }
                //组合号码
                var Number = NHNum.substring(NHNum.length - 1, 0) + "-" + NLNum.substring(NLNum.length - 1, 0);
                zhushu = getZhushu1(Number);
                add(Number, zhushu);
               
            }
            else {
                alert('输入的号码中有重复的号码，请检查！');
                return false;
            }
        }
        //清空输入框
        document.getElementById("tb_ManualInput").value = "";
    }
    //胆拖
    if ($("input[name='a']:checked").val() == "dt") {
        //前区胆码（至少选择1个，最多选择4个）
        if (str.split('-')[0].split('$')[0].split(' ').length < 1 || str.split('-')[0].split('$')[0].split(' ').length > 4) {
            alert('前区胆码（至少选择1个，最多选择4个）');
            return false;
        }
        //前区拖码（至少选择2个，至多选16个）
        if (str.split('-')[0].split('$')[1].split(' ').length < 2 || str.split('-')[0].split('$')[1].split(' ').length > 16) {
            alert('前区拖码（至少选择2个，至多选16个）');
            return false;
        }
        //前区胆码 +前区拖码最少选择6个号码
        if (str.split('-')[0].split('$')[0].split(' ').length + str.split('-')[0].split('$')[1].split(' ').length < 6) {
            alert('前区胆码加前区拖码最少选择6个号码');
            return false;
        }
        //后区胆码(至多选1个)
        if (str.split('-')[1].split('$')[0].split(' ').length > 1) {
            alert('后区胆码(至多选1个)');
            return false;
        }
        //后区拖码(至少选2个)
        if (str.split('-')[1].split('$')[1].split(' ').length < 2) {
            alert('后区拖码(至少选2个)');
            return false;
        }
        zhushu = DTzhushu(str);
        var RetStr = "[前区胆码] " + str.split('-')[0].split('$')[0] + " [前区拖码] " + str.split('-')[0].split('$')[1] + "[后区胆码] " + str.split('-')[1].split('$')[0] + "[后区拖码] " + str.split('-')[1].split('$')[1];
        writeselect(RetStr, str + "|" + zhushu);
        clearall();
    }

    return zhushu;
}
//计算胆拖的组数
function DTzhushu(str) { 
   //前区
    var FrontNum = str.split('-')[0];
    //后区
    var BackNum = str.split('-')[1];
    //前区胆码
    var FrontDan=FrontNum.split('$')[0].split(' ').length;
    //前区拖码
    var FrontTuo=FrontNum.split('$')[1].split(' ').length;

    //后区胆码
    var BackDan = BackNum.split('$')[0].split(' ').length;
    //后区拖码
    var BackTuo = BackNum.split('$')[1].split(' ').length;

    var BNT = 1;
    var BND = 1;
    for (var i = 0; i < FrontDan; i++) {
        BNT = BNT * (FrontTuo - i);
        BND = BND * (FrontDan - i);
    }
    var LNT = 1;
    var LND = 1;
    for (var i = 0; i < BackDan; i++) {
        LNT = LNT * (BackTuo - i);
        LND = LND * (BackDan - i);
    }
    var RedBall = BNT / BND;
    var BuleBall = LNT / LND;
    var BuyNum = RedBall * BuleBall;
    return parseInt(BuyNum);
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
//号码栏状态恢复
function clearall() {
    var hongqiu = document.getElementsByName("hongqiu");

    var lanqiu = document.getElementsByName("lanqiu");
    for (var i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" } //清空红球
    for (var i = 0; i < lanqiu.length; i++) { lanqiu[i].className = "number" } //清空蓝球
    //清空前区胆码
    var FrontDanma = document.getElementsByName("Qdama");
    for (var i = 0; i < FrontDanma.length; i++) {
        FrontDanma[i].className = "number";
    }
    //清空前区拖码
    var FrontTuoma = document.getElementsByName("Qtuoma");
    for (var i = 0; i < FrontTuoma.length; i++) {
        FrontTuoma[i].className = "number";
    }
    //清空后区胆码
    var BackDanma = document.getElementsByName("Hdanma");
    for (var i = 0; i < BackDanma.length; i++) {
        BackDanma[i].className = "number";
    }
    //清空后区拖码
    var BackTuoma = document.getElementsByName("Htuoma");
    for (var i = 0; i < BackTuoma.length; i++) {
        BackTuoma[i].className = "number";
    }

    //前区号码
    $("#J_PreDantuoSize").html(0);
    //前区胆码
    $("#J_PreDanSize").html(0);
    //前区拖码
    $("#J_PreTuoSize").html(0);
    //后区号码
    $("#J_PreDantuoBlueSize").html(0);
    //后区胆码
    $("#J_AreaDanSize").html(0);
    //后区拖码
    $("#J_AreaTuoSize").html(0);
    $("#J_PreDantuoMulti").html(0);
    $("#J_PreDantuoMoney").html(0);
        return;
}

function jixuan(n) {
    BuyNum = "";
    type = "jixuan";
    for (var i = 0; i < n; i++) {
        var Itmp1 = Math.ceil(Math.random() * 35); //机选第一个数值
        Itmp1 = ToLength(parseInt(Itmp1));
        while (true) {
            var Itmp2 = Math.ceil(Math.random() * 35); //机选第二个数值
            if (Itmp2 != Itmp1) { Itmp2 = ToLength(parseInt(Itmp2)); break; }
        }
        while (true) {
            var Itmp3 = Math.ceil(Math.random() * 35); //机选第三个数值
            if (Itmp3 != Itmp1 && Itmp3 != Itmp2) { Itmp3 = ToLength(parseInt(Itmp3)); break; }
        }
        while (true) {
            var Itmp4 = Math.ceil(Math.random() * 35); //机选第四个数值
            if (Itmp4 != Itmp1 && Itmp4 != Itmp2 && Itmp4 != Itmp3) { Itmp4 = ToLength(parseInt(Itmp4)); break; }
        }
        while (true) {
            var Itmp5 = Math.ceil(Math.random() * 35); //机选第五个数值
            if (Itmp5 != Itmp1 && Itmp5 != Itmp2 && Itmp5 != Itmp3 && Itmp5 != Itmp4) { Itmp5 = ToLength(parseInt(Itmp5)); break; }
        }
        //前区号码：
        var Itmp7 = Math.ceil(Math.random() * 12); //机选蓝球数值
        Itmp7 = ToLength(parseInt(Itmp7));
        //后区号码：
        var Itmp8 = Math.ceil(Math.random() * 12); //机选蓝球后区号码
        Itmp8 = ToLength(parseInt(Itmp8));

        //组合蓝球号码
        var Itmp9 = Itmp7 + "," + Itmp8;
        var tempmun = new Array(Itmp1, Itmp2, Itmp3, Itmp4, Itmp5); 	//生成数组
        BubbleSort(tempmun); //排序数组
        //alert(tempmun);
        str = tempmun + "-" + Itmp9
        writeselect("[单式]"+str.replace(/,/g," "), str.replace(/,/g," ") + "|" + 1);
    }
    InsertShow();
}

$(document).ready(function () {
    //选择 追加号玩法
    $("#ck_app").click(function () {
        InsertShow();
    });
});