/*擂台全局公用的方法*/

function InsertShow() {	
    var Temp = document.getElementById("schemeNum"); 	//下拉列表变量
    var code = "";
    var Inab = Temp.length - 1
    for (i = 0; i <= Inab; i++) {
        var Ts = Temp.options[i].value;
        if (i == Inab) {
            code = code + Ts;
        }
        else {
            code = code + Ts + ";";
        }

    }
    document.getElementById("fileorcode").value = code;
}



//更改球体样式
function xuanhao(obj) {
    var Cname = obj.className;
    //红球6胆
    if ($("input[name='ssq']:checked").val() == "hq6d") {
        var haoma = document.getElementsByName("haoma_ssq");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb";codstr--; }
        if (codstr <= 5) {
            if (Cname == "gb") {
                obj.className = "rb";
                
            }
            
        }
        else {
            return false;
        }
        

    }
    //红球3胆
    if ($("input[name='ssq']:checked").val() == "hq3d") {
        var haoma = document.getElementsByName("haoma_ssq");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb"; codstr--; }
        if (codstr <3) {
            if (Cname == "gb") {
                obj.className = "rb";
            }

        }
        else {
            return false;
        }

    }
    //杀3红球
    if ($("input[name='ssq']:checked").val() == "s3hq") {
        var haoma = document.getElementsByName("haoma_ssq");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb"; codstr--; }
        if (codstr < 3) {
            if (Cname == "gb") {
                obj.className = "rb";
            }

        }
        else {
            return false;
        }

    }


    //杀6红球
    if ($("input[name='ssq']:checked").val() == "s6hq") {
        var haoma = document.getElementsByName("haoma_ssq");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb"; codstr--; }
        if (codstr < 6) {
            if (Cname == "gb") {
                obj.className = "rb";
            }

        }
        else {
            return false;
        }

    }
    //蓝球1胆
    if ($("input[name='ssq']:checked").val() == "lq1d") {
        var haoma = document.getElementsByName("haoma_ssql");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "bb") {
                codstr++;
            }
        }
        if (Cname == "bb") { obj.className = "gb"; codstr--; }
        if (codstr < 1) {
            if (Cname == "gb") {
                obj.className = "bb";
            }

        }
        else {
            return false;
        }

    }
    //蓝球3胆
    if ($("input[name='ssq']:checked").val() == "lq3d") {
        var haoma = document.getElementsByName("haoma_ssql");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "bb") {
                codstr++;
            }
        }
        if (Cname == "bb") { obj.className = "gb"; codstr--; }
        if (codstr < 3) {
            if (Cname == "gb") {
                obj.className = "bb";
            }

        }
        else {
            return false;
        }

    }
    //杀3蓝球
    if ($("input[name='ssq']:checked").val() == "s3lq") {
        var haoma = document.getElementsByName("haoma_ssql");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "bb") {
                codstr++;
            }
        }
        if (Cname == "bb") { obj.className = "gb"; codstr--; }
        if (codstr < 3) {
            if (Cname == "gb") {
                obj.className = "bb";
            }

        }
        else {
            return false;
        }

    }
    //杀6蓝球
    if ($("input[name='ssq']:checked").val() == "s6lq") {
        var haoma = document.getElementsByName("haoma_ssql");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "bb") {
                codstr++;
            }
        }
        if (Cname == "bb") { obj.className = "gb"; codstr--; }
        if (codstr < 6) {
            if (Cname == "gb") {
                obj.className = "bb";
            }

        }
        else {
            return false;
        }

    }
    //9红+2蓝
    if ($("input[name='ssq']:checked").val() == "h2l") {
        if (obj.id == "ssq_haoma1") {
            var haoma = document.getElementsByName("ssq_haoma1");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 9) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }
            }
            else {
                return false;
            }
        }
        if (obj.id == "ssql_haoma") {
            //蓝球
            var l_haoma = document.getElementsByName("ssql_haoma");
            var codBul = 0;
            for (var i = 0; i < l_haoma.length; i++) {
                if (l_haoma[i].className == "bb") {
                    codBul++;
                }
            }
            if (Cname == "bb") { obj.className = "gb"; codBul--; }
            if (codBul < 2) {
                if (Cname == "gb") {
                    obj.className = "bb";
                }
            }
            else {
                return false;
            }
        }
    }
    //12红+3蓝
    if ($("input[name='ssq']:checked").val() == "h3l") {
        var codstr = 0;
        var haoma = document.getElementsByName("ssq_haoma1");

        if (obj.id == "ssq_haoma1") {
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 12) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "ssql_haoma") {
            //蓝球
            var haomal = document.getElementsByName("ssql_haoma");
            var codBul = 0;
            for (var i = 0; i < haomal.length; i++) {
                if (haomal[i].className == "bb") {
                    codBul++;
                }
            }
            if (Cname == "bb") { obj.className = "gb"; codBul--; }
            if (codBul < 3) {
                if (Cname == "gb") {
                    obj.className = "bb";
                }

            }
            else {
                return false;
            }
        }
    }

    //独胆、杀1码、杀1跨、杀1合、独跨、独合
    if ($("input[name='ssq']:checked").val() == "dd" || $("input[name='ssq']:checked").val() == "s1m" || $("input[name='ssq']:checked").val() == "s1h" || $("input[name='ssq']:checked").val() == "dk" || $("input[name='ssq']:checked").val() == "dh") {

        var haoma = document.getElementsByName("sd_haoma");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb"; codstr--; }
        if (codstr < 1) {
            if (Cname == "gb") {
                obj.className = "rb";
            }

        }
        else {
            return false;
        }
    }
    //双胆、杀2码
    if ($("input[name='ssq']:checked").val() == "sd" || $("input[name='ssq']:checked").val() == "s2m") {
        var haoma = document.getElementsByName("sd_haoma");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb"; codstr--; }
        if (codstr < 2) {
            if (Cname == "gb") {
                obj.className = "rb";
            }

        }
        else {
            return false;
        }
    }
    //5码
    if ($("input[name='ssq']:checked").val() == "m") {
        var haoma = document.getElementsByName("sd_haoma");
        var codstr = 0;
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                codstr++;
            }
        }
        if (Cname == "rb") { obj.className = "gb"; codstr--; }
        if (codstr < 5) {
            if (Cname == "gb") {
                obj.className = "rb";
            }

        }
        else {
            return false;
        }

    }
    //直选1注   组选1注
    if ($("input[name='ssq']:checked").val() == "zx1z" || $("input[name='ssq']:checked").val() == "zx") {
        if (obj.id == "haoma1") {
            var haoma = document.getElementsByName("haoma1");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 1) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "haoma2") {
            var haoma = document.getElementsByName("haoma2");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 1) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "haoma3") {
            var haoma = document.getElementsByName("haoma3");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 1) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
    }
    //5*5*5定位
    if ($("input[name='ssq']:checked").val() == "5dw") {
        if (obj.id == "haoma1") {
            var haoma = document.getElementsByName("haoma1");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr <5) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "haoma2") {
            var haoma = document.getElementsByName("haoma2");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr <5) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "haoma3") {
            var haoma = document.getElementsByName("haoma3");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr <5) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
    }
    //3*3*3定位
    if ($("input[name='ssq']:checked").val() == "3dw") {
        if (obj.id == "haoma1") {
            var haoma = document.getElementsByName("haoma1");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 3) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "haoma2") {
            var haoma = document.getElementsByName("haoma2");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 3) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
        if (obj.id == "haoma3") {
            var haoma = document.getElementsByName("haoma3");
            var codstr = 0;
            for (var i = 0; i < haoma.length; i++) {
                if (haoma[i].className == "rb") {
                    codstr++;
                }
            }
            if (Cname == "rb") { obj.className = "gb"; codstr--; }
            if (codstr < 3) {
                if (Cname == "gb") {
                    obj.className = "rb";
                }

            }
            else {
                return false;
            }
        }
    }

}
//把号码添加到号码栏
function writeselect(text, value) {		//写入号码栏
    try {
        var temp = document.getElementById("schemeNum"); 	//取得号码栏的下拉菜单
        var Inab = temp.length - 1								//判断长度
        temp.options[Inab + 1] = new Option(text, value); 	//写入值

    } catch (e) { }
}

