    function   killErrors()   
    {   
       return  true;   
    }         
    function myTanChuang1(msg,myWidth,myCallBack)
    {
       $('#dialog1').html('<p>'+msg+'</p>');      
       $('#dialog1').dialog({autoOpen: false,width: myWidth, buttons: { '确定':function() {$(this).dialog('close'); } } });$('#dialog1').dialog('open');
    }

    $(function () {

        var name = $("#txtUsername"),
			Code = $("#txtCode"),
			password = $("#txtPassword"),
			allFields = $([]).add(name).add(Code).add(password),
			tips = $("#validateTips");

        function updateTips(t) {
            tips.text(t).effect("highlight", {}, 3500);
        }

        function checkLength(o, n) {
            if (o.val().length < 1) {
                o.addClass('ui-state-error');
                updateTips(n + "不能为空！.");
                return false;
            } else {
                return true;
            }
        }
        $(document).ready(function () {
            $.get("/reg.aspx", { IsLogin: "islogin" }, function (data) {
                if (data.split('&')[0] == "true") {
                    $("#spUser").text("欢迎您：" + data.split('&')[1] + " |");
                    $("#aloginShow").hide();
                    $("#spUser").show();
                    $("#userCenter").show();
                    $("#aLoginOut").show();
                    $("#aNewUserReg").hide();
                    if (parseInt(data.split('&')[2]) > 0) {
                        $("#spMessage").html("收信箱 (<font color='red'>" + data.split('&')[2] + "</font>) "); //<img src='/images/web/m_news.gif' alt='未读' border='0' />
                    }
                    else {
                        $("#spMessage").html("收信箱 (0)"); //<img src='/images/web/m_olds.gif' alt='已读' border='0' />
                    }
                }
                else {
                    $("#aLoginOut").hide();
                    $("#spUser").hide();
                    $("#userCenter").hide();
                    $("#aloginShow").show();
                    $("#aNewUserReg").show();
                }
            });
// 2021-12-24 vince 屏蔽开始
//            $('#aloginShow').click(function () {
//                $("#imgOKH").hide();
//                $("#imgErrorH").hide();
//                password.val('');
//                Code.val('');
//                $('#imgVerify').attr("src", $('#imgVerify').attr("src") + '?');
//                $.blockUI({ message: $('#divLogin'), css: { width: '350px'} });
//            });
// 结束屏蔽
            $('#btnLogin').click(function () {
                var bValid = true;
                allFields.removeClass('ui-state-error');
                bValid = bValid && checkLength(name, "用户名");
                bValid = bValid && checkLength(password, "密码");
                bValid = bValid && checkLength(Code, "验证码");

                if (bValid) {
                    // $.blockUI({ message: "<h1>正在验证...</h1>" }); 
                    // setTimeout($.unblockUI, 500); 
                    var stateTime = '0';
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
                    if ($("#cbState").attr("checked") == true) {
                        stateTime = '3';
                    }
                    else {
                        stateTime = '0';
                    }
                    $.ajax({
                        type: 'POST',
                        url: '/reg.aspx',
                        data: 'uName=' + escape(name.val()) + '&uPwd=' + escape(password.val()) + '&uCode=' + Code.val() + '&uTime=' + stateTime,
                        cache: false,
                        complete: function (msg, textStatus) {
                            // unblock when remote call returns                                                             
                            if (msg.responsetext.split('&')[0] == "true") {
                                password.val('');
                                Code.val('');
                                $("#spUser").text("欢迎您：" + name.val() + " |");
                                $("#aloginShow").toggle();
                                $("#aLoginOut").toggle();
                                $("#userCenter").toggle();

                                if (parseInt(msg.responsetext.split('&')[1]) > 0) {
                                    $("#spMessage").html("收信箱 (<font color='red'>" + msg.responsetext.split('&')[2] + "</font>) "); //<img src='/images/web/m_news.gif' alt='未读' border='0' />
                                }
                                else {
                                    $("#spMessage").html("收信箱 (0)"); //<img src='/images/web/m_olds.gif' alt='已读' border='0' />
                                }

                                $("#aNewUserReg").toggle();
                                $("#spUser").toggle();
                                // $.unblockUI(); 
                                setTimeout($.unblockUI, 500);
                                //                                window.location.reload();
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json",
                                    url: "/Template/WebService1.asmx/CueQuesion",
                                    data: "{u:'" + escape(name.val()) + "'}",
                                    dataType: "json",
                                    complete: function (result) {
                                        if (result.responseText.split('"')[1].split('"')[0] == "true") {
                                            var txt = "<div style=\"font-family:'Times New Roman',Georgia,Serif; font-size:16px; width:500px; text-align:left; margin-top:10px\">1：您的密码找回问题为空，一旦忘记密码则无法找回密码。<br/><br/>2：请点击<a href=\"http://www.pinble.com/UserCenter/User_Center.aspx\" target=\"_blank\">用户中心</a>我的资料选择“修改登录密保”及时来完善密码找回问题和答案。<br/><br/>3：密码找回问题和答案请勿一样，答案也不要跟网站用户名一样。<br/><br/>4：密码找回答案请勿太简单，也不要太容易被猜测，否则很容易被非法人员通过密码找回功能来盗取您的网站用户名密码。<br/><br/>5：密码找回问题可以设成：“您的出生地？”，“您的生日？”，“您孩子的名字？”等等；密码找回答案应该设置成别人根据密码问题猜测不出来的答案。<br/></div>";
                                            $.XYTipsWindow({
                                                ___title: "<font color='red'>友情提醒：您的密码提示问题和答案存在风险！</font>",    //窗口标题文字
                                                ___content: "text:" + txt,    //内容{text|id|img|url|iframe}
                                                ___width: "509",            //窗口宽度
                                                ___height: "370",          //窗口离度
                                                ___drag: "___boxTitle", 	    //拖动手柄ID
                                                ___showbg: true		//是否显示遮罩层
                                            });
                                        }
                                    }
                                });
                            }
                            else {
                                allFields.removeClass('ui-state-error');
                                alert("登录失败！");
                                Code.val('');
                                password.val('');
                            }
                            $('#imgVerify').attr("src", $('#imgVerify').attr("src") + '?');
                        }
                    });

                    //                          $.ajax({ 
                    //                                type:'POST',
                    //                                url: 'http://bbs.pinble2.com/login.asp?action=chk', 
                    //                                data:'username='+escape(name.val())+'&password='+escape(password.val())+'&CookieDate='+stateTime,
                    //                                cache: false, 
                    //                                complete: function(msg,textStatus) {     
                    //                                alert("完成");                                                                            
                    //                                } 
                    //                            });


                    //bbs登录
                    //                            $.ajax({ 
                    //                                type:'get',
                    //                                url: 'http://bbs.pinble2.com/login.asp?action=chk', 
                    //                                data:'username='+escape(name.val())+'&password='+escape(password.val())+'&CookieDate='+stateTime,
                    //                                cache: false, 
                    //                                complete: function(msg,textStatus) { 
                    //                                  myTanChuang1(msg.responsetext,300,"");
                    //                                       alert(msg.responsetext);                                               
                    //                                } 
                    //                            });  


                    //                            try
                    //                            {
                    //                              //alert("执行了"+stateTime);
                    //                              $.getJSON(
                    //                               "http://bbs.pinble2.com/login.asp?callback=?",
                    //                                {action:"chk", username: escape(name.val()), password: escape(password.val()),CookieDate: "3"}
                    //                                );
                    //                             }catch(err)  
                    //                             {
                    //                                 alert("aaaa");
                    //                             }                                                
                    //                             window.onerror = killErrors;                         



                    //window.onerror = killErrors;
                    //                            $.getJSON("http://bbs.pinble2.com/login.asp?action=chk&tags=cat&tagmode=any&format=json&jsoncallback=?", 
                    //                            function(data){ 
                    //                            $.each(data.items, function(i,item){ 
                    //                            $("<img/>").attr("src", item.media.m).appendTo("#images"); 
                    //                            if ( i == 3 ) return false; 
                    //                            }); 
                    //                            }); 
                    //                            

                }
            });

            $("#aLoginOut").click(function () {
                $.get("/reg.aspx", { loginOut: "loginOut" }, function (data) {
                    if (data == "true") {
                        password.val('');
                        Code.val('');
                        $("#imgOKL").hide();
                        $("#imgErrorH").hide();
                        $("#aloginShow").toggle();
                        $("#aLoginOut").toggle();
                        $("#userCenter").toggle();
                        $("#aNewUserReg").toggle();
                        $("#spUser").toggle();

                        //                                try
                        //                                {
                        //                                    $.getJSON(
                        //                                       "http://bbs.pinble2.com/logout.asp?callback=?",{ username: "test"}
                        //                                        );
                        //                                 }catch(err)  
                        //                                 {
                        //                                   
                        //                                 }  
                        window.location.reload();
                        window.onerror = killErrors;
                    }
                    else {
                        alert('退出失败！', 300, "");
                    }
                });
            });

            $('#btnCancelMeng').click(function () {
                allFields.removeClass('ui-state-error');
                $.unblockUI();
                // setTimeout($.unblockUI, 100);                     
                password.val('');
                Code.val('');
                return false;
            });

            $('#imgReset').click(function () {
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
		for(var id = 0;id< 5;id++)
		{
			if(id==num)
			{
				document.getElementById("qh_con"+id).style.display="block";
				document.getElementById("qh_con"+id).className="Content_pd";
				document.getElementById("mynav"+id).className="tag_label_on";
				if(num == 0)
				{
				    $('#spPriceZi').html("网络版：");
				   $('#spWLP').html("180元/3月&nbsp;330元/6月&nbsp;580元/年&nbsp;");
				   $('#spPriceDay').html("按天：<font color='red'>4元/天</font>&nbsp;");
				}
				else if(num == 1)
				{
				    $('#spPriceZi').html("网络版：");
				    $('#spWLP').html("150元/3月&nbsp;270元/6月&nbsp;480元/年&nbsp;");
				    $('#spPriceDay').html("按天：<font color='red'>3元/天</font>&nbsp;");
				}
				else if(num == 2)
				{
				    $('#spPriceZi').html("网络版：");
				    $('#spWLP').html("120元/3月&nbsp;220元/6月&nbsp;380元/年&nbsp;");
				    $('#spPriceDay').html("按天：<font color='red'>2.5元/天</font>&nbsp;");
				}
				else if(num == 3)
				{				
				    $('#spPriceZi').html("");
				    $('#spWLP').html("");
				    $('#spPriceDay').html("");
				}
				else if (num == 4) {
				    $('#spPriceZi').html("网络版：");
				    $('#spWLP').html("310元/3月&nbsp;560元/6月&nbsp;990元/年&nbsp;");
				    $('#spPriceDay').html("按天：<font color='red'>7元/天</font>&nbsp;");
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
	


