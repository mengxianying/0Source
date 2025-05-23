// JScript 文件
    var xmlhttp;
    function createHTTP()
    {
        if(window.ActiveXObject)
        {
            xmlhttp=new ActiveXObject("Microsoft.XMLHTTP"); //IE浏览器中创建异步调用对象
        }
        else if(window.XMLHttpRequest)
        {
            xmlhttp=new XMLHttpRequest(); //Firefox中创建异步调用对象
        }
    }
    
    function CheckIsBroker()
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?CheckIsBroker=abc",true);
       xmlhttp.onreadystatechange = function(){BrokerStateDo()};
       xmlhttp.send(null);          
    }
    function BrokerStateDo()
    {
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {
       
            if(xmlhttp.responsetext == "broker")
            {
             alert('您已经申请过经纪人了，不能重复申请！');
            }
            else
            {
             top.location.href='/Broker_Agrt.aspx';
            }
       }
    }
    
  function CheckIsDaili()
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?CheckIsDaili=abc",true);
         xmlhttp.onreadystatechange = function(){DailiStateDo()};
       xmlhttp.send(null);          
    }
    function DailiStateDo()
    {        
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {
            if(xmlhttp.responsetext == "daili")
            {           
                 alert('您申请过代理了，不能重复申请！');
            }
            else
            {
                 location.href='/UserCenter/shengqing.aspx';
            }
       }
    }
    ///判断用户名是否被占用
    function CheckUser(user,myId)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?checkUserName="+escape(user),true);
       xmlhttp.onreadystatechange = function(){UserStatedo(myId)};
       xmlhttp.send(null);  
    }
    
    function  UserStatedo(myId)
    {
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {
            document.getElementById(myId).innerHTML =xmlhttp.responsetext; 
       }
    }
    
    ///判断输入的用户名是否正确
    function CheckUserInput(user,myId)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?checkUserNameInput="+escape(user),true);
       xmlhttp.onreadystatechange = function(){UserStatedoInput(myId)};
       xmlhttp.send(null);  
    }
    
    function  UserStatedoInput(myId)
    {
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {
           if(xmlhttp.responsetext=="true")
           {
                document.getElementById("imgOK").style.display = ""; 
                document.getElementById("imgError").style.display = "none"; 
                document.getElementById(myId).innerHTML =""; 
           }
           else
           {
                document.getElementById("imgOK").style.display = "none"; 
                document.getElementById("imgError").style.display = ""; 
                document.getElementById(myId).innerHTML =xmlhttp.responsetext; 
           }
       }
    }
    
    
    ///判断Email是否被占用
    function CheckEmail(email,myId)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?checkUserEmail="+escape(email),true);
       xmlhttp.onreadystatechange = function(){UserStatedo(myId)};
       xmlhttp.send(null);  
    }
    
    
    
    //省选项改变的时候
    function provinceChange(controlid,type)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?province="+escape(type),true);
       xmlhttp.onreadystatechange = function(){provincestatedo(controlid)};
       xmlhttp.send(null);  
    }      
    function provincestatedo(mycontrol)
    {
        if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
        {
            var data = xmlhttp.responsetext;
            var all = data.split(",");
            var city = document.getElementById(mycontrol);      
            city.options.length = 0;          
            for(i =0;i<all.length;i++)
            {
                var oOption = document.createElement("OPTION");
                oOption.text=all[i].split("&")[0];
                oOption.value=all[i].split("&")[1];                    
                city.add(oOption);              
            }          
        }        
     }
     
    //拼搏吧问题大类改变得时候
    function bigTypeChange(controlid,type)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?bigType="+escape(type),true);
       xmlhttp.onreadystatechange = function(){provincestatedo1(controlid)};
       xmlhttp.send(null);  
    }
     
       
    function provincestatedo1(mycontrol)
    {
        if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
        {
            var data = xmlhttp.responsetext;
            var all = data.split(",");
            var city = document.getElementById(mycontrol);      
            city.options.length = 0;   
            
            var oOption0 = document.createElement("OPTION");
            oOption0.text='不选';
            oOption0.value='';                    
            city.add(oOption0);                    
            for(i =0;i<all.length;i++)
            {
                var oOption = document.createElement("OPTION");
                oOption.text=all[i].split("&")[0];
                oOption.value=all[i].split("&")[1];                    
                city.add(oOption);              
            }          
        }        
     }
            

     
     
    
    //新闻搜索
    function newsSearch()
    {   
        createHTTP();           
        var strContent1 = document.getElementById("txtSearch").value;  
        var strContent=strContent1.replace(/ /g,"");     
        xmlhttp.open("POST","/reg.aspx?strSearch="+escape(strContent),true);
        xmlhttp.onreadystatechange=function(){searchResult()};
        xmlhttp.send();        
    }
    function bulletinSearch()
    {      
        createHTTP();
        var strContent1 = document.getElementById("txtSearchKey").value;   
        var strContent =strContent1.replace(/ /g,"");     
        xmlhttp.open("POST","/reg.aspx?strBulletin="+escape(strContent),true);
        xmlhttp.onreadystatechange=function(){searchResult()};
        xmlhttp.send();        
    }
    //学院搜索
    function schoolSearch()
    {   
        createHTTP();           
        var strContent1 = document.getElementById("txtShool").value;  
        var strContent=strContent1.replace(/ /g,"");     
        xmlhttp.open("POST","/reg.aspx?strShool="+escape(strContent),true);
        xmlhttp.onreadystatechange=function(){searchResult()};
        xmlhttp.send();        
    }
    function searchResult()
    {      
        if(xmlhttp.readystate==4 && xmlhttp.status==200)
        {  
            var resultUrl = xmlhttp.responseText;           
            if(resultUrl.length > 0)
            {
                window.top.location = resultUrl;
            }
            else
            {
                alert("抱歉！没有找到相关内容！");      
                          
            }               
        }
    }
    
    function myTestM(name_pwd)
    {
        return name_pwd.split("|");
    }
    
    function SetMyTestM(para)
    {
        myTestM(para);
    }
    
    ////////////验证码√×（start）///////////////////////////////////////////////
    function CheckYZM(myText,type,myId,ok,error)
    {  
        if(event.keyCode==13)
        {
            if(myId !="")
            {
                document.getElementById(myId).click();
            }    
        }
        else
        {
            createHTTP();
            xmlhttp.open("GET","/reg.aspx?keyUpCheckVerifyCode="+myText+"&type="+type,true);
            xmlhttp.onreadystatechange = function(){VerifyCodeStateDo(ok,error)};
            xmlhttp.send(null);          
        }                
     }     
    function VerifyCodeStateDo(ok,error)
    {            
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {
           var kkk = xmlhttp.responseText;
           //alert(kkk);
           if (xmlhttp.responseText == "true")
            {
                document.getElementById(ok).style.display ="";
                document.getElementById(error).style.display ="none";
            }
            else
            {
                document.getElementById(ok).style.display ="none";
                document.getElementById(error).style.display ="";
            }            
       }
    } 
    ////////////验证码√×（end）///////////////////////////////////////////////
    
    /////////////////////检测上传权限（start）///////////////////////////////////////////////
    function CheckAdminUpload()
    {  
        createHTTP();
        xmlhttp.open("GET","/reg.aspx?CheckAdminUpload=meng",true);
        xmlhttp.onreadystatechange = function(){AdminUploadStateDo()};
        xmlhttp.send(null);                       
     }     
    function AdminUploadStateDo()
    {            
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {   
            if(xmlhttp.responseText=="true") {

                document.getElementById("btnUpload").style.display = ""; 

            }
            else
            {
                document.getElementById("btnUpload").style.display = "none";

            }            
       }
    }

    /////////////////////检测上传权限（end）/////////////////////////////////////////////// 


    
 
    
    