function addto(str) {
    if ($("#lottID").val() == 3) {
        //红球3胆
        if ($("input[name='ssq']:checked").val() == "hq3d") {
            if (str.split(',').length != 3) {
                alert("您选择的号码小于3个");
                return false;
            }
            var text = "[红球3胆] " + str;
            var value = "hq3d|" + str;
            writeselect(text, value);
        }
        //红球6胆
        if ($("input[name='ssq']:checked").val() == "hq6d") {
            if (str.split(',').length != 6) {
                alert("您选择的号码小于6个");
                return false;
            }
            var text = "[红球6胆] " + str;
            var value = "hq6d|" + str;
            writeselect(text, value);
        }
        //杀3红球
        if ($("input[name='ssq']:checked").val() == "s3hq") {
            if (str.split(',').length != 3) {
                alert("您选择的号码小于3个");
                return false;
            }
            var text = "[杀3红球] " + str;
            var value = "s3hq|" + str;
            writeselect(text, value);
        }
        //杀6红球
        if ($("input[name='ssq']:checked").val() == "s6hq") {
            if (str.split(',').length != 6) {
                alert("您选择的号码小于6个");
                return false;
            }
            var text = "[杀6红球] " + str;
            var value = "s6hq|" + str;
            writeselect(text, value);
        }
        //蓝球1胆
        if ($("input[name='ssq']:checked").val() == "lq1d") {
            if (str.split(',').length != 1) {
                alert("请您选择1个蓝球号码");
                return false;
            }
            var text = "[蓝球1胆] " + str;
            var value = "lq1d|" + str;
            writeselect(text, value);
        }

        //蓝球3胆
        if ($("input[name='ssq']:checked").val() == "lq3d") {
            if (str.split(',').length != 3) {
                alert("您选择的号码小于3个");
                return false;
            }
            var text = "[蓝球3胆] " + str;
            var value = "lq3d|" + str;
            writeselect(text, value);
        }
        //杀3蓝球
        if ($("input[name='ssq']:checked").val() == "s3lq") {
            if (str.split(',').length != 3) {
                alert("您选择的号码小于3个");
                return false;
            }
            
            var text = "[杀3蓝球] " + str;
            var value = "s3lq|" + str;
            writeselect(text, value);
        }
        //杀6蓝球
        if ($("input[name='ssq']:checked").val() == "s6lq") {
            if (str.split(',').length != 6) {
                alert("您选择的号码小于6个");
                return false;
            }
            var text = "[杀6蓝球] " + str;
            var value = "s6lq|" + str;
            writeselect(text, value);
        }
        //12红+3蓝
        if ($("input[name='ssq']:checked").val() == "h3l") {
            if (str.split('+')[0].split(',').length != 12 || str.split('+')[1].split(',').length!=3) {
                alert("请您选择12个红球+3个蓝球");
                return false;
            }
            var text = "[12红+3蓝] " + str;
            var value = "h3l|" + str;
            writeselect(text, value);
        }
        //9红+2蓝
        if ($("input[name='ssq']:checked").val() == "h2l") {
            if (str.split('+')[0].split(',').length != 9 || str.split('+')[1].split(',').length != 2) {
                alert("请您选择9个红球+2个蓝球");
                return false;
            }
            var text = "[9红+2蓝] " + str;
            var value = "h2l|" + str;
            writeselect(text, value);
        }
    }
    if ($("#lottID").val() == 1) {
        //独胆
        if ($("input[name='ssq']:checked").val() == "dd") {
            if (str.split(',').length != 1) {
                alert("您选择的号码小于1个");
                return false;
            }
            var text = "[3D][独胆] " + str;
            var value = "dd|" + str;
            writeselect(text, value);
        }
        //双胆
        if ($("input[name='ssq']:checked").val() == "sd") {
            if (str.split(',').length != 2) {
                alert("您选择的号码小于2个");
                return false;
            }
            var text = "[3D][双胆] " + str;
            var value = "sd|" + str;
            writeselect(text, value);
        }
        //组选1注
        if ($("input[name='ssq']:checked").val() == "zx1z") {
            if (str.split(',').length != 3) {
                alert("请选择1注号码");
                return false;
            }
            var arr = new Array();
            for (var i = 0; i < 3; i++) {
                arr[i] = str.split(",")[i];
            }
            var retArr = sort(arr);
            var text = "[3D][组选1注] " + retArr;
            var value = "zx1z|" + retArr;
            writeselect(text, value);
        }
        //杀1码
        if ($("input[name='ssq']:checked").val() == "s1m") {
            if (str.split(',').length != 1) {
                alert("请您选择1个号码");
                return false;
            }
            var text = "[3D][杀1码] " + str;
            var value = "s1m|" + str;
            writeselect(text, value);
        }
        //杀2码
        if ($("input[name='ssq']:checked").val() == "s2m") {
            if (str.split(',').length != 2) {
                alert("您选择的号码小于2个");
                return false;
            }
            var text = "[3D][杀2码] " + str;
            var value = "s2m|" + str;
            writeselect(text, value);
        }
        //独跨
        if ($("input[name='ssq']:checked").val() == "dk") {
            if (str.split(',').length != 1) {
                alert("请您选择1个号码");
                return false;
            }
            var text = "[3D][独跨] " + str;
            var value = "dk|" + str;
            writeselect(text, value);
        }
        //独合
        if ($("input[name='ssq']:checked").val() == "dh") {
            if (str.split(',').length != 1) {
                alert("请您选择1个号码");
                return false;
            }
            var text = "[3D][独合] " + str;
            var value = "dh|" + str;
            writeselect(text, value);
        }
        //杀1合
        if ($("input[name='ssq']:checked").val() == "s1h") {
            if (str.split(',').length != 1) {
                alert("请您选择1个号码");
                return false;
            }
            var text = "[3D][杀1合] " + str;
            var value = "s1h|" + str;
            writeselect(text, value);
        }
        //5*5*5定位
        if ($("input[name='ssq']:checked").val() == "5dw") {
            for (var i = 0; i < 3; i++) {
                if (str.split(',')[i].length != 5) {
                    alert("每个位置都需要选择5个号码");
                    return false;
                }
            }
                var text = "[3D][5*5*5定位] " + str;
            var value = "5dw|" + str;
            writeselect(text, value);
        }
        //3*3*3定位
        if ($("input[name='ssq']:checked").val() == "3dw") {
            for (var i = 0; i < 3; i++) {
                if (str.split(',')[i].length != 3) {
                    alert("每个位置都需要选择3个号码");
                    return false;
                }
            }
            var text = "[3D][3*3*3定位] " + str;
            var value = "3dw|" + str;
            writeselect(text, value);
        }
        //直选1注
        if ($("input[name='ssq']:checked").val() == "zx") {
            if (str.split(',').length != 3) {
                alert('请选择1注号码');
                return false;
            }
            var text = "[3D][直选1注] " + str;
            var value = "zx|" + str;
            writeselect(text, value);
        }
        //5码
        if ($("input[name='ssq']:checked").val() == "m") {
            if (str.split(',').length != 5) {
                alert('请选择5个号码');
                return false;
            }
            var text = "[3D][5码] " + str;
            var value = "m|" + str;
            writeselect(text, value);
        }
    }
    if ($("#lottID").val() == 9999) {
        //独胆
        if ($("input[name='ssq']:checked").val() == "dd") {
            if (str.split(',').length != 1) {
                alert("您选择的号码小于1个");
                return false;
            }
            var text = "[排列三][独胆] " + str;
            var value = "pdd|" + str;
            writeselect(text, value);
        }
        //双胆
        if ($("input[name='ssq']:checked").val() == "sd") {
            if (str.split(',').length != 2) {
                alert("您选择的号码小于2个");
                return false;
            }
            var text = "[排列三][双胆] " + str;
            var value = "psd|" + str;
            writeselect(text, value);
        }
        //组选1注
        if ($("input[name='ssq']:checked").val() == "zx1z") {
            if (str.split(',').length != 3) {
                alert("请选择1注号码");
                return false;
            }
            var arr = new Array();
            for (var i = 0; i < 3; i++) {
                arr[i] = str.split(",")[i];
            }
            var retArr=sort(arr);
            var text = "[排列三][组选1注] " + retArr;
            var value = "pzx1z|" + retArr;
            writeselect(text, value);
        }
        //杀1码
        if ($("input[name='ssq']:checked").val() == "s1m") {
            var text = "[排列三][杀1码] " + str;
            var value = "ps1m|" + str;
            writeselect(text, value);
        }
        //杀2码
        if ($("input[name='ssq']:checked").val() == "s2m") {
            if (str.split(',').length != 2) {
                alert("您选择的号码小于2个");
                return false;
            }
            var text = "[排列三][杀2码] " + str;
            var value = "ps2m|" + str;
            writeselect(text, value);
        }
        //独跨
        if ($("input[name='ssq']:checked").val() == "dk") {
            if (str.split(',').length != 1) {
                alert("请选择1个号码");
                return false;
            }
            var text = "[排列三][独跨] " + str;
            var value = "pdk|" + str;
            writeselect(text, value);
        }
        //独合
        if ($("input[name='ssq']:checked").val() == "dh") {
            if (str.split(',').length != 1) {
                alert("请选择1个号码");
                return false;
            }
            var text = "[排列三][独合] " + str;
            var value = "pdh|" + str;
            writeselect(text, value);
        }
        //杀1合
        if ($("input[name='ssq']:checked").val() == "s1h") {
            if (str.split(',').length != 1) {
                alert("请选择1个号码");
                return false;
            }
            var text = "[排列三][杀1合] " + str;
            var value = "ps1h|" + str;
            writeselect(text, value);
        }
        //5*5*5定位
        if ($("input[name='ssq']:checked").val() == "5dw") {
            for (var i = 0; i < 3; i++) {
                if (str.split(',')[i].length != 5) {
                    alert("每个位置都需要选择5个号码");
                    return false;
                }
            }
            var text = "[排列三][5*5*5定位] " + str;
            var value = "p5dw|" + str;
            writeselect(text, value);
        }
        //3*3*3定位
        if ($("input[name='ssq']:checked").val() == "3dw") {
            for (var i = 0; i < 3; i++) {
                if (str.split(',')[i].length != 3) {
                    alert("每个位置都需要选择3个号码");
                    return false;
                }
            }
            var text = "[排列三][3*3*3定位] " + str;
            var value = "p3dw|" + str;
            writeselect(text, value);
        }
        //直选1注
        if ($("input[name='ssq']:checked").val() == "zx") {
            if (str.split(',').length != 3) {
                alert("请选择1注号码");
                return false;
            }
            var text = "[排列三][直选1注] " + str;
            var value = "pzx|" + str;
            writeselect(text, value);
        }
        //5码
        if ($("input[name='ssq']:checked").val() == "m") {
            if (str.split(',').length != 5) {
                alert("您选择的号码不足5个");
                return false;
            }
            var text = "[排列三][5码] " + str;
            var value = "p5m|" + str;
            writeselect(text, value);
        }
    }
}

