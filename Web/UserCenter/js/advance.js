    function LoadReg() {  
        var height = parseInt(document.body.clientHeight)-80;   
         if (confirm('只有高级用户才能使用此项功能，现在申请吗？')==true)
         {
             //$.blockUI({ message: $('#dvRealInfo'), css: {top: ($(window).height() - 660) /2 + 'px', left: ($(window).width() - 830) /2 + 'px', width: '832px' },allowBodyStretch: true }); 
            var result =  window.showModalDialog('/UserCenter/UserRealInfo.aspx','','dialogHeight:'+height+'px;dialogWidth:830px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
            if(result == 'close')
            {
                top.location="/UserCenter/User_Center.aspx";
            }            
         }
         else
         {
               top.location="/UserCenter/User_Center.aspx";
         } 
    }
    
   function LoadRegNo() {  
        var height = parseInt(document.body.clientHeight)-80;           
         //$.blockUI({ message: $('#dvRealInfo'), css: {top: ($(window).height() - 660) /2 + 'px', left: ($(window).width() - 830) /2 + 'px', width: '832px' },allowBodyStretch: true }); 
        var result =  window.showModalDialog('/UserCenter/UserRealInfo.aspx','','dialogHeight:'+height+'px;dialogWidth:830px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
        top.location="/UserCenter/User_Center.aspx";
        
    }
    
    
     function LoadRegYE() {  
        var height = parseInt(document.body.clientHeight)-80;   
         if (confirm('只有高级用户才能使用此项功能，现在申请吗？')==true)
         {
             //$.blockUI({ message: $('#dvRealInfo'), css: {top: ($(window).height() - 660) /2 + 'px', left: ($(window).width() - 830) /2 + 'px', width: '832px' },allowBodyStretch: true }); 
            var result =  window.showModalDialog('/UserCenter/UserRealInfo.aspx','','dialogHeight:'+height+'px;dialogWidth:830px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
            if(result == 'close')
            {
                //top.location="/UserCenter/User_Center.aspx";
            }            
         }
         else
         {
               //top.location="/UserCenter/User_Center.aspx";
         } 
    }
    
    
    
function AllChecked()
{
 $("input[name=sel]").each(function(){ $(this).attr("checked",true);});
   
//  var obj = document.form1.sel;
//	if(obj != null)
//	{
//		if(obj.length == undefined)
//		{
//			obj.checked = true;
//		}
//		else
//		{
//			for(var ii=0; ii < obj.length; ii++)
//			{
//				obj[ii].checked = true;
//			}
//		}
//	}
}
function UnAllChecked()
{
 $("input[name=sel]").each(function(){ $(this).attr("checked",false);});
//    var obj = document.form1.sel;
//	if(obj != null)
//	{
//		if(obj.length == undefined)
//		{
//			obj.checked = true;
//		}
//		else
//		{
//			for(var ii=0; ii < obj.length; ii++)
//			{
//				obj[ii].checked = false;
//			}
//		}
//	}
}

function CheckBatchUpdate(opera)
{
    var obj = document.form1.sel;
	if(obj == null)
	{
	    alert("没有记录，无法批量"+opera+"！");
	    return false;
	}
	else if(obj.length == undefined || obj.length < 1)
	{
	    alert("您没有选中任何记录，无法批量"+opera+"！");
	    return false;
	}
	else
	{
	    return Confirm("您确定要批量"+opera+"选中数据吗？");
	}	
}