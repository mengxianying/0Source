//�л���ʾ��
function switchs() {
    //����
    var rad_purchasing = document.getElementById("rad_purchasing");
    //����
    var rad_chipped = document.getElementById("rad_chipped");
    //׷��
    var rad_AfterNum = document.getElementById("TrackNum");
    if (rad_purchasing.checked == true) {
        document.getElementById("AfterNum").style.display = "none";
        document.getElementById("chipped").style.display = "none";
    }
    if (rad_chipped.checked == true) {
        document.getElementById("chipped").style.display = "block";
        document.getElementById("AfterNum").style.display = "none";
        //������ʾ
        $("#J_UnitedTitle").attr("value", $("#ExpectNum").val() + "��");
        $("#J_UnitedTitle").attr("text", $("#ExpectNum").val() + "��");
        var obj = document.getElementById("J_UnitedTitle");
        checkLen(obj);
        $("#mytext").attr("value", "������е�����ֻ����д󽱡�");
        $("#mytext").attr("text", "������е�����ֻ����д󽱡�");
    }
    if (rad_AfterNum.checked == true) {
        document.getElementById("AfterNum").style.display = "block";
        document.getElementById("chipped").style.display = "none";
        catchOn();
    }
}
//��ʾ׷�Ų���
function catchOn() {
    /**************����׷���ں���ʾ**************/
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
    /**************����׷���ں���ʾ**************/
}


//ѡ�б��� �ı������
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

