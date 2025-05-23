/*
Version Number:    V-20100127-L1
*/
(function($){
$.extend($.browser,{
client:function(){return{width:document.documentElement.clientWidth,height:document.documentElement.clientHeight,bodyWidth:document.body.clientWidth,bodyHeight:document.body.clientHeight};},
scroll:function(){return{width:document.documentElement.scrollWidth,height:document.documentElement.scrollHeight,bodyWidth:document.body.scrollWidth,bodyHeight:document.body.scrollHeight,left:document.documentElement.scrollLeft,top:document.documentElement.scrollTop};},
screen:function(){return{width:window.screen.width,height:window.screen.height};},
isIE6:$.browser.msie&&$.browser.version==6,
isMinW:function(val){return Math.min($.browser.client().bodyWidth,$.browser.client().width)<=val;},
isMinH:function(val){return $.browser.client().height<=val;}});
$.widthForIE6=function(option){
var s=$.extend({max:null,min:null,padding:0},option||{});
var init=function(){
var w=$(document.body);
if($.browser.client().width>=s.max+s.padding){w.width(s.max+"px");}
else if($.browser.client().width<=s.min+s.padding){w.width(s.min+"px");}
else{w.width("auto");}}
init();$(window).resize(init);}
$.fn.hoverForIE6=function(option){
var s=$.extend({
current:"hover"},option||{});
var obj=this;
$.each(this,function(){
$(this).bind("mouseover",function(){
$(this).addClass(s.current);}).bind("mouseleave",function(){
$(this).removeClass(s.current);})})}
$.fn.jdSonny=function(option,callback){
var s=$.extend({current:"curr",delay:100,timer:null,index:null},option||{});
var obj=this;
$.each(this,function(n){
$(this).bind("mouseover",function(){
if(s.timer!=null)clearTimeout(s.timer);
s.index=(s.index==null)?0:s.index;
s.timer=setTimeout(function(){obj.eq(s.index).removeClass(s.current);s.index=n;obj.eq(s.index).addClass(s.current);},s.delay);})})}
$.fn.jdTab=function(option,callback){
$.each(this,function(){
var s=$.extend({event:"mouseover",delay:100,current:"curr",dom:"ul > li > a".split(" > "),attr:"href",timer:null,index:null},option||{});
var child1=$(this).find(s.dom[1]),child2=$(this).find(s.dom[2]),content=[];
child2.each(function(){
content.push($($(this).attr(s.attr)));});
child2.each(function(n){
if(s.action!="click"){$(this).click(function(){return false;})}
$(this).bind(s.event,function(){
clearTimeout(s.timer);
s.index=(s.index==null)?0:s.index;
s.timer=setTimeout(function(){child1.eq(s.index).removeClass(s.current);content[s.index].hide();s.index=n;child1.eq(s.index).addClass(s.current);content[s.index].show();},s.delay);})})})}})(jQuery);
(function($) {
    $.extend({
        _jsonp: {
            scripts: {},
            //charset: 'utf-8',
            counter: 1,
            head: document.getElementsByTagName("head")[0],
            name: function(callback) {
                var name = '_jsonp_' + (new Date).getTime() + '_' + this.counter;
                this.counter++;
                var cb = function(json) {
                    eval('delete ' + name);
                    callback(json);
                    $._jsonp.head.removeChild($._jsonp.scripts[name]);
                    delete $._jsonp.scripts[name];
                };
                eval(name + ' = cb');
                return name;
            },
            load: function(url, name) {
                var script = document.createElement('script');
                script.type = 'text/javascript';
                script.charset = this.charset;
                script.src = url;
                this.head.appendChild(script);
                this.scripts[name] = script;
            }
        },

        getJSONP: function(url, callback) {
            var name = $._jsonp.name(callback);
            var url = url.replace(/{callback}/, name);
            $._jsonp.load(url, name);
            return this;
        }
    });
})(jQuery);


