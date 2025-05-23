//更改球体样式
function xuanhao(obj) {
    var Cname = obj.className;
    if (Cname == "number") {
        obj.className = "numberh";
    }
    if (Cname == "numberh") { obj.className = "number"; }
    //    Show();
    DisNum();
}
//显示选了几个号码
function DisNum() {
    var obj = document.getElementsByName("Buytype");
    var typestr = "";
    for (i = 0; i <= obj.length; i++) {
        if (obj[i].checked == true) {
            typestr = obj[i].value;
            break;
        }
    }
    setcode(typestr);
    var str = document.getElementById("code").value;
    var zhushu = 0;
    if (typestr == "zx") {
        if ($("input[name='a']:checked").val() == "zixuan") {
            var Ttext = str.split(",");
            //长度小于3
            if (Ttext.length < 3) {

                return false;
            }
            zhushu = (Ttext[0].length) * (Ttext[1].length) * (Ttext[2].length);

        }

        if ($("input[name='a']:checked").val() == 'dt') {
            var zhushu = 0;
            //循环选择的号码
            for (var i = 0; i < str.split(',').length; i++) {
                var retNum = SDhz(str.split(',')[i]);

                for (var j = 0; j < retNum.split(',').length; j++) {
                    zhushu++;
                }
            }
        }
        //手动输入
        if ($("input[name='a']:checked").val() == "sdsr") {
            if (str == "") {
                alert('请粘贴或是手动输入号码');
                return false;
            }

            var zhushu = 0;
            var arr = new Array();
            for (i = 0; i < str.split(',').length; i++) {
                if (str.split(',')[i].toString().length < 3) {
                    break;
                }
                arr[i] = str.split(',')[i];
            }
            var retStr = RemoveDuplicate(arr);
            zhushu = retStr.length;
        }

    }
    //组选
    if (typestr == "zux") {
        if ($("input[name='a']:checked").val() == "zixuan") {
            var Ttext = str.split(",");
            //长度小于3
            if (Ttext.length < 3) {

                return false;
            }
            zhushu = (Ttext[0].length) * (Ttext[1].length) * (Ttext[2].length);

        }

        if ($("input[name='a']:checked").val() == 'dt') {
            var zhushu = 0;
            var arrS = new Array();
            var sortStr = new Array();
            var comb = new Array();
            var num = "";
            //循环选择的号码
            for (var i = 0; i < str.split(',').length; i++) {
                var retNum = SDhz(str.split(',')[i]);

                for (var j = 0; j < retNum.split(',').length; j++) {
                    //拆分数字
                    var Rstr = Division(retNum.split(',')[j]);
                    //排序
                    arrS[0] = Rstr.split(',')[0];
                    arrS[1] = Rstr.split(',')[1];
                    arrS[2] = Rstr.split(',')[2];
                    sortStr = sort(arrS);
                    //组合号码
                    for (t = 0; t < sortStr.length; t++) {
                        num = num + sortStr[t];
                    }
                    comb[j] = num;
                    num = "";
                }
                //去除数组中的重复数据
                var delrep = new Array();
                delrep = RemoveDuplicate(comb);
                zhushu += delrep.length;
            }
            
        }
        //手动输入
        if ($("input[name='a']:checked").val() == "sdsr") {
            if (str == "") {
                alert('请粘贴或是手动输入号码');
                return false;
            }

            var zhushu = 0;
            var arr = new Array();
            for (i = 0; i < str.split(',').length; i++) {
                if (str.split(',')[i].toString().length < 3) {
                    break;
                }
                arr[i] = str.split(',')[i];
            }
            var retStr = RemoveDuplicate(arr);
            zhushu = retStr.length;
        }
    }

    //组选三
    if (typestr == "z3bh") {
        //选号投注
        if ($("input[name='b']:checked").val() == "zx3p") {
            var Ttext = zx3Value(str);
            if (Ttext != "" && Ttext != null) {
                zhushu = Ttext.split(',').length;
            }
        }
        //和值
        if ($("input[name='b']:checked").val() == "zx3h") {
            var arr = new Array();
            for (var i = 0; i < str.split(',').length; i++) {
                var num = zxhz(str.split(',')[i], "zx3");
                for (var j = 0; j < num.split(',').length; j++) {
                    arr[j] = num.split(",")[j];
                }
                //去除重复
                var arrStr = RemoveDuplicate(arr);
                zhushu += arrStr.length;
            }
            
        }
        //组选三手动输入
        if ($("input[name='b']:checked").val() == "zx3sd") {
            zhushu = str.split(',').length;
        }

    }
    //组选6
    if (typestr == "zl") {
        //普通选号
        if ($("input[name='c']:checked").val() == "zx6p") {
            //处理后的组选6号码
            if (str.length == 3) {
                zhushu = 1;
            }
            else {
                var Ttext = zx6Val(str);
                zhushu = Ttext.split(',').length;
            }
        }
        //组选六 和值选号
        if ($("input[name='c']:checked").val() == "zx6hz") {
            var arr = new Array();
            for (var i = 0; i < str.split(',').length; i++) {
                var num = zxhz(str.split(',')[i], "zx6");
                for (var j = 0; j < num.split(',').length; j++) {
                    arr[j] = num.split(",")[j];
                }
                //去除重复
                var arrStr = RemoveDuplicate(arr);
                zhushu += arrStr.length;
            }
            
        }
        //组选六 手动输入
        if ($("input[name='c']:checked").val() == "zx6sd") {
            if ($("#tb_ManualInput").val() == "" || $("#tb_ManualInput").val() == null) {
                alert('请您复制或是输入号码');
                return false;
            }
            zhushu = str.split(',').length;
        }

    }
    $("#danbeizhushu").html(zhushu);
    $("#danbeimoney").html(zhushu * 2);
}

