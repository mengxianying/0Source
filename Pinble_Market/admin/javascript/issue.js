


     $(document).ready(function(){
               //���ý��Ŀؼ�����
               $("#money").hide();
               var lotteryType=document.getElementById("lotteryType");
               //��ȡcookie
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
                     //result���ص�ֵ
                          if(result.responseText!=null || result.responseText!="" || result.length!=0)
                          {
                              $("#txt_time").attr("value","");
                               //����cookie
                               delCookie("issue");
                               setCookie("issue",result.responseText.replace(/"/g,"").split('|')[0],1)
                          }
                          else
                          {
                                delCookie("issue");
                                $("#txt_time").attr("value",""); 
                                alert('�ں����ɴ���������ҳ�Ƿ����Cookie,������ˢ��һ��ҳ��');
                                return false;
                          }
                     }
                 });
         });       
        $("#ddlitemName").change(function(){ 
                //������ĿID���ز��ֺͲ�������
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
                                if(confirm('�����Է����շ���Ŀ������300��ұ�֤��Ϳɷ����շ���Ŀ'))
                                {
//                                    var username='<%= Pbzx.Common.Method.Get_UserName %>';
                                      //ȡ���ر�����ֵ
                                      var username=$("#userName").val();
                                      
                                       //�ж��û����ɱ�֤��
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json",
                                        url: "WebService1.asmx/deductMoney",
                                        data: "{username:'"+ username +"'}",
                                        dataType: 'json',
                                        complete: function(result) {
                                                
                                                //1:������  0������
                                                if(result.responseText.split('"')[1].split('"')[0]=="1")
                                                {
                                                    if(confirm("�����������շ�����"))
                                                    {
                                                        //��ʾ���ü۸�Ŀؼ�
                                                        $("#money").show();
                                                    }
                                                }
                                                else
                                                {
                                                     $("#money").attr("value","");
                                                     $("#money").hide();
                                                    alert('�����ʻ�����֧����֤�𡢲��������շ����������ȳ�ֵ��');
                                                }
                                        
                                             }
                                        });
                                }
                            }
                            if(result.responseText.split('|')[1].split('"')[0]=="CueNoSeries")
                            {
                                alert('��û�������ķ�������');
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
        //�ύ����
        $("#Button2").click(function(){   
                var txtmoney=0;
                //�շѽ�Ϊ��Ҳ����0
                if($("#txt_money").val()!="" || $("#txt_money").val()!=0)
                {
                    txtmoney=$("#txt_money").val();
                    //*******�ص�����******
                    $.ajax({
                             type: "POST",
                             contentType: "application/json",
                             url: "WebService1.asmx/deduct",
                             data: "{price:'"+ txtmoney +"',username:'"+ $("#userName").val() +"',itemid:'"+ $("#ddlitemName").val() +"'}",
                             dataType: 'json',
                             complete: function(result) {
                             //result���ص�ֵ
                                if(result.responseText.split('"')[1].split('"')[0]=="1")
                                {
                                    alert('�ۿ�ɹ������Ժ󷢲�����������ֻ�й�����û��ſɹۿ�');
                                    
                                }
                                else
                                {
                                    alert("���ı�֤��۳�ʧ�ܡ��������");
                                    return false;
                                }
                             }
                         });
                  //**********end************  
                }
                var noList = "";
                if(lotteryType.value=="" || lotteryType.value==null)
                {
                    alert('����ѡ����Ŀ��');
                    return false;
                }
                if($("#txt_time").val()=="")
                {
                    alert('�����ںų�����ˢ��һ��ҳ��');
                    return false;
                }
                if(lotteryType.value.split('&')[0].split('"')[1]=="3D" || lotteryType.value.split('&')[0].split('"')[1]=="������")
                {
                    //���������ʱ����ǲ����Է�����Ϣ��
                    var time1=new Date();
                    if(time1.getHours()>19 && time1.getHours()<22)
                    {
                        alert("���ڻ����ܷ���������");
                        $('#Button2').attr('disabled','true');
                        return false;
                    }
                    //ѡ������ۺϵ�����
                     if(lotteryType.value.split('&')[1].split('|')[0]=="�ۺ�����")
                     {
                        
                        var colligate;
                        var arrdm=new Array;
                        var kd;
                        var hmz;
                        //�ж������Ƿ�Ϊ��
                        if($("#txt_dm").val()=="" && $("#txt_hz").val()=="" && $("#txt_kd").val()=="" && $("input[name='qo']:checked").val()=="" && $("#txt_hmz").val()=="")
                        {
                            alert('������дһ����������');
                            return false;
                        }
                        else
                        {
                            //��������
                            if($("#txt_dm").val()!="" || $("#txt_dm").val()!=null)
                            {
                                var numberArr=new Array;
                                //��֤����ͣ��ŵ����
                                if($("#txt_dm").val().replace(/\d+(?:,\d+)+/,"")=="" )
                                {
                                    for(var i=0;i<$("#txt_dm").val().split(',').length;i++)
                                    {
                                        if($("#txt_dm").val().split(',')[i].replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                                        {
                                            alert('����Ϊ0-9֮�������');
                                            return false;
                                        }
                                        else
                                        {
                                            numberArr[i]=$("#txt_dm").val().split(',')[i];
                                        }
                                    }
                                }
                                //��֤������0-9��������
                                else if($("#txt_dm").val().replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                                {
                                    numberArr[0]=$("#txt_dm").val();
                                }//��֤���� �� �ո�����
                                else if($("#txt_dm").val().replace(/\d+(?: \d+)+/,"")=="")
                                {
                                     var numberArr=new Array;
                                    for(var i=0;i<$("#txt_dm").val().split(' ').length;i++)
                                    {
                                        if($("#txt_dm").val().split(' ')[i].replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                                        {
                                            alert('����Ϊ0-9֮�������');
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
                                    alert('������ĸ�ʽ����ȷ������������');
                                    return false;
                                }
                                 arrdm=maopao(unique(numberArr));
                            }
//                            //��ֵ����
//                            if($("#txt_hz").val()!="" || $("#txt_hz").val()!=null)
//                            {
//                                
//                            }
//                            //���
//                            if($("#txt_kd").val()!="" || $("#txt_kd").val()!=null)
//                            {
//                                if($("#txt_kd").val().replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
//                                {
//                                    alert('��Ⱥ����ʽ�������飡');
//                                    return false;
//                                }
//                                else
//                                {
//                                    kd=$("#txt_kd").val();
//                                }
//                                
//                            }
                            //������
                            if($("#txt_hmz").val()!="" || $("#txt_hmz").val()!=null)
                            {
                                //������
                                if($("#txt_hmz").val().replace(/^[1-9]\d*$/,"")=="" )
                                {
                                    hmz=RemoveRepeat($("#txt_hmz").val());
                                }
                                else
                                {
                                    alert('��������ȷ�ĺ�����');
                                    return false;
                                }
                            }
                            /********�������ݿⷽ��**********/
                                 var time=new Date();
                                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
//                                    var colligate=arrdm+"|"+$("#txt_hz").val()+"|"+kd+"|"+$("input[name='qo']:checked").val()+"|"+hmz;
                                    var colligate="���룺"+arrdm+"�� ��ֵ��"+$("#txt_hz").val()+"��  �����飺"+hmz;
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                        return false;
                                    }
                                    //ȡ�Ƿ��Ƽ��ı�ʶ
                                    var rcd=$("input[name='yn']:checked").val();
                                    //ȡ�������ɱ��ı�ʶ
                                    var courage=$("input[name='courage']:checked").val();
                                    if(confirm("���������ǣ�"+"���룺"+arrdm+"��  ��ֵ��"+$("#txt_hz").val()+"��  �����飺"+hmz))
                                    {
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ colligate +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'',itemnumber:'1'}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
                                                    }
                                                 }
                                             });
                                      //**********end************  
                                  }
                                  else
                                  {
                                        return false;
                                  }
                            /********�������ݿⷽ��**********/
                        }
                     }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="����")
                    {
                       
                        $('input[type="checkbox"]').each(function () {
                            if ($(this).attr('checked')) {
                                noList += $(this).val() + "|";
                            }
                        }); 
                        if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null )
                        {
                            alert('��ѡ���������');
                            return false;
                        }
                        else
                        {
                            if($("input[name='testRadio']:checked").val()=="����")
                            {

                               if(!TextValidate($("#selecttags").val()))
                               {
                                  alert('���������ĸ�ʽ����ȷ');
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
                                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                        return false;
                                    }
                                    for(var i=0;i<txt.length;i++)
                                    {
                                        pm[i]=txt.substring(i,i+1);
                                    }
                                    //ȡ�Ƿ��Ƽ��ı�ʶ
                                    var rcd=$("input[name='yn']:checked").val();
                                    //ȡ�������ɱ��ı�ʶ
                                    var courage=$("input[name='courage']:checked").val();
                                    if(confirm("���������ǣ�"+ $("input[name='testRadio']:checked").val()+ "��" + pm))
                                    {
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��,');
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
                            if($("input[name='testRadio']:checked").val()=="��ѡ����")
                            {
                                if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null) 
                                {
                                    alert('��ѡ���������');
                                    return false;
                                }
                                //��֤����Ϸ�
                                if(!TextValidate($("#selecttags").val()))
                                {
                                    alert('��ʽ����ȷ������������');
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
                                            alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                            return false;
                                        }
                                        var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                                        //ȡ�Ƿ��Ƽ��ı�ʶ
                                        var rcd=$("input[name='yn']:checked").val();
                                        //ȡ�������ɱ��ı�ʶ
                                        var courage=$("input[name='courage']:checked").val();
                                     //��ʾ�����ĺ��룻
                                     if(confirm("���������ǣ�"+ $("input[name='testRadio']:checked").val()+ "��" + txt))
                                     {     
                                          //*******�ص�����******
                                            $.ajax({
                                                     type: "POST",
                                                     contentType: "application/json",
                                                     url: "WebService1.asmx/AddItem",
                                                     data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                     dataType: 'json',
                                                     complete: function(result) {
                                                     //result���ص�ֵ
                                                       if(result.responseText==0)
                                                        {
                                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                             return false;
                                                        }
                                                        else
                                                        {
                                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                            if($("input[name='testRadio']:checked").val()=="��ѡ����")
                            {
                                if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null)
                                {
                                    alert('��ѡ���������');
                                    return false;
                                }
                                //ע�������23 ��32��ͬ Ҫע�����ֵ�λ��
                                //��֤����Ϸ�
                                if(!TextValidate($("#selecttags").val()))
                                {
                                    alert('���������ĸ�ʽ����ȷ');
                                    return false;
                                }  
                                else
                                {
                                        var time=new Date();
                                        //�ύ��ʱ��
                                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                        var issue=$("#txt_time").val();
                                        if(issue=="" || issue==null || issue=="null")
                                        {
                                            alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                            return false;
                                        }
                                        //����
                                        var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                                        //ȡ�Ƿ��Ƽ��ı�ʶ
                                        var rcd=$("input[name='yn']:checked").val();
                                        //ȡ�������ɱ��ı�ʶ
                                        var courage=$("input[name='courage']:checked").val();
                                         //��ʾ�����ĺ��룻
                                         if(confirm("���������ǣ�"+ $("input[name='testRadio']:checked").val()+ "��" + txt))
                                         {      
                                              //*******�ص�����******
                                                $.ajax({
                                                         type: "POST",
                                                         contentType: "application/json",
                                                         url: "WebService1.asmx/AddItem",
                                                         data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                         dataType: 'json',
                                                         complete: function(result) {
                                                         //result���ص�ֵ
                                                            if(result.responseText==0)
                                                            {
                                                                alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                                 return false;
                                                            }
                                                            else
                                                            {
                                                                result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                    if(lotteryType.value.split('&')[1].split('|')[0]=="������")
                    {
                        if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null)
                        {
                            alert('��ѡ������������');
                            return false;
                        }
                        //��֤����Ϸ�
                        if(!TextValidate($("#selecttags").val()))
                        {
                            alert('���������ĸ�ʽ����ȷ');
                            return false;
                        }  
                        else
                        {
                            var time=new Date();
                            //�ύ��ʱ��
                            var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                            var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                            var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                            var issue=$("#txt_time").val();
                            if(issue=="" || issue==null || issue=="null")
                            {
                                alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                return false;
                            }
                            //����
                            var txt= TwoNum($("#selecttags").val(),$("input[name='testRadio']:checked").val());
                            if(txt==false)
                            {
                                return false;
                            }
                            //ȡ�Ƿ��Ƽ��ı�ʶ
                            var rcd=$("input[name='yn']:checked").val();
                            //ȡ�������ɱ��ı�ʶ
                            var courage=$("input[name='courage']:checked").val();
                           //��ʾ�����ĺ��룻
                             if(confirm("���������ǣ�"+ $("input[name='testRadio']:checked").val()+ "��" + txt))
                             {        
                                  //*******�ص�����******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result���ص�ֵ
                                                if(result.responseText==0)
                                                {
                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                    if(lotteryType.value.split('&')[1].split('|')[0]=="��ֵ")
                    {
                        if($("input[name='testradio']:checked").val()=="" || $("input[name='testradio']:checked").val()==null)
                        {
                            alert('��ѡ������');
                            return false;
                        }
                        if($("input[name='testradio']:checked").val()=="��ֵ��ż")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ������!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                               //����
                               var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                               //��ʾ�����ĺ��룻
                                 if(confirm("���������ǣ�"+ $("input[name='rad']:checked").val() + "��" + txt))
                                 {           
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                        if($("input[name='testradio']:checked").val()=="��ֵ��С")
                        {  
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ����������!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                               //����
                               var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                  //��ʾ�����ĺ��룻
                                 if(confirm("���������ǣ�"+ $("input[name='rad']:checked").val()+ "��" + txt))
                                 {       
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                        if($("input[name='testradio']:checked").val()=="��ֵDZX")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ����������!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;  
                                }
                               //����
                               var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                               //��ʾ�����ĺ��룻
                                 if(confirm("�����������������ǣ�"+ $("input[name='rad']:checked").val()+ "��" + txt))
                                 {         
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                       if($("input[name='testradio']:checked").val()=="��ֵ012·")
                       {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ����������!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                //��ʾ�����ĺ��룻
                                 if(confirm("���������ǣ�" + txt))
                                 {        
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                       if($("input[name='testradio']:checked").val()=="��ֵ�ʺ�")
                       {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ����������!');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                               var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 if(confirm("���������ǣ�" + txt))
                                 {     
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                        if($("input[name='testradio']:checked").val()=="��ֵ����")
                        {
                            if($("#selecttags").val()=="" ||  $("#selecttags").val().replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                            {
                                alert('������ʽ����ȷ��');
                                return false;
                            }
                            if(parseInt($("#selecttags").val())>=0 && parseInt($("#selecttags").val())<=27)
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                               //����
                               var txt= $("#selecttags").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                if(confirm("���������ǣ�" + txt))
                                 {         
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testradio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                                alert('��ֵ�������벻��ȷ��������0-27�����֣�');
                                return false;
                            }
                        }
                               
                       
                       
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="���")
                    {
                        if($("input[name='textradio']:checked").val()=="���")
                        {
                            if($("#selecttags").val()=="" || $("#selecttags").val().replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                            {
                                alert('��������������');
                                return false;
                            }
                            else
                            {
                                if(parseInt($("#selecttags").val())>=0 && parseInt($("#selecttags").val())<=9)
                                {
                                    var time=new Date();
                                    //�ύ��ʱ��
                                   var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                        return false;
                                    }
                                   //����
                                   var txt= $("#selecttags").val();
                                    //ȡ�Ƿ��Ƽ��ı�ʶ
                                    var rcd=$("input[name='yn']:checked").val();
                                    //ȡ�������ɱ��ı�ʶ
                                    var courage=$("input[name='courage']:checked").val();
                                    //��ʾ�����ĺ��룻
                                     if(confirm("���������ǣ�"+ txt))
                                     {         
                                          //*******�ص�����******
                                            $.ajax({
                                                     type: "POST",
                                                     contentType: "application/json",
                                                     url: "WebService1.asmx/AddItem",
                                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                     dataType: 'json',
                                                     complete: function(result) {
                                                     //result���ص�ֵ
                                                        if(result.responseText==0)
                                                        {
                                                           alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                           return false;
                                                        }
                                                        else
                                                        {
                                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                                    alert('���������������ֻ������0-9֮�������');
                                    return false;
                                }
                            }
                        }
                        if($("input[name='textradio']:checked").val()=="�����ż")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ��������');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                               //����
                               var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("���������ǣ�"+$("input[name='textradio']:checked").val() + txt))
                                 {     
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                        if($("input[name='textradio']:checked").val()=="��ȴ�С")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('��ѡ���ȴ�С��������');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //����
                                var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                  //��ʾ�����ĺ��룻
                                     if(confirm("���������ǣ�"+$("input[name='textradio']:checked").val() + txt))
                                     {     
                                          //*******�ص�����******
                                            $.ajax({
                                                     type: "POST",
                                                     contentType: "application/json",
                                                     url: "WebService1.asmx/AddItem",
                                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                     dataType: 'json',
                                                     complete: function(result) {
                                                     //result���ص�ֵ
                                                        if(result.responseText==0)
                                                        {
                                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                            return false;
                                                        }
                                                        else
                                                        {
                                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                        if($("input[name='textradio']:checked").val()=="���012·")
                        {
                            if($("input[name='rad']:checked").val()=="" || $("input[name='rad']:checked").val()==null)
                            {
                                alert('ǿѡ����012·��������');
                                return false;
                            }
                            else
                            {
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                    var issue=$("#txt_time").val();
                                    if(issue=="" || issue==null || issue=="null")
                                    {
                                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                        return false;
                                    }
                                    var txt=$("input[name='rad']:checked").val();
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("���������ǣ�"+$("input[name='textradio']:checked").val() + txt))
                                 {      
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ $("input[name='rad']:checked").val() +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                    if(lotteryType.value.split('&')[1].split('|')[0]=="��ż")
                    {
                    
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="��λ��ʽ")
                    {
                        if($("input[name='testRadio']:checked").val()=="" || $("input[name='testRadio']:checked").val()==null)
                        {
                            alert('��ѡ���������');
                            return false;
                        }
                        else
                        {
                            if($("input[name='testRadio']:checked").val()=="�������")
                            {
                               
                                if($("#selecttags").val()=="")
                                {
                                    alert('�������벻��Ϊ��');
                                    return false;
                                }
                                else
                                {
                                    //��֤�����ǲ��������ֺ�/����� 
//                                    if($("#selecttags").val().replace(/\d+(?:\/\d+)+/,"")=="" )
                                    //��֤���ֺ�,��
                                    if($("#selecttags").val().replace(/\d+(?:,\d+)+/,"")=="" )
                                    {
                                        var key1=new Array;
                                        key1=$("#selecttags").val().split(",");
                                       
                                        if(key1.length<0 || key1.length>3)
                                        {
                                            alert('���벻��ȷ����ʽΪ��0,0,0������ö��Ÿ�����');
                                            return false;
                                        }
                                        else
                                        {
                                            var txt="";
                                            var time=new Date();
                                            //�ύ��ʱ��
                                           var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                            var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                            var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                            var issue=$("#txt_time").val();
                                            if(issue=="" || issue==null || issue=="null")
                                            {
                                                alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                                return false;
                                            }
                                            //����
                                            for(var k=0;k<key1.length;k++)
                                            {
                                                if($("#selecttags").val().split(",")[k]==null)
                                                {
                                                    break;
                                                }
                                                txt+=RemoveRepeat($("#selecttags").val().split(",")[k])+"|";
                                            }
                                           
                                            //ȡ�Ƿ��Ƽ��ı�ʶ
                                            var rcd=$("input[name='yn']:checked").val();
                                            //�Ƿ��ͺ��뻹�� �����ĺ���
                                            var courage=$("input[name='courage']:checked").val();
                                            //��ʾ�����ĺ��룻
                                             if(confirm("���������ǣ�"+$("input[name='testRadio']:checked").val()+"��"+ txt))
                                             {    
                                                  //*******�ص�����******
                                                    $.ajax({
                                                             type: "POST",
                                                             contentType: "application/json",
                                                             url: "WebService1.asmx/AddItem",
                                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                             dataType: 'json',
                                                             complete: function(result) {
                                                             //result���ص�ֵ
                                                                if(result.responseText==0)
                                                                {
                                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                                    return false;
                                                                }
                                                                else
                                                                {
                                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                                        alert('������󣡶�λ��ʽ��ʽ�����֣����֣�����');
                                        return false;
                                    }
                                }
                            }
                            if($("input[name='testRadio']:checked").val()=="��һ����")
                            {
                                if($("#txt_one").val()=="" || $("#txt_two").val()=="" || $("#txt_three").val()=="")
                                {
                                    alert('��λ��ʽ���ݲ���Ϊ�գ�');
                                    return false;
                                }
                                else
                                {
                                    if(!Rex($("#txt_one").val()) || !Rex($("#txt_two").val()) || !Rex($("#txt_three").val()))
                                    {
                                        
                                        alert('��λ��ʽ���������ʽ����ȷ��');
                                        return false;
                                    }
                                    else
                                    {
                                         //ȡֵ�������ݿ�
                                        var time=new Date();
                                        //�ύ��ʱ��
                                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                        var issue=$("#txt_time").val();
                                        if(issue=="" || issue==null || issue=="null")
                                        {
                                            alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                            return false;
                                        }
                                        //����
                                        var txt;
                                        txt=RemoveRepeat($("#txt_one").val())+"*"+RemoveRepeat($("#txt_two").val())+"*"+RemoveRepeat($("#txt_three").val());
                                       
                                        //ȡ�Ƿ��Ƽ��ı�ʶ
                                        var rcd=$("input[name='yn']:checked").val();
                                        //ȡ�������ɱ��ı�ʶ
                                        var courage=$("input[name='courage']:checked").val();
                                          //��ʾ�����ĺ��룻
                                         if(confirm("���������ǣ� ��һλ*�ڶ�λ*����λ"+ txt))
                                         { 
                                              //*******�ص�����******
                                                $.ajax({
                                                         type: "POST",
                                                         contentType: "application/json",
                                                         url: "WebService1.asmx/AddItem",
                                                         data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ txt +"',itemidentity:'"+ courage +"',itemradio:'"+ $("input[name='testRadio']:checked").val() +"',itemcheck:'"+ noList +"',itemnumber:''}",
                                                         dataType: 'json',
                                                         complete: function(result) {
                                                         //result���ص�ֵ
                                                            if(result.responseText==0)
                                                            {
                                                                alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                                return false;
                                                            }
                                                            else
                                                            {
                                                                result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            //*********�ж�˫ɫ��begin****************
        if(lotteryType.value.split('&')[0].split('"')[1]=="˫ɫ��")
        {
            //���������ʱ����ǲ����Է�����Ϣ��
            var time1=new Date();
            if((time1.getDay()==2 || time1.getDay()==4 || time1.getDay()==6) && time1.getHours()>20 && time1.getHours()<22)
            {
                alert("���ڻ����ܷ���������");
                $('#Button2').attr('disabled','true');
                return false;
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="�ۺ�����")
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
                    alert('����Ҫ��дһ����������');
                    return false;
                }
                //�жϺ�����
                if($("#txt_hqdm").val()!="")
                {
                    //��֤�����ʽ(����)
                    if($("#txt_hqdm").val().replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<$("#txt_hqdm").val().split(',').length;i++)
                        {
                            if($("#txt_hqdm").val().split(',')[i]>33)
                            {
                                alert('��������벻�ܴ���33');
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
                                alert('��������벻�ܴ���33');
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
                            alert('��������벻�ܴ���33');
                            return false;
                        }
                        arrhqdm[0]=$("#txt_hqdm").val();
                    }
                    else
                    {
                        alert('������ĸ�ʽ����ȷ');
                        return false;
                    }
                }
                //�ж�������
                if($("#txt_lqdm").val()!="")
                {
                    //��֤�����ʽ(����)
                    if($("#txt_lqdm").val().replace(/\d+(?:,\d+)+/,"")=="" )
                    {
                        for(var i=0;i<$("#txt_lqdm").val().split(',').length;i++)
                        {
                            if($("#txt_lqdm").val().split(',')[i]>16)
                            {
                                alert('��������벻�ܴ���16');
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
                                alert('��������벻�ܴ���16');
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
                            alert('��������벻�ܴ���16');
                            return false;
                        }
                        arrlqdm[0]=$("#txt_lqdm").val();
                    }
                    else
                    {
                        alert('������ĸ�ʽ����ȷ');
                        return false;
                    }
                    
                }
                //�жϸ�ʽ����
                if($("#txt_fstj").val()!="")
                {
                    if($("#txt_fstj").val().split('+').length>0)
                    {
                         //��֤�����ʽ(����)
                        if($("#txt_fstj").val().split('+')[0].replace(/\d+(?:,\d+)+/,"")=="" )
                        {
                            if($("#txt_fstj").val().split('+')[0].split(',').length<6)
                            {
                                alert('����ʽ��������6������');
                                return false;
                            }
                            for(var i=0;i<$("#txt_fstj").val().split('+')[0].split(',').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[0].split(',')[i]>33)
                                {
                                    alert('��ʽ������벻�ܴ���33');
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
                                alert('��ʽ����������6������');
                                return false;
                            }
                            for(var i=0; i<$("#txt_fstj").val().split('+')[0].split(' ').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[0].split(' ')[i]>33)
                                {
                                    alert('��ʽ������벻�ܴ���33');
                                    return false;
                                }
                                arrfs[i]=$("#txt_fstj").val().split('+')[0].split(' ')[i];
                            }
                            arrfs=maopao(unique(arrfs));
                        }
                        else
                        {
                            alert('������ĺ����ʽ����ȷ');
                            return false;
                        }
                        //��֤�����ʽ(����)
                        if($("#txt_fstj").val().split('+')[1].replace(/\d+(?:,\d+)+/,"")=="" )
                        {
                            if($("#txt_fstj").val().split('+')[1].split(',').length<1)
                            {
                                alert('����ʽ��������1������');
                                return false;
                            }
                            for(var i=0; i<$("#txt_fstj").val().split('+')[1].split(',').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[1].split(',')[i]>16)
                                {
                                    alert('��ʽ����ĺ��벻�ܴ���16');
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
                                alert('����ʽ��������1������');
                                return false;
                            }
                            for(var i=0; i<$("#txt_fstj").val().split('+')[1].split(' ').length;i++)
                            {
                                if($("#txt_fstj").val().split('+')[1].split(' ')[i]>16)
                                {
                                    alert('��ʽ����ĺ��벻�ܴ���16');
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
                                alert('��ʽ����ĺ��벻�ܴ���16');
                                return false;
                            }
                            arrfsl[0]=$("#txt_fstj").val().split('+')[1];
                        }
                        else
                        {
                            alert('�������������������');
                            return false;
                        }
                    }
                    else
                    {
                        alert('������ĸ�ʽ����ȷ333');
                        return false;
                    }
                }
                //�жϵ�ʽ����
                if($("#txt_ds").val()!="")
                {
                    if($("#txt_ds").val().split('+').length>0)
                    {
                        //����(�жϺ����ʽ)
                        if($("#txt_ds").val().split('+')[0].replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            if($("#txt_ds").val().split('+')[0].split(',').length!=6)
                            {
                                alert('�������λ���������');
                                return false;
                            }
                            else
                            {
                                for(var i=0;i<$("#txt_ds").val().split('+').split(',').length;i++)
                                {
                                    if($("#txt_ds").val().split('+').split(',')[i]>33)
                                    {
                                        alert('������벻�ܴ���33');
                                        return false;
                                    }
                                    arrds[i]=$("#txt_ds").val().split('+').split(',')[i];
                                }
                            }
                            arrds=maopao(unique(arrds));
                        }//�ո�
                        else if($("#txt_ds").val().split('+')[0].relace(/\d+(?: \d+)+/,"")=="")
                        {
                            if($("#txt_ds").val().split('+')[0].split(' ').length!=6)
                            {
                                alert('�������λ���������');
                                return false;
                            }
                            else
                            {
                                for(var i=0;i<$("#txt_ds").val().split('+').split(' ').length;i++)
                                {
                                    if($("#txt_ds").val().split('+').split(' ')[i]>33)
                                    {
                                        alert('������벻�ܴ���33');
                                        return false;
                                    }
                                    arrds[i]=$("#txt_ds").val().split('+').split(' ')[i];
                                }
                            }
                            arrds=maopao(unique(arrds));
                        }
                        else
                        {
                            alert('��������ʽ�������');
                            return false;
                        }
                        //�ж�����Ϊ������
                        if($("#txt_ds").val().split('+')[1].replace(/^[1-9]\d*$/,"")=="")
                        {
                            if($("#txt_ds").val.split('+')[1]>16)
                            {
                                alert('������벻�ܴ���16');
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
                        alert('������ĸ�ʽ����ȷ');
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
                 /********�������ݿⷽ��**********/
                             var time=new Date();
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
//                                var colligate=arrhqdm+"|"+arrlqdm+"|"+arrfs+"+"+arrfsl+"|"+arrds+"+"+arrdsl;
                                  var colligate="�����룺"+arrhqdm+"  �����룺"+arrlqdm+"  ��ʽ�Ƽ���"+ fstj +"  ��ʽ�Ƽ���"+ dstj
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                if(confirm("���������ǣ�"+"�����룺"+arrhqdm+"  �����룺"+arrlqdm+"  ��ʽ�Ƽ���"+ fstj +"  ��ʽ�Ƽ���"+ dstj))
                                {
                                  //*******�ص�����******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+ $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ colligate +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'',itemnumber:'1'}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result���ص�ֵ
                                                if(result.responseText==0)
                                                {
                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
                                                }
                                             }
                                         });
                                  //**********end************  
                              }
                              else
                              {
                                    return false;
                              }
                        /********�������ݿⷽ��**********/
                
            }
            if(lotteryType.value.split('&')[1].split('|')[0]=="������")
            {
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    
                    alert('��ʽ����ȷ����������롣');
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
                            alert('�������볬��');
                            return false;
                        }
                        else
                        arr[i]=val.split("<br>")[i];
                    }
                    for(var j=0;j<arr.length;j++)
                    {  
                          //Ԫ�����ǲ��Ǵ���,��
                          if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                          {
                              for(var k=0;k<arr[j].split(",").length;k++)
                              {
                                   if(arr[j].split(",")[k].length!=2 || arr[j].split(",")[k]>33 || parseInt(arr[j].split(",")[k])==0)
                                   {
                                        alert('�������������������λ���룬���벻�ܴ���33��');
                                        //��������
                                        return false;
                                   }
                                   else
                                   {
                                        str+=arr[j].split(",")[k]+",";
                                   }     
                              } 
                          }
                          //��֤�ǲ��� ���пո�
                          else if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                          {
                                  for(var k=0;k<arr[j].split(" ").length;k++)
                                  {
                                       if(arr[j].split(" ")[k].length!=2 || arr[j].split(" ")[k]>33 || parseInt(arr[j].split(",")[k])==0)
                                       {
                                            alert('�������������������λ���룬���벻�ܴ���33');
                                            //��������
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
                                    alert('�������������������λ���룬���벻�ܴ���33��');
                                    return false;
                                }
                                else
                                {
                                    str+=arr[j]+",";
                                }
                          }
                          else
                          {
                                alert('����������󣡸�ʽ������,���� ����  ���� ����');
                                return false;
                          }
                    }
                    //ȥ�����һ������
                    var str1=str.substring(0,str.length-1);
                    //ȥ���ظ�����
                    for(var p=0;p<str1.split(",").length;p++)
                    {
                        twoArr[p]=str1.split(",")[p];
                    }
                    var pm=new Array;
                    pm=maopao(unique(twoArr));
                    //*****************�������ݿ�*****************
                      var time=new Date();
                      //�ύ��ʱ��
                      var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                      //ȡ�Ƿ��Ƽ��ı�ʶ
                      var rcd=$("input[name='yn']:checked").val();
                      //ȡ�������ɱ��ı�ʶ
                      var courage=$("input[name='courage']:checked").val();
                      var issue=$("#txt_time").val();
                      if(issue=="" && parseInt(issue)>0)
                      {
                           alert('�ں�Ϊ�գ���ˢ��ҳ��');
                           return false;
                      } 
                      //��ʾ�����ĺ��룻
                     if(confirm("����������ǣ�"+ pm))
                     {          
                          //*******�ص�����******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:' ',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result���ص�ֵ
                                        if(result.responseText==0)
                                        {
                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                            return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="������")
            {
                if($("#txt_time").val()=="" || parseInt($("#txt_time").val())<0)
                {
                    alert('�ںŴ���������ѡ����֣�');
                    return false;
                }
                if($("#selecttags").val()=="")
                {
                    alert('����д���룡');
                    return false;
                }

                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                var str="";
                if(val.split("<br>").length>1)
                {
                    alert('�������д��һ�У����ּ��ö��Ż����ǿո����ֿ�');
                    return false;
                }
                if(val.replace(/\d+(?:,\d+)+/,"")=="" || val.replace(/\d+(?: \d+)+/,"")=="" || val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                {
                     //����ĸ�ʽ���Ǻ���+���ŵ���ʽ
                    if(val.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                       for(var i=0;i<val.split(",").length;i++)
                       {
                            if(val.split(",")[i]>16 || val.split(",")[i].length != 2)
                            {
                                alert('���������01-16');
                                return false;
                            }
                            arr[i]=val.split(",")[i];
                       }
                    }
                    //�ж��ǲ��Ǵ��пո�
                    if(val.replace(/\d+(?: \d+)+/,"")=="")
                    {
                       for(var i=0;i<val.split(" ").length;i++)
                       {
                            if(val.split(" ")[i]>16 || val.split(" ")[i].length > 2)
                            {
                                alert('�����������������뷶Χ��01-16');
                                return false;
                            }
                            arr[i]=val.split(" ")[i];
                       }
                    }
                    //ֻ��һ������
                    if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                    {
                        if(val>16 || val.length != 2 || parseInt(val)<=0)
                        {
                            alert('�����������������뷶Χ��01-16');
                            return false;
                        }
                        arr[0]=val;
                    }
                }
                else
                {
                     alert('��ʽ�������!��ȷ��ʽ�������룬���룩 ���� ������ ���룩');
                     return false;
                }
            
                  twoArr=maopao(unique(arr));              
                //*****************�������ݿ�*****************
                        var time=new Date();
                        //�ύ��ʱ��
                        var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                        var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                        var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                        var issue=$("#txt_time").val();
                        if(issue=="" || issue==null || issue=="null")
                        {
                            alert('�ں����ɴ�����ˢ��һ��ҳ��');
                            return false;
                        }
                        //ȡ�Ƿ��Ƽ��ı�ʶ
                        var rcd=$("input[name='yn']:checked").val();
                        //ȡ�������ɱ��ı�ʶ
                        var courage=$("input[name='courage']:checked").val();
                          //��ʾ�����ĺ��룻
                         if(confirm("��������������ĺ����ǣ�"+ twoArr))
                         {    
                              //*******�ص�����******
                                $.ajax({
                                         type: "POST",
                                         contentType: "application/json",
                                         url: "WebService1.asmx/AddItem",
                                         data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                         dataType: 'json',
                                         complete: function(result) {
                                         //result���ص�ֵ
                                            if(result.responseText==0)
                                            {
                                                alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                return false;
                                            }
                                            else
                                            {
                                                result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            
            
            if(lotteryType.value.split('&')[1].split('|')[0]=="������")
            {
            
                    
            }    
            if(lotteryType.value.split('&')[1].split('|')[0]=="����ʽ")
            {
                if($("#txt_time").val()=="" || parseInt($("#txt_time").val())<=0)
                {
                    alert('�ں����ɴ���������ѡ����֣�');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    alert('˫ɫ������������벻��ȷ���ո�������࣡');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                if(val.split("<br>").length>1)
                {
                    alert('��Ѻ���д��һ���ϣ�');
                    return false;
                }
                
                //�������������ֺͶ��ŵ����
                if(val.replace(/\d+(?:,\d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        arr[i]=val.split(",")[i];
                    }
                }
                //������������ֺͿո�����
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
                    alert('����ʽ����ĺ��벻������6�����ܶ���33��');
                    return false;
                }
                //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                  //��ʾ�����ĺ��룻
                                 if(confirm("����ʽ�ĺ����ǣ�"+ twoArr))
                                 {    
                                  //*******�ص�����******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result���ص�ֵ
                                                if(result.responseText==0)
                                                {
                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="����ʽ")
            {
                if($("#txt_time").val()=="" || parseInt($("#txt_time").val())<=0)
                {
                    alert('�ں����ɴ���������ѡ����֣�');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    alert('˫ɫ��l����ʽ�ĺ����ʽ���벻��ȷ��');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                if(val.split("<br>").length>1)
                {
                    alert('��Ѻ���д��һ���ϣ�');
                    return false;
                }
                //�������������ֺͶ��ŵ����
                if(val.replace(/\d+(?:,\d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        if(val.split(",")[i]>16)
                        {
                            alert('���������1--16');
                            return false;
                        }
                        arr[i]=val.split(",")[i];
                    }
                }
                //������������ֺͿո�����
                if(val.replace(/\d+(?: \d+)+/,"")=="" )
                {
                    for(var i=0;i<val.split(" ").length;i++)
                    {
                        if(val.split(" ")[i]>16)
                        {
                            alert('���������1--16');
                            return false;
                        }
                        arr[i]=val.split(",")[i];
                    } 
                }
                twoArr=maopao(unique(arr));
                if(twoArr.length<2 || twoArr.length>16)
                {
                    alert('������벻�ܵ���2�������ܴ���16����');
                    return false;
                }
                //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                  //��ʾ�����ĺ��룻
                                 if(confirm("����ʽ�ĺ����ǣ�"+ twoArr))
                                 {  
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            
            if(lotteryType.value.split('&')[1].split('|')[0]=="������ʽ")
            {
                if($("#txt_time").val()=="" ||  parseInt($("#txt_time").val())<0)
                {
                    alert('�ں�Ϊ�գ���ˢ��ҳ������ѡ��');
                    return false;
                }
                if($("#selecttags").val()=="")
                {
                    alert('��ʽ����û�����ݣ�');
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
                        alert('���ڰ�����д��һ�У�');
                        return false;
                    }
                    //�ж������ʽ�ǲ��� XXXX+XXX��������
                    if(val.split("+").length!=2)
                    {
                        alert('�����ʽ���������+������룩��');
                        return false;
                    }
                    if((val.split("+")[0].replace(/\d+(?:,\d+)+/,"")!="" && val.split("+")[1].replace(/\d+(?:,\d+)+/,"")!="") || (val.split("+")[0].replace(/\d+(?: \d+)+/,"")!="" && val.split("+")[1].replace(/\d+(?: \d+)+/,"")!=""))
                    {
                        alert('�������ö��Ż����ÿո����');
                        return false;
                    }
                    else
                    {
                        //�����Ƕ��ż�����
                        if(val.split("+")[0].replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            //�������
                            for(var i=0;i<val.split("+")[0].split(",").length;i++)
                            {
                                if(val.split("+")[0].split(",")[i].length > 2 || val.split("+")[0].split(",")[i]>33)
                                {
                                    alert('������ĺ����д���');
                                    return false;
                                }
                                arr[i]=val.split("+")[0].split(",")[i];
                            }
                        }
                        //�����ǿո������
                        if(val.split("+")[0].replace(/\d+(?: \d+)+/,"")=="")
                        {
                            //�������
                            for(var i=0;i<val.split("+")[0].split(" ").length;i++)
                            {
                                if(val.split("+")[0].split(" ")[i].length>2 || val.split("+")[0].split(" ")[i]>33)
                                {
                                    alert('������ĺ����д���');
                                    return false;
                                }
                                arr[i]=val.split("+")[0].split(" ")[i];
                            }
                        }
                        //ȥ��������ظ����������
                        var redArr=new Array;
                        redArr=maopao(unique(arr));
                        if(redArr.length<6)
                        {
                            alert('�������������6λ��');
                            return false;
                        }
                        //�����ǿո���������
                        if(val.split("+")[1].replace(/\d+(?: \d+)+/,"")=="")
                        {
                            //��������
                            for(var j=0;j<val.split("+")[1].split(" ").length;j++)
                            {
                                if(val.split("+")[1].split(" ")[j].length>2 || val.split("+")[1].split(" ")[j]>16)
                                {
                                    alert('�������������д������飡');
                                    return false;
                                }
                                twoArr[j]=val.split("+")[1].split(" ")[j];
                            }
                        }
                        //�����Ƕ��ż��������
                        if(val.split("+")[1].replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            //��������
                            for(var j=0;j<val.split("+")[1].split(",").length;j++)
                            {
                                if(val.split("+")[1].split(",")[j].length>2 || val.split("+")[1].split(",")[j]>16)
                                {
                                    alert('�������������д������飡');
                                    return false;
                                }
                                twoArr[j]=val.split("+")[1].split(",")[j];
                            }
                        }
                        //�������ֻ��һ��
                        if(val.split("+")[1].replace(/^[0-9]*[1-9][0-9]*$/,"")=="" && val.split("+")[1].length==2)
                        {
                            if(val.split("+")[1]>16)
                            {
                                alert('���������������');
                                return false;
                            }
                            twoArr[0]=val.split("+")[1];
                        }
                        var pm=redArr+ "+" + maopao(unique(twoArr));
                        //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                   //��ʾ�����ĺ��룻
                                 if(confirm("������ʽ�ĺ����ǣ�"+ pm))
                                 {    
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="��ʽ")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('�ںŴ���������ѡ��');
                    return false;
                }
                if($("#selecttags").val()=="")
                {
                    alert('��ʽ����û�����ݣ�');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                var twoArr=new Array;
                var str="";
                if(val.split("<br>").length>1)
                {
                    alert('���ڰ�����д��һ�У�');
                    return false;
                }
                //�ж������ʽ�ǲ��� XXXX+XXX��������
                if(val.split("+").length!=2)
                {
                    alert('�����ʽ���������+������룩��');
                    return false;
                }
                if(val.split("+")[0].replace(/\d+(?:,\d+)+/,"")!="" || val.split("+")[0].split(",").length!=6 )
                {
                    alert('��������ĸ�ʽ�������Ƿ���ȷ');
                    return false;
                }
                if(val.split("+")[1].replace(/\d+(?:,\d+)+/,"")=="")
                {
                    alert('��ѡ��������д��һ������');
                    return false;
                }
                if(val.split("+")[1].replace(/^[0-9]*[1-9][0-9]*$/,"")!="" || val.split("+")[1]>16)
                {
                    alert('��������������');
                    return false;
                }
                else
                {
                    for(var i=0;i<val.split("+")[0].split(",").length;i++)
                    {
                        if(val.split("+")[0].split(",")[i].length>2 || val.split("+")[0].split(",")[i].replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                        {
                            alert('����ĺ����������');
                            return false;
                        }
                        arr[i]=val.split("+")[0].split(",")[i];
                    }
                    twoArr=unique(arr);
                    var pm=twoArr+"+"+val.split("+")[1];
                    //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                    //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {    
                                  //*******�ص�����******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result���ص�ֵ
                                                if(result.responseText==0)
                                                {
                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
         //**************s˫ɫ��end***********************
         
         //**************���ֲ� begin*********************
            if(lotteryType.value.split('&')[0].split('"')[1]=="���ֲ�")
            {
                if(lotteryType.value.split('&')[1].split('|')[0]=="����")
                {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
                        return false;
                    }
                    //�滻�س�
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1 && val.split("<br>").length<31)
                    {
                        //��������
                        for(var i=0;i<val.split("<br>").length;i++)
                        {
                            arr[i]=val.split("<br>")[i];
                        }
                        for(var j=0;j<arr.length;j++)
                        {
                            if(arr[j].length>30)
                            {
                                alert('����ĺ��벻�ܳ����� 30λ��');
                                return false;
                            }   
                            //������
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(",").length;k++)
                                {
                                    if(arr[j].split(",")[k].length>2)
                                    {
                                        alert('���ֲʵĺ���Ϊ2λ����');
                                        return false;
                                    }
                                    str+=arr[j].split(",")[k]+",";
                                }
                            }
                            //����ո�
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2)
                                    {
                                        alert('���ֲʵĺ���Ϊ2λ����');
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
                        //ȥ�����һ��,��
                        var dpstr=str.substring(0,str.length-1);
                        for(var p=0;p<dpstr.split(",").length;p++)
                        {
                            twoArr[p]=dpstr.split(",")[p];
                        }
                        var pm=new Array;
                        pm=maopao(unique(twoArr));
                        if(pm.length<6 || pm.length>30)
                        {
                            alert('������ĺ����������');
                            return false;
                        }
                        //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                  //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {      
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                    //�������ĺ���ֻ��һ��
                    //һ�к����Ƕ��ź��������
                    if(val.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(",").length;i++)
                        {
                            if(val.split(",")[i].length>2)
                            {
                                alert('������ĺ������');
                                return false;
                            }
                            arr[i]=val.split(",")[i];
                        }
                    }
                    //һ�к����ǿո���������
                    if(val.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(" ").length;i++)
                        {
                            if(val.split(" ")[i].length>2)
                            {
                                alert('������ĺ������');
                                return false;
                            }
                            arr[i]=val.split(" ")[i];
                        }
                    }
                    if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                    {
                        if(val.length>2)
                        {
                            alert('������ĺ������');
                            return false;
                        }
                        arr[0]=val;
                    }
                    //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                  //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ arr))
                                 {      
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ arr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                if(lotteryType.value.split('&')[1].split('|')[0]=="��ʽ")
                {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
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
                            //Ԫ���Ƕ��ź��������
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                               for(var k=0;k<arr[j].split(",").length;k++)
                               {
                                    if(arr[j].split(",")[k].length>2)
                                    {
                                        alert('����ĺ��벻�ܳ���2λ����');
                                        return false;
                                    }
                                    str+=arr[j].split(",")[k]+",";
                               }
                            }
                            //Ԫ���ǿո���������
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(" ").length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2)
                                    {
                                        alert('����ĺ��벻�ܳ���2λ����');
                                        return false;
                                    }
                                    str+=arr[j].split(" ")[k]+",";
                                }
                                
                            }
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                            {
                                if(arr[j].length>2)
                                {
                                    alert('����ĺ��벻�ܳ���2λ����');
                                    return false;
                                }
                            }
                            //ȥ�����һ������
                            var dpstr=str.substring(0,str.length-1);
                            for(var p=0;p<dpstr.split(",").length;p++)
                            {
                                twoArr[p]=dpstr.split(",")[p];
                            }
                            var pm=new Array;
                            pm=maopao(unique(twoArr));
                            if(pm.length<7 || pm.length>30)
                            {
                                alert('���ֲʸ�ʽ�������벻��ȷ��');
                                return false;
                            }
                            //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {      
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                if(lotteryType.value.split('&')[1].split('|')[0]=="��ʽ")
                {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1)
                    {
                        alert('��Ѻ��������һ�У�');
                        return false;
                    }
                    if(val.replace(/\d+(?:,\d+)+/,"")!="" || val.replace(/\d+(?: \d+)+/,"")!="")
                    {
                        alert('���ֲʵ�ʽ�����������ʽ����ȷ��');
                        return false;
                    }
                    //Ԫ���Ƕ��ź��������
                    if(val.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(",").length;i++)
                        {
                            if(val.split(",")[i].length>2)
                            {
                                alert('������������');
                                return false;
                            }
                            arr[i]=val.split(",")[i];
                        }
                    }
                    //Ԫ���ǿո���������
                    if(val.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<val.split(" ").length;i++)
                        {
                            if(val.split(" ")[i].length>2)
                            {
                                alert('������������');
                                return false;
                            }
                            arr[i]=val.split(" ")[i];
                        }
                    }
                    twoArr=maopao(unique(arr));
                    if(twoArr.length>7)
                    {

                        alert('���ֲʵ�ʽ�����ĺ��������������');
                        return false;

                    }
                    //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ twoArr))
                                 {       
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ twoArr +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
         //*******************���ֲ� end******************
         
         //*******************����͸��Ʊ begin***********
          if(lotteryType.value.split('&')[0].split('"')[1]=="����͸")
          {
               if(lotteryType.value.split('&')[1].split('|')[0]=="ǰ������")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>35)
                    {
                        alert('���ĺ�������̫�ࡣ������Χ');
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
                            //�����Ƕ��ź�������ɵ�
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                                for(var k=0; k<arr[j].split(",").length;k++)
                                {
                                    if(arr[j].split(",")[k].length>2 || arr[j].split(",")[k]>35)
                                    {
                                        alert('�������벻��ȷ��');
                                        return false;
                                    }
                                    str+=arr[j].split(",")[k]+ ",";
                                }
                            }
                            //�����ǿո��������ɵ�
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(" ").length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2 || arr[j].split(" ")[k]>35)
                                    {
                                        alert('�������벻��ȷ');
                                        return false;
                                    }
                                    str+=arr[j].split(" ")[k]+ ",";
                                }
                            }
                            //ֻ��һ������ţ�
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                            {
                                if(arr[j].length>2 || arr[j]>35)
                                {
                                    alert('�������벻��ȷ');
                                    return false;
                                }
                                str+=arr[j]+",";
                            }
                         }
                         //ȥ�����һ������
                         var dpstr=str.substring(0,str.length-1);
                         for(var p=0;p<dpstr.split(",").length;p++)
                         {
                            twoArr[p]=dpstr.split(",")[p];
                         }
                         //����ȥ�ظ�
                         var pm=new Array;
                         pm=maopao(unique(twoArr));
                         if(pm.length>35)
                         {
                            alert('������ĺ���̫��');
                            return false;
                         }
                             //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {       
                                  //*******�ص�����******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result���ص�ֵ
                                                if(result.responseText==0)
                                                {
                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
               if(lotteryType.value.split('&')[1].split('|')[0]=="��������")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    //�����лس���
                    if(val.split("<br>").length>1 && val.split("<br>").length<13)
                    {
                        for(var i=0;i<val.split("<br>").length;i++)
                        {
                            arr[i]=val.split("<br>")[i];
                        }
                        for(var j=0;j<arr.length;j++)
                        {
                            //��֤�����ǿո�+���ֵ�ģʽ
                            if(arr[j].replace(/\d+(?: \d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(" ").length;k++)
                                {
                                    if(arr[j].split(" ")[k].length>2 || arr[j].split(" ")[k]>12)
                                    {
                                        alert('������ĺ����д���');
                                        return false;
                                    }
                                    str+=arr[j].split(" ")[k] + ",";
                                }
                            }
                            //��֤�����Ƕ���+���ֵ�ģʽ
                            if(arr[j].replace(/\d+(?:,\d+)+/,"")=="")
                            {
                                for(var k=0;k<arr[j].split(",").length;k++)
                                {
                                    if(arr[j].split(",")[k]>2 || arr[j].split(",")[k]>12)
                                    {
                                        alert('������ĺ����д���');
                                        return false;
                                    }
                                    str+= arr[j].split(",")[k] + ",";
                                }
                            }
                            //��֤������1������
                            if(arr[j].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                            {
                                if(arr[j].length>2 || arr[j]>12)
                                {
                                    alert('������ĺ���������');
                                    return false;
                                }
                                str+= arr[j] + ",";
                            }
                        }
                        //ȥ���ַ����е����һ������
                        var dpstr=str.substring(0,str.length-1);
                        for(var p=0;p<drstr.split(",").length;p++)
                        {
                            twoArr[p]=dpstr.split(",")[p];
                        }
                        var pm=new Array;
                        pm=maopao(unique(twoArr));
                        if(pm.length>12)
                        {
                            alert('������ĺ������');
                            return false;
                        }
                        //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                               var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                               var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                               var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                               var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {       
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
                        //�������һ�к���
                        //��֤�����ǿո�+���ֵ�ģʽ
                        if(val.replace(/\d+(?: \d+)+/,"")=="")
                        {
                            for(var k=0;k<arr[j].split(" ").length;k++)
                            {
                                if(val.split(" ")[k].length>2 || val.split(" ")[k]>12)
                                {
                                    alert('������ĺ����д���');
                                    return false;
                                }
                                arr[k]=val.split(" ")[k];
                            }
                        }
                        //��֤�����Ƕ���+���ֵ�ģʽ
                        if(val.replace(/\d+(?:,\d+)+/,"")=="")
                        {
                            for(var k=0;k<arr[j].split(",").length;k++)
                            {
                                if(val.split(",")[k]>2 || val.split(",")[k]>12)
                                {
                                    alert('������ĺ����д���');
                                    return false;
                                }
                                arr[k] = val.split(",")[k];
                            }
                        }
                        //��֤������1������
                        if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                        {
                            if(val.length>2 || val>12)
                            {
                                alert('������ĺ���������');
                                return false;
                            }
                            arr[0] = val ;
                        }
                        //ȥ���ظ�
                        var pm=new Array;
                        pm=maopao(unique(arr));
                        //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {     
                                  //*******�ص�����******
                                    $.ajax({
                                             type: "POST",
                                             contentType: "application/json",
                                             url: "WebService1.asmx/AddItem",
                                             data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                             dataType: 'json',
                                             complete: function(result) {
                                             //result���ص�ֵ
                                                if(result.responseText==0)
                                                {
                                                    alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                                }
                                                else
                                                {
                                                    result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
               if(lotteryType.value.split('&')[1].split('|')[0]=="��ʽ")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    if(val.split("<br>").length>1)
                    {
                        alert('��Ѻ���д��һ�У�����̫����Զ�����');
                        return false;    
                    }
                    if(val.split("+").length!=2)
                    {
                        alert('��ʽ�����ʽ������ + ���� ��������ã��Ż�ո����');
                        return false;
                    }
                    //����+��ǰ��ĺ���  *****begein
                    var front=val.split("+")[0];
                    var frontArr=new Array;
                    if(front.replace(/\d+(?:,\d+)+/,"")!="" || front.replace(/\d+(?: \d+)+/,"")!="")
                    {
                        alert('����ĺ����ʽ����');
                        return false;
                    }
                    //ƥ�䶺��
                    if(front.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i< front.split(",").length;i++)
                        {
                            if(front.split(",")[i].length>2 || front.split(",")[i]>35)
                            {
                                alert('����ĺ����д���');
                                return false;
                            }
                            arr[i]=front.split(",")[i];
                        }
                    }
                    //ƥ��ո�
                    if(front.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<front.split(" ").length;i++)
                        {
                            if(front.split(" ")[i].length>2 || front.split(" ")[i]>35)
                            {
                                alert('����ĺ����д���');
                                return false;
                            }
                            arr[i]=front.split(" ")[i];
                        }
                    }
                    frontArr=maopao(unique(arr));
                    if(frontArr.length<5 || frontArr.length>35)
                    {
                        alert('����ĺ����������');
                        return false;
                    } 
                    //*****end
                    //����+�ź���ĺ��� ****begin
                    var back=val.split("+")[1];
                    var backArr=new Array;
                    if(back.replace(/\d+(?:,\d+)+/,"")!="" || back.replace(/\d+(?: \d+)+/,"")!="")
                    {
                        alert('����ĺ����ʽ����');
                        return false;
                    }
                    //ƥ��,��
                    if(back.replace(/\d+(?:,\d+)+/,"")=="" )
                    {
                        for(var i=0;i<back.split(",").length;i++)
                        {
                            if(back.split(",")[i].length>2 || back.split(",")[i]>12)
                            {
                                alert('������ĺ����д���');
                                return false;
                            }
                            twoArr[i]=back.split(",")[i];
                        }
                    }
                    //ƥ��ո�
                    if(back.replace(/\d+(?: \d+)+/,"")=="")                  
                    {
                        for(var i=0;i<back.split(" ").length;i++)
                        {
                            if(back.split(" ")[i].length>2 || back.split(" ")>12)
                            {
                                alert('������ĺ����д���');
                                return false;
                            }
                            twoArr[i]=back.split(" ")[i];
                        }
                    }
                    backArr=maopao(unique(twoArr));
                    if(backArr.length<2 || back.length>12)
                    {
                        alert('����������벻��ȷ');
                        return false;
                    }
                    var pm=frontArr + "+" + backArr;
                    //*****end
                    //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {     
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
               if(lotteryType.value.split('&')[1].split('|')[0]=="��ʽ")
               {
                    if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                    {
                        alert('�ںŴ���������ѡ��');
                        return false;
                    }
                    if(!TextValidate(trim($("#selecttags").val())))
                    {
                        
                        alert('�������벻��ȷ');
                        return false;
                    }
                    var val=TransferString(trim($("#selecttags").val()));
                    var arr=new Array;
                    var twoArr=new Array;
                    var str="";
                    
                    if(val.split("<br>").length>1)
                    {
                        alert('��Ѻ���д��һ��');
                        return false;
                    }
                    if(val.split("+").length!=2)
                    {
                        alert('��ʽ�����ʽ��ǰ������+�������룬���������ö��Ż��ո����');
                        return false;
                    }
                    //����ǰ������
                    var frontNum=val.split("+")[0];
                    var frontArr=new Array;
                    if(frontNum.replace(/\d+(?: \d+)+/,"")!="" || frontNum.replace(/\d+(?:,\d+)+/,"")!="")
                    {
                        alert('ǰ�������ʽ�������');
                        return false;
                    }
                    //�����ǿո���������
                    if(frontNum.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<frontNum.split(" ").length;i++)
                        {
                            if(frontNum.split(" ")[i].length>2 || frontNum.split(" ")[i]>35)
                            {
                                alert('������ĺ����д�������');
                                return false;
                            }
                            arr[i]=frontNum.split(" ")[i];
                        }
                        frontArr=maopao(unique(arr));
                        if(frontArr.length!=5)
                        {
                            alert('ǰ�������������');
                            return false;
                        }
                    }
                    //�����Ƕ��ż��������
                    if(frontNum.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<frontNum.split(",").length;i++)
                        {
                            if(frontNum.split(",")[i].length>2 || frontNum.split(",")[i]>35)
                            {
                                alert('������ĺ����д�������');
                                return false;
                            }
                            arr[i]=frontNum.split(",")[i];
                        }
                        frontArr=maopao(unique(arr));
                        if(frontArr.length!=5)
                        {
                            alert('ǰ�������������');
                            return false;
                        }
                    }
                    //�����������
                    var backNum=val.split("+")[1];
                    var backArr=new Array;
                    if(backNum.replace(/\d+(?: \d+)+/,"")!="" || backNum.replace(/\d+(?:,\d+)+/,"")!="")
                    {
                        alert('���������ʽ�������');
                        return false;
                    }
                    //����ƥ��ո�
                    if(backNum.replace(/\d+(?: \d+)+/,"")=="")
                    {
                        for(var i=0;i<backNum.split(" ").length;i++)
                        {
                            if(backNum.split(" ").length>2 || backNum.split(" ")[i]>12)
                            {
                                alert('������ĺ��������������');
                                return false;
                            }
                            twoArr[i]=backNum.split(" ")[i];
                        }
                        backArr=maopao(unique(twoArr));
                        if(backArr.length!=2)
                        {
                            alert('���������������');
                            return false;
                        }
                    }
                    //����ƥ�䶺��
                    if(backNum.replace(/\d+(?:,\d+)+/,"")=="")
                    {
                        for(var i=0;i<backNum.split(",").length;i++)
                        {
                            if(backNum.split(",").length>2 || backNum.split(",")[i]>12)
                            {
                                alert('������ĺ��������������');
                                return false;
                            }
                            twoArr[i]=backNum.split(",")[i];
                        }
                        backArr=maopao(unique(twoArr));
                        if(backArr.length!=2)
                        {
                            alert('���������������');
                            return false;
                        }
                    }
                    var pm= frontNum + "+" + backNum;
                    //*****************�������ݿ�*****************
                                var time=new Date();
                                //�ύ��ʱ��
                                var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                                var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                                var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                                var issue=$("#txt_time").val();
                                if(issue=="" || issue==null || issue=="null")
                                {
                                    alert('�ں����ɴ�����ˢ��һ��ҳ��');
                                    return false;
                                }
                                //ȡ�Ƿ��Ƽ��ı�ʶ
                                var rcd=$("input[name='yn']:checked").val();
                                //ȡ�������ɱ��ı�ʶ
                                var courage=$("input[name='courage']:checked").val();
                                 //��ʾ�����ĺ��룻
                                 if(confirm("�������ĺ����ǣ�"+ pm))
                                 {     
                                      //*******�ص�����******
                                        $.ajax({
                                                 type: "POST",
                                                 contentType: "application/json",
                                                 url: "WebService1.asmx/AddItem",
                                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                                 dataType: 'json',
                                                 complete: function(result) {
                                                 //result���ص�ֵ
                                                    if(result.responseText==0)
                                                    {
                                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
         //******************����͸��Ʊ end**************
         //************���ǲʲ�Ʊ begin*****************
         if(lotteryType.value.split('&')[0].split('"')[1]=="���ǲ�")
         {
            if(lotteryType.value.split('&')[1].split('|')[0]=="����")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('�ںŴ���������ѡ��');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    
                    alert('�������벻��ȷ');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                if(val.split("<br>").length>1)
                {
                    alert('������ĺ����лس���������������');
                    return false;
                }
                if( val.replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                {
                    alert('����Ӧ����0000000-9999999��������');
                    return false;
                }
                var pm=RemoveRepeat(val);
                //*****************�������ݿ�*****************
                    var time=new Date();
                    //�ύ��ʱ��
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                        return false;
                    }
                    //ȡ�Ƿ��Ƽ��ı�ʶ
                    var rcd=$("input[name='yn']:checked").val();
                    //ȡ�������ɱ��ı�ʶ
                    var courage=$("input[name='courage']:checked").val();
                      //��ʾ�����ĺ��룻
                     if(confirm("�������ĺ����ǣ�"+ pm))
                     {    
                          //*******�ص�����******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result���ص�ֵ
                                        if(result.responseText==0)
                                        {
                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                            return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="��λ����")
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
                    alert('����Ϊ0-9�������');
                    return false;
                }
                if(trim($("#Text1").val())!="")
                {
                    if(trim($("#Text1").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num1=trim($("#Text1").val());
                }
                if(trim($("#Text2").val())!="")
                {
                    if(trim($("#Text2").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num2=trim($("#Text2").val());
                }
                if(trim($("#Text3").val())!="")
                {
                    if(trim($("#Text3").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num3=trim($("#Text3").val());
                }
                if(trim($("#Text4").val())!="")
                {
                    if(trim($("#Text4").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num4=trim($("#Text4").val());
                }
                if(trim($("#Text5").val())!="")
                {
                    if(trim($("#Text5").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num5=trim($("#Text5").val());
                }
                if(trim($("#Text6").val())!="")
                {
                    if(trim($("#Text6").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num6=trim($("#Text6").val());
                }
                if(trim($("#Text7").val())!="")
                {
                    if(trim($("#Text7").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0-9�������');
                        return false;
                    }    
                    num7=trim($("#Text7").val());
                }
                var pm=RemoveRepeat(num1)+"|"+RemoveRepeat(num2)+"|"+RemoveRepeat(num3)+"|"+RemoveRepeat(num4)+"|"+RemoveRepeat(num5)+"|"+RemoveRepeat(num6)+"|"+RemoveRepeat(num7);
                //*****************�������ݿ�*****************
                    var time=new Date();
                    //�ύ��ʱ��
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                        return false;
                    }
                    //ȡ�Ƿ��Ƽ��ı�ʶ
                    var rcd=$("input[name='yn']:checked").val();
                    //ȡ�������ɱ��ı�ʶ
                    var courage=$("input[name='courage']:checked").val();
                     //��ʾ�����ĺ��룻
                     if(confirm("�������ĺ����ǣ�"+ pm))
                     {     
                      //*******�ص�����******
                        $.ajax({
                                 type: "POST",
                                 contentType: "application/json",
                                 url: "WebService1.asmx/AddItem",
                                 data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                 dataType: 'json',
                                 complete: function(result) {
                                 //result���ص�ֵ
                                    if(result.responseText==0)
                                    {
                                        alert("����ӹ�'"+ issue +"'�ڵ�����");
                                         return false;
                                    }
                                    else
                                    {
                                        result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="��λ��ʽ")
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
                    alert('����Ϊ0-9�������');
                    return false;
                }
                if(trim($("#Text1").val())!="")
                {
                    if(trim($("#Text1").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num1=trim($("#Text1").val());
                }
                if(trim($("#Text2").val())!="")
                {
                    if(trim($("#Text2").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num2=trim($("#Text2").val());
                }
                if(trim($("#Text3").val())!="")
                {
                    if(trim($("#Text3").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num3=trim($("#Text3").val());
                }
                if(trim($("#Text4").val())!="")
                {
                    if(trim($("#Text4").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num4=trim($("#Text4").val());
                }
                if(trim($("#Text5").val())!="")
                {
                    if(trim($("#Text5").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num5=trim($("#Text5").val());
                }
                if(trim($("#Text6").val())!="")
                {
                    if(trim($("#Text6").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num6=trim($("#Text6").val());
                }
                if(trim($("#Text7").val())!="")
                {
                    if(trim($("#Text7").val()).replace(/^[0-9]*[1-9][0-9]*$/,"")!="")
                    {
                        alert('����Ϊ0000000-9999999�������');
                        return false;
                    }    
                    num7=trim($("#Text7").val());
                }
                var pm=num1+"|"+num2+"|"+num3+"|"+num4+"|"+num5+"|"+num6+"|"+num7;
                //*****************�������ݿ�*****************
                    var time=new Date();
                    //�ύ��ʱ��
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                        return false;
                    }
                    //ȡ�Ƿ��Ƽ��ı�ʶ
                    var rcd=$("input[name='yn']:checked").val();
                    //ȡ�������ɱ��ı�ʶ
                    var courage=$("input[name='courage']:checked").val();
                     //��ʾ�����ĺ��룻
                     if(confirm("�������ĺ����ǣ�"+ pm))
                     {     
                          //*******�ص�����******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result���ص�ֵ
                                        if(result.responseText==0)
                                        {
                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="��ʽ")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('�ںŴ���������ѡ��');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    
                    alert('�������벻��ȷ');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                if(val.split("<br>").length>1)
                {
                    alert('������ĺ�����лس�����');
                    return false;
                }
                if(val.lengtn!=7)
                {
                    alert('������ĺ����������');
                    return false;
                }
                //*****************�������ݿ�*****************
                    var time=new Date();
                    //�ύ��ʱ��
                   var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                   var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                   var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                   var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                        return false;
                    }
                    //ȡ�Ƿ��Ƽ��ı�ʶ
                    var rcd=$("input[name='yn']:checked").val();
                    //ȡ�������ɱ��ı�ʶ
                    var courage=$("input[name='courage']:checked").val();
                     //��ʾ�����ĺ��룻
                     if(confirm("�������ĺ����ǣ�"+ val))
                     {     
                          //*******�ص�����******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ val +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result���ص�ֵ
                                        if(result.responseText==0)
                                        {
                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
            if(lotteryType.value.split('&')[1].split('|')[0]=="������")
            {
                
            }
         }
         //*************���ǲʲ�Ʊ end*******************
         
         //**********����5��Ʊ begin**************
         if(lotteryType.value.split('&')[0].split('"')[1]=="������")
         {
            
            if(lotteryType.value.split('&')[1].split('|')[0]=="����")
            {
                if($("#txt_time").val() =="" || parseInt($("#txt_time").val())<0)
                {
                    alert('�ںŴ���������ѡ��');
                    return false;
                }
                if(!TextValidate(trim($("#selecttags").val())))
                {
                    alert('�������벻��ȷ');
                    return false;
                }
                var val=TransferString(trim($("#selecttags").val()));
                var arr=new Array;
                if(val.split("<br>").length>1)
                {
                    alert('�����ʽ����,�벻Ҫ������س�');
                    return false;
                }
                //����ƥ��ո�
                if(val.replace(/\d+(?: \d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(" ").length;i++)
                    {
                        if(val.split(" ")[i].length>1 || val.split(" ")[i]>9)
                        {
                            alert('������0-9֮��ĺ���');
                            return false;
                        }
                        arr[i]=val.split(" ")[i];
                    }
                }
                //����ƥ�䶺��
                if(val.replace(/\d+(?:,\d+)+/,"")=="")
                {
                    for(var i=0;i<val.split(",").length;i++)
                    {
                        if(val.split(",")[i].length>1 || val.split(",")[i]>9)
                        {
                            alert('������0-9֮��ĺ���');
                            return false;
                        }
                        arr[i]=val.split(",")[i];
                    }
                }
                //ֻ��һ������
                if(val.replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                {
                    if(val.length>1 || val>9)
                    {
                        alert('������0-9֮��ĺ���');
                        return false;
                    }
                    arr[0]=val;
                }
                //ȥ�ظ�����
                var pm=new Array;
                pm=maopao(unique(arr));
                //*****************�������ݿ�*****************
                    var time=new Date();
                    //�ύ��ʱ��
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                        return false;
                    }
                    //ȡ�Ƿ��Ƽ��ı�ʶ
                    var rcd=$("input[name='yn']:checked").val();
                    //ȡ�������ɱ��ı�ʶ
                    var courage=$("input[name='courage']:checked").val();
                    //��ʾ�����ĺ��룻
                     if(confirm("�������ĺ����ǣ�"+ pm))
                     {      
                          //*******�ص�����******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result���ص�ֵ
                                        if(result.responseText==0)
                                        {
                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
           if(lotteryType.value.split('&')[1].split('|')[0]=="��λ����")
           {
                var pl1;
                var pl2;
                var pl3;
                var pl4;
                var pl5;
                
                if($("#pl1").val()=="" && $("#pl2").val()=="" && $("#pl3").val()=="" && $("#pl4").val()=="" && $("#pl5").val()=="")
                {
                    alert('����д��λ����ĺ���');
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
                        alert('��һλ��������0-9֮�������');
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
                            alert('�ڶ�λ��������0-9֮�������');
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
                            alert('����λ��������0-9֮�������');
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
                            alert('����λ��������0-9֮�������');
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
                        alert('����λ��������0-9֮�������');
                        return false;
                    }
                        pl5=$("#pl5").val();
                }
                var str=RemoveRepeat(pl1)+RemoveRepeat(pl2)+RemoveRepeat(pl3)+RemoveRepeat(pl4)+RemoveRepeat(pl5);
                var pm=str;
                //*****************�������ݿ�*****************
                    var time=new Date();
                    //�ύ��ʱ��
                    var month=time.getMonth() <10 ? "0"+time.getMonth() : time.getMonth();
                    var day=time.getDate() <10 ? "0"+time.getDate() : time.getDate();
                    var date=time.getFullYear()+"-"+(parseInt(month)+1)+"-"+day+" "+time.toLocaleTimeString();
                    var issue=$("#txt_time").val();
                    if(issue=="" || issue==null || issue=="null")
                    {
                        alert('�ں����ɴ�����ˢ��һ��ҳ��');
                        return false;
                    }
                    //ȡ�Ƿ��Ƽ��ı�ʶ
                    var rcd=$("input[name='yn']:checked").val();
                    //ȡ�������ɱ��ı�ʶ
                    var courage=$("input[name='courage']:checked").val();
                     //��ʾ�����ĺ��룻
                     if(confirm("�������ĺ����ǣ�"+ pm))
                     {       
                          //*******�ص�����******
                            $.ajax({
                                     type: "POST",
                                     contentType: "application/json",
                                     url: "WebService1.asmx/AddItem",
                                     data: "{itemid:'"+  $("#ddlitemName").val() +"',expectnum:'"+ issue +"',issueTime:'"+ date +"',Commend:'"+ rcd +"',content:'"+ pm +"',itemidentity:'"+ courage +"',itemradio:'',itemcheck:'"+ noList +"',itemnumber:''}",
                                     dataType: 'json',
                                     complete: function(result) {
                                     //result���ص�ֵ
                                        if(result.responseText==0)
                                        {
                                            alert("����ӹ�'"+ issue +"'�ڵ�����");
                                                    return false;
                                        }
                                        else
                                        {
                                            result.responseText>0 ? alert('��ӳɹ�') : alert('���ʧ��');
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
         //**********����5��Ʊ  end***************   
     });
});
//���ɵ�ѡ��ť key4:����  key5:����
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
	
	//*********beginû�е���¼��ĵ�ѡ��ť*************
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
	 //*****�������ر�����ֵ����ʾ���������ı�******
	 function hide(obj)
	 {
	        var objName=document.getElementById(obj);
	        var lotteryType=document.getElementById("lotteryType");
            if(lotteryType.value!=null)
            {
                if(lotteryType.value.split("&")[0].split('"')[1]=="3D"  || lotteryType.value.split('&')[0].split('"')[1]=="����3")
                {
                    if(lotteryType.value.split('&')[1].split('|')[0]=="��λ��ʽ")
                    {
                        if(objName.value=="��һ����")
                        {
                            document.getElementById("gut_1").style.display="block";
                            document.getElementById("gut").style.display="none";
                             return;
                        }
                        if(objName.value=="�������")
                        {
                           document.getElementById("gut").style.display="block";
                            document.getElementById("gut_1").style.display="none";
                             return;
                        }
                    }
                    if(lotteryType.value.split('&')[1].split('|')[0]=="������")
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
	
	
	
	//���ɶ�ѡ��ť
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
	//ѭ�����ɶ����ѡ�� ( ���Է���������)
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
	
	//**********ѭ�����ɵ�ѡ��ť*************
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
	
	
	//********���ɶ�ѡ��ĵ���¼� ����***************
	   function checkID(id)
	   {
            var obj=document.getElementById(id);
	       if(obj.value=="��ֵ")
	       {
	          document.getElementById("gut").style.display="block";
	          document.getElementById('gut_1').style.display="none";
              document.getElementById("gut_pl5").style.display="none";
              document.getElementById("gut_7xc").style.display="none";
               return;
	       }

	       if(obj.value=="��ֵ��ż")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("����","ż��","");
	             return;
	       }
	       if(obj.value=="��ֵ��С")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("����","С��","");
	             return;
	       }
	       if(obj.value=="��ֵ012·")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("0·","1·","2·");
	             return;
	       }
	       if(obj.value=="��ֵ����")
	       {
	            document.getElementById("gut").style.display="block";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                 return;
	       }
	       if(obj.value=="���")
	       {
	            document.getElementById("gut").style.display="block";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                 return;
	       }
	       if(obj.value=="�����ż")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("����","ż��","");
	             return;
	       }
	       if(obj.value=="��ȴ�С")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("����","С��","");
	             return;
	       }
	       if(obj.value=="���012·")
	       {
	            document.getElementById("gut").style.display="none";
	            document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
	            CyRadioCheck("0·","1·","2·");
	             return;
	       }
	       //3D
	       if(obj.value=="��������")
	       {
	        
	       }
	       //3D
	       if(obj.value=="ż������")
	       {
	            
	       }
	   }
	
	//**********************end***********************8**
	
	
//    //��ѡ��ťȡֵ
//    function Chooes(obj,key4,key5)
    function Chooes(obj)
    {
        var chooes=document.getElementById(obj);
        if(chooes.checked)
        {   
//            if(key4=="3D" || key4=="����3")
//            {
//                if(type=="����")
//                {
                    if(chooes.id=="radio_1")
                    {
                       //�ж����Ǹ����ֵĺ�����
                       addCheckbos("��","ʮ","��");
                    }
                    if(chooes.id=="radio_2")
                    {
                       addCheckbos("��ʮ","�ٸ�","ʮ��");
                    }  
                    if(chooes.id=="radio_3")
                    {
                       addCheckbos("��ʮ","�ٸ�","ʮ��");
                    } 
//                }
//                if(type=="������")
//                {
//                    
//                }
//            }
           
        }
        //�����������װ���������ݵ��������ID �Զ��жϰ󶨶�ѡ��
    }
    
 //********beginѡ����ֺ����ͺ��ж�**************8
    function ValotteryType(lottery,type)
    {
        //�����Ҫ�޸Ĳ������ƺ��������� ��ô��XML�����Ӧ
        if(lottery=="3D" || lottery=="������")
        {
                document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
            if(type=="����")
            {
                document.getElementById("gut").style.display="block";
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut_colligate_3D").style.display="none";
//                addRadio('����','��ѡ����','��ѡ����',lottery,type);
                addRadio('����','��ѡ����','��ѡ����');
                 return;

            }
            if(type=="������")
            {
                 document.getElementById("gut").style.display="block";
                 document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                 document.getElementById("Condition_Rad").innerHTML="";
                 document.getElementById("Condition_ck").innerHTML="";
                 addRadio1('�������','��һ����','');
                  return;
            }
            if(type=="��ֵ")
            {
                  document.getElementById("gut").style.display="none";
                  document.getElementById("gut_colligate_3D").style.display="none";
                  document.getElementById("Condition_Rad").innerHTML="";
                  document.getElementById("Condition_ck").innerHTML="";
//                  CycRadio(26,'��ֵ,��ֵ��ż,��ֵ��С,��ֵDZX,��ֵ012·,��ֵ�ʺ�,��ֵ����,��ֵ����,��ֵ���ڲ�,��ֵ���ں�,��ֵ���ں�,��ֵ���,��ֵ���,��ֵ3����,��ֵ4����,��ֵ5����,��ֵ6����,��ֵ7����,��ֵ8����,��ֵ��©β,��ֵ��©β��ż,��ֵ��©β��С,��ֵ��©βDZX,��ֵ��©β012·,��ֵ��©β�ʺ�,��ֵ���Ի��ž���');
                  CycRadio(3,'��ֵ��ż,��ֵ��С,��ֵ012·') 
            }
            if(type=="���")
            {
               document.getElementById("gut").style.display="block";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
//                CycRadio(20,'���,�����ż,��ȴ�С,���DZX,���012·,����ʺ�,��Ⱦ���,��Ȼ���,������ڲ�,������ں�,������ں�,������,������,�����©β,�����©β��ż,�����©β��С,�����©βDZX,�����©β012·,�����©β�ʺ�,������Ի��ž���');
               CycRadio(3,'�����ż,��ȴ�С,���012·');  
                return;
            }
            if(type=="��ż")
            {
                  document.getElementById("Condition_Rad").innerHTML="";
                  document.getElementById("Condition_ck").innerHTML="";
                   document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut").style.display="none";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                CycRadio(5,'��������,ż������,��ż����,��ż����ֵ,��ż��');
            }
            if(type=="��λ��ʽ")
            {
                document.getElementById("Condition_Rad").innerHTML="";
                document.getElementById("Condition_ck").innerHTML="";
                document.getElementById("gut").style.display="block";
               document.getElementById('gut_1').style.display="none";
                document.getElementById("gut_pl5").style.display="none";
                document.getElementById("gut_7xc").style.display="none";
                document.getElementById("gut_colligate_3D").style.display="none";
                addRadio1('�������','��һ����','');
                 return;
            }
            if(type=="�ۺ�����")
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
        if(lottery=="˫ɫ��")
        {
            if(type=="������")
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
            if(type=="������")
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
            if(type=="�ۺ�����")
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
        if(lottery=="���ֲ�")
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
        if(lottery=="���ǲ�")
        {
            if(type=="��λ����")
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
        if(lottery=="����͸")
        {
            if(type=="")
            {
                
            }
        }
        if(lottery=="����5")
        {
            if(type=="��λ����")
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
            if(type=="����")
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
//****************end�ύ��֤����*******************
    
    //**********begin��֤���������ֻ������ִ�,��****************
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
    //�ж���������Ϊ�պ͸�ʽ�Ƿ���ȷ
    function TextValidate(text)
    {
       //��֤����ĸ�ʽ �Ƿ���ȷ�� �Ƿ�Ϊ��
       if(text=="" || text=="undefined" || text==null)
       {
           return false;
       }
       else
       {
           return Rex(text);
       }
    }
    //************�滻���лس�*****************
        //�滻���еĻس�����   
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
    
    //*************************8����������arrqy:�������
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
    
    //***********beginð���㷨 array:���������**************
    function maopao(array)
    {
              //ð���㷨����������
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
    //**********************��ȡ�ַ������ַ���Ϊ���֣� ��λ ���֡�(3D��ѡ����) state:��ʶ
    function TwoNum(num,state)
    {
        var array=new Array;
        var getArray=new Array;
        var str_a_b;
        var str="";
        var swap="";
        if(state=="����")
        {
                var arr=new Array;
                var arr1=new Array;
                swap= TransferString(num);
                var pm="";
                for(var i=0;i<swap.split("<br>").length;i++)
                { 
                     
                    //ȥ���ظ�Ԫ��/ȥ���ַ����еģ���/��
                    arr[i]=swap.split("<br>")[i].replace(/[,|/]/g,"");
                }    
                arr1=unique(arr);    
                for(var j=0;j<arr1.length;j++)
                {
                    str="";
                    //ȥ���ظ�����
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
        if(state=="��ѡ����")
        {
            //�滻�س�
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                arr[i]=swap.split("<br>")[i];
            }
            //ȥ���ظ�
            for(var j=0;j<arr.length;j++)
            {
                str+=(arr[j].replace(/\//g,"")).replace(/,/g,"");
            }
               var  a_lenth=RemoveRepeat(str);
               var len=parseInt(a_lenth.length/2);
               for(var i = 0; i < len; i++)
               {
                 //��2Ϊ����д������
                   array[i]=a_lenth.substring(0,2);
                   //�׳����һ����
                   a_lenth=a_lenth.substring(2);
               }

                return array;
                

        }
        if(state=="��ѡ����")
        {
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                arr[i]=swap.split("<br>")[i];
            }
            //ȥ���ظ�
            for(var j=0;j<arr.length;j++)
            {
                str+=(arr[j].replace(/\//g,"")).replace(/,/g,"");
            }
            var a_len=RemoveRepeat(str);
            var a_lenth=parseInt(RemoveRepeat(str).length/2);
            for(var i = 0; i < a_lenth; i++)
            {
               //��2Ϊ����д������
               array[i]=a_len.substring(0,2);
               //�׳����һ����
               a_len=a_len.substring(2);
            }  
            return  unique(array);
        }
        if(state=="�������")
        {
            //ÿ��������<br\>����
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                  arr[i]=swap.split('<br>')[i];
                  //ƥ������
                  if(arr[i].replace(/^[0-9]*[1-9][0-9]*$/,"")=="")
                  {
                        pm+="��'"+ i +"'��"+RemoveRepeat(arr[i])+"|";
                  }
                  else
                  {
                        alert('����������������Ƕ�����롣����ÿ�������ûس�');
                        return false;
                  }   
//                //ȥ��ÿһ�������еģ��ź�/��
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
        if(state=="��һ����")
        {
            //�滻�س�
            swap= TransferString(num);
            var pm="";
            var arr=new Array;
            var arr1=new Array;
            for(var i=0;i<swap.split("<br>").length;i++)
            {  
                arr[i]=swap.split("<br>")[i];
            }
            //ȥ���ظ�
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
    
   //*******************ȥ�������е��ظ�ֵ(ȥ����������ͬԪ�ص�ֵArray('12','32','12'))***
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
    //***********beginȥ���ַ����е��ظ�����*******************
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
    
    //**************��ȡ��������ɾ��cookie  begin*************************
        //д��cookie 
        function setCookie(name,value,days){ 
            var exp=new Date(); 
            exp.setTime(exp.getTime()+days*24*60*60*1000); 
            document.cookie=name+"="+escape(value)+";expires="+exp.toGMTString(); 
        } 
        //��ȡcookie 
        function getCookie(name){ 
            var arr=document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)")); 
            if(arr!=null) 
              return unescape(arr[2]); 
            return null; 
        } 

        //ɾ��cookie 
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
    
    //*************ȥ���ַ�����λ�ո� begin*************************
        function trim(str){ //ɾ���������˵Ŀո�
����     return str.replace(/(^\s*)|(\s*$)/g, "");
����     }
����     function ltrim(str){ //ɾ����ߵĿո�
����         return str.replace(/(^\s*)/g,"");
����     }
����     function rtrim(str){ //ɾ���ұߵĿո�
����         return str.replace(/(\s*$)/g,"");
����     }

    //******************ȥ���ַ�����β�ո� end**********************
       
    //*****����ı���ѡ����*************begion
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
//Ϊ�ı���������ֵ
function checktag(o){
  var tagid = function(id){return document.getElementById(id);}
  var tags = [];//��ű�ǩ,�����ظ�����
  var tagidSPLITCHAR = ' ';//�趨�ָ���,���ݳ�������ɸ�
  var d = tagid('selecttags');
  if (d.value)
    tags = d.value.split(tagidSPLITCHAR);
  var v = o.innerHTML;//���tag�б��ֵ���߱�ķ�innerHTML�����ֵ�����
    var s = tagidSPLITCHAR+tags.join(tagidSPLITCHAR)+tagidSPLITCHAR
    if (!new RegExp(tagidSPLITCHAR+v+tagidSPLITCHAR,'g').test(s)){
      s+=v;
    }
    s = s.replace(new RegExp("(^"+tagidSPLITCHAR+"*|"+tagidSPLITCHAR+"*tagid)","g"),'');
    d.value = s;
    tags = s.split(tagidSPLITCHAR);//ѡ���ı�����ȡ����ֵ
    alert(tags);
}
//**********************************end***********

//*********************begin�����������************************
 //����������ĺ�����ͨ��      
  function DateDiff(sDate1,sDate2){  
     //sDate1��sDate2��yyyy-mm-dd��ʽ       
    var aDate, oDate1, oDate2, iDays;   
    aDate = sDate1.split("-"); 
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);  //ת��Ϊdd-mm-yyyy��ʽ     
    aDate = sDate2.split("-");     
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);     
   // alert(oDate1 - oDate2)     
    iDays = parseInt((oDate2 - oDate1) / 1000 / 60 / 60 /24);  //�����ĺ�����ת��Ϊ����     
    return  iDays;    
  } 
//***********************end************************    


