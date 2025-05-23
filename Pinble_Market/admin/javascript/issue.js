


     $(document).ready(function(){
               //设置金额的控件隐藏
               $("#money").hide();
               var lotteryType=document.getElementById("lotteryType");
               //读取cookie
               var num=getCookie("issue");
               if(num!=null && parseInt(num)>0 || num!="")
               {
                   $("#txt_time").attr("value",num); 
                   delCookie("issue");
               }
               else
               {
                    $("#txt_time").attr("value","");
                    delCookie("issue");
               }
         $("#ddlLottery").change(function(){
               $.ajax({
                     type: "POST",
                     contentType: "application/json",
                     url: "WebService1.asmx/selectIssue",
                     data: "{name:'"+  $("#ddlLottery").val() +"'}",
                     dataType: 'json',
                     complete: function(result) {
                     //result返回的值
                          if(result.responseText!=null || result.responseText!="" || result.length!=0)
                          {
                              $("#txt_time").attr("value","");
                               //创建cookie
                               delCookie("issue");
                               setCookie("issue",result.responseText.replace(/"/g,"").split('|')[0],1)
                          }
                          else
                          {
                                delCookie("issue");
                                $("#txt_time").attr("value",""); 
                                alert('期号生成错误，请检查网页是否禁用Cookie,或重新刷新一下页面');
                                return false;
                          }
                     }
                 });
         });       
        $("#ddlitemName").change(function(){ 
                //根据项目ID返回彩种和彩种类型
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "WebService1.asmx/GetWish",
                    data: "{value1:'"+ $("#ddlitemName").val() +"'}",
                    dataType: 'json',
                    complete: function(result) {
                        document.getElementById("lotteryType").value="";
                        document.getElementById("lotteryType").value=result.responseText;
                        if(result.responseText!="null")
                        {
                            if(result.responseText.split('|')[1].split('"')[0]=="Cue")
                            {
                                if(confirm('您可以发布收费项目，缴纳300金币保证金就可发布收费项目'))
                                {
//                                    var username='<%= Pbzx.Common.Method.Get_UserName %>';
                                      //取隐藏变量的值
                                      var username=$("#userName").val();
                                      
                                       //判断用户缴纳保证金
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json",
                                        url: "WebService1.asmx/deductMoney",
                                        data: "{username:'"+ username +"'}",
                                        dataType: 'json',
                                        complete: function(result) {
                                                
                                                //1:余额充足  0：余额不足
                                                if(result.responseText.split('"')[1].split('"')[0]=="1")
                                                {
                                                    if(confirm("您可以设置收费条件"))
                                                    {
                                                        //显示设置价格的控件
                                                        $("#money").show();
                                                    }
                                                }
                                                else
                                                {
                                                     $("#money").attr("value","");
                                                     $("#money").hide();
                                                    alert('您的帐户余额不够支付保证金、不能设置收费条件。请先充值！');
                                                }
                                        
                                             }
                                        });
                                }
                            }
                            if(result.responseText.split('|')[1].split('"')[0]=="CueNoSeries")
                            {
                                alert('您没有连续的发布条件');
                            }
                            
                            ValotteryType(result.responseText.split('&')[0].split('"')[1],result.responseText.split('&')[1].split('|')[0]);
                        }
                        else
                        {
                             $("#ddlitemName").val()=="0";
                             document.getElementById("txt_time").value=="";
                             document.getElementById("gut").style.display="block";
                             document.getElementById("Condition_Rad").innerHTML="";
                             document.getElementById("Condition_ck").innerHTML="";
                        }
                    }
                });

        });
        //提交数据
        $("#Button2").click(function(){   
                var txtmoney=0;
                //收费金额不为空也不是0
                if($("#txt_money").val()!="" || $("#txt_money").val()!=0)
                {
                    txtmoney=$("#txt_money").val();
                    //*******回调函数******
                    $.ajax({
                             type: "POST",
                             contentType: "application/json",
                             url: "WebService1.asmx/deduct",
                             data: "{price:'"+ txtmoney +"',username:'"+ $("#userName").val() +"',itemid:'"+ $("#ddlitemName").val() +"'}",
                             dataType: 'json',
                             complete: function(result) {
                             //result返回的值
                                if(result.responseText.split('"')[1].split('"')[0]=="1")
                                {
                                    alert('扣款成功！您以后发布的条件内容只有购买的用户才可观看');
                                    
                                }
                                else
                                {
                                    alert("您的保证金扣除失败。请检查余额");
                                    return false;
                                }
                             }
                         });
                  //**********end************  
                }
                var noList = "";
                if(lotteryType.value=="" || lotteryType.value==null)
                {
                    alert('请先选择项目！');
                    return false;
                }
                if($("#txt_time").val()=="")
                {
                    alert('生成期号出错，请刷新一下页面');
                    return false;
                }
                if(lotteryType.value.split('&')[0].split('"')[1]=="3D" || lotteryType.value.split('&')[0].split('"')[1]=="排列三")
                {
                    //如果在下面时间段是不可以发布信息的
                    var time1=new Date();
                    if(time1.getHours()>19 && time1.getHours()<22)
                    {
                        alert("现在还不能发布条件！");
                        $('#Button2').attr('disabled','true');
                        return false;
                    }
                    //选择的是综合的条件
                     if(lotteryType.value.split('&')[1].split('|')[0]=="综合条件")
                     {
                        
                        var colligate;
                        var arrdm=new Array;
                        var kd;
                        var hmz;
                        //判断条件是否都为空
                        if($("#txt_dm").val()=="" && $("#txt_hz").val()=="" && $("#txt_kd").val()=="" && $("input[name='qo']:checked").val()=="" && $("#txt_hmz").val()=="")
                        {
                            alert('最少填写一个条件内容');
                            return false;
                        }
                        else
                        {
                            //胆码条件
                            if($("#txt_dm").val()!="" || $("#txt_dm").val()!=null)
                            {
                                var numberArr=new Array;
                                //验证号码和，号的组合
                                if($("#txt_dm").val().replace(/\d+(?:,\d+)+/,"")=="" )
                                {
                                    for(var i=0;i<$("#txt_dm").val().split(',').length;i++)
                                    {
                                        if($("#txt_dm").val().split(',')[i].replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                                        {
                                            alert('胆码为0-9之间的数字');
                                            return false;
                                        }
                                        else
                                        {
                                            numberArr[i]=$("#txt_dm").val().split(',')[i];
                                        }
                                    }
                                }
                                //验证号码是0-9的正整数
                                else if($("#txt_dm").val().replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                                {
                                    numberArr[0]=$("#txt_dm").val();
                                }//验证号码 和 空格的组合
                                else if($("#txt_dm").val().replace(/\d+(?: \d+)+/,"")=="")
                                {
                                     var numberArr=new Array;
                                    for(var i=0;i<$("#txt_dm").val().split(' ').length;i++)
                                    {
                                        if($("#txt_dm").val().split(' ')[i].replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                                        {
                                            alert('胆码为0-9之间的数字');
                                            return false;
                                        }
                                        else
                                        {
                                            numberArr[i]=$("#txt_dm").val().split(' ')[i];
                                        }
                                    }
                                   
                                }
                                else
                                {
                                    alert('您输入的格式不正确，请重新输入');
                                    return false;
                                }
                                 arrdm=maopao(unique(numberArr));
                            }
//                            //和值条件
//                            if($("#txt_hz").val()!="" || $("#txt_hz").val()!=null)
//                            {
//                                
//                            }
//                            //跨度
//                            if($("#txt_kd").val()!="" || $("#txt_kd").val()!=null)
//                            {
//                                if($("#txt_kd").val().replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
//                                {
//                                    alert('跨度号码格式错误。请检查！');
//                                    return false;
//                                }
//                                else
//                                {
//                                    kd=$("#txt_kd").val();
//                                }
//                                
//                            }
                            //号码组
                            if($("#txt_hmz").val()!="" || $("#txt_hmz").val()!=null)
                            {
                                //正整数
                                if($("#txt_hmz").val().replace(/^[1-9]\d*$/,"")=="" )
                                {
                                    hmz=RemoveRepeat($("#txt_hmz").val());
                                }
                                else
                                {
                                    alert('请输入正确的号码组');
                                    return false;
                                }
                            }
                            /********调用数据库方法**********/
                                 var time=new Date();
                                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
//                                    var colligate=arrdm+"|"+$("#txt_hz").val()+"|"+kd+"|"+$("input[name='qo']:checked").val()+"|"+hmz;
                                    var colligate="胆码："+arrdm+"、 和值："+$("#txt_hz").val()+"、  号码组："+hmz;
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('期号生成错误，请刷新一下页面');
                                        return false;
                                    }
                                    //取是否推荐的标识
                                    var rcd=$("input[name='yn']:checked").val();
                                    //取胆码或是杀码的标识
                                    var courage=$("input[name='courage']:checked").val();
                                    if(confirm("条件号码是："+"胆码："+arrdm+"、  和值："+$("#txt_hz").val()+"、  号码组："+hmz))
                                    {
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ colligate +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'',itemnumber:'1'}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                 }
                                             });
                                      //**********end************  
                                  }
                                  else
                                  {
                                        return false;
                                  }
                            /********调用数据库方法**********/
                        }
                     }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="胆码")
                    {
                       
                        $('input[type="checkbox"]').each(function () {
                            if ($(this).attr('checked')) {
                                noList += $(this).val() + "|";
                            }
                        }); 
                        if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null )
                        {
                            alert('请选择彩种条件');
                            return false;
                        }
                        else
                        {
                            if($("input[name='testRadio']:checked").val()=="单码")
                            {

                               if(!TextValidate($("#selecttags").val()))
                               {
                                  alert('输入条件的格式不正确');
                                  return false;
                                  
                               }
                               else
                               {
                                    var time=new Date();
                                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                    var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                                    var pm=new Array;
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('期号生成错误，请刷新一下页面');
                                        return false;
                                    }
                                    for(var i=0;i<txt.length;i++)
                                    {
                                        pm[i]=txt.substring(i,i+1);
                                    }
                                    //取是否推荐的标识
                                    var rcd=$("input[name='yn']:checked").val();
                                    //取胆码或是杀码的标识
                                    var courage=$("input[name='courage']:checked").val();
                                    if(confirm("条件号码是："+ $("input[name='testRadio']:checked").val()+ "：" + pm))
                                    {
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败,');
                                                        $("#selecttags").val()="";
                                                    }
                                                 }
                                             });
                                      //**********end************  
                                  }
                                  else
                                  {
                                        return false;
                                  }
                                  
                               }
                            }
                            if($("input[name='testRadio']:checked").val()=="组选两码")
                            {
                                if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null) 
                                {
                                    alert('请选择彩种条件');
                                    return false;
                                }
                                //验证输入合法
                                if(!TextValidate($("#selecttags").val()))
                                {
                                    alert('格式不正确，请输入数字');
                                    return false;
                                }  
                                else
                                {
                                        var time=new Date();
                                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                        var issue=$("#txt_time").val();
                                        if(issue=="" || issue==null || issue=="null")
                                        {
                                            alert('期号生成错误，请刷新一下页面');
                                            return false;
                                        }
                                        var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                                        //取是否推荐的标识
                                        var rcd=$("input[name='yn']:checked").val();
                                        //取胆码或是杀码的标识
                                        var courage=$("input[name='courage']:checked").val();
                                     //提示发布的号码；
                                     if(confirm("条件号码是："+ $("input[name='testRadio']:checked").val()+ "：" + txt))
                                     {     
                                          //*******回调函数******
                                            $.ajax({
                                                     type: "POST",
                                                     contentType: "application/json",
                                                     url: "WebService1.asmx/AddItem",
                                                     data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                     dataType: 'json',
                                                     complete: function(result) {
                                                     //result返回的值
                                                       if(result.responseText==0)
                                                        {
                                                            alert("已添加过'"+ issue +"'期的数据");
                                                             return false;
                                                        }
                                                        else
                                                        {
                                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                            $("#selecttags").val()="";
                                                        }
                                                     }
                                                 });
                                          //**********end************ 
                                      } 
                                      else
                                      {
                                            return false;
                                      }
                                }
                            }
                            if($("input[name='testRadio']:checked").val()=="单选两码")
                            {
                                if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null)
                                {
                                    alert('请选择彩种条件');
                                    return false;
                                }
                                //注意这里的23 和32不同 要注意数字的位子
                                //验证输入合法
                                if(!TextValidate($("#selecttags").val()))
                                {
                                    alert('输入条件的格式不正确');
                                    return false;
                                }  
                                else
                                {
                                        var time=new Date();
                                        //提交的时间
                                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                        var issue=$("#txt_time").val();
                                        if(issue=="" || issue==null || issue=="null")
                                        {
                                            alert('期号生成错误，请刷新一下页面');
                                            return false;
                                        }
                                        //内容
                                        var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                                        //取是否推荐的标识
                                        var rcd=$("input[name='yn']:checked").val();
                                        //取胆码或是杀码的标识
                                        var courage=$("input[name='courage']:checked").val();
                                         //提示发布的号码；
                                         if(confirm("条件号码是："+ $("input[name='testRadio']:checked").val()+ "：" + txt))
                                         {      
                                              //*******回调函数******
                                                $.ajax({
                                                         type: "POST",
                                                         contentType: "application/json",
                                                         url: "WebService1.asmx/AddItem",
                                                         data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                         dataType: 'json',
                                                         complete: function(result) {
                                                         //result返回的值
                                                            if(result.responseText==0)
                                                            {
                                                                alert("已添加过'"+ issue +"'期的数据");
                                                                 return false;
                                                            }
                                                            else
                                                            {
                                                                result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                                $("#selecttags").val()="";
                                                            }
                                                               
                                                         }
                                                     });
                                              //**********end************  
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                }
                            }
                        }
                        
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="号码组")
                    {
                        if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null)
                        {
                            alert('请选择号码组的条件');
                            return false;
                        }
                        //验证输入合法
                        if(!TextValidate($("#selecttags").val()))
                        {
                            alert('输入条件的格式不正确');
                            return false;
                        }  
                        else
                        {
                            var time=new Date();
                            //提交的时间
                            var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                            var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                            var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                            var issue=$("#txt_time").val();
                            if(issue=="" || issue==null || issue=="null")
                            {
                                alert('期号生成错误，请刷新一下页面');
                                return false;
                            }
                            //内容
                            var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                            if(txt==false)
                            {
                                return false;
                            }
                            //取是否推荐的标识
                            var rcd=$("input[name='yn']:checked").val();
                            //取胆码或是杀码的标识
                            var courage=$("input[name='courage']:checked").val();
                           //提示发布的号码；
                             if(confirm("条件号码是："+ $("input[name='testRadio']:checked").val()+ "：" + txt))
                             {        
                                  //*******回调函数******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result返回的值
                                                if(result.responseText==0)
                                                {
                                                    alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    $("#selecttags").val()="";
                                                }
                                                   
                                             }
                                         });
                                  //**********end************  
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="和值")
                    {
                        if($("input[name='testradio']:checked").val()=="" || $("input[name='testradio']:checked").val()==null)
                        {
                            alert('请选择条件');
                            return false;
                        }
                        if($("input[name='testradio']:checked").val()=="和值奇偶")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择条件!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                               //内容
                               var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                               //提示发布的号码；
                                 if(confirm("条件号码是："+ $("input[name='rad']:checked").val() + "：" + txt))
                                 {           
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        if($("input[name='testradio']:checked").val()=="和值大小")
                        {  
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择输入条件!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                               //内容
                               var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                  //提示发布的号码；
                                 if(confirm("条件号码是："+ $("input[name='rad']:checked").val()+ "：" + txt))
                                 {       
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************ 
                                } 
                                else
                                {
                                    return false;
                                }
                                
                            }
                        }
                        if($("input[name='testradio']:checked").val()=="和值DZX")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择输入条件!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;  
                                }
                               //内容
                               var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                               //提示发布的号码；
                                 if(confirm("您发布的条件号码是："+ $("input[name='rad']:checked").val()+ "：" + txt))
                                 {         
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                       if($("input[name='testradio']:checked").val()=="和值012路")
                       {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择输入条件!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                //提示发布的号码；
                                 if(confirm("条件号码是：" + txt))
                                 {        
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                }
                                else
                                {
                                    return false;
                                }
                            }
                       }
                       if($("input[name='testradio']:checked").val()=="和值质和")
                       {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择输入条件!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                               var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 if(confirm("条件号码是：" + txt))
                                 {     
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                }
                                else
                                {
                                    return false;
                                }
                            }
                       }
                        if($("input[name='testradio']:checked").val()=="和值距离")
                        {
                            if($("#selecttags").val()=="" ||  $("#selecttags").val().replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                            {
                                alert('条件格式不正确！');
                                return false;
                            }
                            if(parseInt($("#selecttags").val())>=0 && parseInt($("#selecttags").val())<=27)
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                               //内容
                               var txt= $("#selecttags").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                if(confirm("条件号码是：" + txt))
                                 {         
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                  }
                                  else
                                  {
                                        return false;
                                  }
                            }
                            else
                            {
                                alert('和值距离输入不正确：必须是0-27的数字！');
                                return false;
                            }
                        }
                               
                       
                       
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="跨度")
                    {
                        if($("input[name='textradio']:checked").val()=="跨度")
                        {
                            if($("#selecttags").val()=="" || $("#selecttags").val().replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                            {
                                alert('跨度条件输入错误！');
                                return false;
                            }
                            else
                            {
                                if(parseInt($("#selecttags").val())>=0 && parseInt($("#selecttags").val())<=9)
                                {
                                    var time=new Date();
                                    //提交的时间
                                   var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('期号生成错误，请刷新一下页面');
                                        return false;
                                    }
                                   //内容
                                   var txt= $("#selecttags").val();
                                    //取是否推荐的标识
                                    var rcd=$("input[name='yn']:checked").val();
                                    //取胆码或是杀码的标识
                                    var courage=$("input[name='courage']:checked").val();
                                    //提示发布的号码；
                                     if(confirm("条件号码是："+ txt))
                                     {         
                                          //*******回调函数******
                                            $.ajax({
                                                     type: "POST",
                                                     contentType: "application/json",
                                                     url: "WebService1.asmx/AddItem",
                                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                     dataType: 'json',
                                                     complete: function(result) {
                                                     //result返回的值
                                                        if(result.responseText==0)
                                                        {
                                                           alert("已添加过'"+ issue +"'期的数据");
                                                           return false;
                                                        }
                                                        else
                                                        {
                                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                             $("#selecttags").val()="";
                                                        }
                                                           
                                                     }
                                                 });
                                          //**********end************  
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    alert('跨度条件输入有误：只能输入0-9之间的数字');
                                    return false;
                                }
                            }
                        }
                        if($("input[name='textradio']:checked").val()=="跨度奇偶")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择条件！');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                               //内容
                               var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("条件号码是："+$("input[name='textradio']:checked").val() + txt))
                                 {     
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        if($("input[name='textradio']:checked").val()=="跨度大小")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('请选择跨度大小的条件！');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //内容
                                var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                  //提示发布的号码；
                                     if(confirm("条件号码是："+$("input[name='textradio']:checked").val() + txt))
                                     {     
                                          //*******回调函数******
                                            $.ajax({
                                                     type: "POST",
                                                     contentType: "application/json",
                                                     url: "WebService1.asmx/AddItem",
                                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                     dataType: 'json',
                                                     complete: function(result) {
                                                     //result返回的值
                                                        if(result.responseText==0)
                                                        {
                                                            alert("已添加过'"+ issue +"'期的数据");
                                                            return false;
                                                        }
                                                        else
                                                        {
                                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        }
                                                           
                                                     }
                                                 });
                                          //**********end************  
                                     }
                                     else
                                     {
                                        return false;
                                     }
                                
                            }
                        }
                        if($("input[name='textradio']:checked").val()=="跨度012路")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('强选择跨度012路的条件！');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('期号生成错误，请刷新一下页面');
                                        return false;
                                    }
                                    var txt=$("input[name='rad']:checked").val();
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("条件号码是："+$("input[name='textradio']:checked").val() + txt))
                                 {      
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************  
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="奇偶")
                    {
                    
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="定位复式")
                    {
                        if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null)
                        {
                            alert('请选择彩种条件');
                            return false;
                        }
                        else
                        {
                            if($("input[name='testRadio']:checked").val()=="组合输入")
                            {
                               
                                if($("#selecttags").val()=="")
                                {
                                    alert('数据输入不能为空');
                                    return false;
                                }
                                else
                                {
                                    //验证数据是不是由数字和/号组成 
//                                    if($("#selecttags").val().replace(/\d+(?:\/\d+)+/,"")=="" )
                                    //验证数字和,号
                                    if($("#selecttags").val().replace(/\d+(?:,\d+)+/,"")=="" )
                                    {
                                        var key1=new Array;
                                        key1=$("#selecttags").val().split(",");
                                       
                                        if(key1.length<0 || key1.length>3)
                                        {
                                            alert('输入不正确！格式为：0,0,0号码间用逗号隔开。');
                                            return false;
                                        }
                                        else
                                        {
                                            var txt="";
                                            var time=new Date();
                                            //提交的时间
                                           var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                            var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                            var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                            var issue=$("#txt_time").val();
                                            if(issue=="" || issue==null || issue=="null")
                                            {
                                                alert('期号生成错误，请刷新一下页面');
                                                return false;
                                            }
                                            //内容
                                            for(var k=0;k<key1.length;k++)
                                            {
                                                if($("#selecttags").val().split(",")[k]==null)
                                                {
                                                    break;
                                                }
                                                txt+=RemoveRepeat($("#selecttags").val().split(",")[k])+"|";
                                            }
                                           
                                            //取是否推荐的标识
                                            var rcd=$("input[name='yn']:checked").val();
                                            //是发送号码还是 不出的号码
                                            var courage=$("input[name='courage']:checked").val();
                                            //提示发布的号码；
                                             if(confirm("条件号码是："+$("input[name='testRadio']:checked").val()+"："+ txt))
                                             {    
                                                  //*******回调函数******
                                                    $.ajax({
                                                             type: "POST",
                                                             contentType: "application/json",
                                                             url: "WebService1.asmx/AddItem",
                                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                             dataType: 'json',
                                                             complete: function(result) {
                                                             //result返回的值
                                                                if(result.responseText==0)
                                                                {
                                                                    alert("已添加过'"+ issue +"'期的数据");
                                                                    return false;
                                                                }
                                                                else
                                                                {
                                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                                    $("#selecttags").val()="";
                                                                }
                                                                   
                                                             }
                                                         });
                                                  //**********end************  
                                              }
                                              else
                                              {
                                                    return false;
                                              }
                                        }
                                    }
                                    else
                                    {
                                        alert('输入错误！定位复式格式：数字，数字，数字');
                                        return false;
                                    }
                                }
                            }
                            if($("input[name='testRadio']:checked").val()=="单一输入")
                            {
                                if($("#txt_one").val()=="" || $("#txt_two").val()=="" || $("#txt_three").val()=="")
                                {
                                    alert('定位复式数据不能为空！');
                                    return false;
                                }
                                else
                                {
                                    if(!Rex($("#txt_one").val()) || !Rex($("#txt_two").val()) || !Rex($("#txt_three").val()))
                                    {
                                        
                                        alert('定位复式数据输入格式不正确！');
                                        return false;
                                    }
                                    else
                                    {
                                         //取值传入数据库
                                        var time=new Date();
                                        //提交的时间
                                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                        var issue=$("#txt_time").val();
                                        if(issue=="" || issue==null || issue=="null")
                                        {
                                            alert('期号生成错误，请刷新一下页面');
                                            return false;
                                        }
                                        //内容
                                        var txt;
                                        txt=RemoveRepeat($("#txt_one").val())+"*"+RemoveRepeat($("#txt_two").val())+"*"+RemoveRepeat($("#txt_three").val());
                                       
                                        //取是否推荐的标识
                                        var rcd=$("input[name='yn']:checked").val();
                                        //取胆码或是杀码的标识
                                        var courage=$("input[name='courage']:checked").val();
                                          //提示发布的号码；
                                         if(confirm("条件号码是： 第一位*第二位*第三位"+ txt))
                                         { 
                                              //*******回调函数******
                                                $.ajax({
                                                         type: "POST",
                                                         contentType: "application/json",
                                                         url: "WebService1.asmx/AddItem",
                                                         data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                         dataType: 'json',
                                                         complete: function(result) {
                                                         //result返回的值
                                                            if(result.responseText==0)
                                                            {
                                                                alert("已添加过'"+ issue +"'期的数据");
                                                                return false;
                                                            }
                                                            else
                                                            {
                                                                result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                                $("#txt_one").val()="";
                                                                $("#txt_two").val()="";
                                                                $("#txt_three").val()="";
                                                            }
                                                               
                                                         }
                                                     });
                                              //**********end************  
                                          }
                                          else
                                          {
                                                return false;
                                          }
                                    }
                                }
                            }
                        }

                    }
                }
            //*********判断双色球begin****************
        if(lotteryType.value.split('&')[0].split('"')[1]=="双色球")
        {
            //如果在下面时间段是不可以发布信息的
            var time1=new Date();
            if((time1.getDay()==2 || time1.getDay()==4 || time1.getDay()==6) && time1.getHours()>20 && time1.getHours()<22)
            {
                alert("现在还不能发布条件！");
                $('#Button2').attr('disabled','true');
                return false;
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="综合条件")
            {
                var arrhqdm=new Array;
                var arrlqdm=new Array;
                var arrfs=new Array;
                var arrfsl=new Array;
                var arrds=new Array;
                var arrdsl=new Array;
                var fstj="";
                var dstj="";
                if($("#txt_hqdm").val()=="" && $("#txt_lqdm").val()=="" && $("#txt_fstj").val()=="" && $("#txt_ds").val()=="")
                {
                    alert('最少要填写一个条件内容');
                    return false;
                }
                //判断红球胆码
                if($("#txt_hqdm").val()!="")
                {
                    //验证输入格式(逗号)
                    if($("#txt_hqdm").val().replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<$("#txt_hqdm").val().split(',').length;i++)
                        {
                            if($("#txt_hqdm").val().split(',')[i]>33)
                            {
                                alert('红球胆码号码不能大于33');
                                return false;
                            }
                            arrhqdm[i]=$("#txt_hqdm").val().split(',')[i];
                        }
                        arrhqdm=maopao(unique(arrhqdm));
                    }
                    else if($("#txt_hqdm").val().replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0; i<$("#txt_hqdm").val().split(' ').length;i++)
                        {
                            if($("#txt_hqdm").val().split(' ')[i]>33)
                            {
                                alert('红球胆码号码不能大于33');
                                return false;
                            }
                           arrhqdm[i]=$("#txt_hqdm").val().split(' ')[i];     
                        }
                        arrhqdm=maopao(unique(arrhqdm));
                    }
                    else if($("#txt_hqdm").val()>0)
                    {
                        if($("txt_hqdm").val()>33)
                        {
                            alert('红球胆码号码不能大于33');
                            return false;
                        }
                        arrhqdm[0]=$("#txt_hqdm").val();
                    }
                    else
                    {
                        alert('您输入的格式不正确');
                        return false;
                    }
                }
                //判断蓝球胆码
                if($("#txt_lqdm").val()!="")
                {
                    //验证输入格式(逗号)
                    if($("#txt_lqdm").val().replace(/\d+(?:,\d+)+/,"")=="" )
                    {
                        for(var i=0;i<$("#txt_lqdm").val().split(',').length;i++)
                        {
                            if($("#txt_lqdm").val().split(',')[i]>16)
                            {
                                alert('蓝球胆码号码不能大于16');
                                return false;
                            }
                            arrlqdm[i]=$("#txt_lqdm").val().split(',')[i];
                        }
                        arrlqdm=maopao(unique(arrlqdm));
                    }
                    else if($("#txt_lqdm").val().replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<$("#txt_lqdm").val().split(' ').length;i++)
                        {
                            if($("#txt_lqdm").val().split(' ')[i]>16)
                            {
                                alert('蓝球胆码号码不能大于16');
                                return false;
                            }
                            arrlqdm[i]=$("#txt_lqdm").val().split(' ')[i];
                        }
                        arrlqdm=maopao(unique(arrlqdm));
                    }
                    else if($("#txt_lqdm").val()>0)
                    {
                        if($("txt_lqdm").val()>16)
                        {
                            alert('蓝球胆码号码不能大于16');
                            return false;
                        }
                        arrlqdm[0]=$("#txt_lqdm").val();
                    }
                    else
                    {
                        alert('您输入的格式不正确');
                        return false;
                    }
                    
                }
                //判断复式号码
                if($("#txt_fstj").val()!="")
                {
                    if($("#txt_fstj").val().split('+').length>0)
                    {
                         //验证输入格式(逗号)
                        if($("#txt_fstj").val().split('+')[0].replace(/\d+(?:,\d+)+/,"")=="" )
                        {
                            if($("#txt_fstj").val().split('+')[0].split(',').length<6)
                            {
                                alert('红球复式不能少于6个号码');
                                return false;
                            }
                            for(var i=0;i<$("#txt_fstj").val().split('+')[0].split(',').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[0].split(',')[i]>33)
                                {
                                    alert('复式红球号码不能大于33');
                                    return false;
                                }
                                arrfs[i]=$("#txt_fstj").val().split('+')[0].split(',')[i];
                            }
                            arrfs=maopao(unique(arrfs));
                        }
                        else if($("#txt_fstj").val().split('+')[0].replace(/\d+(?: \d+)+/,"")=="")
                        {
                            if($("#txt_fstj").val().split('+')[0].split(' ').length<6)
                            {
                                alert('复式红球不能少于6个号码');
                                return false;
                            }
                            for(var i=0; i<$("#txt_fstj").val().split('+')[0].split(' ').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[0].split(' ')[i]>33)
                                {
                                    alert('复式红球号码不能大于33');
                                    return false;
                                }
                                arrfs[i]=$("#txt_fstj").val().split('+')[0].split(' ')[i];
                            }
                            arrfs=maopao(unique(arrfs));
                        }
                        else
                        {
                            alert('您输入的红球格式不正确');
                            return false;
                        }
                        //验证输入格式(逗号)
                        if($("#txt_fstj").val().split('+')[1].replace(/\d+(?:,\d+)+/,"")=="" )
                        {
                            if($("#txt_fstj").val().split('+')[1].split(',').length<1)
                            {
                                alert('蓝球复式不能少于1个号码');
                                return false;
                            }
                            for(var i=0; i<$("#txt_fstj").val().split('+')[1].split(',').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[1].split(',')[i]>16)
                                {
                                    alert('复式蓝球的号码不能大于16');
                                    return false;
                                }
                                arrfsl[i]=$("#txt_fstj").val().split('+')[1].split(',')[i];
                            }
                            arrfsl=maopao(unique(arrfsl));
                        }
                        else if($("#txt_fstj").val().split('+')[1].replace(/\d+(?: \d+)+/,"")=="")
                        {
                            if($("#txt_fstj").val().split('+')[1].split(' ').length<1)
                            {
                                alert('蓝球复式不能少于1个号码');
                                return false;
                            }
                            for(var i=0; i<$("#txt_fstj").val().split('+')[1].split(' ').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[1].split(' ')[i]>16)
                                {
                                    alert('复式蓝球的号码不能大于16');
                                    return false;
                                }
                                arrfsl[i]=$("#txt_fstj").val().split('+')[1].split(' ')[i];
                            }
                            arrfsl=maopao(unique(arrfsl));
                        }
                        else if($("#txt_fstj").val().split('+')[1]>0)
                        {
                            if($("#txt_fstj").val().split('+')[1]>16)
                            {
                                alert('复式蓝球的号码不能大于16');
                                return false;
                            }
                            arrfsl[0]=$("#txt_fstj").val().split('+')[1];
                        }
                        else
                        {
                            alert('蓝球个数输入有误！请检查');
                            return false;
                        }
                    }
                    else
                    {
                        alert('您输入的格式不正确333');
                        return false;
                    }
                }
                //判断单式号码
                if($("#txt_ds").val()!="")
                {
                    if($("#txt_ds").val().split('+').length>0)
                    {
                        //逗号(判断红球格式)
                        if($("#txt_ds").val().split('+')[0].replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            if($("#txt_ds").val().split('+')[0].split(',').length!=6)
                            {
                                alert('红球号码位数输入错误');
                                return false;
                            }
                            else
                            {
                                for(var i=0;i<$("#txt_ds").val().split('+').split(',').length;i++)
                                {
                                    if($("#txt_ds").val().split('+').split(',')[i]>33)
                                    {
                                        alert('红球号码不能大于33');
                                        return false;
                                    }
                                    arrds[i]=$("#txt_ds").val().split('+').split(',')[i];
                                }
                            }
                            arrds=maopao(unique(arrds));
                        }//空格
                        else if($("#txt_ds").val().split('+')[0].relace(/\d+(?: \d+)+/,"")=="")
                        {
                            if($("#txt_ds").val().split('+')[0].split(' ').length!=6)
                            {
                                alert('红球号码位数输入错误');
                                return false;
                            }
                            else
                            {
                                for(var i=0;i<$("#txt_ds").val().split('+').split(' ').length;i++)
                                {
                                    if($("#txt_ds").val().split('+').split(' ')[i]>33)
                                    {
                                        alert('红球号码不能大于33');
                                        return false;
                                    }
                                    arrds[i]=$("#txt_ds").val().split('+').split(' ')[i];
                                }
                            }
                            arrds=maopao(unique(arrds));
                        }
                        else
                        {
                            alert('红球号码格式输入错误');
                            return false;
                        }
                        //判断蓝球为正整数
                        if($("#txt_ds").val().split('+')[1].replace(/^[1-9]\d*$/,"")=="")
                        {
                            if($("#txt_ds").val.split('+')[1]>16)
                            {
                                alert('蓝球号码不能大于16');
                                return false;
                            }
                            else
                            {
                                arrdsl[0]=$("#txt_ds").val().split('+')[1];
                            }
                        }
                    }
                    else
                    {
                        alert('您输入的格式不正确');
                        return false;
                    }
                }
                if(arrfs.length>0 && arrfsl.length>0)
                {
                    fstj=arrfs+"+"+arrfsl;
                }
                if(arrds.length>0 && arrdsl.length>0)
                {
                    dstj=arrds+"+"+arrdsl;
                }
                 /********调用数据库方法**********/
                             var time=new Date();
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
//                                var colligate=arrhqdm+"|"+arrlqdm+"|"+arrfs+"+"+arrfsl+"|"+arrds+"+"+arrdsl;
                                  var colligate="红球胆码："+arrhqdm+"  蓝球胆码："+arrlqdm+"  复式推荐："+ fstj +"  单式推荐："+ dstj
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                if(confirm("条件号码是："+"红球胆码："+arrhqdm+"  蓝球胆码："+arrlqdm+"  复式推荐："+ fstj +"  单式推荐："+ dstj))
                                {
                                  //*******回调函数******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ colligate +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'',itemnumber:'1'}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result返回的值
                                                if(result.responseText==0)
                                                {
                                                    alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                }
                                             }
                                         });
                                  //**********end************  
                              }
                              else
                              {
                                    return false;
                              }
                        /********调用数据库方法**********/
                
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="红球胆码")
            {
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    
                    alert('格式不正确，请输入号码。');
                    return false;
                }
                else
                {
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    for(var i=0;i<val.split("<br>").length;i++)
                    {   
                        if(i>34)
                        {
                            alert('数据输入超限');
                            return false;
                        }
                        else
                        arr[i]=val.split("<br>")[i];
                    }
                    for(var j=0;j<arr.length;j++)
                    {  
                          //元素中是不是带有,号
                          if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                          {
                              for(var k=0;k<arr[j].split(",").length;k++)
                              {
                                   if(arr[j].split(",")[k].length!=2 || arr[j].split(",")[k]>33 || parseInt(arr[j].split(",")[k])==0)
                                   {
                                        alert('胆码输入错误！请输入两位号码，号码不能大于33，');
                                        //结束程序
                                        return false;
                                   }
                                   else
                                   {
                                        str+=arr[j].split(",")[k]+",";
                                   }     
                              } 
                          }
                          //验证是不是 带有空格
                          else if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                          {
                                  for(var k=0;k<arr[j].split(" ").length;k++)
                                  {
                                       if(arr[j].split(" ")[k].length!=2 || arr[j].split(" ")[k]>33 || parseInt(arr[j].split(",")[k])==0)
                                       {
                                            alert('胆码输入错误！请输入两位号码，号码不能大于33');
                                            //结束程序
                                            return false;
                                       }
                                       else
                                       {
                                            str+=arr[j].split(" ")[k]+",";;
                                       }     
                                  } 
                          }
                          else if(arr[j].replace(/^[1-9]\d*$/,"")=="")
                          {     
                                if(arr[j]>33 || parseInt(arr[j])==0)
                                {
                                    alert('胆码输入错误！请输入两位号码，号码不能大于33。');
                                    return false;
                                }
                                else
                                {
                                    str+=arr[j]+",";
                                }
                          }
                          else
                          {
                                alert('胆码输入错误！格式：号码,号码 或者  号码 号码');
                                return false;
                          }
                    }
                    //去掉最后一个，号
                    var str1=str.substring(0,str.length-1);
                    //去除重复条件
                    for(var p=0;p<str1.split(",").length;p++)
                    {
                        twoArr[p]=str1.split(",")[p];
                    }
                    var pm=new Array;
                    pm=maopao(unique(twoArr));
                    //*****************连接数据库*****************
                      var time=new Date();
                      //提交的时间
                      var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                      //取是否推荐的标识
                      var rcd=$("input[name='yn']:checked").val();
                      //取胆码或是杀码的标识
                      var courage=$("input[name='courage']:checked").val();
                      var issue=$("#txt_time").val();
                      if(issue=="" && parseInt(issue)>0)
                      {
                           alert('期号为空！请刷新页面');
                           return false;
                      } 
                      //提示发布的号码；
                     if(confirm("红球胆码号码是："+ pm))
                     {          
                          //*******回调函数******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:' ',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result返回的值
                                        if(result.responseText==0)
                                        {
                                            alert("已添加过'"+ issue +"'期的数据");
                                            return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                            $("#selecttags").val()="";
                                        }
                                           
                                     }
                                 });
                          //**********end************ 
                      }
                      else
                      {
                            return false;
                      }
                    //*********************end**********************
                }
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="蓝球胆码")
            {
                if($("#txt_time").val()=="" || parseInt($("#txt_time").val())<0)
                {
                    alert('期号错误请重新选择彩种！');
                    return false;
                }
                if($("#selecttags").val()=="")
                {
                    alert('请填写号码！');
                    return false;
                }

                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                var str="";
                if(val.split("<br>").length>1)
                {
                    alert('请把数据写成一行！数字见用逗号或者是空格区分开');
                    return false;
                }
                if(val.replace(/\d+(?:,\d+)+/,"")=="" || val.replace(/\d+(?: \d+)+/,"")=="" || val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                {
                     //输入的格式不是号码+逗号的形式
                    if(val.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                       for(var i=0;i<val.split(",").length;i++)
                       {
                            if(val.split(",")[i]>16 || val.split(",")[i].length != 2)
                            {
                                alert('蓝球胆码号码01-16');
                                return false;
                            }
                            arr[i]=val.split(",")[i];
                       }
                    }
                    //判断是不是带有空格
                    if(val.replace(/\d+(?: \d+)+/,"")=="")
                    {
                       for(var i=0;i<val.split(" ").length;i++)
                       {
                            if(val.split(" ")[i]>16 || val.split(" ")[i].length > 2)
                            {
                                alert('号码输入错误！蓝球号码范围是01-16');
                                return false;
                            }
                            arr[i]=val.split(" ")[i];
                       }
                    }
                    //只有一个号码
                    if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                    {
                        if(val>16 || val.length != 2 || parseInt(val)<=0)
                        {
                            alert('号码输入错误！蓝球号码范围是01-16');
                            return false;
                        }
                        arr[0]=val;
                    }
                }
                else
                {
                     alert('格式输入错误!正确格式：（号码，号码） 或者 （号码 号码）');
                     return false;
                }
            
                  twoArr=maopao(unique(arr));              
                //*****************连接数据库*****************
                        var time=new Date();
                        //提交的时间
                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                        var issue=$("#txt_time").val();
                        if(issue=="" || issue==null || issue=="null")
                        {
                            alert('期号生成错误，请刷新一下页面');
                            return false;
                        }
                        //取是否推荐的标识
                        var rcd=$("input[name='yn']:checked").val();
                        //取胆码或是杀码的标识
                        var courage=$("input[name='courage']:checked").val();
                          //提示发布的号码；
                         if(confirm("您发布的蓝球胆码的号码是："+ twoArr))
                         {    
                              //*******回调函数******
                                $.ajax({
                                         type: "POST",
                                         contentType: "application/json",
                                         url: "WebService1.asmx/AddItem",
                                         data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                         dataType: 'json',
                                         complete: function(result) {
                                         //result返回的值
                                            if(result.responseText==0)
                                            {
                                                alert("已添加过'"+ issue +"'期的数据");
                                                return false;
                                            }
                                            else
                                            {
                                                result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                $("#selecttags").val()="";
                                            }
                                               
                                         }
                                     });
                              //**********end************ 
                          }
                          else
                          {
                               return false;
                          }
                    //*********************end**********************
                
            }
            
            
            if(lotteryType.value.split('&')[1].split('|')[0]=="号码组")
            {
            
                    
            }    
            if(lotteryType.value.split('&')[1].split('|')[0]=="红球复式")
            {
                if($("#txt_time").val()=="" || parseInt($("#txt_time").val())<=0)
                {
                    alert('期号生成错误，请重新选择彩种！');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    alert('双色球胆码的数据输入不正确！空格输入过多！');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                if(val.split("<br>").length>1)
                {
                    alert('请把号码写在一行上！');
                    return false;
                }
                
                //输入数据是数字和逗号的组合
                if(val.replace(/\d+(?:,\d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        arr[i]=val.split(",")[i];
                    }
                }
                //输入号码是数字和空格的组合
                if(val.replace(/\d+(?: \d+)+/,"")=="" )
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        arr[i]=val.split(",")[i];
                    } 
                }
                twoArr=maopao(unique(arr));
                if(twoArr.length<6 || twoArr.length>33)
                {
                    alert('红球复式输入的号码不能少于6个不能多余33个');
                    return false;
                }
                //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                  //提示发布的号码；
                                 if(confirm("红球复式的号码是："+ twoArr))
                                 {    
                                  //*******回调函数******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result返回的值
                                                if(result.responseText==0)
                                                {
                                                    alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    $("#selecttags").val()="";
                                                }
                                                   
                                             }
                                         });
                                  //**********end************ 
                                  }
                                  else
                                  {
                                    return false;
                                  }
                            //*********************end**********************
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="蓝球复式")
            {
                if($("#txt_time").val()=="" || parseInt($("#txt_time").val())<=0)
                {
                    alert('期号生成错误，请重新选择彩种！');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    alert('双色球l蓝球复式的号码格式输入不正确！');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                if(val.split("<br>").length>1)
                {
                    alert('请把号码写在一行上！');
                    return false;
                }
                //输入数据是数字和逗号的组合
                if(val.replace(/\d+(?:,\d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        if(val.split(",")[i]>16)
                        {
                            alert('蓝球号码是1--16');
                            return false;
                        }
                        arr[i]=val.split(",")[i];
                    }
                }
                //输入号码是数字和空格的组合
                if(val.replace(/\d+(?: \d+)+/,"")=="" )
                {
                    for(var i=0;i<val.split(" ").length;i++)
                    {
                        if(val.split(" ")[i]>16)
                        {
                            alert('蓝球号码是1--16');
                            return false;
                        }
                        arr[i]=val.split(",")[i];
                    } 
                }
                twoArr=maopao(unique(arr));
                if(twoArr.length<2 || twoArr.length>16)
                {
                    alert('红球号码不能低于2个，不能大于16个！');
                    return false;
                }
                //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                  //提示发布的号码；
                                 if(confirm("蓝球复式的号码是："+ twoArr))
                                 {  
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************
                                  } 
                                  else
                                  {
                                        return false;
                                  }
                 //*********************end**********************
            }
            
            if(lotteryType.value.split('&')[1].split('|')[0]=="红蓝复式")
            {
                if($("#txt_time").val()=="" ||  parseInt($("#txt_time").val())<0)
                {
                    alert('期号为空，请刷新页面重新选择');
                    return false;
                }
                if($("#selecttags").val()=="")
                {
                    alert('复式方案没有数据！');
                    return false;
                }
                else
                {
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var strRed="";
                    var strBlue="";
                    if(val.split("<br>").length>1)
                    {
                        alert('请在把数据写成一行！');
                        return false;
                    }
                    //判断输入格式是不是 XXXX+XXX这中类型
                    if(val.split("+").length!=2)
                    {
                        alert('输入格式（红球号码+蓝球号码）！');
                        return false;
                    }
                    if((val.split("+")[0].replace(/\d+(?:,\d+)+/,"")!="" && val.split("+")[1].replace(/\d+(?:,\d+)+/,"")!="") || (val.split("+")[0].replace(/\d+(?: \d+)+/,"")!="" && val.split("+")[1].replace(/\d+(?: \d+)+/,"")!=""))
                    {
                        alert('号码请用逗号或是用空格隔开');
                        return false;
                    }
                    else
                    {
                        //号码是逗号加数字
                        if(val.split("+")[0].replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            //处理红球
                            for(var i=0;i<val.split("+")[0].split(",").length;i++)
                            {
                                if(val.split("+")[0].split(",")[i].length > 2 || val.split("+")[0].split(",")[i]>33)
                                {
                                    alert('您输入的号码有错误！');
                                    return false;
                                }
                                arr[i]=val.split("+")[0].split(",")[i];
                            }
                        }
                        //输入是空格的数据
                        if(val.split("+")[0].replace(/\d+(?: \d+)+/,"")=="")
                        {
                            //处理红球
                            for(var i=0;i<val.split("+")[0].split(" ").length;i++)
                            {
                                if(val.split("+")[0].split(" ")[i].length>2 || val.split("+")[0].split(" ")[i]>33)
                                {
                                    alert('您输入的号码有错误！');
                                    return false;
                                }
                                arr[i]=val.split("+")[0].split(" ")[i];
                            }
                        }
                        //去除红球的重复号码和排序
                        var redArr=new Array;
                        redArr=maopao(unique(arr));
                        if(redArr.length<6)
                        {
                            alert('红球号码最少是6位！');
                            return false;
                        }
                        //蓝球是空格加数字组成
                        if(val.split("+")[1].replace(/\d+(?: \d+)+/,"")=="")
                        {
                            //处理蓝球
                            for(var j=0;j<val.split("+")[1].split(" ").length;j++)
                            {
                                if(val.split("+")[1].split(" ")[j].length>2 || val.split("+")[1].split(" ")[j]>16)
                                {
                                    alert('您的蓝球输入有错误，请检查！');
                                    return false;
                                }
                                twoArr[j]=val.split("+")[1].split(" ")[j];
                            }
                        }
                        //蓝球是逗号加数字组成
                        if(val.split("+")[1].replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            //处理蓝球
                            for(var j=0;j<val.split("+")[1].split(",").length;j++)
                            {
                                if(val.split("+")[1].split(",")[j].length>2 || val.split("+")[1].split(",")[j]>16)
                                {
                                    alert('您的蓝球输入有错误，请检查！');
                                    return false;
                                }
                                twoArr[j]=val.split("+")[1].split(",")[j];
                            }
                        }
                        //蓝球号码只有一个
                        if(val.split("+")[1].replace(/^[0-9]*[1-9][0-9]*$/,"")=="" && val.split("+")[1].length==2)
                        {
                            if(val.split("+")[1]>16)
                            {
                                alert('蓝球号码输入有误');
                                return false;
                            }
                            twoArr[0]=val.split("+")[1];
                        }
                        var pm=redArr+ "+" + maopao(unique(twoArr));
                        //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                   //提示发布的号码；
                                 if(confirm("红蓝复式的号码是："+ pm))
                                 {    
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                        return false;
                                  }
                      //*********************end**********************
                        
                    }
                }
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="单式")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('期号错误请重新选择');
                    return false;
                }
                if($("#selecttags").val()=="")
                {
                    alert('复式方案没有数据！');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                var str="";
                if(val.split("<br>").length>1)
                {
                    alert('请在把数据写成一行！');
                    return false;
                }
                //判断输入格式是不是 XXXX+XXX这中类型
                if(val.split("+").length!=2)
                {
                    alert('输入格式（红球号码+蓝球号码）！');
                    return false;
                }
                if(val.split("+")[0].replace(/\d+(?:,\d+)+/,"")!="" || val.split("+")[0].split(",").length!=6 )
                {
                    alert('请检查输入的格式和数据是否正确');
                    return false;
                }
                if(val.split("+")[1].replace(/\d+(?:,\d+)+/,"")=="")
                {
                    alert('单选条件，请写入一个蓝球');
                    return false;
                }
                if(val.split("+")[1].replace(/^[0-9]*[1-9][0-9]*$/,"")!="" || val.split("+")[1]>16)
                {
                    alert('蓝球号码输入错误！');
                    return false;
                }
                else
                {
                    for(var i=0;i<val.split("+")[0].split(",").length;i++)
                    {
                        if(val.split("+")[0].split(",")[i].length>2 || val.split("+")[0].split(",")[i].replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                        {
                            alert('输入的红球号码有误！');
                            return false;
                        }
                        arr[i]=val.split("+")[0].split(",")[i];
                    }
                    twoArr=unique(arr);
                    var pm=twoArr+"+"+val.split("+")[1];
                    //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                    //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {    
                                  //*******回调函数******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result返回的值
                                                if(result.responseText==0)
                                                {
                                                    alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    $("#selecttags").val()="";
                                                }
                                                   
                                             }
                                         });
                                  //**********end************
                                  }
                                  else
                                  {
                                        return false;
                                  } 
                 //*********************end**********************
                }
            }        
         }
         //**************s双色球end***********************
         
         //**************七乐彩 begin*********************
            if(lotteryType.value.split('&')[0].split('"')[1]=="七乐彩")
            {
                if(lotteryType.value.split('&')[1].split('|')[0]=="胆码")
                {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    //替换回车
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1 && val.split("<br>").length<31)
                    {
                        //多行输入
                        for(var i=0;i<val.split("<br>").length;i++)
                        {
                            arr[i]=val.split("<br>")[i];
                        }
                        for(var j=0;j<arr.length;j++)
                        {
                            if(arr[j].length>30)
                            {
                                alert('输入的号码不能超过了 30位！');
                                return false;
                            }   
                            //处理逗号
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(",").length;k++)
                                {
                                    if(arr[j].split(",")[k].length>2)
                                    {
                                        alert('七乐彩的号码为2位数！');
                                        return false;
                                    }
                                    str+=arr[j].split(",")[k]+",";
                                }
                            }
                            //处理空格
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2)
                                    {
                                        alert('七乐彩的号码为2位数！');
                                        return false;
                                    }
                                    str+arr[j].split(" ")[k]+ ",";
                                }
                            }
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="" && arr[j].length==2)
                            {
                                str+=arr[j]+ ",";
                            }
                            
                        }
                        //去除最后一个,号
                        var dpstr=str.substring(0,str.length-1);
                        for(var p=0;p<dpstr.split(",").length;p++)
                        {
                            twoArr[p]=dpstr.split(",")[p];
                        }
                        var pm=new Array;
                        pm=maopao(unique(twoArr));
                        if(pm.length<6 || pm.length>30)
                        {
                            alert('您输入的号码个数错误。');
                            return false;
                        }
                        //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                  //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {      
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                    return false;
                                  }
                     //*********************end**********************
                        
                    }
                    //如果输入的号码只有一行
                    //一行号码是逗号和数字组成
                    if(val.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(",").length;i++)
                        {
                            if(val.split(",")[i].length>2)
                            {
                                alert('您输入的号码错误！');
                                return false;
                            }
                            arr[i]=val.split(",")[i];
                        }
                    }
                    //一行号码是空格和数字组成
                    if(val.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(" ").length;i++)
                        {
                            if(val.split(" ")[i].length>2)
                            {
                                alert('您输入的号码错误！');
                                return false;
                            }
                            arr[i]=val.split(" ")[i];
                        }
                    }
                    if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                    {
                        if(val.length>2)
                        {
                            alert('您输入的号码错误！');
                            return false;
                        }
                        arr[0]=val;
                    }
                    //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                  //提示发布的号码；
                                 if(confirm("您发布的号码是："+ arr))
                                 {      
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ arr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                    return false;
                                  }
                     //*********************end**********************
                    
                }
                if(lotteryType.value.split('&')[1].split('|')[0]=="复式")
                {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1)
                    {
                        for(var i=0;i<val.split("<br>").length;i++)
                        {
                            arr[i]=val.split("<br>")[i];
                        }
                        for(var j=0;j<arr.length;j++)
                        {
                            //元素是逗号和数字组成
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                               for(var k=0;k<arr[j].split(",").length;k++)
                               {
                                    if(arr[j].split(",")[k].length>2)
                                    {
                                        alert('输入的号码不能超过2位数字');
                                        return false;
                                    }
                                    str+=arr[j].split(",")[k]+",";
                               }
                            }
                            //元素是空格和数字组成
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(" ").length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2)
                                    {
                                        alert('输入的号码不能超过2位数字');
                                        return false;
                                    }
                                    str+=arr[j].split(" ")[k]+",";
                                }
                                
                            }
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                            {
                                if(arr[j].length>2)
                                {
                                    alert('输入的号码不能超过2位数字');
                                    return false;
                                }
                            }
                            //去除最后一个逗号
                            var dpstr=str.substring(0,str.length-1);
                            for(var p=0;p<dpstr.split(",").length;p++)
                            {
                                twoArr[p]=dpstr.split(",")[p];
                            }
                            var pm=new Array;
                            pm=maopao(unique(twoArr));
                            if(pm.length<7 || pm.length>30)
                            {
                                alert('七乐彩复式号码输入不正确！');
                                return false;
                            }
                            //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {      
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                       
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                        return false;
                                  }
                           //*********************end**********************
                        }
                    }
                }
                if(lotteryType.value.split('&')[1].split('|')[0]=="单式")
                {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1)
                    {
                        alert('请把号码输入成一行！');
                        return false;
                    }
                    if(val.replace(/\d+(?:,\d+)+/,"")!="" || val.replace(/\d+(?: \d+)+/,"")!="")
                    {
                        alert('七乐彩单式的条件输入格式不正确！');
                        return false;
                    }
                    //元素是逗号和数字组成
                    if(val.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(",").length;i++)
                        {
                            if(val.split(",")[i].length>2)
                            {
                                alert('号码输入有误');
                                return false;
                            }
                            arr[i]=val.split(",")[i];
                        }
                    }
                    //元素是空格和数字组成
                    if(val.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(" ").length;i++)
                        {
                            if(val.split(" ")[i].length>2)
                            {
                                alert('号码输入有误');
                                return false;
                            }
                            arr[i]=val.split(" ")[i];
                        }
                    }
                    twoArr=maopao(unique(arr));
                    if(twoArr.length>7)
                    {

                        alert('七乐彩单式条件的号码个数输入有误！');
                        return false;

                    }
                    //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ twoArr))
                                 {       
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                        return false;
                                  }
                  //*********************end**********************
                }
                
            }
         //*******************七乐彩 end******************
         
         //*******************大乐透彩票 begin***********
          if(lotteryType.value.split('&')[0].split('"')[1]=="大乐透")
          {
               if(lotteryType.value.split('&')[1].split('|')[0]=="前区胆码")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>35)
                    {
                        alert('您的号码输入太多。超出范围');
                        return false;
                    }
                    if(val.split("<br>").length>1)
                    {
                         for(var i=0;i<val.split("<br>").length;i++)
                         {
                            arr[i]=val.split("<br>")[i];
                         }
                         for(var j=0;j<arr.length;j++)
                         {
                            //号码是逗号和数字组成的
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                                for(var k=0; k<arr[j].split(",").length;k++)
                                {
                                    if(arr[j].split(",")[k].length>2 || arr[j].split(",")[k]>35)
                                    {
                                        alert('号码输入不正确！');
                                        return false;
                                    }
                                    str+=arr[j].split(",")[k]+ ",";
                                }
                            }
                            //号码是空格和数字组成的
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(" ").length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2 || arr[j].split(" ")[k]>35)
                                    {
                                        alert('号码输入不正确');
                                        return false;
                                    }
                                    str+=arr[j].split(" ")[k]+ ",";
                                }
                            }
                            //只有一个胆码号；
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                            {
                                if(arr[j].length>2 || arr[j]>35)
                                {
                                    alert('号码输入不正确');
                                    return false;
                                }
                                str+=arr[j]+",";
                            }
                         }
                         //去掉最后一个逗号
                         var dpstr=str.substring(0,str.length-1);
                         for(var p=0;p<dpstr.split(",").length;p++)
                         {
                            twoArr[p]=dpstr.split(",")[p];
                         }
                         //排序去重复
                         var pm=new Array;
                         pm=maopao(unique(twoArr));
                         if(pm.length>35)
                         {
                            alert('您输入的号码太多');
                            return false;
                         }
                             //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {       
                                  //*******回调函数******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result返回的值
                                                if(result.responseText==0)
                                                {
                                                    alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    $("#selecttags").val()="";
                                                }
                                             }
                                         });
                                  //**********end************ 
                                 }
                                 else
                                 {
                                    return false;
                                 }
                        //*********************end**********************
                    }  
                    else
                    {
                    
                    }    
               }
               if(lotteryType.value.split('&')[1].split('|')[0]=="后区胆码")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    //输入有回车符
                    if(val.split("<br>").length>1 && val.split("<br>").length<13)
                    {
                        for(var i=0;i<val.split("<br>").length;i++)
                        {
                            arr[i]=val.split("<br>")[i];
                        }
                        for(var j=0;j<arr.length;j++)
                        {
                            //验证数据是空格+数字的模式
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(" ").length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2 || arr[j].split(" ")[k]>12)
                                    {
                                        alert('您输入的号码有错误');
                                        return false;
                                    }
                                    str+=arr[j].split(" ")[k] + ",";
                                }
                            }
                            //验证数据是逗号+数字的模式
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(",").length;k++)
                                {
                                    if(arr[j].split(",")[k]>2 || arr[j].split(",")[k]>12)
                                    {
                                        alert('您输入的号码有错误');
                                        return false;
                                    }
                                    str+= arr[j].split(",")[k] + ",";
                                }
                            }
                            //验证数据是1个号码
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                            {
                                if(arr[j].length>2 || arr[j]>12)
                                {
                                    alert('您输入的号码有问题');
                                    return false;
                                }
                                str+= arr[j] + ",";
                            }
                        }
                        //去除字符串中的最后一个逗号
                        var dpstr=str.substring(0,str.length-1);
                        for(var p=0;p<drstr.split(",").length;p++)
                        {
                            twoArr[p]=dpstr.split(",")[p];
                        }
                        var pm=new Array;
                        pm=maopao(unique(twoArr));
                        if(pm.length>12)
                        {
                            alert('您输入的号码过多');
                            return false;
                        }
                        //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {       
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                    return false;
                                  }
                        //*********************end**********************
                    }
                    else
                    {
                        //输入的是一行号码
                        //验证数据是空格+数字的模式
                        if(val.replace(/\d+(?: \d+)+/,"")=="")
                        {
                            for(var k=0;k<arr[j].split(" ").length;k++)
                            {
                                if(val.split(" ")[k].length>2 || val.split(" ")[k]>12)
                                {
                                    alert('您输入的号码有错误');
                                    return false;
                                }
                                arr[k]=val.split(" ")[k];
                            }
                        }
                        //验证数据是逗号+数字的模式
                        if(val.replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            for(var k=0;k<arr[j].split(",").length;k++)
                            {
                                if(val.split(",")[k]>2 || val.split(",")[k]>12)
                                {
                                    alert('您输入的号码有错误');
                                    return false;
                                }
                                arr[k] = val.split(",")[k];
                            }
                        }
                        //验证数据是1个号码
                        if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                        {
                            if(val.length>2 || val>12)
                            {
                                alert('您输入的号码有问题');
                                return false;
                            }
                            arr[0] = val ;
                        }
                        //去除重复
                        var pm=new Array;
                        pm=maopao(unique(arr));
                        //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {     
                                  //*******回调函数******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result返回的值
                                                if(result.responseText==0)
                                                {
                                                    alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                    $("#selecttags").val()="";
                                                }
                                             }
                                         });
                                  //**********end************ 
                                  }
                                  else
                                  {
                                        return false;
                                  }
                                  
                        //*********************end**********************
                    }
               }
               if(lotteryType.value.split('&')[1].split('|')[0]=="复式")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1)
                    {
                        alert('请把号码写成一行！号码太多会自动换行');
                        return false;    
                    }
                    if(val.split("+").length!=2)
                    {
                        alert('复式输入格式：号码 + 号码 ，号码间用，号或空格隔开');
                        return false;
                    }
                    //处理+号前面的号码  *****begein
                    var front=val.split("+")[0];
                    var frontArr=new Array;
                    if(front.replace(/\d+(?:,\d+)+/,"")!="" || front.replace(/\d+(?: \d+)+/,"")!="")
                    {
                        alert('输入的号码格式错误');
                        return false;
                    }
                    //匹配逗号
                    if(front.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i< front.split(",").length;i++)
                        {
                            if(front.split(",")[i].length>2 || front.split(",")[i]>35)
                            {
                                alert('输入的号码有错误');
                                return false;
                            }
                            arr[i]=front.split(",")[i];
                        }
                    }
                    //匹配空格
                    if(front.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<front.split(" ").length;i++)
                        {
                            if(front.split(" ")[i].length>2 || front.split(" ")[i]>35)
                            {
                                alert('输入的号码有错误');
                                return false;
                            }
                            arr[i]=front.split(" ")[i];
                        }
                    }
                    frontArr=maopao(unique(arr));
                    if(frontArr.length<5 || frontArr.length>35)
                    {
                        alert('输入的号码个数错误');
                        return false;
                    } 
                    //*****end
                    //处理+号后面的号码 ****begin
                    var back=val.split("+")[1];
                    var backArr=new Array;
                    if(back.replace(/\d+(?:,\d+)+/,"")!="" || back.replace(/\d+(?: \d+)+/,"")!="")
                    {
                        alert('输入的号码格式错误');
                        return false;
                    }
                    //匹配,号
                    if(back.replace(/\d+(?:,\d+)+/,"")=="" )
                    {
                        for(var i=0;i<back.split(",").length;i++)
                        {
                            if(back.split(",")[i].length>2 || back.split(",")[i]>12)
                            {
                                alert('您输入的号码有错误');
                                return false;
                            }
                            twoArr[i]=back.split(",")[i];
                        }
                    }
                    //匹配空格
                    if(back.replace(/\d+(?: \d+)+/,"")=="")                  
                    {
                        for(var i=0;i<back.split(" ").length;i++)
                        {
                            if(back.split(" ")[i].length>2 || back.split(" ")>12)
                            {
                                alert('您输入的号码有错误');
                                return false;
                            }
                            twoArr[i]=back.split(" ")[i];
                        }
                    }
                    backArr=maopao(unique(twoArr));
                    if(backArr.length<2 || back.length>12)
                    {
                        alert('号码个数输入不正确');
                        return false;
                    }
                    var pm=frontArr + "+" + backArr;
                    //*****end
                    //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {     
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                     return false;
                                  }
                        //*********************end**********************
               }
               if(lotteryType.value.split('&')[1].split('|')[0]=="单式")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('期号错误请重新选择');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('号码输入不正确');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    
                    if(val.split("<br>").length>1)
                    {
                        alert('请把号码写成一行');
                        return false;
                    }
                    if(val.split("+").length!=2)
                    {
                        alert('单式输入格式是前区号码+后区号码，多个号码间用逗号货空格隔开');
                        return false;
                    }
                    //处理前区号码
                    var frontNum=val.split("+")[0];
                    var frontArr=new Array;
                    if(frontNum.replace(/\d+(?: \d+)+/,"")!="" || frontNum.replace(/\d+(?:,\d+)+/,"")!="")
                    {
                        alert('前区号码格式输入错误。');
                        return false;
                    }
                    //号码是空格和数字组成
                    if(frontNum.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<frontNum.split(" ").length;i++)
                        {
                            if(frontNum.split(" ")[i].length>2 || frontNum.split(" ")[i]>35)
                            {
                                alert('您输入的号码有错误，请检查');
                                return false;
                            }
                            arr[i]=frontNum.split(" ")[i];
                        }
                        frontArr=maopao(unique(arr));
                        if(frontArr.length!=5)
                        {
                            alert('前区号码输入错误');
                            return false;
                        }
                    }
                    //号码是逗号加数字组成
                    if(frontNum.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<frontNum.split(",").length;i++)
                        {
                            if(frontNum.split(",")[i].length>2 || frontNum.split(",")[i]>35)
                            {
                                alert('您输入的号码有错误，请检查');
                                return false;
                            }
                            arr[i]=frontNum.split(",")[i];
                        }
                        frontArr=maopao(unique(arr));
                        if(frontArr.length!=5)
                        {
                            alert('前区号码输入错误');
                            return false;
                        }
                    }
                    //处理后区号码
                    var backNum=val.split("+")[1];
                    var backArr=new Array;
                    if(backNum.replace(/\d+(?: \d+)+/,"")!="" || backNum.replace(/\d+(?:,\d+)+/,"")!="")
                    {
                        alert('后区号码格式输入错误。');
                        return false;
                    }
                    //号码匹配空格
                    if(backNum.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<backNum.split(" ").length;i++)
                        {
                            if(backNum.split(" ").length>2 || backNum.split(" ")[i]>12)
                            {
                                alert('您输入的后区号码错误。请检查');
                                return false;
                            }
                            twoArr[i]=backNum.split(" ")[i];
                        }
                        backArr=maopao(unique(twoArr));
                        if(backArr.length!=2)
                        {
                            alert('后区号码输入错误');
                            return false;
                        }
                    }
                    //号码匹配逗号
                    if(backNum.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<backNum.split(",").length;i++)
                        {
                            if(backNum.split(",").length>2 || backNum.split(",")[i]>12)
                            {
                                alert('您输入的后区号码错误，请检查');
                                return false;
                            }
                            twoArr[i]=backNum.split(",")[i];
                        }
                        backArr=maopao(unique(twoArr));
                        if(backArr.length!=2)
                        {
                            alert('后区号码输入错误');
                            return false;
                        }
                    }
                    var pm= frontNum + "+" + backNum;
                    //*****************连接数据库*****************
                                var time=new Date();
                                //提交的时间
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('期号生成错误，请刷新一下页面');
                                    return false;
                                }
                                //取是否推荐的标识
                                var rcd=$("input[name='yn']:checked").val();
                                //取胆码或是杀码的标识
                                var courage=$("input[name='courage']:checked").val();
                                 //提示发布的号码；
                                 if(confirm("您发布的号码是："+ pm))
                                 {     
                                      //*******回调函数******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result返回的值
                                                    if(result.responseText==0)
                                                    {
                                                        alert("已添加过'"+ issue +"'期的数据");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                                        $("#selecttags").val()="";
                                                    }
                                                 }
                                             });
                                      //**********end************ 
                                  }
                                  else
                                  {
                                    return false;
                                  }
                  //*********************end**********************
               }
          }
         //******************大乐透彩票 end**************
         //************七星彩彩票 begin*****************
         if(lotteryType.value.split('&')[0].split('"')[1]=="七星彩")
         {
            if(lotteryType.value.split('&')[1].split('|')[0]=="胆码")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('期号错误请重新选择');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    
                    alert('号码输入不正确');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                if(val.split("<br>").length>1)
                {
                    alert('您输入的号码有回车符，请重新输入');
                    return false;
                }
                if( val.replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                {
                    alert('号码应该是0000000-9999999的正整数');
                    return false;
                }
                var pm=RemoveRepeat(val);
                //*****************连接数据库*****************
                    var time=new Date();
                    //提交的时间
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('期号生成错误，请刷新一下页面');
                        return false;
                    }
                    //取是否推荐的标识
                    var rcd=$("input[name='yn']:checked").val();
                    //取胆码或是杀码的标识
                    var courage=$("input[name='courage']:checked").val();
                      //提示发布的号码；
                     if(confirm("您发布的号码是："+ pm))
                     {    
                          //*******回调函数******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result返回的值
                                        if(result.responseText==0)
                                        {
                                            alert("已添加过'"+ issue +"'期的数据");
                                            return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                            $("#selecttags").val()="";
                                        }
                                     }
                                 });
                          //**********end************ 
                      }
                      else
                      {
                            return false;
                      }
             //*********************end**********************           
                
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="定位胆码")
            {
                var num1="f1";
                var num2="f2";
                var num3="f3";
                var num4="f4";
                var num5="f5";
                var num6="f6";
                var num7="f7"
                if($("#Text1").val().length>1 || $("#Text2").val()>1 || $("#Text3").val()>1 || $("#Text4").val()>1 || $("#Text5").val()>1 || $("#Text6").val()>1 || $("#Text7").val()>1)
                {
                    alert('号码为0-9间的数字');
                    return false;
                }
                if(trim($("#Text1").val())!="")
                {
                    if(trim($("#Text1").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num1=trim($("#Text1").val());
                }
                if(trim($("#Text2").val())!="")
                {
                    if(trim($("#Text2").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num2=trim($("#Text2").val());
                }
                if(trim($("#Text3").val())!="")
                {
                    if(trim($("#Text3").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num3=trim($("#Text3").val());
                }
                if(trim($("#Text4").val())!="")
                {
                    if(trim($("#Text4").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num4=trim($("#Text4").val());
                }
                if(trim($("#Text5").val())!="")
                {
                    if(trim($("#Text5").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num5=trim($("#Text5").val());
                }
                if(trim($("#Text6").val())!="")
                {
                    if(trim($("#Text6").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num6=trim($("#Text6").val());
                }
                if(trim($("#Text7").val())!="")
                {
                    if(trim($("#Text7").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0-9间的数字');
                        return false;
                    }    
                    num7=trim($("#Text7").val());
                }
                var pm=RemoveRepeat(num1)+"|"+RemoveRepeat(num2)+"|"+RemoveRepeat(num3)+"|"+RemoveRepeat(num4)+"|"+RemoveRepeat(num5)+"|"+RemoveRepeat(num6)+"|"+RemoveRepeat(num7);
                //*****************连接数据库*****************
                    var time=new Date();
                    //提交的时间
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('期号生成错误，请刷新一下页面');
                        return false;
                    }
                    //取是否推荐的标识
                    var rcd=$("input[name='yn']:checked").val();
                    //取胆码或是杀码的标识
                    var courage=$("input[name='courage']:checked").val();
                     //提示发布的号码；
                     if(confirm("您发布的号码是："+ pm))
                     {     
                      //*******回调函数******
                        $.ajax({
                                 type: "POST",
                                 contentType: "application/json",
                                 url: "WebService1.asmx/AddItem",
                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                 dataType: 'json',
                                 complete: function(result) {
                                 //result返回的值
                                    if(result.responseText==0)
                                    {
                                        alert("已添加过'"+ issue +"'期的数据");
                                         return false;
                                    }
                                    else
                                    {
                                        result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                        $("#Text1").val()="";
                                        $("#Text2").val()="";
                                        $("#Text3").val()="";
                                        $("#Text4").val()="";
                                        $("#Text5").val()="";
                                        $("#Text6").val()="";
                                        $("#Text7").val()="";
                                    }
                                 }
                             });
                      //**********end************ 
                      }
                      else
                      {
                            return false;
                      }
             //*********************end**********************   
                
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="定位复式")
            {
                var num1="f1";
                var num2="f2";
                var num3="f3";
                var num4="f4";
                var num5="f5";
                var num6="f6";
                var num7="f7"
                if($("#Text1").val().length>7 || $("#Text2").val()>7 || $("#Text3").val()>7 || $("#Text4").val()>7 || $("#Text5").val()>7 || $("#Text6").val()>7 || $("#Text7").val()>7)
                {
                    alert('号码为0-9间的数字');
                    return false;
                }
                if(trim($("#Text1").val())!="")
                {
                    if(trim($("#Text1").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num1=trim($("#Text1").val());
                }
                if(trim($("#Text2").val())!="")
                {
                    if(trim($("#Text2").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num2=trim($("#Text2").val());
                }
                if(trim($("#Text3").val())!="")
                {
                    if(trim($("#Text3").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num3=trim($("#Text3").val());
                }
                if(trim($("#Text4").val())!="")
                {
                    if(trim($("#Text4").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num4=trim($("#Text4").val());
                }
                if(trim($("#Text5").val())!="")
                {
                    if(trim($("#Text5").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num5=trim($("#Text5").val());
                }
                if(trim($("#Text6").val())!="")
                {
                    if(trim($("#Text6").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num6=trim($("#Text6").val());
                }
                if(trim($("#Text7").val())!="")
                {
                    if(trim($("#Text7").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('号码为0000000-9999999间的数字');
                        return false;
                    }    
                    num7=trim($("#Text7").val());
                }
                var pm=num1+"|"+num2+"|"+num3+"|"+num4+"|"+num5+"|"+num6+"|"+num7;
                //*****************连接数据库*****************
                    var time=new Date();
                    //提交的时间
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('期号生成错误，请刷新一下页面');
                        return false;
                    }
                    //取是否推荐的标识
                    var rcd=$("input[name='yn']:checked").val();
                    //取胆码或是杀码的标识
                    var courage=$("input[name='courage']:checked").val();
                     //提示发布的号码；
                     if(confirm("您发布的号码是："+ pm))
                     {     
                          //*******回调函数******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result返回的值
                                        if(result.responseText==0)
                                        {
                                            alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                            $("#Text1").val()="";
                                            $("#Text2").val()="";
                                            $("#Text3").val()="";
                                            $("#Text4").val()="";
                                            $("#Text5").val()="";
                                            $("#Text6").val()="";
                                            $("#Text7").val()="";
                                        }
                                     }
                                 });
                          //**********end************ 
                      }
                      else
                      {
                            return false;
                      }
             //*********************end********************** 
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="单式")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('期号错误请重新选择');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    
                    alert('号码输入不正确');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                if(val.split("<br>").length>1)
                {
                    alert('您输入的号码带有回车符号');
                    return false;
                }
                if(val.lengtn!=7)
                {
                    alert('您输入的号码个数错误。');
                    return false;
                }
                //*****************连接数据库*****************
                    var time=new Date();
                    //提交的时间
                   var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                   var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                   var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                   var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('期号生成错误，请刷新一下页面');
                        return false;
                    }
                    //取是否推荐的标识
                    var rcd=$("input[name='yn']:checked").val();
                    //取胆码或是杀码的标识
                    var courage=$("input[name='courage']:checked").val();
                     //提示发布的号码；
                     if(confirm("您发布的号码是："+ val))
                     {     
                          //*******回调函数******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ val +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result返回的值
                                        if(result.responseText==0)
                                        {
                                            alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                            $("#selecttags").val()="";
                                        }
                                     }
                                 });
                          //**********end************ 
                     }
                     else
                     {
                        return false;
                     }
             //*********************end********************** 
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="号码组")
            {
                
            }
         }
         //*************七星彩彩票 end*******************
         
         //**********排列5彩票 begin**************
         if(lotteryType.value.split('&')[0].split('"')[1]=="排列五")
         {
            
            if(lotteryType.value.split('&')[1].split('|')[0]=="胆码")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('期号错误请重新选择');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    alert('号码输入不正确');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                if(val.split("<br>").length>1)
                {
                    alert('输入格式错误,请不要不输入回车');
                    return false;
                }
                //数据匹配空格
                if(val.replace(/\d+(?: \d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(" ").length;i++)
                    {
                        if(val.split(" ")[i].length>1 || val.split(" ")[i]>9)
                        {
                            alert('请输入0-9之间的号码');
                            return false;
                        }
                        arr[i]=val.split(" ")[i];
                    }
                }
                //数据匹配逗号
                if(val.replace(/\d+(?:,\d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        if(val.split(",")[i].length>1 || val.split(",")[i]>9)
                        {
                            alert('请输入0-9之间的号码');
                            return false;
                        }
                        arr[i]=val.split(",")[i];
                    }
                }
                //只有一个号码
                if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                {
                    if(val.length>1 || val>9)
                    {
                        alert('请输入0-9之间的号码');
                        return false;
                    }
                    arr[0]=val;
                }
                //去重复排序
                var pm=new Array;
                pm=maopao(unique(arr));
                //*****************连接数据库*****************
                    var time=new Date();
                    //提交的时间
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('期号生成错误，请刷新一下页面');
                        return false;
                    }
                    //取是否推荐的标识
                    var rcd=$("input[name='yn']:checked").val();
                    //取胆码或是杀码的标识
                    var courage=$("input[name='courage']:checked").val();
                    //提示发布的号码；
                     if(confirm("您发布的号码是："+ pm))
                     {      
                          //*******回调函数******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result返回的值
                                        if(result.responseText==0)
                                        {
                                            alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                            $("#selecttags").val()="";
                                        }
                                     }
                                 });
                          //**********end************ 
                     }
                     else
                     {
                        return false;
                     }
             //*********************end********************** 
            }
           if(lotteryType.value.split('&')[1].split('|')[0]=="定位胆码")
           {
                var pl1;
                var pl2;
                var pl3;
                var pl4;
                var pl5;
                
                if($("#pl1").val()=="" && $("#pl2").val()=="" && $("#pl3").val()=="" && $("#pl4").val()=="" && $("#pl5").val()=="")
                {
                    alert('请填写定位胆码的号码');
                    return false;
                }
                
                if($("#pl1").val()=="")
                {
                    pl1="*"+",";
                }
                else
                {
                    if($("#pl1").val()>9 || $("#pl1").val()<0 || $("#pl1").val().replace(/^[0-9]*[0-9][0-9]*$/,"")!="")
                    {
                        alert('第一位：请输入0-9之间的数字');
                        return false;
                    }
                    pl1=$("#pl1").val()+",";
                }
                if($("#pl2").val()=="")
                {
                    pl2="*"+",";
                }
                else
                {

                        if($("#pl2").val()>9 || $("#pl2").val()<0 || $("#pl2").val().replace(/^[0-9]*[0-9][0-9]*$/,"")!="")
                        {
                            alert('第二位：请输入0-9之间的数字');
                            return false;
                        }
                        pl2=$("#pl2").val() + ",";
                }
                if($("#pl3").val()=="")
                {
                    pl3="*"+",";
                }
                else
                {

                       if($("#pl3").val()>9 || $("#pl3").val()<0 || $("#pl3").val().replace(/^[0-9]*[0-9][0-9]*$/,"")!="")
                        {
                            alert('第三位：请输入0-9之间的数字');
                            return false;
                        }
                        pl3=$("#pl3").val() + ",";
                }
                if($("#pl4").val()=="")
                {
                    pl4="*"+",";
                }
                else
                {
                   if($("#pl4").val()>9 || $("#pl4").val()<0 || $("#pl4").val().replace(/^[0-9]*[0-9][0-9]*$/,"")!="")
                        {
                            alert('第四位：请输入0-9之间的数字');
                            return false;
                        }
                        pl4=$("#pl4").val() + ",";
                }
                if($("#pl5").val()=="")
                {
                    pl5="*";
                }
                else
                {
                    if($("#pl5").val()>9 || $("#pl5").val()<0 || $("#pl5").val().replace(/^[0-9]*[0-9][0-9]*$/,"")!="")
                    {
                        alert('第五位：请输入0-9之间的数字');
                        return false;
                    }
                        pl5=$("#pl5").val();
                }
                var str=RemoveRepeat(pl1)+RemoveRepeat(pl2)+RemoveRepeat(pl3)+RemoveRepeat(pl4)+RemoveRepeat(pl5);
                var pm=str;
                //*****************连接数据库*****************
                    var time=new Date();
                    //提交的时间
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('期号生成错误，请刷新一下页面');
                        return false;
                    }
                    //取是否推荐的标识
                    var rcd=$("input[name='yn']:checked").val();
                    //取胆码或是杀码的标识
                    var courage=$("input[name='courage']:checked").val();
                     //提示发布的号码；
                     if(confirm("您发布的号码是："+ pm))
                     {       
                          //*******回调函数******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result返回的值
                                        if(result.responseText==0)
                                        {
                                            alert("已添加过'"+ issue +"'期的数据");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('添加成功') : alert('添加失败');
                                            $("#pl1").val()="";
                                            $("#pl2").val()="";
                                            $("#pl3").val()="";
                                            $("#pl4").val()="";
                                            $("#pl5").val()="";
                                        }
                                     }
                                 });
                          //**********end************
                     }
                     else
                     {
                        return false;
                     } 
             //*********************end********************** 
           }
         }
         //**********排列5彩票  end***************   
     });
});
//生成单选按钮 key4:彩种  key5:类型
//	function addRadio(key1,key2,key3,key4,key5) {
	function addRadio(key1,key2,key3) {
	    var flag1="";
	    var flag2="";
	    var flag3="";
	    if(key1=="")
	    {
	        flag1="display:none";
	    }
	    if(key2=="")
	    {
	        flag2="display:none";
	    }
	    if(key3=="")
	    {
	        flag3="display:none";
	    }
		document.getElementById("Condition_Rad").innerHTML = "<table border='0' width='100%' cellpadding='0' cellspacing='1'><tr><td><input type='radio' name='testRadio' id='radio_1' style='"+ flag1 +"' onclick='javascript:Chooes(this.id);' value='"+ key1 +"' />"+key1+"<input type='radio' name='testRadio' id='radio_2' style='"+ flag2 +"' value='"+ key2 +"' onclick='Chooes(this.id);' />"+key2+"<input type='radio' name='testRadio' id='radio_3' style='"+ flag3 +"' value='"+ key3 +"' onclick='Chooes(this.id);' />"+key3+"</td></tr></table>";
//	     document.getElementById("Condition_Rad").innerHTML = "<input type='radio' name='testRadio' id='radio_1' onclick='javascript:Chooes(this.id)' value='"+ key1 +"' />"+key1+"</label><input type='radio' name='testRadio' id='radio_2' value='"+ key2 +"' onclick='Chooes(this.id);' />"+key2+"</label><input type='radio' name='testRadio' id='radio_3' value='"+ key3 +"' onclick='Chooes(this.id);' />"+key3+"";
	}
	
	//*********begin没有点击事件的单选按钮*************
		function addRadio1(key1,key2,key3) {
	    var flag1="";
	    var flag2="";
	    var flag3="";
	    if(key1=="")
	    {
	        flag1="display:none";
	    }
	    if(key2=="")
	    {
	        flag2="display:none";
	    }
	    if(key3=="")
	    {
	        flag3="display:none";
	    }
		document.getElementById("Condition_Rad").innerHTML = "<table border='0' width='100%' cellpadding='0' cellspacing='1'><tr><td><input type='radio' name='testRadio' id='radio_1' style='"+ flag1 +"' value='"+ key1 +"' onClick='javascript:hide(this.id)' />"+key1+"<input type='radio' name='testRadio' id='radio_2' style='"+ flag2 +"' value='"+ key2 +"' onClick='javascript:hide(this.id)' />"+key2+"<input type='radio' name='testRadio' id='radio_3' style='"+ flag3 +"' value='"+ key3 +"'onClick='javascript:hide(this.id)' />"+key3+"</td></tr></table>";

	}
	 //*****根据隐藏变量的值来显示或是隐藏文本******
	 function hide(obj)
	 {
	        var objName=document.getElementById(obj);
	        var lotteryType=document.getElementById("lotteryType");
            if(lotteryType.value!=null)
            {
                if(lotteryType.value.split("&")[0].split('"')[1]=="3D"  || lotteryType.value.split('&')[0].split('"')[1]=="排列3")
                {
                    if(lotteryType.value.split('&')[1].split('|')[0]=="定位复式")
                    {
                        if(objName.value=="单一输入")
                        {
                            document.getElementById("gut_1").style.display="block";
                            document.getElementById("gut").style.display="none";
                             return;
                        }
                        if(objName.value=="组合输入")
                        {
                           document.getElementById("gut").style.display="block";
                            document.getElementById("gut_1").style.display="none";
                             return;
                        }
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="号码组")
                    {
                        document.getElementById("gut").style.display="block";
                        document.getElementById("gut_1").style.display="none";
                         return;
                    }
                }
            }
      }
        //*******************end**************************
	//*****************end***********************
	
	
	
	//生成多选按钮
	function addCheckbos(key1,key2,key3)
	{
	    var flag1="";
	    var flag2="";
	    var flag3="";
	    if(key1=="")
	    {
	        flag1="display:none";
	    }
	    if(key2=="")
	    {
	        flag2="display:none";
	    }
	    if(key3=="")
	    {
	        flag3="display:none";
	    }

	    document.getElementById("Condition_ck").innerHTML="<table border='0' width='100%' cellpadding='0' cellspacing='1'><tr><td><input id='cb_1' style='"+ flag1 +"' type='checkbox' name='testcheckbox' value='"+ key1 +"' />"+ key1 +" <input id='cb_2' style='"+ flag2 +"' type='checkbox' name='testcheckbox' value='"+ key2 +"' />"+ key2 +"<input id='cb_3' style='"+ flag3 +"' type='checkbox' name='testcheckbox' value='"+ key3 +"' />"+ key3 +"</td></tr></table>";
	    //document.getElementById("Condition_ck").innerHTML="<input id='Checkbox_1' type='checkbox' name='testcheckbox' value='"+ key1 +"' />"+ key1 +" <input id='Checkbox_2' type='checkbox' name='testcheckbox' value='"+ key2 +"' />"+ key2 +"<input id='Checkbox_3' type='checkbox' name='testcheckbox' value='"+ key3 +"' />"+ key3 +"";
	}
	//循环生成多个复选框 ( 可以发复合条件)
	function CycCheckbos(num,key)
	{   
	    
	    var str="<table border='0' width='100%' cellpadding='0' cellspacing='1'><tr><td>";
	    for(var i=0;i<num;i++)
	    {
	        str+="<input id='Checkbox_"+ i +"' type='checkbox' name='testcheckbox' onclick='javascript:checkID(this.id)' value='"+ key.split(',')[i] +"' />"+ key.split(',')[i]+"";
	    }
	    str+="</td></tr></table>";
	    document.getElementById("Condition_ck").innerHTML=str;
	}
	
	//**********循环生成单选按钮*************
	    function CycRadio(num,key)
	    {   
    	    
	        var str="<table border='0' width='100%' cellpadding='0' cellspacing='1' style='text-align:left'><tr><td>";
	        for(var i=0;i<num;i++)
	        {
	            if(i%5==0)
	            {
	                str+="<br/>";
	            }
	            str+="<input id='rad_"+ i +"' type='Radio' name='testradio' onclick='javascript:checkID(this.id)' value='"+ key.split(',')[i] +"' />"+ key.split(',')[i]+"";
	        }
	        str+="</td></tr></table>";
	        document.getElementById("Condition_Rad").innerHTML=str;
	    }
	    function CyRadioCheck(key1,key2,key3)
	    {
	        var flag1="";
	        var flag2="";
	        var flag3="";
	        if(key1=="")
	        {
	            flag1="display:none";
	        }
	        if(key2=="")
	        {
	            flag2="display:none";
	        }
	        if(key3=="")
	        {
	            flag3="display:none";
	        }
		    document.getElementById("Condition_ck").innerHTML = "<table border='0' width='100%' cellpadding='0' cellspacing='1'><tr><td><input type='radio' name='rad' id='radio_1' style='"+ flag1 +"' value='"+ key1 +"' onClick='javascript:hide(this.id)' />"+key1+"<input type='radio' name='rad' id='radio_2' style='"+ flag2 +"' value='"+ key2 +"' onClick='javascript:hide(this.id)' />"+key2+"<input type='radio' name='rad' id='radio_3' style='"+ flag3 +"' value='"+ key3 +"'onClick='javascript:hide(this.id)' />"+key3+"</td></tr></table>";

	    }
	//*****************end**********************
	
	
	//********生成多选框的点击事件 方法***************
	   function checkID(id)
	   {
            var obj=document.getElementById(id);
	       if(obj.value=="和值")
	       {
	          document.getElementById("gut").style.display="block";
	          document.getElementById('gut_1').style.display="none";
              document.getElementById("gut_pl5").style.display="none";
              document.getElementById("gut_7xc").style.display="none";
               return;
	       }

	       if(obj.value=="和值奇偶")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("奇数","偶数","");
	             return;
	       }
	       if(obj.value=="和值大小")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("大数","小数","");
	             return;
	       }
	       if(obj.value=="和值012路")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("0路","1路","2路");
	             return;
	       }
	       if(obj.value=="和值距离")
	       {
	            document.getElementById("gut").style.display="block";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                 return;
	       }
	       if(obj.value=="跨度")
	       {
	            document.getElementById("gut").style.display="block";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                 return;
	       }
	       if(obj.value=="跨度奇偶")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("奇数","偶数","");
	             return;
	       }
	       if(obj.value=="跨度大小")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("大数","小数","");
	             return;
	       }
	       if(obj.value=="跨度012路")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("0路","1路","2路");
	             return;
	       }
	       //3D
	       if(obj.value=="奇数个数")
	       {
	        
	       }
	       //3D
	       if(obj.value=="偶数个数")
	       {
	            
	       }
	   }
	
	//**********************end***********************8**
	
	