//选择投注方式
function fangshi() {
    var obj = document.getElementsByName("Buytype");

    var typestr = "";
    for (i = 0; i <= obj.length; i++) {
        if (obj[i].checked == true) {
            typestr = obj[i].value;
            break;
        }
    }

    show_fangshi(typestr);
    clearall();
    return;
}


//根据号码串统计注数，并设置显示信息
function Show() {
    var obj = document.getElementsByName("Buytype");
    var typestr = "";
    for (i = 0; i <= obj.length; i++) {
        if (obj[i].checked == true) {
            typestr = obj[i].value;
            break;
        }
    }
    setcode(typestr);
}

//根据选择号码样式设置投注号码串
function setcode(typestr) {
    var selcodestr = "";

    //直选 组选
    if (typestr == 'zx' || typestr == "zux") {

        //当选择为普通投注的时候
        if ($("input[name='a']:checked").val() == 'zixuan') {
            for (i = 1; i <= 3; i++) {
                var haoma = document.getElementsByName("three_haoma" + i);
                var codestr = "";
                for (j = 0; j < haoma.length; j++) {
                    if (haoma[j].className == "numberh") {
                        codestr = codestr + j;
                    }
                }
                if (i == 3) {
                    selcodestr = selcodestr + codestr;
                }
                else {
                    selcodestr = selcodestr + codestr + ",";
                }

            }
        }

        //选择的是直选和值
        if ($("input[name='a']:checked").val() == "dt") {
            var haoma = document.getElementsByName("hezhi_haoma");
            var codestr = "";
            var state = 0;
            for (j = 0; j < haoma.length; j++) {
                if (haoma[j].className == "numberh") {
                    if (state == 1) {
                        codestr = codestr + ',' + j;
                    }
                    else {
                        codestr = codestr + j;
                        state = 1;
                    }

                }
            }
            selcodestr = codestr;
        }
        //手动输入
        if ($("input[name='a']:checked").val() == "sdsr") {

            //剔除字符串中除数字的所有字符
            var regS = new RegExp("[^0-9]", "gim");
            var str = $("#tb_ManualInput").val().replace(regS, "");
            //定义数组
            var tempmun = new Array(Math.floor(str.length / 3));
            for (var i = 0; i < str.length / 3; i++) {
                tempmun[i] = str.substr(i * 3, 3);

            }
            var codestr = "";
            for (var i = 0; i < tempmun.length; i++) {
                codestr += tempmun[i] + ",";
            }
            selcodestr = codestr.substring(codestr.length - 1, 0);
        }

    }
    //组选三
    if (typestr == 'z3bh') {
        //当选择为普通投注的时候
        if ($("input[name='b']:checked").val() == 'zx3p') {
            var haoma = document.getElementsByName("three_haoma5");
            var codestr = "";
            var state = 0;
            var i = 0;

            for (j = 0; j < haoma.length; j++) {
                if (haoma[j].className == "numberh") {
                    codestr = codestr + j;
                    i++;
                }
            }
            selcodestr = codestr;

        }
        //组选三和值
        if ($("input[name='b']:checked").val() == "zx3h") {
            var haoma = document.getElementsByName("zx_haoma");
            var codestr = "";
            var state = 0;
            for (j = 0; j < haoma.length; j++) {
                if (haoma[j].className == "numberh") {
                    if (state == 1) {
                        codestr = codestr + ',' + j;
                    }
                    else {
                        codestr = codestr + j;
                        state = 1;
                    }

                }
            }
            selcodestr = codestr;
        }
        //手动输入 组选三
        if ($("input[name='b']:checked").val() == "zx3sd") {

            //剔除字符串中除数字的所有字符
            var regS = new RegExp("[^0-9]", "gim");
            var str = $("#tb_ManualInput").val().replace(regS, "");
            //定义数组
            var tempmun = new Array(Math.floor(str.length / 3));
            for (var i = 0; i < str.length / 3; i++) {
                tempmun[i] = str.substr(i * 3, 3);

            }
            var codestr = "";
            var arr = new Array();
            var retStr = new Array();
            var numStr = new Array();
            for (var j = 0; j < tempmun.length; j++) {
                //分割
                var str = Division(tempmun[j]);
                //排序
                for (k = 0; k < str.split(',').length; k++) { //1,2,3   1,1,2  ,2,1,1 
                    arr[k] = str.split(',')[k];
                }
                if (arr[0] == arr[1] || arr[1] == arr[2]) {
                    if (arr[0] == arr[2]) {

                    }
                    else {
                        retStr = BubbleSort(arr);
                        //组合数据
                        numStr[numStr.length] = retStr[0].toString() + retStr[1].toString() + retStr[2].toString();
                    }
                }

            }
            //去除重复号码
            var RetNum = new Array();
            RetNum = RemoveDuplicate(numStr);
            //号码组合成字符串
            for (p = 0; p < RetNum.length; p++) {
                codestr += RetNum[p].toString() + ",";
            }

            selcodestr = codestr.substring(codestr.length - 1, 0);

        }
    }

    //组选六
    if (typestr == "zl") {
        if ($("input[name='c']:checked").val() == "zx6p") {
            //获取选择的号码
            var haoma = document.getElementsByName("three_haoma5");
            var codestr = "";
            var state = 0;
            var i = 0;

            for (j = 0; j < haoma.length; j++) {
                if (haoma[j].className == "numberh") {
                    codestr = codestr + j;
                    i++;
                }
            }
            selcodestr = codestr;
        }
        // 组选六和值
        if ($("input[name='c']:checked").val() == "zx6hz") {
            var haoma = document.getElementsByName("zx6_haoma");
            var codestr = "";
            var state = 0;
            for (j = 3; j < haoma.length; j++) {
                if (haoma[j].className == "numberh") {
                    if (state == 1) {
                        codestr = codestr + ',' + j;
                    }
                    else {
                        codestr = codestr + j;
                        state = 1;
                    }

                }
            }
            selcodestr = codestr;
        }
        //组选六手动输入
        if ($("input[name='c']:checked").val() == "zx6sd") {
            //剔除字符串中除数字的所有字符
            var regS = new RegExp("[^0-9]", "gim");
            var str = $("#tb_ManualInput").val().replace(regS, "");
            //定义数组
            var tempmun = new Array(Math.floor(str.length / 3));
            for (var i = 0; i < str.length / 3; i++) {
                tempmun[i] = str.substr(i * 3, 3);

            }
            var codestr = "";
            var arr = new Array();
            var retStr = new Array();
            var numStr = new Array();
            for (var j = 0; j < tempmun.length; j++) {
                //分割
                var str = Division(tempmun[j]);
                //排序
                for (k = 0; k < str.split(',').length; k++) {
                    arr[k] = str.split(',')[k];
                }
                if (arr[0] == arr[1] || arr[1] == arr[2]) {

                }
                else {
                    if (arr[0] != arr[2]) {
                        retStr = BubbleSort(arr);
                        //组合数据
                        numStr[numStr.length] = retStr[0].toString() + retStr[1].toString() + retStr[2].toString();
                    }
                }

            }
            //去除重复号码
            var RetNum = new Array();
            RetNum = RemoveDuplicate(numStr);
            //号码组合成字符串
            for (p = 0; p < RetNum.length; p++) {
                codestr += RetNum[p].toString() + ",";
            }

            selcodestr = codestr.substring(codestr.length - 1, 0);
        }

    }



    //当直选和值号码栏显示的时候

    document.getElementById("code").value = selcodestr;
}

