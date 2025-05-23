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
    function CheckYZM1(myText, type, myId, ok, error) {
        if (event.keyCode == 13) {

            if (myId != '') {

                document.getElementById(myId).click();
            }
        }
        else {
            createHTTP();
            xmlhttp.open("GET", "/reg.aspx?keyUpCheckVerifyCode=" + myText + "&type=2", true);
            xmlhttp.onreadystatechange = function () { VerifyCodeStateDo(ok, error) };
            xmlhttp.send(null);
        }
    } 
    
    ///判断用户名是否被占用
    function CheckUser(user)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?checkUserName="+escape(user),true);
       xmlhttp.onreadystatechange = function(){UserStatedo()};
       xmlhttp.send(null);  
    }
    
    function  UserStatedo()
    {
       if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
       {
            if(xmlhttp.responsetext != "")
            {
                alert(xmlhttp.responsetext);
            }
            
       }
    }
    
    ///判断Email是否被占用
    function CheckEmail(email)
    {
       createHTTP();
       xmlhttp.open("GET","/reg.aspx?checkUserEmail="+escape(email),true);
       xmlhttp.onreadystatechange = function(){UserStatedo()};
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
     
     
    
    //新闻搜索
    function newsSearch()
    {   
        createHTTP();           
        var strContent = document.getElementById("txtSearch").value;       
        xmlhttp.open("POST","/reg.aspx?strSearch="+escape(strContent),true);
        xmlhttp.onreadystatechange=function(){searchResult()};
        xmlhttp.send();        
    }
    function bulletinSearch()
    {      
        createHTTP();           
        var strContent = document.getElementById("txtSearchKey").value;       
        xmlhttp.open("POST","/reg.aspx?strBulletin="+escape(strContent),true);
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
                window.open(resultUrl);
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
    
    function CheckYZM(myText,type,myId,ok,error)
    {           
        if(event.keyCode==13)
        {
            if(myId != '')
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
    
 
    
    