//    //单选按钮取值
//    function Chooes(obj,key4,key5)
    function Chooes(obj)
    {
        var chooes=document.getElementById(obj);
        if(chooes.checked)
        {   
//            if(key4=="3D" || key4=="排列3")
//            {
//                if(type=="胆码")
//                {
                    if(chooes.id=="radio_1")
                    {
                       //判断是那个彩种的和类型
                       addCheckbos("百","十","个");
                    }
                    if(chooes.id=="radio_2")
                    {
                       addCheckbos("百十","百个","十个");
                    }  
                    if(chooes.id=="radio_3")
                    {
                       addCheckbos("百十","百个","十个");
                    } 
//                }
//                if(type=="号码组")
//                {
//                    
//                }
//            }
           
        }
        //把这个方法封装起来。根据点击传来的ID 自动判断绑定多选框。
    }
    
 //********begin选择彩种和类型后判断**************8
    function ValotteryType(lottery,type)
    {
        //如果想要修改彩种名称和类型名称 那么用XML来相对应
        if(lottery=="3D" || lottery=="排列三")
        {
                document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
            if(type=="胆码")
            {
                document.getElementById("gut").style.display="block";
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut_colligate_3D").style.display="none";
//                addRadio('单码','组选两码','单选两码',lottery,type);
                addRadio('单码','组选两码','单选两码');
                 return;

            }
            if(type=="号码组")
            {
                 document.getElementById("gut").style.display="block";
                 document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                 document.getElementById("Condition_Rad").innerHTML="";
                 document.getElementById("Condition_ck").innerHTML="";
                 addRadio1('组合输入','单一输入','');
                  return;
            }
            if(type=="和值")
            {
                  document.getElementById("gut").style.display="none";
                  document.getElementById("gut_colligate_3D").style.display="none";
                  document.getElementById("Condition_Rad").innerHTML="";
                  document.getElementById("Condition_ck").innerHTML="";
//                  CycRadio(26,'和值,和值奇偶,和值大小,和值DZX,和值012路,和值质和,和值距离,和值环距,和值邻期差,和值邻期和,和值邻期合,和值轴差,和值轴距,和值3分区,和值4分区,和值5分区,和值6分区,和值7分区,和值8分区,和值遗漏尾,和值遗漏尾奇偶,和值遗漏尾大小,和值遗漏尾DZX,和值遗漏尾012路,和值遗漏尾质和,和值和试机号距离');
                  CycRadio(3,'和值奇偶,和值大小,和值012路') 
            }
            if(type=="跨度")
            {
               document.getElementById("gut").style.display="block";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
//                CycRadio(20,'跨度,跨度奇偶,跨度大小,跨度DZX,跨度012路,跨度质和,跨度距离,跨度环距,跨度邻期差,跨度邻期和,跨度邻期合,跨度轴差,跨度轴距,跨度遗漏尾,跨度遗漏尾奇偶,跨度遗漏尾大小,跨度遗漏尾DZX,跨度遗漏尾012路,跨度遗漏尾质和,跨度与试机号距离');
               CycRadio(3,'跨度奇偶,跨度大小,跨度012路');  
                return;
            }
            if(type=="奇偶")
            {
                  document.getElementById("Condition_Rad").innerHTML="";
                  document.getElementById("Condition_ck").innerHTML="";
                   document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut").style.display="none";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                CycRadio(5,'奇数个数,偶数个数,奇偶排列,奇偶排列值,奇偶连');
            }
            if(type=="定位复式")
            {
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="block";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                addRadio1('组合输入','单一输入','');
                 return;
            }
            if(type=="综合条件")
            {
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="none";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="block";
                 return;
            }
        }
        if(lottery=="双色球")
        {
            if(type=="红球胆码")
            {
                 document.getElementById("gut").style.display="block";
                 document.getElementById("Condition_Rad").innerHTML="";
                 document.getElementById("Condition_ck").innerHTML="";
                 document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_seq").style.display="none";
                return;
               
            }
            if(type=="蓝球胆码")
            {
                 document.getElementById("gut").style.display="block";
                 document.getElementById("Condition_Rad").innerHTML="";
                 document.getElementById("Condition_ck").innerHTML="";
                 document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                 document.getElementById("gut_seq").style.display="none";
                return;
               
            }
            if(type=="综合条件")
            {
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="none";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_seq").style.display="block";
                return;
            }
        }
        if(lottery=="七乐彩")
        {
                document.getElementById("gut").style.display="block";
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_seq").style.display="none";
                 return;
            if(type=="")
            {
                
            }
        }
        if(lottery=="七星彩")
        {
            if(type=="定位胆码")
            {
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="none";
                document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="block";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_seq").style.display="none";
                 return;
            }
            else
            {
                 document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="none";
                document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                 return;
            }
        }
        if(lottery=="大乐透")
        {
            if(type=="")
            {
                
            }
        }
        if(lottery=="排列5")
        {
            if(type=="定位胆码")
            {
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="none";
                document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="block";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                 return;
            }
            if(type=="胆码")
            {
                document.getElementById("gut").style.display="block";
	              document.getElementById('gut_1').style.display="none";
                  document.getElementById("gut_pl5").style.display="none";
                  document.getElementById("gut_7xc").style.display="none";
                  document.getElementById("gut_colligate_3D").style.display="none";
                   return;
            }
        }
    }