//计算直选和值注数
function SDhz(str) {
    var retStr = "";
    for (var i = 0; i < 10; i++) { //a1
        for (var j = 0; j < 10; j++) {//a2
            for (var k = 0; k < 10; k++) { //a3
                if (i + j + k == str) {
                    //排3组选没有豹子号
                    if ($("input[name='Buytype']:checked").val() == "zux") {
                        if (i == j && i == k && j == k) {
                            
                        }
                        else {
                            retStr += i.toString() + j.toString() + k.toString() + ",";
                        }
                        
                    }
                    else {
                        retStr += i.toString() + j.toString() + k.toString() + ",";
                    }
                }
                if (i + j + k > str) {
                    break;
                }
            }
        }
    }
    return retStr.substring(retStr.length - 1, 0);
}
//计算组选三和值注数
function zxhz(str, obj) {
    var arr = new Array();
    var retStr = "";
    for (var i = 0; i < 10; i++) { //a1
        for (var j = 0; j < 10; j++) {//a2
            for (var k = 0; k < 10; k++) { //a3
                if (i + j + k == str) {
                    //返回组选三和值
                    if (obj == "zx3") {
                        if (i == j || j == k) {
                            if (i == j && i == k && j == k) {
                                break;
                            }
                            else {
                                arr[0] = i;
                                arr[1] = j;
                                arr[2] = k;
                                var retArr = BubbleSort(arr);
                                //数字排序
                                retStr += retArr[0].toString() + retArr[1].toString() + retArr[2].toString() + ",";
                            }
                        }
                    }
                    if (obj == "zx6") {
                        //返回组选六和值
                        if (i == j || j == k || i == k) {
                            if (i == j && i == k && j == k) {
                                break;
                            }
                            break;
                        }
                        else {
                            if (i == j && i == k && j == k) {
                                break;
                            }
                            arr[0] = i;
                            arr[1] = j;
                            arr[2] = k;
                            var retArr = BubbleSort(arr);
                            //数字排序
                            retStr += retArr[0].toString() + retArr[1].toString() + retArr[2].toString() + ",";
                        }
                    }
                }
                if (i + j + k > str) {
                    break;
                }
            }
        }
    }
    return retStr.substring(retStr.length - 1, 0);
}



//计算组选三选号
function zx3Value(str) { //格式 1,2,3,4,5,6,7
    var strVal = "";
    for (var i = 0; i < str.length; i++) {
        for (var j = i + 1; j < str.length; j++) {

            strVal += bb(str.substr(i,1).toString(), str.substr(j,1).toString()) + ",";
        }
    }
    return strVal.substring(strVal.length - 1, 0);
}
function bb(a, b) {
    return a + a + b + "," + a + b + b;
}
//计算组选六选号注
function zx6Val(str) { // str=0,1,2,3,4,5 选择的号码0-9 
    var strVal = "";
    if (str.length == 3) {
        return str.substr(0, 1).toString() + "," + str.substr(1, 1).toString() + "," + str.substr(2, 1).toString();
    }
    else {
        for (var i = 0; i < str.length; i++) { //1,2,3,4
            for (var j = i + 1; j < str.length; j++) {
                for (var k = j + 1; k < str.length; k++) {
                    if (str.substr(i, 1) != str.substr(j, 1) && str.substr(j, 1) != str.substr(k, 1)) {
                        strVal += str.substr(i, 1).toString() + str.substr(j, 1).toString() + str.substr(k, 1).toString() + ",";
                    }
                }
            }
        }
        return strVal.substring(strVal.length - 1, 0);
    }
}


