    function   killErrors()   
    {   
       return  true;   
    }         
    function myTanChuang1(msg,myWidth,myCallBack)
    {
       $('#dialog1').html('<p>'+msg+'</p>');      
       $('#dialog1').dialog({autoOpen: false,width: myWidth, buttons: { 'ȷ��':function() {$(this).dialog('close'); } } });$('#dialog1').dialog('open');
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
				updateTips( n + "����Ϊ�գ�.");
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
                        $("#spUser").text("��ӭ����"+data.split('&')[1]+" |");
                        $("#aloginShow").hide();
                        $("#spUser").show();
                        $("#userCenter").show();
                        $("#aLoginOut").show();
                        $("#aNewUserReg").hide();                                                                    
                         if(parseInt(data.split('&')[2]) > 0)
                         {                  
                            $("#spMessage").html("������ (<font color='red'>"+data.split('&')[2]+"</font>) ");//<img src='/images/web/m_news.gif' alt='δ��' border='0' />
                         }
                         else
                         {                                              
                            $("#spMessage").html("������ (0)");//<img src='/images/web/m_olds.gif' alt='�Ѷ�' border='0' />
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
					        bValid = bValid && checkLength(name,"�û���");
			    	        bValid = bValid && checkLength(password,"����");
					        bValid = bValid && checkLength(Code,"��֤��");
        																			
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
                                    if(msg.responseText.split('&')[0] == "true")
                                    {
                                        password.val('');
                                        Code.val('');
                                        $("#spUser").text("��ӭ����"+name.val()+" |");
                                        $("#aloginShow").toggle();
                                        $("#aLoginOut").toggle();  
                                        $("#userCenter").toggle(); 
                                        
                                         if(parseInt(msg.responseText.split('&')[1]) > 0)
                                         {
                                            $("#spMessage").html("������ (<font color='red'>"+msg.responseText.split('&')[2]+"</font>) ");//<img src='/images/web/m_news.gif' alt='δ��' border='0' />
                                         }
                                         else
                                         {
                                             $("#spMessage").html("������ (0)");//<img src='/images/web/m_olds.gif' alt='�Ѷ�' border='0' />
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
                                         alert("��¼ʧ�ܣ�");                                       
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
                                alert('�˳�ʧ�ܣ�',300,"");
                            }
                        });
                    });
         
                $('#btnCancelMeng').click(function() { 
                  allFields.removeClass('ui-state-error');
                    $.unblockUI();                    
                   // setTimeout($.unblockUI, 100);                     
                    password.val('');
                    Code.val('');
                    window.location.reload(); 
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