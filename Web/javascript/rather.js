function getDate() {
    var d, s, t;
    d = new Date();
    s = d.getFullYear().toString(10) + "-";
    t = d.getMonth() + 1;
    s += (t > 9 ? "" : "0") + t + "-";
    t = d.getDate();
    s += (t > 9 ? "" : "0") + t + " ";
    return s;
}
function LotteryQiehuan(id, obj, intIndex, total) {
    for (var i = 1; i <= total; i++) {
        var objHide = document.getElementById(obj + i);
        var objA = document.getElementById(id + i);
        if (i == intIndex) {
            objA.className = "kai_menubg_open";
            objHide.style.display = "";
        }
        else {
            objA.className = "kai_menubg";
            objHide.style.display = "none";
        }
    }
}

function ListClick(obj, obj1) {
    if (obj == "pl3") {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Template/WebService1.asmx/lotteryNameData",
            data: "{lotteryName:'排列五'}",
            dataType: "json",
            complete: function (result) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "/Template/WebService1.asmx/Present3DList",
                    data: "{pageindex:'1',lottory:'TCPL35Data',pl3:'pl3',name:'排列五',isgp:'" + obj1 + "'}",
                    dataType: "json",
                    success: function (data) {
                        $("#rather").html(data.d);
                    }
                });
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/Template/WebService1.asmx/lotteryNameData",
            data: "{lotteryName:'" + obj + "'}",
            dataType: "json",
            complete: function (result) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "/Template/WebService1.asmx/Present3DList",
                    data: "{pageindex:'1',lottory:'" + JSON.parse(result.response).d + "',pl3:'',name:'" + obj + "',isgp: '" + obj1 + "'}", //.split('"')[1].split('"')[0]
                    dataType: "json",
                    success: function (data) {
                        $("#rather").html(data.d); //HtmlDecode(data)
                    }
                });
            }
        });
    }
    
}
//html解码
function HtmlDecode(text) {
    return text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
}

function PresentList(obj) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Template/WebService1.asmx/PresentList",
        data: "{type:'" + obj + "'}",
        dataType: "json",
        success: function (data) {
            $("#rather").html(data.d);
        }
    });
   
}
$(document).ready(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Template/WebService1.asmx/PresentList",
        data: "{type:'全国开奖'}",
        dataType: "json",
        success: function (data) {
            $("#rather").html(data.d);
        }
    });
    
});