function getZhushu(str, type, inset) {
    var zhushu = 0;
    if (type == "zx") {
        if ($("input[name='a']:checked").val() == "zixuan") {
            var Ttext = str.split(",");
            //长度小于3
            if (Ttext.length < 3) {

                return false;
            }
            zhushu = (Ttext[0].length) * (Ttext[1].length) * (Ttext[2].length);
            if (Ttext[0].length == 0) {
                alert('请选择百位号码');
                return false;
            }
            if (Ttext[1].length == 0) {
                alert('请选择十位号码');
                return false;
            }
            if (Ttext[2].length == 0) {
                alert('请选择个位号码');
                return false;
            }
            //处理复式选号
            for (i = 0; i < Ttext[0].length; i++) {
                for (j = 0; j < Ttext[1].length; j++) {
                    for (k = 0; k < Ttext[2].length; k++) {
                        var Snum = Ttext[0].substr(i, 1)+"," + Ttext[1].substr(j, 1)+"," + Ttext[2].substr(k, 1);
                        add(type, Snum, 1);
                    }
                }
            }
        }

        if ($("input[name='a']:checked").val() == 'dt') {
            //判断是否有数字
            if (str == "") {
                alert('最少选择一个号码');
                return false;
            }

            var zhushu = 0;
            //循环选择的号码
            for (var i = 0; i < str.split(',').length; i++) {
                var retNum = SDhz(str.split(',')[i]);
                zhushu = zhushu + retNum.split(',').length;
            }

            add(type,str,zhushu);
        }
        //手动输入
        if ($("input[name='a']:checked").val() == "sdsr") {
            if (str == "") {
                alert('请粘贴或是手动输入号码');
                return false;
            }

            var zhushu = 0;
            var arr = new Array();
            for (i = 0; i < str.split(',').length; i++) {
                if (str.split(',')[i].toString().length < 3) {
                    break;
                }
                arr[i] = str.split(',')[i];
            }
            var retStr = RemoveDuplicate(arr);
            for (j = 0; j < retStr.length; j++) {
                var nRstr = Division(retStr[j]);
                add(type, nRstr, 1);
                zhushu++;
            }
        }
        document.getElementById("tb_ManualInput").value = "";
    }
    //组选
    if (type == "zux") {
        if ($("input[name='a']:checked").val() == "zixuan") {
            var Ttext = str.split(",");
            //长度小于3
            if (Ttext.length < 3) {

                return false;
            }
            zhushu = (Ttext[0].length) * (Ttext[1].length) * (Ttext[2].length);
            if (zhushu < 1) {
                alert('您选择的号码有误');
                return false;
            }
            //处理复式选号
            for (i = 0; i < Ttext[0].length; i++) {
                for (j = 0; j < Ttext[1].length; j++) {
                    for (k = 0; k < Ttext[2].length; k++) {
                        var Snum = Ttext[0].substr(i, 1) + "," + Ttext[1].substr(j, 1) + "," + Ttext[2].substr(k, 1);

                        if (Snum.split(',')[0] == Snum.split(',')[1] && Snum.split(',')[0] == Snum.split(',')[2] && Snum.split(',')[1] == Snum.split(',')[2]) {
                            add("zx", Snum, 1);
                        }
                        else {
                            add(type, Snum, 1);
                        }
                    }
                }
            }
        }

        if ($("input[name='a']:checked").val() == 'dt') {
            //判断是否有数字
            if (str == "") {
                alert('最少选择一个号码');
                return false;
            }
            var zhushu = 0;
            var arrS = new Array();
            var sortStr = new Array();
            var comb = new Array();
            var num = "";
            //循环选择的号码
            for (var i = 0; i < str.split(',').length; i++) {
                var retNum = SDhz(str.split(',')[i]);
                for (var j = 0; j < retNum.split(',').length; j++) {
                    //拆分数字
                    var Rstr = Division(retNum.split(',')[j]);
                    //排序
                    arrS[0] = Rstr.split(',')[0];
                    arrS[1] = Rstr.split(',')[1];
                    arrS[2] = Rstr.split(',')[2];
                    sortStr = sort(arrS);
                    //组合号码
                    for (t = 0; t < sortStr.length; t++) {
                        num = num + sortStr[t];
                    }
                    comb[j] = num;
                    num = "";
                }
                //去除数组中的重复数据
                var delrep = new Array();
                delrep = RemoveDuplicate(comb);
                zhushu += delrep.length;
            }
            
            add(type, str, zhushu);

        }
        //手动输入
        if ($("input[name='a']:checked").val() == "sdsr") {
            if (str == "") {
                alert('请粘贴或是手动输入号码');
                return false;
            }

            var zhushu = 0;
            var arr = new Array();
            for (i = 0; i < str.split(',').length; i++) {
                if (str.split(',')[i].toString().length < 3) {
                    break;
                }
                arr[i] = str.split(',')[i];
            }
            var retStr = RemoveDuplicate(arr);
            for (j = 0; j < retStr.length; j++) {
                var nRstr = Division(retStr[j]);
                add(type, nRstr, 1);
                zhushu++;
            }
        }
        document.getElementById("tb_ManualInput").value = "";
    }

    //组选三
    if (type == "z3bh") {
        //选号投注
        if ($("input[name='b']:checked").val() == "zx3p") {
            //判断是否选择了 两个号码
            if (str.length < 2) {
                alert('至少选择2个号码');
                return false;
            }
            var Ttext = zx3Value(str);
            zhushu=Ttext.split(',').length;
            add(type,str,zhushu);
        }
        //和值
        if ($("input[name='b']:checked").val() == "zx3h") {
            if (str == "") {
                alert('请您选择一个和值号码');
                return false;
            }
            var arr = new Array();
            for (var i = 0; i < str.split(',').length; i++) {
                var num = zxhz(str.split(',')[i], "zx3");
                for (var j = 0; j < num.split(',').length; j++) {
                    arr[j] = num.split(",")[j];
                }
                //去除重复
                var arrStr = RemoveDuplicate(arr);
                zhushu += arrStr.length;
                
            }
            add(type, str, zhushu);
        }
        //组选三手动输入
        if ($("input[name='b']:checked").val() == "zx3sd") {
            if ($("#tb_ManualInput").val() == "" || $("#tb_ManualInput").val() == null) {
                alert('请您复制或是输入号码');
                return false;
            }
            for (i = 0; i < str.split(',').length; i++) {
                var value = "";
                var text = "";
                value = "3|" + str.split(',')[i];
                text = "[组选三] " + str.split(',')[i];
                writeselect(text, value + "|" + 1);

                zhushu++;
            }
        }
        document.getElementById("tb_ManualInput").value = "";
    }
    //组选6
    if (type == "zl") {
        //普通选号
        if ($("input[name='c']:checked").val() == "zx6p") {
            //判断是否选择了 3个号码
            if (str.length < 3) {
                alert('至少选择3个号码');
                return false;
            }
            //处理后的组选6号码
            var Ttext = zx6Val(str);
            if (str.length == 3) {
                add("zux", Ttext, 1);
            }
            else {
                zhushu = Ttext.split(',').length;
                add(type, str, zhushu);
            }
        }
        //组选六 和值选号
        if ($("input[name='c']:checked").val() == "zx6hz") {
            if (str == "") {
                alert('请您选择一个和值号码');
                return false;
            }
            var arr = new Array();
            for (var i = 0; i < str.split(',').length; i++) {
                var num = zxhz(str.split(',')[i], "zx6");
                for (var j = 0; j < num.split(',').length; j++) {
                    arr[j] = num.split(",")[j];
                }
                //去除重复
                var arrStr = RemoveDuplicate(arr);
                zhushu += arrStr.length;
            }
            add(type,str,zhushu);
        }
        //组选六 手动输入
        if ($("input[name='c']:checked").val() == "zx6sd") {
            if ($("#tb_ManualInput").val() == "" || $("#tb_ManualInput").val() == null) {
                alert('请您复制或是输入号码');
                return false;
            }
            for (i = 0; i < str.split(',').length; i++) {
                var value = "";
                var text = "";
                value = "6|" + str.split(',')[i];
                text = "[组选六] " + str.split(',')[i];
                writeselect(text, value + "|" + 1);

                zhushu++;
            }
        }
        document.getElementById("tb_ManualInput").value = "";
    }
    return zhushu;
}
//向号码拦内添加数据
function add(type, str, zhushu) {
    var value = "";
    var text = "";
    if (type == "zx") {
        //和值
        if ($("input[name='a']:checked").val() == "dt") {
            value = "S1|" + str;
            text = "[直选和值] " + str;
            writeselect(text, value + "|" + zhushu);
        }
        else {
            value = "1|" + str;
            text = "[直选] " + str;
            writeselect(text, value + "|" + zhushu);
        }
    }
    if (type == "zux") {
        //和值
        if ($("input[name='a']:checked").val() == "dt") {
            value = "S9|" + str;
            text = "[组选和值] " + str;
            writeselect(text, value + "|" + zhushu);
        }
        else {
            value = "6|" + str;
            text = "[组选] " + str;
            writeselect(text, value + "|" + zhushu);
        }
    }
    if (type == "z3bh") {
        if ($("input[name='b']:checked").val() == "zx3h") {
            value = "S3|" + str;
            text = "[组三和值] " + str;
            writeselect(text, value + "|" + zhushu);
        }
        else {
            value = "F3|" + str;
            text = "[组三包号] " + str;
            writeselect(text, value + "|" + zhushu);
        }
    }
    if (type == "zl") {

        if ($("input[name='c']:checked").val() == "zx6hz") {
            value = "S6|" + str;
            text = "[组六和值] " + str;
            writeselect(text, value + "|" + zhushu);
        }
        else {
            value = "F6|" + str;
            text = "[组六包号] " + str;
            writeselect(text, value + "|" + zhushu);
        }
    }

}