//�������ı���ʽ������
function ChangeColor(obj) {
    if (obj == 'xuanhao') {
        document.getElementById("xuanhao").className = "on";
        document.getElementById("canyu").className = "";
        document.getElementById("dingzhi").className = "";
        document.getElementById("fangan").className = "";
        //��ʾ����
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

        //��ʾ����
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
    /****˫ɫ��begin******/
    if (obj == 'fanan_ssq') {
        Scheme(3);
    }
    /****˫ɫ��end******/

    /****����͸begin*****/
    if (obj == 'fanan_dlt') {
        Scheme(6);
    }
    /****����͸end*****/
    /****���ǲ�***/
    if (obj == 'fanan_qxc') {
        Scheme(5);
    }
    /****���ǲ�***/
    /****������***/
    if (obj == 'fanan_pls') {
        Scheme(9999);
    }
    /****������***/

    /******���ֲ�begion******/
    if (obj == 'fanan_qlc') {
        Scheme(2);
    }
    /******���ֲ�begion******/
}
//html����
function HtmlEncode(text) {
    return text.replace(/&/g, '&amp').replace(/\"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');

}
//html����
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}
//�ҵ���Ŀ
function Scheme(Lstate) {
    //�ж��Ƿ��¼
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //�ѵ�¼
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == null || result.responseText == "") {
                $("#pagelist").html("����û�е�¼������<a href='LoginPage.aspx'>��¼</a>");
                $("#Div1").html("����û�е�¼������<a href='LoginPage.aspx'>��¼</a>");
                $("#Div2").html("����û�е�¼������<a href='LoginPage.aspx'>��¼</a>");
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
                        //��ȡ�ı��                         
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
        //��ʾ�ҵķ���
        document.getElementById("Myproject").style.display = "block";
        document.getElementById("doc").style.display = "none";
        document.getElementById("Large").style.display = "none";
        document.getElementById("Tracking").style.display = "none";
    }
    else {
        //��ʾ�ҵķ���
        document.getElementById("Myproject").style.display = "block";
        document.getElementById("doc").style.display = "none";
        document.getElementById("Large").style.display = "none";
    }
}
//���Ƹ���
function TheDocumentary(Lid) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/TrackingOrders",
        data: "{playName:'" + Lid + "'}",
        dataType: "json",
        success: function (data) {
            //��ȡ�ı��                         
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


//�б�Ĳ��뵯���򷽷�  	
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
            //�ж��Ƿ��¼
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                //                $.XYTipsWindow({
                //                    ___title: "�û���¼",    //���ڱ�������
                //                    ___content: "iframe:login.aspx",    //����{text|id|img|url|iframe}
                //                    ___width: "350",            //���ڿ��
                //                    ___height: "170",          //�������
                //                    ___titleClass: "boxTitle", //���ڱ�����ʽ����
                //                    ___closeID: "", 	//�رմ���ID
                //                    ___time: "", 	    //�Զ��رյȴ�ʱ��
                //                    ___drag: "___boxTitle", 	    //�϶��ֱ�ID
                //                    ___showbg: true, 	//�Ƿ���ʾ���ֲ�
                //                    //	        ___offsets:{left:"auto",top:"auto"},//�趨������λ��,Ĭ�Ͼ���
                //                    ___fns: function () {
                //                    } //�رմ��ں�ִ�еĺ���
                //                });
                alert("����û�е�¼�����ȵ�¼");
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
                            alert('�÷����Ѿ���ֹ');
                            return false;
                        }
                        if (result.responseText == 2) {
                            alert('���������ִ���ʣ��ķ�����');
                            return false;
                        }
                        if (result.responseText == 3) {
                            $.XYTipsWindow({
                                ___title: "�� '" + $("#ExpectNum").val() + "' ��  ���򷽰�",    //���ڱ�������
                                ___content: "iframe:ChippedInfo.aspx?id=" + Qnum + "&share=" + val,    //����{text|id|img|url|iframe}
                                ___width: "600",            //���ڿ��
                                ___height: "350",          //�������
                                ___drag: "___boxTitle", 	    //�϶��ֱ�ID
                                ___showbg: true		//�Ƿ���ʾ���ֲ�
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
    //˫ɫ��
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
            //�ж�3D��ѡ�Ź���
            if (number.split(';')[i].split('|')[0] == "1") {

                num += "<font color='red'>[ֱѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {

                num += "<font color='red'>[ֱѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //��ѡ����
            if (number.split(';')[i].split('|')[0] == "6") {

                num += "<font color='red'>[��ѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S9") {

                num += "<font color='red'>[��ѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F3") {

                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {

                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F6") {

                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {

                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //1D
            if (number.split(';')[i].split('|')[0] == "1D") {

                num += "<font color='red'>[1D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //2D
            if (number.split(';')[i].split('|')[0] == "2D") {

                num += "<font color='red'>[2D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //ͨѡ
            if (number.split(';')[i].split('|')[0] == "tx") {

                num += "<font color='red'>[ͨѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ
            if (number.split(';')[i].split('|')[0] == "hsx") {

                num += "<font color='red'>[����ѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }



    }
    //���ǲ�
    if ($("#playName").val() == 5) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[����]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }

    //����͸
    if ($("#playName").val() == 6) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font>+" + "<font color='blue'>" + number.split(';')[i].split('-')[1] + "</font><br/>";
        }
    }
    //���ֲ�
    if ($("#playName").val() == 2) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font><br/>";
        }
    }
    //����3
    if ($("#playName").val() == 9999) {
        for (var i = 0; i < number.split(';').length; i++) {
            //ֱѡ
            if (number.split(';')[i].split('|')[0] == "1") {
                num += "<font color='red'>[ֱѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {
                num += "<font color='red'>[ֱѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //��ѡ
            if (number.split(';')[i].split('|')[0] == "6") {
                num += "<font color='red'>[��ѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[��ѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F3") {
                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {
                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F6") {
                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }
    }
    //������
    if ($("#playName").val() == 4) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[����]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }
    //   $.XYTipsWindow({
    //       ___title: "��������",    //���ڱ�������
    //       ___content: "iframe:Number.aspx?CStr=" + num + "&play=" + $("#playName").val(),    //����{text|id|img|url|iframe}
    //       ___width: "600",            //���ڿ��
    //       ___height: "350",          //�������
    //       ___drag: "___boxTitle", 	    //�϶��ֱ�ID
    //       ___showbg: true		//�Ƿ���ʾ���ֲ�
    //   });

    $.XYTipsWindow({
        ___title: "��������",    //���ڱ�������
        ___content: "text:" + num,    //����{text|id|img|url|iframe}
        ___width: "400",            //���ڿ��
        ___height: "270",          //�������
        ___titleClass: "boxTitle", //���ڱ�����ʽ����
        ___closeID: "", 	//�رմ���ID
        ___time: "", 	    //�Զ��رյȴ�ʱ��
        ___drag: "___boxTitle", 	    //�϶��ֱ�ID
        ___showbg: true		//�Ƿ���ʾ���ֲ�
    });


}
function view_s(number, playName) {

    var num = "";
    //˫ɫ��
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
            //�ж�3D��ѡ�Ź���
            if (number.split(';')[i].split('|')[0] == 1) {

                num += "<font color='red'>[ֱѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {

                num += "<font color='red'>[ֱѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //��ѡ����
            if (number.split(';')[i].split('|')[0] == 6) {

                num += "<font color='red'>[��ѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S9") {

                num += "<font color='red'>[��ѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F3") {

                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {

                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F6") {

                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {

                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //1D
            if (number.split(';')[i].split('|')[0] == "1D") {

                num += "<font color='red'>[1D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //2D
            if (number.split(';')[i].split('|')[0] == "2D") {

                num += "<font color='red'>[2D]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //ͨѡ
            if (number.split(';')[i].split('|')[0] == "tx") {

                num += "<font color='red'>[ͨѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ
            if (number.split(';')[i].split('|')[0] == "hsx") {

                num += "<font color='red'>[����ѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }

    }
    //���ǲ�
    if (playName == 5) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[����]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }

    //����͸
    if (playName == 6) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font>+" + "<font color='blue'>" + number.split(';')[i].split('-')[1] + "</font><br/>";
        }
    }
    //���ֲ�
    if (playName == 2) {

        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>" + number.split(';')[i].split('-')[0] + "</font><br/>";
        }
    }
    //����3
    if (playName == 9999) {
        for (var i = 0; i < number.split(';').length; i++) {
            //ֱѡ
            if (number.split(';')[i].split('|')[0] == "1") {
                num += "<font color='red'>[ֱѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S1") {
                num += "<font color='red'>[ֱѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //��ѡ
            if (number.split(';')[i].split('|')[0] == "6") {
                num += "<font color='red'>[��ѡ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[��ѡ��ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F3") {
                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S3") {
                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            //����ѡ��
            if (number.split(';')[i].split('|')[0] == "F6") {
                num += "<font color='red'>[��������]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
            if (number.split(';')[i].split('|')[0] == "S6") {
                num += "<font color='red'>[������ֵ]:" + number.split(';')[i].split('|')[1] + "</font>&nbsp&nbsp";
            }
        }
    }
    //����5
    if (playName == 4) {
        for (var i = 0; i < number.split(';').length; i++) {
            num += "<font color='red'>[����]:" + number.split(';')[i] + "</font>&nbsp&nbsp";
        }
    }


    $.XYTipsWindow({
        ___title: "��������",    //���ڱ�������
        ___content: "text:" + num,    //����{text|id|img|url|iframe}
        ___width: "400",            //���ڿ��
        ___height: "270",          //�������
        ___titleClass: "boxTitle", //���ڱ�����ʽ����
        ___closeID: "", 	//�رմ���ID
        ___time: "", 	    //�Զ��رյȴ�ʱ��
        ___drag: "___boxTitle", 	    //�϶��ֱ�ID
        ___showbg: true		//�Ƿ���ʾ���ֲ�
    });


}

/*iframe�������Ӧ*/
function TuneHeight(fm_name, fm_id) {
    var frm = document.getElementById(fm_id);
    var subWeb = document.frames ? document.frames[fm_name].document : frm.contentDocument;
    if (frm != null && subWeb != null) {
        frm.style.height = subWeb.documentElement.scrollHeight + "px";
        //��������Ӧ���,ȥ�����еġ�//��ע�ͼ��� 
        frm.style.width = subWeb.documentElement.scrollWidth + "px";
    }
}


/************���Ƹ���*****************/
function Display_tarcking(obj, LN, num) {  //ln: �к�   num��������
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
//��ǰ�ڽ��(���ں�׷����ʾ����)
function dataChage(obj, i) {
    var m = obj.split('_')[1];
    /**����׷�ű����ͼ۸���ʾ**/
    if ($("input[name='buy']:checked").val() == "track" && $("input[name='a']:checked").val() != "dqxh") {
        if ($("#" + obj).val() > 99) {
            $("#" + obj).attr("value", 99);
        }
        
        $("#money_"+m +"_"+ i).html(formatCurrency($("#txt_"+m+"_" + i).val() * $("#danzhushu").val() * 2));

    }
    /**����׷�ű����ͼ۸���ʾ**/
    else {
        if ($("#" + obj).val() > 500) {
            $("#" + obj).attr("value", 500);
        }
        if (obj == "txt_" + m+"_" + "1") {
            $("#CurrentMoney").html(formatCurrency($("#txt_"+ m+"_" +"1").val() * 2 * $("#txt_num").val()));
            //��ӽ����ر�����
            $("#curr_money").attr("value", $("#txt_"+ m+"_" +"1").val() * 2 * $("#txt_num").val());
        }
        $("#money_"+m+"_" + i).html(formatCurrency($("#txt_"+m+"_" + i).val() * 2 * $("#txt_num").val()));

        //�û����      
        if ($("#lab_accMoney").text() != "" || $("#lab_accMoney").text() > 0) {
            $("#user_Balance").html($("#lab_accMoney").text() - $("#curr_money").val());
        }
        else {
            $("#user_Balance").html(0);
        }
    }
}

//html����
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}

//���Ƹ����������
//���ֱ�ţ���Ա��,�б��
function Frozen(playname, name,num) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //�ж��Ƿ��¼
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                //                                window.top.location.href="LoginPage.aspx";
                $.XYTipsWindow({
                    ___title: "�û���¼",    //���ڱ�������
                    ___content: "iframe:login.aspx",    //����{text|id|img|url|iframe}
                    ___width: "350",            //���ڿ��
                    ___height: "170",          //�������
                    ___titleClass: "boxTitle", //���ڱ�����ʽ����
                    ___closeID: "", 	//�رմ���ID
                    ___time: "", 	    //�Զ��رյȴ�ʱ��
                    ___drag: "___boxTitle", 	    //�϶��ֱ�ID
                    ___showbg: true, 	//�Ƿ���ʾ���ֲ�
                    //	        ___offsets:{left:"auto",top:"auto"},//�趨������λ��,Ĭ�Ͼ���
                    ___fns: function () {

                    } //�رմ��ں�ִ�еĺ���
                });
            }
            else {
                if ($("#txtNum_" + num).val() == 0 || $("#txtNum_" + num).val() == "") {
                    alert('�Ϲ��ķ�����������Ϊһ��');
                    return false;
                }
                if ($("#tbMoney_" + num).val() < 1 || $("#tbMoney_" + num).val() == "") {
                    alert('ÿ���Ϲ��Ľ���С��1Ԫ');
                    return false;
                }
                //�ύ
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "../WebChipped.asmx/AddTracking",
                    data: "{UserName:'" + name + "',playName:'" + playname + "',num:'" + $("#txtNum_" + num).val() + "',money:'" + $("#tbMoney_" + num).val() + "'}",
                    dataType: "json",
                    complete: function (result) {

                        if (result.responseText == 0) {
                            alert('���ϴεĸ�����δȫ�����');
                            return false;
                        }
                        if (result.responseText == 1) {
                            if (confirm("���Ƴɹ���\r\n���ȡ�������������������֣�\r\n���ȷ�����������鿴������Ϣ��\r\n�����ڡ����Ƽ�¼����ѯ���ж���״̬")) {

                                parent.mainFrame.location.href = "../admin/TrackingList.aspx";
                                return false;
                            }
                            else {
                                //ˢ��ҳ��
                                history.go(0);
                                return false;
                            }
                        }
                        if (result.responseText == 1) {
                            alert("����������ֻ����1000�˶���");
                            return false;
                        }
                    }
                });
            }
        }
    });

}


//��֤�Ƿ��¼
function login() {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../WebChipped.asmx/username",
        data: "{}",
        dataType: "json",
        complete: function (result) {
            //�ж��Ƿ��¼
            if (result.responseText.split('"')[1].split('"')[0] == 0 || result.responseText == "" || result.responseText == null) {
                //                                window.top.location.href="LoginPage.aspx";
                $.XYTipsWindow({
                    ___title: "�û���¼",    //���ڱ�������
                    ___content: "iframe:login.aspx",    //����{text|id|img|url|iframe}
                    ___width: "350",            //���ڿ��
                    ___height: "170",          //�������
                    ___titleClass: "boxTitle", //���ڱ�����ʽ����
                    ___closeID: "", 	//�رմ���ID
                    ___time: "", 	    //�Զ��رյȴ�ʱ��
                    ___drag: "___boxTitle", 	    //�϶��ֱ�ID
                    ___showbg: true, 	//�Ƿ���ʾ���ֲ�
                    //	        ___offsets:{left:"auto",top:"auto"},//�趨������λ��,Ĭ�Ͼ���
                    ___fns: function () {

                    } //�رմ��ں�ִ�еĺ���
                });
            }
            else {
                //                window.location = "Tracking.aspx?name=" + obj;
                return 1;
            }
        }
    });
}
/************���Ƹ���*****************/

//��ʽ���۸���ʾ
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

/*******�������������������*********/
function checkLen(term) {

    if (30 - term.value.length <= 0) {
        alert("���������Ϣ������");
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
        window.alert("\���ݲ���Ϊ�գ�");
        fm.message.focus();
        return false;
    }
    return true;
}
function fTrim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
/*******�������������������*********/
//����������������
//����˵������������
function limitChars(id, count) {
    var obj = document.getElementById(id);
    $("#J_UnitedDescLen").html(50 - obj.value.length);
    if (obj.value.length > count) {
        obj.value = obj.value.substr(0, count);
    }
}

//�����������ַ�Χ �����Ƹ����б�
function Range(obj) {
    var num = obj.id;

    if (obj.value > 10) {
        obj.value = 10;
        return false;
    }
}