//****************end提交验证结束*******************
    
    //**********begin验证输入是数字或是数字带,号****************
    function Rex(value)
    {
        var str=TransferString(value);
        for(var i=0;i<str.split("<br>").length;i++)
        {
            if(str.split("<br>")[i].replace(/^\d+(?:(\/|,)\d+)?(\1\d+)*$/,"")=="" || str.split("<br>")[i].replace(/^[0-9]*[1-9][0-9]*$/,"")=="" || str.split("<br>")[i].replace(/\d+(?: \d+)+/,"")=="")
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }

    }
    //*************************************
    //判断数据输入为空和格式是否正确
    function TextValidate(text)
    {
       //验证输入的格式 是否正确。 是否为空
       if(text=="" || text=="undefined" || text==null)
       {
           return false;
       }
       else
       {
           return Rex(text);
       }
    }
    //************替换所有回车*****************
        //替换所有的回车换行   
        function TransferString(content)   
        {   
            var string = content   
            try{   
                string=string.replace(/\r\n/g,"<br>")   
                string=string.replace(/\n/g,"<br>");   
            }catch(e) {   
                alert(e.message);   
            }   
            return string;   
        } 
        
    //*****************************************
    
    //*************************8给数字排序arrqy:数组参数
    function compositor(array)
    {
        for(var i=0;i<array.length;i++)
        {
            if(parseInt(array[i].substring(0,1))>parseInt(array[i].substring(1,2)))
            {
                array[i]=array[i].substring(1,2)+array[i].substring(0,1);
            }
        }
        return array;

    }
    //*************************
    
    //***********begin冒泡算法 array:排序的数组**************
    function maopao(array)
    {
              //冒泡算法给数字排序
        for(var b=0;b<array.length-1;b++)
        {
            for(var j=b+1;j<array.length;j++)
            {
                var k;
                if(array[b]>array[j])
                {
                    k=array[b];
                    array[b]=array[j];
                    array[j]=k;
                }
            }
        }
        return array;
    }
    
    //***************end**************
    //**********************截取字符串（字符串为数字） 两位 数字。(3D组选两码) state:标识
    function TwoNum(num,state)
    {
        var array=new Array;
        var getArray=new Array;
        var str_a_b;
        var str="";
        var swap="";
        if(state=="单码")
        {
                var arr=new Array;
                var arr1=new Array;
                swap= TransferString(num);
                var pm="";
                for(var i=0;i<swap.split("<br>").length;i++)
                { 
                     
                    //去除重复元素/去除字符串中的，和/号
                    arr[i]=swap.split("<br>")[i].replace(/[,|/]/g,"");
                }    
                arr1=unique(arr);    
                for(var j=0;j<arr1.length;j++)
                {
                    str="";
                    //去除重复数字
                    var number=RemoveRepeat(arr1[j].toString());
                    for(var k=0; k<number.length;k++)
                    {
                        array[k]=number.substring(k,k+1);
                    }
                    getArray=maopao(array); 
                    for(var w=0;w<getArray.length;w++)
                    {
                        str+=getArray[w];
                    }
                    pm+=str+",";
                } 
                return pm.substring(0,pm.length-1);   
        }
        if(state=="组选两码")
        {
            //替换回车
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                arr[i]=swap.split("<br>")[i];
            }
            //去除重复
            for(var j=0;j<arr.length;j++)
            {
                str+=(arr[j].replace(/\//g,"")).replace(/,/g,"");
            }
               var  a_lenth=RemoveRepeat(str);
               var len=parseInt(a_lenth.length/2);
               for(var i = 0; i < len; i++)
               {
                 //把2为数字写入数组
                   array[i]=a_lenth.substring(0,2);
                   //抛出最后一个数
                   a_lenth=a_lenth.substring(2);
               }

                return array;
                

        }
        if(state=="单选两码")
        {
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                arr[i]=swap.split("<br>")[i];
            }
            //去除重复
            for(var j=0;j<arr.length;j++)
            {
                str+=(arr[j].replace(/\//g,"")).replace(/,/g,"");
            }
            var a_len=RemoveRepeat(str);
            var a_lenth=parseInt(RemoveRepeat(str).length/2);
            for(var i = 0; i < a_lenth; i++)
            {
               //把2为数字写入数组
               array[i]=a_len.substring(0,2);
               //抛出最后一个数
               a_len=a_len.substring(2);
            }  
            return  unique(array);
        }
        if(state=="组合输入")
        {
            //每组数字用<br\>隔开
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                  arr[i]=swap.split('<br>')[i];
                  //匹配整数
                  if(arr[i].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                  {
                        pm+="第'"+ i +"'组"+RemoveRepeat(arr[i])+"|";
                  }
                  else
                  {
                        alert('请输入整数，如果是多组号码。请在每组号码后敲回车');
                        return false;
                  }   
//                //去除每一行数字中的，号和/号
//                arr[i]=(swap.split("<br>")[i].replace(/\//g,"")).replace(/,/g,"");
//                arr1[i]= RemoveRepeat(arr[i]);
//                for(var j=0;j<arr1[i].length;j++)
//                {
//                    array[j]=arr1[i].substring(j,j+1);
//                }
//                getArray=maopao(array);
//                for(var w=0;w<getArray.length;w++)
//                {
//                    str+=getArray[w];
//                }
//                pm+=str+"|";
            }
            pm=pm.substring(0,pm.length-1);
            return pm;
        }
        if(state=="单一输入")
        {
            //替换回车
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                arr[i]=swap.split("<br>")[i];
            }
            //去除重复
            for(var j=0;j<arr.length;j++)
            {
                str+=(arr[j].replace(/\//g,"")).replace(/,/g,"");
            }
            var val=RemoveRepeat(str);
            for(var j=0;j<val.length;j++)
            {
                arr1[j]=val.substring(j,j+1);
            }    
            getArray=maopao(arr1);
            for(var k=0;k<getArray.length;k++)
            {
                pm+=getArray[k];
            }
            return pm;
        }
        
    }
    //************************
    
   //*******************去掉数组中的重复值(去掉数组中相同元素的值Array('12','32','12'))***
    function unique(data){
    data = data || [];
    var a = {};
    for (var i=0; i<data.length; i++) {
        var v = data[i];
        if (typeof(a[v]) == 'undefined'){
            a[v] = 1;
        }
    };
    data.length=0; 
    for (var i in a){
        data[data.length] = i;
    }
    return data;
   }
  //************************************* 
    //***********begin去除字符串中的重复数据*******************
    function RemoveRepeat(str)
    {
        var a = {};
        for(var i=0;i<str.length;i++) {
	        a[str.charAt(i)] = "*"
        }
        str = "";
        for(var i in a){
	        str += i;
        }
        return str;
    }
    
    //*************end***********************
    
    //**************读取，创建，删除cookie  begin*************************
        //写入cookie 
        function setCookie(name,value,days){ 
            var exp=new Date(); 
            exp.setTime(exp.getTime()+days*24*60*60*1000); 
            document.cookie=name+"="+escape(value)+";expires="+exp.toGMTString(); 
        } 
        //读取cookie 
        function getCookie(name){ 
            var arr=document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)")); 
            if(arr!=null) 
              return unescape(arr[2]); 
            return null; 
        } 

        //删除cookie 
        function delCookie(name){ 
            var exp=new Date(); 
            exp.setTime(exp.getTime()-1); 
            var cval=getCookie(name); 
            if(cval!=null) 
               document.cookie=name + "="+cval+";expires="+exp.toGMTString(); 
        } 
        
        function isCookieEnable(){ 
            if (!window.navigator.cookieEnabled) return false; 
            var key='supportCookie'; 
            setCookie(key,key,60000); 
            var v = getCookie(key); 
            if (v==key) { 
             delCookie(key); 
             return true; 
            } 
            return false; 
       }


        
    //****************************end****************************************
    
    //*************去出字符串首位空格 begin*************************
        function trim(str){ //删除左右两端的空格
　　     return str.replace(/(^\s*)|(\s*$)/g, "");
　　     }
　　     function ltrim(str){ //删除左边的空格
　　         return str.replace(/(^\s*)/g,"");
　　     }
　　     function rtrim(str){ //删除右边的空格
　　         return str.replace(/(\s*$)/g,"");
　　     }

    //******************去除字符串首尾空格 end**********************
       
    //*****点击文本框选数字*************begion
    (function($){
$.fn.bgIframe = $.fn.bgiframe = function(s) {
	if ( $.browser.msie && /6.0/.test(navigator.userAgent) ) {
		s = $.extend({
			top     : 'auto', // auto == .currentStyle.borderTopWidth
			left    : 'auto', // auto == .currentStyle.borderLeftWidth
			width   : 'auto', // auto == offsetWidth
			height  : 'auto', // auto == offsetHeight
			opacity : true,
			src     : 'javascript:false;'
		}, s || {});
		var prop = function(n){return n&&n.constructor==Number?n+'px':n;},
		    html = '<iframe class="bgiframe"frameborder="0"tabindex="-1"src="'+s.src+'"'+
		               'style="display:block;position:absolute;z-index:-1;'+
			               (s.opacity !== false?'filter:Alpha(Opacity=\'0\');':'')+
					       'top:'+(s.top=='auto'?'expression(((parseInt(this.parentNode.currentStyle.borderTopWidth)||0)*-1)+\'px\')':prop(s.top))+';'+
					       'left:'+(s.left=='auto'?'expression(((parseInt(this.parentNode.currentStyle.borderLeftWidth)||0)*-1)+\'px\')':prop(s.left))+';'+
					       'width:'+(s.width=='auto'?'expression(this.parentNode.offsetWidth+\'px\')':prop(s.width))+';'+
					       'height:'+(s.height=='auto'?'expression(this.parentNode.offsetHeight+\'px\')':prop(s.height))+';'+
					'"/>';
		return this.each(function() {
			if ( $('> iframe.bgiframe', this).length == 0 )
				this.insertBefore( document.createElement(html), this.firstChild );
		});
	}
	return this;
};
})(jQuery);
jQuery.fn.selectCity = function(targetId) {
	var _seft = this;
	var targetId = $(targetId);
	this.click(function(){
		var A_top = $(this).offset().top + $(this).outerHeight(true);
		var A_left =  $(this).offset().left;
		targetId.bgiframe();
		targetId.show().css({"position":"absolute","top":A_top+"px" ,"left":A_left+"px"});
	});
	targetId.find("#tagClose").click(function(){
		targetId.hide();
	});
	$(document).click(function(event){
		if(event.target.id!=_seft.selector.substring(1)){
			targetId.hide();	
		}
	});
	targetId.click(function(e){
		e.stopPropagation(); 
	});
    return this;
}
$(function(){
//	$("#Button3").selectCity("#m_tagsItem");
}); 
//为文本域连续赋值
function checktag(o){
  var tagid = function(id){return document.getElementById(id);}
  var tags = [];//存放标签,避免重复加入
  var tagidSPLITCHAR = ' ';//设定分隔符,根据程序需求可改
  var d = tagid('selecttags');
  if (d.value)
    tags = d.value.split(tagidSPLITCHAR);
  var v = o.innerHTML;//如果tag有别的值或者别的非innerHTML里体现的内容
    var s = tagidSPLITCHAR+tags.join(tagidSPLITCHAR)+tagidSPLITCHAR
    if (!new RegExp(tagidSPLITCHAR+v+tagidSPLITCHAR,'g').test(s)){
      s+=v;
    }
    s = s.replace(new RegExp("(^"+tagidSPLITCHAR+"*|"+tagidSPLITCHAR+"*tagid)","g"),'');
    d.value = s;
    tags = s.split(tagidSPLITCHAR);//选择文本后所取到的值
    alert(tags);
}
//**********************************end***********

//*********************begin计算距离天数************************
 //计算天数差的函数，通用      
  function DateDiff(sDate1,sDate2){  
     //sDate1和sDate2是yyyy-mm-dd格式       
    var aDate, oDate1, oDate2, iDays;   
    aDate = sDate1.split("-"); 
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);  //转换为dd-mm-yyyy格式     
    aDate = sDate2.split("-");     
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);     
   // alert(oDate1 - oDate2)     
    iDays = parseInt((oDate2 - oDate1) / 1000 / 60 / 60 /24);  //把相差的毫秒数转换为天数     
    return  iDays;    
  } 
//***********************end************************    


