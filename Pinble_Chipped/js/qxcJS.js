//更改球体样式
function xuanhao(obj) {
    var Cname = obj.className;
    if (Cname == "number") {
        obj.className = "numberh";
    }
    if (Cname == "numberh") { obj.className = "number"; }
    DisNum();
}
//选择注数显示金额
function DisNum() {
    setcode();
    var str = document.getElementById("code").value;

    var zhushu = 0;
    //七星彩选号
    if ($("input[name='a']:checked").val() == "zixuan") {
        var Ttext = str.split(",");
        zhushu = (Ttext[0].length) * (Ttext[1].length) * (Ttext[2].length) * (Ttext[3].length) * (Ttext[4].length) * (Ttext[5].length) * (Ttext[6].length);

    }
    // 手动输入号码
    if ($("input[name='a']:checked").val() == "sdsr") {
        for (i = 0; i < str.split('|').length; i++) {
            if (str.split('|')[i].split(',').length == 7) {
                zhushu++;
            }
        }
    }
    $("#danbeizhushu").html(zhushu);
    $("#danbeimoney").html(zhushu * 2);

}


//根据号码串统计注数，并设置显示信息
function Show() {
    setcode();
}

//根据选择号码样式设置投注号码串
function setcode() {
    var selcodestr = "";
    //七星彩选号
    if ($("input[name='a']:checked").val() == "zixuan") {
        for (i = 1; i <= 7; i++) {
            var haoma = document.getElementsByName("three_haoma" + i);
            var codestr = "";
            for (j = 0; j < haoma.length; j++) {
                if (haoma[j].className == "numberh") {
                    codestr = codestr + j;
                }
            }
            if (i == 7) {
                selcodestr = selcodestr + codestr;
            }
            else {
                selcodestr = selcodestr + codestr + ",";
            }

        }

    }
    //手动输入
    if ($("input[name='a']:checked").val() == "sdsr") {
        //清除下拉列表的值
        //        var Temp = document.getElementById("schemeNum"); 	//下拉列表变量
        //        Temp.options.length = 0;

        //剔除字符串中除数字的所有字符
        var regS = new RegExp("[^0-9]", "gim");
        var str = $("#tb_ManualInput").val().replace(regS, "");
        var codestr = "";
        //定义数组
        var tempmun = new Array(Math.floor(str.length / 7));
        for (var i = 0; i < str.length / 7; i++) {
            tempmun[i] = str.substr(i * 7, 7);

        }
        for (var i = 0; i < tempmun.length; i++) {
             codestr += Division(tempmun[i])+"|";
         }
         selcodestr = codestr.substring(codestr.length-1,0);

    }
    document.getElementById("code").value = selcodestr;
}

function getZhushu(str, inset) {
    var zhushu = 0;
    //七星彩选号
    if ($("input[name='a']:checked").val() == "zixuan") {
        var Ttext = str.split(",");
        //长度小于3
        if (Ttext.length < 7) {

            return false;
        }
        if (Ttext[0].length <= 0) {
            alert('请选择第一位号码！');
            return false;
        }
        if (Ttext[1].length <= 0) {
            alert('请选择第二位号码！');
            return false;
        }
        if (Ttext[2].length <= 0) {
            alert('请选择第三位号码！');
            return false;
        }
        if (Ttext[3].length <= 0) {
            alert('请选择第四位号码！');
            return false;
        }
        if (Ttext[4].length <= 0) {
            alert('请选择第五位号码！');
            return false;
        }
        if (Ttext[5].length <= 0) {
            alert('请选择第六位号码！');
            return false;
        }
        if (Ttext[6].length <= 0) {
            alert('请选择第七位号码！');
            return false;
        }

        zhushu = (Ttext[0].length) * (Ttext[1].length) * (Ttext[2].length) * (Ttext[3].length) * (Ttext[4].length) * (Ttext[5].length) * (Ttext[6].length);
        if (zhushu < 1) {
            alert('您选择的号码有误');
            return false;
        }
        //限制七星彩最多买1万注
        if (zhushu > 500) {
            alert("单个方案不能超过500注");
            return false;
        }
        add(str, zhushu);
    }
    // 手动输入号码
    if ($("input[name='a']:checked").val() == "sdsr") {
        if ($("#tb_ManualInput").val() == "" || $("#tb_ManualInput").val() == null) {
            alert('请输入或是粘贴号码');
            return false;
        }
        if (str.split(',').length < 7) {
            alert('请最少输入7个号码');
            return false;
        }
        for (i = 0; i < str.split('|').length; i++) {
            if (str.split('|')[i].split(',').length == 7) {
                add(str.split('|')[i],1);
                zhushu++;
            }
        }
        //清空输入框
        document.getElementById("tb_ManualInput").value = "";
    }
    return zhushu;
}
//向号码拦内添加数据
function add( str, zhushu) {
    var value = "";
    var text = "";
    var state=0;
    for (i = 0; i < str.split(',').length; i++) {
        if (str.split(',')[i].length > 1) {
            state = 1;
            break;
        }
    }
    if (state == 0) {
        value = str;
        text = "[单式] " + str;
        writeselect(text, value + "|" + zhushu);
    }
    if (state == 1) {
        value = str;
        text = "[复式] " + str;
        writeselect(text, value + "|" + zhushu);
    }
}

