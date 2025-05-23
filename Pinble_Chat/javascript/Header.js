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
                           // $.blockUI({ message: "<h1>正在验证...</h1>" }); 
                           // setTimeout($.unblockUI, 500); 
                           var stateTime  = '0';
//                           if(rdState[0].checked)
//                           {
//                              stateTime='0';                        
//                           }  
//                           else if(rdState[1].checked)
//                           {
//                              stateTime='1';
//                           }
//                           else if(rdState[2].checked)
//                           {
//                              stateTime='2';
//                           }
//                           else if(rdState[3].checked)
//                           {
//                               stateTime='3';
//                           }
                            
                           if($("#cbState").attr("checked")==true)
                           {
                                 stateTime='0';  
                           }
                           else
                           {
                                 stateTime='3';
                           }
                           //stateTime
                                               
                            $.ajax({ 
                                type:'POST',
                                url: '/reg.aspx', 
                                data:'uName='+escape(name.val())+'&uPwd='+escape(password.val())+'&uCode='+Code.val()+'&uTime='+stateTime,
                                cache: false, 
                                complete: function(msg,textStatus) { 
                                    // unblock when remote call returns 
                                    if(msg.responsetext == "true")
                                    {
                                        password.val('');
                                        Code.val('');
                                        $("#spUser").text("欢迎您："+name.val()+" |");
                                        $("#aloginShow").toggle();
                                        $("#aLoginOut").toggle();  
                                         $("#userCenter").toggle();  
                                        $("#aNewUserReg").toggle();  
                                        $("#spUser").toggle();                                     
                                       // $.unblockUI(); 
                                        setTimeout($.unblockUI, 500); 
                                    }
                                    else
                                    {
                                        allFields.removeClass('ui-state-error');                                        
                                         alert("登录失败！");                                       
                                         Code.val('');                                      
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
                                $("#aloginShow").toggle();
                                $("#aLoginOut").toggle();
                                 $("#userCenter").toggle();  
                                $("#aNewUserReg").toggle();
                                $("#spUser").toggle();
                            }
                            else
                            {
                                alert('退出失败！');
                            }
                        });
                    });
         
                $('#btnCancel').click(function() { 
                    allFields.removeClass('ui-state-error');                               
                    setTimeout($.unblockUI, 100);                     
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
		for(var id = 0;id<=4;id++)
		{
			if(id==num)
			{
				document.getElementById("qh_con"+id).style.display="block";
				document.getElementById("qh_con"+id).className="Content_pd";
				document.getElementById("mynav"+id).className="tag_label_on";
				if(num == 0)
				{
				   $('#spPriceZi').html("网络注册：");
				   $('#spWLP').html("90元/三个月&nbsp;160元/六个月&nbsp;270元/一年&nbsp;&nbsp;");
				   $('#spPriceDay').html("按天:2元/天");
				}
				else if(num == 1)
				{
				    $('#spPriceZi').html("网络注册：");
				    $('#spWLP').html("70元/三个月&nbsp;120元/六个月&nbsp;200元/一年");
				    $('#spPriceDay').html("按天:1.5元/天");
				}
				else if(num == 2)
				{
				    $('#spPriceZi').html("网络注册：");
				    $('#spWLP').html("45元/三个月&nbsp;80元/六个月&nbsp;150元/一年&nbsp;&nbsp;&nbsp;");
				    $('#spPriceDay').html("按天:1元/天");
				}
				else if(num == 3)
				{				
				    $('#spPriceZi').html("");
				    $('#spWLP').html("");
				    $('#spPriceDay').html("");
				}
				
				
			}
			else
			{
				document.getElementById("qh_con"+id).style.display="none";
				document.getElementById("mynav"+id).className="tag_label";
				document.getElementById("qh_con"+id).className="Content_pd";
			}
		}
	}
	


