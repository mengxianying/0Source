

//��ѡ����
function jxhq(colorn) {
    var selectValueh = document.getElementById("J_JxRedNum");
    var selectValuel = document.getElementById("J_JxBlueNum");
    var arr = new Array();
    //��ѡ����
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
    //��ѡ����
    if (colorn == "l") {
        var lanqiu = document.getElementsByName("lanqiu");
        for (var i = 0; i < lanqiu.length; i++) { lanqiu[i].className = "number" } //�������
        arr = random_select(selectValuel.value, 16, 1);

        for (var j = 0; j < arr.length; j++) {
            lanqiu[arr[j] - 1].className = "numberl";
        }
        DisNum();
    }
}

//��ʾѡ�˼�������
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
                //����
                var Rball = new Array();
                //����
                var Lball = new Array();
                //�������
                for (var j = 0; j < Math.floor(str.split("\r\n")[i].split('-')[0].length / 2); j++) {
                    Rball[j] = repNum(str.split("\r\n")[i].split('-')[0]).substr(j * 2, 2);
                }
                //��������
                for (var j = 0; j < Math.floor(str.split("\r\n")[i].split('-')[1].length / 2); j++) {
                    Lball[j] = repNum(str.split("\r\n")[i].split('-')[1]).substr(j * 2, 2);
                }
                //�ж��Ƿ����ظ�����
                var doubNumh = 0;
                var doubNuml = 0;
                doubNumh = doobNum(Rball);
                doubNuml = doobNum(Lball);
                if (doubNumh != 1 && doubNuml != 1) {
                    //����
                    var RedBall = "";
                    //����
                    var BlueBall = "";
                    for (var k = 0; k < Rball.length; k++) {
                        RedBall += Rball[k] + " ";
                    }
                    for (var k = 0; k < Lball.length; k++) {
                        BlueBall += Lball[k] + " ";
                    }
                }
                else {
                    alert('������ĺ������ظ���');
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
//���� ��ʾѡ���˼���
function DisNumDT() {
    setcode();
    var str = document.getElementById("code").value;
    var zhushu = 0;
    //�������
    var Hnum = 0;
    //����
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
    //�������
    $("#J_PreDanSize").html(Hnum);
    //�������
    $("#J_PreTuoSize").html(Rnum);
    //�������
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
    //ע��
    $("#J_PreDantuoMulti").html(zhushu);
    //���
    $("#J_PreDantuoMoney").html(zhushu * 2);
}
//����ѡ��
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


//����������ʽ
function xuanhao(obj, sort) {		//�ı����� Class
    var Cname = obj.className;
    if (Cname == "number") {
        if (sort == "h") {
            obj.className = "numberh";
        } else if (sort == "l") {
            obj.className = "numberl";
        }
    }
    if (Cname == "numberh") { obj.className = "number"; }
    if (Cname == "numberl") { obj.className = "number"; } //����������ʱ���ܸı������ʽ
    //    Show();
    DisNum();

}

//����ѡ�������ʽ����Ͷע���봮 
function setcode() {
    var str = "";
    //��ͨѡ��
    if ($("input[name='a']:checked").val() == "fs") {
        var hongqiu = document.getElementsByName("hongqiu");
        var lanqiu = document.getElementsByName("lanqiu");
        var hongqiustr = "", lanqiustr = "";
        for (var i = 0; i < hongqiu.length; i++) {
            if (hongqiu[i].className == "numberh") {
                hongqiustr += ToLength(parseInt(i + 1)) + " ";
            }
        } //��պ���
        for (var i = 0; i < lanqiu.length; i++) {
            if (lanqiu[i].className == "numberl") {
                lanqiustr += ToLength(parseInt(i + 1)) + " ";
            }
        }
        str = hongqiustr.substring(hongqiustr.length - 1, 0) + "-" + lanqiustr.substring(lanqiustr.length - 1, 0);
    }
    //����ѡ��
    if ($("input[name='a']:checked").val() == "dt") {
        //�쵨
        var hdanma = document.getElementsByName("hdanma");
        //��������
        var htuma = document.getElementsByName("htuma");
        //����
        var lq = document.getElementsByName("lq");
        var dama = "";
        var tuoma = "";
        var lqq = "";
        //��ϵ���
        for (var i = 0; i < hdanma.length; i++) {
            if (hdanma[i].className == "numberh") {
                dama += ToLength(parseInt(i + 1)) + " ";
            }
        }
        //�������
        for (var i = 0; i < htuma.length; i++) {
            if (htuma[i].className == "numberh") {
                tuoma += ToLength(parseInt(i + 1)) + " ";
            }
        }
        //����
        for (var i = 0; i < lq.length; i++) {
            if (lq[i].className == "numberl") {
                lqq += ToLength(parseInt(i + 1)) + " ";
            }
        }
        str = dama.substring(dama.length - 1, 0) + "$" + tuoma.substring(tuoma.length - 1, 0) + "-" + lqq.substring(lqq.length - 1, 0);
    }
    //�ֶ�ѡ��
    if ($("input[name='a']:checked").val() == "sd") {
        str = $("#tb_ManualInput").val();
    }
    document.getElementById("code").value = str;
}
//���ݺ��봮ͳ��ע������������ʾ��Ϣ
function Show() {
    //    setcode();
    var str = document.getElementById("code").value;
    //    var zhushu = getZhushu(str, "0")
}


//��Ӻ���
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
//���㵨�ϵķ���ע��
function getZhushuDT(str) {
    var Temp = str.split("-");
    var TempNum = Temp[0].split('$');

    //�������
    var danma = TempNum[0].split(' ').length;
    //�������
    var tuoma = TempNum[1].split(' ').length;
    //�������
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


//���㷽��ע��
function getZhushu(str, inset) {
    var zhushu = 0;
    //��ͨѡ��
    if ($("input[name='a']:checked").val() == "fs") {

        var codestr = ""
        zhushu = getZhushu1(str);
        codestr = str;
        if (str.split('-')[0].split(' ').length < 6) {
            alert('����ѡ��6������');
            return false;
        }
        if (str.split('-')[1].length<1) {
            alert('����ѡ��1������');
            return false;
        }
        if (zhushu < 1) {
            alert("��û��ѡ��Ϸ���Ͷע���룡");
            return false;
        }
        add(codestr, zhushu);
        clearall();
    }
    //����
    if ($("input[name='a']:checked").val() == "dt") {
        //����ѡ��һ������
        var TempNum = str.split('$');
        if (TempNum[0] == "" || TempNum[0].split(' ').length < 1) {
            alert('����ѡ��һ������');
            return false;
        }
        if (TempNum[0].split(' ').length > 5) {
            alert('���ѡ��5������');
            return false;
        }
        //�ж�����
        if (TempNum[1].split('-')[0].split(' ').length < 2) {
            alert('����ѡ��2������');
            return false;
        }
        var leng = parseInt(TempNum[0].split(' ').length) + parseInt(TempNum[1].split('-')[0].split(' ').length);
        if (leng < 7) {
            alert('�������������ѡ��7������');
            return false;
        }

        if (TempNum[1].split('-')[1].split(' ')[0].length == 0) {
            alert('��ѡ��һ������');
            return false;
        }
        if (TempNum[1].split('-')[1].split(' ').length < 1) {
            alert('��ѡ��һ������');
            return false;
        }
        zhushu = getZhushuDT(str);
        var retStr = "[����]" + str.split('$')[0] + " [����]" + str.split('$')[1].split('-')[0] + " [����]" + str.split('$')[1].split('-')[1];
        writeselect(retStr, str + "|" + zhushu);
        clearall();
    }
    //�ֶ�����
    if ($("input[name='a']:checked").val() == "sd") {
        //�ж��ֶ���������Ƿ�Ϊ��
        if (str == "" || str == null) {
            alert('�����������ճ�����뵽�����');
            return false;
        }
        //�������� ������
        var arrh = new Array();
        var arrl = new Array();

        //���ݻ��з���ȡ
        for (var i = 0; i < str.split('\r\n').length; i++) {
            //�ж������������ϱ�׼ ����+���� ��ʽ
            if (str.split('\r\n')[i].split('-')[0] == null || str.split('\r\n')[i].split('-')[0].toString == "") {
                alert('ע��˫ɫ�������ʽ');
                return false;
            }
            if (str.split('\r\n')[i].split('-')[1] == null || str.split('\r\n')[i].split('-')[1].toString == "") {
                alert('ע��˫ɫ�������ʽ');
                return false;
            }

            //�������
            var HNum = repNum(str.split('\r\n')[i].split('-')[0]);
            //��������
            var LNum = repNum(str.split('\r\n')[i].split('-')[1]);
            //�жϺ����Ƿ�Ϸ� 
            if (Math.floor(HNum.length / 2) < 6 || Math.floor(LNum.length / 2) < 1) {
                alert('�����������������������������ʾ����������6�� ��������1��');
                return false;
            }
            //�������
            arrh.splice(0, arrh.length);
           
            //������Ϻ��� 

            //����
            for (var j = 0; j < Math.floor(HNum.length / 2); j++) {
                //��֤���������Ƿ�Ϸ�
                if (HNum.substr(j * 2, 2) <= 0 || HNum.substr(j * 2, 2) > 33) {
                    alert('����Χ01-33');
                    return false;
                }
                arrh[j] = HNum.substr(j * 2, 2);
            }
            arrl.splice(0, arrl.length);
            // ����ȥ���ظ�
            var retArrh = new Array();
            retArrh = BubbleSort(arrh);
            //����
            for (var j = 0; j < Math.floor(LNum.length / 2); j++) {
                //��֤���������Ƿ�Ϸ�
                if (LNum.substr(j * 2, 2) <= 0 || LNum.substr(j * 2, 2) > 16) {
                    alert('����Χ01-16');
                    return false;
                }
                arrl[j] = LNum.substr(j * 2, 2);
            }
            var retArrl = new Array();
            retArrl = BubbleSort(arrl);
            //����
            var NHNum = "";
            var doubStateh;
            var doubStatel
            doubStateh = doobNum(retArrh);
            doubStatel = doobNum(retArrl);
            if (doubStateh == 1) {
                alert('���ĺ������ظ����룡');
                return false;
            }
            if (doubStatel == 1) {
                alert('�����������ظ�����');
                return false;
            }
            for (j = 0; j < retArrh.length; j++) {
                NHNum += retArrh[j] + " ";
            }
            //����
            var NLNum = "";
            for (j = 0; j < retArrl.length; j++) {
                NLNum += retArrl[j] + " ";
            }
            //��Ϻ���
            var Number = NHNum.substr(0,NHNum.length - 1) + "-" + NLNum.substr(0,NLNum.length - 1);
            var zhushu = getZhushu1(Number);
            add(Number, zhushu);
        }
        //��������
        document.getElementById("tb_ManualInput").value = "";
    }
    return zhushu;
}



//������״̬�ָ�
function clearall() {
    var hongqiu = document.getElementsByName("hongqiu");

    var lanqiu = document.getElementsByName("lanqiu");
    for (var i = 0; i < hongqiu.length; i++) { hongqiu[i].className = "number" } //��պ���
    for (var i = 0; i < lanqiu.length; i++) { lanqiu[i].className = "number" } //�������

    var hdanma = document.getElementsByName("hdanma"); //������

    var htuma = document.getElementsByName("htuma"); //������

    var lq = document.getElementsByName("lq"); //����

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
    //�������
    $("#J_PreDanSize").html(0);
    //�������
    $("#J_PreTuoSize").html(0);

    $("#J_PreDantuoBlueSize").html(0);

    //ע��
    $("#J_PreDantuoMulti").html(0);
    //���
    $("#J_PreDantuoMoney").html(0);
    return;
}

function jixuan(n) {
    BuyNum = "";
    type = "jixuan";
    for (var i = 0; i < n; i++) {
        var Itmp1 = Math.ceil(Math.random() * 33); //��ѡ��һ����ֵ
        Itmp1 = ToLength(parseInt(Itmp1));
        while (true) {
            var Itmp2 = Math.ceil(Math.random() * 33); //��ѡ�ڶ�����ֵ
            if (Itmp2 != Itmp1) { Itmp2 = ToLength(parseInt(Itmp2)); break; }
        }
        while (true) {
            var Itmp3 = Math.ceil(Math.random() * 33); //��ѡ��������ֵ
            if (Itmp3 != Itmp1 && Itmp3 != Itmp2) { Itmp3 = ToLength(parseInt(Itmp3)); break; }
        }
        while (true) {
            var Itmp4 = Math.ceil(Math.random() * 33); //��ѡ���ĸ���ֵ
            if (Itmp4 != Itmp1 && Itmp4 != Itmp2 && Itmp4 != Itmp3) { Itmp4 = ToLength(parseInt(Itmp4)); break; }
        }
        while (true) {
            var Itmp5 = Math.ceil(Math.random() * 33); //��ѡ�������ֵ
            if (Itmp5 != Itmp1 && Itmp5 != Itmp2 && Itmp5 != Itmp3 && Itmp5 != Itmp4) { Itmp5 = ToLength(parseInt(Itmp5)); break; }
        }
        while (true) {
            var Itmp6 = Math.ceil(Math.random() * 33); //��ѡ��������ֵ
            if (Itmp6 != Itmp1 && Itmp6 != Itmp2 && Itmp6 != Itmp3 && Itmp6 != Itmp4 && Itmp6 != Itmp5) { Itmp6 = ToLength(parseInt(Itmp6)); break; }
        }

        var Itmp7 = Math.ceil(Math.random() * 16); //��ѡ������ֵ
        Itmp7 = ToLength(parseInt(Itmp7));
        var tempmun = new Array(Itmp1, Itmp2, Itmp3, Itmp4, Itmp5, Itmp6); 	//��������
        BubbleSort(tempmun); //��������
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
        var Itmp1 = Math.ceil(Math.random() * 33); //��ѡ��һ����ֵ
        Itmp1 = ToLength(parseInt(Itmp1));
        while (true) {
            var Itmp2 = Math.ceil(Math.random() * 33); //��ѡ�ڶ�����ֵ
            if (Itmp2 != Itmp1) { Itmp2 = ToLength(parseInt(Itmp2)); break; }
        }
        while (true) {
            var Itmp3 = Math.ceil(Math.random() * 33); //��ѡ��������ֵ
            if (Itmp3 != Itmp1 && Itmp3 != Itmp2) { Itmp3 = ToLength(parseInt(Itmp3)); break; }
        }
        while (true) {
            var Itmp4 = Math.ceil(Math.random() * 33); //��ѡ���ĸ���ֵ
            if (Itmp4 != Itmp1 && Itmp4 != Itmp2 && Itmp4 != Itmp3) { Itmp4 = ToLength(parseInt(Itmp4)); break; }
        }
        while (true) {
            var Itmp5 = Math.ceil(Math.random() * 33); //��ѡ�������ֵ
            if (Itmp5 != Itmp1 && Itmp5 != Itmp2 && Itmp5 != Itmp3 && Itmp5 != Itmp4) { Itmp5 = ToLength(parseInt(Itmp5)); break; }
        }
        while (true) {
            var Itmp6 = Math.ceil(Math.random() * 33); //��ѡ��������ֵ
            if (Itmp6 != Itmp1 && Itmp6 != Itmp2 && Itmp6 != Itmp3 && Itmp6 != Itmp4 && Itmp6 != Itmp5) { Itmp6 = ToLength(parseInt(Itmp6)); break; }
        }

        while (true) {
            var Itmp7 = Math.ceil(Math.random() * 33); //��ѡ���߸���ֵ
            if (Itmp7 != Itmp1 && Itmp7 != Itmp2 && Itmp7 != Itmp3 && Itmp7 != Itmp4 && Itmp7 != Itmp5 && Itmp7 != Itmp6) { Itmp7 = ToLength(parseInt(Itmp7)); break; }
        }

        var Itmp8 = Math.ceil(Math.random() * 16); //��ѡ������ֵ
        Itmp8 = ToLength(parseInt(Itmp8));
        var tempmun = new Array(Itmp1, Itmp2, Itmp3, Itmp4, Itmp5, Itmp6, Itmp7); 	//��������
        BubbleSort(tempmun); //��������ZZ
        //alert(tempmun);
        str = tempmun + "-" + Itmp8
        add(str,1);
    }
    InsertShow();
}
//ȥ���ظ� ����
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
//�ж��Ƿ����ظ�����
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