var initScrollY=0;
var proIDs=new Array();
function compare(){
if($("#compare").get(0)==null){
$("body").append("<div id='compare'><h6><a title='清空' class='close' onclick='clearCompare()'></a>商品比较</h6><div class='comPro'><ul id='comProlist'></ul><img src='http://www.360buy.com/images/compare_15.gif' id='compareImg' onclick='openCompare()'/></div></div>")
$("#compare").css({position:"absolute",top:"220px",right:"0px"});
isCoo();}
if($.browser.msie){
var defaultY=document.documentElement.scrollTop;
var perceH=0.3*(defaultY-initScrollY);
if(perceH>0){perceH=Math.ceil(perceH);}
else{perceH=Math.floor(perceH);}
$("#compare").get(0).style.top=parseInt($("#compare").get(0).style.top)+perceH+"px";
initScrollY=initScrollY+perceH;
setTimeout("compare()",50)}else{
window.onscroll=function(){
$("#compare").get(0).style.top=parseInt($("#compare").get(0).style.top)+"px";
$("#compare").get(0).style.position="fixed";}}}
function clearCompare(){
$("#comProlist").empty();
$("#compare").hide();
createCookie("compare","");
proIDs=new Array();}
function addToCompare(checkobj,checkid,checkProName){
$("#compare").show();
$(".comPro").show();
var proIDsTemp=proIDs.join(".");
if(proIDsTemp.indexOf(checkid)==-1){
if(proIDs.length<3){
proIDs.push(checkid);
$("#comProlist").append("<li id='check_"+checkid+"'><a title='删除' class='close' onclick='reduceCompare("+checkid+")'></a>"+checkProName+"</li>");
writeCompare(checkid,checkProName);}else{
alert("对不起，最多可以选择三种商品进行对比！");}}else{
alert("对不起，您已经选择此商品！");
return;}}
function reduceCompare(checkid){
$("#check_"+checkid).remove();
$.each(proIDs,function(i,n){
if(checkid==n){
proIDs.splice(i,1);}});
var coo=readCookie("compare");
var idindexstart=coo.indexOf(checkid);
var idindexend=coo.indexOf("|||",idindexstart)+3;
var delStr=coo.substring(idindexstart,idindexend);
var innerStr=coo.replace(delStr,"")
createCookie("compare",innerStr);
if(proIDs.length==0){$(".comPro").hide();}}
function openCompare(){
switch(proIDs.length){
case 1:
alert("对不起，最少选择两种商品进行对比！");
break;
case 2:
window.open("http://www.360buy.com/pcompare.aspx?s1="+proIDs[0]+"&s2="+proIDs[1]);
break;
case 3:
window.open("http://www.360buy.com/pcompare.aspx?s1="+proIDs[0]+"&s2="+proIDs[1]+"&s3="+proIDs[2]);
break;
default:
alert("请选择2-3件商品进行对比！");
return;}}
function writeCompare(checkid,checkProName){
var compareList=readCookie("compare");
if(compareList==null){compareList="";}
compareList+=checkid+"||"+escape(checkProName)+"|||";
createCookie("compare",compareList);}
function isCoo(){
var coo=readCookie("compare");
if(coo){
var cootemp=coo.split("|||");
var compareListTemp="";
for(var i=0;i<cootemp.length-1;i++){
compareListTemp+="<li id='check_"+cootemp[i].split("||")[0]+"'><a title='删除' class='close' onclick='reduceCompare("+cootemp[i].split("||")[0]+")'></a>"+unescape(cootemp[i].split("||")[1])+"</li>";
proIDs.push(cootemp[i].split("||")[0]);}
$("#comProlist").html(compareListTemp);
$("#compare").show();
$(".comPro").show();}}
function createCookie(name,value,days,Tdom){
var Tdom=(Tdom)?Tdom:"/";
if(days){
var date=new Date();
date.setTime(date.getTime()+(days*24*60*60*1000));
var expires="; expires="+date.toGMTString();}else{
var expires="";}
document.cookie=name+"="+value+expires+"; path="+Tdom;}
function readCookie(name){
var nameEQ=name+"=";
var ca=document.cookie.split(';');
for(var i=0;i<ca.length;i++){
var c=ca[i];
while(c.charAt(0)==' '){c=c.substring(1,c.length);}
if(c.indexOf(nameEQ)==0){return c.substring(nameEQ.length,c.length);}}
return null;}
var timera=null;
var tag=1;
var Stag="stop";
var marqueeHeight;
var maxTop;
var minTop;
var marqueeObj;
var dpps;
var originalObj;
var cloneObj;
function marquee(Mtimes,mH,dP){
marqueeHeight=mH;
dpps=dP;
clearTimeout(timera);
Mtimes=Mtimes?Mtimes:2;
marqueeObj=document.getElementById("NewProduct").getElementsByTagName("ul");
maxTop=-marqueeHeight*Mtimes;
minTop=marqueeHeight*Mtimes;
if(marqueeObj.length==1){
originalObj=marqueeObj[0];
cloneObj=originalObj.cloneNode(true);
originalObj.parentNode.appendChild(cloneObj);
marqueeObj[0].style.top=0+"px";
marqueeObj[1].style.top=minTop+"px";}
if((tag==0&&marqueeObj[0].offsetTop==0)||marqueeObj[0].offsetTop/tag==-marqueeHeight){
tag++;
Stag="stop";
clearTimeout(timera);
timera=setTimeout("marquee("+Mtimes+","+mH+","+dP+")",5000);}else{
Stag="continue";
marqueeObj[0].style.top=marqueeObj[0].offsetTop-dpps+"px"
marqueeObj[1].style.top=marqueeObj[1].offsetTop-dpps+"px"
if(marqueeObj[0].offsetTop==maxTop){
marqueeObj[0].style.top=minTop+"px";
tag=-Mtimes;;}
if(marqueeObj[1].offsetTop==maxTop){
marqueeObj[1].style.top=minTop+"px";}
timera=setTimeout("marquee("+Mtimes+","+mH+","+dP+")",30)}}
function SwitchTab(IDprefix,order,TagAmount,status){
switch(status){
case "S1":
var TagObj=OOO(IDprefix+"Option","li");
var TagArr=new Array();
for(var i=0;i<TagObj.length;i++){
TagArr.push(TagObj[i].id.split("_Option_")[1]);}
for(var i=0;i<TagArr.length;i++){
OOO(IDprefix+"Option_"+TagArr[i]).className=(TagArr[i]==order)?"curr":"";
OOO(IDprefix+"Con_"+TagArr[i]).style.display=(TagArr[i]==order)?"":"none";}
break;
default:
for(var i=0;i<TagAmount;i++){
OOO(IDprefix+"Option_"+i).className=(i==order)?"curr":"";
OOO(IDprefix+"Con_"+i).className=(i==order)?"default":"disNone";}
return;}}
function showSort(obj){
$("#"+obj+" h3").click(function(){
this.className=(this.className=="open")?"":"open";
$("#EFF_ul_"+this.id.substr(7)).get(0).className=(this.className=="open")?"open":"";});}
function OOO(obj,ele){
if(obj&&!ele){return document.getElementById(obj);}
else if(obj&&ele){return document.getElementById(obj).getElementsByTagName(ele);}
else{return false;}}
var Dtimer=null;
var Dtimer2=null;
var Mdisplay=false;
var hideDiv;
var Container;
var button;
var jqShowObj;
var offset;
var height;
var width;
var btnHeight;
var btnWidth;
function initDMenu(obj,showobj,Dtimeout,Dspeed){
hideDiv=$("<div style='z-index:10000;'></div>");
Container=$("<div id=\"Container\"></div>");
hideDiv.append(Container);
button=$(obj);
jqShowObj=$(showobj);
offset=button.offset();
height=jqShowObj.height();
width=jqShowObj.width();
btnHeight=button.height();
btnWidth=button.width();
$(document.body).prepend(hideDiv);}







