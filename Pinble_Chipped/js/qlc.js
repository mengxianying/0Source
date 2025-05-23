
//机选号码
function jxhq(colorn) {
    var selectValueh = document.getElementById("J_JxRedNum");
    //    var selectValuel = document.getElementById("J_JxBlueNum");
    var arr = new Array();
    //机选红球
    if (colorn == "h") {
        var hongqiu = document.getElementsByName("hongqiu");
        for (i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" }
        arr = random_select(selectValueh.value, 30, 1);

        for (var j = 0; j < arr.length; j++) {
            if ((arr[j] - 1) >= 0)
                hongqiu[arr[j] - 1].className = "numberh";
            else
                hongqiu[0].className = "numberh";
        }
    }
    Show();
}
//胆拖选号
function DTxuanhao(obj, sort) {
    var Cname = obj.className;
    if (Cname == "number") {
        if (sort == "h") {
            obj.className = "numberh";
        } 
    }
    if (Cname == "numberh") { obj.className = "number"; }
    var danma = document.getElementsByName("danma");
    var tuoma = document.getElementsByName("tuoma");
    for (i = 0; i < 30; i++) {
        if (danma[i].className == "numberh" && danma[i].id == obj.id) {
            tuoma[i].className = "number";

        }
        if (tuoma[i].className == "numberh" && tuoma[i].id == obj.id) {
            danma[i].className = "number";

        }
    }
    DisMoney();
}
//选号显示金额
function DisMoney() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = 0;
    zhushu = DTzhushu(str);
    if (str.split('$')[0] != "" && str.split("$")[0].split(' ').length + str.split("$")[1].split(' ').length > 7) {
        $("#EmNum").html(zhushu);
        $("#EmMoney").html(zhushu*2);
    }
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
    Show();
}

//根据选择号码样式设置投注号码串
function setcode() {
    var selcodestr = "";
    var coder = "";
    //七乐彩选号
    if ($("input[name='a']:checked").val() == "pt") {
        var haoma = document.getElementsByName("hongqiu");
        for (i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "numberh") {
                coder += ToLength(parseInt(i + 1)) + " ";
            }
        }
        selcodestr = coder.substring(coder.length-1,0);
    }
    //手动输入
    if ($("input[name='a']:checked").val() == "sd") {
        selcodestr = $("#tb_ManualInput").val();
    }
    //胆拖
    if ($("input[name='a']:checked").val() == "dt") {
        var danma = document.getElementsByName("danma");
        var GroupDanma = "";
        for (i = 0; i < danma.length; i++) {
            if (danma[i].className == "numberh") {
                GroupDanma += ToLength(parseInt(i+1))+" ";
            }
        }
        var tuoma = document.getElementsByName("tuoma");
        var GroupTuoma = "";
        for (i = 0; i < tuoma.length; i++) {
            if (tuoma[i].className == "numberh") {
                GroupTuoma += ToLength(parseInt(i+1))+" ";
            }
        }
        selcodestr = GroupDanma.substring(GroupDanma.length - 1, 0) + "$" + GroupTuoma.substring(GroupTuoma.length-1,0);
    }
    document.getElementById("code").value = selcodestr;
}

//根据号码串统计注数，并设置显示信息
function Show() {
    setcode();
    var zhushu = 0
    var str = document.getElementById("code").value;
    //选号
    if ($("input[name='a']:checked").val() == "pt") {
        if (str.split(' ').length < 7) {
            return false;
        }
        zhushu = getZhushu1(str);
    }
    //手动输入
    if ($("input[name='a']:checked").val()=="sd") {

        for (var i = 0; i < str.split("\r\n").length; i++) {
            var ballN = "";
            var numball = repNum(str.split("\r\n")[i]);
            if (Math.floor(numball.length / 2) > 6) {
                for (j = 0; j < Math.floor(numball.length / 2); j++) {
                    if (numball.substr(j * 2, 2) > 30) {
                        alert('号码最大不能超过30');
                        return false;
                    }
                    ballN += ToLength(parseInt(numball.substr(j * 2, 2))) + " ";
                }
                zhushu += getZhushu1(ballN.substr(0, ballN.length - 1));
            }  
        }
        
    }
    $("#danbeizhushu").html(zhushu);
    $("#danbeimoney").html(zhushu*2);
}

    //剔除字符串中除数字的所有字符
function repNum(str) {
    var regS = new RegExp("[^0-9]", "gim");
    var strNum = str.replace(regS, "");
    return strNum;
}

function Insert() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = getZhushu(str, "1");
    InsertShow();
}
function getZhushu1(BuyNum) {
    if (BuyNum == "") {
        return 0;
    }
    var rn = parseInt((BuyNum.split(" ")).length);
    var tempNum = 1;

    for (var i = 8; i <= rn; i++) {
        tempNum = tempNum * i;
    }
    for (var i = 1; i <= rn - 7; i++) {
        tempNum = tempNum / i;
    }
    return parseInt(tempNum);
}
//计算胆拖的组数
function DTzhushu(str) {
    if (str == "$") { 
        return 0;
    }
    //胆码
    var dan=str.split('$')[0].split(' ').length;
    //拖码
    var tuo = str.split('$')[1].split(' ').length;
    var nDen = 1;
    var nMol = 1;
    var BuyZhu = 0;
    if (dan > 0 && dan <=6) {
        for (var i = 0; i < 7 - dan; i++) {
            nDen = nDen * (tuo - i);
            nMol = nMol * (7 - dan - i);
        }
        BuyZhu = nDen / nMol;
    }
    
   
    return parseInt(BuyZhu);
}