function writeselect(text, value) {		//写入号码栏
    try {
        var temp = document.getElementById("schemeNum"); 	//取得号码栏的下拉菜单
        var Inab = temp.length - 1; 							//判断长度
        temp.options[Inab + 1] = new Option(text, value); 	//写入值
        clearall();
    } catch (e) { }
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
    DisNum();
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
    for (i = 1; i <= 3; i++) {
        var haoma = document.getElementsByName("three_haoma" + i);
        for (j = 0; j < haoma.length; j++) {

            if (haoma[j].className != "number") {
                haoma[j].className = "number";
            }
        }
    }
    //清除直选和值号码区 hezhi_haoma
    var haoma3 = document.getElementsByName("hezhi_haoma");
    for (i = 0; i < haoma3.length; i++) {
        if (haoma3[i].className != "number") {
            haoma3[i].className = "number";
        }
    }
    //清除组选三、和值号码区  zx_haoma
    var haoma1 = document.getElementsByName("zx_haoma");
    for (i = 0; i < haoma1.length; i++) {
        if (haoma1[i].className != "number") {
            haoma1[i].className = "number";
        }
    }
    //清除组选六和值号码区 zx6_haoma
    var haoma4 = document.getElementsByName("zx6_haoma");
    for (i = 0; i < haoma4.length; i++) {
        if (haoma4[i].className != "number") {
            haoma4[i].className = "number";
        }
    }


    //清除组选三、组选六选号区
    var haoma2 = document.getElementsByName("three_haoma5");
    for (i = 0; i < haoma2.length; i++) {
        if (haoma2[i].className != "number") {
            haoma2[i].className = "number";
        }
    }

    //    Show();
    document.getElementById("danbeizhushu").innerHTML = 0;
    document.getElementById("danbeimoney").innerHTML = 0;
    return;
}
//添加号码
function Insert() {
    //选号计算
    var obj = document.getElementsByName("Buytype");
    var typestr = "";
    for (i = 0; i <= obj.length; i++) {
        if (obj[i].checked == true) {
            typestr = obj[i].value;
            break;
        }
    }
    setcode(typestr);
    var str = document.getElementById("code").value;


    var zhushu = getZhushu(str, typestr, "1");

    InsertShow();

}