function showDMenu(){

if(Mdisplay==true){
    return false;}
else{
Mdisplay=true;
Container.css({margin:"0 auto",width:btnWidth+"px",height:btnHeight+"px"});
hideDiv.css({position:"absolute",top:offset.top+16+"px",left:button.offset().left-35+"px",height:height+"px",width:width+"px"}).show();
Container.css({border:"1px solid #666666"});
Container.animate({marginTop:10,height:height+4,width:width+4,opacity:'100'},100,function(){
jqShowObj.show();
Container.append(jqShowObj);
Container.css({border:"0px"});
jqShowObj.mouseover(function(){
clearTimeout(Dtimer);clearTimeout(Dtimer2);}).mouseout(function(){
hideDMenu();});});
    }

}


function hideDMenu(){

clearTimeout(Dtimer);
clearTimeout(Dtimer2);
Dtimer=setTimeout(function(){

Container.css({border:"1px solid #666666"});
$(document.body).prepend(jqShowObj);
jqShowObj.hide();
Container.empty();
Container.animate({width:btnWidth,height:btnHeight,marginTop:'0',opacity:'0'},100,function(){
Container.hide();
hideDiv.hide();

Mdisplay=false;});},100);


}


var display=false;
var display2=false;
var display3=false;
function showTip(proobj){
var TipDivW=$(proobj).width();
var TipDivH=$(proobj).height();
var TipDiv=$("<div id='c01tip' style='z-index:20000;position:absolute;width:"+eval(TipDivW+5)+"px;height:"+eval(TipDivH+5)+"px;'><div style='position:absolute;margin:5px 0 0 5px;width:"+TipDivW+"px;height:"+TipDivH+"px;background:#BCBEC0;z-index:20001;'></div></div>")
if(display==false){
TipDiv.append($(proobj));
$(document.body).prepend(TipDiv);
$(proobj).show();
display=true;}else{
$("#c01tip").show();}
$("#c01tip").css({top:parseInt(document.documentElement.scrollTop+(document.documentElement.clientHeight-$("#c01tip").height())/2 )+"px",left:(document.documentElement.clientWidth-$("#c01tip").width())/2+"px"})
$("#Tip_viewCart,#Tip_continue,.Tip_Close").click(function(){
$("#c01tip").fadeOut();});}
function showTip2(proobj){
var TipDivW=$(proobj).width();
var TipDivH=$(proobj).height();
var TipDiv=$("<div id='c02tip' style='z-index:20000;position:absolute;width:"+eval(TipDivW+5)+"px;height:"+eval(TipDivH+5)+"px;'><div style='position:absolute;margin:5px 0 0 5px;width:"+TipDivW+"px;height:"+TipDivH+"px;background:#BCBEC0;z-index:20001;'></div></div>")
if(display2==false){
TipDiv.append($(proobj));
$(document.body).prepend(TipDiv);
$(proobj).show();
display2=true;}else{
$("#c02tip").show();}
$("#c02tip").css({top:parseInt(document.documentElement.scrollTop+(document.documentElement.clientHeight-$("#c02tip").height())/2 )+"px",left:(document.documentElement.clientWidth-$("#c02tip").width())/2+"px"})
$(".Tip_Close").click(function(){
$("#c02tip").fadeOut();});
timer_5=setTimeout("showTime()",1000);}
function showTip3(proobj){
var TipDivW=$(proobj).width();
var TipDivH=$(proobj).height();
var TipDiv=$("<div id='c03tip' style='z-index:20000;position:absolute;width:"+eval(TipDivW+5)+"px;height:"+eval(TipDivH+5)+"px;'><div style='position:absolute;margin:5px 0 0 5px;width:"+TipDivW+"px;height:"+TipDivH+"px;background:#BCBEC0;z-index:20001;'></div></div>")
if(display3==false){
TipDiv.append($(proobj));
$(document.body).prepend(TipDiv);
$(proobj).show();
display3=true;}else{
$("#c03tip").show();}
$("#c03tip").css({top:parseInt(document.documentElement.scrollTop+(document.documentElement.clientHeight-$("#c03tip").height())/2 )+"px",left:(document.documentElement.clientWidth-$("#c03tip").width())/2+"px"})
$("#Tip_notice,.Tip_Close").click(function(){
$("#c03tip").fadeOut();});}
function showTime(){
clearTimeout(timer_5);
var overtime=parseInt($("#timer_5").html())-1;
if(overtime==0){
$("#c02tip").fadeOut();
return;}
$("#timer_5").html(overtime);
timer_5=setTimeout("showTime()",1000)}
function showNotice(obj,noticetype,offX,offY){
var noticeX=$(obj).offset().left;
var noticeT=$(obj).offset().top;
var noticeW=$(obj).width();
var noticeH=$(obj).height();
var offX=(!offX)?60:offX;
var offY=(!offY)?2:offY;
if($("#"+noticetype).get(0)==null){
var newNotice=document.createElement("span");
$(newNotice).attr("id",noticetype)
$(newNotice).css({position:"absolute",top:noticeT+noticeH+offY+"px",left:noticeX-offX+"px",background:"#FFF9D9","z-index":"50000",padding:"5px",border:"1px solid #F88E00"});
$(document.body).prepend($(newNotice));
$(newNotice).html(obj.name);}else{
$("#"+noticetype).css({top:noticeT+noticeH+offY+"px",left:noticeX-offX+"px"});
$("#"+noticetype).show();}}
function opennewWin(url,newwinT,newwinW,newwinH){
window.open(url,newwinT,"width="+newwinW+",height="+newwinH+",toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no");}
function defineW(i){
if($("#suitP"+i).width()>$("#suitPWrap"+i).width()){
$("#suitPWrap"+i).get(0).style.overflowX="scroll";}
var suitW=(Swidth>=1280)?708:472;
if($("#suitP"+i).width()<suitW){
$("#suitPWrap"+i).get(0).style.width=$("#suitP"+i).width()+"px";}}
function buyFitting(obj){
var newHref=obj.href;
obj.getElementsByTagName("img")[0].src="http://www.360buy.com/images/appendToCart_4.gif";
obj.parentNode.innerHTML=obj.innerHTML;
if($.browser.msie){
window.open(newHref);
return false;}}
function gotop(){
window.onscroll=function(){
if(document.documentElement.scrollTop==0&&document.body.scrollTop==0){
$("#gotop").get(0).style.display="none";}else{
$("#gotop").get(0).style.display="";
if($.browser.msie&&$.browser.version<"7.0"){
$("#gotop").get(0).style.position="absolute";
$("#gotop").get(0).style.top=getPosition(180);}}}}
function getPosition(currObjH){
return document.documentElement.scrollTop+document.documentElement.clientHeight-currObjH+"px";}
$(function(){
$("#My360buy,#ServiceCenter").mouseover(function(){
this.className="dis";}).bind("mouseleave",function(){
this.className="";})
$("#Nav li").click(function(){
$(this).siblings().removeClass("curr");
this.className="curr";});


initDMenu("#CartSwitch_wrap","#MyCart");

$("#CartSwitch_wrap").mouseover(function(){

clearTimeout(Dtimer);



Dtimer=setTimeout("showDMenu()",100);

}).bind("mouseleave",function(){

clearTimeout(Dtimer);


if(Mdisplay==true){Dtimer2=setTimeout("hideDMenu()",100);}
    
    });
    
    
    })