//验证包含的关系  value 选择的号码  用，号隔开
function Belong(value) {
    var n_Record = 0;
    //判断是否已经有选择是值
    if ($("#fileorcode").val() != "" || $("#fileorcode").val() != null) { 
        
        //保存条件的数组
        var arr=new Array();

        //保存号码的数组
        var arrN=new Array();

        var n_StrNum=$("#fileorcode").val();
        for(var i=0;i<n_StrNum.split(';').length;i++)
        {
            //获取条件名称
            arr[i]= n_StrNum.split(';')[i].split('|')[0];
            //获取号码
            arrN[i]= n_StrNum.split(';')[i].split('|')[1];
        }
        
        //红球3胆 
        if ($("input[name='ssq']:checked").val() == "hq3d") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "hq3d") {
                    n_Record = 1;
                    alert('您已经添加过红球3胆');
                    return n_Record;
                }
                if (arr[i] == "hq6d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 3) {
                        alert('您选择的号码必须包含在[红球6胆(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;
                        
                    }
                }
                if (arr[i] == "s3hq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num >0) {
                        alert('红球3胆中的号码不能包括[杀3红球(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num !=3) {
                        alert('红球3胆中的号码必须包括在[12红+3蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num != 3) {
                        alert('红球3胆中的号码必须包括在[9红+2蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //红球6胆  必须包含3胆的号
        if ($("input[name='ssq']:checked").val() == "hq6d") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "hq6d") {
                    n_Record = 1;
                    alert('您已经添加过红球6胆');
                    return n_Record;
                }
                if (arr[i] == "hq3d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num < 3) {
                        alert('您选择的号码必须包含[红球3胆(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s3hq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('红球6胆中的号码不能包括[杀3红球(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s6hq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('红球6胆中的号码不能包括[杀6红球(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num != 6) {
                        alert('红球6胆中的号码必须包括在[12红+3蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num != 6) {
                        alert('红球6胆中的号码必须包括在[9红+2蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //杀3红球 
        if ($("input[name='ssq']:checked").val() == "s3hq") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s3hq") {
                    n_Record = 1;
                    alert('您已经添加过杀3红球');
                    return n_Record;
                }
                if (arr[i] == "s6hq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num !=3 ) {
                        alert('您选择的号码必须包含在[杀6红球(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "hq3d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀3红球中的号码不能包括[红球3胆(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "hq6d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀3红球中的号码不能包括[红球6胆(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num >0) {
                        alert('杀3红球中的号码不能包括[12红+3蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num >0) {
                        alert('杀3红球中的号码不能包括[9红+2蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                
            }
        }

        //杀6红球 必须包含杀3红球 
        if ($("input[name='ssq']:checked").val() == "s6hq") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s6hq") {
                    n_Record = 1;
                    alert('您已经添加过杀6红球');
                    return n_Record;
                }
                if (arr[i] == "s3hq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num <3) {
                        alert('您选择的号码必须包含[杀3红球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "hq3d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀6红球中的号码不能包括[红球3胆(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "hq6d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀6红球中的号码不能包括[红球6胆(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num >0) {
                        alert('杀6红球中的号码不能包括[12红+3蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[0]);
                    if (n_num >0) {
                        alert('杀6红球中的号码不能包括[9红+2蓝的红球号码(' + arrN[i].split('+')[0] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }

        //蓝球1胆 
        if ($("input[name='ssq']:checked").val() == "lq1d") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "lq1d") {
                    n_Record = 1;
                    alert('您已经添加过蓝球1胆');
                    return n_Record;
                }
                if (arr[i] == "lq3d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num !=1) {
                        alert('您选择的号码必须包含在[蓝球3胆(' + arrN[i] + ')]的号码中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s3lq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num >0 ) {
                        alert('蓝球1胆中不能包含[杀3蓝球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s6lq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('蓝球1胆中不能包含[杀6蓝球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num != 1) {
                        alert('蓝球1胆中的号码必须包括[12红+3蓝的蓝球号码(' + arrN[i].split('+')[1] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num != 1) {
                        alert('蓝球1胆中的号码必须包括在[9红+2蓝的蓝球(' + arrN[i].split('+')[1] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }

        //蓝球3胆 必须包含蓝球1胆的号码
        if ($("input[name='ssq']:checked").val() == "lq3d") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "lq3d") {
                    n_Record = 1;
                    alert('您已经添加过蓝球3胆');
                    return n_Record;
                }
                if (arr[i] == "lq1d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num < 1) {
                        alert('您选择的号码必须包含[蓝球1胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s3lq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('蓝球3胆中不能包含[杀3蓝球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s6lq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('蓝球3胆中不能包含[杀6蓝球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num != 3) {
                        alert('蓝球3胆中的号码必须包括在[12红+3蓝的蓝球号码(' + arrN[i].split('+')[1] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num != 2) {
                        alert('蓝球3胆中的号码必须包括在[9红+2蓝的蓝球号码(' + arrN[i].split('+')[1] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }

        //杀3蓝球
        if ($("input[name='ssq']:checked").val() == "s3lq") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s3lq") {
                    n_Record = 1;
                    alert('您已经添加过杀3蓝球');
                    return n_Record;
                }
                if (arr[i] == "s6lq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num !=3) {
                        alert('您选择的号码必须包含在[杀6蓝球(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "lq1d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀3蓝球中不能包含[蓝球1胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "lq3d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀3蓝球中不能包含[蓝球3胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num >0) {
                        alert('杀3蓝球中的号码不能包括[12红+3蓝中蓝球的号码(' + arrN[i].split('+')[1] + ')]');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num >0) {
                        alert('杀3蓝球中的号码不能包括[9红+2蓝中的蓝球号码(' + arrN[i].split('+')[1] + ')]');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }

        //杀6蓝球  必须包含杀3蓝球
        if ($("input[name='ssq']:checked").val() == "s6lq") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s6lq") {
                    n_Record = 1;
                    alert('您已经添加过杀6蓝球');
                    return n_Record;
                }
                if (arr[i] == "s3lq") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num < 3) {
                        alert('您选择的号码必须包含[杀3蓝球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "lq1d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀6蓝球中不能包含[蓝球1胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "lq3d") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('杀6蓝球中不能包含[蓝球3胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num >0) {
                        alert('杀3蓝球中的号码不能包括[12红+3蓝中蓝球的号码(' + arrN[i].split('+')[1] + ')]');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value, arrN[i].split('+')[1]);
                    if (n_num >0) {
                        alert('杀3蓝球中的号码不能包括[9红+2蓝中的蓝球号码(' + arrN[i].split('+')[1] + ')]');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //12红+3蓝  红球必须包含胆红球    蓝球必须包含胆蓝球
        if ($("input[name='ssq']:checked").val() == "h3l") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "h3l") {
                    n_Record = 1;
                    alert('您已经添加过12红+3蓝');
                    return n_Record;
                }
                //包含9红+2蓝
                if (arr[i] == "h2l") {
                    var n_num = Comparison(value.split('+')[0], arrN[i].split('+')[0]);

                    var n_bnum = Comparison(value.split('+')[1], arrN[i].split('+')[1]);
                    if (n_num < 9 && n_bnum < 2) {
                        alert('您选择的号码必须包含[9红+2蓝(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "hq6d") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num != 6) {
                        alert('您选择的红球号码必须包含[红球6胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "hq3d") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num != 3) {
                        alert('您选择的红球号码必须包含[红球3胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s6hq") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num >1) {
                        alert('您选择的红球号码不能包含[杀6红球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s3hq") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num > 1) {
                        alert('您选择的红球号码不能包含[杀3红球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }

                if (arr[i] == "lq3d") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num != 3) {
                        alert('您选择的红球号码必须包含[蓝球3胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "lq1d") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num != 1) {
                        alert('您选择的红球号码必须包含[蓝球1胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s3lq") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的蓝球号码不能包含[杀3蓝球(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s6lq") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的蓝球号码不能包含[杀6蓝球(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;
                    }
                }
                
            }
        }

        //9红+2蓝  红球必须包含胆红球    蓝球必须包含胆蓝球 包含在12红+3蓝中
        if ($("input[name='ssq']:checked").val() == "h2l") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "h2l") {
                    n_Record = 1;
                    alert('您已经添加过9红+2蓝');
                    return n_Record;
                }
                if (arr[i] == "hq6d") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num != 6) {
                        alert('您选择的红球号码必须包含[红球6胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "hq3d") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num != 3) {
                        alert('您选择的红球号码必须包含[红球3胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }

                if (arr[i] == "s6hq") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num > 1) {
                        alert('您选择的红球号码不能包含[杀6红球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s3hq") {
                    var n_num = Comparison(value.split('+')[0], arrN[i]);
                    if (n_num > 1) {
                        alert('您选择的红球号码不能包含[杀3红球(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }

                if (arr[i] == "lq3d") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num != 2) {
                        alert('您选择的蓝球号码必须包含在[蓝球3胆(' + arrN[i] + ')]中，并请选择2个蓝球号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "lq1d") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num != 1) {
                        alert('您选择的蓝球号码必须包含[蓝球1胆(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                //包含在12红+3蓝 中
                if (arr[i] == "h3l") {
                    var n_num = Comparison(value.split('+')[0], arrN[i].split('+')[0]);

                    var n_bnum = Comparison(value.split('+')[1], arrN[i].split('+')[1]);
                    if (n_num != 9 && n_bnum != 2) {
                        alert('您选择的号码必须包含在[12红+3蓝(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s3lq") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的蓝球号码不能包含[杀3蓝球(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s6lq") {
                    var n_num = Comparison(value.split('+')[1], arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的蓝球号码不能包含[杀6蓝球(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;
                    }
                }
            }
        }
       /****************3D 、排列3**********************/
        //独胆  
        if ($("input[name='ssq']:checked").val() == "dd") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "dd" || arr[i] == "pdd") {
                    n_Record = 1;
                    alert('您已经添加过独胆');
                    return n_Record;
                }
                if (arr[i] == "sd" || arr[i] == "pdd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num !=1) {
                        alert('您选择的号码必须包含在[双胆(' + arrN[i] + ')]的号码中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx1z" || arr[i] == "pzx1z") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 1) {
                        alert('您选择的号码必须包含在[组选1注(' + arrN[i] + ')]的号码中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s1m" || arr[i] == "ps1m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num >0) {
                        alert('选择的号码不能包含在[杀1码(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[杀2码(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //双胆
        if ($("input[name='ssq']:checked").val() == "sd") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "sd" || arr[i] == "psd") {
                    n_Record = 1;
                    alert('您已经添加过双胆');
                    return n_Record;
                }
                if (arr[i] == "dd" || arr[i] == "pdd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 1) {
                        alert('您选择的号码必须包含[独胆(' + arrN[i] + ')]号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx1z" || arr[i] == "pzx1z") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 2) {
                        alert('您选择的号码必须包含在[组选1注(' + arrN[i] + ')]的号码中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s1m" || arr[i] == "ps1m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('选择的号码不能包含在[杀1码(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[杀2码(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //组选1注
        if ($("input[name='ssq']:checked").val() == "zx1z") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "zx1z" || arr[i] == "pzx1z") {
                    n_Record = 1;
                    alert('您已经添加过组选1注');
                    return n_Record;
                }
                if (arr[i] == "dd" || arr[i] == "pdd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num < 1) {
                        alert('您选择的号码必须包含[独胆(' + arrN[i] + ')]号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "sd" || arr[i] == "psd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num < 2) {
                        alert('您选择的号码必须包含[双胆(' + arrN[i] + ')]号码');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //杀1码
        if ($("input[name='ssq']:checked").val() == "s1m") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s1m" || arr[i] == "ps1m") {
                    n_Record = 1;
                    alert('您已经添加过杀1码');
                    return n_Record;
                }
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 1) {
                        alert('您选择的号码必须包含在[杀2码(' + arrN[i] + ')]的号码中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "dd" || arr[i] == "pdd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num >0) {
                        alert('您选择的号码不能包含在[独胆(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "sd" || arr[i] == "psd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[双胆(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx1z" || arr[i] == "pzx1z") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[组选1注(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx" || arr[i] == "pzx") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[直选1注(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }

        //杀2码
        if ($("input[name='ssq']:checked").val() == "s2m") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    n_Record = 1;
                    alert('您已经添加过杀2码');
                    return n_Record;
                }
                if (arr[i] == "s1m" || arr[i] == "ps1m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 1) {
                        alert('您选择的号码必须包含[杀1码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "dd" || arr[i] == "pdd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[独胆(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "sd" || arr[i] == "psd") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[双胆(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx1z" || arr[i] == "pzx1z") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[组选1注(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx" || arr[i] == "pzx") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[直选1注(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //杀1合
        if ($("input[name='ssq']:checked").val() == "s1h") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "s1h" || arr[i] == "ps1h") {
                    n_Record = 1;
                    alert('您已经添加过杀1合');
                    return n_Record;
                }
                if (arr[i] == "dh" || arr[i] == "pdh") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num >0) {
                        alert('您选择的号码不能包含在[独合(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }
        //独合
        if ($("input[name='ssq']:checked").val() == "dh") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "dh" || arr[i] == "pdh") {
                    n_Record = 1;
                    alert('您已经添加过独合');
                    return n_Record;
                }
                if (arr[i] == "s1h" || arr[i] == "ps1h") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含在[杀1合(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
            }
        }

        //5*5*5定位
        if ($("input[name='ssq']:checked").val() == "5dw") {
            var num = 0;
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "5dw" || arr[i] == "p5dw") {
                    n_Record = 1;
                    alert('您已经添加过5*5*5定位');
                    return n_Record;
                }
                if (arr[i] == "3dw" || arr[i] == "p3dw") {
                    num = 0;
                    for (var j = 0; j < 3; j++) {
                        var NewValue = ""; 
                        var Newarr="";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k,1)+",";
                        }
                        for (var k = 0; k < arrN[i].split(',')[j].length; k++) {
                            Newarr += arrN[i].split(',')[j].substr(k, 1)+",";
                        }
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), Newarr.substr(0, Newarr.length - 1));
                        num = num + n_num;
                    }
                    // 百位3个   十位 3个  个位3个 
                    if (num!=9) {
                        alert('您选择的号码必须包含[3*3*3定位(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx" || arr[i] == "pzx") {
                    num = 0;
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }

                        Newarr = arrN[i].split(',')[j];
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), Newarr);
                        num = num + n_num;
                    }
                    // 百位3个   十位 3个  个位3个 
                    if (num != 3) {
                        alert('您选择的号码必须包含[直选1注(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s1m" || arr[i] == "ps1m") {
                    num = 0;
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), arrN[i]);
                        num = num + n_num;
                    }
                    if (num > 0) {
                        alert('您选择的号码不能包含[杀1码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    num = 0;
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), arrN[i]);
                        num = num + n_num;

                    }
                    if (num > 0) {
                        alert('您选择的号码不能包含[杀2码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
            }
        }
        //3*3*3定位
        if ($("input[name='ssq']:checked").val() == "3dw") {
            var num = 0;
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "3dw" || arr[i] == "p3dw") {
                    n_Record = 1;
                    alert('您已经添加过3*3*3定位');
                    return n_Record;
                }
                if (arr[i] == "5dw" || arr[i] == "p5dw") {
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }
                        for (var k = 0; k < arrN[i].split(',')[j].length; k++) {
                            Newarr += arrN[i].split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), Newarr.substr(0, Newarr.length - 1));
                        num = num + n_num;
                    }
                    // 百位3个   十位 3个  个位3个 
                    if (num != 9) {
                        alert('您选择的号码必须包含在[5*5*5定位(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "zx" || arr[i] == "pzx") {
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }

                        Newarr = arrN[i].split(',')[j];
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), Newarr);
                        num = num + n_num;
                    }
                    // 百位3个   十位 3个  个位3个 
                    if (num != 3) {
                        alert('您选择的号码必须包含[直选1注(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s1m" || arr[i]=="ps1m") {
                    num = 0;
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), arrN[i]);
                        num = num + n_num;
                    }
                    if (num > 0) {
                        alert('您选择的号码不能包含[杀1码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s2m" || arr[i]=="ps2m") {
                    num = 0;
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        for (var k = 0; k < value.split(',')[j].length; k++) {
                            NewValue += value.split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue.substr(0, NewValue.length - 1), arrN[i]);
                        num = num + n_num;

                    }
                    if (num > 0) {
                        alert('您选择的号码不能包含[杀2码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
            }
        }

        //直选1注 
        if ($("input[name='ssq']:checked").val() == "zx") {
            var num = 0;
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "zx" || arr[i] == "pzx") {
                    n_Record = 1;
                    alert('您已经添加过直选1注');
                    return n_Record;
                }

                if (arr[i] == "3dw" || arr[i] == "p3dw") {
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        NewValue = value.split(',')[j];
                        for (var k = 0; k < arrN[i].split(',')[j].length; k++) {
                            Newarr += arrN[i].split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue, Newarr.substr(0, Newarr.length - 1));
                        num = num + n_num;
                    }
                    // 百位3个   十位 3个  个位3个 
                    if (num != 3) {
                        alert('您选择的号码必须包含在[3*3*3定位(' + arrN[i] + ')]中');
                        n_Record = 1;
                        break;

                    }
                    num = 0;
                }
                if (arr[i] == "5dw" || arr[i] == "p5dw") {
                    for (var j = 0; j < 3; j++) {
                        var NewValue = "";
                        var Newarr = "";
                        //重组号码
                        NewValue = value.split(',')[j];
                        for (var k = 0; k < arrN[i].split(',')[j].length; k++) {
                            Newarr += arrN[i].split(',')[j].substr(k, 1) + ",";
                        }
                        var n_num = Comparison(NewValue, Newarr.substr(0, Newarr.length - 1));
                        num = num + n_num;
                    }
                    // 百位3个   十位 3个  个位3个 
                    if (num != 3) {
                        alert('您选择的号码必须包含在[5*5*5定位(' + arrN[i] + ')]中');
                        n_Record = 1;
                        num = 0;
                        break;

                    }
                }
                if (arr[i] == "s1m" || arr[i] == "ps1m") {
                    num = 0;
                    var n_num = Comparison(value, arrN[i]);
                    num = num + n_num;
                    if (num > 0) {
                        alert('您选择的号码不能包含[杀1码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    num = 0;

                    var n_num = Comparison(value, arrN[i]);
                    num = num + n_num;
                    if (num > 0) {
                        alert('您选择的号码不能包含[杀2码(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;
                    }
                }
            }
        }
        //5码
        if ($("input[name='ssq']:checked").val() == "m") {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == "m" || arr[i] == "p5m") {
                    n_Record = 1;
                    alert('您已经添加过5码');
                    return n_Record;
                }
                if (arr[i] == "zx1z" || arr[i] == "pzx1z") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num != 3) {
                        alert('您选择的号码必须包含[组选1注(' + arrN[i] + ')]的号码');
                        n_Record = 1;
                        break;

                    }
                }
                if (arr[i] == "s2m" || arr[i] == "ps2m") {
                    var n_num = Comparison(value, arrN[i]);
                    if (n_num > 0) {
                        alert('您选择的号码不能包含[杀2码(' + arrN[i] + ')]中的号码');
                        n_Record = 1;
                        break;
                    }
                }
            }
        }

        //清空数组
        arr.length = 0;

        return n_Record;
    }

}
//比较号码 号码num1 中的数字 和num2中多有数字比较
function Comparison(num1, num2) {
    var num=0;
    for (var i = 0; i < num1.split(',').length; i++) {
        for (var j = 0; j < num2.split(',').length; j++) {
            if (num1.split(',')[i] == num2.split(',')[j]) {
                num = num + 1;
            }
        }
    }
    return num;
    
}


//根据条件显示号码
function setcode() {
    var selcodestr = "";
    //红球3胆，红球6胆，杀3红球，杀6红球
    if ($("input[name='ssq']:checked").val() == "hq3d" || $("input[name='ssq']:checked").val() == "hq6d" || $("input[name='ssq']:checked").val() == "s3hq" || $("input[name='ssq']:checked").val() == "s6hq") {
        var haoma = document.getElementsByName("haoma_ssq");
        var codstr = "";
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                var num = i + 1;
                codstr += ToLength(num) + ",";
            }
        }
        selcodestr = codstr.substring(codstr.length - 1, 0);
        return selcodestr;
    }
    //蓝球1胆、蓝球3胆、杀3蓝球、杀6蓝球
    if ($("input[name='ssq']:checked").val() == "lq1d" || $("input[name='ssq']:checked").val() == "lq3d" || $("input[name='ssq']:checked").val() == "s3lq" || $("input[name='ssq']:checked").val() == "s6lq") {
        var haoma = document.getElementsByName("haoma_ssql");
        var codstr = "";
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "bb") {
                var num = i + 1;
                codstr += ToLength(num) + ",";
            }
        }
        selcodestr = codstr.substring(codstr.length - 1, 0);
        return selcodestr;
    }

    //12红+3蓝、9红+2蓝
    if ($("input[name='ssq']:checked").val() == "h3l" || $("input[name='ssq']:checked").val() == "h2l") {
        var haomaH = document.getElementsByName("ssq_haoma1");
        var codstrH = "";
        for (var i = 0; i < haomaH.length; i++) {
            if (haomaH[i].className == "rb") {
                var num = i + 1;
                codstrH += ToLength(num) + ",";
            }
        }
        //蓝球
        var haomaL = document.getElementsByName("ssql_haoma");
        var codstrL = "";
        for (var i = 0; i < haomaL.length; i++) {
            if (haomaL[i].className == "bb") {
                var num = i + 1;
                codstrL += ToLength(num) + ",";
            }
        }
        selcodestr = codstrH.substr(0, codstrH.length - 1) + "+" + codstrL.substr(0, codstrL.length - 1);
        return selcodestr;
    }
    //独胆、双胆、杀1码、杀2码、独跨、杀1跨、独合、杀1合、5码
    if ($("input[name='ssq']:checked").val() == "dd" || $("input[name='ssq']:checked").val() == "sd" || $("input[name='ssq']:checked").val() == "s1m" || $("input[name='ssq']:checked").val() == "s2m" || $("input[name='ssq']:checked").val() == "dk" || $("input[name='ssq']:checked").val() == "s1k" || $("input[name='ssq']:checked").val() == "dh" || $("input[name='ssq']:checked").val() == "s1h" || $("input[name='ssq']:checked").val() == "m") {
        var haoma = document.getElementsByName("sd_haoma");
        var codstr = "";
        for (var i = 0; i < haoma.length; i++) {
            if (haoma[i].className == "rb") {
                var num = i;
                codstr += num + ",";
            }
        }
        selcodestr = codstr.substring(codstr.length - 1, 0);
        return selcodestr;
    }
    //组选1注、5*5*5定位、3*3*3定位、直选1注
    if ($("input[name='ssq']:checked").val() == "zx1z" || $("input[name='ssq']:checked").val() == "5dw" || $("input[name='ssq']:checked").val() == "3dw" || $("input[name='ssq']:checked").val() == "zx") {
        
        for (i = 1; i <= 3; i++) {
            var haoma = document.getElementsByName("haoma" + i);
            var codestr = "";
            for (j = 0; j < haoma.length; j++) {
                if (haoma[j].className == "rb") {
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
        return selcodestr;
    }
}


//向显示框添加信息
function Insert() {
    //判断是否选择了条件
    if ($("input[name='ssq']:checked").val() == null) {
        alert('请您先选择一个条件');
    }
    else {
        var value = setcode();
        if (value == "" || value == null) {
            alert('请选择号码');
        }
        else {
            //验证号码选择是否正确 和 条件所属关系
            var n_Record = Belong(value);

            if (n_Record != 1) {
                addto(value);
                InsertShow();
            }
        }
    }
}



//在各位数前加0  组合号码为01
function ToLength(num) {
    if (num <= 9) {
        return "0" + num;
    }
    else {
        return num;
    }
}

//删除单行数据
function Del_S() {
    var index = 0;
    var temp = document.getElementById('schemeNum');
    if (temp.length > 0) {
        index = temp.selectedIndex
        if (index >= 0) {
            temp.remove(index);
        }
        try { if (index != 0 && temp.length > 0 && index < temp.length) { temp.options[index].selected = true; } } catch (e) { }
    }
    else {
        alert('请选择一注号码');
    }
    InsertShow();
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










