
        /*iframe�������Ӧ*/
    function TuneHeightLeft(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  

            var subWeb=document.frames ? document.frames[fm_name].document : frm.contentDocument;  
        
            if(frm != null && subWeb != null)
            { 
                frm.style.height = subWeb.documentElement.scrollHeight+"px"; 
                //��������Ӧ���,ȥ�����еġ�//��ע�ͼ��� 
    //         frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
            }
 
    }  
    function TuneHeightRight(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  

            var subWeb=document.frames ? document.frames[fm_name].document : frm.contentDocument;  
        
            if(frm != null && subWeb != null)
            { 
                frm.style.height = subWeb.documentElement.scrollHeight+"px"; 
                //��������Ӧ���,ȥ�����еġ�//��ע�ͼ��� 
//                frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
            }
 
    } 
    function GetQueryString(name) 
    { 
        var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)"); 
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return decodeURI(r[2]); return null; 
    }  
    
    /*********��Ӧ��Ӱ���ȱʡ��ʼֵ����������IDֵ��Ӧ***********/
    $(document).ready(function () {
        //����ҳ�����ñ���
        var Title = GetQueryString("name");
        $("#titleName").html(Title);
        var id = GetQueryString("id");

        var helpName = GetQueryString("helpName");

        //��ȡcid
        var n_cid = GetQueryString("cid");
        var address = "";
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../webser.asmx/DownLoadMian",
            data: "{cid:'" + n_cid + "'}",
            dataType: "json",
            complete: function (result) {

                address = result.responseText.split('"')[1].split('"')[0];
                if (id == "" || id == null) {
                    $("#titleName").html("������������ͨ������" + "&nbsp; &nbsp; &nbsp; &nbsp &nbsp &nbsp &nbsp<a href='http://download2.pinble.com/help/S3Cst.chm' style='font-size:12px;font-family:����'>���ظ���������߰����ļ�</a>");
                    $("#FM_Id").attr("src", "leftHtml/������������ͨ������.htm");

                    $("#left").attr("src", "/publicHtml/Explain.htm");
                }
                else {
                    //���ص�ַ
                    var d_address = "&nbsp; &nbsp; &nbsp; &nbsp &nbsp &nbsp &nbsp<a href='";
                    var h_address = "' style='font-size:12px;font-family:����'>���ظ���������߰����ļ�</a>";
                    var str = "";
                    if (address != null || address != "") {
                        str = d_address + address + h_address;
                    }
                    if (helpName != "" && helpName != 0) {
                        var Title = GetQueryString("name").split(' ')[0] + "������ͨ��" + GetQueryString("name").split(' ')[1];
                        $("#titleName").html(Title + str);
                        $("#FM_Id").attr("src", "leftHtml/" + helpName + ".htm");
                        //Ĭ��ҳ��
                        $("#left").attr("src", "/publicHtml/Explain.htm");
                    }
                    else {
                        var Title = GetQueryString("name");
                        $("#titleName").html(Title + str);
                        $("#FM_Id").attr("src", "leftHtml/" + helpName + ".htm");
                        //Ĭ��ҳ��
                        $("#left").attr("src", "/publicHtml/Explain.htm");
                    }
                }
            }
        });




        $("#aa").click(function () {
            if ($("#hidden").val() == 0) {
                $("#leftTree").animate({ width: 0 }, "slow");
                $("#RightTree").removeClass("right1");
                $("#RightTree").addClass("right2");
                $("#hidden").val("1");
                return false;
            }
            if ($("#hidden").val() == 1) {
                $("#leftTree").animate({ width: 255 }, "slow");
                $("#RightTree").removeClass("right2");
                $("#RightTree").addClass("right1");
                $("#hidden").val("0");
                return false;
            }

        });



    });
        
  /*********��Ӧ��Ӱ���ȱʡ��ʼֵ***********/    
  
    function checkfenbian() 
    { 
       $("#RightTree").css("height",document.body.clientHeight-93);
            $("#leftTree").css("height",document.body.clientHeight-93);
            $("#centerImage").css("height",document.body.clientHeight-93);
        
    }