function ResumeError(){return true;}
window.onerror=ResumeError;
if($.browser.msie&&$.browser.version<"7.0"){
try{document.execCommand("BackgroundImageCache",false,true);}
catch(err){}}
/*shipmentbar*/
var serverPage='http://jd2008.360buy.com/Service/ShipmentBarService.aspx';
var ShipmentBarPanel='shipBarPanel';
var ShipM_wait='请等待...';
var ShipM_template="<a style='font-size: 10px; position: absolute; right: 5px; top: 0pt;cursor: pointer;' onclick='CloseObject(this)'>关闭</a><div style='padding:5px 10px;'>";
ShipM_template+="<div id='sb_area'>送货至：<span id='sb_area_level0'>{ddlAreaLevel0}</span>&nbsp;&nbsp;<span id='sb_area_level1'>{ddlAreaLevel1}</span>&nbsp;&nbsp;<span id='sb_area_level2'>{ddlAreaLevel2}</span></div>";
ShipM_template+="<div id='sb_shipItems'></div>";
ShipM_template+="</div>";
var ShipM_template_ship="<table cellspacing='0' width='100%' style='margin-top: 8px;'><tr  style='color: rgb(153, 153, 153);'><td  align='left' style='border-bottom: 1px solid rgb(221, 229, 239); width: 180px;'>配送方式</td><td style='border-bottom: 1px solid rgb(221, 229, 239); width: 100px;'>运费</td><td  style='border-bottom: 1px solid rgb(221, 229, 239);'>预计送达时间</td></tr>";
ShipM_template_ship+="{Items}</table><div style='margin-top: 5px;'>{message}</div>";
var ShipM_template_shipItem="<tr><td><b>{Name}</b></td><td>{Fee}</td><td>{Days}</td></tr>";
var ShipmentBar_skuId=0;
function g(nodeId){
return document.getElementById(nodeId);}
function CloseObject(target){
var shipBarPanel=g(ShipmentBarPanel);
if(shipBarPanel){
shipBarPanel.style.display="none";}}
function AjaxRequestJson(){
this.url='';
this.param='';
this.process=function(){
var js=document.createElement('script');
js.type='text/javascript';
js.src='http://jd2008.360buy.com/Service/ShipmentBarService.aspx?roid='+Math.random()+'&'+this.param;
js.charset='GB2312';
document.getElementsByTagName('head')[0].appendChild(js);}}
function ShipmentBarDt(){
this.skuId=0;
this.show=function(){
ShipmentBar_skuId=this.skuId;
g(ShipmentBarPanel).innerHTML='请等待...';
var a=new AjaxRequestJson();
a.url=serverPage;
a.param='action=showShipmentBar&skuId='+this.skuId+'&callBack=ShipmentBarDt_callBack({obj})';
a.process();}}
function ShipmentBarDt_callBack(obj){
var html=ShipM_template.replace(/{ddlAreaLevel0}/i,showAreaSelectDt(0,obj));
html=html.replace(/{ddlAreaLevel1}/i,showAreaSelectDt(1,null));
html=html.replace(/{ddlAreaLevel2}/i,showAreaSelectDt(2,null));
g(ShipmentBarPanel).innerHTML=html;}
function showShipBarDt(skuId){
var shipBarPanel=g(ShipmentBarPanel);
if(shipBarPanel&&shipBarPanel.style.display=="none"){
shipBarPanel.style.display="";}
var s=new ShipmentBarDt();
s.skuId=skuId;
s.show();}
function showAreaSelectDt(level,obj){
var _w_=0;
if(screen.width>=1280){_w_=(level==2)?140:100;}
else{_w_=(level==2)?100:80;}
var html="<select id='sb_area_select"+level+"' onchange=\"selectAreaDt('" + level + "',this.value);\" style=\"width:"+_w_+"px;\">";
html+="<option value='-1'>请选择</option>";
if(obj!=null){
if(obj.json!=null){obj=obj.json;}
for(var i=0;i<obj.length;i++){
html+="<option value='"+obj[i].Id+"'>"+obj[i].Name
if(obj[i].IsCod=='1'){
html+="*";}
html+="</option>";}}
html+="</select>";
return html;}
function selectAreaDt(level,idArea){
if(level<2){
if(idArea<0){
selectAreaDt_callback(++level,null);}else{
var pLevel=++level;
var a=new AjaxRequestJson();
a.url=serverPage;
a.param="action=selectArea&parentId="+idArea+"&level="+pLevel+"&provinceId="+g('sb_area_select0').value+"&callBack=selectAreaDt_callback('"+pLevel+"',{obj})";
a.process();}
while(level<2){
level++;
selectAreaDt_callback(level,null);}
g('sb_shipItems').innerHTML='';}else{
showShipmentTypesDt(ShipmentBar_skuId);}}
function selectAreaDt_callback(level,obj){
g('sb_area_level'+level).innerHTML=showAreaSelectDt(level,obj);
g('sb_shipItems').innerHTML="<div style=\"margin:5px 0pt 0pt 54px;\">加“*”号地区支持货到付款</div>";}
var DeliverExpectList={
getChilds:function(obj){
var childs=[];
var child;
if(obj&&obj.childNodes){
for(i=0;i<obj.childNodes.length;i++){
if(obj.childNodes[i].nodeName=="#text"){
continue;}
child=obj.childNodes[i];
childs.push(child);}}
return childs;},
getChildsValueByAttribute:function(obj,attributeName){
var returnValue=[];
var tempValue=[];
var childs=this.getChilds(obj);
if(childs&&childs.length>0){
for(var i=0;i<childs.length;i++){
if(childs[i]&&childs[i].getAttribute(attributeName)&&childs[i].parentNode.tagName.toLowerCase()=="li"&&childs[i].tagName.toLowerCase()=="a"){
returnValue.push(childs[i]);}
else{
tempValue=this.getChildsValueByAttribute(childs[i],attributeName);
for(var j=0;j<tempValue.length;j++){
returnValue.push(tempValue[j]);}}}}
return returnValue;}};
function showShipmentTypesDt(skuId){
var Infos="";
var Product_Intro_Right=g("Product_Intro_Right");
if(Product_Intro_Right&&Product_Intro_Right.childNodes[0]&&Product_Intro_Right.childNodes[0].tagName.toLowerCase()=="ul"){
var AContents=DeliverExpectList.getChildsValueByAttribute(Product_Intro_Right.childNodes[0],"name");
if(AContents){
for(var i=0;i<AContents.length;i++){
Infos+=AContents[i].innerHTML.replace(/<.*?>/ig,"");}}}
var idArea=g('sb_area_select2').value;
if(idArea<0){g('sb_shipItems').innerHTML='';return;}
var idProvince=g('sb_area_select0').value;
var idCity=g('sb_area_select1').value;
var a=new AjaxRequestJson();
a.url=serverPage;
a.param="action=showShipmentTypes&idArea="+idArea+"&idProvince="+idProvince+"&idCity="+idCity+"&skuId="+skuId+"&stockStatus="+Infos+"&callBack=showShipmentTypesDt_callback({obj})";
a.process();
g('sb_shipItems').innerHTML=ShipM_wait;}
function showShipmentTypesDt_callback(obj){
var message="";
var html="";
if(obj!=null){
if(obj.json!=null){obj=obj.json;}
for(var i=0;i<obj.length;i++){
if(obj[i].Id=="-1"){
if(obj[i].Name=="djd"&&message.indexOf("此商品属于大家电，只能选择“京东快递”或是“快递运输”;")==-1){
message+="此商品属于大家电，只能选择“京东快递”或是“快递运输”;";}
if(obj[i].Name=="weight"){
message += "此商品重量大于10公斤，不适用于<a style='color:#0000A0;' target=\"_blank\" href=\"http://www.360buy.com/help/kdexpress.aspx#kdmyf\">免运费规则</a>，请您谅解;";}
if(i<obj.length){
message+="<br/>";}
continue;}
html+=ShipM_template_shipItem;
html=html.replace(/{Name}/i,obj[i].Name);
if(obj[i].Fee=="0.00")
html=html.replace(/{Fee}/i,obj[i].Fee+"<span style='color: red;'>(免运费)</span>");
else
html=html.replace(/{Fee}/i,obj[i].Fee);
html=html.replace(/{Days}/i,obj[i].Days);}}
g('sb_shipItems').innerHTML=ShipM_template_ship.replace(/{Items}/i,html).replace(/{message}/i,"<p style='color: red;'> 提示:</p><p>"+message+"该运费只适用于当前商品，购买多个商品以最终下单为准。</p>");}