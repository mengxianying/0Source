    function setHref(aid,type)
    {
        var result ="";
        var xml;
        if(window.ActiveXObject)
        {
         //获得操作的xml文件的对象
            xml = new ActiveXObject('Microsoft.XMLDOM');                
            xml.async = false;
            xml.load("xml/WebDomainConfig.xml");
            if(xml == null)
            {
              alert('您的浏览器不支持xml文件读取,于是本页面禁止您的操作,推荐使用IE5.0以上可以解决此问题!');
              window.location.href='/Index.aspx';
              return;
            }
        }
     //解析xml文件，判断是否出错
        if(xml.parseError.errorCode != 0)
        {
           alert(xml.parseError.reason);
           return;
        }  
        if(type == 'www')
        {
            result = xml.documentElement.selectNodes("/Root/WwwUrl")[0].getAttribute("value"); //取属性  
        }
        else if(type == 'bar')
        {
            result = xml.documentElement.selectNodes("/Root/BarUrl")[0].getAttribute("value"); //取属性 
        }
        else if(type == 'chat')
        {
             result = xml.documentElement.selectNodes("/Root/ChatUrl")[0].getAttribute("value"); //取属性 
        }
          
        var myIds = aid.split('|');
        for(i =0;i<myIds.length;i++)
        {
            alert(result);
            document.getElementById(myIds[i]).href = result;                 
        }        
        //document.getElementById(aid).href = result;
        //删除对象                        
        delete(xml);                        
    }