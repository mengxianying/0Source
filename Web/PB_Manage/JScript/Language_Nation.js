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
    
    function SoftwareTypeChange(f_controlid, controlid,type)
    {
       document.getElementById(controlid).options.length =0;
       xmlhttp.open("GET","/PB_Manage/CST/GetInstallType.aspx?SoftwareType="+type,true);
       xmlhttp.onreadystatechange = function(){provincestatedo(controlid)};
       xmlhttp.send(null);  
    }
    
    function RegTypeChange(f_controlid, controlid,type)
    {
       document.getElementById(controlid).options.length =0;
       var install =  document.getElementById(controlid);            
       if(type =='8')
       {
          install.options.add(new Option('三个月','三个月'));
          install.options.add(new Option('六个月','六个月'));
          install.options.add(new Option('一年','一年'));
          install.options.add(new Option('按天计算','每天'));
       }
       else if(type=='1' || type=='9' )
       {
            install.options.add(new Option('一年','一年'));
            install.options.add(new Option('终身','终身'));
       }
       else 
       {
        install.options.add(new Option('所有',''));
       }
    }
    
    function provincestatedo(controlid)
    {
        if(xmlhttp.readyState ==4 && xmlhttp.status ==200)
        {
            var data = xmlhttp.responsetext;
            var all = data.split(",");
            var install =  document.getElementById(controlid);           
                for(i =0;i<all.length;i++)
                {
                    var oOption = document.createElement("OPTION");
                    oOption.text=all[i].split("&")[0];
                    oOption.value=all[i].split("&")[1];                   
                    install.add(oOption);              
                }         
        }
        
    }
    function statedo()
    {
        if(xmlhttp.readyState==4 && xmlhttp.status==200)
        {
            var con = document.getElementById('l_Nation');            
            var data = xmlhttp.responsetext;
            var all = data.split(",");
            for(i = 0;i < all.length;i++)
            {
             var   oOption   =   document.createElement("OPTION");   
                      oOption.text=all[i].split("&")[0];   
                      oOption.value= all[i].split("&")[1];
                      document.form1.l_Nation.add(oOption);                  
            }
        }
    }
    
    function checkUser(uname)
    {
                
                xmlhttp.open("GET","CheckUserName.aspx?uname="+uname,true);
                xmlhttp.onreadystatechange=function(){userName()};
                xmlhttp.send(null);
        
    }
    function checkEmail(email1)
    {              
                xmlhttp.open("GET","CheckUserEmail.aspx?email="+email1,true);
                xmlhttp.onreadystatechange=function(){email()};
                xmlhttp.send(null);
        
    }
    function email()
    {
        var pp = document.getElementById("emaildiv");
        if(xmlhttp.readystate==4 && xmlhttp.status==200)
        {
            pp.innerHTML = xmlhttp.responseText;
        }
    }
    
    function userName()
    {
        	var pp=document.getElementById("M_UserName");
            if(xmlhttp.readyState==4 && xmlhttp.status==200)
            {
	            pp.innerHTML = xmlhttp.responseText;
	        }
    }
    
    window.setTimeout('createHTTP()',500);