////机选处理函数
//function jixuan(Strmun) {		//机选函数 /然后通过 随机数重复判断 得到数组	时时乐机选一注为  三个数字
//    if ($("input[name='Buytype']:checked").val() == "zx") {
//        //直选选号投注
//        for (Tmun = 1; Tmun <= Strmun; Tmun++) {
//            var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
//            var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
//            var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
//            var tempmun = new Array(Itmp1, Itmp2, Itmp3); 	//生成数组
//            writeselect("[直选] " + tempmun, "1|" + tempmun + "|1"); 	//写入号码栏
//        }


//    }
//    //组选
//    if ($("input[name='Buytype']:checked").val() == "zux") {
//        var i = 0;
//        for (Tmun = 1; Tmun <= 100; Tmun++) {
//            var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
//            var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
//            var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
//            if (!(Itmp1 == Itmp2 && Itmp1 == Itmp3 && Itmp2 == Itmp3)) {
//                var tempmun = new Array(Itmp1, Itmp2, Itmp3); 	//生成数组
//                writeselect("[组选] " + sort(tempmun), "2|" + tempmun + "|1"); 	//写入号码栏
//                i = i + 1;
//            }
//            if (i == Strmun) {
//                break;
//            }

//        }
//    }
//    //组选三
//    if ($("input[name='Buytype']:checked").val() == "z3bh") {
//        var i = 0;
//        while (9) {
//            var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
//            var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
//            var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
//            if (Itmp1 == Itmp2 || Itmp2 == Itmp3) {
//                if (Itmp1 != Itmp3) {
//                    var tempmun = new Array(Itmp1, Itmp2, Itmp3); 	//生成数组
//                    writeselect("[组选三] " + tempmun, "3|" + tempmun + "|1"); 	//写入号码栏
//                    i++;
//                }
//            }
//            if (i == Strmun) {
//                break;
//            }
//        }

//    }
//    //组选六
//    if ($("input[name='Buytype']:checked").val() == "zl") {
//        var i = 0;
//        while (9) {
//            var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
//            var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
//            var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
//            if (Itmp1 != Itmp2 || Itmp2 != Itmp3) {
//                if (Itmp1 != Itmp3) {
//                    var tempmun = new Array(Itmp1, Itmp2, Itmp3); 	//生成数组
//                    writeselect("[组选六] " + tempmun, "6|" + tempmun + "|1"); 	//写入号码栏
//                    i++;
//                }
//            }
//            if (i == Strmun) {
//                break;
//            }
//        }
//    }
//    InsertShow();
//}

