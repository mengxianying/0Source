    function setHref(aid,type)
    {
        var result ="";
        var xml;
        if(window.ActiveXObject)
        {
         //��ò�����xml�ļ��Ķ���
            xml = new ActiveXObject('Microsoft.XMLDOM');                
            xml.async = false;
            xml.load("xml/WebDomainConfig.xml");
            if(xml == null)
            {
              alert('�����������֧��xml�ļ���ȡ,���Ǳ�ҳ���ֹ���Ĳ���,�Ƽ�ʹ��IE5.0���Ͽ��Խ��������!');
              window.location.href='/Index.aspx';
              return;
            }
        }
     //����xml�ļ����ж��Ƿ����
        if(xml.parseError.errorCode != 0)
        {
           alert(xml.parseError.reason);
           return;
        }  
        if(type == 'www')
        {
            result = xml.documentElement.selectNodes("/Root/WwwUrl")[0].getAttribute("value"); //ȡ����  
        }
        else if(type == 'bar')
        {
            result = xml.documentElement.selectNodes("/Root/BarUrl")[0].getAttribute("value"); //ȡ���� 
        }
        else if(type == 'chat')
        {
             result = xml.documentElement.selectNodes("/Root/ChatUrl")[0].getAttribute("value"); //ȡ���� 
        }
          
        var myIds = aid.split('|');
        for(i =0;i<myIds.length;i++)
        {
            alert(result);
            document.getElementById(myIds[i]).href = result;                 
        }        
        //document.getElementById(aid).href = result;
        //ɾ������                        
        delete(xml);                        
    }