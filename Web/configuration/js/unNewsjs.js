<!--
Array.prototype.remove = function(start,deleteCount){
    if(isNaN(start)||start>this.length||deleteCount>(this.length-start)){return false;}
    this.splice(start,deleteCount);
}

function CheckNum(obj){
    if (isNaN(obj.value) || obj.value<=0){
	    alert("您输入的不是正确的行数,\n请输入一个正整数.");
	    obj.value="";
	    obj.focus();
	    }
}
function DisplayUnNews()
{
    var StrUnNewsList="";
    var ListLen=0;
    var Str_tem="";
    var TLPic="";
    var PicInfo="";
    try{
        ListLen=UnNewArray.length;
    }
    catch(e)
    {
        ListLen=0;
    }
    var StrUnNewsListSub="";
    for (var i=0;i<ListLen;i++){
        StrUnNewsList+="<div class=\"ContentDiv\" id=\"Arr"+i+"\"><input name=\"NewsID\" type=\"hidden\" id=\"NewsID_"+i+"\" value=\""+UnNewArray[i][0]+"\" /><a href=\"原新闻标题\" title=\"原新闻标题:"+UnNewArray[i][1]+"\" class=\"list_link\" onclick=\"return false;\">标题</a>：<input title=\"原新闻标题:"+UnNewArray[i][1]+"\" name=\"NewsTitle"+UnNewArray[i][0]+"\" type=\"text\" id=\"NewsTitle_"+i+"\" value=\""+UnNewArray[i][2]+"\" size=\"60\" onkeyup=\"UnNewModify()\" onmousedown=\"new Form.Element.Observer('NewsTitle"+UnNewArray[i][0]+"',1,UnNewModify);\" style=\"height:18px;\" class=\"form\" />&nbsp;放在第<input class=\"Contentform\" name=\"Row"+UnNewArray[i][0]+"\" type=\"text\" id=\"Row_"+i+"\" value=\""+UnNewArray[i][3]+"\" size=\"2\" maxlength=\"2\" onkeyup=\"UnNewModify(this,'')\" onbeforepaste=\"clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''));\" onmousedown=\"new Form.Element.Observer('Row"+UnNewArray[i][0]+"',1,UnNewModify);\" />行&nbsp;<button class=\"Contentform\" onclick=\"UnNewDel("+i+");return false;\">移除</button><input type=\"hidden\"  name=\"NewsTable"+UnNewArray[i][0]+"\" id=\"Table"+i+"\" value=\""+UnNewArray[i][4]+"\" /></div>";
    }
    if (TopLineArray.length>0)
    {
        if (TopLineArray[6]==1)
        {
            Str_tem=" checked=\"checked\"";
            TLPic="";
        }
        else
        {
            Str_tem="";
            TLPic=" style=\"display:none\"";
        }
        PicInfo="字体<select name=\"FontFamily\" id=\"FontFamily\" class=\"form\"></select>\
            样式<select name=\"FontStyle\" id=\"FontStyle\" class=\"form\"></select>\
            字号<input name=\"FontSize\" type=\"text\" id=\"FontSize\" class=\"form\" size=\"3\" maxlength=\"2\" />px&nbsp;&nbsp;\
            字体间距<input name=\"FontCellpadding\" type=\"text\" id=\"FontCellpadding\" class=\"form\" size=\"4\" maxlength=\"3\" />px&nbsp;\
            图片宽度<input name=\"Picwidth\" type=\"text\" id=\"Picwidth\" class=\"form\" size=\"5\" maxlength=\"4\" />px&nbsp;\
            字体颜色<input type=\"hidden\" name=\"FontColor\" id=\"FontColor\" />\
            <img src=\"../../sysImages/blue/admin/Rect.gif\" alt=\"-\" width=\"18\" height=\"17\" border=\"0\" id=\"Img1\" style=\"cursor:pointer;\" title=\"选取字体颜色\" onclick=\"GetColor(this,'FontColor',event);\"/>&nbsp;\
            图片背景色:<input type=\"hidden\" name=\"FontBgColor\" id=\"FontBgColor\" />\
            <img src=\"../../sysImages/blue/admin/Rect.gif\" alt=\"-\" width=\"18\" height=\"17\" border=\"0\" id=\"Img2\" style=\"cursor:pointer;\" title=\"选取图片前景色\" onclick=\"GetColor(this,'Imagesbgcolor',event);\"/>";
        StrUnNewsList="<div class=\"ContentDiv\" id=\"ArrTop\"><input class=\"Contentform\" name=\"TopNewsID\" type=\"hidden\" id=\"NewsID_Top\" value=\""+TopLineArray[0]+"\" /><a href=\"原新闻标题\" title=\"原新闻标题:"+TopLineArray[1]+"\" class=\"list_link\" onclick=\"return false;\">头条新闻</a>：<input class=\"Contentform\" name=\"TopNewsTitle\" type=\"text\" id=\"NewsTitle_Top\" value=\""+TopLineArray[2]+"\" size=\"20\" onkeyup=\"UnNewModify()\" onmousedown=\"new Form.Element.Observer('NewsTitle_Top',1,UnNewModify);\" />&nbsp;<input class=\"Contentform\" name=\"TopRow\" type=\"hidden\" id=\"Row_Top\" value=\"0\" size=\"2\" maxlength=\"2\" />&nbsp;CSS：<input class=\"Contentform\" name=\"TTNewsCSS\" type=\"text\" id=\"TTNewsCSS\" value=\""+TopLineArray[5]+"\" size=\"8\" />&nbsp;是否生成图片<input name=\"IsMakePic\" id=\"IsMakePic\" class=\"Contentform\" onclick=\"if(this.checked){$('TLPic').style.display='';}else{$('TLPic').style.display='none';}\" type=\"checkbox\""+Str_tem+" />&nbsp;<button class=\"Contentform\" onclick=\"UnNewDel(-1)\">移除</button><input type=\"hidden\" name=\"TopNewsTable\" id=\"Table"+i+"\" value=\""+TopLineArray[4]+"\" />&nbsp;<button class=\"Contentform\" onclick=\"UnNewTopLine(-1);return false;\">取消头条</button><div class=\"ContentDiv\" id=\"TLPic\""+TLPic+">"+PicInfo+"</div></div>"+StrUnNewsList;
    }
    document.getElementById("UnNewsList").innerHTML=StrUnNewsList;
}

