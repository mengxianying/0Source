//普通画线
function DrawLine(ojbCurrnetTd,ojbPrevTd,myColor)
{  
	var a = parseInt(ojbCurrnetTd.innerText);  
    var b = parseInt(ojbPrevTd.innerText);
     
    // alert(a);
    // alert(b);
     var coordinate = (a - b) *18 - 0;    
     var newLine = document.createElement('<v:line from="-4,8" to="'+coordinate+',28" strokecolor='+myColor+' StrokeWeight="1" />');    
    ojbPrevTd.insertBefore(newLine);
}
//质合画线
function DrawLineZh(ojbCurrnetTd,ojbPrevTd)
{
	var a = ojbCurrnetTd.id;	
	var a_array = a.split('_');	
	var b = ojbPrevTd.id;	
	var b_array = b.split('_');	
	var coordinate = (parseInt(a_array[1]) - parseInt(b_array[1])) *84-4;
	var newLine = document.createElement('<v:line from="-5,-10" to="' + coordinate + ',15" strokecolor="#999999" StrokeWeight="1.0" />');	
	ojbPrevTd.insertBefore(newLine);
}
//012图1中的画线
function DrawLine012(ojbCurrnetTd,ojbPrevTd)
{  
	var a = parseInt(ojbCurrnetTd.innerText);  
    var b = parseInt(ojbPrevTd.innerText);
     var coordinate = (a - b) *35 - 4;    
     var newLine = document.createElement('<v:line from="-4,7" to="'+coordinate+',32" strokecolor="#999999" StrokeWeight="1" />');    
    ojbPrevTd.insertBefore(newLine);
}
//012图2中的画线
function DrawLine0121(ojbCurrnetTd,ojbPrevTd)
{
	var a = ojbCurrnetTd.id;	
	var a_array = a.split('_');	
	var b = ojbPrevTd.id;	
	var b_array = b.split('_');	
	var coordinate = (parseInt(a_array[1]) - parseInt(b_array[1])) *31-5;
	var newLine = document.createElement('<v:line from="-4,-10" to="' + coordinate + ',15" strokecolor="#999999" StrokeWeight="1" />');	
	ojbPrevTd.insertBefore(newLine);
}
//和值画线
function DrawLineHz(ojbCurrnetTd,ojbPrevTd)
{  
	var a = parseInt(ojbCurrnetTd.innerText);  
    var b = parseInt(ojbPrevTd.innerText);
     var coordinate = (a - b) *25 -4;    
     var newLine = document.createElement('<v:line from="-4,7" to="'+coordinate+',32" strokecolor="#999999" StrokeWeight="1.0" />');    
    ojbPrevTd.insertBefore(newLine);
}
function DrawLine_Hz(ojbCurrnetTd,ojbPrevTd)
{  
	var a = parseInt(ojbCurrnetTd.innerText);  
    var b = parseInt(ojbPrevTd.innerText);
     var coordinate = (a - b) *22-4;    
     var newLine = document.createElement('<v:line from="-4,7" to="'+coordinate+',32" strokecolor="#999999" StrokeWeight="1.0" />');    
    ojbPrevTd.insertBefore(newLine);
}

//大小奇偶画线
function DrawLineDX(ojbCurrnetTd,ojbPrevTd)
{
	var a = ojbCurrnetTd.id;	
	var a_array = a.split('_');	
	var b = ojbPrevTd.id;	
	var b_array = b.split('_');	
	var coordinate = (parseInt(a_array[1]) - parseInt(b_array[1])) *44-4;
	var newLine = document.createElement('<v:line from="-5,-10" to="' + coordinate + ',15" strokecolor="#999999" StrokeWeight="1.0" />');	
	ojbPrevTd.insertBefore(newLine);
}
//和值中给图片画线的
function DrawLineHzImg(ojbCurrnetTd,ojbPrevTd)
{	
	var a = ojbCurrnetTd.id;	
	var a_array = a.split('_');	
	var b = ojbPrevTd.id;	
	var b_array = b.split('_');	
	var coordinate = (parseInt(a_array[1]) - parseInt(b_array[1])) *33-6;
	var newLine = document.createElement('<v:line from="-6,6" to="' + coordinate + ',32" strokecolor="#999999" StrokeWeight="1.0"/>');	
	ojbPrevTd.insertBefore(newLine);
}
function DrawLineHz_Img(ojbCurrnetTd,ojbPrevTd)
{	
	var a = parseInt(ojbCurrnetTd.innerText);  
    var b = parseInt(ojbPrevTd.innerText);
     var coordinate = (a - b) *22-4;    
     var newLine = document.createElement('<v:line from="-4,7" to="'+coordinate+',35" strokecolor="#999999" StrokeWeight="1.0" />');    
    ojbPrevTd.insertBefore(newLine);
}