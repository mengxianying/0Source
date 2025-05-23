    function   killErrors()   
    {   
       return  true;   
    }         
    function myTanChuang1(msg,myWidth,myCallBack)
    {
       $('#dialog1').html('<p>'+msg+'</p>');      
       $('#dialog1').dialog({autoOpen: false,width: myWidth, buttons: { '确定':function() {$(this).dialog('close'); } } });$('#dialog1').dialog('open');
    }
    
	$(function() {		
			
		var name = $("#txtUsername"),
			Code = $("#txtCode"),
			password = $("#txtPassword"),
			allFields = $([]).add(name).add(Code).add(password),
			tips = $("#validateTips");

		function updateTips(t) {
			tips.text(t).effect("highlight",{},3500);
		}

		function checkLength(o,n) {
			if ( o.val().length  < 1 ) {
				o.addClass('ui-state-error');
				updateTips( n + "不能为空！.");
				return false;
			} else {
				return true;
			}
		}	
            $(document).ready(function() {  
            	$.get("/reg.aspx",{IsLogin:"islogin"},function(data)
                {
                    if(data.split('&')[0] == "true")
                    {
                        $("#spUser").text("欢迎您："+data.split('&')[1]+" |");
                        $("#aloginShow").hide();
                        $("#spUser").show();
                        $("#userCenter").show();
                        $("#aLoginOut").show();
                        $("#aNewUserReg").hide();                                                                    
                         if(parseInt(data.split('&')[2]) > 0)
                         {                  
                            $("#spMessage").html("收信箱 (<font color='red'>"+data.split('&')[2]+"</font>) ");//<img src='/images/web/m_news.gif' alt='未读' border='0' />
                         }
                         else
                         {                                              
                            $("#spMessage").html("收信箱 (0)");//<img src='/images/web/m_olds.gif' alt='已读' border='0' />
                         }
                    }
                    else
                    {
                        $("#aLoginOut").hide();
                        $("#spUser").hide();
                        $("#userCenter").hide();
                        $("#aloginShow").show();
                        $("#aNewUserReg").show();       
                    }
                });
                        
                $('#aloginShow').click(function() { 
                           $("#imgOKH").hide();
                           $("#imgErrorH").hide();                            
                           password.val('');
                           Code.val('');
                           $('#imgVerify').attr("src",$('#imgVerify').attr("src")+'?'); 
                    $.blockUI({ message: $('#divLogin'), css: { width: '350px' } }); 
                }); 
                        		
                $('#btnLogin').click(function() {                           
                           var bValid = true;
					        allFields.removeClass('ui-state-error');
					        bValid = bValid && checkLength(name,"用户名");
			    	        bValid = bValid && checkLength(password,"密码");
					        bValid = bValid && checkLength(Code,"验证码");
        																			
			            if (bValid) {                
                           var stateTime  = '0';
                        
                           if($("#cbState").attr("checked")== true)
                           {
                                 stateTime='3';  
                           }
                           else
                           {
                                 stateTime='0';
                           }                                               
                            $.ajax({ 
                                type:'POST',
                                url: '/reg.aspx', 
                                data:'uName='+escape(name.val())+'&uPwd='+escape(password.val())+'&uCode='+Code.val()+'&uTime='+stateTime,
                                cache: false, 
                                complete: function(msg,textStatus) { 
                                    // unblock when remote call returns                                                             
                                    if(msg.responsetext.split('&')[0] == "true")
                                    {
                                        password.val('');
                                        Code.val('');
                                        $("#spUser").text("欢迎您："+name.val()+" |");
                                        $("#aloginShow").toggle();
                                        $("#aLoginOut").toggle();  
                                        $("#userCenter").toggle(); 
                                        
                                         if(parseInt(msg.responsetext.split('&')[1]) > 0)
                                         {
                                            $("#spMessage").html("收信箱 (<font color='red'>"+msg.responsetext.split('&')[2]+"</font>) ");//<img src='/images/web/m_news.gif' alt='未读' border='0' />
                                         }
                                         else
                                         {
                                             $("#spMessage").html("收信箱 (0)");//<img src='/images/web/m_olds.gif' alt='已读' border='0' />
                                         }                                         
                                          
                                        $("#aNewUserReg").toggle();  
                                        $("#spUser").toggle();                                     
                                       // $.unblockUI(); 
                                        setTimeout($.unblockUI, 500); 
                                        window.location.reload(); 
//                                        parent.mainFrame.location.href="../rightFrom.aspx";
                                    }
                                    else
                                    {
                                        allFields.removeClass('ui-state-error');                                        
                                         alert("登录失败！");                                       
                                         Code.val('');  
                                         password.val('');                                
                                    }
                                    $('#imgVerify').attr("src",$('#imgVerify').attr("src")+'?');                                                    
                                } 
                            });                                                                                                                                                     
                       }
                }); 
                
                    $("#aLoginOut").click(function()
                    {
                        $.get("/reg.aspx",{loginOut:"loginOut"},function(data)
                        {
                            if(data == "true")
                            {
                                password.val('');
                                Code.val('');                                                                
                                $("#imgOKL").hide();
                                $("#imgErrorH").hide();                                
                                $("#aloginShow").toggle();
                                $("#aLoginOut").toggle();
                                 $("#userCenter").toggle();  
                                $("#aNewUserReg").toggle();
                                $("#spUser").toggle();
                             
                                 window.location.reload(); 
                                 window.onerror = killErrors;
                            }
                            else
                            {
                                alert('退出失败！',300,"");
                            }
                        });
                    });
         
                $('#btnCancelMeng').click(function() { 
                  allFields.removeClass('ui-state-error');
                    $.unblockUI();                    
                   // setTimeout($.unblockUI, 100);                     
                    password.val('');
                    Code.val('');
                    return false; 
                }); 
                
                 $('#imgReset').click(function() { 
                   allFields.removeClass('ui-state-error');
                    name.val('');
                    password.val('');
                    Code.val('');
                   // setTimeout($.unblockUI, 500); 
                    return false; 
                }); 
                
         
            }); 
        
     });
     
         /*iframe宽高自适应*/
    function TuneHeight(fm_name,fm_id){  
        var frm=document.getElementById(fm_id);  
        var subWeb=document.frames?document.frames[fm_name].document:frm.contentDocument;  
        if(frm != null && subWeb != null)
        { 
            frm.style.height = subWeb.documentElement.scrollHeight+"px"; 
            //如需自适应宽高,去除下行的“//”注释即可 
         frm.style.width = subWeb.documentElement.scrollWidth+"px"; 
        }  
    }    

	function qiehuan(num){
		for(var id = 0;id< 8;id++)
		{
			if(id==num)
			{
				document.getElementById("qh_con"+id).style.display="block";
				document.getElementById("qh_con"+id).className="Content_pd";
				document.getElementById("mynav"+id).className="tag_label_on";
			}
			else
			{
				document.getElementById("qh_con"+id).style.display="none";
				document.getElementById("mynav"+id).className="tag_label";
				document.getElementById("qh_con"+id).className="Content_pd";
			}
		}
	}
	