function UnNewModify(){
    for (var i=0;i<UnNewArray.length;i++){
	    UnNewArray[i][2]=$("NewsTitle_"+i).value;
	    $("Row_"+i).value=$("Row_"+i).value.replace(/[^\d]/g,'');
	    UnNewArray[i][3]=parseInt($("Row_"+i).value);
    }
    if (TopLineArray.length>0)
    {
        TopLineArray[2]=$("NewsTitle_Top").value;
        TopLineArray[3]=0;
        TopLineArray[5]=$("TTNewsCSS").value;
        TopLineArray[6]=$("IsMakePic").value;
    }
    UnNewPreviewCh();
}

function UnNewDel(Row){
    if (confirm("确定移除吗？")){
        if(Row==-1)
        {
            TopLineArray.remove(0,7);
        }
        else
        {
	        UnNewArray.remove(Row,1);
	    }
	    DisplayUnNews();
	    UnNewPreviewCh();
	    window.frames["DisNews"].CheckUnNews();
    }
}
function UnNewTopLine(Rows)
{
    UnNewModify();
    if (Rows==-1)
    {
        var ArrLen=UnNewArray.length;
        UnNewArray[ArrLen]=new Array();
        UnNewArray[ArrLen][0]=TopLineArray[0];
        UnNewArray[ArrLen][1]=TopLineArray[1];
        UnNewArray[ArrLen][2]=TopLineArray[2];
        UnNewArray[ArrLen][3]=ArrLen+1;
        UnNewArray[ArrLen][4]=TopLineArray[4];
        TopLineArray.remove(0,7)
    }
    else
    {
        if (TopLineArray.length>0)
        {
            var Arr_temp=[UnNewArray[Rows][0],UnNewArray[Rows][1],UnNewArray[Rows][2],UnNewArray[Rows][3],UnNewArray[Rows][4]];
            UnNewArray[Rows][0]=TopLineArray[0];
            UnNewArray[Rows][1]=TopLineArray[1];
            UnNewArray[Rows][2]=TopLineArray[2];
            UnNewArray[Rows][3]=Arr_temp[3];
            UnNewArray[Rows][4]=TopLineArray[4];
            TopLineArray[0]=Arr_temp[0];
            TopLineArray[1]=Arr_temp[1];
            TopLineArray[2]=Arr_temp[2];
            TopLineArray[3]=0;
            TopLineArray[4]=Arr_temp[4];
        }
        else
        {
            TopLineArray[0]=UnNewArray[Rows][0];
            TopLineArray[1]=UnNewArray[Rows][1];
            TopLineArray[2]=UnNewArray[Rows][2];
            TopLineArray[3]=0;
            TopLineArray[4]=UnNewArray[Rows][4];
            TopLineArray[5]="";
            TopLineArray[6]=0;
            UnNewArray.remove(Rows,1);
        }
    }
    DisplayUnNews();
    UnNewPreviewCh();
    window.frames["DisNews"].CheckUnNews();
}
function DivCenter(M_div,M_width,M_zindex)
{
    var xposition=0,yposition=0;
    $(M_div).style.position='absolute';
    $(M_div).style.width=M_width.toString(10)+'px';
    $(M_div).style.zIndex=M_zindex.toString(10);
    if (parseInt(navigator.appVersion) >= 4 )
    {
        var dimensions = Element.getDimensions($(M_div));
	    xposition = (document.body.offsetWidth - dimensions.width) / 2;
	    yposition = (400 - dimensions.height) / 2;
	    $(M_div).style.left=xposition.toString(10)+"px";
	    $(M_div).style.top=(yposition).toString(10)+"px";
    }
}

