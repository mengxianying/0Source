
        /*iframe宽高自适应*/
    function TuneHeightLeft(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  

            var subWeb=document.frames ? document.frames[fm_name].document : frm.contentDocument;  
        
            if(frm != null && subWeb != null)
            { 
                frm.style.height = subWeb.documentElement.scrollHeight+"px"; 
                //如需自适应宽高,去除下行的“//”注释即可 
    //         frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
            }
 
    }  
    function TuneHeightRight(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  

            var subWeb=document.frames ? document.frames[fm_name].document : frm.contentDocument;  
        
            if(frm != null && subWeb != null)
            { 
                frm.style.height = subWeb.documentElement.scrollHeight+"px"; 
                //如需自适应宽高,去除下行的“//”注释即可 
//                frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
            }
 
    } 
    function GetQueryString(name) 
    { 
        var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)"); 
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return decodeURI(r[2]); return null; 
    }  
    
    /*********对应添加帮助缺省初始值————和ID值对应***********/
    $(document).ready(function () {
        //给网页上设置标题
        var Title = GetQueryString("name");
        $("#titleName").html(Title);
        var id = GetQueryString("id");

        var helpName = GetQueryString("helpName");

        //获取cid
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
                    $("#titleName").html("数字三『彩神通』帮助" + "&nbsp; &nbsp; &nbsp; &nbsp &nbsp &nbsp &nbsp<a href='http://download2.pinble.com/help/S3Cst.chm' style='font-size:12px;font-family:宋体'>下载该软件的离线帮助文件</a>");
                    $("#FM_Id").attr("src", "leftHtml/数字三『彩神通』帮助.htm");

                    $("#left").attr("src", "/publicHtml/Explain.htm");
                }
                else {
                    //下载地址
                    var d_address = "&nbsp; &nbsp; &nbsp; &nbsp &nbsp &nbsp &nbsp<a href='";
                    var h_address = "' style='font-size:12px;font-family:宋体'>下载该软件的离线帮助文件</a>";
                    var str = "";
                    if (address != null || address != "") {
                        str = d_address + address + h_address;
                    }
                    if (helpName != "" && helpName != 0) {
                        var Title = GetQueryString("name").split(' ')[0] + "『彩神通』" + GetQueryString("name").split(' ')[1];
                        $("#titleName").html(Title + str);
                        $("#FM_Id").attr("src", "leftHtml/" + helpName + ".htm");
                        //默认页面
                        $("#left").attr("src", "/publicHtml/Explain.htm");
                    }
                    else {
                        var Title = GetQueryString("name");
                        $("#titleName").html(Title + str);
                        $("#FM_Id").attr("src", "leftHtml/" + helpName + ".htm");
                        //默认页面
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
        
  /*********对应添加帮助缺省初始值***********/    
  
    function checkfenbian() 
    { 
       $("#RightTree").css("height",document.body.clientHeight-93);
            $("#leftTree").css("height",document.body.clientHeight-93);
            $("#centerImage").css("height",document.body.clientHeight-93);
        
    }