//写入号码栏
function writeselect(text, value) {		//写入号码栏
    try {
        var temp = document.getElementById("schemeNum"); 	//取得号码栏的下拉菜单
        var Inab = temp.length - 1; 							//判断长度
        temp.options[Inab + 1] = new Option(text, value); 	//写入值
    } catch (e) { }
    clearall();

}



//快速选号的处理函数
function selectcode(num, strtext) {
    var str = "";
    switch (strtext) {
        case 'selall': 
            {
                str = '0,1,2,3,4,5,6,7,8,9'; break;
            } case 'delall': 
            {
                str = ""; break;
            } case 'seljin': 
            {
                str = '1,3,5,7,9'; break;
            } case 'selou': 
            {
                str = '0,2,4,6,8'; break;
            } case 'selda': 
            {
                str = '5,6,7,8,9'; break;
            } case 'selxiao': 
            {
                str = '0,1,2,3,4'; break;
            }
    }

    var haoma = document.getElementsByName("three_haoma" + num);
    for (j = 0; j < haoma.length; j++) {
        if (str.indexOf(j) != -1) {
            haoma[j].className = "numberh";
        }
        else {
            haoma[j].className = "number";
        }
    }
}

//清理所有的投注号码状态
function clearall() {
    //清楚组选号码区
    var haoma = document.getElementsByName("one_haoma");
    for (i = 0; i < haoma.length; i++) {
        if (haoma[i].className != "number") {
            haoma[i].className = "number";
        }
    }

    //清楚直选号码区
    for (i = 1; i <= 7; i++) {
        var haoma = document.getElementsByName("three_haoma" + i);
        for (j = 0; j < haoma.length; j++) {

            if (haoma[j].className != "number") {
                haoma[j].className = "number";
            }
        }
    }
    return;
}
//添加号码
function Insert() {

    setcode();
    var str = document.getElementById("code").value;
    var zhushu = getZhushu(str, "1");
    InsertShow();

}

//机选处理函数
function jixuan(Strmun) {		//机选函数 /然后通过 随机数重复判断 得到数组	时时乐机选一注为  三个数字
    for (Tmun = 1; Tmun <= Strmun; Tmun++) {
        var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
        var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
        var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        var Itmp4 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        var Itmp5 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        var Itmp6 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        var Itmp7 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        var tempmun = new Array(Itmp1, Itmp2, Itmp3,Itmp4,Itmp5,Itmp6,Itmp7); 	//生成数组
        writeselect("[单式] " + tempmun, tempmun + "|1"); 	//写入号码栏
    }
    InsertShow();
}


function revert() {
    fangshi();
    var textstr = document.getElementById("textstr").value;
    var valuestr = document.getElementById("valuestr").value;
    if (textstr != "") {
        var texta = textstr.split(";");
        var valuea = valuestr.split(";");
        for (i = 0; i <= texta.length - 1; i++) {
            writeselect(texta[i], valuea[i]);
        }
    }
    InsertShow();
}
$(document).ready(function () {
    $(".J_SelectBuyMethod").click(function () {
        $("#ssq_fs").attr("class", "uchoose");
        $("#ssq_sc").attr("class", "uchoose");
        $("#ssq_sd").attr("class", "uchoose");
        //切换选号还是上传
        if ($("input[name='a']:checked").val() == "shangchuan") {
            $("#ssq_sc").attr("class", "choose");
            document.getElementById("zx_upload").style.display = "block";
            document.getElementById("touzhushow1").style.display = "none";

        }
        if ($("input[name='a']:checked").val() == "zixuan") {
            $("#ssq_fs").attr("class", "choose");
            document.getElementById("zx_upload").style.display = "none";
            document.getElementById("touzhushow1").style.display = "block";
            //隐藏输入框
            document.getElementById("sdsrh").style.display = "none";
            //显示选号
            document.getElementById("xuanqiu").style.display = "block";

            $("#Prompt").html("每位至少选择一个号码");
        }
        if ($("input[name='a']:checked").val() == "sdsr") {
            $("#ssq_sd").attr("class", "choose");
            //点击手动输入
            document.getElementById("sdsrh").style.display = "block";
            document.getElementById("xuanqiu").style.display = "none";


            document.getElementById("touzhushow1").style.display = "block";

            $("#Prompt").html("请输入或是复制您的号码到文本框");

        }

    });
});