function UnNewPreviewCh(){
    if ($("preview").style.display==""){
	    UnNewPreview();
    }
}
function UnNewPreview(){
    var ListLen=UnNewArray.length;
    var Maxrow=1;
    var PreviewStr="";
    var PreviewRowStr="";
    var For_string="";
    for (var i=0;i<ListLen;i++){
	    if (UnNewArray[i][3]>Maxrow){
		    Maxrow=UnNewArray[i][3];
	    }
    }
    PreviewStr="<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
    for (i=1;i<=Maxrow;i++){
	    FindFlag="";
	    PreviewRowStr="";
	    for (var j=0;j<ListLen;j++){
		    if (UnNewArray[j][3]==i){
			    if (FindFlag==""){
				    FindFlag=j.toString(10);
			    }else{
				    FindFlag+=","+j;
			    }
		    }
	    }
		
	    PreviewStr+="<tr><td>";
	    if (FindFlag){
		    PreviewRowStr=FindFlag.split(",");
		    for (var j=0;j<PreviewRowStr.length;j++){
		        For_string="<a class=\"list_link\" href=\""+UnNewArray[PreviewRowStr[j]][2]+"\" onclick=\"return false;\">"+UnNewArray[PreviewRowStr[j]][2]+"</a>";
			    if (j==0){
				    PreviewStr+=For_string;
			    }else{
				    PreviewStr+="&nbsp;"+For_string;
			    }
		    }
	    }else{
		    PreviewStr+="&nbsp;";
	    }
	    PreviewStr+="</td></tr>";
    }
    if (TopLineArray.length>0)
    {
        PreviewStr="<tr>\
				        <td><a class=\""+TopLineArray[5]+"\" href=\""+TopLineArray[2]+"\" onclick=\"return false;\">"+TopLineArray[2]+"</a></td>\
			        </tr>"+PreviewStr;
	}
    PreviewStr+="</table>";
	
    if ($("preview").style.display=="none"){
	    $("preview").style.display="";
	    DivCenter("preview",700,100);
    }
    $("PreviewContent").innerHTML=PreviewStr;
    if (ListLen<=0 && TopLineArray.length<=0)
    {
        $('preview').style.display='none';
    }
}
function UnNewcheck()
 {
    if(document.getElementById("unName").value=="")
    {
	    alert("\n 请填写不规则新闻标题!");
	    document.getElementById("unName").focus();
	    return false;
    }
    var ListLen=UnNewArray.length;
    var Maxrow=0;
    var ErrStr="";
    for (var i=0;i<ListLen;i++){
	    if (UnNewArray[i][3]==0){
		    ErrStr=" -第 "+(i+1)+"条 存放行数不能为 0";
	    }
	    if (isNaN(UnNewArray[i][3])){
		    ErrStr=" -第 "+(i+1)+"条 存放行数不能为空";
	    }
	    if (UnNewArray[i][2]==""){
		    ErrStr=" -第 "+(i+1)+"条 不规则标题不能为空";
	    }
	    if (UnNewArray[i][3]>Maxrow){
		    Maxrow=UnNewArray[i][3];
	    }
    }
    var FindFlag=false;
    for (i=1;i<=Maxrow;i++){
	    FindFlag=false;
	    for (var j=0;j<ListLen;j++){
		    if (UnNewArray[j][3]==i){
			    FindFlag=true;
			    break;
		    }
	    }
	    if (!FindFlag){
		    ErrStr+="\n -第 "+i+" 行中没有新闻";
	    }
    }
    if (Maxrow==0 && TopLineArray.length==0)
    {
        ErrStr+="\n -还没有加入新闻";
    }
    if (ErrStr){
	    alert("发生以下错误：\n"+ErrStr);
	    return false;
    }else{
	    return true;
    }
}
window.onload=DisplayUnNews;
-->