//机选处理函数
function jixuan(Strmun) {		//机选函数 /然后通过 随机数重复判断 得到数组	时时乐机选一注为  三个数字
    //直选选号投注
    for (Tmun = 1; Tmun <= Strmun; Tmun++) {
        var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
        var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
        var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        var tempmun = new Array(Itmp1, Itmp2, Itmp3); 	//生成数组
        add("zx", sort(tempmun), 1); //写入号码栏
    }
    InsertShow();
}
//机选组选处理函数
function jixuan_zx(Strmun) {		//机选函数 /然后通过 随机数重复判断 得到数组	时时乐机选一注为  三个数字
    var i = 0;
    for (Tmun = 1; Tmun <= 100; Tmun++) {
        var Itmp1 = Math.ceil(Math.random() * 10) - 1; //机选第一个数值
        var Itmp2 = Math.ceil(Math.random() * 10) - 1; //机选第二个数值
        var Itmp3 = Math.ceil(Math.random() * 10) - 1; //机选第三个数值
        if (!(Itmp1 == Itmp2 && Itmp1 == Itmp3 && Itmp2 == Itmp3)) {
            var tempmun = new Array(Itmp1, Itmp2, Itmp3); 	//生成数组
            //            writeselect("[组选] " + sort(tempmun), "6|" + tempmun + "|1"); 	//写入号码栏
            add("zux", sort(tempmun), 1);
            i = i + 1;
        }
        if (i == Strmun) {
            break;
        }

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
    //直选
    $(".J_SelectBuyMethod").click(function () {
        $("#pt_1").attr("class", "uchoose");
        $("#hz_1").attr("class", "uchoose");
        $("#sc_1").attr("class", "uchoose");
        $("#sdsr_1").attr("class", "uchoose");
        $("#zxhz1").show();
        $("#zxhz2").show();
        //显示玩法提示
        $("#zxPrompt").html(" 玩法提示：所选号码与开奖号码相同（且顺序一致）即中1000元");
        //切换选号还是上传
        if ($("input[name='a']:checked").val() == "shangchuan") {
            $("#sc_1").attr("class", "choose");
            document.getElementById("zx_upload").style.display = "block";
            document.getElementById("touzhushow1").style.display = "none";

        }
        if ($("input[name='a']:checked").val() == "zixuan") {
            $("#pt_1").attr("class", "choose");
            document.getElementById("zx_upload").style.display = "none";
            document.getElementById("touzhushow1").style.display = "block";
            //隐藏输入框
            document.getElementById("sdsrh").style.display = "none";
            //显示选号
            document.getElementById("xuanqiu").style.display = "block";
            //显示文字
            document.getElementById("szhd").style.display = "block";

            //隐藏直选和值
            document.getElementById("touzhushow3").style.display = "none";

            $("#Prompt").html("每位至少选择一个号码");
            $("#danbeizhushu").html(0);
            $("#danbeimoney").html(0);

        }
        if ($("input[name='a']:checked").val() == "sdsr") {
            $("#sdsr_1").attr("class", "choose");
            //点击手动输入
            document.getElementById("sdsrh").style.display = "block";
            document.getElementById("xuanqiu").style.display = "none";
            //隐藏文字
            document.getElementById("szhd").style.display = "none";

            document.getElementById("touzhushow1").style.display = "block";

            //隐藏直选和值
            document.getElementById("touzhushow3").style.display = "none";
        }
        if ($("input[name='a']:checked").val() == "dt") {
            if ($("input[name='Buytype']:checked").val() == "zux") {
                $("#zxhz1").hide();
                $("#zxhz2").hide();
                //选择组选和值 提示说明
                $("#zxPrompt").html("玩法提示：所选号码与开奖号码相同（且顺序一致）奖金1000元 <font color='red'>特别提示：排三组选和值不包含豹子号。例：和值24中不包含 888</font>");
            }

            $("#hz_1").attr("class", "choose");
            document.getElementById("zx_upload").style.display = "none";
            document.getElementById("touzhushow1").style.display = "block";
            //隐藏输入框
            document.getElementById("sdsrh").style.display = "none";
            //显示选号
            document.getElementById("xuanqiu").style.display = "none";
            //显示文字
            document.getElementById("szhd").style.display = "block";

            //显示直选和值
            document.getElementById("touzhushow3").style.display = "block";
            //通过个、十、百位的数字和值进行组合投注
            $("#Prompt").html(" ");
            $("#danbeizhushu").html(0);
            $("#danbeimoney").html(0);
        }

    });

    //组选3
    $(".J_zx3").click(function () {

        $("#Span1").attr("class", "uchoose");
        $("#Span2").attr("class", "uchoose");
        $("#Span3").attr("class", "uchoose");
        $("#Span4").attr("class", "uchoose");

        //普通选号
        if ($("input[name='b']:checked").val() == "zx3p") {

            $("#Span1").attr("class", "choose");
            $("#Prompt").html("最少选择2个号码");
            document.getElementById("sdsrh").style.display = "none";
            document.getElementById("zxhm").style.display = "block";
            document.getElementById("z3hzxh").style.display = "none";
            $("#danbeizhushu").html(0);
            $("#danbeimoney").html(0);
        }
        //和值
        if ($("input[name='b']:checked").val() == "zx3h") {
            
            $("#Span2").attr("class", "choose");
            //最少选择一个号码
            $("#Prompt").html(" ");
            document.getElementById("z3hzxh").style.display = "block";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "none";
            $("#danbeizhushu").html(0);
            $("#danbeimoney").html(0);
        }
        //手动上传
        if ($("input[name='b']:checked").val() == "zx3sd") {
            $("#Span4").attr("class", "choose");
            document.getElementById("z3hzxh").style.display = "none";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "block";
            $("#Prompt").html("");
        }
    });
    //组选6
    $(".J_zx6").click(function () {
        $("#Span5").attr("class", "uchoose");
        $("#Span6").attr("class", "uchoose");
        $("#Span7").attr("class", "uchoose");
        $("#Span8").attr("class", "uchoose");
        //普通选号
        if ($("input[name='c']:checked").val() == "zx6p") {
            $("#Span5").attr("class", "choose");
            $("#Prompt").html("最少选择3个号码");
            document.getElementById("zxhm").style.display = "block";
            document.getElementById("xhz6").style.display = "none";
            document.getElementById("sdsrh").style.display = "none";
            $("#danbeizhushu").html(0);
            $("#danbeimoney").html(0);
        }
        //和值
        if ($("input[name='c']:checked").val() == "zx6hz") {
            $("#Span6").attr("class", "choose");
            //最少选择一个号码
            $("#Prompt").html(" ");
            document.getElementById("xhz6").style.display = "block";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "none";
            $("#danbeizhushu").html(0);
            $("#danbeimoney").html(0);
        }
        //手动上传
        if ($("input[name='c']:checked").val() == "zx6sd") {
            $("#Span8").attr("class", "choose");
            document.getElementById("xhz6").style.display = "none";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "block";
            $("#Prompt").html("");
        }
    });
});


