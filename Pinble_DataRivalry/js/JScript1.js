
function SelectNum(Fid,issue,lottNum) {
    //接收开奖号码
    var aDate="";
    
    //查询开奖号码
    var lot_id;
    if(lottNum==1)
    {
        lot_id = 1;
    }
    if(lottNum==2)
    {
        lot_id = 9999;
    }
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "../DataList.asmx/lottOpenNum",
        data: "{lottID:'" + lot_id + "',issue:'" + issue + "'}",
        dataType: "json",
        complete: function (result) {
            aDate = result.responseText.split('"')[1].split('"')[0];
            $.XYTipsWindow({
                ___title: issue + "期开奖号码为：" + aDate,    //窗口标题文字
                ___content: "url:get?displayData.aspx?id=" + Fid,    //内容{text|id|img|url|iframe}
                ___width: "400",            //窗口宽度
                ___height: "270",          //窗口离度
                ___drag: "___boxTitle", 	    //拖动手柄ID
                ___showbg: true		//是否显示遮罩层
            });
        }
    });
}