//计算方案注数
function getZhushu(str, inset) {
    var zhushu = 0;
    var codestr = ""
    if (str == "") {
        alert('请选择号码！');
        return false;
    }
    if ($("input[name='a']:checked").val() == "pt") {
        
        if (str.split(' ').length < 7) {
            alert('最少选择7个号码球!');
            return false;
        }
        zhushu = getZhushu1(str);
        codestr = str;
        add(codestr, zhushu);
        clearall();
    }
    //手动输入
    if ($("input[name='a']:checked").val() == "sd") {
        
        var arr = new Array();
        var nRetArr = new Array();
        for (var i = 0; i < str.split("\r\n").length; i++) {
            var ballN = "";
            var numball = repNum(str.split("\r\n")[i]);
            if (Math.floor(numball.length / 2) <7) {
                alert('您的号码不足7位');
                return false;
            }
            for (var j = 0; j < Math.floor(numball.length / 2); j++) {
                if (numball.substr(j * 2, 2) > 30 || numball.substr(j * 2, 2)<=0) {
                    alert('七乐彩号码范围01-30');
                    return false;
                }
                
                arr[j] = numball.substr(j * 2, 2);
                ballN += numball.substr(j * 2, 2) + " ";
            }
            //去除重复
            nRetArr = doobNum(arr);
            if (nRetArr == 1) {
                alert('您输入的号码有重复');
                return false;
                break;
            }
            else {
                zhushu = getZhushu1(ballN.substr(0, ballN.length - 1));
                add(ballN.substr(0, ballN.length - 1), zhushu);
//                arr.splice(0, 100000000); 
            }
        }

        
        //清空输入框
        document.getElementById("tb_ManualInput").value = "";
    }
    //胆拖
    if ($("input[name='a']:checked").val() == "dt") {
        //必须选择一个胆码
        if (str.split('$')[0] == "") {
            alert('必须选择一个胆码');
            return false;
        }
        if (str.split('$')[0].split(' ').length > 6) {
            alert('最多可以选择6个胆码');
            return false;
        }
        //胆码和拖码至少选择8个
        if (str.split('$')[0].split(' ').length + str.split('$')[1].split(' ').length <8) {
            alert('胆码和拖码至少要选择8个');
            return false;
        }
        zhushu = DTzhushu(str);
        var RetStr = "[胆码] " + str.split('$')[0] + " [拖码] " + str.split('$')[1];
        writeselect(RetStr, str + "|" + zhushu);
        clearall();
    }
    return zhushu;

}

//号码栏状态恢复
function clearall() {
    var hongqiu = document.getElementsByName("hongqiu");

    for (var i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" } //清空红球
    //清空胆码区
    var danma = document.getElementsByName("danma");
    for (var i = 0; i < danma.length; i++) {
        danma[i].className = "number";
    }
    //清空拖码区
    var tuoma = document.getElementsByName("tuoma");
    for (var i = 0; i < tuoma.length; i++) {
        tuoma[i].className = "number";
    }
    $("#EmNum").html(0);
    $("#EmMoney").html(0);

    return;
}


function jixuan_1(n) {
    BuyNum = "";
    type = "jixuan";
    for (var i = 0; i < n; i++) {
        var Itmp1 = Math.ceil(Math.random() * 30); //机选第一个数值
        Itmp1 = ToLength(parseInt(Itmp1));
        while (true) {
            var Itmp2 = Math.ceil(Math.random() * 30); //机选第二个数值
            if (Itmp2 != Itmp1) { Itmp2 = ToLength(parseInt(Itmp2)); break; }
        }
        while (true) {
            var Itmp3 = Math.ceil(Math.random() * 30); //机选第三个数值
            if (Itmp3 != Itmp1 && Itmp3 != Itmp2) { Itmp3 = ToLength(parseInt(Itmp3)); break; }
        }
        while (true) {
            var Itmp4 = Math.ceil(Math.random() * 30); //机选第四个数值
            if (Itmp4 != Itmp1 && Itmp4 != Itmp2 && Itmp4 != Itmp3) { Itmp4 = ToLength(parseInt(Itmp4)); break; }
        }
        while (true) {
            var Itmp5 = Math.ceil(Math.random() * 30); //机选第五个数值
            if (Itmp5 != Itmp1 && Itmp5 != Itmp2 && Itmp5 != Itmp3 && Itmp5 != Itmp4) { Itmp5 = ToLength(parseInt(Itmp5)); break; }
        }
        while (true) {
            var Itmp6 = Math.ceil(Math.random() * 30); //机选第六个数值
            if (Itmp6 != Itmp1 && Itmp6 != Itmp2 && Itmp6 != Itmp3 && Itmp6 != Itmp4 && Itmp6 != Itmp5) { Itmp6 = ToLength(parseInt(Itmp6)); break; }
        }

        while (true) {
            var Itmp7 = Math.ceil(Math.random() * 30); //机选第七个数值
            if (Itmp7 != Itmp1 && Itmp7 != Itmp2 && Itmp7 != Itmp3 && Itmp7 != Itmp4 && Itmp7 != Itmp5 && Itmp7 != Itmp6) { Itmp7 = ToLength(parseInt(Itmp7)); break; }
        }

        var Itmp8 = Math.ceil(Math.random() * 30); //机选蓝球数值
        Itmp8 = ToLength(parseInt(Itmp8));
        var tempmun = new Array(Itmp1, Itmp2, Itmp3, Itmp4, Itmp5, Itmp6, Itmp7); 	//生成数组
        BubbleSort(tempmun); //排序数组ZZ
        str = tempmun
        writeselect("[单式]"+str, str + "|" + 1);
    }
    InsertShow();
    Show();
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