//切换选项清除号码
function Eclear(obj) {
    //    clearNum();
    $("#zxid").attr("class", "uchoose");
    $("#zuxid").attr("class", "uchoose");
    $("#z3id").attr("class", "uchoose");
    $("#z6id").attr("class", "uchoose");

    //显示选号区
    if (obj == 'zx' || obj == "zux") {
        
        if (obj == 'zx') {
            $("#zxhz1").show();
            $("#zxhz2").show();
            $("#zxid").attr("class", "choose");
            //显示玩法提示
            $("#zxPrompt").html(" 玩法提示：所选号码与开奖号码相同（且顺序一致）即中1000元");
        }
        if (obj == 'zux') {
            $("#zxhz1").hide();
            $("#zxhz2").hide();
            $("#zuxid").attr("class", "choose");
            //显示玩法提示
            $("#zxPrompt").html(" 玩法提示：所选号码与开奖号码相同（且顺序一致）即中320和160元");
        }
        //直选
        document.getElementById("zxxq").style.display = "none";
        document.getElementById("xuanqiu").style.display = "block";
        document.getElementById("zxhm").style.display = "none";
        document.getElementById("zx3").style.display = "none";
        //直选
        document.getElementById("J_subnav").style.display = "block";
        //组选6
        document.getElementById("zx6").style.display = "none";
        //切换选号还是上传
        if ($("input[name='a']:checked").val() == "shangchuan") {
            document.getElementById("zx_upload").style.display = "block";
            document.getElementById("touzhushow1").style.display = "none";

        }
        if ($("input[name='a']:checked").val() == "zixuan") {
            
            document.getElementById("zx_upload").style.display = "none";
            document.getElementById("touzhushow1").style.display = "block";
            //隐藏输入框
            document.getElementById("sdsrh").style.display = "none";
            //显示选号
            document.getElementById("xuanqiu").style.display = "block";
            //显示文字
            document.getElementById("szhd").style.display = "block";

            //隐藏直选和值
            document.getElementById("touzhushow3").style.display = "none";

            $("#Prompt").html("每位至少选择一个号码");

        }
        if ($("input[name='a']:checked").val() == "sdsr") {
            //点击手动输入
            document.getElementById("sdsrh").style.display = "block";
            document.getElementById("xuanqiu").style.display = "none";
            //隐藏文字
            document.getElementById("szhd").style.display = "none";

            document.getElementById("touzhushow1").style.display = "block";

            //隐藏直选和值
            document.getElementById("touzhushow3").style.display = "none";
        }
        if ($("input[name='a']:checked").val() == "dt") {

            //显示玩法提示
            $("#zxPrompt").html(" 玩法提示：所选号码与开奖号码相同（且顺序一致）即中1000元<font color='red'> 特别提示：排三组选和值不包含豹子号。例：和值24中不包含 888</font>");

            document.getElementById("zx_upload").style.display = "none";
            document.getElementById("touzhushow1").style.display = "block";
            //隐藏输入框
            document.getElementById("sdsrh").style.display = "none";
            //显示选号
            document.getElementById("xuanqiu").style.display = "none";
            //显示文字
            document.getElementById("szhd").style.display = "block";

            //显示直选和值
            document.getElementById("touzhushow3").style.display = "block";
            //通过个、十、百位的数字和值进行组合投注
            $("#Prompt").html(" ");
        }

    }
    if (obj == "z3bh") {
        $("#z3id").attr("class", "choose");
        //组选3 6
        document.getElementById("zxxq").style.display = "block";
        document.getElementById("xuanqiu").style.display = "none";
        document.getElementById("zxhm").style.display = "block";
        document.getElementById("touzhushow3").style.display = "none";

        //显示玩法提示
        $("#zxPrompt").html("玩法提示：所选号码与开奖号码相同(顺序不限)，且有任意两位相同，奖金320元");
        //组选3
        $("#zxh").html("组选三选号：");

        document.getElementById("zx3").style.display = "block";
        //直选
        document.getElementById("J_subnav").style.display = "none";
        //组选6
        document.getElementById("zx6").style.display = "none";
        //手动输入框
        document.getElementById("sdsrh").style.display = "none";

        //组选6和值区
        document.getElementById("xhz6").style.display = "none";

        //普通选号
        if ($("input[name='b']:checked").val() == "zx3p") {
            $("#Prompt").html("至少选择2个号码球");
            document.getElementById("sdsrh").style.display = "none";
            document.getElementById("zxhm").style.display = "block";
            document.getElementById("z3hzxh").style.display = "none";
        }
        //和值
        if ($("input[name='b']:checked").val() == "zx3h") {
            $("#Prompt").html("至少选择1个号码球");
            document.getElementById("z3hzxh").style.display = "block";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "none";

        }
        //手动上传
        if ($("input[name='b']:checked").val() == "zx3sd") {
            document.getElementById("z3hzxh").style.display = "none";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "block";
            $("#Prompt").html("");
        }
    }
    if (obj == "zl") {
        $("#z6id").attr("class", "choose");
        //组选3 6
        document.getElementById("zxxq").style.display = "block";
        document.getElementById("xuanqiu").style.display = "none";
        document.getElementById("zxhm").style.display = "block";
        document.getElementById("touzhushow3").style.display = "none";

        //显示玩法提示
        $("#zxPrompt").html("玩法提示：所选号码与开奖号码相同（顺序不限）奖金160元");
        //组选6
        $("#zxh").html("组选六选号：");


        //直选
        document.getElementById("J_subnav").style.display = "none";
        //组选3
        document.getElementById("zx3").style.display = "none";

        //组选6
        document.getElementById("zx6").style.display = "block";

        document.getElementById("z3hzxh").style.display = "none";
        //普通选号
        if ($("input[name='c']:checked").val() == "zx6p") {
            $("#Prompt").html("至少选择 3 个号码球 ");
            document.getElementById("zxhm").style.display = "block";
            document.getElementById("xhz6").style.display = "none";
            document.getElementById("sdsrh").style.display = "none";
        }
        //和值
        if ($("input[name='c']:checked").val() == "zx6hz") {
            $("#Prompt").html("至少选择 1 个号码球 ");
            document.getElementById("xhz6").style.display = "block";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "none";
        }
        //手动上传
        if ($("input[name='c']:checked").val() == "zx6sd") {
            document.getElementById("xhz6").style.display = "none";
            document.getElementById("zxhm").style.display = "none";
            document.getElementById("sdsrh").style.display = "block";
            $("#Prompt").html("");
        }
    }


    clearall();
    document.getElementById("tb_ManualInput").value = "";
}